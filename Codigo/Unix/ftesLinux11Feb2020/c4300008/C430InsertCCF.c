
/*
** Generated code begins here.
*/
# line 1 "C430InsertCCF.cp"

/*
** This file was generated on Wed Mar 25 07:26:04 2015
**  by Sybase Embedded SQL Preprocessor Sybase ESQL/C Precompiler/15.7/P-EBF227
** 38 SP112/DRV.15.7.0.11/Linux x86_64/Linux 2.6.18-128.el5 x86_64/BUILD1570-03
** 5/64bit/OPT/Fri Apr 18 06:53:39 2014
*/
# line 1 "C430InsertCCF.cp"
# line 1 "C430InsertCCF.cp"
#define _SQL_SCOPE extern
# line 1 "C430InsertCCF.cp"
#include <sybhesql.h>

/*
** Generated code ends here.
*/
# line 1 "C430InsertCCF.cp"
/* NOMBRE       : C430InsertCCF                                              */
/* DESCRIPCION	: Permite colocar la informacion contenida en un archivo     */
/*                CCF (Diario / Por Corte) en la Base de Datos del Sistema   */
/*                C430.                                                      */
/* PARAMETROS 	:                                                            */
/*    argv[1] = Usuario de Base De Datos                                     */
/*    argv[2] = Password de Base de Datos                                    */
/*    argv[3] = Servidor donde se encuentra la Base de Datos                 */
/*    argv[4] = Tipo de archivo(s) a procesar:                               */
/*                 D - Diario.                                               */
/*                 C - Por Corte.                                            */
/*    argv[5] = Nombre del archivo donde estan concentrados los registros    */
/*              a procesar.                                                  */
/*    argv[6] = Fecha de Procesamiento.                                      */
/* SALIDAS      : Registros del Archivo CCF en la Base de Datos.             */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 12/08/2003                                                 */
/* CONTROL DE                                                                */
/* VERSIONES    : V.1.0                                                      */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     12/08/2003     Primera Version         */
/* Copyright Derechos Reservados Banamex S.A. de C.V 2003a                   */
/*   Observaciones:                                                          */
/*                                                                           */

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "C430InsertCCF.h"


/*
** SQL STATEMENT: 1
** EXEC SQL INCLUDE SQLCA;

*/
# line 33 "C430InsertCCF.cp"
# line 33 "C430InsertCCF.cp"
SQLCA sqlca;

/*
** Generated code ends here.
*/
# line 33 "C430InsertCCF.cp"


#if defined(__STDC__) || defined(__cplusplus)
int main(int argc, char *argv[])             
#else                                        
int main(argc, argv)                         
int argc;                                    
char *argv[];                                
#endif                                       
{
   
           /*
           ** SQL STATEMENT: 1
           ** EXEC SQL BEGIN DECLARE SECTION;

           */
# line 43 "C430InsertCCF.cp"

      char sUsername[LEN30+1];	 /* Usuario. */
      char sPassword[LEN30+1];   /* Password. */
      char sServer[LEN30+1];     /* Servidor. */
   
           /*
           ** SQL STATEMENT: 2
           ** EXEC SQL END DECLARE SECTION;

           */
# line 47 "C430InsertCCF.cp"

           /*
           ** Generated code ends here.
           */
# line 47 "C430InsertCCF.cp"



   /* El No. de Parametros pasados a la aplicacion es incorrecto. */

   if(argc != 8)   
   {
      printf("\nUse: C430InsertCCF <User> <Password> <Server> <File Type>\n");
      printf("                   <File Name> <Process Date> <Number of Records>\n");
      exit(ERREXIT);
   }

   /* Definicion de rutinas para manejo de errores y mensajes de
      alerta. */

   
           /*
           ** SQL STATEMENT: 3
           ** EXEC SQL WHENEVER SQLERROR CALL error_handler();
           */
# line 62 "C430InsertCCF.cp"

   
           /*
           ** SQL STATEMENT: 4
           ** EXEC SQL WHENEVER SQLWARNING CALL warning_handler();
           */
# line 63 "C430InsertCCF.cp"

   
           /*
           ** SQL STATEMENT: 5
           ** EXEC SQL WHENEVER NOT FOUND CONTINUE;

           */
# line 64 "C430InsertCCF.cp"


   strcpy(sUsername, argv[1]);
   strcpy(sPassword, argv[2]);
   strcpy(sServer, argv[3]);

   /* Conexion al servidor de SYBASE. */

   
           /*
           ** SQL STATEMENT: 6
           ** EXEC SQL CONNECT :sUsername IDENTIFIED BY :sPassword USING :sServer
           ** ;
           */
# line 72 "C430InsertCCF.cp"
# line 72 "C430InsertCCF.cp"
           {
# line 72 "C430InsertCCF.cp"
                _SQL_CT_HANDLES * _sql;
# line 72 "C430InsertCCF.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 72 "C430InsertCCF.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 72 "C430InsertCCF.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 72 "C430InsertCCF.cp"
               {
# line 72 "C430InsertCCF.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 72 "C430InsertCCF.cp"
                   _sql->stmttype = SQL_NONANSI_CONNECT;
# line 72 "C430InsertCCF.cp"
                   _sql->connName.lnlen = CS_NULLTERM;
# line 72 "C430InsertCCF.cp"
                   strcpy(_sql->connName.last_name, sServer);
# line 72 "C430InsertCCF.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 72 "C430InsertCCF.cp"
                   {
# line 72 "C430InsertCCF.cp"
                       if (_sql->doDecl == CS_TRUE)
# line 72 "C430InsertCCF.cp"
                       {
# line 72 "C430InsertCCF.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 72 "C430InsertCCF.cp"
                           {
# line 72 "C430InsertCCF.cp"
                               _sql->retcode = 
# line 72 "C430InsertCCF.cp"
                                   ct_con_props(_sql->conn.connection, CS_SET, 
# line 72 "C430InsertCCF.cp"
                                   CS_USERNAME, sUsername, CS_NULLTERM, NULL);
# line 72 "C430InsertCCF.cp"
                           }
# line 72 "C430InsertCCF.cp"
                           
# line 72 "C430InsertCCF.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 72 "C430InsertCCF.cp"
                           {
# line 72 "C430InsertCCF.cp"
                               _sql->retcode = 
# line 72 "C430InsertCCF.cp"
                                   ct_con_props(_sql->conn.connection, CS_SET, 
# line 72 "C430InsertCCF.cp"
                                   CS_PASSWORD, sPassword, CS_NULLTERM, NULL);
# line 72 "C430InsertCCF.cp"
                           }
# line 72 "C430InsertCCF.cp"
                           
# line 72 "C430InsertCCF.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 72 "C430InsertCCF.cp"
                           {
# line 72 "C430InsertCCF.cp"
                               _sql->retcode = _sqlctdiag(_sql, CS_CLEAR, 
# line 72 "C430InsertCCF.cp"
                                   CS_UNUSED);
# line 72 "C430InsertCCF.cp"
                           }
# line 72 "C430InsertCCF.cp"
                           
# line 72 "C430InsertCCF.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 72 "C430InsertCCF.cp"
                           {
# line 72 "C430InsertCCF.cp"
                               _sql->retcode = 
# line 72 "C430InsertCCF.cp"
                                   ct_capability(_sql->conn.connection, CS_SET,
# line 72 "C430InsertCCF.cp"
                                    CS_CAP_RESPONSE, CS_RES_NOSTRIPBLANKS, 
# line 72 "C430InsertCCF.cp"
                                   &_sql->cstrue);
# line 72 "C430InsertCCF.cp"
                           }
# line 72 "C430InsertCCF.cp"
                           
# line 72 "C430InsertCCF.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 72 "C430InsertCCF.cp"
                           {
# line 72 "C430InsertCCF.cp"
                               _sql->retcode = 
# line 72 "C430InsertCCF.cp"
                                   ct_con_props(_sql->conn.connection, CS_SET, 
# line 72 "C430InsertCCF.cp"
                                   CS_EXTRA_INF, &_sql->cstrue, CS_UNUSED, 
# line 72 "C430InsertCCF.cp"
                                   NULL);
# line 72 "C430InsertCCF.cp"
                           }
# line 72 "C430InsertCCF.cp"
                           
# line 72 "C430InsertCCF.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 72 "C430InsertCCF.cp"
                           {
# line 72 "C430InsertCCF.cp"
                               _sql->retcode = 
# line 72 "C430InsertCCF.cp"
                                   ct_con_props(_sql->conn.connection, CS_SET, 
# line 72 "C430InsertCCF.cp"
                                   CS_ANSI_BINDS, &_sql->cstrue, CS_UNUSED, 
# line 72 "C430InsertCCF.cp"
                                   NULL);
# line 72 "C430InsertCCF.cp"
                           }
# line 72 "C430InsertCCF.cp"
                           
# line 72 "C430InsertCCF.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 72 "C430InsertCCF.cp"
                           {
# line 72 "C430InsertCCF.cp"
                               _sql->retcode = 
# line 72 "C430InsertCCF.cp"
                                   ct_connect(_sql->conn.connection, sServer, 
# line 72 "C430InsertCCF.cp"
                                   CS_NULLTERM);
# line 72 "C430InsertCCF.cp"
                           }
# line 72 "C430InsertCCF.cp"
                           
# line 72 "C430InsertCCF.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 72 "C430InsertCCF.cp"
                           {
# line 72 "C430InsertCCF.cp"
                               _sql->retcode = 
# line 72 "C430InsertCCF.cp"
                                   ct_con_props(_sql->conn.connection, CS_GET, 
# line 72 "C430InsertCCF.cp"
                                   CS_TDS_VERSION, &_sql->temp_int, CS_UNUSED, 
# line 72 "C430InsertCCF.cp"
                                   &_sql->outlen);
# line 72 "C430InsertCCF.cp"
                               if (_sql->retcode == CS_SUCCEED)
# line 72 "C430InsertCCF.cp"
                               {
# line 72 "C430InsertCCF.cp"
                                   if (_sql->temp_int < CS_TDS_50)
# line 72 "C430InsertCCF.cp"
                                   {
# line 72 "C430InsertCCF.cp"
                                       _sqlsetintrerr(_sql, (CS_INT) 
# line 72 "C430InsertCCF.cp"
                                           _SQL_INTRERR_25013);
# line 72 "C430InsertCCF.cp"
                                   }
# line 72 "C430InsertCCF.cp"
                                   
# line 72 "C430InsertCCF.cp"
                               }
# line 72 "C430InsertCCF.cp"
                               
# line 72 "C430InsertCCF.cp"
                           }
# line 72 "C430InsertCCF.cp"
                           
# line 72 "C430InsertCCF.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 72 "C430InsertCCF.cp"
                           {
# line 72 "C430InsertCCF.cp"
                               _sql->retcode = 
# line 72 "C430InsertCCF.cp"
                                   ct_options(_sql->conn.connection, CS_SET, 
# line 72 "C430InsertCCF.cp"
                                   CS_OPT_ANSINULL, &_sql->cstrue, CS_UNUSED, 
# line 72 "C430InsertCCF.cp"
                                   NULL);
# line 72 "C430InsertCCF.cp"
                           }
# line 72 "C430InsertCCF.cp"
                           
# line 72 "C430InsertCCF.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 72 "C430InsertCCF.cp"
                           {
# line 72 "C430InsertCCF.cp"
                               _sql->retcode = 
# line 72 "C430InsertCCF.cp"
                                   ct_options(_sql->conn.connection, CS_SET, 
# line 72 "C430InsertCCF.cp"
                                   CS_OPT_ANSIPERM, &_sql->cstrue, CS_UNUSED, 
# line 72 "C430InsertCCF.cp"
                                   NULL);
# line 72 "C430InsertCCF.cp"
                               _sql->retcode = CS_SUCCEED;
# line 72 "C430InsertCCF.cp"
                           }
# line 72 "C430InsertCCF.cp"
                           
# line 72 "C430InsertCCF.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 72 "C430InsertCCF.cp"
                           {
# line 72 "C430InsertCCF.cp"
                               _sql->retcode = 
# line 72 "C430InsertCCF.cp"
                                   ct_options(_sql->conn.connection, CS_SET, 
# line 72 "C430InsertCCF.cp"
                                   CS_OPT_STR_RTRUNC, &_sql->cstrue, CS_UNUSED,
# line 72 "C430InsertCCF.cp"
                                    NULL);
# line 72 "C430InsertCCF.cp"
                               _sql->retcode = CS_SUCCEED;
# line 72 "C430InsertCCF.cp"
                           }
# line 72 "C430InsertCCF.cp"
                           
# line 72 "C430InsertCCF.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 72 "C430InsertCCF.cp"
                           {
# line 72 "C430InsertCCF.cp"
                               _sql->retcode = 
# line 72 "C430InsertCCF.cp"
                                   ct_options(_sql->conn.connection, CS_SET, 
# line 72 "C430InsertCCF.cp"
                                   CS_OPT_ARITHABORT, &_sql->csfalse, 
# line 72 "C430InsertCCF.cp"
                                   CS_UNUSED, NULL);
# line 72 "C430InsertCCF.cp"
                           }
# line 72 "C430InsertCCF.cp"
                           
# line 72 "C430InsertCCF.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 72 "C430InsertCCF.cp"
                           {
# line 72 "C430InsertCCF.cp"
                               _sql->retcode = 
# line 72 "C430InsertCCF.cp"
                                   ct_options(_sql->conn.connection, CS_SET, 
# line 72 "C430InsertCCF.cp"
                                   CS_OPT_TRUNCIGNORE, &_sql->cstrue, 
# line 72 "C430InsertCCF.cp"
                                   CS_UNUSED, NULL);
# line 72 "C430InsertCCF.cp"
                           }
# line 72 "C430InsertCCF.cp"
                           
# line 72 "C430InsertCCF.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 72 "C430InsertCCF.cp"
                           {
# line 72 "C430InsertCCF.cp"
                               _sql->retcode = 
# line 72 "C430InsertCCF.cp"
                                   ct_options(_sql->conn.connection, CS_SET, 
# line 72 "C430InsertCCF.cp"
                                   CS_OPT_ARITHIGNORE, &_sql->csfalse, 
# line 72 "C430InsertCCF.cp"
                                   CS_UNUSED, NULL);
# line 72 "C430InsertCCF.cp"
                           }
# line 72 "C430InsertCCF.cp"
                           
# line 72 "C430InsertCCF.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 72 "C430InsertCCF.cp"
                           {
# line 72 "C430InsertCCF.cp"
                               _sql->retcode = 
# line 72 "C430InsertCCF.cp"
                                   ct_options(_sql->conn.connection, CS_SET, 
# line 72 "C430InsertCCF.cp"
                                   CS_OPT_ISOLATION, &_sql->Level3, CS_UNUSED, 
# line 72 "C430InsertCCF.cp"
                                   NULL);
# line 72 "C430InsertCCF.cp"
                           }
# line 72 "C430InsertCCF.cp"
                           
# line 72 "C430InsertCCF.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 72 "C430InsertCCF.cp"
                           {
# line 72 "C430InsertCCF.cp"
                               _sql->retcode = 
# line 72 "C430InsertCCF.cp"
                                   ct_options(_sql->conn.connection, CS_SET, 
# line 72 "C430InsertCCF.cp"
                                   CS_OPT_CHAINXACTS, &_sql->cstrue, CS_UNUSED,
# line 72 "C430InsertCCF.cp"
                                    NULL);
# line 72 "C430InsertCCF.cp"
                           }
# line 72 "C430InsertCCF.cp"
                           
# line 72 "C430InsertCCF.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 72 "C430InsertCCF.cp"
                           {
# line 72 "C430InsertCCF.cp"
                               _sql->retcode = 
# line 72 "C430InsertCCF.cp"
                                   ct_options(_sql->conn.connection, CS_SET, 
# line 72 "C430InsertCCF.cp"
                                   CS_OPT_CURCLOSEONXACT, &_sql->cstrue, 
# line 72 "C430InsertCCF.cp"
                                   CS_UNUSED, NULL);
# line 72 "C430InsertCCF.cp"
                           }
# line 72 "C430InsertCCF.cp"
                           
# line 72 "C430InsertCCF.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 72 "C430InsertCCF.cp"
                           {
# line 72 "C430InsertCCF.cp"
                               _sql->retcode = 
# line 72 "C430InsertCCF.cp"
                                   ct_options(_sql->conn.connection, CS_SET, 
# line 72 "C430InsertCCF.cp"
                                   CS_OPT_QUOTED_IDENT, &_sql->cstrue, 
# line 72 "C430InsertCCF.cp"
                                   CS_UNUSED, NULL);
# line 72 "C430InsertCCF.cp"
                           }
# line 72 "C430InsertCCF.cp"
                           
# line 72 "C430InsertCCF.cp"
                           _sql->retcode = _sqlepilog(_sql);
# line 72 "C430InsertCCF.cp"
                       }
# line 72 "C430InsertCCF.cp"
                       
# line 72 "C430InsertCCF.cp"
                   }
# line 72 "C430InsertCCF.cp"
                   
# line 72 "C430InsertCCF.cp"
                   if (sqlca.sqlcode < 0)
# line 72 "C430InsertCCF.cp"
                   {
# line 72 "C430InsertCCF.cp"
                       error_handler();
# line 72 "C430InsertCCF.cp"
                   }
# line 72 "C430InsertCCF.cp"
                   
# line 72 "C430InsertCCF.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 72 "C430InsertCCF.cp"
                   {
# line 72 "C430InsertCCF.cp"
                       warning_handler();
# line 72 "C430InsertCCF.cp"
                   }
# line 72 "C430InsertCCF.cp"
                   
# line 72 "C430InsertCCF.cp"
               }
# line 72 "C430InsertCCF.cp"
               
# line 72 "C430InsertCCF.cp"
           }
# line 72 "C430InsertCCF.cp"
           

           /*
           ** Generated code ends here.
           */
# line 72 "C430InsertCCF.cp"


   /* Cambio a Base de Datos Sistema Tarjeta Corporativa. */

   
           /*
           ** SQL STATEMENT: 7
           ** EXEC SQL USE M111; 
           */
# line 76 "C430InsertCCF.cp"
# line 76 "C430InsertCCF.cp"
           {
# line 76 "C430InsertCCF.cp"
                _SQL_CT_HANDLES * _sql;
# line 76 "C430InsertCCF.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 76 "C430InsertCCF.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 76 "C430InsertCCF.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 76 "C430InsertCCF.cp"
               {
# line 76 "C430InsertCCF.cp"
                   _sql->stmtIdlen = CS_UNUSED;
# line 76 "C430InsertCCF.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 76 "C430InsertCCF.cp"
                   _sql->stmttype = SQL_MISC;
# line 76 "C430InsertCCF.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 76 "C430InsertCCF.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 76 "C430InsertCCF.cp"
                   {
# line 76 "C430InsertCCF.cp"
                       _sql->retcode = ct_command(_sql->conn.command, 
# line 76 "C430InsertCCF.cp"
                           CS_LANG_CMD, "USE M111", 8, CS_UNUSED);
# line 76 "C430InsertCCF.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 76 "C430InsertCCF.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 76 "C430InsertCCF.cp"
                       _sql->retcode = _sqlResults(_sql);
# line 76 "C430InsertCCF.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 76 "C430InsertCCF.cp"
                   }
# line 76 "C430InsertCCF.cp"
                   
# line 76 "C430InsertCCF.cp"
                   if (sqlca.sqlcode < 0)
# line 76 "C430InsertCCF.cp"
                   {
# line 76 "C430InsertCCF.cp"
                       error_handler();
# line 76 "C430InsertCCF.cp"
                   }
# line 76 "C430InsertCCF.cp"
                   
# line 76 "C430InsertCCF.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 76 "C430InsertCCF.cp"
                   {
# line 76 "C430InsertCCF.cp"
                       warning_handler();
# line 76 "C430InsertCCF.cp"
                   }
# line 76 "C430InsertCCF.cp"
                   
# line 76 "C430InsertCCF.cp"
               }
# line 76 "C430InsertCCF.cp"
               
# line 76 "C430InsertCCF.cp"
           }
# line 76 "C430InsertCCF.cp"
           

           /*
           ** Generated code ends here.
           */
# line 76 "C430InsertCCF.cp"
    

   /* Insercion de registros asociados al archivo CCF en la Base de Datos. */

   iC430InsertData_CCF(argv);

   
           /*
           ** SQL STATEMENT: 8
           ** EXEC SQL COMMIT WORK;

           */
# line 82 "C430InsertCCF.cp"
# line 82 "C430InsertCCF.cp"
           {
# line 82 "C430InsertCCF.cp"
                _SQL_CT_HANDLES * _sql;
# line 82 "C430InsertCCF.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 82 "C430InsertCCF.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 82 "C430InsertCCF.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 82 "C430InsertCCF.cp"
               {
# line 82 "C430InsertCCF.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 82 "C430InsertCCF.cp"
                   _sql->stmttype = SQL_TRANS;
# line 82 "C430InsertCCF.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 82 "C430InsertCCF.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 82 "C430InsertCCF.cp"
                   {
# line 82 "C430InsertCCF.cp"
                       _sql->retcode = ct_command(_sql->conn.command, 
# line 82 "C430InsertCCF.cp"
                           CS_LANG_CMD, "COMMIT WORK", 11, CS_UNUSED);
# line 82 "C430InsertCCF.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 82 "C430InsertCCF.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 82 "C430InsertCCF.cp"
                       _sql->retcode = _sqlResults(_sql);
# line 82 "C430InsertCCF.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 82 "C430InsertCCF.cp"
                   }
# line 82 "C430InsertCCF.cp"
                   
# line 82 "C430InsertCCF.cp"
                   if (sqlca.sqlcode < 0)
# line 82 "C430InsertCCF.cp"
                   {
# line 82 "C430InsertCCF.cp"
                       error_handler();
# line 82 "C430InsertCCF.cp"
                   }
# line 82 "C430InsertCCF.cp"
                   
# line 82 "C430InsertCCF.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 82 "C430InsertCCF.cp"
                   {
# line 82 "C430InsertCCF.cp"
                       warning_handler();
# line 82 "C430InsertCCF.cp"
                   }
# line 82 "C430InsertCCF.cp"
                   
# line 82 "C430InsertCCF.cp"
               }
# line 82 "C430InsertCCF.cp"
               
# line 82 "C430InsertCCF.cp"
           }
# line 82 "C430InsertCCF.cp"
           

           /*
           ** Generated code ends here.
           */
# line 82 "C430InsertCCF.cp"


   
           /*
           ** SQL STATEMENT: 9
           ** EXEC SQL DISCONNECT ALL;

           */
# line 84 "C430InsertCCF.cp"
# line 84 "C430InsertCCF.cp"
           {
# line 84 "C430InsertCCF.cp"
                _SQL_CT_HANDLES * _sql;
# line 84 "C430InsertCCF.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 84 "C430InsertCCF.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 84 "C430InsertCCF.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 84 "C430InsertCCF.cp"
               {
# line 84 "C430InsertCCF.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 84 "C430InsertCCF.cp"
                   _sql->stmttype = SQL_DISCONNECT_ALL;
# line 84 "C430InsertCCF.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 84 "C430InsertCCF.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 84 "C430InsertCCF.cp"
                   {
# line 84 "C430InsertCCF.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 84 "C430InsertCCF.cp"
                   }
# line 84 "C430InsertCCF.cp"
                   
# line 84 "C430InsertCCF.cp"
                   if (sqlca.sqlcode < 0)
# line 84 "C430InsertCCF.cp"
                   {
# line 84 "C430InsertCCF.cp"
                       error_handler();
# line 84 "C430InsertCCF.cp"
                   }
# line 84 "C430InsertCCF.cp"
                   
# line 84 "C430InsertCCF.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 84 "C430InsertCCF.cp"
                   {
# line 84 "C430InsertCCF.cp"
                       warning_handler();
# line 84 "C430InsertCCF.cp"
                   }
# line 84 "C430InsertCCF.cp"
                   
# line 84 "C430InsertCCF.cp"
               }
# line 84 "C430InsertCCF.cp"
               
# line 84 "C430InsertCCF.cp"
           }
# line 84 "C430InsertCCF.cp"
           

           /*
           ** Generated code ends here.
           */
# line 84 "C430InsertCCF.cp"


   exit(STDEXIT);
}

