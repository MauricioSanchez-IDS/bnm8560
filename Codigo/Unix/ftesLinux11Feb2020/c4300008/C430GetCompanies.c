
/*
** Generated code begins here.
*/
# line 1 "C430GetCompanies.cp"

/*
** This file was generated on Wed Mar 25 07:25:27 2015
**  by Sybase Embedded SQL Preprocessor Sybase ESQL/C Precompiler/15.7/P-EBF227
** 38 SP112/DRV.15.7.0.11/Linux x86_64/Linux 2.6.18-128.el5 x86_64/BUILD1570-03
** 5/64bit/OPT/Fri Apr 18 06:53:39 2014
*/
# line 1 "C430GetCompanies.cp"
# line 1 "C430GetCompanies.cp"
#define _SQL_SCOPE extern
# line 1 "C430GetCompanies.cp"
#include <sybhesql.h>

/*
** Generated code ends here.
*/
# line 1 "C430GetCompanies.cp"
/* NOMBRE       : C430GetCompanies                                           */
/* DESCRIPCION	: Permite la recuperacion de las Empreas que se encuentren   */
/*                bajo el esquema de Tarjeta Corporativa.                    */
/* PARAMETROS 	:                                                            */
/*    argv[1] = Usuario de Base De Datos                                     */
/*    argv[2] = Password de Base de Datos                                    */
/*    argv[3] = Servidor donde se encuentra la Base de Datos                 */
/*    argv[4] = Tipo de Empresa a Analizar:                                  */
/*                 0 - Proceso Diario.                                       */
/*                 1 - Proceso Por Corte.                                    */
/*    argv[5] = Fecha de Procesamiento (Opcional).                           */
/* SALIDAS      : Empresas bajo esquema de Tarjeta Corporativa.              */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 19/08/2003                                                 */
/* CONTROL DE                                                                */
/* VERSIONES    : V.1.0                                                      */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     19/08/2003     Primera Version         */
/* Copyright Derechos Reservados Banamex S.A. de C.V 2003a                   */
/*   Observaciones:                                                          */
/*                                                                           */

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "C430GetCompanies.h"


/*
** SQL STATEMENT: 1
** EXEC SQL INCLUDE SQLCA;

*/
# line 30 "C430GetCompanies.cp"
# line 30 "C430GetCompanies.cp"
SQLCA sqlca;

/*
** Generated code ends here.
*/
# line 30 "C430GetCompanies.cp"


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
# line 40 "C430GetCompanies.cp"

      char sUsername[LEN30+1];	 /* Usuario. */
      char sPassword[LEN30+1];   /* Password. */
      char sServer[LEN30+1];     /* Servidor. */
   
           /*
           ** SQL STATEMENT: 2
           ** EXEC SQL END DECLARE SECTION;

           */
# line 44 "C430GetCompanies.cp"

           /*
           ** Generated code ends here.
           */
# line 44 "C430GetCompanies.cp"



   /* El No. de Parametros pasados a la aplicacion es incorrecto. */

   if(!((argc == 5) || (argc == 6)))   
   {

#ifdef DEBUG1
      printf("\nUse: C430GetCompanies <User> <Password> <Server>\n");
      printf("                   <Process Type> [<Process Date>]\n");
#endif

      exit(ERREXIT);
   }

   /* Definicion de rutinas para manejo de errores y mensajes de
      alerta. */

   
           /*
           ** SQL STATEMENT: 3
           ** EXEC SQL WHENEVER SQLERROR CALL error_handler();
           */
# line 63 "C430GetCompanies.cp"
 
   
           /*
           ** SQL STATEMENT: 4
           ** EXEC SQL WHENEVER SQLWARNING CALL warning_handler();
           */
# line 64 "C430GetCompanies.cp"

   
           /*
           ** SQL STATEMENT: 5
           ** EXEC SQL WHENEVER NOT FOUND CONTINUE;

           */
# line 65 "C430GetCompanies.cp"


   strcpy(sUsername, argv[1]);
   strcpy(sPassword, argv[2]);
   strcpy(sServer, argv[3]);

   /* Conexion al servidor de SYBASE. */

   
           /*
           ** SQL STATEMENT: 6
           ** EXEC SQL CONNECT :sUsername IDENTIFIED BY :sPassword USING :sServer
           ** ;
           */
# line 73 "C430GetCompanies.cp"
# line 73 "C430GetCompanies.cp"
           {
# line 73 "C430GetCompanies.cp"
                _SQL_CT_HANDLES * _sql;
# line 73 "C430GetCompanies.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 73 "C430GetCompanies.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 73 "C430GetCompanies.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 73 "C430GetCompanies.cp"
               {
# line 73 "C430GetCompanies.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 73 "C430GetCompanies.cp"
                   _sql->stmttype = SQL_NONANSI_CONNECT;
# line 73 "C430GetCompanies.cp"
                   _sql->connName.lnlen = CS_NULLTERM;
# line 73 "C430GetCompanies.cp"
                   strcpy(_sql->connName.last_name, sServer);
# line 73 "C430GetCompanies.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 73 "C430GetCompanies.cp"
                   {
# line 73 "C430GetCompanies.cp"
                       if (_sql->doDecl == CS_TRUE)
# line 73 "C430GetCompanies.cp"
                       {
# line 73 "C430GetCompanies.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 73 "C430GetCompanies.cp"
                           {
# line 73 "C430GetCompanies.cp"
                               _sql->retcode = 
# line 73 "C430GetCompanies.cp"
                                   ct_con_props(_sql->conn.connection, CS_SET, 
# line 73 "C430GetCompanies.cp"
                                   CS_USERNAME, sUsername, CS_NULLTERM, NULL);
# line 73 "C430GetCompanies.cp"
                           }
# line 73 "C430GetCompanies.cp"
                           
# line 73 "C430GetCompanies.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 73 "C430GetCompanies.cp"
                           {
# line 73 "C430GetCompanies.cp"
                               _sql->retcode = 
# line 73 "C430GetCompanies.cp"
                                   ct_con_props(_sql->conn.connection, CS_SET, 
# line 73 "C430GetCompanies.cp"
                                   CS_PASSWORD, sPassword, CS_NULLTERM, NULL);
# line 73 "C430GetCompanies.cp"
                           }
# line 73 "C430GetCompanies.cp"
                           
# line 73 "C430GetCompanies.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 73 "C430GetCompanies.cp"
                           {
# line 73 "C430GetCompanies.cp"
                               _sql->retcode = _sqlctdiag(_sql, CS_CLEAR, 
# line 73 "C430GetCompanies.cp"
                                   CS_UNUSED);
# line 73 "C430GetCompanies.cp"
                           }
# line 73 "C430GetCompanies.cp"
                           
# line 73 "C430GetCompanies.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 73 "C430GetCompanies.cp"
                           {
# line 73 "C430GetCompanies.cp"
                               _sql->retcode = 
# line 73 "C430GetCompanies.cp"
                                   ct_capability(_sql->conn.connection, CS_SET,
# line 73 "C430GetCompanies.cp"
                                    CS_CAP_RESPONSE, CS_RES_NOSTRIPBLANKS, 
# line 73 "C430GetCompanies.cp"
                                   &_sql->cstrue);
# line 73 "C430GetCompanies.cp"
                           }
# line 73 "C430GetCompanies.cp"
                           
# line 73 "C430GetCompanies.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 73 "C430GetCompanies.cp"
                           {
# line 73 "C430GetCompanies.cp"
                               _sql->retcode = 
# line 73 "C430GetCompanies.cp"
                                   ct_con_props(_sql->conn.connection, CS_SET, 
# line 73 "C430GetCompanies.cp"
                                   CS_EXTRA_INF, &_sql->cstrue, CS_UNUSED, 
# line 73 "C430GetCompanies.cp"
                                   NULL);
# line 73 "C430GetCompanies.cp"
                           }
# line 73 "C430GetCompanies.cp"
                           
# line 73 "C430GetCompanies.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 73 "C430GetCompanies.cp"
                           {
# line 73 "C430GetCompanies.cp"
                               _sql->retcode = 
# line 73 "C430GetCompanies.cp"
                                   ct_con_props(_sql->conn.connection, CS_SET, 
# line 73 "C430GetCompanies.cp"
                                   CS_ANSI_BINDS, &_sql->cstrue, CS_UNUSED, 
# line 73 "C430GetCompanies.cp"
                                   NULL);
# line 73 "C430GetCompanies.cp"
                           }
# line 73 "C430GetCompanies.cp"
                           
# line 73 "C430GetCompanies.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 73 "C430GetCompanies.cp"
                           {
# line 73 "C430GetCompanies.cp"
                               _sql->retcode = 
# line 73 "C430GetCompanies.cp"
                                   ct_connect(_sql->conn.connection, sServer, 
# line 73 "C430GetCompanies.cp"
                                   CS_NULLTERM);
# line 73 "C430GetCompanies.cp"
                           }
# line 73 "C430GetCompanies.cp"
                           
# line 73 "C430GetCompanies.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 73 "C430GetCompanies.cp"
                           {
# line 73 "C430GetCompanies.cp"
                               _sql->retcode = 
# line 73 "C430GetCompanies.cp"
                                   ct_con_props(_sql->conn.connection, CS_GET, 
# line 73 "C430GetCompanies.cp"
                                   CS_TDS_VERSION, &_sql->temp_int, CS_UNUSED, 
# line 73 "C430GetCompanies.cp"
                                   &_sql->outlen);
# line 73 "C430GetCompanies.cp"
                               if (_sql->retcode == CS_SUCCEED)
# line 73 "C430GetCompanies.cp"
                               {
# line 73 "C430GetCompanies.cp"
                                   if (_sql->temp_int < CS_TDS_50)
# line 73 "C430GetCompanies.cp"
                                   {
# line 73 "C430GetCompanies.cp"
                                       _sqlsetintrerr(_sql, (CS_INT) 
# line 73 "C430GetCompanies.cp"
                                           _SQL_INTRERR_25013);
# line 73 "C430GetCompanies.cp"
                                   }
# line 73 "C430GetCompanies.cp"
                                   
# line 73 "C430GetCompanies.cp"
                               }
# line 73 "C430GetCompanies.cp"
                               
# line 73 "C430GetCompanies.cp"
                           }
# line 73 "C430GetCompanies.cp"
                           
# line 73 "C430GetCompanies.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 73 "C430GetCompanies.cp"
                           {
# line 73 "C430GetCompanies.cp"
                               _sql->retcode = 
# line 73 "C430GetCompanies.cp"
                                   ct_options(_sql->conn.connection, CS_SET, 
# line 73 "C430GetCompanies.cp"
                                   CS_OPT_ANSINULL, &_sql->cstrue, CS_UNUSED, 
# line 73 "C430GetCompanies.cp"
                                   NULL);
# line 73 "C430GetCompanies.cp"
                           }
# line 73 "C430GetCompanies.cp"
                           
# line 73 "C430GetCompanies.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 73 "C430GetCompanies.cp"
                           {
# line 73 "C430GetCompanies.cp"
                               _sql->retcode = 
# line 73 "C430GetCompanies.cp"
                                   ct_options(_sql->conn.connection, CS_SET, 
# line 73 "C430GetCompanies.cp"
                                   CS_OPT_ANSIPERM, &_sql->cstrue, CS_UNUSED, 
# line 73 "C430GetCompanies.cp"
                                   NULL);
# line 73 "C430GetCompanies.cp"
                               _sql->retcode = CS_SUCCEED;
# line 73 "C430GetCompanies.cp"
                           }
# line 73 "C430GetCompanies.cp"
                           
# line 73 "C430GetCompanies.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 73 "C430GetCompanies.cp"
                           {
# line 73 "C430GetCompanies.cp"
                               _sql->retcode = 
# line 73 "C430GetCompanies.cp"
                                   ct_options(_sql->conn.connection, CS_SET, 
# line 73 "C430GetCompanies.cp"
                                   CS_OPT_STR_RTRUNC, &_sql->cstrue, CS_UNUSED,
# line 73 "C430GetCompanies.cp"
                                    NULL);
# line 73 "C430GetCompanies.cp"
                               _sql->retcode = CS_SUCCEED;
# line 73 "C430GetCompanies.cp"
                           }
# line 73 "C430GetCompanies.cp"
                           
# line 73 "C430GetCompanies.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 73 "C430GetCompanies.cp"
                           {
# line 73 "C430GetCompanies.cp"
                               _sql->retcode = 
# line 73 "C430GetCompanies.cp"
                                   ct_options(_sql->conn.connection, CS_SET, 
# line 73 "C430GetCompanies.cp"
                                   CS_OPT_ARITHABORT, &_sql->csfalse, 
# line 73 "C430GetCompanies.cp"
                                   CS_UNUSED, NULL);
# line 73 "C430GetCompanies.cp"
                           }
# line 73 "C430GetCompanies.cp"
                           
# line 73 "C430GetCompanies.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 73 "C430GetCompanies.cp"
                           {
# line 73 "C430GetCompanies.cp"
                               _sql->retcode = 
# line 73 "C430GetCompanies.cp"
                                   ct_options(_sql->conn.connection, CS_SET, 
# line 73 "C430GetCompanies.cp"
                                   CS_OPT_TRUNCIGNORE, &_sql->cstrue, 
# line 73 "C430GetCompanies.cp"
                                   CS_UNUSED, NULL);
# line 73 "C430GetCompanies.cp"
                           }
# line 73 "C430GetCompanies.cp"
                           
# line 73 "C430GetCompanies.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 73 "C430GetCompanies.cp"
                           {
# line 73 "C430GetCompanies.cp"
                               _sql->retcode = 
# line 73 "C430GetCompanies.cp"
                                   ct_options(_sql->conn.connection, CS_SET, 
# line 73 "C430GetCompanies.cp"
                                   CS_OPT_ARITHIGNORE, &_sql->csfalse, 
# line 73 "C430GetCompanies.cp"
                                   CS_UNUSED, NULL);
# line 73 "C430GetCompanies.cp"
                           }
# line 73 "C430GetCompanies.cp"
                           
# line 73 "C430GetCompanies.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 73 "C430GetCompanies.cp"
                           {
# line 73 "C430GetCompanies.cp"
                               _sql->retcode = 
# line 73 "C430GetCompanies.cp"
                                   ct_options(_sql->conn.connection, CS_SET, 
# line 73 "C430GetCompanies.cp"
                                   CS_OPT_ISOLATION, &_sql->Level3, CS_UNUSED, 
# line 73 "C430GetCompanies.cp"
                                   NULL);
# line 73 "C430GetCompanies.cp"
                           }
# line 73 "C430GetCompanies.cp"
                           
# line 73 "C430GetCompanies.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 73 "C430GetCompanies.cp"
                           {
# line 73 "C430GetCompanies.cp"
                               _sql->retcode = 
# line 73 "C430GetCompanies.cp"
                                   ct_options(_sql->conn.connection, CS_SET, 
# line 73 "C430GetCompanies.cp"
                                   CS_OPT_CHAINXACTS, &_sql->cstrue, CS_UNUSED,
# line 73 "C430GetCompanies.cp"
                                    NULL);
# line 73 "C430GetCompanies.cp"
                           }
# line 73 "C430GetCompanies.cp"
                           
# line 73 "C430GetCompanies.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 73 "C430GetCompanies.cp"
                           {
# line 73 "C430GetCompanies.cp"
                               _sql->retcode = 
# line 73 "C430GetCompanies.cp"
                                   ct_options(_sql->conn.connection, CS_SET, 
# line 73 "C430GetCompanies.cp"
                                   CS_OPT_CURCLOSEONXACT, &_sql->cstrue, 
# line 73 "C430GetCompanies.cp"
                                   CS_UNUSED, NULL);
# line 73 "C430GetCompanies.cp"
                           }
# line 73 "C430GetCompanies.cp"
                           
# line 73 "C430GetCompanies.cp"
                           if (_sql->retcode == CS_SUCCEED)
# line 73 "C430GetCompanies.cp"
                           {
# line 73 "C430GetCompanies.cp"
                               _sql->retcode = 
# line 73 "C430GetCompanies.cp"
                                   ct_options(_sql->conn.connection, CS_SET, 
# line 73 "C430GetCompanies.cp"
                                   CS_OPT_QUOTED_IDENT, &_sql->cstrue, 
# line 73 "C430GetCompanies.cp"
                                   CS_UNUSED, NULL);
# line 73 "C430GetCompanies.cp"
                           }
# line 73 "C430GetCompanies.cp"
                           
# line 73 "C430GetCompanies.cp"
                           _sql->retcode = _sqlepilog(_sql);
# line 73 "C430GetCompanies.cp"
                       }
# line 73 "C430GetCompanies.cp"
                       
# line 73 "C430GetCompanies.cp"
                   }
# line 73 "C430GetCompanies.cp"
                   
# line 73 "C430GetCompanies.cp"
                   if (sqlca.sqlcode < 0)
# line 73 "C430GetCompanies.cp"
                   {
# line 73 "C430GetCompanies.cp"
                       error_handler();
# line 73 "C430GetCompanies.cp"
                   }
# line 73 "C430GetCompanies.cp"
                   
# line 73 "C430GetCompanies.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 73 "C430GetCompanies.cp"
                   {
# line 73 "C430GetCompanies.cp"
                       warning_handler();
# line 73 "C430GetCompanies.cp"
                   }
# line 73 "C430GetCompanies.cp"
                   
# line 73 "C430GetCompanies.cp"
               }
# line 73 "C430GetCompanies.cp"
               
# line 73 "C430GetCompanies.cp"
           }
