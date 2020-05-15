using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	class mdlDialogo
	{
	
		//Option Explicit
		//
		//Global Const cteiAltaS111OK = 1                     'Se realizó el alta satisfactoriamente en el S111
		//Global Const cteiAltaS016OK = 2                     'Se realizó el alta satisfactoriamente en el S016
		//Global Const cteiAltaOK = 3
		//Global Const cteiAltaS111NO = 5                     'No se realizó el alta en el S111
		//Global Const cteiAltaS016NO = 6                     'No se realizó el alta en el S016
		//Global Const cteiConsultaS111OK = 0                 'Se realizó la consulta al S111 satisfactoriamente
		//Global Const cteiConsultaS111NO = 1                 'No se realizó la consulta al S111 satisfactoriamente
		//Global Const cteiErrorComunicaciones = -1           'Indica que no se puede enlazar un diálogo
		//
		//Public Enum enuMensajesS111
		//    mS111ExisteEnS111 = 30                          'Ya existe la cuenta en el S111
		//    mS111IncInfoS111 = 11                           'Indica que hubo inconsistencia
		//End Enum
		//
		//Public Enum enuMensajesS016
		//    mS016ExisteEnS016 = 5                           'Ya existe la cuenta en el S111
		//    mS016ErrComS016 = 11                            'Indica que hubo error de Comunicaciones hacia el S016
		//End Enum
		//
		//Public Enum enuTipoAlta
		//    taltAltaS111 = 1                                'Alta en el S111
		//    taltAltaS016 = 2                                'Alta en el S016
		//End Enum
		//
		//Public Enum enuTipoSistema
		//    tSstSistemaC430 = 0                             'C430
		//    tSstSistemaS111 = 1                             'S111
		//    tSstSistemaS016 = 2                             'S016
		//    tSstSistemaTandem = 3                           'Tandem
		//End Enum
		//
		//Public Enum enuTipoCambioS111
		//    tcmbNombre = 2
		//    tcmbCredito = 3
		//    tcmbDomicilio = 4
		//End Enum
		//
		//'Public Type typDatosEjecutivo
		//'    sNombre           As String
		//'    sCalle            As String
		//'    sColonia          As String
		//'    sCiudad           As String
		//'    sCP               As String
		//'    sTipoCuenta       As String
		//'    sSucursal         As String
		//'    sCorte            As String
		//'    sSexo             As String
		//'    sTelDomicilio     As String
		//'    sTelOficina       As String
		//'    sExt              As String
		//'    sFecAlta          As String
		//'    sFecModificacion  As String
		//'    sLimiteCredito    As String
		//'End Type
		//
		//Public Function fncEnviaDialogoI(ByRef cnxpConexionRut As Conexion, ByRef lpNumNom As Long, ByRef spMensaje As String, ByRef spEnviaRut As String, ByRef spCuenta As String, ByRef ejepEjecutivo As clsDatosEjecutivo, ByVal ipTipoAlta As enuTipoAlta) As Integer
		//
		//Dim ilRespuestaEnvio      As Integer
		//Dim slResMensaje          As String
		//Dim slCveResTransaccion   As String
		//Dim slCveTransaccion      As String
		//Dim slRespS111            As String
		//Dim slDescMsg             As String
		//Dim slDescMsgS111         As String
		//Dim slMensaje             As String
		//
		//On Error GoTo ErrEnviaDialogo
		//
		//    spEnviaRut = "Error"
		//
		//    ilRespuestaEnvio = cnxpConexionRut.RutReadWrite(spMensaje, "S753-CONALTAS")
		//    DoEvents
		//
		//    slResMensaje = fncVpoV(spMensaje, "")
		//
		//    If ilRespuestaEnvio = 0 Then
		//        slCveResTransaccion = Mid$(slResMensaje, 32, 2)                     'Si es diferente de cero es error
		//        slCveTransaccion = Mid$(slResMensaje, 34, 4)                        'Si no se dio de alta trae 5181, si la dio de alta trae 0000
		//        slRespS111 = Mid$(slResMensaje, 38, 30)                             '0030 Cuenta Existente, 0048 Problema con datos
		//        slMensaje = Trim(Mid$(slResMensaje, 50, 78))                        'Obtiene la descripcion de la respuesta del dialogo
		//        If InStr(1, "0123456789", Mid$(slCveResTransaccion, 1, 1)) = 0 Then
		//            MsgBox "Existe un error de comunicaciones. Avise a sistemas", vbInformation + vbOKOnly, App.Title
		//            Select Case ipTipoAlta
		//                Case taltAltaS111
		//                    fncEnviaDialogoI = cteiAltaS111NO
		//                Case taltAltaS016
		//                    fncEnviaDialogoI = cteiAltaS016NO
		//            End Select
		//        End If
		//        If (slCveResTransaccion = "04" Or slCveResTransaccion = "05") And slRespS111 = "" Then
		//            slCveResTransaccion = "01"
		//        End If
		//        Select Case ipTipoAlta
		//            Case taltAltaS016
		//                Select Case slCveResTransaccion
		//                    Case "00"                       'Transaccion OK
		//                        If Trim(slMensaje) <> "" Then
		//                            MsgBox slMensaje, vbInformation + vbOKOnly, "Respuesta del Sistema S016"
		//                        End If
		//                        fncEnviaDialogoI = cteiAltaS016OK
		//                        spEnviaRut = "OK"
		//                    Case "05"
		//
		//                    Case "06"                       'Alta S016 no informacion enviada
		//                        If Trim(UCase(slMensaje)) = "CONTRATO A DAR DE ALTA YA EXISTE" Then
		//                            fncEnviaDialogoI = cteiAltaS016OK
		//                            spEnviaRut = "OK"
		//                        Else
		//                            MsgBox "slmensaje", vbCritical + vbOKOnly, "Respuesta del Sistema S016"
		//                            fncEnviaDialogoI = cteiAltaS016NO
		//                        End If
		//                    Case "07"                       'Alta S016 No problemas de comunicacion
		//                        MsgBox slMensaje, vbCritical + vbOKOnly, "Respuesta del Sistema S016"
		//                        fncEnviaDialogoI = cteiAltaS016NO
		//                    Case "21"                       'Alta S016 no el cliente tiene homonimos
		//                        MsgBox slMensaje, vbCritical + vbOKOnly, "Respuesta del Sistema S016"
		//                        fncEnviaDialogoI = cteiAltaS016NO
		//                    Case Else
		//                        MsgBox "Mensaje de respuesta del diálogo " & vbCrLf & fncObtenErrorDialogoS(Val(slCveResTransaccion), tSstSistemaTandem), vbCritical + vbOKOnly, App.Title
		//                        fncEnviaDialogoI = cteiAltaS016NO
		//                End Select
		//            Case taltAltaS111
		//                Select Case Trim(slRespS111)
		//                    Case "0030"                     'Ya existe la cuenta
		//                        fncEnviaDialogoI = mS111ExisteEnS111
		//                        'If Trim() Then
		//                End Select
		//        End Select
		//    End If
		//
		//
		//  'Analiza el tipo de alta que se realizó
		//'    Select Case ipTipoAlta
		//'      Case cteSistemaS016
		//'      Case cteSistemaS111      'Evalua la respuesta que devuelve el S111
		//'          Select Case Trim(slRespS111)
		//'            Case "0030" 'Si el codigo es igual al 0030 ya existe la cuenta
		//'                ifncEnviaDialogo = cteExisteEnS111
		//'                If Trim(sfncVerificaConsulta111(cnxpConexionRut, lpNumNom, spCuenta, spMensaje, ejepEjecutivo)) = "" Then
		//'                  ifncEnviaDialogo = cteAltaS111OK
		//'                  spEnviaRut = "OK"
		//'                Else
		//'                  ifncEnviaDialogo = cteAltaS111NO
		//'                  spEnviaRut = "Error"
		//'                End If
		//'              Exit Function
		//'            Case Else
		//'          End Select
		//'
		//'      'Interpretamos de la respuesta la Clave de Transacción
		//'        Select Case slCveResTransaccion
		//'          Case "00" 'Transaccion OK
		//'              'verificamos que haya entrado correctamente en el S111
		//''              If (Mid$(slRespS111, 1, 4) = TIPO_TRANSACCION And Mid$(slRespS111, 5, 16) = spCuenta) Or '''                 (Trim(Mid$(slRespS111, 1, 4)) = Trim(NULL_STRING) And Trim(Mid$(slRespS111, 5, 16)) = Trim(NULL_STRING)) Then
		//'                  'Realiza la consulta al S111
		//'                  slMensaje = sfncVerificaConsulta111(cnxpConexionRut, lpNumNom, spCuenta, spMensaje, ejepEjecutivo)
		//'                  If Trim(slMensaje) = "" Then
		//'                    ifncEnviaDialogo = cteAltaS111OK
		//'                    spEnviaRut = "OK"
		//'                  Else
		//'                    MsgBox slMensaje, vbExclamation, "S111" & "Inconsistencia de Información."
		//'                    ifncEnviaDialogo = cteAltaS111OK
		//'                    spEnviaRut = "OK"
		//'                  End If
		//''              End If
		//'          Case "06"   'S111 OK, S016 NO
		//'          'Verificamos que haya entrado correctamente en el S111
		//'            If Trim(UCase(slMensaje)) = "CONTRATO A DAR DE ALTA YA EXISTE" Then
		//'            'Realiza la consulta al S111
		//'              slMensaje = sfncVerificaConsulta111(cnxpConexionRut, lpNumNom, spCuenta, spMensaje, ejepEjecutivo)
		//'              If Trim(slMensaje) <> "" Then
		//'                MsgBox slMensaje, vbExclamation, "Alta"
		//'              End If
		//'              ifncEnviaDialogo = cteAltaS111OK
		//'              spEnviaRut = "OK"
		//'            Else
		//'              slMensaje = sfncVerificaConsulta111(cnxpConexionRut, lpNumNom, spCuenta, spMensaje, ejepEjecutivo)
		//'              If Trim(slMensaje) <> "" Then
		//'                'MsgBox slMensaje, vbExclamation, "Alta"
		//'              End If
		//'              ifncEnviaDialogo = cteAltaS111OK
		//'              spEnviaRut = "OK"
		//'            End If
		//'          Case "07"
		//'          Case "21" 'Transaccion OK
		//'
		//'          Case "01", "03"     'Se alamacena en reenvios time out S111
		//'               MsgBox "El servidor CONALTAS no esta disponible", MB_ICONEXCLAMATION, STR_APP_TIT
		//'                ifncEnviaDialogo = cteAltaS111NO
		//'          Case "02"           'Sale de secuenci por error de informacion
		//'                ifncEnviaDialogo = cteAltaS111NO
		//'            'ifncEnviaDialogo =
		//'          Case "04", "05"               'B_ok,A_no         ,  B_no
		//'               'se busca el tipo de error en la tabla de MTCERR01
		//'               If Val(slRespS111) <> NULL_INTEGER Then
		//'                 MsgBox "Mensaje del S111 : " & vbCrLf & sfncObtenErrorDialogo(Val(slRespS111), cteSistemaS111), MB_OK + MB_ICONEXCLAMATION, STR_APP_TIT
		//'               End If
		//'               If slCveResTransaccion = "05" Then    'basica no_ok
		//'                  ifncEnviaDialogo = cteAltaS111NO
		//'               Else
		//'                 'no realiza nada debido que si es 04 la basica se dio de alta y no existe adicional
		//'               End If
		//'          Case Else
		//'            MsgBox "Mensaje de respuesta del diálogo " & vbCrLf & sfncObtenErrorDialogo(Val(slCveResTransaccion), cteTandem)
		//'        End Select
		//'      Case Else
		//'        MsgBox "Tipo de alta no válido", vbCritical, "Envia Dialogo"
		//'    End Select
		//'
		//'  Else
		//'    MsgBox "Existe un error en el TANDEM No.: " & ilRespuestaEnvio & " " & vbCrLf & sfncObtenErrorDialogo(ilRespuestaEnvio, cteSistemaTandem), MB_ICONEXCLAMATION, STR_APP_TIT
		//'    MsgBox "Favor de intentar más tarde", MB_ICONEXCLAMATION, STR_APP_TIT
		//'  End If
		//
		//'    'se toma la acción a ejecutar dependiendo de la cve de respuesta del transacción
		//'    Select Case slCveResTransaccion
		//'      Case "06", "09"               'para el s16   B_ok,A_ok,C_no    ,  B_ok,A_no,C_no error de informacion
		//'               spEnviaRut = "OK"
		//'               'bfncEnviaDialogo = True
		//'      Case "07", "08"               'para el s16 problemas de comunicacion B_ok, A_ok, C_no    ,B_ok,A_no,C_no
		//'           MsgBox "Existen problemas de Comunicaciones", MB_ICONEXCLAMATION, STR_APP_TIT
		//'      Case "10", "12"   'B , 237, C , error de comunicacion
		//'           MsgBox "Existen problemas de Comunicaciones", MB_ICONEXCLAMATION, STR_APP_TIT
		//'      Case "11", "13"     'B , 237, C , error de informacion
		//'
		//'      Case "14"                     'Parámetro PATHCOM 237 incorrecto
		//'           MsgBox "Existen problemas de Comunicaciones, PATHCOM incorrecto.", MB_ICONEXCLAMATION, STR_APP_TIT
		//'      Case "21", "22", "23"              'clientes no x homonimos
		//'           MsgBox "Existen problemas de Comunicaciones,Clientes no por homonimos.", MB_ICONEXCLAMATION, STR_APP_TIT
		//'      Case Else
		//'          MsgBox "Error no definido. ", MB_OK + MB_ICONEXCLAMATION, STR_APP_TIT
		//'    End Select
		//'    Debug.Print "------Diálogo de Respuesta ------------------------------------------------------------"
		//'    Debug.Print Time & Date
		//'    Debug.Print spCuenta
		//'    Debug.Print slRespS111
		//'    Debug.Print slDescMsgS111
		//'    prLog "Resp " & spCuenta & " " & Time & " " & Date & " " & " Resp:" & slRespS111 & " DescMsg:" & slDescMsgS111
		//'    Debug.Print "------Fin Diálogo de Respuesta ------------------------------------------------------------"
		//Exit Function
		//ErrEnviaDialogo:
		//  Select Case Err.Number
		//    Case 28
		//      Err.Clear
		//      Resume Next
		//    Case Else
		//      prObtenError "EnviaDialogo"
		//  End Select
		//End Function
		//
		//
		//Public Function fncObtenErrorDialogoS(ByVal ipError As Integer, ByVal ipTipoSistema As enuTipoSistema) As String
		//
		//Dim slSistema As String
		//Dim slMensaje As String
		//
		//On Error GoTo ErrObtenErrorDialogo
		//
		//    Select Case ipTipoSistema
		//        Case tSstSistemaTandem
		//            slSistema = ctesTandem
		//        Case tSstSistemaS111
		//            slSistema = ctesS111
		//        Case tSstSistemaS016
		//            slSistema = ctesS016
		//    End Select
		//
		//    pszgblsql = "select"
		//    pszgblsql = pszgblsql & " err_desc"
		//    pszgblsql = pszgblsql & " from MTCERR01 "
		//    pszgblsql = pszgblsql & " where err_cve = " & ipError
		//    pszgblsql = pszgblsql & " and err_origen = '" & slSistema & "'"
		//
		//    If Obtiene_Registros Then
		//        If SqlNextRow(hgblConexion) = MOREROWS Then
		//            slMensaje = fncVpoV(SqlData(hgblConexion, 1), "Error Desconocido")
		//        End If
		//    Else
		//        slMensaje = "No se encuentra registrado este Error en la base de datos."
		//    End If
		//    igblRetorna = SqlCancel(hgblConexion)
		//
		//'    sfncObtenErrorDialogo = fncVpoV(slMensaje, "Error Desconocido")
		//
		//Exit Function
		//ErrObtenErrorDialogo:
		//    prObtenError "mdlDialogo (ObtenErrorDialogo)"
		//End Function
		//
		//Public Function fncVerificaConsulta111S(ByRef cnxpConexionRut As Conexion, ByRef lpNumNom As Long, ByRef spCuenta As String, ByRef spMensaje As String, ByRef ejepEjecutivo As DatosEjecutivo) As String
		//
		//'Dim ejelEjecutivo111       As typDatosEjecutivo
		//Dim ilResConS111           As Integer
		//Dim slConS111              As String
		//Dim slCausaS111            As String
		//Dim slConsulta             As String
		//Dim slCadena1              As String
		//Dim slCadena2              As String
		//Dim slCadena3              As String
		//Dim slFolio                As String
		//Dim slCampo                As String
		//
		//On Error GoTo ErrVerificaConsulta111
		//
		//    slFolio = lpNumNom                      'Se le asigna el Numero de Nomina
		//
		//    spMensaje = Space(55)
		//
		//    Mid$(spMensaje, 1, 4) = "C430"                                              'Sistema
		//    Mid$(spMensaje, 5, 3) = ctesProcesoAlta                                     'Clave de proceso
		//    Mid$(spMensaje, 8, 2) = "00"                                                'Clave tipo de alta
		//    Mid$(spMensaje, 10, 2) = ctesTipoTramite                                    'Clave tipo de tramite
		//    Mid$(spMensaje, 12, 8) = Format$(slFolio, "00000000")                       'Numero de Folio
		//    Mid$(spMensaje, 20, 12) = Format$(Str$(0), "000000000000")                  'Numero de nomina
		//    Mid$(spMensaje, 32, 4) = ctesTransaccionConsulta                            'Transacción
		//    Mid$(spMensaje, 36, 16) = spCuenta                                          'Cuenta
		//
		//    slConsulta = spMensaje
		//
		//    ilResConS111 = cnxpConexionRut.RutReadWrite(slConsulta, "S753-CONALTAS")
		//    DoEvents
		//    slConS111 = slConsulta
		//
		//    If ilResConS111 <> 0 Then
		//        MsgBox "ERROR EN EL ENVIO DE LA INFORMACION", vbInformation + vbOKOnly, App.Title
		//    End If
		//
		//    'Obtengo los datos del S111
		//    slCadena1 = Trim(Mid(slConS111, 1243, 151))
		//    slcandea2 = Trim(Mid(slConS111, 38, 371))
		//    slCadena3 = Trim(Mid(slConS111, 1608, 31))
		//
		//    ejelEjecutivo111.sNombre = Trim(Mid(slCadena1, 1, 26))
		//    ejelEjecutivo111.sCalle = Trim(Mid(slCadena1, 46, 35))
		//    ejelEjecutivo111.sColonia = Trim(Mid(slCadena1, 81, 25))
		//    ejelEjecutivo111.sCiudad = Trim(Mid(slCadena1, 106, 25))
		//    ejelEjecutivo111.sCP = Trim(Mid(slCadena1, 133, 5))
		//
		//    If Trim$(Mid(slCadena1, 138, 1)) = "1" Then
		//       ejelEjecutivo111.sTipoCuenta = "       Básica       "
		//    End If
		//    If Trim$(Mid(slCadena1, 138, 1)) = "2" Then
		//       ejelEjecutivo111.sTipoCuenta = "      Adicional     "
		//    End If
		//    If Trim$(Mid(slCadena1, 138, 1)) = "3" Then
		//       ejelEjecutivo111.sTipoCuenta = "Básica con Adicional"
		//    End If
		//
		//
		//    ejelEjecutivo111.sSucursal = Trim$(Mid(slCadena1, 139, 4))
		//    ejelEjecutivo111.sCorte = Trim$(Mid(slCadena1, 143, 2))
		//    ejelEjecutivo111.sSexo = Trim$(Mid(slCadena1, 145, 1))
		//    ejelEjecutivo111.sTelDomicilio = Trim$(Mid(slCadena1, 27, 7))
		//    ejelEjecutivo111.sTelOficina = Trim$(Mid(slCadena1, 34, 7))
		//    ejelEjecutivo111.sExt = Trim$(Mid(slCadena1, 41, 4))
		//    slCausaS111 = Trim$(Mid(slCadena3, 1, 19))
		//    ejelEjecutivo111.sFecAlta = Trim$(Mid(slCadena3, 20, 6))
		//    ejelEjecutivo111.sFecModificacion = Trim$(Mid(slCadena3, 26, 6))
		//    ejelEjecutivo111.sLimiteCredito = Trim$(Mid(slCadena2, 21, 9))
		//
		//    MsgBox STR_ALTA_EJE + spCuenta, MB_ICONEXCLAMATION, STR_APP_TIT
		//    slCampo = sfncValidaDatos(ejelEjecutivo111, ejepEjecutivo)
		//    sfncVerificaConsulta111 = slCampo
		//    If Trim(slCampo) = Empty Then
		//      MsgBox "Transacción Completa. ", MB_OK + MB_ICONEXCLAMATION, STR_APP_TIT
		//    Else
		//      MsgBox "Transacción Completa. Hay Inconsistencia de Datos en el S111 en el campo " & slCampo, MB_OK + MB_ICONEXCLAMATION, STR_APP_TIT
		//    End If
		//  End If
		//Exit Function
		//ErrVerificaConsulta111:
		//  prObtenError "VerificaConsulta111"
		//End Function
		//
		//
		//
		//
		//
		//
	}
}