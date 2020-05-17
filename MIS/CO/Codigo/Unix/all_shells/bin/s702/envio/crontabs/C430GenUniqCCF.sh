#!/bin/ksh

##__HP changes for Linux migration - start -change /bin/sh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# NOMBRE	: C430GenUniqCCF.                                       #
# DESCRIPCION	: Permite generar un archivo UNICO en formato CCF       #
#                 tomando como base los archivos CCF de cada una de     #
#                 las empresas previamente procesadas con la aplica-    #
#                 cion C430ValComCCF. El archivo generado puede ser     #
#                 Diario o por Fecha de Corte.                          #
# PRECEDIDO POR	: C430ValComCCF.                                        #
#                                                                       #
#			                                                #
# VARIABLES DE			                                        #
# AMBIENTE		: NOMBRE VARIABLE           DESCRIPCION         #
#			                                                #
#                            LAPath           Ruta de Ubicacion         # 
#                                             Archivos CCF.             # 
#                            LATransfer       Ruta de Deposito          #
#                                             Archivo CCF Unico         #
#                            LAFileType       Modo de Generacion del    #
#                                             Archivo.                  #
#                            LAFileTypeCode   Clave de Modo de          #
#                                             Generacion del Archivo.   #
#                            LAFileName       Nombre del Archivo        #
#                                             Unico.                    #
#                            LADate           Fecha de Generacion del   #
#                                             Archivo (MMDD).           #
#                            LAPreffix        Prefijo asociado al       #
#                                             Archivo.                  #
#                            LASuffix         Sufijo asociado al        #
#                                             Archivo.                  #
#                            LAUserName       Nombre de Usuario de      #
#                                             UNIX.                     #
#                            LNProcesses      Numero de Instancias      #
#                                             Activas del Programa.     # 
#                            LAPattern        Patron de Busqueda de     #
#                                             Archivos CCF.             #
#                            LALogFile        Nombre del Archivo de     #
#                                             Log.                      #
#                            LARegLogFile     Registro de Archivo de    #
#                                             Log.                      #
#                            LASysDate        Fecha del Sistema.        #
#                            LNStatus         Estado de Ejecucion del   #
#                                             Programa.                 #
#                            LAIDProcess      Clave de Identificacion   #
#                                             del Programa.             #
#                            LATempFile       Archivo Temporal.         #
#                            LATempISQLFile   Archivo Temporal de       #
#                                             resultado de ejecucion de #
#                                             comandos de SQL.          #
#                            LAUser           Usuario de Base de Datos. #
#                            LAPassword       Password de Base de       #
#                                             Datos.                    #
#                            LAServer         Servidor de Base de       #
#                                             Datos.                    #
#                            LAISQLUtil       Nombre del Programa para  #
#                                             Acceso a Base de Datos.   #
#                            LADatabase       Nombre de la Base de      #
#                                             Datos del Sistema C430.   #
#                            LAStatusTab      Nombre de la Tabla de     #
#                                             Registro de Estatus del   #
#                                             Proceso de Generacion del #
#                                             Archivo CCF.              #
#                            LNValStaTab      Valor a Almacenar en la   #
#                                             Tabla de Registro de      #
#                                             Estatus.                  #
#                            LNValCurSta      Valor Actual de la        #
#                                             columna Estatus de la     #
#                                             Tabla de Registro de      #
#                                             Estatus.                  #
#                            LNCCFFiles       Archivos CCF por Empresa  #
#                                             Disponibles en la Ruta    #
#                                             Especificada.             # 
#                            LAErrMsg1        Mensaje de Error 1.       #
#                            LAErrMsg2        Mensaje de Error 2.       #
#                            LAInfMsg1        Mensaje Informativo 1.    #
# PARAMETROS 	:                                                       #
#                 $0 = Nombre del Programa.                             #
#                 $1 = Ruta de Ubicacion Archivos CCF por Empresa.      #
#                 $2 = Ruta de Deposito del Archivo CCF Unico           #
#                 $3 = Nombre del Archivo Unico generado en TransCCF.sh #
#                 $4 = Fecha de Procesamiento (Parametro Opcional).     #
#                                                                       #
#                                                                       # 
# SALIDAS	: Archivo CCF Unico:                                    #
#                    CCFMMDDD.txt (Archivo Unico Diario).               #
#                 Donde:                                                #
#                    MM = Mes de Generacion del Archivo.                #
#                    DD = Dia de Generacion del Archivo.                #
#                    C,D = Modo de Generacion del Archivo               #
#                          (C: Por Corte; D: Diario)                    #
#                 Notificacion de Evolucion de Proceso al Archivo de    #
#                 Log C430TransCCF.log.                                 #
# AUTOR		: Vicente Ferrer Andrade <VFA>                          #
# COMPANIA	: Softtek                                               #
# FECHA		: 24/07/2003                                            #
# CONTROL DE                                                            #
# VERSIONES	: V.1.0	                                                #
# CONTROL DE MODIFICACION                                               #
#   IS	      NOMBRE		   FECHA	DESCRIPCION             #
#  VFA  Vicente Ferrer Andrade  24/07/2003  Primer Version              #
# Copyright Derechos Reservados Banamex S.A. de C.V 2003                #
#  Observaciones:                                                       #
#

