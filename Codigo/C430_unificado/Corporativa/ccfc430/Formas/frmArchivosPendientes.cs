using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    internal partial class frmArchivosPendientes
        : System.Windows.Forms.Form
    {

        private void frmArchivosPendientes_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != this)
            {
                ActivateHelper.myActiveForm = this;
            }
        }
        private void cmdAceptar_Click(Object eventSender, EventArgs eventArgs)
        {
            try
            {

                if (LstArchivosPendientes.SelectedItem != null)
                {
                    if (LstArchivosPendientes.ListItems.Count > 0)
                    {
                        object tempRefParam = 1;
                        CCFmodGeneral.ESTATUS_ARCHIVO = LstArchivosPendientes.SelectedItem.ListSubItems.get_Item(ref tempRefParam).Text;
                        object tempRefParam2 = 5;
                        CCFmodGeneral.TAMANIO_ARCHIVO = LstArchivosPendientes.SelectedItem.ListSubItems.get_Item(ref tempRefParam2).Text;
                        CCFmodGeneral.NOMBRE_ARCHIVO = LstArchivosPendientes.SelectedItem.Text.Trim();
                        if (CCFmodGeneral.ESTATUS_ARCHIVO == "")
                        {
                            MessageBox.Show("Debe seleccionar algún archivo para su validación", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                            frmNivelEmpresa.DefInstance.ShowDialog();
                            LlenaLista();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existen Archivos Pendientes.", "TC C430", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(cmdAceptar_Click)", e);
            }
        }

        private void cmdCancelar_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Close();
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {
            string lsFecha = DateTime.Today.AddDays(-1).ToString();
            System.DateTime TempDate = DateTime.FromOADate(0);
            CCFmodGeneral.FECHA_PROCESO = (DateTime.TryParse(lsFecha, out TempDate)) ? TempDate.ToString("yyyyMMdd") : lsFecha;

            LlenaLista();

            //Checo qué tipo de periodo me solicitaron
            //If TIPO_PERIODO = 0 Then
            //    Carga_lsv
            //End If
        }

        private void LlenaLista()
        {
            ADODB.Recordset rs = null;

            //Llenar header
            LstArchivosPendientes.GridLines = true;

            object tempRefParam = Type.Missing;
            object tempRefParam2 = Type.Missing;
            object tempRefParam3 = "Nombre del Archivo";
            object tempRefParam4 = Type.Missing;
            object tempRefParam5 = Type.Missing;
            object tempRefParam6 = Type.Missing;
            LstArchivosPendientes.ColumnHeaders.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
            object tempRefParam7 = LstArchivosPendientes.ColumnHeaders.Count;
            LstArchivosPendientes.ColumnHeaders.get_Item(ref tempRefParam7).Width = (float)VB6.TwipsToPixelsX(150 * VB6.TwipsPerPixelX());
            object tempRefParam8 = Type.Missing;
            object tempRefParam9 = Type.Missing;
            object tempRefParam10 = "Status";
            object tempRefParam11 = Type.Missing;
            object tempRefParam12 = Type.Missing;
            object tempRefParam13 = Type.Missing;
            LstArchivosPendientes.ColumnHeaders.Add(ref tempRefParam8, ref tempRefParam9, ref tempRefParam10, ref tempRefParam11, ref tempRefParam12, ref tempRefParam13);
            object tempRefParam14 = LstArchivosPendientes.ColumnHeaders.Count;
            LstArchivosPendientes.ColumnHeaders.get_Item(ref tempRefParam14).Width = (float)VB6.TwipsToPixelsX(100 * VB6.TwipsPerPixelX());
            object tempRefParam15 = LstArchivosPendientes.ColumnHeaders.Count;
            LstArchivosPendientes.ColumnHeaders.get_Item(ref tempRefParam15).Alignment = MSComctlLib.ListColumnAlignmentConstants.lvwColumnCenter;
            object tempRefParam16 = Type.Missing;
            object tempRefParam17 = Type.Missing;
            object tempRefParam18 = "Fecha VoBo";
            object tempRefParam19 = Type.Missing;
            object tempRefParam20 = Type.Missing;
            object tempRefParam21 = Type.Missing;
            LstArchivosPendientes.ColumnHeaders.Add(ref tempRefParam16, ref tempRefParam17, ref tempRefParam18, ref tempRefParam19, ref tempRefParam20, ref tempRefParam21);
            object tempRefParam22 = LstArchivosPendientes.ColumnHeaders.Count;
            LstArchivosPendientes.ColumnHeaders.get_Item(ref tempRefParam22).Width = (float)VB6.TwipsToPixelsX(100 * VB6.TwipsPerPixelX());
            object tempRefParam23 = LstArchivosPendientes.ColumnHeaders.Count;
            LstArchivosPendientes.ColumnHeaders.get_Item(ref tempRefParam23).Alignment = MSComctlLib.ListColumnAlignmentConstants.lvwColumnCenter;
            object tempRefParam24 = Type.Missing;
            object tempRefParam25 = Type.Missing;
            object tempRefParam26 = "Fecha Envio";
            object tempRefParam27 = Type.Missing;
            object tempRefParam28 = Type.Missing;
            object tempRefParam29 = Type.Missing;
            LstArchivosPendientes.ColumnHeaders.Add(ref tempRefParam24, ref tempRefParam25, ref tempRefParam26, ref tempRefParam27, ref tempRefParam28, ref tempRefParam29);
            object tempRefParam30 = LstArchivosPendientes.ColumnHeaders.Count;
            LstArchivosPendientes.ColumnHeaders.get_Item(ref tempRefParam30).Width = (float)VB6.TwipsToPixelsX((100 * VB6.TwipsPerPixelX()));
            object tempRefParam31 = LstArchivosPendientes.ColumnHeaders.Count;
            LstArchivosPendientes.ColumnHeaders.get_Item(ref tempRefParam31).Alignment = MSComctlLib.ListColumnAlignmentConstants.lvwColumnCenter;
            object tempRefParam32 = Type.Missing;
            object tempRefParam33 = Type.Missing;
            object tempRefParam34 = "Fecha Confirmacion";
            object tempRefParam35 = Type.Missing;
            object tempRefParam36 = Type.Missing;
            object tempRefParam37 = Type.Missing;
            LstArchivosPendientes.ColumnHeaders.Add(ref tempRefParam32, ref tempRefParam33, ref tempRefParam34, ref tempRefParam35, ref tempRefParam36, ref tempRefParam37);
            object tempRefParam38 = LstArchivosPendientes.ColumnHeaders.Count;
            LstArchivosPendientes.ColumnHeaders.get_Item(ref tempRefParam38).Width = (float)VB6.TwipsToPixelsX((100 * VB6.TwipsPerPixelX()));
            object tempRefParam39 = LstArchivosPendientes.ColumnHeaders.Count;
            LstArchivosPendientes.ColumnHeaders.get_Item(ref tempRefParam39).Alignment = MSComctlLib.ListColumnAlignmentConstants.lvwColumnCenter;
            object tempRefParam40 = Type.Missing;
            object tempRefParam41 = Type.Missing;
            object tempRefParam42 = "Tamaño (KB)";
            object tempRefParam43 = Type.Missing;
            object tempRefParam44 = Type.Missing;
            object tempRefParam45 = Type.Missing;
            LstArchivosPendientes.ColumnHeaders.Add(ref tempRefParam40, ref tempRefParam41, ref tempRefParam42, ref tempRefParam43, ref tempRefParam44, ref tempRefParam45);
            object tempRefParam46 = LstArchivosPendientes.ColumnHeaders.Count;
            LstArchivosPendientes.ColumnHeaders.get_Item(ref tempRefParam46).Width = (float)VB6.TwipsToPixelsX(100 * VB6.TwipsPerPixelX());
            object tempRefParam47 = LstArchivosPendientes.ColumnHeaders.Count;
            LstArchivosPendientes.ColumnHeaders.get_Item(ref tempRefParam47).Alignment = MSComctlLib.ListColumnAlignmentConstants.lvwColumnCenter;


            if (VBSQL.OpenConn(11) == 0)
            { // se Conecto a la base
                object tempRefParam48 = ADODB.AffectEnum.adAffectAllChapters;
                rs = VBSQL.gConn[11].Execute("exec sp_CCFConsulta 1, null, null, null, null ", out tempRefParam48, -1);

                if (!(rs.BOF && rs.EOF))
                {
                    rs.MoveFirst();
                    LstArchivosPendientes.ListItems.Clear();
                    LstArchivosPendientes.Sorted = false;


                    while (!rs.EOF)
                    {
                        object tempRefParam49 = Type.Missing;
                        object tempRefParam50 = rs.Fields["nom_archivo"];
                        object tempRefParam51 = rs.Fields["nom_archivo"];
                        object tempRefParam52 = Type.Missing;
                        object tempRefParam53 = Type.Missing;
                        LstArchivosPendientes.ListItems.Add(ref tempRefParam49, ref tempRefParam50, ref tempRefParam51, ref tempRefParam52, ref tempRefParam53);
                        object tempRefParam54 = LstArchivosPendientes.ListItems.Count;
                        LstArchivosPendientes.ListItems.get_Item(ref tempRefParam54).set_SubItems(1, Convert.ToString(rs.Fields["CCF_estatus"].Value));
                        object tempRefParam55 = LstArchivosPendientes.ListItems.Count;
                        LstArchivosPendientes.ListItems.get_Item(ref tempRefParam55).set_SubItems(2, Convert.ToString(rs.Fields["fecha_VoBo"].Value));
                        object tempRefParam56 = LstArchivosPendientes.ListItems.Count;
                        LstArchivosPendientes.ListItems.get_Item(ref tempRefParam56).set_SubItems(3, Convert.ToString(rs.Fields["fecha_envio"].Value));
                        object tempRefParam57 = LstArchivosPendientes.ListItems.Count;
                        LstArchivosPendientes.ListItems.get_Item(ref tempRefParam57).set_SubItems(4, Convert.ToString(rs.Fields["fecha_confirmacion"].Value));
                        object tempRefParam58 = LstArchivosPendientes.ListItems.Count;
                        LstArchivosPendientes.ListItems.get_Item(ref tempRefParam58).set_SubItems(5, Convert.ToString(rs.Fields["tamanio"].Value));
                        object tempRefParam59 = LstArchivosPendientes.ListItems.Count;
                        LstArchivosPendientes.ListItems.get_Item(ref tempRefParam59).set_SubItems(2, (Convert.ToDateTime(rs.Fields["fecha_VoBo"].Value) != DateAndTime.DateSerial(1900, 1, 1)) ? StringsHelper.Format(rs.Fields["fecha_VoBo"].Value, CRSParametros.cteFormatoFecha) : "");
                        object tempRefParam60 = LstArchivosPendientes.ListItems.Count;
                        LstArchivosPendientes.ListItems.get_Item(ref tempRefParam60).set_SubItems(3, (Convert.ToDateTime(rs.Fields["fecha_envio"].Value) != DateAndTime.DateSerial(1900, 1, 1)) ? StringsHelper.Format(rs.Fields["fecha_envio"].Value, CRSParametros.cteFormatoFecha) : "");
                        object tempRefParam61 = LstArchivosPendientes.ListItems.Count;
                        LstArchivosPendientes.ListItems.get_Item(ref tempRefParam61).set_SubItems(4, (Convert.ToDateTime(rs.Fields["fecha_confirmacion"].Value) != DateAndTime.DateSerial(1900, 1, 1)) ? StringsHelper.Format(rs.Fields["fecha_confirmacion"].Value, CRSParametros.cteFormatoFecha) : "");

                        if (Convert.ToString(rs.Fields["CCF_estatus"].Value) == "Pendiente")
                        {
                            object tempRefParam62 = LstArchivosPendientes.ListItems.Count;
                            //AIS-380 NGONZALEZ
                            LstArchivosPendientes.ListItems.get_Item(ref tempRefParam62).ForeColor = Convert.ToUInt32(ColorTranslator.ToOle(Color.Red));

                            object tempRefParam63 = LstArchivosPendientes.ListItems.Count;
                            for (int i = 1; i <= LstArchivosPendientes.ListItems.get_Item(ref tempRefParam63).ListSubItems.Count; i++)
                            {
                                object tempRefParam64 = i;
                                object tempRefParam65 = LstArchivosPendientes.ListItems.Count;
                                //AIS-380 NGONZALEZ
                                LstArchivosPendientes.ListItems.get_Item(ref tempRefParam65).ListSubItems.get_ControlDefault(ref tempRefParam64).ForeColor = Convert.ToUInt32(ColorTranslator.ToOle(Color.Red));
                            }
                        }
                        else
                        {
                            object tempRefParam66 = LstArchivosPendientes.ListItems.Count;
                            //AIS-380 NGONZALEZ
                            //ais-1591 chidalgo
                            LstArchivosPendientes.ListItems.get_Item(ref tempRefParam66).ForeColor = 0x80000012;

                            object tempRefParam67 = LstArchivosPendientes.ListItems.Count;
                            for (int i = 1; i <= LstArchivosPendientes.ListItems.get_Item(ref tempRefParam67).ListSubItems.Count; i++)
                            {
                                object tempRefParam68 = i;
                                object tempRefParam69 = LstArchivosPendientes.ListItems.Count;
                                //AIS-380 NGONZALEZ
                                //ais-1591 chidalgo
                                LstArchivosPendientes.ListItems.get_Item(ref tempRefParam69).ListSubItems.get_ControlDefault(ref tempRefParam68).ForeColor = 0x80000012;
                            }
                        }
                        rs.MoveNext();
                    };
                }

                rs.Close();
                VBSQL.gConn[11].Close();
            }
            else
            {
                MessageBox.Show("No Existe ningun Archivo para su Validacion.", "CCF C430", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }





        public void Carga_lsv()
        {

            string strdato = String.Empty;
            CCFmodGeneral.IniciaHeaders();
            CCFmodGeneral.AddHeaderLst(this.LstArchivosPendientes, 6, CCFmodGeneral.gsArchivo, CCFmodGeneral.giArchivo);
            txtTipoProceso.Text = "PROCESO DIARIO";
            CORVAR.pszgblsql = "exec sp_CCFConsulta 1, null, null, null, null ";
            CCFmodGeneral.LlenaLst(this.LstArchivosPendientes, 6, ref CORVAR.pszgblsql);

            for (int intCont = 1; intCont <= LstArchivosPendientes.ListItems.Count; intCont++)
            {
                object tempRefParam4 = intCont;
                object tempRefParam5 = 1;
                object tempRefParam6 = intCont;
                if ((((String.CompareOrdinal(Strings.Mid(LstArchivosPendientes.ListItems.get_ControlDefault(ref tempRefParam4).Text, 4, 4), DateTime.Today.ToString("MMdd")) < 0) ? -1 : 0) & (LstArchivosPendientes.ListItems.get_ControlDefault(ref tempRefParam6).ListSubItems.get_Item(ref tempRefParam5).Text.Trim().IndexOf("Pendiente", StringComparison.CurrentCultureIgnoreCase) + 1)) != 0)
                {
                    for (int intContReg = 1; intContReg <= 5; intContReg++)
                    {
                        object tempRefParam = intContReg;
                        object tempRefParam2 = intCont;
                        //AIS-380 NGONZALEZ
                        LstArchivosPendientes.ListItems.get_ControlDefault(ref tempRefParam2).ListSubItems.get_Item(ref tempRefParam).ForeColor = Convert.ToUInt32(ColorTranslator.ToOle(Color.Red));
                    }
                    object tempRefParam3 = intCont;
                    //AIS-380 NGONZALEZ
                    LstArchivosPendientes.ListItems.get_ControlDefault(ref tempRefParam3).ForeColor = Convert.ToUInt32(ColorTranslator.ToOle(Color.Red));
                }
                LstArchivosPendientes.ForeColor = Color.Black;
            }
        }

        private void LstArchivosPendientes_DblClick(Object eventSender, EventArgs eventArgs)
        {
            cmdAceptar_Click(cmdAceptar, new EventArgs());
        }
        private void frmArchivosPendientes_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}