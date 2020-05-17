/* NOMBRE       : C430CreateTempTables                                       */
/* DESCRIPCION	: Permite crear las tablas temporales que se requieran para  */
/*                colocar en ellas posteriormente la informacion contenida   */
/*                en un archivo CCF Unico.                                   */
/* PARAMETROS 	:                                                            */
/*    argv[1] = Usuario de Base De Datos                                     */
/*    argv[2] = Password de Base de Datos                                    */
/*    argv[3] = Servidor donde se encuentra la Base de Datos                 */
/*    argv[4] = Tipo de archivo Unico a procesar:                            */
/*                 D - Diario.                                               */
/*                 C - Por Corte.                                            */
/*    argv[5] = Nombre del archivo donde estan concentrados los registros    */
/*              a procesar (Tipos).                                          */
/*    argv[6] = Fecha de Procesamiento.                                      */
/*    argv[7] = No. de Registros contenidos en el archivo a procesar.        */
/* SALIDAS      : Tablas Temporales para el archivo Unico.                   */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 11/09/2003                                                 */
/* CONTROL DE                                                                */
/* VERSIONES    : V.1.0                                                      */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     11/09/2003     Primera Version         */
/*     FUN Felipe Uribe Negrón        21/12/2004     Segunda Version         */
/* Copyright Derechos Reservados Banamex S.A. de C.V 2003a                   */
/*   Observaciones:                                                          */
/*                                                                           */

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "C430CreateTempTables.h"

EXEC SQL INCLUDE SQLCA;

#if defined(__STDC__) || defined(__cplusplus)
int main(int argc, char *argv[])             
#else                                        
int main(argc, argv)                         
int argc;                                    
char *argv[];                                
#endif                                       
{
   EXEC SQL BEGIN DECLARE SECTION;
      char sUsername[LEN30+1];	 /* Usuario. */
      char sPassword[LEN30+1];   /* Password. */
      char sServer[LEN30+1];     /* Servidor. */
   EXEC SQL END DECLARE SECTION;


   /* El No. de Parametros pasados a la aplicacion es incorrecto. */

   if(argc != 8)   
   {
      printf("\nUse: C430CreateTempTables <User> <Password> <Server>\n");
      printf("                          <File Type> <File Name> <Process Date>\n");
      printf("                          <No. of Records>\n");
      exit(ERREXIT);
   }

   /* Definicion de rutinas para manejo de errores y mensajes de
      alerta. */

   EXEC SQL WHENEVER SQLERROR CALL error_handler();
   EXEC SQL WHENEVER SQLWARNING CALL warning_handler();
   EXEC SQL WHENEVER NOT FOUND CONTINUE;

   strcpy(sUsername, argv[1]);
   strcpy(sPassword, argv[2]);
   strcpy(sServer, argv[3]);

   /* Conexion al servidor de SYBASE. */

   EXEC SQL CONNECT :sUsername IDENTIFIED BY :sPassword USING :sServer;

   /* Cambio a Base de Datos Sistema Tarjeta Corporativa. */

   EXEC SQL USE M111;    

   /* Creacion de tablas temporales asociadas al archivo CCF. */

   iC430CreateTables_CCF(argv);

   EXEC SQL COMMIT WORK;

   EXEC SQL DISCONNECT ALL;

   exit(STDEXIT);
}

