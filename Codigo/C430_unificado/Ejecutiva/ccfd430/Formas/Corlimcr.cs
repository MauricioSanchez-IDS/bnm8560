using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class CORLIMCR
        : System.Windows.Forms.Form
    {

        private void CORLIMCR_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != this)
            {
                ActivateHelper.myActiveForm = this;
            }
        }

        public void Obten_Inconsistencias(ListBox lstControl)
        {

            string pszCadena = String.Empty;
            string pszMonto = String.Empty;
            int iLenMonto = 0;

            //Realiza la busqueda de limites desbordadosen la taba MTCOR01 (Corporativos)
            if (CORPROC2.Obtiene_Registros() != 0)
            {

                iLenMonto = 14;
                lstControl.Items.Clear();


                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {

                    pszCadena = new String(' ', 100);

                    //Obtiene los datos de Archivo, Estatus y Mensaje
                    pszCadena = StringsHelper.MidAssignment(pszCadena, 1, StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 1), "00000"));
                    pszCadena = StringsHelper.MidAssignment(pszCadena, 7, VBSQL.SqlData(CORVAR.hgblConexion, 2));
                    pszMonto = StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 3), "###,###,###,###,##0");
                    pszCadena = StringsHelper.MidAssignment(pszCadena, 46, new String(' ', iLenMonto - pszMonto.Length) + pszMonto);
                    pszMonto = StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 4), "###,###,###,###,##0");
                    pszCadena = StringsHelper.MidAssignment(pszCadena, 62, new String(' ', iLenMonto - pszMonto.Length) + pszMonto);

                    lstControl.Items.Add(pszCadena);

                };
            }
            else
            {
                lstControl.Items.Clear();
            }

            //Se cierra la conexión
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {

            this.Cursor = Cursors.WaitCursor;

            //Centra la forma
            this.Left = (int)VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(Screen.PrimaryScreen.Bounds.Width) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);

            this.Cursor = Cursors.WaitCursor;

            //Actualiza los Límites de Crédito
            if (~CORPROC2.Actualiza_Limites_Credito() != 0)
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("Error al revisar los Límites de Crédito" + Strings.Chr(CORVB.KEY_RETURN).ToString() + "¿Desea dar de Alta ?", (MsgBoxStyle)(CORVB.MB_ICONQUESTION + CORVB.MB_YESNO), CORSTR.STR_APP_TIT);
                return;
            }

            try
            {
                //Muestra los Límites de Crédito Inconsistentes
                Muestra_Limites();
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(Form_Load)", e);
            }


            this.Cursor = Cursors.Default;

        }

        public void Muestra_Limites()
        {

            //Arma las sentencia SQL de consulta de inconsistencias de Corporativos
            CORVAR.pszgblsql = "select gpo_num, gpo_nom, gpo_cred_tot, gpo_acum_cred ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "from MTCCOR01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where gpo_cred_tot < gpo_acum_cred";

            CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco= " + CORVAR.igblBanco.ToString();

            //pszgblsql = pszgblsql + " group by gpo_num, gpo_nom"
            CORVAR.pszgblsql = CORVAR.pszgblsql + " order by gpo_num, gpo_nom";
            Obten_Inconsistencias(ID_LIM_COR_LIB);


            //Arma las sentencia SQL de consulta de inconsistencias de Empresas
            CORVAR.pszgblsql = "select emp_num, emp_nom, emp_cred_tot, emp_acum_cred ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "from MTCEMP01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where emp_cred_tot < emp_acum_cred";

            CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco= " + CORVAR.igblBanco.ToString();

            //pszgblsql = pszgblsql + " group by emp_num, emp_nom"
            CORVAR.pszgblsql = CORVAR.pszgblsql + " order by emp_num, emp_nom";
            Obten_Inconsistencias(ID_LIM_EMP_LIB);

        }

        private void ID_MEN_SAL_CB_Click(Object eventSender, EventArgs eventArgs)
        {

            //Descarga la Forma
            this.Close();

        }
        private void CORLIMCR_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}