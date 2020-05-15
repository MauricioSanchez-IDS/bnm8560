@Echo OFF

Echo Copiando componentes

copy "C:\FTES CORP Y EJEC V_25_04\Ejecutiva\dlls\COMDLG32.OCX" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Ejecutiva\dlls\GEAR32PO.OCX" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Ejecutiva\dlls\GRAPH32.OCX" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Ejecutiva\dlls\IGMed32x.OCX" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Ejecutiva\dlls\MSMAPI32.ocx" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Ejecutiva\dlls\msmask32.OCX" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Ejecutiva\dlls\ss32x25.ocx" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Ejecutiva\dlls\TABCTL32.ocx" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Ejecutiva\dlls\Threed32.ocx" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Ejecutiva\dlls\Vbsql.OCX" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Ejecutiva\dlls\mswinsck.OCX" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Ejecutiva\dlls\mscomct2.OCX" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Ejecutiva\dlls\MSCOMCTL.OCX" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Ejecutiva\dlls\pryActualizaS111.dll" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Ejecutiva\dlls\prySeguridadS041.dll" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Ejecutiva\dlls\VBSQL.dll" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Ejecutiva\dlls\GEAR32PD.dll" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Ejecutiva\dlls\mfc40.dll" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Ejecutiva\dlls\mfc42.dll" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Ejecutiva\dlls\msvbvm60.dll" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Ejecutiva\dlls\oc30.dll" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Ejecutiva\dlls\oleaut32.dll" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Ejecutiva\dlls\olepro32.dll" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Ejecutiva\dlls\TransS111.dll" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Ejecutiva\dlls\AxGearLib.dll" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Ejecutiva\dlls\gswdll32.dll" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Ejecutiva\dlls\EvaluadorExpReg.dll" C:\Windows\SysWOW64


Echo Instalando componentes

cd C:\Windows\SysWOW64

regsvr32 COMDLG32.ocx
regsvr32 IGMed32x.OCX
regsvr32 MSMAPI32.OCX
regsvr32 msmask32.OCX
regsvr32 ss32x25.OCX
regsvr32 TABCTL32.OCX
regsvr32 Threed32.OCX
regsvr32 mswinsck.OCX
regsvr32 mscomct2.OCX
regsvr32 MSCOMCTL.OCX
regsvr32 pryActualizaS111.dll
regsvr32 prySeguridadS041.dll
regsvr32 VBSQL.dll
regsvr32 mfc40.dll
regsvr32 oleaut32.dll
regsvr32 msvbvm60.dll
regsvr32 mfc42.dll
regsvr32 olepro32.dll
regsvr32 TransS111.dll
regsvr32 GEAR32PO.OCX
regsvr32 GRAPH32.OCX
regsvr32 Vbsql.OCX
regsvr32 pryActualizaS111.dll
regsvr32 prySeguridadS041.dll
regsvr32 EvaluadorExpReg.dll