/* NOMBRE       : iC430InsertData_CCF                                        */
/* DESCRIPCION	: Recupera los registros contenidos en un archivo CCF deter- */
/*                minado y los coloca en la Base de Datos.                   */
/* PARAMETROS 	:                                                            */
/*    psParams[4] = Tipo de archivo(s) a procesar:                           */
/*                 C - Diario.                                               */
/*                 D - Por Corte.                                            */
/*    psParams[5] = Nombre del archivo donde estan concentrados los          */
/*                  registros a procesar.                                    */
/*    psParams[6] = Fecha de Procesamiento.                                  */
/*    psParams[7] = No. de Registros contenidos en el archivo.               */
/* SALIDAS      : Estatus de conclusion de la rutina:                        */
/*                0 - Exito.                                                 */
/*                1 - Falla.                                                 */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 12/08/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     12/08/2003     Primera Version         */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
int iC430InsertData_CCF(char *psParams[])             
#else                                        
int iC430InsertData_CCF(psParams)                         
char *psParams[];                                
#endif                                       
{
   
           /*
           ** SQL STATEMENT: 9
           ** EXEC SQL BEGIN DECLARE SECTION;

           */
# line 119 "C430InsertCCF.cp"


      /* Identificador de Tabla de Registros en formato CCF. */

      int  iTableID;


      /* Identificador de Indice sobre Tabla de Registros en formato CCF. */

      int  iIndexID;

      
      /* Indice asignado a la Tabla de Registros del archivo CCF. */

      char sIndexName[LEN30+1];


      /* Comando de SQL a ejecutar en la Base de Datos. */

      char sSQLCommand[LEN2000+1];

   
           /*
           ** SQL STATEMENT: 10
           ** EXEC SQL END DECLARE SECTION;

           */
# line 140 "C430InsertCCF.cp"

           /*
           ** Generated code ends here.
           */
# line 140 "C430InsertCCF.cp"



   /* Informacion correspondiente a Datos Generales de un Registro. */

   char sRecordIndicator[LEN4+1];     
   char sTypeIndicator[LEN3+1];       
   char sCompanyName[LEN100+1];       
   char sCompanyID[LEN6+1];           
   char sSubCompanyID[LEN3+1];        
   char sEffectiveFileDate[LEN8+1];   
   char sTRXControlData[LEN50+1];     
   char sProcessor[LEN3+1];     
   char sAccountNumber[LEN25+1];
   char sAccountNo[LEN16+1];
   char sRecordTypeID[LEN2+1];
   char sAddDetailRecType[LEN2+1];
   char sPurchDetailSeqNum[LEN3+1];
   char sUniqueVATInvRefNo[LEN15+1];
   char sVATTaxAmount[LEN12+1];
   char sVATTaxRate[LEN4+1];   
   char sNoShowIndicator[LEN1+1];
   char sCheckOutDate[LEN8+1];
   char sDiscountAmount[LEN12+1];
   char sBillingCurrency[LEN3+1];
   char sOtherCharges[LEN12+1];
   char sLineItemTotal[LEN12+1];
 
   /* Informacion correspondiente al Registro 0000. */

   char sCCFVersion[LEN5+1];
   char sCompNameKanjiShiftOUT[LEN1+1];		/* FUN 23122004 */
   char sCompNameKanji[LEN60+1];		/* FUN 23122004 */
   char sCompNameKanjiShiftIN[LEN1+1];		/* FUN 23122004 */
   char sFiller0000[LEN759+1];			/* FUN 23122004    original    char sFiller0000[LEN821+1];*/

   /* Informacion correspondiente al Registro 1000. */

   char sCorpParentNode[LEN50+1];
   char sCorpChildNode[LEN50+1];
   char sDepth[LEN10+1];
   char sLevelName[LEN50+1];
   char sHierarchyType[LEN10+1];
   char sAcctCodeID[LEN10+1];
   char sCurrSicTemplate[LEN15+1];
   char sFutureSicTemplate[LEN15+1];
   char sReportTemplate[LEN15+1];
   char sTextsetTemplate[LEN15+1];
   char sExceptionTemplate[LEN15+1];
   char sFiller1100[LEN679+1];

   /* Informacion correspondiente al Registro 1001. */

   char sNodeID[LEN50+1];
   char sAccountNumber1001[LEN50+1];
   char sFiller1001[LEN834+1];

   /* Informacion correspondiente al Registro 2000. */

   char sAccountType[LEN1+1];
   char sLastName[LEN25+1];
   char sCardhFirstName[LEN25+1];
   char sCardhMiddleName[LEN20+1];
   char sAddrLine1kanjiShiftOUT[LEN1+1];		/* FUN 23122004 */
   char sAddrLine1[LEN40+1];
   char sAddrLine1kanjiShiftIN[LEN1+1];			/* FUN 23122004 */
   char sAddrLine2kanjiShiftOUT[LEN1+1];		/* FUN 23122004 */
   char sAddrLine2[LEN40+1];
   char sAddrLine2kanjiShiftIN[LEN1+1];			/* FUN 23122004 */
   char sAddrLine3kanjiShiftOUT[LEN1+1];		/* FUN 23122004 */
   char sAddrLine3[LEN40+1];
   char sAddrLine3kanjiShiftIN[LEN1+1];			/* FUN 23122004 */
   char sAddrLine4SO[LEN1+1];				/* FUN 23122004 */
   char sAddrLine4[LEN40+1];
   char sAddrLine4SI[LEN1+1];				/* FUN 23122004 */
   char sAddressLine5[LEN40+1];
   char sCity[LEN25+1];
   char sStateCountyProvince[LEN25+1];
   char sPostalCode[LEN10+1];
   char sCountry[LEN20+1];
   char sNationalID[LEN30+1];
   char sTelephoneNumber[LEN18+1];
   char sWorkPhoneNum[LEN18+1];
   char sIDVerificationCode[LEN15+1];
   char sDateOfBirth[LEN8+1];
   char sCycleCode[LEN2+1];
   char sFaxNumber[LEN18+1];
   char sEMailAddress[LEN60+1];
   char sEmployeeID[LEN20+1];
   char sClientIDCustomerNumber[LEN20+1];
   char sCustomerVATNumber[LEN20+1];
   char sKanjiNameKanjiShiftOUT[LEN1+1];		/* FUN 23122004 */
   char sKanjiNameKanji[LEN50+1];			/* FUN 23122004 */
   char sKanjiNameKanjiShiftIN[LEN1+1];			/* FUN 23122004 */
   char sAddrLine4kanjiShiftOUT[LEN1+1];		/* FUN 23122004 */
   char sAddrLine4kanji[LEN60+1];			/* FUN 23122004 */
   char sAddrLine4kanjiShiftIN[LEN1+1];			/* FUN 23122004 */
   char sFiller2000[LEN204+1];				/* FUN 23122004    original   char sFiller2000[LEN326+1];*/


   /* Informacion correspondiente al Registro 2001. */

   char sControlBillingVirtual[LEN25+1];
   char sMasterAcctCode[LEN150+1];
   char sCityPairCode[LEN1+1];
   char sTaxExemptNumber[LEN20+1];
   char sTaxExemptFlag[LEN1+1];
   char sTaxExemptStatus[LEN3+1];
   char sNumCards[LEN2+1];
   char sOpenDate[LEN8+1];
   char sCreditRating[LEN2+1];
   char sCreditLimit[LEN18+1];
   char sSingleTranLmt[LEN18+1];
   char sPrimEmbossName[LEN30+1];
   char sEmbossLegend[LEN26+1];
   char sCardActivationDate[LEN8+1];
   char sLastPayDate[LEN8+1];
   char sCurrentBalance[LEN18+1];
   char sPaymentAmtDue[LEN18+1];
   char sPaymentDueDate[LEN8+1];
   char sTransitRoutingNo[LEN9+1];
   char sDDANumber[LEN25+1];
   char sAuthStatus[LEN4+1];
   char sNewCardInd[LEN1+1];
   char sNewCardSerNo[LEN20+1];
   char sLastMaintenanceDate[LEN8+1];
   char sPinRequestFlag[LEN1+1];
   char sBillType[LEN1+1];
   char sTransferAccount[LEN25+1];
   char sTransferStatus[LEN1+1];
   char sTransferReason[LEN1+1];
   char sTransferDate[LEN8+1];
   char sChargeOffStatus[LEN1+1];
   char sChargeOffDate[LEN8+1];				/* fun 23122004   original  char sChargeOffDate[LEN6+1];*/
   char sChargeOffBalance[LEN18+1];
   char sChargeOffReason[LEN1+1];
   char sOtherAcctNbr[LEN25+1];
   char sCRVStatus[LEN1+1];
   char sCashAdvanceLimit[LEN18+1];
   char sCashAdvLimitFreq[LEN3+1];
   char sEcsAccountStatus[LEN1+1];			/*fun 23122004 */
   char sEcsBlockCode[LEN1+1];				/*fun 23122004 */
   char sEcsBlockReason[LEN2+1];			/*fun 23122004 */
   char sPreviewBalance[LEN18+1];
   char sNumberOfCyclesPastDue[LEN2+1];			/*fun 23122004 */
   char sFiller2001[LEN336+1];				/*fun 23122004    original  char sFiller2001[LEN344+1];*/


   /* Informacion correspondiente al Registro 5000. */

   char sCBSTRRunDate[LEN8+1];
   char sTransDate[LEN8+1];
   char sTransTime[LEN8+1];
   char sPostDate[LEN8+1];
   char sTransAmount[LEN18+1];
   char sAuthRequired[LEN1+1];
   char sAuthID[LEN6+1];
   char sConversDate[LEN8+1];
   char sPosEntry[LEN12+1];
   char sPosCondCode[LEN2+1];
   char sAcquirerID[LEN15+1];
   char sReferenceNum[LEN23+1];
   char sTraceNumber[LEN6+1];
   char sTransCurrencyCd[LEN3+1];
   char sTransID[LEN15+1];
   char sMCC[LEN4+1];
   char sMCCInfoData[LEN19+1];
   char sMerchAcceptorID[LEN16+1];
   char sMerchDescription[LEN40+1];
   char sMerchantCity[LEN15+1];
   char sMerchantStateProvince[LEN5+1];
   char sMerchantPostalCode[LEN10+1];
   char sMerchCountry[LEN3+1];
   char sMerchantVATNumber[LEN20+1];
   char sMerchDescFlag[LEN1+1];
   char sMerchantReferenceNumber[LEN25+1];
   char sSourceCurrency[LEN3+1];
   char sSourceAmount[LEN18+1];
   char sBillingAmount[LEN18+1];
   char sSettlemCurrency[LEN3+1];
   char sSettlemAmount[LEN18+1];
   char sUSDollarCurr[LEN3+1];
   char sUSDollarAmt[LEN18+1];
   char sGBPoundCurr[LEN3+1];
   char sGBPoundAmt[LEN18+1];
   char sEuroCurrency[LEN3+1];
   char sEuroAmount[LEN18+1];
   char sAsiaYenCurr[LEN3+1];
   char sAsiaYenAmt[LEN18+1];
   char sSwedKronCurr[LEN3+1];
   char sSwedKronAmt[LEN18+1];
   char sCanadianCurr[LEN3+1];
   char sCanadianAmt[LEN18+1];
   char sConversionRate[LEN14+1];
   char sDBCRFlag[LEN1+1];
   char sMemoFlag[LEN1+1];
   char sCorpAcctNo[LEN25+1];
   char sSalesTax[LEN18+1];
   char sSalesTaxFlag[LEN1+1];
   char sVATTax[LEN18+1];
   char sVATTaxFlag[LEN1+1];
   char sPurchaseID[LEN25+1];
   char sPurchIDFlag[LEN1+1];
   char sTranType[LEN1+1];
   char sNoOfAddendums[LEN4+1];
   char sVisaTranCode[LEN4+1];
   char sAddendumKey[LEN50+1];
   char sTicketNumber[LEN15+1];
   char sMsgType[LEN4+1];
   char sFiller1_5000[LEN1+1];
   char sVATEvidenceFlag[LEN1+1];
   char sCustRefNumber[LEN17+1];
   char sDiscAmount[LEN18+1];
   char sBillingDate[LEN8+1];			/*fun 23122004*/
   char sFiller2_5000[LEN193+1];		/*fun 23122004    original    char sFiller2_5000[LEN201+1]; */


   /* Informacion correspondiente al Registro 6001. */

   char sMessageID[LEN15+1];
   char sReferenceNumber[LEN23+1];
   char sTotalFareAmount[LEN12+1];
   char sTotalTaxAmount[LEN12+1];
   char sNationalTaxAmount[LEN12+1];
   char sTotalFeeAmount[LEN12+1];
   char sAirlineTicketNumber[LEN15+1];
   char sExchangeTicketNumber[LEN13+1];
   char sExchangeTicketAmount[LEN12+1];
   char sAirlineStopOver1[LEN1+1];
   char sDestination1[LEN5+1];
   char sAirlineCarrierCode1[LEN2+1];
   char sAirlineServiceClass1[LEN1+1];
   char sFlightNumber1[LEN5+1];
   char sAirlineStopOver2[LEN1+1];
   char sDestination2[LEN5+1];
   char sAirlineCarrierCode2[LEN2+1];
   char sAirlineServiceClass2[LEN1+1];
   char sFlightNumber2[LEN5+1];
   char sAirlineStopOver3[LEN1+1];
   char sDestination3[LEN5+1];
   char sAirlineCarrierCode3[LEN2+1];
   char sAirlineServiceClass3[LEN1+1];
   char sFlightNumber3[LEN5+1];
   char sAirlineStopOver4[LEN1+1];
   char sDestination4[LEN5+1];
   char sAirlineCarrierCode4[LEN2+1];
   char sAirlineServiceClass4[LEN1+1];
   char sFlightNumber4[LEN5+1];
   char sAirlineStopOver5[LEN1+1];
   char sDestination5[LEN5+1];
   char sAirlineCarrierCode5[LEN2+1];
   char sAirlineServiceClass5[LEN1+1];
   char sFlightNumber5[LEN5+1];
   char sAirlineStopOver6[LEN1+1];
   char sDestination6[LEN5+1];
   char sAirlineCarrierCode6[LEN2+1];
   char sAirlineServiceClass6[LEN1+1];
   char sFlightNumber6[LEN5+1];
   char sAirlineStopOver7[LEN1+1];
   char sDestination7[LEN5+1];
   char sAirlineCarrierCode7[LEN2+1];
   char sAirlineServiceClass7[LEN1+1];
   char sFlightNumber7[LEN5+1];
   char sAirlineStopOver8[LEN1+1];
   char sDestination8[LEN5+1];
   char sAirlineCarrierCode8[LEN2+1];
   char sAirlineServiceClass8[LEN1+1];
   char sFlightNumber8[LEN5+1];
   char sAirlineStopOver9[LEN1+1];
   char sDestination9[LEN5+1];
   char sAirlineCarrierCode9[LEN2+1];
   char sAirlineServiceClass9[LEN1+1];
   char sFlightNumber9[LEN5+1];
   char sAirlineStopOver10[LEN1+1];
   char sDestination10[LEN5+1];
   char sAirlineCarrierCode10[LEN2+1];
   char sAirlineServiceClass10[LEN1+1];
   char sFlightNumber10[LEN5+1];
   char sAirlineStopOver11[LEN1+1];
   char sDestination11[LEN5+1];
   char sAirlineCarrierCode11[LEN2+1];
   char sAirlineServiceClass11[LEN1+1];
   char sFlightNumber11[LEN5+1];
   char sAirlineStopOver12[LEN1+1];
   char sDestination12[LEN5+1];
   char sAirlineCarrierCode12[LEN2+1];
   char sAirlineServiceClass12[LEN1+1];
   char sFlightNumber12[LEN5+1];
   char sAirlineStopOver13[LEN1+1];
   char sDestination13[LEN5+1];
   char sAirlineCarrierCode13[LEN2+1];
   char sAirlineServiceClass13[LEN1+1];
   char sFlightNumber13[LEN5+1];
   char sAirlineStopOver14[LEN1+1];
   char sDestination14[LEN5+1];
   char sAirlineCarrierCode14[LEN2+1];
   char sAirlineServiceClass14[LEN1+1];
   char sFlightNumber14[LEN5+1];
   char sAirlineStopOver15[LEN1+1];
   char sDestination15[LEN5+1];
   char sAirlineCarrierCode15[LEN2+1];
   char sAirlineServiceClass15[LEN1+1];
   char sFlightNumber15[LEN5+1];
   char sAirlineStopOver16[LEN1+1];
   char sDestination16[LEN5+1];
   char sAirlineCarrierCode16[LEN2+1];
   char sAirlineServiceClass16[LEN1+1];
   char sFlightNumber16[LEN5+1];
   char sTravelAgencyCode[LEN8+1];
   char sTravelAgencyName[LEN25+1];
   char sPassengerName[LEN20+1];
   char sDepartureDate[LEN6+1];
   char sOriginationCode[LEN3+1];
   char sInternetIndicator[LEN1+1];
   char sElectTicketInd[LEN1+1];
   char sFiller6001[LEN507+1];

   /* Informacion correspondiente al Registro 6002. */

   char sOrderDate[LEN6+1];
   char sDestinationZipCode[LEN10+1];
   char sDestinationCountryCode[LEN3+1];
   char sOriginationZipCode[LEN10+1];
   char sFreightAmount[LEN13+1];
   char sFreightVATTaxAmount[LEN12+1];
   char sFreightVATTaxRate[LEN4+1];
   char sCommodityCode[LEN15+1];
   char sDescription[LEN35+1];
   char sProductCode[LEN12+1];
   char sQuantity[LEN15+1];
   char sUnitOfMeasure[LEN12+1];
   char sUnitCost[LEN15+1];
   char sDiscountPerLineItem[LEN12+1];
   char sFiller6002[LEN701+1];

   /* Informacion correspondiente al Registro 6004. */

   char sPropTelephoneNumber[LEN10+1];
   char sCustServPhoneNum[LEN10+1];
   char sCheckInDate[LEN8+1];
   char sTotalAuthAmount[LEN13+1];
   char sPrepaidExpenses[LEN7+1];
   char sNumberOfRoomNights[LEN12+1];
   char sDailyRoomRate[LEN12+1];
   char sVATTaxRate_6004[LEN12+1];
   char sRoomTaxAmount[LEN12+1];
   char sFoodAndBeverageCharge[LEN12+1];
   char sCashAdvances[LEN12+1];
   char sValetParkingCharges[LEN12+1];
   char sMiniBarCharges[LEN12+1];
   char sLaundryCharges[LEN12+1];
   char sPhoneCharges[LEN12+1];
   char sGiftShopCharges[LEN12+1];
   char sMovieCharges[LEN12+1];
   char sBusinessCenterCharges[LEN12+1];
   char sHealthClubCharges[LEN12+1];
   char sTotalNonRoomCharges[LEN12+1];
   char sFiller6004[LEN630+1];

   /* Informacion correspondiente al Registro 6005. */

   char sRentalAgreeNum[LEN25+1];
   char sRentersName[LEN40+1];
   char sLocOfRetCity[LEN25+1];
   char sRetStaCountry[LEN3+1];
   char sCarClassCode[LEN2+1];
   char sCheckInDate_6005[LEN6+1];
   char sInsuranceInd[LEN1+1];
   char sInsuranceCharges[LEN12+1];
   char sTotalMiles[LEN5+1];
   char sNumOfDaysRented[LEN2+1];
   char sDailyRate[LEN12+1];
   char sWeeklyRate[LEN12+1];
   char sRatePerMile[LEN12+1];
   char sOneWayDropOffCh[LEN12+1];
   char sRegMilCharge[LEN12+1];
   char sExtraMilCharge[LEN12+1];
   char sMaxFreeMiles[LEN5+1];
   char sLateRetChHourRate[LEN12+1];
   char sFuelCharge[LEN12+1];
   char sTelephoneCharges[LEN12+1];
   char sAutoTowingCharges[LEN12+1];
   char sExtraCharges[LEN12+1];
   char sFiller6005[LEN584+1];
      
   /* Informacion correspondiente al Registro 9000. */

   char sType1000RecordCount[LEN18+1];
   char sType1001RecordCount[LEN18+1];
   char sType2000RecordCount[LEN18+1];
   char sType2001RecordCount[LEN18+1];
   char sType2002RecordCount[LEN18+1];
   char sType5000RecordCount[LEN18+1];
   char sType5000TotalValue[LEN18+1];
   char sType5001RecordCount[LEN18+1];
   char sType6001RecordCount[LEN18+1];
   char sType6002RecordCount[LEN18+1];
   char sType6004RecordCount[LEN18+1];
   char sType6005RecordCount[LEN18+1];
   char sFiller9000[LEN610+1];


   char sFileType[LEN1+1];      /* Tipo de Archivo a Procesar (Diario / Por Corte). */
   int  iNumRecords;            /* No. de Registros contenidos en el archivo . */
   FILE *pFileCCF;              /* Puntero al archivo CCF. */

   char sFileGenDate[LEN4+1];   /* Fecha de Generacion del archivo CCF. */

   char sTableName[LEN30+1];    /* Nombre de la Tabla donde seran colocados
                                   los registros del archivo CCF. */

   char sRecord[LEN2000+1];     /* Registro correspondiente a un archivo CCF. */

   char sRecordType[LEN4+1];    /* Tipo de Registro Analizado. */  

   char **psRecords;            /* Registros recuperados del archivo CCF. */

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
      *(psRecords + iCountRec) = (char *) malloc(LEN2000 * sizeof(char));
      strcpy(psRecords[iCountRec], EMPSTR);
   }


   /* Recuperacion de Informacion de Base de Datos. */

   iCountRec=0;

   /* Apertura del archivo CCF. */                            
                                                           
   if((pFileCCF = fopen(psParams[5], "r")) == NULL)           
   {                                                          
      printf("\nFile %s not found.\n", psParams[5]);

      /* Elimina el espacio reservado para el arreglo de Registros. */ 

      for(iCountRec = 0; iCountRec < iNumRecords; iCountRec++)

         free(psRecords[iCountRec]);

      free(psRecords);

      exit(ERREXIT);                                          
   }       

   fgets(sRecord, LEN2000, pFileCCF); 

   while(!feof(pFileCCF)){

      strcpy(psRecords[iCountRec], sRecord);

      strcpy(sRecord, EMPSTR);          
                                     
      fgets(sRecord, LEN2000, pFileCCF);

      iCountRec++;
   }                                    
                                     
   fclose(pFileCCF);                    

  
   /* Insercion de registros en la Base de Datos. */

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

      
           /*
           ** SQL STATEMENT: 11
           ** EXEC SQL PREPARE counttable FROM :sSQLCommand;
           */
# line 662 "C430InsertCCF.cp"
# line 662 "C430InsertCCF.cp"
           {
# line 662 "C430InsertCCF.cp"
                _SQL_CT_HANDLES * _sql;
# line 662 "C430InsertCCF.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 662 "C430InsertCCF.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 662 "C430InsertCCF.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 662 "C430InsertCCF.cp"
               {
# line 662 "C430InsertCCF.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 662 "C430InsertCCF.cp"
                   _sql->stmttype = SQL_PREPARE;
# line 662 "C430InsertCCF.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 662 "C430InsertCCF.cp"
                   _sql->stmtName.fnlen = 10;
# line 662 "C430InsertCCF.cp"
                   strcpy(_sql->stmtName.first_name, "counttable");
# line 662 "C430InsertCCF.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 662 "C430InsertCCF.cp"
                   {
# line 662 "C430InsertCCF.cp"
                       _sql->retcode = ct_dynamic(_sql->conn.command, 
# line 662 "C430InsertCCF.cp"
                           CS_PREPARE, "counttable", 10, sSQLCommand, 
# line 662 "C430InsertCCF.cp"
                           CS_NULLTERM);
# line 662 "C430InsertCCF.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 662 "C430InsertCCF.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 662 "C430InsertCCF.cp"
                       _sql->resloop = CS_TRUE;
# line 662 "C430InsertCCF.cp"
                       while ((!_sql->hastate) && (_sql->resloop == CS_TRUE) 
# line 662 "C430InsertCCF.cp"
                           && ((_sql->retcode = ct_results(_sql->conn.command, 
# line 662 "C430InsertCCF.cp"
                           &_sql->restype)) == CS_SUCCEED))
# line 662 "C430InsertCCF.cp"
                       {
# line 662 "C430InsertCCF.cp"
                           switch ( _sql->restype )
# line 662 "C430InsertCCF.cp"
                           {
# line 662 "C430InsertCCF.cp"
                           case CS_CMD_FAIL:
# line 662 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 662 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_ALL);
# line 662 "C430InsertCCF.cp"
                           break;
# line 662 "C430InsertCCF.cp"
                           case CS_COMPUTE_RESULT:
# line 662 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 662 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25003);
# line 662 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 662 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 662 "C430InsertCCF.cp"
                           break;
# line 662 "C430InsertCCF.cp"
                           case CS_CURSOR_RESULT:
# line 662 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 662 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25004);
# line 662 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 662 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 662 "C430InsertCCF.cp"
                           break;
# line 662 "C430InsertCCF.cp"
                           case CS_PARAM_RESULT:
# line 662 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 662 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25005);
# line 662 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 662 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 662 "C430InsertCCF.cp"
                           break;
# line 662 "C430InsertCCF.cp"
                           case CS_ROW_RESULT:
# line 662 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 662 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25006);
# line 662 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 662 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 662 "C430InsertCCF.cp"
                           break;
# line 662 "C430InsertCCF.cp"
                           case CS_STATUS_RESULT:
# line 662 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 662 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25009);
# line 662 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 662 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 662 "C430InsertCCF.cp"
                           break;
# line 662 "C430InsertCCF.cp"
                           case CS_DESCRIBE_RESULT:
# line 662 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 662 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25010);
# line 662 "C430InsertCCF.cp"
                           break;
# line 662 "C430InsertCCF.cp"
                           }
# line 662 "C430InsertCCF.cp"
                           
# line 662 "C430InsertCCF.cp"
                       }
# line 662 "C430InsertCCF.cp"
                       
# line 662 "C430InsertCCF.cp"
                       if ((_sql->retcode != CS_END_RESULTS) && (_sql->retcode 
# line 662 "C430InsertCCF.cp"
                           != CS_CANCELED) && (_sql->retcode != 
# line 662 "C430InsertCCF.cp"
                           CS_RET_HAFAILOVER) && (_sql->resloop != CS_FALSE))
# line 662 "C430InsertCCF.cp"
                       {
# line 662 "C430InsertCCF.cp"
                           _sql->retcode = ct_cancel(NULL, _sql->conn.command, 
# line 662 "C430InsertCCF.cp"
                               CS_CANCEL_ALL);
# line 662 "C430InsertCCF.cp"
                           }
# line 662 "C430InsertCCF.cp"
                            else {
# line 662 "C430InsertCCF.cp"
                           if (((_sql->retcode != CS_CANCELED) && 
# line 662 "C430InsertCCF.cp"
                               (_sql->retcode != CS_RET_HAFAILOVER)))
# line 662 "C430InsertCCF.cp"
                           {
# line 662 "C430InsertCCF.cp"
                               _sql->retcode = CS_SUCCEED;
# line 662 "C430InsertCCF.cp"
                           }
# line 662 "C430InsertCCF.cp"
                           
# line 662 "C430InsertCCF.cp"
                       }
# line 662 "C430InsertCCF.cp"
                       
# line 662 "C430InsertCCF.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 662 "C430InsertCCF.cp"
                   }
# line 662 "C430InsertCCF.cp"
                   
# line 662 "C430InsertCCF.cp"
                   if (sqlca.sqlcode < 0)
# line 662 "C430InsertCCF.cp"
                   {
# line 662 "C430InsertCCF.cp"
                       error_handler();
# line 662 "C430InsertCCF.cp"
                   }
# line 662 "C430InsertCCF.cp"
                   
# line 662 "C430InsertCCF.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 662 "C430InsertCCF.cp"
                   {
# line 662 "C430InsertCCF.cp"
                       warning_handler();
# line 662 "C430InsertCCF.cp"
                   }
# line 662 "C430InsertCCF.cp"
                   
# line 662 "C430InsertCCF.cp"
               }
# line 662 "C430InsertCCF.cp"
               
# line 662 "C430InsertCCF.cp"
           }
# line 662 "C430InsertCCF.cp"
           

           /*
           ** Generated code ends here.
           */
# line 662 "C430InsertCCF.cp"
  
                                               
      
           /*
           ** SQL STATEMENT: 12
           ** EXEC SQL EXECUTE counttable INTO :iTableID;
           */
