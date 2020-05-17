using Artinsoft.VB6.Utils; 
using Artinsoft.VB6.VB; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal partial class CORCONFI
		: System.Windows.Forms.Form
		{
		
			//****************************************************************************
			//**                                                                        **
			//**         CopyRight(C) DDEMESIS, SA DE CV / Banamex - Sistemas           **
			//**                                                                        **
			//**       --------------------------------------------------------         **
			//**                                                                        **
			//**       Descripción: Consulta de Firmas para Ejecutivos de la Empresa    **
			//**                                                                        **
			//**       Responsable: Felipe Zacarias Jimenez                             **
			//**                                                                        **
			//**       Ultima Fecha de Modificación: 06/Junio/1994                      **
			//**                                                                        **
			//**       NOTA: Esta forma necesita Visual Basic 3.0                       **
			//**                                                                        **
			//****************************************************************************
			
			const string CAPTION_ALTA_EJE = "Alta de Ejecutivos de Empresas";
			
			private void  Carga_Imagen()
			{
					
					ID_FIR_FR1_IMM.ClearImage = true;
					ID_FIR_FR2_IMM.ClearImage = true;
					ID_FIR_FR3_IMM.ClearImage = true;
					
					//carga la firma del representate 1
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					//    LeerImagen ID_FIR_FR1_IMM, "MTCEMP01", "emp_fir_r1", "  gpo_banco = " + Format$(igblBanco) + " AND emp_num = " + Format$(lgblNumEmpresa)
					//***** FIN DE CODIGO ANTERIOR FSWBMX *****
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					IMAGEN.LeerImagen(ID_FIR_FR1_IMM, "MTCEMP01", "emp_fir_r1", "  eje_prefijo = " + CORVAR.igblPref.ToString() + " AND gpo_banco = " + CORVAR.igblBanco.ToString() + " AND emp_num = " + CORVAR.lgblNumEmpresa.ToString());
					//***** FIN DE CODIGO ANTERIOR FSWBMX *****
					//Asigna el nombre del Ejecutivo
					ID_FIR_NOM_PNL[0].Caption = CORMNEMP.DefInstance.ID_MEM_NOM_EB[0].Text;
					ID_CFI_ETI_PNL[0].Enabled = true;
					
					//obtiene la firma del ejecitivo 2
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					//   LeerImagen ID_FIR_FR2_IMM, "MTCEMP01", "emp_fir_r2", "  gpo_banco = " + Format$(igblBanco) + " AND emp_num = " + Format$(lgblNumEmpresa)
					//***** FIN DE CODIGO ANTERIOR FSWBMX *****
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					IMAGEN.LeerImagen(ID_FIR_FR2_IMM, "MTCEMP01", "emp_fir_r2", "  eje_prefijo = " + CORVAR.igblPref.ToString() + " AND gpo_banco = " + CORVAR.igblBanco.ToString() + " AND emp_num = " + CORVAR.lgblNumEmpresa.ToString());
					//***** FIN DE CODIGO ANTERIOR FSWBMX *****
					//Asigna el nombre del Ejecutivo
					ID_FIR_NOM_PNL[1].Caption = CORMNEMP.DefInstance.ID_MEM_NOM_EB[1].Text;
					ID_CFI_ETI_PNL[1].Enabled = true;
					
					//obtiene la firma del ejecitivo 3
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					//     LeerImagen ID_FIR_FR3_IMM, "MTCEMP01", "emp_fir_r3", "  gpo_banco = " + Format$(igblBanco) + " AND emp_num = " + Format$(lgblNumEmpresa)
					//***** FIN DE CODIGO ANTERIOR FSWBMX *****
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					IMAGEN.LeerImagen(ID_FIR_FR3_IMM, "MTCEMP01", "emp_fir_r3", "  eje_prefijo = " + CORVAR.igblPref.ToString() + " AND gpo_banco = " + CORVAR.igblBanco.ToString() + " AND emp_num = " + CORVAR.lgblNumEmpresa.ToString());
					//***** FIN DE CODIGO ANTERIOR FSWBMX *****
					//Asigna el nombre del Ejecutivo
					ID_FIR_NOM_PNL[2].Caption = CORMNEMP.DefInstance.ID_MEM_NOM_EB[2].Text;
					ID_CFI_ETI_PNL[2].Enabled = true;
					
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					
					this.Cursor = Cursors.WaitCursor;
					
					this.Top = (int) VB6.TwipsToPixelsY(1880);
					this.Left = (int) VB6.TwipsToPixelsX((((float) VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float) VB6.PixelsToTwipsX(Width))) / 2);
					
                    try
                    {
                        Carga_Imagen();
                    }
                    catch (Exception e)
                    {
                        CRSGeneral.prObtenError(this.GetType().Name + "(Form_Load)", e);
                    }
					this.Cursor = Cursors.Default;
					
			}
			
			private void  ID_FIR_IMP_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
				
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
					try
					{
							
							PrinterHelper.Printer.FontName = "Courier New";
							
							PrinterHelper.Printer.FontBold = true;
							
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print(new String(' ', 24) + "Reporte de Empresas");
							PrinterHelper.Printer.Print(new String(' ', 24) + new string('-', 19));
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print("GRUPO                  : " + CORMNEMP.DefInstance.ID_MEM_TEX_PNL[0].Text);
                            PrinterHelper.Printer.Print("EMPRESA                : " + CORMNEMP.DefInstance.ID_MEM_TEX_PNL[1].Text);
							
							PrinterHelper.Printer.FontBold = false;
							
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print("NOMBRE LARGO           : " + CORMNEMP.DefInstance.ID_MEM_NLG_EB.Text);
							PrinterHelper.Printer.Print("NOMBRE CORTO           : " + CORMNEMP.DefInstance.ID_MEM_NCT_EB.Text);
							PrinterHelper.Printer.Print("RFC                    : " + CORMNEMP.DefInstance.ID_MEM_RFC_MKE.CtlText);
                            PrinterHelper.Printer.Print("NO. CARTERA            : 0");
							PrinterHelper.Printer.Print("SECTOR                 : " + CORMNEMP.DefInstance.ID_MEM_SEC_COB.Text);
							PrinterHelper.Printer.Print("PRINCIPAL ACCIONISTA   : " + CORMNEMP.DefInstance.ID_MEM_PAC_EB.Text); //principal accionista
                            PrinterHelper.Printer.Print("CREDITO TOTAL ASIGNADO : 0");
							PrinterHelper.Printer.Print("CONMMUTADOR            : " + CORMNEMP.DefInstance.ID_MEM_CON_TXT.Text);
							PrinterHelper.Printer.Print();
							
							//Domicilio Fiscal
							PrinterHelper.Printer.Print("     DOMICILIO FISCAL");
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print("CALLE Y NUMERO         : " + CORMNEMP.DefInstance.ID_MEM_DOM_EB[0].Text); //Domicilio Fiscal
							PrinterHelper.Printer.Print("COLONIA                : " + CORMNEMP.DefInstance.ID_MEM_COL_EB[0].Text); //Colonia"
							PrinterHelper.Printer.Print("POBLACION/DEL./MUN.    : " + CORMNEMP.DefInstance.ID_MEM_PDM_EB[0].Text); //Poblacion/delegacion
							PrinterHelper.Printer.Print("CIUDAD                 : " + CORMNEMP.DefInstance.ID_MEM_CIU_EB[0].Text); //Ciudad
							PrinterHelper.Printer.Print("ESTADO                 : " + CORMNEMP.DefInstance.ID_MEM_EDO_EB[0].Text);
							PrinterHelper.Printer.Print("C.P                    : " + CORMNEMP.DefInstance.ID_MEM_CP_PIC[0].CtlText); //Estado
							PrinterHelper.Printer.Print();
							
							//Domicilio de envío
							PrinterHelper.Printer.Print("     DOMICILIO DE ENVIO");
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print("CALLE Y NUMERO         : " + CORMNEMP.DefInstance.ID_MEM_DOM_EB[1].Text); //Doimicilio de envio
							PrinterHelper.Printer.Print("COLONIA                : " + CORMNEMP.DefInstance.ID_MEM_COL_EB[1].Text); //Colonia
							PrinterHelper.Printer.Print("POBLACION/DEL./MUN.    : " + CORMNEMP.DefInstance.ID_MEM_PDM_EB[1].Text); //Poblacion/delegacion
							PrinterHelper.Printer.Print("CIUDAD                 : " + CORMNEMP.DefInstance.ID_MEM_CIU_EB[1].Text); //Ciudad
							PrinterHelper.Printer.Print("ESTADO                 : " + CORMNEMP.DefInstance.ID_MEM_EDO_EB[1].Text);
							PrinterHelper.Printer.Print("C.P                    : " + CORMNEMP.DefInstance.ID_MEM_CP_PIC[1].CtlText); //Estado
							PrinterHelper.Printer.Print();
							
							
							//Representantes
							PrinterHelper.Printer.Print("     REPRESENTANTE 1");
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print("NOMBRE                 : " + CORMNEMP.DefInstance.ID_MEM_NOM_EB[0].Text); //Nombre de representante1"
							PrinterHelper.Printer.Print("PUESTO                 : " + CORMNEMP.DefInstance.ID_MEM_PUE_EB[0].Text); //Puesto"
							PrinterHelper.Printer.Print("TELEFONO               : " + CORMNEMP.DefInstance.ID_MEM_TEL_MKE[0].CtlText);
							PrinterHelper.Printer.Print("EXTENSION              : " + CORMNEMP.DefInstance.ID_MEM_EXT_PIC[0].CtlText);
							PrinterHelper.Printer.Print("FAX                    : " + CORMNEMP.DefInstance.ID_MEM_FAX_MKE[0].CtlText); //Telefono
							PrinterHelper.Printer.Print(); //Extension
							
							PrinterHelper.Printer.Print("     REPRESENTANTE 2");
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print("NOMBRE                 : " + CORMNEMP.DefInstance.ID_MEM_NOM_EB[1].Text); //Nombre de representante2
							PrinterHelper.Printer.Print("PUESTO                 : " + CORMNEMP.DefInstance.ID_MEM_PUE_EB[1].Text); //Puesto
							PrinterHelper.Printer.Print("TELEFONO               : " + CORMNEMP.DefInstance.ID_MEM_TEL_MKE[1].CtlText);
							PrinterHelper.Printer.Print("EXTENSION              : " + CORMNEMP.DefInstance.ID_MEM_EXT_PIC[1].CtlText);
							PrinterHelper.Printer.Print("FAX                    : " + CORMNEMP.DefInstance.ID_MEM_FAX_MKE[1].CtlText); //Telefono
							PrinterHelper.Printer.Print(); //Extension
							
							PrinterHelper.Printer.Print("     REPRESENTANTE 3");
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print("NOMBRE                 : " + CORMNEMP.DefInstance.ID_MEM_NOM_EB[2].Text); //Nombre de representante3
							PrinterHelper.Printer.Print("PUESTO                 : " + CORMNEMP.DefInstance.ID_MEM_PUE_EB[2].Text); //Puesto
							PrinterHelper.Printer.Print("TELEFONO               : " + CORMNEMP.DefInstance.ID_MEM_TEL_MKE[2].CtlText);
							PrinterHelper.Printer.Print("EXTENSION              : " + CORMNEMP.DefInstance.ID_MEM_EXT_PIC[2].CtlText);
							PrinterHelper.Printer.Print("FAX                    : " + CORMNEMP.DefInstance.ID_MEM_FAX_MKE[2].CtlText); //Telefono
							PrinterHelper.Printer.Print(); //Extension
							
							PrinterHelper.Printer.Print();
							if (CORMNEMP.DefInstance.ID_MEM_TPA_3OPB[0].Checked)
							{
								PrinterHelper.Printer.Print("TIPO DE PAGO           : CENTRALIZADO");
							} else
							{
								PrinterHelper.Printer.Print("TIPO DE PAGO           : INDIVIDUAL");
							}
                            if (CORMNEMP.DefInstance.ID_MEM_EEC_3OPB[0].Checked)
							{
								PrinterHelper.Printer.Print("ENVIO EDO. CUENTA      : EMPRESA"); //pszTipoEnv
							} else
							{
								PrinterHelper.Printer.Print("ENVIO EDO. CUENTA      : INDIVIDUAL"); //pszTipoEnv
							}
							
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print("SUCURSAL               : " + CORMNEMP.DefInstance.ID_MEM_SUC_ITB.CtlText);
							PrinterHelper.Printer.Print("CUENTA DE CAPTACION    : " + CORMNEMP.DefInstance.ID_MEM_NMC_FTB.CtlText); //Sucursal"
							
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print("EJECUTIVO BANAMEX        : " + CORMNEMP.DefInstance.ID_MEM_NOM_COB.Text); //Ejecutivo Banamex
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print();
							PrinterHelper.Printer.Print();
							
							PrinterHelper.Printer.FontBold = false;
							
							string pszCadena = new String(' ', 150);
							pszCadena = StringsHelper.MidAssignment(pszCadena, 10, ID_FIR_NOM_PNL[0].Caption);
							pszCadena = StringsHelper.MidAssignment(pszCadena, 60, ID_FIR_NOM_PNL[1].Caption);
							pszCadena = StringsHelper.MidAssignment(pszCadena, 110, ID_FIR_NOM_PNL[2].Caption);
							
							PrinterHelper.Printer.Print(pszCadena);
							
							int hDC = PrinterHelper.Printer.hDC;
                            //AIS-1182 NGONZALEZ
                            CORVAR.igblErr = API.GDI.SetMapMode(hDC, 6);
							
							ID_FIR_FR1_IMM.DebugLevel = 1;
							
							ID_FIR_FR1_IMM.SettingMode = GEAR.MODE_PRINTDRIVER;
							ID_FIR_FR1_IMM.SettingValue = 0;
							ID_FIR_FR1_IMM.PrintSize = GEAR.IG_PRINT_CUSTOM;
							ID_FIR_FR1_IMM.PrintLeft = Convert.ToInt32(1532.1d);
							ID_FIR_FR1_IMM.PrintTop = Convert.ToInt32(1897.7d);
							ID_FIR_FR1_IMM.PrintRight = Convert.ToInt32(2239.3d);
							ID_FIR_FR1_IMM.PrintBottom = Convert.ToInt32(2609.3d);
							//  Print the image to the default printer
							ID_FIR_FR1_IMM.PrintImage = PrinterHelper.Printer.hDC;
							
							ID_FIR_FR2_IMM.SettingMode = GEAR.MODE_PRINTDRIVER;
							ID_FIR_FR2_IMM.SettingValue = 0;
							ID_FIR_FR2_IMM.PrintSize = GEAR.IG_PRINT_CUSTOM;
							ID_FIR_FR2_IMM.PrintLeft = Convert.ToInt32(2946.4d);
							ID_FIR_FR2_IMM.PrintTop = Convert.ToInt32(1897.7d);
							ID_FIR_FR2_IMM.PrintRight = Convert.ToInt32(3653.6d);
							ID_FIR_FR2_IMM.PrintBottom = Convert.ToInt32(2609.3d);
							//  Print the image to the default printer
							ID_FIR_FR2_IMM.PrintImage = PrinterHelper.Printer.hDC;
							
							ID_FIR_FR3_IMM.SettingMode = GEAR.MODE_PRINTDRIVER;
							ID_FIR_FR3_IMM.SettingValue = 0;
							ID_FIR_FR3_IMM.PrintSize = GEAR.IG_PRINT_CUSTOM;
							ID_FIR_FR3_IMM.PrintLeft = Convert.ToInt32(4360.8d);
							ID_FIR_FR3_IMM.PrintTop = Convert.ToInt32(1897.7d);
							ID_FIR_FR3_IMM.PrintRight = Convert.ToInt32(5067.9d);
							ID_FIR_FR3_IMM.PrintBottom = Convert.ToInt32(2609.3d);
							//  Print the image to the default printer
							ID_FIR_FR3_IMM.PrintImage = PrinterHelper.Printer.hDC;
							
							
							PrinterHelper.Printer.EndDoc();
						}
					catch (Exception exc)
					{
						//throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
                        CRSGeneral.prObtenError(this.GetType().Name + "(ID_FIR_IMP_PB_Click)", exc);
					}
					
			}
			
			private void  ID_FIR_SAL_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					ID_FIR_FR1_IMM.ClearImage = true;
					ID_FIR_FR2_IMM.ClearImage = true;
					ID_FIR_FR3_IMM.ClearImage = true;
					
					CORVAR.igblCancela = -1;
					mdlParametros.bgCancela = true;
					
					this.Close();
					
			}
			private void  CORCONFI_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}