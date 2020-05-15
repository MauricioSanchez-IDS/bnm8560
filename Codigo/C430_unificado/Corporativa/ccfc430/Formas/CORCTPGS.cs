using Artinsoft.VB6.Gui; 
using Microsoft.VisualBasic; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal partial class CORCTPGS
		: System.Windows.Forms.Form
		{
		
			private void  CORCTPGS_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			string slSQL = String.Empty;
			
			private void  cboCombo_SelectedIndexChanged( Object eventSender,  EventArgs eventArgs)
			{
					int Index = Array.IndexOf(cboCombo, eventSender);
					switch(Index)
					{
						case 0 : 
							prObtenDetalle(); 
							break;
					}
			}
			
			private void  cmdBoton_Click( Object eventSender,  EventArgs eventArgs)
			{
					int Index = Array.IndexOf(cmdBoton, eventSender);
					switch(Index)
					{
						case 0 : 
							switch(cmdBoton[0].Text)
							{
								case "&Alta" : 
									//Limpia los campos 
									break;
								case "&Aceptar" : 
									//Realiza el Insert 
									break;
							} 
							break;
						case 1 : 
							switch(cmdBoton[0].Text)
							{
								case "&Cambios" : 
									//Habilita los Campos 
									break;
								case "&Aceptar" : 
									//Realiza el Update 
									break;
							} 
							break;
						case 2 : 
							//Realiza la baja del producto, previa Validación 
							break;
						case 3 : 
							this.Close(); 
							break;
					}
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					slSQL = "SELECT convert(char(4),con_pref) + '   ' + convert(char(4),con_banco), con_ban_des FROM " + CORBD.DB_SYB_CON + " ORDER BY con_banco";
					CRSGeneral.prCargaSQLCombo(slSQL, cboCombo[0], CRSParametros.cteSeparador, 1, 2);
			}
			
			private void  prObtenDetalle()
			{
					string slSQL = String.Empty;
					try
					{
							this.Cursor = Cursors.WaitCursor;
							slSQL = " Select";
							slSQL = slSQL + " MTCPGS01.pgs_rep_prefijo,";
							slSQL = slSQL + " MTCPGS01.pgs_rep_banco,";
							slSQL = slSQL + " MTCCON01.con_gpo,";
							slSQL = slSQL + " MTCCON01.con_emp,";
							slSQL = slSQL + " MTCPGS01.pgs_emp,";
							slSQL = slSQL + " MTCCON01.con_ban_des,";
							slSQL = slSQL + " MTCPGS01.pgs_incremento,";
							slSQL = slSQL + " MTCPGS01.pgs_long_emp,";
							slSQL = slSQL + " MTCPGS01.pgs_long_eje";
							slSQL = slSQL + " From MTCPGS01, MTCCON01";
							slSQL = slSQL + " Where";
							slSQL = slSQL + " MTCPGS01.pgs_rep_prefijo = MTCCON01.con_pref";
							slSQL = slSQL + " and   MTCPGS01.pgs_rep_banco = MTCCON01.con_banco";
							string tempRefParam = cboCombo[0].Text;
							slSQL = slSQL + " and   MTCPGS01.pgs_rep_prefijo = " + Conversion.Val(CRSGeneral.fncsObtenerElementoDeCadena(ref tempRefParam, 1, CRSParametros.cteSeparador)).ToString();
							string tempRefParam2 = cboCombo[0].Text;
							slSQL = slSQL + " and   MTCPGS01.pgs_rep_banco = " + Conversion.Val(CRSGeneral.fncsObtenerElementoDeCadena(ref tempRefParam2, 2, CRSParametros.cteSeparador)).ToString();
							if (CORPROC2.ObtieneRegistros(ref slSQL) != 0)
							{
								while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
									{
									
										txtTexto[0].Text = VBSQL.SqlData(CORVAR.hgblConexion, 5).Trim();
										txtTexto[1].Text = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString();
										txtTexto[2].Text = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)).ToString();
										txtTexto[3].Text = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)).ToString();
										txtTexto[4].Text = VBSQL.SqlData(CORVAR.hgblConexion, 4);
										txtTexto[5].Text = VBSQL.SqlData(CORVAR.hgblConexion, 7);
										txtTexto[6].Text = VBSQL.SqlData(CORVAR.hgblConexion, 8);
										txtTexto[7].Text = VBSQL.SqlData(CORVAR.hgblConexion, 9);
									}
							}
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
							this.Cursor = Cursors.Default;
						}
                        catch (Exception e)
					{
						
						CRSGeneral.prObtenError("ObtenDetalle",e );
					}
			}
			
			
			//
			//
			//
			//Public Sub Inserta_Banco()
			//  Dim iPtoCom     As Integer
			//''17.10.2001 Código Anterior para Ingresar un banco a la tabla MTCPGS01
			//'  pszgblsql = "INSERT INTO " + DB_SYB_PGS + _
			//''  " (pgs_emp,pgs_mes_oper,pgs_dia_corte,pgs_ver,pgs_ths,pgs_pla,pgs_his,"
			//'  pszgblsql = pszgblsql + _
			//''  "pgs_ara,pgs_sgo,pgs_neg,pgs_act,pgs_acl,pgs_incremento,pgs_telefono,pgs_tel_lada,"
			//'  pszgblsql = pszgblsql + _
			//''  "pgs_fax,pgs_fax_lada,pgs_vel_transmis,pgs_pto_modem,pgs_email,pgs_internet,pgs_extension,pgs_rep_prefijo,pgs_rep_banco) "
			
			//'  pszgblsql = pszgblsql + "VALUES ('" + Trim$(ID_PAR_EMP_EB.Text) + "',"
			//'  pszgblsql = pszgblsql + Trim$(ID_PAR_MES_COB.ListIndex + 1) + ","
			//'  pszgblsql = pszgblsql + Trim$(ID_PAR_DIA_EB.Text) + ","
			//'  pszgblsql = pszgblsql + Trim$(ID_PAR_VER_EB.Text) + ","
			//'  pszgblsql = pszgblsql + "' ',"
			//'  pszgblsql = pszgblsql + "' ',"
			//'  pszgblsql = pszgblsql + "' ',"
			//'  pszgblsql = pszgblsql + "' ',"
			//'  pszgblsql = pszgblsql + "' ',"
			//'  pszgblsql = pszgblsql + "' ',"
			//'  pszgblsql = pszgblsql + "' ',"
			//'  pszgblsql = pszgblsql + "' ',"
			//'  pszgblsql = pszgblsql + Trim$(ID_PAR_INC_COB.List(ID_PAR_INC_COB.ListIndex)) + ","
			//'  pszgblsql = pszgblsql + "'" + Trim$(ID_PAR_TEL_TXT.Text) + "',"
			//'  pszgblsql = pszgblsql + "'" + Trim$(ID_PAR_LADA_TXT.Text) + "',"
			//'  pszgblsql = pszgblsql + "'" + Trim$(ID_PAR_FAX_TXT.Text) + "',"
			//'  pszgblsql = pszgblsql + "'" + Trim$(ID_PAR_FAX_LADA_TXT.Text) + "',"
			//'  pszgblsql = pszgblsql + Trim$(ID_PAR_COM_TRA_COB.Text) + ","
			//'  pszgblsql = pszgblsql + Trim$(Str$(iPtoCom)) + ","
			//'  pszgblsql = pszgblsql + "'" + Trim$(ID_PAR_EMAIL_TXT.Text) + "',"
			//'  pszgblsql = pszgblsql + "'" + Trim$(ID_PAR_INTER_TXT.Text) + "',"
			//'  pszgblsql = pszgblsql + "'" + Trim$(ID_PAR_TEL_EXT_TXT.Text) + "',"
			//'  pszgblsql = pszgblsql + Trim$(ID_PAR_PRE_EB.Text) + ","
			//'  pszgblsql = pszgblsql + Trim$(ID_PAR_NUM_EB.Text) + ")"
			//''17.10.2001 Código Anterior para Ingresar un banco a la tabla MTCPGS01
			//
			//'EISSA 17.10.2001 Código Nuevo para Ingresar un banco a la tabla MTCPGS01
			//  pszgblsql = "INSERT INTO " & DB_SYB_PGS
			//
			//  pszgblsql = pszgblsql & " (pgs_emp, pgs_dia_corte, pgs_mes_oper, pgs_ver, pgs_path,"
			//  pszgblsql = pszgblsql & " pgs_ths, pgs_pla, pgs_his, pgs_ara, pgs_sgo,"
			//  pszgblsql = pszgblsql & " pgs_neg, pgs_act, pgs_acl, pgs_folio, pgs_incremento,"
			//  pszgblsql = pszgblsql & " pgs_telefono, pgs_extension, pgs_tel_lada, pgs_fax, pgs_fax_lada,"
			//  pszgblsql = pszgblsql & " pgs_par_comu, pgs_vel_transmis, pgs_pto_modem, pgs_email, pgs_internet,"
			//  pszgblsql = pszgblsql & " pgs_rep_fec, pgs_rep_fec_ant, pgs_rep_banco, pgs_rep_prefijo, pgs_rep_porc_comp,"
			//  pszgblsql = pszgblsql & " pgs_rep_porc_disp, pgs_long_emp, pgs_long_eje)"
			//  pszgblsql = pszgblsql & " VALUES "
			//  pszgblsql = pszgblsql & "('" + Trim$(ID_PAR_EMP_EB.Text) & "', "       'pgs_emp Char
			//  pszgblsql = pszgblsql & Trim(ID_PAR_DIA_EB.Text) & ", "                'pgs_dia_corte SmallInt
			//  pszgblsql = pszgblsql & ID_PAR_MES_COB.ListIndex + 1 & ", "            'pgs_mes_oper SmallInt
			//  pszgblsql = pszgblsql & Trim$(ID_PAR_VER_EB.Text) & ", "               'pgs_ver Float
			//  pszgblsql = pszgblsql & "' ', "                                        'pgs_path Char
			//  pszgblsql = pszgblsql & "' ', "                                        'pgs_ths Char
			//  pszgblsql = pszgblsql & "' ', "                                        'pgs_pla Char
			//  pszgblsql = pszgblsql & "' ', "                                        'pgs_his Char
			//  pszgblsql = pszgblsql & "' ', "                                        'pgs_ara Char
			//  pszgblsql = pszgblsql & "' ', "                                        'pgs_sgo Char
			//  pszgblsql = pszgblsql & "' ', "                                        'pgs_neg Char
			//  pszgblsql = pszgblsql & "' ', "                                        'pgs_act Char
			//  pszgblsql = pszgblsql & "' ', "                                        'pgs_acl Char
			//  pszgblsql = pszgblsql & "0, "                                         '*pgs_folio   int
			//  pszgblsql = pszgblsql & (ID_PAR_INC_COB.List(ID_PAR_INC_COB.ListIndex)) & ", " 'pgs_incremento SmallInt
			//  pszgblsql = pszgblsql & "'" & Trim(ID_PAR_TEL_TXT.Text) & "', "        'pgs_telefono Char
			//  pszgblsql = pszgblsql & "'" & Trim(ID_PAR_TEL_EXT_TXT.Text) & "', "    'pgs_extension Char
			//  pszgblsql = pszgblsql & "'" & Trim(ID_PAR_LADA_TXT.Text) & "', "       'pgs_tel_lada Char
			//  pszgblsql = pszgblsql & "'" & Trim(ID_PAR_FAX_TXT.Text) & "', "        'pgs_fax Char
			//  pszgblsql = pszgblsql & "'" & Trim(ID_PAR_FAX_LADA_TXT.Text) & "', "   'pgs_fax_lada Char
			//  pszgblsql = pszgblsql & "'', "                                        '*pgs_par_comu Char
			//  pszgblsql = pszgblsql & Trim$(ID_PAR_COM_TRA_COB.Text) & ", "          'pgs_vel_transmis    int
			//  pszgblsql = pszgblsql & Trim$(Str$(iPtoCom)) & ", "                    'pgs_pto_modem   int
			//  pszgblsql = pszgblsql & "'" & Trim(ID_PAR_EMAIL_TXT.Text) & "', "      'pgs_email Char
			//  pszgblsql = pszgblsql & "'" & Trim(ID_PAR_INTER_TXT.Text) & "', "      'pgs_internet Char
			//  pszgblsql = pszgblsql & "0, "                                          'pgs_rep_fec int
			//  pszgblsql = pszgblsql & "0, "                                         '*pgs_rep_fec_ant int1
			//  pszgblsql = pszgblsql & Trim(ID_PAR_NUM_EB.Text) & ", "                'pgs_rep_banco   int
			//  pszgblsql = pszgblsql & Trim(ID_PAR_PRE_EB.Text) & ", "               '*pgs_rep_prefijo int
			//  pszgblsql = pszgblsql & "0, "                                         '*pgs_rep_porc_comp   int
			//  pszgblsql = pszgblsql & "0, "                                         '*pgs_rep_porc_disp   int
			//  pszgblsql = pszgblsql & ID_PAR_LEM_EB.Text & ", "                      'pgs_long_emp    int
			//  pszgblsql = pszgblsql & ID_PAR_LEJ_EB.Text & ")"                       'pgs_long_eje    int
			//
			//'EISSA 17.10.2001 Código Nuevo para Ingresar un banco a la tabla MTCPGS01
			//
			//  If Modifica_Registro Then
			//  Else
			//      igblRetorna = SqlCancel(hgblConexion)
			//      igblErr = PostMessage(CORMNPAR.hwnd, WM_CLOSE, NULL_INTEGER, NULL_INTEGER)
			//      Exit Sub
			//  End If
			//  igblRetorna = SqlCancel(hgblConexion)
			//End Sub
			//
			//
			private void  Label2_Click( Object eventSender,  EventArgs eventArgs)
			{
					
			}
			private void  CORCTPGS_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}