using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal class clsDialogo
	{
		public enum enuTipoDialogo
		{
			tAltaEmpresaS016 = 1 ,
			tAltaEmpresaS111 = 2 ,
			tConsEmpresaS016 = 3 ,
			tConsEmpresaS111 = 4 ,
			tAltaEjecutivoS016 = 5 ,
			tAltaEjecutivoS111 = 6 ,
			tConsEjecutivoS016 = 7 ,
			tConsEjecutivoS111 = 8 ,
			tCambioNombreEjeS111 = 9 ,
			tCambioCreditoEjeS111 = 10 ,
			tCambioEmpresaMasivosS111 = 11 ,
			tCambioMCCEmpresaS111 = 12 ,
			tCambioSkipEmpresaS111 = 13 ,
			tCambioMCCEjecutivoS111 = 14 ,
			tCambioSkipEjecutivoS111 = 15 ,
			tCambioDispEjecutivoS111 = 16 ,
			tCambioGenPinPlaEjecutivoS111 = 17 ,
			tCambioTipoBloqueoEjecutivoS111 = 18 ,
			// APQ 1-Julio-2010 Inicio - Cambio Tipo de Bloqueo
			tCambioLimCredEjecutivos = 19,
			tCambioTipBloqEmpresaS111 = 20,
			// APQ 1-Julio-2010 Inicio - Cambio Tipo de Bloqueo
			tAltaEjecutivosComdrv = 21
		}
		
		private string mvarDialogoS = String.Empty;
		public string mIdTransaccionS = String.Empty;
		public string mNumCuentaS = String.Empty;
		public string DialogoS
		{
			get
			{
				return mvarDialogoS;
			}
			set
			{
				mvarDialogoS = value;
			}
		}
		
		/// <summary>
		///		Se hacen cambios en las direcciones ya que salen invertidas en producción, el cambio se realizo en las lineas
		///		760-765,768-769,771-772, 783-786,788-793
		///		Junio 6, 2016
		///		Alejandro Pérez Hernández
		/// </summary>
		public void  prGeneraDlg( object objpRepositorio,  enuTipoDialogo ipTipoDlg)
		{
			clsDatosEmpresa demplEmpresa = null;
			clsDatosEjecutivo dejelEjecutivo = null;
			string slDialogo = String.Empty;
			try
			{
				switch(ipTipoDlg)
				{
					case enuTipoDialogo.tAltaEmpresaS016 :  //***** Transaccion de Alta Empresa S016 ***** 
							demplEmpresa = null; 
							demplEmpresa = (clsDatosEmpresa) objpRepositorio;  //Se le pasa el valor de la Clase clsDatosEmpresa 
							slDialogo = new String(' ', 1133);  //Variable local que va a tener el Dialogo 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1, "C430");  //Sistema 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 5, mdlParametros.ctesProcesoAltaS016);  //Clave de proceso 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 8, mdlParametros.ctesTipoAlta);  //Clave tipo de alta 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 10, mdlParametros.ctesTipoTramite);  //Clave tipo de trámite 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 12, "00000000");  //Número de Folio 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 20, "000000000000");  //Numero de Nómina 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 32, mdlParametros.ctesTipoTransaccion);  //Transacción 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 36, demplEmpresa.EmpCuentaS);  //Cuenta 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 52, demplEmpresa.EmpNomGrabaS);  //Nombre de Grabacion 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 78, "F");  //Sexo **** OJO **** 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 79, StringsHelper.Format(demplEmpresa.EmpDiaCorteI, "00"));  //Dia de Corte 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 81, "0137");  //Sucursal Transmisora **** OJO **** 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 85, "0137");  //Sucursal Promotora **** OJO **** 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 89, StringsHelper.Format(Conversion.Str(demplEmpresa.EmpLimDisEfecI), "000000000"));  //Límite de Crédito **** OJO **** 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 98, DateTime.Today.ToString("yyyyMMdd"));  //Fecha Alta 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 106, mdlParametros.ctesTipoOrigen);  //Origen 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 107, demplEmpresa.EmpDomEnvioDMC.DomicilioS);  //Calle y Número 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 142, demplEmpresa.EmpDomEnvioDMC.ColoniaS);  //Colonia 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 167, demplEmpresa.EmpDomEnvioDMC.PoblacionS);  //Poblacion 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 188, demplEmpresa.EmpDomEnvioDMC.EstadoEST.AbreviaturaS);  //Estado 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 192, "00");  //Zona Postal 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 194, StringsHelper.Format(demplEmpresa.EmpDomEnvioDMC.CPL, "00000"));  //Codigo Postal 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 199, "0000");  //Actividad Subactividad 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 203, StringsHelper.Format(StringsHelper.DoubleValue(demplEmpresa.EmpTelefonoS.Trim()).ToString().Substring(StringsHelper.DoubleValue(demplEmpresa.EmpTelefonoS.Trim()).ToString().Length - Math.Min(StringsHelper.DoubleValue(demplEmpresa.EmpTelefonoS.Trim()).ToString().Length, 7)), "0000000"));  //Telefono Particular 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 210, StringsHelper.Format(StringsHelper.DoubleValue(demplEmpresa.EmpTelefonoS.Trim()).ToString().Substring(StringsHelper.DoubleValue(demplEmpresa.EmpTelefonoS.Trim()).ToString().Length - Math.Min(StringsHelper.DoubleValue(demplEmpresa.EmpTelefonoS.Trim()).ToString().Length, 7)), "0000000"));  //Telefono de Oficina 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 217, StringsHelper.Format(StringsHelper.DoubleValue(demplEmpresa.EmpExtensionS.Trim()).ToString().Substring(StringsHelper.DoubleValue(demplEmpresa.EmpExtensionS.Trim()).ToString().Length - Math.Min(StringsHelper.DoubleValue(demplEmpresa.EmpExtensionS.Trim()).ToString().Length, 4)), "0000"));  //Extension 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 221, new String(' ', 1)); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 222, demplEmpresa.EmpRfcRFC.fncConstruyeRfcS(false).Trim());  //RFC 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 235, "000");  //Lada Telefono Casa 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 238, "000");  //Lada Telefono Oficina 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 241, "000");  //Puntos del Scoredcard 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 244, "000");  //Identificador del Scoredcard 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 247, StringsHelper.Format(DateTime.Today.ToString("yyyyMMdd"), "000000"));  //Fecha de Evaluación 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 253, new String(' ', 35)); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 288, new String(' ', 25)); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 313, new String(' ', 25)); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 338, "00000"); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 343, new String(' ', 55)); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 398, "00000000"); 
							//UPGRADE_WARNING: (1068) GeneracionPlastico.cteNoPlasticoNoPIN of type CRSParametros.GeneracionPlastico is being forced to Scalar. 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 406, StringsHelper.Format(CRSParametros.GeneracionPlastico.cteNoPlasticoNoPIN, "0"));  //Genera Pin Plastico 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 407, "1");  //Identificador de Domicilio 1=casa 2=oficina 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 408, new String(' ', 10));  //Identificador de Linea Aerea 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 418, new String(' ', 30));  //Nombre 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 448, demplEmpresa.EmpNomS);  //Ap. Paterno 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 478, new String(' ', 30));  //Ap. Materno 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 508, "0000");  //Transaccion 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 512, "0000000000000000");  //Numero de Cuenta 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 528, new String(' ', 26));  //Nombre del Solicitante 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 554, new String(' ', 1));  //Sexo 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 555, "00000000");  //Fecha de Nacimiento 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 563, new String(' ', 35));  //Direccion 1 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 598, new String(' ', 25));  //Direccion 2 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 623, new String(' ', 25));  //Direccion 3 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 648, "00");  //Zona Postal 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 650, "00000");  //Codigo Postal 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 655, "0000000");  //Telefono Particular 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 662, "000");  //Lada 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 665, "000000000");  //Credito 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 674, "0");  //Indicador de generacion de plastico 0=normal, 1=urgente 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 675, "0000");  //Region Grupo 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 679, "0000");  //Región en Cadena 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 683, "00000000");  //Número de Negocio 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 691, new String(' ', 40));  //Nombre Razon 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 731, "00000000");  //Fecha de Nacimiento 
							if (demplEmpresa.EmpSucEjeL == 0 || demplEmpresa.EmpCtaEjeD == 0)
							{
								slDialogo = StringsHelper.MidAssignment(slDialogo, 739, "0000000000000000"); //Tarjeta 1
							} else
							{
								slDialogo = StringsHelper.MidAssignment(slDialogo, 739, (StringsHelper.Format(demplEmpresa.EmpSucEjeL, "0000") + StringsHelper.Format(demplEmpresa.EmpSucEjeL, "000000000000")).Trim());
							} 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 755, "0000000000000000");  //Tarjeta 2 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 771, "00");  //Clave Nacionalidad 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 773, "0000");  //Clave Ocupacion 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 777, "0000000000");  //Numero de Nomina 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 787, "ADE");  //Tipo Operacion 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 790, new String(' ', 55));  //Nombre Largo Adicional 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 845, "00000000");  //Fecha Nacimiento Adicional 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 853, new String(' ', 1));  //Clave Parentesco Adicional 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 854, new String(' ', 38));  //Filler 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 892, new String(' ', 56));  //Info tabla B11 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 948, new String(' ', 150));  //Comentarios 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1098, "00");  //Familia Producto y Tipo Solicitud 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1100, "00");  //Tipo Solicitud 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1102, mdlParametros.ctesEmpresa);  //Tipo Cuenta 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1103, StringsHelper.Format(demplEmpresa.EmpSkipPaymentI, "0"));  //Skip Payment 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1104, StringsHelper.Format(demplEmpresa.EmpTablaMccL, "0000"));  //Indicativo de tabla MCC 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1108, StringsHelper.Format(demplEmpresa.EmpLimDisEfecI, "000"));  //Limite de Disposiciones 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1111, demplEmpresa.EmpTipoFacS);  //Tipo de Facturacion 
							this.DialogoS = slDialogo; 
							break;
					case enuTipoDialogo.tAltaEmpresaS111 :  //***** Transaccion de Alta Empresa S111 ***** 
							demplEmpresa = null; 
							demplEmpresa = (clsDatosEmpresa) objpRepositorio;  //Se le pasa el valor de la Clase clsDatosEmpresa 
							slDialogo = new String(' ', 1133);  //Variable local que va a tener el Dialogo 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1, "C430");  //Sistema 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 5, mdlParametros.ctesProcesoAltaS111);  //Clave de Proceso 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 8, mdlParametros.ctesTipoAlta);  //Clave tipo de alta 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 10, mdlParametros.ctesTipoTramite);  //Clave tipo de trámite 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 12, "00000000");  //Número de Folio 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 20, "000000000000");  //Numero de Nómina 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 32, mdlParametros.ctesTipoTransaccion);  //Transacción 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 36, demplEmpresa.EmpCuentaS);  //Cuenta 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 52, demplEmpresa.EmpNomGrabaS);  //Nombre de Grabacion 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 78, "F");  //Sexo **** OJO **** 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 79, StringsHelper.Format(demplEmpresa.EmpDiaCorteI, "00"));  //Dia de Corte 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 81, "0137");  //Sucursal Transmisora **** OJO **** 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 85, "0137");  //Sucursal Promotora **** OJO **** 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 89, StringsHelper.Format(Conversion.Str(demplEmpresa.EmpLimDisEfecI), "000000000"));  //Límite de Crédito **** OJO **** 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 98, DateTime.Today.ToString("yyyyMMdd"));  //Fecha Alta 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 106, mdlParametros.ctesTipoOrigen);  //Origen 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 107, demplEmpresa.EmpDomEnvioDMC.DomicilioS);  //Calle y Número 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 142, demplEmpresa.EmpDomEnvioDMC.ColoniaS);  //Colonia 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 167, demplEmpresa.EmpDomEnvioDMC.PoblacionS);  //Poblacion 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 188, demplEmpresa.EmpDomEnvioDMC.EstadoEST.AbreviaturaS);  //Estado 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 192, "00");  //Zona Postal 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 194, StringsHelper.Format(demplEmpresa.EmpDomEnvioDMC.CPL, "00000"));  //Codigo Postal 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 199, "0000");  //Actividad Subactividad 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 203, StringsHelper.Format(StringsHelper.DoubleValue(demplEmpresa.EmpTelefonoS.Trim()).ToString().Substring(StringsHelper.DoubleValue(demplEmpresa.EmpTelefonoS.Trim()).ToString().Length - Math.Min(StringsHelper.DoubleValue(demplEmpresa.EmpTelefonoS.Trim()).ToString().Length, 7)), "0000000"));  //Telefono Particular 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 210, StringsHelper.Format(StringsHelper.DoubleValue(demplEmpresa.EmpTelefonoS.Trim()).ToString().Substring(StringsHelper.DoubleValue(demplEmpresa.EmpTelefonoS.Trim()).ToString().Length - Math.Min(StringsHelper.DoubleValue(demplEmpresa.EmpTelefonoS.Trim()).ToString().Length, 7)), "0000000"));  //Telefono de Oficina 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 217, StringsHelper.Format(StringsHelper.DoubleValue(demplEmpresa.EmpExtensionS.Trim()).ToString().Substring(StringsHelper.DoubleValue(demplEmpresa.EmpExtensionS.Trim()).ToString().Length - Math.Min(StringsHelper.DoubleValue(demplEmpresa.EmpExtensionS.Trim()).ToString().Length, 4)), "0000"));  //Extension 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 221, new String(' ', 1)); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 222, demplEmpresa.EmpRfcRFC.fncConstruyeRfcS(false).Trim());  //RFC 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 235, "000");  //Lada Telefono Casa 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 238, "000");  //Lada Telefono Oficina 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 241, "000");  //Puntos del Scoredcard 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 244, "000");  //Identificador del Scoredcard 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 247, StringsHelper.Format(DateTime.Today.ToString("yyyyMMdd"), "000000"));  //Fecha de Evaluación 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 253, new String(' ', 35)); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 288, new String(' ', 25)); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 313, new String(' ', 25)); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 338, "00000"); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 343, new String(' ', 55)); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 398, "00000000"); 
							//UPGRADE_WARNING: (1068) GeneracionPlastico.cteNoPlasticoNoPIN of type CRSParametros.GeneracionPlastico is being forced to Scalar. 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 406, StringsHelper.Format(CRSParametros.GeneracionPlastico.cteNoPlasticoNoPIN, "0"));  //Genera Pin Plastico 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 407, "1");  //Identificador de Domicilio 1=casa 2=oficina 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 408, new String(' ', 10));  //Identificador de Linea Aerea 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 418, new String(' ', 30));  //Nombre 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 448, demplEmpresa.EmpNomS);  //Ap. Paterno 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 478, new String(' ', 30));  //Ap. Materno 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 508, "0000");  //Transaccion 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 512, "0000000000000000");  //Numero de Cuenta 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 528, new String(' ', 26));  //Nombre del Solicitante 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 554, new String(' ', 1));  //Sexo 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 555, "00000000");  //Fecha de Nacimiento 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 563, new String(' ', 35));  //Direccion 1 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 598, new String(' ', 25));  //Direccion 2 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 623, new String(' ', 25));  //Direccion 3 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 648, "00");  //Zona Postal 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 650, "00000");  //Codigo Postal 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 655, "0000000");  //Telefono Particular 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 662, "000");  //Lada 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 665, "000000000");  //Credito 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 674, "0");  //Indicador de generacion de plastico 0=normal, 1=urgente 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 675, "0000");  //Region Grupo 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 679, "0000");  //Región en Cadena 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 683, "00000000");  //Número de Negocio 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 691, new String(' ', 40));  //Nombre Razon 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 731, "00000000");  //Fecha de Nacimiento 
							if (demplEmpresa.EmpSucEjeL == 0 || demplEmpresa.EmpCtaEjeD == 0)
							{
								slDialogo = StringsHelper.MidAssignment(slDialogo, 739, "0000000000000000"); //Tarjeta 1
							} 
							else
							{
								slDialogo = StringsHelper.MidAssignment(slDialogo, 739, (StringsHelper.Format(demplEmpresa.EmpSucEjeL, "0000") + StringsHelper.Format(demplEmpresa.EmpSucEjeL, "000000000000")).Trim());
							} 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 755, "0000000000000000");  //Tarjeta 2 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 771, "00");  //Clave Nacionalidad 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 773, "0000");  //Clave Ocupacion 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 777, "0000000000");  //Numero de Nomina 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 787, "ADE");  //Tipo Operacion 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 790, new String(' ', 55));  //Nombre Largo Adicional 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 845, "00000000");  //Fecha Nacimiento Adicional 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 853, new String(' ', 1));  //Clave Parentesco Adicional 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 854, new String(' ', 38));  //Filler 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 892, new String(' ', 56));  //Info tabla B11 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 948, new String(' ', 150));  //Comentarios 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1098, "00");  //Familia Producto y Tipo Solicitud 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1100, "00");  //Tipo Solicitud 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1102, mdlParametros.ctesEmpresa);  //Tipo Cuenta 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1103, StringsHelper.Format(demplEmpresa.EmpSkipPaymentI, "0"));  //Skip Payment 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1104, StringsHelper.Format(demplEmpresa.EmpTablaMccL, "0000"));  //Indicativo de tabla MCC 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1108, StringsHelper.Format(demplEmpresa.EmpLimDisEfecI, "000"));  //Limite de Disposiciones 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1111, demplEmpresa.EmpTipoFacS);  //Tipo de Facturacion 
							this.DialogoS = slDialogo; 
							break;
					case enuTipoDialogo.tConsEmpresaS016 :  //***** Transaccion de Consulta S016 ***** 
							mdlParametros.tgConsultaS016.NumCuentaS = (StringsHelper.Format(dejelEjecutivo.EjeProductoPRD.PrefijoL, dejelEjecutivo.EjeProductoPRD.MascaraPrefijoS) + StringsHelper.Format(dejelEjecutivo.EjeProductoPRD.BancoL, dejelEjecutivo.EjeProductoPRD.MascaraBancoS) + StringsHelper.Format(dejelEjecutivo.EjeEmpNumL, dejelEjecutivo.EjeProductoPRD.MascaraEmpresaS) + StringsHelper.Format(dejelEjecutivo.EjeNumL, dejelEjecutivo.EjeProductoPRD.MascaraEjecutivoS)).Trim(); 
							slDialogo = new String(' ', 148); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1, "001644");  //Transacción 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 7, "000000");  //Sistema origen, aplicación origen 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 13, "0016");  //Aplicación 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 17, "44");  //Código 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 19, "000");  //Sub código 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 22, "0000");  //Aplicación 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 26, "00");  //Código 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 28, "000");  //Sub código 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 31, "1");  //Dirección Envio=1, Regreso=2, Envio-Revoca=3, Regreso-Revoca=4 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 32, "1006");  //Longitud 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 36, "00015");  //Tiempo de espera 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 41, "01");  //Código de respuesta Solicitud=1, Respuesta=2, Timeout=3, Entregado=4, Confirma=6, Aceptado=7, Seguridad=8, Error=9 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 43, "000");  //Identificador Msg 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 46, "B");  //Versión 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 47, "0");  //Clase "O=original, 1=repetisión" 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 48, "0");  //Estado "Nonecesario =0, Aplicado=1, Rechazada=2" 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 49, "1");  //Modo "Interectivo=1, Notificacion=2, Certificado=3" 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 50, "0730");  //Origen 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 54, "000");  //Código Origen 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 57, "00000005");  // Número 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 65, "020515");  //Fecha 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 71, "171250");  //Hora 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 77, "22");  //Modalidad 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 79, "0000000000");  //Operador 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 89, "A");  // Versión Mensaje 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 90, "FDC001");  //Transacción 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 96, "0");  //Opción 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 97, "3");  //Sub Opción (Medio de Acceso) 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 98, "00");  //Versión 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 100, "0000");  //Error Código 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 104, "0000");  //Error SubCódigo 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 108, "0000");  //Error SubSubCódigo 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 112, "000000000000");  //Numero de Cliente 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 124, "0111");  //Producto 
							if (mdlParametros.gprdProducto.PrefijoL == 4943 && mdlParametros.gprdProducto.BancoL == 88)
							{
								slDialogo = StringsHelper.MidAssignment(slDialogo, 128, "0005"); //Instrumento
							} 
							else
							{
								slDialogo = StringsHelper.MidAssignment(slDialogo, 128, "0025"); //Instrumento
							} 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 132, StringsHelper.Format(mdlParametros.tgConsultaS016.NumCuentaS, "0000000000000000"));  //Cuenta 
							this.DialogoS = slDialogo; 
							break;
					case enuTipoDialogo.tConsEmpresaS111 :  //***** Transaccion de Consulta S111 ***** 
							slDialogo = new String(' ', 55); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1, "C430"); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 5, mdlParametros.ctesProcesoConsulta); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 8, "00"); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 10, mdlParametros.ctesTipoTramite); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 12, "00000000"); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 20, "000000000000"); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 32, mdlParametros.ctesTransaccionConsulta); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 36, mdlParametros.tgConsultaS111.NumCuentaS); 
							this.DialogoS = slDialogo; 
							break;
					case enuTipoDialogo.tAltaEjecutivoS016 :  //***** Transaccion de Alta Ejecutivo S016 ***** 
							dejelEjecutivo = null; 
							dejelEjecutivo = (clsDatosEjecutivo) objpRepositorio;  //Se le pasa el valor de la Clase clsDatosEjecutivo 
							dejelEjecutivo.EjeCuentaS = (StringsHelper.Format(dejelEjecutivo.EjeProductoPRD.PrefijoL, dejelEjecutivo.EjeProductoPRD.MascaraPrefijoS) + StringsHelper.Format(dejelEjecutivo.EjeProductoPRD.BancoL, dejelEjecutivo.EjeProductoPRD.MascaraBancoS) + StringsHelper.Format(dejelEjecutivo.EjeEmpNumL, dejelEjecutivo.EjeProductoPRD.MascaraEmpresaS) + StringsHelper.Format(dejelEjecutivo.EjeNumL, dejelEjecutivo.EjeProductoPRD.MascaraEjecutivoS) + dejelEjecutivo.EjeRolloverI.ToString().Trim() + dejelEjecutivo.EjeDigitI.ToString().Trim()).Trim(); 
							slDialogo = new String(' ', 1133);  //Variable local que va a tener el Dialogo 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1, "C430");  //Sistema 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 5, mdlParametros.ctesProcesoAltaS016);  //Clave de proceso 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 8, mdlParametros.ctesTipoAlta);  //Clave tipo de alta 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 10, mdlParametros.ctesTipoTramite);  //Clave tipo de trámite 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 12, "00000000");  //Número de Folio 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 20, "000000000000");  //Numero de Nómina 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 32, mdlParametros.ctesTipoTransaccion);  //Transacción 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 36, dejelEjecutivo.EjeCuentaS);  //Cuenta 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 52, dejelEjecutivo.EjeNomGrabaS);  //Nombre 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 78, dejelEjecutivo.EjeSexoS);  //Sexo 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 79, StringsHelper.Format(dejelEjecutivo.EjeDiaCorteI, "00"));  //Dia de Corte 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 81, StringsHelper.Format(dejelEjecutivo.EjeSucTransS, "0000"));  //Sucursal Transmisora 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 85, StringsHelper.Format(dejelEjecutivo.EjeSucPromS, "0000"));  //Sucursal Promotora 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 89, StringsHelper.Format(Conversion.Str(dejelEjecutivo.EjeLimCredL), "000000000"));  //Límite de Crédito 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 98, DateTime.Today.ToString("yyyyMMdd"));  //Fecha Alta 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 106, dejelEjecutivo.EjeOrigenS);  //Origen 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 107, dejelEjecutivo.EjeDomEnvioDMC.DomicilioS);  //Calle y Número 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 142, dejelEjecutivo.EjeDomEnvioDMC.ColoniaS);  //Colonia 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 167, dejelEjecutivo.EjeDomEnvioDMC.PoblacionS);  //Poblacion 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 188, dejelEjecutivo.EjeDomEnvioDMC.EstadoEST.AbreviaturaS);  //Estado 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 192, "00");  //Zona Postal 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 194, StringsHelper.Format(dejelEjecutivo.EjeDomEnvioDMC.CPL, "00000"));  //Codigo Postal 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 199, StringsHelper.Format(dejelEjecutivo.EjeActiSubactiS, "0000"));  //Actividad Subactividad 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 203, StringsHelper.Format(StringsHelper.DoubleValue(((dejelEjecutivo.EjeTelDomS.Trim() == "") ? "0": dejelEjecutivo.EjeTelDomS.Trim()).Trim()).ToString().Substring(StringsHelper.DoubleValue(((dejelEjecutivo.EjeTelDomS.Trim() == "") ? "0": dejelEjecutivo.EjeTelDomS.Trim()).Trim()).ToString().Length - Math.Min(StringsHelper.DoubleValue(((dejelEjecutivo.EjeTelDomS.Trim() == "") ? "0": dejelEjecutivo.EjeTelDomS.Trim()).Trim()).ToString().Length, 7)), "0000000"));  //Telefono Particular 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 210, StringsHelper.Format(StringsHelper.DoubleValue(((dejelEjecutivo.EjeTelOfiS.Trim() == "") ? "0": dejelEjecutivo.EjeTelOfiS.Trim()).Trim()).ToString().Substring(StringsHelper.DoubleValue(((dejelEjecutivo.EjeTelOfiS.Trim() == "") ? "0": dejelEjecutivo.EjeTelOfiS.Trim()).Trim()).ToString().Length - Math.Min(StringsHelper.DoubleValue(((dejelEjecutivo.EjeTelOfiS.Trim() == "") ? "0": dejelEjecutivo.EjeTelOfiS.Trim()).Trim()).ToString().Length, 7)), "0000000"));  //Telefono de Oficina 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 217, StringsHelper.Format(StringsHelper.DoubleValue(((dejelEjecutivo.EjeExtensionS.Trim() == "") ? "0": dejelEjecutivo.EjeExtensionS.Trim()).Trim()).ToString().Substring(StringsHelper.DoubleValue(((dejelEjecutivo.EjeExtensionS.Trim() == "") ? "0": dejelEjecutivo.EjeExtensionS.Trim()).Trim()).ToString().Length - Math.Min(StringsHelper.DoubleValue(((dejelEjecutivo.EjeExtensionS.Trim() == "") ? "0": dejelEjecutivo.EjeExtensionS.Trim()).Trim()).ToString().Length, 4)), "0000"));  //Extension 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 221, new String(' ', 1)); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 222, dejelEjecutivo.EjeRfcRFC.fncConstruyeRfcS(false).Trim());  //RFC 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 235, "000");  //Lada Telefono Casa 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 238, "000");  //Lada Telefono Oficina 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 241, "000");  //Puntos del Scoredcard 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 244, "000");  //Identificador del Scoredcard 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 247, StringsHelper.Format(DateTime.Today.ToString("yyyyMMdd"), "000000"));  //Fecha de Evaluación 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 253, new String(' ', 35)); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 288, new String(' ', 25)); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 313, new String(' ', 25)); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 338, "00000"); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 343, new String(' ', 55)); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 398, "00000000"); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 406, StringsHelper.Format(dejelEjecutivo.EjeGenPinPlaI, "0"));  //Genera Pin Plastico 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 407, "1");  //Identificador de Domicilio 1=casa 2=oficina 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 408, new String(' ', 10));  //Identificador de Linea Aerea 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 418, Strings.Mid(dejelEjecutivo.EjeNomGrabaS, 1, dejelEjecutivo.EjeNomGrabaS.IndexOf(',')));  //Nombre 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 448, Strings.Mid(dejelEjecutivo.EjeNomGrabaS, (dejelEjecutivo.EjeNomGrabaS.IndexOf(',') + 1) + 1, (dejelEjecutivo.EjeNomGrabaS.IndexOf('/') + 1) - (dejelEjecutivo.EjeNomGrabaS.IndexOf(',') + 1) - 1));  //Apellido Paterno 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 478, dejelEjecutivo.EjeNomGrabaS.Substring(dejelEjecutivo.EjeNomGrabaS.Length - Math.Min(dejelEjecutivo.EjeNomGrabaS.Length, Strings.Len(dejelEjecutivo.EjeNomGrabaS) - (dejelEjecutivo.EjeNomGrabaS.IndexOf('/') + 1))));  //Apellido Materno 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 508, "0000");  //Transaccion 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 512, "0000000000000000");  //Numero de Cuenta 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 528, new String(' ', 26));  //Nombre del Solicitante 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 554, new String(' ', 1));  //Sexo 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 555, "00000000");  //Fecha de Nacimiento 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 563, new String(' ', 35));  //Direccion 1 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 598, new String(' ', 25));  //Direccion 2 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 623, new String(' ', 25));  //Direccion 3 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 648, "00");  //Zona Postal 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 650, "00000");  //Codigo Postal 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 655, "0000000");  //Telefono Particular 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 662, "000");  //Lada 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 665, "000000000");  //Credito 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 674, "0");  //Indicador de generacion de plastico 0=normal, 1=urgente 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 675, "0000");  //Region Grupo 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 679, "0000");  //Región en Cadena 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 683, "00000000");  //Número de Negocio 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 691, new String(' ', 40));  //Nombre Razon 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 731, DateTime.Parse(dejelEjecutivo.EjeRfcRFC.DiaI.ToString() + "/" + dejelEjecutivo.EjeRfcRFC.MesI.ToString() + "/" + dejelEjecutivo.EjeRfcRFC.AñoI.ToString()).ToString("yyyyMMdd"));  //Fecha de Nacimiento 
							if (dejelEjecutivo.EjeCuentaReferenciaS == "")
							{
								slDialogo = StringsHelper.MidAssignment(slDialogo, 739, "0000000000000000"); //Tarjeta 1
							}
							else
							{
								slDialogo = StringsHelper.MidAssignment(slDialogo, 739, StringsHelper.Format(dejelEjecutivo.EjeCuentaReferenciaS, "0000000000000000")); //Tarjeta 1
							} 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 755, "0000000000000000");  //Tarjeta 2 
							if (dejelEjecutivo.EjeNacionalidadS == "")
							{
								slDialogo = StringsHelper.MidAssignment(slDialogo, 771, "00"); //Clave Nacionalidad
							} 
							else
							{
								slDialogo = StringsHelper.MidAssignment(slDialogo, 771, StringsHelper.Format(dejelEjecutivo.EjeNacionalidadS, "00")); //Clave Nacionalidad
							} 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 773, "0000");  //Clave Ocupacion 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 777, "0000000000");  //Numero de Nomina 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 787, new String(' ', 3));  //Tipo Operacion 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 790, new String(' ', 55));  //Nombre Largo Adicional 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 845, "00000000");  //Fecha Nacimiento Adicional 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 853, new String(' ', 1));  //Clave Parentesco Adicional 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 854, new String(' ', 38));  //Filler 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 892, new String(' ', 56));  //Info tabla B11 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 948, new String(' ', 150));  //Comentarios 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1098, "00");  //Familia Producto y Tipo Solicitud 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1100, "00");  //Tipo Solicitud 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1102, mdlParametros.ctesIndividual);  //Tipo Cuenta 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1103, StringsHelper.Format(dejelEjecutivo.EjeSkipPaymentL, "0"));  //Skip Payment 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1104, StringsHelper.Format(dejelEjecutivo.EjeTablaMCCL, "0000"));  //Indicativo de tabla MCC 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1108, StringsHelper.Format(dejelEjecutivo.EjeLimDisEfecL, "000"));  //Limite de Disposiciones 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1111, dejelEjecutivo.EjeTipoFactS);  //Tipo de Facturacion 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1112, new String(' ', 20));  //***** Campos que no se usan ***** 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1132, dejelEjecutivo.EjeTipoBloqueoI.ToString());  //Tipo de Bloqueo 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1133, mdlParametros.igIndAltaCteOK.ToString());  //Ind. de Alta S016 OK 
							this.DialogoS = slDialogo; 
							break;
					case enuTipoDialogo.tAltaEjecutivoS111 :  //***** Transaccion de Alta Ejecutivo S111 ***** 
							dejelEjecutivo = null; 
							dejelEjecutivo = (clsDatosEjecutivo) objpRepositorio;  //Se le pasa el valor de la Clase clsDatosEjecutivo 
							dejelEjecutivo.EjeCuentaS = (StringsHelper.Format(dejelEjecutivo.EjeProductoPRD.PrefijoL, dejelEjecutivo.EjeProductoPRD.MascaraPrefijoS) + StringsHelper.Format(dejelEjecutivo.EjeProductoPRD.BancoL, dejelEjecutivo.EjeProductoPRD.MascaraBancoS) + StringsHelper.Format(dejelEjecutivo.EjeEmpNumL, dejelEjecutivo.EjeProductoPRD.MascaraEmpresaS) + StringsHelper.Format(dejelEjecutivo.EjeNumL, dejelEjecutivo.EjeProductoPRD.MascaraEjecutivoS) + dejelEjecutivo.EjeRolloverI.ToString().Trim() + dejelEjecutivo.EjeDigitI.ToString().Trim()).Trim(); 
							slDialogo = new String(' ', 1133);  //Variable local que va a tener el Dialogo 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1, "C430");  //Sistema 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 5, mdlParametros.ctesProcesoAltaS111);  //Clave de proceso 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 8, mdlParametros.ctesTipoAlta);  //Clave tipo de alta 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 10, mdlParametros.ctesTipoTramite);  //Clave tipo de trámite 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 12, "00000000");  //Número de Folio 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 20, "000000000000");  //Numero de Nómina 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 32, mdlParametros.ctesTipoTransaccion);  //Transacción 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 36, dejelEjecutivo.EjeCuentaS);  //Cuenta 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 52, dejelEjecutivo.EjeNomGrabaS);  //Nombre 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 78, dejelEjecutivo.EjeSexoS);  //Sexo 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 79, StringsHelper.Format(dejelEjecutivo.EjeDiaCorteI, "00"));  //Dia de Corte 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 81, StringsHelper.Format(dejelEjecutivo.EjeSucTransS, "0000"));  //Sucursal Transmisora 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 85, StringsHelper.Format(dejelEjecutivo.EjeSucPromS, "0000"));  //Sucursal Promotora 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 89, StringsHelper.Format(Conversion.Str(dejelEjecutivo.EjeLimCredL), "000000000"));  //Límite de Crédito 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 98, DateTime.Today.ToString("yyyyMMdd"));  //Fecha Alta 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 106, dejelEjecutivo.EjeOrigenS);  //Origen 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 107, dejelEjecutivo.EjeDomEnvioDMC.DomicilioS);  //Calle y Número 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 142, dejelEjecutivo.EjeDomEnvioDMC.ColoniaS);  //Colonia 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 167, dejelEjecutivo.EjeDomEnvioDMC.PoblacionS);  //Poblacion 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 188, dejelEjecutivo.EjeDomEnvioDMC.EstadoEST.AbreviaturaS);  //Estado 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 192, "00");  //Zona Postal 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 194, StringsHelper.Format(dejelEjecutivo.EjeDomEnvioDMC.CPL, "00000"));  //Codigo Postal 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 199, StringsHelper.Format(dejelEjecutivo.EjeActiSubactiS, "0000"));  //Actividad Subactividad 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 203, StringsHelper.Format(StringsHelper.DoubleValue(((dejelEjecutivo.EjeTelDomS.Trim() == "") ? "0": dejelEjecutivo.EjeTelDomS.Trim()).Trim()).ToString().Substring(StringsHelper.DoubleValue(((dejelEjecutivo.EjeTelDomS.Trim() == "") ? "0": dejelEjecutivo.EjeTelDomS.Trim()).Trim()).ToString().Length - Math.Min(StringsHelper.DoubleValue(((dejelEjecutivo.EjeTelDomS.Trim() == "") ? "0": dejelEjecutivo.EjeTelDomS.Trim()).Trim()).ToString().Length, 7)), "0000000"));  //Telefono Particular 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 210, StringsHelper.Format(StringsHelper.DoubleValue(((dejelEjecutivo.EjeTelOfiS.Trim() == "") ? "0": dejelEjecutivo.EjeTelOfiS.Trim()).Trim()).ToString().Substring(StringsHelper.DoubleValue(((dejelEjecutivo.EjeTelOfiS.Trim() == "") ? "0": dejelEjecutivo.EjeTelOfiS.Trim()).Trim()).ToString().Length - Math.Min(StringsHelper.DoubleValue(((dejelEjecutivo.EjeTelOfiS.Trim() == "") ? "0": dejelEjecutivo.EjeTelOfiS.Trim()).Trim()).ToString().Length, 7)), "0000000"));  //Telefono de Oficina 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 217, StringsHelper.Format(StringsHelper.DoubleValue(((dejelEjecutivo.EjeExtensionS.Trim() == "") ? "0": dejelEjecutivo.EjeExtensionS.Trim()).Trim()).ToString().Substring(StringsHelper.DoubleValue(((dejelEjecutivo.EjeExtensionS.Trim() == "") ? "0": dejelEjecutivo.EjeExtensionS.Trim()).Trim()).ToString().Length - Math.Min(StringsHelper.DoubleValue(((dejelEjecutivo.EjeExtensionS.Trim() == "") ? "0": dejelEjecutivo.EjeExtensionS.Trim()).Trim()).ToString().Length, 4)), "0000"));  //Extension 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 221, new String(' ', 1)); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 222, dejelEjecutivo.EjeRfcRFC.fncConstruyeRfcS(false).Trim());  //RFC 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 235, "000");  //Lada Telefono Casa 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 238, "000");  //Lada Telefono Oficina 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 241, "000");  //Puntos del Scoredcard 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 244, "000");  //Identificador del Scoredcard 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 247, StringsHelper.Format(DateTime.Today.ToString("yyyyMMdd"), "000000"));  //Fecha de Evaluación 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 253, new String(' ', 35)); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 288, new String(' ', 25)); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 313, new String(' ', 25)); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 338, "00000"); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 343, new String(' ', 55)); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 398, "00000000"); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 406, StringsHelper.Format(dejelEjecutivo.EjeGenPinPlaI, "0"));  //Genera Pin Plastico 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 407, "1");  //Identificador de Domicilio 1=casa 2=oficina 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 408, new String(' ', 10));  //Identificador de Linea Aerea 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 418, Strings.Mid(dejelEjecutivo.EjeNomGrabaS, 1, dejelEjecutivo.EjeNomGrabaS.IndexOf(',')));  //Nombre 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 448, Strings.Mid(dejelEjecutivo.EjeNomGrabaS, (dejelEjecutivo.EjeNomGrabaS.IndexOf(',') + 1) + 1, (dejelEjecutivo.EjeNomGrabaS.IndexOf('/') + 1) - (dejelEjecutivo.EjeNomGrabaS.IndexOf(',') + 1) - 1));  //Apellido Paterno 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 478, dejelEjecutivo.EjeNomGrabaS.Substring(dejelEjecutivo.EjeNomGrabaS.Length - Math.Min(dejelEjecutivo.EjeNomGrabaS.Length, Strings.Len(dejelEjecutivo.EjeNomGrabaS) - (dejelEjecutivo.EjeNomGrabaS.IndexOf('/') + 1))));  //Apellido Materno 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 508, "0000");  //Transaccion 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 512, "0000000000000000");  //Numero de Cuenta 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 528, new String(' ', 26));  //Nombre del Solicitante 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 554, new String(' ', 1));  //Sexo 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 555, "00000000");  //Fecha de Nacimiento 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 563, new String(' ', 35));  //Direccion 1 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 598, new String(' ', 25));  //Direccion 2 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 623, new String(' ', 25));  //Direccion 3 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 648, "00");  //Zona Postal 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 650, "00000");  //Codigo Postal 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 655, "0000000");  //Telefono Particular 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 662, "000");  //Lada 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 665, "000000000");  //Credito 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 674, "0");  //Indicador de generacion de plastico 0=normal, 1=urgente 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 675, "0000");  //Region Grupo 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 679, "0000");  //Región en Cadena 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 683, "00000000");  //Número de Negocio 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 691, new String(' ', 40));  //Nombre Razon 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 731, DateTime.Parse(dejelEjecutivo.EjeRfcRFC.DiaI.ToString() + "/" + dejelEjecutivo.EjeRfcRFC.MesI.ToString() + "/" + dejelEjecutivo.EjeRfcRFC.AñoI.ToString()).ToString("yyyyMMdd"));  //Fecha de Nacimiento 
							if (dejelEjecutivo.EjeCuentaReferenciaS == "")
							{
								slDialogo = StringsHelper.MidAssignment(slDialogo, 739, "0000000000000000"); //Tarjeta 1
							} 
							else
							{
								slDialogo = StringsHelper.MidAssignment(slDialogo, 739, StringsHelper.Format(dejelEjecutivo.EjeCuentaReferenciaS, "0000000000000000")); //Tarjeta 1
							} 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 755, "0000000000000000");  //Tarjeta 2 
							if (dejelEjecutivo.EjeNacionalidadS == "")
							{
								slDialogo = StringsHelper.MidAssignment(slDialogo, 771, "00"); //Clave Nacionalidad
							} 
							else
							{
								slDialogo = StringsHelper.MidAssignment(slDialogo, 771, StringsHelper.Format(dejelEjecutivo.EjeNacionalidadS, "00")); //Clave Nacionalidad
							} 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 773, "0000");  //Clave Ocupacion 
							//OJO este campo cambio 
							//Mid$(slDialogo, 777, 10) = "0000000000"                                             'Numero de Nomina 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 777, "0000000000");  //Numero de Nomina 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 787, new String(' ', 3));  //Tipo Operacion 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 790, new String(' ', 55));  //Nombre Largo Adicional 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 845, "00000000");  //Fecha Nacimiento Adicional 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 853, new String(' ', 1));  //Clave Parentesco Adicional 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 854, new String(' ', 38));  //Filler 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 892, new String(' ', 56));  //Info tabla B11 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 948, new String(' ', 150));  //Comentarios 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1098, "00");  //Familia Producto y Tipo Solicitud 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1100, "00");  //Tipo Solicitud 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1102, mdlParametros.ctesIndividual);  //Tipo Cuenta 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1103, StringsHelper.Format(dejelEjecutivo.EjeSkipPaymentL, "0"));  //Skip Payment 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1104, StringsHelper.Format(dejelEjecutivo.EjeTablaMCCL, "0000"));  //Indicativo de tabla MCC 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1108, StringsHelper.Format(dejelEjecutivo.EjeLimDisEfecL, "000"));  //Limite de Disposiciones 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1111, dejelEjecutivo.EjeTipoFactS);  //Tipo de Facturacion 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1112, new String(' ', 20));  //***** Campos que no se usan ***** 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1132, dejelEjecutivo.EjeTipoBloqueoI.ToString());  //Tipo de Bloqueo 
							if (mdlParametros.igIndAltaCteOK != 0)
							{
								slDialogo = StringsHelper.MidAssignment(slDialogo, 1133, mdlParametros.igIndAltaCteOK.ToString()); //Ind. de Alta S016 OK
							} 
							else
							{
								slDialogo = StringsHelper.MidAssignment(slDialogo, 1133, new String(' ', 1));
							} 
							this.DialogoS = slDialogo; 
							break;
					case enuTipoDialogo.tConsEjecutivoS016 :  //***** Transaccion de Consulta S016 ***** 
							dejelEjecutivo = null; 
							dejelEjecutivo = (clsDatosEjecutivo) objpRepositorio;  //Se le pasa el valor de la Clase clsDatosEjecutivo 
							mdlParametros.tgConsultaS016.NumCuentaS = (StringsHelper.Format(dejelEjecutivo.EjeProductoPRD.PrefijoL, dejelEjecutivo.EjeProductoPRD.MascaraPrefijoS) + StringsHelper.Format(dejelEjecutivo.EjeProductoPRD.BancoL, dejelEjecutivo.EjeProductoPRD.MascaraBancoS) + StringsHelper.Format(dejelEjecutivo.EjeEmpNumL, dejelEjecutivo.EjeProductoPRD.MascaraEmpresaS) + StringsHelper.Format(dejelEjecutivo.EjeNumL, dejelEjecutivo.EjeProductoPRD.MascaraEjecutivoS)).Trim() + dejelEjecutivo.EjeRolloverI.ToString() + dejelEjecutivo.EjeDigitI.ToString(); 
							slDialogo = new String(' ', 148); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1, "001644");  //Transacción 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 7, "000000");  //Sistema origen, aplicación origen 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 13, "0016");  //Aplicación 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 17, "44");  //Código 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 19, "000");  //Sub código 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 22, "0000");  //Aplicación 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 26, "00");  //Código 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 28, "000");  //Sub código 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 31, "1");  //Dirección Envio=1, Regreso=2, Envio-Revoca=3, Regreso-Revoca=4 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 32, "1006");  //Longitud 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 36, "00015");  //Tiempo de espera 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 41, "01");  //Código de respuesta Solicitud=1, Respuesta=2, Timeout=3, Entregado=4, Confirma=6, Aceptado=7, Seguridad=8, Error=9 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 43, "000");  //Identificador Msg 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 46, "B");  //Versión 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 47, "0");  //Clase "O=original, 1=repetisión" 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 48, "0");  //Estado "Nonecesario =0, Aplicado=1, Rechazada=2" 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 49, "1");  //Modo "Interectivo=1, Notificacion=2, Certificado=3" 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 50, "0730");  //Origen 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 54, "000");  //Código Origen 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 57, "00000005");  // Número 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 65, "020515");  //Fecha 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 71, "171250");  //Hora 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 77, "22");  //Modalidad 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 79, "0000000000");  //Operador 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 89, "A");  // Versión Mensaje 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 90, "FDC001");  //Transacción 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 96, "0");  //Opción 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 97, "3");  //Sub Opción (Medio de Acceso) 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 98, "00");  //Versión 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 100, "0000");  //Error Código 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 104, "0000");  //Error SubCódigo 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 108, "0000");  //Error SubSubCódigo 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 112, "000000000000");  //Numero de Cliente 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 124, "0111");  //Producto 
							if (mdlParametros.gprdProducto.PrefijoL != 4943 && mdlParametros.gprdProducto.BancoL != 88)
							{
								slDialogo = StringsHelper.MidAssignment(slDialogo, 128, "0005"); //Instrumento
							} 
							else
							{
								slDialogo = StringsHelper.MidAssignment(slDialogo, 128, "0025"); //Instrumento
							} 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 132, StringsHelper.Format(mdlParametros.tgConsultaS016.NumCuentaS, "0000000000000000"));  //Cuenta 
							this.DialogoS = slDialogo; 
							break;
					case enuTipoDialogo.tConsEjecutivoS111 :  //***** Transaccion de Consulta S111 ***** 
							dejelEjecutivo = null; 
							dejelEjecutivo = (clsDatosEjecutivo) objpRepositorio;  //Se le pasa el valor de la Clase clsDatosEjecutivo 
							dejelEjecutivo.EjeCuentaS = (StringsHelper.Format(dejelEjecutivo.EjeProductoPRD.PrefijoL, dejelEjecutivo.EjeProductoPRD.MascaraPrefijoS) + StringsHelper.Format(dejelEjecutivo.EjeProductoPRD.BancoL, dejelEjecutivo.EjeProductoPRD.MascaraBancoS) + StringsHelper.Format(dejelEjecutivo.EjeEmpNumL, dejelEjecutivo.EjeProductoPRD.MascaraEmpresaS) + StringsHelper.Format(dejelEjecutivo.EjeNumL, dejelEjecutivo.EjeProductoPRD.MascaraEjecutivoS) + dejelEjecutivo.EjeRolloverI.ToString().Trim() + dejelEjecutivo.EjeDigitI.ToString().Trim()).Trim(); 
							slDialogo = new String(' ', 51); 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1, "C430");  //Sistema 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 5, mdlParametros.ctesProcesoConsulta);  //Clave de Proceso 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 8, "00");  //Clave Tipo de Alta 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 10, mdlParametros.ctesTipoTramite);  //Clave Tipo de Tramite 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 12, StringsHelper.Format(dejelEjecutivo.EjeNumNomS, "00000000"));  //Numero de Folio 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 20, "000000000000");  //Numero de Nomina 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 32, mdlParametros.ctesTransaccionConsulta);  //Transaccion 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 36, dejelEjecutivo.EjeCuentaS);  //Cuenta 
							this.DialogoS = slDialogo; 
							break;
					case enuTipoDialogo.tCambioNombreEjeS111 :  //***** Transaccion de Cambio Nombre Ejecutivo S111 ***** 
							//Dialogo para cambiar el Nombre del Ejecutivo 
							break;
					case enuTipoDialogo.tCambioCreditoEjeS111 :  //***** Transaccion de Cambio Credito Ejecutivo S111 ***** 
							//Dialogo para cambiar el Credito del Ejecutivo 
							break;
					case enuTipoDialogo.tCambioEmpresaMasivosS111 :  //***** Transaccion de Cambio Masivo Empresa S111 ***** 
							//Dialogo para cambios masivos 
							break;
					case enuTipoDialogo.tCambioMCCEmpresaS111 :  //***** Transaccion de Cambio de MCC S111 ***** 
							this.mIdTransaccionS = "5368"; 
							this.mNumCuentaS = StringsHelper.Format(mdlParametros.tgCambioS111.NumCuentaS, "0000000000000000");  //Numero de Cuenta 
							slDialogo = slDialogo + "M ";  //Subtransaccion 
							slDialogo = slDialogo + mdlParametros.tgCambioS111.MccL.ToString();  //Subtransaccion2 
							this.DialogoS = slDialogo; 
							break;
					case enuTipoDialogo.tCambioSkipEmpresaS111 :  //***** Transaccion de Cambio de Skip Payment Ejecutivo S111 ***** 
							//slDialogo = "D" 
							this.mIdTransaccionS = "5368"; 
							this.mNumCuentaS = StringsHelper.Format(mdlParametros.tgCambioS111.NumCuentaS, "0000000000000000");  //Numero de Cuenta 
							slDialogo = slDialogo + "S ";  //Subtransaccion 
							slDialogo = slDialogo + mdlParametros.tgCambioS111.SkipPaymentI.ToString();  //Subtransaccion2 
							this.DialogoS = slDialogo; 
							break;
					case enuTipoDialogo.tCambioMCCEjecutivoS111 :  //***** Transaccion de Cambio de MCC S111 ***** 
							this.mIdTransaccionS = "5368 ";  //Transaccion 
							this.mNumCuentaS = StringsHelper.Format(mdlParametros.tgCambioS111.NumCuentaS, "0000000000000000");  //Numero de Cuenta 
							slDialogo = slDialogo + "M ";  //Subtransaccion 
							slDialogo = slDialogo + mdlParametros.tgCambioS111.MccL.ToString();  //Subtransaccion2 
							this.DialogoS = slDialogo; 
							break;
					case enuTipoDialogo.tCambioSkipEjecutivoS111 :  //***** Transaccion de Cambio de Skip Payment Ejecutivo S111 ***** 
							this.mIdTransaccionS = "5368 "; 
							this.mNumCuentaS = StringsHelper.Format(mdlParametros.tgCambioS111.NumCuentaS, "0000000000000000");  //Numero de Cuenta 
							slDialogo = slDialogo + "S ";  //Subtransaccion 
							slDialogo = slDialogo + mdlParametros.tgCambioS111.SkipPaymentI.ToString();  //Subtransaccion2 
							slDialogo = slDialogo + Strings.Chr(3).ToString(); 
							this.DialogoS = slDialogo; 
							break;
					case enuTipoDialogo.tCambioDispEjecutivoS111 :  //***** Transaccion de Cambio de Disponible Ejecutivo S111 ***** 
							this.mIdTransaccionS = "5368"; 
							this.mNumCuentaS = StringsHelper.Format(mdlParametros.tgCambioS111.NumCuentaS, "0000000000000000");  //Numero de Cuenta 
							slDialogo = "D ";  //Subtransaccion 
							slDialogo = slDialogo + mdlParametros.tgCambioS111.PorcentajeDispI.ToString();  //Subtransaccion2 
							this.DialogoS = slDialogo; 
							break;
					case enuTipoDialogo.tCambioGenPinPlaEjecutivoS111 :  //***** Transaccion de Gen. Pin Pla Ejecutivo S111 ***** 
							this.mIdTransaccionS = "5368"; 
							this.mNumCuentaS = StringsHelper.Format(mdlParametros.tgCambioS111.NumCuentaS, "0000000000000000");  //Numero de Cuenta 
							slDialogo = slDialogo + "P ";  //Subtransaccion 
							slDialogo = slDialogo + mdlParametros.tgCambioS111.PinPlaI.ToString();  //Subtransaccion2 
							slDialogo = slDialogo + Strings.Chr(3).ToString(); 
							this.DialogoS = slDialogo; 
							break;
					case enuTipoDialogo.tCambioTipoBloqueoEjecutivoS111 :  //***** Transaccion de Tipo Bloqueo Ejecutivo S111 ***** 
							this.mIdTransaccionS = "5368"; 
							this.mNumCuentaS = StringsHelper.Format(mdlParametros.tgCambioS111.NumCuentaS, "0000000000000000");  //Numero de Cuenta 
							slDialogo = slDialogo + "Q ";  //Subtransaccion 
							slDialogo = slDialogo + mdlParametros.tgCambioS111.BloqueoI.ToString();  //Subtransaccion2 
							this.DialogoS = slDialogo; 
							break;
					case enuTipoDialogo.tCambioLimCredEjecutivos : 
							this.mIdTransaccionS = mdlParametros.ctesModificaCreditoEje; 
							this.mNumCuentaS = mdlParametros.tgCambioLimCred.CtaBnxS;  //Cuenta 
							slDialogo = slDialogo + Conversion.Str(mdlParametros.tgCambioLimCred.LimCredL);  //Limite de Credito 
							this.DialogoS = slDialogo; 
							break;
							// APQ 1-Julio-2010 Inicio - Cambio Tipo de Bloqueo
					case enuTipoDialogo.tCambioTipBloqEmpresaS111:  //***** Transaccion de Tipo Bloqueo Empresa S111 ***** 
							this.mIdTransaccionS = "5368";
							this.mNumCuentaS = StringsHelper.Format(mdlParametros.tgCambioS111.NumCuentaS, "0000000000000000");  //Numero de Cuenta 
							slDialogo = slDialogo + "Q ";  //Subtransaccion 
							slDialogo = slDialogo + mdlParametros.tgCambioS111.BloqueoI.ToString();  //Subtransaccion2 
							this.DialogoS = slDialogo;
							break;
							// APQ 1-Julio-2010 Fin - Cambio Tipo de Bloqueo
					case enuTipoDialogo.tAltaEjecutivosComdrv:  //***** Transaccion de Alta comdrv ***** 
							string TelPar = String.Empty;
							string TelOfi = String.Empty;
							dejelEjecutivo = null;
							dejelEjecutivo = (clsDatosEjecutivo)objpRepositorio;  //Se le pasa el valor de la Clase clsDatosEjecutivo 
							dejelEjecutivo.EjeCuentaS = (StringsHelper.Format(dejelEjecutivo.EjeProductoPRD.PrefijoL, dejelEjecutivo.EjeProductoPRD.MascaraPrefijoS) + StringsHelper.Format(dejelEjecutivo.EjeProductoPRD.BancoL, dejelEjecutivo.EjeProductoPRD.MascaraBancoS) + StringsHelper.Format(dejelEjecutivo.EjeEmpNumL, dejelEjecutivo.EjeProductoPRD.MascaraEmpresaS) + StringsHelper.Format(dejelEjecutivo.EjeNumL, dejelEjecutivo.EjeProductoPRD.MascaraEjecutivoS) + dejelEjecutivo.EjeRolloverI.ToString().Trim() + dejelEjecutivo.EjeDigitI.ToString().Trim()).Trim();
							TelPar = StringsHelper.Format(StringsHelper.DoubleValue(((dejelEjecutivo.EjeTelDomS.Trim() == "") ? "0" : dejelEjecutivo.EjeTelDomS.Trim()).Trim()).ToString().Substring(StringsHelper.DoubleValue(((dejelEjecutivo.EjeTelDomS.Trim() == "") ? "0" : dejelEjecutivo.EjeTelDomS.Trim()).Trim()).ToString().Length - Math.Min(StringsHelper.DoubleValue(((dejelEjecutivo.EjeTelDomS.Trim() == "") ? "0" : dejelEjecutivo.EjeTelDomS.Trim()).Trim()).ToString().Length, 10)), "0000000000");
							TelOfi = StringsHelper.Format(StringsHelper.DoubleValue(((dejelEjecutivo.EjeTelOfiS.Trim() == "") ? "0" : dejelEjecutivo.EjeTelOfiS.Trim()).Trim()).ToString().Substring(StringsHelper.DoubleValue(((dejelEjecutivo.EjeTelOfiS.Trim() == "") ? "0" : dejelEjecutivo.EjeTelOfiS.Trim()).Trim()).ToString().Length - Math.Min(StringsHelper.DoubleValue(((dejelEjecutivo.EjeTelOfiS.Trim() == "") ? "0" : dejelEjecutivo.EjeTelOfiS.Trim()).Trim()).ToString().Length, 10)), "0000000000");  //Telefono de Oficina 
							string ladaP = TelPar.Substring(0, 3);
							string telefonoP = TelPar.Substring(3, 7);
							string ladaO = TelOfi.Substring(0, 3);
							string telefonoO = TelOfi.Substring(3, 7);
							string sfechaN = Strings.Mid(dejelEjecutivo.EjeRfcRFC.RFCS, 5, 6);
							short iAnio = StringsHelper.ShortValue(sfechaN.Substring(0, 2));
							if ((iAnio >= 0) && (iAnio <= 30))
							{
								sfechaN = "20" + sfechaN;
							}
							else
							{
								sfechaN = "19" + sfechaN;
							}

							slDialogo = new String(' ', 1197);  //Variable local que va a tener el Dialogo 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1, "5566");  //Sistema 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 5, " ");     //Clave de proceso 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 6, "01");     //Subtransaccion
							slDialogo = StringsHelper.MidAssignment(slDialogo, 8, "0000000000000000");
							slDialogo = StringsHelper.MidAssignment(slDialogo, 24, "00000000");  //Número de Folio 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 32, "C430");//Sistema
							slDialogo = StringsHelper.MidAssignment(slDialogo, 36, mdlParametros.ctesTipoTramite);  //Clave tipo de trámite 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 38, "00");     ////Familia Producto
							slDialogo = StringsHelper.MidAssignment(slDialogo, 40, "00");     ////Tipo de Solicitud
							slDialogo = StringsHelper.MidAssignment(slDialogo, 42, "000");//Status (de la solicitud)
							slDialogo = StringsHelper.MidAssignment(slDialogo, 45, "00");//Resultado de la transacción
							slDialogo = StringsHelper.MidAssignment(slDialogo, 47, new String(' ', 50));//Resultado de la transacción
							slDialogo = StringsHelper.MidAssignment(slDialogo, 97, new String(' ', 10));//Ejecutivo
							//slDialogo = StringsHelper.MidAssignment(slDialogo, 97, "0001622528");//Ejecutivo
							slDialogo = StringsHelper.MidAssignment(slDialogo, 107, StringsHelper.Format(mdlParametros.ctesTipoAlta.ToString(),"000")); //se pidio cambiar a  "000" Clave tipo de alta
							//slDialogo = StringsHelper.MidAssignment(slDialogo, 107, "001");  //Clave tipo de alta 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 110, "0");//Flag Informativo
							slDialogo = StringsHelper.MidAssignment(slDialogo, 111, "0");//Indicador Control de Cambios
							slDialogo = StringsHelper.MidAssignment(slDialogo, 112, "00");//Numero de pantalla
							slDialogo = StringsHelper.MidAssignment(slDialogo, 114, "                                                               ");//filler
							//Datos
							//Seguridad.usugUsuario.NominaS
							slDialogo = StringsHelper.MidAssignment(slDialogo, 177, "000000000000");  //se solicito enviar ceros 18/12/2013 IRP Numero de Nómina 
							//slDialogo = StringsHelper.MidAssignment(slDialogo, 177,StringsHelper.Format(Seguridad.usugUsuario.NominaS, "000000000000"));  //Numero de Nómina 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 189, dejelEjecutivo.EjeNomGrabaS);//Nombre
							//slDialogo = StringsHelper.MidAssignment(slDialogo, 215, dejelEjecutivo.EjeNom);//npombre 
							//slDialogo = StringsHelper.MidAssignment(slDialogo, 265, dejelEjecutivo.EjeApePat);// paterno 
							//slDialogo = StringsHelper.MidAssignment(slDialogo, 325, dejelEjecutivo.EjeApeMat);//materno
							//slDialogo = StringsHelper.MidAssignment(slDialogo, 385, dejelEjecutivo.EjeFechaNac);//fecha de nacimiento
							slDialogo = StringsHelper.MidAssignment(slDialogo, 215, Strings.Mid(dejelEjecutivo.EjeNomGrabaS, 1, dejelEjecutivo.EjeNomGrabaS.IndexOf(','))); //nombre 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 265, Strings.Mid(dejelEjecutivo.EjeNomGrabaS, (dejelEjecutivo.EjeNomGrabaS.IndexOf(',') + 1) + 1, (dejelEjecutivo.EjeNomGrabaS.IndexOf('/') + 1) - (dejelEjecutivo.EjeNomGrabaS.IndexOf(',') + 1) - 1)); // paterno 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 325, dejelEjecutivo.EjeNomGrabaS.Substring(dejelEjecutivo.EjeNomGrabaS.Length - Math.Min(dejelEjecutivo.EjeNomGrabaS.Length, Strings.Len(dejelEjecutivo.EjeNomGrabaS) - (dejelEjecutivo.EjeNomGrabaS.IndexOf('/') + 1)))); //materno
							slDialogo = StringsHelper.MidAssignment(slDialogo, 385, sfechaN.Trim());//fecha de nacimiento
							slDialogo = StringsHelper.MidAssignment(slDialogo, 393, dejelEjecutivo.EjeRfcRFC.fncConstruyeRfcS(false).Trim());  //RFC
							slDialogo = StringsHelper.MidAssignment(slDialogo, 406, dejelEjecutivo.EjeSexoS);  //Sexo 
							//if (dejelEjecutivo.EjeNacionalidad.ToString() == "1")  //PAIS NACIONALIDAD()
							//{
							//    slDialogo = StringsHelper.MidAssignment(slDialogo, 407, "01"); //Nacionalidad
							//}
							//else {
							//    slDialogo = StringsHelper.MidAssignment(slDialogo, 407, "02"); //Nacionalidad                            
							//}
							if (dejelEjecutivo.EjeNacionalidadS == "")  //PAIS NACIONALIDAD()
							{
								slDialogo = StringsHelper.MidAssignment(slDialogo, 407, "00"); //Nacionalidad
							}
							else
							{
								slDialogo = StringsHelper.MidAssignment(slDialogo, 407, StringsHelper.Format(dejelEjecutivo.EjeNacionalidadS, "00")); //Nacionalidad                            
							}
							slDialogo = StringsHelper.MidAssignment(slDialogo, 409, "0000");  //Clave Ocupacion 
							//slDialogo = StringsHelper.MidAssignment(slDialogo, 413, "0000");  //Actividad Subactividad 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 413, StringsHelper.Format(dejelEjecutivo.EjeActiSubactiS, "0000"));  //Actividad Subactividad 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 417, "1");  //Identificador de Domicilio 1=casa 2=oficina 
							//slDialogo = StringsHelper.MidAssignment(slDialogo, 417, "2");  //Identificador de Domicilio 1=casa 2=oficina prueba jorge muñoz
					// Cambios que se realizan en las direcciones que estan invertidas Particular por Envio 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 418, dejelEjecutivo.EjeDomEnvioDMC.DomicilioS);  //Calle y Número //Cambia por la calle del domicilio 2// Jun 6,2016 cambio por direcciones invertidas APH
							//slDialogo = StringsHelper.MidAssignment(slDialogo, 418, dejelEjecutivo.EjeDomPartDMC.DomicilioS);  //Calle y Número 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 453, dejelEjecutivo.EjeDomEnvioDMC.ColoniaS);  //Colonia //Cambia por la colonia del domicilio 2// Jun 6,2016 cambio por direcciones invertidas APH
							//slDialogo = StringsHelper.MidAssignment(slDialogo, 453, dejelEjecutivo.EjeDomPartDMC.ColoniaS);  //Colonia 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 478, dejelEjecutivo.EjeDomEnvioDMC.PoblacionS);  //Poblacion  //Cambia por la ciudad del domicilio 2// Jun 6,2016 cambio por direcciones invertidas APH
							//slDialogo = StringsHelper.MidAssignment(slDialogo, 478, dejelEjecutivo.EjeDomPartDMC.PoblacionS);  //Poblacion 
							//slDialogo = StringsHelper.MidAssignment(slDialogo, 499, dejelEjecutivo.EjeDomEnvioDMC.EstadoEST.AbreviaturaS);  //Estado 
							//slDialogo = StringsHelper.MidAssignment(slDialogo, 499, "01");  //Estado 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 499, StringsHelper.Format(dejelEjecutivo.EjeDomEnvioDMC.EstadoEST.CodigoI,"00"));  //Estado //Cambia por la ciudad del estado 2//  Jun 6,2016 cambio por direcciones invertidas APH
							//slDialogo = StringsHelper.MidAssignment(slDialogo, 499, StringsHelper.Format(dejelEjecutivo.EjeDomPartDMC.EstadoEST.CodigoI, "00"));  //Estado 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 501, "00");  //Zona Postal 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 503, StringsHelper.Format(dejelEjecutivo.EjeDomEnvioDMC.CPL, "00000"));  //Codigo Postal//Cambia por el cp del estado 2//  Jun 6,2016 cambio por direcciones invertidas APH
							//slDialogo = StringsHelper.MidAssignment(slDialogo, 503, StringsHelper.Format(dejelEjecutivo.EjeDomPartDMC.CPL, "00000"));  //Codigo Postal 
							//slDialogo = StringsHelper.MidAssignment(slDialogo, 508, "000");  //Lada Telefono Casa
							slDialogo = StringsHelper.MidAssignment(slDialogo, 508, ladaP);
							//slDialogo = StringsHelper.MidAssignment(slDialogo, 511, "0000000");  //Telefono Particular
							//slDialogo = StringsHelper.MidAssignment(slDialogo, 511, StringsHelper.Format(StringsHelper.DoubleValue(((dejelEjecutivo.EjeTelDomS.Trim() == "") ? "0" : dejelEjecutivo.EjeTelDomS.Trim()).Trim()).ToString().Substring(StringsHelper.DoubleValue(((dejelEjecutivo.EjeTelDomS.Trim() == "") ? "0" : dejelEjecutivo.EjeTelDomS.Trim()).Trim()).ToString().Length - Math.Min(StringsHelper.DoubleValue(((dejelEjecutivo.EjeTelDomS.Trim() == "") ? "0" : dejelEjecutivo.EjeTelDomS.Trim()).Trim()).ToString().Length, 7)), "0000000"));  //Telefono de Oficina 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 511, telefonoP);  //Telefono de Oficina 
							//slDialogo = StringsHelper.MidAssignment(slDialogo, 518, "000");  //Lada Telefono Oficina
							slDialogo = StringsHelper.MidAssignment(slDialogo, 518, ladaO);  //Lada Telefono Oficina
							//slDialogo = StringsHelper.MidAssignment(slDialogo, 521, StringsHelper.Format(StringsHelper.DoubleValue(((dejelEjecutivo.EjeTelOfiS.Trim() == "") ? "0" : dejelEjecutivo.EjeTelOfiS.Trim()).Trim()).ToString().Substring(StringsHelper.DoubleValue(((dejelEjecutivo.EjeTelOfiS.Trim() == "") ? "0" : dejelEjecutivo.EjeTelOfiS.Trim()).Trim()).ToString().Length - Math.Min(StringsHelper.DoubleValue(((dejelEjecutivo.EjeTelOfiS.Trim() == "") ? "0" : dejelEjecutivo.EjeTelOfiS.Trim()).Trim()).ToString().Length, 7)), "0000000"));  //Telefono de Oficina 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 521, telefonoO);
							slDialogo = StringsHelper.MidAssignment(slDialogo, 528, StringsHelper.Format(StringsHelper.DoubleValue(((dejelEjecutivo.EjeExtensionS.Trim() == "") ? "0" : dejelEjecutivo.EjeExtensionS.Trim()).Trim()).ToString().Substring(StringsHelper.DoubleValue(((dejelEjecutivo.EjeExtensionS.Trim() == "") ? "0" : dejelEjecutivo.EjeExtensionS.Trim()).Trim()).ToString().Length - Math.Min(StringsHelper.DoubleValue(((dejelEjecutivo.EjeExtensionS.Trim() == "") ? "0" : dejelEjecutivo.EjeExtensionS.Trim()).Trim()).ToString().Length, 5)), "00000"));  //Extension 
					// Cambios que se realizan en las direcciones que estan invertidas Particular por Envio 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 533, dejelEjecutivo.EjeDomPartDMC.DomicilioS);//new String(' ', 35));  //Direccion 1 //Calle Num2 // Jun 6,2016 cambio por direcciones invertidas APH
							//slDialogo = StringsHelper.MidAssignment(slDialogo, 533, dejelEjecutivo.EjeDomEnvioDMC.DomicilioS);    
							slDialogo = StringsHelper.MidAssignment(slDialogo, 568, dejelEjecutivo.EjeDomPartDMC.ColoniaS);//new String(' ', 25));  //Direccion 2  // Jun 6,2016 cambio por direcciones invertidas APH
							//slDialogo = StringsHelper.MidAssignment(slDialogo, 568, dejelEjecutivo.EjeDomEnvioDMC.ColoniaS);
							//ver si va o no slDialogo = StringsHelper.MidAssignment(slDialogo, 593, new String(' ', 25));  //Direccion 3 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 593, dejelEjecutivo.EjeDomPartDMC.PoblacionS);//new String(' ', 21));  //CIUDAD-2   // Jun 6,2016 cambio por direcciones invertidas APH
							//slDialogo = StringsHelper.MidAssignment(slDialogo, 593, dejelEjecutivo.EjeDomEnvioDMC.PoblacionS);
							slDialogo = StringsHelper.MidAssignment(slDialogo, 614, StringsHelper.Format(dejelEjecutivo.EjeDomPartDMC.EstadoEST.CodigoI,"00"));//"00");  //ESTADO-2 // Jun 6,2016 cambio por direcciones invertidas APH
							//slDialogo = StringsHelper.MidAssignment(slDialogo, 614, StringsHelper.Format(dejelEjecutivo.EjeDomEnvioDMC.EstadoEST.CodigoI, "00"));
							slDialogo = StringsHelper.MidAssignment(slDialogo, 616, StringsHelper.Format(dejelEjecutivo.EjeDomPartDMC.CPL, "00000")); // Jun 6,2016 cambio por direcciones invertidas APH
							//slDialogo = StringsHelper.MidAssignment(slDialogo, 616, StringsHelper.Format(dejelEjecutivo.EjeDomEnvioDMC.CPL,"00000"));//"00000");  //COD-POSTAL-2
							//slDialogo = StringsHelper.MidAssignment(slDialogo, 621, StringsHelper.Format(dejelEjecutivo.EjeSucTransS, "0000"));  //Sucursal Transmisora 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 621, StringsHelper.Format(dejelEjecutivo.EjeSucTransS, "0000"));  //Sucursal Transmisora 
							//slDialogo = StringsHelper.MidAssignment(slDialogo, 621, StringsHelper.Format(dejelEjecutivo.EjeSucTransS, "3874"));  //Sucursal Transmisora 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 625, StringsHelper.Format(dejelEjecutivo.EjeSucPromS, "0000"));  //Sucursal Promotora 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 629, dejelEjecutivo.EjeOrigenS);  //Origen  
							slDialogo = StringsHelper.MidAssignment(slDialogo, 630, dejelEjecutivo.EjeCuentaS);  //Cuenta 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 646, StringsHelper.Format(Conversion.Str(dejelEjecutivo.EjeLimCredL), "000000000"));  //Límite de Crédito 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 655, "000");  //Puntos del Scoredcard 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 658, "000");  //Identificador del Scoredcard 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 661, "000000");  //FEC-EVAL-SCORECARD 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 667, "0");  //Indicador de generacion de plastico 0=normal, 1=urgente 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 668, StringsHelper.Format(dejelEjecutivo.EjeLimDisEfecL, "000"));  //Limite de Disposiciones 
							if (dejelEjecutivo.EjeCuentaReferenciaS == "")
							{
								slDialogo = StringsHelper.MidAssignment(slDialogo, 671, "0000000000000000"); //Tarjeta 1
							}
							else
							{
								slDialogo = StringsHelper.MidAssignment(slDialogo, 671, StringsHelper.Format(dejelEjecutivo.EjeCuentaReferenciaS, "0000000000000000")); //Tarjeta 1
							}
							slDialogo = StringsHelper.MidAssignment(slDialogo, 687, "0000000000000000");  //Tarjeta 2 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 703, new String(' ', 1)); //-BAS-CATEGORIA 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 704, new String(' ', 3));  //Tipo Operacion 
							//Cambia para que ahora si es per F. Act Emp = "A" de no ser asi "I"//se solicita cambiar para que mande una "I" 11/11/13
							//slDialogo = StringsHelper.MidAssignment(slDialogo, 707, "E");  //BAS-CVE-OPCION  
							//Se  solicita cambiar esta validacion para que en caso de ser persona moral ponga una "E" 19/02/2014
							//Resultado del cambio
							//Fisica = "I"
							//F. Act. Emp. = "A"
							//Moral = "E"
							if (dejelEjecutivo.EjePersona.Equals(3))
							{
								slDialogo = StringsHelper.MidAssignment(slDialogo, 707, "A");
							}
							else if (dejelEjecutivo.EjePersona.Equals(2))
							{
								slDialogo = StringsHelper.MidAssignment(slDialogo, 707, mdlParametros.ctesIndividual);//Cambia para que ahora si es per F. Act Emp = "A" de no ser asi "I"//se solicita cambiar para uqe mande una "I" 11/11/13
							}
							else if (dejelEjecutivo.EjePersona.Equals(1))
							{
								slDialogo = StringsHelper.MidAssignment(slDialogo, 707, "E");
							}
							slDialogo = StringsHelper.MidAssignment(slDialogo, 708, StringsHelper.Format(dejelEjecutivo.EjeSkipPaymentL, "0"));  //Skip Payment 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 709, StringsHelper.Format(dejelEjecutivo.EjeTablaMCCL, "0000"));  //Indicativo de tabla MCC 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 713, dejelEjecutivo.EjeTipoFactS);  //Tipo de Facturacion 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 714, new String(' ', 10));  //Identificador de Linea Aerea 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 724, new String(' ', 55));  //Nombre Largo Adicional 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 779, "00000000");  //Fecha Nacimiento Adicional
							slDialogo = StringsHelper.MidAssignment(slDialogo, 787, StringsHelper.Format(dejelEjecutivo.EjeDiaCorteI, "00"));  //Día de Corte 
							if (mdlParametros.igIndAltaCteOK == 0)
							{
								slDialogo = StringsHelper.MidAssignment(slDialogo, 789, "0"); //IND-CTES-OK
							}
							else if (mdlParametros.igIndAltaCteOK == 1)
							{
								slDialogo = StringsHelper.MidAssignment(slDialogo, 789, "1"); //IND-CTES-OK
							}
							slDialogo = StringsHelper.MidAssignment(slDialogo, 790, dejelEjecutivo.EjeTipoBloqueoI.ToString());  //Tipo de Bloqueo 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 791, new String(' ', 46));  //Filler 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 837, DateTime.Today.ToString("yyyyMMdd"));  //Fecha Alta 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 845, "000000"); //-PROC-HH-HORA-INICIAL   
							slDialogo = StringsHelper.MidAssignment(slDialogo, 851, "00000000"); //PROC-FEC-FINAL    
							slDialogo = StringsHelper.MidAssignment(slDialogo, 859, "000000"); //PROC-HH-HORA-FINAL
							slDialogo = StringsHelper.MidAssignment(slDialogo, 865, "0000"); //PROC-CVE-CAUSA-RECHAZO 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 869, new String(' ', 150)); //WKS-PROC-COMENTARIOS 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1019, "0000000000000000");  //Numero de Cuenta 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1035, new String(' ', 30));  //TR01-NOMBRE-EMPRESA 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1065, "0000");  //PAIS NACIONALIDAD
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1069, "0000");  //PAIS NACIMIENTO
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1073, new String(' ', 20));  //FIEL  
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1093, new String(' ', 18));//CURP
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1111, new String(' ', 78));  //mail 
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1189, "000000");//giro
							slDialogo = StringsHelper.MidAssignment(slDialogo, 1195, "00"); //Endidad de nacimiento
							slDialogo = slDialogo.Replace("Ñ", "@");
							slDialogo.Replace("ñ", "@");
							slDialogo = EliminaAcentos(slDialogo);

                            //LMHR & CMET: Se agrega funcionalidad para completar la cadena segun la definicion del layout
                            slDialogo = CRSDialogo.ComplementaDialogo(slDialogo);

							this.DialogoS = slDialogo;
							//CAMBIAR Ñ POR @ Y ELIMINAR ACENTOS ISRAEL RAMIREZ 07/02/2014
							break;
                    /*case enuTipoDialogo.tAltaEjecutivosComdrv:  //LMHR & CMET:  Transaccion de Alta comdrv nuevo Layout 5566-01 
                            string TelPar = String.Empty;
							string TelOfi = String.Empty;
							dejelEjecutivo = null;
							dejelEjecutivo = (clsDatosEjecutivo)objpRepositorio;  //Se le pasa el valor de la Clase clsDatosEjecutivo 
							dejelEjecutivo.EjeCuentaS = (StringsHelper.Format(dejelEjecutivo.EjeProductoPRD.PrefijoL, dejelEjecutivo.EjeProductoPRD.MascaraPrefijoS) + StringsHelper.Format(dejelEjecutivo.EjeProductoPRD.BancoL, dejelEjecutivo.EjeProductoPRD.MascaraBancoS) + StringsHelper.Format(dejelEjecutivo.EjeEmpNumL, dejelEjecutivo.EjeProductoPRD.MascaraEmpresaS) + StringsHelper.Format(dejelEjecutivo.EjeNumL, dejelEjecutivo.EjeProductoPRD.MascaraEjecutivoS) + dejelEjecutivo.EjeRolloverI.ToString().Trim() + dejelEjecutivo.EjeDigitI.ToString().Trim()).Trim();
							TelPar = StringsHelper.Format(StringsHelper.DoubleValue(((dejelEjecutivo.EjeTelDomS.Trim() == "") ? "0" : dejelEjecutivo.EjeTelDomS.Trim()).Trim()).ToString().Substring(StringsHelper.DoubleValue(((dejelEjecutivo.EjeTelDomS.Trim() == "") ? "0" : dejelEjecutivo.EjeTelDomS.Trim()).Trim()).ToString().Length - Math.Min(StringsHelper.DoubleValue(((dejelEjecutivo.EjeTelDomS.Trim() == "") ? "0" : dejelEjecutivo.EjeTelDomS.Trim()).Trim()).ToString().Length, 10)), "0000000000");
							TelOfi = StringsHelper.Format(StringsHelper.DoubleValue(((dejelEjecutivo.EjeTelOfiS.Trim() == "") ? "0" : dejelEjecutivo.EjeTelOfiS.Trim()).Trim()).ToString().Substring(StringsHelper.DoubleValue(((dejelEjecutivo.EjeTelOfiS.Trim() == "") ? "0" : dejelEjecutivo.EjeTelOfiS.Trim()).Trim()).ToString().Length - Math.Min(StringsHelper.DoubleValue(((dejelEjecutivo.EjeTelOfiS.Trim() == "") ? "0" : dejelEjecutivo.EjeTelOfiS.Trim()).Trim()).ToString().Length, 10)), "0000000000");  //Telefono de Oficina 
							string ladaP = TelPar.Substring(0, 3);
							string telefonoP = TelPar.Substring(3, 7);
							string ladaO = TelOfi.Substring(0, 3);
							string telefonoO = TelOfi.Substring(3, 7);
							string sfechaN = Strings.Mid(dejelEjecutivo.EjeRfcRFC.RFCS, 5, 6);
							short iAnio = StringsHelper.ShortValue(sfechaN.Substring(0, 2));
							if ((iAnio >= 0) && (iAnio <= 30))
							{
								sfechaN = "20" + sfechaN;
							}
							else
							{
								sfechaN = "19" + sfechaN;
							}

                                System.Text.StringBuilder sb = new System.Text.StringBuilder("5566 ");
                                string sDate, sTime;

                                #region  Header
                                sb.Append(CRSDialogo.fnArmaCadena("1", '0', 2, FillDirection.Izquierda)); //Id Transaccion
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, '0', 16));//Numero de Folio Preimpreso
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, '0', 8));//Numero de Folio
                                sb.Append(CRSDialogo.fnArmaCadena(CRSDialogo.cteC430.ToUpper(), ' ', 4));  //Sistema (C430)
                                sb.Append(CRSDialogo.fnArmaCadena(mdlParametros.ctesTipoTramite, '0', 2, FillDirection.Izquierda)); //Clave tipo de trámite 
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, '0', 2));//Familia Producto
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, '0', 2));//Tipo de Solicitud
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, '0', 3));//Status (de la solicitud)
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, '0', 2));//Resultado de la transacción
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, ' ', 45));//Descripcion del resultado
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, '0', 5));//Codigo de error
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, ' ', 10));//Ejecutivo
                                sb.Append(CRSDialogo.fnArmaCadena(mdlParametros.ctesTipoAlta.ToString(), '0', 3, FillDirection.Izquierda));//Clave de Proceso
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, '0', 1));//Flag Informativo
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, '0', 1));//Indicador Control Cambio
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, '0', 2));//Numero de pantalla
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, ' ', 63));//Filler
                                #endregion

                                //Datos
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, '0', 12)); //Numero de  Cliente 

                                #region Datos Personales
                                sb.Append(CRSDialogo.fnArmaCadena(dejelEjecutivo.EjeNomGrabaS, ' ', 26));//Nombre Codificado corte
                                sb.Append(CRSDialogo.fnArmaCadena(Strings.Mid(dejelEjecutivo.EjeNomGrabaS, 1, dejelEjecutivo.EjeNomGrabaS.IndexOf(',')), ' ', 50));//Nombre 
                                sb.Append(CRSDialogo.fnArmaCadena(Strings.Mid(dejelEjecutivo.EjeNomGrabaS, (dejelEjecutivo.EjeNomGrabaS.IndexOf(',') + 1) + 1, (dejelEjecutivo.EjeNomGrabaS.IndexOf('/') + 1) - (dejelEjecutivo.EjeNomGrabaS.IndexOf(',') + 1) - 1), ' ', 60));//Paterno 
                                sb.Append(CRSDialogo.fnArmaCadena(dejelEjecutivo.EjeNomGrabaS.Substring(dejelEjecutivo.EjeNomGrabaS.Length - Math.Min(dejelEjecutivo.EjeNomGrabaS.Length, Strings.Len(dejelEjecutivo.EjeNomGrabaS) - (dejelEjecutivo.EjeNomGrabaS.IndexOf('/') + 1))), ' ', 60));//Materno
                                sb.Append(CRSDialogo.fnArmaCadena(sfechaN.Trim(), '0', 8));//Fecha de nacimiento
                                sb.Append(CRSDialogo.fnArmaCadena(dejelEjecutivo.EjeRfcRFC.fncConstruyeRfcS(false).Trim(), ' ', 13)); //RFC
                                sb.Append(CRSDialogo.fnArmaCadena(dejelEjecutivo.EjeSexoS, ' ', 1));  //Sexo
                                if (dejelEjecutivo.EjeNacionalidadS == "")  //PAIS NACIONALIDAD()
                                {
                                    sb.Append(CRSDialogo.fnArmaCadena("1", '0', 2, FillDirection.Izquierda)); //Clave Nacionalidad
                                }
                                else
                                {
                                    sb.Append(CRSDialogo.fnArmaCadena(dejelEjecutivo.EjeNacionalidadS, '0', 2, FillDirection.Izquierda)); //Clave Nacionalidad                           
                                }


                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, '0', 4)); //Clave Ocupacion 
                                sb.Append(CRSDialogo.fnArmaCadena(dejelEjecutivo.EjeActiSubactiS, '0', 4,FillDirection.Izquierda));//Actividad Subactividad
                                #endregion;

                                #region Datos Domicilio
                                sb.Append(CRSDialogo.fnArmaCadena("1", '0', 1));  //Identificador de Domicilio 1=casa 2=oficina 
                                sb.Append(CRSDialogo.fnArmaCadena(dejelEjecutivo.EjeDomEnvioDMC.DomicilioS, ' ', 35));  //Calle Num1 
                                sb.Append(CRSDialogo.fnArmaCadena(dejelEjecutivo.EjeDomEnvioDMC.ColoniaS, ' ', 25));  //Colonia1 
                                sb.Append(CRSDialogo.fnArmaCadena(dejelEjecutivo.EjeDomEnvioDMC.PoblacionS, ' ', 21));  //Ciudad1
                                sb.Append(CRSDialogo.fnArmaCadena(dejelEjecutivo.EjeDomEnvioDMC.EstadoEST.CodigoI.ToString(), '0', 2, FillDirection.Izquierda)); //Estado1 
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, '0', 2));//Zona Postal 
                                sb.Append(CRSDialogo.fnArmaCadena(dejelEjecutivo.EjeDomEnvioDMC.CPL.ToString(), '0', 5,FillDirection.Izquierda)); //Codigo Postal 
                                sb.Append(CRSDialogo.fnArmaCadena(ladaP, '0', 3, FillDirection.Izquierda));//Lada Telefono Casa
                                sb.Append(CRSDialogo.fnArmaCadena(telefonoP, '0', 7, FillDirection.Izquierda));//Telefono Particular
                                sb.Append(CRSDialogo.fnArmaCadena(ladaO, '0', 3, FillDirection.Izquierda));//Lada Telefono Oficina
                                sb.Append(CRSDialogo.fnArmaCadena(telefonoO, '0', 7,FillDirection.Izquierda));  //Telefono de Oficina 
                                sb.Append(CRSDialogo.fnArmaCadena(StringsHelper.DoubleValue(((dejelEjecutivo.EjeExtensionS.Trim() == "") ? "0" : dejelEjecutivo.EjeExtensionS.Trim()).Trim()).ToString().Substring(StringsHelper.DoubleValue(((dejelEjecutivo.EjeExtensionS.Trim() == "") ? "0" : dejelEjecutivo.EjeExtensionS.Trim()).Trim()).ToString().Length - Math.Min(StringsHelper.DoubleValue(((dejelEjecutivo.EjeExtensionS.Trim() == "") ? "0" : dejelEjecutivo.EjeExtensionS.Trim()).Trim()).ToString().Length, 5)), '0', 5, FillDirection.Izquierda));  //Extension 
                                sb.Append(CRSDialogo.fnArmaCadena(dejelEjecutivo.EjeDomPartDMC.DomicilioS, ' ', 35));  //Calle Num2 
                                sb.Append(CRSDialogo.fnArmaCadena(dejelEjecutivo.EjeDomPartDMC.ColoniaS, ' ', 25));  //Colonia2 
                                sb.Append(CRSDialogo.fnArmaCadena(dejelEjecutivo.EjeDomPartDMC.PoblacionS, ' ', 21));  //CIUDAD2   
                                sb.Append(CRSDialogo.fnArmaCadena(dejelEjecutivo.EjeDomPartDMC.EstadoEST.CodigoI.ToString(), '0', 2,FillDirection.Izquierda));  //ESTADO2 
                                sb.Append(CRSDialogo.fnArmaCadena(dejelEjecutivo.EjeDomPartDMC.CPL.ToString(), '0', 5,FillDirection.Izquierda));  //COD-POSTAL2
                                #endregion;

                                #region Datos Basica
                                sb.Append(CRSDialogo.fnArmaCadena(dejelEjecutivo.EjeSucTransS, '0', 4, FillDirection.Izquierda));  //Sucursal Transmisora 
                                sb.Append(CRSDialogo.fnArmaCadena(dejelEjecutivo.EjeSucPromS, '0', 4, FillDirection.Izquierda));  //Sucursal Promotora 
                                sb.Append(CRSDialogo.fnArmaCadena(dejelEjecutivo.EjeOrigenS, ' ', 1));  //Origen * 
                                sb.Append(CRSDialogo.fnArmaCadena(dejelEjecutivo.EjeCuentaS, '0', 16, FillDirection.Izquierda));  //Cuenta 
                                sb.Append(CRSDialogo.fnArmaCadena(dejelEjecutivo.EjeLimCredL.ToString(), '0', 9,FillDirection.Izquierda));  //Límite de Crédito 
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, '0', 3));  //Puntos del Scoredcard 
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, '0', 3));  //Identificador del Scoredcard 
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, '0', 6));  //FEC-EVAL-SCORECARD 
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, '0', 1));  //Indicador de generacion de plastico 0=normal, 1=urgente 
                                sb.Append(CRSDialogo.fnArmaCadena(dejelEjecutivo.EjeLimDisEfecL.ToString(), '0', 3, FillDirection.Izquierda));  //Limite de Disposiciones 
                                sb.Append(CRSDialogo.fnArmaCadena(dejelEjecutivo.EjeCuentaReferenciaS, '0', 16, FillDirection.Izquierda)); //Tarjeta 1
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, '0', 16));  //Tarjeta 2 
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, ' ', 1)); //-BAS-CATEGORIA 
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, ' ', 3));  //Tipo Operacion 
                                //Cambia para que ahora si es per F. Act Emp = "A" de no ser asi "I"//se solicita cambiar para que mande una "I" 11/11/13
                                //slDialogo = StringsHelper.MidAssignment(slDialogo, 707, "E");  //BAS-CVE-OPCION  
                                //Se  solicita cambiar esta validacion para que en caso de ser persona moral ponga una "E" 19/02/2014
                                //Resultado del cambio
                                //Fisica = "I"
                                //F. Act. Emp. = "A"
                                //Moral = "E"
                                if (dejelEjecutivo.EjePersona.Equals(3))
                                {
                                    sb.Append(CRSDialogo.fnArmaCadena("A", ' ', 1));
                                }
                                else if (dejelEjecutivo.EjePersona.Equals(2))
                                {
                                    sb.Append(CRSDialogo.fnArmaCadena(mdlParametros.ctesIndividual, ' ', 1));//Cambia para que ahora si es per F. Act Emp = "A" de no ser asi "I"//se solicita cambiar para uqe mande una "I" 11/11/13
                                }
                                else if (dejelEjecutivo.EjePersona.Equals(1))
                                {
                                    sb.Append(CRSDialogo.fnArmaCadena("E", ' ', 1));
                                }

                                sb.Append(CRSDialogo.fnArmaCadena(dejelEjecutivo.EjeSkipPaymentL.ToString(), '0', 1));  //Skip Payment 
                                sb.Append(CRSDialogo.fnArmaCadena(dejelEjecutivo.EjeTablaMCCL.ToString(), '0', 4, FillDirection.Izquierda));  //Indicativo de tabla MCC 
                                sb.Append(CRSDialogo.fnArmaCadena(dejelEjecutivo.EjeTipoFactS, ' ', 1));  //Tipo de Facturacion 
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, ' ', 10));  //Identificador de Linea Aerea 
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, ' ', 55));  //Nombre Largo Adicional 
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, '0', 8));  //Fecha Nacimiento Adicional
                                sb.Append(CRSDialogo.fnArmaCadena(dejelEjecutivo.EjeDiaCorteI.ToString(), '0', 2, FillDirection.Izquierda));  //Dia de Corte


                                if (mdlParametros.igIndAltaCteOK == 0)
                                {
                                    sb.Append(CRSDialogo.fnArmaCadena(string.Empty, '0', 1)); //IND-CTES-OK
                                }
                                else if (mdlParametros.igIndAltaCteOK == 1)
                                {
                                    sb.Append(CRSDialogo.fnArmaCadena("1", '0', 1)); //IND-CTES-OK
                                }

                                sb.Append(CRSDialogo.fnArmaCadena(dejelEjecutivo.EjeTipoBloqueoI.ToString(), '0', 1));  //Tipo de Bloqueo MCC 
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, ' ', 46));//Filler
                                #endregion;

                                #region Datos Proc Eempresa
                                sb.Append(CRSDialogo.fnArmaCadena(DateTime.Today.ToString("yyyyMMdd"), '0', 8));//Fecha Alta
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, '0', 6));//-PROC-HH-HORA-INICIAL   
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, '0', 8)); //PROC-FEC-FINAL    
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, '0', 6)); //PROC-HH-HORA-FINAL
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, '0', 4)); //PROC-CVE-CAUSA-RECHAZO 
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, ' ', 150)); //WKS-PROC-COMENTARIOS 
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, '0', 16));  //Numero de Cuenta 
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, ' ', 30));  //TR01-NOMBRE-EMPRESA 
                                #endregion;

                                #region Datos Comp S016
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, '0', 4, FillDirection.Izquierda));//PAIS NACIONALIDAD
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, '0', 4, FillDirection.Izquierda));//PAIS NACIMIENTO
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, ' ', 20));//FIEL  
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, ' ', 18));//CURP
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, ' ', 78));//mail 
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, '0', 6,FillDirection.Izquierda));//giro
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, '0', 2,FillDirection.Izquierda));//Endidad de nacimiento
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, ' ', 20)); //ID Fiscal Equi1
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, ' ', 4)); //Pais que asigno1
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, ' ', 20));//ID Fiscal Equi2
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, ' ', 4));//Pais que asigno2
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, ' ', 2));//Tipo Persona
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, ' ', 8));//Fecha constitucion
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, ' ', 20));//Firma electronica
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, ' ', 2)); //Has trabajado en el ext
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, ' ', 70));//Empresa empleador
                                sb.Append(CRSDialogo.fnArmaCadena(CRSDialogo.cteIdentificacion.ToUpper(), ' ', 10));//Datos de identificacion

                                sb.Append(CRSDialogo.fnArmaCadena(Seguridad.usugUsuario.NominaS, ' ', 10));//Nomina del operador
                                sb.Append(CRSDialogo.fnArmaCadena(mdlSeguridad._SIRH, '0', 4,FillDirection.Izquierda));//SIRH

                                CRSDialogo.fncDateTimeToSend(out sDate, out sTime);

                                sb.Append(CRSDialogo.fnArmaCadena(sDate, '0', 8));//Fecha transacccion
                                sb.Append(CRSDialogo.fnArmaCadena(sTime, ' ', 8));//Hora transaccion
                                sb.Append(CRSDialogo.fnArmaCadena(string.Empty, ' ', 190));//Filler

                                #endregion;

                            //CAMBIAR Ñ POR @ Y ELIMINAR ACENTOS
                            this.DialogoS = EliminaAcentos(sb.ToString().Replace("Ñ", "@").Replace("ñ", "@"));
                            break;*/

					}
			}
			catch (Exception e)
			{
				CRSGeneral.prObtenError("clsDialogo (GeneraDlg)",e );
				return;
			}
		}

		public static string EliminaAcentos(string texto)
		{
			if (string.IsNullOrEmpty(texto))
				return texto;
			byte[] tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(texto);
			return System.Text.Encoding.UTF8.GetString(tempBytes);
		}
	}
}