using Microsoft.VisualBasic; 
using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	class mdlConectividad
	{
	
		public struct Datos
		{
			public string Tipo;
			public string DATO;
			public static Datos CreateInstance()
			{
					Datos result = new Datos();
					result.Tipo = String.Empty;
					result.DATO = String.Empty;
					return result;
			}
		}
		
		
		
		
		static public int Envia( string cad,  string strNombreArchivoCte)
		{
			int result = 0;
			object TPEEVENT = null;
			object tperrno = null;
			Datos dtDatos = Datos.CreateInstance();
			
			//Dim cd As Integer
			//Dim revent As Integer
			int revent = 0;
			//Dim RecevLen  As Long
			int RecevLen = 0;
			int retlen = 0;
			int num = 0;
			int contador = 0;
			string resultado = String.Empty;
			int longitud = 0;
			int posicion = 0;
			int iteracion = 0;
			
			
			
			
			string Label = "Genera Reporte0";
			//ServicioS$ = "18 REP_18 20050918 4943 88 747 1304 917 0 9 file_c.tmp 0 0                                                                                                                                                                                                "
			//ServicioS$ = "22 REP_22 20050918 4943 88 866 1304 917 0 9 file_c.tmp 0 0                                                                                                                                                                                                "
			string ServicioS = cad;
			dtDatos.Tipo = new String(' ', 4);
			dtDatos.DATO = new String(' ', 256);
            //AIS-1182 NGONZALEZ
			int cd = API.Tux.tpconnect("SRVC_REPS_C", mdlTuxedo.Cadena.bufptr, retlen, mdlTuxedo.TPSENDONLY);
			if (cd == -1)
			{
				mdlTuxedo.TuxError(ref Label);
				mdlTuxedo.reserva_libera(0);
				mdlTuxedo.Desconecta_Tuxedo();
				return 0;
			}
			Label = "FCHG32-F_TYPE";
			string cadTipo = "0000";
			dtDatos.Tipo = "0000";
            //AIS-1182 NGONZALEZ
			if (API.FML.Fchg32(mdlTuxedo.Cadena.bufptr, mdlTuxedo.F_TYPE, 0, cadTipo, 0) == -1)
			{
				mdlTuxedo.Fml32Error(Label);
				mdlTuxedo.reserva_libera(0);
				return 0;
			}
			Label = "FCHG32-F_DATA";
			dtDatos.DATO = ServicioS;
            //AIS-1182 NGONZALEZ
			if (API.FML.Fchg32(mdlTuxedo.Cadena.bufptr, mdlTuxedo.F_DATA, 0, ServicioS, 0) == -1)
			{
				mdlTuxedo.Fml32Error(Label);
				mdlTuxedo.reserva_libera(0);
				return 0;
			}
			
			Label = "TPSEND_1 iteracion" + Conversion.Str(iteracion);
            //AIS-1182 NGONZALEZ
            if (API.Tux.tpsend(cd,  mdlTuxedo.Cadena.bufptr, 0, mdlTuxedo.TPRECVONLY, out revent) == -1)
			{
				mdlTuxedo.TuxError(ref Label);
				mdlTuxedo.reserva_libera(0);
				mdlTuxedo.Desconecta_Tuxedo();
				return 0;
			}
			Label = "TPRECV_1 iteracion" + Conversion.Str(iteracion);
            //AIS-1182 NGONZALEZ
            int tmpInt = 0;
            if (API.Tux.tprecv(cd, out mdlTuxedo.respuesta.bufptr, out tmpInt, mdlTuxedo.TPNOCHANGE, out revent) != -1)
			{
				mdlTuxedo.TuxError(ref Label);
				mdlTuxedo.reserva_libera(0);
				mdlTuxedo.Desconecta_Tuxedo();
				return 0;
			}
			//UPGRADE_WARNING: (1037) Couldn't resolve default property of object TPEEVENT.
			//UPGRADE_WARNING: (1037) Couldn't resolve default property of object tperrno.
			if ((! tperrno.Equals(TPEEVENT)) || ((revent != mdlTuxedo.TPEV_SENDONLY) && (revent != mdlTuxedo.TPEV_SVCSUCC) && (revent != mdlTuxedo.TPEV_SVCFAIL)))
			{
				mdlTuxedo.TuxError(ref Label);
				mdlTuxedo.reserva_libera(0);
				mdlTuxedo.Desconecta_Tuxedo();
				return 0;
			}
			Label = "TPRECV_1_1 iteracion" + Conversion.Str(iteracion);
			if (revent == mdlTuxedo.TPEV_SVCSUCC)
			{
				mdlTuxedo.TuxError(ref Label);
				mdlTuxedo.reserva_libera(0);
				mdlTuxedo.Desconecta_Tuxedo();
				return 0;
			}
			cadTipo = new String(' ', 4);
			ServicioS = new String(' ', 256);
			retlen = 300;
			//retlen& = 4
			Label = "FGET32_1_F_TYPE iteracion" + Conversion.Str(iteracion);
			//AIS-1182 NGONZALEZ
            if (API.FML.Fget32(mdlTuxedo.respuesta.bufptr, mdlTuxedo.F_TYPE, 0, ref cadTipo, out retlen) == -1)
			{
				mdlTuxedo.TuxError(ref Label);
				mdlTuxedo.reserva_libera(0);
				mdlTuxedo.Desconecta_Tuxedo();
				return 0;
			}
			retlen = 300;
			//retlen& = 256
			Label = "FGET32_1_F_DATA iteracion" + Conversion.Str(iteracion);
            //AIS-1182 NGONZALEZ
            if (API.FML.Fget32(mdlTuxedo.respuesta.bufptr, mdlTuxedo.F_DATA, 0,ref ServicioS, out retlen) == -1)
			{
				mdlTuxedo.TuxError(ref Label);
				mdlTuxedo.reserva_libera(0);
				mdlTuxedo.Desconecta_Tuxedo();
				return 0;
			}
			
			Label = "REPORT_FAILURE";
			string resp = ServicioS.Substring(0, Math.Min(ServicioS.Length, 14));
			if (resp == "REPORT_FAILURE")
			{
				//TuxError (label$)
				mdlTuxedo.reserva_libera(0);
				mdlTuxedo.Desconecta_Tuxedo();
				//MsgBox "REPORT_FAILURE"
				return 1;
			}
			//respuesta$ = "REPORT_NO_DATA"
			if (resp == "REPORT_NO_DATA")
			{
				//TuxError (label$)
				mdlTuxedo.reserva_libera(0);
				mdlTuxedo.Desconecta_Tuxedo();
				//MsgBox "REPORT_NO_DATA"
				return 2;
			}
			//fdelall32( )
            //AIS-1182 NGONZALEZ
			if (API.FML.Fdelall32((int)mdlTuxedo.respuesta.bufptr, mdlTuxedo.F_TYPE) < 0)
			{
				mdlTuxedo.TuxError(ref Label);
				mdlTuxedo.reserva_libera(0);
				mdlTuxedo.Desconecta_Tuxedo();
				return 1;
			}
            //AIS-1182 NGONZALEZ
			if (API.FML.Fdelall32((int)mdlTuxedo.respuesta.bufptr, mdlTuxedo.F_DATA) < 0)
			{
				mdlTuxedo.TuxError(ref Label);
				mdlTuxedo.reserva_libera(0);
				mdlTuxedo.Desconecta_Tuxedo();
				return 1;
			}
			string NomArch = strNombreArchivoCte;
			FileSystem.FileOpen(1, NomArch, OpenMode.Append, OpenAccess.Default, OpenShare.Default, -1);
			//msgBit = Format(Now, "HhNnSs") & ":" & Title & ": " & TIPO & ": " & "ERROR " & NumErr & ": " & msjErr
			
			
			
			int band = 1;
			byte itracion = 0;
			do 
			{
				//MsgBox "Loop fase 1"
				Label = "TPSEND-Iteracción numero " + Conversion.Str(iteracion);
                //AIS-1182 NGONZALEZ
				if (API.Tux.tpsend(cd, mdlTuxedo.Cadena.bufptr, 0, mdlTuxedo.TPRECVONLY, out revent) == -1)
				{
					mdlTuxedo.TuxError(ref Label);
					mdlTuxedo.reserva_libera(0);
					mdlTuxedo.Desconecta_Tuxedo();
					return 1;
				}
				Label = "TPRECV-Iteración número" + Conversion.Str(iteracion);
                //AIS-1182 NGONZALEZ
                tmpInt = 0;
				if (API.Tux.tprecv( cd, out mdlTuxedo.respuesta.bufptr, out tmpInt, mdlTuxedo.TPNOCHANGE, out revent) != -1)
				{
					mdlTuxedo.TuxError(ref Label);
					mdlTuxedo.reserva_libera(0);
					mdlTuxedo.Desconecta_Tuxedo();
					return 1;
				}
				//UPGRADE_WARNING: (1037) Couldn't resolve default property of object TPEEVENT.
				//UPGRADE_WARNING: (1037) Couldn't resolve default property of object tperrno.
				if ((! tperrno.Equals(TPEEVENT)) || ((revent != mdlTuxedo.TPEV_SENDONLY) && (revent != mdlTuxedo.TPEV_SVCSUCC) && (revent != mdlTuxedo.TPEV_SVCFAIL)))
				{
					mdlTuxedo.TuxError(ref Label);
					mdlTuxedo.reserva_libera(0);
					mdlTuxedo.Desconecta_Tuxedo();
					return 1;
				}
                //AIS-1182 NGONZALEZ
				num = API.FML.Foccur32(mdlTuxedo.respuesta.bufptr, mdlTuxedo.F_DATA);
				for (double i = 0; i <= num; i++)
				{
					if (i < num)
					{
						cadTipo = new String(' ', 4);
						ServicioS = new String(' ', 256);
						retlen = 300;
						contador = Convert.ToInt32(i);
						Label = "FGET32-F_TYPE-Iteración número" + Conversion.Str(iteracion) + "FOR " + Conversion.Str(i);
                        //AIS-1182 NGONZALEZ
                        if (API.FML.Fget32(mdlTuxedo.respuesta.bufptr, mdlTuxedo.F_TYPE, contador, ref cadTipo, out retlen) == -1)
						{
							mdlTuxedo.TuxError(ref Label);
							mdlTuxedo.reserva_libera(0);
							mdlTuxedo.Desconecta_Tuxedo();
							return 1;
						}
						Label = "FGET32-F_DATA-Iteración número" + Conversion.Str(iteracion) + "FOR " + Conversion.Str(i);
						retlen = 300;
						//retlen& = 256
                        //AIS-1182 NGONZALEZ
                        if (API.FML.Fget32(mdlTuxedo.respuesta.bufptr, mdlTuxedo.F_DATA,  contador, ref ServicioS, out retlen) == -1)
						{
							mdlTuxedo.TuxError(ref Label);
							mdlTuxedo.reserva_libera(0);
							mdlTuxedo.Desconecta_Tuxedo();
							return 1;
						}
						//MsgBox ServicioS$
						Label = "REPORT_FAILURE";
						if (ServicioS == "REPORT_FAILURE")
						{
							mdlTuxedo.TuxError(ref Label);
							mdlTuxedo.reserva_libera(0);
							mdlTuxedo.Desconecta_Tuxedo();
							return 1;
						}
						//Replace (ServicioS$,chr(10),chr(10)+chr(13),1)
						//resultado$ = Replace(ServicioS$, Chr(10), "|", 1)
						//ServicioS$ = Replace(resultado$, Chr(13), "]", 1)
						longitud = ServicioS.Trim().Length;
						if (longitud > 0)
						{
							posicion = (ServicioS.IndexOf("\n") + 1);
							resultado = ServicioS;
							if (posicion > 0)
							{
								resultado = ServicioS.Substring(0, Math.Min(ServicioS.Length, posicion - 1));
							} else
							{
								posicion = (ServicioS.IndexOf(Strings.Chr(12).ToString()) + 1);
								if (posicion > 0)
								{
									resultado = ServicioS.Substring(0, Math.Min(ServicioS.Length, posicion));
								}
							}
							FileSystem.PrintLine(1, resultado);
						}
					} //fin del if dentro del for
				} //fin del for
				
				if (revent == mdlTuxedo.TPEV_SENDONLY)
				{
					band = 1;
				}
				if (revent == mdlTuxedo.TPEV_SVCSUCC)
				{
					band = 0;
				}
				if (revent == mdlTuxedo.TPEV_SVCFAIL)
				{
					band = 0;
				}
				Label = "FDELALL32_2_FTYPE";
                //AIS-1182 NGONZALEZ
				if (API.FML.Fdelall32((int)mdlTuxedo.respuesta.bufptr, mdlTuxedo.F_TYPE) < 0)
				{
					mdlTuxedo.TuxError(ref Label);
					mdlTuxedo.reserva_libera(0);
					mdlTuxedo.Desconecta_Tuxedo();
					return 1;
				}
				Label = "FDELALL32_2_FDATA";
                //AIS-1182 NGONZALEZ
				if (API.FML.Fdelall32((int)mdlTuxedo.respuesta.bufptr, mdlTuxedo.F_DATA) < 0)
				{
					mdlTuxedo.TuxError(ref Label);
					mdlTuxedo.reserva_libera(0);
					mdlTuxedo.Desconecta_Tuxedo();
					return 1;
				}
				
				//End If
				//Next i
				iteracion++;
			}
			while(band != 0);
			FileSystem.FileClose(1);
			mdlTuxedo.Desconecta_Tuxedo();
			return result;
		}
	}
}