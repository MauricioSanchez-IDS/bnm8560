@Echo OFF

Echo Copiando componentes

copy "C:\FTES CORP Y EJEC V_25_04\Corporativa\dlls\COMDLG32.OCX" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Corporativa\dlls\GEAR32PO.OCX" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Corporativa\dlls\gswdll32.dll" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Corporativa\dlls\GRAPH32.OCX" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Corporativa\dlls\IGMed32x.OCX" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Corporativa\dlls\MSMAPI32.ocx" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Corporativa\dlls\msmask32.OCX" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Corporativa\dlls\ss32x25.ocx" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Corporativa\dlls\TABCTL32.ocx" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Corporativa\dlls\Threed32.ocx" C:\Windows\SysWOW64

copy "C:\FTES CORP Y EJEC V_25_04\Corporativa\dlls\VBSQL.dll" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Corporativa\dlls\Vbsql.OCX" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Corporativa\dlls\NTWDBLIB.DLL" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Corporativa\dlls\DBNMPNTW.DLL" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Corporativa\dlls\MFCANS32.DLL" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Corporativa\dlls\MSVCRT40.DLL" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Corporativa\dlls\mfc40.dll" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Corporativa\dlls\mfc42.dll" C:\Windows\SysWOW64

copy "C:\FTES CORP Y EJEC V_25_04\Corporativa\dlls\mswinsck.OCX" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Corporativa\dlls\mscomct2.OCX" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Corporativa\dlls\MSCOMCTL.OCX" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Corporativa\dlls\pryActualizaS111.dll" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Corporativa\dlls\prySeguridadS041.dll" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Corporativa\dlls\GEAR32PD.dll" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Corporativa\dlls\msvbvm60.dll" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Corporativa\dlls\oc30.dll" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Corporativa\dlls\oleaut32.dll" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Corporativa\dlls\olepro32.dll" C:\Windows\SysWOW64
copy "C:\FTES CORP Y EJEC V_25_04\Corporativa\dlls\TransS111.dll" C:\Windows\SysWOW64



Echo Instalando componentes

C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\COMDLG32.ocx
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\GEAR32PO.OCX
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\gswdll32.dll
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\GRAPH32.OCX
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\IGMed32x.OCX
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\MSMAPI32.OCX
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\msmask32.OCX
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\ss32x25.OCX
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\TABCTL32.OCX
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\Threed32.OCX

C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\VBSQL.dll
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\Vbsql.OCX
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\NTWDBLIB.DLL
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\DBNMPNTW.DLL
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\MFCANS32.DLL
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\MSVCRT40.DLL
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\mfc40.dll
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\mfc42.dll


C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\mswinsck.OCX
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\mscomct2.OCX
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\MSCOMCTL.OCX
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\pryActualizaS111.dll
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\prySeguridadS041.dll
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\GEAR32PD.dll
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\msvbvm60.dll
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\oc30.dll
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\oleaut32.dll
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\olepro32.dll
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\TransS111.dll