# line 73 "C430GetCompanies.cp"
           

           /*
           ** Generated code ends here.
           */
# line 73 "C430GetCompanies.cp"


   /* Cambio a Base de Datos Sistema Tarjeta Corporativa. */

   
           /*
           ** SQL STATEMENT: 7
           ** EXEC SQL USE M111; 
           */
# line 77 "C430GetCompanies.cp"
# line 77 "C430GetCompanies.cp"
           {
# line 77 "C430GetCompanies.cp"
                _SQL_CT_HANDLES * _sql;
# line 77 "C430GetCompanies.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 77 "C430GetCompanies.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 77 "C430GetCompanies.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 77 "C430GetCompanies.cp"
               {
# line 77 "C430GetCompanies.cp"
                   _sql->stmtIdlen = CS_UNUSED;
# line 77 "C430GetCompanies.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 77 "C430GetCompanies.cp"
                   _sql->stmttype = SQL_MISC;
# line 77 "C430GetCompanies.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 77 "C430GetCompanies.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 77 "C430GetCompanies.cp"
                   {
# line 77 "C430GetCompanies.cp"
                       _sql->retcode = ct_command(_sql->conn.command, 
# line 77 "C430GetCompanies.cp"
                           CS_LANG_CMD, "USE M111", 8, CS_UNUSED);
# line 77 "C430GetCompanies.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 77 "C430GetCompanies.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 77 "C430GetCompanies.cp"
                       _sql->retcode = _sqlResults(_sql);
# line 77 "C430GetCompanies.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 77 "C430GetCompanies.cp"
                   }
# line 77 "C430GetCompanies.cp"
                   
# line 77 "C430GetCompanies.cp"
                   if (sqlca.sqlcode < 0)
# line 77 "C430GetCompanies.cp"
                   {
# line 77 "C430GetCompanies.cp"
                       error_handler();
# line 77 "C430GetCompanies.cp"
                   }
# line 77 "C430GetCompanies.cp"
                   
# line 77 "C430GetCompanies.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 77 "C430GetCompanies.cp"
                   {
# line 77 "C430GetCompanies.cp"
                       warning_handler();
# line 77 "C430GetCompanies.cp"
                   }
# line 77 "C430GetCompanies.cp"
                   
# line 77 "C430GetCompanies.cp"
               }
# line 77 "C430GetCompanies.cp"
               
# line 77 "C430GetCompanies.cp"
           }
# line 77 "C430GetCompanies.cp"
           

           /*
           ** Generated code ends here.
           */
# line 77 "C430GetCompanies.cp"
    

   /* Recuperacion de Empresas. */

   iC430GetComp(argv);

   
           /*
           ** SQL STATEMENT: 8
           ** EXEC SQL COMMIT WORK;

           */
# line 83 "C430GetCompanies.cp"
# line 83 "C430GetCompanies.cp"
           {
# line 83 "C430GetCompanies.cp"
                _SQL_CT_HANDLES * _sql;
# line 83 "C430GetCompanies.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 83 "C430GetCompanies.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 83 "C430GetCompanies.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 83 "C430GetCompanies.cp"
               {
# line 83 "C430GetCompanies.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 83 "C430GetCompanies.cp"
                   _sql->stmttype = SQL_TRANS;
# line 83 "C430GetCompanies.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 83 "C430GetCompanies.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 83 "C430GetCompanies.cp"
                   {
# line 83 "C430GetCompanies.cp"
                       _sql->retcode = ct_command(_sql->conn.command, 
# line 83 "C430GetCompanies.cp"
                           CS_LANG_CMD, "COMMIT WORK", 11, CS_UNUSED);
# line 83 "C430GetCompanies.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 83 "C430GetCompanies.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 83 "C430GetCompanies.cp"
                       _sql->retcode = _sqlResults(_sql);
# line 83 "C430GetCompanies.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 83 "C430GetCompanies.cp"
                   }
# line 83 "C430GetCompanies.cp"
                   
# line 83 "C430GetCompanies.cp"
                   if (sqlca.sqlcode < 0)
# line 83 "C430GetCompanies.cp"
                   {
# line 83 "C430GetCompanies.cp"
                       error_handler();
# line 83 "C430GetCompanies.cp"
                   }
# line 83 "C430GetCompanies.cp"
                   
# line 83 "C430GetCompanies.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 83 "C430GetCompanies.cp"
                   {
# line 83 "C430GetCompanies.cp"
                       warning_handler();
# line 83 "C430GetCompanies.cp"
                   }
# line 83 "C430GetCompanies.cp"
                   
# line 83 "C430GetCompanies.cp"
               }
# line 83 "C430GetCompanies.cp"
               
# line 83 "C430GetCompanies.cp"
           }
# line 83 "C430GetCompanies.cp"
           

           /*
           ** Generated code ends here.
           */
# line 83 "C430GetCompanies.cp"


   
           /*
           ** SQL STATEMENT: 9
           ** EXEC SQL DISCONNECT ALL;

           */
# line 85 "C430GetCompanies.cp"
# line 85 "C430GetCompanies.cp"
           {
# line 85 "C430GetCompanies.cp"
                _SQL_CT_HANDLES * _sql;
# line 85 "C430GetCompanies.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 85 "C430GetCompanies.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 85 "C430GetCompanies.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 85 "C430GetCompanies.cp"
               {
# line 85 "C430GetCompanies.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 85 "C430GetCompanies.cp"
                   _sql->stmttype = SQL_DISCONNECT_ALL;
# line 85 "C430GetCompanies.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 85 "C430GetCompanies.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 85 "C430GetCompanies.cp"
                   {
# line 85 "C430GetCompanies.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 85 "C430GetCompanies.cp"
                   }
# line 85 "C430GetCompanies.cp"
                   
# line 85 "C430GetCompanies.cp"
                   if (sqlca.sqlcode < 0)
# line 85 "C430GetCompanies.cp"
                   {
# line 85 "C430GetCompanies.cp"
                       error_handler();
# line 85 "C430GetCompanies.cp"
                   }
# line 85 "C430GetCompanies.cp"
                   
# line 85 "C430GetCompanies.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 85 "C430GetCompanies.cp"
                   {
# line 85 "C430GetCompanies.cp"
                       warning_handler();
# line 85 "C430GetCompanies.cp"
                   }
# line 85 "C430GetCompanies.cp"
                   
# line 85 "C430GetCompanies.cp"
               }
# line 85 "C430GetCompanies.cp"
               
# line 85 "C430GetCompanies.cp"
           }
# line 85 "C430GetCompanies.cp"
           

           /*
           ** Generated code ends here.
           */
# line 85 "C430GetCompanies.cp"


   exit(STDEXIT);
}