. $(paths.sh 08 PAR)/.variables	  #descomentar en la nueva ruta

# Inicializacion de Variables.

LAPath=$1
LAFileType=$FileMode
LATransfer=$2
LAFileTypeCode=""
LAFileName=""
LADate=""
LAPreffix=$PreffixCCF
LASuffix=$SuffixCCF
LAUserName=$UserNameUNIX
LNProcesses=0
LAPattern=""
LALogFile=$LogFile
LARegLogFile=""
LASysDate=""
LNStatus=0
LAIDProcess="07"
LATempFile=$TempFilePath"TempC430GenUniqCCF.tmp"
LATempISQLFile=$ISQLFile
LAUser=$UserSYB
LAPassword=$PasswordSYB
LAServer=$ServerSYB
LAISQLUtil=$ISQLUtilSYB
LADatabase=$DatabaseSYB
LAStatusTab=$StatusTabSYB
LNValStaTab=2
LNValCurSta=0
LNCCFFiles=0
LAErrMsg1="Archivo CCF ya generado con anterioridad"
LAErrMsg2="No existe(n) archivo(s) CCF por empresa disponible(s) para generar el archivo CCF Unico"
LAInfMsg1="Generacion del Archivo UNICO OK"

# Determinar el No. de Parametros de Ejecucion.

case $# in
   3) ;;   # No. de Parametros Correcto.
   4) ;;   # No. de Parametros Correcto.
   *) print "Use: C430GenUniqCCF.sh <Path> <Transfer Path> [<Date>]"
      exit 1 ;;
esac

# Eliminar archivos temporales.

if [[ -a $LATempFile ]]
then                               
   rm $LATempFile
fi

if [[ -a $LATempISQLFile ]]
then
   rm $LATempISQLFile
fi

# Determinar el No. de Procesos Activos.

ps -ef | grep $LAUserName | grep $0 | grep "sh -c" | grep -v grep > $LATempFile

LNProcesses=$(wc -l $LATempFile | awk '{ print $1; }')

if [[ -a $LATempFile ]]
then
   rm $LATempFile
fi

if [[ $LNProcesses > 1 ]]   # No puede haber mas de un proceso activo.
then
   print "The process " $0 " is online."
   exit 2
fi

# Establecer la Clave Asociada al Modo de Generacion del Archivo CCF.

if [[ $LAFileType = "0" ]]   # El archivo CCF a generar es Diario.
then
   LAFileTypeCode="D" 
elif [[ $LAFileType = "1" ]]   # El archivo CCF a generar es por Fecha de Corte.
then
   LAFileTypeCode="C"
else
   print "The FileType Parameter's Value is incorrect."
   exit 3
fi

# Establecer la Fecha de Generacion del Archivo.

if [[ -z $4 ]]
then
   LADate=$(date +'%m%d')
else
   LADate=$4
fi 

# Establecer el Nombre del Archivo CCF Unico.

#LAFileName=$LAPreffix$LADate$LAFileTypeCode$LASuffix 
LAFileName=$3

# Establecer el Patron de Busqueda de Archivos CCF.

LAPattern=$LAPreffix"*"$LADate$LAFileTypeCode$LASuffix

# Construccion de script de SQL para analizar la tabla
# de Estatus del Proceso de Generacion del Archivo Unico
# CCF MTCCCF01.
 