# line 664 "C430InsertCCF.cp"
# line 664 "C430InsertCCF.cp"
           {
# line 664 "C430InsertCCF.cp"
                _SQL_CT_HANDLES * _sql;
# line 664 "C430InsertCCF.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 664 "C430InsertCCF.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 664 "C430InsertCCF.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 664 "C430InsertCCF.cp"
               {
# line 664 "C430InsertCCF.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 664 "C430InsertCCF.cp"
                   _sql->stmttype = SQL_EXECUTE;
# line 664 "C430InsertCCF.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 664 "C430InsertCCF.cp"
                   _sql->stmtName.fnlen = 10;
# line 664 "C430InsertCCF.cp"
                   strcpy(_sql->stmtName.first_name, "counttable");
# line 664 "C430InsertCCF.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 664 "C430InsertCCF.cp"
                   {
# line 664 "C430InsertCCF.cp"
                       _sql->retcode = ct_dynamic(_sql->conn.command, 
# line 664 "C430InsertCCF.cp"
                           CS_EXECUTE, "counttable", 10, NULL, CS_UNUSED);
# line 664 "C430InsertCCF.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 664 "C430InsertCCF.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 664 "C430InsertCCF.cp"
                       _sql->resloop = CS_TRUE;
# line 664 "C430InsertCCF.cp"
                       while ((!_sql->hastate) && (_sql->resloop == CS_TRUE) 
# line 664 "C430InsertCCF.cp"
                           && ((_sql->retcode = ct_results(_sql->conn.command, 
# line 664 "C430InsertCCF.cp"
                           &_sql->restype)) == CS_SUCCEED))
# line 664 "C430InsertCCF.cp"
                       {
# line 664 "C430InsertCCF.cp"
                           switch ( _sql->restype )
# line 664 "C430InsertCCF.cp"
                           {
# line 664 "C430InsertCCF.cp"
                           case CS_COMPUTE_RESULT:
# line 664 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 664 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25003);
# line 664 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 664 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 664 "C430InsertCCF.cp"
                           break;
# line 664 "C430InsertCCF.cp"
                           case CS_CURSOR_RESULT:
# line 664 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 664 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25004);
# line 664 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 664 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 664 "C430InsertCCF.cp"
                           break;
# line 664 "C430InsertCCF.cp"
                           case CS_PARAM_RESULT:
# line 664 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 664 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25005);
# line 664 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 664 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 664 "C430InsertCCF.cp"
                           break;
# line 664 "C430InsertCCF.cp"
                           case CS_ROW_RESULT:
# line 664 "C430InsertCCF.cp"
                               _sql->dfmtCS_INT_TYPE.count = 0;
# line 664 "C430InsertCCF.cp"
                                   _sql->retcode = ct_bind(_sql->conn.command, 
# line 664 "C430InsertCCF.cp"
                                       1, &_sql->dfmtCS_INT_TYPE, &iTableID, 
# line 664 "C430InsertCCF.cp"
                                       NULL, NULL);
# line 664 "C430InsertCCF.cp"
                               _sql->retcode = ct_fetch(_sql->conn.command, 
# line 664 "C430InsertCCF.cp"
                                   CS_UNUSED, CS_UNUSED, CS_UNUSED, 
# line 664 "C430InsertCCF.cp"
                                   &_sql->rowsread);
# line 664 "C430InsertCCF.cp"
                               _sql->hastate = (_sql->retcode == 
# line 664 "C430InsertCCF.cp"
                                   CS_RET_HAFAILOVER);
# line 664 "C430InsertCCF.cp"
                               if ((_sql->retcode == CS_SUCCEED) || 
# line 664 "C430InsertCCF.cp"
                                   (_sql->retcode == CS_ROW_FAIL))
# line 664 "C430InsertCCF.cp"
                               {
# line 664 "C430InsertCCF.cp"
                                   _sql->retcode = ct_bind(_sql->conn.command, 
# line 664 "C430InsertCCF.cp"
                                       CS_UNUSED, NULL, NULL, NULL, NULL);
# line 664 "C430InsertCCF.cp"
                                   _sql->retcode = ct_fetch(_sql->conn.command,
# line 664 "C430InsertCCF.cp"
                                        CS_UNUSED, CS_UNUSED, CS_UNUSED, 
# line 664 "C430InsertCCF.cp"
                                       &_sql->rowsread);
# line 664 "C430InsertCCF.cp"
                                   _sql->hastate = (_sql->retcode == 
# line 664 "C430InsertCCF.cp"
                                       CS_RET_HAFAILOVER);
# line 664 "C430InsertCCF.cp"
                               }
# line 664 "C430InsertCCF.cp"
                               
# line 664 "C430InsertCCF.cp"
                           break;
# line 664 "C430InsertCCF.cp"
                           case CS_STATUS_RESULT:
# line 664 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 664 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25009);
# line 664 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 664 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 664 "C430InsertCCF.cp"
                           break;
# line 664 "C430InsertCCF.cp"
                           case CS_DESCRIBE_RESULT:
# line 664 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 664 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25010);
# line 664 "C430InsertCCF.cp"
                           break;
# line 664 "C430InsertCCF.cp"
                           }
# line 664 "C430InsertCCF.cp"
                           
# line 664 "C430InsertCCF.cp"
                       }
# line 664 "C430InsertCCF.cp"
                       
# line 664 "C430InsertCCF.cp"
                       if ((_sql->retcode != CS_END_RESULTS) && (_sql->retcode 
# line 664 "C430InsertCCF.cp"
                           != CS_CANCELED) && (_sql->retcode != 
# line 664 "C430InsertCCF.cp"
                           CS_RET_HAFAILOVER) && (_sql->resloop != CS_FALSE))
# line 664 "C430InsertCCF.cp"
                       {
# line 664 "C430InsertCCF.cp"
                           _sql->retcode = ct_cancel(NULL, _sql->conn.command, 
# line 664 "C430InsertCCF.cp"
                               CS_CANCEL_ALL);
# line 664 "C430InsertCCF.cp"
                           }
# line 664 "C430InsertCCF.cp"
                            else {
# line 664 "C430InsertCCF.cp"
                           if (((_sql->retcode != CS_CANCELED) && 
# line 664 "C430InsertCCF.cp"
                               (_sql->retcode != CS_RET_HAFAILOVER)))
# line 664 "C430InsertCCF.cp"
                           {
# line 664 "C430InsertCCF.cp"
                               _sql->retcode = CS_SUCCEED;
# line 664 "C430InsertCCF.cp"
                           }
# line 664 "C430InsertCCF.cp"
                           
# line 664 "C430InsertCCF.cp"
                       }
# line 664 "C430InsertCCF.cp"
                       
# line 664 "C430InsertCCF.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 664 "C430InsertCCF.cp"
                   }
# line 664 "C430InsertCCF.cp"
                   
# line 664 "C430InsertCCF.cp"
                   if (sqlca.sqlcode < 0)
# line 664 "C430InsertCCF.cp"
                   {
# line 664 "C430InsertCCF.cp"
                       error_handler();
# line 664 "C430InsertCCF.cp"
                   }
# line 664 "C430InsertCCF.cp"
                   
# line 664 "C430InsertCCF.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 664 "C430InsertCCF.cp"
                   {
# line 664 "C430InsertCCF.cp"
                       warning_handler();
# line 664 "C430InsertCCF.cp"
                   }
# line 664 "C430InsertCCF.cp"
                   
# line 664 "C430InsertCCF.cp"
               }
# line 664 "C430InsertCCF.cp"
               
# line 664 "C430InsertCCF.cp"
           }
# line 664 "C430InsertCCF.cp"
           

           /*
           ** Generated code ends here.
           */
# line 664 "C430InsertCCF.cp"


      
           /*
           ** SQL STATEMENT: 13
           ** EXEC SQL DEALLOCATE PREPARE counttable;

           */
# line 666 "C430InsertCCF.cp"
# line 666 "C430InsertCCF.cp"
           {
# line 666 "C430InsertCCF.cp"
                _SQL_CT_HANDLES * _sql;
# line 666 "C430InsertCCF.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 666 "C430InsertCCF.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 666 "C430InsertCCF.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 666 "C430InsertCCF.cp"
               {
# line 666 "C430InsertCCF.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 666 "C430InsertCCF.cp"
                   _sql->stmttype = SQL_DEALLOCATE_PREPARE;
# line 666 "C430InsertCCF.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 666 "C430InsertCCF.cp"
                   _sql->stmtName.fnlen = 10;
# line 666 "C430InsertCCF.cp"
                   strcpy(_sql->stmtName.first_name, "counttable");
# line 666 "C430InsertCCF.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 666 "C430InsertCCF.cp"
                   {
# line 666 "C430InsertCCF.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 666 "C430InsertCCF.cp"
                   }
# line 666 "C430InsertCCF.cp"
                   
# line 666 "C430InsertCCF.cp"
                   if (sqlca.sqlcode < 0)
# line 666 "C430InsertCCF.cp"
                   {
# line 666 "C430InsertCCF.cp"
                       error_handler();
# line 666 "C430InsertCCF.cp"
                   }
# line 666 "C430InsertCCF.cp"
                   
# line 666 "C430InsertCCF.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 666 "C430InsertCCF.cp"
                   {
# line 666 "C430InsertCCF.cp"
                       warning_handler();
# line 666 "C430InsertCCF.cp"
                   }
# line 666 "C430InsertCCF.cp"
                   
# line 666 "C430InsertCCF.cp"
               }
# line 666 "C430InsertCCF.cp"
               
# line 666 "C430InsertCCF.cp"
           }
# line 666 "C430InsertCCF.cp"
           

           /*
           ** Generated code ends here.
           */
# line 666 "C430InsertCCF.cp"

                                      
      
           /*
           ** SQL STATEMENT: 14
           ** EXEC SQL COMMIT WORK;

           */
# line 668 "C430InsertCCF.cp"
# line 668 "C430InsertCCF.cp"
           {
# line 668 "C430InsertCCF.cp"
                _SQL_CT_HANDLES * _sql;
# line 668 "C430InsertCCF.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 668 "C430InsertCCF.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 668 "C430InsertCCF.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 668 "C430InsertCCF.cp"
               {
# line 668 "C430InsertCCF.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 668 "C430InsertCCF.cp"
                   _sql->stmttype = SQL_TRANS;
# line 668 "C430InsertCCF.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 668 "C430InsertCCF.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 668 "C430InsertCCF.cp"
                   {
# line 668 "C430InsertCCF.cp"
                       _sql->retcode = ct_command(_sql->conn.command, 
# line 668 "C430InsertCCF.cp"
                           CS_LANG_CMD, "COMMIT WORK", 11, CS_UNUSED);
# line 668 "C430InsertCCF.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 668 "C430InsertCCF.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 668 "C430InsertCCF.cp"
                       _sql->retcode = _sqlResults(_sql);
# line 668 "C430InsertCCF.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 668 "C430InsertCCF.cp"
                   }
# line 668 "C430InsertCCF.cp"
                   
# line 668 "C430InsertCCF.cp"
                   if (sqlca.sqlcode < 0)
# line 668 "C430InsertCCF.cp"
                   {
# line 668 "C430InsertCCF.cp"
                       error_handler();
# line 668 "C430InsertCCF.cp"
                   }
# line 668 "C430InsertCCF.cp"
                   
# line 668 "C430InsertCCF.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 668 "C430InsertCCF.cp"
                   {
# line 668 "C430InsertCCF.cp"
                       warning_handler();
# line 668 "C430InsertCCF.cp"
                   }
# line 668 "C430InsertCCF.cp"
                   
# line 668 "C430InsertCCF.cp"
               }
# line 668 "C430InsertCCF.cp"
               
# line 668 "C430InsertCCF.cp"
           }
# line 668 "C430InsertCCF.cp"
           

           /*
           ** Generated code ends here.
           */
# line 668 "C430InsertCCF.cp"


      /* Verificar la existencia del indice asociado a la tabla previamente
         establecida. */

      
           /*
           ** SQL STATEMENT: 15
           ** EXEC SQL SELECT count(*)
           **                INTO :iIndexID 
           **                FROM sysindexes
           **                WHERE name = :sIndexName;
           */
# line 676 "C430InsertCCF.cp"
# line 673 "C430InsertCCF.cp"
           {
# line 673 "C430InsertCCF.cp"
                _SQL_CT_HANDLES * _sql;
# line 673 "C430InsertCCF.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 673 "C430InsertCCF.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 673 "C430InsertCCF.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 673 "C430InsertCCF.cp"
               {
# line 673 "C430InsertCCF.cp"
                   _sql->stmtIdlen = CS_UNUSED;
# line 673 "C430InsertCCF.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 673 "C430InsertCCF.cp"
                   _sql->stmttype = SQL_SELECT_STMT;
# line 673 "C430InsertCCF.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 673 "C430InsertCCF.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 673 "C430InsertCCF.cp"
                   {
# line 673 "C430InsertCCF.cp"
                       _sql->retcode = ct_command(_sql->conn.command, 
# line 673 "C430InsertCCF.cp"
                           CS_LANG_CMD, "SELECT count(*) FROM sysindexes WHERE "
"name = @sql1_sIndexName ", 62, CS_UNUSED);
# line 673 "C430InsertCCF.cp"
                       if (_sql->retcode == CS_SUCCEED)
# line 673 "C430InsertCCF.cp"
                       {
# line 673 "C430InsertCCF.cp"
                           _sql->dfmtCS_CHAR_TYPE.count = 0;
# line 673 "C430InsertCCF.cp"
                           _sql->dfmtCS_CHAR_TYPE.format = (CS_FMT_NULLTERM | 
# line 673 "C430InsertCCF.cp"
                               CS_FMT_PADBLANK);
# line 673 "C430InsertCCF.cp"
                           _sql->dfmtCS_CHAR_TYPE.maxlength = 
# line 673 "C430InsertCCF.cp"
                           _sql_MIN(16384,LEN30+1);
# line 673 "C430InsertCCF.cp"
                           _sql->dfmtCS_CHAR_TYPE.status = CS_INPUTVALUE;
# line 673 "C430InsertCCF.cp"
                           _sql->retcode = ct_param(_sql->conn.command, 
# line 673 "C430InsertCCF.cp"
                               &_sql->dfmtCS_CHAR_TYPE, _sqlcheckstr(_sql, 
# line 673 "C430InsertCCF.cp"
                           SQLNULLSTR(sIndexName)), (CS_INT) CS_NULLTERM, 
# line 673 "C430InsertCCF.cp"
                               (CS_SMALLINT) 0);
# line 673 "C430InsertCCF.cp"
                           _sql->dfmtCS_CHAR_TYPE.status = 0;
# line 673 "C430InsertCCF.cp"
                       }
# line 673 "C430InsertCCF.cp"
                       
# line 673 "C430InsertCCF.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 673 "C430InsertCCF.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 673 "C430InsertCCF.cp"
                       _sql->resloop = CS_TRUE;
# line 673 "C430InsertCCF.cp"
                       while ((!_sql->hastate) && (_sql->resloop == CS_TRUE) 
# line 673 "C430InsertCCF.cp"
                           && ((_sql->retcode = ct_results(_sql->conn.command, 
# line 673 "C430InsertCCF.cp"
                           &_sql->restype)) == CS_SUCCEED))
# line 673 "C430InsertCCF.cp"
                       {
# line 673 "C430InsertCCF.cp"
                           switch ( _sql->restype )
# line 673 "C430InsertCCF.cp"
                           {
# line 673 "C430InsertCCF.cp"
                           case CS_COMPUTE_RESULT:
# line 673 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 673 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25003);
# line 673 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 673 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 673 "C430InsertCCF.cp"
                           break;
# line 673 "C430InsertCCF.cp"
                           case CS_CURSOR_RESULT:
# line 673 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 673 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25004);
# line 673 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 673 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 673 "C430InsertCCF.cp"
                           break;
# line 673 "C430InsertCCF.cp"
                           case CS_PARAM_RESULT:
# line 673 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 673 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25005);
# line 673 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 673 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 673 "C430InsertCCF.cp"
                           break;
# line 673 "C430InsertCCF.cp"
                           case CS_ROW_RESULT:
# line 673 "C430InsertCCF.cp"
                               _sql->dfmtCS_INT_TYPE.count = 0;
# line 673 "C430InsertCCF.cp"
                                   _sql->retcode = ct_bind(_sql->conn.command, 
# line 673 "C430InsertCCF.cp"
                                       1, &_sql->dfmtCS_INT_TYPE, &iIndexID, 
# line 673 "C430InsertCCF.cp"
                                       NULL, NULL);
# line 673 "C430InsertCCF.cp"
                               _sql->retcode = ct_fetch(_sql->conn.command, 
# line 673 "C430InsertCCF.cp"
                                   CS_UNUSED, CS_UNUSED, CS_UNUSED, 
# line 673 "C430InsertCCF.cp"
                                   &_sql->rowsread);
# line 673 "C430InsertCCF.cp"
                               _sql->hastate = (_sql->retcode == 
# line 673 "C430InsertCCF.cp"
                                   CS_RET_HAFAILOVER);
# line 673 "C430InsertCCF.cp"
                               if ((_sql->retcode == CS_SUCCEED) || 
# line 673 "C430InsertCCF.cp"
                                   (_sql->retcode == CS_ROW_FAIL))
# line 673 "C430InsertCCF.cp"
                               {
# line 673 "C430InsertCCF.cp"
                                   _sql->retcode = ct_bind(_sql->conn.command, 
# line 673 "C430InsertCCF.cp"
                                       CS_UNUSED, NULL, NULL, NULL, NULL);
# line 673 "C430InsertCCF.cp"
                                   _sql->retcode = ct_fetch(_sql->conn.command,
# line 673 "C430InsertCCF.cp"
                                        CS_UNUSED, CS_UNUSED, CS_UNUSED, 
# line 673 "C430InsertCCF.cp"
                                       &_sql->rowsread);
# line 673 "C430InsertCCF.cp"
                                   _sql->hastate = (_sql->retcode == 
# line 673 "C430InsertCCF.cp"
                                       CS_RET_HAFAILOVER);
# line 673 "C430InsertCCF.cp"
                               }
# line 673 "C430InsertCCF.cp"
                               
# line 673 "C430InsertCCF.cp"
                           break;
# line 673 "C430InsertCCF.cp"
                           case CS_STATUS_RESULT:
# line 673 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 673 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25009);
# line 673 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 673 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 673 "C430InsertCCF.cp"
                           break;
# line 673 "C430InsertCCF.cp"
                           case CS_DESCRIBE_RESULT:
# line 673 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 673 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25010);
# line 673 "C430InsertCCF.cp"
                           break;
# line 673 "C430InsertCCF.cp"
                           }
# line 673 "C430InsertCCF.cp"
                           
# line 673 "C430InsertCCF.cp"
                       }
# line 673 "C430InsertCCF.cp"
                       
# line 673 "C430InsertCCF.cp"
                       if ((_sql->retcode != CS_END_RESULTS) && (_sql->retcode 
# line 673 "C430InsertCCF.cp"
                           != CS_CANCELED) && (_sql->retcode != 
# line 673 "C430InsertCCF.cp"
                           CS_RET_HAFAILOVER) && (_sql->resloop != CS_FALSE))
# line 673 "C430InsertCCF.cp"
                       {
# line 673 "C430InsertCCF.cp"
                           _sql->retcode = ct_cancel(NULL, _sql->conn.command, 
# line 673 "C430InsertCCF.cp"
                               CS_CANCEL_ALL);
# line 673 "C430InsertCCF.cp"
                           }
# line 673 "C430InsertCCF.cp"
                            else {
# line 673 "C430InsertCCF.cp"
                           if (((_sql->retcode != CS_CANCELED) && 
# line 673 "C430InsertCCF.cp"
                               (_sql->retcode != CS_RET_HAFAILOVER)))
# line 673 "C430InsertCCF.cp"
                           {
# line 673 "C430InsertCCF.cp"
                               _sql->retcode = CS_SUCCEED;
# line 673 "C430InsertCCF.cp"
                           }
# line 673 "C430InsertCCF.cp"
                           
# line 673 "C430InsertCCF.cp"
                       }
# line 673 "C430InsertCCF.cp"
                       
# line 673 "C430InsertCCF.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 673 "C430InsertCCF.cp"
                   }
# line 673 "C430InsertCCF.cp"
                   
# line 673 "C430InsertCCF.cp"
                   if (sqlca.sqlcode < 0)
# line 673 "C430InsertCCF.cp"
                   {
# line 673 "C430InsertCCF.cp"
                       error_handler();
# line 673 "C430InsertCCF.cp"
                   }
# line 673 "C430InsertCCF.cp"
                   
# line 673 "C430InsertCCF.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 673 "C430InsertCCF.cp"
                   {
# line 673 "C430InsertCCF.cp"
                       warning_handler();
# line 673 "C430InsertCCF.cp"
                   }
# line 673 "C430InsertCCF.cp"
                   
# line 673 "C430InsertCCF.cp"
               }
# line 673 "C430InsertCCF.cp"
               
# line 673 "C430InsertCCF.cp"
           }
# line 673 "C430InsertCCF.cp"
           

           /*
           ** Generated code ends here.
           */
# line 676 "C430InsertCCF.cp"
 

      
           /*
           ** SQL STATEMENT: 16
           ** EXEC SQL COMMIT WORK;

           */
# line 678 "C430InsertCCF.cp"
# line 678 "C430InsertCCF.cp"
           {
# line 678 "C430InsertCCF.cp"
                _SQL_CT_HANDLES * _sql;
# line 678 "C430InsertCCF.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 678 "C430InsertCCF.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 678 "C430InsertCCF.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 678 "C430InsertCCF.cp"
               {
# line 678 "C430InsertCCF.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 678 "C430InsertCCF.cp"
                   _sql->stmttype = SQL_TRANS;
# line 678 "C430InsertCCF.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 678 "C430InsertCCF.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 678 "C430InsertCCF.cp"
                   {
# line 678 "C430InsertCCF.cp"
                       _sql->retcode = ct_command(_sql->conn.command, 
# line 678 "C430InsertCCF.cp"
                           CS_LANG_CMD, "COMMIT WORK", 11, CS_UNUSED);
# line 678 "C430InsertCCF.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 678 "C430InsertCCF.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 678 "C430InsertCCF.cp"
                       _sql->retcode = _sqlResults(_sql);
# line 678 "C430InsertCCF.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 678 "C430InsertCCF.cp"
                   }
# line 678 "C430InsertCCF.cp"
                   
# line 678 "C430InsertCCF.cp"
                   if (sqlca.sqlcode < 0)
# line 678 "C430InsertCCF.cp"
                   {
# line 678 "C430InsertCCF.cp"
                       error_handler();
# line 678 "C430InsertCCF.cp"
                   }
# line 678 "C430InsertCCF.cp"
                   
# line 678 "C430InsertCCF.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 678 "C430InsertCCF.cp"
                   {
# line 678 "C430InsertCCF.cp"
                       warning_handler();
# line 678 "C430InsertCCF.cp"
                   }
# line 678 "C430InsertCCF.cp"
                   
# line 678 "C430InsertCCF.cp"
               }
# line 678 "C430InsertCCF.cp"
               
# line 678 "C430InsertCCF.cp"
           }
# line 678 "C430InsertCCF.cp"
           

           /*
           ** Generated code ends here.
           */
# line 678 "C430InsertCCF.cp"


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
	    strcat(sSQLCommand, "com_name_kanji_out	char(1)		NOT NULL, ");		/* FUN 23122004 */
	    strcat(sSQLCommand, "com_name_kanji		char(60)	NOT NULL, ");		/* FUN 23122004 */
	    strcat(sSQLCommand, "com_name_kanji_in	char(1)		NOT NULL, ");		/* FUN 23122004 */
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
	    strcat(sSQLCommand, "address_line1_kanji_out	char(1)		NOT NULL, ");	/* FUN 23122004 */
            strcat(sSQLCommand, "address_line1			char(40)	not null, ");
	    strcat(sSQLCommand, "address_line1_kanji_in		char(1)		NOT NULL, ");	/* FUN 23122004 */
	    strcat(sSQLCommand, "address_line2_kanji_out	char(1)		NOT NULL, ");	/* FUN 23122004 */
            strcat(sSQLCommand, "address_line2			char(40)	not null, ");
	    strcat(sSQLCommand, "address_line2_kanji_in		char(1)		NOT NULL, ");	/* FUN 23122004 */
	    strcat(sSQLCommand, "address_line3_kanji_out	char(1)		NOT NULL, ");	/* FUN 23122004 */
            strcat(sSQLCommand, "address_line3			char(40)	not null, ");
	    strcat(sSQLCommand, "address_line3_kanji_in		char(1)		NOT NULL, ");	/* FUN 23122004 */
	    strcat(sSQLCommand, "address_line4_so		char(1)		NOT NULL, ");	/* FUN 23122004 */
            strcat(sSQLCommand, "address_line4			char(40)	not null, ");
	    strcat(sSQLCommand, "address_line4_si		char(1)		NOT NULL, ");	/* FUN 23122004 */
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
	    strcat(sSQLCommand, "kanji_name_out			char(1)		NOT NULL, ");	/* FUN 23122004 */
	    strcat(sSQLCommand, "kanji_name			char(50)	NOT NULL, ");	/* FUN 23122004 */
	    strcat(sSQLCommand, "kanji_name_in			char(1)		NOT NULL, ");	/* FUN 23122004 */
	    strcat(sSQLCommand, "address_line4_kanji_out	char(1)		NOT NULL, ");	/* FUN 23122004 */
	    strcat(sSQLCommand, "address_line4_kanji		char(60)	NOT NULL, ");	/* FUN 23122004 */
	    strcat(sSQLCommand, "address_line4_kanji_in		char(1)		NOT NULL, ");	/* FUN 23122004 */
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
            strcat(sSQLCommand, "charge_off_date		char(8)		not null, ");	/* FUN 23122004 */
            strcat(sSQLCommand, "charge_off_balance c		har(18)		not null, ");
            strcat(sSQLCommand, "charge_off_reason		char(1)		not null, ");
            strcat(sSQLCommand, "other_acct_nbr			char(25)	not null, ");
            strcat(sSQLCommand, "crv_status			char(1)		not null, ");
            strcat(sSQLCommand, "cash_advance_lmt		char(18)	not null, ");
            strcat(sSQLCommand, "cash_adv_lmt_frec		char(3)		not null, ");
	    strcat(sSQLCommand, "ecs_account_status		char(1)		NOT NULL, ");	/* FUN 23122004 */
	    strcat(sSQLCommand, "ecs_block_code			char(1)		NOT NULL, ");	/* FUN 23122004 */
	    strcat(sSQLCommand, "ecs_block_reason		char(2)		NOT NULL, ");	/* FUN 23122004 */
            strcat(sSQLCommand, "preview_balance		char(18)	not null, ");
	    strcat(sSQLCommand, "number_of_cycles_past_due	char(2)		NOT NULL, ");	/* FUN 23122004 */
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
	    strcat(sSQLCommand, "billing_date           char(8)		NOT NULL, ");	/* FUN 23122004 */
            strcat(sSQLCommand, "filler2		char(193)	not null, ");	/* FUN 23122004 */
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
            strcat(sSQLCommand, "filler				text		not null, ");
            strcat(sSQLCommand, "trx_control_data		char(50)	not null)");
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
            exit(ERREXIT);                                          
         }

         
           /*
           ** SQL STATEMENT: 17
           ** EXEC SQL PREPARE creattable FROM :sSQLCommand;
           */
