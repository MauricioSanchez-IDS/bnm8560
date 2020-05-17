#ifndef _RUT_COMUN
#define _RUT_COMUN

/******************************************************************************
Identificacion: 	fechas.h
Autor: 			Gerardo Uriel Gamez Torres ( Banamex/ISD ) 
Instalacion: 		BANAMEX, S.A. 
Fecha:			20/dic/1999 
Version: 		1.0
*******************************************************************************
Objetivo: 		Archivo de encabezado de funciones de fechas
*******************************************************************************
Fecha de creacion :  	20/dic/1999
Ultima modificacion:	20/dic/1999
Modificacion:		
Descripcion:  		Contiene la declaracion de las funciones de fechas.
			
FUNCIONES INCLUIDAS: 

	- iInitFecha			Da inicio a uso de funciones de fechas
	- entertime			obtiene fecha y hora actual
	- hfecmasmenosdias_2k		suma o resta dias naturales
	- hfecmasmenosdiashab_2k 	suma o resta dias habiles
	- hdiffecnat 			obtiene diferencia en dias naturales
	- hdiffechab 			obtiene diferencia en dias habiles
	- caracfecha_2k 		determina si una fecha es o no habil
	 
******************************************************************************/
#include <stdio.h>
#include <stdlib.h>
#include <time.h>
				/* Banderas para indicar si los dias festivos
				 se tomaran de ARCHIVO(1) o sera INTERNA(0) */
#define INTERNA         0	/* Tabla en el codigo */
#define ARCHIVO         1	/* Tabla de archivo */

int iInitFecha( char * );
void entertime(int *, int *, int *, int *, int *, int *);
int hfecmasmenosdias_2k( int anio_ent, int mes_ent, int dia_ent, int cont,
			 int *anio_sal, int *mes_sal, int *dia_sal );
int hfecmasmenosdiashab_2k( int anio_ent, int mes_ent, int dia_ent, int cont,
			    int *anio_sal, int *mes_sal, int *dia_sal );
int hdiffecnat( int anio_ini, int mes_ini, int dia_ini,
		int anio_fin, int mes_fin, int dia_fin );
int hdiffechab( int anio_ini, int mes_ini, int dia_ini,
		int anio_fin, int mes_fin, int dia_fin );
int caracfecha_2k( int Anio, int Mes, int Dia );
void vCurrentDate( int *iAnio, int *iMes, int *iDia );


#endif /* _RUT_COMUN */
