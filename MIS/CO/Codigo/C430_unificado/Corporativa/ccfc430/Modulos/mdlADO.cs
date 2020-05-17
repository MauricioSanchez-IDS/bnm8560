using Microsoft.VisualBasic; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	class mdlADO
	{
	
		
		static public bool fncConectaM111b()
		{
			
			try
			{

                //VBSQL.gConn[10].ConnectionString = "PROVIDER=MSDASQL;dsn=c430;uid=" + CORDBLIB.gsUsuario + ";pwd=" + CORDBLIB.gsPassword + ";database=M111" + ";Charset=iso_1;";
                VBSQL.gConn[10].ConnectionString = "PROVIDER=MSDASQL;dsn=c430;uid=" + CORDBLIB.gsUsuario + ";pwd=" + CORDBLIB.gsPassword + ";database=M111" + ";Charset=iso_1" + ";keeporgmultibyte=1" + ";EncryptPassword=1;";
                VBSQL.gConn[10].Open("", "", "", -1);

                VBSQL.gConn[10].Open("", "", "", -1);
					
					return true;
				}
                catch (Exception e)
			{
				
				
				if (Information.Err().Number == -2147467259)
				{
					//MsgBox "Se presento el siguiente error: " & Err.Description & vbCrLf & vbCrLf & "Al realizar la Conexión con el servidor M111", vbCritical + vbOKOnly, "Error No. " & Err.Number
					CRSGeneral.prObtenError("mdlADO" + "(ConectaM111)",e );
					return false;
				} else
				{
					//        MsgBox "Se presento el siguiente error: " & Err.Description & vbCrLf & vbCrLf & "En la función ConectaM111", vbCritical + vbOKOnly, "Error No. " & Err.Number
					CRSGeneral.prObtenError("mdlADO" + "(ConectaM111)",e );
					return false;
				}
			}
			
		}
		
		
		static public bool fncDesconectaM111b()
		{
			try
			{
					VBSQL.gConn[10].Close();
					
					return true;
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("mdlADO" + "(ConectaM111)",e );
				return false;
			}
		}
		
		
		static public bool fncVerificaConexionM111b()
		{
			bool ErrVerificaConexionM111 = false;
			
			try
			{
					ErrVerificaConexionM111 = true;
					
					if (VBSQL.gConn[10] == null)
					{
						VBSQL.gConn[10] = new ADODB.Connection();
					}
					if (VBSQL.gConn[10].State == 1)
					{
						return true;
					} else
					{
						if (VBSQL.gConn[10].State != 0)
						{
							VBSQL.gConn[10].Close();
                            //VBSQL.gConn[10].ConnectionString = "PROVIDER=MSDASQL;dsn=c430;uid=" + CORDBLIB.gsUsuario + ";pwd=" + CORDBLIB.gsPassword + ";database=M111" + ";Charset=iso_1;";
                            VBSQL.gConn[10].ConnectionString = "PROVIDER=MSDASQL;dsn=c430;uid=" + CORDBLIB.gsUsuario + ";pwd=" + CORDBLIB.gsPassword + ";database=M111" + ";Charset=iso_1" + ";keeporgmultibyte=1" + ";EncryptPassword=1;";
                            VBSQL.gConn[10].Open("", "", "", -1);
							return true;
						} else
						{
                            //VBSQL.gConn[10].ConnectionString = "PROVIDER=MSDASQL;dsn=c430;uid=" + CORDBLIB.gsUsuario + ";pwd=" + CORDBLIB.gsPassword + ";database=M111" + ";Charset=iso_1;";
                            VBSQL.gConn[10].ConnectionString = "PROVIDER=MSDASQL;dsn=c430;uid=" + CORDBLIB.gsUsuario + ";pwd=" + CORDBLIB.gsPassword + ";database=M111" + ";Charset=iso_1" + ";keeporgmultibyte=1" + ";EncryptPassword=1;"; 
                            VBSQL.gConn[10].Open("", "", "", -1);
							return true;
						}
					}
				}
			catch (Exception excep)
			{
				if (! ErrVerificaConexionM111)
				{
					throw excep;
				}
				//UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
				throw new Exception("Migration Exception: 'Resume' not supported");
				if (ErrVerificaConexionM111)
				{
					
					if (Information.Err().Number == -2147467259)
					{
						MessageBox.Show("Se presento el siguiente error: " + excep.Message + "\r\n" + "\r\n" + "Al realizar la Conexión con el servidor M111", "Error No. " + Information.Err().Number.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
						return false;
					} else
					{
						MessageBox.Show("Se presento el siguiente error: " + excep.Message + "\r\n" + "\r\n" + "En la función VerificaConexionM111", "Error No. " + Information.Err().Number.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
						return false;
					}
					
				}
			}
			return false;
		}
		
		static public ADODB.Recordset fncEjecutaSqlRST(ref  string spSQL, ref  ADODB.Connection cnnpM111)
		{
			
			ADODB.Recordset result = new ADODB.Recordset();
			ADODB.Recordset rstSQL = new ADODB.Recordset();
			
			try
			{
					
					if (fncVerificaConexionM111b())
					{
						rstSQL.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
						rstSQL.Open(spSQL, cnnpM111, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, -1);
						result = rstSQL;
					}
				}
			catch (Exception excep)
			{
				
				MessageBox.Show("Se presento el siguiente error: " + excep.Message + "\r\n" + "\r\n" + "En la función EjecutaSql", "Error No. " + Information.Err().Number.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
				return result;
			}
			
			return result;
		}
		
		
		//
		//Sub Main()
		//
		//    If fncConectaM111b = True Then
		//        CORSGPRE.Show
		//    Else
		//        End
		//    End If
		//End Sub
		//
		//Public Sub prConfiguraAplicacion()
		//
		//
		//
		//
		//End Sub
		//
		//Public Function fncConectaM111b() As Boolean
		//
		//On Error GoTo ErrConectaM111
		//
		//    cnngM111.ConnectionString = "PROVIDER=MSDASQL;dsn=TCc430;uid=c430;pwd=tjcorp;database=M111;"
		//    cnngM111.Open
		//    fncConectaM111b = True
		//
		//    Exit Function
		//
		//ErrConectaM111:
		//    If Err.Number = -2147467259 Then
		//        'MsgBox "Se presento el siguiente error: " & Err.Description & vbCrLf & vbCrLf & "Al realizar la Conexión con el servidor M111", vbCritical + vbOKOnly, "Error No. " & Err.Number
		//        prObtenError "mdlADO" & "(ConectaM111)"
		//        fncConectaM111b = False
		//        Exit Function
		//    Else
		//'        MsgBox "Se presento el siguiente error: " & Err.Description & vbCrLf & vbCrLf & "En la función ConectaM111", vbCritical + vbOKOnly, "Error No. " & Err.Number
		//        prObtenError "mdlADO" & "(ConectaM111)"
		//        fncConectaM111b = False
		//        Exit Function
		//    End If
		//
		//End Function
		//
		//Public Function fncVerificaConexionM111b() As Boolean
		//
		//On Error GoTo ErrVerificaConexionM111
		//
		//    If cnngM111.State = 1 Then
		//        fncVerificaConexionM111b = True
		//        Exit Function
		//    Else
		//        If cnngM111.State <> 0 Then
		//            cnngM111.Close
		//            cnngM111.ConnectionString = "PROVIDER=MSDASQL;dsn=TCc430;uid=c430;pwd=tjcorp;database=M111;"
		//            cnngM111.Open
		//            fncVerificaConexionM111b = True
		//            Exit Function
		//        Else
		//            cnngM111.ConnectionString = "PROVIDER=MSDASQL;dsn=TCc430;uid=c430;pwd=tjcorp;database=M111;"
		//            cnngM111.Open
		//            fncVerificaConexionM111b = True
		//            Exit Function
		//        End If
		//    End If
		//    Exit Function
		//
		//ErrVerificaConexionM111:
		//    If Err.Number = -2147467259 Then
		//        MsgBox "Se presento el siguiente error: " & Err.Description & vbCrLf & vbCrLf & "Al realizar la Conexión con el servidor M111", vbCritical + vbOKOnly, "Error No. " & Err.Number
		//        fncVerificaConexionM111b = False
		//        Exit Function
		//    Else
		//        MsgBox "Se presento el siguiente error: " & Err.Description & vbCrLf & vbCrLf & "En la función VerificaConexionM111", vbCritical + vbOKOnly, "Error No. " & Err.Number
		//        fncVerificaConexionM111b = False
		//        Exit Function
		//    End If
		//
		//End Function
		//
		//Public Function fncEjecutaSqlRST(spSQL As String, cnnpM111 As ADODB.Connection) As ADODB.Recordset
		//
		//Dim rstSQL As New ADODB.Recordset
		//
		//On Error GoTo ErrEjecutaSql
		//
		//    If fncVerificaConexionM111b = True Then
		//        rstSQL.CursorLocation = adUseClient
		//        rstSQL.Open spSQL, cnnpM111, adOpenKeyset, adLockOptimistic
		//        Set fncEjecutaSqlRST = rstSQL
		//    End If
		//Exit Function
		//ErrEjecutaSql:
		//    MsgBox "Se presento el siguiente error: " & Err.Description & vbCrLf & vbCrLf & "En la función EjecutaSql", vbCritical + vbOKOnly, "Error No. " & Err.Number
		//    Exit Function
		//
		//End Function
	}
}