# line 1214 "C430InsertCCF.cp"
# line 1214 "C430InsertCCF.cp"
           {
# line 1214 "C430InsertCCF.cp"
                _SQL_CT_HANDLES * _sql;
# line 1214 "C430InsertCCF.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 1214 "C430InsertCCF.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 1214 "C430InsertCCF.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 1214 "C430InsertCCF.cp"
               {
# line 1214 "C430InsertCCF.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 1214 "C430InsertCCF.cp"
                   _sql->stmttype = SQL_PREPARE;
# line 1214 "C430InsertCCF.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 1214 "C430InsertCCF.cp"
                   _sql->stmtName.fnlen = 10;
# line 1214 "C430InsertCCF.cp"
                   strcpy(_sql->stmtName.first_name, "creattable");
# line 1214 "C430InsertCCF.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 1214 "C430InsertCCF.cp"
                   {
# line 1214 "C430InsertCCF.cp"
                       _sql->retcode = ct_dynamic(_sql->conn.command, 
# line 1214 "C430InsertCCF.cp"
                           CS_PREPARE, "creattable", 10, sSQLCommand, 
# line 1214 "C430InsertCCF.cp"
                           CS_NULLTERM);
# line 1214 "C430InsertCCF.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 1214 "C430InsertCCF.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 1214 "C430InsertCCF.cp"
                       _sql->resloop = CS_TRUE;
# line 1214 "C430InsertCCF.cp"
                       while ((!_sql->hastate) && (_sql->resloop == CS_TRUE) 
# line 1214 "C430InsertCCF.cp"
                           && ((_sql->retcode = ct_results(_sql->conn.command, 
# line 1214 "C430InsertCCF.cp"
                           &_sql->restype)) == CS_SUCCEED))
# line 1214 "C430InsertCCF.cp"
                       {
# line 1214 "C430InsertCCF.cp"
                           switch ( _sql->restype )
# line 1214 "C430InsertCCF.cp"
                           {
# line 1214 "C430InsertCCF.cp"
                           case CS_CMD_FAIL:
# line 1214 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 1214 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_ALL);
# line 1214 "C430InsertCCF.cp"
                           break;
# line 1214 "C430InsertCCF.cp"
                           case CS_COMPUTE_RESULT:
# line 1214 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 1214 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25003);
# line 1214 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 1214 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 1214 "C430InsertCCF.cp"
                           break;
# line 1214 "C430InsertCCF.cp"
                           case CS_CURSOR_RESULT:
# line 1214 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 1214 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25004);
# line 1214 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 1214 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 1214 "C430InsertCCF.cp"
                           break;
# line 1214 "C430InsertCCF.cp"
                           case CS_PARAM_RESULT:
# line 1214 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 1214 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25005);
# line 1214 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 1214 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 1214 "C430InsertCCF.cp"
                           break;
# line 1214 "C430InsertCCF.cp"
                           case CS_ROW_RESULT:
# line 1214 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 1214 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25006);
# line 1214 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 1214 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 1214 "C430InsertCCF.cp"
                           break;
# line 1214 "C430InsertCCF.cp"
                           case CS_STATUS_RESULT:
# line 1214 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 1214 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25009);
# line 1214 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 1214 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 1214 "C430InsertCCF.cp"
                           break;
# line 1214 "C430InsertCCF.cp"
                           case CS_DESCRIBE_RESULT:
# line 1214 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 1214 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25010);
# line 1214 "C430InsertCCF.cp"
                           break;
# line 1214 "C430InsertCCF.cp"
                           }
# line 1214 "C430InsertCCF.cp"
                           
# line 1214 "C430InsertCCF.cp"
                       }
# line 1214 "C430InsertCCF.cp"
                       
# line 1214 "C430InsertCCF.cp"
                       if ((_sql->retcode != CS_END_RESULTS) && (_sql->retcode 
# line 1214 "C430InsertCCF.cp"
                           != CS_CANCELED) && (_sql->retcode != 
# line 1214 "C430InsertCCF.cp"
                           CS_RET_HAFAILOVER) && (_sql->resloop != CS_FALSE))
# line 1214 "C430InsertCCF.cp"
                       {
# line 1214 "C430InsertCCF.cp"
                           _sql->retcode = ct_cancel(NULL, _sql->conn.command, 
# line 1214 "C430InsertCCF.cp"
                               CS_CANCEL_ALL);
# line 1214 "C430InsertCCF.cp"
                           }
# line 1214 "C430InsertCCF.cp"
                            else {
# line 1214 "C430InsertCCF.cp"
                           if (((_sql->retcode != CS_CANCELED) && 
# line 1214 "C430InsertCCF.cp"
                               (_sql->retcode != CS_RET_HAFAILOVER)))
# line 1214 "C430InsertCCF.cp"
                           {
# line 1214 "C430InsertCCF.cp"
                               _sql->retcode = CS_SUCCEED;
# line 1214 "C430InsertCCF.cp"
                           }
# line 1214 "C430InsertCCF.cp"
                           
# line 1214 "C430InsertCCF.cp"
                       }
# line 1214 "C430InsertCCF.cp"
                       
# line 1214 "C430InsertCCF.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 1214 "C430InsertCCF.cp"
                   }
# line 1214 "C430InsertCCF.cp"
                   
# line 1214 "C430InsertCCF.cp"
                   if (sqlca.sqlcode < 0)
# line 1214 "C430InsertCCF.cp"
                   {
# line 1214 "C430InsertCCF.cp"
                       error_handler();
# line 1214 "C430InsertCCF.cp"
                   }
# line 1214 "C430InsertCCF.cp"
                   
# line 1214 "C430InsertCCF.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 1214 "C430InsertCCF.cp"
                   {
# line 1214 "C430InsertCCF.cp"
                       warning_handler();
# line 1214 "C430InsertCCF.cp"
                   }
# line 1214 "C430InsertCCF.cp"
                   
# line 1214 "C430InsertCCF.cp"
               }
# line 1214 "C430InsertCCF.cp"
               
# line 1214 "C430InsertCCF.cp"
           }
# line 1214 "C430InsertCCF.cp"
           

           /*
           ** Generated code ends here.
           */
# line 1214 "C430InsertCCF.cp"
  
                                               
         
           /*
           ** SQL STATEMENT: 18
           ** EXEC SQL EXECUTE creattable;

           */
# line 1216 "C430InsertCCF.cp"
# line 1216 "C430InsertCCF.cp"
           {
# line 1216 "C430InsertCCF.cp"
                _SQL_CT_HANDLES * _sql;
# line 1216 "C430InsertCCF.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 1216 "C430InsertCCF.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 1216 "C430InsertCCF.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 1216 "C430InsertCCF.cp"
               {
# line 1216 "C430InsertCCF.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 1216 "C430InsertCCF.cp"
                   _sql->stmttype = SQL_EXECUTE;
# line 1216 "C430InsertCCF.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 1216 "C430InsertCCF.cp"
                   _sql->stmtName.fnlen = 10;
# line 1216 "C430InsertCCF.cp"
                   strcpy(_sql->stmtName.first_name, "creattable");
# line 1216 "C430InsertCCF.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 1216 "C430InsertCCF.cp"
                   {
# line 1216 "C430InsertCCF.cp"
                       _sql->retcode = ct_dynamic(_sql->conn.command, 
# line 1216 "C430InsertCCF.cp"
                           CS_EXECUTE, "creattable", 10, NULL, CS_UNUSED);
# line 1216 "C430InsertCCF.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 1216 "C430InsertCCF.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 1216 "C430InsertCCF.cp"
                       _sql->retcode = _sqlResults(_sql);
# line 1216 "C430InsertCCF.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 1216 "C430InsertCCF.cp"
                   }
# line 1216 "C430InsertCCF.cp"
                   
# line 1216 "C430InsertCCF.cp"
                   if (sqlca.sqlcode < 0)
# line 1216 "C430InsertCCF.cp"
                   {
# line 1216 "C430InsertCCF.cp"
                       error_handler();
# line 1216 "C430InsertCCF.cp"
                   }
# line 1216 "C430InsertCCF.cp"
                   
# line 1216 "C430InsertCCF.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 1216 "C430InsertCCF.cp"
                   {
# line 1216 "C430InsertCCF.cp"
                       warning_handler();
# line 1216 "C430InsertCCF.cp"
                   }
# line 1216 "C430InsertCCF.cp"
                   
# line 1216 "C430InsertCCF.cp"
               }
# line 1216 "C430InsertCCF.cp"
               
# line 1216 "C430InsertCCF.cp"
           }
# line 1216 "C430InsertCCF.cp"
           

           /*
           ** Generated code ends here.
           */
# line 1216 "C430InsertCCF.cp"


         
           /*
           ** SQL STATEMENT: 19
           ** EXEC SQL DEALLOCATE PREPARE creattable;

           */
# line 1218 "C430InsertCCF.cp"
# line 1218 "C430InsertCCF.cp"
           {
# line 1218 "C430InsertCCF.cp"
                _SQL_CT_HANDLES * _sql;
# line 1218 "C430InsertCCF.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 1218 "C430InsertCCF.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 1218 "C430InsertCCF.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 1218 "C430InsertCCF.cp"
               {
# line 1218 "C430InsertCCF.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 1218 "C430InsertCCF.cp"
                   _sql->stmttype = SQL_DEALLOCATE_PREPARE;
# line 1218 "C430InsertCCF.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 1218 "C430InsertCCF.cp"
                   _sql->stmtName.fnlen = 10;
# line 1218 "C430InsertCCF.cp"
                   strcpy(_sql->stmtName.first_name, "creattable");
# line 1218 "C430InsertCCF.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 1218 "C430InsertCCF.cp"
                   {
# line 1218 "C430InsertCCF.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 1218 "C430InsertCCF.cp"
                   }
# line 1218 "C430InsertCCF.cp"
                   
# line 1218 "C430InsertCCF.cp"
                   if (sqlca.sqlcode < 0)
# line 1218 "C430InsertCCF.cp"
                   {
# line 1218 "C430InsertCCF.cp"
                       error_handler();
# line 1218 "C430InsertCCF.cp"
                   }
# line 1218 "C430InsertCCF.cp"
                   
# line 1218 "C430InsertCCF.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 1218 "C430InsertCCF.cp"
                   {
# line 1218 "C430InsertCCF.cp"
                       warning_handler();
# line 1218 "C430InsertCCF.cp"
                   }
# line 1218 "C430InsertCCF.cp"
                   
# line 1218 "C430InsertCCF.cp"
               }
# line 1218 "C430InsertCCF.cp"
               
# line 1218 "C430InsertCCF.cp"
           }
# line 1218 "C430InsertCCF.cp"
           

           /*
           ** Generated code ends here.
           */
# line 1218 "C430InsertCCF.cp"

                                      
         
           /*
           ** SQL STATEMENT: 20
           ** EXEC SQL COMMIT WORK;

           */
# line 1220 "C430InsertCCF.cp"
# line 1220 "C430InsertCCF.cp"
           {
# line 1220 "C430InsertCCF.cp"
                _SQL_CT_HANDLES * _sql;
# line 1220 "C430InsertCCF.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 1220 "C430InsertCCF.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 1220 "C430InsertCCF.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 1220 "C430InsertCCF.cp"
               {
# line 1220 "C430InsertCCF.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 1220 "C430InsertCCF.cp"
                   _sql->stmttype = SQL_TRANS;
# line 1220 "C430InsertCCF.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 1220 "C430InsertCCF.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 1220 "C430InsertCCF.cp"
                   {
# line 1220 "C430InsertCCF.cp"
                       _sql->retcode = ct_command(_sql->conn.command, 
# line 1220 "C430InsertCCF.cp"
                           CS_LANG_CMD, "COMMIT WORK", 11, CS_UNUSED);
# line 1220 "C430InsertCCF.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 1220 "C430InsertCCF.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 1220 "C430InsertCCF.cp"
                       _sql->retcode = _sqlResults(_sql);
# line 1220 "C430InsertCCF.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 1220 "C430InsertCCF.cp"
                   }
# line 1220 "C430InsertCCF.cp"
                   
# line 1220 "C430InsertCCF.cp"
                   if (sqlca.sqlcode < 0)
# line 1220 "C430InsertCCF.cp"
                   {
# line 1220 "C430InsertCCF.cp"
                       error_handler();
# line 1220 "C430InsertCCF.cp"
                   }
# line 1220 "C430InsertCCF.cp"
                   
# line 1220 "C430InsertCCF.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 1220 "C430InsertCCF.cp"
                   {
# line 1220 "C430InsertCCF.cp"
                       warning_handler();
# line 1220 "C430InsertCCF.cp"
                   }
# line 1220 "C430InsertCCF.cp"
                   
# line 1220 "C430InsertCCF.cp"
               }
# line 1220 "C430InsertCCF.cp"
               
# line 1220 "C430InsertCCF.cp"
           }
# line 1220 "C430InsertCCF.cp"
           

           /*
           ** Generated code ends here.
           */
