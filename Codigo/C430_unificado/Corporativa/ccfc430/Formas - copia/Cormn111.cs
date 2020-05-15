using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System;
using System.IO; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;
using System.Runtime.InteropServices;

namespace TCc430
{
	internal partial class Cormn111
		: System.Windows.Forms.Form
		{
		
			private void  Cormn111_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			bool bConexion = false;

            pryActualizaS111.ClsConectaS111 objTransS111 = null;
            clsAltaEmpresa ConsultaS111 = null;
            TransS111.EnumEstadosFirma EnCausaErrorFirma = (TransS111.EnumEstadosFirma)0;
			
			//crea un objeto de clase conexion del ole server
			/*private OLERut.Conexion _ConexionRut = null;
			OLERut.Conexion ConexionRut
			{
				get
				{
					if (_ConexionRut == null)
					{
						_ConexionRut = new OLERut.Conexion();
					}
					return _ConexionRut;
				}
				set
				{
					_ConexionRut = value;
				}
			}*/
       
        [DllImport("RUT.dll")]
        public extern static int RUT_Connect(string pcHostName, string pcService, bool bVal);
        [DllImport("RUT.dll")]
        public extern static int RUT_Disconnect(bool bVal);
        [DllImport("RUT.dll")]
        public extern static int RUT_WriteRead(string pcServerName, string pcRequest, ushort uRequestSize, [MarshalAs(UnmanagedType.VBByRefStr)] ref string pcReply, [MarshalAs(UnmanagedType.U2)] ref ushort puReplySize, bool bDisplayError);
	
			
			
			private void  Limpia_Controles()
			{
					//se limpian los controles
					ID_MEE_NEJS111_EB.Text = CORVB.NULL_STRING;
					ID_MEE_CNUS111_EB.Text = CORVB.NULL_STRING;
					ID_MEE_COLS111_EB.Text = CORVB.NULL_STRING;
					ID_MEE_POBS111_EB.Text = CORVB.NULL_STRING;
					ID_MEE_CPS111_PIC.CtlText = CORVB.NULL_STRING;
					
					ID_MEE_SUC_ITB.CtlText = CORVB.NULL_STRING;
					ID_MEE_COR_PIC.CtlText = CORVB.NULL_STRING;
					ID_MEE_SEXS111_EB.Text = CORVB.NULL_STRING;
					ID_MEE_TDOS111_PIC.CtlText = CORVB.NULL_STRING;
					ID_MEE_TOFS111_PIC.CtlText = CORVB.NULL_STRING;
					ID_MEE_EXTS111_PIC.CtlText = CORVB.NULL_STRING;
					ID_MEE_FECS111_EB.Text = CORVB.NULL_STRING;
			}
			
			private void  Cormn111_KeyPress( Object eventSender,  KeyPressEventArgs eventArgs)
			{
					int KeyAscii = (int) eventArgs.KeyChar;
					
					if (KeyAscii == CORVB.KEY_RETURN)
					{
						ID_MEE_OK_PB_Click(ID_MEE_OK_PB, new EventArgs());
					}
					
					if (KeyAscii == 0)
					{
						eventArgs.Handled = true;
					}
					eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
            //private void  Form_Load()
            //{
            //        //***** INICIO CODIGO NUEVO FSWBMX *****
            //        //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            //        try
            //        {
            //                //***** FIN DE CODIGO NUEVO FSWBMX *****
							
            //                this.Cursor = Cursors.WaitCursor;
							
            //                //inicia la comunicación con el tandem por medio del OLE
            //                bConexion = false;							
            //                //if (ConexionRut.Inicia_Conexion())
            //                int iresult = RUT_Connect(mdlParametros.sgEquipoUnix, mdlParametros.sgPuertoTandem, false);
            //                if (iresult == 0)
            //                {
            //                    bConexion = true;
								
            //                } else
            //                {
								
            //                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
            //                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
            //                    Interaction.MsgBox("No se realizo la conexión al S111. Avise a Ingeniería de Sistemas ó intente más tarde", CORVB.MB_ICONSTOP, CORSTR.STR_APP_TIT);
            //                    //Se cierra la ventana
            //                    //AIS-1182 NGONZALEZ
            //                    CORVAR.igblRetorna = API.USER.PostMessage(this.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
								
            //                }
							
            //                this.Cursor = Cursors.Default;
            //            }
            //        catch (Exception exc)
            //        {
            //            throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            //        }
            //        ID_MEE_NUCS111_EB.Focus();
            //        ID_MEE_NUCS111_EB.Select();
            //}

            private void Form_Load()
            {
                //***** INICIO CODIGO NUEVO FSWBMX *****
                //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
                try
                {
                    //***** FIN DE CODIGO NUEVO FSWBMX *****

                    this.Cursor = Cursors.WaitCursor;

                    //inicia la comunicación con el tandem por medio del OLE
                    bConexion = false;
                    //if (ConexionRut.Inicia_Conexion())
                    //int iresult = RUT_Connect(mdlParametros.sgEquipoUnix, mdlParametros.sgPuertoTandem, false);
                    //if (iresult == 0)
                    //{
                    //    bConexion = true;

                    //} else
                    //{

                    //    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    //    Interaction.MsgBox("No se realizo la conexión al S111. Avise a Ingeniería de Sistemas ó intente más tarde", CORVB.MB_ICONSTOP, CORSTR.STR_APP_TIT);
                    //    //Se cierra la ventana
                    //    //AIS-1182 NGONZALEZ
                    //    CORVAR.igblRetorna = API.USER.PostMessage(this.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);

                    //}

                    this.Cursor = Cursors.Default;
                }
                catch (Exception exc)
                {
                    CRSGeneral.prObtenError(this.GetType().Name + "(Form_Load)", exc);
                    //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
                }
                ID_MEE_NUCS111_EB.Focus();
                ID_MEE_NUCS111_EB.Select();
            }
        
        private void  Cormn111_Closed( Object eventSender,  EventArgs eventArgs)
			{
					this.Cursor = Cursors.WaitCursor;
					
					if (bConexion)
					{
                        
						//if (ConexionRut.Termina_Conexion())
                        int iresult2=RUT_Disconnect(false);
                        if (iresult2 == 0)
						{
							bConexion = false;
						}
					}
					
					
					this.Cursor = Cursors.Default;
					MemoryHelper.ReleaseMemory();
			}
			
			
			private void  ID_MEE_CER_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
					try
					{
							this.Cursor = Cursors.WaitCursor;
							
							if (bConexion)
							{
								//if (ConexionRut.Termina_Conexion())
                                int iresult2 = RUT_Disconnect(false);
                                if (iresult2 == 0)
								{
									bConexion = false;
								}
							}
							
							this.Close();
							
							this.Cursor = Cursors.Default;
						}
					catch (Exception exc)
					{
                        CRSGeneral.prObtenError(this.GetType().Name + "(ID_MEE_CER_PB_Click)", exc);
						//throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
					}
					
					
			}
			
			private void  ID_MEE_COR_PIC_KeyPressEvent( Object eventSender,  AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
			{
					if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != 8)
					{
						eventArgs.keyAscii = (short) CORVB.NULL_INTEGER;
					}
			}
			
			private void  ID_MEE_CPS111_PIC_KeyPressEvent( Object eventSender,  AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
			{
					if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != 8)
					{
						eventArgs.keyAscii = (short) CORVB.NULL_INTEGER;
					}
			}
			
			private void  ID_MEE_EXTS111_PIC_KeyPressEvent( Object eventSender,  AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
			{
					if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != 8)
					{
						eventArgs.keyAscii = (short) CORVB.NULL_INTEGER;
					}
			}
			
			private void  ID_MEE_LIMS111_FTB_KeyPressEvent( Object eventSender,  AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
			{
					if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != 8 && eventArgs.keyAscii != 46)
					{
						eventArgs.keyAscii = (short) CORVB.NULL_INTEGER;
					}
			}
			
			private void  ID_MEE_NUCS111_EB_KeyPress( Object eventSender,  KeyPressEventArgs eventArgs)
			{
					int KeyAscii = (int) eventArgs.KeyChar;
					
					
					if ((KeyAscii < 48 || KeyAscii > 57) && KeyAscii != 8)
					{
						//UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant
						KeyAscii = CORVB.NULL_INTEGER;
					}
					
					
					if (KeyAscii == 0)
					{
						eventArgs.Handled = true;
					}
					eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}

            private void ID_MEE_OK_PB_Click(Object eventSender, EventArgs eventArgs)
            {

                ConsultaS111 = new clsAltaEmpresa();

                string pszCadena1 = String.Empty;
                string pszCadena2 = String.Empty;
                string pszCadena3 = String.Empty;
                string pszRespuesta = String.Empty;
                string slConsulta = String.Empty;

                this.Cursor = Cursors.WaitCursor;

                Limpia_Controles();

                pszRespuesta = ConsultaS111.fncConsultaS111SComDrv(ID_MEE_NUCS111_EB.Text, out slConsulta);

                if (pszRespuesta == "Coinciden")
                {
                    //se realizó correctamente la consulta

                    ID_MEE_NEJS111_EB.Text = Strings.Mid(slConsulta, 4, 26).Trim();
                    ID_MEE_CNUS111_EB.Text = Strings.Mid(slConsulta, 110, 35).Trim();
                    ID_MEE_COLS111_EB.Text = Strings.Mid(slConsulta, 188, 25).Trim();
                    ID_MEE_POBS111_EB.Text = Strings.Mid(slConsulta, 259, 25).Trim();
                    ID_MEE_CPS111_PIC.CtlText = Strings.Mid(slConsulta, 323, 5).Trim();

                    ID_MEE_SUC_ITB.CtlText = Strings.Mid(slConsulta, 394, 4).Trim();
                    ID_MEE_COR_PIC.CtlText = Strings.Mid(slConsulta, 414, 2).Trim();
                    if (Strings.Mid(slConsulta, 165, 1).Trim() == "F")
                    {
                        ID_MEE_SEXS111_EB.Text = "Femenino";
                    }
                    else
                    {
                        ID_MEE_SEXS111_EB.Text = "Masculino";
                    }
                    ID_MEE_TDOS111_PIC.CtlText = Conversion.Val(Strings.Mid(slConsulta, 49, 7).Trim()).ToString();
                    ID_MEE_TOFS111_PIC.CtlText = Conversion.Val(Strings.Mid(slConsulta, 75, 7).Trim()).ToString();
                    ID_MEE_EXTS111_PIC.CtlText = Conversion.Val(Strings.Mid(slConsulta, 84, 4).Trim()).ToString();
                    ID_MEE_FECS111_EB.Text = ""; // se deja en blanco, ya que el diálogo que regresa la información está incorrecto

                }
                else
                {
                    Interaction.MsgBox("Cuenta incorrecta o no existe ", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                    Limpia_Controles();
                }


            }
		
	
            //private void  ID_MEE_OK_PB_Click( Object eventSender,  EventArgs eventArgs)
            //{
					
            //        string pszCadena1 = String.Empty;
            //        string pszCadena2 = String.Empty;
            //        string pszCadena3 = String.Empty;
					
            //        //***** INICIO CODIGO NUEVO FSWBMX *****
            //        //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            //        try
            //        {
            //                //***** FIN DE CODIGO NUEVO FSWBMX *****
							
            //                this.Cursor = Cursors.WaitCursor;
							
            //                Limpia_Controles();
							
            //                //arma la cadena para enviar el emsaje
            //                string pszMensajeS111 = new String(' ', 55);
            //                //Mid$(pszMensajeS111, 1, 4) = "S753"                   'Sistema
            //                pszMensajeS111 = StringsHelper.MidAssignment(pszMensajeS111, 1, "C430"); //Sistema
            //                pszMensajeS111 = StringsHelper.MidAssignment(pszMensajeS111, 5, CORBD.PROCESO_CONSULTA); //clave de proceso
            //                pszMensajeS111 = StringsHelper.MidAssignment(pszMensajeS111, 8, "00"); //clave tipo de alta
            //                pszMensajeS111 = StringsHelper.MidAssignment(pszMensajeS111, 10, CORBD.TIPO_TRAMITE); //clave tipo de tramite
            //                pszMensajeS111 = StringsHelper.MidAssignment(pszMensajeS111, 12, StringsHelper.Format(CORVB.NULL_INTEGER, "00000000")); //numero de folio
            //                pszMensajeS111 = StringsHelper.MidAssignment(pszMensajeS111, 20, StringsHelper.Format(Conversion.Str(CORVB.NULL_INTEGER), "000000000000")); //numero de nomina
            //                pszMensajeS111 = StringsHelper.MidAssignment(pszMensajeS111, 32, CORBD.TRANSACCION_CONSULTA); //Transacción
            //                pszMensajeS111 = StringsHelper.MidAssignment(pszMensajeS111, 36, ID_MEE_NUCS111_EB.Text); //cuenta
							
            //                string pszConsulta = pszMensajeS111;
							
            //                //envia la cadena al rut
            //                string tempRefParam = "S753-CONALTAS";
            //                //int iResConS111 = ConexionRut.RutReadWrite(ref pszConsulta, ref tempRefParam);
            //                ushort tamsal = 1654;
            //                string slDialogSal = new String(' ', tamsal);
            //                int iResConS111 = RUT_WriteRead(tempRefParam, pszConsulta, (ushort)pszConsulta.Length, ref slDialogSal, ref tamsal, false);
            //                pszConsulta = slDialogSal;

            //                string pszConS111 = pszConsulta;
							
            //                if (iResConS111 != CORVB.NULL_INTEGER)
            //                {
            //                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
            //                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
            //                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
            //                    Interaction.MsgBox("ERROR EN EL ENVIO DE LA INFORMACION ", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
            //                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
            //                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
            //                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
            //                    Interaction.MsgBox("No se logro realizar la consulta.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
            //                } else
            //                {
            //                    if ((pszConsulta.IndexOf("RSC error on RUT") + 1) > CORVB.NULL_INTEGER)
            //                    {
            //                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
            //                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
            //                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
            //                        Interaction.MsgBox("Error de comunicaciones.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
            //                    } else
            //                    {
            //                        //Obtengo los datos del S111
            //                        pszCadena1 = Strings.Mid(pszConS111, 1243, 151).Trim();
            //                        pszCadena2 = Strings.Mid(pszConS111, 38, 371).Trim();
            //                        //pszCadena3 = Strings.Mid(pszConS111, 1608, 31).Trim();
            //                        pszCadena3 = Strings.Mid(pszConS111, 1608, 31).Trim();
                                   
									
            //                        if (pszCadena1.Length < 21)
            //                        {
            //                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
            //                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
            //                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
            //                            Interaction.MsgBox("Cuenta incorrecta o no existe ", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
										
            //                            Limpia_Controles();
										
            //                        } else
            //                        {
            //                            //se realizó correctamente la consulta
										
            //                            ID_MEE_NEJS111_EB.Text = Strings.Mid(pszCadena1, 1, 26).Trim();
            //                            ID_MEE_CNUS111_EB.Text = Strings.Mid(pszCadena1, 46, 35).Trim();
            //                            ID_MEE_COLS111_EB.Text = Strings.Mid(pszCadena1, 81, 25).Trim();
            //                            ID_MEE_POBS111_EB.Text = Strings.Mid(pszCadena1, 106, 25).Trim();
            //                            ID_MEE_CPS111_PIC.CtlText = Strings.Mid(pszCadena1, 133, 5).Trim();
										
            //                            ID_MEE_SUC_ITB.CtlText = Strings.Mid(pszCadena1, 139, 4).Trim();
            //                            ID_MEE_COR_PIC.CtlText = Conversion.Val(Strings.Mid(pszCadena1, 143, 2).Trim()).ToString();
            //                            if (Strings.Mid(pszCadena1, 145, 1).Trim() == "F")
            //                            {
            //                                ID_MEE_SEXS111_EB.Text = "Femenino";
            //                            } else
            //                            {
            //                                ID_MEE_SEXS111_EB.Text = "Masculino";
            //                            }
            //                            ID_MEE_TDOS111_PIC.CtlText = Conversion.Val(Strings.Mid(pszCadena1, 27, 7).Trim()).ToString();
            //                            ID_MEE_TOFS111_PIC.CtlText = Conversion.Val(Strings.Mid(pszCadena1, 34, 7).Trim()).ToString();
            //                            ID_MEE_EXTS111_PIC.CtlText = Conversion.Val(Strings.Mid(pszCadena1, 41, 4).Trim()).ToString();
            //                            ID_MEE_FECS111_EB.Text = ""; // se deja en blanco, ya que el diálogo que regresa la información está incorrecto
            //                            /*if (Conversion.Val(Strings.Mid(pszCadena3, 20, 2).Trim()) < 80)
            //                            {
            //                                ID_MEE_FECS111_EB.Text = Strings.Mid(pszCadena3, 24, 2).Trim() + "/" + Strings.Mid(pszCadena3, 22, 2).Trim() + "/" + "20" + Strings.Mid(pszCadena3, 20, 2).Trim();
            //                            } else
            //                            {
            //                                ID_MEE_FECS111_EB.Text = Strings.Mid(pszCadena3, 24, 2).Trim() + "/" + Strings.Mid(pszCadena3, 22, 2).Trim() + "/" + "19" + Strings.Mid(pszCadena3, 20, 2).Trim();
            //                            }*/
										
            //                        }
            //                    }
            //                }
							
            //                this.Cursor = Cursors.Default;
            //            }
            //        catch (Exception exc)
            //        {
            //            throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            //        }
					
            //}
			
			
			private void  ID_MEE_SUC_ITB_KeyPressEvent( Object eventSender,  AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
			{
					if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != 8)
					{
						eventArgs.keyAscii = (short) CORVB.NULL_INTEGER;
					}
			}
			
			private void  ID_MEE_TDOS111_PIC_KeyPressEvent( Object eventSender,  AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
			{
					if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != 8)
					{
						eventArgs.keyAscii = (short) CORVB.NULL_INTEGER;
					}
			}
			
			
			private void  ID_MEE_TOFS111_PIC_KeyPressEvent( Object eventSender,  AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
			{
					if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != 8)
					{
						eventArgs.keyAscii = (short) CORVB.NULL_INTEGER;
					}
			}

        private void ID_CEE_PPLS111_PNL_Paint(object sender, PaintEventArgs e)
        {

        }
		}
}