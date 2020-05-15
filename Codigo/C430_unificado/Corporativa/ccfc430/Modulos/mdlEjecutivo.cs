using Microsoft.VisualBasic.Compatibility.VB6; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	class mdlEjecutivo
	{
	
		
		//Variable global del objeto datos ejecutivo
		//Global gdteEjecutivo    As clsDatosEjecutivo
		
		//Variable global del objeto datos ejecutivo para la consulta del Ejecutivo
		//Global gdteEjeExists    As clsDatosEjecutivo
		
		//Variable para la Validacion de Informacion
		static public string smValidaInf = String.Empty;
		static public int lmEmpCredTot = 0;
		static public int lmEmpCredAcum = 0;
		
		//Variable para el dialogo
		//Global gdlgDialogoS016          As clsDialogo
		//Global gdlgDialogoS111          As clsDialogo
		
		public enum enuTipoConsultaEjecutivo
		 {
			tcneConsultaAlta = 0 ,
			tcneConsultaCambio = 1 ,
			tcneConsultaConsulta = 2
		}
		
		public enum enuTipoAltaEjecutivo
		 {
			taejAltaIndividual = 0 ,
			taejAltaMasiva = 1
		}
		
		public enum enuTipoAltaSistema
		 {
			tasAltaS016 = 0 ,
			tasAltaS111 = 1
		}
		
		//Variables para Limite de Credito
		static public clsDialogo gdlgConexionConComDrive = null;
		
		//Public Function fncAltaEjecutivoB(ipTipoAltaEjecutivo As enuTipoAltaEjecutivo) As Boolean
		//
		//On Error GoTo ErrAltaEjecutivo
		//
		//    Select Case ipTipoAltaEjecutivo
		//        Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//            If fncValidarConsecutivoB = True Then
		//                If fncValidaInfB = True Then
		//                    prObtenCredEmp
		//                    If fncVerificaCreditoB = True Then
		//                        If fncGrabaTablaRespB(taejAltaIndividual) = True Then
		//                            If fncObtenEjeNumB(taejAltaIndividual) = True Then
		//                                prActualizaEstatus taejAltaIndividual, 1
		//                                gdlgDialogoS016.prGeneraDlg gdteEjecutivo, tAltaEjecutivoS016
		//                                gdlgDialogoS111.prGeneraDlg gdteEjecutivo, tAltaEjecutivoS111
		//                                If fncRealizaConexionRutB(tcnxConexionRut) = True Then
		//                                    prActualizaEstatus taejAltaIndividual, 2
		//                                    If fncEnviaValidaDialogoB(taejAltaIndividual, tasAltaS016) = True Then
		//                                        If fncActualizaConsecutivoB(taejAltaIndividual) = True Then
		//                                            prActualizaEstatus taejAltaIndividual, 5
		//                                            If fncRealizaConexionRutB(tcnxConexionRut) = True Then
		//                                                prActualizaEstatus taejAltaIndividual, 6
		//                                                If fncEnviaValidaDialogoB(taejAltaIndividual, tasAltaS111) = True Then
		//                                                    If fncInsertaEjecutivoM111B(taejAltaIndividual) = True Then
		//                                                        prActualizaEstatus taejAltaIndividual, 10
		//                                                        If fncActualizaCredAcumEmpB(taejAltaIndividual) = True Then
		//                                                            prActualizaEstatus taejAltaIndividual, 11
		//                                                            If fncConsultaEjecutivoM111B(taejAltaIndividual) = True Then
		//                                                                prActualizaEstatus taejAltaIndividual, 12
		//                                                                MsgBox "Se dió de alta el Ejecutivo, el número de cuenta asignado es " & gdteEjecutivo.EjeCuentaBnxS, vbInformation + vbOKOnly, "Tarjeta Corporativa"
		//                                                                fncEliminaEjecutivoRespB (taejAltaIndividual)
		//                                                                fncAltaEjecutivoB = True
		//                                                                Screen.MousePointer = vbDefault
		//                                                                Exit Function
		//                                                            Else
		//                                                                fncAltaEjecutivoB = False
		//                                                                Screen.MousePointer = vbDefault
		//                                                                Exit Function
		//                                                            End If
		//                                                        Else
		//                                                            fncAltaEjecutivoB = False
		//                                                            Screen.MousePointer = vbDefault
		//                                                            Exit Function
		//                                                        End If
		//                                                    Else
		//                                                        fncAltaEjecutivoB = False
		//                                                        Screen.MousePointer = vbDefault
		//                                                        Exit Function
		//                                                    End If
		//                                                Else
		//                                                    fncAltaEjecutivoB = False
		//                                                    Screen.MousePointer = vbDefault
		//                                                    Exit Function
		//                                                End If
		//                                            Else
		//                                                fncAltaEjecutivoB = False
		//                                                Screen.MousePointer = vbDefault
		//                                                Exit Function
		//                                            End If
		//                                        Else
		//                                            fncAltaEjecutivoB = False
		//                                            Screen.MousePointer = vbDefault
		//                                            Exit Function
		//                                        End If
		//                                    Else
		//                                        fncAltaEjecutivoB = False
		//                                        Screen.MousePointer = vbDefault
		//                                        Exit Function
		//                                    End If
		//                                Else
		//                                    fncAltaEjecutivoB = False
		//                                    Screen.MousePointer = vbDefault
		//                                    Exit Function
		//                                End If
		//                            Else
		//                                fncAltaEjecutivoB = False
		//                                Screen.MousePointer = vbDefault
		//                                Exit Function
		//                            End If
		//                        Else
		//                            fncAltaEjecutivoB = False
		//                            Screen.MousePointer = vbDefault
		//                            Exit Function
		//                        End If
		//                    Else
		//                        fncAltaEjecutivoB = False
		//                        Screen.MousePointer = vbDefault
		//                        Exit Function
		//                    End If
		//                Else
		//                    fncAltaEjecutivoB = False
		//                    MsgBox "Falta por capturar el campo: " & smValidaInf, vbInformation + vbOKOnly, App.Title
		//                    Screen.MousePointer = vbDefault
		//                    Exit Function
		//                End If
		//            Else
		//                fncAltaEjecutivoB = False
		//                Screen.MousePointer = vbDefault
		//                Exit Function
		//            End If
		//            Screen.MousePointer = vbDefault
		//
		//        Case taejAltaMasiva         '***** ALTA MASIVA *****
		//
		//            Screen.MousePointer = vbHourglass
		//            Set gdlgDialogoS016 = New clsDialogo
		//            Set gdlgDialogoS111 = New clsDialogo
		//
		//'            If fncRealizaConexionB(tcnxConComDriver) = True Then
		//'                If fncObtenEjeNumB(taejAltaMasiva) = True Then
		//'                    prActualizaEstatus taejAltaMasiva, 1
		//'                    gdlgDialogoS016.prGeneraDlg gdteEjecutivo, tAltaEjecutivoS016
		//'                    gdlgDialogoS111.prGeneraDlg gdteEjecutivo, tAltaEjecutivoS111
		//'                    If fncRealizaConexionB(tcnxConexionRut) = True Then
		//'                        prActualizaEstatus taejAltaMasiva, 3
		//'                        If fncEnviaValidaDialogoB(taejAltaMasiva, tasAltaS016) = True Then
		//'                            If fncActualizaConsecutivoB(taejAltaMasiva) = True Then
		//'                                prActualizaEstatus taejAltaMasiva, 11
		//'                                If fncEnviaValidaDialogoB(taejAltaMasiva, tasAltaS111) = True Then
		//'                                    If fncInsertaEjecutivoM111B(taejAltaMasiva) = True Then
		//'                                        prActualizaEstatus taejAltaMasiva, 18
		//'                                        If fncActualizaCredAcumEmpB(taejAltaMasiva) = True Then
		//'                                            prActualizaEstatus taejAltaMasiva, 20
		//'                                            If fncConsultaEjecutivoM111B(taejAltaMasiva) = True Then
		//'                                                prActualizaEstatus taejAltaMasiva, 22
		//'                                                If fncEliminaEjecutivoRespB(taejAltaMasiva) = True Then
		//'                                                    fncAltaEjecutivoB = True
		//'                                                    Screen.MousePointer = vbDefault
		//'                                                    Exit Function
		//'                                                Else
		//'                                                    fncAltaEjecutivoB = False
		//'                                                    Screen.MousePointer = vbDefault
		//'                                                    Exit Function
		//'                                                End If
		//'                                            Else
		//'                                                prActualizaEstatus taejAltaMasiva, 23
		//'                                                Screen.MousePointer = vbDefault
		//'                                                Exit Function
		//'                                            End If
		//'                                        Else
		//'                                            fncAltaEjecutivoB = False
		//'                                            prActualizaEstatus taejAltaMasiva, 21
		//'                                            Screen.MousePointer = vbDefault
		//'                                            Exit Function
		//'                                        End If
		//'                                    Else
		//'                                        fncAltaEjecutivoB = False
		//'                                        prActualizaEstatus taejAltaMasiva, 19
		//'                                        Screen.MousePointer = vbDefault
		//'                                        Exit Function
		//'                                    End If
		//'                                Else
		//'                                    fncAltaEjecutivoB = False
		//'                                    Screen.MousePointer = vbDefault
		//'                                    Exit Function
		//'                                End If
		//'                            Else
		//'                                fncAltaEjecutivoB = False
		//'                                prActualizaEstatus taejAltaMasiva, 12
		//'                                Screen.MousePointer = vbDefault
		//'                                Exit Function
		//'                            End If
		//'                        Else
		//'                            fncAltaEjecutivoB = False
		//'                            Screen.MousePointer = vbDefault
		//'                            Exit Function
		//'                        End If
		//'                    Else
		//'                        fncAltaEjecutivoB = False
		//'                        prActualizaEstatus taejAltaMasiva, 4
		//'                        Screen.MousePointer = vbDefault
		//'                        Exit Function
		//'                    End If
		//'                Else
		//'                    fncAltaEjecutivoB = False
		//'                    prActualizaEstatus taejAltaMasiva, 2
		//'                    Screen.MousePointer = vbDefault
		//'                    Exit Function
		//'                End If
		//'            Else
		//'                fncAltaEjecutivoB = False
		//'                Screen.MousePointer = vbDefault
		//'                Exit Function
		//'            End If
		//
		//            Screen.MousePointer = vbDefault
		//
		//    End Select
		//
		//Exit Function
		//ErrAltaEjecutivo:
		//    Select Case ipTipoAltaEjecutivo
		//        Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//            prObtenError "mdlEjecutivo (AltaEjecutivo)"
		//    End Select
		//    fncAltaEjecutivoB = False
		//    Screen.MousePointer = vbDefault
		//    Exit Function
		//End Function
		//
		//Public Function fncEliminaEjecutivoRespB(ipTipoAltaEjecutivo As enuTipoAltaEjecutivo) As Boolean
		//
		//On Error GoTo ErrEliminaEjecutivoResp
		//
		//    Screen.MousePointer = vbHourglass
		//
		//    Select Case ipTipoAltaEjecutivo
		//        Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//            pszgblsql = "delete "
		//            pszgblsql = pszgblsql & "from MTCIND01 "
		//            pszgblsql = pszgblsql & "where eje_status_reg = 22"
		//        Case taejAltaMasiva         '***** ALTA MASIVA *****
		//            pszgblsql = "delete "
		//            pszgblsql = pszgblsql & "from MTCMSV01 "
		//            pszgblsql = pszgblsql & "where eje_status_reg = 22"
		//    End Select
		//
		//    If Modifica_Registro Then
		//        fncEliminaEjecutivoRespB = True
		//        Screen.MousePointer = vbDefault
		//        Exit Function
		//    Else
		//        Select Case ipTipoAltaEjecutivo
		//            Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//                MsgBox "No se pudo eliminar el respaldo del ejecutivo.", vbInformation + vbOKOnly, "Tarjeta Corporativa"
		//        End Select
		//        fncEliminaEjecutivoRespB = False
		//        Screen.MousePointer = vbDefault
		//        Exit Function
		//    End If
		//
		//Exit Function
		//ErrEliminaEjecutivoResp:
		//    Select Case ipTipoAltaEjecutivo
		//        Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//            prObtenError "mdlEjecutivo (EliminaEjecutivoResp)"
		//    End Select
		//    fncEliminaEjecutivoRespB = False
		//    Screen.MousePointer = vbDefault
		//    Exit Function
		//End Function
		//
		//Public Function fncConsultaEjecutivoM111B(ipTipoAltaEjecutivo As enuTipoAltaEjecutivo) As Boolean
		//
		//On Error GoTo ErrConsultaEjecutivoM111
		//
		//    Screen.MousePointer = vbHourglass
		//
		//    pszgblsql = "select "
		//    pszgblsql = pszgblsql & "eje_prefijo,"
		//    pszgblsql = pszgblsql & "gpo_banco,"
		//    pszgblsql = pszgblsql & "emp_num,"
		//    pszgblsql = pszgblsql & "eje_num,"
		//    pszgblsql = pszgblsql & "eje_roll_over,"
		//    pszgblsql = pszgblsql & "eje_digit "
		//    pszgblsql = pszgblsql & "from MTCEJE01 "
		//    pszgblsql = pszgblsql & "where eje_prefijo = " & gdteEjecutivo.EjeProductoPRD.PrefijoL
		//    pszgblsql = pszgblsql & "and gpo_banco = " & gdteEjecutivo.EjeProductoPRD.BancoL
		//    pszgblsql = pszgblsql & "and emp_num = " & gdteEjecutivo.EjeEmpNumL
		//    pszgblsql = pszgblsql & "and eje_num = " & gdteEjecutivo.EjeNumL
		//    pszgblsql = pszgblsql & "and eje_nom_gra = '" & gdteEjecutivo.EjeNomGrabaS & "'"
		//    pszgblsql = pszgblsql & "and eje_rfc = '" & gdteEjecutivo.EjeRfcRFC.RFCS & "'"
		//
		//    If Cuenta_Registros >= 1 Then
		//        fncConsultaEjecutivoM111B = True
		//        Screen.MousePointer = vbDefault
		//        Exit Function
		//    Else
		//        Select Case ipTipoAltaEjecutivo
		//            Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//                MsgBox "No se encontro el ejecutivo en el M111", vbInformation + vbOKOnly, "Tarjeta Corporativa"
		//        End Select
		//        fncConsultaEjecutivoM111B = False
		//        Screen.MousePointer = vbDefault
		//        Exit Function
		//    End If
		//
		//Exit Function
		//ErrConsultaEjecutivoM111:
		//    Select Case ipTipoAltaEjecutivo
		//        Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//            prObtenError "mdlEjecutivo (ConsultaEjecutivoM111)"
		//    End Select
		//    fncConsultaEjecutivoM111B = False
		//    Screen.MousePointer = vbDefault
		//    Exit Function
		//End Function
		//
		//Public Function fncActualizaCredAcumEmpB(ipTipoAltaEjecutivo As enuTipoAltaEjecutivo) As Boolean
		//
		//On Error GoTo ErrActualizaCredAcumEmp
		//
		//    Screen.MousePointer = vbHourglass
		//
		//    pszgblsql = "update MTCEMP01 "
		//    pszgblsql = pszgblsql & "set emp_acum_cred = "
		//    pszgblsql = pszgblsql & "(select isnull(sum(eje_limcred),0) "
		//    pszgblsql = pszgblsql & "from MTCEJE01 "
		//    pszgblsql = pszgblsql & "where eje_prefijo = " & gdteEjecutivo.EjeProductoPRD.PrefijoL
		//    pszgblsql = pszgblsql & "and gpo_banco = " & gdteEjecutivo.EjeProductoPRD.BancoL
		//    pszgblsql = pszgblsql & "and emp_num = " & gdteEjecutivo.EjeEmpNumL
		//    pszgblsql = pszgblsql & "and eje_num > 0 "
		//    pszgblsql = pszgblsql & "group by eje_prefijo, gpo_banco, emp_num),"
		//    pszgblsql = pszgblsql & "emp_usu_cam = '" & sgUserID & "' "
		//    pszgblsql = pszgblsql & "where eje_prefijo = " & gdteEjecutivo.EjeProductoPRD.PrefijoL
		//    pszgblsql = pszgblsql & "and gpo_banco = " & gdteEjecutivo.EjeProductoPRD.BancoL
		//    pszgblsql = pszgblsql & "and emp_num = " & gdteEjecutivo.EjeEmpNumL
		//
		//    If Modifica_Registro Then
		//        fncActualizaCredAcumEmpB = True
		//        Screen.MousePointer = vbDefault
		//        Exit Function
		//    Else
		//        Select Case ipTipoAltaEjecutivo
		//            Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//                MsgBox "No se pudo actualizar el credito acumulado de la empresa: " & gdteEjecutivo.EjeEmpNumL, vbInformation + vbOKOnly, "Tarjeta Corporativa"
		//        End Select
		//        fncActualizaCredAcumEmpB = False
		//        Screen.MousePointer = vbDefault
		//        Exit Function
		//    End If
		//
		//Exit Function
		//ErrActualizaCredAcumEmp:
		//    Select Case ipTipoAltaEjecutivo
		//        Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//            prObtenError "mdlEjecutivo (ActualizaCredAcumEmp)"
		//    End Select
		//    fncActualizaCredAcumEmpB = False
		//    Screen.MousePointer = vbDefault
		//    Exit Function
		//End Function
		//
		//Public Function fncInsertaEjecutivoM111B(ipTipoAltaEjecutivo As enuTipoAltaEjecutivo) As Boolean
		//
		//On Error GoTo ErrInsertaEjecutivoM111
		//
		//    Screen.MousePointer = vbHourglass
		//
		//    gdteEjecutivo.EjeCuentaBnxS = Trim(Format(gdteEjecutivo.EjeProductoPRD.PrefijoL, gdteEjecutivo.EjeProductoPRD.MascaraPrefijoS) & Format(gdteEjecutivo.EjeProductoPRD.BancoL, gdteEjecutivo.EjeProductoPRD.MascaraBancoS) & Format(gdteEjecutivo.EjeEmpNumL, gdteEjecutivo.EjeProductoPRD.MascaraEmpresaS) & Format(gdteEjecutivo.EjeNumL, gdteEjecutivo.EjeProductoPRD.MascaraEjecutivoS) & Trim(gdteEjecutivo.EjeRolloverI) & Trim(gdteEjecutivo.EjeDigitI))
		//
		//    pszgblsql = "exec spAltaEjecutivo "
		//    pszgblsql = pszgblsql & gdteEjecutivo.EjeProductoPRD.PrefijoL & ","
		//    pszgblsql = pszgblsql & gdteEjecutivo.EjeProductoPRD.BancoL & ","
		//    pszgblsql = pszgblsql & gdteEjecutivo.EjeEmpNumL & ","
		//    pszgblsql = pszgblsql & gdteEjecutivo.EjeNumL & ","
		//    pszgblsql = pszgblsql & gdteEjecutivo.EjeRolloverI & ","
		//    pszgblsql = pszgblsql & gdteEjecutivo.EjeDigitI & ","
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeNomS & "',"
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeRfcRFC.RFCS & "',"
		//    pszgblsql = pszgblsql & gdteEjecutivo.EjeSueldoL & ","
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeNumNomS & "',"
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeCentroCostS & "',"
		//    pszgblsql = pszgblsql & gdteEjecutivo.EjeNivelI & ","
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeNomGrabaS & "',"
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeDomEnvioDMC.DomicilioS & "',"
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeDomEnvioDMC.ColoniaS & "',"
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeDomEnvioDMC.PoblacionS & "',"
		//    pszgblsql = pszgblsql & "0,"
		//    pszgblsql = pszgblsql & gdteEjecutivo.EjeDomEnvioDMC.CPL & ","
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeTelDomS & "',"
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeTelOfiS & "',"
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeExtensionS & "',"
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeFaxS & "',"
		//    pszgblsql = pszgblsql & gdteEjecutivo.EjeLimCredL & ","
		//    pszgblsql = pszgblsql & gdteEjecutivo.EjeRegNumL & ","
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeEstatusS & "',"
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeCuentaBnxS & "',"
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeSexoS & "',"
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeSucTransS & "',"
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeSucPromS & "',"
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeOrigenS & "',"
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeActiSubactiS & "',"
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeDomEnvioDMC.EstadoEST.AbreviaturaS & "',"
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeDomPartDMC.DomicilioS & "',"
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeDomPartDMC.ColoniaS & "',"
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeDomPartDMC.CiudadS & "',"
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeDomPartDMC.PoblacionS & "',"
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeDomPartDMC.EstadoEST.AbreviaturaS & "',"
		//    pszgblsql = pszgblsql & gdteEjecutivo.EjeDomPartDMC.CPL & ","
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeEmailS & "',"
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeCtaContableS & "',"
		//    pszgblsql = pszgblsql & gdteEjecutivo.EjeGenPinPlaI & ","
		//    pszgblsql = pszgblsql & gdteEjecutivo.EjeLimDisEfecL & ","
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeTipoCuentaS & "',"
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeTipoFactS & "',"
		//    pszgblsql = pszgblsql & gdteEjecutivo.EjeSkipPaymentL & ","
		//    pszgblsql = pszgblsql & gdteEjecutivo.EjeTablaMCCL & ","
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeIndLimDispS & "',"
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeIndCtaCtrlS & "',"
		//    pszgblsql = pszgblsql & "'" & gdteEjecutivo.EjeNacionalidadS & "',"
		//    pszgblsql = pszgblsql & "'" & sgUserID & "'"
		//
		//    If Modifica_Registro Then
		//        fncInsertaEjecutivoM111B = True
		//        Screen.MousePointer = vbDefault
		//        Exit Function
		//    Else
		//        Select Case ipTipoAltaEjecutivo
		//            Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//                MsgBox "No se pudo insertar el ejecutivo: " & gdteEjecutivo.EjeEmpNumL, vbCritical + vbOKOnly, "Tarjeta Corporativa"
		//        End Select
		//        fncInsertaEjecutivoM111B = False
		//        Screen.MousePointer = vbDefault
		//        Exit Function
		//    End If
		//
		//Exit Function
		//ErrInsertaEjecutivoM111:
		//    Select Case ipTipoAltaEjecutivo
		//        Case taejAltaIndividual
		//            prObtenError "mdlEjecutivo (InsertaEjecutivoM111)"
		//    End Select
		//    fncInsertaEjecutivoM111B = False
		//    Screen.MousePointer = vbDefault
		//    Exit Function
		//End Function
		//
		//Public Function fncActualizaConsecutivoB(ipTipoAltaEjecutivo As enuTipoAltaEjecutivo) As Boolean
		//
		//On Error GoTo ErrActualizaConsecutivo
		//
		//    Screen.MousePointer = vbHourglass
		//
		//    pszgblsql = "update MTCEMP01"
		//    pszgblsql = pszgblsql & " set emp_con_eje = " & (gdteEjecutivo.EjeNumL + 1) & ","
		//    pszgblsql = pszgblsql & " emp_usu_cam = '" & sgUserID & "'"
		//    pszgblsql = pszgblsql & " where eje_prefijo = " & gdteEjecutivo.EjeProductoPRD.PrefijoL
		//    pszgblsql = pszgblsql & " and gpo_banco = " & gdteEjecutivo.EjeProductoPRD.BancoL
		//    pszgblsql = pszgblsql & " and emp_num = " & gdteEjecutivo.EjeEmpNumL
		//
		//    If Modifica_Registro Then
		//        fncActualizaConsecutivoB = True
		//        Screen.MousePointer = vbDefault
		//        Exit Function
		//    Else
		//        Select Case ipTipoAltaEjecutivo
		//            Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//                MsgBox "No se pudo modificar el consecutivo de ejecutivo de la empresa: " & gdteEjecutivo.EjeEmpNumL, vbCritical + vbOKOnly, "Tarjeta Corporativa"
		//        End Select
		//        fncActualizaConsecutivoB = False
		//        Screen.MousePointer = vbDefault
		//        Exit Function
		//    End If
		//
		//Exit Function
		//ErrActualizaConsecutivo:
		//    Select Case ipTipoAltaEjecutivo
		//        Case taejAltaIndividual
		//            prObtenError "mdlEjecutivo (ActualizaConsecutivo)"
		//    End Select
		//    fncActualizaConsecutivoB = False
		//    Screen.MousePointer = vbDefault
		//    Exit Function
		//End Function
		//
		//Public Sub prActualizaEstatus(ipTipoAltaEjecutivo As enuTipoAltaEjecutivo, lpEstatus As Long)
		//
		//On Error GoTo ErrActualizaEstatus
		//
		//    Screen.MousePointer = vbHourglass
		//
		//    Select Case ipTipoAltaEjecutivo
		//        Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//            Select Case lpEstatus
		//                Case 3
		//                    pszgblsql = "update MTCIND01"
		//                    pszgblsql = pszgblsql & " set eje_num = " & gdteEjecutivo.EjeNumL
		//                    pszgblsql = pszgblsql & " ,eje_digit = " & gdteEjecutivo.EjeDigitI
		//                    pszgblsql = pszgblsql & " ,eje_status_reg = " & lpEstatus
		//                    pszgblsql = pszgblsql & " where eje_prefijo = " & gdteEjecutivo.EjeProductoPRD.PrefijoL
		//                    pszgblsql = pszgblsql & " and gpo_banco = " & gdteEjecutivo.EjeProductoPRD.BancoL
		//                    pszgblsql = pszgblsql & " and emp_num = " & gdteEjecutivo.EjeEmpNumL
		//                    pszgblsql = pszgblsql & " and eje_rfc = '" & gdteEjecutivo.EjeRfcRFC.RFCS & "'"
		//
		//                Case Else
		//                    pszgblsql = "update MTCIND01"
		//                    pszgblsql = pszgblsql & " set eje_status_reg = " & lpEstatus
		//                    pszgblsql = pszgblsql & " where eje_prefijo = " & gdteEjecutivo.EjeProductoPRD.PrefijoL
		//                    pszgblsql = pszgblsql & " and gpo_banco = " & gdteEjecutivo.EjeProductoPRD.BancoL
		//                    pszgblsql = pszgblsql & " and emp_num = " & gdteEjecutivo.EjeEmpNumL
		//                    pszgblsql = pszgblsql & " and eje_nom_gra = '" & gdteEjecutivo.EjeNomGrabaS & "'"
		//                    pszgblsql = pszgblsql & " and eje_rfc = '" & gdteEjecutivo.EjeRfcRFC.RFCS & "'"
		//            End Select
		//
		//            If Modifica_Registro Then
		//                Screen.MousePointer = vbDefault
		//                Exit Sub
		//            Else
		//                MsgBox "No se actualizo el estatus del Ejecutivo en la tabla de Respaldo", vbCritical + vbOKOnly, "Tarjeta Corporativa"
		//                Screen.MousePointer = vbDefault
		//                Exit Sub
		//            End If
		//
		//        Case taejAltaMasiva         '***** ALTA MASIVA *****
		//            Select Case lpEstatus
		//                Case 3
		//                    pszgblsql = "update MTCMSV01"
		//                    pszgblsql = pszgblsql & " set eje_num = " & gdteEjecutivo.EjeNumL
		//                    pszgblsql = pszgblsql & " ,eje_digit = " & gdteEjecutivo.EjeDigitI
		//                    pszgblsql = pszgblsql & " ,eje_status_reg = " & lpEstatus
		//                    pszgblsql = pszgblsql & " where eje_prefijo = " & gdteEjecutivo.EjeProductoPRD.PrefijoL
		//                    pszgblsql = pszgblsql & " and gpo_banco = " & gdteEjecutivo.EjeProductoPRD.BancoL
		//                    pszgblsql = pszgblsql & " and emp_num = " & gdteEjecutivo.EjeEmpNumL
		//                    pszgblsql = pszgblsql & " and eje_rfc = '" & gdteEjecutivo.EjeRfcRFC.RFCS & "'"
		//
		//                Case Else
		//                    pszgblsql = "update MTCMSV01"
		//                    pszgblsql = pszgblsql & " set eje_status_reg = " & lpEstatus
		//                    pszgblsql = pszgblsql & " where eje_prefijo = " & gdteEjecutivo.EjeProductoPRD.PrefijoL
		//                    pszgblsql = pszgblsql & " and gpo_banco = " & gdteEjecutivo.EjeProductoPRD.BancoL
		//                    pszgblsql = pszgblsql & " and emp_num = " & gdteEjecutivo.EjeEmpNumL
		//                    pszgblsql = pszgblsql & " and eje_nom_gra = '" & gdteEjecutivo.EjeNomGrabaS & "'"
		//                    pszgblsql = pszgblsql & " and eje_rfc = '" & gdteEjecutivo.EjeRfcRFC.RFCS & "'"
		//            End Select
		//
		//            If Modifica_Registro Then
		//                Screen.MousePointer = vbDefault
		//                Exit Sub
		//            End If
		//    End Select
		//
		//    Screen.MousePointer = vbDefault
		//
		//Exit Sub
		//ErrActualizaEstatus:
		//    Select Case ipTipoAltaEjecutivo
		//        Case taejAltaIndividual
		//            prObtenError "mdlEjecutivo (ActualizaEstatus)"
		//    End Select
		//    Screen.MousePointer = vbDefault
		//    Exit Sub
		//End Sub
		//
		//Private Function fncGrabaTablaRespB(ipTipoAltaEjecutivo As enuTipoAltaEjecutivo) As Boolean
		//
		//On Error GoTo ErrGrabaTablaResp
		//
		//    Screen.MousePointer = vbHourglass
		//
		//    Select Case ipTipoAltaEjecutivo
		//        Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//            pszgblsql = "insert into MTCIND01 "
		//            pszgblsql = pszgblsql & "(eje_prefijo,"
		//            pszgblsql = pszgblsql & "gpo_banco,"
		//            pszgblsql = pszgblsql & "emp_num,"
		//            pszgblsql = pszgblsql & "eje_roll_over,"
		//            pszgblsql = pszgblsql & "eje_nombre,"
		//            pszgblsql = pszgblsql & "eje_rfc,"
		//            pszgblsql = pszgblsql & "eje_sueldo,"
		//            pszgblsql = pszgblsql & "eje_num_nom,"
		//            pszgblsql = pszgblsql & "eje_centro_c,"
		//            pszgblsql = pszgblsql & "eje_nivel,"
		//            pszgblsql = pszgblsql & "eje_nom_gra,"
		//            pszgblsql = pszgblsql & "eje_calle,"
		//            pszgblsql = pszgblsql & "eje_col,"
		//            pszgblsql = pszgblsql & "eje_pob,"
		//            pszgblsql = pszgblsql & "eje_edo,"
		//            pszgblsql = pszgblsql & "eje_zp,"
		//            pszgblsql = pszgblsql & "eje_cp,"
		//            pszgblsql = pszgblsql & "eje_tel_dom,"
		//            pszgblsql = pszgblsql & "eje_tel_ofi,"
		//            pszgblsql = pszgblsql & "eje_ext,"
		//            pszgblsql = pszgblsql & "eje_fax,"
		//            pszgblsql = pszgblsql & "eje_limcred,"
		//            pszgblsql = pszgblsql & "reg_num,"
		//            pszgblsql = pszgblsql & "eje_status,"
		//            pszgblsql = pszgblsql & "eje_cuenta_bnx,"
		//            pszgblsql = pszgblsql & "eje_sexo,"
		//            pszgblsql = pszgblsql & "eje_suc_trans,"
		//            pszgblsql = pszgblsql & "eje_suc_prom,"
		//            pszgblsql = pszgblsql & "eje_origen,"
		//            pszgblsql = pszgblsql & "eje_acti_subacti,"
		//            pszgblsql = pszgblsql & "eje_dom_calle,"
		//            pszgblsql = pszgblsql & "eje_dom_col,"
		//            pszgblsql = pszgblsql & "eje_dom_ciu,"
		//            pszgblsql = pszgblsql & "eje_dom_pob,"
		//            pszgblsql = pszgblsql & "eje_dom_edo,"
		//            pszgblsql = pszgblsql & "eje_dom_cp,"
		//            pszgblsql = pszgblsql & "eje_email,"
		//            pszgblsql = pszgblsql & "eje_cta_contable,"
		//            pszgblsql = pszgblsql & "eje_gen_pin_pla,"
		//            pszgblsql = pszgblsql & "eje_lim_dis_efec,"
		//            pszgblsql = pszgblsql & "eje_tipo_cuenta,"
		//            pszgblsql = pszgblsql & "eje_tipo_fac,"
		//            pszgblsql = pszgblsql & "eje_skip_payment,"
		//            pszgblsql = pszgblsql & "eje_tabla_mcc,"
		//            pszgblsql = pszgblsql & "eje_ind_lim_disp,"
		//            pszgblsql = pszgblsql & "eje_ind_cta_ctrl,"
		//            pszgblsql = pszgblsql & "eje_nacionalidad,"
		//            pszgblsql = pszgblsql & "eje_status_reg) "
		//            pszgblsql = pszgblsql & "values (" & gdteEjecutivo.EjeProductoPRD.PrefijoL
		//            pszgblsql = pszgblsql & "," & gdteEjecutivo.EjeProductoPRD.BancoL
		//            pszgblsql = pszgblsql & "," & gdteEjecutivo.EjeEmpNumL
		//            pszgblsql = pszgblsql & "," & gdteEjecutivo.EjeRolloverI
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeNomS & "'"
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeRfcRFC.RFCS & "'"
		//            pszgblsql = pszgblsql & "," & gdteEjecutivo.EjeSueldoL
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeNumNomS & "'"
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeCentroCostS & "'"
		//            pszgblsql = pszgblsql & "," & gdteEjecutivo.EjeNivelI
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeNomGrabaS & "'"
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeDomEnvioDMC.DomicilioS & "'"
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeDomEnvioDMC.ColoniaS & "'"
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeDomEnvioDMC.PoblacionS & "'"
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeDomEnvioDMC.EstadoEST.AbreviaturaS & "'"
		//            pszgblsql = pszgblsql & ",0"
		//            pszgblsql = pszgblsql & "," & gdteEjecutivo.EjeDomEnvioDMC.CPL
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeTelDomS & "'"
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeTelOfiS & "'"
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeExtensionS & "'"
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeFaxS & "'"
		//            pszgblsql = pszgblsql & "," & gdteEjecutivo.EjeLimCredL
		//            pszgblsql = pszgblsql & "," & gdteEjecutivo.EjeRegNumL
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeEstatusS & "'"
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeCuentaBnxS & "'"
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeSexoS & "'"
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeSucTransS & "'"
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeSucPromS & "'"
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeOrigenS & "'"
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeActiSubactiS & "'"
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeDomPartDMC.DomicilioS & "'"
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeDomPartDMC.ColoniaS & "'"
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeDomPartDMC.CiudadS & "'"
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeDomPartDMC.PoblacionS & "'"
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeDomPartDMC.EstadoEST.AbreviaturaS & "'"
		//            pszgblsql = pszgblsql & "," & gdteEjecutivo.EjeDomPartDMC.CPL
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeEmailS & "'"
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeCtaContableS & "'"
		//            pszgblsql = pszgblsql & "," & gdteEjecutivo.EjeGenPinPlaI
		//            pszgblsql = pszgblsql & "," & gdteEjecutivo.EjeLimDisEfecL
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeTipoCuentaS & "'"
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeTipoFactS & "'"
		//            pszgblsql = pszgblsql & "," & gdteEjecutivo.EjeSkipPaymentL
		//            pszgblsql = pszgblsql & "," & gdteEjecutivo.EjeTablaMCCL
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeIndLimDispS & "'"
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeIndCtaCtrlS & "'"
		//            pszgblsql = pszgblsql & ",'" & gdteEjecutivo.EjeNacionalidadS & "'"
		//            pszgblsql = pszgblsql & ",0)"
		//
		//            If Modifica_Registro Then
		//                fncGrabaTablaRespB = True
		//                Screen.MousePointer = vbDefault
		//                Exit Function
		//            Else
		//                MsgBox "No se pudo insertar el registro en la tabla de respaldo", vbCritical + vbOKOnly, "Tarjeta Corporativa"
		//                fncGrabaTablaRespB = False
		//                Screen.MousePointer = vbDefault
		//                Exit Function
		//            End If
		//    End Select
		//
		//    Screen.MousePointer = vbDefault
		//
		//Exit Function
		//ErrGrabaTablaResp:
		//    prObtenError "mdlEjecutivo (GrabaTablaResp)"
		//    fncGrabaTablaRespB = False
		//    Screen.MousePointer = vbDefault
		//    Exit Function
		//End Function
		//
		//Private Function fncObtenEjeNumB(ipTipoAltaEjecutivo As enuTipoAltaEjecutivo) As Boolean
		//
		//Dim slCuenta As String
		//
		//On Error GoTo ErrObtenEjeNum
		//
		//    Screen.MousePointer = vbHourglass
		//
		//    pszgblsql = "select"
		//    pszgblsql = pszgblsql & " emp_con_eje"
		//    pszgblsql = pszgblsql & " from MTCEMP01"
		//    pszgblsql = pszgblsql & " where eje_prefijo = " & gdteEjecutivo.EjeProductoPRD.PrefijoL
		//    pszgblsql = pszgblsql & " and gpo_banco = " & gdteEjecutivo.EjeProductoPRD.BancoL
		//    pszgblsql = pszgblsql & " and emp_num = " & gdteEjecutivo.EjeEmpNumL
		//
		//    If Obtiene_Registros Then
		//        Do Until SqlNextRow(hgblConexion) = NOMOREROWS
		//            gdteEjecutivo.EjeNumL = CLng(SqlData(hgblConexion, 1))
		//        Loop
		//    Else
		//        Select Case ipTipoAltaEjecutivo
		//            Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//                MsgBox "No se logro obtener el consecutivo de la empresa: " & Format(gdteEjecutivo.EjeEmpNumL, gdteEjecutivo.EjeProductoPRD.MascaraEmpresaS), vbInformation + vbOKOnly, App.Title
		//        End Select
		//        fncObtenEjeNumB = False
		//        Screen.MousePointer = vbDefault
		//        Exit Function
		//    End If
		//    igblRetorna = SqlCancel(hgblConexion)
		//
		//    slCuenta = Trim(Format(gdteEjecutivo.EjeProductoPRD.PrefijoL, gdteEjecutivo.EjeProductoPRD.MascaraPrefijoS) & '                    Format(gdteEjecutivo.EjeProductoPRD.BancoL, gdteEjecutivo.EjeProductoPRD.MascaraBancoS) & '                    Format(gdteEjecutivo.EjeEmpNumL, gdteEjecutivo.EjeProductoPRD.MascaraEmpresaS) & '                    Format(gdteEjecutivo.EjeNumL, gdteEjecutivo.EjeProductoPRD.MascaraEjecutivoS) & '                    gdteEjecutivo.EjeRolloverI)
		//
		//    gdteEjecutivo.EjeDigitI = Calcula_digito_verif(slCuenta)
		//    fncObtenEjeNumB = True
		//
		//    Screen.MousePointer = vbDefault
		//
		//Exit Function
		//ErrObtenEjeNum:
		//    Select Case ipTipoAltaEjecutivo
		//        Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//            prObtenError "mdlEjecutivo (ObtenEjeNum)"
		//    End Select
		//    fncObtenEjeNumB = False
		//    Screen.MousePointer = vbDefault
		//    Exit Function
		//End Function
		//
		//Private Function fncVerificaCreditoB() As Boolean
		//
		//On Error GoTo ErrVerificaCredito
		//
		//    Screen.MousePointer = vbHourglass
		//
		//    If gdteEjecutivo.EjeProductoPRD.PrefijoL = 4943 And gdteEjecutivo.EjeProductoPRD.BancoL = 88 Then
		//        fncVerificaCreditoB = True
		//        Screen.MousePointer = vbDefault
		//        Exit Function
		//    Else
		//        If (lmEmpCredAcum + gdteEjecutivo.EjeLimCredL) > lmEmpCredTot Then
		//            fncVerificaCreditoB = False
		//            MsgBox "Se ha sobrepasado el crédito de la Empresa." & vbCrLf & '                    "Crédito dispuesto: " & Str(lmEmpCredTot - lmEmpCredAcum), vbInformation + vbOKOnly, App.Title
		//            Screen.MousePointer = vbDefault
		//            Exit Function
		//        Else
		//            fncVerificaCreditoB = True
		//            Screen.MousePointer = vbDefault
		//            Exit Function
		//        End If
		//    End If
		//
		//    Screen.MousePointer = vbDefault
		//
		//Exit Function
		//ErrVerificaCredito:
		//    prObtenError "mdlEjecutivo (VerificaCredito)"
		//    fncVerificaCreditoB = False
		//    Screen.MousePointer = vbDefault
		//    Exit Function
		//End Function
		//
		//Private Function fncExcepcionCreditoB() As Boolean
		//
		//On Error GoTo ErrExcepcionCredito
		//
		//    If gdteEjecutivo.EjeProductoPRD.PrefijoL = 4943 And gdteEjecutivo.EjeProductoPRD.BancoL = 88 Then
		//        fncExcepcionCreditoB = True
		//    Else
		//        fncExcepcionCreditoB = False
		//    End If
		//
		//Exit Function
		//ErrExcepcionCredito:
		//    prObtenError "mdlEjecutivo (ExcepcionCredito)"
		//    Exit Function
		//End Function
		//
		//Public Sub prObtenCredEmp()
		//
		//On Error GoTo ErrObtenCredEmp
		//
		//    Screen.MousePointer = vbHourglass
		//
		//    pszgblsql = "select"
		//    pszgblsql = pszgblsql & " emp_cred_tot,"
		//    pszgblsql = pszgblsql & " emp_acum_cred"
		//    pszgblsql = pszgblsql & " from MTCEMP01"
		//    pszgblsql = pszgblsql & " where eje_prefijo = " & gdteEjecutivo.EjeProductoPRD.PrefijoL
		//    pszgblsql = pszgblsql & " and gpo_banco = " & gdteEjecutivo.EjeProductoPRD.BancoL
		//    pszgblsql = pszgblsql & " and emp_num = " & gdteEjecutivo.EjeEmpNumL
		//
		//    If Obtiene_Registros Then
		//        Do Until SqlNextRow(hgblConexion) = NOMOREROWS
		//            lmEmpCredTot = CLng(SqlData(hgblConexion, 1))
		//            lmEmpCredAcum = CLng(SqlData(hgblConexion, 2))
		//        Loop
		//    End If
		//    igblRetorna = SqlCancel(hgblConexion)
		//
		//    Screen.MousePointer = vbDefault
		//
		//Exit Sub
		//ErrObtenCredEmp:
		//    prObtenError "mdlEjecutivo (ObtenCredEmp)"
		//    lmEmpCredTot = 0
		//    lmEmpCredAcum = 0
		//    Screen.MousePointer = vbDefault
		//    Exit Sub
		//End Sub
		//
		//Public Function fncValidaInfB() As Boolean
		//
		//On Error GoTo ErrValidaInf
		//
		//    Screen.MousePointer = vbHourglass
		//
		//    If Trim(gdteEjecutivo.EjeNomS) = "" Then
		//        fncValidaInfB = False
		//        smValidaInf = "NOMBRE DEL EJECUTIVO"
		//        Screen.MousePointer = vbDefault
		//        Exit Function
		//    ElseIf Trim(gdteEjecutivo.EjeNomGrabaS) = "" Then
		//        fncValidaInfB = False
		//        smValidaInf = "NOMBRE DE GRABACIÓN"
		//        Screen.MousePointer = vbDefault
		//        Exit Function
		//    ElseIf Trim(gdteEjecutivo.EjeRfcRFC.RFCS) = "" Then
		//        fncValidaInfB = False
		//        smValidaInf = "RFC"
		//        Screen.MousePointer = vbDefault
		//        Exit Function
		//    ElseIf Trim(gdteEjecutivo.EjeLimCredL) = "" Then
		//        fncValidaInfB = False
		//        smValidaInf = "LIMITE DE CREDITO INCORRECTO"
		//        Screen.MousePointer = vbDefault
		//        Exit Function
		//    ElseIf Trim(gdteEjecutivo.EjeSexoS) = "" Then
		//        fncValidaInfB = False
		//        smValidaInf = "SEXO"
		//        Screen.MousePointer = vbDefault
		//        Exit Function
		//    ElseIf Trim(gdteEjecutivo.EjeDomEnvioDMC.DomicilioS) = "" Then
		//        fncValidaInfB = False
		//        smValidaInf = "CALLE Y NÚMERO"
		//        Screen.MousePointer = vbDefault
		//        Exit Function
		//    ElseIf Trim(gdteEjecutivo.EjeDomEnvioDMC.ColoniaS) = "" Then
		//        fncValidaInfB = False
		//        smValidaInf = "COLONIA"
		//        Screen.MousePointer = vbDefault
		//        Exit Function
		//    ElseIf Trim(gdteEjecutivo.EjeDomEnvioDMC.PoblacionS) = "" Then
		//        fncValidaInfB = False
		//        smValidaInf = "POBLACIÓN"
		//        Screen.MousePointer = vbDefault
		//        Exit Function
		//    ElseIf Trim(gdteEjecutivo.EjeDomEnvioDMC.EstadoEST.EstadoS) = "" Then
		//        fncValidaInfB = False
		//        smValidaInf = "ESTADO"
		//        Screen.MousePointer = vbDefault
		//        Exit Function
		//    ElseIf Trim(gdteEjecutivo.EjeDomEnvioDMC.CPL) = "" Then
		//        fncValidaInfB = False
		//        smValidaInf = "CÓDIGO POSTAL"
		//        Screen.MousePointer = vbDefault
		//        Exit Function
		//    ElseIf Trim(gdteEjecutivo.EjeTelOfiS) = "" Then
		//        fncValidaInfB = False
		//        smValidaInf = "TEL. OFICINA"
		//        Screen.MousePointer = vbDefault
		//        Exit Function
		//    End If
		//
		//    fncValidaInfB = True
		//
		//    Screen.MousePointer = vbDefault
		//
		//Exit Function
		//ErrValidaInf:
		//    prObtenError "mdlEjecutivo (ValidaInf)"
		//    fncValidaInfB = False
		//    Screen.MousePointer = vbDefault
		//    Exit Function
		//End Function
		//
		//Public Function fncValidarConsecutivoB() As Boolean
		//
		//Dim llConsecutivo As Long
		//Dim llConsecutivoTope As Long
		//
		//On Error GoTo ErrValidarConsecutivo
		//
		//    Screen.MousePointer = vbHourglass
		//
		//    pszgblsql = "select"
		//    pszgblsql = pszgblsql & " emp_con_eje"
		//    pszgblsql = pszgblsql & " from MTCEMP01"
		//    pszgblsql = pszgblsql & " where eje_prefijo = " & gdteEjecutivo.EjeProductoPRD.PrefijoL
		//    pszgblsql = pszgblsql & " and gpo_banco = " & gdteEjecutivo.EjeProductoPRD.BancoL
		//    pszgblsql = pszgblsql & " and emp_num = " & gdteEjecutivo.EjeEmpNumL
		//
		//    If Obtiene_Registros Then
		//        Do Until SqlNextRow(hgblConexion) = NOMOREROWS
		//            llConsecutivo = CLng(SqlData(hgblConexion, 1)) - 1
		//            llConsecutivoTope = CLng(String(gdteEjecutivo.EjeProductoPRD.LongitudEjecutivoI, "9"))
		//        Loop
		//    End If
		//    igblRetorna = SqlCancel(hgblConexion)
		//
		//    If llConsecutivo >= llConsecutivoTope Then
		//        fncValidarConsecutivoB = False
		//        MsgBox "Se deberá crear una nueva empresa para los siguientes ejecutivos." & vbCrLf & '                "Se ha llegado al límite de " & llConsecutivoTope + 1 & " tarjetahabientes.", vbInformation + vbOKOnly, App.Title
		//        Screen.MousePointer = vbDefault
		//        Exit Function
		//    Else
		//        fncValidarConsecutivoB = True
		//        Screen.MousePointer = vbDefault
		//        Exit Function
		//    End If
		//
		//    Screen.MousePointer = vbDefault
		//
		//Exit Function
		//ErrValidarConsecutivo:
		//    prObtenError "mdlEjecutivo ValidarConsecutivo"
		//    fncValidarConsecutivoB = False
		//    Screen.MousePointer = vbDefault
		//    Exit Function
		//End Function
		//
		//Public Sub prLlenaCentroC(ctrlpControl As Control)
		//
		//Dim llRegistros     As Long
		//Dim slCentroC       As String
		//Dim slCentroName    As String
		//Dim llCont          As Long
		//Dim cmblCombo       As ComboBox
		//
		//On Error GoTo ErrLlenaCentroC
		//
		//    Set cmblCombo = ctrlpControl
		//    cmblCombo.Clear
		//
		//    pszgblsql = "select"
		//    pszgblsql = pszgblsql & " unit_id,"
		//    pszgblsql = pszgblsql & " unit_name"
		//    pszgblsql = pszgblsql & " from MTCUNI01"
		//    pszgblsql = pszgblsql & " where eje_prefijo = " & gprdProducto.PrefijoL
		//    pszgblsql = pszgblsql & " and gpo_banco = " & gprdProducto.BancoL
		//    pszgblsql = pszgblsql & " and emp_num = " & lgblEmpCve
		//
		//    If Obtiene_Registros Then
		//        Do Until SqlNextRow(hgblConexion) = NOMOREROWS
		//            slCentroC = Trim(SqlData(hgblConexion, 1))
		//            slCentroName = Trim(SqlData(hgblConexion, 2))
		//            cmblCombo.AddItem slCentroC & Space(3) & slCentroName
		//        Loop
		//        cmblCombo.ListIndex = 0
		//    End If
		//    igblRetorna = SqlCancel(hgblConexion)
		//
		//Exit Sub
		//ErrLlenaCentroC:
		//    prObtenError "mdlEjecutivo (LlenaCentroC)"
		//    Exit Sub
		//End Sub
		//
		static public string fncCuentaPadreS( int lpPrefijo,  int lpBanco,  int lpEmpresa)
		{
			string result = String.Empty;
			string slCuenta = String.Empty;
			ADODB.Recordset adorst = null;
			string strCuentaPadre = String.Empty;
			string strCuentaCiti = String.Empty;
			
			try
			{
					
					result = "000000000000000";
					
					if (VBSQL.OpenConn(10) != 0)
					{
						VBSQL.gConn[10].Close();
					} else
					{
						VBSQL.gConn[10].Close();
					}
					
					if (VBSQL.OpenConn(10) == 0)
					{
						adorst = new ADODB.Recordset();
						
						CORVAR.pszgblsql = "select convert(char(4), c.eje_prefijo) + ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "convert(char(2),c.gpo_banco) + ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "replicate ('0', (select i.pgs_long_emp from MTCPGS01 i ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "Where i.pgs_rep_prefijo = c.eje_prefijo ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "and i.pgs_rep_banco = c.gpo_banco) - char_length(ltrim(rtrim(str(c.emp_num))))) + ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "ltrim(rtrim(str(c.emp_num))) + ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "replicate ('0', (select i.pgs_long_eje from MTCPGS01 i ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "Where i.pgs_rep_prefijo = c.eje_prefijo ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "and i.pgs_rep_banco = c.gpo_banco) - char_length(ltrim(rtrim(str(c.eje_num))))) + ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "ltrim(rtrim(str(c.eje_num))) + convert(char(1),c.eje_roll_over) + ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "convert(char(1),c.eje_digit) as Cta ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "From  MTCEJE01 c  Where c.eje_prefijo = " + lpPrefijo.ToString() + " and c.gpo_banco = " + lpBanco.ToString();
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.emp_num = " + lpEmpresa.ToString() + " and c.eje_num = 0";
						
						adorst.Open(CORVAR.pszgblsql, VBSQL.gConn[10], ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, -1);
						
						if (! adorst.EOF && ! adorst.BOF)
						{
							strCuentaPadre = Convert.ToString(adorst.Fields["Cta"].Value);
						}
						
						adorst.Close();
						
						CORVAR.pszgblsql = "select map_cta_citi ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "From MTCMAP01  where map_cta_bnx = '" + strCuentaPadre + "' ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and map_estatus = ''";
						
						
						adorst.Open(CORVAR.pszgblsql, VBSQL.gConn[10], ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, -1);
						
						if (! adorst.EOF && ! adorst.BOF)
						{
							strCuentaCiti = Convert.ToString(adorst.Fields["map_cta_citi"].Value);
						}
						
						adorst.Close();
						adorst = null;
						
						if (strCuentaCiti == "")
						{
							result = strCuentaPadre;
						} else
						{
							result = strCuentaCiti;
						}
						
						if (VBSQL.gConn[10].State == 1)
						{
							VBSQL.gConn[10].Close();
						}
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("mdlEjecutivo (CuentaPadre)",e );
				if (adorst.State != 0)
				{
					adorst.Close();
				}
				
				if (VBSQL.gConn[10].State != ((int) ADODB.ObjectStateEnum.adStateClosed))
				{
					VBSQL.gConn[10].Close();
				}
				
				return result;
			}
			
			return result;
		}
		//
		//Public Function fncVerificaNombreB(spEjeNom As String) As Boolean
		//
		//Dim ilCont
		//Dim slCaracter As String * 1
		//Dim blDiagonal As Boolean
		//Dim blComa As Boolean
		//Dim ilPosComa As Integer
		//Dim ilPosDiag As Integer
		//
		//On Error Resume Next
		//
		//    blComa = False
		//    blDiagonal = False
		//
		//    For ilCont = 1 To Len(spEjeNom)
		//        slCaracter = Mid(spEjeNom, ilCont, 1)
		//        If slCaracter = "," Then
		//            blComa = True
		//        End If
		//        If blComa = True And slCaracter = "/" Then
		//            blDiagonal = True
		//            Exit For
		//        End If
		//    Next
		//
		//    If blDiagonal Then
		//        ilPosComa = InStr(spEjeNom, ",")
		//        ilPosDiag = InStr(spEjeNom, "/")
		//        If ilPosDiag - ilPosComa <= 1 Then
		//            spEjeNom = Trim(Mid(spEjeNom, 1, ilPosComa - 1)) & ",/" & Trim(Mid(spEjeNom, ilPosDiag + 1))
		//        Else
		//            spEjeNom = Trim(Mid(spEjeNom, 1, ilPosComa - 1)) & "," & Trim(Mid(spEjeNom, ilPosComa + 1, ilPosDiag - ilPosComa - 1)) & "/" & Trim(Mid(spEjeNom, ilPosDiag + 1))
		//        End If
		//    End If
		//    frmEjecutivo.txtEjecutivos(3).Text = spEjeNom
		//    fncVerificaNombreB = blDiagonal
		//
		//End Function
		//
		//Public Function fncObtenValoresEjecutivoB(ipTipoConsulta As enuTipoConsultaEjecutivo) As Boolean
		//
		//Dim ilIndice As Integer
		//
		//On Error GoTo ErrObtenValoresEjecutivo
		//
		//    Select Case ipTipoConsulta
		//        Case tcneConsultaAlta
		//
		//            pszgblsql = "select"
		//            pszgblsql = pszgblsql & " emp_tipo_envio"
		//            pszgblsql = pszgblsql & ", emp_envio_calle"
		//            pszgblsql = pszgblsql & ", emp_envio_col"
		//            pszgblsql = pszgblsql & ", emp_envio_pob"
		//            pszgblsql = pszgblsql & ", emp_envio_edo"
		//            pszgblsql = pszgblsql & ", emp_envio_cp"
		//            pszgblsql = pszgblsql & ", emp_sector"
		//            pszgblsql = pszgblsql & ", emp_skip_payment"
		//            pszgblsql = pszgblsql & ", emp_tabla_mcc"
		//            pszgblsql = pszgblsql & ", emp_tipo_fac "
		//            pszgblsql = pszgblsql & ", emp_tipo_producto "
		//            pszgblsql = pszgblsql & ", emp_dia_corte"
		//            pszgblsql = pszgblsql & " from MTCEMP01"
		//            pszgblsql = pszgblsql & " where eje_prefijo = " & gdteEjecutivo.EjeProductoPRD.PrefijoL
		//            pszgblsql = pszgblsql & " and gpo_banco = " & gdteEjecutivo.EjeProductoPRD.BancoL
		//            pszgblsql = pszgblsql & " and emp_num = " & gdteEjecutivo.EjeEmpNumL
		//
		//            If Obtiene_Registros Then
		//                Do Until SqlNextRow(hgblConexion) = NOMOREROWS
		//                    gdteEjecutivo.EjeEmpTipoEnvioS = CStr(SqlData(hgblConexion, 1))
		//                    gdteEjecutivo.EjeDomEnvioDMC.DomicilioS = CStr(SqlData(hgblConexion, 2))
		//                    gdteEjecutivo.EjeDomEnvioDMC.ColoniaS = CStr(SqlData(hgblConexion, 3))
		//                    gdteEjecutivo.EjeDomEnvioDMC.PoblacionS = CStr(SqlData(hgblConexion, 4))
		//                    ilIndice = gcestEstado.fncBuscaEstadoI(CStr(SqlData(hgblConexion, 5)))
		//                    Set gdteEjecutivo.EjeDomEnvioDMC.EstadoEST = gcestEstado.Item(ilIndice)
		//                    gdteEjecutivo.EjeDomEnvioDMC.CPL = CLng(SqlData(hgblConexion, 6))
		//                    gdteEjecutivo.EjeEmpSectorI = CInt(SqlData(hgblConexion, 7))
		//                    gdteEjecutivo.EjeSkipPaymentL = CLng(SqlData(hgblConexion, 8))
		//                    gdteEjecutivo.EjeTablaMCCL = CLng(SqlData(hgblConexion, 9))
		//                    gdteEjecutivo.EjeEmpTipoFactS = CStr(SqlData(hgblConexion, 10))
		//                    gdteEjecutivo.EjeEmpTipoProductoS = CStr(SqlData(hgblConexion, 11))
		//                    gdteEjecutivo.EjeDiaCorteI = CInt(SqlData(hgblConexion, 12))
		//                    fncObtenValoresEjecutivoB = True
		//                Loop
		//            Else
		//                fncObtenValoresEjecutivoB = False
		//                MsgBox "No se puede realizar el alta de Ejecutivos de la Empresa: " & gdteEjecutivo.EjeEmpNumL & "." & vbCrLf & _
		//'                        "Porque los datos de la Empresa son Incorrecto", vbInformation + vbOKOnly, "Tarjeta Corporativa Credito"
		//                Exit Function
		//            End If
		//
		//        Case tcneConsultaCambio
		//        Case tcneConsultaConsulta
		//    End Select
		//
		//Exit Function
		//ErrObtenValoresEjecutivo:
		//    prObtenError "mdlEjecutivo (ObtenValoresEjecutivo)"
		//    Exit Function
		//End Function
		//
		//Public Sub prLlenaSubActividad(ipSector As Integer)
		//
		//On Error GoTo ErrLlenaSubActividad
		//
		//    Select Case ipSector
		//        Case 1
		//            gdteEjecutivo.EjeActiSubactiS = Trim(Left(ctesSectorIndustrial, 2))
		//        Case 2
		//            gdteEjecutivo.EjeActiSubactiS = Trim(Left(ctesSectorComercial, 2))
		//        Case 3
		//            gdteEjecutivo.EjeActiSubactiS = Trim(Left(ctesSectorServicios, 2))
		//        Case 4
		//            gdteEjecutivo.EjeActiSubactiS = Trim(Left(ctesSectorFinanciero, 2))
		//        Case 5
		//            gdteEjecutivo.EjeActiSubactiS = Trim(Left(ctesSectorPublico, 2))
		//        Case 6
		//            gdteEjecutivo.EjeActiSubactiS = Trim(Left(ctesSectorGobFed, 2))
		//        Case 7
		//            gdteEjecutivo.EjeActiSubactiS = Trim(Left(ctesSectorGobEst, 2))
		//        Case 8
		//            gdteEjecutivo.EjeActiSubactiS = Trim(Left(ctesSectorOtros, 2))
		//    End Select
		//
		//Exit Sub
		//ErrLlenaSubActividad:
		//    prObtenError "mdlEjecutivo (LlenaSubActividad)"
		//    Exit Sub
		//End Sub
		
		static public bool fncObtenNominaPassB( int lpNomina,  string spPassword)
		{
			
			bool result = false;
			int ilEdo = 0;
			FixedLengthString slNomina = new FixedLengthString(4);
			FixedLengthString slPassword = new FixedLengthString(8);
			
			try
			{
					
					Cursor.Current = Cursors.WaitCursor;
					
					slNomina.Value = new string((char) 0, 4);
					slPassword.Value = new string((char) 255, 8);
					//AIS-1182 NGONZALEZ
					ilEdo = API.Encryption.iCompactaNomina(lpNomina, slNomina.Value);
                    //AIS-1182 NGONZALEZ
                    ilEdo = API.Encryption.iCompactaPasswd(spPassword, slPassword.Value);
					
					mdlParametros.tgCveAccesoConComdrive.NominaS = slNomina.Value;
					mdlParametros.tgCveAccesoConComdrive.ClaveS = slPassword.Value;
					
					result = true;
					
					Cursor.Current = Cursors.Default;
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("mdlEjecutivo (ObtenNominaPass)",e );
				result = false;
				Cursor.Current = Cursors.Default;
				return result;
			}
			
			return result;
		}
		
		static public string fncSucursalS( int lpPrefijo,  int lpBanco,  int lpEmpresa)
		{
			string result = String.Empty;
			string slCuenta = String.Empty;
			ADODB.Recordset adorst = null;
			
			try
			{
					
					if (VBSQL.OpenConn(10) != 0)
					{
						VBSQL.gConn[10].Close();
					} else
					{
						VBSQL.gConn[10].Close();
					}
					
					if (VBSQL.OpenConn(10) == 0)
					{
						adorst = new ADODB.Recordset();
						
						CORVAR.pszgblsql = "SELECT emp_sucur ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "FROM MTCEMP01 ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "WHERE eje_prefijo = " + lpPrefijo.ToString();
						CORVAR.pszgblsql = CORVAR.pszgblsql + "AND gpo_banco = " + lpBanco.ToString();
						CORVAR.pszgblsql = CORVAR.pszgblsql + "AND emp_num = " + lpEmpresa.ToString();
						
						adorst.Open(CORVAR.pszgblsql, VBSQL.gConn[10], ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, -1);
						
						if (! adorst.EOF && ! adorst.BOF)
						{
							result = Convert.ToString(adorst.Fields["emp_sucur"].Value);
						}
						
						adorst.Close();
						
						adorst = null;
						
						if (VBSQL.gConn[10].State == 1)
						{
							VBSQL.gConn[10].Close();
						}
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("mdlEjecutivo (Sucursal)",e );
				if (adorst.State != 0)
				{
					adorst.Close();
				}
				
				if (VBSQL.gConn[10].State != ((int) ADODB.ObjectStateEnum.adStateClosed))
				{
					VBSQL.gConn[10].Close();
				}
			}
			
			return result;
		}
	}
}