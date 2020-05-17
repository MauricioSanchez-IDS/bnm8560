#!/bin/ksh
# Sistema: c430
##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end
# Directorio: 
# Procedimiento: procRespCDF.sh
# Descripción: procesa la respuesta del archivo CDF que envia Master Card     
# Versión y fecha: 1.0
# Autor: 
#             
# Modificacion :
# Autor y fecha:

##### Inicia proceso para validar respuesta de Master Card #####

PATH=$PATH:/opt/c430/000/bin:.
export PATH

file_system="c430"
#Inicia las validaciones del estatus de la tabla MTCPRO02
fecha_proceso=`date '+%y%m%d'`  

terminaPrograma=0
insertaMTCPRO02=0 

nombreLogico=''
nombreFisico=''
fecha=''
estatus=0
estatusUsu=0
mensaje=''
accion=''
nombreLogicoIns=''
nombreFisicoIns=''
fechaIns=''
estatusIns=0
estatusUsuIns=0
mensajeIns=''
accionIns=''

variable=`isql -U${GE_USER} -P${GE_PASSWORD} -D$(base.sh) -S${GE_SERVER} -w1200 -i $DIR_CARGA/checaUltEstatus.txt | grep '[0-9]' | egrep -v '\(.*\)'`
checa=`echo $variable | grep -c "|"`
if [ $checa -ne 1 ] 
then
  errores="No se pudo consultar la tabla MTCPRO02" 
  echo "Fecha proceso:  $fecha_proceso" 
  echo "Nombre archivo: " 
  echo "Programa:       " 
  echo "Error: $errores"
  terminaPrograma=1 
else
  nombreLogico=`echo $variable | cut -f2 -d'|'`
  nombreFisico=`echo $variable | cut -f3 -d'|'`
  fecha=`echo $variable | cut -f4 -d'|'`
  estatus=`echo $variable | cut -f5 -d'|'`
  estatusUsu=`echo $variable | cut -f6 -d'|'`
  mensaje=`echo $variable | cut -f7 -d'|'`
  accion=`echo $variable | cut -f8 -d'|'`
  fecha_JulReg=`echo $variable | cut -f9 -d'|' | sed 's/ //g'`
  ref_num=`echo $variable | cut -f10 -d'|'`
  #ref_num1=`echo $variable | cut -f10 -d'|' | awk '{ print $1 }'`
  #ref_num2=`echo $variable | cut -f10 -d'|' | awk '{ print $2 }'`
  #ref_num="$ref_num1   $ref_num2"                                
 
  echo "nombreLogico=" `echo $variable | cut -f2 -d'|'`
  echo "nombreFisico=" `echo $variable | cut -f3 -d'|'`
  echo "fecha=" `echo $variable | cut -f4 -d'|'`
  echo "estatus=" `echo $variable | cut -f5 -d'|'`
  echo "estatusUsu=" `echo $variable | cut -f6 -d'|'`
  echo "mensaje=" `echo $variable | cut -f7 -d'|'`
  echo "accion=" `echo $variable | cut -f8 -d'|'`
  echo "fecha_JulReg=" `echo $variable | cut -f9 -d'|' | sed 's/ //g'`
  #ref_num=`echo $variable | cut -f10 -d'|'`
  ref_num1=`echo $variable | cut -f10 -d'|' | awk '{ print $1 }'`
  ref_num2=`echo $variable | cut -f10 -d'|' | awk '{ print $2 }'`
  echo "ref_num=" "$ref_num1   $ref_num2"                                

  
 
  nombreLogicoIns=$nombreLogico
  FECARCH=$(echo $nombreLogico | awk '{print substr($0,5,4)}')
  nombreFisicoIns=$nombreFisico
  estatusIns=$estatus
  estatusUsuIns=$estatusUsu
  mensajeIns=$mensaje
  accionIns=$accion
  ref_numIns=$ref_num
  
  echo "ref_num : $ref_num"
  echo "fecha_JulReg:  $fecha_JulReg"
  echo "nombreLogicoIns"
  echo "nombreLogicoIns"
  echo "$nombreFisicoIns"
  echo "$estatusIns"
  echo "$estatusUsuIns"
  echo "$mensajeIns"
  echo "$accionIns"
  echo "$ref_numIns"
fi