echo "use "$LADatabase > $LATempFile
echo "go" >> $LATempFile
echo "if exists (select * from "$LAStatusTab >> $LATempFile
echo "           where nom_archivo = '"$LAFileName"')" >> $LATempFile
echo "   begin" >> $LATempFile
echo "      select estatus from "$LAStatusTab >> $LATempFile
echo "      where nom_archivo = '"$LAFileName"'" >> $LATempFile
echo "   end" >> $LATempFile
echo "go" >> $LATempFile
echo "exit" >> $LATempFile
                                                                               
chmod 775 $LATempFile
                                                                               
$LAISQLUtil -U$LAUser -P$LAPassword -S$LAServer -i$LATempFile -o$LATempISQLFile
                                                                               
#LNValCurSta=$(awk '{ if(NR==3) { print $1; } }' $LATempISQLFile)
LNValCurSta=$(head -6 $LATempISQLFile | tail -5 | awk '{ if(NR==3) { print $1; } }')

if [[ -a $LATempFile ]]
then
   rm $LATempFile
fi

if [[ -a $LATempISQLFile ]]
then
   rm $LATempISQLFile
fi

# Verificar el valor actual de la Tabla de Estatus.
                                                   
if [[ $LNValCurSta -ne $LNValStaTab ]]
then                                               
   print "The Generation of Unique File process can't continue."
   exit 4
fi

# Buscar los archivos CCF por Empresa en la Ruta Especificada.

cd $LAPath

# Verificar si el Archivo CCF unico ya fue generado previamente.

echo "existe ? HP-> LAFileName : $LAPath$LAFileName" >>  $LALogFile
if [[ -a $LAFileName ]]
then

   # Generar el registro de Log correspondiente y dar por
   # concluido el proceso.

   LASysDate=$(date +'%Y%m%d %H%M%S')
   LNStatus=1
   LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg1"|"$LASysDate"|"$LNStatus"|"$LAIDProcess

   print $LARegLogFile >> $LALogFile
   exit 5
 
fi

ls $LAPattern > $LATempFile

LNCCFFiles=$(wc -l $LATempFile | awk '{ print $1; }')

if [[ -a $LATempFile ]]
then
   rm $LATempFile
fi

if [[ $LNCCFFiles < 1 ]]   # No hay archivos CCF disponibles.
then
   LASysDate=$(date +'%Y%m%d %H%M%S')
   LNStatus=1
   LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg2"|"$LASysDate"|"$LNStatus"|"$LAIDProcess

   print $LARegLogFile >> $LALogFile
   exit 6
fi

# Generar el archivo CCF Unico.

# Adicionar el contenido de cada uno de los archivos CCF por Empresa
# al archivo CCF Unico.
 
for CCFFiles in $(ls $LAPattern | grep -v $LAFileName)
{
   cat $CCFFiles >> $LAFileName 
}

# Verificar si el Archivo CCF Unico pudo ser generado; en caso afirmativo,
# generar el registro correspondiente en el Archivo de Log.
 
if [[ -a $LAFileName ]]
then

   LASysDate=$(date +'%Y%m%d %H%M%S')
   LNStatus=0
   LARegLogFile=$LAFileName"|"$LADate"|"$LAInfMsg1"|"$LASysDate"|"$LNStatus"|"$LAIDProcess

   print $LARegLogFile >> $LALogFile

   # Construccion de script de SQL para actualizar la tabla             
   # de Estatus del Proceso de Generacion del Archivo Unico             
   # CCF MTCCCF01 (Generacion de Archivo CCF Unico).             
                                                                     
   LNValStaTab=3                                                        
                                                                     
   echo "use "$LADatabase > $LATempFile                                 
   echo "go" >> $LATempFile                                             
   echo "if exists (select * from "$LAStatusTab >> $LATempFile          
   echo "           where nom_archivo = '"$LAFileName"')" >> $LATempFile
   echo "   begin" >> $LATempFile                                       
   echo "      update "$LAStatusTab >> $LATempFile                      
   echo "      set estatus = "$LNValStaTab >> $LATempFile               
   echo "      where nom_archivo = '"$LAFileName"'" >> $LATempFile      
   echo "   end" >> $LATempFile                                         
   echo "go" >> $LATempFile                                             
   echo "exit" >> $LATempFile                                           
                                                                     
   $LAISQLUtil -U$LAUser -P$LAPassword -S$LAServer -i$LATempFile        
   
   if [[ -a $LATempFile ]]
   then
      rm $LATempFile
   fi
 
fi

mv $LAFileName $LATransfer

exit 0
