@Echo OFF

Echo Desinstalando componentes

C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\COMDLG32.ocx -u /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\GEAR32PO.OCX -u /s/s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\gswdll32.dll -u /s

C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\IGMed32x.OCX -u /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\MSMAPI32.OCX -u /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\msmask32.OCX -u /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\ss32x25.OCX -u /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\TABCTL32.OCX -u /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\Threed32.OCX -u /s

C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\VBSQL.dll -u /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\Vbsql.OCX -u /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\NTWDBLIB.DLL -u /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\DBNMPNTW.DLL -u /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\MFCANS32.DLL -u /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\MSVCRT40.DLL -u /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\mfc40.dll -u /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\mfc42.dll -u /s


C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\mswinsck.OCX -u /s 
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\mscomct2.OCX -u /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\MSCOMCTL.OCX -u /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\pryActualizaS111.dll -u /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\prySeguridadS041.dll -u /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\GEAR32PD.dll -u /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\msvbvm60.dll -u /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\oc30.dll -u /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\oleaut32.dll -u /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\olepro32.dll -u /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\TransS111.dll -u /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\N_ActualizaS111.dll -u /s
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\N_TransS111.dll -u /s


Echo Borrando componentes


del C:\Windows\SysWOW64\COMDLG32.ocx
del C:\Windows\SysWOW64\GEAR32PO.OCX
del C:\Windows\SysWOW64\gswdll32.dll

del C:\Windows\SysWOW64\IGMed32x.OCX
del C:\Windows\SysWOW64\MSMAPI32.OCX
del C:\Windows\SysWOW64\msmask32.OCX
del C:\Windows\SysWOW64\ss32x25.OCX
del C:\Windows\SysWOW64\TABCTL32.OCX
del C:\Windows\SysWOW64\Threed32.OCX

del C:\Windows\SysWOW64\VBSQL.dll 
del C:\Windows\SysWOW64\Vbsql.OCX
del C:\Windows\SysWOW64\NTWDBLIB.DLL
del C:\Windows\SysWOW64\DBNMPNTW.DLL
del C:\Windows\SysWOW64\MFCANS32.DLL
del C:\Windows\SysWOW64\MSVCRT40.DLL
del C:\Windows\SysWOW64\mfc40.dll
del C:\Windows\SysWOW64\mfc42.dll

del C:\Windows\SysWOW64\mswinsck.OCX
del C:\Windows\SysWOW64\mscomct2.OCX
del C:\Windows\SysWOW64\MSCOMCTL.OCX
del C:\Windows\SysWOW64\pryActualizaS111.dll
del C:\Windows\SysWOW64\prySeguridadS041.dll
del C:\Windows\SysWOW64\GEAR32PD.dll
del C:\Windows\SysWOW64\msvbvm60.dll
del C:\Windows\SysWOW64\oc30.dll
del C:\Windows\SysWOW64\oleaut32.dll
del C:\Windows\SysWOW64\olepro32.dll
del C:\Windows\SysWOW64\TransS111.dll
del C:\Windows\SysWOW64\N_ActualizaS111.dll
del C:\Windows\SysWOW64\N_TransS111.dll


Pause&Exit
