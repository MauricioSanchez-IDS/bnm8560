using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class RangosCats
        : System.Windows.Forms.Form
    {


        int iRow = 0;
        int iCol = 0;

        double dFrom = 0;
        double dTo = 0;

        int iRag_ID = 0;

        int iList = 0;

        private bool Inserta_Rango()
        {
            CORVAR.pszgblsql = "insert into MTCRAG01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + iRag_ID.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + "," + CORVAR.igblPref.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + "," + CORVAR.igblBanco.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + "," + Conversion.Val(Formato.IdEstruct).ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + "," + Conversion.Val(Strings.Mid(CORCTCATS.DefInstance.ID_CAT_LB.Text, 7, 4)).ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + "," + dFrom.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + "," + dTo.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + ")";
            if (CORPROC2.Modifica_Registro() == 1)
            {
                Llena_Lista(iRag_ID, dFrom, dTo);
                return true;
            }
            else
            {
                //    MsgBox "No se pudo dar de alta el rango", vbInformation + vbOKOnly, "tarjeta Corporativa"
                return false;
            }
        }

        private void Llena_Lista(int Rag_Id, double Rag_Ini, double Rag_Fin)
        {

            int iLen_RagId = Rag_Ini.ToString().Trim().Length;

            switch (iLen_RagId)
            {
                case 1:
                    LST_RAG.Items.Insert(iList, new String(' ', 5) + Rag_Ini.ToString() + new String(' ', 16) + Rag_Fin.ToString());
                    VB6.SetItemData(LST_RAG, iList, Rag_Id);
                    break;
                case 2:
                    LST_RAG.Items.Insert(iList, new String(' ', 5) + Rag_Ini.ToString() + new String(' ', 15) + Rag_Fin.ToString());
                    VB6.SetItemData(LST_RAG, iList, Rag_Id);
                    break;
                case 3:
                    LST_RAG.Items.Insert(iList, new String(' ', 5) + Rag_Ini.ToString() + new String(' ', 14) + Rag_Fin.ToString());
                    VB6.SetItemData(LST_RAG, iList, Rag_Id);
                    break;
                case 4:
                    LST_RAG.Items.Insert(iList, new String(' ', 5) + Rag_Ini.ToString() + new String(' ', 13) + Rag_Fin.ToString());
                    VB6.SetItemData(LST_RAG, iList, Rag_Id);
                    break;
                case 5:
                    LST_RAG.Items.Insert(iList, new String(' ', 5) + Rag_Ini.ToString() + new String(' ', 12) + Rag_Fin.ToString());
                    VB6.SetItemData(LST_RAG, iList, Rag_Id);
                    break;
            }
            iList++;
        }


        private bool Valida_Datos()
        {
            bool result = false;
            double iRegMcc = 0;
            int iRegMccFrom = 0;
            int iRegMccTo = 0;
            bool bMCC = false;
            bool bRag = false;

            if (Formato.sgForma == "A")
            { //Altas
                CORVAR.pszgblsql = "select";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " count(b06_acd_num_acd)";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCACT01";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where b06_acd_num_acd = " + dFrom.ToString();

                if (CORPROC2.Obtiene_Registros() != 0)
                {

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        iRegMccFrom = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    };
                }

                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                CORVAR.pszgblsql = "select";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " count(b06_acd_num_acd)";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCACT01";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where b06_acd_num_acd = " + dTo.ToString();

                if (CORPROC2.Obtiene_Registros() != 0)
                {

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        iRegMccTo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    };
                }

                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                if (iRegMccFrom == 1 && iRegMccFrom == 1)
                {
                    bMCC = true;
                    CORVAR.pszgblsql = "select ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " *";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCRAG01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where cat_eje_prefijo = " + CORVAR.igblPref.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and cat_gpo_banco = " + CORVAR.igblBanco.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and cat_exp_struct_id = " + Conversion.Val(Formato.IdEstruct).ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and cat_id = " + Conversion.Val(Strings.Mid(CORCTCATS.DefInstance.ID_CAT_LB.Text, 7, 4)).ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and cat_sic_from = " + dFrom.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and cat_sic_to = " + dTo.ToString();

                    if (CORPROC2.Cuenta_Registros() == 0)
                    {
                        bRag = true;
                        CORVAR.pszgblsql = "select ";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " max(cat_rag_id)";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCRAG01";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where cat_eje_prefijo = " + CORVAR.igblPref.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and cat_gpo_banco = " + CORVAR.igblBanco.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and cat_exp_struct_id = " + Conversion.Val(Formato.IdEstruct).ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and cat_id = " + Conversion.Val(Strings.Mid(CORCTCATS.DefInstance.ID_CAT_LB.Text, 7, 4)).ToString();

                        if (CORPROC2.Cuenta_Registros() >= 1)
                        {
                            if (CORPROC2.Obtiene_Registros() != 0)
                            {

                                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                {
                                    iRag_ID = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)) + 1);
                                };
                                if (iRag_ID > 25)
                                {
                                    MessageBox.Show("No se pueden dar de alta mas de 25 Rangos", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return false;
                                }
                            }
                        }
                    }
                    else
                    {
                        //MsgBox "Se encontro un rango similar dado de alta por lo que ya no se podra dar de alta", vbInformation + vbOKOnly, "Tarjeta Corporativa"
                        bRag = false;
                    }
                }
                else if (iRegMcc == 1)
                {
                    //MsgBox "Uno de los Rangos que proporcionaste no existe", vbInformation + vbOKOnly, "Tarjeta Corporativa"
                    bMCC = false;
                }
                else if (iRegMcc == 0)
                {
                    //MsgBox "Ninguno de los Rangos que proporcionaste existe", vbInformation + vbOKOnly, "Tarjeta Corporativa"
                    bMCC = false;
                }

                if (bMCC && bRag)
                {
                    result = true;
                }
                else if (!bMCC || !bRag)
                {
                    result = false;
                }

            }
            else if (Formato.sgForma == "B")
            {
                CORVAR.pszgblsql = "select";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " count(b06_acd_num_acd)";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCACT01";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where b06_acd_num_acd = " + dFrom.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " or b06_acd_num_acd = " + dTo.ToString();

                if (CORPROC2.Obtiene_Registros() != 0)
                {

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        iRegMcc = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1));
                    };
                }
                //UPGRADE_WARNING: (1068) iRegMcc of type Variant is being forced to double.
                //AIS-119 NGONZALEZ
                switch (Convert.ToInt32(iRegMcc))
                {
                    case 2:
                        bMCC = true;
                        break;
                    case 1:
                        //MsgBox "Uno de los Rangos que proporcionaste no existe", vbInformation + vbOKOnly, "Tarjeta Corporativa" 
                        bMCC = false;
                        break;
                    case 0:
                        //MsgBox "Ninguno de los Rangos que proporcionaste existe", vbInformation + vbOKOnly, "Tarjeta Corporativa" 
                        bMCC = false;
                        break;
                }
                if (bMCC)
                {
                    result = true;
                }
                else if (!bMCC)
                {
                    result = false;
                }
            }
            return result;
        }

        private void CMD_RAN_CAT_Click(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(CMD_RAN_CAT, eventSender);
            double dRagId = 0;
            //itsm
            string[,] dRangos = ArraysHelper.InitializeArray<string[,]>(new int[] { 25, 2 }, new int[] { 0, 0 });
            int iArr = 0;
            int nArr = 0;
            //***

            int iCont = 0;
            int iExCont = 0;
            try
            {
                switch (Index)
                {
                    case 0:
                        Formato.sgForma = "A";  //Altas 
                        //itsm 
                        for (double I = 1; I <= 25; I++)
                        {
                            ID_CEJ_PROD_SS.Row = Convert.ToInt32(I);
                            ID_CEJ_PROD_SS.Col = 1;
                            ID_CEJ_PROD_SS.Text = "";
                            ID_CEJ_PROD_SS.Col = 2;
                            ID_CEJ_PROD_SS.Text = "";
                        }
                        //*** 
                        Frame1[0].Visible = false;
                        Frame1[1].Visible = true;
                        ID_CEJ_PROD_SS.Col = 1;
                        ID_CEJ_PROD_SS.Row = 1;
                        break;
                    case 1:  //Baja 
                        if (MessageBox.Show("¿ Desea dar de baja el rango: " + LST_RAG.Text.Trim() + " ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (LST_RAG.Items.Count != -1)
                            {
                                if (ListBoxHelper.GetSelectedIndex(LST_RAG) != -1)
                                {
                                    dRagId = VB6.GetItemData(LST_RAG, ListBoxHelper.GetSelectedIndex(LST_RAG));
                                    CORVAR.pszgblsql = "delete MTCRAG01";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where cat_rag_id = " + dRagId.ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and cat_eje_prefijo = " + CORVAR.igblPref.ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and cat_gpo_banco = " + CORVAR.igblBanco.ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and cat_exp_struct_id = " + Conversion.Val(Formato.IdEstruct).ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and cat_id = " + Conversion.Val(Strings.Mid(CORCTCATS.DefInstance.ID_CAT_LB.Text, 7, 4)).ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and cat_sic_from = " + Conversion.Val(Strings.Mid(LST_RAG.Text, 6, 8)).ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and cat_sic_to = " + Conversion.Val(Strings.Mid(LST_RAG.Text, 23, 8)).ToString();
                                    if (CORPROC2.Modifica_Registro() == 1)
                                    {
                                        LST_RAG.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(LST_RAG));
                                        iList = LST_RAG.Items.Count;
                                        MessageBox.Show("Se dio de baja el Rango", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        //itsm
                                        //LST_RAG.ListIndex = 0
                                        return;
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se pudo dar de baja el Rango", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No se puede dar de Baja ningun rango porque aun no se ha seleccionado a alguno", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se puede dar de Baja ningun rango porque aun no existe alguno", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                        break;
                    case 2:
                        if (LST_RAG.Items.Count != -1)
                        {
                            if (ListBoxHelper.GetSelectedIndex(LST_RAG) != -1)
                            {
                                Formato.sgForma = "B";
                                dFrom = Conversion.Val(Strings.Mid(LST_RAG.Text, 6, 8));
                                dTo = Conversion.Val(Strings.Mid(LST_RAG.Text, 23, 8));
                                iCol = 1;
                                iRow = 1;
                                ID_CEJ_PROD_SS.Col = iCol;
                                ID_CEJ_PROD_SS.Row = iRow;
                                ID_CEJ_PROD_SS.Text = dFrom.ToString();
                                iCol = 2;
                                ID_CEJ_PROD_SS.Col = iCol;
                                ID_CEJ_PROD_SS.Text = dTo.ToString();
                                Frame1[0].Visible = false;
                                Frame1[1].Visible = true;
                            }
                            else
                            {
                                MessageBox.Show("No se puede realizar ningun cambio porque aun no se ha seleccionado a alguno", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se puede dar de Baja ningun rango porque aun no existe alguno", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        break;
                    case 3:
                        this.Close();

                        // Aceptar alta 
                        break;
                    case 4:
                        if (Formato.sgForma == "A")
                        {
                            iCol = 1;
                            iRow = 1;
                            iArr = 1;
                            nArr = 1;

                            ID_CEJ_PROD_SS.Col = iCol;
                            ID_CEJ_PROD_SS.Row = iRow;


                            while (ID_CEJ_PROD_SS.Text != "")
                            {
                                if (ID_CEJ_PROD_SS.Text != "")
                                {
                                    dFrom = Double.Parse(ID_CEJ_PROD_SS.Text);
                                    //itsm
                                    //ID_CEJ_PROD_SS.Text = ""
                                }
                                iCol = 2;
                                ID_CEJ_PROD_SS.Col = iCol;
                                if (ID_CEJ_PROD_SS.Text != "")
                                {
                                    dTo = Double.Parse(ID_CEJ_PROD_SS.Text);
                                    //itsm
                                    //ID_CEJ_PROD_SS.Text = ""
                                }

                                if (dFrom <= dTo)
                                {
                                    if (Valida_Datos())
                                    {
                                        if (Inserta_Rango())
                                        {
                                            iExCont++;
                                            //itsm
                                            ID_CEJ_PROD_SS.Col = 1;
                                            ID_CEJ_PROD_SS.Text = "";
                                            ID_CEJ_PROD_SS.Col = 2;
                                            ID_CEJ_PROD_SS.Text = "";
                                            //***
                                        }
                                    }
                                    else
                                    {
                                        //La validacion de los datos no fue exitosa
                                    }
                                }
                                else
                                {
                                    //MsgBox "No puede ser el Rango Inicial mayor que el Rango Final", vbInformation + vbOKOnly, "Tarjeta Corporativa"
                                }

                                //itsm
                                ID_CEJ_PROD_SS.Col = 1;
                                dRangos[iArr - 1, 0] = ID_CEJ_PROD_SS.Text;
                                ID_CEJ_PROD_SS.Col = 2;
                                dRangos[iArr - 1, 1] = ID_CEJ_PROD_SS.Text;
                                iArr++;
                                nArr = iArr;
                                //***

                                iCol = 1;
                                iRow++;
                                ID_CEJ_PROD_SS.Col = iCol;
                                ID_CEJ_PROD_SS.Row = iRow;
                                iCont++;
                            };

                            if (iCont == iExCont)
                            {
                                if (iCont > 0)
                                {
                                    MessageBox.Show("Se dieron de alta todos los Rangos", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LST_RAG.SelectedIndex = 0;
                                }
                                iCol = 1;
                                iRow = 1;
                                ID_CEJ_PROD_SS.Row = iRow;
                                ID_CEJ_PROD_SS.Col = iCol;
                                Frame1[0].Visible = true;
                                Frame1[1].Visible = false;
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Se dieron de alta " + iExCont.ToString() + " Rango(s) de " + iCont.ToString(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                iCol = 1;
                                iRow = 1;
                                ID_CEJ_PROD_SS.Row = iRow;
                                ID_CEJ_PROD_SS.Col = iCol;

                                //itsm
                                if (MessageBox.Show("¿Desea descartar los rangos invalidos?", this.Text, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    for (double I = 1; I <= 25; I++)
                                    {
                                        ID_CEJ_PROD_SS.Row = Convert.ToInt32(I);
                                        ID_CEJ_PROD_SS.Col = 1;
                                        ID_CEJ_PROD_SS.Text = "";
                                        ID_CEJ_PROD_SS.Col = 2;
                                        ID_CEJ_PROD_SS.Text = "";
                                    }
                                    Frame1[0].Visible = true;
                                    Frame1[1].Visible = false;
                                    if (LST_RAG.Items.Count >= 1)
                                    {
                                        LST_RAG.SelectedIndex = 0;
                                    }
                                }
                                else
                                {
                                    for (double I = 1; I <= 25; I++)
                                    {
                                        ID_CEJ_PROD_SS.Row = Convert.ToInt32(I);
                                        ID_CEJ_PROD_SS.Col = 1;
                                        ID_CEJ_PROD_SS.Text = "";
                                        ID_CEJ_PROD_SS.Col = 2;
                                        ID_CEJ_PROD_SS.Text = "";
                                    }

                                    iArr = 1;
                                    for (double I = 1; I <= nArr; I++)
                                    {
                                        ID_CEJ_PROD_SS.Row = Convert.ToInt32(I);
                                        if (dRangos[iArr - 1, 0] != "" || dRangos[iArr - 1, 1] != "")
                                        {
                                            ID_CEJ_PROD_SS.Col = 1;
                                            ID_CEJ_PROD_SS.Text = dRangos[iArr - 1, 0];
                                            ID_CEJ_PROD_SS.Col = 2;
                                            ID_CEJ_PROD_SS.Text = dRangos[iArr - 1, 1];
                                        }
                                        else
                                        {
                                            I--;
                                        }
                                        iArr++;
                                        if (iArr > 25)
                                        {
                                            break;
                                        }
                                    }
                                }
                                //***

                                return;
                            }

                        }
                        else if (Formato.sgForma == "B")
                        {
                            iCol = 1;
                            iRow = 1;
                            ID_CEJ_PROD_SS.Col = iCol;
                            ID_CEJ_PROD_SS.Row = iRow;
                            dFrom = Double.Parse(ID_CEJ_PROD_SS.Text);
                            ID_CEJ_PROD_SS.Text = "";
                            iCol = 2;
                            ID_CEJ_PROD_SS.Col = iCol;
                            dTo = Double.Parse(ID_CEJ_PROD_SS.Text);
                            ID_CEJ_PROD_SS.Text = "";
                            if (dFrom <= dTo)
                            {
                                if (Valida_Datos())
                                {
                                    if (Cambia_Rango())
                                    {
                                        iExCont++;
                                    }
                                    iCont++;
                                }
                            }
                            else
                            {
                                //MsgBox "No puede ser el Rango Inicial mayor que el Rango Final", vbInformation + vbOKOnly, "Tarjeta Corporativa"
                            }

                            if (iCont == iExCont)
                            {
                                MessageBox.Show("Se dieron de alta todos los cambios de los Rangos", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                iCol = 1;
                                iRow = 1;
                                ID_CEJ_PROD_SS.Row = iRow;
                                ID_CEJ_PROD_SS.Col = iCol;
                                LST_RAG.SelectedIndex = 0;
                                Frame1[0].Visible = true;
                                Frame1[1].Visible = false;
                                LST_RAG.SelectedIndex = 0;
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Se dieron de alta " + iExCont.ToString() + " cambio(s) de " + iCont.ToString(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                iCol = 1;
                                iRow = 1;
                                ID_CEJ_PROD_SS.Row = iRow;
                                ID_CEJ_PROD_SS.Col = iCol;
                                LST_RAG.SelectedIndex = 0;
                                Frame1[0].Visible = true;
                                Frame1[1].Visible = false;
                                LST_RAG.SelectedIndex = 0;
                                return;
                            }
                        }

                        break;
                    case 5:
                        iCol = ID_CEJ_PROD_SS.ActiveColumn;
                        iRow = ID_CEJ_PROD_SS.ActiveRow;
                        MCC tempLoadForm = MCC.DefInstance;
                        MCC.DefInstance.Show();
                        break;
                    case 6:
                        Frame1[0].Visible = true;
                        Frame1[1].Visible = false;
                        break;
                }

            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(CMD_RAN_CAT_Click)", e);
            }
        }

        private void RangosCats_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;
                if (Formato.bPrimeraVez)
                {
                    ID_CEJ_PROD_SS.Col = iCol;
                    ID_CEJ_PROD_SS.Row = iRow;
                    ID_CEJ_PROD_SS.Text = Formato.dMCC.ToString();
                }
                //itsm
                //ID_CEJ_PROD_SS.ProcessTab = true;
                //***
            }
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {

            Formato.bPrimeraVez = false;
            this.Height = (int)VB6.TwipsToPixelsY(3285);
            this.Width = (int)VB6.TwipsToPixelsX(5415);
            this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);
            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);

            Frame1[1].Top = (int)0;
            Frame1[1].Left = (int)0;

            iList = 0;

            CORVAR.pszgblsql = "select";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " cat_rag_id,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " cat_sic_from,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " cat_sic_to";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCRAG01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where cat_eje_prefijo = " + CORVAR.igblPref.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and cat_gpo_banco = " + CORVAR.igblBanco.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and cat_exp_struct_id = " + Conversion.Val(Formato.IdEstruct).ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and cat_id = " + Conversion.Val(Strings.Mid(CORCTCATS.DefInstance.ID_CAT_LB.Text, 7, 4)).ToString();

            if (CORPROC2.Cuenta_Registros() >= 1)
            {
                if (CORPROC2.Obtiene_Registros() != 0)
                {

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        Llena_Lista(Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1))), Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)), Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)));
                    };
                }
                LST_RAG.SelectedIndex = 0;
            }
            TXT_CAT[0].Text = Strings.Mid(CORCTCATS.DefInstance.ID_CAT_LB.Text, 26, 20).Trim();
            TXT_CAT[0].Enabled = false;
            TXT_CAT[1].Text = TXT_CAT[0].Text;
            TXT_CAT[1].Enabled = false;
            Frame1[0].Visible = true;
            Frame1[1].Visible = false;

            Formato.bgForma = true;

        }

        //UPGRADE_NOTE: (7001) The following declaration (Borra_Rango) seems to be dead code
        //private bool Borra_Rango()
        //{
        //CORVAR.pszgblsql = "delete MTCRAG01";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + iRag_ID.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "," + CORVAR.igblPref.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "," + CORVAR.igblBanco.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "," + Conversion.Val(Formato.IdEstruct).ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "," + Conversion.Val(Strings.Mid(CORCTCATS.DefInstance.ID_CAT_LB.Text, 7, 4)).ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "," + dFrom.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "," + dTo.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ")";
        //if (CORPROC2.Modifica_Registro() == 1)
        //{
        //return true;
        //} else
        //{
        //    MsgBox "No se pudo dar de baja el rango", vbInformation + vbOKOnly, "tarjeta Corporativa"
        //return false;
        //}
        //}

        private bool Cambia_Rango()
        {
            int iRagId = 0;
            CORVAR.pszgblsql = "update MTCRAG01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " set cat_sic_from = " + dFrom.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + ", cat_sic_to = " + dTo.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where cat_rag_id = " + VB6.GetItemData(LST_RAG, ListBoxHelper.GetSelectedIndex(LST_RAG)).ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and cat_eje_prefijo = " + CORVAR.igblPref.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and cat_gpo_banco = " + CORVAR.igblBanco.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and cat_exp_struct_id = " + Conversion.Val(Formato.IdEstruct).ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and cat_id = " + Conversion.Val(Strings.Mid(CORCTCATS.DefInstance.ID_CAT_LB.Text, 7, 4)).ToString();

            if (CORPROC2.Modifica_Registro() == 1)
            {
                iRagId = VB6.GetItemData(LST_RAG, ListBoxHelper.GetSelectedIndex(LST_RAG));
                for (int I = 0; I <= LST_RAG.Items.Count - 1; I++)
                {
                    LST_RAG.SelectedIndex = I;
                    if (Conversion.Val(VB6.GetItemData(LST_RAG, ListBoxHelper.GetSelectedIndex(LST_RAG)).ToString()) == iRagId)
                    {
                        LST_RAG.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(LST_RAG));
                        switch (dFrom.ToString().Trim().Length)
                        {
                            case 1:
                                LST_RAG.Items.Insert(I, new String(' ', 5) + dFrom.ToString() + new String(' ', 16) + dTo.ToString());
                                VB6.SetItemData(LST_RAG, I, iRagId);
                                break;
                            case 2:
                                LST_RAG.Items.Insert(I, new String(' ', 5) + dFrom.ToString() + new String(' ', 15) + dTo.ToString());
                                VB6.SetItemData(LST_RAG, I, iRagId);
                                break;
                            case 3:
                                LST_RAG.Items.Insert(I, new String(' ', 5) + dFrom.ToString() + new String(' ', 14) + dTo.ToString());
                                VB6.SetItemData(LST_RAG, I, iRagId);
                                break;
                            case 4:
                                LST_RAG.Items.Insert(I, new String(' ', 5) + dFrom.ToString() + new String(' ', 13) + dTo.ToString());
                                VB6.SetItemData(LST_RAG, I, iRagId);
                                break;
                            case 5:
                                LST_RAG.Items.Insert(I, new String(' ', 5) + dFrom.ToString() + new String(' ', 12) + dTo.ToString());
                                VB6.SetItemData(LST_RAG, I, iRagId);
                                break;
                        }
                    }
                }
                return true;
            }
            else
            {
                //    MsgBox "No se pudo dar de alta el cambio del rango", vbInformation + vbOKOnly, "tarjeta Corporativa"
                return false;
            }
        }

        //itsm
        private void ID_CEJ_PROD_SS_KeyDown(Object eventSender, KeyEventArgs eventArgs)
        {
            int KeyCode = (int)eventArgs.KeyCode;
            int Shift = (int)eventArgs.KeyData / 0x10000;
            if (KeyCode == 9 && Shift == 0)
            {
                return;
            }
        }
        //***
        private void RangosCats_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}