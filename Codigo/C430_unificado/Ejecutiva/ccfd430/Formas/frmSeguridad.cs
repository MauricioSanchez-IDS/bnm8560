using Artinsoft.VB6.Gui; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal partial class frmSeguridad
		: System.Windows.Forms.Form
		{
		
			private void  frmSeguridad_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			
			private void  cmdSeguridad_Click( Object eventSender,  EventArgs eventArgs)
			{
					int Index = Array.IndexOf(cmdSeguridad, eventSender);
					
					prDeshabilitaBoton();
					
					switch(Index)
					{
						case 0 :  //Aceptar 
							if (mdlSeguridad.bgChecaUser)
							{
								if (txtSeguridad[0].Text == mdlParametros.sgUserCamLimCred)
								{
									MessageBox.Show("No se puede firmar con el mismo usuario que hizo el cambio.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
									mdlSeguridad.bgSeguridadS041 = false;
									prHabilitaBoton();
									return;
								} else
								{
									if (txtSeguridad[0].Text != CRSParametros.sgUserID)
									{
										MessageBox.Show("No se puede firmar con diferente usuario para hacer el cambio.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
										mdlSeguridad.bgSeguridadS041 = false;
										prHabilitaBoton();
										return;
									}
								}
							} else
							{
								if (txtSeguridad[0].Text != CRSParametros.sgUserID)
								{
									MessageBox.Show("No se puede firmar con diferente usuario para hacer el cambio.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
									mdlSeguridad.bgSeguridadS041 = false;
									prHabilitaBoton();
									return;
								}
							} 
							string tempRefParam = ""; 
							mdlSeguridad.fncFirmaS041B(ref tempRefParam, "", "", mdlSeguridad.enuTipoDlgSeguridad.tDesfirmaS041); 
							 
							string tempRefParam2 = txtSeguridad[0].Text.Trim(); 
							if (mdlSeguridad.fncFirmaS041B(ref tempRefParam2, txtSeguridad[1].Text.Trim(), "", mdlSeguridad.enuTipoDlgSeguridad.tFirmaSinModuloS041))
							{
								mdlSeguridad.bgSeguridadS041 = true;
								CORMNEJE.DefInstance.blFirma = false;
								this.Close();
							} else
							{
								MessageBox.Show("No se puede firmar. Intente de nuevo.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
								mdlSeguridad.bgSeguridadS041 = false;
								//                objSeguridad.Disconnect
								prHabilitaBoton();
							} 
							break;
						case 1 :  //Cancelar 
							MessageBox.Show("No se firmo al S041 por lo cual no se podra hacer el cambio.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information); 
							mdlSeguridad.bgSeguridadS041 = false; 
							mdlSeguridad.objSeguridad.Disconnect(); 
							CORMNEJE.DefInstance.blActualizo = false; 
							CORMNEJE.DefInstance.blFirma = false; 
							this.Close(); 
							break;
					}
					
			}
			
			private void  prHabilitaBoton()
			{
					
					for (int ilCont = 0; ilCont <= 1; ilCont++)
					{
						cmdSeguridad[ilCont].Enabled = true;
					}
					
			}
			
			private void  prDeshabilitaBoton()
			{
					
					for (int ilCont = 0; ilCont <= 1; ilCont++)
					{
						cmdSeguridad[ilCont].Enabled = false;
					}
					
			}
			private void  frmSeguridad_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}