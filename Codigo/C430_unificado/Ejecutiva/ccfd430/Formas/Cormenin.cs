using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class CORMENIN
        : System.Windows.Forms.Form
    {


        private void CORMENIN_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;

                this.Cursor = Cursors.Default;

            }

        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {

            this.Cursor = Cursors.WaitCursor;

            //Centra la forma
            this.Left = (int)VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(Screen.PrimaryScreen.Bounds.Width) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
            this.ID_MEN_SAL_CB.Focus();
            try
            {
                //Muestra los registros de la integración diaria
                Muestra_Datos();
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(Form_Load)", e);
            }

            this.ID_MEN_SAL_CB.Select();
            this.Cursor = Cursors.Default;


        }

        private void Muestra_Datos()
        {

            string pszNomArch = String.Empty;
            string pszMensaje = String.Empty;
            int iEstatus = 0;

            string pszMensajeMAP = String.Empty;
            bool bMAP = false;
            string pszAccion = String.Empty;
            string pszSituacion = String.Empty;
            string pszCadena = String.Empty;

            //Se inicializa el ListBox de Mensajes
            ID_MEN_MEN_LIB.Items.Clear();

            //Se inicializan los mensajes
            string pszMensajeTHS = CORVB.NULL_STRING;
            string pszMensajeHIH = CORVB.NULL_STRING;
            string pszMensajeHIS = CORVB.NULL_STRING;
            string pszMensajePLA = CORVB.NULL_STRING;
            string pszMensajeARA = CORVB.NULL_STRING;
            string pszMensajeSEG = CORVB.NULL_STRING;
            string pszMensajeNEG = CORVB.NULL_STRING;
            string pszMensajeACT = CORVB.NULL_STRING;
            string pszMensajeREN = CORVB.NULL_STRING;

            //Se inicializan las banderas
            bool bTHS = false;
            bool bHIH = false;
            bool bHIS = false;
            bool bPLA = false;
            bool bARA = false;
            bool bSEG = false;
            bool bNEG = false;
            bool bACT = false;
            bool bREN = false;

            //Se oculta la forma CORMENIN
            this.Hide();

            //Arma las sentencia SQL de consulta de mensajes
            CORVAR.pszgblsql = "select * ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "from MTCPRO01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where convert(varchar(10), pro_fecha, 103) = convert(varchar(10), getdate(), 103)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and pro_nomarch like ('D%')";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " order by pro_nomarch, pro_fecha";

            //Realiza la busqueda de mensajes en la taba MTCRRO01
            if (CORPROC2.Obtiene_Registros() != 0)
            {


                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {

                    //Inicializa las variabes
                    pszNomArch = CORVB.NULL_STRING;
                    iEstatus = CORVB.NULL_INTEGER;
                    pszMensaje = CORVB.NULL_STRING;
                    pszAccion = CORVB.NULL_STRING;
                    pszSituacion = CORVB.NULL_STRING;
                    pszCadena = new String(' ', 100);

                    //Obtiene los datos de Archivo, Estatus y Mensaje
                    pszNomArch = VBSQL.SqlData(CORVAR.hgblConexion, 1);
                    iEstatus = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 3));
                    pszMensaje = VBSQL.SqlData(CORVAR.hgblConexion, 4);

                    //Convierte a mayusculas
                    pszNomArch = pszNomArch.ToUpper();

                    //Decide la acción del estatus
                    if (iEstatus == 0)
                    { //Sin error
                        pszAccion = CORVB.NULL_STRING;
                        pszSituacion = "OK";
                    }
                    else if (iEstatus == 2)
                    {  //Problemas con el espacio del disco
                        pszAccion = "Problemas de espacio, hablar a Redes.";
                        pszSituacion = "ERROR";
                    }
                    else if (iEstatus == 1 || iEstatus >= 4 && iEstatus <= 19)
                    {  //Aviso a ingeniería
                        pszAccion = "Avisar a Ingeniería.";
                        pszSituacion = "ERROR";
                    }
                    else if (iEstatus >= 20 && iEstatus <= 29)
                    {  //Realizar reenvío
                        pszAccion = "Solicitar Reenvío.";
                        pszSituacion = "ERROR";
                    }
                    else
                    { //Cualquier otro error
                        pszAccion = "Avisar a Ingeniería.";
                        pszSituacion = "ERROR";
                    }


                    //----------Si se trata de ..., se arma e inserta el mensaje
                    //THS o TAR
                    if ((pszNomArch.IndexOf("TAR") + 1) > CORVB.NULL_INTEGER)
                    {
                        if (Strings.Mid(pszNomArch, pszNomArch.IndexOf("TAR") + 1, 3) == "TAR")
                        {
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 1, pszNomArch);
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 11, "TARJETAHABIENTES");
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 32, pszSituacion);
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 41, pszAccion);
                            if (iEstatus == CORVB.NULL_INTEGER && !bTHS)
                            {
                                ID_MEN_MEN_LIB.Items.Add(pszCadena);
                                bTHS = true;
                            }
                            else
                            {
                                pszMensajeTHS = pszCadena;
                            }
                        }
                    }

                    //HIH o HEA
                    if ((pszNomArch.IndexOf("HEA") + 1) > CORVB.NULL_INTEGER)
                    {
                        if (Strings.Mid(pszNomArch, pszNomArch.IndexOf("HEA") + 1, 3) == "HEA")
                        {
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 1, pszNomArch);
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 11, "HEADER HISTORICO");
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 32, pszSituacion);
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 41, pszAccion);
                            if (iEstatus == CORVB.NULL_INTEGER && !bHIH)
                            {
                                ID_MEN_MEN_LIB.Items.Add(pszCadena);
                                bHIH = true;
                            }
                            else
                            {
                                pszMensajeHIH = pszCadena;
                            }
                        }
                    }

                    //HIS o HST
                    if ((pszNomArch.IndexOf("HST") + 1) > CORVB.NULL_INTEGER)
                    {
                        if (Strings.Mid(pszNomArch, pszNomArch.IndexOf("HST") + 1, 3) == "HST")
                        {
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 1, pszNomArch);
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 11, "HISTORICO");
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 32, pszSituacion);
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 41, pszAccion);
                            if (iEstatus == CORVB.NULL_INTEGER && !bHIS)
                            {
                                ID_MEN_MEN_LIB.Items.Add(pszCadena);
                                bHIS = true;
                            }
                            else
                            {
                                pszMensajeHIS = pszCadena;
                            }
                        }
                    }

                    //NEG
                    if ((pszNomArch.IndexOf("NEG") + 1) > CORVB.NULL_INTEGER)
                    {
                        if (Strings.Mid(pszNomArch, pszNomArch.IndexOf("NEG") + 1, 3) == "NEG")
                        {
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 1, pszNomArch);
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 11, "NEGOCIOS");
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 32, pszSituacion);
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 41, pszAccion);
                            if (iEstatus == CORVB.NULL_INTEGER && !bNEG)
                            {
                                ID_MEN_MEN_LIB.Items.Add(pszCadena);
                                bNEG = true;
                            }
                            else
                            {
                                pszMensajeNEG = pszCadena;
                            }
                        }
                    }

                    //ARA
                    if ((pszNomArch.IndexOf("ARA") + 1) > CORVB.NULL_INTEGER)
                    {
                        if (Strings.Mid(pszNomArch, pszNomArch.IndexOf("ARA") + 1, 3) == "ARA")
                        {
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 1, pszNomArch);
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 11, "AREAS");
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 32, pszSituacion);
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 41, pszAccion);
                            if (iEstatus == CORVB.NULL_INTEGER && !bARA)
                            {
                                ID_MEN_MEN_LIB.Items.Add(pszCadena);
                                bARA = true;
                            }
                            else
                            {
                                pszMensajeARA = pszCadena;
                            }
                        }
                    }

                    //SGO
                    if ((pszNomArch.IndexOf("SGO") + 1) > CORVB.NULL_INTEGER)
                    {
                        if (Strings.Mid(pszNomArch, pszNomArch.IndexOf("SGO") + 1, 3) == "SGO")
                        {
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 1, pszNomArch);
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 11, "SEGMENTOS");
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 32, pszSituacion);
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 41, pszAccion);
                            if (iEstatus == CORVB.NULL_INTEGER && !bSEG)
                            {
                                ID_MEN_MEN_LIB.Items.Add(pszCadena);
                                bSEG = true;
                            }
                            else
                            {
                                pszMensajeSEG = pszCadena;
                            }
                        }
                    }

                    //ACD
                    if ((pszNomArch.IndexOf("ACD") + 1) > CORVB.NULL_INTEGER)
                    {
                        if (Strings.Mid(pszNomArch, pszNomArch.IndexOf("ACD") + 1, 3) == "ACD")
                        {
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 1, pszNomArch);
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 11, "ACTIVIDADES");
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 32, pszSituacion);
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 41, pszAccion);
                            if (iEstatus == CORVB.NULL_INTEGER && !bACT)
                            {
                                ID_MEN_MEN_LIB.Items.Add(pszCadena);
                                bACT = true;
                            }
                            else
                            {
                                pszMensajeACT = pszCadena;
                            }
                        }
                    }

                    //PLA o PLS
                    if ((pszNomArch.IndexOf("PLS") + 1) > CORVB.NULL_INTEGER)
                    {
                        if (Strings.Mid(pszNomArch, pszNomArch.IndexOf("PLS") + 1, 3) == "PLS")
                        {
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 1, pszNomArch);
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 11, "PLASTICOS");
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 32, pszSituacion);
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 41, pszAccion);
                            if (iEstatus == CORVB.NULL_INTEGER && !bPLA)
                            {
                                ID_MEN_MEN_LIB.Items.Add(pszCadena);
                                bPLA = true;
                            }
                            else
                            {
                                pszMensajePLA = pszCadena;
                            }
                        }
                    }


                    //REN
                    if ((pszNomArch.IndexOf("REN") + 1) > CORVB.NULL_INTEGER)
                    {
                        if (Strings.Mid(pszNomArch, pszNomArch.IndexOf("REN") + 1, 3) == "REN")
                        {
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 1, pszNomArch);
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 11, "RENTABILIDAD");
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 32, pszSituacion);
                            pszCadena = StringsHelper.MidAssignment(pszCadena, 41, pszAccion);
                            if (iEstatus == CORVB.NULL_INTEGER && !bREN)
                            {
                                ID_MEN_MEN_LIB.Items.Add(pszCadena);
                                bREN = true;
                            }
                            else
                            {
                                pszMensajeREN = pszCadena;
                            }
                        }
                    }


                    //REN
                    //if ((pszNomArch.IndexOf("ATM") + 1) > CORVB.NULL_INTEGER)
                    //{
                    //    if (Strings.Mid(pszNomArch, pszNomArch.IndexOf("ATM") + 1, 3) == "ATM")
                    //    {
                    //        pszCadena = StringsHelper.MidAssignment(pszCadena, 1, pszNomArch);
                    //        pszCadena = StringsHelper.MidAssignment(pszCadena, 11, "MAESTRO");
                    //        pszCadena = StringsHelper.MidAssignment(pszCadena, 32, pszSituacion);
                    //        pszCadena = StringsHelper.MidAssignment(pszCadena, 41, pszAccion);
                    //        if (iEstatus == CORVB.NULL_INTEGER && ! bREN)
                    //        {
                    //            ID_MEN_MEN_LIB.Items.Add(pszCadena);
                    //            bREN = true;
                    //        } else
                    //        {
                    //            pszMensajeREN = pszCadena;
                    //        }
                    //    }
                    //}


                    //EMAP
                    if ((pszNomArch.IndexOf("MAP") + 1) > CORVB.NULL_INTEGER)
                    {
                        if (Strings.Mid(pszNomArch, pszNomArch.IndexOf("MAP") + 1, 3) == "MAP")
                        {
                            if (Conversion.Val(pszNomArch.Trim().Substring(pszNomArch.Trim().Length - Math.Min(pszNomArch.Trim().Length, 4))) <= 0)
                            {
                                pszCadena = StringsHelper.MidAssignment(pszCadena, 1, pszNomArch);
                                pszCadena = StringsHelper.MidAssignment(pszCadena, 11, "CUENTAS ESPEJO");
                                pszCadena = StringsHelper.MidAssignment(pszCadena, 32, pszSituacion);
                                pszCadena = StringsHelper.MidAssignment(pszCadena, 41, pszAccion);
                                if (iEstatus == CORVB.NULL_INTEGER && !bMAP)
                                {
                                    ID_MEN_MEN_LIB.Items.Add(pszCadena);
                                    bMAP = true;
                                }
                                else
                                {
                                    pszMensajeMAP = pszCadena;
                                }
                            }
                            else if (Conversion.Val(pszNomArch.Trim().Substring(pszNomArch.Trim().Length - Math.Min(pszNomArch.Trim().Length, 4))) > 0)
                            {
                                bMAP = false;
                                pszCadena = StringsHelper.MidAssignment(pszCadena, 1, pszNomArch);
                                pszCadena = StringsHelper.MidAssignment(pszCadena, 11, "CUENTAS ESPEJO");
                                pszCadena = StringsHelper.MidAssignment(pszCadena, 32, pszSituacion);
                                pszCadena = StringsHelper.MidAssignment(pszCadena, 41, pszAccion);
                                if (iEstatus == CORVB.NULL_INTEGER && !bMAP)
                                {
                                    ID_MEN_MEN_LIB.Items.Add(pszCadena);
                                    bMAP = true;
                                }
                                else
                                {
                                    pszMensajeMAP = pszCadena;
                                }
                            }
                        }
                    }



                    //Guarda los mensajes diferentes a las tablas anteriores
                    if ((pszNomArch.IndexOf("PLS") + 1) == CORVB.NULL_INTEGER &&
                        (pszNomArch.IndexOf("TAR") + 1) == CORVB.NULL_INTEGER &&
                        (pszNomArch.IndexOf("HEA") + 1) == CORVB.NULL_INTEGER &&
                        (pszNomArch.IndexOf("HST") + 1) == CORVB.NULL_INTEGER &&
                        (pszNomArch.IndexOf("NEG") + 1) == CORVB.NULL_INTEGER &&
                        (pszNomArch.IndexOf("ARA") + 1) == CORVB.NULL_INTEGER &&
                        (pszNomArch.IndexOf("SGO") + 1) == CORVB.NULL_INTEGER &&
                        (pszNomArch.IndexOf("ACD") + 1) == CORVB.NULL_INTEGER &&
                        (pszNomArch.IndexOf("REN") + 1) == CORVB.NULL_INTEGER &&
                        (pszNomArch.IndexOf("EMAP") + 1) == CORVB.NULL_INTEGER)
                    {

                        pszCadena = StringsHelper.MidAssignment(pszCadena, 1, pszNomArch);
                        pszCadena = StringsHelper.MidAssignment(pszCadena, 11, "------------");
                        pszCadena = StringsHelper.MidAssignment(pszCadena, 32, pszSituacion);
                        pszCadena = StringsHelper.MidAssignment(pszCadena, 41, "ERROR DESCONOCIDO");

                        ID_MEN_MEN_LIB.Items.Add(pszCadena);

                    }

                };

                //Guarda los ultimos mensajes que son diferente de OK
                //THS
                if (pszMensajeTHS != CORVB.NULL_STRING && !bTHS)
                {
                    ID_MEN_MEN_LIB.Items.Add(pszMensajeTHS);
                }

                //HIH
                if (pszMensajeHIH != CORVB.NULL_STRING && !bHIH)
                {
                    ID_MEN_MEN_LIB.Items.Add(pszMensajeHIH);
                }

                //HIS
                if (pszMensajeHIS != CORVB.NULL_STRING && !bHIS)
                {
                    ID_MEN_MEN_LIB.Items.Add(pszMensajeHIS);
                }

                //NEG
                if (pszMensajeNEG != CORVB.NULL_STRING && !bNEG)
                {
                    ID_MEN_MEN_LIB.Items.Add(pszMensajeNEG);
                }

                //PLA
                if (pszMensajePLA != CORVB.NULL_STRING && !bPLA)
                {
                    ID_MEN_MEN_LIB.Items.Add(pszMensajePLA);
                }

                //SEG
                if (pszMensajeSEG != CORVB.NULL_STRING && !bSEG)
                {
                    ID_MEN_MEN_LIB.Items.Add(pszMensajeSEG);
                }
                //ACT
                if (pszMensajeACT != CORVB.NULL_STRING && !bACT)
                {
                    ID_MEN_MEN_LIB.Items.Add(pszMensajeACT);
                }
                //ARA
                if (pszMensajeARA != CORVB.NULL_STRING && !bARA)
                {
                    ID_MEN_MEN_LIB.Items.Add(pszMensajeARA);
                }

                //REN
                if (pszMensajeREN != CORVB.NULL_STRING && !bREN)
                {
                    ID_MEN_MEN_LIB.Items.Add(pszMensajeREN);
                }

            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            //Muestra la ventana de los mensajes
            //AIS-1199 NGONZALEZ
            this.ID_MEN_SAL_CB.Select();
            this.ShowDialog();
            //VB6.ShowForm(this, (int) CORVB.MODAL, this);
            //Se cierra la conexión
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

        }

        private void ID_MEN_SAL_CB_Click(Object eventSender, EventArgs eventArgs)
        {

            //Oculta la forma para descargarla donde se hizo el show
            this.Hide();

        }
        private void CORMENIN_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}