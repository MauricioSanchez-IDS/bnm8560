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

EXEC SQL INCLUDE SQLCA;

EXEC SQL WHENEVER SQLERROR CALL error_handler();    
EXEC SQL WHENEVER SQLWARNING CALL warning_handler();
EXEC SQL WHENEVER NOT FOUND CONTINUE;               

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
