using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal partial class CORIREJB
		: System.Windows.Forms.Form
		{
		
			private void  CORIREJB_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			//****************************************************************************
			//**                                                                        **
			//**         CopyRight(C) DDEMESIS, SA DE CV / Banamex - Sistemas           **
			//**                                                                        **
			//**       ---------------------------------------------------------        **
			//**                                                                        **
			//**       Descripción: Forma para captura de un ejecutivo Banamex          **
			//**                    en la busqueda especifica de catalogos              **
			//**                                                                        **
			//**       Responsable:                                                     **
			//**                                                                        **
			//**       Ultima Fecha de Modificación: 24/Junio/1994                      **
			//**                                                                        **
			//**       NOTA: Esta forma necesita Visual Basic 3.0                       **
			//**                                                                        **
			//****************************************************************************
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					
					this.Left = (int) VB6.TwipsToPixelsX((((float) VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float) VB6.PixelsToTwipsX(this.Width))) / 2);
					this.Top = (int) VB6.TwipsToPixelsY((((float) VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float) VB6.PixelsToTwipsY(this.Height))) / 2);
					
			}
			
			private void  ID_IRA_CAN_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					CORVAR.bgblCerrar = -1;
					this.Close();
					
			}
			
			private void  ID_IRA_NOM_PIC_KeyPressEvent( Object eventSender,  AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
			{
					
					if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != CORVB.KEY_BACK)
					{
						eventArgs.keyAscii = 0;
					}
					
			}
			
			private void  ID_IRA_NOM_PIC_Leave( Object eventSender,  EventArgs eventArgs)
			{
					
					ID_IRA_NOM_PIC.CtlText = StringsHelper.Format(ID_IRA_NOM_PIC.CtlText, "00000000");
					
			}
			
			
			private void  ID_IRA_OK_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					int hConexion = 0;
					int hEjeBan = 0;
					int iError = 0;
					string pszEjxDesc = String.Empty;
					int iValor = 0;
					int reg_mod = 0;
                    try
                    {

                   	
					CORVAR.lgblEjxCve = Convert.ToInt32(Conversion.Val(ID_IRA_NOM_PIC.CtlText));
					
					if (CORVAR.lgblEjxCve <= CORVB.NULL_INTEGER)
					{
						this.Cursor = Cursors.Default;
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
						Interaction.MsgBox("La clave del Ejecutivo no deberá ser cero", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
						ID_IRA_NOM_PIC.Focus();
						return;
					}
					
					CORVAR.bgblIrExiste = 0;
					CORVAR.bgblCerrar = 0;
					
					this.Cursor = Cursors.WaitCursor;
					
					//Obtiene los Campos de la tabla de Ejecutivos Banamex
					//ros  igblErr = qeSetSelectOptions(hConexion, QE_UP_DOWN_DIR)
					//pszgblsql = "exec ira_ejebnx " + Format$(lgblEjxCve)
					CORVAR.pszgblsql = "select ejx_nombre from MTCEJX01 ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "where ejx_numero = " + CORVAR.lgblEjxCve.ToString();
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
						{
							pszEjxDesc = VBSQL.SqlData(CORVAR.hgblConexion, 1);
							CORVAR.pszgblEjxDesc = pszEjxDesc;
							CORVAR.bgblIrExiste = -1;
						}
					}
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					
					
					if (CORVAR.bgblIrExiste != 0)
					{
						this.Close();
					} else
					{
						this.Cursor = Cursors.Default;
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
						Interaction.MsgBox("El Ejecutivo seleccionado no existe en catálogos", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
						ID_IRA_NOM_PIC.CtlText = CORVB.NULL_INTEGER.ToString();
						ID_IRA_NOM_PIC.Focus();
					}
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Fallo operación ID_IRA_OK_PB_Click " + exc.Message, "Error Corirejb", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
					
			}
			private void  CORIREJB_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}