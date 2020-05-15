using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.IO; 
using System.Text; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	class IMAGEN
	{
	
		
		
		const int DataPartLimitRead = 256;
		const int DataPartLimitWrite = 256;
		
		const int ReadDelay = 50;
		const int WriteDelay = 50;
		
		public const int EDITAR_PBRUSH = 1;
		public const int EDITAR_ARCHIVO = 2;
		
		static public int HuboEventoMsgErr = 0;
		
		static int UltSql = 0;
		static int Ver_SQL = 0;
		
		static public string nomArchivo = String.Empty;
		
		private const int TAM_CHUNK = 1024;
		
		static public void  GrabarTextArc( string Filename,  string tabla,  string campo,  string cond)
		{
			string strQry = String.Empty;
			string StrCadena = String.Empty;
			byte[] arreglo = null;
			string strArchivo = String.Empty;
			int lngOffset = 0;
			int intFile = 0;
			string strwhere = String.Empty;
			
			ADODB.Recordset rstTabla = new ADODB.Recordset();
			int iNumarch = 0;
			byte[] yImg = null;
			byte[] yChunk = null;
			int lDesplazamiento = 0, lTamArch = 0;
			
			try
			{
					strArchivo = Filename;
					
					if (VBSQL.OpenConn(10) != 0)
					{
						VBSQL.gConn[10].Close();
					} else
					{
						VBSQL.gConn[10].Close();
					}
					
					if (VBSQL.OpenConn(10) == 0)
					{
						if (cond.IndexOf("where", StringComparison.CurrentCultureIgnoreCase) >= 0)
						{
							strwhere = " " + cond;
						} else
						{
							strwhere = " where " + cond;
						}
						
						rstTabla.Open("SELECT " + campo + ", * FROM " + tabla + " " + UneCond(cond, ""), VBSQL.gConn[10], ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, -1);
						
						iNumarch = FileSystem.FreeFile();
						nomArchivo = CORVAR.pszgblPathFirmas + "firma" + campo.Substring(campo.Length - Math.Min(campo.Length, 1)) + ".pcx";
						
						if (FileSystem.Dir(nomArchivo, FileAttribute.Normal) == "")
						{
							if (VBSQL.gConn[10].State == 1)
							{
								VBSQL.gConn[10].Close();
							}
							
							if (rstTabla.State == 1)
							{
								rstTabla.Close();
							}
							return;
						}
						
						FileSystem.FileOpen(iNumarch, nomArchivo, OpenMode.Binary, OpenAccess.Default, OpenShare.Default, -1);
						lTamArch = (int) FileSystem.LOF(iNumarch);
						yImg = new byte[lTamArch];
						//UPGRADE_WARNING: (1041) Get was upgraded to FileGet and has a new behavior.
						Array TempArray = Array.CreateInstance(yImg.GetType().GetElementType(), yImg.Length);
						FileSystem.FileGet(iNumarch, ref TempArray, -1, false, false);
						Array.Copy(TempArray, yImg, TempArray.Length);
						lDesplazamiento = 0;
						FileSystem.FileClose(iNumarch);
						
						
						while(lDesplazamiento < lTamArch)
						{
							//UPGRADE_ISSUE: (1040) MidB function is not supported.
							//UPGRADE_TODO: (1059) Code was upgraded to use System.Text.UnicodeEncoding.Unicode.GetBytes() which may not have the same behavior.
                            //AIS-1127 NGONZALEZ
                            yChunk = MidB(yImg, lDesplazamiento, TAM_CHUNK);
							rstTabla.Fields[0].AppendChunk(yChunk);
							lDesplazamiento += TAM_CHUNK;
						};
						
						rstTabla.Update(Type.Missing, Type.Missing);
						rstTabla.Close();
						
						if (VBSQL.gConn[10].State == 1)
						{
							VBSQL.gConn[10].Close();
						}
						
					}
					nomArchivo = "";
					Cursor.Current = Cursors.Default;
				}
			catch (Exception excep)
			{
				
				MessageBox.Show("Error almacenando texto/imagen " + excep.Message, Application.ProductName);
				Cursor.Current = Cursors.Default;
				nomArchivo = "";
				
				if (rstTabla.State != 0)
				{
					rstTabla.Close();
				}
				
				if (VBSQL.gConn[10].State != ((int) ADODB.ObjectStateEnum.adStateClosed))
				{
					VBSQL.gConn[10].Close();
				}
				
				//    Resume 0
			}
		}

        //AIS-1127 NGONZALEZ
        public static byte[] MidB(byte[] arraySource, int SourceIndex, int length)
        {
            byte[] result = null;
            try
            {
                if ((SourceIndex + length) > arraySource.Length)
                {
                    result = new byte[arraySource.Length - SourceIndex];
                    Array.Copy(arraySource, SourceIndex, result, 0, arraySource.Length - SourceIndex - 1);
                }
                else
                {
                    result = new byte[length];
                    Array.Copy(arraySource, SourceIndex, result, 0, length);
                }

            }
            catch
            {

            }
            return result;
        }

		//AIS-1162 NGONZALEZ
		static public void  LeerImagen( AxGEARLib.AxGear pic,  string tabla,  string campo,  string cond)
		{
			string Temp = ArcTemp();
			try
			{
			LeerTextArc(Temp, tabla, campo, cond);
			
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.

					//UPGRADE_TODO: (1067) Member LoadImage is not defined in type GEAR.
					pic.LoadImage = Temp;
					pic.Visible = false;
					pic.Visible = true;
					File.Delete(Temp);
				}
			catch (Exception exc)
			{
				throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
			}
		}
		
		static public void  LeerTextArc( string Filename,  string tabla,  string campo,  string cond)
		{
			try
			{
					File.Delete(Filename);
				}
			catch 
			{
			}
			AppendTextArc(Filename, tabla, campo, cond);
		}
		
		static public void  AppendTextArc( string Filename,  string tabla,  string campo,  string cond)
		{
			//Codigo Nuevo ado en sybase
			ADODB.Recordset xRs = new ADODB.Recordset();
			ADODB.Command xCmd = new ADODB.Command();
			ADODB.Stream xStream = new ADODB.Stream();
			string Valor = String.Empty;
			int iNumarch = 0;
			byte[] yImg = null;
			byte[] yChunk = null;
			int lDesplazamiento = 0, lTamArch = 0;
			int intTam = 0;
			int intNumPart = 0;
			int intCont = 0;
			int inrprefijo = 0;
			int intbanco = 0;
			double intempresa = 0;
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
						intNumPart = 0;
						intCont = 1;
						
						//        If InStr(1, tabla, "MTCEJX01", vbTextCompare) Then
						//            inrprefijo = CInt(Mid(cond, InStr(1, cond, "ejx_numero", vbTextCompare) + 13))
						//            intbanco = 0
						//            intempresa = 0
						//        Else
						//            inrprefijo = CInt(Mid(cond, InStr(1, cond, "eje_prefijo", vbTextCompare) + 14, 4))
						//            intbanco = CInt(Mid(cond, InStr(1, cond, "banco", vbTextCompare) + 8, InStr(1, Mid(cond, InStr(1, cond, "banco", vbTextCompare) + 8), "AND") - 1))
						//            intempresa = CDbl(Mid(cond, InStr(1, cond, "emp_num", vbTextCompare) + 10))
						//        End If
						
						//Set xRs = gConn(10).Execute("exec spS_Imagen '" & inrprefijo & "','" & CStr(intbanco) & "','" & CStr(intempresa) & "','0','" & tabla & "','" & campo & "'")
						
						
						if ((cond.IndexOf("where", StringComparison.CurrentCultureIgnoreCase) + 1) == 0)
						{
							cond = " where " + cond;
						}
						
						object tempRefParam = Type.Missing;
						xRs = VBSQL.gConn[10].Execute("exec spS_Imagen '" + cond + "','0','" + tabla + "','" + campo + "'", out tempRefParam, -1);
						intNumPart = Convert.ToInt32(xRs.Fields[0].Value);
						xRs.Close();
						
						
						if (intNumPart > 0)
						{
							//ReDim yImg(1000)
							//iNumarch = FileSystem.FreeFile();
							//FileSystem.FileOpen(iNumarch, Filename, OpenMode.Binary, OpenAccess.Default, OpenShare.Default, -1);
                            //AIS-1235 NGONZALEZ
                            FileStream aux = File.Create(Filename);
                            aux.Close();
                            FileStream stream = new FileStream(Filename, FileMode.Open, FileAccess.Write);
                            BinaryWriter writer = new BinaryWriter(stream);

							while (intCont <= intNumPart)
								{
								
									object tempRefParam2 = Type.Missing;
									xRs = VBSQL.gConn[10].Execute("exec spS_Imagen '" + cond + "','" + intCont.ToString() + "','" + tabla + "','" + campo + "'", out tempRefParam2, -1);
									//UPGRADE_WARNING: (1068) xRs.Fields().GetChunk() of type Variant is being forced to Array(byte).
									//yImg = (byte[]) xRs.Fields[0].GetChunk(TAM_CHUNK);
                                    yImg = (byte[])xRs.Fields[0].Value;
									//MsgBox yImg
									xRs.Close();
									
									//UPGRADE_WARNING: (1041) Put was upgraded to FilePutObject and has a new behavior.
                                    //AIS-1235 NGONZALEZ   
                                writer.Write(yImg);
                                   // FileSystem.FilePutObject(iNumarch, yImg, (long) OpenMode.Binary);
									
									intCont++;
								}
                                //AIS-1235 NGONZALEZ
                                writer.Close();
                                stream.Close();
							//FileSystem.FileClose(iNumarch);
							
						}
						
						Valor = "SELECT " + campo + " FROM " + tabla + " " + UneCond(cond, "");
						
						//        'Set xRs = gConn(10).Execute("exec spS_Imagen 4943,88,904 ")
						//
						//        xRs.Open "SELECT " & campo & " FROM " & tabla & " " & UneCond(cond, ""), gConn(10), adOpenDynamic, adLockReadOnly
						//        iNumarch = FreeFile
						//        intTam = 1
						//        xRs.MoveFirst
						//        'If Not IsNull(xRs.Fields(0)) Then
						//        If xRs.Fields(0).ActualSize > 0 Then
						//            Open Filename For Binary As iNumarch
						//            Do
						//                yImg = xRs.Fields(0).GetChunk(TAM_CHUNK)
						//                Put #iNumarch, intTam, yImg
						//                intTam = intTam + UBound(yImg) + 1
						//            Loop While UBound(yImg) = TAM_CHUNK - 1
						//            Close #iNumarch
						//        End If
						
						if (VBSQL.gConn[10].State != ((int) ADODB.ObjectStateEnum.adStateClosed))
						{
							VBSQL.gConn[10].Close();
						}
						if (xRs.State != 0)
						{
							xRs.Close();
						}
						
					}
					Cursor.Current = Cursors.Default;
				}
			catch (Exception excep)
			{
				
				if (xRs.State != 0)
				{
					xRs.Close();
				}
				if (VBSQL.gConn[10].State != ((int) ADODB.ObjectStateEnum.adStateClosed))
				{
					VBSQL.gConn[10].Close();
				}
				MessageBox.Show(Information.Err().Number.ToString() + excep.Message, Application.ProductName);
			}
		}
		
		//UPGRADE_NOTE: (7001) The following declaration (Delay) seems to be dead code
		//private void  Delay( int Num)
		//{
				//
				//while(Num > 0)
				//{
					//Num--;
					//Application.DoEvents();
				//};
		//}
        //AIS-1162 NGONZALEZ
		static public void  GrabarImagen( AxGEARLib.AxGear pic,  string tabla,  string campo,  string cond)
		{
			string Temp = String.Empty;
			try
			{
					//If pic.Picture Then
					
					Temp = ArcTemp();
					
					//SavePicture pic.Picture, Temp
					GrabarTextArc(Temp, tabla, campo, cond);
					//            Kill Temp
					
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					//End If
				}
			catch(Exception e) 
			{
				
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
				//AIS-1133 NGONZALEZ
                Interaction.MsgBox("Error grabando imagen en archivo temporal: " + e.Message.ToString() + "\r" + "Operación cancelada", (MsgBoxStyle) CORVB.MB_ICONSTOP, null);
				return;
			}
		}
		
		//UPGRADE_NOTE: (7001) The following declaration (Wait4Read) seems to be dead code
		//private void  Wait4Read()
		//{
				//Wait ReadDelay
		//}
		
		//UPGRADE_NOTE: (7001) The following declaration (Wait4Write) seems to be dead code
		//private void  Wait4Write()
		//{
				//Wait WriteDelay
		//}
		
		static public string ArcTemp()
		{
			return ArcTempMsk("");
		}
		
		static public string ArcTempMsk( string msk)
		{
			return ArcTempMskSuf(msk, "");
		}
		
		static public string ArcTempMskSuf( string msk,  string Suf)
		{
			string result = String.Empty;
			const string C = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456879";
			string p = String.Empty;
			int File = 0, pos = 0;
			if (msk == "")
			{
				msk = "????????.tmp";
			}
			if ((msk.IndexOf('.') + 1) == 0)
			{
				msk = msk.Trim() + ".tmp";
			}
			msk = Xpandmsk(msk);
			if ((msk.IndexOf('\\') + 1) == 0)
			{
				//p = Interaction.Environ("TEMP");
                p=CORVAR.pszgblPathFirmas;
				if (p.Length == 0)
				{
					p = Path.GetDirectoryName(Application.ExecutablePath);
				}
				if ((! p.EndsWith("\\")))
				{
					p = p + "\\";
				}
				msk = p + msk;
			}
			string T = msk;
			int indsuf = 0;
			do 
			{
				pos = (T.IndexOf('?') + 1);
				if (pos == 0)
				{
					break;
				}
				indsuf++;
				if ((Suf == "") || (pos > (T.IndexOf('.') + 1)))
				{
					T = StringsHelper.MidAssignment(T, pos, Strings.Mid(C, Convert.ToInt32(VBMath.Rnd() * C.Length + 1), 1));
				} else if (Suf.Length >= indsuf) { 
					T = StringsHelper.MidAssignment(T, pos, Strings.Mid(Suf, indsuf, 1));
				} else
				{
					T = StringsHelper.MidAssignment(T, pos, " ");
				}
			}
			while(true);
			
			while(T.IndexOf(" .") >= 0)
			{
				ReplaceStr(ref T, " .", ".");
			};
			result = T;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
			try
			{
					if (FileSystem.Dir(T, FileAttribute.Normal).Length != 0)
					{
                        //AIS-1083 NGONZALEZ
					 System.IO.File.Delete(T);
					}
				}
			catch (Exception exc)
			{
				throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
			}
			return result;
		}
		
		static public void  CancelarResultados()
		{
			CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
		}
		
		static public void  EjecutaSQL( string Cmd)
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
			try
			{
					HuboEventoMsgErr = 0;
					if ((Cmd == "") && (VBSQL.SqlstrLen(CORVAR.hgblConexion) == 0))
					{
						return;
					}
					//    RevisarhgblConexion
					Cursor SaveMousePointer =  Cursor.Current;
					if (VBSQL.SqlDead(CORVAR.hgblConexion) != 0)
					{
						return;
					}
					if (SaveMousePointer == Cursors.Default)
					{
						Cursor.Current = Cursors.No;
					}
					CancelarResultados();
					CORVAR.igblRetorna = VBSQL.SqlCmd(CORVAR.hgblConexion, Cmd);
					if (Ver_SQL != 0)
					{
						mostrarsql();
					}
                    if (SaveMousePointer == Cursors.Default)
					{
						Cursor.Current = Cursors.WaitCursor;
					}
					
					CORVAR.igblRetorna = VBSQL.SqlExec(CORVAR.hgblConexion);
					
					VBSQL.SqlFreeBuf(CORVAR.hgblConexion);
					if (CORVAR.igblRetorna == VBSQL.SUCCEED)
					{
						CORVAR.igblRetorna = VBSQL.SqlResults(CORVAR.hgblConexion);
					}
					if (HuboEventoMsgErr != 0)
					{
						CORVAR.igblRetorna = VBSQL.FAIL;
					}
					//UPGRADE_ISSUE: (2036) Screen property Screen.MousePointer does not support custom mousepointers.
					Cursor.Current = SaveMousePointer;
					UltSql++;
				}
			catch (Exception exc)
			{
				throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
			}
		}
		
		static public void  MeteSQL( string Cmd)
		{
			if (Cmd.Length == 0)
			{
				return;
			}
			//    RevisarhgblConexion
			CORVAR.igblRetorna = VBSQL.SqlCmd(CORVAR.hgblConexion, Cmd + "\r" + "\n");
		}
		
		static public void  mostrarsql()
		{
			string Buffer = String.Empty;
			CORVAR.igblRetorna = VBSQL.SqlStrCpy(CORVAR.hgblConexion, 0, -1, ref Buffer);
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
			//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
			//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
            if (Interaction.MsgBox(Buffer, (MsgBoxStyle)(((int)CORVB.MB_ICONINFORMATION) | CORVB.MB_YESNO | CORVB.MB_DEFBUTTON2), "¿ Copiar ?") == MsgBoxResult.Yes)
			{
				//UPGRADE_WARNING: (1041) Clipboard.SetText has a new behavior.
				Clipboard.SetText(Buffer);
			}
		}
		
		//Reemplaza todas las ocurrencias de sFrom por sTo en Src
		static public void  ReplaceStr(ref  string Src,  string sFrom,  string sTo)
		{
			int pos = 0;
			do 
			{
				pos = Strings.InStr(pos + 1, Src, sFrom, CompareMethod.Binary);
				if (pos == 0)
				{
					break;
				}
				Src = Src.Substring(0, Math.Min(Src.Length, pos - 1)) + sTo + Strings.Mid(Src, pos + sFrom.Length);
				pos += sTo.Length;
			}
			while(true);
		}
		
		static public string UneCond( string c1,  string c2)
		{
			// las  condiciones y  ordenamientos
			// de c1 aparecen antes de las de c2
			string ord2 = String.Empty, ord1 = String.Empty, R = String.Empty;
			c1 = c1.Trim();
			c2 = c2.Trim();
			ReplaceStr(ref c1, "where", "");
			ReplaceStr(ref c2, "where", "");
			int p = (c1.IndexOf("order by") + 1);
			if (p != 0)
			{
				ord1 = Strings.Mid(c1, p);
				c1 = c1.Substring(0, Math.Min(c1.Length, p - 1));
			}
			p = (c2.IndexOf("order by") + 1);
			if (p != 0)
			{
				ord2 = Strings.Mid(c2, p);
				c2 = c2.Substring(0, Math.Min(c2.Length, p - 1));
			}
			c1 = c1.Trim();
			c2 = c2.Trim();
			if (c1.Length + c2.Length == 0)
			{
				R = "";
			} else if (c1.Length == 0) { 
				R = " where " + c2 + " ";
			} else if (c2.Length == 0) { 
				R = " where " + c1 + " ";
			} else
			{
				R = " where " + c1 + " and " + c2 + " ";
			}
			if (ord1.Length != 0)
			{
				R = R + ord1;
			} else if (ord2.Length != 0) { 
				R = R + ord2;
			}
			return R;
		}
		
		static public void  Wait( int hModule)
		{
            //AIS-1182 NGONZALEZ
			while(API.KERNEL.GetModuleUsage((short) hModule) != 0)
			{
				Application.DoEvents();
			};
		}
		
		static public string Xpandmsk( string msk)
		{
			string ch = String.Empty;
			StringBuilder s = new StringBuilder();
			s.Append(String.Empty);
			int ml = (Strings.Mid(msk, 2, 1) == ":") ? 2: 8;
			for (int p = 1; p <= msk.Length; p++)
			{
				ch = Strings.Mid(msk, p, 1);
				switch(ch)
				{
					case "." : 
						ml = 3; 
						s.Append(ch); 
						break;
					case "\\" : case "/" : 
						ml = 8; 
						s.Append(ch); 
						break;
					case "*" : 
						s.Append(new string('?', ml)); 
						ml = 0; 
						break;
					default:
						if (ml > 0)
						{
							s.Append(ch);
							ml--;
						} 
						break;
				}
			}
			return s.ToString();
		}
	}
}