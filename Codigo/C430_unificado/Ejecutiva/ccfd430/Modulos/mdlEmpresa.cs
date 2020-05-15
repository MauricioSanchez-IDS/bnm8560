using Artinsoft.VB6.Utils; 
using Artinsoft.VB6.VB; 
using Microsoft.VisualBasic; 
using System; 
using System.Globalization; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	class mdlEmpresa
	{
	
		
		//Parametros para la configuración de la empresa
		public const int cteiLongitudEmpresaEjecutivo = 8;
		
		//Parámetros de Configuración
		public const string ctesFormatoFecha = "dd/mm/yyyy";
		public const string ctesFormatoHora = "hh:mm";
		public const string ctesSeparadorFecha = "/";
		
		//Constantes de Sector
		public const string ctesSectorIndustrial = "01 Industrial";
		public const string ctesSectorComercial = "02 Comercial";
		public const string ctesSectorServicios = "03 Servicios";
		public const string ctesSectorFinanciero = "04 Financiero";
		public const string ctesSectorPublico = "05 Sector Público";
		public const string ctesSectorGobFed = "06 Gobierno Federal";
		public const string ctesSectorGobEst = "07 Gobierno Estatal y Municipal";
		public const string ctesSectorOtros = "08 Otros";
		
		//Constantes de Generación de Plástico
		public const int cteiSiPlasticoSiPIN = 0;
		public const int cteiNoPlasticoNoPIN = 1;
		public const int cteiSiPlasticoNoPIN = 2;
		
		//Constantes Globales de Generación de SBF
		public const int cteiNoGenerarSBFNoDerivado = 0;
		public const int cteiNoGenerarSBFSiDerivado = 1;
		public const int cteiSiGenerarSBFNoDerivado = 2;
		public const int cteiSiGenerarSBFSiDerivado = 3;
		public const int cteiSiGenerarSBFCycleDailySiDerivado = 4;
		public const int cteiSiGenerarSBFCycleDailyNoDerivado = 5;
		
		//Parámetros de Crédito
		public const int ctelLimiteCredito = 999999999;
		public const int cteiDiaCorte = 17;
		public const int cteiPlazoGracia = 15;
		public const string ctesMascaraDinero = "###,###,##0.00";
		
		//Constantes Generales del Sistema
		public const string ctesEmpCorporativo = "C";
		public const string ctesEmpEmpresa = "E";
		public const string ctesEmpIndividual = "I";
		
		//Constantes Generales del Sistema
		public const string ctesEjeCorporativo = "C";
		public const string ctesEjeIndividual = "I";
		
		//Constantes para tipos de pago
		public const string ctesPagoAutomatico = "A";
		public const string ctesPagoIndividual = "I";
		public const string ctesPagoLibre = "L";
		
		public const string ctesTotal = "T";
		public const string ctesMinimo = "M";
		
		public const string ctesBusinessCard = "B";
		public const string ctesPurchasingCard = "P";
		public const string ctesDistributionLine = "D";
		
		//Constantes de la Cuenta
		public const string ctesNoCuentaControl = "";
		public const string ctesSiCuentaControl = "C";
		
		//Costantes de Nacionalidad
		public const string ctesMexicana = "1";
		public const string ctesExtranjera = "2";
		
		//Constantes de Tipo de Pago
		public const string ctesEmpAutomatico = "A";
		public const string ctesEmpLibre = "L";
		
		//Constante de Tipo de Bloqueo
		public const int cteiNoManejaBloqueo = 0;
		public const int cteiBloqueoPorMCC = 1;
		public const int cteiBloqueoPorNegocio = 2;
		
		//Constante de Persona
		public const int ctePersonaMoral = 1; //FSWB NR 20070221
		public const int ctePersonaFisica = 1; //FSWB NR 20070221
		public const int ctePersonaFisicaAE = 1; //FSWB NR 20070221
		
		//Variable de Reenvío
		static public int intReenvio = 0;
		
		static public void  prLlenaEstruct( ComboBox ctrlpControl)
		{
			
			int llRegistros = 0;
			int llEstruct = 0;
			string slEstructName = String.Empty;
			int llCont = 0;
			ComboBox cmblCombo = null;
			
			try
			{
					
					cmblCombo = ctrlpControl;
					cmblCombo.Items.Clear();
					
					CORVAR.pszgblsql = "select";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " exp_struc_id,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " exp_strucy_name";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEST01";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " where exp_eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
					
					llCont = 1;
					cmblCombo.Items.Insert(0, "NINGUNA");
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							llEstruct = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
							slEstructName = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim();
							cmblCombo.Items.Insert(llCont, slEstructName);
							VB6.SetItemData(cmblCombo, llCont, llEstruct);
							llCont++;
						};
					}
					cmblCombo.SelectedIndex = 0;
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
				}
                catch (Exception e)
			{
				
				
				CRSGeneral.prObtenError("mdlEmpresa (LlenaStruct)",e );
				return;
			}
		}
		
		static public void  prLlenaMeses( ComboBox ctrlpControl)
		{
			
			ComboBox cmblCombo = null;
			
			try
			{
					
					cmblCombo = ctrlpControl;
					cmblCombo.Items.Clear();
					
					for (int ilMeses = 0; ilMeses <= 12; ilMeses++)
					{
						if (ilMeses == 0)
						{
							cmblCombo.Items.Add("NINGUNO");
							VB6.SetItemData(cmblCombo, 0, ilMeses);
						} else
						{
							cmblCombo.Items.Add(DateTimeFormatInfo.CurrentInfo.GetMonthName(ilMeses).ToUpper());
							VB6.SetItemData(cmblCombo, ilMeses, ilMeses);
						}
					}
					cmblCombo.SelectedIndex = 0;
				}
                catch (Exception e)
			{
				
				
				CRSGeneral.prObtenError("mdlEmpresa (LlenaMeses)",e );
				return;
			}
		}
		
		static public void  prLlenaSector( ComboBox ctrlControl)
		{
			
			int llCont = 0;
			ComboBox cmblCombo = null;
			
			try
			{
					
					cmblCombo = ctrlControl;
					cmblCombo.Items.Clear();
					
					cmblCombo.Items.Add(ctesSectorIndustrial);
					VB6.SetItemData(cmblCombo, 0, 1);
					cmblCombo.Items.Add(ctesSectorComercial);
					VB6.SetItemData(cmblCombo, 1, 2);
					cmblCombo.Items.Add(ctesSectorServicios);
					VB6.SetItemData(cmblCombo, 2, 3);
					cmblCombo.Items.Add(ctesSectorFinanciero);
					VB6.SetItemData(cmblCombo, 3, 4);
					cmblCombo.Items.Add(ctesSectorPublico);
					VB6.SetItemData(cmblCombo, 4, 5);
					cmblCombo.Items.Add(ctesSectorGobFed);
					VB6.SetItemData(cmblCombo, 5, 6);
					cmblCombo.Items.Add(ctesSectorGobEst);
					VB6.SetItemData(cmblCombo, 6, 7);
					cmblCombo.Items.Add(ctesSectorOtros);
					VB6.SetItemData(cmblCombo, 7, 8);
					cmblCombo.SelectedIndex = 0;
				}
                catch (Exception e)
			{
				
				
				CRSGeneral.prObtenError("mdlEmpresa (LlenaSector)",e );
				return;
			}
			
		}
		
		static public bool fncObtieneEjecutivosB()
		{
			
			string slNombreEje = String.Empty; //Nombre del Ejecutivo Banamex
			int llNominaEje = 0; //Número de Nómina del Ejecutivo Banamex
			
			try
			{
					
					CORVAR.pszgblsql = "select";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " ejx_numero,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " ejx_nombre";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEJX01";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " order by ejx_nombre";
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						frmEmpresa.DefInstance.cmbEmpresa[3].Items.Clear();
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							llNominaEje = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
							slNombreEje = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim();
							frmEmpresa.DefInstance.cmbEmpresa[3].Items.Add(StringsHelper.Format(llNominaEje, "0000000") + new String(' ', 3) + slNombreEje.Trim());
						};
					}
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					
					
					if (frmEmpresa.DefInstance.cmbEmpresa[3].Items.Count > 0)
					{
						frmEmpresa.DefInstance.cmbEmpresa[3].SelectedIndex = 0;
						return true;
					} else
					{
						return false;
					}
				}
                catch (Exception e)
			{
				
				
				CRSGeneral.prObtenError("mdlEmpresa (ObtieneEjecutivos)",e );
				return false;
			}
			
			return false;
		}
		
		static public clsEjecutivoBanamex fncBuscaEjecutivoEmpresaEJX( int lpNomina)
		{
			int llCont = 0;
			
			clsEjecutivoBanamex ejxlEjecutivoBanamex = new clsEjecutivoBanamex();
			
			int llIndice = mdlParametros.gcejxEjecutivoBanamex.fncBuscaEjecutivoBanamexL(lpNomina);
			
			if (llIndice != 0)
			{
				
				ejxlEjecutivoBanamex = mdlParametros.gcejxEjecutivoBanamex[llIndice];
				frmEmpresa.DefInstance.cmbEmpresa[3].Text = StringsHelper.Format(ejxlEjecutivoBanamex.NominaL, "0000000") + new String(' ', 10) + ejxlEjecutivoBanamex.NombreS.Trim();
				//        Do While Not llCont = gcejxEjecutivoBanamex.Count
				//            frmEmpresa.cmbEmpresa(3).ListIndex = llCont
				//            If Val(Left(frmEmpresa.cmbEmpresa(3).Text, 7)) = Val(lpNomina) Then
				//                Exit Do
				//            End If
				//            llCont = llCont + 1
				//        Loop
				return ejxlEjecutivoBanamex;
			} else
			{
				MessageBox.Show("No existe ningun Ejecutivo con el Numero de Nomina " + Conversion.Val(StringsHelper.Format(lpNomina, "0000000")).ToString(), AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				frmEmpresa.DefInstance.txtEmpresa[21].Focus();
				return null;
			}
			
			return null;
		}
		
		static public int fncCuentaUnidadesI( int lpEmpresa)
		{
			int result = 0;
			int ilCont = 0;
			
			try
			{
					
					CORVAR.pszgblsql = "select";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " count(*)";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUNI01";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + lpEmpresa.ToString();
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							result = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
						};
					} else
					{
						
					}
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("mdlEmpresa (CuentaUnidades)",e );
				return result;
			}
			
			return result;
		}
		
		static public int fncEstatusSBFI()
		{
			
			try
			{
					
					if (frmEmpresa.DefInstance.chkEmpresa[1].CheckState == CheckState.Unchecked && frmEmpresa.DefInstance.chkEmpresa[3].CheckState == CheckState.Unchecked)
					{
						return cteiNoGenerarSBFNoDerivado;
					} else if (frmEmpresa.DefInstance.chkEmpresa[0].CheckState == CheckState.Unchecked && frmEmpresa.DefInstance.chkEmpresa[3].CheckState == CheckState.Checked) { 
						return cteiNoGenerarSBFSiDerivado;
					} else if (frmEmpresa.DefInstance.chkEmpresa[0].CheckState == CheckState.Checked && frmEmpresa.DefInstance.chkEmpresa[3].CheckState == CheckState.Unchecked) { 
						if (frmEmpresa.DefInstance.chkEmpresa[2].CheckState == CheckState.Unchecked)
						{
							return cteiSiGenerarSBFNoDerivado;
						} else if (frmEmpresa.DefInstance.chkEmpresa[2].CheckState == CheckState.Checked) { 
							return cteiSiGenerarSBFCycleDailyNoDerivado;
						}
					} else if (frmEmpresa.DefInstance.chkEmpresa[0].CheckState == CheckState.Checked && frmEmpresa.DefInstance.chkEmpresa[3].CheckState == CheckState.Checked) { 
						if (frmEmpresa.DefInstance.chkEmpresa[2].CheckState == CheckState.Unchecked)
						{
							return cteiSiGenerarSBFSiDerivado;
						} else if (frmEmpresa.DefInstance.chkEmpresa[2].CheckState == CheckState.Checked) { 
							return cteiSiGenerarSBFCycleDailySiDerivado;
						}
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("mdlEmpresa (EstatusSBF)",e );
				return 0;
			}
			return 0;
		}
		
		static public void  prLlenaRepresentanteEmp( int ipNumRepresentante,  clsRepresentante rprpRepresentante)
		{
			
			try
			{
					
					switch(ipNumRepresentante)
					{
						case 1 :  //Representante 1 
							frmEmpresa.DefInstance.txtEmpresa[12].Text = rprpRepresentante.NombreS; 
							frmEmpresa.DefInstance.txtEmpresa[13].Text = rprpRepresentante.PuestoS; 
							frmEmpresa.DefInstance.mskEmpresa[13].CtlText = rprpRepresentante.TelefonoS; 
							frmEmpresa.DefInstance.mskEmpresa[14].CtlText = rprpRepresentante.ExtensionS; 
							frmEmpresa.DefInstance.mskEmpresa[15].CtlText = rprpRepresentante.FaxS; 
							 
							break;
						case 2 :  //Representante 2 
							frmEmpresa.DefInstance.txtEmpresa[12].Text = rprpRepresentante.NombreS; 
							frmEmpresa.DefInstance.txtEmpresa[13].Text = rprpRepresentante.PuestoS; 
							frmEmpresa.DefInstance.mskEmpresa[13].CtlText = rprpRepresentante.TelefonoS; 
							frmEmpresa.DefInstance.mskEmpresa[14].CtlText = rprpRepresentante.ExtensionS; 
							frmEmpresa.DefInstance.mskEmpresa[15].CtlText = rprpRepresentante.FaxS; 
							 
							break;
						case 3 :  //Representante 3 
							frmEmpresa.DefInstance.txtEmpresa[12].Text = rprpRepresentante.NombreS; 
							frmEmpresa.DefInstance.txtEmpresa[13].Text = rprpRepresentante.PuestoS; 
							frmEmpresa.DefInstance.mskEmpresa[13].CtlText = rprpRepresentante.TelefonoS; 
							frmEmpresa.DefInstance.mskEmpresa[14].CtlText = rprpRepresentante.ExtensionS; 
							frmEmpresa.DefInstance.mskEmpresa[15].CtlText = rprpRepresentante.FaxS; 
							 
							break;
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("mdlEmpresa (LlenaRepresentanteEmp)",e );
				return;
			}
			
		}
		
		static public void  prLimpiaRepresentanteEmp()
		{
			
			try
			{
					
					frmEmpresa.DefInstance.txtEmpresa[12].Text = "";
					frmEmpresa.DefInstance.txtEmpresa[13].Text = "";
					frmEmpresa.DefInstance.mskEmpresa[13].CtlText = "";
					frmEmpresa.DefInstance.mskEmpresa[14].CtlText = "";
					frmEmpresa.DefInstance.mskEmpresa[15].CtlText = "";
				}
                catch (Exception e) 
			{
				
				CRSGeneral.prObtenError("mdlEmpresa (LimpiaRepresentanteEmp)",e );
				return;
			}
			
		}
		
		static public void  prImprimirEmpresa( clsDatosEmpresa dtepDatosEmpresa)
		{
			
			try
			{
					
					PrinterHelper.Printer.FontName = "Courier New";
					
					PrinterHelper.Printer.FontBold = true;
					
					PrinterHelper.Printer.Print();
					PrinterHelper.Printer.Print(new String(' ', 24) + frmEmpresa.DefInstance.Text);
					PrinterHelper.Printer.Print(new String(' ', 24) + new string('-', Strings.Len(frmEmpresa.DefInstance.Text)));
					PrinterHelper.Printer.Print();
					PrinterHelper.Printer.Print("PREFIJO                : " + StringsHelper.Format(mdlParametros.gprdProducto.PrefijoL, mdlParametros.gprdProducto.MascaraPrefijoS));
					PrinterHelper.Printer.Print("BANCO                  : " + StringsHelper.Format(mdlParametros.gprdProducto.BancoL, mdlParametros.gprdProducto.MascaraBancoS));
					PrinterHelper.Printer.Print("GRUPO                  : " + dtepDatosEmpresa.EmpGpoNumL.ToString());
					PrinterHelper.Printer.Print("EMPRESA                : " + StringsHelper.Format(dtepDatosEmpresa.EmpNumL, mdlParametros.gprdProducto.MascaraEmpresaS));
					
					PrinterHelper.Printer.FontBold = false;
					
					PrinterHelper.Printer.Print();
					PrinterHelper.Printer.Print("NOMBRE LARGO           : " + dtepDatosEmpresa.EmpNomS);
					PrinterHelper.Printer.Print("NOMBRE CORTO           : " + dtepDatosEmpresa.EmpNomGrabaS);
					PrinterHelper.Printer.Print("RFC                    : " + dtepDatosEmpresa.EmpRfcRFC.fncConstruyeRfcS(true));
					PrinterHelper.Printer.Print("NO. CARTERA            : " + dtepDatosEmpresa.EmpNumCarteraD.ToString());
					PrinterHelper.Printer.Print("SECTOR                 : " + dtepDatosEmpresa.EmpSectorI.ToString());
					PrinterHelper.Printer.Print("PRINCIPAL ACCIONISTA   : " + dtepDatosEmpresa.EmpPrincAccS);
					PrinterHelper.Printer.Print("CREDITO TOTAL ASIGNADO : " + dtepDatosEmpresa.EmpCredTotL.ToString());
					PrinterHelper.Printer.Print("CREDITO ACUMULADO      : " + dtepDatosEmpresa.EmpAcumCredL.ToString());
					PrinterHelper.Printer.Print("FECHA DE VENCIMIENTO   : " + dtepDatosEmpresa.EmpFecVencCredS);
					
					PrinterHelper.Printer.Print();
					
					//Domicilio Fiscal
					PrinterHelper.Printer.Print("     DOMICILIO FISCAL");
					PrinterHelper.Printer.Print();
					PrinterHelper.Printer.Print("CALLE Y NUMERO         : " + dtepDatosEmpresa.EmpDomFiscalDMC.DomicilioS);
					PrinterHelper.Printer.Print("COLONIA                : " + dtepDatosEmpresa.EmpDomFiscalDMC.ColoniaS);
					PrinterHelper.Printer.Print("POBLACION/DEL./MUN.    : " + dtepDatosEmpresa.EmpDomFiscalDMC.PoblacionS);
					PrinterHelper.Printer.Print("CIUDAD                 : " + dtepDatosEmpresa.EmpDomFiscalDMC.CiudadS);
					PrinterHelper.Printer.Print("ESTADO                 : " + dtepDatosEmpresa.EmpDomFiscalDMC.EstadoEST.EstadoS);
					PrinterHelper.Printer.Print("C.P                    : " + dtepDatosEmpresa.EmpDomFiscalDMC.CPL.ToString());
					PrinterHelper.Printer.Print();
					
					//Domicilio de envío
					PrinterHelper.Printer.Print("     DOMICILIO DE ENVIO");
					PrinterHelper.Printer.Print();
					PrinterHelper.Printer.Print("CALLE Y NUMERO         : " + dtepDatosEmpresa.EmpDomEnvioDMC.DomicilioS);
					PrinterHelper.Printer.Print("COLONIA                : " + dtepDatosEmpresa.EmpDomEnvioDMC.ColoniaS);
					PrinterHelper.Printer.Print("POBLACION/DEL./MUN.    : " + dtepDatosEmpresa.EmpDomEnvioDMC.PoblacionS);
					PrinterHelper.Printer.Print("CIUDAD                 : " + dtepDatosEmpresa.EmpDomEnvioDMC.CiudadS);
					PrinterHelper.Printer.Print("ESTADO                 : " + dtepDatosEmpresa.EmpDomEnvioDMC.EstadoEST.EstadoS);
					PrinterHelper.Printer.Print("C.P                    : " + dtepDatosEmpresa.EmpDomEnvioDMC.CPL.ToString());
					PrinterHelper.Printer.Print();
					
					//Representantes
					PrinterHelper.Printer.Print("     REPRESENTANTE 1");
					PrinterHelper.Printer.Print();
					PrinterHelper.Printer.Print("NOMBRE                 : " + dtepDatosEmpresa.EmpRep1RPR.NombreS);
					PrinterHelper.Printer.Print("PUESTO                 : " + dtepDatosEmpresa.EmpRep1RPR.PuestoS);
					PrinterHelper.Printer.Print("TELEFONO               : " + dtepDatosEmpresa.EmpRep1RPR.TelefonoS);
					PrinterHelper.Printer.Print("EXTENSION              : " + dtepDatosEmpresa.EmpRep1RPR.ExtensionS);
					PrinterHelper.Printer.Print("FAX                    : " + dtepDatosEmpresa.EmpRep1RPR.FaxS);
					PrinterHelper.Printer.Print();
					
					PrinterHelper.Printer.Print("     REPRESENTANTE 2");
					PrinterHelper.Printer.Print();
					PrinterHelper.Printer.Print("NOMBRE                 : " + dtepDatosEmpresa.EmpRep2RPR.NombreS);
					PrinterHelper.Printer.Print("PUESTO                 : " + dtepDatosEmpresa.EmpRep2RPR.PuestoS);
					PrinterHelper.Printer.Print("TELEFONO               : " + dtepDatosEmpresa.EmpRep2RPR.TelefonoS);
					PrinterHelper.Printer.Print("EXTENSION              : " + dtepDatosEmpresa.EmpRep2RPR.ExtensionS);
					PrinterHelper.Printer.Print("FAX                    : " + dtepDatosEmpresa.EmpRep2RPR.FaxS);
					PrinterHelper.Printer.Print();
					
					PrinterHelper.Printer.Print("     REPRESENTANTE 3");
					PrinterHelper.Printer.Print();
					PrinterHelper.Printer.Print("NOMBRE                 : " + dtepDatosEmpresa.EmpRep3RPR.NombreS);
					PrinterHelper.Printer.Print("PUESTO                 : " + dtepDatosEmpresa.EmpRep3RPR.PuestoS);
					PrinterHelper.Printer.Print("TELEFONO               : " + dtepDatosEmpresa.EmpRep3RPR.TelefonoS);
					PrinterHelper.Printer.Print("EXTENSION              : " + dtepDatosEmpresa.EmpRep3RPR.ExtensionS);
					PrinterHelper.Printer.Print("FAX                    : " + dtepDatosEmpresa.EmpRep3RPR.FaxS);
					PrinterHelper.Printer.Print();
					
					PrinterHelper.Printer.Print();
					
					if (dtepDatosEmpresa.EmpTipoPagoS == ctesEmpAutomatico)
					{
						PrinterHelper.Printer.Print("TIPO DE PAGO           : CENTRALIZADO");
					} else if (dtepDatosEmpresa.EmpTipoPagoS == ctesEmpIndividual) { 
						PrinterHelper.Printer.Print("TIPO DE PAGO           : INDIVIDUAL");
					}
					
					if (dtepDatosEmpresa.EmpTipoEnvioS == ctesEmpEmpresa)
					{
						PrinterHelper.Printer.Print("ENVIO EDO. CUENTA      : EMPRESA");
					} else if (dtepDatosEmpresa.EmpTipoEnvioS == ctesEmpIndividual) { 
						PrinterHelper.Printer.Print("ENVIO EDO. CUENTA      : INDIVIDUAL");
					}
					
					PrinterHelper.Printer.Print();
					PrinterHelper.Printer.Print("SUCURSAL               : " + dtepDatosEmpresa.EmpSucEjeL.ToString());
					PrinterHelper.Printer.Print("CUENTA DE CAPTACION    : " + dtepDatosEmpresa.EmpCtaEjeD.ToString());
					
					PrinterHelper.Printer.Print();
					PrinterHelper.Printer.Print("EJECUTIVO BANAMEX        : " + dtepDatosEmpresa.EmpEjecutivoBanamexEJX.NombreS);
					
					PrinterHelper.Printer.Print();
					PrinterHelper.Printer.Print("TELEFONO                 : " + dtepDatosEmpresa.EmpTelefonoS);
					PrinterHelper.Printer.Print("EXTENSION                : " + dtepDatosEmpresa.EmpExtensionS);
					PrinterHelper.Printer.Print("LADA                     : " + dtepDatosEmpresa.EmpTelLadaS);
					PrinterHelper.Printer.Print("FAX                      : " + dtepDatosEmpresa.EmpFaxS);
					PrinterHelper.Printer.Print("FAX LADA                 : " + dtepDatosEmpresa.EmpFaxLadaS);
					PrinterHelper.Printer.Print("EMAIL                    : " + dtepDatosEmpresa.EmpEmailS);
					PrinterHelper.Printer.Print("INTERNET                 : " + dtepDatosEmpresa.EmpInternetS);
					PrinterHelper.Printer.EndDoc();
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("mdlEmpresa (Imprimir)",e );
				return;
			}
			
		}
	}
}