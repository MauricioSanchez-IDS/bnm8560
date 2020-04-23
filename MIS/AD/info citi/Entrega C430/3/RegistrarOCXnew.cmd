@Echo OFF

Echo Copiando componentes

copy "C:\CodigoAngel\C430_unificado\Corporativa\dlls\COMDLG32.OCX" C:\Windows\SysWOW64
copy "C:\CodigoAngel\C430_unificado\Corporativa\dlls\GEAR32PO.OCX" C:\Windows\SysWOW64
copy "C:\CodigoAngel\C430_unificado\Corporativa\dlls\gswdll32.dll" C:\Windows\SysWOW64
copy "C:\CodigoAngel\C430_unificado\Corporativa\dlls\GRAPH32.OCX" C:\Windows\SysWOW64
copy "C:\CodigoAngel\C430_unificado\Corporativa\dlls\IGMed32x.OCX" C:\Windows\SysWOW64
copy "C:\CodigoAngel\C430_unificado\Corporativa\dlls\MSMAPI32.ocx" C:\Windows\SysWOW64
copy "C:\CodigoAngel\C430_unificado\Corporativa\dlls\msmask32.OCX" C:\Windows\SysWOW64
copy "C:\CodigoAngel\C430_unificado\Corporativa\dlls\ss32x25.ocx" C:\Windows\SysWOW64
copy "C:\CodigoAngel\C430_unificado\Corporativa\dlls\TABCTL32.ocx" C:\Windows\SysWOW64
copy "C:\CodigoAngel\C430_unificado\Corporativa\dlls\Threed32.ocx" C:\Windows\SysWOW64

copy "C:\CodigoAngel\C430_unificado\Corporativa\dlls\VBSQL.dll" C:\Windows\SysWOW64
copy "C:\CodigoAngel\C430_unificado\Corporativa\dlls\Vbsql.OCX" C:\Windows\SysWOW64
copy "C:\CodigoAngel\C430_unificado\Corporativa\dlls\NTWDBLIB.DLL" C:\Windows\SysWOW64
copy "C:\CodigoAngel\C430_unificado\Corporativa\dlls\DBNMPNTW.DLL" C:\Windows\SysWOW64
copy "C:\CodigoAngel\C430_unificado\Corporativa\dlls\MFCANS32.DLL" C:\Windows\SysWOW64
copy "C:\CodigoAngel\C430_unificado\Corporativa\dlls\MSVCRT40.DLL" C:\Windows\SysWOW64
copy "C:\CodigoAngel\C430_unificado\Corporativa\dlls\mfc40.dll" C:\Windows\SysWOW64
copy "C:\CodigoAngel\C430_unificado\Corporativa\dlls\mfc42.dll" C:\Windows\SysWOW64

copy "C:\CodigoAngel\C430_unificado\Corporativa\dlls\mswinsck.OCX" C:\Windows\SysWOW64
copy "C:\CodigoAngel\C430_unificado\Corporativa\dlls\mscomct2.OCX" C:\Windows\SysWOW64
copy "C:\CodigoAngel\C430_unificado\Corporativa\dlls\MSCOMCTL.OCX" C:\Windows\SysWOW64
copy "C:\CodigoAngel\C430_unificado\Corporativa\dlls\pryActualizaS111.dll" C:\Windows\SysWOW64
copy "C:\CodigoAngel\C430_unificado\Corporativa\dlls\prySeguridadS041.dll" C:\Windows\SysWOW64
copy "C:\CodigoAngel\C430_unificado\Corporativa\dlls\GEAR32PD.dll" C:\Windows\SysWOW64
copy "C:\CodigoAngel\C430_unificado\Corporativa\dlls\msvbvm60.dll" C:\Windows\SysWOW64
copy "C:\CodigoAngel\C430_unificado\Corporativa\dlls\oc30.dll" C:\Windows\SysWOW64
copy "C:\CodigoAngel\C430_unificado\Corporativa\dlls\oleaut32.dll" C:\Windows\SysWOW64
copy "C:\CodigoAngel\C430_unificado\Corporativa\dlls\olepro32.dll" C:\Windows\SysWOW64
copy "C:\CodigoAngel\C430_unificado\Corporativa\dlls\TransS111.dll" C:\Windows\SysWOW64
copy "C:\CodigoAngel\C430_unificado\Corporativa\dlls\N_ActualizaS111.dll" C:\Windows\SysWOW64
copy "C:\CodigoAngel\C430_unificado\Corporativa\dlls\N_TransS111.dll" C:\Windows\SysWOW64




Echo Instalando componentes

C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\COMDLG32.ocx /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\GEAR32PO.OCX /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\gswdll32.dll /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\GRAPH32.OCX /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\IGMed32x.OCX /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\MSMAPI32.OCX /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\msmask32.OCX /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\ss32x25.OCX /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\TABCTL32.OCX /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\Threed32.OCX /s

C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\VBSQL.dll /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\Vbsql.OCX /s 
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\NTWDBLIB.DLL /s 
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\DBNMPNTW.DLL /s 
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\MFCANS32.DLL /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\MSVCRT40.DLL /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\mfc40.dll /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\mfc42.dll /s


C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\mswinsck.OCX /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\mscomct2.OCX /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\MSCOMCTL.OCX /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\pryActualizaS111.dll /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\prySeguridadS041.dll /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\GEAR32PD.dll /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\msvbvm60.dll /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\oc30.dll /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\oleaut32.dll /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\olepro32.dll /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\TransS111.dll /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\N_ActualizaS111.dll /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\N_TransS111.dll /s

