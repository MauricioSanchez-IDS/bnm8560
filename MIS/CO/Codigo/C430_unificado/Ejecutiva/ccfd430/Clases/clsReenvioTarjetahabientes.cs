using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal class clsReenvioTarjetahabientes
	{

		//*****************************************************************************
		//**                                                                         **
		//**                     EISSA / Banamex - Sistemas                          **
		//**                                                                         **
		//**       -----------------------------------------------------------       **
		//**                                                                         **
		//**       Descripción:  Lleva el control de los Estados dentro de           **
		//**                     la alta de los Ejecutivos                           **
		//**                                                                         **
		//**                                                                         **
		//**                                                                         **
		//**       Responsables: Marcos Garcia Cruz                                  **
		//**                                                                         **
		//**       Fecha de Modificación:  11 de Septiembre del 2003                 **
		//**                                                                         **
		//**             NOTA: Esta forma esta hecha en Visual Basic 6.0             **
		//**                                                                         **
		//*****************************************************************************
		
		
		//Dim galtTarjetahabientes As clsAltaTarjetahabiente
		clsAltaTarjetahabiente gObjetoAlta = null;
		
		clsDatosEjecutivo gdteEjecutivo = null;
		//Dim imEstado            As Integer
		bool bmError = false;
		string smTablaTemporal = String.Empty;
		//Variables para las conexiones
		/*private OLERut.Conexion _cnxConexionRut = null;
		OLERut.Conexion cnxConexionRut
		{
			get
			{
				if (_cnxConexionRut == null)
				{
					_cnxConexionRut = new OLERut.Conexion();
				}
				return _cnxConexionRut;
			}
			set
			{
				_cnxConexionRut = value;
			}
		}*/
		
		
		//Variable global del objeto datos ejecutivo para la consulta del Ejecutivo
		clsDatosEjecutivo gdteEjeExists = null;
		
		//Variable para el dialogo
		clsDialogo gdlgDialogoS016 = null;
		clsDialogo gdlgDialogoS111 = null;
		const string smArchivoLog = "F:\\Documentos\\mgarcia\\VisualBasic\\";
		
		private void  prEstado0()
		{
			try
			{
					//En este estado aún no se ha dado de alta al ejecutivo dentro del S016 ni en el S111 ni el
					//el c430.
					//Cuando fncEnviaDialogoLocal regresa 0 se registró exitosamente en el S016 y en el S111
					string slRespuesta = String.Empty;
					string slResultado = String.Empty;
					bmError = true;
					slRespuesta = "";
					slResultado = "";
					
					
					//MsgInfo "Llamando gObjetoAlta.fncObtenNumB"
					
					if (gObjetoAlta.fncObtenNumB())
					{
						//   MsgInfo "Numero de cuenta obtenido"
						slResultado = gObjetoAlta.fncEnviaDialogoLocalPrimeraS(ref slRespuesta, false);
    					// slResultado = gObjetoAlta.fncEnviaDialogoLocalPrimeraS(slRespuesta, False)
						//If slResultado = "00" Or slResultado = "05" Or slResultado = "07alta" Then
						if (slResultado == "00")
						{
							
							if (gObjetoAlta.fncGrabaTablaRespB())
							{
                                //if (gObjetoAlta.fncActualizaConsecutivoB())
                                //{
									//imEstado = 1
									
									if (gObjetoAlta.fncActualizaEstatusTemporalB(1))
									{
										bmError = false;
										prEstado1();
									} else
									{
										MessageBox.Show("No se pudo actualizar el estado 1 en Temporal.", "Tarjeta Ejecutiva", MessageBoxButtons.OK, MessageBoxIcon.Error);
									}
                                //} else
                                //{
                                //    MessageBox.Show("Ya se encuentra dentro del S016 y S111, pero no se pudo actualizar el consecutivo.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //}
							} else
							{
								MessageBox.Show("Ya se encuentra dentro del S016 y S111, pero no se pudo grabar el respaldo.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
						} else
						{
							if (slResultado == "05" || slResultado == "07alta")
							{
								if (gObjetoAlta.fncGrabaTablaRespB())
								{
                                    //if (gObjetoAlta.fncActualizaConsecutivoB())
                                    //{
										//imEstado = 5
										if (gObjetoAlta.fncActualizaEstatusTemporalB(5))
										{
											MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Ejecutiva", MessageBoxButtons.OK, MessageBoxIcon.Error);
											bmError = false;
										} else
										{
                                            MessageBox.Show("No se pudo actualizar el estado 5 en Temporal.", "Tarjeta Ejecutiva", MessageBoxButtons.OK, MessageBoxIcon.Error);
										}
                                    //} else
                                    //{
                                    //    MessageBox.Show("Ya se encuentra registrado en S016 pero no se actualizó el consecutivo.", "Tarjeta Ejecutiva", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //}
								} else
								{
                                    MessageBox.Show("Ya se encuentra dentro del S016, pero no se pudo grabar el respaldo.", "Tarjeta Ejecutiva", MessageBoxButtons.OK, MessageBoxIcon.Error);
								}
							} else
							{
								if (slResultado == "02" || slResultado == "35" || slResultado == "06" || slResultado == "07error")
								{
									MessageBox.Show(slRespuesta, "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
									
								} else
								{
									if (slResultado.Trim() == "ErrorConexion")
									{
										MessageBox.Show("Error en la conexion", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
										
									} else
									{
										//Mandar la información a un archivo log con los datalles de
										//del ejecutivo.
										gObjetoAlta.prRegistraLog(slRespuesta);
									}
								}
							}
						}
					}
				}
			catch (Exception excep)
			{
				
				string tempRefParam = "PrEstado0" + excep.Source;
				if (MdlCambioMasivo.fnGetError(ref tempRefParam))
				{
					throw new Exception("Migration Exception: 'Resume' not supported");
				}
			}
		}
		
		private void  prEstado1()
		{
			//En este estado ya el ejecutivo se encuentra registrado dentro del S016 pero aún no se sabe
			//si se encuentra registrado en el S111
			try
			{
					string slResultado = String.Empty;
					bmError = true;
					slResultado = gObjetoAlta.fncConsultaS111S();
					if (slResultado == "ErrorConexion")
					{
						MessageBox.Show("Error en la conexion.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
						//imEstado = 1
						if (gObjetoAlta.fncActualizaEstatusTemporalB(1))
						{
							MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
						} else
						{
							MessageBox.Show("No se pudo actualizar el estado 1 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					} else
					{
						if (slResultado == "NoCoinciden")
						{
							//Manda un error de alerta.
							//imEstado = 2
							gObjetoAlta.prRegistraLog(slResultado);
							if (gObjetoAlta.fncActualizaEstatusTemporalB(2))
							{
								prEstado2();
							} else
							{
								MessageBox.Show("No se pudo actualizar el estado 2 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
						} else
						{
							if (slResultado == "Coinciden")
							{
								//imEstado = 2
								if (gObjetoAlta.fncActualizaEstatusTemporalB(2))
								{
									bmError = false;
									prEstado2();
								} else
								{
									MessageBox.Show("No se pudo actualizar el estado 2 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
								}
							} else
							{
								if (slResultado == "NoEncontrado")
								{
									//imEstado = 5
									if (gObjetoAlta.fncActualizaEstatusTemporalB(5))
									{
										MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
									} else
									{
										MessageBox.Show("No se pudo actualizar el estado 5 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
									}
								}
							}
						}
					}
				}
			catch 
			{
				
				string tempRefParam = "PrEstado1";
				if (MdlCambioMasivo.fnGetError(ref tempRefParam))
				{
					throw new Exception("Migration Exception: 'Resume' not supported");
				}
			}
			
		}
		private void  prEstado2()
		{
			//En este estado ya hay certidumbre de que el ejecutivo se encuentra tanto en el S016 como en
			//el S111
			try
			{
					string slResultado = String.Empty;
					bmError = true;
					
					slResultado = gObjetoAlta.fncConsultac430S();
					if (slResultado == "Coinciden")
					{
						//imEstado = 3
						MessageBox.Show("El ejecutivo ya se encontraba registrado.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
						MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
						if (! gObjetoAlta.fncActualizaEstatusTemporalB(3))
						{
							MessageBox.Show("No se pudo actualizar el estado 3 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
						return;
					}
					if (gObjetoAlta.fncInsertaM111B())
					{
						//imEstado = 3
						if (gObjetoAlta.fncActualizaEstatusTemporalB(3))
						{
							bmError = false;
							prEstado3();
						} else
						{
							MessageBox.Show("No se pudo actualizar el estado 3 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					} else
					{
						//imEstado = 2
						if (gObjetoAlta.fncActualizaEstatusTemporalB(2))
						{
							//MsgBox "No se pudo insertar el ejecutivo: " & gdteEjecutivo.EjeEmpNumL, vbCritical + vbOKOnly, "Tarjeta Corporativa"
							MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
						} else
						{
							MessageBox.Show("No se pudo actualizar el estado 2 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
				}
			catch 
			{
				
				string tempRefParam = "PrEstado2";
				if (MdlCambioMasivo.fnGetError(ref tempRefParam))
				{
					throw new Exception("Migration Exception: 'Resume' not supported");
				}
			}
			
		}
		
		private void  prEstado3()
		{
			//En este estado el ejecutivo ya se encuentra dentro del S016 y el S111 pero no se sabe con certeza
			//si se encuentra dentro del c430 o no.
			try
			{
					string slResultado = String.Empty;
					bmError = true;
					slResultado = gObjetoAlta.fncConsultac430S();
					if (slResultado == "ErrorConexion")
					{
						//imEstado = 3
						if (gObjetoAlta.fncActualizaEstatusTemporalB(3))
						{
							MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
						} else
						{
							MessageBox.Show("No se pudo actualizar el estado 3 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					} else
					{
						if (slResultado == "NoEsta")
						{
							//imEstado = 2
							if (gObjetoAlta.fncActualizaEstatusTemporalB(2))
							{
								MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
							} else
							{
								MessageBox.Show("No se pudo actualizar el estado 2 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
						} else
						{
							if (slResultado == "NoCoinciden")
							{
								//imEstado = 2
								if (gObjetoAlta.fncActualizaEstatusTemporalB(2))
								{
									MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
								} else
								{
									MessageBox.Show("No se pudo actualizar el estado 2 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
								}
							} else
							{
								if (slResultado == "Coinciden")
								{
									//imEstado = 4
									if (gObjetoAlta.fncActualizaEstatusTemporalB(4))
									{
										bmError = false;
										prEstado4();
									} else
									{
										MessageBox.Show("No se pudo actualizar el estado 4 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
									}
								}
							}
						}
					}
				}
			catch 
			{
				
				string tempRefParam = "PrEstado3";
				if (MdlCambioMasivo.fnGetError(ref tempRefParam))
				{
					throw new Exception("Migration Exception: 'Resume' not supported");
				}
			}
			
		}
		private void  prEstado4()
		{
			//En este estado el ejecutivo ya se encuentra dentro del S016, S111 y el c430.
			try
			{
					bmError = true;
                    //if (! gObjetoAlta.fncActualizaCredAcumB())
                    //{
                    //    //imEstado = 4
                    //    if (gObjetoAlta.fncActualizaEstatusTemporalB(4))
                    //    {
                    //        MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Ejecutiva", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    } else
                    //    {
                    //        MessageBox.Show("No se pudo actualizar el estado 4 en Temporal.", "Tarjeta Ejecutiva", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    //} else
                    //{
						//imEstado = 7
						if (gObjetoAlta.fncActualizaEstatusTemporalB(7))
						{
							bmError = false;
							prEstado7();
						} else
						{
                            MessageBox.Show("No se pudo actualizar el estado 7 en Temporal.", "Tarjeta Ejecutiva", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
                    //}
				}
			catch 
			{
				
				string tempRefParam = "PrEstado4";
				if (MdlCambioMasivo.fnGetError(ref tempRefParam))
				{
					throw new Exception("Migration Exception: 'Resume' not supported");
				}
			}
			
		}
		private void  prEstado5()
		{
			try
			{
					//En este estado el ejecutivo ya se encuentra dentro del S016 pero no se encuentra dentro del
					//S111 ni dentro del c430.
					string slRespuesta = String.Empty;
					string slResultado = String.Empty;
					
					bmError = true;
					slResultado = gObjetoAlta.fncEnviaDialogoLocalSegundaS(ref slRespuesta, true);
					//If slResultado = "00" Or slResultado = "05" Or slResultado = "07alta" Then
					if (slResultado == "00")
					{
						//imEstado = 1
						if (gObjetoAlta.fncActualizaEstatusTemporalB(1))
						{
							bmError = false;
							prEstado1();
						} else
						{
							MessageBox.Show("No se pudo actualizar el estado 1 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					} else
					{
						if (slResultado == "02" || slResultado == "05")
						{
							MessageBox.Show(slRespuesta, "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
							//imEstado = 5
							if (gObjetoAlta.fncActualizaEstatusTemporalB(5))
							{
								MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
							} else
							{
								MessageBox.Show("No se pudo actualizar el estado 5 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
						} else
						{
							//Hay que implementar una función que grabe en un archivo log el detalle del
							//tarjetahabitente.
							gObjetoAlta.prRegistraLog(slRespuesta);
							//MsgBox slRespuesta, vbCritical + vbOKOnly, "Tarjeta Corporativa"
							//imEstado = 5
							if (gObjetoAlta.fncActualizaEstatusTemporalB(5))
							{
								MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
							} else
							{
								MessageBox.Show("No se pudo actualizar el estado 5 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
						}
					}
				}
			catch 
			{
				
				string tempRefParam = "PrEstado5";
				if (MdlCambioMasivo.fnGetError(ref tempRefParam))
				{
					throw new Exception("Migration Exception: 'Resume' not supported");
				}
			}
			
		}
		private void  prEstado7()
		{
			try
			{
					//En este estado los datos del ejecutivo ya se encuentran dentro del S016, S111, c430 y ya se encuentra
					//calculado el crédito acumulado de la empresa.
					bmError = true;
					if (! gObjetoAlta.fncEliminaRespB())
					{
						//MsgBox "No se pudo eliminar el respaldo del ejecutivo.", vbInformation + vbOKOnly, "Tarjeta Corporativa"
						MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
					} else
					{
						bmError = false;
					}
				}
			catch 
			{
				
				string tempRefParam = "PrEstado7";
				if (MdlCambioMasivo.fnGetError(ref tempRefParam))
				{
					throw new Exception("Migration Exception: 'Resume' not supported");
				}
			}
			
		}
		
		
		public string EjeStatusS
		{
			set
			{
				try
				{
						//imEstado = -1
						switch(value.Trim())
						{
							case "0" : 
								//imEstado = 0 
								prEstado0(); 
								break;
							case "1" : 
								//imEstado = 1 
								prEstado1(); 
								break;
							case "2" : 
								//imEstado = 2 
								prEstado2(); 
								break;
							case "3" : 
								//imEstado = 3 
								prEstado3(); 
								break;
							case "4" : 
								//imEstado = 4 
								prEstado4(); 
								break;
							case "5" : 
								//imEstado = 5 
								prEstado5(); 
								break;
							case "7" : 
								//imEstado = 7 
								prEstado7(); 
								break;
							default:
								//imEstado = -1 
								break;
						}
					}
				catch 
				{
					
					
					string tempRefParam = "EjeStatusS:" + value;
					if (MdlCambioMasivo.fnGetError(ref tempRefParam))
					{
						throw new Exception("Migration Exception: 'Resume' not supported");
					}
				}
			}
		}

        public string EjeStatusSComdrv
        {
            set
            {
                try
                {
                    //imEstado = -1
                    switch (value.Trim()) //BORRAR COMENTARIO 
                    {
                        case "0":
                            //imEstado = 0 
                            prEstadoComdrv0();
                            break;
                        case "1":
                            //imEstado = 0 
                            prEstadoComdrv1();
                            break;
                        case "2":
                            //imEstado = 2 
                            prEstadoComdrv2();
                            break;
                        case "3":
                            //imEstado = 2 
                            prEstadoComdrv3();
                            break;
                        case "4":
                            //imEstado = 4 
                            prEstadoComdrv4();
                            break;
                        case "5":
                            //imEstado = 5 
                            prEstadoComdrv5();
                            break;
                        case "7":
                            //imEstado = 7 
                            prEstadoComdrv7();
                            break;

                        default:
                            //imEstado = -1 
                            break;
                    }
                }
                catch
                {


                    string tempRefParam = "EjeStatusS:" + value;
                    if (MdlCambioMasivo.fnGetError(ref tempRefParam))
                    {
                        throw new Exception("Migration Exception: 'Resume' not supported");
                    }
                }
            }
        }

        private void prEstadoComdrv0()
        {
            try
            {

                string slRespuesta = String.Empty;
                string slResultado = String.Empty;
                bmError = true;
                slRespuesta = "";
                slResultado = "";

                if (gObjetoAlta.fncObtenNumB())
                {

                    slResultado = gObjetoAlta.fncEnviaDialogoLocalPrimeraSComdrv(ref slRespuesta, false);
                    if (slResultado == "00")
                    {
                        if (gObjetoAlta.fncGrabaTablaRespB())
                        {
                            //if (gObjetoAlta.fncActualizaConsecutivoB())
                            //{
                                if (gObjetoAlta.fncActualizaEstatusTemporalB(1))//cambio a 1 27/03/2014
                                {
                                    bmError = false;
                                    prEstadoComdrv1();
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo actualizar el estado 1 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            //}
                            //else
                            //{
                            //    MessageBox.Show("Ya se encuentra dentro del S016 y S111, pero no se pudo actualizar el consecutivo.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //}
                        }
                        else
                        {
                            MessageBox.Show("Ya se encuentra dentro del S016 y S111, pero no se pudo grabar el respaldo.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (Strings.Mid(slResultado, 1, 4) == "5566" && Strings.Mid(slResultado, 6, 2) == "01")
                        {

                            if (Strings.Mid(slResultado, 45, 2) == "05" || Strings.Mid(slResultado, 45, 6) == "07alta")
                            {
                                if (gObjetoAlta.fncGrabaTablaRespB())
                                {
                                    //if (gObjetoAlta.fncActualizaConsecutivoB())
                                    //{
                                        //imEstado = 5
                                        if (gObjetoAlta.fncActualizaEstatusTemporalB(5))
                                        {
                                            MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            bmError = false;
                                        }
                                        else
                                        {
                                            MessageBox.Show("No se pudo actualizar el estado 5 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    //}
                                    //else
                                    //{
                                    //    MessageBox.Show("Ya se encuentra registrado en S016 pero no se actualizó el consecutivo.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //}
                                }
                                else
                                {
                                    MessageBox.Show("Ya se encuentra dentro del S016, pero no se pudo grabar el respaldo.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                if (Strings.Mid(slResultado, 45, 2) == "02" || Strings.Mid(slResultado, 45, 2) == "35" ||
                                    Strings.Mid(slResultado, 45, 2) == "06" || Strings.Mid(slResultado, 45, 7) == "07error")
                                {
                                    MessageBox.Show(slRespuesta, "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }
                                else
                                {
                                    if (slResultado.Trim() == "ErrorConexion")
                                    {
                                        MessageBox.Show("Error en la conexion", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    }
                                    else
                                    {
                                        //Mandar la información a un archivo log con los datalles de
                                        //del ejecutivo.
                                        gObjetoAlta.prRegistraLog(slRespuesta);
                                    }
                                }
                            }
                        }

                    }

                }
            }
            catch (Exception excep)
            {
                string tempRefParam = "PrEstadoComdrv0" + excep.Source;
                if (MdlCambioMasivo.fnGetError(ref tempRefParam))
                {
                    throw new Exception("Migration Exception: 'Resume' not supported");
                }
            }
        }

        private void prEstadoComdrv1()
        {
            //En este estado ya el ejecutivo se encuentra registrado dentro del S016 pero aún no se sabe
            //si se encuentra registrado en el S111
            try
            {
                string slCuenta = String.Empty;
                string slConsulta = String.Empty;
                string slResultado = String.Empty;
                bmError = true;
                //slResultado = gObjetoAlta.fncConsultaS111S();
                slResultado = gObjetoAlta.fncConsultaS111EjeComDrv(slCuenta, out slConsulta);
                if (slResultado == "ErrorConexion")
                {
                    MessageBox.Show("Error en la conexion.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //imEstado = 1
                    if (gObjetoAlta.fncActualizaEstatusTemporalB(1))
                    {
                        MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el estado 1 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (slResultado == "NoCoinciden")
                    {
                        //Manda un error de alerta.
                        //imEstado = 2
                        gObjetoAlta.prRegistraLog(slResultado);
                        if (gObjetoAlta.fncActualizaEstatusTemporalB(2))
                        {
                            prEstadoComdrv2();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el estado 2 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (slResultado == "Coinciden")
                        {
                            //imEstado = 2
                            if (gObjetoAlta.fncActualizaEstatusTemporalB(2))
                            {
                                bmError = false;
                                prEstadoComdrv2();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar el estado 2 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            if (slResultado == "NoEncontrado")
                            {
                                //imEstado = 5
                                if (gObjetoAlta.fncActualizaEstatusTemporalB(5))
                                {
                                    MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo actualizar el estado 5 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
            }
            catch
            {

                string tempRefParam = "PrEstadoComdrv1";
                if (MdlCambioMasivo.fnGetError(ref tempRefParam))
                {
                    throw new Exception("Migration Exception: 'Resume' not supported");
                }
            }

        }

        private void prEstadoComdrv2()
        {
            //En este estado ya hay certidumbre de que el ejecutivo se encuentra tanto en el S016 como en
            //el S111
            try
            {
                string slResultado = String.Empty;
                bmError = true;

                slResultado = gObjetoAlta.fncConsultac430S();
                if (slResultado == "Coinciden")
                {
                    //imEstado = 3
                    MessageBox.Show("El ejecutivo ya se encontraba registrado.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!gObjetoAlta.fncActualizaEstatusTemporalB(3))
                    {
                        MessageBox.Show("No se pudo actualizar el estado 3 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }
                if (gObjetoAlta.fncInsertaM111B())
                {

                    if (gObjetoAlta.fncActualizaEstatusTemporalB(3))
                    {

                        bmError = false;
                        prEstadoComdrv3();

                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el estado 3 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (gObjetoAlta.fncActualizaEstatusTemporalB(2))
                    {

                        MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el estado 2 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch
            {

                string tempRefParam = "PrEstadoComdrv2";
                if (MdlCambioMasivo.fnGetError(ref tempRefParam))
                {
                    throw new Exception("Migration Exception: 'Resume' not supported");
                }
            }

        }

        private void prEstadoComdrv3()
        {
            //En este estado el ejecutivo ya se encuentra dentro del S016 y el S111 pero no se sabe con certeza
            //si se encuentra dentro del c430 o no.
            try
            {
                string slResultado = String.Empty;
                bmError = true;
                slResultado = gObjetoAlta.fncConsultac430S();
                if (slResultado == "ErrorConexion")
                {
                    //imEstado = 3
                    if (gObjetoAlta.fncActualizaEstatusTemporalB(3))
                    {
                        MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el estado 3 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (slResultado == "NoEsta")
                    {
                        //imEstado = 2
                        if (gObjetoAlta.fncActualizaEstatusTemporalB(2))
                        {
                            MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el estado 2 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (slResultado == "NoCoinciden")
                        {
                            //imEstado = 2
                            if (gObjetoAlta.fncActualizaEstatusTemporalB(2))
                            {
                                MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar el estado 2 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            if (slResultado == "Coinciden")
                            {
                                //imEstado = 4
                                if (gObjetoAlta.fncActualizaEstatusTemporalB(4))
                                {
                                    bmError = false;
                                    prEstadoComdrv4();
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo actualizar el estado 4 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
            }
            catch
            {

                string tempRefParam = "PrEstadoComdrv3";
                if (MdlCambioMasivo.fnGetError(ref tempRefParam))
                {
                    throw new Exception("Migration Exception: 'Resume' not supported");
                }
            }

        }

        private void prEstadoComdrv4()
        {
            //En este estado el ejecutivo ya se encuentra dentro del S016, S111 y el c430.
            try
            {
                bmError = true;
                if (!gObjetoAlta.fncActualizaCredAcumB())
                {
                    //imEstado = 4
                    if (gObjetoAlta.fncActualizaEstatusTemporalB(4))
                    {
                        MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el estado 4 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //imEstado = 7
                    if (gObjetoAlta.fncActualizaEstatusTemporalB(7))
                    {
                        bmError = false;
                        prEstadoComdrv7();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el estado 7 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {

                string tempRefParam = "PrEstadoComdrv4";
                if (MdlCambioMasivo.fnGetError(ref tempRefParam))
                {
                    throw new Exception("Migration Exception: 'Resume' not supported");
                }
            }

        }

        private void prEstadoComdrv5()
        {
            try
            {

                string slRespuesta = String.Empty;
                string slResultado = String.Empty;

                bmError = true;
                //Cambio Art. 115
                //slResultado = gObjetoAlta.fncEnviaDialogoLocalSegundaS(ref slRespuesta, true);
                slResultado = gObjetoAlta.fncEnviaDialogoLocalSegundaSComdrv(ref slRespuesta, true);
                //If slResultado = "00" Or slResultado = "05" Or slResultado = "07alta" Then
                if (slResultado == "00")
                {

                    if (gObjetoAlta.fncActualizaEstatusTemporalB(1))
                    {
                        bmError = false;
                        prEstadoComdrv1();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el estado 1 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (Strings.Mid(slResultado, 1, 4) == "5566" && Strings.Mid(slResultado, 6, 2) == "01")
                    {
                        if (Strings.Mid(slResultado, 45, 2) == "02" || Strings.Mid(slResultado, 45, 2) == "05")
                        {
                            MessageBox.Show(slRespuesta, "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //imEstado = 5
                            if (gObjetoAlta.fncActualizaEstatusTemporalB(5))
                            {
                                MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar el estado 5 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            //Hay que implementar una función que grabe en un archivo log el detalle del
                            //tarjetahabitente.
                            gObjetoAlta.prRegistraLog(slRespuesta);
                            //MsgBox slRespuesta, vbCritical + vbOKOnly, "Tarjeta Corporativa"
                            //imEstado = 5
                            if (gObjetoAlta.fncActualizaEstatusTemporalB(5))
                            {
                                MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar el estado 5 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                    }

                }
            }

            catch
            {
                string tempRefParam = "PrEstadoComdrv5";
                if (MdlCambioMasivo.fnGetError(ref tempRefParam))
                {
                    throw new Exception("Migration Exception: 'Resume' not supported");
                }
            }

        }

        private void prEstadoComdrv7()
        {
            try
            {
                //En este estado los datos del ejecutivo ya se encuentran dentro del S016, S111, c430 y ya se encuentra
                //calculado el crédito acumulado de la empresa.
                bmError = true;
                if (!gObjetoAlta.fncEliminaRespB())
                {
                    //MsgBox "No se pudo eliminar el respaldo del ejecutivo.", vbInformation + vbOKOnly, "Tarjeta Corporativa"
                    MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bmError = false;
                }
            }
            catch
            {

                string tempRefParam = "PrEstadoComdrv7";
                if (MdlCambioMasivo.fnGetError(ref tempRefParam))
                {
                    throw new Exception("Migration Exception: 'Resume' not supported");
                }
            }

        }
		
		public bool resultado
		{
			get
			{
				return bmError;
			}
		}
		
		
		public clsAltaTarjetahabiente mObjetoAlta
		{
			set
			{
				if (Information.IsReference(value))
				{
					gObjetoAlta = value;
				} else
				{
					gObjetoAlta = null;
				}
			}
		}
		
		
		~clsReenvioTarjetahabientes(){
			gObjetoAlta = null;
		}
}
}