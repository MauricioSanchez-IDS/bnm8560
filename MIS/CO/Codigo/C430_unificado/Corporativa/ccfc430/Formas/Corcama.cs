using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using Microsoft.VisualBasic.Compatibility.VB6; 
using System; 
using System.Drawing; 
using System.Text; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;
using System.Data.Odbc;

namespace TCc430
{
	internal partial class CORCAMA
		: System.Windows.Forms.Form
		{
		
			private void  CORCAMA_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			
			int iErr = 0;
			private Conecta.ConexionesHost _ConComDrive = null;
			Conecta.ConexionesHost ConComDrive
			{
				get
				{
					if (_ConComDrive == null)
					{
						_ConComDrive = new Conecta.ConexionesHost();
					}
					return _ConComDrive;
				}
				set
				{
					_ConComDrive = value;
				}
			}
			
			bool BolProcesando = false;
			
			
			int intCont = 0;
			
			
			//****************************************************************************
			//**                                                                        **
			//**       Descripción:                                                     **
			//**                   Lee la tabla de cambios pendientes MTCCAM01 y mestra **
			//**                   en pantalla los cambios pendientes que se realizaron **
			//**                   proceso de catalogo de empresas                      **
			//**                                                                        **
			//**                                                                        **
			//**       Paso de parámetros:                                              **
			//**                                                                        **
			//**       Valor de Regreso: Ninguno                                        **
			//**                                                                        **
			//**                                                                        **
			//**       Ultima modificacion: 12oct98                                     **
			//**                                                                        **
			//****************************************************************************'
			
			private void  CambiosPendientesS111()
			{
					
					string pszSQL = String.Empty;
					string pszPrefijo = String.Empty;
					string pszBanco = String.Empty;
					string pszEmp = String.Empty;
					string pszEjeNum = String.Empty;
					string pszRollOver = String.Empty;
					string pszEjeDigi = String.Empty;
					string pszNombre = String.Empty;
					string pszCadena = String.Empty;
					string pszNumCta = String.Empty;
					string pszMensaje = String.Empty;
					
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
					try
					{
							
							//Se inicializa el ListBox de Mensajes
							ID_CAM_MEN_LIB.Items.Clear();
							int lContador = 0;
							ID_CAM_CONT_LBL.Text = lContador.ToString();
							
							//Arma las sentencia SQL de consulta de la tabla de cambios masivos
							CORVAR.pszgblsql = "select eje_prefijo, gpo_banco, emp_num, eje_num, eje_roll_over,   ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_digit, eje_nombre,cam_mensaje from " + CORBD.DB_SYS_CAM;
							CORVAR.pszgblsql = CORVAR.pszgblsql + " where cam_estado = 'No Proce'";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " and cam_proceso = 'DomicilioEmp'"; //sólo mostrará los cambios realizados por empresa
							CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_prefijo = " + CORVAR.igblPref.ToString();
							CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
							CORVAR.pszgblsql = CORVAR.pszgblsql + " order by emp_num,eje_num ";
							
							//    MsgBox "Número de cambios pendientes con estado 'No proce': " & CStr(Cuenta_Registros)
							
							//Realiza la busqueda de mensajes en la taba MTCRRO01
							if (CORPROC2.Obtiene_Registros() != 0)
							{
								
								while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
								{
									pszPrefijo = VBSQL.SqlData(CORVAR.hgblConexion, 1);
									pszBanco = VBSQL.SqlData(CORVAR.hgblConexion, 2);
									pszEmp = VBSQL.SqlData(CORVAR.hgblConexion, 3);
									pszEjeNum = VBSQL.SqlData(CORVAR.hgblConexion, 4);
									pszRollOver = VBSQL.SqlData(CORVAR.hgblConexion, 5);
									pszEjeDigi = VBSQL.SqlData(CORVAR.hgblConexion, 6);
									pszNombre = VBSQL.SqlData(CORVAR.hgblConexion, 7);
									pszMensaje = VBSQL.SqlData(CORVAR.hgblConexion, 8);
									
									//pszNombre = UCase$(pszNombre)
									pszCadena = new String(' ', 100);
									
									
									//Arma el num de cuenta
									pszNumCta = pszPrefijo + pszBanco + StringsHelper.Format(pszEmp, Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format(pszEjeNum, Formato.sMascara(Formato.iTipo.Ejecutivo)) + pszRollOver + pszEjeDigi;
									
									//Arma la cadena
									pszCadena = StringsHelper.MidAssignment(pszCadena, 1, pszNombre);
									pszCadena = StringsHelper.MidAssignment(pszCadena, 28, pszNumCta);
									pszCadena = StringsHelper.MidAssignment(pszCadena, 48, pszEmp);
									pszCadena = StringsHelper.MidAssignment(pszCadena, 58, pszBanco);
									pszCadena = StringsHelper.MidAssignment(pszCadena, 67, pszMensaje);
									
									//Agrega la cadena al list
									ID_CAM_MEN_LIB.Items.Add(pszCadena);
									lContador++;
									
								};
								ID_CAM_CONT_LBL.Text = lContador.ToString();
							}
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
						}
					catch (Exception exc)
					{
						throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
					}
					
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
					try
					{
							
							this.Cursor = Cursors.WaitCursor;
							
							//Centra la forma
							this.Left = (int) VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(Screen.PrimaryScreen.Bounds.Width) - ((float) VB6.PixelsToTwipsX(this.Width))) / 2);
							
							//Muestra los registros de la integración diaria
							CambiosPendientesS111();
							CRSGeneral.prAsignaScrollBar(scrScroll, picPicture, ID_CAM_MEN_LIB);
							
							this.Cursor = Cursors.Default;
						}
					catch (Exception exc)
					{
						throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
					}
					
			}
			
			
			private void  CORCAMA_Closed( Object eventSender,  EventArgs eventArgs)
			{
					VBSQL.subCanConRec(ref intCont);
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
			
			private void  ID_CAM_ACE_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					int liEdo = 0;
					int llNomina = 0;
					FixedLengthString fsNomina = new FixedLengthString(4);
					FixedLengthString lsPassword = new FixedLengthString(8);
					
					string pszRepS111 = String.Empty;
					string pszCadena = String.Empty;
					int iPos = 0;
					string pszResAcc = String.Empty;
					string pszMensajeS111 = String.Empty;
					
					string pszExiste = String.Empty;
					int lID = 0;
					TransS111.EnumEstadosFirma enEstadoFirma = (TransS111.EnumEstadosFirma) 0;
					pryActualizaS111.ClsConectaS111 objTransaccionS111 = null;
					try
					{
							
							
							this.Cursor = Cursors.WaitCursor;
							if (ID_CAM_MEN_LIB.Items.Count == 0)
							{
								this.Cursor = Cursors.Default;
								MessageBox.Show("No hay registros a procesar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
								return;
							}
							
							
							objTransaccionS111 = new pryActualizaS111.ClsConectaS111();
                            frmLoginS53 frmFirma = new frmLoginS53();
                            var regreso = frmFirma.ShowDialog();


                            if (regreso.ToString() != "OK")
                            {
							//if (objTransaccionS111.FnPreguntaPwd())
							//{
								RealizaCambiosMasivos(objTransaccionS111);
							} else
							{
                                //AIS-1146 NGONZALEZ
                                bool tempBool = true;
								MdlCambioMasivo.MsgInfo(objTransaccionS111.get_MsgError(ref tempBool));
							}
							objTransaccionS111 = null;
							this.Cursor = Cursors.Default;
						}
					catch (Exception excep)
					{
						
						MdlCambioMasivo.MsgError(excep.Message);
						this.Cursor = Cursors.Default;
					}
			}
			
			
			//****************************************************************************
			//**                                                                        **
			//**       Descripción: Realiza los cambios masivos en el S111 y en el      **
			//**                    micro. Realizando primero el proceso en el S111     **
			//**                    y si este fue exito se realiza en el micro.         **
			//**                    Si hubo error se realiza una bitacora de los errores**
			//**                                                                        **
			//**                                                                        **
			//**       Paso de parámetros:                                              **
			//**                                                                        **
			//**       Valor de Regreso: Ninguno                                        **
			//**                                                                        **
			//**                                                                        **
			//**       Ultima modificacion: 22-Abril-2004                                     **
			//**                                                                        **
			//****************************************************************************

        private void RealizaCambiosMasivos(pryActualizaS111.ClsConectaS111 objTransS111)
        {
            string pszSQL = String.Empty;
            string pszCadena = String.Empty;
            string pszPrefijo = String.Empty;
            string pszBanco = String.Empty;
            int lEmpresa = 0;
            string pszEmpresas = String.Empty;
            int iEjeNum = 0;
            int iEjeDig = 0;
            int iRollOver = 0;
            string pszCalle = String.Empty;
            string pszColonia = String.Empty;
            string pszPob = String.Empty;
            string pszCP = String.Empty;
            string pszNumCuenta = String.Empty;
            string pszNombre = String.Empty;
            string pszZP = String.Empty;
            string pszTelPart = String.Empty;
            string pszTelOfi = String.Empty;
            string pszExt = String.Empty;
            string pszSubActi = String.Empty;
            string pszCalleEmp = String.Empty;
            string pszColEmp = String.Empty;
            string pszPobEmp = String.Empty;
            string pszEdoEmp = String.Empty;
            int lCPEmp = 0;
            bool bCambio = false;
            string pszSexo = String.Empty;
            StringBuilder pszEnviaS111 = new StringBuilder();
            pszEnviaS111.Append(String.Empty);
            string pszRegresaS111 = String.Empty;
            int hTemp = 0;
            string pszEspacio = String.Empty;
            string pszMensajeS111 = String.Empty;
            string pszEdo = String.Empty;
            string pszTipo = String.Empty;
            string slRFC = String.Empty;


            bool blContinue = false;

            object slDialogo = null;
            string slRespuesta = String.Empty;
            string slBloque = String.Empty;
            string slCausaError = String.Empty;

            int ilCont = 0;
            int ilLongitudMsg = 0;
            int ilResultado = 0;
            TransS111.EnumRespTransaccion enEstadoTransS111 = (TransS111.EnumRespTransaccion)0;

            // 25-Mar-2010 Cambios Masivos
            TransS111.EnumEstadosFirma EnCausaErrorFirma = (TransS111.EnumEstadosFirma)0;
            //

            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {
                BolProcesando = true;

                //    MsgBox "Ha ingresado a la función 'RealizaCambiosMasivos'"
                this.Cursor = Cursors.WaitCursor;

                //int iBaseConteo = Int32.Parse(mdlParametros.fncReadIniS("Corporativa", "baseRegProcS111"));
                int iBaseConteo = Int32.Parse(mdlParametros.valorRegistro(2, "SOFTWARE\\Banamex\\C430_001\\TarjetaCorporativa\\Parametros", "baseRegProcS111").Trim());
                int lMultiplos = iBaseConteo;
                int lContador = 0;

                iErr = CORCONST.OK;
                int iTempRow = CORVB.NULL_INTEGER;
                int iCountRow = CORVB.NULL_INTEGER;
                int iFlood = CORVB.NULL_INTEGER;
                int bColorCambiado = 0;

                int iRegs;
                //string connectionString = "Dsn=c430;uid=c430_dbo;pwd=" + CORDBLIB.gsPassword;
                //string connectionString = "Dsn=" + CORDBLIB.gsServidor + "; uid =" + CORDBLIB.gsUsuario + ";pwd=" + CORDBLIB.gsPassword;
                //string connectionString = "Dsn=" + CORDBLIB.gsServidor + "; uid =" + CORDBLIB.gsUsuario + ";pwd=" + CORDBLIB.gsPassword + ";keeporgmultibyte=1" + ";Charset=iso_1;";
                string connectionString = "Dsn=" + CORDBLIB.gsServidor + "; uid =" + CORDBLIB.gsUsuario + ";pwd=" + CORDBLIB.gsPassword + ";keeporgmultibyte=1" + ";Charset=iso_1" + ";EncryptPassword=1;";

                OdbcConnection conexion = new OdbcConnection(connectionString);

                intCont = CORDBLIB.Segunda_ConexionServidor();

                if (intCont == 0)
                {
                    this.Cursor = Cursors.Default;
                    Interaction.MsgBox(CORSTR.STR_NO_CONEXION, (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONSTOP)), CORSTR.STR_APP_TIT);
                    CORPROC2.Libera_Memoria(CORVAR.hgblConexion2);
                    VBSQL.SqlClose(CORVAR.hgblConexion2);
                    BolProcesando = false;
                    return;
                }

                Application.DoEvents();

                SSPanel1.FloodType = Threed.enumFloodTypeConstants._LeftToRight;
                SSPanel1.FloodShowPct = true;
                SSPanel1.FloodPercent = (short)CORVB.NULL_INTEGER;
                SSPanel1.ForeColor = ColorTranslator.FromOle(CORVB.BLACK);
                CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = "Realizando Cambios Masivos";
                CORMDIBN.DefInstance.ID_COR_MSG_TXT.Visible = true;

                //Consulta a la tabla de Cambios masivos
                CORVAR.pszgblsql = " select eje_prefijo,gpo_banco,emp_num,eje_num,eje_roll_over, ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_digit,cam_calle,cam_col,cam_pob,cam_zp,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " cam_cp, cam_tel_dom,cam_tel_ofi,cam_ext,cam_sexo,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " cam_acti_subacti,cam_calle_emp,cam_col_emp,cam_pob_emp,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " cam_cp_emp,eje_nombre,cam_estado_emp,cam_tipo, cam_rfc";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCCAM01";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where cam_estado = 'No Proce'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and cam_mensaje not like  '%OPE NEG%'       ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and cam_proceso = 'DomicilioEmp'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_prefijo = " + CORVAR.igblPref.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " order by eje_prefijo,gpo_banco,emp_num,eje_num ";

                OdbcCommand command = new OdbcCommand(CORVAR.pszgblsql, conexion);
                conexion.Open();
                OdbcDataReader reader = command.ExecuteReader();

                //Obtiene el total de registros
                iTempRow = CORPROC2.Cuenta_Registros();

                //    MsgBox "Número de registros con estado 'No proce': " & iTempRow

                if (iTempRow != 0)
                {
                    while (reader.Read())
                    {
                        lContador++;
                        bCambio = false;
                        //            MsgBox "Extrayendo registro de la consulta a la tabla de cambios"

                        pszPrefijo = reader[0].ToString();
                        pszBanco = reader[1].ToString();
                        lEmpresa = Convert.ToInt32(Conversion.Val(reader[2].ToString()));
                        pszEmpresas = StringsHelper.Format(lEmpresa, Formato.sMascara(Formato.iTipo.Empresa));
                        iEjeNum = Convert.ToInt32(Conversion.Val(reader[3].ToString()));
                        iRollOver = Convert.ToInt32(Conversion.Val(reader[4].ToString()));
                        iEjeDig = Convert.ToInt32(Conversion.Val(reader[5].ToString()));
                        pszCalle = reader[6].ToString();
                        pszColonia = reader[7].ToString();
                        pszPob = reader[8].ToString();
                        pszZP = Conversion.Val(reader[9].ToString()).ToString();
                        pszCP = reader[10].ToString();
                        //pszTelPart = (reader[11].ToString()).Substring((reader[11].ToString()).Length - Math.Min((reader[11].ToString()).Length, 7));
                        //pszTelOfi = (reader[12].ToString()).Substring((reader[12].ToString()).Length - Math.Min((reader[12].ToString()).Length, 7));
                        //pszExt = (reader[13].ToString()).Substring((reader[13].ToString()).Length - Math.Min((reader[13].ToString()).Length, 4));
                        pszTelPart = reader[11].ToString().Trim();
                        pszTelOfi = reader[12].ToString().Trim();
                        pszExt = reader[13].ToString().Trim();
                        pszSexo = reader[14].ToString();
                        pszSubActi = reader[15].ToString();
                        pszCalleEmp = reader[16].ToString();
                        pszColEmp = reader[17].ToString();
                        pszPobEmp = reader[18].ToString();
                        lCPEmp = Convert.ToInt32(Conversion.Val(reader[19].ToString()));
                        pszNombre = reader[20].ToString();
                        pszEdoEmp = reader[21].ToString();
                        pszTipo = reader[22].ToString();
                        slRFC = reader[23].ToString();

                        //Arma el numero de cuenta del ejecutivo
                        pszNumCuenta = pszPrefijo + pszBanco + StringsHelper.Format(pszEmpresas, Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format(Conversion.Str(iEjeNum).Trim(), Formato.sMascara(Formato.iTipo.Ejecutivo)) + Conversion.Str(iRollOver).Trim() + Conversion.Str(iEjeDig).Trim();

                        //Compara los datos de calle, colonia, población y cp si son difrentes no se cambia la dirección
                        //si son iguales si cambia la dirección del ejecutivo.
                        if (pszTipo.Trim() == "Empresa")
                        {
                            //Si el tipo de envio es por empresa se asignan los valores por default sino si se comparan los datos
                            bCambio = true;
                            pszCalle = pszCalleEmp;
                            pszColonia = pszColEmp;
                            pszPob = pszPobEmp + " " + pszEdoEmp;
                            pszCP = Conversion.Str(lCPEmp);
                        }
                        else
                        {
                            if ((pszCalle.Trim() == pszCalleEmp.Trim()) || (pszColonia.Trim() == pszColEmp.Trim()) || (pszPob.Trim() == (pszPobEmp.Trim() + " " + pszEdoEmp.Trim())) || (Conversion.Val(pszCP) == Conversion.Val(lCPEmp.ToString())))
                            {
                                bCambio = true;
                                pszCalle = pszCalleEmp;
                                pszColonia = pszColEmp;
                                pszPob = pszPobEmp + " " + pszEdoEmp;
                                pszCP = Conversion.Str(lCPEmp);
                            }
                        }

                        //Valida que no haya campos en blanco
                        if (pszSexo == CORVB.NULL_STRING)
                        {
                            pszSexo = " ";
                        }

                        if ((pszTelPart == CORVB.NULL_STRING) || (pszTelPart == ""))
                        {
                            pszTelPart = new String(' ', 7);
                        }
                        if ((pszTelOfi == CORVB.NULL_STRING) || (pszTelOfi == ""))
                        {
                            pszTelOfi = new String(' ', 7);
                        }
                        if ((pszExt == CORVB.NULL_STRING) || pszExt == "")
                        {
                            pszExt = "0000";
                        }

                        // 25-Mar-2010 Cambios Masivos
                        if (pszSubActi == CORVB.NULL_STRING || pszSubActi == "    ")
                        {
                            pszSubActi = "00";
                        }
                        //


                        if (pszNombre.Length <= 26)
                        {
                            pszEspacio = new String(' ', 26);
                            pszEspacio = StringsHelper.MidAssignment(pszEspacio, 1, Strings.Mid(pszNombre, 1, 26));
                            pszNombre = pszEspacio;
                        }
                        else
                        {
                            pszNombre = Strings.Mid(pszNombre, 1, 26);
                        }

                        if (pszCalle.Length <= 35)
                        {
                            pszEspacio = new String(' ', 35);
                            pszEspacio = StringsHelper.MidAssignment(pszEspacio, 1, Strings.Mid(pszCalle, 1, 35));
                            pszCalle = pszEspacio;
                        }
                        else
                        {
                            pszCalle = Strings.Mid(pszCalle, 1, 26);
                        }

                        if (pszColonia.Length <= 25)
                        {
                            pszEspacio = new String(' ', 25);
                            pszEspacio = StringsHelper.MidAssignment(pszEspacio, 1, Strings.Mid(pszColonia, 1, 25));
                            pszColonia = pszEspacio;
                        }
                        else
                        {
                            pszColonia = Strings.Mid(pszColonia, 1, 26);
                        }

                        if (pszPob.Length <= 25)
                        {
                            pszEspacio = new String(' ', 25);
                            pszEspacio = StringsHelper.MidAssignment(pszEspacio, 1, Strings.Mid(pszPob, 1, 25));
                            pszPob = pszEspacio;
                        }
                        else
                        {
                            pszPob = Strings.Mid(pszPob, 1, 26);
                        }

                        if (pszTelPart == new String(' ', 1) )
                        {
                            pszTelPart = "0000000";
                        }
                        else
                        {
                            if (pszTelPart.Length < 7)
                            {
                                pszTelPart = StringsHelper.Format(pszTelPart, "0000000");
                            }
                            else
                            {
                                pszTelPart = Strings.Mid(pszTelPart, 1, 7);
                            }
                        }

                        if (pszTelOfi == new String(' ', 1))
                        {
                            pszTelOfi = "0000000";
                        }
                        else
                        {
                            if (pszTelOfi.Length < 7)
                            {
                                pszTelOfi = StringsHelper.Format(pszTelOfi, "0000000");
                            }
                            else
                            {
                                pszTelOfi = Strings.Mid(pszTelOfi, 1, 7);
                            }
                        }
                        if (pszExt == CORVB.NULL_STRING)
                        {
                            pszExt = "0000";
                        }



                        if (pszCP == CORVB.NULL_STRING)
                        {
                            pszCP = "00000";
                        }
                        else
                        {
                            pszCP = StringsHelper.Format(pszCP, "00000");
                        }

                        if (pszZP == " ")
                        {
                            pszZP = "00";
                        }
                        else
                        {
                            pszZP = StringsHelper.Format(pszZP, "00");
                        }

                        slRFC = slRFC.Trim();
                        if (slRFC.Trim() == "")
                        {
                            slRFC = new string(CORVB.NULL_STRING[0], 13);
                        }

                        //            MsgBox "Se han validado los datos"

                        if (bCambio)
                        { //Si hay diferencias
                            //Arma la cadena para el S111
                            objTransS111.StrIdTransaccion = CORCONST.MODIFICA_EMPRESA_MASIVOS;
                            objTransS111.StrNoCuenta = pszNumCuenta;
                            pszEnviaS111 = new StringBuilder("M" + Strings.Chr(28).ToString()); //M = modificación
                            pszEnviaS111.Append(pszNombre + Strings.Chr(28).ToString()); //Nombre
                            //*: Código Nuevo:
                            pszEnviaS111.Append(((pszSexo == "H") ? "M" : "F") + Strings.Chr(28).ToString());
                            //*: Código Anterior:
                            //*: pszEnviaS111 = pszEnviaS111 & pszSexo & Chr(28)
                            //* Fin: EISSA (MRG) 2005-08-23
                            pszEnviaS111.Append(pszCalle + Strings.Chr(28).ToString()); //Calle
                            pszEnviaS111.Append(pszColonia + Strings.Chr(28).ToString()); //Colonia
                            pszEnviaS111.Append(pszZP + Strings.Chr(28).ToString()); //Zona Postal
                            pszEnviaS111.Append(pszPob + Strings.Chr(28).ToString()); //Poblacion
                            pszEnviaS111.Append(pszCP + Strings.Chr(28).ToString()); //Codigo Postal
                            pszEnviaS111.Append(StringsHelper.Format(pszTelPart.Trim(), "0000000") + Strings.Chr(28).ToString()); //Tel Particular
                            pszEnviaS111.Append(StringsHelper.Format(pszTelOfi.Trim(), "0000000") + Strings.Chr(28).ToString()); //Tel oficina
                            pszEnviaS111.Append(StringsHelper.Format(pszExt.Trim(), "0000") + Strings.Chr(28).ToString());
                            pszEnviaS111.Append(StringsHelper.Format(Strings.Mid(pszSubActi.Trim(), 1, 2), "00") + Strings.Chr(28).ToString()); //actividad
                            pszEnviaS111.Append(StringsHelper.Format(Strings.Mid(pszSubActi.Trim(), 1, 2), "00") + Strings.Chr(28).ToString());

                            if (iEjeNum == 0)
                            {
                                pszEnviaS111.Append(" " + slRFC + Strings.Chr(28).ToString()); //RFC
                            }
                            else
                            {
                                pszEnviaS111.Append(slRFC + Strings.Chr(28).ToString()); //RFC
                            }
                            pszEnviaS111.Append(" "); //Adicional
                            objTransS111.StrParametrosAdicionales = pszEnviaS111.ToString();
                            //AIS-1119 NGONZALEZ
                            String tempString = String.Empty;

                            // 25-Mar-2010 Cambios Masivos
                            bool tempRefParam1 = true;
                            string StrError = "";
                            do
                            {
                                if ((StrError == ";  SEG; FAVOR\r\n") || (StrError == ";  SEG; VUELV\r\n"))
                                {
                                    objTransS111.set_Usuario(ref CRSParametros.sgUserID);

                                    frmLoginS53 frmFirma = new frmLoginS53();
                                    var regreso = frmFirma.ShowDialog();


                                    if (regreso.ToString() != "OK")
                                    {
                                    //if (!objTransS111.FnPreguntaPwd())
                                    //{
                                        if (EnCausaErrorFirma == TransS111.EnumEstadosFirma.EnSinRespuesta)
                                        {
                                            MdlCambioMasivo.MsgInfo("No se encontro respuesta del S111");
                                        }
                                    }
                                }
                                enEstadoTransS111 = objTransS111.FnEnviarTransaccion(ref tempString, ref tempString, ref tempString);
                                StrError = objTransS111.get_MsgError(ref tempRefParam1);
                            }
                            while ((StrError == ";  SEG; FAVOR\r\n") || (StrError == ";  SEG; VUELV\r\n"));
                            //

                            if (enEstadoTransS111 == TransS111.EnumRespTransaccion.EnRespTransaccionAceptada)
                            {

                                //                    MsgBox "Transacción aceptada, diálogo: " & pszMensajeS111
                                if (iEjeNum == 0)
                                {
                                    //Realiza los cambios en la tabla de empresas cuando se trata del ejecutivo cero
                                    CORVAR.pszgblsql = "update " + CORBD.DB_SYB_EMP + " set ";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_usu_cam = '" + CRSParametros.sgUserID + "', ";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_envio_calle ='" + pszCalle.Trim() + "',emp_envio_col='" + pszColonia.Trim() + "',";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_envio_pob ='" + pszPobEmp.Trim() + "',emp_envio_edo='" + pszEdoEmp.Trim() + "',emp_envio_cp=" + pszCP;
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " , emp_telefono = '" + pszTelPart.Trim() + "'";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " , emp_extension = '" + pszExt.Trim() + "'";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " , emp_rfc = '" + slRFC + "'";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + lEmpresa.ToString();
                                    iRegs = 0;
                                    using (OdbcCommand command1 = new OdbcCommand(CORVAR.pszgblsql, conexion))
                                    { iRegs = command1.ExecuteNonQuery(); }
                                }

                                CORVAR.pszgblsql = "UPDATE " + CORBD.DB_SYB_EJE + " SET eje_calle = '" + pszCalle.Trim() + "',";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_usuario_cam = '" + CRSParametros.sgUserID + "', ";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_col = '" + pszColonia.Trim() + "',";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_pob = '" + pszPobEmp.Trim() + "',";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_edo = '" + pszEdoEmp.Trim() + "',";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_cp = " + pszCP + ",";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_rfc = '" + slRFC + "',";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_fecha_cam =  convert(int , convert( char(12), getdate(),112 ) )  ";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + ",eje_hora_cam = ";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "datepart(hh,getdate()) *100 + datepart(mi,getdate())";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + lEmpresa.ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_num = " + iEjeNum.ToString();

                                //                    MsgBox "Antes de Actualizar al Ejecutivo " & iEjeNum
                                iRegs = 0;
                                using (OdbcCommand command1 = new OdbcCommand(CORVAR.pszgblsql, conexion))
                                { iRegs = command1.ExecuteNonQuery(); }
                                if (iRegs != 0)
                                {

                                    //                        MsgBox "Ha sido actualizada la tabla de ejecutivos"

                                    CORVAR.pszgblsql = "update MTCCAM01 set cam_estado = 'Procesado'";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " and emp_num = " + lEmpresa.ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and  eje_num = " + iEjeNum.ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and cam_proceso = 'DomicilioEmp'";

                                    iRegs = 0;
                                    using (OdbcCommand command1 = new OdbcCommand(CORVAR.pszgblsql, conexion))
                                    { iRegs = command1.ExecuteNonQuery(); }

                                }
                            }
                            else
                            {

                                bool tempRefParam = true;
                                pszMensajeS111 = objTransS111.get_MsgError(ref tempRefParam);

                                // 25-Mar-2010 Cambios Masivos
                                pszMensajeS111 = pszMensajeS111.Substring(3, (pszMensajeS111.Length - 3));
                                pszMensajeS111 = pszMensajeS111.Replace("OPERACION NEGADA", "OPE NEG");
                                //
                                //Actualiza el registro con el mensaje de rechazo por el S111
                                CORVAR.pszgblsql = "UPDATE " + CORBD.DB_SYS_CAM + " SET ";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "cam_mensaje = '" + pszMensajeS111 + "'";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " and emp_num = " + lEmpresa.ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and  eje_num = " + iEjeNum.ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and cam_proceso = 'DomicilioEmp'";

                                iRegs = 0;
                                using (OdbcCommand command1 = new OdbcCommand(CORVAR.pszgblsql, conexion))
                                { iRegs = command1.ExecuteNonQuery(); }
                            }
                        }
                        else
                        {
                            //no hay cambio de dirección para ese tarjetahabiente. Tiene dirección personal

                            CORVAR.pszgblsql = "UPDATE " + CORBD.DB_SYS_CAM + " SET cam_estado = 'No Cambio'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " and emp_num = " + lEmpresa.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and  eje_num = " + iEjeNum.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and cam_proceso = 'DomicilioEmp'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and cam_mensaje = ''";

                            iRegs = 0;
                            using (OdbcCommand command1 = new OdbcCommand(CORVAR.pszgblsql, conexion))
                            { iRegs = command1.ExecuteNonQuery(); }
                        }

                        //Incrementa el contador de registros
                        iCountRow++;
                        lContador++;

                        iFlood = Convert.ToInt32(Math.Floor((iCountRow / ((double)iTempRow)) * 100));
                        SSPanel1.FloodPercent = (short)iFlood;
                        if ((((SSPanel1.FloodPercent > 50) ? -1 : 0) & ~bColorCambiado) != 0)
                        {
                            SSPanel1.ForeColor = ColorTranslator.FromOle(CORVB.WHITE);
                            bColorCambiado = -1;
                        }
                        Application.DoEvents();
                    };
                    reader.Close();
                    conexion.Close();

                }
                else
                {
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    this.Cursor = Cursors.Default;
                    Interaction.MsgBox("No se obtuvieron registros en cambios masivos ", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                }

                //Regresamos el status bar
                SSPanel1.Caption = CORVB.NULL_STRING;
                CORMDIBN.DefInstance.ID_COR_MSG_TXT.Visible = false;
                SSPanel1.FloodType = CORVB.NONE;
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                //Genera el archivo de procesados
                string tempRefParam2 = "Procesado";
                string tempRefParam3 = "DomicilioEmp";
                CORPROC2.Genera_Achivos_Cambios("CMProces.txt", ref tempRefParam2, ref tempRefParam3, "Normal");
                //Genera archivo de reg que no cambiaron
                string tempRefParam4 = "No Cambio";
                string tempRefParam5 = "DomicilioEmp";
                CORPROC2.Genera_Achivos_Cambios("CMNoCamb.txt", ref tempRefParam4, ref tempRefParam5, "Normal");
                //Genera archivo de reg que no se procesaron y estan pendientes
                string tempRefParam6 = "No Proce";
                string tempRefParam7 = "DomicilioEmp";
                CORPROC2.Genera_Achivos_Cambios("CMPendie.txt", ref tempRefParam6, ref tempRefParam7, "Normal");
                //Genera un archivo general para la lectura de datos desde excel
                string tempRefParam8 = "Procesado";
                string tempRefParam9 = "DomicilioEmp";
                CORPROC2.Genera_Achivos_Cambios("DomEmpre.txt", ref tempRefParam8, ref tempRefParam9, "Excel");

                //Borra los registros procesados solo los realizados en empresas
                string tempRefParam10 = "DomicilioEmp";
                string tempRefParam11 = "";
                CORMNEMP.DefInstance.Depura_Tabla_CamMasivos(ref tempRefParam10, ref tempRefParam11);

                //Limpia nuevamente el control y muestra los cambios
                CambiosPendientesS111();

                this.Cursor = Cursors.Default;
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }
        }

			
			
			
			//****************************************************************************
			//**                                                                        **
			//**       Descripción:                                                     **
			//**                   Llama a la función EnvAccConexionPen para obtener su **
			//**                   número de nómina y clave de acceso al s111           **
			//**                                                                        **
			//**                                                                        **
			//**       Paso de parámetros:                                              **
			//**                                                                        **
			//**       Valor de Regreso: ninguno                                        **
			//**                                                                        **
			//**                                                                        **
			//**       Ultima modificacion: 12oct98                                     **
			//**                                                                        **
			//****************************************************************************'
			//UPGRADE_NOTE: (7001) The following declaration (Alta_S111_Usuario_Pen) seems to be dead code
			//private bool Alta_S111_Usuario_Pen()
			//{
					//llama al aforma que realiza la conexión al s111
					//
					//if (EnvAccConexionPen())
					//{
						////UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
						////UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
						////UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
						//Interaction.MsgBox("Clave de acceso incorrecta.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
						//return false;
					//}
					//
					//return false;
			//}
			
			
			
			
			//****************************************************************************
			//**                                                                        **
			//**       Descripción:                                                     **
			//**                   Funcion que llama a la forma CORACCOM y obtiene su   **
			//**                   numero de nomina y cve de acceso al S111.            **
			//**                   Envia los datos anetriores al S111 por medio del     **
			//**                   condrive y obtiene una res. del S111                 **
			//**                                                                        **
			//**                                                                        **
			//**       Paso de parámetros:                                              **
			//**                                                                        **
			//**       Valor de Regreso: función booleana                               **
			//**                                                                        **
			//**                                                                        **
			//**       Ultima modificacion: 12oct98                                     **
			//**                                                                        **
			//****************************************************************************''
			private bool EnvAccConexionPen()
			{
					//envia la clave de acceso al S111 por medio del condrive
					
					bool result = false;
					int liEdo = 0;
					int llNomina = 0;
					FixedLengthString fsNomina = new FixedLengthString(4);
					FixedLengthString lsPassword = new FixedLengthString(8);
					
					string pszRepS111 = String.Empty;
					string pszCadena = String.Empty;
					int iPos = 0;
					string pszMensajeS111 = String.Empty;
					
					
					//***** INICIO CODIGO NUEVO FSWBMX *****
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
					try
					{
							//***** FIN DE CODIGO NUEVO FSWBMX *****
							
							result = false;
							this.Cursor = Cursors.Default;
							//UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
							CORACCOM.DefInstance.ShowDialog();
							string pszResAcc = CORACCOM.DefInstance.Tag.ToString();
							if (pszResAcc == "Cancelar")
							{
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
								Interaction.MsgBox("No se capturaron datos.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
								ConComDrive.Termina_Conexion();
								CORACCOM.DefInstance.Close();
								return true;
							} else
							{
								MessageBox.Show("Evaluando validez de la nómina ingresada", Application.ProductName);
								//compacta nómina
								fsNomina.Value = new string((char) 0, 4);
								llNomina = Int32.Parse(CORACCOM.DefInstance.ID_ACC_NOM_TXT.Text);
                                liEdo = API.Encryption.iCompactaNomina(llNomina, fsNomina.Value);
								//compacta password
								lsPassword.Value = new string((char) 255, 8);
                                //AIS-1182 NGONZALEZ
                                liEdo = API.Encryption.iCompactaPasswd(CORACCOM.DefInstance.ID_ACC_CVE_TXT.Text, lsPassword.Value);
								//arma la cadena para el envio
								pszCadena = CORCONST.CVE_ACCESO_MODIFICA_S111;
								pszCadena = pszCadena + fsNomina.Value + lsPassword.Value;
								pszCadena = pszCadena + " " + "\r" + "\n";
								//envia la cadena al S111
								this.Cursor = Cursors.WaitCursor;
								pszRepS111 = ConComDrive.Envia_Mensaje(ref pszCadena);
								pszMensajeS111 = CORPROC.Muestra_Mensaje(pszRepS111);
								iPos = (pszRepS111.IndexOf("SEG:") + 1);
								if (iPos > CORVB.NULL_INTEGER)
								{
									//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
									//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
									//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
									Interaction.MsgBox(" " + pszMensajeS111, (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
									CORACCOM.DefInstance.Close();
									return result;
								} else
								{
									MessageBox.Show(" " + pszMensajeS111 + "\r" + " FIN DEL PROCESO.", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
									result = true; //no se pudo conectar, y envia que falló la conexión
									ConComDrive.Termina_Conexion();
									this.Cursor = Cursors.Default;
								}
								CORACCOM.DefInstance.Close();
							}
							
							
							// EnvAccConexionPen = False
							
							// For i = 1 To 2
							//   'muestra la pantalla de acceso al condrive
							//   CORACCOM.Show 1
							//   pszResAcc = CORACCOM.Tag
							//   If pszResAcc = "Cancelar" Then
							//     Screen.MousePointer = DEFAULT
							//     MsgBox "No se capturaron datos.", MB_OK + MB_ICONEXCLAMATION, STR_APP_TIT
							//     ConComDrive.Termina_Conexion
							//     Unload CORACCOM
							//     EnvAccConexionPen = True
							//     Exit For
							//     Exit Function
							//   Else
							//     'arma la cadena para el envio
							//     pszCadena = CVE_ACCESO_MODIFICA_S111
							//     pszCadena = pszCadena & " " & CORACCOM!ID_ACC_NOM_TXT.Text
							//     pszCadena = pszCadena & " " & CORACCOM!ID_ACC_CVE_TXT.Text
							//     pszCadena = pszCadena & " " + Chr(13) + Chr(10)
							//
							//      'envia la cadena al S111
							//      pszRepS111 = ConComDrive.Envia_Mensaje(pszCadena)
							//
							//      pszMensajeS111 = Muestra_Mensaje(pszRepS111)
							//      If InStr(pszRepS111, "BIENVENID") = NULL_INTEGER And InStr(pszRepS111, "EXPIRA SU CLAVE SECRETA") = NULL_INTEGER Then
							//        Screen.MousePointer = DEFAULT
							//        MsgBox " " & pszMensajeS111 & " FIN DEL PROCESO.", vbCritical, STR_APP_TIT
							//        EnvAccConexionPen = True
							//        If InStr(pszRepS111, "CLAVE SECRETA INVALIDA") = 0 Then
							//          ConComDrive.Termina_Conexion
							//        End If
							//        Unload CORACCOM
							//        If InStr(pszRepS111, "YA ESTA FIRMADO EN LA TERMINAL") <> 0 Or (pszRepS111 = NULL_STRING) Then
							//          Exit For
							//        End If
							//      Else
							//        If InStr(pszMensajeS111, "BIENVENID") = NULL_INTEGER Then
							//          Screen.MousePointer = DEFAULT
							//          MsgBox " " & pszMensajeS111, MB_OK + MB_ICONEXCLAMATION, STR_APP_TIT
							//        End If
							//        EnvAccConexionPen = False
							//        Unload CORACCOM
							//        Exit For
							//      End If
							//    End If
							//  Next
						}
					catch (Exception exc)
					{
						throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
					}
					
					
					return result;
			}
			
			private void  ID_CAM_CAN_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					if (BolProcesando)
					{
						BolProcesando = ! MdlCambioMasivo.FnMsgYesno(" Desea cancelar el proceso actual");
						Application.DoEvents();
						
					} else
					{
						this.Close();
					}
					
			}
			
			//UPGRADE_WARNING: (2065) HScrollBar event scrScroll.Change has a new behavior.
			private void  scrScroll_Change( int newScrollValue)
			{
					CRSGeneral.prScrollBar(scrScroll, ID_CAM_MEN_LIB);
			}
			private void  scrScroll_Scroll( Object eventSender,  ScrollEventArgs eventArgs)
			{
					switch(eventArgs.Type)
					{
						case ScrollEventType.EndScroll : 
							scrScroll_Change(eventArgs.NewValue); 
							break;
					}
			}
		}
}