# line 1220 "C430InsertCCF.cp"

      }

      if(iIndexID == 0)
      {
         /* Si el indice no existe, crearlo. */

         printf("Dentro de la rutina de indices...");

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
         
         
           /*
           ** SQL STATEMENT: 21
           ** EXEC SQL PREPARE creatindex FROM :sSQLCommand;
           */
# line 1272 "C430InsertCCF.cp"
# line 1272 "C430InsertCCF.cp"
           {
# line 1272 "C430InsertCCF.cp"
                _SQL_CT_HANDLES * _sql;
# line 1272 "C430InsertCCF.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 1272 "C430InsertCCF.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 1272 "C430InsertCCF.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 1272 "C430InsertCCF.cp"
               {
# line 1272 "C430InsertCCF.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 1272 "C430InsertCCF.cp"
                   _sql->stmttype = SQL_PREPARE;
# line 1272 "C430InsertCCF.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 1272 "C430InsertCCF.cp"
                   _sql->stmtName.fnlen = 10;
# line 1272 "C430InsertCCF.cp"
                   strcpy(_sql->stmtName.first_name, "creatindex");
# line 1272 "C430InsertCCF.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 1272 "C430InsertCCF.cp"
                   {
# line 1272 "C430InsertCCF.cp"
                       _sql->retcode = ct_dynamic(_sql->conn.command, 
# line 1272 "C430InsertCCF.cp"
                           CS_PREPARE, "creatindex", 10, sSQLCommand, 
# line 1272 "C430InsertCCF.cp"
                           CS_NULLTERM);
# line 1272 "C430InsertCCF.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 1272 "C430InsertCCF.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 1272 "C430InsertCCF.cp"
                       _sql->resloop = CS_TRUE;
# line 1272 "C430InsertCCF.cp"
                       while ((!_sql->hastate) && (_sql->resloop == CS_TRUE) 
# line 1272 "C430InsertCCF.cp"
                           && ((_sql->retcode = ct_results(_sql->conn.command, 
# line 1272 "C430InsertCCF.cp"
                           &_sql->restype)) == CS_SUCCEED))
# line 1272 "C430InsertCCF.cp"
                       {
# line 1272 "C430InsertCCF.cp"
                           switch ( _sql->restype )
# line 1272 "C430InsertCCF.cp"
                           {
# line 1272 "C430InsertCCF.cp"
                           case CS_CMD_FAIL:
# line 1272 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 1272 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_ALL);
# line 1272 "C430InsertCCF.cp"
                           break;
# line 1272 "C430InsertCCF.cp"
                           case CS_COMPUTE_RESULT:
# line 1272 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 1272 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25003);
# line 1272 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 1272 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 1272 "C430InsertCCF.cp"
                           break;
# line 1272 "C430InsertCCF.cp"
                           case CS_CURSOR_RESULT:
# line 1272 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 1272 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25004);
# line 1272 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 1272 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 1272 "C430InsertCCF.cp"
                           break;
# line 1272 "C430InsertCCF.cp"
                           case CS_PARAM_RESULT:
# line 1272 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 1272 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25005);
# line 1272 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 1272 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 1272 "C430InsertCCF.cp"
                           break;
# line 1272 "C430InsertCCF.cp"
                           case CS_ROW_RESULT:
# line 1272 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 1272 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25006);
# line 1272 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 1272 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 1272 "C430InsertCCF.cp"
                           break;
# line 1272 "C430InsertCCF.cp"
                           case CS_STATUS_RESULT:
# line 1272 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 1272 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25009);
# line 1272 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 1272 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 1272 "C430InsertCCF.cp"
                           break;
# line 1272 "C430InsertCCF.cp"
                           case CS_DESCRIBE_RESULT:
# line 1272 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 1272 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25010);
# line 1272 "C430InsertCCF.cp"
                           break;
# line 1272 "C430InsertCCF.cp"
                           }
# line 1272 "C430InsertCCF.cp"
                           
# line 1272 "C430InsertCCF.cp"
                       }
# line 1272 "C430InsertCCF.cp"
                       
# line 1272 "C430InsertCCF.cp"
                       if ((_sql->retcode != CS_END_RESULTS) && (_sql->retcode 
# line 1272 "C430InsertCCF.cp"
                           != CS_CANCELED) && (_sql->retcode != 
# line 1272 "C430InsertCCF.cp"
                           CS_RET_HAFAILOVER) && (_sql->resloop != CS_FALSE))
# line 1272 "C430InsertCCF.cp"
                       {
# line 1272 "C430InsertCCF.cp"
                           _sql->retcode = ct_cancel(NULL, _sql->conn.command, 
# line 1272 "C430InsertCCF.cp"
                               CS_CANCEL_ALL);
# line 1272 "C430InsertCCF.cp"
                           }
# line 1272 "C430InsertCCF.cp"
                            else {
# line 1272 "C430InsertCCF.cp"
                           if (((_sql->retcode != CS_CANCELED) && 
# line 1272 "C430InsertCCF.cp"
                               (_sql->retcode != CS_RET_HAFAILOVER)))
# line 1272 "C430InsertCCF.cp"
                           {
# line 1272 "C430InsertCCF.cp"
                               _sql->retcode = CS_SUCCEED;
# line 1272 "C430InsertCCF.cp"
                           }
# line 1272 "C430InsertCCF.cp"
                           
# line 1272 "C430InsertCCF.cp"
                       }
# line 1272 "C430InsertCCF.cp"
                       
# line 1272 "C430InsertCCF.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 1272 "C430InsertCCF.cp"
                   }
# line 1272 "C430InsertCCF.cp"
                   
# line 1272 "C430InsertCCF.cp"
                   if (sqlca.sqlcode < 0)
# line 1272 "C430InsertCCF.cp"
                   {
# line 1272 "C430InsertCCF.cp"
                       error_handler();
# line 1272 "C430InsertCCF.cp"
                   }
# line 1272 "C430InsertCCF.cp"
                   
# line 1272 "C430InsertCCF.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 1272 "C430InsertCCF.cp"
                   {
# line 1272 "C430InsertCCF.cp"
                       warning_handler();
# line 1272 "C430InsertCCF.cp"
                   }
# line 1272 "C430InsertCCF.cp"
                   
# line 1272 "C430InsertCCF.cp"
               }
# line 1272 "C430InsertCCF.cp"
               
# line 1272 "C430InsertCCF.cp"
           }
# line 1272 "C430InsertCCF.cp"
           

           /*
           ** Generated code ends here.
           */
# line 1272 "C430InsertCCF.cp"
  
                                               
         
           /*
           ** SQL STATEMENT: 22
           ** EXEC SQL EXECUTE creatindex;

           */
# line 1274 "C430InsertCCF.cp"
# line 1274 "C430InsertCCF.cp"
           {
# line 1274 "C430InsertCCF.cp"
                _SQL_CT_HANDLES * _sql;
# line 1274 "C430InsertCCF.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 1274 "C430InsertCCF.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 1274 "C430InsertCCF.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 1274 "C430InsertCCF.cp"
               {
# line 1274 "C430InsertCCF.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 1274 "C430InsertCCF.cp"
                   _sql->stmttype = SQL_EXECUTE;
# line 1274 "C430InsertCCF.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 1274 "C430InsertCCF.cp"
                   _sql->stmtName.fnlen = 10;
# line 1274 "C430InsertCCF.cp"
                   strcpy(_sql->stmtName.first_name, "creatindex");
# line 1274 "C430InsertCCF.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 1274 "C430InsertCCF.cp"
                   {
# line 1274 "C430InsertCCF.cp"
                       _sql->retcode = ct_dynamic(_sql->conn.command, 
# line 1274 "C430InsertCCF.cp"
                           CS_EXECUTE, "creatindex", 10, NULL, CS_UNUSED);
# line 1274 "C430InsertCCF.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 1274 "C430InsertCCF.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 1274 "C430InsertCCF.cp"
                       _sql->retcode = _sqlResults(_sql);
# line 1274 "C430InsertCCF.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 1274 "C430InsertCCF.cp"
                   }
# line 1274 "C430InsertCCF.cp"
                   
# line 1274 "C430InsertCCF.cp"
                   if (sqlca.sqlcode < 0)
# line 1274 "C430InsertCCF.cp"
                   {
# line 1274 "C430InsertCCF.cp"
                       error_handler();
# line 1274 "C430InsertCCF.cp"
                   }
# line 1274 "C430InsertCCF.cp"
                   
# line 1274 "C430InsertCCF.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 1274 "C430InsertCCF.cp"
                   {
# line 1274 "C430InsertCCF.cp"
                       warning_handler();
# line 1274 "C430InsertCCF.cp"
                   }
# line 1274 "C430InsertCCF.cp"
                   
# line 1274 "C430InsertCCF.cp"
               }
# line 1274 "C430InsertCCF.cp"
               
# line 1274 "C430InsertCCF.cp"
           }
# line 1274 "C430InsertCCF.cp"
           

           /*
           ** Generated code ends here.
           */
# line 1274 "C430InsertCCF.cp"


         
           /*
           ** SQL STATEMENT: 23
           ** EXEC SQL DEALLOCATE PREPARE creatindex;

           */
# line 1276 "C430InsertCCF.cp"
# line 1276 "C430InsertCCF.cp"
           {
# line 1276 "C430InsertCCF.cp"
                _SQL_CT_HANDLES * _sql;
# line 1276 "C430InsertCCF.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 1276 "C430InsertCCF.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 1276 "C430InsertCCF.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 1276 "C430InsertCCF.cp"
               {
# line 1276 "C430InsertCCF.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 1276 "C430InsertCCF.cp"
                   _sql->stmttype = SQL_DEALLOCATE_PREPARE;
# line 1276 "C430InsertCCF.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 1276 "C430InsertCCF.cp"
                   _sql->stmtName.fnlen = 10;
# line 1276 "C430InsertCCF.cp"
                   strcpy(_sql->stmtName.first_name, "creatindex");
# line 1276 "C430InsertCCF.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 1276 "C430InsertCCF.cp"
                   {
# line 1276 "C430InsertCCF.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 1276 "C430InsertCCF.cp"
                   }
# line 1276 "C430InsertCCF.cp"
                   
# line 1276 "C430InsertCCF.cp"
                   if (sqlca.sqlcode < 0)
# line 1276 "C430InsertCCF.cp"
                   {
# line 1276 "C430InsertCCF.cp"
                       error_handler();
# line 1276 "C430InsertCCF.cp"
                   }
# line 1276 "C430InsertCCF.cp"
                   
# line 1276 "C430InsertCCF.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 1276 "C430InsertCCF.cp"
                   {
# line 1276 "C430InsertCCF.cp"
                       warning_handler();
# line 1276 "C430InsertCCF.cp"
                   }
# line 1276 "C430InsertCCF.cp"
                   
# line 1276 "C430InsertCCF.cp"
               }
# line 1276 "C430InsertCCF.cp"
               
# line 1276 "C430InsertCCF.cp"
           }
# line 1276 "C430InsertCCF.cp"
           

           /*
           ** Generated code ends here.
           */
# line 1276 "C430InsertCCF.cp"

                                      
         
           /*
           ** SQL STATEMENT: 24
           ** EXEC SQL COMMIT WORK;

           */
# line 1278 "C430InsertCCF.cp"
# line 1278 "C430InsertCCF.cp"
           {
# line 1278 "C430InsertCCF.cp"
                _SQL_CT_HANDLES * _sql;
# line 1278 "C430InsertCCF.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 1278 "C430InsertCCF.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 1278 "C430InsertCCF.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 1278 "C430InsertCCF.cp"
               {
# line 1278 "C430InsertCCF.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 1278 "C430InsertCCF.cp"
                   _sql->stmttype = SQL_TRANS;
# line 1278 "C430InsertCCF.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 1278 "C430InsertCCF.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 1278 "C430InsertCCF.cp"
                   {
# line 1278 "C430InsertCCF.cp"
                       _sql->retcode = ct_command(_sql->conn.command, 
# line 1278 "C430InsertCCF.cp"
                           CS_LANG_CMD, "COMMIT WORK", 11, CS_UNUSED);
# line 1278 "C430InsertCCF.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 1278 "C430InsertCCF.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 1278 "C430InsertCCF.cp"
                       _sql->retcode = _sqlResults(_sql);
# line 1278 "C430InsertCCF.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 1278 "C430InsertCCF.cp"
                   }
# line 1278 "C430InsertCCF.cp"
                   
# line 1278 "C430InsertCCF.cp"
                   if (sqlca.sqlcode < 0)
# line 1278 "C430InsertCCF.cp"
                   {
# line 1278 "C430InsertCCF.cp"
                       error_handler();
# line 1278 "C430InsertCCF.cp"
                   }
# line 1278 "C430InsertCCF.cp"
                   
# line 1278 "C430InsertCCF.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 1278 "C430InsertCCF.cp"
                   {
# line 1278 "C430InsertCCF.cp"
                       warning_handler();
# line 1278 "C430InsertCCF.cp"
                   }
# line 1278 "C430InsertCCF.cp"
                   
# line 1278 "C430InsertCCF.cp"
               }
# line 1278 "C430InsertCCF.cp"
               
# line 1278 "C430InsertCCF.cp"
           }
# line 1278 "C430InsertCCF.cp"
           

           /*
           ** Generated code ends here.
           */
# line 1278 "C430InsertCCF.cp"


         /* Creacion de indices adicionales. */

         strcpy(sSQLCommand, "CREATE NONCLUSTERED INDEX ");
         printf("\n%s", sSQLCommand);
         strcat(sSQLCommand, PREFFIXINDNC);
         strcat(sSQLCommand, sIndexName);
         strcat(sSQLCommand, " on ");
         strcat(sSQLCommand, sTableName);
         strcat(sSQLCommand, "(");

         if((strcmp(sRecordType, FMTREC2000) == 0) ||
            (strcmp(sRecordType, FMTREC2001) == 0) ||
            (strcmp(sRecordType, FMTREC5000) == 0))
         {
            /* Registro Analizado 2000. */
            /* Registro Analizado 2001. */
            /* Registro Analizado 5000. */

            strcat(sSQLCommand, "account_number)"); 
         }


         
           /*
           ** SQL STATEMENT: 25
           ** EXEC SQL PREPARE creatindnc FROM :sSQLCommand;
           */
# line 1302 "C430InsertCCF.cp"
# line 1302 "C430InsertCCF.cp"
           {
# line 1302 "C430InsertCCF.cp"
                _SQL_CT_HANDLES * _sql;
# line 1302 "C430InsertCCF.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 1302 "C430InsertCCF.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 1302 "C430InsertCCF.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 1302 "C430InsertCCF.cp"
               {
# line 1302 "C430InsertCCF.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 1302 "C430InsertCCF.cp"
                   _sql->stmttype = SQL_PREPARE;
# line 1302 "C430InsertCCF.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 1302 "C430InsertCCF.cp"
                   _sql->stmtName.fnlen = 10;
# line 1302 "C430InsertCCF.cp"
                   strcpy(_sql->stmtName.first_name, "creatindnc");
# line 1302 "C430InsertCCF.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 1302 "C430InsertCCF.cp"
                   {
# line 1302 "C430InsertCCF.cp"
                       _sql->retcode = ct_dynamic(_sql->conn.command, 
# line 1302 "C430InsertCCF.cp"
                           CS_PREPARE, "creatindnc", 10, sSQLCommand, 
# line 1302 "C430InsertCCF.cp"
                           CS_NULLTERM);
# line 1302 "C430InsertCCF.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 1302 "C430InsertCCF.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 1302 "C430InsertCCF.cp"
                       _sql->resloop = CS_TRUE;
# line 1302 "C430InsertCCF.cp"
                       while ((!_sql->hastate) && (_sql->resloop == CS_TRUE) 
# line 1302 "C430InsertCCF.cp"
                           && ((_sql->retcode = ct_results(_sql->conn.command, 
# line 1302 "C430InsertCCF.cp"
                           &_sql->restype)) == CS_SUCCEED))
# line 1302 "C430InsertCCF.cp"
                       {
# line 1302 "C430InsertCCF.cp"
                           switch ( _sql->restype )
# line 1302 "C430InsertCCF.cp"
                           {
# line 1302 "C430InsertCCF.cp"
                           case CS_CMD_FAIL:
# line 1302 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 1302 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_ALL);
# line 1302 "C430InsertCCF.cp"
                           break;
# line 1302 "C430InsertCCF.cp"
                           case CS_COMPUTE_RESULT:
# line 1302 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 1302 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25003);
# line 1302 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 1302 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 1302 "C430InsertCCF.cp"
                           break;
# line 1302 "C430InsertCCF.cp"
                           case CS_CURSOR_RESULT:
# line 1302 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 1302 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25004);
# line 1302 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 1302 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 1302 "C430InsertCCF.cp"
                           break;
# line 1302 "C430InsertCCF.cp"
                           case CS_PARAM_RESULT:
# line 1302 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 1302 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25005);
# line 1302 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 1302 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 1302 "C430InsertCCF.cp"
                           break;
# line 1302 "C430InsertCCF.cp"
                           case CS_ROW_RESULT:
# line 1302 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 1302 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25006);
# line 1302 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 1302 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 1302 "C430InsertCCF.cp"
                           break;
# line 1302 "C430InsertCCF.cp"
                           case CS_STATUS_RESULT:
# line 1302 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 1302 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25009);
# line 1302 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 1302 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 1302 "C430InsertCCF.cp"
                           break;
# line 1302 "C430InsertCCF.cp"
                           case CS_DESCRIBE_RESULT:
# line 1302 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 1302 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25010);
# line 1302 "C430InsertCCF.cp"
                           break;
# line 1302 "C430InsertCCF.cp"
                           }
# line 1302 "C430InsertCCF.cp"
                           
# line 1302 "C430InsertCCF.cp"
                       }
# line 1302 "C430InsertCCF.cp"
                       
# line 1302 "C430InsertCCF.cp"
                       if ((_sql->retcode != CS_END_RESULTS) && (_sql->retcode 
# line 1302 "C430InsertCCF.cp"
                           != CS_CANCELED) && (_sql->retcode != 
# line 1302 "C430InsertCCF.cp"
                           CS_RET_HAFAILOVER) && (_sql->resloop != CS_FALSE))
# line 1302 "C430InsertCCF.cp"
                       {
# line 1302 "C430InsertCCF.cp"
                           _sql->retcode = ct_cancel(NULL, _sql->conn.command, 
# line 1302 "C430InsertCCF.cp"
                               CS_CANCEL_ALL);
# line 1302 "C430InsertCCF.cp"
                           }
# line 1302 "C430InsertCCF.cp"
                            else {
# line 1302 "C430InsertCCF.cp"
                           if (((_sql->retcode != CS_CANCELED) && 
# line 1302 "C430InsertCCF.cp"
                               (_sql->retcode != CS_RET_HAFAILOVER)))
# line 1302 "C430InsertCCF.cp"
                           {
# line 1302 "C430InsertCCF.cp"
                               _sql->retcode = CS_SUCCEED;
# line 1302 "C430InsertCCF.cp"
                           }
# line 1302 "C430InsertCCF.cp"
                           
# line 1302 "C430InsertCCF.cp"
                       }
# line 1302 "C430InsertCCF.cp"
                       
# line 1302 "C430InsertCCF.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 1302 "C430InsertCCF.cp"
                   }
# line 1302 "C430InsertCCF.cp"
                   
# line 1302 "C430InsertCCF.cp"
                   if (sqlca.sqlcode < 0)
# line 1302 "C430InsertCCF.cp"
                   {
# line 1302 "C430InsertCCF.cp"
                       error_handler();
# line 1302 "C430InsertCCF.cp"
                   }
# line 1302 "C430InsertCCF.cp"
                   
# line 1302 "C430InsertCCF.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 1302 "C430InsertCCF.cp"
                   {
# line 1302 "C430InsertCCF.cp"
                       warning_handler();
# line 1302 "C430InsertCCF.cp"
                   }
# line 1302 "C430InsertCCF.cp"
                   
# line 1302 "C430InsertCCF.cp"
               }
# line 1302 "C430InsertCCF.cp"
               
# line 1302 "C430InsertCCF.cp"
           }
# line 1302 "C430InsertCCF.cp"
           

           /*
           ** Generated code ends here.
           */
# line 1302 "C430InsertCCF.cp"
  
                                               
         
           /*
           ** SQL STATEMENT: 26
           ** EXEC SQL EXECUTE creatindnc;

           */
# line 1304 "C430InsertCCF.cp"
# line 1304 "C430InsertCCF.cp"
           {
# line 1304 "C430InsertCCF.cp"
                _SQL_CT_HANDLES * _sql;
# line 1304 "C430InsertCCF.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 1304 "C430InsertCCF.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 1304 "C430InsertCCF.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 1304 "C430InsertCCF.cp"
               {
# line 1304 "C430InsertCCF.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 1304 "C430InsertCCF.cp"
                   _sql->stmttype = SQL_EXECUTE;
# line 1304 "C430InsertCCF.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 1304 "C430InsertCCF.cp"
                   _sql->stmtName.fnlen = 10;
# line 1304 "C430InsertCCF.cp"
                   strcpy(_sql->stmtName.first_name, "creatindnc");
# line 1304 "C430InsertCCF.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 1304 "C430InsertCCF.cp"
                   {
# line 1304 "C430InsertCCF.cp"
                       _sql->retcode = ct_dynamic(_sql->conn.command, 
# line 1304 "C430InsertCCF.cp"
                           CS_EXECUTE, "creatindnc", 10, NULL, CS_UNUSED);
# line 1304 "C430InsertCCF.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 1304 "C430InsertCCF.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 1304 "C430InsertCCF.cp"
                       _sql->retcode = _sqlResults(_sql);
# line 1304 "C430InsertCCF.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 1304 "C430InsertCCF.cp"
                   }
# line 1304 "C430InsertCCF.cp"
                   
# line 1304 "C430InsertCCF.cp"
                   if (sqlca.sqlcode < 0)
# line 1304 "C430InsertCCF.cp"
                   {
# line 1304 "C430InsertCCF.cp"
                       error_handler();
# line 1304 "C430InsertCCF.cp"
                   }
# line 1304 "C430InsertCCF.cp"
                   
# line 1304 "C430InsertCCF.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 1304 "C430InsertCCF.cp"
                   {
# line 1304 "C430InsertCCF.cp"
                       warning_handler();
# line 1304 "C430InsertCCF.cp"
                   }
# line 1304 "C430InsertCCF.cp"
                   
# line 1304 "C430InsertCCF.cp"
               }
# line 1304 "C430InsertCCF.cp"
               
# line 1304 "C430InsertCCF.cp"
           }
# line 1304 "C430InsertCCF.cp"
           

           /*
           ** Generated code ends here.
           */
# line 1304 "C430InsertCCF.cp"


         
           /*
           ** SQL STATEMENT: 27
           ** EXEC SQL DEALLOCATE PREPARE creatindnc;

           */
# line 1306 "C430InsertCCF.cp"
# line 1306 "C430InsertCCF.cp"
           {
# line 1306 "C430InsertCCF.cp"
                _SQL_CT_HANDLES * _sql;
# line 1306 "C430InsertCCF.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 1306 "C430InsertCCF.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 1306 "C430InsertCCF.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 1306 "C430InsertCCF.cp"
               {
# line 1306 "C430InsertCCF.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 1306 "C430InsertCCF.cp"
                   _sql->stmttype = SQL_DEALLOCATE_PREPARE;
# line 1306 "C430InsertCCF.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 1306 "C430InsertCCF.cp"
                   _sql->stmtName.fnlen = 10;
# line 1306 "C430InsertCCF.cp"
                   strcpy(_sql->stmtName.first_name, "creatindnc");
# line 1306 "C430InsertCCF.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 1306 "C430InsertCCF.cp"
                   {
# line 1306 "C430InsertCCF.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 1306 "C430InsertCCF.cp"
                   }
# line 1306 "C430InsertCCF.cp"
                   
# line 1306 "C430InsertCCF.cp"
                   if (sqlca.sqlcode < 0)
# line 1306 "C430InsertCCF.cp"
                   {
# line 1306 "C430InsertCCF.cp"
                       error_handler();
# line 1306 "C430InsertCCF.cp"
                   }
# line 1306 "C430InsertCCF.cp"
                   
# line 1306 "C430InsertCCF.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 1306 "C430InsertCCF.cp"
                   {
# line 1306 "C430InsertCCF.cp"
                       warning_handler();
# line 1306 "C430InsertCCF.cp"
                   }
# line 1306 "C430InsertCCF.cp"
                   
# line 1306 "C430InsertCCF.cp"
               }
# line 1306 "C430InsertCCF.cp"
               
# line 1306 "C430InsertCCF.cp"
           }
# line 1306 "C430InsertCCF.cp"
           

           /*
           ** Generated code ends here.
           */
# line 1306 "C430InsertCCF.cp"

                                      
         
           /*
           ** SQL STATEMENT: 28
           ** EXEC SQL COMMIT WORK;

           */
# line 1308 "C430InsertCCF.cp"
# line 1308 "C430InsertCCF.cp"
           {
# line 1308 "C430InsertCCF.cp"
                _SQL_CT_HANDLES * _sql;
# line 1308 "C430InsertCCF.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 1308 "C430InsertCCF.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 1308 "C430InsertCCF.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 1308 "C430InsertCCF.cp"
               {
# line 1308 "C430InsertCCF.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 1308 "C430InsertCCF.cp"
                   _sql->stmttype = SQL_TRANS;
# line 1308 "C430InsertCCF.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 1308 "C430InsertCCF.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 1308 "C430InsertCCF.cp"
                   {
# line 1308 "C430InsertCCF.cp"
                       _sql->retcode = ct_command(_sql->conn.command, 
# line 1308 "C430InsertCCF.cp"
                           CS_LANG_CMD, "COMMIT WORK", 11, CS_UNUSED);
# line 1308 "C430InsertCCF.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 1308 "C430InsertCCF.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 1308 "C430InsertCCF.cp"
                       _sql->retcode = _sqlResults(_sql);
# line 1308 "C430InsertCCF.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 1308 "C430InsertCCF.cp"
                   }
# line 1308 "C430InsertCCF.cp"
                   
# line 1308 "C430InsertCCF.cp"
                   if (sqlca.sqlcode < 0)
# line 1308 "C430InsertCCF.cp"
                   {
# line 1308 "C430InsertCCF.cp"
                       error_handler();
# line 1308 "C430InsertCCF.cp"
                   }
# line 1308 "C430InsertCCF.cp"
                   
# line 1308 "C430InsertCCF.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 1308 "C430InsertCCF.cp"
                   {
# line 1308 "C430InsertCCF.cp"
                       warning_handler();
# line 1308 "C430InsertCCF.cp"
                   }
# line 1308 "C430InsertCCF.cp"
                   
# line 1308 "C430InsertCCF.cp"
               }
# line 1308 "C430InsertCCF.cp"
               
# line 1308 "C430InsertCCF.cp"
           }
# line 1308 "C430InsertCCF.cp"
           

           /*
           ** Generated code ends here.
           */
# line 1308 "C430InsertCCF.cp"


      }

      /* Extraer del archivo los campos correspondientes dependiendo
         del Tipo de Registro previamente establecido y construir
         el comando de insercion asociado. */

      if(strcmp(sRecordType, FMTREC0000) == 0)
      {
         strcpy(sRecordIndicator, sRecordType);

	 strncpy(sTypeIndicator, &(sRecord[POS5_0000 - 1]), LEN3);
         sTypeIndicator[LEN3] = EOLN;
	 
	 strncpy(sCompanyName, &(sRecord[POS8_0000 - 1]), LEN100);
         sCompanyName[LEN100] = EOLN;
         
	 strncpy(sCompanyID, &(sRecord[POS108_0000 - 1]), LEN6);
         sCompanyID[LEN6] = EOLN;
         
	 strncpy(sSubCompanyID, &(sRecord[POS114_0000 - 1]), LEN3);
         sSubCompanyID[LEN3] = EOLN;
         
	 strncpy(sEffectiveFileDate, &(sRecord[POS117_0000 - 1]), LEN8);
         sEffectiveFileDate[LEN8] = EOLN;
         
	 strncpy(sCCFVersion, &(sRecord[POS125_0000 - 1]), LEN5);
         sCCFVersion[LEN5] = EOLN;
         
         strncpy(sCompNameKanjiShiftOUT, &(sRecord[POS130_0000 - 1]), LEN1);
	 sCompNameKanjiShiftOUT[LEN1] = EOLN;

	 strncpy(sCompNameKanji, &(sRecord[POS131_0000 - 1]), LEN60);		
	 sCompNameKanji[LEN60] = EOLN;

	 strncpy(sCompNameKanjiShiftIN, &(sRecord[POS191_0000 - 1]), LEN1);
	 sCompNameKanjiShiftIN[LEN1] = EOLN;

	 strncpy(sFiller0000, &(sRecord[POS192_0000 - 1]), LEN759);
         sFiller0000[LEN759] = EOLN;
         
	 strncpy(sTRXControlData, &(sRecord[POS951_0000 - 1]), LEN50);
         sTRXControlData[LEN50] = EOLN;

         strcpy(sSQLCommand, "INSERT ");
         strcat(sSQLCommand, sTableName);
         strcat(sSQLCommand, " VALUES (\'");      
         strcat(sSQLCommand, sRecordIndicator);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTypeIndicator);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCompanyName);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCompanyID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sSubCompanyID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sEffectiveFileDate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCCFVersion);
         strcat(sSQLCommand, "\', \'");
	 strcat(sSQLCommand, sCompNameKanjiShiftOUT);
         strcat(sSQLCommand, "\', \'");
	 strcat(sSQLCommand, sCompNameKanji);
         strcat(sSQLCommand, "\', \'");
	 strcat(sSQLCommand, sCompNameKanjiShiftIN);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFiller0000);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTRXControlData);
         strcat(sSQLCommand, "\')"); 
      }

      if(strcmp(sRecordType, FMTREC1000) == 0)
      {
         strcpy(sRecordIndicator, sRecordType);
         
	 strncpy(sTypeIndicator, &(sRecord[POS5_1000 - 1]), LEN3);
         sTypeIndicator[LEN3] = EOLN;
         
	 strncpy(sCompanyID, &(sRecord[POS8_1000 - 1]), LEN6);
         sCompanyID[LEN6] = EOLN;
         
	 strncpy(sSubCompanyID, &(sRecord[POS14_1000 - 1]), LEN3);
         sSubCompanyID[LEN3] = EOLN;
         
	 strncpy(sCorpParentNode, &(sRecord[POS17_1000 - 1]), LEN50);
         sCorpParentNode[LEN50] = EOLN;
         
	 strncpy(sCorpChildNode, &(sRecord[POS67_1000 - 1]), LEN50);
         sCorpChildNode[LEN50] = EOLN;
         
	 strncpy(sDepth, &(sRecord[POS117_1000 - 1]), LEN10);
         sDepth[LEN10] = EOLN;
         
	 strncpy(sLevelName, &(sRecord[POS127_1000 - 1]), LEN50);
         sLevelName[LEN50] = EOLN;
         
	 strncpy(sHierarchyType, &(sRecord[POS177_1000 - 1]), LEN10);
         sHierarchyType[LEN10] = EOLN;
         
	 strncpy(sAcctCodeID, &(sRecord[POS187_1000 - 1]), LEN10);
         sAcctCodeID[LEN10] = EOLN;
         
	 strncpy(sCurrSicTemplate, &(sRecord[POS197_1000 - 1]), LEN15);
         sCurrSicTemplate[LEN15] = EOLN;
         
	 strncpy(sFutureSicTemplate, &(sRecord[POS212_1000 - 1]), LEN15);
         sFutureSicTemplate[LEN15] = EOLN;
         
	 strncpy(sReportTemplate, &(sRecord[POS227_1000 - 1]), LEN15);
         sReportTemplate[LEN15] = EOLN;
         
	 strncpy(sTextsetTemplate, &(sRecord[POS242_1000 - 1]), LEN15);
         sTextsetTemplate[LEN15] = EOLN;
         
	 strncpy(sExceptionTemplate, &(sRecord[POS257_1000 - 1]), LEN15);
         sExceptionTemplate[LEN15] = EOLN;
         
	 strncpy(sFiller1100, &(sRecord[POS272_1000 - 1]), LEN679);
         sFiller1100[LEN679] = EOLN;
         
	 strncpy(sTRXControlData, &(sRecord[POS951_1000 - 1]), LEN50);
         sTRXControlData[LEN50] = EOLN;
 
         strcpy(sSQLCommand, "INSERT ");
         strcat(sSQLCommand, sTableName);
         strcat(sSQLCommand, " VALUES (\'");      
         strcat(sSQLCommand, sRecordIndicator);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTypeIndicator);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCompanyID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sSubCompanyID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCorpParentNode);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCorpChildNode);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sDepth);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sLevelName);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sHierarchyType);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAcctCodeID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCurrSicTemplate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFutureSicTemplate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sReportTemplate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTextsetTemplate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sExceptionTemplate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFiller1100);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTRXControlData);
         strcat(sSQLCommand, "\')"); 
      }

      if(strcmp(sRecordType, FMTREC1001) == 0)
      {
         strcpy(sRecordIndicator, sRecordType);
         
	 strncpy(sTypeIndicator, &(sRecord[POS5_1001 - 1]), LEN3);
         sTypeIndicator[LEN3] = EOLN;
         
	 strncpy(sCompanyID, &(sRecord[POS8_1001 - 1]), LEN6);
         sCompanyID[LEN6] = EOLN;
         
	 strncpy(sSubCompanyID, &(sRecord[POS14_1001 - 1]), LEN3);
         sSubCompanyID[LEN3] = EOLN;
         
	 strncpy(sNodeID, &(sRecord[POS17_1001 - 1]), LEN50);
         sNodeID[LEN50] = EOLN;
         
	 strncpy(sAccountNumber1001, &(sRecord[POS67_1001 - 1]), LEN50);
         sAccountNumber1001[LEN50] = EOLN;
         
	 strncpy(sFiller1001, &(sRecord[POS117_1001 - 1]), LEN834);
         sFiller1001[LEN834] = EOLN;
         
	 strncpy(sTRXControlData, &(sRecord[POS951_1001 - 1]), LEN50);
         sTRXControlData[LEN50] = EOLN;

         strcpy(sSQLCommand, "INSERT ");
         strcat(sSQLCommand, sTableName);
         strcat(sSQLCommand, " VALUES (\'");      
         strcat(sSQLCommand, sRecordIndicator);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTypeIndicator);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCompanyID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sSubCompanyID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sNodeID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAccountNumber1001);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFiller1001);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTRXControlData);
         strcat(sSQLCommand, "\')"); 
      }

      if(strcmp(sRecordType, FMTREC2000) == 0)
      {
         strcpy(sRecordIndicator, sRecordType);

         strncpy(sTypeIndicator, &(sRecord[POS5_2000 - 1]), LEN3);
         sTypeIndicator[LEN3] = EOLN;
         
	 strncpy(sCompanyID, &(sRecord[POS8_2000 - 1]), LEN6);
         sCompanyID[LEN6] = EOLN;
         
	 strncpy(sSubCompanyID, &(sRecord[POS14_2000 - 1]), LEN3);
         sSubCompanyID[LEN3] = EOLN;
         
	 strncpy(sProcessor, &(sRecord[POS17_2000 - 1]), LEN3);
         sProcessor[LEN3] = EOLN;
         
	 strncpy(sAccountNumber, &(sRecord[POS20_2000 - 1]), LEN25);
         sAccountNumber[LEN25] = EOLN;
         
	 strncpy(sAccountType, &(sRecord[POS45_2000 - 1]), LEN1);
         sAccountType[LEN1] = EOLN;
         
	 strncpy(sLastName, &(sRecord[POS46_2000 - 1]), LEN25);
         sLastName[LEN25] = EOLN;
         
	 strncpy(sCardhFirstName, &(sRecord[POS71_2000 - 1]), LEN25);
         sCardhFirstName[LEN25] = EOLN;
         
	 strncpy(sCardhMiddleName, &(sRecord[POS96_2000 - 1]), LEN20);
         sCardhMiddleName[LEN20] = EOLN;

	 strncpy(sAddrLine1kanjiShiftOUT, &(sRecord[POS116_2000 - 1]), LEN1);		
	 sAddrLine1kanjiShiftOUT[LEN1] = EOLN;

         strncpy(sAddrLine1, &(sRecord[POS117_2000 - 1]), LEN40);
         sAddrLine1[LEN40] = EOLN;

	 strncpy(sAddrLine1kanjiShiftIN, &(sRecord[POS157_2000 -1]), LEN1);			
	 sAddrLine1kanjiShiftIN[LEN1] = EOLN;

	 strncpy(sAddrLine2kanjiShiftOUT, &(sRecord[POS158_2000-1]), LEN1);		
	 sAddrLine2kanjiShiftOUT[LEN1] = EOLN;

	 strncpy(sAddrLine2, &(sRecord[POS159_2000 - 1]), LEN40);
         sAddrLine2[LEN40] = EOLN;
   
	 strncpy(sAddrLine2kanjiShiftIN, &(sRecord[POS199_2000 -1]), LEN1);			
	 sAddrLine2kanjiShiftIN[LEN1] = EOLN;

	 strncpy(sAddrLine3kanjiShiftOUT, &(sRecord[POS200_2000 -1]), LEN1);		
	 sAddrLine3kanjiShiftOUT[LEN1] = EOLN;
	 
	 strncpy(sAddrLine3, &(sRecord[POS201_2000 - 1]), LEN40);
         sAddrLine3[LEN40] = EOLN;

	 strncpy(sAddrLine3kanjiShiftIN, &(sRecord[POS241_2000 - 1]),  LEN1);
	 sAddrLine3kanjiShiftIN[LEN1] = EOLN;

	 strncpy(sAddrLine4SO, &(sRecord[POS242_2000 - 1]), LEN1);
	 sAddrLine4SO[LEN1] = EOLN;

         strncpy(sAddrLine4, &(sRecord[POS243_2000 - 1]), LEN40);
         sAddrLine4[LEN40] = EOLN;

         strncpy(sAddrLine4SI, &(sRecord[POS283_2000  - 1]), LEN1);				
	 sAddrLine4SI[LEN1] = EOLN;

	 strncpy(sAddressLine5, &(sRecord[POS284_2000 - 1]), LEN40);
         sAddressLine5[LEN40] = EOLN;

         strncpy(sCity, &(sRecord[POS324_2000 - 1]), LEN25);
         sCity[LEN25] = EOLN;

         strncpy(sStateCountyProvince, &(sRecord[POS349_2000  - 1]), LEN25);
         sStateCountyProvince[LEN25] = EOLN;

         strncpy(sPostalCode, &(sRecord[POS374_2000 - 1]), LEN10);
         sPostalCode[LEN10] = EOLN;

         strncpy(sCountry, &(sRecord[POS384_2000 - 1]), LEN20);
         sCountry[LEN20] = EOLN;

         strncpy(sNationalID, &(sRecord[POS404_2000 - 1]), LEN30);
         sNationalID[LEN30] = EOLN;

         strncpy(sTelephoneNumber, &(sRecord[POS434_2000 - 1]), LEN18);
         sTelephoneNumber[LEN18] = EOLN;

         strncpy(sWorkPhoneNum, &(sRecord[POS452_2000 - 1]), LEN18);
         sWorkPhoneNum[LEN18] = EOLN;

         strncpy(sIDVerificationCode, &(sRecord[POS470_2000 - 1]), LEN15);
         sIDVerificationCode[LEN15] = EOLN;

         strncpy(sDateOfBirth, &(sRecord[POS485_2000 - 1]), LEN8);
         sDateOfBirth[LEN8] = EOLN;

         strncpy(sCycleCode, &(sRecord[POS493_2000 - 1]), LEN2);
         sCycleCode[LEN2] = EOLN;

         strncpy(sFaxNumber, &(sRecord[POS495_2000 - 1]), LEN18);
         sFaxNumber[LEN18] = EOLN;

         strncpy(sEMailAddress, &(sRecord[POS513_2000 - 1]), LEN60);
         sEMailAddress[LEN60] = EOLN;

         strncpy(sEmployeeID, &(sRecord[POS573_2000 - 1]), LEN20);
         sEmployeeID[LEN20] = EOLN;

         strncpy(sClientIDCustomerNumber, &(sRecord[POS593_2000 - 1]), LEN20);
         sClientIDCustomerNumber[LEN20] = EOLN;

         strncpy(sCustomerVATNumber, &(sRecord[POS613_2000 - 1]), LEN20);
         sCustomerVATNumber[LEN20] = EOLN;


         strncpy(sKanjiNameKanjiShiftOUT, &(sRecord[POS633_2000 - 1]), LEN1);
	 sKanjiNameKanjiShiftOUT[LEN1] = EOLN;
   
         strncpy(sKanjiNameKanji, &(sRecord[POS634_2000 - 1]), LEN50);			
	 sKanjiNameKanji[LEN50] = EOLN;

         strncpy(sKanjiNameKanjiShiftIN, &(sRecord[POS684_2000 - 1]), LEN1);			
	 sKanjiNameKanjiShiftIN[LEN1] = EOLN;

         strncpy(sAddrLine4kanjiShiftOUT, &(sRecord[POS685_2000 - 1]), LEN1);		
	 sAddrLine4kanjiShiftOUT[LEN1] = EOLN;

         strncpy(sAddrLine4kanji, &(sRecord[POS686_2000 - 1]), LEN60);			
	 sAddrLine4kanji[LEN60] = EOLN;

         strncpy(sAddrLine4kanjiShiftIN, &(sRecord[POS746_2000 - 1]), LEN1);		
	 sAddrLine4kanjiShiftIN[LEN1] = EOLN;

         strncpy(sFiller2000, &(sRecord[POS747_2000 - 1]), LEN204);
         sFiller2000[LEN204] = EOLN;

         strncpy(sTRXControlData, &(sRecord[POS951_2000 - 1]), LEN50);
         sTRXControlData[LEN50] = EOLN;

         strcpy(sSQLCommand, "INSERT ");
         strcat(sSQLCommand, sTableName);
         strcat(sSQLCommand, " VALUES (\'");      
         strcat(sSQLCommand, sRecordIndicator);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTypeIndicator);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCompanyID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sSubCompanyID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sProcessor);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAccountNumber);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAccountType);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sLastName);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCardhFirstName);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCardhMiddleName);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAddrLine1kanjiShiftOUT);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAddrLine1);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAddrLine1kanjiShiftIN);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAddrLine2kanjiShiftOUT);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAddrLine2);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAddrLine2kanjiShiftIN);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAddrLine3kanjiShiftOUT);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAddrLine3);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAddrLine3kanjiShiftIN);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAddrLine4SO);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAddrLine4);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAddrLine4SI);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAddressLine5);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCity);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sStateCountyProvince);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sPostalCode);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCountry);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sNationalID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTelephoneNumber);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sWorkPhoneNum);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sIDVerificationCode);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sDateOfBirth);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCycleCode);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFaxNumber);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sEMailAddress);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sEmployeeID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sClientIDCustomerNumber);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCustomerVATNumber);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sKanjiNameKanjiShiftOUT);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sKanjiNameKanji);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sKanjiNameKanjiShiftIN);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAddrLine4kanjiShiftOUT);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAddrLine4kanji);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAddrLine4kanjiShiftIN);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFiller2000);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTRXControlData);
         strcat(sSQLCommand, "\')"); 
      }

      if(strcmp(sRecordType, FMTREC2001) == 0)
      {
         strcpy(sRecordIndicator, sRecordType);

         strncpy(sTypeIndicator, &(sRecord[POS5_2001 - 1]), LEN3);
         sTypeIndicator[LEN3] = EOLN;

         strncpy(sCompanyID, &(sRecord[POS8_2001 - 1]), LEN6);
         sCompanyID[LEN6] = EOLN;

         strncpy(sSubCompanyID, &(sRecord[POS14_2001 - 1]), LEN3);
         sSubCompanyID[LEN3] = EOLN;

         strncpy(sProcessor, &(sRecord[POS17_2001  - 1]), LEN3);
         sProcessor[LEN3] = EOLN;

         strncpy(sAccountNumber, &(sRecord[POS20_2001 - 1]), LEN25);
         sAccountNumber[LEN25] = EOLN;

         strncpy(sControlBillingVirtual, &(sRecord[POS45_2001 - 1]), LEN25);
         sControlBillingVirtual[LEN25] = EOLN;

         strncpy(sMasterAcctCode, &(sRecord[POS70_2001 - 1]), LEN150);
         sMasterAcctCode[LEN150] = EOLN;

         strncpy(sCityPairCode, &(sRecord[POS220_2001 - 1]), LEN1);
         sCityPairCode[LEN1] = EOLN;

         strncpy(sTaxExemptNumber, &(sRecord[POS221_2001 - 1]), LEN20);
         sTaxExemptNumber[LEN20] = EOLN;

         strncpy(sTaxExemptFlag, &(sRecord[POS241_2001 - 1]), LEN1);
         sTaxExemptFlag[LEN1] = EOLN;

         strncpy(sTaxExemptStatus, &(sRecord[POS242_2001 - 1]), LEN3);
         sTaxExemptStatus[LEN3] = EOLN;

         strncpy(sNumCards, &(sRecord[POS245_2001 - 1]), LEN2);
         sNumCards[LEN2] = EOLN;

         strncpy(sOpenDate, &(sRecord[POS247_2001 - 1]), LEN8);
         sOpenDate[LEN8] = EOLN;

         strncpy(sCreditRating, &(sRecord[POS255_2001 - 1]), LEN2);
         sCreditRating[LEN2] = EOLN;

         strncpy(sCreditLimit, &(sRecord[POS257_2001 - 1]), LEN18);
         sCreditLimit[LEN18] = EOLN;

         strncpy(sSingleTranLmt, &(sRecord[POS275_2001 - 1]), LEN18);
         sSingleTranLmt[LEN18] = EOLN;

         strncpy(sPrimEmbossName, &(sRecord[POS293_2001 - 1]), LEN30);
         sPrimEmbossName[LEN30] = EOLN;

         strncpy(sEmbossLegend, &(sRecord[POS323_2001 - 1]), LEN26);
         sEmbossLegend[LEN26] = EOLN;

         strncpy(sCardActivationDate, &(sRecord[POS349_2001 - 1]), LEN8);
         sCardActivationDate[LEN8] = EOLN;

         strncpy(sLastPayDate, &(sRecord[POS357_2001 - 1]), LEN8);
         sLastPayDate[LEN8] = EOLN;

         strncpy(sBillingCurrency, &(sRecord[POS365_2001 - 1]), LEN3);
         sBillingCurrency[LEN3] = EOLN;

         strncpy(sCurrentBalance, &(sRecord[POS368_2001 - 1]), LEN18);
         sCurrentBalance[LEN18] = EOLN;

         strncpy(sPaymentAmtDue, &(sRecord[POS386_2001 - 1]), LEN18);
         sPaymentAmtDue[LEN18] = EOLN;

         strncpy(sPaymentDueDate, &(sRecord[POS404_2001 - 1]), LEN8);
         sPaymentDueDate[LEN8] = EOLN;

         strncpy(sTransitRoutingNo, &(sRecord[POS412_2001 - 1]), LEN9);
         sTransitRoutingNo[LEN9] = EOLN;

         strncpy(sDDANumber, &(sRecord[POS421_2001 - 1]), LEN25);
         sDDANumber[LEN25] = EOLN;

         strncpy(sAuthStatus, &(sRecord[POS446_2001 - 1]), LEN4);
         sAuthStatus[LEN4] = EOLN;

         strncpy(sNewCardInd, &(sRecord[POS450_2001 - 1]), LEN1);
         sNewCardInd[LEN1] = EOLN;

         strncpy(sNewCardSerNo, &(sRecord[POS451_2001 - 1]), LEN20);
         sNewCardSerNo[LEN20] = EOLN;

         strncpy(sLastMaintenanceDate, &(sRecord[POS471_2001 - 1]), LEN8);
         sLastMaintenanceDate[LEN8] = EOLN;

         strncpy(sPinRequestFlag, &(sRecord[POS479_2001 - 1]), LEN1);
         sPinRequestFlag[LEN1] = EOLN;

         strncpy(sBillType, &(sRecord[POS480_2001 - 1]), LEN1);
         sBillType[LEN1] = EOLN;

         strncpy(sTransferAccount, &(sRecord[POS481_2001 - 1]), LEN25);
         sTransferAccount[LEN25] = EOLN;

         strncpy(sTransferStatus, &(sRecord[POS506_2001 - 1]), LEN1);
         sTransferStatus[LEN1] = EOLN;

         strncpy(sTransferReason, &(sRecord[POS507_2001 - 1]), LEN1);
         sTransferReason[LEN1] = EOLN;

         strncpy(sTransferDate, &(sRecord[POS508_2001 - 1]), LEN8);
         sTransferDate[LEN8] = EOLN;

         strncpy(sChargeOffStatus, &(sRecord[POS516_2001 - 1]), LEN1);
         sChargeOffStatus[LEN1] = EOLN;

         strncpy(sChargeOffDate, &(sRecord[POS517_2001 - 1]), LEN8);
         sChargeOffDate[LEN8] = EOLN;

         strncpy(sChargeOffBalance, &(sRecord[POS525_2001 - 1]), LEN18);
         sChargeOffBalance[LEN18] = EOLN;

         strncpy(sChargeOffReason, &(sRecord[POS543_2001 - 1]), LEN1);
         sChargeOffReason[LEN1] = EOLN;

         strncpy(sOtherAcctNbr, &(sRecord[POS544_2001 - 1]), LEN25);
         sOtherAcctNbr[LEN25] = EOLN;

         strncpy(sCRVStatus, &(sRecord[POS569_2001 - 1]), LEN1);
         sCRVStatus[LEN1] = EOLN;

         strncpy(sCashAdvanceLimit, &(sRecord[POS570_2001 - 1]), LEN18);
         sCashAdvanceLimit[LEN18] = EOLN;

         strncpy(sCashAdvLimitFreq, &(sRecord[POS588_2001 - 1]), LEN3);
         sCashAdvLimitFreq[LEN3] = EOLN;


         strncpy(sEcsAccountStatus, &(sRecord[POS591_2001 - 1]), LEN1);	
	 sEcsAccountStatus[LEN1] = EOLN;

         strncpy(sEcsBlockCode, &(sRecord[POS592_2001 - 1]), LEN1);
	 sEcsBlockCode[LEN1] = EOLN;

         strncpy(sEcsBlockReason, &(sRecord[POS593_2001 - 1]), LEN2);
	 sEcsBlockReason[LEN2] = EOLN;

	 strncpy(sPreviewBalance, &(sRecord[POS595_2001 - 1]), LEN18);
         sPreviewBalance[LEN18] = EOLN;

	 strncpy(sNumberOfCyclesPastDue, &(sRecord[POS613_2001 - 1]), LEN2);			
	 sNumberOfCyclesPastDue[LEN2] = EOLN;

         strncpy(sFiller2001, &(sRecord[POS615_2001 - 1]), LEN336);
         sFiller2001[LEN336] = EOLN;

         strncpy(sTRXControlData, &(sRecord[POS951_2001 - 1]), LEN50);
         sTRXControlData[LEN50] = EOLN;

         strcpy(sSQLCommand, "INSERT ");
         strcat(sSQLCommand, sTableName);
         strcat(sSQLCommand, " VALUES (\'");      
         strcat(sSQLCommand, sRecordIndicator);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTypeIndicator);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCompanyID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sSubCompanyID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sProcessor);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAccountNumber);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sControlBillingVirtual);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sMasterAcctCode);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCityPairCode);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTaxExemptNumber);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTaxExemptFlag);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTaxExemptStatus);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sNumCards);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sOpenDate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCreditRating);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCreditLimit);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sSingleTranLmt);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sPrimEmbossName);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sEmbossLegend);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCardActivationDate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sLastPayDate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sBillingCurrency);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCurrentBalance);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sPaymentAmtDue);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sPaymentDueDate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTransitRoutingNo);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sDDANumber);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAuthStatus);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sNewCardInd);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sNewCardSerNo);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sLastMaintenanceDate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sPinRequestFlag);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sBillType);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTransferAccount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTransferStatus);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTransferReason);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTransferDate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sChargeOffStatus);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sChargeOffDate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sChargeOffBalance);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sChargeOffReason);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sOtherAcctNbr);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCRVStatus);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCashAdvanceLimit);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCashAdvLimitFreq);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sEcsAccountStatus);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sEcsBlockCode);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sEcsBlockReason);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sPreviewBalance);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sNumberOfCyclesPastDue);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFiller2001);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTRXControlData);
         strcat(sSQLCommand, "\')"); 
      }

      if(strcmp(sRecordType, FMTREC5000) == 0)
      {
         strcpy(sRecordIndicator, sRecordType);

         strncpy(sTypeIndicator, &(sRecord[POS5_5000 - 1]), LEN3);
         sTypeIndicator[LEN3] = EOLN;

         strncpy(sCompanyID, &(sRecord[POS8_5000 - 1]), LEN6);
         sCompanyID[LEN6] = EOLN;

         strncpy(sSubCompanyID, &(sRecord[POS14_5000 - 1]), LEN3);
         sSubCompanyID[LEN3] = EOLN;
         
	 strncpy(sCBSTRRunDate, &(sRecord[POS17_5000 - 1]), LEN8);
         sCBSTRRunDate[LEN8] = EOLN;
         
	 strncpy(sAccountNumber, &(sRecord[POS25_5000 - 1]), LEN25);
         sAccountNumber[LEN25] = EOLN;
         
	 strncpy(sTransDate, &(sRecord[POS50_5000 - 1]), LEN8);
         sTransDate[LEN8] = EOLN;
         
	 strncpy(sTransTime, &(sRecord[POS58_5000 - 1]), LEN8);
         sTransTime[LEN8] = EOLN;
         
	 strncpy(sPostDate, &(sRecord[POS66_5000 - 1]), LEN8);
         sPostDate[LEN8] = EOLN;
         
	 strncpy(sTransAmount, &(sRecord[POS74_5000 - 1]), LEN18);
         sTransAmount[LEN18] = EOLN;
         
	 strncpy(sAuthRequired, &(sRecord[POS92_5000 - 1]), LEN1);
         sAuthRequired[LEN1] = EOLN;
         
	 strncpy(sAuthID, &(sRecord[POS93_5000 - 1]), LEN6);
         sAuthID[LEN6] = EOLN;
         
	 strncpy(sConversDate, &(sRecord[POS99_5000 - 1]), LEN8);
         sConversDate[LEN8] = EOLN;
         
	 strncpy(sPosEntry, &(sRecord[POS107_5000 - 1]), LEN12);
         sPosEntry[LEN12] = EOLN;
         
	 strncpy(sPosCondCode, &(sRecord[POS119_5000 - 1]), LEN2);
         sPosCondCode[LEN2] = EOLN;
         
	 strncpy(sAcquirerID, &(sRecord[POS121_5000 - 1]), LEN15);
         sAcquirerID[LEN15] = EOLN;
         
	 strncpy(sReferenceNum, &(sRecord[POS136_5000 - 1]), LEN23);
         sReferenceNum[LEN23] = EOLN;
         
	 strncpy(sTraceNumber, &(sRecord[POS159_5000 - 1]), LEN6);
         sTraceNumber[LEN6] = EOLN;
         
	 strncpy(sTransCurrencyCd, &(sRecord[POS165_5000 - 1]), LEN3);
         sTransCurrencyCd[LEN3] = EOLN;
         
	 strncpy(sTransID, &(sRecord[POS168_5000 - 1]), LEN15);
         sTransID[LEN15] = EOLN;
         
	 strncpy(sMCC, &(sRecord[POS183_5000 - 1]), LEN4);
         sMCC[LEN4] = EOLN;
         
	 strncpy(sMCCInfoData, &(sRecord[POS187_5000 - 1]), LEN19);
         sMCCInfoData[LEN19] = EOLN;
         
	 strncpy(sMerchAcceptorID, &(sRecord[POS206_5000 - 1]), LEN16);
         sMerchAcceptorID[LEN16] = EOLN;
         
	 strncpy(sMerchDescription, &(sRecord[POS222_5000 - 1]), LEN40);
         sMerchDescription[LEN40] = EOLN;
         
	 strncpy(sMerchantCity, &(sRecord[POS262_5000 - 1]), LEN15);
         sMerchantCity[LEN15] = EOLN;
         
	 strncpy(sMerchantStateProvince, &(sRecord[POS277_5000 - 1]), LEN5);
         sMerchantStateProvince[LEN5] = EOLN;
         
	 strncpy(sMerchantPostalCode, &(sRecord[POS282_5000 - 1]), LEN10);
         sMerchantPostalCode[LEN10] = EOLN;
         
	 strncpy(sMerchCountry, &(sRecord[POS292_5000 - 1]), LEN3);
         sMerchCountry[LEN3] = EOLN;
         
	 strncpy(sMerchantVATNumber, &(sRecord[POS295_5000 - 1]), LEN20);
         sMerchantVATNumber[LEN20] = EOLN;
         
	 strncpy(sMerchDescFlag, &(sRecord[POS315_5000 - 1]), LEN1);
         sMerchDescFlag[LEN1] = EOLN;
         
	 strncpy(sMerchantReferenceNumber, &(sRecord[POS316_5000 - 1]), LEN25);
         sMerchantReferenceNumber[LEN25] = EOLN;
         
	 strncpy(sSourceCurrency, &(sRecord[POS341_5000 - 1]), LEN3);
         sSourceCurrency[LEN3] = EOLN;
         
	 strncpy(sSourceAmount, &(sRecord[POS344_5000 - 1]), LEN18);
         sSourceAmount[LEN18] = EOLN;
         
	 strncpy(sBillingCurrency, &(sRecord[POS362_5000 - 1]), LEN3);
         sBillingCurrency[LEN3] = EOLN;
         
	 strncpy(sBillingAmount, &(sRecord[POS365_5000 - 1]), LEN18);
         sBillingAmount[LEN18] = EOLN;
         
	 strncpy(sSettlemCurrency, &(sRecord[POS383_5000 - 1]), LEN3);
         sSettlemCurrency[LEN3] = EOLN;
         
	 strncpy(sSettlemAmount, &(sRecord[POS386_5000 - 1]), LEN18);
         sSettlemAmount[LEN18] = EOLN;
         
	 strncpy(sUSDollarCurr, &(sRecord[POS404_5000 - 1]), LEN3);
         sUSDollarCurr[LEN3] = EOLN;
         
	 strncpy(sUSDollarAmt, &(sRecord[POS407_5000 - 1]), LEN18);
         sUSDollarAmt[LEN18] = EOLN;
         
	 strncpy(sGBPoundCurr, &(sRecord[POS425_5000 - 1]), LEN3);
         sGBPoundCurr[LEN3] = EOLN;
         
	 strncpy(sGBPoundAmt, &(sRecord[POS428_5000 - 1]), LEN18);
         sGBPoundAmt[LEN18] = EOLN;
         
	 strncpy(sEuroCurrency, &(sRecord[POS446_5000 - 1]), LEN3);
         sEuroCurrency[LEN3] = EOLN;
         
	 strncpy(sEuroAmount, &(sRecord[POS449_5000 - 1]), LEN18);
         sEuroAmount[LEN18] = EOLN;
         
	 strncpy(sAsiaYenCurr, &(sRecord[POS467_5000 - 1]), LEN3);
         sAsiaYenCurr[LEN3] = EOLN;
         
	 strncpy(sAsiaYenAmt, &(sRecord[POS470_5000 - 1]), LEN18);
         sAsiaYenAmt[LEN18] = EOLN;
         
	 strncpy(sSwedKronCurr, &(sRecord[POS488_5000 - 1]), LEN3);
         sSwedKronCurr[LEN3] = EOLN;
         
	 strncpy(sSwedKronAmt, &(sRecord[POS491_5000 - 1]), LEN18);
         sSwedKronAmt[LEN18] = EOLN;
         
	 strncpy(sCanadianCurr, &(sRecord[POS509_5000 - 1]), LEN3);
         sCanadianCurr[LEN3] = EOLN;
         
	 strncpy(sCanadianAmt, &(sRecord[POS512_5000 - 1]), LEN18);
         sCanadianAmt[LEN18] = EOLN;
         
	 strncpy(sConversionRate, &(sRecord[POS530_5000 - 1]), LEN14);
         sConversionRate[LEN14] = EOLN;
         
	 strncpy(sDBCRFlag, &(sRecord[POS544_5000 - 1]), LEN1);
         sDBCRFlag[LEN1] = EOLN;
         
	 strncpy(sMemoFlag, &(sRecord[POS545_5000 - 1]), LEN1);
         sMemoFlag[LEN1] = EOLN;
         
	 strncpy(sCorpAcctNo, &(sRecord[POS546_5000 - 1]), LEN25);
         sCorpAcctNo[LEN25] = EOLN;
         
	 strncpy(sSalesTax, &(sRecord[POS571_5000 - 1]), LEN18);
         sSalesTax[LEN18] = EOLN;
         
	 strncpy(sSalesTaxFlag, &(sRecord[POS589_5000 - 1]), LEN1);
         sSalesTaxFlag[LEN1] = EOLN;
         
	 strncpy(sVATTax, &(sRecord[POS590_5000 - 1]), LEN18);
         sVATTax[LEN18] = EOLN;
         
	 strncpy(sVATTaxFlag, &(sRecord[POS608_5000 - 1]), LEN1);
         sVATTaxFlag[LEN1] = EOLN;
         
	 strncpy(sPurchaseID, &(sRecord[POS609_5000 - 1]), LEN25);
         sPurchaseID[LEN25] = EOLN;
         
	 strncpy(sPurchIDFlag, &(sRecord[POS634_5000 - 1]), LEN1);
         sPurchIDFlag[LEN1] = EOLN;
         
	 strncpy(sTranType, &(sRecord[POS635_5000 - 1]), LEN1);
         sTranType[LEN1] = EOLN;
         
	 strncpy(sNoOfAddendums, &(sRecord[POS636_5000 - 1]), LEN4);
         sNoOfAddendums[LEN4] = EOLN;
         
	 strncpy(sVisaTranCode, &(sRecord[POS640_5000 - 1]), LEN4);
         sVisaTranCode[LEN4] = EOLN;
         
	 strncpy(sAddendumKey, &(sRecord[POS644_5000 - 1]), LEN50);
         sAddendumKey[LEN50] = EOLN;
         
	 strncpy(sTicketNumber, &(sRecord[POS694_5000 - 1]), LEN15);
         sTicketNumber[LEN15] = EOLN;
         
	 strncpy(sMsgType, &(sRecord[POS709_5000 - 1]), LEN4);
         sMsgType[LEN4] = EOLN;
         
	 strncpy(sFiller1_5000, &(sRecord[POS713_5000 - 1]), LEN1);
         sFiller1_5000[LEN1] = EOLN;
         
	 strncpy(sVATEvidenceFlag, &(sRecord[POS714_5000 - 1]), LEN1);
         sVATEvidenceFlag[LEN1] = EOLN;
         
	 strncpy(sCustRefNumber, &(sRecord[POS715_5000 - 1]), LEN17);
         sCustRefNumber[LEN17] = EOLN;
         
	 strncpy(sDiscAmount, &(sRecord[POS732_5000 - 1]), LEN18);
         sDiscAmount[LEN18] = EOLN;
         
	 strncpy(sBillingDate, &(sRecord[POS750_5000 - 1]), LEN8);	
	 sBillingDate[LEN8] = EOLN;

         strncpy(sFiller2_5000, &(sRecord[POS758_5000 - 1]), LEN193);
         sFiller2_5000[LEN193] = EOLN;
         
	 strncpy(sTRXControlData, &(sRecord[POS951_5000 - 1]), LEN50);
         sTRXControlData[LEN50] = EOLN;

         strcpy(sSQLCommand, "INSERT ");
         strcat(sSQLCommand, sTableName);
         strcat(sSQLCommand, " VALUES (\'");      
         strcat(sSQLCommand, sRecordIndicator);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTypeIndicator);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCompanyID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sSubCompanyID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCBSTRRunDate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAccountNumber);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTransDate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTransTime),
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sPostDate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTransAmount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAuthRequired);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAuthID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sConversDate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sPosEntry);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sPosCondCode);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAcquirerID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sReferenceNum);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTraceNumber);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTransCurrencyCd);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTransID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sMCC);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sMCCInfoData);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sMerchAcceptorID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sMerchDescription);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sMerchantCity);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sMerchantStateProvince);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sMerchantPostalCode);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sMerchCountry);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sMerchantVATNumber);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sMerchDescFlag);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sMerchantReferenceNumber);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sSourceCurrency);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sSourceAmount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sBillingCurrency);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sBillingAmount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sSettlemCurrency);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sSettlemAmount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sUSDollarCurr);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sUSDollarAmt);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sGBPoundCurr);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sGBPoundAmt);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sEuroCurrency);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sEuroAmount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAsiaYenCurr);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAsiaYenAmt);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sSwedKronCurr);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sSwedKronAmt);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCanadianCurr);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCanadianAmt);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sConversionRate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sDBCRFlag);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sMemoFlag);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCorpAcctNo);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sSalesTax);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sSalesTaxFlag);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sVATTax);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sVATTaxFlag);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sPurchaseID);
         strcat(sSQLCommand, "\', \'"); 
         strcat(sSQLCommand, sPurchIDFlag);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTranType);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sNoOfAddendums);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sVisaTranCode);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAddendumKey);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTicketNumber);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sMsgType);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFiller1_5000);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sVATEvidenceFlag);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCustRefNumber);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sDiscAmount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sBillingDate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFiller2_5000);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTRXControlData);
         strcat(sSQLCommand, "\')"); 
      }

      if(strcmp(sRecordType, FMTREC6001) == 0)
      {                                       
         strncpy(sRecordTypeID, sRecord, LEN2);
         sRecordTypeID[LEN2] = EOLN;
         
	 strncpy(sAddDetailRecType, &(sRecord[POS3_6001 - 1]), LEN2);
         sAddDetailRecType[LEN2] = EOLN;
         
	 strncpy(sCompanyID, &(sRecord[POS5_6001 - 1]), LEN6);
         sCompanyID[LEN6] = EOLN;
         
	 strncpy(sSubCompanyID, &(sRecord[POS11_6001 - 1]), LEN3);
         sSubCompanyID[LEN3] = EOLN;
         
	 strncpy(sAccountNo, &(sRecord[POS14_6001 - 1]), LEN16);
         sAccountNo[LEN16] = EOLN;
         
	 strncpy(sMessageID, &(sRecord[POS30_6001 - 1]), LEN15);
         sMessageID[LEN15] = EOLN;
         
	 strncpy(sReferenceNumber, &(sRecord[POS45_6001 - 1]), LEN23);
         sReferenceNumber[LEN23] = EOLN;
         
	 strncpy(sTotalFareAmount, &(sRecord[POS68_6001 - 1]), LEN12);
         sTotalFareAmount[LEN12] = EOLN;
         
	 strncpy(sTotalTaxAmount, &(sRecord[POS80_6001 - 1]), LEN12);
         sTotalTaxAmount[LEN12] = EOLN;
         
	 strncpy(sNationalTaxAmount, &(sRecord[POS92_6001 - 1]), LEN12);
         sNationalTaxAmount[LEN12] = EOLN;
         
	 strncpy(sTotalFeeAmount, &(sRecord[POS104_6001 - 1]), LEN12);
         sTotalFeeAmount[LEN12] = EOLN;
         
	 strncpy(sAirlineTicketNumber, &(sRecord[POS116_6001 - 1]), LEN15);
         sAirlineTicketNumber[LEN15] = EOLN;
         
	 strncpy(sExchangeTicketNumber, &(sRecord[POS131_6001 - 1]), LEN13);
         sExchangeTicketNumber[LEN13] = EOLN;
         
	 strncpy(sExchangeTicketAmount, &(sRecord[POS144_6001 - 1]), LEN12);
         sExchangeTicketAmount[LEN12] = EOLN;
         
	 strncpy(sAirlineStopOver1, &(sRecord[POS156_6001 - 1]), LEN1);
         sAirlineStopOver1[LEN1] = EOLN;
         
	 strncpy(sDestination1, &(sRecord[POS157_6001 - 1]), LEN5);
         sDestination1[LEN5] = EOLN;
         
	 strncpy(sAirlineCarrierCode1, &(sRecord[POS162_6001 - 1]), LEN2);
         sAirlineCarrierCode1[LEN2] = EOLN;
         
	 strncpy(sAirlineServiceClass1, &(sRecord[POS164_6001 - 1]), LEN1);
         sAirlineServiceClass1[LEN1] = EOLN;
         
	 strncpy(sFlightNumber1, &(sRecord[POS165_6001 - 1]), LEN5);
         sFlightNumber1[LEN5] = EOLN;
         
	 strncpy(sAirlineStopOver2, &(sRecord[POS170_6001 - 1]), LEN1);
         sAirlineStopOver2[LEN1] = EOLN;
         
	 strncpy(sDestination2, &(sRecord[POS171_6001 - 1]), LEN5);
         sDestination2[LEN5] = EOLN;
         
	 strncpy(sAirlineCarrierCode2, &(sRecord[POS176_6001 - 1]), LEN2);
         sAirlineCarrierCode2[LEN2] = EOLN;
         
	 strncpy(sAirlineServiceClass2, &(sRecord[POS178_6001 - 1]), LEN1);
         sAirlineServiceClass2[LEN1] = EOLN;
         
	 strncpy(sFlightNumber2, &(sRecord[POS179_6001 - 1]), LEN5);
         sFlightNumber2[LEN5] = EOLN;
         
	 strncpy(sAirlineStopOver3, &(sRecord[POS184_6001 - 1]), LEN1);
         sAirlineStopOver3[LEN1] = EOLN;
         
	 strncpy(sDestination3, &(sRecord[POS185_6001 - 1]), LEN5);
         sDestination3[LEN5] = EOLN;
         
	 strncpy(sAirlineCarrierCode3, &(sRecord[POS190_6001 - 1]), LEN2);
         sAirlineCarrierCode3[LEN2] = EOLN;
         
	 strncpy(sAirlineServiceClass3, &(sRecord[POS192_6001 - 1]), LEN1);
         sAirlineServiceClass3[LEN1] = EOLN;
         
	 strncpy(sFlightNumber3, &(sRecord[POS193_6001 - 1]), LEN5);
         sFlightNumber3[LEN5] = EOLN;
         
	 strncpy(sAirlineStopOver4, &(sRecord[POS198_6001 - 1]), LEN1);
         sAirlineStopOver4[LEN1] = EOLN;
         
	 strncpy(sDestination4, &(sRecord[POS199_6001 - 1]), LEN5);
         sDestination4[LEN5] = EOLN;
         
	 strncpy(sAirlineCarrierCode4, &(sRecord[POS204_6001 - 1]), LEN2);
         sAirlineCarrierCode4[LEN2] = EOLN;
         
	 strncpy(sAirlineServiceClass4, &(sRecord[POS206_6001 - 1]), LEN1);
         sAirlineServiceClass4[LEN1] = EOLN;
         
	 strncpy(sFlightNumber4, &(sRecord[POS207_6001 - 1]), LEN5);
         sFlightNumber4[LEN5] = EOLN;
         
	 strncpy(sAirlineStopOver5, &(sRecord[POS212_6001 - 1]), LEN1);
         sAirlineStopOver5[LEN1] = EOLN;
         
	 strncpy(sDestination5, &(sRecord[POS213_6001 - 1]), LEN5);
         sDestination5[LEN5] = EOLN;
         
	 strncpy(sAirlineCarrierCode5, &(sRecord[POS218_6001 - 1]), LEN2);
         sAirlineCarrierCode5[LEN2] = EOLN;
         
	 strncpy(sAirlineServiceClass5, &(sRecord[POS220_6001 - 1]), LEN1);
         sAirlineServiceClass5[LEN1] = EOLN;
         
	 strncpy(sFlightNumber5, &(sRecord[POS221_6001 - 1]), LEN5);
         sFlightNumber5[LEN5] = EOLN;
         
	 strncpy(sAirlineStopOver6, &(sRecord[POS226_6001 - 1]), LEN1);
         sAirlineStopOver6[LEN1] = EOLN;
         
	 strncpy(sDestination6, &(sRecord[POS227_6001 - 1]), LEN5);
         sDestination6[LEN5] = EOLN;
         
	 strncpy(sAirlineCarrierCode6, &(sRecord[POS232_6001 - 1]), LEN2);
         sAirlineCarrierCode6[LEN2] = EOLN;
         
	 strncpy(sAirlineServiceClass6, &(sRecord[POS234_6001 - 1]), LEN1);
         sAirlineServiceClass6[LEN1] = EOLN;
         
	 strncpy(sFlightNumber6, &(sRecord[POS235_6001 - 1]), LEN5);
         sFlightNumber6[LEN5] = EOLN;
         
	 strncpy(sAirlineStopOver7, &(sRecord[POS240_6001 - 1]), LEN1);
         sAirlineStopOver7[LEN1] = EOLN;
         
	 strncpy(sDestination7, &(sRecord[POS241_6001 - 1]), LEN5);
         sDestination7[LEN5] = EOLN;
         
	 strncpy(sAirlineCarrierCode7, &(sRecord[POS246_6001 - 1]), LEN2);
         sAirlineCarrierCode7[LEN2] = EOLN;
         
	 strncpy(sAirlineServiceClass7, &(sRecord[POS248_6001 - 1]), LEN1);
         sAirlineServiceClass7[LEN1] = EOLN;
         
	 strncpy(sFlightNumber7, &(sRecord[POS249_6001 - 1]), LEN5);
         sFlightNumber7[LEN5] = EOLN;
         
	 strncpy(sAirlineStopOver8, &(sRecord[POS254_6001 - 1]), LEN1);
         sAirlineStopOver8[LEN1] = EOLN;
         
	 strncpy(sDestination8, &(sRecord[POS255_6001 - 1]), LEN5);
         sDestination8[LEN5] = EOLN;
         
	 strncpy(sAirlineCarrierCode8, &(sRecord[POS260_6001 - 1]), LEN2);
         sAirlineCarrierCode8[LEN2] = EOLN;
         
	 strncpy(sAirlineServiceClass8, &(sRecord[POS262_6001 - 1]), LEN1);
         sAirlineServiceClass8[LEN1] = EOLN;
         
	 strncpy(sFlightNumber8, &(sRecord[POS263_6001 - 1]), LEN5);
         sFlightNumber8[LEN5] = EOLN;
         
	 strncpy(sAirlineStopOver9, &(sRecord[POS268_6001 - 1]), LEN1);
         sAirlineStopOver9[LEN1] = EOLN;
         
	 strncpy(sDestination9, &(sRecord[POS269_6001 - 1]), LEN5);
         sDestination9[LEN5] = EOLN;
         
	 strncpy(sAirlineCarrierCode9, &(sRecord[POS274_6001 - 1]), LEN2);
         sAirlineCarrierCode9[LEN2] = EOLN;
         
	 strncpy(sAirlineServiceClass9, &(sRecord[POS276_6001 - 1]), LEN1);
         sAirlineServiceClass9[LEN1] = EOLN;
         
	 strncpy(sFlightNumber9, &(sRecord[POS277_6001 - 1]), LEN5);
         sFlightNumber9[LEN5] = EOLN;
         
	 strncpy(sAirlineStopOver10, &(sRecord[POS282_6001 - 1]), LEN1);
         sAirlineStopOver10[LEN1] = EOLN;
         
	 strncpy(sDestination10, &(sRecord[POS283_6001 - 1]), LEN5);
         sDestination10[LEN5] = EOLN;
         
	 strncpy(sAirlineCarrierCode10, &(sRecord[POS288_6001 - 1]), LEN2);
         sAirlineCarrierCode10[LEN2] = EOLN;
         
	 strncpy(sAirlineServiceClass10, &(sRecord[POS290_6001 - 1]), LEN1);
         sAirlineServiceClass10[LEN1] = EOLN;
         
	 strncpy(sFlightNumber10, &(sRecord[POS291_6001 - 1]), LEN5);
         sFlightNumber10[LEN5] = EOLN;
         
	 strncpy(sAirlineStopOver11, &(sRecord[POS296_6001 - 1]), LEN1);
         sAirlineStopOver11[LEN1] = EOLN;
         
	 strncpy(sDestination11, &(sRecord[POS297_6001 - 1]), LEN5);
         sDestination11[LEN5] = EOLN;
         
	 strncpy(sAirlineCarrierCode11, &(sRecord[POS302_6001 - 1]), LEN2);
         sAirlineCarrierCode11[LEN2] = EOLN;
         
	 strncpy(sAirlineServiceClass11, &(sRecord[POS304_6001 - 1]), LEN1);
         sAirlineServiceClass11[LEN1] = EOLN;
         
	 strncpy(sFlightNumber11, &(sRecord[POS305_6001 - 1]), LEN5);
         sFlightNumber11[LEN5] = EOLN;
         
	 strncpy(sAirlineStopOver12, &(sRecord[POS310_6001 - 1]), LEN1);
         sAirlineStopOver12[LEN1] = EOLN;
         
	 strncpy(sDestination12, &(sRecord[POS311_6001 - 1]), LEN5);
         sDestination12[LEN5] = EOLN;
         
	 strncpy(sAirlineCarrierCode12, &(sRecord[POS316_6001 - 1]), LEN2);
         sAirlineCarrierCode12[LEN2] = EOLN;
         
	 strncpy(sAirlineServiceClass12, &(sRecord[POS318_6001 - 1]), LEN1);
         sAirlineServiceClass12[LEN1] = EOLN;
         
	 strncpy(sFlightNumber12, &(sRecord[POS319_6001 - 1]), LEN5);
         sFlightNumber12[LEN5] = EOLN;
         
	 strncpy(sAirlineStopOver13, &(sRecord[POS324_6001 - 1]), LEN1);
         sAirlineStopOver13[LEN1] = EOLN;
         
	 strncpy(sDestination13, &(sRecord[POS325_6001 - 1]), LEN5);
         sDestination13[LEN5] = EOLN;
         
	 strncpy(sAirlineCarrierCode13, &(sRecord[POS330_6001 - 1]), LEN2);
         sAirlineCarrierCode13[LEN2] = EOLN;
         
	 strncpy(sAirlineServiceClass13, &(sRecord[POS332_6001 - 1]), LEN1);
         sAirlineServiceClass13[LEN1] = EOLN;
         
	 strncpy(sFlightNumber13, &(sRecord[POS333_6001 - 1]), LEN5);
         sFlightNumber13[LEN5] = EOLN;
         
	 strncpy(sAirlineStopOver14, &(sRecord[POS338_6001 - 1]), LEN1);
         sAirlineStopOver14[LEN1] = EOLN;
         
	 strncpy(sDestination14, &(sRecord[POS339_6001 - 1]), LEN5);
         sDestination14[LEN5] = EOLN;
         
	 strncpy(sAirlineCarrierCode14, &(sRecord[POS344_6001 - 1]), LEN2);
         sAirlineCarrierCode14[LEN2] = EOLN;
         
	 strncpy(sAirlineServiceClass14, &(sRecord[POS346_6001 - 1]), LEN1);
         sAirlineServiceClass14[LEN1] = EOLN;
         
	 strncpy(sFlightNumber14, &(sRecord[POS347_6001 - 1]), LEN5);
         sFlightNumber14[LEN5] = EOLN;
         
	 strncpy(sAirlineStopOver15, &(sRecord[POS352_6001 - 1]), LEN1);
         sAirlineStopOver15[LEN1] = EOLN;
         
	 strncpy(sDestination15, &(sRecord[POS353_6001 - 1]), LEN5);
         sDestination15[LEN5] = EOLN;
         
	 strncpy(sAirlineCarrierCode15, &(sRecord[POS358_6001 - 1]), LEN2);
         sAirlineCarrierCode15[LEN2] = EOLN;
         
	 strncpy(sAirlineServiceClass15, &(sRecord[POS360_6001 - 1]), LEN1);
         sAirlineServiceClass15[LEN1] = EOLN;
         
	 strncpy(sFlightNumber15, &(sRecord[POS361_6001 - 1]), LEN5);
         sFlightNumber15[LEN5] = EOLN;
         
	 strncpy(sAirlineStopOver16, &(sRecord[POS366_6001 - 1]), LEN1);
         sAirlineStopOver16[LEN1] = EOLN;
         
	 strncpy(sDestination16, &(sRecord[POS367_6001 - 1]), LEN5);
         sDestination16[LEN5] = EOLN;
         
	 strncpy(sAirlineCarrierCode16, &(sRecord[POS372_6001 - 1]), LEN2);
         sAirlineCarrierCode16[LEN2] = EOLN;
         
	 strncpy(sAirlineServiceClass16, &(sRecord[POS374_6001 - 1]), LEN1);
         sAirlineServiceClass16[LEN1] = EOLN;
         
	 strncpy(sFlightNumber16, &(sRecord[POS375_6001 - 1]), LEN5);
         sFlightNumber16[LEN5] = EOLN;
         
	 strncpy(sTravelAgencyCode, &(sRecord[POS380_6001 - 1]), LEN8);
         sTravelAgencyCode[LEN8] = EOLN;
         
	 strncpy(sTravelAgencyName, &(sRecord[POS388_6001 - 1]), LEN25);
         sTravelAgencyName[LEN25] = EOLN;
         
	 strncpy(sPassengerName, &(sRecord[POS413_6001 - 1]), LEN20);
         sPassengerName[LEN20] = EOLN;
         
	 strncpy(sDepartureDate, &(sRecord[POS433_6001 - 1]), LEN6);
         sDepartureDate[LEN6] = EOLN;
         
	 strncpy(sOriginationCode, &(sRecord[POS439_6001 - 1]), LEN3);
         sOriginationCode[LEN3] = EOLN;
         
	 strncpy(sInternetIndicator, &(sRecord[POS442_6001 - 1]), LEN1);
         sInternetIndicator[LEN1] = EOLN;
         
	 strncpy(sElectTicketInd, &(sRecord[POS443_6001 - 1]), LEN1);
         sElectTicketInd[LEN1] = EOLN;
         
	 strncpy(sFiller6001, &(sRecord[POS444_6001 - 1]), LEN507);
         sFiller6001[LEN507] = EOLN;
         
	 strncpy(sTRXControlData, &(sRecord[POS951_6001 - 1]), LEN50);
         sTRXControlData[LEN50] = EOLN;

         strcpy(sSQLCommand, "INSERT ");
         strcat(sSQLCommand, sTableName);
         strcat(sSQLCommand, " VALUES (\'");      
         strcat(sSQLCommand, sRecordTypeID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAddDetailRecType);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCompanyID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sSubCompanyID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAccountNo);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sMessageID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sReferenceNumber);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTotalFareAmount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTotalTaxAmount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sNationalTaxAmount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTotalFeeAmount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineTicketNumber);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sExchangeTicketNumber);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sExchangeTicketAmount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineStopOver1);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sDestination1);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineCarrierCode1);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineServiceClass1);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFlightNumber1);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineStopOver2);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sDestination2);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineCarrierCode2);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineServiceClass2);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFlightNumber2);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineStopOver3);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sDestination3);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineCarrierCode3);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineServiceClass3);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFlightNumber3);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineStopOver4);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sDestination4);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineCarrierCode4);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineServiceClass4);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFlightNumber4);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineStopOver5);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sDestination5);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineCarrierCode5);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineServiceClass5);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFlightNumber5);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineStopOver6);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sDestination6);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineCarrierCode6);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineServiceClass6);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFlightNumber6);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineStopOver7);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sDestination7);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineCarrierCode7);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineServiceClass7);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFlightNumber7);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineStopOver8);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sDestination8);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineCarrierCode8);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineServiceClass8);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFlightNumber8);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineStopOver9);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sDestination9);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineCarrierCode9);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineServiceClass9);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFlightNumber9);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineStopOver10);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sDestination10);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineCarrierCode10);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineServiceClass10);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFlightNumber10);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineStopOver11);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sDestination11);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineCarrierCode11);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineServiceClass11);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFlightNumber11);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineStopOver12);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sDestination12);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineCarrierCode12);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineServiceClass12);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFlightNumber12);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineStopOver13);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sDestination13);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineCarrierCode13);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineServiceClass13);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFlightNumber13);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineStopOver14);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sDestination14);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineCarrierCode14);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineServiceClass14);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFlightNumber14);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineStopOver15);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sDestination15);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineCarrierCode15);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineServiceClass15);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFlightNumber15);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineStopOver16);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sDestination16);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineCarrierCode16);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAirlineServiceClass16);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFlightNumber16);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTravelAgencyCode);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTravelAgencyName);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sPassengerName);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sDepartureDate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sOriginationCode);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sInternetIndicator);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sElectTicketInd);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFiller6001);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTRXControlData);
         strcat(sSQLCommand, "\')"); 
      }

      if(strcmp(sRecordType, FMTREC6002) == 0)
      {                                       
         strncpy(sRecordTypeID, sRecord, LEN2);
         sRecordTypeID[LEN2] = EOLN;
         
	 strncpy(sAddDetailRecType, &(sRecord[POS3_6002 - 1]), LEN2);
         sAddDetailRecType[LEN2] = EOLN;
         
	 strncpy(sCompanyID, &(sRecord[POS5_6002 - 1]), LEN6);
         sCompanyID[LEN6] = EOLN;
         
	 strncpy(sSubCompanyID, &(sRecord[POS11_6002 - 1]), LEN3);
         sSubCompanyID[LEN3] = EOLN;
         
	 strncpy(sAccountNo, &(sRecord[POS14_6002 - 1]), LEN16);
         sAccountNo[LEN16] = EOLN;
         
	 strncpy(sPurchDetailSeqNum, &(sRecord[POS30_6002 - 1]), LEN3);
         sPurchDetailSeqNum[LEN3] = EOLN;
         
	 strncpy(sOrderDate, &(sRecord[POS33_6002 - 1]), LEN6);
         sOrderDate[LEN6] = EOLN;
         
	 strncpy(sDestinationZipCode, &(sRecord[POS39_6002 - 1]), LEN10);
         sDestinationZipCode[LEN10] = EOLN;
         
	 strncpy(sDestinationCountryCode, &(sRecord[POS49_6002 - 1]), LEN3);
         sDestinationCountryCode[LEN3] = EOLN;
         
	 strncpy(sOriginationZipCode, &(sRecord[POS52_6002 - 1]), LEN10);
         sOriginationZipCode[LEN10] = EOLN;
         
	 strncpy(sFreightAmount, &(sRecord[POS62_6002 - 1]), LEN13);
         sFreightAmount[LEN13] = EOLN;
         
	 strncpy(sFreightVATTaxAmount, &(sRecord[POS75_6002 - 1]), LEN12);
         sFreightVATTaxAmount[LEN12] = EOLN;
         
	 strncpy(sFreightVATTaxRate, &(sRecord[POS87_6002 - 1]), LEN4);
         sFreightVATTaxRate[LEN4] = EOLN;
         
	 strncpy(sCommodityCode, &(sRecord[POS91_6002 - 1]), LEN15);
         sCommodityCode[LEN15] = EOLN;
         
	 strncpy(sDescription, &(sRecord[POS106_6002 - 1]), LEN35);
         sDescription[LEN35] = EOLN;
         
	 strncpy(sProductCode, &(sRecord[POS141_6002 - 1]), LEN12);
         sProductCode[LEN12] = EOLN;
         
	 strncpy(sQuantity, &(sRecord[POS153_6002 - 1]), LEN15);
         sQuantity[LEN15] = EOLN;
         
	 strncpy(sUnitOfMeasure, &(sRecord[POS168_6002 - 1]), LEN12);
         sUnitOfMeasure[LEN12] = EOLN;
         
	 strncpy(sUnitCost, &(sRecord[POS180_6002 - 1]), LEN15);
         sUnitCost[LEN15] = EOLN;
         
	 strncpy(sVATTaxAmount, &(sRecord[POS195_6002 - 1]), LEN12);
         sVATTaxAmount[LEN12] = EOLN;
         
	 strncpy(sVATTaxRate, &(sRecord[POS207_6002 - 1]), LEN4);
         sVATTaxRate[LEN4] = EOLN;
         
	 strncpy(sUniqueVATInvRefNo, &(sRecord[POS211_6002 - 1]), LEN15);
         sUniqueVATInvRefNo[LEN15] = EOLN;
         
	 strncpy(sDiscountPerLineItem, &(sRecord[POS226_6002 - 1]), LEN12);
         sDiscountPerLineItem[LEN12] = EOLN;
         
	 strncpy(sLineItemTotal, &(sRecord[POS238_6002 - 1]), LEN12);
         sLineItemTotal[LEN12] = EOLN;
         
	 strncpy(sFiller6002, &(sRecord[POS250_6002 - 1]), LEN701);
         sFiller6002[LEN701] = EOLN;
         
	 strncpy(sTRXControlData, &(sRecord[POS951_6002 - 1]), LEN50);
         sTRXControlData[LEN50] = EOLN;

         strcpy(sSQLCommand, "INSERT ");
         strcat(sSQLCommand, sTableName);
         strcat(sSQLCommand, " VALUES (\'");      
         strcat(sSQLCommand, sRecordTypeID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAddDetailRecType);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCompanyID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sSubCompanyID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAccountNo);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sPurchDetailSeqNum);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sOrderDate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sDestinationZipCode);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sDestinationCountryCode);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sOriginationZipCode);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFreightAmount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFreightVATTaxAmount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFreightVATTaxRate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCommodityCode);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sDescription);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sProductCode);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sQuantity);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sUnitOfMeasure);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sUnitCost);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sVATTaxAmount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sVATTaxRate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sUniqueVATInvRefNo);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sDiscountPerLineItem);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sLineItemTotal);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFiller6002);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTRXControlData);
         strcat(sSQLCommand, "\')"); 
      }

      if(strcmp(sRecordType, FMTREC6004) == 0)
      {        
         strncpy(sRecordTypeID, sRecord, LEN2);
         sRecordTypeID[LEN2] = EOLN;
         
	 strncpy(sAddDetailRecType, &(sRecord[POS3_6004 - 1]), LEN2);
         sAddDetailRecType[LEN2] = EOLN;
         
	 strncpy(sCompanyID, &(sRecord[POS5_6004 - 1]), LEN6);
         sCompanyID[LEN6] = EOLN;
         
	 strncpy(sSubCompanyID, &(sRecord[POS11_6004 - 1]), LEN3);
         sSubCompanyID[LEN3] = EOLN;
         
	 strncpy(sAccountNo, &(sRecord[POS14_6004 - 1]), LEN16);
         sAccountNo[LEN16] = EOLN;
         
	 strncpy(sPurchDetailSeqNum, &(sRecord[POS30_6004 - 1]), LEN3);
         sPurchDetailSeqNum[LEN3] = EOLN;
         
	 strncpy(sPropTelephoneNumber, &(sRecord[POS33_6004 - 1]), LEN10);
         sPropTelephoneNumber[LEN10] = EOLN;
         
	 strncpy(sCustServPhoneNum, &(sRecord[POS43_6004 - 1]), LEN10);
         sCustServPhoneNum[LEN10] = EOLN;
         
	 strncpy(sCheckInDate, &(sRecord[POS53_6004 - 1]), LEN8);
         sCheckInDate[LEN8] = EOLN;
         
	 strncpy(sCheckOutDate, &(sRecord[POS61_6004 - 1]), LEN8);
         sCheckOutDate[LEN8] = EOLN;
         
	 strncpy(sNoShowIndicator, &(sRecord[POS69_6004 - 1]), LEN1);
         sNoShowIndicator[LEN1] = EOLN;
         
	 strncpy(sTotalAuthAmount, &(sRecord[POS70_6004 - 1]), LEN13);
         sTotalAuthAmount[LEN13] = EOLN;
         
	 strncpy(sPrepaidExpenses, &(sRecord[POS83_6004 - 1]), LEN7);
         sPrepaidExpenses[LEN7] = EOLN;
         
	 strncpy(sNumberOfRoomNights, &(sRecord[POS90_6004 - 1]), LEN12);
         sNumberOfRoomNights[LEN12] = EOLN;
         
	 strncpy(sDailyRoomRate, &(sRecord[POS102_6004 - 1]), LEN12);
         sDailyRoomRate[LEN12] = EOLN;
         
	 strncpy(sVATTaxAmount, &(sRecord[POS114_6004 - 1]), LEN12);
         sVATTaxAmount[LEN12] = EOLN;
         
	 strncpy(sVATTaxRate_6004, &(sRecord[POS126_6004 - 1]), LEN12);
         sVATTaxRate_6004[LEN12] = EOLN;
         
	 strncpy(sRoomTaxAmount, &(sRecord[POS138_6004 - 1]), LEN12);
         sRoomTaxAmount[LEN12] = EOLN;
         
	 strncpy(sUniqueVATInvRefNo, &(sRecord[POS150_6004 - 1]), LEN15);
         sUniqueVATInvRefNo[LEN15] = EOLN;
         
	 strncpy(sDiscountAmount, &(sRecord[POS165_6004 - 1]), LEN12);
         sDiscountAmount[LEN12] = EOLN;
         
	 strncpy(sFoodAndBeverageCharge, &(sRecord[POS177_6004 - 1]), LEN12);
         sFoodAndBeverageCharge[LEN12] = EOLN;
         
	 strncpy(sCashAdvances, &(sRecord[POS189_6004 - 1]), LEN12);
         sCashAdvances[LEN12] = EOLN;
         
	 strncpy(sValetParkingCharges, &(sRecord[POS201_6004 - 1]), LEN12);
         sValetParkingCharges[LEN12] = EOLN;
         
	 strncpy(sMiniBarCharges, &(sRecord[POS213_6004 - 1]), LEN12);
         sMiniBarCharges[LEN12] = EOLN;
         
	 strncpy(sLaundryCharges, &(sRecord[POS225_6004 - 1]), LEN12);
         sLaundryCharges[LEN12] = EOLN;
         
	 strncpy(sPhoneCharges, &(sRecord[POS237_6004 - 1]), LEN12);
         sPhoneCharges[LEN12] = EOLN;
         
	 strncpy(sGiftShopCharges, &(sRecord[POS249_6004 - 1]), LEN12);
         sGiftShopCharges[LEN12] = EOLN;
         
	 strncpy(sMovieCharges, &(sRecord[POS261_6004 - 1]), LEN12);
         sMovieCharges[LEN12] = EOLN;
         
	 strncpy(sBusinessCenterCharges, &(sRecord[POS273_6004 - 1]), LEN12);
         sBusinessCenterCharges[LEN12] = EOLN;
         
	 strncpy(sHealthClubCharges, &(sRecord[POS285_6004 - 1]), LEN12);
         sHealthClubCharges[LEN12] = EOLN;
         
	 strncpy(sOtherCharges, &(sRecord[POS297_6004 - 1]), LEN12);
         sOtherCharges[LEN12] = EOLN;
         
	 strncpy(sTotalNonRoomCharges, &(sRecord[POS309_6004 - 1]), LEN12);
         sTotalNonRoomCharges[LEN12] = EOLN;
         
	 strncpy(sFiller6004, &(sRecord[POS321_6004 - 1]), LEN630);
         sFiller6004[LEN630] = EOLN;
         
	 strncpy(sTRXControlData, &(sRecord[POS951_6004 - 1]), LEN50);
         sTRXControlData[LEN50] = EOLN;

         strcpy(sSQLCommand, "INSERT ");
         strcat(sSQLCommand, sTableName);
         strcat(sSQLCommand, " VALUES (\'");      
         strcat(sSQLCommand, sRecordTypeID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAddDetailRecType);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCompanyID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sSubCompanyID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAccountNo);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sPurchDetailSeqNum);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sPropTelephoneNumber);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCustServPhoneNum);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCheckInDate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCheckOutDate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sNoShowIndicator);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTotalAuthAmount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sPrepaidExpenses);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sNumberOfRoomNights);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sDailyRoomRate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sVATTaxAmount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sVATTaxRate_6004);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sRoomTaxAmount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sUniqueVATInvRefNo);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sDiscountAmount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFoodAndBeverageCharge);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCashAdvances);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sValetParkingCharges);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sMiniBarCharges);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sLaundryCharges);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sPhoneCharges);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sGiftShopCharges);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sMovieCharges);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sBusinessCenterCharges);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sHealthClubCharges);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sOtherCharges);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTotalNonRoomCharges);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFiller6004);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTRXControlData);
         strcat(sSQLCommand, "\')"); 
      }

      if(strcmp(sRecordType, FMTREC6005) == 0)
      { 
         strncpy(sRecordTypeID, sRecord, LEN2);
         sRecordTypeID[LEN2] = EOLN;
         
	 strncpy(sAddDetailRecType, &(sRecord[POS3_6005 - 1]), LEN2);
         sAddDetailRecType[LEN2] = EOLN;
         
	 strncpy(sCompanyID, &(sRecord[POS5_6005 - 1]), LEN6);
         sCompanyID[LEN6] = EOLN;
         
	 strncpy(sSubCompanyID, &(sRecord[POS11_6005 - 1]), LEN3);
         sSubCompanyID[LEN3] = EOLN;
         
	 strncpy(sAccountNo, &(sRecord[POS14_6005 - 1]), LEN16);
         sAccountNo[LEN16] = EOLN;
         
	 strncpy(sPurchDetailSeqNum, &(sRecord[POS30_6005 - 1]), LEN3);
         sPurchDetailSeqNum[LEN3] = EOLN;
         
	 strncpy(sRentalAgreeNum, &(sRecord[POS33_6005 - 1]), LEN25);
         sRentalAgreeNum[LEN25] = EOLN;
         
	 strncpy(sRentersName, &(sRecord[POS58_6005 - 1]), LEN40);
         sRentersName[LEN40] = EOLN;
         
	 strncpy(sLocOfRetCity, &(sRecord[POS98_6005 - 1]), LEN25);
         sLocOfRetCity[LEN25] = EOLN;
         
	 strncpy(sRetStaCountry, &(sRecord[POS123_6005 - 1]), LEN3);
         sRetStaCountry[LEN3] = EOLN;
         
	 strncpy(sCarClassCode, &(sRecord[POS126_6005 - 1]), LEN2);
         sCarClassCode[LEN2] = EOLN;
         
	 strncpy(sNoShowIndicator, &(sRecord[POS128_6005 - 1]), LEN1);
         sNoShowIndicator[LEN1] = EOLN;
         
	 strncpy(sCheckOutDate, &(sRecord[POS129_6005 - 1]), LEN8);
         sCheckOutDate[LEN8] = EOLN;
         
	 strncpy(sCheckInDate_6005, &(sRecord[POS137_6005 - 1]), LEN6);
         sCheckInDate_6005[LEN6] = EOLN; 
         
	 strncpy(sInsuranceInd, &(sRecord[POS143_6005 - 1]), LEN1);
         sInsuranceInd[LEN1] = EOLN;
         
	 strncpy(sInsuranceCharges, &(sRecord[POS144_6005 - 1]), LEN12);
         sInsuranceCharges[LEN12] = EOLN;
         
	 strncpy(sTotalMiles, &(sRecord[POS156_6005 - 1]), LEN5);
         sTotalMiles[LEN5] = EOLN;
         
	 strncpy(sNumOfDaysRented, &(sRecord[POS161_6005 - 1]), LEN2);
         sNumOfDaysRented[LEN2] = EOLN;
         
	 strncpy(sDailyRate, &(sRecord[POS163_6005 - 1]), LEN12);
         sDailyRate[LEN12] = EOLN;
         
	 strncpy(sVATTaxAmount, &(sRecord[POS175_6005 - 1]), LEN12);
         sVATTaxAmount[LEN12] = EOLN;
         
	 strncpy(sVATTaxRate, &(sRecord[POS187_6005 - 1]), LEN4);
         sVATTaxRate[LEN4] = EOLN;
         
	 strncpy(sUniqueVATInvRefNo, &(sRecord[POS191_6005 - 1]), LEN15);
         sUniqueVATInvRefNo[LEN15] = EOLN;
         
	 strncpy(sWeeklyRate, &(sRecord[POS206_6005 - 1]), LEN12);
         sWeeklyRate[LEN12] = EOLN;
         
	 strncpy(sRatePerMile, &(sRecord[POS218_6005 - 1]), LEN12);
         sRatePerMile[LEN12] = EOLN;
         
	 strncpy(sOneWayDropOffCh, &(sRecord[POS230_6005 - 1]), LEN12);
         sOneWayDropOffCh[LEN12] = EOLN;
         
	 strncpy(sRegMilCharge, &(sRecord[POS242_6005 - 1]), LEN12);
         sRegMilCharge[LEN12] = EOLN;
         
	 strncpy(sExtraMilCharge, &(sRecord[POS254_6005 - 1]), LEN12);
         sExtraMilCharge[LEN12] = EOLN;
         
	 strncpy(sMaxFreeMiles, &(sRecord[POS266_6005 - 1]), LEN5);
         sMaxFreeMiles[LEN5] = EOLN;
         
	 strncpy(sLateRetChHourRate, &(sRecord[POS271_6005 - 1]), LEN12);
         sLateRetChHourRate[LEN12] = EOLN;
         
	 strncpy(sFuelCharge, &(sRecord[POS283_6005 - 1]), LEN12);
         sFuelCharge[LEN12] = EOLN;
         
	 strncpy(sTelephoneCharges, &(sRecord[POS295_6005 - 1]), LEN12);
         sTelephoneCharges[LEN12] = EOLN;
         
	 strncpy(sAutoTowingCharges, &(sRecord[POS307_6005 - 1]), LEN12);
         sAutoTowingCharges[LEN12] = EOLN;
         
	 strncpy(sExtraCharges, &(sRecord[POS319_6005 - 1]), LEN12);
         sExtraCharges[LEN12] = EOLN;
         
	 strncpy(sOtherCharges, &(sRecord[POS331_6005 - 1]), LEN12);
         sOtherCharges[LEN12] = EOLN;
         
	 strncpy(sDiscountAmount, &(sRecord[POS343_6005 - 1]), LEN12);
         sDiscountAmount[LEN12] = EOLN;
         
	 strncpy(sLineItemTotal, &(sRecord[POS355_6005 - 1]), LEN12);
         sLineItemTotal[LEN12] = EOLN;
         
	 strncpy(sFiller6005, &(sRecord[POS367_6005 - 1]), LEN584);
         sFiller6005[LEN584] = EOLN;
         
	 strncpy(sTRXControlData, &(sRecord[POS951_6005 - 1]), LEN50);
         sTRXControlData[LEN50] = EOLN;

         strcpy(sSQLCommand, "INSERT ");
         strcat(sSQLCommand, sTableName);
         strcat(sSQLCommand, " VALUES (\'");      
         strcat(sSQLCommand, sRecordTypeID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAddDetailRecType);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCompanyID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sSubCompanyID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAccountNo);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sPurchDetailSeqNum);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sRentalAgreeNum);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sRentersName);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sLocOfRetCity);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sRetStaCountry);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCarClassCode);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sNoShowIndicator);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCheckOutDate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCheckInDate_6005);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sInsuranceInd);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sInsuranceCharges);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTotalMiles);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sNumOfDaysRented);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sDailyRate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sVATTaxAmount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sVATTaxRate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sUniqueVATInvRefNo);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sWeeklyRate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sRatePerMile);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sOneWayDropOffCh);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sRegMilCharge);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sExtraMilCharge);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sMaxFreeMiles);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sLateRetChHourRate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFuelCharge);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTelephoneCharges);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sAutoTowingCharges);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sExtraCharges);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sOtherCharges);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sDiscountAmount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sLineItemTotal);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFiller6005);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTRXControlData);
         strcat(sSQLCommand, "\')"); 
      }

      if(strcmp(sRecordType, FMTREC9000) == 0)
      {  
         strcpy(sRecordIndicator, sRecordType);
         
	 strncpy(sTypeIndicator, &(sRecord[POS5_9000 - 1]), LEN3);
         sTypeIndicator[LEN3] = EOLN;
         
	 strncpy(sCompanyName, &(sRecord[POS8_9000 - 1]), LEN100);
         sCompanyName[LEN100] = EOLN;
         
	 strncpy(sCompanyID, &(sRecord[POS108_9000 - 1]), LEN6);
         sCompanyID[LEN6] = EOLN;
         
	 strncpy(sSubCompanyID, &(sRecord[POS114_9000 - 1]), LEN3);
         sSubCompanyID[LEN3] = EOLN;
         
	 strncpy(sEffectiveFileDate, &(sRecord[POS117_9000 - 1]), LEN8);
         sEffectiveFileDate[LEN8] = EOLN;
         
	 strncpy(sType1000RecordCount, &(sRecord[POS125_9000 - 1]), LEN18);
         sType1000RecordCount[LEN18] = EOLN;
         
	 strncpy(sType1001RecordCount, &(sRecord[POS143_9000 - 1]), LEN18);
         sType1001RecordCount[LEN18] = EOLN;
         
	 strncpy(sType2000RecordCount, &(sRecord[POS161_9000 - 1]), LEN18);
         sType2000RecordCount[LEN18] = EOLN;
         
	 strncpy(sType2001RecordCount, &(sRecord[POS179_9000 - 1]), LEN18);
         sType2001RecordCount[LEN18] = EOLN;
         
	 strncpy(sType2002RecordCount, &(sRecord[POS197_9000 - 1]), LEN18);
         sType2002RecordCount[LEN18] = EOLN;
         
	 strncpy(sType5000RecordCount, &(sRecord[POS215_9000 - 1]), LEN18);
         sType5000RecordCount[LEN18] = EOLN;
         
	 strncpy(sType5000TotalValue, &(sRecord[POS233_9000 - 1]), LEN18);
         sType5000TotalValue[LEN18] = EOLN;
         
	 strncpy(sType5001RecordCount, &(sRecord[POS251_9000 - 1]), LEN18);
         sType5001RecordCount[LEN18] = EOLN;
         
	 strncpy(sType6001RecordCount, &(sRecord[POS269_9000 - 1]), LEN18);
         sType6001RecordCount[LEN18] = EOLN;
         
	 strncpy(sType6002RecordCount, &(sRecord[POS287_9000 - 1]), LEN18);
         sType6002RecordCount[LEN18] = EOLN;
         
	 strncpy(sType6004RecordCount, &(sRecord[POS305_9000 - 1]), LEN18);
         sType6004RecordCount[LEN18] = EOLN;
         
	 strncpy(sType6005RecordCount, &(sRecord[POS323_9000 - 1]), LEN18);
         sType6005RecordCount[LEN18] = EOLN;
         
	 strncpy(sFiller9000, &(sRecord[POS341_9000 - 1]), LEN610);
         sFiller9000[LEN610] = EOLN;
         
	 strncpy(sTRXControlData, &(sRecord[POS951_9000 - 1]), LEN50);
         sTRXControlData[LEN50] = EOLN; 

         strcpy(sSQLCommand, "INSERT ");
         strcat(sSQLCommand, sTableName);
         strcat(sSQLCommand, " VALUES (\'");      
         strcat(sSQLCommand, sRecordIndicator);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTypeIndicator);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCompanyName);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sCompanyID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sSubCompanyID);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sEffectiveFileDate);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sType1000RecordCount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sType1001RecordCount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sType2000RecordCount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sType2001RecordCount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sType2002RecordCount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sType5000RecordCount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sType5000TotalValue);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sType5001RecordCount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sType6001RecordCount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sType6002RecordCount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sType6004RecordCount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sType6005RecordCount);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sFiller9000);
         strcat(sSQLCommand, "\', \'");
         strcat(sSQLCommand, sTRXControlData);
         strcat(sSQLCommand, "\')"); 
      }

      /* Insertar la informacion previamente extraida en la tabla
         correspondiente. */