if [ $terminaPrograma -eq 0 ]
then 
  echo ""
  echo "Obtengo los siguientes parametros"
  horaProceso=`date '+%H%M'`
  fecha_hoyJuliana=`date '+%Y%j'`           
  fecha_hoy=`date '+%Y%m%d'`
  echo "horaProceso:$horaProceso"
  echo "fecha_hoyJuliana:$fecha_hoyJuliana"
  echo "fecha_JulReg:$fecha_JulReg"
  echo "fecha_hoy:$fecha_hoy"
  
  if [ fecha_hoyJuliana -lt fecha_JulReg ]
  then
    errores="La fecha sistema es menor a la fecha del registro en MTCPRO02" 
    echo "Fecha proceso:  $fecha_proceso" 
    echo "Nombre archivo: " 
    echo "Programa:       " 
    echo "Error: $errores"
    terminaPrograma=1 
  else
    difDias=`diffDias $fecha_JulReg $fecha_hoyJuliana`
    #echo "$difDias"
  fi

  diasLimite=`grep -F diasLimite $DIR_PARAM/parametros | cut -f2 -d'|'` 
  horaLimiteCDF=`grep -F horaLimiteCDF $DIR_PARAM/parametros | cut -f2 -d'|'` 
   echo "        horaProceso     : $horaProceso"
   echo "        fecha_hoyJuliana: $fecha_hoyJuliana"
   echo "        fecha_hoySQL    : $fecha_hoySQL"
   echo "        fecha_hoy       : $fecha_hoy"
   echo "        difDias         : $difDias"
   echo "        diasLimite      : $diasLimite"
   echo "        horaLimiteCDF   : $horaLimiteCDF"
   echo "   fecha nombre Logico  : $nombreLogico"
   echo "   fecha nombre Fisico  : $nombreFisico"
   echo "   fecha proceso        : $fecha_proceso"
   echo "   fecha Jul Registro   : $fecha_JulReg"
   echo "   estatus del registro : $estatus"
   echo ""
fi

# Si el estatus es 0, 2, 7, 10, 30, 32, 37 o 40 busca archivo
if [ $estatus -eq 0 -o $estatus -eq 2 -o $estatus -eq 7 -o $estatus -eq 10 -o $estatus -eq 30 -o $estatus -eq 32 -o $estatus -eq 37 -o $estatus -eq 40 ] && [ $terminaPrograma -eq 0 ]
then
  # Valida espacio en UNIX
#__HP_Changes for linux migration -Start
#changed bdf to df --direct 
  #espUNIXMegas=`bdf | grep '/opt/c430/000$' | tr -s ' ' | cut -d' ' -f4`
  espUNIXMegas=`df --direct | grep '/opt/c430/000$' | tr -s ' ' | cut -d' ' -f4`
#_HP_Changes for linux migration -End
espacioRequerido=30000
  echo "espUNIXMegas:${espUNIXMegas}"