/* NOMBRE       : iC430CreateTables_CCF                                      */
/* DESCRIPCION	: Crea las tablas temporales asociadas a cada uno de los     */
/*                Tipos de Registros contenidos en un archivo CCF determina- */
/*                do (asi como sus respectivos indices).                     */
/* PARAMETROS 	:                                                            */
/*    psParams[4] = Tipo de archivo(s) a procesar:                           */
/*                 C - Diario.                                               */
/*                 D - Por Corte.                                            */
/*    psParams[5] = Nombre del archivo donde estan concentrados los          */
/*                  registros a procesar.                                    */
/*    psParams[6] = Fecha de Procesamiento.                                  */
/*    psParams[7] = No. de Registros contenidos en el archivo a procesar.    */
/* SALIDAS      : Estatus de conclusion de la rutina:                        */
/*                0 - Exito.                                                 */
/*                1 - Falla.                                                 */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 11/09/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     11/09/2003     Primera Version         */
/*     FUN Felipe Uribe Negrón        21/12/2004     Segunda Version         */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
int iC430CreateTables_CCF(char *psParams[])             
#else                                        
int iC430CreateTables_CCF(psParams)                         
char *psParams[];                                
#endif                                       
{
   EXEC SQL BEGIN DECLARE SECTION;

      /* Identificador de Tabla de Registros en formato CCF. */

      int  iTableID;


      /* Identificador de Indice sobre Tabla de Registros en formato CCF. */

      int  iIndexID;

      
      /* Indice asignado a la Tabla de Registros del archivo CCF. */

      char sIndexName[LEN30+1];


      /* Comando de SQL a ejecutar en la Base de Datos. */

      char sSQLCommand[LEN5000+1];

   EXEC SQL END DECLARE SECTION;


   char sFileType[LEN1+1];      /* Tipo de Archivo Unico a Procesar (Diario / Por Corte). */

   int  iNumRecords;            /* No. de Registros contenidos en el archivo. */

   FILE *pFile;                 /* Puntero al archivo. */

   char sFileGenDate[LEN4+1];   /* Fecha de Generacion del archivo Unico CCF. */

   char sTableName[LEN30+1];    /* Nombre de la Tabla donde seran colocados
                                   los registros del archivo Unico CCF. */

   char sRecord[LEN10+1];       /* Registro correspondiente al archivo de 
                                   Tipos. */

   char sRecordType[LEN4+1];    /* Tipo de Registro Analizado. */  

   char **psRecords;            /* Registros recuperados del archivo de Tipos. */

   int  iCountRec;              /* Contador asociado al arreglo de Registros. */ 


   /* Inicializacion de Variables. */

   iTableID=0;
   iIndexID=0;
   iNumRecords=0;
   iCountRec=0;
   strcpy(sFileGenDate, EMPSTR);
   strcpy(sSQLCommand, EMPSTR);
   strcpy(sFileType, EMPSTR);
   strcpy(sTableName, EMPSTR);
   strcpy(sIndexName, EMPSTR);
   strcpy(sRecord, EMPSTR);
   strcpy(sRecordType, EMPSTR);

   strcpy(sFileType, psParams[4]);
   strcpy(sFileGenDate, psParams[6]);
   iNumRecords=atoi(psParams[7]);


   /* Construccion del arreglo de Registros. */

   psRecords=(char **) malloc(iNumRecords * sizeof(char *));

   for(iCountRec = 0; iCountRec < iNumRecords; iCountRec++)
   {
      *(psRecords + iCountRec) = (char *) malloc(LEN10 * sizeof(char));
      strcpy(psRecords[iCountRec], EMPSTR);
   }


   /* Recuperacion de Tipos de Registros. */

   iCountRec=0;

   /* Apertura del archivo de Tipos. */                            
                                                           
   if((pFile = fopen(psParams[5], "r")) == NULL)           
   {                                                          
      printf("\nFile %s not found.\n", psParams[5]);

      /* Elimina el espacio reservado para el arreglo de Registros. */ 

      for(iCountRec = 0; iCountRec < iNumRecords; iCountRec++)

         free(psRecords[iCountRec]);

      free(psRecords);

      exit(ERREXIT);                                          
   }       

   fgets(sRecord, LEN10, pFile); 

   while(!feof(pFile)){

      strcpy(psRecords[iCountRec], sRecord);

      strcpy(sRecord, EMPSTR);          
                                     
      fgets(sRecord, LEN10, pFile);

      iCountRec++;
   }                                    
                                     
   fclose(pFile);                    

  
   /* Construccion de Tablas Temporales. */

   for(iCountRec = 0; iCountRec < iNumRecords; iCountRec++)
   {
      iTableID=0;
      iIndexID=0;

      strcpy(sRecord, psRecords[iCountRec]);

      /* Establecer el Tipo de Registro recuperado. */

      strncpy(sRecordType, sRecord, LEN4);
      sRecordType[LEN4] = EOLN;

      /* Construir el nombre de la tabla de registros. */

      strcpy(sTableName, PREFFIXCCF);
      strcat(sTableName, sRecordType);
      strcat(sTableName, UNDERSCORE);
      strcat(sTableName, sFileGenDate);
      strcat(sTableName, sFileType);

      /* Construir el nombre del indice asociado a la tabla de registros. */ 

      strcpy(sIndexName, PREFFIXIND);
      strcat(sIndexName, sTableName);


      /* Verificar la existencia de la tabla previamente
         establecida. */

      strcpy(sSQLCommand, "SELECT isnull(object_id(\'dbo.");
      strcat(sSQLCommand, sTableName);
      strcat(sSQLCommand, "\'), 0)");

      EXEC SQL PREPARE counttable FROM :sSQLCommand;  
                                               
      EXEC SQL EXECUTE counttable INTO :iTableID;

      EXEC SQL DEALLOCATE PREPARE counttable;
                                      
      EXEC SQL COMMIT WORK;

      /* Verificar la existencia del indice asociado a la tabla previamente
         establecida. */

      EXEC SQL SELECT count(*)
               INTO :iIndexID 
               FROM sysindexes
               WHERE name = :sIndexName; 

      EXEC SQL COMMIT WORK;

      if(iTableID == 0)
      {
         /* Si la tabla no existe, crearla. */

         strcpy(sSQLCommand, "CREATE TABLE ");
         strcat(sSQLCommand, sTableName);
         strcat(sSQLCommand, " (");

         if(strcmp(sRecordType, FMTREC0000) == 0)
         {
            /* Si el Registro Analizado es el 0000, asociar a la Tabla 
               a crear los campos correspondientes. */

            strcat(sSQLCommand, "record_indicator	char(4)		not null, ");
            strcat(sSQLCommand, "type_indicator		char(3)		not null, ");
            strcat(sSQLCommand, "company_name		char(100)	not null, ");
            strcat(sSQLCommand, "company_id		char(6)		not null, ");
            strcat(sSQLCommand, "subcompany_id		char(3)		not null, ");
            strcat(sSQLCommand, "effective_file_date	char(8)		not null, ");
            strcat(sSQLCommand, "ccf_version		char(5)		not null, ");
	    strcat(sSQLCommand, "com_name_kanji_out	char(1)		NOT NULL, ");		/* FUN 21122004 */
	    strcat(sSQLCommand, "com_name_kanji		char(60)	NOT NULL, ");		/* FUN 21122004 */
	    strcat(sSQLCommand, "com_name_kanji_in	char(1)		NOT NULL, ");		/* FUN 21122004 */
	    strcat(sSQLCommand, "filler			text		not null, ");
            strcat(sSQLCommand, "trx_control_data	char(50)	not null)");
         }

         if(strcmp(sRecordType, FMTREC1000) == 0)
         {
            /* Si el Registro Analizado es el 1000, asociar a la Tabla 
               a crear los campos correspondientes. */

            strcat(sSQLCommand, "record_indicator	char(4)		not null, ");
            strcat(sSQLCommand, "type_indicator		char(3)		not null, ");
            strcat(sSQLCommand, "company_id		char(6)		not null, ");
            strcat(sSQLCommand, "subcompany_id		char(3)		not null, ");
            strcat(sSQLCommand, "corp_parent_node	char(50)	not null, ");
            strcat(sSQLCommand, "corp_child_node	char(50)	not null, ");
            strcat(sSQLCommand, "depth			char(10)	not null, ");
            strcat(sSQLCommand, "level_name		char(50)	not null, ");
            strcat(sSQLCommand, "hierarchy_type		char(10)	not null, ");
            strcat(sSQLCommand, "acct_code_id		char(10)	not null, ");
            strcat(sSQLCommand, "curr_sic_template	char(15)	not null, ");
            strcat(sSQLCommand, "future_sic_template	char(15)	not null, ");
            strcat(sSQLCommand, "report_template	char(15)	not null, ");
            strcat(sSQLCommand, "textset_template	char(15)	not null, ");
            strcat(sSQLCommand, "exception_template	char(15)	not null, ");
            strcat(sSQLCommand, "filler			text		not null, ");
            strcat(sSQLCommand, "trx_control_data	char(50)	not null)");
         }

         if(strcmp(sRecordType, FMTREC1001) == 0)
         {
            /* Si el Registro Analizado es el 1001, asociar a la Tabla 
               a crear los campos correspondientes. */

            strcat(sSQLCommand, "record_indicator	char(4)		not null, ");
            strcat(sSQLCommand, "type_indicator		char(3)		not null, ");
            strcat(sSQLCommand, "company_id		char(6)		not null, ");
            strcat(sSQLCommand, "subcompany_id		char(3)		not null, ");
            strcat(sSQLCommand, "node_id		char(50)	not null, ");
            strcat(sSQLCommand, "account_number		char(50)	not null, ");
            strcat(sSQLCommand, "filler			text		not null, ");
            strcat(sSQLCommand, "trx_control_data	char(50)	not null)");
         }

         if(strcmp(sRecordType, FMTREC2000) == 0)
         {
            /* Si el Registro Analizado es el 2000, asociar a la Tabla 
               a crear los campos correspondientes. */

            strcat(sSQLCommand, "record_indicator		char(4)		not null, ");
            strcat(sSQLCommand, "type_indicator			char(3)		not null, ");
            strcat(sSQLCommand, "company_id			char(6)		not null, ");
            strcat(sSQLCommand, "subcompany_id			char(3)		not null, ");
            strcat(sSQLCommand, "processor			char(3)		not null, ");
            strcat(sSQLCommand, "account_number			char(25)	not null, ");
            strcat(sSQLCommand, "account_type			char(1)		not null, ");
            strcat(sSQLCommand, "last_name			char(25)	not null, ");
            strcat(sSQLCommand, "cardh_first_name		char(25)	not null, ");
            strcat(sSQLCommand, "cardh_middle_name		char(20)	not null, ");
	    strcat(sSQLCommand, "address_line1_kanji_out	char(1)		NOT NULL, ");	/* FUN 21122004 */
            strcat(sSQLCommand, "address_line1			char(40)	not null, ");
	    strcat(sSQLCommand, "address_line1_kanji_in		char(1)		NOT NULL, ");	/* FUN 21122004 */
	    strcat(sSQLCommand, "address_line2_kanji_out	char(1)		NOT NULL, ");	/* FUN 21122004 */
            strcat(sSQLCommand, "address_line2			char(40)	not null, ");
	    strcat(sSQLCommand, "address_line2_kanji_in		char(1)		NOT NULL, ");	/* FUN 21122004 */
	    strcat(sSQLCommand, "address_line3_kanji_out	char(1)		NOT NULL, ");	/* FUN 21122004 */
            strcat(sSQLCommand, "address_line3			char(40)	not null, ");
	    strcat(sSQLCommand, "address_line3_kanji_in		char(1)		NOT NULL, ");	/* FUN 21122004 */
	    strcat(sSQLCommand, "address_line4_so		char(1)		NOT NULL, ");	/* FUN 21122004 */
            strcat(sSQLCommand, "address_line4			char(40)	not null, ");
	    strcat(sSQLCommand, "address_line4_si		char(1)		NOT NULL, ");	/* FUN 21122004 */
            strcat(sSQLCommand, "address_line5			char(40)	not null, ");
            strcat(sSQLCommand, "city				char(25)	not null, ");
            strcat(sSQLCommand, "state_country			char(25)	not null, ");
            strcat(sSQLCommand, "postal_code			char(10)	not null, ");
            strcat(sSQLCommand, "country			char(20)	not null, ");
            strcat(sSQLCommand, "national_id			char(30)	not null, ");
            strcat(sSQLCommand, "telephone_number		char(18)	not null, ");
            strcat(sSQLCommand, "work_phone_num			char(18)	not null, ");
            strcat(sSQLCommand, "id_verification_code		char(15)	not null, ");
            strcat(sSQLCommand, "date_birth			char(8)		not null, ");
            strcat(sSQLCommand, "cycle_code			char(2)		not null, ");
            strcat(sSQLCommand, "fax_number			char(18)	not null, ");
            strcat(sSQLCommand, "e_mail_address			char(60)	not null, ");
            strcat(sSQLCommand, "employee_id			char(20)	not null, ");
            strcat(sSQLCommand, "client_id_cust_num		char(20)	not null, ");
            strcat(sSQLCommand, "customer_vat_num		char(20)	not null, ");
	    strcat(sSQLCommand, "kanji_name_out			char(1)		NOT NULL, ");	/* FUN 21122004 */
	    strcat(sSQLCommand, "kanji_name			char(50)	NOT NULL, ");	/* FUN 21122004 */
	    strcat(sSQLCommand, "kanji_name_in			char(1)		NOT NULL, ");	/* FUN 21122004 */
	    strcat(sSQLCommand, "address_line4_kanji_out	char(1)		NOT NULL, ");	/* FUN 21122004 */
	    strcat(sSQLCommand, "address_line4_kanji		char(60)	NOT NULL, ");	/* FUN 21122004 */
	    strcat(sSQLCommand, "address_line4_kanji_in		char(1)		NOT NULL, ");	/* FUN 21122004 */
            strcat(sSQLCommand, "filler				text not	null, ");
            strcat(sSQLCommand, "trx_control_data		char(50)	not null)");
	 }

         if(strcmp(sRecordType, FMTREC2001) == 0)
         {
            /* Si el Registro Analizado es el 2001, asociar a la Tabla 
               a crear los campos correspondientes. */

            strcat(sSQLCommand, "record_indicator		char(4)		not null, ");
            strcat(sSQLCommand, "type_indicator			char(3)		not null, ");
            strcat(sSQLCommand, "company_id			char(6)		not null, ");
            strcat(sSQLCommand, "subcompany_id			char(3)		not null, ");
            strcat(sSQLCommand, "processor			char(3)		not null, ");
            strcat(sSQLCommand, "account_number			char(25)	not null, ");
            strcat(sSQLCommand, "control_billing		char(25)	not null, ");
            strcat(sSQLCommand, "master_acct_code		char(150)	not null, ");
            strcat(sSQLCommand, "city_pair_code			char(1)		not null, ");
            strcat(sSQLCommand, "tax_exempt_num			char(20)	not null, ");
            strcat(sSQLCommand, "tax_exempt_flag		char(1)		not null, ");
            strcat(sSQLCommand, "tax_exempt_status		char(3)		not null, ");
            strcat(sSQLCommand, "num_cards			char(2)		not null, ");
            strcat(sSQLCommand, "open_date			char(8)		not null, ");
            strcat(sSQLCommand, "credit_rating			char(2)		not null, ");
            strcat(sSQLCommand, "credit_limit			char(18)	not null, ");
            strcat(sSQLCommand, "single_tran_lmt		char(18)	not null, ");
            strcat(sSQLCommand, "prim_emboss_name		char(30)	not null, ");
            strcat(sSQLCommand, "emboss_legend			char(26)	not null, ");
            strcat(sSQLCommand, "card_activation_date		char(8)		not null, ");
            strcat(sSQLCommand, "last_pay_date			char(8)		not null, ");
            strcat(sSQLCommand, "billing_currency		char(3)		not null, ");
            strcat(sSQLCommand, "current_balance		char(18)	not null, ");
            strcat(sSQLCommand, "payment_amt_due		char(18)	not null, ");
            strcat(sSQLCommand, "payment_due_date		char(8)		not null, ");
            strcat(sSQLCommand, "transit_routing_no		char(9)		not null, ");
            strcat(sSQLCommand, "dda_number			char(25)	not null, ");
            strcat(sSQLCommand, "auth_status			char(4)		not null, ");
            strcat(sSQLCommand, "new_card_ind			char(1)		not null, ");
            strcat(sSQLCommand, "newcard_serno			char(20)	not null, ");
            strcat(sSQLCommand, "last_mainten_date		char(8)		not null, ");
            strcat(sSQLCommand, "pin_request_flag		char(1)		not null, ");
            strcat(sSQLCommand, "bill_type			char(1)		not null, ");
            strcat(sSQLCommand, "transfer_account		char(25)	not null, ");
            strcat(sSQLCommand, "transfer_status		char(1)		not null, ");
            strcat(sSQLCommand, "transfer_reason		char(1)		not null, ");
            strcat(sSQLCommand, "transfer_date			char(8)		not null, ");
            strcat(sSQLCommand, "charge_off_status		char(1)		not null, ");
            strcat(sSQLCommand, "charge_off_date		char(8)		not null, ");	/* FUN 21122004 */
            strcat(sSQLCommand, "charge_off_balance c		har(18)		not null, ");
            strcat(sSQLCommand, "charge_off_reason		char(1)		not null, ");
            strcat(sSQLCommand, "other_acct_nbr			char(25)	not null, ");
            strcat(sSQLCommand, "crv_status			char(1)		not null, ");
            strcat(sSQLCommand, "cash_advance_lmt		char(18)	not null, ");
            strcat(sSQLCommand, "cash_adv_lmt_frec		char(3)		not null, ");
	    strcat(sSQLCommand, "ecs_account_status		char(1)		NOT NULL, ");	/* FUN 21122004 */
	    strcat(sSQLCommand, "ecs_block_code			char(1)		NOT NULL, ");	/* FUN 21122004 */
	    strcat(sSQLCommand, "ecs_block_reason		char(2)		NOT NULL, ");	/* FUN 21122004 */
            strcat(sSQLCommand, "preview_balance		char(18)	not null, ");
	    strcat(sSQLCommand, "number_of_cycles_past_due	char(2)		NOT NULL, ");	/* FUN 21122004 */
            strcat(sSQLCommand, "filler				text		not null, ");
            strcat(sSQLCommand, "trx_control_data		char(50)	not null)");
         }

         if(strcmp(sRecordType, FMTREC5000) == 0)
         {
            /* Si el Registro Analizado es el 5000, asociar a la Tabla 
               a crear los campos correspondientes. */

            strcat(sSQLCommand, "record_indicator	char(4)		not null, ");
            strcat(sSQLCommand, "type_indicator		char(3)		not null, ");
            strcat(sSQLCommand, "company_id		char(6)		not null, ");
            strcat(sSQLCommand, "subcompany_id		char(3)		not null, ");
            strcat(sSQLCommand, "cbs_tr_run_date	char(8)		not null, ");
            strcat(sSQLCommand, "account_number		char(25)	not null, ");
            strcat(sSQLCommand, "trans_date		char(8)		not null, ");
            strcat(sSQLCommand, "trans_time		char(8)		not null, ");
            strcat(sSQLCommand, "post_date		char(8)		not null, ");
            strcat(sSQLCommand, "trans_amount		char(18)	not null, ");
            strcat(sSQLCommand, "auth_required		char(1)		not null, ");
            strcat(sSQLCommand, "auth_id		char(6)		not null, ");
            strcat(sSQLCommand, "convers_date		char(8)		not null, ");
            strcat(sSQLCommand, "pos_entry		char(12)	not null, ");
            strcat(sSQLCommand, "pos_cond_code		char(2)		not null, ");
            strcat(sSQLCommand, "acquirer_id		char(15)	not null, ");
            strcat(sSQLCommand, "reference_num		char(23)	not null, ");
            strcat(sSQLCommand, "trace_number		char(6)		not null, ");
            strcat(sSQLCommand, "trans_currency_cd	char(3)		not null, ");
            strcat(sSQLCommand, "trans_id		char(15)	not null, ");
            strcat(sSQLCommand, "mcc			char(4)		not null, ");
            strcat(sSQLCommand, "mcc_info_data		char(19)	not null, ");
            strcat(sSQLCommand, "merch_acceptor_id	char(16)	not null, ");
            strcat(sSQLCommand, "merch_description	char(40)	not null, ");
            strcat(sSQLCommand, "merchant_city		char(15)	not null, ");
            strcat(sSQLCommand, "merchant_state		char(5)		not null, ");
            strcat(sSQLCommand, "merchant_postal_co	char(10)	not null, ");
            strcat(sSQLCommand, "merch_country		char(3)		not null, ");
            strcat(sSQLCommand, "merchant_vat_num	char(20)	not null, ");
            strcat(sSQLCommand, "merch_desc_flag	char(1)		not null, ");
            strcat(sSQLCommand, "merchant_reference_num char(25)	not null, ");
            strcat(sSQLCommand, "source_currency	char(3)		not null, ");
            strcat(sSQLCommand, "source_amount		char(18)	not null, ");
            strcat(sSQLCommand, "billing_currency	char(3)		not null, ");
            strcat(sSQLCommand, "billing_amount		char(18)	not null, ");
            strcat(sSQLCommand, "settlem_currency	char(3)		not null, ");
            strcat(sSQLCommand, "settlem_amount		char(18)	not null, ");
            strcat(sSQLCommand, "us_dollar_curr		char(3)		not null, ");
            strcat(sSQLCommand, "us_dollar_amt		char(18)	not null, ");
            strcat(sSQLCommand, "gb_pound_curr		char(3)		not null, ");
            strcat(sSQLCommand, "gb_pound_amt		char(18)	not null, ");
            strcat(sSQLCommand, "euro_currency		char(3)		not null, ");
            strcat(sSQLCommand, "euro_amount		char(18)	not null, ");
            strcat(sSQLCommand, "asia_yen_curr		char(3)		not null, ");
            strcat(sSQLCommand, "asia_yen_amt		char(18)	not null, ");
            strcat(sSQLCommand, "swed_kron_curr		char(3)		not null, ");
            strcat(sSQLCommand, "swed_kron_amt		char(18)	not null, ");
            strcat(sSQLCommand, "canadian_curr		char(3)		not null, ");
            strcat(sSQLCommand, "canadian_amt		char(18)	not null, ");
            strcat(sSQLCommand, "conversion_rate	char(14)	not null, ");
            strcat(sSQLCommand, "db_cr_flag		char(1)		not null, ");
            strcat(sSQLCommand, "memo_flag		char(1)		not null, ");
            strcat(sSQLCommand, "corp_acct_no		char(25)	not null, ");
            strcat(sSQLCommand, "sales_tax		char(18)	not null, ");
            strcat(sSQLCommand, "sales_tax_flag		char(1)		not null, ");
            strcat(sSQLCommand, "vat_tax		char(18)	not null, ");
            strcat(sSQLCommand, "vat_tax_flag		char(1)		not null, ");
            strcat(sSQLCommand, "purchase_id		char(25)	not null, ");
            strcat(sSQLCommand, "purch_id_flag		char(1)		not null, ");
            strcat(sSQLCommand, "tran_type		char(1)		not null, ");
            strcat(sSQLCommand, "no_of_addendums	char(4)		not null, ");
            strcat(sSQLCommand, "visa_tran_code		char(4)		not null, ");
            strcat(sSQLCommand, "addendum_key		char(50)	not null, ");
            strcat(sSQLCommand, "ticket_number		char(15)	not null, ");
            strcat(sSQLCommand, "msg_type		char(4)		not null, ");
            strcat(sSQLCommand, "filler			char(1)		not null, ");
            strcat(sSQLCommand, "vat_evidence_flag	char(1)		not null, ");
            strcat(sSQLCommand, "customer_ref_num	char(17)	not null, ");
            strcat(sSQLCommand, "discount_amount	char(18)	not null, ");
	    strcat(sSQLCommand, "billing_date           char(8)		NOT NULL, ");	/* FUN 21122004 */
            strcat(sSQLCommand, "filler2		char(193)	not null, ");	/* FUN 21122004 */
            strcat(sSQLCommand, "trx_control_data	char(50)	not null)");
         }

         if(strcmp(sRecordType, FMTREC6001) == 0)
         {
            /* Si el Registro Analizado es el 6001, asociar a la Tabla 
               a crear los campos correspondientes. */

            strcat(sSQLCommand, "record_type_id			char(2)		not null, ");
            strcat(sSQLCommand, "adden_det_rec_typ		char(2)		not null, ");
            strcat(sSQLCommand, "company_id			char(6)		not null, ");
            strcat(sSQLCommand, "subcompany_id			char(3)		not null, ");
            strcat(sSQLCommand, "account_number			char(16)	not null, ");
            strcat(sSQLCommand, "message_id			char(15)	not null, ");
            strcat(sSQLCommand, "reference_num			char(23)	not null, ");
            strcat(sSQLCommand, "total_fare_amount		char(12)	not null, ");
            strcat(sSQLCommand, "total_tax_amount		char(12)	not null, ");
            strcat(sSQLCommand, "national_tax_amount		char(12)	not null, ");
            strcat(sSQLCommand, "total_fee_amount		char(12)	not null, ");
            strcat(sSQLCommand, "airline_ticket_number		char(15)	not null, ");
            strcat(sSQLCommand, "exchange_ticket_number		char(13)	not null, ");
            strcat(sSQLCommand, "exchange_ticket_amount		char(12)	not null, ");
            strcat(sSQLCommand, "airline_stop_over1		char(1)		not null, ");
            strcat(sSQLCommand, "destination1			char(5)		not null, ");
            strcat(sSQLCommand, "airline_carrier_code1		char(2)		not null, ");
            strcat(sSQLCommand, "airline_service_class1		char(1)		not null, ");
            strcat(sSQLCommand, "flight_number1			char(5)		not null, ");
            strcat(sSQLCommand, "airline_stop_over2		char(1)		not null, ");
            strcat(sSQLCommand, "destination2			char(5)		not null, ");
            strcat(sSQLCommand, "airline_carrier_code2		char(2)		not null, ");
            strcat(sSQLCommand, "airline_service_class2		char(1)		not null, ");
            strcat(sSQLCommand, "flight_number2			char(5)		not null, ");
            strcat(sSQLCommand, "airline_stop_over3		char(1)		not null, ");
            strcat(sSQLCommand, "destination3			char(5)		not null, ");
            strcat(sSQLCommand, "airline_carrier_code3		char(2)		not null, ");
            strcat(sSQLCommand, "airline_service_class3		char(1)		not null, ");
            strcat(sSQLCommand, "flight_number3			char(5)		not null, ");
            strcat(sSQLCommand, "airline_stop_over4		char(1)		not null, ");
            strcat(sSQLCommand, "destination4			char(5)		not null, ");
            strcat(sSQLCommand, "airline_carrier_code4		char(2)		not null, ");
            strcat(sSQLCommand, "airline_service_class4		char(1)		not null, ");
            strcat(sSQLCommand, "flight_number4			char(5)		not null, ");
            strcat(sSQLCommand, "airline_stop_over5		char(1)		not null, ");
            strcat(sSQLCommand, "destination5			char(5)		not null, ");
            strcat(sSQLCommand, "airline_carrier_code5		char(2)		not null, ");
            strcat(sSQLCommand, "airline_service_class5		char(1)		not null, ");
            strcat(sSQLCommand, "flight_number5			char(5)		not null, ");
            strcat(sSQLCommand, "airline_stop_over6		char(1)		not null, ");
            strcat(sSQLCommand, "destination6			char(5)		not null, ");
            strcat(sSQLCommand, "airline_carrier_code6		char(2)		not null, ");
            strcat(sSQLCommand, "airline_service_class6		char(1)		not null, ");
            strcat(sSQLCommand, "flight_number6			char(5)		not null, ");
            strcat(sSQLCommand, "airline_stop_over7		char(1)		not null, ");
            strcat(sSQLCommand, "destination7			char(5)		not null, ");
            strcat(sSQLCommand, "airline_carrier_code7		char(2)		not null, ");
            strcat(sSQLCommand, "airline_service_class7		char(1)		not null, ");
            strcat(sSQLCommand, "flight_number7			char(5)		not null, ");
            strcat(sSQLCommand, "airline_stop_over8		char(1)		not null, ");
            strcat(sSQLCommand, "destination8			char(5)		not null, ");
            strcat(sSQLCommand, "airline_carrier_code8		char(2)		not null, ");
            strcat(sSQLCommand, "airline_service_class8		char(1)		not null, ");
            strcat(sSQLCommand, "flight_number8			char(5)		not null, ");
            strcat(sSQLCommand, "airline_stop_over9		char(1)		not null, ");
            strcat(sSQLCommand, "destination9			char(5)		not null, ");
            strcat(sSQLCommand, "airline_carrier_code9		char(2)		not null, ");
            strcat(sSQLCommand, "airline_service_class9		char(1)		not null, ");
            strcat(sSQLCommand, "flight_number9			char(5)		not null, ");
            strcat(sSQLCommand, "airline_stop_over10		char(1)		not null, ");
            strcat(sSQLCommand, "destination10			char(5)		not null, ");
            strcat(sSQLCommand, "airline_carrier_code10		char(2)		not null, ");
            strcat(sSQLCommand, "airline_service_class10	char(1)		not null, ");
            strcat(sSQLCommand, "flight_number10		char(5)		not null, ");
            strcat(sSQLCommand, "airline_stop_over11		char(1)		not null, ");
            strcat(sSQLCommand, "destination11			char(5)		not null, ");
            strcat(sSQLCommand, "airline_carrier_code11		char(2)		not null, ");
            strcat(sSQLCommand, "airline_service_class11	char(1)		not null, ");
            strcat(sSQLCommand, "flight_number11		char(5)		not null, ");
            strcat(sSQLCommand, "airline_stop_over12		char(1)		not null, ");
            strcat(sSQLCommand, "destination12			char(5)		not null, ");
            strcat(sSQLCommand, "airline_carrier_code12		char(2)		not null, ");
            strcat(sSQLCommand, "airline_service_class12	char(1)		not null, ");
            strcat(sSQLCommand, "flight_number12		char(5)		not null, ");
            strcat(sSQLCommand, "airline_stop_over13		char(1)		not null, ");
            strcat(sSQLCommand, "destination13			char(5)		not null, ");
            strcat(sSQLCommand, "airline_carrier_code13		char(2)		not null, ");
            strcat(sSQLCommand, "airline_service_class13	char(1)		not null, ");
            strcat(sSQLCommand, "flight_number13		char(5)		not null, ");
            strcat(sSQLCommand, "airline_stop_over14		char(1)		not null, ");
            strcat(sSQLCommand, "destination14			char(5)		not null, ");
            strcat(sSQLCommand, "airline_carrier_code14		char(2)		not null, ");
            strcat(sSQLCommand, "airline_service_class14	char(1)		not null, ");
            strcat(sSQLCommand, "flight_number14		char(5)		not null, ");
            strcat(sSQLCommand, "airline_stop_over15		char(1)		not null, ");
            strcat(sSQLCommand, "destination15			char(5)		not null, ");
            strcat(sSQLCommand, "airline_carrier_code15		char(2)		not null, ");
            strcat(sSQLCommand, "airline_service_class15	char(1)		not null, ");
            strcat(sSQLCommand, "flight_number15		char(5)		not null, ");
            strcat(sSQLCommand, "airline_stop_over16		char(1)		not null, ");
            strcat(sSQLCommand, "destination16			char(5)		not null, ");
            strcat(sSQLCommand, "airline_carrier_code16		char(2)		not null, ");
            strcat(sSQLCommand, "airline_service_class16	char(1)		not null, ");
            strcat(sSQLCommand, "flight_number16		char(5)		not null, ");
            strcat(sSQLCommand, "travel_agency_code		char(8)		not null, ");
            strcat(sSQLCommand, "travel_agency_name		char(25)	not null, ");
            strcat(sSQLCommand, "passenger_name			char(20)	not null, ");
            strcat(sSQLCommand, "departure_date			char(6)		not null, ");
            strcat(sSQLCommand, "origination_code		char(3)		not null, ");
            strcat(sSQLCommand, "internet_indicator		char(1)		not null, ");
            strcat(sSQLCommand, "electronic_ticket_ind		char(1)		not null, ");
            strcat(sSQLCommand, "filler				text		not null, ");
            strcat(sSQLCommand, "trx_control_data		char(50)	not null)");
         }

         if(strcmp(sRecordType, FMTREC6002) == 0)
         {
            /* Si el Registro Analizado es el 6002, asociar a la Tabla 
               a crear los campos correspondientes. */

            strcat(sSQLCommand, "record_type_id			char(2)		not null, ");
            strcat(sSQLCommand, "adden_det_rec_typ		char(2)		not null, ");
            strcat(sSQLCommand, "company_id			char(6)		not null, ");
            strcat(sSQLCommand, "subcompany_id			char(3)		not null, ");
            strcat(sSQLCommand, "account_number			char(16)	not null, ");
            strcat(sSQLCommand, "purchasing_det_seq_num		char(3)		not null, ");
            strcat(sSQLCommand, "order_date			char(6)		not null, ");
            strcat(sSQLCommand, "destination_zip_code		char(10)	not null, ");
            strcat(sSQLCommand, "destination_country_cod	char(3)		not null, ");
            strcat(sSQLCommand, "origination_zip_code		char(10)	not null, ");
            strcat(sSQLCommand, "freight_amount			char(13)	not null, ");
            strcat(sSQLCommand, "freight_vat_tax_amount		char(12)	not null, ");
            strcat(sSQLCommand, "freight_vat_tax_rate		char(4)		not null, ");
            strcat(sSQLCommand, "commodity_code			char(15)	not null, ");
            strcat(sSQLCommand, "description			char(35)	not null, ");
            strcat(sSQLCommand, "product_code			char(12)	not null, ");
            strcat(sSQLCommand, "quantity			char(15)	not null, ");
            strcat(sSQLCommand, "unit_of_measure		char(12)	not null, ");
            strcat(sSQLCommand, "unit_cost			char(15)	not null, ");
            strcat(sSQLCommand, "vat_tax_amount			char(12)	not null, ");
            strcat(sSQLCommand, "vat_tax_rate			char(4)		not null, ");
            strcat(sSQLCommand, "unique_vat			char(15)	not null, ");
            strcat(sSQLCommand, "discount_per			char(12)	not null, ");
            strcat(sSQLCommand, "line_item_total		char(12)	not null, ");
            strcat(sSQLCommand, "filler				text		not null, ");
            strcat(sSQLCommand, "trx_control_data		char(50)	not null)");
         }

         if(strcmp(sRecordType, FMTREC6004) == 0)
         {
            /* Si el Registro Analizado es el 6004, asociar a la Tabla 
               a crear los campos correspondientes. */

            strcat(sSQLCommand, "record_type_id			char(2)		not null, ");
            strcat(sSQLCommand, "adden_det_rec_typ		char(2)		not null, ");
            strcat(sSQLCommand, "company_id			char(6)		not null, ");
            strcat(sSQLCommand, "subcompany_id			char(3)		not null, ");
            strcat(sSQLCommand, "account_number			char(16)	not null, ");
            strcat(sSQLCommand, "purchasing_det_seq_num		char(3)		not null, ");
            strcat(sSQLCommand, "property_telephone_num		char(10)	not null, ");
            strcat(sSQLCommand, "customer_service_phone		char(10)	not null, ");
            strcat(sSQLCommand, "check_in_date			char(8)		not null, ");
            strcat(sSQLCommand, "check_out_date			char(8)		not null, ");
            strcat(sSQLCommand, "no_show_indicator		char(1)		not null, ");
            strcat(sSQLCommand, "total_authorized_amount	char(13)	not null, ");
            strcat(sSQLCommand, "prepaid_expenses		char(7)		not null, ");
            strcat(sSQLCommand, "number_room_nights		char(12)	not null, ");
            strcat(sSQLCommand, "daily_room_rate		char(12)	not null, ");
            strcat(sSQLCommand, "vat_tax_amount			char(12)	not null, ");
            strcat(sSQLCommand, "vat_tax_rate			char(12)	not null, ");
            strcat(sSQLCommand, "room_tax_amount		char(12)	not null, ");
            strcat(sSQLCommand, "unique_vat_invoice		char(15)	not null, ");
            strcat(sSQLCommand, "discount_amount		char(12)	not null, ");
            strcat(sSQLCommand, "food_beverage_charge		char(12)	not null, ");
            strcat(sSQLCommand, "cash_advances			char(12)	not null, ");
            strcat(sSQLCommand, "valet_parking_charges		char(12)	not null, ");
            strcat(sSQLCommand, "mini_bar_charges		char(12)	not null, ");
            strcat(sSQLCommand, "laundry_charges		char(12)	not null, ");
            strcat(sSQLCommand, "phone_charges			char(12)	not null, ");
            strcat(sSQLCommand, "gift_shop_charges		char(12)	not null, ");
            strcat(sSQLCommand, "movie_charges			char(12)	not null, ");
            strcat(sSQLCommand, "business_center_charges	char(12)	not null, ");
            strcat(sSQLCommand, "health_club_charges		char(12)	not null, ");
            strcat(sSQLCommand, "other_charges			char(12)	not null, ");
            strcat(sSQLCommand, "total_non_room			char(12)	not null, ");
            strcat(sSQLCommand, "filler				text		not null, ");
            strcat(sSQLCommand, "trx_control_data		char(50)	not null)");
         }

         if(strcmp(sRecordType, FMTREC6005) == 0)
         {
            /* Si el Registro Analizado es el 6005, asociar a la Tabla 
               a crear los campos correspondientes. */

            strcat(sSQLCommand, "record_type_id			char(2)		not null, ");
            strcat(sSQLCommand, "adden_det_rec_typ		char(2)		not null, ");
            strcat(sSQLCommand, "company_id			char(6)		not null, ");
            strcat(sSQLCommand, "subcompany_id			char(3)		not null, ");
            strcat(sSQLCommand, "account_number			char(16)	not null, ");
            strcat(sSQLCommand, "purchasing_detail_seq_num	char(3)		not null, ");
            strcat(sSQLCommand, "rental_agreement_number	char(25)	not null, ");
            strcat(sSQLCommand, "renters_name			char(40)	not null, ");
            strcat(sSQLCommand, "location_return_city		char(25)	not null, ");
            strcat(sSQLCommand, "return_state			char(3)		not null, ");
            strcat(sSQLCommand, "car_class_code			char(2)		not null, ");
            strcat(sSQLCommand, "no_show_indicator		char(1)		not null, ");
            strcat(sSQLCommand, "check_out_date			char(8)		not null, ");
            strcat(sSQLCommand, "check_in_date			char(6)		not null, ");
            strcat(sSQLCommand, "insurance_indicator		char(1)		not null, ");
            strcat(sSQLCommand, "insurance_charges		char(12)	not null, ");
            strcat(sSQLCommand, "total_miles			char(5)		not null, ");
            strcat(sSQLCommand, "number_days_rented		char(2)		not null, ");
            strcat(sSQLCommand, "daily_rate			char(12)	not null, ");
            strcat(sSQLCommand, "vat_tax_amount			char(12)	not null, ");
            strcat(sSQLCommand, "vat_tax_rate			char(4)		not null, ");
            strcat(sSQLCommand, "unique_vat_invoice		char(15)	not null, ");
            strcat(sSQLCommand, "weekly_rate			char(12)	not null, ");
            strcat(sSQLCommand, "rate_per_mile			char(12)	not null, ");
            strcat(sSQLCommand, "one_way_drop_charge		char(12)	not null, ");
            strcat(sSQLCommand, "regular_mileage_charge		char(12)	not null, ");
            strcat(sSQLCommand, "extra_mileage_charge		char(12)	not null, ");
            strcat(sSQLCommand, "maximum_free_miles		char(5)		not null, ");
            strcat(sSQLCommand, "late_return_charge		char(12)	not null, ");
            strcat(sSQLCommand, "fuel_charge			char(12)	not null, ");
            strcat(sSQLCommand, "telephone_charges		char(12)	not null, ");
            strcat(sSQLCommand, "auto_towing_charges		char(12)	not null, ");
            strcat(sSQLCommand, "extra_charges			char(12)	not null, ");
            strcat(sSQLCommand, "other_charges			char(12)	not null, ");
            strcat(sSQLCommand, "discount_amount		char(12)	not null, ");
            strcat(sSQLCommand, "line_item_total		char(12)	not null, ");
            strcat(sSQLCommand, "filler				text		not null, ");
            strcat(sSQLCommand, "trx_control_data		char(50)	not null)");
         }

         if(strcmp(sRecordType, FMTREC9000) == 0)
         {
            /* Si el Registro Analizado es el 9000, asociar a la Tabla 
               a crear los campos correspondientes. */

            strcat(sSQLCommand, "record_indicator		char(4)		not null, ");
            strcat(sSQLCommand, "type_indicator			char(3)		not null, ");
            strcat(sSQLCommand, "company_name			char(100)	not null, ");
            strcat(sSQLCommand, "company_id			char(6)		not null, ");
            strcat(sSQLCommand, "subcompany_id			char(3)		not null, ");
            strcat(sSQLCommand, "effective_file_date		char(8)		not null, ");
            strcat(sSQLCommand, "type_1000_record_count		char(18)	not null, ");
            strcat(sSQLCommand, "type_1001_record_count		char(18)	not null, ");
            strcat(sSQLCommand, "type_2000_record_count		char(18)	not null, ");
            strcat(sSQLCommand, "type_2001_record_count		char(18)	not null, ");
            strcat(sSQLCommand, "type_2002_record_count		char(18)	not null, ");
            strcat(sSQLCommand, "type_5000_record_count		char(18)	not null, ");
            strcat(sSQLCommand, "type_5000_total_value		char(18)	not null, ");
            strcat(sSQLCommand, "type_5001_record_count		char(18)	not null, ");
            strcat(sSQLCommand, "type_6001_record_count		char(18)	not null, ");
            strcat(sSQLCommand, "type_6002_record_count		char(18)	not null, ");
            strcat(sSQLCommand, "type_6004_record_count		char(18)	not null, ");
            strcat(sSQLCommand, "type_6005_record_count		char(18)	not null, ");
            strcat(sSQLCommand, "filler text not null, ");
            strcat(sSQLCommand, "trx_control_data char(50) not null)");
         }

         /* Si el Tipo de Registro no fue encontrado,  generar un mensaje
            de error y dar por concluido el programa. */

         if((strcmp(sRecordType, FMTREC0000) != 0) &&
            (strcmp(sRecordType, FMTREC1000) != 0) &&
            (strcmp(sRecordType, FMTREC1001) != 0) &&
            (strcmp(sRecordType, FMTREC2000) != 0) &&
            (strcmp(sRecordType, FMTREC2001) != 0) &&
            (strcmp(sRecordType, FMTREC5000) != 0) &&
            (strcmp(sRecordType, FMTREC6001) != 0) &&
            (strcmp(sRecordType, FMTREC6002) != 0) &&
            (strcmp(sRecordType, FMTREC6004) != 0) &&
            (strcmp(sRecordType, FMTREC6005) != 0) &&
            (strcmp(sRecordType, FMTREC9000) != 0))
         {
            printf("\nRecord Type %s not found.\n", sRecordType);

            /* Elimina el espacio reservado para el arreglo de Registros. */ 

            for(iCountRec = 0; iCountRec < iNumRecords; iCountRec++)

               free(psRecords[iCountRec]);

            free(psRecords);

            exit(ERREXIT);                                          
         }

         EXEC SQL PREPARE creattable FROM :sSQLCommand;  
                                               
         EXEC SQL EXECUTE creattable;

         EXEC SQL DEALLOCATE PREPARE creattable;
                                      
         EXEC SQL COMMIT WORK;
      }

      if(iIndexID == 0)
      {
         /* Si el indice no existe, crearlo. */

         strcpy(sSQLCommand, "CREATE CLUSTERED INDEX ");
         strcat(sSQLCommand, sIndexName);
         strcat(sSQLCommand, " on ");
         strcat(sSQLCommand, sTableName);
         strcat(sSQLCommand, "(");

         if((strcmp(sRecordType, FMTREC0000) == 0) || 
            (strcmp(sRecordType, FMTREC1000) == 0) ||
            (strcmp(sRecordType, FMTREC2000) == 0) ||
            (strcmp(sRecordType, FMTREC2001) == 0) ||
            (strcmp(sRecordType, FMTREC9000) == 0)) 
         {
            /* Registro Analizado 0000. */
            /* Registro Analizado 1100. */
            /* Registro Analizado 2000. */
            /* Registro Analizado 2001. */
            /* Registro Analizado 9000. */

            strcat(sSQLCommand, "company_id)");
         }

         if(strcmp(sRecordType, FMTREC1001) == 0)
         {
            /* Registro Analizado 1001. */

            strcat(sSQLCommand, "company_id, node_id)"); 
         }

         if((strcmp(sRecordType, FMTREC5000) == 0) ||
            (strcmp(sRecordType, FMTREC6001) == 0) ||
            (strcmp(sRecordType, FMTREC6002) == 0) ||
            (strcmp(sRecordType, FMTREC6004) == 0) ||
            (strcmp(sRecordType, FMTREC6005) == 0))
         {
            /* Registro Analizado 5000. */
            /* Registro Analizado 6001. */
            /* Registro Analizado 6002. */
            /* Registro Analizado 6004. */
            /* Registro Analizado 6005. */

            strcat(sSQLCommand, "company_id, account_number)");
         }

         
         EXEC SQL PREPARE creatindex FROM :sSQLCommand;  
                                               
         EXEC SQL EXECUTE creatindex;

         EXEC SQL DEALLOCATE PREPARE creatindex;
                                      
         EXEC SQL COMMIT WORK;

         /* Creacion de indices adicionales. */
 
         if((strcmp(sRecordType, FMTREC2000) == 0) ||
            (strcmp(sRecordType, FMTREC2001) == 0) ||
            (strcmp(sRecordType, FMTREC5000) == 0))
         {
            /* Registro Analizado 2000. */
            /* Registro Analizado 2001. */
            /* Registro Analizado 5000. */
 
            strcpy(sSQLCommand, "CREATE NONCLUSTERED INDEX ");
            strcat(sSQLCommand, PREFFIXINDNC);
            strcat(sSQLCommand, sIndexName);
            strcat(sSQLCommand, " on ");
            strcat(sSQLCommand, sTableName);
            strcat(sSQLCommand, "(");
            strcat(sSQLCommand, "account_number)");

            EXEC SQL PREPARE creatindnc FROM :sSQLCommand;
 
            EXEC SQL EXECUTE creatindnc;
 
            EXEC SQL DEALLOCATE PREPARE creatindnc;
 
            EXEC SQL COMMIT WORK;
         }

         if(strcmp(sRecordType, FMTREC1000) == 0)
         {
            /* Registro Analizado 1000. */
 
            strcpy(sSQLCommand, "CREATE NONCLUSTERED INDEX ");
            strcat(sSQLCommand, PREFFIXINDNC);
            strcat(sSQLCommand, sIndexName);
            strcat(sSQLCommand, " on ");
            strcat(sSQLCommand, sTableName);
            strcat(sSQLCommand, "(");
            strcat(sSQLCommand, "acct_code_id)");

            EXEC SQL PREPARE creatindnc FROM :sSQLCommand;
 
            EXEC SQL EXECUTE creatindnc;
 
            EXEC SQL DEALLOCATE PREPARE creatindnc;
 
            EXEC SQL COMMIT WORK;
         }

      }

   } 

   /* Elimina el espacio reservado para los Registros previamente
      recuperados del Archivo CCF. */

   for(iCountRec = 0; iCountRec < iNumRecords; iCountRec++)

      free(psRecords[iCountRec]);

   free(psRecords);

   return STDEXIT;
}
