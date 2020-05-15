using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class CORCTACL
        : System.Windows.Forms.Form
    {

        //****************************************************************************
        //**                                                                        **
        //**         CopyRight(C) DDEMESIS, SA DE CV / Banamex - Sistemas           **
        //**                                                                        **
        //**       ---------------------------------------------------------        **
        //**                                                                        **
        //**       Descripción: Carga las aclaraciones que existen el para          **
        //**                    cada grupo, empresa, y ejecutivo                    **
        //**                                                                        **
        //**       Responsable: Felipe Zacarias Jimenez                             **
        //**                                                                        **
        //**       Ultima Fecha de Modificación: 24/Junio/1994                      **
        //**                                                                        **
        //**       NOTA: Esta forma necesita Visual Basic 3.0                       **
        //**                                                                        **
        //****************************************************************************

        string pszGruCve = String.Empty;
        string pszEmpCve = String.Empty;
        string pszEjeCve = String.Empty;
        string pszAclCve = String.Empty;
        string pszFolio = String.Empty;
        int iAclPend = 0;
        int iAclFavorBanco = 0;
        int iAclFavorCliente = 0;
        int iPrefijo = 0;
        int iDigito = 0;
        int iRollOver = 0;

        string[] pszTiposAcl = null;

        int hACLConexion = 0;

        public bool flag = false;

        private int Busca_Nivel(string pszCveEje, string pszCveEmp)
        {

            int hNivel = 0;
            int iNivelEje = 0;
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            // pszgblsql = "SELECT eje_nivel FROM " + DB_SYB_EJE + " WHERE gpo_banco = " + Format$(igblBanco) + " AND emp_num = " + pszCveEmp + " AND eje_num = " + pszCveEje
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "SELECT eje_nivel FROM " + CORBD.DB_SYB_EJE + " WHERE eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " AND emp_num = " + pszCveEmp + " AND eje_num = " + pszCveEje;
            //***** FIN DE CODIGO NUEVO FSWBMX *****

            if (CORPROC2.Obtiene_Registros() != 0)
            {

                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                {
                    iNivelEje = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIRST_COL)));
                }
                else
                {
                    //AIS-1182 NGONZALEZ
                    //CORVAR.igblErr = API.USER.PostMessage(CORCTACL.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                    flag = true;
                }
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            return iNivelEje;

        }

        private void Carga_Acl_Eje(string pszEmpresa, string pszEjecutivo, string pszFolio)
        {

            int hAclaracion = 0;
            double dImporte = 0;
            int lStatusSAA = 0;
            int lRedirec = 0;
            int lTipoAcl = 0;
            int lFecVenci = 0;
            int lFecAbono = 0;
            int lFechaSol = 0;
            double dImporCor = 0;
            string pszPasoFecha = String.Empty;

            FixedLengthString szStatus = new FixedLengthString(CORBD.LEN_ACL_STA);

            CORMNACL.DefInstance.ID_ACL_NOM_EB.Text = Nombre_Eje(pszEjecutivo, pszEmpresa);
            CORMNACL.DefInstance.ID_ACL_EMP_EB.Text = Nombre_Emp(pszEmpresa);
            CORMNACL.DefInstance.ID_ACL_NIV_EB.Text = Busca_Nivel(pszEjecutivo, pszEmpresa).ToString();

            Carga_Acl_Totales(pszEmpresa, pszEjecutivo);

            CORMNACL.DefInstance.ID_ACL_NUM_EB.Text = (iAclFavorBanco + iAclFavorCliente + iAclPend).ToString();
            CORMNACL.DefInstance.ID_ACL_BAN_EB.Text = iAclFavorBanco.ToString();
            CORMNACL.DefInstance.ID_ACL_CLI_EB.Text = iAclFavorCliente.ToString();
            CORMNACL.DefInstance.ID_ACL_PEN_EB.Text = iAclPend.ToString();
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            // pszgblsql = "SELECT acl_out_importe, acl_out_fecha_solicitud, acl_out_sta_saa, acl_out_redireccionar, acl_out_tip_acl, acl_out_fec_venci, acl_out_fec_abono, acl_out_imp_correcto FROM " + DB_SYB_ACL + " WHERE gpo_banco = " + Format$(igblBanco) + " AND emp_num =" + pszEmpresa + " AND eje_num = " + pszEjecutivo + " AND acl_out_folio = " + pszFolio
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "SELECT acl_out_importe, acl_out_fecha_solicitud, acl_out_sta_saa, acl_out_redireccionar, acl_out_tip_acl, acl_out_fec_venci, acl_out_fec_abono, acl_out_imp_correcto FROM " + CORBD.DB_SYB_ACL + " WHERE eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " AND emp_num =" + pszEmpresa + " AND eje_num = " + pszEjecutivo + " AND acl_out_folio = " + pszFolio;
            //***** FIN DE CODIGO NUEVO FSWBMX *****

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                {
                    dImporte = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIRST_COL));
                    lFechaSol = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.SECOND_COL)));
                    lStatusSAA = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.THIRD_COL)));
                    lRedirec = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FOURTH_COL)));
                    lTipoAcl = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIFTH_COL)));
                    lFecVenci = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.SIXTH_COL)));
                    lFecAbono = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.SEVENTH_COL)));
                    dImporCor = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.EIGTH_COL));

                    //EISSA 03-10-2001. Formateo de número de empresa y número de ejecutivo.
                    CORMNACL.DefInstance.ID_ACL_CTA_EB.Text = StringsHelper.Format(iPrefijo, "0000") + StringsHelper.Format(CORVAR.igblBanco, "00") + StringsHelper.Format(pszEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format(pszEjecutivo, Formato.sMascara(Formato.iTipo.Ejecutivo)) + StringsHelper.Format(iRollOver, "0") + StringsHelper.Format(iDigito, "0");

                    foreach (string pszTiposAcl_item in pszTiposAcl)
                    {
                        if (Strings.Mid(pszTiposAcl_item, 1, 2) == StringsHelper.Format(lTipoAcl, "00"))
                        {
                            CORMNACL.DefInstance.ID_ACL_TIP_EB.Text = pszTiposAcl_item;
                            break;
                        }
                    }
                    if (lFechaSol > CORVB.NULL_INTEGER)
                    {
                        CORMNACL.DefInstance.ID_ACL_FEC_EB.Text = Strings.Mid(lFechaSol.ToString(), 7, 2) + "/" + Strings.Mid(lFechaSol.ToString(), 5, 2) + "/" + Strings.Mid(lFechaSol.ToString(), 1, 4);
                    }
                    CORMNACL.DefInstance.ID_ACL_IMP_EB.Text = StringsHelper.Format(dImporte, "###,###,##0.00");
                    CORMNACL.DefInstance.ID_ACL_NREG_EB.Text = StringsHelper.Format(pszFolio, "00000");
                    if (lFecVenci > CORVB.NULL_INTEGER)
                    {
                        CORMNACL.DefInstance.ID_ACL_FECV_EB.Text = Strings.Mid(lFecVenci.ToString(), 7, 2) + "/" + Strings.Mid(lFecVenci.ToString(), 5, 2) + "/" + Strings.Mid(lFecVenci.ToString(), 1, 4);
                    }
                    if (lRedirec >= 1 && lRedirec <= 3)
                    {
                        CORMNACL.DefInstance.ID_ACL_ORI_CKB[lRedirec - 1].Value = true;
                    }
                    if (lFecAbono > CORVB.NULL_INTEGER)
                    {
                        CORMNACL.DefInstance.ID_ACL_FEC_EB.Text = Strings.Mid(lFecAbono.ToString(), 7, 2) + "/" + Strings.Mid(lFecAbono.ToString(), 5, 2) + "/" + Strings.Mid(lFecAbono.ToString(), 1, 4);
                        CORMNACL.DefInstance.ID_ACL_FECA_EB.Text = Strings.Mid(lFecAbono.ToString(), 7, 2) + "/" + Strings.Mid(lFecAbono.ToString(), 5, 2) + "/" + Strings.Mid(lFecAbono.ToString(), 1, 4);
                    }
                    CORMNACL.DefInstance.ID_ACL_IMPA_EB.Text = StringsHelper.Format(dImporCor, "###,###,##0.00");

                    if (lStatusSAA <= 899 || lStatusSAA == 901)
                    {
                        CORMNACL.DefInstance.ID_ACL_RES_EB.Text = lStatusSAA.ToString() + " Pendiente";
                    }
                    else if (lStatusSAA == 900)
                    {
                        CORMNACL.DefInstance.ID_ACL_RES_EB.Text = lStatusSAA.ToString() + " Banco";
                    }
                    else if (lStatusSAA == 902)
                    {
                        if (dImporte > CORVB.NULL_INTEGER)
                        {
                            CORMNACL.DefInstance.ID_ACL_RES_EB.Text = lStatusSAA.ToString() + " Cliente";
                        }
                        else
                        {
                            CORMNACL.DefInstance.ID_ACL_RES_EB.Text = lStatusSAA.ToString() + " Pendiente";
                        }
                    }
                    else if (lStatusSAA >= 903)
                    {
                        CORMNACL.DefInstance.ID_ACL_RES_EB.Text = lStatusSAA.ToString() + " Cliente";
                    }
                }
            }
            else
            {

                //AIS-1182 NGONZALEZ
                //CORVAR.igblErr = API.USER.PostMessage(CORCTACL.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                flag = true;
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

        }

        private void Carga_Acl_Totales(string pszEmpCve, string pszEjeCve)
        {

            int hAclaracion = 0;
            int lTipoAcl = 0;
            double dImporte = 0;
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            // pszgblsql = "SELECT acl_out_tip_acl,acl_out_importe  FROM " + DB_SYB_ACL + " WHERE gpo_banco = " + Format$(igblBanco) + " AND emp_num =" + pszEmpCve + " AND eje_num = " + pszEjeCve
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "SELECT acl_out_tip_acl,acl_out_importe  FROM " + CORBD.DB_SYB_ACL + " WHERE eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " AND emp_num =" + pszEmpCve + " AND eje_num = " + pszEjeCve;
            //***** FIN DE CODIGO NUEVO FSWBMX *****

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                iAclPend = CORVB.NULL_INTEGER;
                iAclFavorBanco = CORVB.NULL_INTEGER;
                iAclFavorCliente = CORVB.NULL_INTEGER;


                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                {
                    lTipoAcl = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIRST_COL)));
                    dImporte = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.SECOND_COL));

                    if (lTipoAcl <= 899 || lTipoAcl == 901)
                    {
                        iAclPend++;
                    }
                    else if (lTipoAcl == 900)
                    {
                        iAclFavorBanco++;
                    }
                    else if (lTipoAcl == 902)
                    {
                        if (dImporte > CORVB.NULL_INTEGER)
                        {
                            iAclFavorCliente++;
                        }
                        else
                        {
                            iAclPend++;
                        }
                    }
                    else if (lTipoAcl >= 903)
                    {
                        iAclFavorCliente++;
                    }
                };
            }
            else
            {
                //AIS-1182 NGONZALEZ
                //CORVAR.igblErr = API.USER.PostMessage(CORCTACL.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                flag = true;
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

        }

        private void Carga_Aclaraciones()
        {

            int hAclaracion = 0;
            string pszEmpresa = String.Empty;
            string pszEjecutivo = String.Empty;
            string pszEje = String.Empty;
            int lTipoAcl = 0;
            int lFolio = 0;
            double dImporte = 0;
            FixedLengthString szStatus = new FixedLengthString(CORBD.LEN_ACL_STA);

            ID_ACL_CTA_LB.Items.Clear();

            if (ID_ACL_EJE_COB.Items.Count > CORVB.NULL_INTEGER)
            {
                pszEje = VB6.GetItemString(ID_ACL_EJE_COB, ID_ACL_EJE_COB.SelectedIndex);
                pszEjeCve = Conversion.Val(Strings.Mid(pszEje, 1, pszEje.IndexOf(' '))).ToString();
            }
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //  pszgblsql = "SELECT acl_out_folio, acl_out_tip_acl, acl_out_importe FROM " + DB_SYB_ACL + " WHERE gpo_banco = " + Format$(igblBanco) + " AND emp_num =" + pszEmpCve + " AND eje_num = " + pszEjeCve
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "SELECT acl_out_folio, acl_out_tip_acl, acl_out_importe FROM " + CORBD.DB_SYB_ACL + " WHERE eje_prefijo = " + CORVAR.igblPref.ToString() + " AND gpo_banco = " + CORVAR.igblBanco.ToString() + " AND emp_num =" + pszEmpCve + " AND eje_num = " + pszEjeCve;
            //***** FIN DE CODIGO NUEVO FSWBMX *****


            if (CORPROC2.Obtiene_Registros() != 0)
            {

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    lFolio = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIRST_COL)));
                    lTipoAcl = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.SECOND_COL)));
                    dImporte = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.THIRD_COL));
                    pszEje = new string(' ', 60);
                    pszEje = StringsHelper.MidAssignment(pszEje, 2, StringsHelper.Format(lFolio, "000000"));
                    pszEje = StringsHelper.MidAssignment(pszEje, 23, StringsHelper.Format(dImporte, "###,###,##0.00"));
                    pszEje = StringsHelper.MidAssignment(pszEje, 37, Strings.Mid(TipoDesc(lTipoAcl), 1, 20));

                    ID_ACL_CTA_LB.Items.Add(pszEje);
                };
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

        }

        private void Carga_Ejecutivos()
        {

            int lEjecutivo = 0;
            string pszEje = String.Empty;
            string pszEmp = String.Empty;
            int iNivEje = 0;
            int hEjecutivo = 0;
            string pszEjeDesc = String.Empty;

            ID_ACL_EJE_COB.Items.Clear();
            ID_ACL_CTA_LB.Items.Clear();

            if (ID_ACL_EMP_COB.Items.Count > CORVB.NULL_INTEGER)
            {
                pszEmp = VB6.GetItemString(ID_ACL_EMP_COB, ID_ACL_EMP_COB.SelectedIndex);
                pszEmpCve = Conversion.Val(Strings.Mid(pszEmp, 1, pszEmp.IndexOf(' '))).ToString();
            }
            //***** INICIO CODIGO ANTERIOR FSWBMX  *****
            // pszgblsql = "SELECT eje_num, ths_nombre FROM " + DB_SYB_THS + " WHERE emp_num = " + pszEmpCve + " and gpo_banco=" + Format$(igblBanco)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX  *****
            CORVAR.pszgblsql = "SELECT eje_num, ths_nombre FROM " + CORBD.DB_SYB_THS + " WHERE emp_num = " + pszEmpCve + " and eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****

            if (CORPROC2.Obtiene_Registros() != 0)
            {

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    lEjecutivo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIRST_COL)));
                    pszEjeDesc = VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.SECOND_COL);
                    //EISSA. 03-10-2001. Formateo del número de ejecutivo
                    ID_ACL_EJE_COB.Items.Add(StringsHelper.Format(lEjecutivo, Formato.sMascara(Formato.iTipo.Ejecutivo)) + "   " + pszEjeDesc.Trim());
                };
            }
            else
            {
                //AIS-1182 NGONZALEZ
                //CORVAR.igblErr = API.USER.PostMessage(CORCTACL.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                flag = true;
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            if (ID_ACL_EJE_COB.Items.Count > CORVB.NULL_INTEGER)
            {
                pszEje = VB6.GetItemString(ID_ACL_EJE_COB, CORVB.NULL_INTEGER);
                pszEjeCve = Conversion.Val(Strings.Mid(pszEje, 1, pszEje.IndexOf(' '))).ToString();
            }

        }

        private void Carga_Empresas()
        {

            int hEmpresa = 0;
            int lEmpresa = 0;
            string pszEmpDesc = String.Empty;
            string pszEmp = String.Empty;
            string pszGrupo = String.Empty;

            ID_ACL_EMP_COB.Items.Clear();
            ID_ACL_EJE_COB.Items.Clear();
            ID_ACL_CTA_LB.Items.Clear();

            if (ID_ACL_GRU_COB.Items.Count > CORVB.NULL_INTEGER)
            {
                pszGrupo = VB6.GetItemString(ID_ACL_GRU_COB, ID_ACL_GRU_COB.SelectedIndex);
                pszGruCve = Conversion.Val(Strings.Mid(pszGrupo, 1, pszGrupo.IndexOf(' '))).ToString();
            }
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            // pszgblsql = "SELECT emp_num, emp_nom FROM " + DB_SYB_EMP + " WHERE gpo_num = " + pszGruCve + " and gpo_banco=" + Format$(igblBanco)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "SELECT emp_num, emp_nom FROM " + CORBD.DB_SYB_EMP + " WHERE eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString() + " and gpo_num = " + pszGruCve;
            //***** FIN DE CODIGO NUEVO FSWBMX *****

            if (CORPROC2.Obtiene_Registros() != 0)
            {

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    lEmpresa = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIRST_COL)));
                    pszEmpDesc = VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.SECOND_COL);
                    //EISSA 03-10-2001. Formateo del número de empresa y número de ejecutivo.
                    ID_ACL_EMP_COB.Items.Add(StringsHelper.Format(lEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + CORCONST.SPC_TRES + pszEmpDesc.Trim());
                };
            }
            else
            {
                //AIS-1182 NGONZALEZ
                //CORVAR.igblErr = API.USER.PostMessage(CORCTACL.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                flag = true;
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            if (ID_ACL_EMP_COB.Items.Count > CORVB.NULL_INTEGER)
            {
                pszEmp = VB6.GetItemString(ID_ACL_EMP_COB, CORVB.NULL_INTEGER);
                pszEmpCve = Conversion.Val(Strings.Mid(pszEmp, 1, pszEmp.IndexOf(' '))).ToString();
            }

        }

        private void Carga_Grupos()
        {

            int hGrupo = 0;
            int iGpoCve = 0;
            string pszGpoDesc = String.Empty;
            string pszGrupo = String.Empty;

            ID_ACL_GRU_COB.Items.Clear();
            ID_ACL_EMP_COB.Items.Clear();
            ID_ACL_EJE_COB.Items.Clear();
            ID_ACL_CTA_LB.Items.Clear();
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            // pszgblsql = "SELECT gpo_num, gpo_nom FROM " + DB_SYB_COR + " WHERE gpo_banco = " + Format$(igblBanco)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "SELECT gpo_num, gpo_nom FROM " + CORBD.DB_SYB_COR + " WHERE eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****


            if (CORPROC2.Obtiene_Registros() != 0)
            {

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    iGpoCve = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIRST_COL)));
                    pszGpoDesc = VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.SECOND_COL);
                    ID_ACL_GRU_COB.Items.Add(StringsHelper.Format(iGpoCve, "0000") + CORCONST.SPC_TRES + pszGpoDesc.Trim());
                };
            }
            else
            {
                //AIS-1182 NGONZALEZ
                //CORVAR.igblErr = API.USER.PostMessage(CORCTACL.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                flag = true;
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            //Posiciona en el Primer Elemento del ComboBox de Grupos
            if (ID_ACL_GRU_COB.Items.Count > CORVB.NULL_INTEGER)
            {
                pszGrupo = VB6.GetItemString(ID_ACL_GRU_COB, CORVB.NULL_INTEGER);
                pszGruCve = Conversion.Val(Strings.Mid(pszGrupo, 1, pszGrupo.IndexOf(' '))).ToString();
                ID_ACL_GRU_COB.SelectedIndex = CORVB.NULL_INTEGER;
            }

        }

        private void Carga_Tipos()
        {

            pszTiposAcl = ArraysHelper.InitializeArray<string>(16);

            pszTiposAcl[0] = "01 No Reconoce Cargo";
            pszTiposAcl[1] = "02 Cargo Duplicado";
            pszTiposAcl[2] = "03 Pagaré Alterado en Importe";
            pszTiposAcl[3] = "04 Cargos Múltiples";
            pszTiposAcl[4] = "05 Cargo Diferido";
            pszTiposAcl[5] = "06 Cargo Promoción";
            pszTiposAcl[6] = "20 Pago No Aplicado";
            pszTiposAcl[7] = "21 Pago Aplicado Extemporáneo";
            pszTiposAcl[8] = "30 Pagaré por Rechazos";
            pszTiposAcl[9] = "31 Pagaré Otro Emisor";
            pszTiposAcl[10] = "32 Pagaré Trámite Legal";
            pszTiposAcl[11] = "33 Pagaré Extemporáneo";
            pszTiposAcl[12] = "34 Pagaré";
            pszTiposAcl[13] = "35 Acuse de Recibo de Tarjeta";
            pszTiposAcl[14] = "36 Estado de Cuenta Extemporáneo";
            pszTiposAcl[15] = "37 Contrato";

        }

        private void CORCTACL_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;

                ID_ACL_GRU_COB.Focus();

            }
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {

            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
            this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);

            this.Show();
            this.Refresh();

            iPrefijo = CORVB.NULL_INTEGER;
            iDigito = CORVB.NULL_INTEGER;
            iRollOver = CORVB.NULL_INTEGER;

            Carga_Tipos();

            Carga_Grupos();

            CORVAR.bgblIrExiste = -1;

            if (ID_ACL_EMP_COB.Items.Count > CORVB.NULL_INTEGER)
            {
                ID_ACL_EMP_COB.SelectedIndex = CORVB.NULL_INTEGER;
            }

            if (ID_ACL_EJE_COB.Items.Count > CORVB.NULL_INTEGER)
            {
                ID_ACL_EJE_COB.SelectedIndex = CORVB.NULL_INTEGER;
            }

            if (ID_ACL_CTA_LB.Items.Count > CORVB.NULL_INTEGER)
            {
                ID_ACL_CTA_LB.SelectedIndex = CORVB.NULL_INTEGER;
            }

        }

        private void ID_ACL_CON_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (ID_ACL_IRA_CKB.Value)
                {
                    CORVAR.bgblIrExiste = 0;
                    CORVAR.lgblEmpCve = CORVB.NULL_INTEGER;
                    CORVAR.igblEjeCve = CORVB.NULL_INTEGER;
                    CORVAR.igblFolio = CORVB.NULL_INTEGER;

                    //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                    CORIRACL.DefInstance.ShowDialog();

                    if (CORVAR.bgblIrExiste != 0)
                    {
                        //Carga_Grupos
                        this.Cursor = Cursors.WaitCursor;
                        //EISSA 03-10-2001. Formateo de número de empresa y número de ejecutivo.
                        Carga_Acl_Eje(StringsHelper.Format(CORVAR.lgblEmpCve, Formato.sMascara(Formato.iTipo.Empresa)), StringsHelper.Format(CORVAR.igblEjeCve, Formato.sMascara(Formato.iTipo.Ejecutivo)), CORVAR.igblFolio.ToString());
                    }
                    else
                    {
                        CORVAR.bgblIrExiste = -1;
                    }
                }
                else
                {
                    if (ID_ACL_CTA_LB.Items.Count > CORVB.NULL_INTEGER)
                    {
                        CORMNACL.DefInstance.Show();

                        if (ListBoxHelper.GetSelectedIndex(ID_ACL_CTA_LB) == -1)
                        {
                            ID_ACL_CTA_LB.SelectedIndex = CORVB.NULL_INTEGER;
                        }

                        pszFolio = Strings.Mid(VB6.GetItemString(ID_ACL_CTA_LB, ListBoxHelper.GetSelectedIndex(ID_ACL_CTA_LB)), 2, Strings.InStr(2, VB6.GetItemString(ID_ACL_CTA_LB, ListBoxHelper.GetSelectedIndex(ID_ACL_CTA_LB)), " ", CompareMethod.Binary) - 1).Trim();

                        Carga_Acl_Eje(pszEmpCve, pszEjeCve, pszFolio);

                    }
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_ACL_CON_PB_Click)", e);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void ID_ACL_CTA_LB_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {

            string pszCadena = String.Empty;

            if (ID_ACL_CTA_LB.Items.Count > CORVB.NULL_INTEGER)
            {
                pszCadena = VB6.GetItemString(ID_ACL_CTA_LB, ListBoxHelper.GetSelectedIndex(ID_ACL_CTA_LB));
                pszAclCve = Strings.Mid(pszCadena, 2, Strings.InStr(2, pszCadena, " ", CompareMethod.Binary));
            }

        }

        private void ID_ACL_EJE_COB_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            Carga_Aclaraciones();

            if (CORVAR.bgblIrExiste != 0)
            {
                if (ID_ACL_CTA_LB.Items.Count > CORVB.NULL_INTEGER)
                {
                    ID_ACL_CTA_LB.SelectedIndex = CORVB.NULL_INTEGER;
                }
            }

            ID_ACL_CON_PB.Enabled = ID_ACL_IRA_CKB.Value || ID_ACL_CTA_LB.Items.Count > CORVB.NULL_INTEGER;

            this.Cursor = Cursors.Default;

        }

        private void ID_ACL_EMP_COB_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            Carga_Ejecutivos();

            if (CORVAR.bgblIrExiste != 0)
            {
                if (ID_ACL_EJE_COB.Items.Count > CORVB.NULL_INTEGER)
                {
                    ID_ACL_EJE_COB.SelectedIndex = CORVB.NULL_INTEGER;
                }

                if (ID_ACL_CTA_LB.Items.Count > CORVB.NULL_INTEGER)
                {
                    ID_ACL_CTA_LB.SelectedIndex = CORVB.NULL_INTEGER;
                }
            }

            ID_ACL_CON_PB.Enabled = ID_ACL_IRA_CKB.Value || ID_ACL_CTA_LB.Items.Count > CORVB.NULL_INTEGER;

            this.Cursor = Cursors.Default;

        }

        private void ID_ACL_GRU_COB_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            Carga_Empresas();

            if (CORVAR.bgblIrExiste != 0)
            {
                if (ID_ACL_EMP_COB.Items.Count > CORVB.NULL_INTEGER)
                {
                    ID_ACL_EMP_COB.SelectedIndex = CORVB.NULL_INTEGER;
                }

                if (ID_ACL_EJE_COB.Items.Count > CORVB.NULL_INTEGER)
                {
                    ID_ACL_EJE_COB.SelectedIndex = CORVB.NULL_INTEGER;
                }

                if (ID_ACL_CTA_LB.Items.Count > CORVB.NULL_INTEGER)
                {
                    ID_ACL_CTA_LB.SelectedIndex = CORVB.NULL_INTEGER;
                }
            }

            this.Cursor = Cursors.Default;

        }

        private void ID_ACL_IRA_CKB_ClickEvent(Object eventSender, AxThreed.ISSCBCtrlEvents_ClickEvent eventArgs)
        {

            ID_ACL_CON_PB.Enabled = (eventArgs.value | ((ID_ACL_CTA_LB.Items.Count > CORVB.NULL_INTEGER) ? -1 : 0)) != 0;

        }

        private void ID_ACL_SAL_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Close();

        }

        private string Nombre_Eje(string pszCveEje, string pszCveEmp)
        {

            int hEjecutivo = 0;
            FixedLengthString szNomEje = new FixedLengthString(CORBD.LNG_THS_NOMBRE);
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            // pszgblsql = "SELECT ths_nombre,eje_prefijo,eje_roll_over,eje_digit FROM " + DB_SYB_THS + " WHERE gpo_banco = " + Format$(igblBanco) + " AND emp_num = " + pszCveEmp + " AND eje_num = " + pszCveEje
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "SELECT ths_nombre,eje_prefijo,eje_roll_over,eje_digit FROM " + CORBD.DB_SYB_THS + " WHERE eje_prefijo = " + CORVAR.igblPref.ToString() + " AND gpo_banco = " + CORVAR.igblBanco.ToString() + " AND emp_num = " + pszCveEmp + " AND eje_num = " + pszCveEje;
            //***** FIN DE CODIGO NUEVO FSWBMX *****

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                {
                    szNomEje.Value = VBSQL.SqlData(CORVAR.hgblConexion, 1);
                    iPrefijo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)));
                    iDigito = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)));
                    iRollOver = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 4)));
                }
            }
            else
            {
                //AIS-1182 NGONZALEZ
                //CORVAR.igblErr = API.USER.PostMessage(CORCTACL.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                flag = true;
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            return szNomEje.Value.Trim();

        }

        private string Nombre_Emp(string pszCveEmp)
        {

            int hEmpresa = 0;
            string pszNomEmp = String.Empty;
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            // pszgblsql = "SELECT emp_nom FROM " + DB_SYB_EMP + " WHERE emp_num =" + pszCveEmp + " and gpo_banco=" + Format$(igblBanco)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "SELECT emp_nom FROM " + CORBD.DB_SYB_EMP + " WHERE eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString() + " AND emp_num =" + pszCveEmp;
            //***** FIN DE CODIGO NUEVO FSWBMX *****

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                {
                    pszNomEmp = VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIRST_COL);
                }
            }
            else
            {
                //AIS-1182 NGONZALEZ
                //CORVAR.igblErr = API.USER.PostMessage(CORCTACL.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                flag = true;
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            return pszNomEmp.Trim();

        }

        private string TipoDesc(int iTipo)
        {

            string pszDesc = String.Empty;

            switch (iTipo)
            {
                case 1:
                    pszDesc = "No Reconoce Cargo";
                    break;
                case 2:
                    pszDesc = "Cargo Duplicado";
                    break;
                case 3:
                    pszDesc = "Pagaré Alterado en Importe";
                    break;
                case 4:
                    pszDesc = "Cargos Múltiples";
                    break;
                case 5:
                    pszDesc = "Cargo Diferido";
                    break;
                case 6:
                    pszDesc = "Cargo Promoción";
                    break;
                case 20:
                    pszDesc = "Pago No Aplicado";
                    break;
                case 21:
                    pszDesc = "Pago Aplicado Extemporáneo";
                    break;
                case 30:
                    pszDesc = "Pagaré por Rechazos";
                    break;
                case 31:
                    pszDesc = "Pagaré Otro Emisor";
                    break;
                case 32:
                    pszDesc = "Pagaré Trámite Legal";
                    break;
                case 33:
                    pszDesc = "Pagaré Extemporáneo";
                    break;
                case 34:
                    pszDesc = "Pagaré";
                    break;
                case 35:
                    pszDesc = "Acuse de Recibo de Tarjeta";
                    break;
                case 36:
                    pszDesc = "Estado de Cuenta Extemporáneo";
                    break;
                case 37:
                    pszDesc = "Contrato";
                    break;
                default:
                    pszDesc = "Sin tipo = " + iTipo.ToString();
                    break;
            }

            return pszDesc;

        }
        private void CORCTACL_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}