@Echo OFF

Echo Desinstalando componentes

C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\AxGearLib.dll -u
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\COMDLG32.ocx -u
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\GRAPH32.OCX -u
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\IGMed32x.OCX -u
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\MSMAPI32.OCX -u
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\msmask32.OCX -u
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\ss32x25.OCX -u
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\TABCTL32.OCX -u
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\Threed32.OCX -u
C:\Windows\SysWOW64\regsvr32 C:\Windows\SysWOW64\Vbsql.OCX -u

Echo Borrando componentes

del C:\Windows\SysWOW64\AxGearLib.dll
del C:\Windows\SysWOW64\COMDLG32.ocx
del C:\Windows\SysWOW64\GRAPH32.OCX
del C:\Windows\SysWOW64\IGMed32x.OCX
del C:\Windows\SysWOW64\MSMAPI32.OCX
del C:\Windows\SysWOW64\msmask32.OCX
del C:\Windows\SysWOW64\ss32x25.OCX
del C:\Windows\SysWOW64\TABCTL32.OCX
del C:\Windows\SysWOW64\Threed32.OCX
del C:\Windows\SysWOW64\Vbsql.OCX

Pause&Exit
