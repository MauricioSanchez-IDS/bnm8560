
/*
** Generated code begins here.
*/
# line 1 "C430ErrHandle.cp"

/*
** This file was generated on Tue Oct  2 20:29:08 2018
**  by Sybase Embedded SQL Preprocessor Sybase ESQL/C Precompiler/15.7/P-EBF271
** 15 SP139/DRV.15.7.0.13/Linux x86_64/Linux 2.6.18-128.el5 x86_64/BUILD1570-05
** 3/64bit/OPT/Tue Jul 25 04:17:53 2017
*/
# line 1 "C430ErrHandle.cp"
# line 1 "C430ErrHandle.cp"
#define _SQL_SCOPE extern
# line 1 "C430ErrHandle.cp"
#include <sybhesql.h>

/*
** Generated code ends here.
*/
# line 1 "C430ErrHandle.cp"
/* NOMBRE       : C430ErrHandle                                              */
/* DESCRIPCION  : Definicion de Rutinas para manejo de Errores y Mensajes de */
/*                Alerta.                                                    */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 26/06/2003                                                 */
/* CONTROL DE                                                                */
/* VERSIONES    : V.1.0                                                      */
/* CONTROL DE MODIFICACION                                                   */
/*      IS      NOMBRE                  FECHA           DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     26/06/2003     Primera Version         */
/* Copyright Derechos Reservados Banamex S.A. de C.V 2003a                   */
/*   Observaciones:                                                          */
/*                                                                           */

#include <stdio.h>
#include "C430TransCCF.h"


/*
** SQL STATEMENT: 1
** EXEC SQL INCLUDE SQLCA;

*/
# line 19 "C430ErrHandle.cp"
# line 19 "C430ErrHandle.cp"
SQLCA sqlca;

/*
** Generated code ends here.
*/
# line 19 "C430ErrHandle.cp"



/*
** SQL STATEMENT: 2
** EXEC SQL WHENEVER SQLERROR CALL error_handler();
*/
# line 21 "C430ErrHandle.cp"
    

/*
** SQL STATEMENT: 3
** EXEC SQL WHENEVER SQLWARNING CALL warning_handler();
*/
# line 22 "C430ErrHandle.cp"


/*
** SQL STATEMENT: 4
** EXEC SQL WHENEVER NOT FOUND CONTINUE; 
*/
# line 23 "C430ErrHandle.cp"
               

/* NOMBRE       : error_handler                                              */
/* DESCRIPCION  : Manejador de Errores ocurridos en la Base de Datos.        */
/* PARAMETROS   : Ninguno.                                                   */
/* SALIDAS      : Ninguna.                                                   */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 26/06/2003                                                 */
/* CONTROL DE                                                                */
/* VERSIONES    : V.1.0                                                      */
/* CONTROL DE MODIFICACION                                                   */
/*      IS      NOMBRE                  FECHA           DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     26/06/2003     Primera Version         */
/* Copyright Derechos Reservados Banamex S.A. de C.V 2003a                   */
/*   Observaciones:                                                          */
/*                                                                           */

void error_handler()
{
   /* Imprime el codigo del error ocurrido. */

  /*fprintf(stderr, "\n** SQLCODE=(%d)", sqlca.sqlcode); */
   fprintf(stderr, "\n** SQLCODE=(%ld)", sqlca.sqlcode);

	if (sqlca.sqlcode == -4023)
	{
		fprintf(stderr, "\n** %s", sqlca.sqlerrm.sqlerrmc);
	}
	else
	{

		   /* Imprime la descripcion del error ocurrido. */

		   if(sqlca.sqlerrm.sqlerrml) 
		   {
		      fprintf(stderr, "\n** SQL Server Error ");
		      fprintf(stderr, "\n** %s", sqlca.sqlerrm.sqlerrmc);
		   }

		   fprintf(stderr, "\n\n");

		   exit(ERREXIT);
	}
}

/* NOMBRE       : warning_handler                                            */
/* DESCRIPCION  : Manejador de Mensajes de Alerta generados porla Base de    */
/*                Datos.                                                     */
/* PARAMETROS   : Ninguno.                                                   */
/* SALIDAS      : Ninguna.                                                   */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 26/06/2003                                                 */
/* CONTROL DE                                                                */
/* VERSIONES    : V.1.0                                                      */
/* CONTROL DE MODIFICACION                                                   */
/*      IS      NOMBRE                  FECHA           DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     26/06/2003     Primera Version         */
/* Copyright Derechos Reservados Banamex S.A. de C.V 2003a                   */
/*   Observaciones:                                                          */
/*                                                                           */

void warning_handler()
{

   /* Indica si la informacion devuelta por el servidor fue truncada. */

   if(sqlca.sqlwarn[1] == 'W')
      fprintf(stderr, "\n** Data truncated.\n");

   /* Indica si las variables declaradas por el usuario resultaron
      insuficientes para alojar la informacion devuelta por el
      servidor. */

   if(sqlca.sqlwarn[3] == 'W')
      fprintf(stderr, "\n** Insufficient host variables to store results.\n");

   return;
}

/*
** Generated code begins here.
*/
# line 103 "C430ErrHandle.cp"

/*
** Generated code ends here.
*/
# line 103 "C430ErrHandle.cp"
