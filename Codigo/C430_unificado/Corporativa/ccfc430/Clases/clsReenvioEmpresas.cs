using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;


namespace TCc430
{
	internal class clsReenvioEmpresas
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
		
		
		//Dim gObjetoAlta As Object
		clsAltaEmpresa gObjetoAlta = null;
		clsDatosEjecutivo gdteEjecutivo = null;
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
			//En este estado aún no se ha dado de alta al ejecutivo dentro del S016 ni en el S111 ni el
			//el c430.
			//Cuando fncEnviaDialogoLocal regresa 0 se registró exitosamente en el S016 y en el S111
			string slRespuesta = String.Empty;
			string slResultado = String.Empty;
			bmError = true;
			if (gObjetoAlta.fncObtenNumB())
			{
				if (mdlParametros.ES_DEBUG)
				{
					MessageBox.Show("resultado obtuvo numero", Application.ProductName);
				}
				slResultado = gObjetoAlta.fncEnviaDialogoLocalPrimeraS(ref slRespuesta, false);
				if (slResultado == "00")
				{
					if (mdlParametros.ES_DEBUG)
					{
						MessageBox.Show("resultado 00", Application.ProductName);
					}
					if (gObjetoAlta.fncGrabaTablaRespB())
					{
						if (mdlParametros.ES_DEBUG)
						{
							MessageBox.Show("grabo en la responsable", Application.ProductName);
						}
						if (gObjetoAlta.fncActualizaConsecutivoB())
						{
							if (mdlParametros.ES_DEBUG)
							{
								MessageBox.Show("actualizo consecutivo", Application.ProductName);
							}
							//imEstado = 1
							if (gObjetoAlta.fncActualizaEstatusTemporalB(1))
							{
								bmError = false;
								if (mdlParametros.ES_DEBUG)
								{
									MessageBox.Show("actualizo temporal 1", Application.ProductName);
								}
								prEstado1();
							} else
							{
								MessageBox.Show("No se pudo actualizar el estado 1 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
						} else
						{
							MessageBox.Show("Ya se encuentra dentro del S016 y S111, pero no se pudo actualizar el consecutivo.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					} else
					{
						MessageBox.Show("Ya se encuentra dentro del S016 y S111, pero no se pudo grabar el respaldo.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				} else
				{
					if (slResultado == "05" || slResultado == "07alta" || slResultado=="07error")
					{
						if (gObjetoAlta.fncGrabaTablaRespB())
						{
							if (gObjetoAlta.fncActualizaConsecutivoB())
							{
								//imEstado = 5
								if (gObjetoAlta.fncActualizaEstatusTemporalB(5))
								{
									MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
									bmError = false;
								} else
								{
									MessageBox.Show("No se pudo actualizar el estado 5 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
								}
							} else
							{
								MessageBox.Show("Ya se encuentra registrado en S016 pero no se actualizó el consecutivo.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
						} else
						{
							MessageBox.Show("Ya se encuentra dentro del S016, pero no se pudo grabar el respaldo.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					} else
					{
                        //if (slResultado == "02" || slResultado == "35" || slResultado == "06" || slResultado == "07error") cuando mara ERROR TIMEOUT DCUNIS regresa 07error, y no sabemos si se aplicó o no
						if (slResultado == "02" || slResultado == "35" || slResultado == "06" )
						{
							MessageBox.Show(slRespuesta, "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
							//            If slResultado = "06" And slRespuesta = "CONTRATO A DAR DE ALTA YA EXISTE" Then
							//                gObjetoAlta.fncActualizaConsecutivoB
							//            End If
							
						} else
						{
							if (slResultado.Trim() == "ErrorConexion")
							{
								MessageBox.Show("Error en la conexion", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
								gObjetoAlta.prRegistraLog(slRespuesta); //Comentar en produccion
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
		
		private void  prEstado1()
		{
			//En este estado ya el ejecutivo se encuentra registrado dentro del S016 pero aún no se sabe
			//si se encuentra registrado en el S111
			bmError = true;
			string slResultado = gObjetoAlta.fncConsultaS111S();
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
		private void  prEstado2()
		{
			//En este estado ya hay certidumbre de que el ejecutivo se encuentra tanto en el S016 como en
			//el S111
			bmError = true;
			
			string slResultado = gObjetoAlta.fncConsultac430S();
			if (slResultado == "Coinciden")
			{
				//imEstado = 3
				MessageBox.Show("La Empresa ya se encontraba registrada.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				MessageBox.Show("Para terminar de registrar la alta de la empresa, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				if (! gObjetoAlta.fncActualizaEstatusTemporalB(3))
				{
					MessageBox.Show("No se pudo actualizar el estado 3 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				return;
			}
			if (gObjetoAlta.fncInsertaM111BEMP())
			{
				//imEstado = 3
				if (gObjetoAlta.fncActualizaEstatusTemporalB(3))
				{
					bmError = false;
					mdlEmpresa.intReenvio = 0;
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
					MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				} else
				{
					MessageBox.Show("No se pudo actualizar el estado 2 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		
		private void  prEstado3()
		{
			//En este estado el ejecutivo ya se encuentra dentro del S016 y el S111 pero no se sabe con certeza
			//si se encuentra dentro del c430 o no.
			bmError = true;
			string slResultado = gObjetoAlta.fncConsultac430S();
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
							mdlEmpresa.intReenvio = 1;
						} else
						{
							MessageBox.Show("No se pudo actualizar el estado 2 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					} else
					{
						if (slResultado == "Coinciden")
						{
							//imEstado = 4
							if (gObjetoAlta.fncActualizaEstatusTemporalB(8))
							{
								bmError = false;
								prEstado8();
							} else
							{
								MessageBox.Show("No se pudo actualizar el estado 4 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
						}
					}
				}
			}
		}
		private void  prEstado4()
		{
			//En este estado el ejecutivo ya se encuentra dentro del S016, S111 y el c430.
			bmError = true;
			if (! gObjetoAlta.fncActualizaCredAcumB())
			{
				//imEstado = 4
				if (gObjetoAlta.fncActualizaEstatusTemporalB(4))
				{
					MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				} else
				{
					MessageBox.Show("No se pudo actualizar el estado 4 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			} else
			{
				//imEstado = 7
				if (gObjetoAlta.fncActualizaEstatusTemporalB(7))
				{
					bmError = false;
					prEstado7();
				} else
				{
					MessageBox.Show("No se pudo actualizar el estado 7 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		private void  prEstado5()
		{
			//En este estado el ejecutivo ya se encuentra dentro del S016 pero no se encuentra dentro del
			//S111 ni dentro del c430.
			string slRespuesta = String.Empty;
			
			bmError = true;
			string slResultado = gObjetoAlta.fncEnviaDialogoLocalSegundaS(ref slRespuesta, true);
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
		private void  prEstado7()
		{
			//En este estado los datos del ejecutivo ya se encuentran dentro del S016, S111, c430 y ya se encuentra
			//calculado el crédito acumulado de la empresa.
			bmError = true;
			if (! gObjetoAlta.fncEliminaRespB())
			{
				MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
			} else
			{
				bmError = false;
				gObjetoAlta.prRegistraCliente();
				gObjetoAlta.prMensajeEmpresaAlta();
			}
		}
		private void  prEstado8()
		{
			//Ya se verificó que esté dentro del c430 Empresas, ya se encuentran registrados en S016 y S111.
			bmError = true;
			
			string slResultado = gObjetoAlta.fncConsultac430EjeS();
			if (slResultado == "Coinciden")
			{
				MessageBox.Show("El ejecutivo0 para esta empresa ya se encontraba registrado.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				MessageBox.Show("Para terminar de registrar la alta de la empresa, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				if (! gObjetoAlta.fncActualizaEstatusTemporalB(9))
				{
					MessageBox.Show("No se pudo actualizar el estado 9 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				return;
			}
			if (gObjetoAlta.fncInsertaM111BEJE0())
			{
				if (gObjetoAlta.fncActualizaEstatusTemporalB(9))
				{
					bmError = false;
					prEstado9();
				} else
				{
					MessageBox.Show("No se pudo actualizar el estado 9 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			} else
			{
				if (gObjetoAlta.fncActualizaEstatusTemporalB(8))
				{
					MessageBox.Show("Para terminar de registrar la alta de la empresa, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				} else
				{
					MessageBox.Show("No se pudo actualizar el estado 8 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		private void  prEstado9()
		{
			//Ya se encuentran en S016, S111 y c430 Empresas, ya se registró dentro de c430 Tarjetahabientes pero
			//no se ha verificado que esté ahí.
			bmError = true;
			string slResultado = gObjetoAlta.fncConsultac430EjeS();
			if (slResultado == "ErrorConexion")
			{
				if (gObjetoAlta.fncActualizaEstatusTemporalB(9))
				{
					MessageBox.Show("Para terminar de registrar la alta de la empresa , reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				} else
				{
					MessageBox.Show("No se pudo actualizar el estado 9 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			} else
			{
				if (slResultado == "NoEsta")
				{
					if (gObjetoAlta.fncActualizaEstatusTemporalB(8))
					{
						MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
					} else
					{
						MessageBox.Show("No se pudo actualizar el estado 8 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				} else
				{
					if (slResultado == "NoCoinciden")
					{
						//imEstado = 8
						if (gObjetoAlta.fncActualizaEstatusTemporalB(8))
						{
							MessageBox.Show("Para terminar de registrar la alta de la empresa, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
						} else
						{
							MessageBox.Show("No se pudo actualizar el estado 8 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					} else
					{
						if (slResultado == "Coinciden")
						{
							//imEstado = 10
							if (gObjetoAlta.fncActualizaEstatusTemporalB(10))
							{
								bmError = false;
								prEstado10();
							} else
							{
								MessageBox.Show("No se pudo actualizar el estado 10 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
						}
					}
				}
			}
		}
		private void  prEstado10()
		{
			//Ya se encuentran registrados dentro de S016, S111, c430 Tarjetahabientes y se ha creado el Directorio
			//de la Empresa.
			bmError = true;
			if (! gObjetoAlta.fncCrea_Directorio_EmpB())
			{
				if (gObjetoAlta.fncActualizaEstatusTemporalB(10))
				{
					MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				} else
				{
					MessageBox.Show("No se pudo actualizar el estado 10 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			} else
			{
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

        private void prEstadoComDrv0()
        {
            //En este estado aún no se ha dado de alta al ejecutivo dentro del S016 ni en el S111 ni el
            //el c430.
            //Cuando fncEnviaDialogoLocal regresa 0 se registró exitosamente en el S016 y en el S111
            string slRespuesta = String.Empty;
            string slResultado = String.Empty;
            bmError = true;
            if (gObjetoAlta.fncObtenNumB())
            {
                if (mdlParametros.ES_DEBUG)
                {
                    MessageBox.Show("resultado obtuvo numero", Application.ProductName);
                }
                slResultado = gObjetoAlta.fncEnviaDialogoLocalPrimeraSComdrv(ref slRespuesta, false);
                if (slResultado == "00")
                {
                    if (mdlParametros.ES_DEBUG)
                    {
                        MessageBox.Show("resultado 00", Application.ProductName);
                    }
                    if (gObjetoAlta.fncGrabaTablaRespB())
                    {
                        if (mdlParametros.ES_DEBUG)
                        {
                            MessageBox.Show("grabo en la responsable", Application.ProductName);
                        }
                        if (gObjetoAlta.fncActualizaConsecutivoB())
                        {
                            if (mdlParametros.ES_DEBUG)
                            {
                                MessageBox.Show("actualizo consecutivo", Application.ProductName);
                            }
                            //imEstado = 1
                            if (gObjetoAlta.fncActualizaEstatusTemporalB(1))
                            {
                                bmError = false;
                                if (mdlParametros.ES_DEBUG)
                                {
                                    MessageBox.Show("actualizo temporal 1", Application.ProductName);
                                }
                                prEstadoComDrv1();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar el estado 1 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ya se encuentra dentro del S016 y S111, pero no se pudo actualizar el consecutivo.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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

                        if (Strings.Mid(slResultado, 45, 2) == "05" || Strings.Mid(slResultado, 45, 6) == "07alta" || 
                            Strings.Mid(slResultado, 45, 7) == "07error")
                        {
                            if (gObjetoAlta.fncGrabaTablaRespB())
                            {
                                if (gObjetoAlta.fncActualizaConsecutivoB())
                                {
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
                                }
                                else
                                {
                                    MessageBox.Show("Ya se encuentra registrado en S016 pero no se actualizó el consecutivo.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Ya se encuentra dentro del S016, pero no se pudo grabar el respaldo.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            if (Strings.Mid(slResultado, 45, 2) == "02" || Strings.Mid(slResultado, 45, 2) == "35" ||
                                Strings.Mid(slResultado, 45, 2) == "06")
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

        private void prEstadoComDrv1()
        {
            //En este estado ya el ejecutivo se encuentra registrado dentro del S016 pero aún no se sabe
            //si se encuentra registrado en el S111
            bmError = true;
            string slCuenta = String.Empty;
            string slConsulta = String.Empty;
            //string slResultado = gObjetoAlta.fncConsultaS111S();    **************
            string slResultado = gObjetoAlta.fncConsultaS111SComDrv(slCuenta, out slConsulta);
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
                        prEstadoComDrv2();
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
                            prEstadoComDrv2();
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

        private void prEstadoComDrv2()
        {
            //En este estado ya hay certidumbre de que el ejecutivo se encuentra tanto en el S016 como en
            //el S111
            bmError = true;

            string slResultado = gObjetoAlta.fncConsultac430S();
            if (slResultado == "Coinciden")
            {
                //imEstado = 3
                MessageBox.Show("La Empresa ya se encontraba registrada.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Para terminar de registrar la alta de la empresa, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (!gObjetoAlta.fncActualizaEstatusTemporalB(3))
                {
                    MessageBox.Show("No se pudo actualizar el estado 3 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            if (gObjetoAlta.fncInsertaM111BEMP())
            {
                //imEstado = 3
                if (gObjetoAlta.fncActualizaEstatusTemporalB(3))
                {
                    bmError = false;
                    mdlEmpresa.intReenvio = 0;
                    prEstadoComDrv3();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el estado 3 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
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
        }

        private void prEstadoComDrv3()
        {
            //En este estado el ejecutivo ya se encuentra dentro del S016 y el S111 pero no se sabe con certeza
            //si se encuentra dentro del c430 o no.
            bmError = true;
            string slResultado = gObjetoAlta.fncConsultac430S();
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
                            mdlEmpresa.intReenvio = 1;
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
                            if (gObjetoAlta.fncActualizaEstatusTemporalB(8))
                            {
                                bmError = false;
                                prEstadoComDrv8();
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

        private void prEstadoComDrv4()
        {
            //En este estado el ejecutivo ya se encuentra dentro del S016, S111 y el c430.
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
                    prEstadoComDrv7();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el estado 7 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void prEstadoComDrv5()
        {
            //En este estado el ejecutivo ya se encuentra dentro del S016 pero no se encuentra dentro del
            //S111 ni dentro del c430.
            string slRespuesta = String.Empty;

            bmError = true;
            string slResultado = gObjetoAlta.fncEnviaDialogoLocalSegundaSComdrv(ref slRespuesta, true);
            if (slResultado == "00")
            {
                //imEstado = 1
                if (gObjetoAlta.fncActualizaEstatusTemporalB(1))
                {
                    bmError = false;
                    prEstadoComDrv1();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el estado 2 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void prEstadoComDrv7()
        {
            //En este estado los datos del ejecutivo ya se encuentran dentro del S016, S111, c430 y ya se encuentra
            //calculado el crédito acumulado de la empresa.
            bmError = true;
            if (!gObjetoAlta.fncEliminaRespB())
            {
                MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bmError = false;
                gObjetoAlta.prRegistraCliente();
                gObjetoAlta.prMensajeEmpresaAlta();
            }
        }

        private void prEstadoComDrv8()
        {
            //Ya se verificó que esté dentro del c430 Empresas, ya se encuentran registrados en S016 y S111.
            bmError = true;

            string slResultado = gObjetoAlta.fncConsultac430EjeS();
            if (slResultado == "Coinciden")
            {
                MessageBox.Show("El ejecutivo0 para esta empresa ya se encontraba registrado.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Para terminar de registrar la alta de la empresa, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (!gObjetoAlta.fncActualizaEstatusTemporalB(9))
                {
                    MessageBox.Show("No se pudo actualizar el estado 9 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            if (gObjetoAlta.fncInsertaM111BEJE0())
            {
                if (gObjetoAlta.fncActualizaEstatusTemporalB(9))
                {
                    bmError = false;
                    prEstadoComDrv9();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el estado 9 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (gObjetoAlta.fncActualizaEstatusTemporalB(8))
                {
                    MessageBox.Show("Para terminar de registrar la alta de la empresa, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el estado 8 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void prEstadoComDrv9()
        {
            //Ya se encuentran en S016, S111 y c430 Empresas, ya se registró dentro de c430 Tarjetahabientes pero
            //no se ha verificado que esté ahí.
            bmError = true;
            string slResultado = gObjetoAlta.fncConsultac430EjeS();
            if (slResultado == "ErrorConexion")
            {
                if (gObjetoAlta.fncActualizaEstatusTemporalB(9))
                {
                    MessageBox.Show("Para terminar de registrar la alta de la empresa , reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el estado 9 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (slResultado == "NoEsta")
                {
                    if (gObjetoAlta.fncActualizaEstatusTemporalB(8))
                    {
                        MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el estado 8 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (slResultado == "NoCoinciden")
                    {
                        //imEstado = 8
                        if (gObjetoAlta.fncActualizaEstatusTemporalB(8))
                        {
                            MessageBox.Show("Para terminar de registrar la alta de la empresa, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el estado 8 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (slResultado == "Coinciden")
                        {
                            //imEstado = 10
                            if (gObjetoAlta.fncActualizaEstatusTemporalB(10))
                            {
                                bmError = false;
                                prEstadoComDrv10();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar el estado 10 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private void prEstadoComDrv10()
        {
            //Ya se encuentran registrados dentro de S016, S111, c430 Tarjetahabientes y se ha creado el Directorio
            //de la Empresa.
            bmError = true;
            if (!gObjetoAlta.fncCrea_Directorio_EmpB())
            {
                if (gObjetoAlta.fncActualizaEstatusTemporalB(10))
                {
                    MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el estado 10 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (gObjetoAlta.fncActualizaEstatusTemporalB(4))
                {
                    bmError = false;
                    prEstadoComDrv4();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el estado 4 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
		
		public string EjeStatusS
		{
			set
			{
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
					case "8" : 
						//imEstado = 8 
						prEstado8(); 
						break;
					case "9" : 
						//imEstado = 9 
						prEstado9(); 
						break;
					case "10" : 
						//imEstado = 10 
						prEstado10(); 
						break;
                    case "20":
                        //imEstado = 20 
                        prEstado20();
                        break;
					default:
						//imEstado = -1 
						break;
				}
				
			}
		}


        public string EjeStatusSComDrv
        {
            set
            {
                switch (value.Trim())
                {
                    case "0":
                        //imEstado = 0 
                        prEstadoComDrv0();
                        break;
                    case "1":
                        //imEstado = 1 
                        prEstadoComDrv1();
                        break;
                    case "2":
                        //imEstado = 2 
                        prEstadoComDrv2();
                        break;
                    case "3":
                        //imEstado = 3 
                        prEstadoComDrv3();
                        break;
                    case "4":
                        //imEstado = 4 
                        prEstadoComDrv4();
                        break;
                    case "5":
                        //imEstado = 5 
                        prEstadoComDrv5();
                        break;
                    case "7":
                        //imEstado = 7 
                        prEstadoComDrv7();
                        break;
                    case "8":
                        //imEstado = 8 
                        prEstadoComDrv8();
                        break;
                    case "9":
                        //imEstado = 9 
                        prEstadoComDrv9();
                        break;
                    case "10":
                        //imEstado = 10 
                        prEstadoComDrv10();
                        break;
                    case "20":
                        //imEstado = 20 
                        prEstadoComDrv20();
                        break;
                    default:
                        //imEstado = -1 
                        break;
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
		
		
		public clsAltaEmpresa mObjetoAlta
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
		
		
		~clsReenvioEmpresas(){
			gObjetoAlta = null;
		}

        private void prEstado20()
        {
            //Se deja esta función para grabar en MTCINE01, debido a que se ha detectado que se graba en S016
            //pero no en el S111 y en C430, y tampoco queda registrada en reenvíos.
            string slRespuesta = String.Empty;
            string slResultado = String.Empty;
            bmError = true;
            if (gObjetoAlta.fncObtenNumB())
            {
                if (mdlParametros.ES_DEBUG)
                {
                    MessageBox.Show("resultado obtuvo numero  prEstado20", Application.ProductName);
                }
                if (gObjetoAlta.fncGrabaTablaRespB())
                {
                    if (gObjetoAlta.fncActualizaEstatusTemporalB(1))
                    {
                        MessageBox.Show("Se grabó la empresa en reenvío. Está pendiente de enviar", Application.ProductName);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo grabar la empresa en reenvío", Application.ProductName);
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo grabar en REENVIOS favor de reportar al encargado", Application.ProductName);
                }
            }
        }

        private void prEstadoComDrv20()
        {
            //Se deja esta función para grabar en MTCINE01, debido a que se ha detectado que se graba en S016
            //pero no en el S111 y en C430, y tampoco queda registrada en reenvíos.
            string slRespuesta = String.Empty;
            string slResultado = String.Empty;
            bmError = true;
            if (gObjetoAlta.fncObtenNumB())
            {
                if (mdlParametros.ES_DEBUG)
                {
                    MessageBox.Show("resultado obtuvo numero  prEstado20", Application.ProductName);
                }
                if (gObjetoAlta.fncGrabaTablaRespB())
                {
                    if (gObjetoAlta.fncActualizaEstatusTemporalB(1))
                    {
                        MessageBox.Show("Se grabó la empresa en reenvío. Está pendiente de enviar", Application.ProductName);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo grabar la empresa en reenvío", Application.ProductName);
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo grabar en REENVIOS favor de reportar al encargado", Application.ProductName);
                }
            }
        }

}
}