#ifdef DEBUG1
   printf("\nSQL Command: %s", sSQLCommand);
#endif                                         

      
           /*
           ** SQL STATEMENT: 29
           ** EXEC SQL PREPARE insertdata FROM :sSQLCommand;
           */
# line 3535 "C430InsertCCF.cp"
# line 3535 "C430InsertCCF.cp"
           {
# line 3535 "C430InsertCCF.cp"
                _SQL_CT_HANDLES * _sql;
# line 3535 "C430InsertCCF.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 3535 "C430InsertCCF.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 3535 "C430InsertCCF.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 3535 "C430InsertCCF.cp"
               {
# line 3535 "C430InsertCCF.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 3535 "C430InsertCCF.cp"
                   _sql->stmttype = SQL_PREPARE;
# line 3535 "C430InsertCCF.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 3535 "C430InsertCCF.cp"
                   _sql->stmtName.fnlen = 10;
# line 3535 "C430InsertCCF.cp"
                   strcpy(_sql->stmtName.first_name, "insertdata");
# line 3535 "C430InsertCCF.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 3535 "C430InsertCCF.cp"
                   {
# line 3535 "C430InsertCCF.cp"
                       _sql->retcode = ct_dynamic(_sql->conn.command, 
# line 3535 "C430InsertCCF.cp"
                           CS_PREPARE, "insertdata", 10, sSQLCommand, 
# line 3535 "C430InsertCCF.cp"
                           CS_NULLTERM);
# line 3535 "C430InsertCCF.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 3535 "C430InsertCCF.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 3535 "C430InsertCCF.cp"
                       _sql->resloop = CS_TRUE;
# line 3535 "C430InsertCCF.cp"
                       while ((!_sql->hastate) && (_sql->resloop == CS_TRUE) 
# line 3535 "C430InsertCCF.cp"
                           && ((_sql->retcode = ct_results(_sql->conn.command, 
# line 3535 "C430InsertCCF.cp"
                           &_sql->restype)) == CS_SUCCEED))
# line 3535 "C430InsertCCF.cp"
                       {
# line 3535 "C430InsertCCF.cp"
                           switch ( _sql->restype )
# line 3535 "C430InsertCCF.cp"
                           {
# line 3535 "C430InsertCCF.cp"
                           case CS_CMD_FAIL:
# line 3535 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 3535 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_ALL);
# line 3535 "C430InsertCCF.cp"
                           break;
# line 3535 "C430InsertCCF.cp"
                           case CS_COMPUTE_RESULT:
# line 3535 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 3535 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25003);
# line 3535 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 3535 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 3535 "C430InsertCCF.cp"
                           break;
# line 3535 "C430InsertCCF.cp"
                           case CS_CURSOR_RESULT:
# line 3535 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 3535 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25004);
# line 3535 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 3535 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 3535 "C430InsertCCF.cp"
                           break;
# line 3535 "C430InsertCCF.cp"
                           case CS_PARAM_RESULT:
# line 3535 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 3535 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25005);
# line 3535 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 3535 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 3535 "C430InsertCCF.cp"
                           break;
# line 3535 "C430InsertCCF.cp"
                           case CS_ROW_RESULT:
# line 3535 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 3535 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25006);
# line 3535 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 3535 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 3535 "C430InsertCCF.cp"
                           break;
# line 3535 "C430InsertCCF.cp"
                           case CS_STATUS_RESULT:
# line 3535 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 3535 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25009);
# line 3535 "C430InsertCCF.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 3535 "C430InsertCCF.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 3535 "C430InsertCCF.cp"
                           break;
# line 3535 "C430InsertCCF.cp"
                           case CS_DESCRIBE_RESULT:
# line 3535 "C430InsertCCF.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 3535 "C430InsertCCF.cp"
                                   _SQL_INTRERR_25010);
# line 3535 "C430InsertCCF.cp"
                           break;
# line 3535 "C430InsertCCF.cp"
                           }
# line 3535 "C430InsertCCF.cp"
                           
# line 3535 "C430InsertCCF.cp"
                       }
# line 3535 "C430InsertCCF.cp"
                       
# line 3535 "C430InsertCCF.cp"
                       if ((_sql->retcode != CS_END_RESULTS) && (_sql->retcode 
# line 3535 "C430InsertCCF.cp"
                           != CS_CANCELED) && (_sql->retcode != 
# line 3535 "C430InsertCCF.cp"
                           CS_RET_HAFAILOVER) && (_sql->resloop != CS_FALSE))
# line 3535 "C430InsertCCF.cp"
                       {
# line 3535 "C430InsertCCF.cp"
                           _sql->retcode = ct_cancel(NULL, _sql->conn.command, 
# line 3535 "C430InsertCCF.cp"
                               CS_CANCEL_ALL);
# line 3535 "C430InsertCCF.cp"
                           }
# line 3535 "C430InsertCCF.cp"
                            else {
# line 3535 "C430InsertCCF.cp"
                           if (((_sql->retcode != CS_CANCELED) && 
# line 3535 "C430InsertCCF.cp"
                               (_sql->retcode != CS_RET_HAFAILOVER)))
# line 3535 "C430InsertCCF.cp"
                           {
# line 3535 "C430InsertCCF.cp"
                               _sql->retcode = CS_SUCCEED;
# line 3535 "C430InsertCCF.cp"
                           }
# line 3535 "C430InsertCCF.cp"
                           
# line 3535 "C430InsertCCF.cp"
                       }
# line 3535 "C430InsertCCF.cp"
                       
# line 3535 "C430InsertCCF.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 3535 "C430InsertCCF.cp"
                   }
# line 3535 "C430InsertCCF.cp"
                   
# line 3535 "C430InsertCCF.cp"
                   if (sqlca.sqlcode < 0)
# line 3535 "C430InsertCCF.cp"
                   {
# line 3535 "C430InsertCCF.cp"
                       error_handler();
# line 3535 "C430InsertCCF.cp"
                   }
# line 3535 "C430InsertCCF.cp"
                   
# line 3535 "C430InsertCCF.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 3535 "C430InsertCCF.cp"
                   {
# line 3535 "C430InsertCCF.cp"
                       warning_handler();
# line 3535 "C430InsertCCF.cp"
                   }
# line 3535 "C430InsertCCF.cp"
                   
# line 3535 "C430InsertCCF.cp"
               }