espUNIXKBytes=`echo "$espUNIXMegas * 1024 - 1024" | bc` #le da un margen
echo "espUNIXKBytes:$espUNIXKBytes"
result=`expr $espUNIXKBytes \<= $espacioRequerido`
  echo "result = $result"

  if [ $result -eq 1 ]
  then
    estatusIns=6
    estatusUsuIns=6
    mensajeIns='Espacio UNIX insuficiente para la respuesta del CDF'
    accionIns=''
    insertaMTCPRO02=1 

    errores="Espacio UNIX insuficiente"
    echo "Fecha proceso:  $fecha_proceso" 
    echo "Nombre archivo: " 
    echo "Programa:       " 
    echo "Error: $errores"
    terminaPrograma=1
  else
    echo "OK ESPACIO SUFICIENTE\n"
  fi

  if [ $terminaPrograma -eq 0 ]
  then
    echo "valida que haya llegado archivo de respuesta de Master Card"  
    totArch=`ls $DIR_ARCH | grep -c -f $DIR_PARAM/arch.list`      
    echo "Numero de archivos encontrados: $totArch"
    llegoArchivo=0
    if [ $totArch -gt 0 ]
    then
      ArchsQueCoinciden=0
      ls $DIR_ARCH | grep -f $DIR_PARAM/arch.list | \
      while read archResp    #{
      do
        archRespCDF=$archResp
        echo "archRespCDF: $archRespCDF"
        #Checa que el archivo tenga permisos para poder leerlo
        if [ -r $DIR_ARCH/$archRespCDF ]
        then
          echo "El archivo tiene permisos"
          # Valida que el archivo llego completo, espera por
          # lo menos 15 minutos a que termine de llegar 
    
          tiempoInicial=`date '+%Y%j%H%M'`
          tiempoFinal=$tiempoInicial
          tiempoMaxEspera=0
          #tiempoMaxEspera=15 #tiempo en minutos
    
          bandera=0
          lapso=0
          tamano=`ls -l $DIR_ARCH/$archRespCDF | tr -s ' ' | cut -d' ' -f5`
          echo "TAMANO $tamano   , $tiempoInicial   , $tiempoFinal\n"
          while [ -f $DIR_ARCH/$archRespCDF -a $lapso -le $tiempoMaxEspera -a $bandera -eq 0 ]
          do
            echo "Entro a revisar el archivo enviado por mc"
            trailer=`tail -1 $DIR_ARCH/$archRespCDF | cut -c1-4`
            echo "TRAILER DE $archRespCDF = $trailer :"
            if [ "$trailer" = "1100" ]
             then
              FECARCH2=$(echo "$archRespCDF" | awk '{print substr($0,4,4)}')
                ## Antes cut -c100-123   y cut -c186-191
                nomArchEnviado=`tail -1 $DIR_ARCH/$archRespCDF | cut -c106-129`
                regsRechazados=`tail -1 $DIR_ARCH/$archRespCDF | cut -c192-197`
                bandera=1
                echo "nomArchEnviado:'$nomArchEnviado'"
                echo "ref_num: '$ref_num'"
                if [ "$nomArchEnviado" = "$ref_num" ]
                then
                  llegoArchivo=1 
                  ArchsQueCoinciden=`expr $ArchsQueCoinciden + 1`
                  if [ $ArchsQueCoinciden -gt 1 ]
                  then
                    errores="Se recibio mas de un archivo a procesar. Verificar trailers en la posicion 100-123"
                    echo "Fecha proceso: $fecha_proceso" 
                    echo "Nombre archivo:"
                    echo "Programa:      "
                    echo "Error: $errores"
                    terminaPrograma=1 
                  fi
               #yuria
               else
                  echo 'La referencia del archivo y la referencia de tabla no igual'
               #yuria
                fi
            else
              tiempoFinal=`date '+%Y%j%H%M'`
              echo "TIEMPO FINAL $tiempoFinal   TIEMPO INICIAL $tiempoInicial"
              if [ $tiempoFinal -lt $tiempoInicial ]
              then
                errores="Modificaron la fecha UNIX"
                echo "Fecha proceso:  $fecha_proceso"
                echo "Nombre archivo: $archRespCDF"
                echo "Programa:       "
                echo "Error: $errores"
                exit 0
              else
                lapso=`$DIR_CARGA/diffTime $tiempoInicial $tiempoFinal`
                echo "LAPSO $lapso"
                if [ $lapso -gt $tiempoMaxEspera ]
                then
                  mv $DIR_ARCH/* $DIR_BACK
                  errores="El archivo llego incompleto. Ya se respaldo"
                  echo "Fecha proceso:  $fecha_proceso"
                  echo "Nombre archivo: $archRespCDF"
                  echo "Programa:       "
                  echo "Error: $errores"
                  llegoArchivo=0
                fi
              fi
            fi
          done
        else
          llegoArchivo=0
          errores="El archivo que llego no tiene permisos para ser leido"
          echo "Fecha proceso:  $fecha_proceso"
          echo "Nombre archivo: $archRespCDF"
          echo "Programa:       "
          echo "Error: $errores"
        fi
      done  #}
    else # no se ha recibido respuesta crea archivo vacio para connect direct
      nomarch=OS011CDF.F$fecha_proceso
      echo "nomarch:$nomarch"
      totArchUno=`ls $(paths.sh 04 DEP) | grep -c $nomarch` 
      echo "Numero de archivos encontrados: $totArchUno"
      if [ $totArchUno -eq 0 ]
      then         
        echo "touch $(paths.sh 04 DEP)/$nomarch"
        touch $(paths.sh 04 DEP)/$nomarch       
        echo "touch $(paths.sh 04 DEP)/control${fecha_proceso}.ctrl"
        touch $(paths.sh 04 DEP)/control${fecha_proceso}.ctrl       
      fi
    fi
  fi
fi

# Obtiene la diferencia en dias transcurridos para los estatus 7 y 37
if [ $estatus -eq 7 -o $estatus -eq 37 ] && [ $terminaPrograma -eq 0 ]
then
  if [ $estatus -eq 7 ] 
  then  
    estatusSql=0
  else
    estatusSql=30
  fi
  echo "select '|'+                     " > $DIR_CARGA/fhJul.txt    
  echo "ltrim(str(datepart(yy,pro_fecha)))+" >> $DIR_CARGA/fhJul.txt
  echo "ltrim(str(datepart(dayofyear,pro_fecha)))+'|'" >> $DIR_CARGA/fhJul.txt
  echo "from MTCPRO02                   " >> $DIR_CARGA/fhJul.txt 
  echo "where pro_fecha=                " >> $DIR_CARGA/fhJul.txt
  echo "(select max(pro_fecha)          " >> $DIR_CARGA/fhJul.txt
  echo "from MTCPRO02                   " >> $DIR_CARGA/fhJul.txt
  echo "where pro_estatus=$estatusSql   " >> $DIR_CARGA/fhJul.txt
  echo "and pro_nomLogi='"$nombreLogico"')" >> $DIR_CARGA/fhJul.txt
  echo "go                              " >> $DIR_CARGA/fhJul.txt
  resultado=`isql -U${GE_USER} -P${GE_PASSWORD} -D$(base.sh) -S${GE_SERVER} -w1200 -i $DIR_CARGA/fhJul.txt`
  checa=`echo $resultado | grep -c "|"`
  if [ $checa -ne 1 ]                 
  then                                
    errores="No se pudo consultar la tabla MTCPRO02. Ver el archivo $DIR_CARGA/fhJul.txt"
    echo "Fecha proceso:  $fecha_proceso" 
    echo "Nombre archivo: " 
    echo "Programa:       " 
    echo "Error: $errores"
    terminaPrograma=1
  else
    fecha_JulReg=`echo $resultado | cut -f2 -d'|'`
    difDias=`diffDias $fecha_JulReg $fecha_hoyJuliana`
  fi 
fi

if [ $estatus -eq 0 -o $estatus -eq 2 -o $estatus -eq 7 -o $estatus -eq 10 ] && [ $terminaPrograma -eq 0 ]
then 
  if [ $llegoArchivo -eq 1 ]                                          
  then
    #nombreFisicoIns=$archRespCDF
    nombreFisicoIns="CNF$FECARCH.txt" 
    estatusIns=4
    estatusUsuIns=0
    mensajeIns='Se esta procesando respuesta MC'
    accionIns=''
    echo "insert MTCPRO02          " > $DIR_CARGA/insertEstatus4.txt
    echo " (pro_nomLogi            " >> $DIR_CARGA/insertEstatus4.txt
    echo " ,pro_nomFisi            " >> $DIR_CARGA/insertEstatus4.txt
    echo " ,pro_fecha              " >> $DIR_CARGA/insertEstatus4.txt 
    echo " ,pro_estatus            " >> $DIR_CARGA/insertEstatus4.txt 
    echo " ,pro_est_usu            " >> $DIR_CARGA/insertEstatus4.txt
    echo " ,pro_mensaje            " >> $DIR_CARGA/insertEstatus4.txt
    echo " ,pro_accion             " >> $DIR_CARGA/insertEstatus4.txt
    echo " ,pro_ref_num)           " >> $DIR_CARGA/insertEstatus4.txt
    echo "values('$nombreLogicoIns'" >> $DIR_CARGA/insertEstatus4.txt
    echo "      ,'$nombreFisicoIns'" >> $DIR_CARGA/insertEstatus4.txt 
    echo "      ,getdate()         " >> $DIR_CARGA/insertEstatus4.txt 
    echo "      ,$estatusIns       " >> $DIR_CARGA/insertEstatus4.txt 
    echo "      ,$estatusUsuIns    " >> $DIR_CARGA/insertEstatus4.txt 
    echo "      ,'$mensajeIns'     " >> $DIR_CARGA/insertEstatus4.txt 
    echo "      ,'$accionIns'      " >> $DIR_CARGA/insertEstatus4.txt
    echo "      ,'$ref_numIns')    " >> $DIR_CARGA/insertEstatus4.txt
    echo "go                       " >> $DIR_CARGA/insertEstatus4.txt
    checaTabla=`isql -U${GE_USER} -P${GE_PASSWORD} -D$(base.sh) -S${GE_SERVER} -i $DIR_CARGA/insertEstatus4.txt`

    if [ "$checaTabla" != "(1 row affected)" ] 
    then                  
      errores="No se puede actualizar la tabla MTCPRO02."
      echo "Fecha proceso:  $fecha_proceso" 
      echo "Nombre archivo: " 
      echo "Programa:       " 
      echo "Error: $errores"
      exit 0
    fi 

    # Se ejecuta el proceso de evaluacion de respuesta MC
    $DIR_CARGA/ActRech $DIR_ARCH/$archRespCDF
    if [ $? != 0 ]
    then
      estatusIns=8
      estatusUsuIns=8
      mensajeIns='Error al evaluar respuesta MasterCard'
      accionIns='Corregir manualmente errores del proceso Ejecuta Respuesta CDF, poner estatus 2'
      insertaMTCPRO02=1 
      errores="Error al evaluar respuesta MC"
      echo "Fecha proceso:  $fecha_proceso" 
      echo "Nombre archivo: $archRespCDF" 
      echo "Programa:       ActRech" 
      echo "Error: $errores"
    else
      #$DIR_CARGA/DepAcep
      $DIR_CARGA/depura.sh
      if [ $? != 0 ]
      then
        estatusIns=8
        estatusUsuIns=8
        mensajeIns='Error al evaluar respuesta MasterCard'
        accionIns='Corregir manualmente errores del proceso Ejecuta Respuesta CDF, poner estatus 2'
        insertaMTCPRO02=1 
        errores="Error al evaluar respuesta MC"
        echo "Fecha proceso:  $fecha_proceso" 
        echo "Nombre archivo: $archRespCDF" 
        echo "Programa:       depura.sh" 
        echo "Error: $errores"
      else
        mv $DIR_ARCH/* $DIR_BACK
        if [ $regsRechazados != "000000" ] 
        then
          estatusIns=9
          estatusUsuIns=8
          mensajeIns='Errores en registros de CDF enviados que reporto MC'
          accionIns='Corregir reg rech por MC manualmente, poner estatus 20'
          insertaMTCPRO02=1 
        else
          estatusIns=3
          estatusUsuIns=0
          mensajeIns='Se recibio respuesta MC sin errores'
          accionIns=''
          insertaMTCPRO02=1 
        fi
      fi
    fi
  else
    if [ $fecha -lt $fecha_hoy ]
    then
      if [ $estatus -eq 0 ]
      then
        if [ $difDias -lt $diasLimite ]
        then 
          estatusIns=7
          estatusUsuIns=0
          mensajeIns='Esperando archivo de respuesta MC'
          accionIns=''
          insertaMTCPRO02=1 
        else
          # echo "diferencia en dias > a los dias limite"
          estatusIns=10
          estatusUsuIns=8
          mensajeIns='Se envio el archivo CDF y no se recibio respuesta de MC en tiempo establecido'
          accionIns='Validar con MC porque no se ha recibido respuesta, No cambiar estatus'
          insertaMTCPRO02=1 
        fi
      fi
      if [ $estatus -eq 2 ]
      then 
        estatusIns=2
        estatusUsuIns=8
        mensajeIns='Se corrigio problema en el proceso Ejecuta Respuesta CDF'
        accionIns=''
        insertaMTCPRO02=1 
      fi
      if [ $estatus -eq 7 ]
      then 
        if [ $difDias -lt $diasLimite ]
        then 
          estatusIns=7
          estatusUsuIns=0
          mensajeIns='Esperando archivo de respuesta MC'
          accionIns=''
          insertaMTCPRO02=1 
        else
          # echo "diferencia en dias > a los dias limite"
          estatusIns=10
          estatusUsuIns=8
          mensajeIns='Se envio el archivo CDF y no se recibio respuesta de MC en tiempo establecido'
          accionIns='Validar con MC porque no se ha recibido respuesta, No cambiar estatus'
          insertaMTCPRO02=1 
        fi
      fi
      if [ $estatus -eq 10 ]
      then 
        estatusIns=10
        estatusUsuIns=8
        mensajeIns='Se envio el archivo CDF y no se recibio respuesta de MC en tiempo establecido'
        accionIns='Validar con MC porque no se ha recibido respuesta, No cambiar estatus'
        insertaMTCPRO02=1 
      fi
    fi
  fi
fi

if [ $estatus -eq 1 -a $terminaPrograma -eq 0 ]
then 
  if [ $fecha -lt $fecha_hoy ]
  then 
    estatusIns=1
    estatusUsuIns=6
    mensajeIns='Se debe volver a generar el archivo CDF'
    accionIns='Se volvera a iniciar proceso automatico'
    insertaMTCPRO02=1 
  fi
fi

if [ $estatus -eq 3 -a $terminaPrograma -eq 0 ]
then 
  if [ $fecha -lt $fecha_hoy ]
  then 
    if [ $horaProceso -gt $horaLimiteCDF ]
    then 
      estatusIns=12
      estatusUsuIns=6
      mensajeIns='No se ha iniciado generacion de archivo CDF y ya se debio de haber generado'
      accionIns=''
      insertaMTCPRO02=1 
    else
      estatusIns=3
      estatusUsuIns=0
      mensajeIns='Se recibio respuesta MC sin errores'
      accionIns=''
      insertaMTCPRO02=1 
    fi
  else
    if [ $horaProceso -gt $horaLimiteCDF ]
    then 
      estatusIns=12
      estatusUsuIns=6
      mensajeIns='No se ha iniciado generacion de archivo CDF y ya se debio de haber generado'
      accionIns=''
      insertaMTCPRO02=1 
    fi
  fi
fi

if [ $estatus -eq 6 -a $terminaPrograma -eq 0 ]
then 
  if [ $fecha -lt $fecha_hoy ]
  then 
    estatusIns=6
    estatusUsuIns=6
    mensajeIns='Error al generar archivo CDF'
    accionIns=''
    insertaMTCPRO02=1 
  fi
fi

if [ $estatus -eq 8 -a $terminaPrograma -eq 0 ]
then 
  if [ $fecha -lt $fecha_hoy ]
  then 
    estatusIns=8
    estatusUsuIns=8
    mensajeIns='Error al evaluar archivo respuesta MC'
    accionIns=''
    insertaMTCPRO02=1 
  fi
fi

if [ $estatus -eq 9 -a $terminaPrograma -eq 0 ]
then 
  if [ $fecha -lt $fecha_hoy ]
  then 
    estatusIns=9
    estatusUsuIns=8
    mensajeIns='Errores en registros de CDF enviados que reporto MC'
    accionIns='Corregir reg rechazados por MC manualmente, poner un estatus 20'
    insertaMTCPRO02=1 
  fi
fi

if [ $estatus -eq 11 -a $terminaPrograma -eq 0 ]
then 
  if [ $fecha -lt $fecha_hoy ]
  then 
    estatusIns=11
    estatusUsuIns=8
    mensajeIns='Ya se tardo mucho en procesar respuesta de MC'
    accionIns=''
    insertaMTCPRO02=1 
  fi
fi

if [ $estatus -eq 12 -a $terminaPrograma -eq 0 ]
then 
  if [ $fecha -lt $fecha_hoy ]
  then 
    estatusIns=12
    estatusUsuIns=6
    mensajeIns='No se ha iniciado generacion de archivo CDF y ya se debio de haber generado'
    accionIns=''
    insertaMTCPRO02=1 
  fi
fi

if [ $estatus -eq 14 -a $terminaPrograma -eq 0 ]
then 
  if [ $fecha -lt $fecha_hoy ]
  then 
    estatusIns=14
    estatusUsuIns=8
    mensajeIns='Ya se tardo mucho en generar archivo CDF'
    accionIns=''
    insertaMTCPRO02=1 
  fi
fi

if [ $estatus -eq 20 -a $terminaPrograma -eq 0 ]
then 
  if [ $fecha -lt $fecha_hoy ]
  then 
    estatusIns=20
    estatusUsuIns=0
    mensajeIns='Registros corregidos'
    accionIns='Iniciar reproceso'
    insertaMTCPRO02=1 
  fi
fi

if [ $estatus -eq 30 -o $estatus -eq 32 -o $estatus -eq 37 -o $estatus -eq 40 ] && [ $terminaPrograma -eq 0 ]
then 
  if [ $llegoArchivo -eq 1 ]                                          
  then
    nombreFisicoIns="CNF$FECARCH.txt" 
    #nombreFisicoIns=$archRespCDF
    estatusIns=34
    estatusUsuIns=0
    mensajeIns='Se esta reprocesando respuesta MC'
    accionIns=''
    echo "insert MTCPRO02          " > $DIR_CARGA/insertEstatus4.txt
    echo " (pro_nomLogi            " >> $DIR_CARGA/insertEstatus4.txt
    echo " ,pro_nomFisi            " >> $DIR_CARGA/insertEstatus4.txt
    echo " ,pro_fecha              " >> $DIR_CARGA/insertEstatus4.txt 
    echo " ,pro_estatus            " >> $DIR_CARGA/insertEstatus4.txt 
    echo " ,pro_est_usu            " >> $DIR_CARGA/insertEstatus4.txt
    echo " ,pro_mensaje            " >> $DIR_CARGA/insertEstatus4.txt
    echo " ,pro_accion             " >> $DIR_CARGA/insertEstatus4.txt
    echo " ,pro_ref_num)           " >> $DIR_CARGA/insertEstatus4.txt
    echo "values('$nombreLogicoIns'" >> $DIR_CARGA/insertEstatus4.txt
    echo "      ,'$nombreFisicoIns'" >> $DIR_CARGA/insertEstatus4.txt 
    echo "      ,getdate()         " >> $DIR_CARGA/insertEstatus4.txt 
    echo "      ,$estatusIns       " >> $DIR_CARGA/insertEstatus4.txt 
    echo "      ,$estatusUsuIns    " >> $DIR_CARGA/insertEstatus4.txt 
    echo "      ,'$mensajeIns'     " >> $DIR_CARGA/insertEstatus4.txt 
    echo "      ,'$accionIns'      " >> $DIR_CARGA/insertEstatus4.txt
    echo "      ,'$ref_numIns')    " >> $DIR_CARGA/insertEstatus4.txt
    echo "go                       " >> $DIR_CARGA/insertEstatus4.txt
    checaTabla=`isql -U${GE_USER} -P${GE_PASSWORD} -D$(base.sh) -S${GE_SERVER} -i $DIR_CARGA/insertEstatus4.txt`

    if [ "$checaTabla" != "(1 row affected)" ] 
    then                  
      errores="No se puede actualizar la tabla MTCPRO02."
      echo "Fecha proceso:  $fecha_proceso" 
      echo "Nombre archivo: " 
      echo "Programa:       " 
      echo "Error: $errores"
      exit 0
    fi 

    # echo "Se ejecuta el proceso de evaluacion de respuesta Mastercard"
    $DIR_CARGA/ActRech $DIR_ARCH/$archRespCDF
    if [ $? != 0 ]
    then
      estatusIns=38
      estatusUsuIns=38
      mensajeIns='Error al evaluar respuesta MC'
      accionIns='Corregir manualmente errores del proceso Ejecuta Respuesta CDF, poner estatus 2'
      insertaMTCPRO02=1 
      errores="Error al evaluar respuesta MC"
      echo "Fecha proceso:  $fecha_proceso" 
      echo "Nombre archivo: $archRespCDF" 
      echo "Programa:       ActRech" 
      echo "Error: $errores"
    else
      #$DIR_CARGA/DepAcep
      $DIR_CARGA/depura.sh
      if [ $? != 0 ]
      then
        estatusIns=38
        estatusUsuIns=38
        mensajeIns='Error al evaluar respuesta MC'
        accionIns='Corregir manualmente errores del proceso Ejecuta Respuesta CDF, poner estatus 2'
        insertaMTCPRO02=1 
        errores="Error al evaluar respuesta MC"
        echo "Fecha proceso:  $fecha_proceso" 
        echo "Nombre archivo: $archRespCDF" 
        echo "Programa:       depura.sh" 
        echo "Error: $errores"
      else
        mv $DIR_ARCH/* $DIR_ARCH2
        if [ $regsRechazados != "000000" ] 
        then
          estatusIns=9
          estatusUsuIns=8
          mensajeIns='Errores en registros de CDF enviados que reporto MC'
          accionIns='Corregir reg rech por MC manualmente, poner estatus 20'
          insertaMTCPRO02=1 
        else
          estatusIns=3
          estatusUsuIns=0
          mensajeIns='Se recibio respuesta MC sin errores'
          accionIns=''
          insertaMTCPRO02=1 
        fi
      fi
    fi
  else
    if [ $fecha -lt $fecha_hoy ]
    then
      if [ $estatus -eq 30 ]
      then
        if [ $difDias -lt $diasLimite ]
        then 
          estatusIns=37
          estatusUsuIns=0
          mensajeIns='Esperando archivo de respuesta MC reproceso'
          accionIns=''
          insertaMTCPRO02=1 
        else
          # echo "diferencia en dias > a los dias limite"
          estatusIns=40
          estatusUsuIns=38
          mensajeIns='Se envio el archivo CDF reprocesado y no se recibio respuesta de MC en tiempo establecido'
          accionIns='Validar con MC porque no se ha recibido respuesta, No cambiar estatus'
          insertaMTCPRO02=1 
        fi
      fi
      if [ $estatus -eq 32 ]
      then 
        estatusIns=32
        estatusUsuIns=0
        mensajeIns='Se corrigio problema en el reproceso Ejecuta Respuesta CDF'
        accionIns=''
        insertaMTCPRO02=1 
      fi
      if [ $estatus -eq 37 ]
      then 
        if [ $difDias -lt $diasLimite ]
        then 
          estatusIns=37
          estatusUsuIns=0
          mensajeIns='Esperando archivo de respuesta MC reproceso'
          accionIns=''
          insertaMTCPRO02=1 
        else
          # echo "diferencia en dias > a los dias limite"
          estatusIns=40
          estatusUsuIns=38
          mensajeIns='Se envio el archivo CDF reprocesado y no se recibio respuesta de MC en tiempo establecido'
          accionIns='Validar con MC porque no se ha recibido respuesta, No cambiar estatus'
          insertaMTCPRO02=1 
        fi
      fi
      if [ $estatus -eq 40 ]
      then 
        estatusIns=40
        estatusUsuIns=38
        mensajeIns='Se envio el archivo CDF reprocesado y no se recibio respuesta de MC en tiempo establecido'
        accionIns='Validar con MC porque no se ha recibido respuesta, No cambiar estatus'
        insertaMTCPRO02=1 
      fi
    fi
  fi
fi

if [ $estatus -eq 31 -a $terminaPrograma -eq 0 ]
then 
  if [ $fecha -lt $fecha_hoy ]
  then 
    estatusIns=31
    estatusUsuIns=36
    mensajeIns='Se debe volver a generar el archivo CDF reproceso'
    accionIns='Se volvera a iniciar proceso automatico'
    insertaMTCPRO02=1 
  fi
fi

if [ $estatus -eq 36 -a $terminaPrograma -eq 0 ]
then 
  if [ $fecha -lt $fecha_hoy ]
  then 
    estatusIns=36
    estatusUsuIns=36
    mensajeIns='Error al generar archivo CDF reproceso'
    accionIns=''
    insertaMTCPRO02=1 
  fi
fi

if [ $estatus -eq 38 -a $terminaPrograma -eq 0 ]
then 
  if [ $fecha -lt $fecha_hoy ]
  then 
    estatusIns=38
    estatusUsuIns=38
    mensajeIns='Error al evaluar archivo respuesta MC reproceso'
    accionIns=''
    insertaMTCPRO02=1 
  fi
fi

if [ $estatus -eq 41 -a $terminaPrograma -eq 0 ]
then 
  if [ $fecha -lt $fecha_hoy ]
  then 
    estatusIns=41
    estatusUsuIns=38
    mensajeIns='Ya se tardo mucho en reprocesar archivo de respuesta'
    accionIns=''
    insertaMTCPRO02=1 
  fi
fi

if [ $estatus -eq 44 -a $terminaPrograma -eq 0 ]
then 
  if [ $fecha -lt $fecha_hoy ]
  then 
    estatusIns=44
    estatusUsuIns=38
    mensajeIns='Ya se tardo mucho en generar archivo CDF reproceso'
    accionIns=''
    insertaMTCPRO02=1 
  fi
fi

if [ $insertaMTCPRO02 -eq 1 ]
then                  
  echo "insert MTCPRO02          " > $DIR_CARGA/insertMTCPRO02.txt
  echo " (pro_nomLogi            " >> $DIR_CARGA/insertMTCPRO02.txt
  echo " ,pro_nomFisi            " >> $DIR_CARGA/insertMTCPRO02.txt
  echo " ,pro_fecha              " >> $DIR_CARGA/insertMTCPRO02.txt 
  echo " ,pro_estatus            " >> $DIR_CARGA/insertMTCPRO02.txt 
  echo " ,pro_est_usu            " >> $DIR_CARGA/insertMTCPRO02.txt
  echo " ,pro_mensaje            " >> $DIR_CARGA/insertMTCPRO02.txt
  echo " ,pro_accion             " >> $DIR_CARGA/insertMTCPRO02.txt
  echo " ,pro_ref_num)           " >> $DIR_CARGA/insertMTCPRO02.txt
  echo "values('$nombreLogicoIns'" >> $DIR_CARGA/insertMTCPRO02.txt
  echo "      ,'$nombreFisicoIns'" >> $DIR_CARGA/insertMTCPRO02.txt 
  echo "      ,getdate()         " >> $DIR_CARGA/insertMTCPRO02.txt 
  echo "      ,$estatusIns       " >> $DIR_CARGA/insertMTCPRO02.txt 
  echo "      ,$estatusUsuIns    " >> $DIR_CARGA/insertMTCPRO02.txt 
  echo "      ,'$mensajeIns'     " >> $DIR_CARGA/insertMTCPRO02.txt 
  echo "      ,'$accionIns'      " >> $DIR_CARGA/insertMTCPRO02.txt
  echo "      ,'$ref_numIns')    " >> $DIR_CARGA/insertMTCPRO02.txt
  echo "go                       " >> $DIR_CARGA/insertMTCPRO02.txt
  checaTabla=`isql -U${GE_USER} -P${GE_PASSWORD} -D$(base.sh) -S${GE_SERVER} -i $DIR_CARGA/insertMTCPRO02.txt`

  if [ "$checaTabla" != "(1 row affected)" ] 
  then                  
    errores="No se puede actualizar la tabla MTCPRO02."
    echo "Fecha proceso:  $fecha_proceso" 
    echo "Nombre archivo: " 
    echo "Programa:       " 
    echo "Error: $errores"
  fi 
fi 
