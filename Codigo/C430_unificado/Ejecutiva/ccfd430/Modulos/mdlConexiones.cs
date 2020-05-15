using Microsoft.VisualBasic; 
using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	class mdlConexiones
	{
	
		
		//'Variables para las conexiones
		//Global cnxConexionRut      As New Conexion
		
		public enum enuTipoConexion
		 {
			tcnxConexionRut = 0
		}
		
		public enum enuTipoSistema
		 {
			tsistSistemaC430 = 0 , //Sistema C430
			tsistSistemaS111 = 1 , //Sistema S111
			tsistSistemaS016 = 2 , //Sistema S016
			tsistSistemaTandem = 3 //Sistema TANDEM
		}
		
		//Public Function fncEnviaValidaDialogoB(ipTipoAltaEjecutivo As enuTipoAltaEjecutivo, ipTipoAlta As enuTipoAltaSistema) As Boolean
		//
		//Dim slRespMensaje           As String
		//Dim slClaveRespTransaccion  As String
		//Dim slClaveTransaccion      As String
		//Dim slRespuestaS111         As String
		//Dim slDescResp              As String
		//Dim ilRespuestaEnvio        As Integer
		//Dim slDialogo               As String
		//
		//On Error GoTo ErrValidaRespuestaDialogo
		//
		//    Screen.MousePointer = vbHourglass
		//
		//    Select Case ipTipoAlta
		//
		//        Case tasAltaS016        '***** ALTA S016 *****
		//            slDialogo = gdlgDialogoS016.DialogoS
		//            ilRespuestaEnvio = cnxConexionRut.RutReadWrite(slDialogo, "S753-CONALTAS")
		//            DoEvents
		//            cnxConexionRut.Termina_Conexion
		//            slRespMensaje = fncValorOmisionV(slDialogo, "")
		//            If ilRespuestaEnvio = 0 Then
		//                slClaveRespTransaccion = Mid(slRespMensaje, 32, 2)
		//                slClaveTransaccion = Mid(slRespMensaje, 34, 4)
		//                slRespuestaS111 = Mid(slRespMensaje, 38, 30)
		//                slDescResp = Trim(Mid(slRespMensaje, 50, 78))
		//
		//                If InStr(1, "0123456789", Mid(slClaveRespTransaccion, 1, 1)) = 0 Then
		//                    Select Case ipTipoAltaEjecutivo
		//                        Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//                            MsgBox "Existe un error de comunicaciones. Avise a sistemas", vbInformation + vbOKOnly, App.Title
		//                            fncEnviaValidaDialogoB = False
		//                            Screen.MousePointer = vbDefault
		//                        Case taejAltaMasiva         '***** ALTA MASIVA *****
		//                            fncEnviaValidaDialogoB = False
		//                            Screen.MousePointer = vbDefault
		//                    End Select
		//                End If
		//
		//                If (slClaveRespTransaccion = "04" Or slClaveRespTransaccion = "05") And slRespuestaS111 = NULL_STRING Then
		//                    slClaveRespTransaccion = "01"
		//                End If
		//
		//                Select Case slClaveRespTransaccion
		//                    Case "00"
		//                        Select Case ipTipoAltaEjecutivo
		//                            Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//                                fncEnviaValidaDialogoB = True
		//                                prActualizaEstatus taejAltaIndividual, 3
		//                                If Trim(slDescResp) <> "" Then
		//                                    MsgBox slDescResp, vbExclamation + vbOKOnly, "Respuesta del Sistema S016"
		//                                End If
		//                                Screen.MousePointer = vbDefault
		//
		//                            Case taejAltaMasiva         '***** ALTA MASIVA *****
		//                                fncEnviaValidaDialogoB = True
		//                                prActualizaEstatus taejAltaMasiva, 3
		//                                Screen.MousePointer = vbDefault
		//                        End Select
		//
		//                    Case "06"
		//                        Select Case ipTipoAltaEjecutivo
		//                            Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//                                If Trim(UCase(slDescResp)) <> "CONTRATO A DAR DE ALTA YA EXISTE" Then
		//                                    fncEnviaValidaDialogoB = False
		//                                    MsgBox slDescResp, vbCritical + vbOKOnly, "Respuesta del Sistema S016"
		//                                    Screen.MousePointer = vbDefault
		//                                Else
		//                                    If fncActualizaConsecutivoB(taejAltaIndividual) = True Then
		//                                        prActualizaEstatus taejAltaIndividual, 4
		//                                        fncEnviaValidaDialogoB = False
		//                                        Screen.MousePointer = vbDefault
		//                                    End If
		//                                End If
		//
		//                            Case taejAltaMasiva         '***** ALTA MASIVA *****
		//                                If Trim(UCase(slDescResp)) <> "CONTRATO A DAR DE ALTA YA EXISTE" Then
		//                                    fncEnviaValidaDialogoB = False
		//                                    Screen.MousePointer = vbDefault
		//                                Else
		//                                    If fncActualizaConsecutivoB(taejAltaMasiva) = True Then
		//                                        prActualizaEstatus taejAltaMasiva, 4
		//                                        fncEnviaValidaDialogoB = False
		//                                        Screen.MousePointer = vbDefault
		//                                    End If
		//                                End If
		//
		//                        End Select
		//
		//                    Case "07"
		//                        Select Case ipTipoAltaEjecutivo
		//                            Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//                                fncEnviaValidaDialogoB = False
		//                                MsgBox slDescResp, vbCritical + vbOKOnly, "Respuesta del Sistema S016"
		//                                Screen.MousePointer = vbDefault
		//
		//                            Case taejAltaMasiva         '***** ALTA MASIVA *****
		//                                fncEnviaValidaDialogoB = False
		//                                Screen.MousePointer = vbDefault
		//                        End Select
		//
		//                    Case "21"
		//                        Select Case ipTipoAltaEjecutivo
		//                            Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//                                fncEnviaValidaDialogoB = False
		//                                MsgBox slDescResp, vbCritical + vbOKOnly, "Respuesta del Sistema S016"
		//                                Screen.MousePointer = vbDefault
		//                            Case taejAltaMasiva         '***** ALTA MASIVA *****
		//                                fncEnviaValidaDialogoB = False
		//                                Screen.MousePointer = vbDefault
		//                        End Select
		//
		//                    Case Else
		//                        Select Case ipTipoAltaEjecutivo
		//                            Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//                                fncEnviaValidaDialogoB = False
		//                                MsgBox "Mensaje de respuesta del diálogo " & vbCrLf & fncObtenErrorDialogoS(Val(slClaveRespTransaccion), tsistSistemaTandem), vbCritical + vbOKOnly, "Tarjeta Corporativa"
		//                                Screen.MousePointer = vbDefault
		//                            Case taejAltaMasiva         '***** ALTA MASIVA *****
		//                                fncEnviaValidaDialogoB = False
		//                                MsgBox "Mensaje de respuesta del diálogo " & vbCrLf & fncObtenErrorDialogoS(Val(slClaveRespTransaccion), tsistSistemaTandem), vbCritical + vbOKOnly, "Tarjeta Corporativa"
		//                                Screen.MousePointer = vbDefault
		//                        End Select
		//                End Select
		//            Else
		//                Select Case ipTipoAltaEjecutivo
		//                    Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//                        fncEnviaValidaDialogoB = False
		//                        MsgBox "Existe un error en el TANDEM No.: " & " ilRespuestaEnvio " & vbCrLf & fncObtenErrorDialogoS(ilRespuestaEnvio, tsistSistemaTandem), vbInformation + vbOKOnly, "Tarjeta Corporativa"
		//                        Screen.MousePointer = vbDefault
		//                    Case taejAltaMasiva         '***** ALTA MASIVA *****
		//                        fncEnviaValidaDialogoB = False
		//                        Screen.MousePointer = vbDefault
		//                End Select
		//            End If
		//
		//        Case tasAltaS111        '***** ALTA S111 *****
		//
		//            slDialogo = gdlgDialogoS111.DialogoS
		//            ilRespuestaEnvio = cnxConexionRut.RutReadWrite(slDialogo, "S753-CONALTAS")
		//            DoEvents
		//            slRespMensaje = fncValorOmisionV(slDialogo, "")
		//            If ilRespuestaEnvio = 0 Then
		//                slClaveRespTransaccion = Mid(slRespMensaje, 32, 2)
		//                slClaveTransaccion = Mid(slRespMensaje, 34, 4)
		//                slRespuestaS111 = Mid(slRespMensaje, 38, 30)
		//                slDescResp = Trim(Mid(slRespMensaje, 50, 78))
		//
		//                If InStr(1, "0123456789", Mid(slClaveRespTransaccion, 1, 1)) = 0 Then
		//                    Select Case ipTipoAltaEjecutivo
		//                        Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//                            MsgBox "Existe un error de comunicaciones. Avise a sistemas", vbInformation + vbOKOnly, App.Title
		//                            If fncVerificaConsultaB(taejAltaIndividual, tasAltaS111) = True Then
		//                                prActualizaEstatus taejAltaIndividual, 9
		//                                fncEnviaValidaDialogoB = True
		//                                Screen.MousePointer = vbDefault
		//                                Exit Function
		//                            Else
		//                                fncEnviaValidaDialogoB = False
		//                                Screen.MousePointer = vbDefault
		//                                Exit Function
		//                            End If
		//
		//                        Case taejAltaMasiva         '***** ALTA MASIVA *****
		//                            If fncVerificaConsultaB(taejAltaMasiva, tasAltaS111) = True Then
		//                                prActualizaEstatus taejAltaMasiva, 9
		//                                fncEnviaValidaDialogoB = True
		//                                Screen.MousePointer = vbDefault
		//                                Exit Function
		//                            Else
		//                                fncEnviaValidaDialogoB = False
		//                                Screen.MousePointer = vbDefault
		//                                Exit Function
		//                            End If
		//                    End Select
		//                End If
		//
		//                If (slClaveRespTransaccion = "04" Or slClaveRespTransaccion = "05") And slRespuestaS111 = NULL_STRING Then
		//                    slClaveRespTransaccion = "01"
		//                End If
		//
		//                If Trim(slRespuestaS111) = "0030" Then
		//                    Select Case ipTipoAltaEjecutivo
		//                        Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//                            If fncVerificaConsultaB(taejAltaIndividual, tasAltaS111) = True Then
		//                                prActualizaEstatus taejAltaIndividual, 9
		//                                fncEnviaValidaDialogoB = True
		//                                Screen.MousePointer = vbDefault
		//                                Exit Function
		//                            Else
		//                                fncEnviaValidaDialogoB = False
		//                                Screen.MousePointer = vbDefault
		//                                Exit Function
		//                            End If
		//                        Case taejAltaMasiva         '***** ALTA MASIVA *****
		//                            If fncVerificaConsultaB(taejAltaMasiva, tasAltaS111) = True Then
		//                                prActualizaEstatus taejAltaMasiva, 9
		//                                fncEnviaValidaDialogoB = True
		//                                Screen.MousePointer = vbDefault
		//                                Exit Function
		//                            Else
		//                                fncEnviaValidaDialogoB = False
		//                                Screen.MousePointer = vbDefault
		//                                Exit Function
		//                            End If
		//                    End Select
		//                End If
		//
		//                Select Case slClaveRespTransaccion
		//                    Case "00"
		//                        Select Case ipTipoAltaEjecutivo
		//                            Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//                                prActualizaEstatus taejAltaIndividual, 7
		//                                If fncVerificaConsultaB(taejAltaIndividual, tasAltaS111) = True Then
		//                                    prActualizaEstatus taejAltaIndividual, 9
		//                                    fncEnviaValidaDialogoB = True
		//                                    Screen.MousePointer = vbDefault
		//                                    Exit Function
		//                                Else
		//                                    fncEnviaValidaDialogoB = False
		//                                    Screen.MousePointer = vbDefault
		//                                    Exit Function
		//                                End If
		//                            Case taejAltaMasiva         '***** ALTA MASIVA *****
		//                                prActualizaEstatus taejAltaMasiva, 7
		//                                If fncVerificaConsultaB(taejAltaMasiva, tasAltaS111) = True Then
		//                                    prActualizaEstatus taejAltaMasiva, 9
		//                                    fncEnviaValidaDialogoB = True
		//                                    Screen.MousePointer = vbDefault
		//                                    Exit Function
		//                                Else
		//                                    fncEnviaValidaDialogoB = False
		//                                    Screen.MousePointer = vbDefault
		//                                    Exit Function
		//                                End If
		//                        End Select
		//
		//                    Case "06", "07", "21"
		//                        Select Case ipTipoAltaEjecutivo
		//                            Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//                                If fncVerificaConsultaB(taejAltaIndividual, tasAltaS111) = True Then
		//                                    prActualizaEstatus taejAltaIndividual, 9
		//                                    fncEnviaValidaDialogoB = True
		//                                    Screen.MousePointer = vbDefault
		//                                    Exit Function
		//                                Else
		//                                    fncEnviaValidaDialogoB = False
		//                                    Screen.MousePointer = vbDefault
		//                                    Exit Function
		//                                End If
		//                            Case taejAltaMasiva         '***** ALTA MASIVA *****
		//                                If fncVerificaConsultaB(taejAltaMasiva, tasAltaS111) = True Then
		//                                    prActualizaEstatus taejAltaMasiva, 9
		//                                    fncEnviaValidaDialogoB = True
		//                                    Screen.MousePointer = vbDefault
		//                                    Exit Function
		//                                Else
		//                                    fncEnviaValidaDialogoB = False
		//                                    Screen.MousePointer = vbDefault
		//                                    Exit Function
		//                                End If
		//                        End Select
		//
		//                    Case "01", "03"
		//                        Select Case ipTipoAltaEjecutivo
		//                            Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//                                MsgBox "El servidor CONALTAS no esta disponible", vbInformation + vbOKOnly, "Tarjeta Corporativa"
		//                                If fncVerificaConsultaB(taejAltaIndividual, tasAltaS111) = True Then
		//                                    prActualizaEstatus taejAltaIndividual, 9
		//                                    fncEnviaValidaDialogoB = True
		//                                    Screen.MousePointer = vbDefault
		//                                    Exit Function
		//                                Else
		//                                    fncEnviaValidaDialogoB = False
		//                                    Screen.MousePointer = vbDefault
		//                                    Exit Function
		//                                End If
		//                            Case taejAltaMasiva         '***** ALTA MASIVA *****
		//                                If fncVerificaConsultaB(taejAltaMasiva, tasAltaS111) = True Then
		//                                    prActualizaEstatus taejAltaMasiva, 9
		//                                    fncEnviaValidaDialogoB = True
		//                                    Screen.MousePointer = vbDefault
		//                                    Exit Function
		//                                Else
		//                                    fncEnviaValidaDialogoB = False
		//                                    Screen.MousePointer = vbDefault
		//                                    Exit Function
		//                                End If
		//                        End Select
		//
		//                    Case "02"
		//                        Select Case ipTipoAltaEjecutivo
		//                            Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//                                If fncVerificaConsultaB(taejAltaIndividual, tasAltaS111) = True Then
		//                                    prActualizaEstatus taejAltaIndividual, 9
		//                                    fncEnviaValidaDialogoB = True
		//                                    Screen.MousePointer = vbDefault
		//                                    Exit Function
		//                                Else
		//                                    fncEnviaValidaDialogoB = False
		//                                    Screen.MousePointer = vbDefault
		//                                    Exit Function
		//                                End If
		//                            Case taejAltaMasiva         '***** ALTA MASIVA *****
		//                                If fncVerificaConsultaB(taejAltaMasiva, tasAltaS111) = True Then
		//                                    prActualizaEstatus taejAltaMasiva, 9
		//                                    fncEnviaValidaDialogoB = True
		//                                    Screen.MousePointer = vbDefault
		//                                    Exit Function
		//                                Else
		//                                    fncEnviaValidaDialogoB = False
		//                                    Screen.MousePointer = vbDefault
		//                                    Exit Function
		//                                End If
		//                        End Select
		//
		//                    Case "04", "05"
		//                        If Val(slRespuestaS111) <> 0 Then
		//                            Select Case ipTipoAltaEjecutivo
		//                                Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//                                    MsgBox "Mensaje del S111: " & vbCrLf & fncObtenErrorDialogoS(Val(slRespuestaS111), tsistSistemaS111), vbCritical + vbOKOnly, "Sistema S111"
		//                                    If fncVerificaConsultaB(taejAltaIndividual, tasAltaS111) = True Then
		//                                        prActualizaEstatus taejAltaIndividual, 9
		//                                        fncEnviaValidaDialogoB = True
		//                                        Screen.MousePointer = vbDefault
		//                                        Exit Function
		//                                    Else
		//                                        fncEnviaValidaDialogoB = False
		//                                        Screen.MousePointer = vbDefault
		//                                        Exit Function
		//                                    End If
		//                                Case taejAltaMasiva         '***** ALTA MASIVA *****
		//                                    If fncVerificaConsultaB(taejAltaMasiva, tasAltaS111) = True Then
		//                                        prActualizaEstatus taejAltaMasiva, 9
		//                                        fncEnviaValidaDialogoB = True
		//                                        Screen.MousePointer = vbDefault
		//                                        Exit Function
		//                                    Else
		//                                        fncEnviaValidaDialogoB = False
		//                                        Screen.MousePointer = vbDefault
		//                                        Exit Function
		//                                    End If
		//                            End Select
		//                        End If
		//
		//                    Case Else
		//                        Select Case ipTipoAltaEjecutivo
		//                            Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//                                MsgBox "Mensaje de respuesta del diálogo " & vbCrLf & fncObtenErrorDialogoS(Val(slClaveRespTransaccion), tsistSistemaTandem)
		//                                If fncVerificaConsultaB(taejAltaIndividual, tasAltaS111) = True Then
		//                                    prActualizaEstatus taejAltaIndividual, 9
		//                                    fncEnviaValidaDialogoB = True
		//                                    Screen.MousePointer = vbDefault
		//                                    Exit Function
		//                                Else
		//                                    fncEnviaValidaDialogoB = False
		//                                    Screen.MousePointer = vbDefault
		//                                    Exit Function
		//                                End If
		//                            Case taejAltaMasiva         '***** ALTA MASIVA *****
		//                                If fncVerificaConsultaB(taejAltaMasiva, tasAltaS111) = True Then
		//                                    prActualizaEstatus taejAltaMasiva, 9
		//                                    fncEnviaValidaDialogoB = True
		//                                    Screen.MousePointer = vbDefault
		//                                    Exit Function
		//                                Else
		//                                    fncEnviaValidaDialogoB = False
		//                                    Screen.MousePointer = vbDefault
		//                                    Exit Function
		//                                End If
		//                        End Select
		//                End Select
		//            Else
		//                Select Case ipTipoAltaEjecutivo
		//                    Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//                        MsgBox "Existe un error en el TANDEM No.: " & " ilRespuestaEnvio " & vbCrLf & fncObtenErrorDialogoS(ilRespuestaEnvio, tsistSistemaTandem), vbInformation + vbOKOnly, "Tarjeta Corporativa"
		//                        If fncVerificaConsultaB(taejAltaIndividual, tasAltaS111) = True Then
		//                            prActualizaEstatus taejAltaIndividual, 9
		//                            fncEnviaValidaDialogoB = True
		//                            Screen.MousePointer = vbDefault
		//                            Exit Function
		//                        Else
		//                            fncEnviaValidaDialogoB = False
		//                            Screen.MousePointer = vbDefault
		//                            Exit Function
		//                        End If
		//                    Case taejAltaMasiva         '***** ALTA MASIVA *****
		//                        If fncVerificaConsultaB(taejAltaMasiva, tasAltaS111) = True Then
		//                            prActualizaEstatus taejAltaMasiva, 9
		//                            fncEnviaValidaDialogoB = True
		//                            Screen.MousePointer = vbDefault
		//                            Exit Function
		//                        Else
		//                            fncEnviaValidaDialogoB = False
		//                            Screen.MousePointer = vbDefault
		//                            Exit Function
		//                        End If
		//                End Select
		//            End If
		//    End Select
		//
		//    Screen.MousePointer = vbDefault
		//
		//Exit Function
		//ErrValidaRespuestaDialogo:
		//    Select Case ipTipoAltaEjecutivo
		//        Case taejAltaIndividual
		//            prObtenError "mdlConexiones (ValidaRespuestaDialogo)"
		//    End Select
		//    fncEnviaValidaDialogoB = False
		//    Screen.MousePointer = vbDefault
		//    Exit Function
		//End Function
		//
		//Public Function fncVerificaConsultaB(ipTipoAltaEjecutivo As enuTipoAltaEjecutivo, ipTipoAltaSistema As enuTipoAltaSistema) As Boolean
		//
		//Dim ilResConS111            As Integer
		//Dim slConS111               As String
		//Dim slCausaS111             As String
		//Dim slConsulta              As String
		//Dim slCadena1               As String
		//Dim slCadena2               As String
		//Dim slCadena3               As String
		//Dim slFolio                 As String
		//Dim slCampo                 As String
		//Dim ilRespuestaEnvio        As Integer
		//Dim slFecAlta               As String
		//Dim slFecModificacion       As String
		//Dim slValidacion            As String
		//Dim slRespuestaS016         As String
		//Dim slNombreGraba           As String
		//Dim slRFC                   As String
		//Dim slDialogoConsulta       As String
		//Dim slRespMensaje           As String
		//Dim slDialogo               As String
		//Dim ilCont                  As Integer
		//
		//
		//On Error GoTo ErrVerificaConsultaS111
		//
		//    Screen.MousePointer = vbHourglass
		//
		//    Select Case ipTipoAltaSistema
		//
		//        Case tasAltaS111        '***** CONSULTA S111 *****
		//
		//            Set gdlgDialogoS111 = Nothing
		//            Set gdlgDialogoS111 = New clsDialogo
		//
		//            gdlgDialogoS111.prGeneraDlg gdteEjecutivo, tConsEjecutivoS111
		//
		//            slDialogo = gdlgDialogoS111.DialogoS
		//            ilRespuestaEnvio = cnxConexionRut.RutReadWrite(slDialogo, "S753-CONALTAS")
		//            DoEvents
		//
		//            slRespMensaje = fncValorOmisionV(slDialogo, "")
		//
		//            If ilRespuestaEnvio <> 0 Then
		//                Select Case ipTipoAltaEjecutivo
		//                    Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//                        prActualizaEstatus taejAltaIndividual, 8
		//                        MsgBox "Error en el envio de la informacion.", vbCritical + vbOKOnly, "Tarjeta Corporativa"
		//                    Case taejAltaMasiva
		//                        prActualizaEstatus taejAltaMasiva, 8
		//                End Select
		//                fncVerificaConsultaB = False
		//                Screen.MousePointer = vbDefault
		//                Exit Function
		//            Else
		//                slCadena1 = Trim(Mid(slRespMensaje, 1243, 151))
		//                slCadena2 = Trim(Mid(slRespMensaje, 38, 371))
		//                slCadena3 = Trim(Mid(slRespMensaje, 1608, 31))
		//
		//                Set gdteEjeExists = Nothing
		//                Set gdteEjeExists = New clsDatosEjecutivo
		//
		//                gdteEjeExists.EjeNomGrabaS = Trim(Mid(slCadena1, 1, 26))
		//                gdteEjeExists.EjeDomEnvioDMC.DomicilioS = Trim(Mid(slCadena1, 46, 35))
		//                gdteEjeExists.EjeDomEnvioDMC.ColoniaS = Trim(Mid(slCadena1, 81, 25))
		//                gdteEjeExists.EjeDomEnvioDMC.PoblacionS = Trim$(Mid(slCadena1, 106, 19))
		//                gdteEjeExists.EjeDomEnvioDMC.CPL = Trim$(Mid(slCadena1, 133, 5))
		//
		//                If Trim(Mid(slCadena1, 138, 1)) = "1" Then
		//                    gdteEjeExists.EjeTipoCuentaS = "       Básica       "
		//                ElseIf Trim(Mid(slCadena1, 138, 1)) = "2" Then
		//                    gdteEjeExists.EjeTipoCuentaS = "      Adicional     "
		//                ElseIf Trim(Mid(slCadena1, 138, 1)) = "3" Then
		//                    gdteEjeExists.EjeTipoCuentaS = "Básica con Adicional"
		//                End If
		//
		//                gdteEjeExists.EjeSucTransS = Trim(Mid(slCadena1, 139, 4))
		//                gdteEjeExists.EjeDiaCorteI = Trim(Mid(slCadena1, 143, 2))
		//                gdteEjeExists.EjeSexoS = Trim(Mid(slCadena1, 145, 1))
		//                slCausaS111 = Trim$(Mid(slCadena3, 1, 19))
		//                slFecAlta = Trim$(Mid(slCadena3, 20, 6))
		//                slFecModificacion = Trim$(Mid(slCadena3, 26, 6))
		//                gdteEjeExists.EjeLimCredL = Trim(Mid(slCadena2, 21, 9))
		//
		//                slValidacion = fncValidaDatosS(tasAltaS111)
		//
		//                If slValidacion = "" Then
		//                    fncVerificaConsultaB = True
		//                    Screen.MousePointer = vbDefault
		//                    Exit Function
		//                Else
		//                    Select Case ipTipoAltaEjecutivo
		//                        Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//                            MsgBox "Hay Inconsistencia de Datos en el S111 en el campo " & slValidacion, vbInformation + vbOKOnly, "Tarjeta Corporativa"
		//                    End Select
		//                    fncVerificaConsultaB = False
		//                    Screen.MousePointer = vbDefault
		//                    Exit Function
		//                End If
		//            End If
		//    End Select
		//
		//    Screen.MousePointer = vbDefault
		//
		//Exit Function
		//ErrVerificaConsultaS111:
		//    Select Case ipTipoAltaEjecutivo
		//        Case taejAltaIndividual     '***** ALTA INDIVIDUAL *****
		//            prObtenError "mdlConexiones (VerificaConsultaS111)"
		//    End Select
		//   fncVerificaConsultaB = False
		//    Screen.MousePointer = vbDefault
		//    Exit Function
		//End Function
		//
		//Public Function fncValidaDatosS(ipTipoAltaSistema As enuTipoAltaSistema) As String
		//
		//    Select Case ipTipoAltaSistema
		//        Case tasAltaS016
		//            If gdteEjeExists.EjeNomGrabaS <> gdteEjecutivo.EjeNomGrabaS Then
		//                fncValidaDatosS = "Nombre de Grabación"
		//            ElseIf gdteEjeExists.EjeRfcRFC.RFCS <> gdteEjecutivo.EjeRfcRFC.RFCS Then
		//                fncValidaDatosS = "RFC"
		//            End If
		//
		//        Case tasAltaS111
		//            If gdteEjeExists.EjeNomGrabaS <> gdteEjecutivo.EjeNomGrabaS Then
		//                fncValidaDatosS = "Nombre"
		//            ElseIf gdteEjeExists.EjeDomEnvioDMC.DomicilioS <> gdteEjecutivo.EjeDomEnvioDMC.DomicilioS Then
		//                fncValidaDatosS = "Calle"
		//            ElseIf gdteEjeExists.EjeDomEnvioDMC.ColoniaS <> gdteEjecutivo.EjeDomEnvioDMC.ColoniaS Then
		//                fncValidaDatosS = "Colonia"
		//            ElseIf gdteEjeExists.EjeDomEnvioDMC.PoblacionS <> gdteEjecutivo.EjeDomEnvioDMC.PoblacionS Then
		//                fncValidaDatosS = "Población"
		//            ElseIf gdteEjeExists.EjeDomEnvioDMC.CPL <> gdteEjecutivo.EjeDomEnvioDMC.CPL Then
		//                fncValidaDatosS = "CP"
		//            ElseIf gdteEjeExists.EjeDiaCorteI <> gdteEjecutivo.EjeDiaCorteI Then
		//                fncValidaDatosS = "Dia de Corte"
		//            ElseIf gdteEjeExists.EjeSexoS <> gdteEjecutivo.EjeSexoS Then
		//                fncValidaDatosS = "Sexo"
		//            ElseIf gdteEjeExists.EjeLimCredL <> gdteEjecutivo.EjeLimCredL Then
		//                fncValidaDatosS = "Limite de Credito"
		//            ElseIf gdteEjeExists.EjeTipoCuentaS <> "       Básica       " Then
		//                fncValidaDatosS = "Tipo de Cuenta"
		//            ElseIf gdteEjeExists.EjeSucTransS <> gdteEjecutivo.EjeSucTransS Then
		//                fncValidaDatosS = "Sucursal"
		//            End If
		//    End Select
		//
		//End Function
		//
		//Public Function fncRealizaConexionRutB(ipTipoConexion As enuTipoConexion) As Boolean
		//
		//Dim slRespuesta     As String
		//Dim slCadena        As String
		//Dim slRespAcc       As String
		//Dim slMensaje       As String
		//Dim ilPos           As Integer
		//
		//On Error GoTo ErrRealizaConexionRut
		//
		//    Select Case ipTipoConexion
		//
		//        Case tcnxConexionRut
		//            cnxConexionRut.Termina_Conexion
		//            If cnxConexionRut.Inicia_Conexion = True Then
		//                fncRealizaConexionRutB = True
		//                Screen.MousePointer = vbDefault
		//                Exit Function
		//            Else
		//                fncRealizaConexionRutB = False
		//                MsgBox "No hay conexion al S111. Avise a sistemas.", vbCritical + vbOKOnly, "Conexión S111"
		//                Screen.MousePointer = vbDefault
		//                Exit Function
		//            End If
		//
		//    End Select
		//
		//    Screen.MousePointer = vbDefault
		//
		//Exit Function
		//ErrRealizaConexionRut:
		//    Select Case ipTipoConexion
		//        Case tcnxConexionRut
		//            Select Case Err
		//                Case 0
		//                    fncRealizaConexionRutB = True
		//                    Screen.MousePointer = vbDefault
		//                    Exit Function
		//                Case Else
		//                    MsgBox "No hay conexión al S111. Avise a sistemas.", vbCritical + vbOKOnly, "Conexión S111"
		//                    fncRealizaConexionRutB = False
		//                    Screen.MousePointer = vbDefault
		//                    Resume Next
		//            End Select
		//    End Select
		//
		//End Function
		
		static public string fncGeneraMensajeS( string spMensaje)
		{
			
			string result = String.Empty;
			string slCaracter = String.Empty;
			
			try
			{
					
					for (int ilContador = 1; ilContador <= spMensaje.Length; ilContador++)
					{
						slCaracter = Strings.Mid(spMensaje, ilContador, 1);
						if ((((int) slCaracter[0]) >= 32 && ((int) slCaracter[0]) <= 63) || (((int) slCaracter[0]) >= 65 && ((int) slCaracter[0]) <= 125))
						{
							result = result + slCaracter;
						}
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("mdlConexiones (GeneraMensaje)",e );
				return "SEG:";
			}
			
			return result;
		}
		//
		//Public Function fncVerificaConexionB(ipTipoConexion As enuTipoConexion) As Boolean
		//
		//Dim cnxlConexionRut As New Conexion
		//Dim slExistePath    As String
		//Dim llID            As Long
		//
		//On Error GoTo ErrVerificaConexion
		//
		//    Screen.MousePointer = vbHourglass
		//
		//    Select Case ipTipoConexion
		//
		//        Case tcnxConexionRut
		//            cnxlConexionRut.Termina_Conexion
		//            If cnxlConexionRut.Inicia_Conexion = True Then
		//                fncVerificaConexionB = True
		//                Screen.MousePointer = vbDefault
		//                Exit Function
		//            Else
		//                fncVerificaConexionB = False
		//                MsgBox "No hay conexion al S111. Avise a sistemas.", vbCritical + vbOKOnly, "Conexión S111"
		//                Screen.MousePointer = vbDefault
		//                Exit Function
		//            End If
		//
		//    End Select
		//
		//    Screen.MousePointer = vbDefault
		//
		//Exit Function
		//ErrVerificaConexion:
		//    Select Case ipTipoConexion
		//        Case tcnxConexionRut
		//            Select Case Err
		//                Case 0      'OK
		//                    Screen.MousePointer = vbDefault
		//                Case Else   'No hay conexion con Rut
		//                    MsgBox "No hay conexión al S111. Avise a sistemas.", vbCritical + vbOKOnly, "Conexión S111"
		//                    fncVerificaConexionB = False
		//                    Screen.MousePointer = vbDefault
		//                    Resume Next
		//            End Select
		//    End Select
		//End Function
		//
		//Public Function fncObtenErrorDialogoS(ipError As Integer, ipTipoSistema As enuTipoSistema) As String
		//
		//Dim slSistema As String
		//Dim slMensaje As String
		//
		//On Error GoTo ErrObtenErrorDialogo
		//
		//    Select Case ipTipoSistema
		//        Case cteSistemaTandem
		//            slSistema = cteTandem
		//        Case cteSistemaS111
		//            slSistema = cteS111
		//        Case cteSistemaS016
		//            slSistema = cteS016
		//    End Select
		//
		//    pszgblsql = "select"
		//    pszgblsql = pszgblsql & " err_desc"
		//    pszgblsql = pszgblsql & " from MTCERR01"
		//    pszgblsql = pszgblsql & " where err_cve = " & ipError
		//    pszgblsql = pszgblsql & " and err_origen = '" & slSistema & "'"
		//
		//    If Obtiene_Registros Then
		//        If SqlNextRow(hgblConexion) = MOREROWS Then
		//            slMensaje = Trim(SqlData(hgblConexion, 1))
		//        End If
		//    Else
		//        slMensaje = "No se encuentra registrado este Error en la base de datos."
		//    End If
		//    igblRetorna = SqlCancel(hgblConexion)
		//
		//    fncObtenErrorDialogoS = fncValorOmisionV(slMensaje, "Error Desconocido")
		//
		//Exit Function
		//ErrObtenErrorDialogo:
		//    prObtenError "mdlConexiones (ObtenErrorDialogo)"
		//    fncObtenErrorDialogoS = "Error Desconocido"
		//    Exit Function
		//End Function
		//
	}
}