# line 3535 "C430InsertCCF.cp"
               
# line 3535 "C430InsertCCF.cp"
           }
# line 3535 "C430InsertCCF.cp"
           

           /*
           ** Generated code ends here.
           */
# line 3535 "C430InsertCCF.cp"
  
                                               
      
           /*
           ** SQL STATEMENT: 30
           ** EXEC SQL EXECUTE insertdata;

           */
# line 3537 "C430InsertCCF.cp"
# line 3537 "C430InsertCCF.cp"
           {
# line 3537 "C430InsertCCF.cp"
                _SQL_CT_HANDLES * _sql;
# line 3537 "C430InsertCCF.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 3537 "C430InsertCCF.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 3537 "C430InsertCCF.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 3537 "C430InsertCCF.cp"
               {
# line 3537 "C430InsertCCF.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 3537 "C430InsertCCF.cp"
                   _sql->stmttype = SQL_EXECUTE;
# line 3537 "C430InsertCCF.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 3537 "C430InsertCCF.cp"
                   _sql->stmtName.fnlen = 10;
# line 3537 "C430InsertCCF.cp"
                   strcpy(_sql->stmtName.first_name, "insertdata");
# line 3537 "C430InsertCCF.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 3537 "C430InsertCCF.cp"
                   {
# line 3537 "C430InsertCCF.cp"
                       _sql->retcode = ct_dynamic(_sql->conn.command, 
# line 3537 "C430InsertCCF.cp"
                           CS_EXECUTE, "insertdata", 10, NULL, CS_UNUSED);
# line 3537 "C430InsertCCF.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 3537 "C430InsertCCF.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 3537 "C430InsertCCF.cp"
                       _sql->retcode = _sqlResults(_sql);
# line 3537 "C430InsertCCF.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 3537 "C430InsertCCF.cp"
                   }
# line 3537 "C430InsertCCF.cp"
                   
# line 3537 "C430InsertCCF.cp"
                   if (sqlca.sqlcode < 0)
# line 3537 "C430InsertCCF.cp"
                   {
# line 3537 "C430InsertCCF.cp"
                       error_handler();
# line 3537 "C430InsertCCF.cp"
                   }
# line 3537 "C430InsertCCF.cp"
                   
# line 3537 "C430InsertCCF.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 3537 "C430InsertCCF.cp"
                   {
# line 3537 "C430InsertCCF.cp"
                       warning_handler();
# line 3537 "C430InsertCCF.cp"
                   }
# line 3537 "C430InsertCCF.cp"
                   
# line 3537 "C430InsertCCF.cp"
               }
# line 3537 "C430InsertCCF.cp"
               
# line 3537 "C430InsertCCF.cp"
           }
