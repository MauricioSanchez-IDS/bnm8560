using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.VB; 
using Microsoft.VisualBasic; 
using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal partial class CORMNACL
		: System.Windows.Forms.Form
		{
		
			private void  CORMNACL_Activated( Object eventSender,  EventArgs eventArgs)
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
			//**       Descripción: Consulta de aclaraciones capturadas en MULTERM e    **
			//**                    integradas por el sistema
			//**                                                                        **
			//**       Responsable: Felipe Zacarias Jimenez                                                    **
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
					
					this.Show();
					this.Refresh();
					
					ID_ACL_CTA_EB.Enabled = false;
					ID_ACL_EJE_PNL.Enabled = false;
					ID_ACL_HIS_PNL.Enabled = false;
					ID_ACL_ABO_PNL.Enabled = false;
					ID_ACL_ABD_PNL.Enabled = false;
					ID_ACL_TIP_EB.Enabled = false;
					
			}
			
			private void  ID_ACL_ACE_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					this.Close();
					
			}
			
			private void  ID_ACL_IMP_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
					try
					{
							
							PrinterHelper.Printer.FontName = "Courier New";
							
							PrinterHelper.Printer.FontBold = true;
							
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print(new String(' ', 24) + Text);
							PrinterHelper.Printer.Print(new String(' ', 24) + new string('-', Strings.Len(Text)));
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print("CUENTA                 : " + ID_ACL_CTA_EB.Text);
							PrinterHelper.Printer.Print("NOMBRE                 : " + ID_ACL_NOM_EB.Text);
							PrinterHelper.Printer.Print("EMPRESA                : " + ID_ACL_EMP_EB.Text);
							PrinterHelper.Printer.Print("NIVEL JERARQUICO       : " + ID_ACL_NIV_EB.Text);
							PrinterHelper.Printer.Print("TIPO                   : " + ID_ACL_TIP_EB.Text);
							
							PrinterHelper.Printer.FontBold = false;
							
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print("ABONO CONDICIONADO");
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print("FECHA                  : " + ID_ACL_FEC_EB.Text);
							PrinterHelper.Printer.Print("IMPORTE                : " + ID_ACL_IMP_EB.Text);
							PrinterHelper.Printer.Print("NO. REGISTRO EN S.S.A. : " + ID_ACL_NREG_EB.Text);
							PrinterHelper.Printer.Print("FECHA DE VENCIMIENTO   : " + ID_ACL_FECV_EB.Text);
							if (ID_ACL_ORI_CKB[0].Value)
							{
								PrinterHelper.Printer.Print("ORIGEN                 : " + "INTERNA BANCO");
							}
							if (ID_ACL_ORI_CKB[1].Value)
							{
								PrinterHelper.Printer.Print("ORIGEN                 : " + "EXTERNA NACIONAL");
							}
							if (ID_ACL_ORI_CKB[2].Value)
							{
								PrinterHelper.Printer.Print("ORIGEN                 : " + "EXTERNA INTERNACIONAL");
							}
							
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print("HISTORIAL");
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print("NUMERO                 : " + ID_ACL_NUM_EB.Text);
							PrinterHelper.Printer.Print("BANCO                  : " + ID_ACL_BAN_EB.Text);
							PrinterHelper.Printer.Print("CLIENTE                : " + ID_ACL_CLI_EB.Text);
							PrinterHelper.Printer.Print("PENDIENTE              : " + ID_ACL_PEN_EB.Text);
							
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print("ABONO DEFINITIVO");
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print("FECHA                  : " + ID_ACL_FECA_EB.Text);
							PrinterHelper.Printer.Print("IMPORTE                : " + ID_ACL_IMPA_EB.Text);
							PrinterHelper.Printer.Print("RESULTADO              : " + ID_ACL_RES_EB.Text);
							
							PrinterHelper.Printer.EndDoc();
						}
					catch (Exception exc)
					{
                        CRSGeneral.prObtenError(this.GetType().Name + "(ID_ACL_IMP_PB_Click)", exc);
                        //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
					}
					
			}
			private void  CORMNACL_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}