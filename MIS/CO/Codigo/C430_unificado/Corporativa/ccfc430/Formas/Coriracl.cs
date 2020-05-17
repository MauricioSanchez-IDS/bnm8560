using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal partial class CORIRACL
		: System.Windows.Forms.Form
		{
		
			//****************************************************************************
			//**                                                                        **
			//**         CopyRight(C) DDEMESIS, SA DE CV / Banamex - Sistemas           **
			//**                                                                        **
			//**       ---------------------------------------------------------        **
			//**                                                                        **
			//**       Descripción: Busca una aclaracion en base al ejecutivo           **
			//**                    y al grupo de forma directa para desplegarla        **
			//**                    junto con CORMNACL
			//**                                                                        **
			//**       Responsable: Felipe Zacarias Jimenez                             **
			//**                                                                        **
			//**       Ultima Fecha de Modificación: 24/Junio/1994                      **
			//**                                                                        **
			//**       NOTA: Esta forma necesita Visual Basic 3.0                       **
			//**                                                                        **
			//****************************************************************************
			
			private int ExisteEje( int lEjeCve)
			{
					
					
					int bExiste = 0;
					for (int iCont = CORVB.NULL_INTEGER; iCont <= CORCTACL.DefInstance.ID_ACL_EJE_COB.Items.Count - 1; iCont++)
					{
						if (Conversion.Val(Strings.Mid(VB6.GetItemString(CORCTACL.DefInstance.ID_ACL_EJE_COB, iCont), 1, CORBD.LNG_EJE_CP)) == lEjeCve)
						{
							CORCTACL.DefInstance.ID_ACL_EJE_COB.SelectedIndex = iCont;
							bExiste = -1;
							break;
						}
					}
					
					return bExiste;
					
			}
			
			private int ExisteEmp( int lEmpCve)
			{
					
					
					int bExiste = 0;
					for (int iCont = CORVB.NULL_INTEGER; iCont <= CORCTACL.DefInstance.ID_ACL_EMP_COB.Items.Count - 1; iCont++)
					{
						if (Conversion.Val(Strings.Mid(VB6.GetItemString(CORCTACL.DefInstance.ID_ACL_EMP_COB, iCont), 1, CORBD.LNG_EMP_CVE)) == lEmpCve)
						{
							CORCTACL.DefInstance.ID_ACL_EMP_COB.SelectedIndex = iCont;
							bExiste = -1;
							break;
						}
					}
					
					return bExiste;
					
			}
			
			private void  CORIRACL_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != eventSender)
					{
						ActivateHelper.myActiveForm = (Form) eventSender;
						
						this.Cursor = Cursors.Default;
						
					}
			}
			
			private void  ID_IRA_CAN_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					this.Cursor = Cursors.WaitCursor;
					
					this.Close();
					
			}
			
			private void  ID_IRA_EJE_PIC_KeyPressEvent( Object eventSender,  AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
			{
					
					if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != CORVB.KEY_BACK)
					{
						eventArgs.keyAscii = 0;
					}
					
			}
			
			private void  ID_IRA_EJE_PIC_Leave( Object eventSender,  EventArgs eventArgs)
			{
					//EISSA 03-10-2001 Cambio para el formateo del número de ejecutivo.
					ID_IRA_EJE_PIC.CtlText = StringsHelper.Format(ID_IRA_EJE_PIC.CtlText, Formato.sMascara(Formato.iTipo.Ejecutivo));
					
			}
			
			
			private void  ID_IRA_EMP_PIC_Change( Object eventSender,  EventArgs eventArgs)
			{
					
					ID_IRA_OK_PB.Enabled = Conversion.Val(ID_IRA_EMP_PIC.CtlText) != CORVB.NULL_INTEGER;
					
			}
			
			private void  ID_IRA_EMP_PIC_KeyPressEvent( Object eventSender,  AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
			{
					
					if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != CORVB.KEY_BACK)
					{
						eventArgs.keyAscii = 0;
					}
					
			}
			
			private void  ID_IRA_EMP_PIC_Leave( Object eventSender,  EventArgs eventArgs)
			{
					//EISSA 03-10-2001. Cambio para el formateo del número de empresa.
					ID_IRA_EMP_PIC.CtlText = StringsHelper.Format(ID_IRA_EMP_PIC.CtlText, Formato.sMascara(Formato.iTipo.Empresa));
					
			}
			
			
			private void  ID_IRA_FOL_PIC_KeyPressEvent( Object eventSender,  AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
			{
					
					if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != CORVB.KEY_BACK)
					{
						eventArgs.keyAscii = 0;
					}
					
			}
			
			private void  ID_IRA_FOL_PIC_Leave( Object eventSender,  EventArgs eventArgs)
			{
					
					ID_IRA_FOL_PIC.CtlText = StringsHelper.Format(ID_IRA_FOL_PIC.CtlText, "000000");
					
			}
			
			
			private void  ID_IRA_OK_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					int iCont = 0;
					int hAclaracion = 0;
					int bExiste = 0;
					int bTemp = 0;
					
					this.Cursor = Cursors.WaitCursor;
					
					int lEmpCve = Convert.ToInt32(Conversion.Val(ID_IRA_EMP_PIC.CtlText));
					int lEjeCve = Convert.ToInt32(Conversion.Val(ID_IRA_EJE_PIC.CtlText));
					int lFolio = Convert.ToInt32(Conversion.Val(ID_IRA_FOL_PIC.CtlText));

                    try
                    {


                        if (lEmpCve != CORVB.NULL_INTEGER)
                        {
                            if (lEjeCve != CORVB.NULL_INTEGER)
                            {
                                if (lFolio != CORVB.NULL_INTEGER)
                                {
                                    //Existe Folio
                                    bExiste = 0;

                                    //***** INICIO CODIGO ANTERIOR FSWBMX *****
                                    //        pszgblsql = "exec ira_aclaraciones " + Format$(igblBanco) + "," + Format$(lEmpCve) + "," + Format$(lEjeCve) + "," + Format$(lFolio)
                                    //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                                    //***** INICIO CODIGO NUEVO FSWBMX *****
                                    CORVAR.pszgblsql = "exec ira_aclaraciones " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + lEmpCve.ToString() + "," + lEjeCve.ToString() + "," + lFolio.ToString();
                                    //***** FIN DE CODIGO NUEVO FSWBMX *****

                                    if (CORPROC2.Obtiene_Registros() != 0)
                                    {
                                        if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                                        {
                                            bExiste = -1;
                                        }
                                    }
                                    else
                                    {
                                        //ros          igblErr = PostMessage(CORIRACL.hwnd, WM_CLOSE, NULL_INTEGER, NULL_INTEGER)
                                        bExiste = 0;
                                    }

                                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                                    if (bExiste != 0)
                                    {
                                        CORVAR.bgblIrExiste = -1;
                                        CORVAR.lgblEmpCve = lEmpCve;
                                        CORVAR.igblEjeCve = lEjeCve;
                                        CORVAR.igblFolio = lFolio;

                                        this.Cursor = Cursors.Default;
                                        this.Close();
                                    }
                                    else
                                    {
                                        this.Cursor = Cursors.Default;
                                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                        Interaction.MsgBox("No existe la Aclaración Capturada. Favor de verificar la Empresa, el Ejecutivo y el Folio", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                                        CORVAR.bgblIrExiste = 0;
                                    }
                                }
                                else
                                {
                                    //Existe Empresa
                                    CORVAR.bgblIrExiste = 0;

                                    if (ExisteEmp(lEmpCve) != 0)
                                    {
                                    }
                                    else
                                    {
                                        this.Cursor = Cursors.Default;
                                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                        Interaction.MsgBox("No existe la Empresa Capturada. Favor de verificarla", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                                    }

                                    if (ExisteEje(lEjeCve) != 0)
                                    {
                                        CORVAR.lgblEmpCve = lEmpCve;
                                        CORVAR.igblEjeCve = lEjeCve;
                                        CORVAR.igblFolio = lFolio;
                                        this.Cursor = Cursors.Default;
                                        this.Close();
                                    }
                                    else
                                    {
                                        this.Cursor = Cursors.Default;
                                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                        Interaction.MsgBox("No existe el Ejecutivo Capturado. Favor de verificar la Empresa y el Ejecutivo ", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                                    }
                                }
                            }
                            else
                            {
                                //Existe Empresa
                                CORVAR.bgblIrExiste = 0;

                                if (ExisteEmp(lEmpCve) != 0)
                                {
                                    CORVAR.lgblEmpCve = lEmpCve;
                                    CORVAR.igblEjeCve = lEjeCve;
                                    CORVAR.igblFolio = lFolio;
                                    this.Cursor = Cursors.Default;
                                    this.Close();
                                }
                                else
                                {
                                    this.Cursor = Cursors.Default;
                                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                    Interaction.MsgBox("No existe la Empresa Capturada. Favor de verificarla", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                                }
                            }
                        }
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Fallo operación ID_IRA_OK_PB_Click " + exc.Message, "Error Coriracl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
			}
			private void  CORIRACL_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}