# line 3537 "C430InsertCCF.cp"
           

           /*
           ** Generated code ends here.
           */
# line 3537 "C430InsertCCF.cp"


      
           /*
           ** SQL STATEMENT: 31
           ** EXEC SQL DEALLOCATE PREPARE insertdata;

           */
# line 3539 "C430InsertCCF.cp"
# line 3539 "C430InsertCCF.cp"
           {
# line 3539 "C430InsertCCF.cp"
                _SQL_CT_HANDLES * _sql;
# line 3539 "C430InsertCCF.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 3539 "C430InsertCCF.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 3539 "C430InsertCCF.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 3539 "C430InsertCCF.cp"
               {
# line 3539 "C430InsertCCF.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 3539 "C430InsertCCF.cp"
                   _sql->stmttype = SQL_DEALLOCATE_PREPARE;
# line 3539 "C430InsertCCF.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 3539 "C430InsertCCF.cp"
                   _sql->stmtName.fnlen = 10;
# line 3539 "C430InsertCCF.cp"
                   strcpy(_sql->stmtName.first_name, "insertdata");
# line 3539 "C430InsertCCF.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 3539 "C430InsertCCF.cp"
                   {
# line 3539 "C430InsertCCF.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 3539 "C430InsertCCF.cp"
                   }
# line 3539 "C430InsertCCF.cp"
                   
# line 3539 "C430InsertCCF.cp"
                   if (sqlca.sqlcode < 0)
# line 3539 "C430InsertCCF.cp"
                   {
# line 3539 "C430InsertCCF.cp"
                       error_handler();
# line 3539 "C430InsertCCF.cp"
                   }
# line 3539 "C430InsertCCF.cp"
                   
# line 3539 "C430InsertCCF.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 3539 "C430InsertCCF.cp"
                   {
# line 3539 "C430InsertCCF.cp"
                       warning_handler();
# line 3539 "C430InsertCCF.cp"
                   }
# line 3539 "C430InsertCCF.cp"
                   
# line 3539 "C430InsertCCF.cp"
               }
# line 3539 "C430InsertCCF.cp"
               
# line 3539 "C430InsertCCF.cp"
           }
# line 3539 "C430InsertCCF.cp"
           

           /*
           ** Generated code ends here.
           */
# line 3539 "C430InsertCCF.cp"

                                      
      
           /*
           ** SQL STATEMENT: 32
           ** EXEC SQL COMMIT WORK;

           */
# line 3541 "C430InsertCCF.cp"
# line 3541 "C430InsertCCF.cp"
           {
# line 3541 "C430InsertCCF.cp"
                _SQL_CT_HANDLES * _sql;
# line 3541 "C430InsertCCF.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 3541 "C430InsertCCF.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 3541 "C430InsertCCF.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 3541 "C430InsertCCF.cp"
               {
# line 3541 "C430InsertCCF.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 3541 "C430InsertCCF.cp"
                   _sql->stmttype = SQL_TRANS;
# line 3541 "C430InsertCCF.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 3541 "C430InsertCCF.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 3541 "C430InsertCCF.cp"
                   {
# line 3541 "C430InsertCCF.cp"
                       _sql->retcode = ct_command(_sql->conn.command, 
# line 3541 "C430InsertCCF.cp"
                           CS_LANG_CMD, "COMMIT WORK", 11, CS_UNUSED);
# line 3541 "C430InsertCCF.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 3541 "C430InsertCCF.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 3541 "C430InsertCCF.cp"
                       _sql->retcode = _sqlResults(_sql);
# line 3541 "C430InsertCCF.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 3541 "C430InsertCCF.cp"
                   }
# line 3541 "C430InsertCCF.cp"
                   
# line 3541 "C430InsertCCF.cp"
                   if (sqlca.sqlcode < 0)
# line 3541 "C430InsertCCF.cp"
                   {
# line 3541 "C430InsertCCF.cp"
                       error_handler();
# line 3541 "C430InsertCCF.cp"
                   }
# line 3541 "C430InsertCCF.cp"
                   
# line 3541 "C430InsertCCF.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 3541 "C430InsertCCF.cp"
                   {
# line 3541 "C430InsertCCF.cp"
                       warning_handler();
# line 3541 "C430InsertCCF.cp"
                   }
# line 3541 "C430InsertCCF.cp"
                   
# line 3541 "C430InsertCCF.cp"
               }
# line 3541 "C430InsertCCF.cp"
               
# line 3541 "C430InsertCCF.cp"
           }
# line 3541 "C430InsertCCF.cp"
           

           /*
           ** Generated code ends here.
           */
# line 3541 "C430InsertCCF.cp"


   } 

   /* Elimina el espacio reservado para los Registros previamente
      recuperados del Archivo CCF. */

   for(iCountRec = 0; iCountRec < iNumRecords; iCountRec++)

      free(psRecords[iCountRec]);

   free(psRecords);

   return STDEXIT;
}

           /*
           ** Generated code begins here.
           */
# line 3556 "C430InsertCCF.cp"

           /*
           ** Generated code ends here.
           */
# line 3556 "C430InsertCCF.cp"