/* NOMBRE       : iC430GetComp                                               */
/* DESCRIPCION	: Recupera las Empresas bajo el esquema de Tarjeta Corpora-  */
/*                tiva de acuerdo con los parametros proporcionados por el   */
/*                usuario.                                                   */
/* PARAMETROS 	:                                                            */
/*    psParams[4] = Tipo de Empresa a Analizar:                              */
/*                 0 - Proceso Diario.                                       */
/*                 1 - Proceso Por Corte.                                    */
/*    psParams[5] = Fecha de Procesamiento (Opcional).                       */
/* SALIDAS      : Estatus de conclusion de la rutina:                        */
/*                0 - Exito.                                                 */
/*                1 - Falla.                                                 */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 19/08/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     19/08/2003     Primera Version         */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
int iC430GetComp(char *psParams[])             
#else                                        
int iC430GetComp(psParams)                         
char *psParams[];                                
#endif                                       
{
   
           /*
           ** SQL STATEMENT: 9
           ** EXEC SQL BEGIN DECLARE SECTION;

           */
# line 118 "C430GetCompanies.cp"


      /* Datos de Empresa. */

      int  iPreffix;		     /* Prefijo del Ejecutivo. */
      int  iBankGroup;               /* No. de Grupo del Banco. */
      int  iCompanyID;               /* Identificador de la Empresa. */
      int  iChargeOffDate;           /* Fecha de Corte (Dia). */
      int  iNumCompanies;            /* No. Total de Empresas a Procesar. */


      /* Fecha del Sistema y componentes. */
 
      char sSystemDate[LEN10+1];   /* Fecha del Sistema. */
      char sProcessDate[LEN8+1];   /* Fecha de Procesamiento de Datos. */ 
      int  iSystemDay;             /* Fecha del Sistema (Dia). */
      int  iSystemMonth;           /* Fecha del Sistema (Mes). */
      int  iSystemYear;            /* Fecha del Sistema (Annio). */


      /* Comando de SQL a ejecutar en la Base de Datos. */

      char sSQLCommand[LEN1000+501];

   
           /*
           ** SQL STATEMENT: 10
           ** EXEC SQL END DECLARE SECTION;

           */
# line 142 "C430GetCompanies.cp"

           /*
           ** Generated code ends here.
           */
# line 142 "C430GetCompanies.cp"



   int  iProcType;               /* Tipo de Procesamiento (Diario / Por Corte). */
   int iCompCount;               /* Contador para Empresas. */
   char sTempNum[LEN10+1];       /* Cadena para conversion de numeros enteros. */
   Company *psCompanies;         /* Conjunto de Empresas a Procesar. */


   /* Inicializacion de Variables. */

   iSystemDay=0;  
   iSystemMonth=0;
   iSystemYear=0;
   strcpy(sSystemDate, EMPSTR);
   strcpy(sProcessDate, EMPSTR);
   strcpy(sSQLCommand, EMPSTR);
   iProcType=0;
   iCompCount=0;


   /* Extraccion de la Fecha del Sistema menos un dia. */

   if(strlen(psParams[5]) > 0)

      strcpy(sProcessDate, psParams[5]);

   /* Si la Fecha de Procesamiento fue definida por el usuario,  tomarla
      como referencia para la extraccion de datos;  de lo contrario,
      tomar la Fecha del Sistema. */

   if(strcmp(sProcessDate, EMPSTR) != 0)
   {
      strcpy(sSQLCommand, "SELECT convert(char(10),");
      strcat(sSQLCommand, " dateadd(dd, -1,");        
      strcat(sSQLCommand, " convert(datetime, \'");   
      strcat(sSQLCommand, sProcessDate);              
      strcat(sSQLCommand, "\')), 101)");              
   } 
   else
   {
      strcpy(sSQLCommand, "SELECT convert(char(10),");
      strcat(sSQLCommand, " dateadd(dd, -1,");        
      strcat(sSQLCommand, " getdate()");              
      strcat(sSQLCommand, "), 101)");                 
   }


   
           /*
           ** SQL STATEMENT: 11
           ** EXEC SQL PREPARE setdate FROM :sSQLCommand;
           */
# line 190 "C430GetCompanies.cp"
# line 190 "C430GetCompanies.cp"
           {
# line 190 "C430GetCompanies.cp"
                _SQL_CT_HANDLES * _sql;
# line 190 "C430GetCompanies.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 190 "C430GetCompanies.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 190 "C430GetCompanies.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 190 "C430GetCompanies.cp"
               {
# line 190 "C430GetCompanies.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 190 "C430GetCompanies.cp"
                   _sql->stmttype = SQL_PREPARE;
# line 190 "C430GetCompanies.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 190 "C430GetCompanies.cp"
                   _sql->stmtName.fnlen = 7;
# line 190 "C430GetCompanies.cp"
                   strcpy(_sql->stmtName.first_name, "setdate");
# line 190 "C430GetCompanies.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 190 "C430GetCompanies.cp"
                   {
# line 190 "C430GetCompanies.cp"
                       _sql->retcode = ct_dynamic(_sql->conn.command, 
# line 190 "C430GetCompanies.cp"
                           CS_PREPARE, "setdate", 7, sSQLCommand, CS_NULLTERM);
# line 190 "C430GetCompanies.cp"
                       
# line 190 "C430GetCompanies.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 190 "C430GetCompanies.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 190 "C430GetCompanies.cp"
                       _sql->resloop = CS_TRUE;
# line 190 "C430GetCompanies.cp"
                       while ((!_sql->hastate) && (_sql->resloop == CS_TRUE) 
# line 190 "C430GetCompanies.cp"
                           && ((_sql->retcode = ct_results(_sql->conn.command, 
# line 190 "C430GetCompanies.cp"
                           &_sql->restype)) == CS_SUCCEED))
# line 190 "C430GetCompanies.cp"
                       {
# line 190 "C430GetCompanies.cp"
                           switch ( _sql->restype )
# line 190 "C430GetCompanies.cp"
                           {
# line 190 "C430GetCompanies.cp"
                           case CS_CMD_FAIL:
# line 190 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 190 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_ALL);
# line 190 "C430GetCompanies.cp"
                           break;
# line 190 "C430GetCompanies.cp"
                           case CS_COMPUTE_RESULT:
# line 190 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 190 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25003);
# line 190 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 190 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 190 "C430GetCompanies.cp"
                           break;
# line 190 "C430GetCompanies.cp"
                           case CS_CURSOR_RESULT:
# line 190 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 190 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25004);
# line 190 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 190 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 190 "C430GetCompanies.cp"
                           break;
# line 190 "C430GetCompanies.cp"
                           case CS_PARAM_RESULT:
# line 190 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 190 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25005);
# line 190 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 190 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 190 "C430GetCompanies.cp"
                           break;
# line 190 "C430GetCompanies.cp"
                           case CS_ROW_RESULT:
# line 190 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 190 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25006);
# line 190 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 190 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 190 "C430GetCompanies.cp"
                           break;
# line 190 "C430GetCompanies.cp"
                           case CS_STATUS_RESULT:
# line 190 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 190 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25009);
# line 190 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 190 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 190 "C430GetCompanies.cp"
                           break;
# line 190 "C430GetCompanies.cp"
                           case CS_DESCRIBE_RESULT:
# line 190 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 190 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25010);
# line 190 "C430GetCompanies.cp"
                           break;
# line 190 "C430GetCompanies.cp"
                           }
# line 190 "C430GetCompanies.cp"
                           
# line 190 "C430GetCompanies.cp"
                       }
# line 190 "C430GetCompanies.cp"
                       
# line 190 "C430GetCompanies.cp"
                       if ((_sql->retcode != CS_END_RESULTS) && (_sql->retcode 
# line 190 "C430GetCompanies.cp"
                           != CS_CANCELED) && (_sql->retcode != 
# line 190 "C430GetCompanies.cp"
                           CS_RET_HAFAILOVER) && (_sql->resloop != CS_FALSE))
# line 190 "C430GetCompanies.cp"
                       {
# line 190 "C430GetCompanies.cp"
                           _sql->retcode = ct_cancel(NULL, _sql->conn.command, 
# line 190 "C430GetCompanies.cp"
                               CS_CANCEL_ALL);
# line 190 "C430GetCompanies.cp"
                           }
# line 190 "C430GetCompanies.cp"
                            else {
# line 190 "C430GetCompanies.cp"
                           if (((_sql->retcode != CS_CANCELED) && 
# line 190 "C430GetCompanies.cp"
                               (_sql->retcode != CS_RET_HAFAILOVER)))
# line 190 "C430GetCompanies.cp"
                           {
# line 190 "C430GetCompanies.cp"
                               _sql->retcode = CS_SUCCEED;
# line 190 "C430GetCompanies.cp"
                           }
# line 190 "C430GetCompanies.cp"
                           
# line 190 "C430GetCompanies.cp"
                       }
# line 190 "C430GetCompanies.cp"
                       
# line 190 "C430GetCompanies.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 190 "C430GetCompanies.cp"
                   }
# line 190 "C430GetCompanies.cp"
                   
# line 190 "C430GetCompanies.cp"
                   if (sqlca.sqlcode < 0)
# line 190 "C430GetCompanies.cp"
                   {
# line 190 "C430GetCompanies.cp"
                       error_handler();
# line 190 "C430GetCompanies.cp"
                   }
# line 190 "C430GetCompanies.cp"
                   
# line 190 "C430GetCompanies.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 190 "C430GetCompanies.cp"
                   {
# line 190 "C430GetCompanies.cp"
                       warning_handler();
# line 190 "C430GetCompanies.cp"
                   }
# line 190 "C430GetCompanies.cp"
                   
# line 190 "C430GetCompanies.cp"
               }
# line 190 "C430GetCompanies.cp"
               
# line 190 "C430GetCompanies.cp"
           }
# line 190 "C430GetCompanies.cp"
           

           /*
           ** Generated code ends here.
           */
# line 190 "C430GetCompanies.cp"

                                           
   
           /*
           ** SQL STATEMENT: 12
           ** EXEC SQL EXECUTE setdate INTO :sSystemDate;
           */
# line 192 "C430GetCompanies.cp"
# line 192 "C430GetCompanies.cp"
           {
# line 192 "C430GetCompanies.cp"
                _SQL_CT_HANDLES * _sql;
# line 192 "C430GetCompanies.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 192 "C430GetCompanies.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 192 "C430GetCompanies.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 192 "C430GetCompanies.cp"
               {
# line 192 "C430GetCompanies.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 192 "C430GetCompanies.cp"
                   _sql->stmttype = SQL_EXECUTE;
# line 192 "C430GetCompanies.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 192 "C430GetCompanies.cp"
                   _sql->stmtName.fnlen = 7;
# line 192 "C430GetCompanies.cp"
                   strcpy(_sql->stmtName.first_name, "setdate");
# line 192 "C430GetCompanies.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 192 "C430GetCompanies.cp"
                   {
# line 192 "C430GetCompanies.cp"
                       _sql->retcode = ct_dynamic(_sql->conn.command, 
# line 192 "C430GetCompanies.cp"
                           CS_EXECUTE, "setdate", 7, NULL, CS_UNUSED);
# line 192 "C430GetCompanies.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 192 "C430GetCompanies.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 192 "C430GetCompanies.cp"
                       _sql->resloop = CS_TRUE;
# line 192 "C430GetCompanies.cp"
                       while ((!_sql->hastate) && (_sql->resloop == CS_TRUE) 
# line 192 "C430GetCompanies.cp"
                           && ((_sql->retcode = ct_results(_sql->conn.command, 
# line 192 "C430GetCompanies.cp"
                           &_sql->restype)) == CS_SUCCEED))
# line 192 "C430GetCompanies.cp"
                       {
# line 192 "C430GetCompanies.cp"
                           switch ( _sql->restype )
# line 192 "C430GetCompanies.cp"
                           {
# line 192 "C430GetCompanies.cp"
                           case CS_COMPUTE_RESULT:
# line 192 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 192 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25003);
# line 192 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 192 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 192 "C430GetCompanies.cp"
                           break;
# line 192 "C430GetCompanies.cp"
                           case CS_CURSOR_RESULT:
# line 192 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 192 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25004);
# line 192 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 192 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 192 "C430GetCompanies.cp"
                           break;
# line 192 "C430GetCompanies.cp"
                           case CS_PARAM_RESULT:
# line 192 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 192 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25005);
# line 192 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 192 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 192 "C430GetCompanies.cp"
                           break;
# line 192 "C430GetCompanies.cp"
                           case CS_ROW_RESULT:
# line 192 "C430GetCompanies.cp"
                               _sql->dfmtCS_CHAR_TYPE.count = 0;
# line 192 "C430GetCompanies.cp"
                               _sql->dfmtCS_CHAR_TYPE.format = 
# line 192 "C430GetCompanies.cp"
                                   (CS_FMT_NULLTERM | CS_FMT_PADBLANK);
# line 192 "C430GetCompanies.cp"
                               _sql->dfmtCS_CHAR_TYPE.maxlength = LEN10+1;
# line 192 "C430GetCompanies.cp"
                                   _sql->retcode = ct_bind(_sql->conn.command, 
# line 192 "C430GetCompanies.cp"
                                       1, &_sql->dfmtCS_CHAR_TYPE, sSystemDate,
# line 192 "C430GetCompanies.cp"
                                        NULL, NULL);
# line 192 "C430GetCompanies.cp"
                               _sql->retcode = ct_fetch(_sql->conn.command, 
# line 192 "C430GetCompanies.cp"
                                   CS_UNUSED, CS_UNUSED, CS_UNUSED, 
# line 192 "C430GetCompanies.cp"
                                   &_sql->rowsread);
# line 192 "C430GetCompanies.cp"
                               _sql->hastate = (_sql->retcode == 
# line 192 "C430GetCompanies.cp"
                                   CS_RET_HAFAILOVER);
# line 192 "C430GetCompanies.cp"
                               if ((_sql->retcode == CS_SUCCEED) || 
# line 192 "C430GetCompanies.cp"
                                   (_sql->retcode == CS_ROW_FAIL))
# line 192 "C430GetCompanies.cp"
                               {
# line 192 "C430GetCompanies.cp"
                                   _sql->retcode = ct_bind(_sql->conn.command, 
# line 192 "C430GetCompanies.cp"
                                       CS_UNUSED, NULL, NULL, NULL, NULL);
# line 192 "C430GetCompanies.cp"
                                   _sql->retcode = ct_fetch(_sql->conn.command,
# line 192 "C430GetCompanies.cp"
                                        CS_UNUSED, CS_UNUSED, CS_UNUSED, 
# line 192 "C430GetCompanies.cp"
                                       &_sql->rowsread);
# line 192 "C430GetCompanies.cp"
                                   _sql->hastate = (_sql->retcode == 
# line 192 "C430GetCompanies.cp"
                                       CS_RET_HAFAILOVER);
# line 192 "C430GetCompanies.cp"
                               }
# line 192 "C430GetCompanies.cp"
                               
# line 192 "C430GetCompanies.cp"
                           break;
# line 192 "C430GetCompanies.cp"
                           case CS_STATUS_RESULT:
# line 192 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 192 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25009);
# line 192 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 192 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 192 "C430GetCompanies.cp"
                           break;
# line 192 "C430GetCompanies.cp"
                           case CS_DESCRIBE_RESULT:
# line 192 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 192 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25010);
# line 192 "C430GetCompanies.cp"
                           break;
# line 192 "C430GetCompanies.cp"
                           }
# line 192 "C430GetCompanies.cp"
                           
# line 192 "C430GetCompanies.cp"
                       }
# line 192 "C430GetCompanies.cp"
                       
# line 192 "C430GetCompanies.cp"
                       if ((_sql->retcode != CS_END_RESULTS) && (_sql->retcode 
# line 192 "C430GetCompanies.cp"
                           != CS_CANCELED) && (_sql->retcode != 
# line 192 "C430GetCompanies.cp"
                           CS_RET_HAFAILOVER) && (_sql->resloop != CS_FALSE))
# line 192 "C430GetCompanies.cp"
                       {
# line 192 "C430GetCompanies.cp"
                           _sql->retcode = ct_cancel(NULL, _sql->conn.command, 
# line 192 "C430GetCompanies.cp"
                               CS_CANCEL_ALL);
# line 192 "C430GetCompanies.cp"
                           }
# line 192 "C430GetCompanies.cp"
                            else {
# line 192 "C430GetCompanies.cp"
                           if (((_sql->retcode != CS_CANCELED) && 
# line 192 "C430GetCompanies.cp"
                               (_sql->retcode != CS_RET_HAFAILOVER)))
# line 192 "C430GetCompanies.cp"
                           {
# line 192 "C430GetCompanies.cp"
                               _sql->retcode = CS_SUCCEED;
# line 192 "C430GetCompanies.cp"
                           }
# line 192 "C430GetCompanies.cp"
                           
# line 192 "C430GetCompanies.cp"
                       }
# line 192 "C430GetCompanies.cp"
                       
# line 192 "C430GetCompanies.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 192 "C430GetCompanies.cp"
                   }
# line 192 "C430GetCompanies.cp"
                   
# line 192 "C430GetCompanies.cp"
                   if (sqlca.sqlcode < 0)
# line 192 "C430GetCompanies.cp"
                   {
# line 192 "C430GetCompanies.cp"
                       error_handler();
# line 192 "C430GetCompanies.cp"
                   }
# line 192 "C430GetCompanies.cp"
                   
# line 192 "C430GetCompanies.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 192 "C430GetCompanies.cp"
                   {
# line 192 "C430GetCompanies.cp"
                       warning_handler();
# line 192 "C430GetCompanies.cp"
                   }
# line 192 "C430GetCompanies.cp"
                   
# line 192 "C430GetCompanies.cp"
               }
# line 192 "C430GetCompanies.cp"
               
# line 192 "C430GetCompanies.cp"
           }
# line 192 "C430GetCompanies.cp"
           

           /*
           ** Generated code ends here.
           */
# line 192 "C430GetCompanies.cp"



   /* Calculo del dia, mes y annio previo a la Fecha del Sistema. */

   strcpy(sSQLCommand, "SELECT datepart(dd,");
   strcat(sSQLCommand, " convert(datetime, \'");
   strcat(sSQLCommand, sSystemDate);
   strcat(sSQLCommand, "\'))");

   
           /*
           ** SQL STATEMENT: 13
           ** EXEC SQL PREPARE setday FROM :sSQLCommand;
           */
# line 202 "C430GetCompanies.cp"
# line 202 "C430GetCompanies.cp"
           {
# line 202 "C430GetCompanies.cp"
                _SQL_CT_HANDLES * _sql;
# line 202 "C430GetCompanies.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 202 "C430GetCompanies.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 202 "C430GetCompanies.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 202 "C430GetCompanies.cp"
               {
# line 202 "C430GetCompanies.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 202 "C430GetCompanies.cp"
                   _sql->stmttype = SQL_PREPARE;
# line 202 "C430GetCompanies.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 202 "C430GetCompanies.cp"
                   _sql->stmtName.fnlen = 6;
# line 202 "C430GetCompanies.cp"
                   strcpy(_sql->stmtName.first_name, "setday");
# line 202 "C430GetCompanies.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 202 "C430GetCompanies.cp"
                   {
# line 202 "C430GetCompanies.cp"
                       _sql->retcode = ct_dynamic(_sql->conn.command, 
# line 202 "C430GetCompanies.cp"
                           CS_PREPARE, "setday", 6, sSQLCommand, CS_NULLTERM);
# line 202 "C430GetCompanies.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 202 "C430GetCompanies.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 202 "C430GetCompanies.cp"
                       _sql->resloop = CS_TRUE;
# line 202 "C430GetCompanies.cp"
                       while ((!_sql->hastate) && (_sql->resloop == CS_TRUE) 
# line 202 "C430GetCompanies.cp"
                           && ((_sql->retcode = ct_results(_sql->conn.command, 
# line 202 "C430GetCompanies.cp"
                           &_sql->restype)) == CS_SUCCEED))
# line 202 "C430GetCompanies.cp"
                       {
# line 202 "C430GetCompanies.cp"
                           switch ( _sql->restype )
# line 202 "C430GetCompanies.cp"
                           {
# line 202 "C430GetCompanies.cp"
                           case CS_CMD_FAIL:
# line 202 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 202 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_ALL);
# line 202 "C430GetCompanies.cp"
                           break;
# line 202 "C430GetCompanies.cp"
                           case CS_COMPUTE_RESULT:
# line 202 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 202 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25003);
# line 202 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 202 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 202 "C430GetCompanies.cp"
                           break;
# line 202 "C430GetCompanies.cp"
                           case CS_CURSOR_RESULT:
# line 202 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 202 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25004);
# line 202 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 202 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 202 "C430GetCompanies.cp"
                           break;
# line 202 "C430GetCompanies.cp"
                           case CS_PARAM_RESULT:
# line 202 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 202 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25005);
# line 202 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 202 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 202 "C430GetCompanies.cp"
                           break;
# line 202 "C430GetCompanies.cp"
                           case CS_ROW_RESULT:
# line 202 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 202 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25006);
# line 202 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 202 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 202 "C430GetCompanies.cp"
                           break;
# line 202 "C430GetCompanies.cp"
                           case CS_STATUS_RESULT:
# line 202 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 202 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25009);
# line 202 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 202 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 202 "C430GetCompanies.cp"
                           break;
# line 202 "C430GetCompanies.cp"
                           case CS_DESCRIBE_RESULT:
# line 202 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 202 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25010);
# line 202 "C430GetCompanies.cp"
                           break;
# line 202 "C430GetCompanies.cp"
                           }
# line 202 "C430GetCompanies.cp"
                           
# line 202 "C430GetCompanies.cp"
                       }
# line 202 "C430GetCompanies.cp"
                       
# line 202 "C430GetCompanies.cp"
                       if ((_sql->retcode != CS_END_RESULTS) && (_sql->retcode 
# line 202 "C430GetCompanies.cp"
                           != CS_CANCELED) && (_sql->retcode != 
# line 202 "C430GetCompanies.cp"
                           CS_RET_HAFAILOVER) && (_sql->resloop != CS_FALSE))
# line 202 "C430GetCompanies.cp"
                       {
# line 202 "C430GetCompanies.cp"
                           _sql->retcode = ct_cancel(NULL, _sql->conn.command, 
# line 202 "C430GetCompanies.cp"
                               CS_CANCEL_ALL);
# line 202 "C430GetCompanies.cp"
                           }
# line 202 "C430GetCompanies.cp"
                            else {
# line 202 "C430GetCompanies.cp"
                           if (((_sql->retcode != CS_CANCELED) && 
# line 202 "C430GetCompanies.cp"
                               (_sql->retcode != CS_RET_HAFAILOVER)))
# line 202 "C430GetCompanies.cp"
                           {
# line 202 "C430GetCompanies.cp"
                               _sql->retcode = CS_SUCCEED;
# line 202 "C430GetCompanies.cp"
                           }
# line 202 "C430GetCompanies.cp"
                           
# line 202 "C430GetCompanies.cp"
                       }
# line 202 "C430GetCompanies.cp"
                       
# line 202 "C430GetCompanies.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 202 "C430GetCompanies.cp"
                   }
# line 202 "C430GetCompanies.cp"
                   
# line 202 "C430GetCompanies.cp"
                   if (sqlca.sqlcode < 0)
# line 202 "C430GetCompanies.cp"
                   {
# line 202 "C430GetCompanies.cp"
                       error_handler();
# line 202 "C430GetCompanies.cp"
                   }
# line 202 "C430GetCompanies.cp"
                   
# line 202 "C430GetCompanies.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 202 "C430GetCompanies.cp"
                   {
# line 202 "C430GetCompanies.cp"
                       warning_handler();
# line 202 "C430GetCompanies.cp"
                   }
# line 202 "C430GetCompanies.cp"
                   
# line 202 "C430GetCompanies.cp"
               }
# line 202 "C430GetCompanies.cp"
               
# line 202 "C430GetCompanies.cp"
           }
# line 202 "C430GetCompanies.cp"
           

           /*
           ** Generated code ends here.
           */
# line 202 "C430GetCompanies.cp"

 
   
           /*
           ** SQL STATEMENT: 14
           ** EXEC SQL EXECUTE setday INTO :iSystemDay;
           */
# line 204 "C430GetCompanies.cp"
# line 204 "C430GetCompanies.cp"
           {
# line 204 "C430GetCompanies.cp"
                _SQL_CT_HANDLES * _sql;
# line 204 "C430GetCompanies.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 204 "C430GetCompanies.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 204 "C430GetCompanies.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 204 "C430GetCompanies.cp"
               {
# line 204 "C430GetCompanies.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 204 "C430GetCompanies.cp"
                   _sql->stmttype = SQL_EXECUTE;
# line 204 "C430GetCompanies.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 204 "C430GetCompanies.cp"
                   _sql->stmtName.fnlen = 6;
# line 204 "C430GetCompanies.cp"
                   strcpy(_sql->stmtName.first_name, "setday");
# line 204 "C430GetCompanies.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 204 "C430GetCompanies.cp"
                   {
# line 204 "C430GetCompanies.cp"
                       _sql->retcode = ct_dynamic(_sql->conn.command, 
# line 204 "C430GetCompanies.cp"
                           CS_EXECUTE, "setday", 6, NULL, CS_UNUSED);
# line 204 "C430GetCompanies.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 204 "C430GetCompanies.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 204 "C430GetCompanies.cp"
                       _sql->resloop = CS_TRUE;
# line 204 "C430GetCompanies.cp"
                       while ((!_sql->hastate) && (_sql->resloop == CS_TRUE) 
# line 204 "C430GetCompanies.cp"
                           && ((_sql->retcode = ct_results(_sql->conn.command, 
# line 204 "C430GetCompanies.cp"
                           &_sql->restype)) == CS_SUCCEED))
# line 204 "C430GetCompanies.cp"
                       {
# line 204 "C430GetCompanies.cp"
                           switch ( _sql->restype )
# line 204 "C430GetCompanies.cp"
                           {
# line 204 "C430GetCompanies.cp"
                           case CS_COMPUTE_RESULT:
# line 204 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 204 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25003);
# line 204 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 204 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 204 "C430GetCompanies.cp"
                           break;
# line 204 "C430GetCompanies.cp"
                           case CS_CURSOR_RESULT:
# line 204 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 204 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25004);
# line 204 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 204 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 204 "C430GetCompanies.cp"
                           break;
# line 204 "C430GetCompanies.cp"
                           case CS_PARAM_RESULT:
# line 204 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 204 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25005);
# line 204 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 204 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 204 "C430GetCompanies.cp"
                           break;
# line 204 "C430GetCompanies.cp"
                           case CS_ROW_RESULT:
# line 204 "C430GetCompanies.cp"
                               _sql->dfmtCS_INT_TYPE.count = 0;
# line 204 "C430GetCompanies.cp"
                                   _sql->retcode = ct_bind(_sql->conn.command, 
# line 204 "C430GetCompanies.cp"
                                       1, &_sql->dfmtCS_INT_TYPE, &iSystemDay, 
# line 204 "C430GetCompanies.cp"
                                       NULL, NULL);
# line 204 "C430GetCompanies.cp"
                               _sql->retcode = ct_fetch(_sql->conn.command, 
# line 204 "C430GetCompanies.cp"
                                   CS_UNUSED, CS_UNUSED, CS_UNUSED, 
# line 204 "C430GetCompanies.cp"
                                   &_sql->rowsread);
# line 204 "C430GetCompanies.cp"
                               _sql->hastate = (_sql->retcode == 
# line 204 "C430GetCompanies.cp"
                                   CS_RET_HAFAILOVER);
# line 204 "C430GetCompanies.cp"
                               if ((_sql->retcode == CS_SUCCEED) || 
# line 204 "C430GetCompanies.cp"
                                   (_sql->retcode == CS_ROW_FAIL))
# line 204 "C430GetCompanies.cp"
                               {
# line 204 "C430GetCompanies.cp"
                                   _sql->retcode = ct_bind(_sql->conn.command, 
# line 204 "C430GetCompanies.cp"
                                       CS_UNUSED, NULL, NULL, NULL, NULL);
# line 204 "C430GetCompanies.cp"
                                   _sql->retcode = ct_fetch(_sql->conn.command,
# line 204 "C430GetCompanies.cp"
                                        CS_UNUSED, CS_UNUSED, CS_UNUSED, 
# line 204 "C430GetCompanies.cp"
                                       &_sql->rowsread);
# line 204 "C430GetCompanies.cp"
                                   _sql->hastate = (_sql->retcode == 
# line 204 "C430GetCompanies.cp"
                                       CS_RET_HAFAILOVER);
# line 204 "C430GetCompanies.cp"
                               }
# line 204 "C430GetCompanies.cp"
                               
# line 204 "C430GetCompanies.cp"
                           break;
# line 204 "C430GetCompanies.cp"
                           case CS_STATUS_RESULT:
# line 204 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 204 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25009);
# line 204 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 204 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 204 "C430GetCompanies.cp"
                           break;
# line 204 "C430GetCompanies.cp"
                           case CS_DESCRIBE_RESULT:
# line 204 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 204 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25010);
# line 204 "C430GetCompanies.cp"
                           break;
# line 204 "C430GetCompanies.cp"
                           }
# line 204 "C430GetCompanies.cp"
                           
# line 204 "C430GetCompanies.cp"
                       }
# line 204 "C430GetCompanies.cp"
                       
# line 204 "C430GetCompanies.cp"
                       if ((_sql->retcode != CS_END_RESULTS) && (_sql->retcode 
# line 204 "C430GetCompanies.cp"
                           != CS_CANCELED) && (_sql->retcode != 
# line 204 "C430GetCompanies.cp"
                           CS_RET_HAFAILOVER) && (_sql->resloop != CS_FALSE))
# line 204 "C430GetCompanies.cp"
                       {
# line 204 "C430GetCompanies.cp"
                           _sql->retcode = ct_cancel(NULL, _sql->conn.command, 
# line 204 "C430GetCompanies.cp"
                               CS_CANCEL_ALL);
# line 204 "C430GetCompanies.cp"
                           }
# line 204 "C430GetCompanies.cp"
                            else {
# line 204 "C430GetCompanies.cp"
                           if (((_sql->retcode != CS_CANCELED) && 
# line 204 "C430GetCompanies.cp"
                               (_sql->retcode != CS_RET_HAFAILOVER)))
# line 204 "C430GetCompanies.cp"
                           {
# line 204 "C430GetCompanies.cp"
                               _sql->retcode = CS_SUCCEED;
# line 204 "C430GetCompanies.cp"
                           }
# line 204 "C430GetCompanies.cp"
                           
# line 204 "C430GetCompanies.cp"
                       }
# line 204 "C430GetCompanies.cp"
                       
# line 204 "C430GetCompanies.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 204 "C430GetCompanies.cp"
                   }
# line 204 "C430GetCompanies.cp"
                   
# line 204 "C430GetCompanies.cp"
                   if (sqlca.sqlcode < 0)
# line 204 "C430GetCompanies.cp"
                   {
# line 204 "C430GetCompanies.cp"
                       error_handler();
# line 204 "C430GetCompanies.cp"
                   }
# line 204 "C430GetCompanies.cp"
                   
# line 204 "C430GetCompanies.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 204 "C430GetCompanies.cp"
                   {
# line 204 "C430GetCompanies.cp"
                       warning_handler();
# line 204 "C430GetCompanies.cp"
                   }
# line 204 "C430GetCompanies.cp"
                   
# line 204 "C430GetCompanies.cp"
               }
# line 204 "C430GetCompanies.cp"
               
# line 204 "C430GetCompanies.cp"
           }
# line 204 "C430GetCompanies.cp"
           

           /*
           ** Generated code ends here.
           */
# line 204 "C430GetCompanies.cp"

 
   strcpy(sSQLCommand, "SELECT datepart(mm,");
   strcat(sSQLCommand, " convert(datetime, \'");
   strcat(sSQLCommand, sSystemDate);
   strcat(sSQLCommand, "\'))");
 
   
           /*
           ** SQL STATEMENT: 15
           ** EXEC SQL PREPARE setmonth FROM :sSQLCommand;
           */
# line 211 "C430GetCompanies.cp"
# line 211 "C430GetCompanies.cp"
           {
# line 211 "C430GetCompanies.cp"
                _SQL_CT_HANDLES * _sql;
# line 211 "C430GetCompanies.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 211 "C430GetCompanies.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 211 "C430GetCompanies.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 211 "C430GetCompanies.cp"
               {
# line 211 "C430GetCompanies.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 211 "C430GetCompanies.cp"
                   _sql->stmttype = SQL_PREPARE;
# line 211 "C430GetCompanies.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 211 "C430GetCompanies.cp"
                   _sql->stmtName.fnlen = 8;
# line 211 "C430GetCompanies.cp"
                   strcpy(_sql->stmtName.first_name, "setmonth");
# line 211 "C430GetCompanies.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 211 "C430GetCompanies.cp"
                   {
# line 211 "C430GetCompanies.cp"
                       _sql->retcode = ct_dynamic(_sql->conn.command, 
# line 211 "C430GetCompanies.cp"
                           CS_PREPARE, "setmonth", 8, sSQLCommand, 
# line 211 "C430GetCompanies.cp"
                           CS_NULLTERM);
# line 211 "C430GetCompanies.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 211 "C430GetCompanies.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 211 "C430GetCompanies.cp"
                       _sql->resloop = CS_TRUE;
# line 211 "C430GetCompanies.cp"
                       while ((!_sql->hastate) && (_sql->resloop == CS_TRUE) 
# line 211 "C430GetCompanies.cp"
                           && ((_sql->retcode = ct_results(_sql->conn.command, 
# line 211 "C430GetCompanies.cp"
                           &_sql->restype)) == CS_SUCCEED))
# line 211 "C430GetCompanies.cp"
                       {
# line 211 "C430GetCompanies.cp"
                           switch ( _sql->restype )
# line 211 "C430GetCompanies.cp"
                           {
# line 211 "C430GetCompanies.cp"
                           case CS_CMD_FAIL:
# line 211 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 211 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_ALL);
# line 211 "C430GetCompanies.cp"
                           break;
# line 211 "C430GetCompanies.cp"
                           case CS_COMPUTE_RESULT:
# line 211 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 211 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25003);
# line 211 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 211 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 211 "C430GetCompanies.cp"
                           break;
# line 211 "C430GetCompanies.cp"
                           case CS_CURSOR_RESULT:
# line 211 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 211 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25004);
# line 211 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 211 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 211 "C430GetCompanies.cp"
                           break;
# line 211 "C430GetCompanies.cp"
                           case CS_PARAM_RESULT:
# line 211 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 211 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25005);
# line 211 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 211 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 211 "C430GetCompanies.cp"
                           break;
# line 211 "C430GetCompanies.cp"
                           case CS_ROW_RESULT:
# line 211 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 211 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25006);
# line 211 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 211 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 211 "C430GetCompanies.cp"
                           break;
# line 211 "C430GetCompanies.cp"
                           case CS_STATUS_RESULT:
# line 211 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 211 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25009);
# line 211 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 211 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 211 "C430GetCompanies.cp"
                           break;
# line 211 "C430GetCompanies.cp"
                           case CS_DESCRIBE_RESULT:
# line 211 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 211 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25010);
# line 211 "C430GetCompanies.cp"
                           break;
# line 211 "C430GetCompanies.cp"
                           }
# line 211 "C430GetCompanies.cp"
                           
# line 211 "C430GetCompanies.cp"
                       }
# line 211 "C430GetCompanies.cp"
                       
# line 211 "C430GetCompanies.cp"
                       if ((_sql->retcode != CS_END_RESULTS) && (_sql->retcode 
# line 211 "C430GetCompanies.cp"
                           != CS_CANCELED) && (_sql->retcode != 
# line 211 "C430GetCompanies.cp"
                           CS_RET_HAFAILOVER) && (_sql->resloop != CS_FALSE))
# line 211 "C430GetCompanies.cp"
                       {
# line 211 "C430GetCompanies.cp"
                           _sql->retcode = ct_cancel(NULL, _sql->conn.command, 
# line 211 "C430GetCompanies.cp"
                               CS_CANCEL_ALL);
# line 211 "C430GetCompanies.cp"
                           }
# line 211 "C430GetCompanies.cp"
                            else {
# line 211 "C430GetCompanies.cp"
                           if (((_sql->retcode != CS_CANCELED) && 
# line 211 "C430GetCompanies.cp"
                               (_sql->retcode != CS_RET_HAFAILOVER)))
# line 211 "C430GetCompanies.cp"
                           {
# line 211 "C430GetCompanies.cp"
                               _sql->retcode = CS_SUCCEED;
# line 211 "C430GetCompanies.cp"
                           }
# line 211 "C430GetCompanies.cp"
                           
# line 211 "C430GetCompanies.cp"
                       }
# line 211 "C430GetCompanies.cp"
                       
# line 211 "C430GetCompanies.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 211 "C430GetCompanies.cp"
                   }
# line 211 "C430GetCompanies.cp"
                   
# line 211 "C430GetCompanies.cp"
                   if (sqlca.sqlcode < 0)
# line 211 "C430GetCompanies.cp"
                   {
# line 211 "C430GetCompanies.cp"
                       error_handler();
# line 211 "C430GetCompanies.cp"
                   }
# line 211 "C430GetCompanies.cp"
                   
# line 211 "C430GetCompanies.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 211 "C430GetCompanies.cp"
                   {
# line 211 "C430GetCompanies.cp"
                       warning_handler();
# line 211 "C430GetCompanies.cp"
                   }
# line 211 "C430GetCompanies.cp"
                   
# line 211 "C430GetCompanies.cp"
               }
# line 211 "C430GetCompanies.cp"
               
# line 211 "C430GetCompanies.cp"
           }
# line 211 "C430GetCompanies.cp"
           

           /*
           ** Generated code ends here.
           */
# line 211 "C430GetCompanies.cp"

 
   
           /*
           ** SQL STATEMENT: 16
           ** EXEC SQL EXECUTE setmonth INTO :iSystemMonth;
           */
# line 213 "C430GetCompanies.cp"
# line 213 "C430GetCompanies.cp"
           {
# line 213 "C430GetCompanies.cp"
                _SQL_CT_HANDLES * _sql;
# line 213 "C430GetCompanies.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 213 "C430GetCompanies.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 213 "C430GetCompanies.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 213 "C430GetCompanies.cp"
               {
# line 213 "C430GetCompanies.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 213 "C430GetCompanies.cp"
                   _sql->stmttype = SQL_EXECUTE;
# line 213 "C430GetCompanies.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 213 "C430GetCompanies.cp"
                   _sql->stmtName.fnlen = 8;
# line 213 "C430GetCompanies.cp"
                   strcpy(_sql->stmtName.first_name, "setmonth");
# line 213 "C430GetCompanies.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 213 "C430GetCompanies.cp"
                   {
# line 213 "C430GetCompanies.cp"
                       _sql->retcode = ct_dynamic(_sql->conn.command, 
# line 213 "C430GetCompanies.cp"
                           CS_EXECUTE, "setmonth", 8, NULL, CS_UNUSED);
# line 213 "C430GetCompanies.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 213 "C430GetCompanies.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 213 "C430GetCompanies.cp"
                       _sql->resloop = CS_TRUE;
# line 213 "C430GetCompanies.cp"
                       while ((!_sql->hastate) && (_sql->resloop == CS_TRUE) 
# line 213 "C430GetCompanies.cp"
                           && ((_sql->retcode = ct_results(_sql->conn.command, 
# line 213 "C430GetCompanies.cp"
                           &_sql->restype)) == CS_SUCCEED))
# line 213 "C430GetCompanies.cp"
                       {
# line 213 "C430GetCompanies.cp"
                           switch ( _sql->restype )
# line 213 "C430GetCompanies.cp"
                           {
# line 213 "C430GetCompanies.cp"
                           case CS_COMPUTE_RESULT:
# line 213 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 213 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25003);
# line 213 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 213 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 213 "C430GetCompanies.cp"
                           break;
# line 213 "C430GetCompanies.cp"
                           case CS_CURSOR_RESULT:
# line 213 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 213 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25004);
# line 213 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 213 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 213 "C430GetCompanies.cp"
                           break;
# line 213 "C430GetCompanies.cp"
                           case CS_PARAM_RESULT:
# line 213 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 213 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25005);
# line 213 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 213 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 213 "C430GetCompanies.cp"
                           break;
# line 213 "C430GetCompanies.cp"
                           case CS_ROW_RESULT:
# line 213 "C430GetCompanies.cp"
                               _sql->dfmtCS_INT_TYPE.count = 0;
# line 213 "C430GetCompanies.cp"
                                   _sql->retcode = ct_bind(_sql->conn.command, 
# line 213 "C430GetCompanies.cp"
                                       1, &_sql->dfmtCS_INT_TYPE, 
# line 213 "C430GetCompanies.cp"
                                       &iSystemMonth, NULL, NULL);
# line 213 "C430GetCompanies.cp"
                               _sql->retcode = ct_fetch(_sql->conn.command, 
# line 213 "C430GetCompanies.cp"
                                   CS_UNUSED, CS_UNUSED, CS_UNUSED, 
# line 213 "C430GetCompanies.cp"
                                   &_sql->rowsread);
# line 213 "C430GetCompanies.cp"
                               _sql->hastate = (_sql->retcode == 
# line 213 "C430GetCompanies.cp"
                                   CS_RET_HAFAILOVER);
# line 213 "C430GetCompanies.cp"
                               if ((_sql->retcode == CS_SUCCEED) || 
# line 213 "C430GetCompanies.cp"
                                   (_sql->retcode == CS_ROW_FAIL))
# line 213 "C430GetCompanies.cp"
                               {
# line 213 "C430GetCompanies.cp"
                                   _sql->retcode = ct_bind(_sql->conn.command, 
# line 213 "C430GetCompanies.cp"
                                       CS_UNUSED, NULL, NULL, NULL, NULL);
# line 213 "C430GetCompanies.cp"
                                   _sql->retcode = ct_fetch(_sql->conn.command,
# line 213 "C430GetCompanies.cp"
                                        CS_UNUSED, CS_UNUSED, CS_UNUSED, 
# line 213 "C430GetCompanies.cp"
                                       &_sql->rowsread);
# line 213 "C430GetCompanies.cp"
                                   _sql->hastate = (_sql->retcode == 
# line 213 "C430GetCompanies.cp"
                                       CS_RET_HAFAILOVER);
# line 213 "C430GetCompanies.cp"
                               }
# line 213 "C430GetCompanies.cp"
                               
# line 213 "C430GetCompanies.cp"
                           break;
# line 213 "C430GetCompanies.cp"
                           case CS_STATUS_RESULT:
# line 213 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 213 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25009);
# line 213 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 213 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 213 "C430GetCompanies.cp"
                           break;
# line 213 "C430GetCompanies.cp"
                           case CS_DESCRIBE_RESULT:
# line 213 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 213 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25010);
# line 213 "C430GetCompanies.cp"
                           break;
# line 213 "C430GetCompanies.cp"
                           }
# line 213 "C430GetCompanies.cp"
                           
# line 213 "C430GetCompanies.cp"
                       }
# line 213 "C430GetCompanies.cp"
                       
# line 213 "C430GetCompanies.cp"
                       if ((_sql->retcode != CS_END_RESULTS) && (_sql->retcode 
# line 213 "C430GetCompanies.cp"
                           != CS_CANCELED) && (_sql->retcode != 
# line 213 "C430GetCompanies.cp"
                           CS_RET_HAFAILOVER) && (_sql->resloop != CS_FALSE))
# line 213 "C430GetCompanies.cp"
                       {
# line 213 "C430GetCompanies.cp"
                           _sql->retcode = ct_cancel(NULL, _sql->conn.command, 
# line 213 "C430GetCompanies.cp"
                               CS_CANCEL_ALL);
# line 213 "C430GetCompanies.cp"
                           }
# line 213 "C430GetCompanies.cp"
                            else {
# line 213 "C430GetCompanies.cp"
                           if (((_sql->retcode != CS_CANCELED) && 
# line 213 "C430GetCompanies.cp"
                               (_sql->retcode != CS_RET_HAFAILOVER)))
# line 213 "C430GetCompanies.cp"
                           {
# line 213 "C430GetCompanies.cp"
                               _sql->retcode = CS_SUCCEED;
# line 213 "C430GetCompanies.cp"
                           }
# line 213 "C430GetCompanies.cp"
                           
# line 213 "C430GetCompanies.cp"
                       }
# line 213 "C430GetCompanies.cp"
                       
# line 213 "C430GetCompanies.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 213 "C430GetCompanies.cp"
                   }
# line 213 "C430GetCompanies.cp"
                   
# line 213 "C430GetCompanies.cp"
                   if (sqlca.sqlcode < 0)
# line 213 "C430GetCompanies.cp"
                   {
# line 213 "C430GetCompanies.cp"
                       error_handler();
# line 213 "C430GetCompanies.cp"
                   }
# line 213 "C430GetCompanies.cp"
                   
# line 213 "C430GetCompanies.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 213 "C430GetCompanies.cp"
                   {
# line 213 "C430GetCompanies.cp"
                       warning_handler();
# line 213 "C430GetCompanies.cp"
                   }
# line 213 "C430GetCompanies.cp"
                   
# line 213 "C430GetCompanies.cp"
               }
# line 213 "C430GetCompanies.cp"
               
# line 213 "C430GetCompanies.cp"
           }
# line 213 "C430GetCompanies.cp"
           

           /*
           ** Generated code ends here.
           */
# line 213 "C430GetCompanies.cp"


   strcpy(sSQLCommand, "SELECT datepart(yy,");
   strcat(sSQLCommand, " convert(datetime, \'");
   strcat(sSQLCommand, sSystemDate);
   strcat(sSQLCommand, "\'))");
 
   
           /*
           ** SQL STATEMENT: 17
           ** EXEC SQL PREPARE setyear FROM :sSQLCommand;
           */
# line 220 "C430GetCompanies.cp"
# line 220 "C430GetCompanies.cp"
           {
# line 220 "C430GetCompanies.cp"
                _SQL_CT_HANDLES * _sql;
# line 220 "C430GetCompanies.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 220 "C430GetCompanies.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 220 "C430GetCompanies.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 220 "C430GetCompanies.cp"
               {
# line 220 "C430GetCompanies.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 220 "C430GetCompanies.cp"
                   _sql->stmttype = SQL_PREPARE;
# line 220 "C430GetCompanies.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 220 "C430GetCompanies.cp"
                   _sql->stmtName.fnlen = 7;
# line 220 "C430GetCompanies.cp"
                   strcpy(_sql->stmtName.first_name, "setyear");
# line 220 "C430GetCompanies.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 220 "C430GetCompanies.cp"
                   {
# line 220 "C430GetCompanies.cp"
                       _sql->retcode = ct_dynamic(_sql->conn.command, 
# line 220 "C430GetCompanies.cp"
                           CS_PREPARE, "setyear", 7, sSQLCommand, CS_NULLTERM);
# line 220 "C430GetCompanies.cp"
                       
# line 220 "C430GetCompanies.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 220 "C430GetCompanies.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 220 "C430GetCompanies.cp"
                       _sql->resloop = CS_TRUE;
# line 220 "C430GetCompanies.cp"
                       while ((!_sql->hastate) && (_sql->resloop == CS_TRUE) 
# line 220 "C430GetCompanies.cp"
                           && ((_sql->retcode = ct_results(_sql->conn.command, 
# line 220 "C430GetCompanies.cp"
                           &_sql->restype)) == CS_SUCCEED))
# line 220 "C430GetCompanies.cp"
                       {
# line 220 "C430GetCompanies.cp"
                           switch ( _sql->restype )
# line 220 "C430GetCompanies.cp"
                           {
# line 220 "C430GetCompanies.cp"
                           case CS_CMD_FAIL:
# line 220 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 220 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_ALL);
# line 220 "C430GetCompanies.cp"
                           break;
# line 220 "C430GetCompanies.cp"
                           case CS_COMPUTE_RESULT:
# line 220 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 220 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25003);
# line 220 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 220 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 220 "C430GetCompanies.cp"
                           break;
# line 220 "C430GetCompanies.cp"
                           case CS_CURSOR_RESULT:
# line 220 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 220 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25004);
# line 220 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 220 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 220 "C430GetCompanies.cp"
                           break;
# line 220 "C430GetCompanies.cp"
                           case CS_PARAM_RESULT:
# line 220 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 220 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25005);
# line 220 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 220 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 220 "C430GetCompanies.cp"
                           break;
# line 220 "C430GetCompanies.cp"
                           case CS_ROW_RESULT:
# line 220 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 220 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25006);
# line 220 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 220 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 220 "C430GetCompanies.cp"
                           break;
# line 220 "C430GetCompanies.cp"
                           case CS_STATUS_RESULT:
# line 220 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 220 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25009);
# line 220 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 220 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 220 "C430GetCompanies.cp"
                           break;
# line 220 "C430GetCompanies.cp"
                           case CS_DESCRIBE_RESULT:
# line 220 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 220 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25010);
# line 220 "C430GetCompanies.cp"
                           break;
# line 220 "C430GetCompanies.cp"
                           }
# line 220 "C430GetCompanies.cp"
                           
# line 220 "C430GetCompanies.cp"
                       }
# line 220 "C430GetCompanies.cp"
                       
# line 220 "C430GetCompanies.cp"
                       if ((_sql->retcode != CS_END_RESULTS) && (_sql->retcode 
# line 220 "C430GetCompanies.cp"
                           != CS_CANCELED) && (_sql->retcode != 
# line 220 "C430GetCompanies.cp"
                           CS_RET_HAFAILOVER) && (_sql->resloop != CS_FALSE))
# line 220 "C430GetCompanies.cp"
                       {
# line 220 "C430GetCompanies.cp"
                           _sql->retcode = ct_cancel(NULL, _sql->conn.command, 
# line 220 "C430GetCompanies.cp"
                               CS_CANCEL_ALL);
# line 220 "C430GetCompanies.cp"
                           }
# line 220 "C430GetCompanies.cp"
                            else {
# line 220 "C430GetCompanies.cp"
                           if (((_sql->retcode != CS_CANCELED) && 
# line 220 "C430GetCompanies.cp"
                               (_sql->retcode != CS_RET_HAFAILOVER)))
# line 220 "C430GetCompanies.cp"
                           {
# line 220 "C430GetCompanies.cp"
                               _sql->retcode = CS_SUCCEED;
# line 220 "C430GetCompanies.cp"
                           }
# line 220 "C430GetCompanies.cp"
                           
# line 220 "C430GetCompanies.cp"
                       }
# line 220 "C430GetCompanies.cp"
                       
# line 220 "C430GetCompanies.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 220 "C430GetCompanies.cp"
                   }
# line 220 "C430GetCompanies.cp"
                   
# line 220 "C430GetCompanies.cp"
                   if (sqlca.sqlcode < 0)
# line 220 "C430GetCompanies.cp"
                   {
# line 220 "C430GetCompanies.cp"
                       error_handler();
# line 220 "C430GetCompanies.cp"
                   }
# line 220 "C430GetCompanies.cp"
                   
# line 220 "C430GetCompanies.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 220 "C430GetCompanies.cp"
                   {
# line 220 "C430GetCompanies.cp"
                       warning_handler();
# line 220 "C430GetCompanies.cp"
                   }
# line 220 "C430GetCompanies.cp"
                   
# line 220 "C430GetCompanies.cp"
               }
# line 220 "C430GetCompanies.cp"
               
# line 220 "C430GetCompanies.cp"
           }
# line 220 "C430GetCompanies.cp"
           

           /*
           ** Generated code ends here.
           */
# line 220 "C430GetCompanies.cp"

 
   
           /*
           ** SQL STATEMENT: 18
           ** EXEC SQL EXECUTE setyear INTO :iSystemYear;
           */
# line 222 "C430GetCompanies.cp"
# line 222 "C430GetCompanies.cp"
           {
# line 222 "C430GetCompanies.cp"
                _SQL_CT_HANDLES * _sql;
# line 222 "C430GetCompanies.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 222 "C430GetCompanies.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 222 "C430GetCompanies.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 222 "C430GetCompanies.cp"
               {
# line 222 "C430GetCompanies.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 222 "C430GetCompanies.cp"
                   _sql->stmttype = SQL_EXECUTE;
# line 222 "C430GetCompanies.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 222 "C430GetCompanies.cp"
                   _sql->stmtName.fnlen = 7;
# line 222 "C430GetCompanies.cp"
                   strcpy(_sql->stmtName.first_name, "setyear");
# line 222 "C430GetCompanies.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 222 "C430GetCompanies.cp"
                   {
# line 222 "C430GetCompanies.cp"
                       _sql->retcode = ct_dynamic(_sql->conn.command, 
# line 222 "C430GetCompanies.cp"
                           CS_EXECUTE, "setyear", 7, NULL, CS_UNUSED);
# line 222 "C430GetCompanies.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 222 "C430GetCompanies.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 222 "C430GetCompanies.cp"
                       _sql->resloop = CS_TRUE;
# line 222 "C430GetCompanies.cp"
                       while ((!_sql->hastate) && (_sql->resloop == CS_TRUE) 
# line 222 "C430GetCompanies.cp"
                           && ((_sql->retcode = ct_results(_sql->conn.command, 
# line 222 "C430GetCompanies.cp"
                           &_sql->restype)) == CS_SUCCEED))
# line 222 "C430GetCompanies.cp"
                       {
# line 222 "C430GetCompanies.cp"
                           switch ( _sql->restype )
# line 222 "C430GetCompanies.cp"
                           {
# line 222 "C430GetCompanies.cp"
                           case CS_COMPUTE_RESULT:
# line 222 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 222 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25003);
# line 222 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 222 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 222 "C430GetCompanies.cp"
                           break;
# line 222 "C430GetCompanies.cp"
                           case CS_CURSOR_RESULT:
# line 222 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 222 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25004);
# line 222 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 222 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 222 "C430GetCompanies.cp"
                           break;
# line 222 "C430GetCompanies.cp"
                           case CS_PARAM_RESULT:
# line 222 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 222 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25005);
# line 222 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 222 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 222 "C430GetCompanies.cp"
                           break;
# line 222 "C430GetCompanies.cp"
                           case CS_ROW_RESULT:
# line 222 "C430GetCompanies.cp"
                               _sql->dfmtCS_INT_TYPE.count = 0;
# line 222 "C430GetCompanies.cp"
                                   _sql->retcode = ct_bind(_sql->conn.command, 
# line 222 "C430GetCompanies.cp"
                                       1, &_sql->dfmtCS_INT_TYPE, &iSystemYear,
# line 222 "C430GetCompanies.cp"
                                        NULL, NULL);
# line 222 "C430GetCompanies.cp"
                               _sql->retcode = ct_fetch(_sql->conn.command, 
# line 222 "C430GetCompanies.cp"
                                   CS_UNUSED, CS_UNUSED, CS_UNUSED, 
# line 222 "C430GetCompanies.cp"
                                   &_sql->rowsread);
# line 222 "C430GetCompanies.cp"
                               _sql->hastate = (_sql->retcode == 
# line 222 "C430GetCompanies.cp"
                                   CS_RET_HAFAILOVER);
# line 222 "C430GetCompanies.cp"
                               if ((_sql->retcode == CS_SUCCEED) || 
# line 222 "C430GetCompanies.cp"
                                   (_sql->retcode == CS_ROW_FAIL))
# line 222 "C430GetCompanies.cp"
                               {
# line 222 "C430GetCompanies.cp"
                                   _sql->retcode = ct_bind(_sql->conn.command, 
# line 222 "C430GetCompanies.cp"
                                       CS_UNUSED, NULL, NULL, NULL, NULL);
# line 222 "C430GetCompanies.cp"
                                   _sql->retcode = ct_fetch(_sql->conn.command,
# line 222 "C430GetCompanies.cp"
                                        CS_UNUSED, CS_UNUSED, CS_UNUSED, 
# line 222 "C430GetCompanies.cp"
                                       &_sql->rowsread);
# line 222 "C430GetCompanies.cp"
                                   _sql->hastate = (_sql->retcode == 
# line 222 "C430GetCompanies.cp"
                                       CS_RET_HAFAILOVER);
# line 222 "C430GetCompanies.cp"
                               }
# line 222 "C430GetCompanies.cp"
                               
# line 222 "C430GetCompanies.cp"
                           break;
# line 222 "C430GetCompanies.cp"
                           case CS_STATUS_RESULT:
# line 222 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 222 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25009);
# line 222 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 222 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 222 "C430GetCompanies.cp"
                           break;
# line 222 "C430GetCompanies.cp"
                           case CS_DESCRIBE_RESULT:
# line 222 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 222 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25010);
# line 222 "C430GetCompanies.cp"
                           break;
# line 222 "C430GetCompanies.cp"
                           }
# line 222 "C430GetCompanies.cp"
                           
# line 222 "C430GetCompanies.cp"
                       }
# line 222 "C430GetCompanies.cp"
                       
# line 222 "C430GetCompanies.cp"
                       if ((_sql->retcode != CS_END_RESULTS) && (_sql->retcode 
# line 222 "C430GetCompanies.cp"
                           != CS_CANCELED) && (_sql->retcode != 
# line 222 "C430GetCompanies.cp"
                           CS_RET_HAFAILOVER) && (_sql->resloop != CS_FALSE))
# line 222 "C430GetCompanies.cp"
                       {
# line 222 "C430GetCompanies.cp"
                           _sql->retcode = ct_cancel(NULL, _sql->conn.command, 
# line 222 "C430GetCompanies.cp"
                               CS_CANCEL_ALL);
# line 222 "C430GetCompanies.cp"
                           }
# line 222 "C430GetCompanies.cp"
                            else {
# line 222 "C430GetCompanies.cp"
                           if (((_sql->retcode != CS_CANCELED) && 
# line 222 "C430GetCompanies.cp"
                               (_sql->retcode != CS_RET_HAFAILOVER)))
# line 222 "C430GetCompanies.cp"
                           {
# line 222 "C430GetCompanies.cp"
                               _sql->retcode = CS_SUCCEED;
# line 222 "C430GetCompanies.cp"
                           }
# line 222 "C430GetCompanies.cp"
                           
# line 222 "C430GetCompanies.cp"
                       }
# line 222 "C430GetCompanies.cp"
                       
# line 222 "C430GetCompanies.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 222 "C430GetCompanies.cp"
                   }
# line 222 "C430GetCompanies.cp"
                   
# line 222 "C430GetCompanies.cp"
                   if (sqlca.sqlcode < 0)
# line 222 "C430GetCompanies.cp"
                   {
# line 222 "C430GetCompanies.cp"
                       error_handler();
# line 222 "C430GetCompanies.cp"
                   }
# line 222 "C430GetCompanies.cp"
                   
# line 222 "C430GetCompanies.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 222 "C430GetCompanies.cp"
                   {
# line 222 "C430GetCompanies.cp"
                       warning_handler();
# line 222 "C430GetCompanies.cp"
                   }
# line 222 "C430GetCompanies.cp"
                   
# line 222 "C430GetCompanies.cp"
               }
# line 222 "C430GetCompanies.cp"
               
# line 222 "C430GetCompanies.cp"
           }
# line 222 "C430GetCompanies.cp"
           

           /*
           ** Generated code ends here.
           */
# line 222 "C430GetCompanies.cp"



#ifdef DEBUG1
   printf("\nDay: %d", iSystemDay);
   printf("\nMonth: %d", iSystemMonth);
   printf("\nYear: %d\n\n", iSystemYear);
#endif 

   iProcType=atoi(psParams[4]);

   /* Recuperacion de Informacion de Base de Datos. */

   /* Determinacion de Empresas a Procesar. */

   iNumCompanies=0;

   strcpy(sSQLCommand, "SELECT count(*) \n");
   strcat(sSQLCommand, "FROM MTCEMP01 EMP, MTCEJE01 EJE \n");
   strcat(sSQLCommand, "WHERE EMP.eje_prefijo = EJE.eje_prefijo \n");
   strcat(sSQLCommand, "AND EMP.gpo_banco = EJE.gpo_banco \n");
   strcat(sSQLCommand, "AND EMP.emp_num = EJE.emp_num \n");
   strcat(sSQLCommand, "AND EJE.eje_tipo_cuenta = \'E\' \n"); 

   /* Establecer los criterios de recuperacion de Empresas de
      acuerdo con los Parametros de Entrada. */

   if(iProcType == 0)   /* Proceso Diario. */
   {
      strcat(sSQLCommand, "AND EMP.emp_gen_SBF IN (2,3,4,5)\n");
   }
   else   
   {
      if(iProcType == 1)   /* Proceso por Fecha de Corte. */
      {
         strcat(sSQLCommand, "AND EMP.emp_gen_SBF IN (2,3,4,5) \n");
         strcat(sSQLCommand, "AND EMP.emp_dia_corte = ");
         sprintf(sTempNum, "%d", iSystemDay);
         strcat(sSQLCommand, sTempNum);
      }
      else   /* Error en el parametro Tipo de Archivo. */
      {

#ifdef DEBUG1
         printf("\nFile Type not specified.\n");
#endif

         exit(ERREXIT);
      }
   }


   
           /*
           ** SQL STATEMENT: 19
           ** EXEC SQL PREPARE countcomp FROM :sSQLCommand;
           */
# line 274 "C430GetCompanies.cp"
# line 274 "C430GetCompanies.cp"
           {
# line 274 "C430GetCompanies.cp"
                _SQL_CT_HANDLES * _sql;
# line 274 "C430GetCompanies.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 274 "C430GetCompanies.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 274 "C430GetCompanies.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 274 "C430GetCompanies.cp"
               {
# line 274 "C430GetCompanies.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 274 "C430GetCompanies.cp"
                   _sql->stmttype = SQL_PREPARE;
# line 274 "C430GetCompanies.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 274 "C430GetCompanies.cp"
                   _sql->stmtName.fnlen = 9;
# line 274 "C430GetCompanies.cp"
                   strcpy(_sql->stmtName.first_name, "countcomp");
# line 274 "C430GetCompanies.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 274 "C430GetCompanies.cp"
                   {
# line 274 "C430GetCompanies.cp"
                       _sql->retcode = ct_dynamic(_sql->conn.command, 
# line 274 "C430GetCompanies.cp"
                           CS_PREPARE, "countcomp", 9, sSQLCommand, 
# line 274 "C430GetCompanies.cp"
                           CS_NULLTERM);
# line 274 "C430GetCompanies.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 274 "C430GetCompanies.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 274 "C430GetCompanies.cp"
                       _sql->resloop = CS_TRUE;
# line 274 "C430GetCompanies.cp"
                       while ((!_sql->hastate) && (_sql->resloop == CS_TRUE) 
# line 274 "C430GetCompanies.cp"
                           && ((_sql->retcode = ct_results(_sql->conn.command, 
# line 274 "C430GetCompanies.cp"
                           &_sql->restype)) == CS_SUCCEED))
# line 274 "C430GetCompanies.cp"
                       {
# line 274 "C430GetCompanies.cp"
                           switch ( _sql->restype )
# line 274 "C430GetCompanies.cp"
                           {
# line 274 "C430GetCompanies.cp"
                           case CS_CMD_FAIL:
# line 274 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 274 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_ALL);
# line 274 "C430GetCompanies.cp"
                           break;
# line 274 "C430GetCompanies.cp"
                           case CS_COMPUTE_RESULT:
# line 274 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 274 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25003);
# line 274 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 274 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 274 "C430GetCompanies.cp"
                           break;
# line 274 "C430GetCompanies.cp"
                           case CS_CURSOR_RESULT:
# line 274 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 274 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25004);
# line 274 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 274 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 274 "C430GetCompanies.cp"
                           break;
# line 274 "C430GetCompanies.cp"
                           case CS_PARAM_RESULT:
# line 274 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 274 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25005);
# line 274 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 274 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 274 "C430GetCompanies.cp"
                           break;
# line 274 "C430GetCompanies.cp"
                           case CS_ROW_RESULT:
# line 274 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 274 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25006);
# line 274 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 274 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 274 "C430GetCompanies.cp"
                           break;
# line 274 "C430GetCompanies.cp"
                           case CS_STATUS_RESULT:
# line 274 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 274 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25009);
# line 274 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 274 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 274 "C430GetCompanies.cp"
                           break;
# line 274 "C430GetCompanies.cp"
                           case CS_DESCRIBE_RESULT:
# line 274 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 274 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25010);
# line 274 "C430GetCompanies.cp"
                           break;
# line 274 "C430GetCompanies.cp"
                           }
# line 274 "C430GetCompanies.cp"
                           
# line 274 "C430GetCompanies.cp"
                       }
# line 274 "C430GetCompanies.cp"
                       
# line 274 "C430GetCompanies.cp"
                       if ((_sql->retcode != CS_END_RESULTS) && (_sql->retcode 
# line 274 "C430GetCompanies.cp"
                           != CS_CANCELED) && (_sql->retcode != 
# line 274 "C430GetCompanies.cp"
                           CS_RET_HAFAILOVER) && (_sql->resloop != CS_FALSE))
# line 274 "C430GetCompanies.cp"
                       {
# line 274 "C430GetCompanies.cp"
                           _sql->retcode = ct_cancel(NULL, _sql->conn.command, 
# line 274 "C430GetCompanies.cp"
                               CS_CANCEL_ALL);
# line 274 "C430GetCompanies.cp"
                           }
# line 274 "C430GetCompanies.cp"
                            else {
# line 274 "C430GetCompanies.cp"
                           if (((_sql->retcode != CS_CANCELED) && 
# line 274 "C430GetCompanies.cp"
                               (_sql->retcode != CS_RET_HAFAILOVER)))
# line 274 "C430GetCompanies.cp"
                           {
# line 274 "C430GetCompanies.cp"
                               _sql->retcode = CS_SUCCEED;
# line 274 "C430GetCompanies.cp"
                           }
# line 274 "C430GetCompanies.cp"
                           
# line 274 "C430GetCompanies.cp"
                       }
# line 274 "C430GetCompanies.cp"
                       
# line 274 "C430GetCompanies.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 274 "C430GetCompanies.cp"
                   }
# line 274 "C430GetCompanies.cp"
                   
# line 274 "C430GetCompanies.cp"
                   if (sqlca.sqlcode < 0)
# line 274 "C430GetCompanies.cp"
                   {
# line 274 "C430GetCompanies.cp"
                       error_handler();
# line 274 "C430GetCompanies.cp"
                   }
# line 274 "C430GetCompanies.cp"
                   
# line 274 "C430GetCompanies.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 274 "C430GetCompanies.cp"
                   {
# line 274 "C430GetCompanies.cp"
                       warning_handler();
# line 274 "C430GetCompanies.cp"
                   }
# line 274 "C430GetCompanies.cp"
                   
# line 274 "C430GetCompanies.cp"
               }
# line 274 "C430GetCompanies.cp"
               
# line 274 "C430GetCompanies.cp"
           }
# line 274 "C430GetCompanies.cp"
           

           /*
           ** Generated code ends here.
           */
# line 274 "C430GetCompanies.cp"


   
           /*
           ** SQL STATEMENT: 20
           ** EXEC SQL EXECUTE countcomp INTO :iNumCompanies;
           */
# line 276 "C430GetCompanies.cp"
# line 276 "C430GetCompanies.cp"
           {
# line 276 "C430GetCompanies.cp"
                _SQL_CT_HANDLES * _sql;
# line 276 "C430GetCompanies.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 276 "C430GetCompanies.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 276 "C430GetCompanies.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 276 "C430GetCompanies.cp"
               {
# line 276 "C430GetCompanies.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 276 "C430GetCompanies.cp"
                   _sql->stmttype = SQL_EXECUTE;
# line 276 "C430GetCompanies.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 276 "C430GetCompanies.cp"
                   _sql->stmtName.fnlen = 9;
# line 276 "C430GetCompanies.cp"
                   strcpy(_sql->stmtName.first_name, "countcomp");
# line 276 "C430GetCompanies.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 276 "C430GetCompanies.cp"
                   {
# line 276 "C430GetCompanies.cp"
                       _sql->retcode = ct_dynamic(_sql->conn.command, 
# line 276 "C430GetCompanies.cp"
                           CS_EXECUTE, "countcomp", 9, NULL, CS_UNUSED);
# line 276 "C430GetCompanies.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 276 "C430GetCompanies.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 276 "C430GetCompanies.cp"
                       _sql->resloop = CS_TRUE;
# line 276 "C430GetCompanies.cp"
                       while ((!_sql->hastate) && (_sql->resloop == CS_TRUE) 
# line 276 "C430GetCompanies.cp"
                           && ((_sql->retcode = ct_results(_sql->conn.command, 
# line 276 "C430GetCompanies.cp"
                           &_sql->restype)) == CS_SUCCEED))
# line 276 "C430GetCompanies.cp"
                       {
# line 276 "C430GetCompanies.cp"
                           switch ( _sql->restype )
# line 276 "C430GetCompanies.cp"
                           {
# line 276 "C430GetCompanies.cp"
                           case CS_COMPUTE_RESULT:
# line 276 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 276 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25003);
# line 276 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 276 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 276 "C430GetCompanies.cp"
                           break;
# line 276 "C430GetCompanies.cp"
                           case CS_CURSOR_RESULT:
# line 276 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 276 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25004);
# line 276 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 276 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 276 "C430GetCompanies.cp"
                           break;
# line 276 "C430GetCompanies.cp"
                           case CS_PARAM_RESULT:
# line 276 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 276 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25005);
# line 276 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 276 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 276 "C430GetCompanies.cp"
                           break;
# line 276 "C430GetCompanies.cp"
                           case CS_ROW_RESULT:
# line 276 "C430GetCompanies.cp"
                               _sql->dfmtCS_INT_TYPE.count = 0;
# line 276 "C430GetCompanies.cp"
                                   _sql->retcode = ct_bind(_sql->conn.command, 
# line 276 "C430GetCompanies.cp"
                                       1, &_sql->dfmtCS_INT_TYPE, 
# line 276 "C430GetCompanies.cp"
                                       &iNumCompanies, NULL, NULL);
# line 276 "C430GetCompanies.cp"
                               _sql->retcode = ct_fetch(_sql->conn.command, 
# line 276 "C430GetCompanies.cp"
                                   CS_UNUSED, CS_UNUSED, CS_UNUSED, 
# line 276 "C430GetCompanies.cp"
                                   &_sql->rowsread);
# line 276 "C430GetCompanies.cp"
                               _sql->hastate = (_sql->retcode == 
# line 276 "C430GetCompanies.cp"
                                   CS_RET_HAFAILOVER);
# line 276 "C430GetCompanies.cp"
                               if ((_sql->retcode == CS_SUCCEED) || 
# line 276 "C430GetCompanies.cp"
                                   (_sql->retcode == CS_ROW_FAIL))
# line 276 "C430GetCompanies.cp"
                               {
# line 276 "C430GetCompanies.cp"
                                   _sql->retcode = ct_bind(_sql->conn.command, 
# line 276 "C430GetCompanies.cp"
                                       CS_UNUSED, NULL, NULL, NULL, NULL);
# line 276 "C430GetCompanies.cp"
                                   _sql->retcode = ct_fetch(_sql->conn.command,
# line 276 "C430GetCompanies.cp"
                                        CS_UNUSED, CS_UNUSED, CS_UNUSED, 
# line 276 "C430GetCompanies.cp"
                                       &_sql->rowsread);
# line 276 "C430GetCompanies.cp"
                                   _sql->hastate = (_sql->retcode == 
# line 276 "C430GetCompanies.cp"
                                       CS_RET_HAFAILOVER);
# line 276 "C430GetCompanies.cp"
                               }
# line 276 "C430GetCompanies.cp"
                               
# line 276 "C430GetCompanies.cp"
                           break;
# line 276 "C430GetCompanies.cp"
                           case CS_STATUS_RESULT:
# line 276 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 276 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25009);
# line 276 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 276 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 276 "C430GetCompanies.cp"
                           break;
# line 276 "C430GetCompanies.cp"
                           case CS_DESCRIBE_RESULT:
# line 276 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 276 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25010);
# line 276 "C430GetCompanies.cp"
                           break;
# line 276 "C430GetCompanies.cp"
                           }
# line 276 "C430GetCompanies.cp"
                           
# line 276 "C430GetCompanies.cp"
                       }
# line 276 "C430GetCompanies.cp"
                       
# line 276 "C430GetCompanies.cp"
                       if ((_sql->retcode != CS_END_RESULTS) && (_sql->retcode 
# line 276 "C430GetCompanies.cp"
                           != CS_CANCELED) && (_sql->retcode != 
# line 276 "C430GetCompanies.cp"
                           CS_RET_HAFAILOVER) && (_sql->resloop != CS_FALSE))
# line 276 "C430GetCompanies.cp"
                       {
# line 276 "C430GetCompanies.cp"
                           _sql->retcode = ct_cancel(NULL, _sql->conn.command, 
# line 276 "C430GetCompanies.cp"
                               CS_CANCEL_ALL);
# line 276 "C430GetCompanies.cp"
                           }
# line 276 "C430GetCompanies.cp"
                            else {
# line 276 "C430GetCompanies.cp"
                           if (((_sql->retcode != CS_CANCELED) && 
# line 276 "C430GetCompanies.cp"
                               (_sql->retcode != CS_RET_HAFAILOVER)))
# line 276 "C430GetCompanies.cp"
                           {
# line 276 "C430GetCompanies.cp"
                               _sql->retcode = CS_SUCCEED;
# line 276 "C430GetCompanies.cp"
                           }
# line 276 "C430GetCompanies.cp"
                           
# line 276 "C430GetCompanies.cp"
                       }
# line 276 "C430GetCompanies.cp"
                       
# line 276 "C430GetCompanies.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 276 "C430GetCompanies.cp"
                   }
# line 276 "C430GetCompanies.cp"
                   
# line 276 "C430GetCompanies.cp"
                   if (sqlca.sqlcode < 0)
# line 276 "C430GetCompanies.cp"
                   {
# line 276 "C430GetCompanies.cp"
                       error_handler();
# line 276 "C430GetCompanies.cp"
                   }
# line 276 "C430GetCompanies.cp"
                   
# line 276 "C430GetCompanies.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 276 "C430GetCompanies.cp"
                   {
# line 276 "C430GetCompanies.cp"
                       warning_handler();
# line 276 "C430GetCompanies.cp"
                   }
# line 276 "C430GetCompanies.cp"
                   
# line 276 "C430GetCompanies.cp"
               }
# line 276 "C430GetCompanies.cp"
               
# line 276 "C430GetCompanies.cp"
           }
# line 276 "C430GetCompanies.cp"
           

           /*
           ** Generated code ends here.
           */
# line 276 "C430GetCompanies.cp"


   psCompanies=malloc(iNumCompanies * sizeof(Company));

   if(psCompanies == NULL)
   {

#ifdef DEBUG1
      printf("\nMemory Not Available.\n");
#endif

      exit(ERREXIT);
   }

   for(iCompCount=0; iCompCount < iNumCompanies; iCompCount++)
   {  
      psCompanies[iCompCount].iPreffix=0;
      psCompanies[iCompCount].iBankGroup=0;
      psCompanies[iCompCount].iCompanyID=0;
      psCompanies[iCompCount].iChargeOffDate=0;
   }                                                           

   
           /*
           ** SQL STATEMENT: 21
           ** EXEC SQL DEALLOCATE PREPARE countcomp;

           */
# line 298 "C430GetCompanies.cp"
# line 298 "C430GetCompanies.cp"
           {
# line 298 "C430GetCompanies.cp"
                _SQL_CT_HANDLES * _sql;
# line 298 "C430GetCompanies.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 298 "C430GetCompanies.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 298 "C430GetCompanies.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 298 "C430GetCompanies.cp"
               {
# line 298 "C430GetCompanies.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 298 "C430GetCompanies.cp"
                   _sql->stmttype = SQL_DEALLOCATE_PREPARE;
# line 298 "C430GetCompanies.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 298 "C430GetCompanies.cp"
                   _sql->stmtName.fnlen = 9;
# line 298 "C430GetCompanies.cp"
                   strcpy(_sql->stmtName.first_name, "countcomp");
# line 298 "C430GetCompanies.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 298 "C430GetCompanies.cp"
                   {
# line 298 "C430GetCompanies.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 298 "C430GetCompanies.cp"
                   }
# line 298 "C430GetCompanies.cp"
                   
# line 298 "C430GetCompanies.cp"
                   if (sqlca.sqlcode < 0)
# line 298 "C430GetCompanies.cp"
                   {
# line 298 "C430GetCompanies.cp"
                       error_handler();
# line 298 "C430GetCompanies.cp"
                   }
# line 298 "C430GetCompanies.cp"
                   
# line 298 "C430GetCompanies.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 298 "C430GetCompanies.cp"
                   {
# line 298 "C430GetCompanies.cp"
                       warning_handler();
# line 298 "C430GetCompanies.cp"
                   }
# line 298 "C430GetCompanies.cp"
                   
# line 298 "C430GetCompanies.cp"
               }
# line 298 "C430GetCompanies.cp"
               
# line 298 "C430GetCompanies.cp"
           }
# line 298 "C430GetCompanies.cp"
           

           /*
           ** Generated code ends here.
           */
# line 298 "C430GetCompanies.cp"


   
           /*
           ** SQL STATEMENT: 22
           ** EXEC SQL COMMIT WORK; 
           */
# line 300 "C430GetCompanies.cp"
# line 300 "C430GetCompanies.cp"
           {
# line 300 "C430GetCompanies.cp"
                _SQL_CT_HANDLES * _sql;
# line 300 "C430GetCompanies.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 300 "C430GetCompanies.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 300 "C430GetCompanies.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 300 "C430GetCompanies.cp"
               {
# line 300 "C430GetCompanies.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 300 "C430GetCompanies.cp"
                   _sql->stmttype = SQL_TRANS;
# line 300 "C430GetCompanies.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 300 "C430GetCompanies.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 300 "C430GetCompanies.cp"
                   {
# line 300 "C430GetCompanies.cp"
                       _sql->retcode = ct_command(_sql->conn.command, 
# line 300 "C430GetCompanies.cp"
                           CS_LANG_CMD, "COMMIT WORK", 11, CS_UNUSED);
# line 300 "C430GetCompanies.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 300 "C430GetCompanies.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 300 "C430GetCompanies.cp"
                       _sql->retcode = _sqlResults(_sql);
# line 300 "C430GetCompanies.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 300 "C430GetCompanies.cp"
                   }
# line 300 "C430GetCompanies.cp"
                   
# line 300 "C430GetCompanies.cp"
                   if (sqlca.sqlcode < 0)
# line 300 "C430GetCompanies.cp"
                   {
# line 300 "C430GetCompanies.cp"
                       error_handler();
# line 300 "C430GetCompanies.cp"
                   }
# line 300 "C430GetCompanies.cp"
                   
# line 300 "C430GetCompanies.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 300 "C430GetCompanies.cp"
                   {
# line 300 "C430GetCompanies.cp"
                       warning_handler();
# line 300 "C430GetCompanies.cp"
                   }
# line 300 "C430GetCompanies.cp"
                   
# line 300 "C430GetCompanies.cp"
               }
# line 300 "C430GetCompanies.cp"
               
# line 300 "C430GetCompanies.cp"
           }
# line 300 "C430GetCompanies.cp"
           

           /*
           ** Generated code ends here.
           */
# line 300 "C430GetCompanies.cp"
 


   /* Extraccion de registros de la tabla de Empresas MTCEMP01. */ 

   iCompCount=0;

   strcpy(sSQLCommand, "SELECT EMP.eje_prefijo, EMP.gpo_banco, EMP.emp_num, ");
   strcat(sSQLCommand, "isnull(EMP.emp_dia_corte, 0) ");
   strcat(sSQLCommand, "FROM MTCEMP01 EMP, MTCEJE01 EJE ");
   strcat(sSQLCommand, "WHERE EMP.eje_prefijo = EJE.eje_prefijo ");
   strcat(sSQLCommand, "AND EMP.gpo_banco = EJE.gpo_banco ");
   strcat(sSQLCommand, "AND EMP.emp_num = EJE.emp_num ");
   strcat(sSQLCommand, "AND EJE.eje_tipo_cuenta = \'E\' "); 

   /* Establecer los criterios de recuperacion de Empresas de
      acuerdo con los Parametros de Entrada. */

   if(iProcType == 0)   /* Proceso Diario. */
   {
      strcat(sSQLCommand, "AND EMP.emp_gen_SBF IN (2,3,4,5) ");
   }
   else   
   {
      if(iProcType == 1)   /* Proceso por Fecha de Corte. */
      {
         strcat(sSQLCommand, "AND EMP.emp_gen_SBF IN (2,3,4,5) ");
         strcat(sSQLCommand, "AND EMP.emp_dia_corte = ");
         sprintf(sTempNum, "%d", iSystemDay);
         strcat(sSQLCommand, sTempNum);
      }
      else   /* Error en el parametro Tipo de Archivo. */
      {

#ifdef DEBUG1
         printf("\nFile Type not specified.\n");
#endif

         free(psCompanies);
         exit(ERREXIT);

      }
   }

   
           /*
           ** SQL STATEMENT: 23
           ** EXEC SQL PREPARE companysql FROM :sSQLCommand;
           */
# line 344 "C430GetCompanies.cp"
# line 344 "C430GetCompanies.cp"
           {
# line 344 "C430GetCompanies.cp"
                _SQL_CT_HANDLES * _sql;
# line 344 "C430GetCompanies.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 344 "C430GetCompanies.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 344 "C430GetCompanies.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 344 "C430GetCompanies.cp"
               {
# line 344 "C430GetCompanies.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 344 "C430GetCompanies.cp"
                   _sql->stmttype = SQL_PREPARE;
# line 344 "C430GetCompanies.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 344 "C430GetCompanies.cp"
                   _sql->stmtName.fnlen = 10;
# line 344 "C430GetCompanies.cp"
                   strcpy(_sql->stmtName.first_name, "companysql");
# line 344 "C430GetCompanies.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 344 "C430GetCompanies.cp"
                   {
# line 344 "C430GetCompanies.cp"
                       _sql->retcode = ct_dynamic(_sql->conn.command, 
# line 344 "C430GetCompanies.cp"
                           CS_PREPARE, "companysql", 10, sSQLCommand, 
# line 344 "C430GetCompanies.cp"
                           CS_NULLTERM);
# line 344 "C430GetCompanies.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 344 "C430GetCompanies.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 344 "C430GetCompanies.cp"
                       _sql->resloop = CS_TRUE;
# line 344 "C430GetCompanies.cp"
                       while ((!_sql->hastate) && (_sql->resloop == CS_TRUE) 
# line 344 "C430GetCompanies.cp"
                           && ((_sql->retcode = ct_results(_sql->conn.command, 
# line 344 "C430GetCompanies.cp"
                           &_sql->restype)) == CS_SUCCEED))
# line 344 "C430GetCompanies.cp"
                       {
# line 344 "C430GetCompanies.cp"
                           switch ( _sql->restype )
# line 344 "C430GetCompanies.cp"
                           {
# line 344 "C430GetCompanies.cp"
                           case CS_CMD_FAIL:
# line 344 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 344 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_ALL);
# line 344 "C430GetCompanies.cp"
                           break;
# line 344 "C430GetCompanies.cp"
                           case CS_COMPUTE_RESULT:
# line 344 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 344 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25003);
# line 344 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 344 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 344 "C430GetCompanies.cp"
                           break;
# line 344 "C430GetCompanies.cp"
                           case CS_CURSOR_RESULT:
# line 344 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 344 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25004);
# line 344 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 344 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 344 "C430GetCompanies.cp"
                           break;
# line 344 "C430GetCompanies.cp"
                           case CS_PARAM_RESULT:
# line 344 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 344 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25005);
# line 344 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 344 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 344 "C430GetCompanies.cp"
                           break;
# line 344 "C430GetCompanies.cp"
                           case CS_ROW_RESULT:
# line 344 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 344 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25006);
# line 344 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 344 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 344 "C430GetCompanies.cp"
                           break;
# line 344 "C430GetCompanies.cp"
                           case CS_STATUS_RESULT:
# line 344 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 344 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25009);
# line 344 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 344 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 344 "C430GetCompanies.cp"
                           break;
# line 344 "C430GetCompanies.cp"
                           case CS_DESCRIBE_RESULT:
# line 344 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 344 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25010);
# line 344 "C430GetCompanies.cp"
                           break;
# line 344 "C430GetCompanies.cp"
                           }
# line 344 "C430GetCompanies.cp"
                           
# line 344 "C430GetCompanies.cp"
                       }
# line 344 "C430GetCompanies.cp"
                       
# line 344 "C430GetCompanies.cp"
                       if ((_sql->retcode != CS_END_RESULTS) && (_sql->retcode 
# line 344 "C430GetCompanies.cp"
                           != CS_CANCELED) && (_sql->retcode != 
# line 344 "C430GetCompanies.cp"
                           CS_RET_HAFAILOVER) && (_sql->resloop != CS_FALSE))
# line 344 "C430GetCompanies.cp"
                       {
# line 344 "C430GetCompanies.cp"
                           _sql->retcode = ct_cancel(NULL, _sql->conn.command, 
# line 344 "C430GetCompanies.cp"
                               CS_CANCEL_ALL);
# line 344 "C430GetCompanies.cp"
                           }
# line 344 "C430GetCompanies.cp"
                            else {
# line 344 "C430GetCompanies.cp"
                           if (((_sql->retcode != CS_CANCELED) && 
# line 344 "C430GetCompanies.cp"
                               (_sql->retcode != CS_RET_HAFAILOVER)))
# line 344 "C430GetCompanies.cp"
                           {
# line 344 "C430GetCompanies.cp"
                               _sql->retcode = CS_SUCCEED;
# line 344 "C430GetCompanies.cp"
                           }
# line 344 "C430GetCompanies.cp"
                           
# line 344 "C430GetCompanies.cp"
                       }
# line 344 "C430GetCompanies.cp"
                       
# line 344 "C430GetCompanies.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 344 "C430GetCompanies.cp"
                   }
# line 344 "C430GetCompanies.cp"
                   
# line 344 "C430GetCompanies.cp"
                   if (sqlca.sqlcode < 0)
# line 344 "C430GetCompanies.cp"
                   {
# line 344 "C430GetCompanies.cp"
                       error_handler();
# line 344 "C430GetCompanies.cp"
                   }
# line 344 "C430GetCompanies.cp"
                   
# line 344 "C430GetCompanies.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 344 "C430GetCompanies.cp"
                   {
# line 344 "C430GetCompanies.cp"
                       warning_handler();
# line 344 "C430GetCompanies.cp"
                   }
# line 344 "C430GetCompanies.cp"
                   
# line 344 "C430GetCompanies.cp"
               }
# line 344 "C430GetCompanies.cp"
               
# line 344 "C430GetCompanies.cp"
           }
# line 344 "C430GetCompanies.cp"
           

           /*
           ** Generated code ends here.
           */
# line 344 "C430GetCompanies.cp"


   
           /*
           ** SQL STATEMENT: 24
           ** EXEC SQL DECLARE companydata CURSOR FOR companysql;

           */
# line 346 "C430GetCompanies.cp"
# line 346 "C430GetCompanies.cp"
           {
# line 346 "C430GetCompanies.cp"
                _SQL_CT_HANDLES * _sql;
# line 346 "C430GetCompanies.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 346 "C430GetCompanies.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 346 "C430GetCompanies.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 346 "C430GetCompanies.cp"
               {
# line 346 "C430GetCompanies.cp"
                   _sql->stmtName.fnlen = 10;
# line 346 "C430GetCompanies.cp"
                   strcpy(_sql->stmtName.first_name, "companysql");
# line 346 "C430GetCompanies.cp"
                   ;
# line 346 "C430GetCompanies.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 346 "C430GetCompanies.cp"
                   _sql->moreData.curData.norebind = CS_FALSE;
# line 346 "C430GetCompanies.cp"
                   _sql->stmttype = SQL_DYNAMIC_DECLARE_CURSOR;
# line 346 "C430GetCompanies.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 346 "C430GetCompanies.cp"
                   _sql->curName.fnlen = 11;
# line 346 "C430GetCompanies.cp"
                   strcpy(_sql->curName.first_name, "companydata");
# line 346 "C430GetCompanies.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 346 "C430GetCompanies.cp"
                   {
# line 346 "C430GetCompanies.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 346 "C430GetCompanies.cp"
                   }
# line 346 "C430GetCompanies.cp"
                   
# line 346 "C430GetCompanies.cp"
                   if (sqlca.sqlcode < 0)
# line 346 "C430GetCompanies.cp"
                   {
# line 346 "C430GetCompanies.cp"
                       error_handler();
# line 346 "C430GetCompanies.cp"
                   }
# line 346 "C430GetCompanies.cp"
                   
# line 346 "C430GetCompanies.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 346 "C430GetCompanies.cp"
                   {
# line 346 "C430GetCompanies.cp"
                       warning_handler();
# line 346 "C430GetCompanies.cp"
                   }
# line 346 "C430GetCompanies.cp"
                   
# line 346 "C430GetCompanies.cp"
               }
# line 346 "C430GetCompanies.cp"
               
# line 346 "C430GetCompanies.cp"
           }
# line 346 "C430GetCompanies.cp"
           

           /*
           ** Generated code ends here.
           */
# line 346 "C430GetCompanies.cp"


   
           /*
           ** SQL STATEMENT: 25
           ** EXEC SQL OPEN companydata;

           */
# line 348 "C430GetCompanies.cp"
# line 348 "C430GetCompanies.cp"
           {
# line 348 "C430GetCompanies.cp"
                _SQL_CT_HANDLES * _sql;
# line 348 "C430GetCompanies.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 348 "C430GetCompanies.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 348 "C430GetCompanies.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 348 "C430GetCompanies.cp"
               {
# line 348 "C430GetCompanies.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 348 "C430GetCompanies.cp"
                   _sql->moreData.curData.norebind = CS_FALSE;
# line 348 "C430GetCompanies.cp"
                   _sql->stmttype = SQL_OPEN_STMT;
# line 348 "C430GetCompanies.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 348 "C430GetCompanies.cp"
                   _sql->curName.fnlen = 11;
# line 348 "C430GetCompanies.cp"
                   strcpy(_sql->curName.first_name, "companydata");
# line 348 "C430GetCompanies.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 348 "C430GetCompanies.cp"
                   {
# line 348 "C430GetCompanies.cp"
                       if (_sql->retcode == CS_SUCCEED)
# line 348 "C430GetCompanies.cp"
                       {
# line 348 "C430GetCompanies.cp"
                           if (_sql->stmtData.persistent == CS_TRUE)
# line 348 "C430GetCompanies.cp"
                           {
# line 348 "C430GetCompanies.cp"
                               _sql->retcode = ct_cursor(_sql->conn.command, 
# line 348 "C430GetCompanies.cp"
                                   CS_CURSOR_OPEN, NULL, CS_UNUSED, NULL, 
# line 348 "C430GetCompanies.cp"
                                   CS_UNUSED, CS_RESTORE_OPEN);
# line 348 "C430GetCompanies.cp"
                               }
# line 348 "C430GetCompanies.cp"
                                else {
# line 348 "C430GetCompanies.cp"
                               _sql->retcode = ct_cursor(_sql->conn.command, 
# line 348 "C430GetCompanies.cp"
                                   CS_CURSOR_OPEN, NULL, CS_UNUSED, NULL, 
# line 348 "C430GetCompanies.cp"
                                   CS_UNUSED, CS_UNUSED);
# line 348 "C430GetCompanies.cp"
                           }
# line 348 "C430GetCompanies.cp"
                           
# line 348 "C430GetCompanies.cp"
                       }
# line 348 "C430GetCompanies.cp"
                       
# line 348 "C430GetCompanies.cp"
                       if (_sql->retcode == CS_SUCCEED)
# line 348 "C430GetCompanies.cp"
                       {
# line 348 "C430GetCompanies.cp"
                           _sql->retcode = ct_send(_sql->conn.command);
# line 348 "C430GetCompanies.cp"
                           _sql->hastate = (_sql->retcode == 
# line 348 "C430GetCompanies.cp"
                               CS_RET_HAFAILOVER);
# line 348 "C430GetCompanies.cp"
                       }
# line 348 "C430GetCompanies.cp"
                       
# line 348 "C430GetCompanies.cp"
                       _sql->resloop = CS_TRUE;
# line 348 "C430GetCompanies.cp"
                       while ((!_sql->hastate) && (_sql->resloop == CS_TRUE) 
# line 348 "C430GetCompanies.cp"
                           && ((_sql->retcode = ct_results(_sql->conn.command, 
# line 348 "C430GetCompanies.cp"
                           &_sql->restype)) == CS_SUCCEED))
# line 348 "C430GetCompanies.cp"
                       {
# line 348 "C430GetCompanies.cp"
                           switch ( _sql->restype )
# line 348 "C430GetCompanies.cp"
                           {
# line 348 "C430GetCompanies.cp"
                           case CS_COMPUTE_RESULT:
# line 348 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 348 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25003);
# line 348 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 348 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 348 "C430GetCompanies.cp"
                           break;
# line 348 "C430GetCompanies.cp"
                           case CS_CURSOR_RESULT:
# line 348 "C430GetCompanies.cp"
                               _sql->resloop = CS_FALSE;
# line 348 "C430GetCompanies.cp"
                           break;
# line 348 "C430GetCompanies.cp"
                           case CS_PARAM_RESULT:
# line 348 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 348 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25005);
# line 348 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 348 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 348 "C430GetCompanies.cp"
                           break;
# line 348 "C430GetCompanies.cp"
                           case CS_ROW_RESULT:
# line 348 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 348 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25006);
# line 348 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 348 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 348 "C430GetCompanies.cp"
                           break;
# line 348 "C430GetCompanies.cp"
                           case CS_STATUS_RESULT:
# line 348 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 348 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25009);
# line 348 "C430GetCompanies.cp"
                               _sql->retcode = ct_cancel(NULL, 
# line 348 "C430GetCompanies.cp"
                                   _sql->conn.command, CS_CANCEL_CURRENT);
# line 348 "C430GetCompanies.cp"
                           break;
# line 348 "C430GetCompanies.cp"
                           case CS_DESCRIBE_RESULT:
# line 348 "C430GetCompanies.cp"
                               _sqlsetintrerr(_sql, (CS_INT) 
# line 348 "C430GetCompanies.cp"
                                   _SQL_INTRERR_25010);
# line 348 "C430GetCompanies.cp"
                           break;
# line 348 "C430GetCompanies.cp"
                           }
# line 348 "C430GetCompanies.cp"
                           
# line 348 "C430GetCompanies.cp"
                       }
# line 348 "C430GetCompanies.cp"
                       
# line 348 "C430GetCompanies.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 348 "C430GetCompanies.cp"
                   }
# line 348 "C430GetCompanies.cp"
                   
# line 348 "C430GetCompanies.cp"
                   if (sqlca.sqlcode < 0)
# line 348 "C430GetCompanies.cp"
                   {
# line 348 "C430GetCompanies.cp"
                       error_handler();
# line 348 "C430GetCompanies.cp"
                   }
# line 348 "C430GetCompanies.cp"
                   
# line 348 "C430GetCompanies.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 348 "C430GetCompanies.cp"
                   {
# line 348 "C430GetCompanies.cp"
                       warning_handler();
# line 348 "C430GetCompanies.cp"
                   }
# line 348 "C430GetCompanies.cp"
                   
# line 348 "C430GetCompanies.cp"
               }
# line 348 "C430GetCompanies.cp"
               
# line 348 "C430GetCompanies.cp"
           }
# line 348 "C430GetCompanies.cp"
           

           /*
           ** Generated code ends here.
           */
# line 348 "C430GetCompanies.cp"



   for(;;) 
   {
      iPreffix=0;
      iBankGroup=0;
      iCompanyID=0;
      iChargeOffDate=0;
   
      
           /*
           ** SQL STATEMENT: 26
           ** EXEC SQL FETCH companydata 
           **                INTO :iPreffix, :iBankGroup, :iCompanyID, :iCharge
           ** OffDate;
           */
# line 359 "C430GetCompanies.cp"
# line 358 "C430GetCompanies.cp"
           {
# line 358 "C430GetCompanies.cp"
                _SQL_CT_HANDLES * _sql;
# line 358 "C430GetCompanies.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 358 "C430GetCompanies.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 358 "C430GetCompanies.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 358 "C430GetCompanies.cp"
               {
# line 358 "C430GetCompanies.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 358 "C430GetCompanies.cp"
                   _sql->stmttype = SQL_FETCH_STMT;
# line 358 "C430GetCompanies.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 358 "C430GetCompanies.cp"
                   _sql->curName.fnlen = 11;
# line 358 "C430GetCompanies.cp"
                   strcpy(_sql->curName.first_name, "companydata");
# line 358 "C430GetCompanies.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 358 "C430GetCompanies.cp"
                   {
# line 358 "C430GetCompanies.cp"
                       _sql->doDecl = CS_FALSE;
# line 358 "C430GetCompanies.cp"
                       if ((_sql->stmtData.bind == CS_TRUE) ||
# line 358 "C430GetCompanies.cp"
                       (_sql->moreData.curData.norebind == CS_FALSE))
# line 358 "C430GetCompanies.cp"
                       {
# line 358 "C430GetCompanies.cp"
                           _sql->dfmtCS_INT_TYPE.count = 0;
# line 358 "C430GetCompanies.cp"
                               _sql->retcode = ct_bind(_sql->conn.command, 1, 
# line 358 "C430GetCompanies.cp"
                                   &_sql->dfmtCS_INT_TYPE, &iPreffix, NULL, 
# line 358 "C430GetCompanies.cp"
                                   NULL);
# line 358 "C430GetCompanies.cp"
                           _sql->dfmtCS_INT_TYPE.count = 0;
# line 358 "C430GetCompanies.cp"
                               _sql->retcode = ct_bind(_sql->conn.command, 2, 
# line 358 "C430GetCompanies.cp"
                                   &_sql->dfmtCS_INT_TYPE, &iBankGroup, NULL, 
# line 358 "C430GetCompanies.cp"
                                   NULL);
# line 358 "C430GetCompanies.cp"
                           _sql->dfmtCS_INT_TYPE.count = 0;
# line 358 "C430GetCompanies.cp"
                               _sql->retcode = ct_bind(_sql->conn.command, 3, 
# line 358 "C430GetCompanies.cp"
                                   &_sql->dfmtCS_INT_TYPE, &iCompanyID, NULL, 
# line 358 "C430GetCompanies.cp"
                                   NULL);
# line 358 "C430GetCompanies.cp"
                           _sql->dfmtCS_INT_TYPE.count = 0;
# line 358 "C430GetCompanies.cp"
                               _sql->retcode = ct_bind(_sql->conn.command, 4, 
# line 358 "C430GetCompanies.cp"
                                   &_sql->dfmtCS_INT_TYPE, &iChargeOffDate, 
# line 358 "C430GetCompanies.cp"
                                   NULL, NULL);
# line 358 "C430GetCompanies.cp"
                           if (_sql->stmtData.bind == CS_TRUE)
# line 358 "C430GetCompanies.cp"
                           {
# line 358 "C430GetCompanies.cp"
                               _sql->stmtData.bind = CS_FALSE;
# line 358 "C430GetCompanies.cp"
                               _sql->doDecl = CS_TRUE;
# line 358 "C430GetCompanies.cp"
                           }
# line 358 "C430GetCompanies.cp"
                           
# line 358 "C430GetCompanies.cp"
                       }
# line 358 "C430GetCompanies.cp"
                       
# line 358 "C430GetCompanies.cp"
                       _sql->retcode = ct_fetch(_sql->conn.command, CS_UNUSED, 
# line 358 "C430GetCompanies.cp"
                           CS_UNUSED, CS_UNUSED, &_sql->rowsread);
# line 358 "C430GetCompanies.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 358 "C430GetCompanies.cp"
                       if ((_sql->retcode == CS_END_DATA)||(_sql->retcode == 
# line 358 "C430GetCompanies.cp"
                       CS_FAIL)||
# line 358 "C430GetCompanies.cp"
                       (_sql->retcode == CS_SCROLL_CURSOR_ENDS))
# line 358 "C430GetCompanies.cp"
                       {
# line 358 "C430GetCompanies.cp"
                           _sql->retcode = _sqlResults(_sql);
# line 358 "C430GetCompanies.cp"
                       }
# line 358 "C430GetCompanies.cp"
                       
# line 358 "C430GetCompanies.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 358 "C430GetCompanies.cp"
                       sqlca.sqlerrd[2] = _sql->rowsread;
# line 358 "C430GetCompanies.cp"
                   }
# line 358 "C430GetCompanies.cp"
                   
# line 358 "C430GetCompanies.cp"
                   if (sqlca.sqlcode < 0)
# line 358 "C430GetCompanies.cp"
                   {
# line 358 "C430GetCompanies.cp"
                       error_handler();
# line 358 "C430GetCompanies.cp"
                   }
# line 358 "C430GetCompanies.cp"
                   
# line 358 "C430GetCompanies.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 358 "C430GetCompanies.cp"
                   {
# line 358 "C430GetCompanies.cp"
                       warning_handler();
# line 358 "C430GetCompanies.cp"
                   }
# line 358 "C430GetCompanies.cp"
                   
# line 358 "C430GetCompanies.cp"
               }
# line 358 "C430GetCompanies.cp"
               
# line 358 "C430GetCompanies.cp"
           }
# line 358 "C430GetCompanies.cp"
           

           /*
           ** Generated code ends here.
           */
# line 359 "C430GetCompanies.cp"


      if(sqlca.sqlcode == 100)	/* Fin de consulta. */
         break;

      /* Evaluar la Fecha de Corte asociada a los registros de la
         Empresa. */ 

      if(iProcType == 1)
      {
         /* La Fecha de Corte no corresponde a la Fecha del Sistema 
            menos 1. */
                                                                
         if(iChargeOffDate != iSystemDay)                                
         {
            continue; 
         }
      } 

      /* La informacion recuperada es almacenada en el arreglo de Empresas. */

      psCompanies[iCompCount].iPreffix=iPreffix;
      psCompanies[iCompCount].iBankGroup=iBankGroup;
      psCompanies[iCompCount].iCompanyID=iCompanyID;
      psCompanies[iCompCount].iChargeOffDate=iChargeOffDate;

      iCompCount++;    
   }

   
           /*
           ** SQL STATEMENT: 27
           ** EXEC SQL CLOSE companydata; 
           */
# line 388 "C430GetCompanies.cp"
# line 388 "C430GetCompanies.cp"
           {
# line 388 "C430GetCompanies.cp"
                _SQL_CT_HANDLES * _sql;
# line 388 "C430GetCompanies.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 388 "C430GetCompanies.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 388 "C430GetCompanies.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 388 "C430GetCompanies.cp"
               {
# line 388 "C430GetCompanies.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 388 "C430GetCompanies.cp"
                   _sql->stmttype = SQL_CLOSE_STMT;
# line 388 "C430GetCompanies.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 388 "C430GetCompanies.cp"
                   _sql->curName.fnlen = 11;
# line 388 "C430GetCompanies.cp"
                   strcpy(_sql->curName.first_name, "companydata");
# line 388 "C430GetCompanies.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 388 "C430GetCompanies.cp"
                   {
# line 388 "C430GetCompanies.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 388 "C430GetCompanies.cp"
                   }
# line 388 "C430GetCompanies.cp"
                   
# line 388 "C430GetCompanies.cp"
                   if (sqlca.sqlcode < 0)
# line 388 "C430GetCompanies.cp"
                   {
# line 388 "C430GetCompanies.cp"
                       error_handler();
# line 388 "C430GetCompanies.cp"
                   }
# line 388 "C430GetCompanies.cp"
                   
# line 388 "C430GetCompanies.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 388 "C430GetCompanies.cp"
                   {
# line 388 "C430GetCompanies.cp"
                       warning_handler();
# line 388 "C430GetCompanies.cp"
                   }
# line 388 "C430GetCompanies.cp"
                   
# line 388 "C430GetCompanies.cp"
               }
# line 388 "C430GetCompanies.cp"
               
# line 388 "C430GetCompanies.cp"
           }
# line 388 "C430GetCompanies.cp"
           

           /*
           ** Generated code ends here.
           */
# line 388 "C430GetCompanies.cp"
            
                                       
   
           /*
           ** SQL STATEMENT: 28
           ** EXEC SQL DEALLOCATE PREPARE companysql;

           */
# line 390 "C430GetCompanies.cp"
# line 390 "C430GetCompanies.cp"
           {
# line 390 "C430GetCompanies.cp"
                _SQL_CT_HANDLES * _sql;
# line 390 "C430GetCompanies.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 390 "C430GetCompanies.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 390 "C430GetCompanies.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 390 "C430GetCompanies.cp"
               {
# line 390 "C430GetCompanies.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 390 "C430GetCompanies.cp"
                   _sql->stmttype = SQL_DEALLOCATE_PREPARE;
# line 390 "C430GetCompanies.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 390 "C430GetCompanies.cp"
                   _sql->stmtName.fnlen = 10;
# line 390 "C430GetCompanies.cp"
                   strcpy(_sql->stmtName.first_name, "companysql");
# line 390 "C430GetCompanies.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 390 "C430GetCompanies.cp"
                   {
# line 390 "C430GetCompanies.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 390 "C430GetCompanies.cp"
                   }
# line 390 "C430GetCompanies.cp"
                   
# line 390 "C430GetCompanies.cp"
                   if (sqlca.sqlcode < 0)
# line 390 "C430GetCompanies.cp"
                   {
# line 390 "C430GetCompanies.cp"
                       error_handler();
# line 390 "C430GetCompanies.cp"
                   }
# line 390 "C430GetCompanies.cp"
                   
# line 390 "C430GetCompanies.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 390 "C430GetCompanies.cp"
                   {
# line 390 "C430GetCompanies.cp"
                       warning_handler();
# line 390 "C430GetCompanies.cp"
                   }
# line 390 "C430GetCompanies.cp"
                   
# line 390 "C430GetCompanies.cp"
               }
# line 390 "C430GetCompanies.cp"
               
# line 390 "C430GetCompanies.cp"
           }
# line 390 "C430GetCompanies.cp"
           

           /*
           ** Generated code ends here.
           */
# line 390 "C430GetCompanies.cp"


   
           /*
           ** SQL STATEMENT: 29
           ** EXEC SQL COMMIT WORK;

           */
# line 392 "C430GetCompanies.cp"
# line 392 "C430GetCompanies.cp"
           {
# line 392 "C430GetCompanies.cp"
                _SQL_CT_HANDLES * _sql;
# line 392 "C430GetCompanies.cp"
               _sqlinitctx(&_sql, CS_CURRENT_VERSION, CS_TRUE, &sqlca, (long 
# line 392 "C430GetCompanies.cp"
                   *)NULL, (CS_CHAR *)NULL);
# line 392 "C430GetCompanies.cp"
               if (_sql != (_SQL_CT_HANDLES *) NULL)
# line 392 "C430GetCompanies.cp"
               {
# line 392 "C430GetCompanies.cp"
                   _sql->stmtData.persistent = CS_FALSE;
# line 392 "C430GetCompanies.cp"
                   _sql->stmttype = SQL_TRANS;
# line 392 "C430GetCompanies.cp"
                   _sql->connName.lnlen = CS_UNUSED;
# line 392 "C430GetCompanies.cp"
                   if ((_sql->retcode = _sqlprolog(_sql)) == CS_SUCCEED)
# line 392 "C430GetCompanies.cp"
                   {
# line 392 "C430GetCompanies.cp"
                       _sql->retcode = ct_command(_sql->conn.command, 
# line 392 "C430GetCompanies.cp"
                           CS_LANG_CMD, "COMMIT WORK", 11, CS_UNUSED);
# line 392 "C430GetCompanies.cp"
                       _sql->retcode = ct_send(_sql->conn.command);
# line 392 "C430GetCompanies.cp"
                       _sql->hastate = (_sql->retcode == CS_RET_HAFAILOVER);
# line 392 "C430GetCompanies.cp"
                       _sql->retcode = _sqlResults(_sql);
# line 392 "C430GetCompanies.cp"
                       _sql->retcode = _sqlepilog(_sql);
# line 392 "C430GetCompanies.cp"
                   }
# line 392 "C430GetCompanies.cp"
                   
# line 392 "C430GetCompanies.cp"
                   if (sqlca.sqlcode < 0)
# line 392 "C430GetCompanies.cp"
                   {
# line 392 "C430GetCompanies.cp"
                       error_handler();
# line 392 "C430GetCompanies.cp"
                   }
# line 392 "C430GetCompanies.cp"
                   
# line 392 "C430GetCompanies.cp"
                   if (sqlca.sqlwarn[0] == 'W')
# line 392 "C430GetCompanies.cp"
                   {
# line 392 "C430GetCompanies.cp"
                       warning_handler();
# line 392 "C430GetCompanies.cp"
                   }
# line 392 "C430GetCompanies.cp"
                   
# line 392 "C430GetCompanies.cp"
               }
# line 392 "C430GetCompanies.cp"
               
# line 392 "C430GetCompanies.cp"
           }
# line 392 "C430GetCompanies.cp"
           

           /*
           ** Generated code ends here.
           */
# line 392 "C430GetCompanies.cp"


   /* Imprime la informacion previamente recuperada en pantalla. */

   for(iCompCount=0; iCompCount < iNumCompanies; iCompCount++)
   {  
      printf("%d|%d|%d\n", psCompanies[iCompCount].iPreffix,
                           psCompanies[iCompCount].iBankGroup,
                           psCompanies[iCompCount].iCompanyID);
   }                                                           

   free(psCompanies);

   return STDEXIT;
}

           /*
           ** Generated code begins here.
           */
# line 407 "C430GetCompanies.cp"

           /*
           ** Generated code ends here.
           */
# line 407 "C430GetCompanies.cp"
