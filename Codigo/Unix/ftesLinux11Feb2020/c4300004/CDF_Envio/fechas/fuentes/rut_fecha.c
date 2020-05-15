/******************************************************************************
Identificacion: 	rut_fecha.c
Nombre : 		rut_fecha
Autor: 			Gerardo Uriel Gamez Torres ( Banamex/ISD ) 
Instalacion: 		BANAMEX, S.A. 
Fecha:			20/dic/1999 
Version: 		1.0
*******************************************************************************
Objetivo: 		Proporcionar un conjunto de funciones que realizan 
			calculos con fechas
*******************************************************************************
Fecha de creacion :  	20/dic/1999
Ultima modificacion:	20/dic/1999
Modificacion:		Adaptacion a rutinas de fechas
Descripcion:  		Esta biblioteca esta compuesta por un conjunto de 
			funciones que permiten, entre otras cosas obtener la 
			fecha y hora actuales, asi como realizar operaciones 
			con fechas como son las de a una fecha agregarle dias 
			habiles o naturales para obtener una fecha habil; dadas
			dos fechas obtener la diferencia en dias habiles o 
			naturales; y finalmente dada una fecha determinar si es
			o no habil.
			
FUNCIONES INCLUIDAS: 

	- iInitFecha			Da inicio a uso de funciones de fechas
	- entertime			obtiene fecha y hora actual
	- hfecmasmenosdias_2k		suma o resta dias naturales
	- hfecmasmenosdiashab_2k 	suma o resta dias habiles
	- hdiffecnat 			obtiene diferencia en dias naturales
	- hdiffechab 			obtiene diferencia en dias habiles
	- caracfecha_2k 		determina si una fecha es o no habil
	 
	y las siguientes funciones internas:
	- Julian 
	- JulianToDate
	- DiadelaSem
	- checkdate
	- DiaNoHabil
	- SemSanta
	
******************************************************************************/
#include "fechas.h"
#include <math.h>
				/* nombre y path del archivo de configuracion */
#define NOM_FEST	"arc/dias_festivos.txt"

				/* declaracion de funciones internas */
static int 	SemSanta(double jul, int anio);
static double  	Julian(int Year, int Month, int Day);
static void 	JulianToDate(double JulianDate,int *Year,int *Month,int *Day);
static int 	DiadelaSem( int Anio, int Mes, int Dia );
static int 	checkdate( int year,  int month,  int day);
static int 	DiaNoHabil( double jul, int anio, int mes, int dia );

				/* valores de dias festivos si no hay archivo */
static int	tabla_dias_fest[500] = { 1, 5, 21, 1, 16, 20, 12, 25 };
static int	tabla_mes_fest[500] =  { 1, 2,  3, 5,  9, 11, 12, 12 };
static int	Num_dias_fest = 12;

/******************************************************************************

Autor: 			Gerardo Uriel Gamez Torres (Banamex/ISD) 
Fecha de creacion:  	20/sept/1999
Ultima modificacion:	20/sept/1999 
Objetivo: 		Dada una fecha en formato AAAA MM DD ( numericos ) 
			permite sumar dias habiles( positivos o negativos ) 
			y obtiene un dia habil, sin considerar los dias no 
			habiles ( fines de semana - sabados, domingos - y 
			dias festivos incluyendo semana santa ).

Parametros: 
	- anio_ent, 	A&o de la fecha en cuestion
	- mes_ent,	Mes de la fecha en cuestion 
	- dia_ent, 	Dia de la fecha en cuestion
	- cont,		Numero de dias habiles a sumar o restar
		* para sumar el valor debe ser positivo
		* para restar el valor debe ser negativo
Salidas: 
	- *anio_sal,	A&o de la fecha calculada del dia habil 
	- *mes_sal, 	Mes de la fecha calculada del dia habil 
	- *dia_sal 	Dia de la fecha calculada del dia habil 

*******************************************************************************/
int hfecmasmenosdiashab_2k( int anio_ent, int mes_ent, int dia_ent, int cont,
		 	    int *anio_sal, int *mes_sal, int *dia_sal )
{
	int A, M, D;
	double jul, jul_ini;

	jul = jul_ini = Julian (anio_ent, mes_ent, dia_ent);
	if( checkdate( anio_ent, mes_ent, dia_ent ) < 0 || jul < 0 )
	{
		return( -1 );
	}

	if( cont > 0 )
	{
		while( cont != 0 )
		{
			JulianToDate( jul, &A, &M, &D );
			if( !DiaNoHabil( jul, A, M, D ) && jul != jul_ini )
				cont --;
			jul++;
		}
		JulianToDate( --jul, anio_sal, mes_sal, dia_sal );
	}
	else
	{
		if( jul < ( cont < 0? (-1)*cont : cont ) )
		{
			printf(" Error:Limite minimo ( 01/enero/1980 )\n" );
			return( -2 );
		}
		while( cont != 0 )
		{
			JulianToDate( jul, &A, &M, &D );
			if( !DiaNoHabil( jul, A, M, D ) && jul != jul_ini )
				cont++;
			jul--;
		}
		JulianToDate( ++jul, anio_sal, mes_sal, dia_sal );
	}

	return( 1 );
} /* fin hfecmasmenosdiashab_2k */

/******************************************************************************

Autor: 			Gerardo Uriel Gamez Torres (Banamex/ISD) 
Fecha de creacion:  	20/dic/1999
Ultima modificacion:	20/dic/1999 
Objetivo: 		Dada una fecha en formato AAAA MM DD ( numericos ) 
			permite sumar dias naturales( positivos o negativos )
			y obtener un dia habil, sin considerar los dias no 
			habiles ( fines de semana - sabados, domingos - y
			dias festivos incluyendo semana santa ).

Parametros: 
	- anio_ent, 	A&o de la fecha en cuestion
	- mes_ent,	Mes de la fecha en cuestion 
	- dia_ent, 	Dia de la fecha en cuestion
	- cont,		Numero de dias habiles a sumar o restar
		* para sumar el valor debe ser positivo
		* para restar el valor debe ser negativo
Salidas: 
	- *anio_sal,	A&o de la fecha calculada del dia habil 
	- *mes_sal, 	Mes de la fecha calculada del dia habil
	- *dia_sal 	Dia de la fecha calculada del dia habil

*******************************************************************************/
int hfecmasmenosdias_2k( int anio_ent, int mes_ent, int dia_ent, int cont,
			 int *anio_sal, int *mes_sal, int *dia_sal )
{
	int A, M, D;
	double jul;

	jul = Julian (anio_ent, mes_ent, dia_ent);
	if( checkdate( anio_ent, mes_ent, dia_ent ) < 0 || jul < 0 )
	{
		return( -1 );
	}

	jul += cont;

	if( cont > 0 )
	{
		JulianToDate( jul, &A, &M, &D );
		while( DiaNoHabil( jul, A, M, D ) )
		{
			jul++;
			JulianToDate( jul, &A, &M, &D );
		}
	}
	else
	{
		if( jul < ( cont < 0? (-1)*cont : cont ) )
		{
			printf(" Error:Limite minimo ( 01/enero/1980 )\n" );
			return( -2 );
		}
		JulianToDate( jul, &A, &M, &D );
		while( DiaNoHabil( jul, A, M, D ) )
		{
			jul--;
			JulianToDate( jul, &A, &M, &D );
		}
	}

	*anio_sal = A; *mes_sal = M; *dia_sal = D;

	return( 1 );
} /* fin hfecmasmenosdias_2k */

/******************************************************************************

Autor: 			Gerardo Uriel Gamez Torres (Banamex/ISD) 
Fecha de creacion:  	20/dic/1999
Ultima modificacion:	20/dic/1999 
Objetivo: 		A partir de dos fechas obtiene el numero de dias 
			naturales transcurridos.

Parametros: 
	- anio_ini, 	A&o de la fecha inicial
	- mes_ini,	Mes de la fecha inicial
	- dia_ini, 	Dia de la fecha inicial
	- anio_fin, 	A&o de la fecha final
	- mes_fin,	Mes de la fecha final
	- dia_fin, 	Dia de la fecha final
Salidas: 
	- Dias naturales transcurridos, en el valor de regreso de la funcion

*******************************************************************************/
int hdiffecnat( int anio_ini, int mes_ini, int dia_ini,
		int anio_fin, int mes_fin, int dia_fin )
{
	double jul_ini, jul_fin;

	jul_ini = Julian (anio_ini, mes_ini, dia_ini);
	jul_fin = Julian (anio_fin, mes_fin, dia_fin);

	if( checkdate( anio_ini, mes_ini, dia_ini ) < 0 || (int)jul_ini < 0 )
		return( -1 );

	if( checkdate( anio_fin, mes_fin, dia_fin ) < 0 || (int)jul_fin < 0 )
		return( -1 );
			    /* la fecha inicial debe ser menor que la final */
	if( (int)jul_ini > (int)jul_fin )
		return( -2 );

	return((int)(jul_fin - jul_ini) );
}/* fin hdiffecnat */

/******************************************************************************

Autor: 			Gerardo Uriel Gamez Torres (Banamex/ISD) 
Fecha de creacion:  	20/dic/1999
Ultima modificacion:	20/dic/1999 
Objetivo: 		A partir de dos fechas obtiene el numero de dias 
			habiles transcurridos.

Parametros: 
	- anio_ini, 	A&o de la fecha inicial
	- mes_ini,	Mes de la fecha inicial
	- dia_ini, 	Dia de la fecha inicial
	- anio_fin, 	A&o de la fecha final
	- mes_fin,	Mes de la fecha final
	- dia_fin, 	Dia de la fecha final
Salidas: 
	- Dias habiles transcurridos, en el valor de regreso de la funcion

*******************************************************************************/
int hdiffechab( int anio_ini, int mes_ini, int dia_ini,
		int anio_fin, int mes_fin, int dia_fin )
{
	int A, M, D, cont = 0;
	double jul_ini, jul_fin, jul_tem;

	jul_ini = Julian (anio_ini, mes_ini, dia_ini);
	jul_fin = Julian (anio_fin, mes_fin, dia_fin);

	if( checkdate( anio_ini, mes_ini, dia_ini ) < 0 || (int)jul_ini < 0 )
		return( -1 );

	if( checkdate( anio_fin, mes_fin, dia_fin ) < 0 || (int)jul_fin < 0 )
		return( -1 );

			    /* la fecha inicial debe ser menor que la final */
	if( (int)jul_ini > (int)jul_fin )
		return( -2 );

	for( jul_tem = jul_ini+1; jul_tem <= jul_fin; jul_tem++ )
	{
		JulianToDate( jul_tem, &A, &M, &D );
		if( !DiaNoHabil( jul_tem, A, M, D ) )
			cont++;
	}

	return( cont );
}/* fin hdiffechab */

/******************************************************************************

Autor: 			Gerardo Uriel Gamez Torres (Banamex/ISD) 
Fecha de creacion:  	20/dic/1999	
Ultima modificacion:	20/dic/1999	
Objetivo: 		Dada una fecha en formato AAAA MM DD ( numericos ) 
			permite determinar si es o no habil.
Parametros: 
	- anio, 	A&o de la fecha en cuestion
	- mes,		Mes de la fecha en cuestion 
	- dia, 		Dia de la fecha en cuestion
Salidas: 
	- 0,		fecha no habil
	- 1, 		fecha habil

*******************************************************************************/
int caracfecha_2k( int anio, int mes, int dia )
{
	double jul;

	jul = Julian (anio, mes, dia);
	if( checkdate( anio, mes, dia ) < 0 || jul < 0 )
	{
		return( -1 );
	}

	if( DiaNoHabil( jul, anio, mes, dia ) )
		return( 0 );
	else
		return( 1 );

} /* fin caracfecha_2k */

/****************************************************************************

Autor:			Codigo proporcionado por Victor Camacho
Fecha de creacion :  
Ultima modificacion :	20/sept/1999 
Objetivo:  		Dada la fecha gregoriana regresa el dia juliano, tomando
			como base el a&o 1980.
Parametros: 
	- anio, 	A&o a convertir
	- mes, 		Mes a convertir
	- dia,		Dia a convertir
Salidas: 
	- la fecha en juliano en el valor de regreso de la funcion
   
****************************************************************************/
static double Julian(int anio, int mes, int dia)
{
	static unsigned int   Yr, Mth;
	static double NoLeap, Leap, Days, Yrs, Fraccion, Entero;

	if (anio < 0)      
		Yr = anio + 1;
	else               
		Yr = anio;

	Mth = mes;

	if (mes < 3) 
	{
		Mth = Mth + 12;
		Yr  = Yr - 1;
	}

	Yrs = 365.25 * Yr;
	Fraccion = modf((double)Yrs, (double *)&Entero);
	if (Yrs<0 && Fraccion!=0)
		Yrs=Entero + 1;
	else
	 	Yrs=Entero;

	Entero = 30.6001 * (Mth+1);
	Fraccion = modf(Entero, &Entero);
	Days = (double)(Yrs + Entero + dia) - 723244.0;

	if (Days < (double)-145068.0)
		return Days;
   	else 
   	{
	 	Yrs = Yr/100;
	 	Fraccion = modf (Yrs, &Entero);
	 	if (Yrs<0 && Fraccion!=0)
	       		Yrs=Entero-1;
	 	Fraccion = modf (Yrs, &Entero);
	 	NoLeap = Entero;
	 	Yrs = NoLeap/4;
	 	Fraccion = modf (Yrs, &Entero);
	 	if (Yrs<0 && Fraccion!=0)
	    		Yrs=Entero-1;
	 	Fraccion = modf (Yrs, &Entero);
	 	Leap = 2 - NoLeap + Entero;
	 	Leap = Leap + Days;
	 	return (Leap);
   	}
}/* fin Julian */

/****************************************************************************

Autor:			Codigo proporcionado por Victor Camacho
Fecha de creacion :  
Fecha de modificacion :	20/sep/1999  
Objetivo:  		Convertir una fecha juliana a formato gregoriano.
Parametros: 
	- JulianDate, 	Fecha a convertir en formato juliano
Salidas: 
	- *anio, 	A&o de fecha convertida (formato gregoriano) 
	- *mes,  	Mes de fecha convertida (formato gregoriano) 
	- *dia, 	Dia de fecha convertida (formato gregoriano) 

****************************************************************************/
static void JulianToDate(double JulianDate, int *anio, int *mes, int *dia)
{
	static double   JulCalDay, TempDay, Correction, Century, Days, Mo,
			JulDate, Fraccion, Entero;

	JulDate = JulianDate + 2444239L;
	Fraccion = modf (JulDate, &JulDate);
	if (JulianDate < -145078L)
		JulCalDay = JulDate;
	else 
	{
		TempDay = (JulDate-1867216.25) / 36524.25;
		Fraccion = modf (TempDay, &TempDay);
		JulCalDay = JulDate + 1 + TempDay;
		TempDay = TempDay / 4;
		Fraccion = modf (TempDay, &Entero);
		if (TempDay<0 && Fraccion!=0)
			TempDay=Entero-1;
		Fraccion = modf (TempDay, &Entero);
		JulCalDay = JulCalDay - Entero;
	}
	Correction = JulCalDay + 1524;
	Century = (Correction-122.1)/365.25;
	Fraccion = modf (Century, &Century);
	Days = Century *  365.25;
	Fraccion = modf (Days, &Days);
	Mo = (Correction - Days) / 30.6001;
	Fraccion = modf (Mo, &Mo);
	Entero = Mo * 30.6001;
	Fraccion = modf (Entero, &Entero);
	Entero = Correction-Days-Entero;
	Fraccion = modf (Entero, &Entero);
	*dia = (int)Entero;

	if (Mo>13.5)
	 	Entero = Mo-13;
	else
	 	Entero = Mo-1;
	Fraccion = modf(Entero, &Entero);
	*mes = (int)Entero;

	if (Entero>2)
	 	Entero = Century - 4716;
	else
	 	Entero = Century - 4715;
	Fraccion = modf(Entero, &Entero);
	*anio = (int)Entero;
}/* fin JulianToDate */

/***************************************************************************

Autor: 			Gerardo Uriel Gamez Torres 
Fecha de creacion :  	20/sept/1999 
Ultima modificacion : 
Objetivo: 		Obtiene el dia de la semana ( del 1 al 7 ), Lunes es
			el dia 1 y Domingo el dia 7.
Parametros: 
	- anio, 	A&o de la fecha a obtener el dia.
	- mes,		Mes de la fecha a obtener el dia. 
	- dia,		Dia de la fecha a obtener el dia.
Salidas: 
	- El dia de la semana correspondiente a la fecha dada se devuelve en el
	  nombre de la funcion 
   
****************************************************************************/
static int DiadelaSem( int anio, int mes, int dia )
{
	int ind;
			/* january a febrary are trated as month 13 and 14 */
			/* respectively, from the year before */

	if( ( mes == 1 ) || ( mes == 2 ) )
	{
		mes += 12;
		anio--;
	}
	ind = ( dia+2*mes +3*(mes+1)/5 +anio +anio/4 -anio/100 +anio/400 ) % 7;

	return( ind+1 );

} /* fin DiadelaSem */

#define LEAP(year)  ((year%4 == 0) && (year%100 != 0) || (year%400 == 0)) 
char  days[13]      = {0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
char *monthname[13] = {"", "Enero", "Febrero", "Marzo", "Abril", "Mayo","Junio",
		       "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre",
		       "Diciembre"}; 

/******************************************************************************

Autor: 			Marcel J.E. Mol 
			Mail bugs to: email: marcel@duteca.tudelft.nl 
Fecha de creacion : 	12/28/89              (first release) 
Ultima modificacion : 
Objetivo: 		checks if the given date is a valid one. 
			if not, it just exits.
Parametros: 
	- year, 	A&o de la fecha a validar. 
	- month, 	Mes de la fecha a validar. 
	- day,		Dia de la fecha a validar. 
Salidas: 
	- El resultado es devuelto en el nombre de la funcion, en caso de no ser
	 valido se dregresa un -1.

*******************************************************************************/
static int checkdate( int year,  int month,  int day)
{
    int dim;

    if (year < 0) 
    {
        printf(" %d is an invalid year\n", year);
        return(-1);
    }
 
    if ((month < 1) || (month > 12)) 
    {
        printf("%d is an invalid month\n", month);
        return(-1);
    }
 
    dim = days[month];
    if ((month == 2) && LEAP(year)) 
        dim++;
    if ((day > dim) || (day < 1)) 
    {
        printf("%d is an invalid day in %s %d\n", day, monthname[month], year);
        return(-1);
    }

   return( 0 );

} /* fin checkdate */

/******************************************************************************

Autor:  		Gerardo Uriel Gamez Torres (Banamex/ISD)
			(Basada en el codigo proporcionado por Jorge Castro)
Fecha de creacion : 	20/sept/1999 
Ultima modificacion : 
Objetivo:  		Determina si una fecha es no habil, incluyendo
			- Cambio de poder,
			- Fines de semana,
			- Dias festivos y 
			- Semana Santa.
Parametros: 
	- jul, 		Fecha en formato juliano
	- anio, 	A&o de la fecha a verificar
	- mes, 		Mes de la fecha a verificar
	- dia, 		Dia de la fecha a verificar
Salidas: 
	- Regresa 1 si la fecha es dia festivo, de lo contrario sera 0.

*******************************************************************************/
static int DiaNoHabil( double jul, int anio, int mes, int dia ) 
{
	int   i;

	if ( DiadelaSem(anio,mes,dia) == 7 || DiadelaSem(anio, mes, dia) == 6 ) 
    		return(1);

	if ( SemSanta(jul, anio) ) 
    		return(1);
	for(i=0; i<Num_dias_fest; i++)
   		if( mes == tabla_mes_fest[i] && dia == tabla_dias_fest[i] )
			return(1);
/*
	if( (anio % 6) == 4 && mes == 12 && dia == 1 )  / *cambio presidencial* /
    		return(1);
*/
	return(0);     
} /* fin DiaNoHabil */

#define PARA_JUEVES_SANTO	3
#define PARA_VIERNES_SANTO	2

/******************************************************************************

Autor:  		Gerardo Uriel Gamez Torres (Banamex/ISD)
			( Basada en el codigo proporcionado por Jorge Castro,
			 PRAXIS  DAH   )
Fecha de creacion :  	JUN/1998
Ultima modificacion :   Adaptacion, 20/sept/1999
Objetivo: 		Verificar si una fecha es Jueves o Viernes Santos. 
Parametros: 
	- jul, 		Fecha juliana a validar.
	- anio,		A&o de la fecha a validar.
Salidas: 
	- Regresa 1 si la fecha esta en semana santa, de lo contrario sera 0        
*******************************************************************************/
static int SemSanta(double jul, int anio )
{
	int g, c, h, i, j, l, domingo_pascua, mes_pascua;
	double	fecha_a_comparar;

				/* formatea el a&o a 4 posiciones */
	if ( anio < 100 )
	{
   		if (anio > 60) 
			anio += 1900;
   		else 
			anio += 2000;
	}
			/* se calcula el domingo de pascua para el a&o dado */
	g = anio % 19;
	c = anio/100;
	h = (c- (c/4) - ((8*c + 13) / 25 ) + (19*g) + 15 ) %30;
	i = h - (h/28)*(1-(h/28)*(29/(h+1)) * ((21-g)/11));
	j = (anio + (anio/4) + i + 2 -c + (c/4))%7;
	l = i - j;
			/* mes en el que cae el domingo de pascua */
	mes_pascua = 3 + (( l + 40) / 44);

			/* domingo de pascua */
	domingo_pascua = l + 28 - (31 * (mes_pascua / 4));

	fecha_a_comparar = Julian( anio, mes_pascua, domingo_pascua );

	if( ( jul == (fecha_a_comparar-PARA_JUEVES_SANTO) ) ||
	    ( jul == (fecha_a_comparar-PARA_VIERNES_SANTO) ) )
		return( 1 );
	else
		return( 0 );

}  /* fin SemSanta */

/****************************************************************************

Autor: 			Gerardo Uriel Gamez Torres (Banamex/ISD)
Fecha de creacion: 	23/abr/1997
Fecha de Modificacion:	20/dic/1999
Objetivo: 		Obtiene la fecha y hora actual. Estos valores se 
			almacenan en los parametros formales de la funcion.
Parametros:	
	- iDia, 	Dia de la fecha actual.
	- iMes, 	Mes de la fecha actual.
	- iAno, 	A&o de la fecha actual.
	- iHora,  	Hora de la fecha actual.
	- iMins, 	Minutos de la fecha actual.
	- iSegs, 	Segundos de la fecha actual.

Retorno:	No devuelve valores.

****************************************************************************/
void entertime(int *iDia,int *iMes,int *iAno,int *iHora,int *iMins,int *iSegs)
{
	time_t 	lt;   		/* Fecha actual en formato numerico         */
	struct tm *prTime; 	/* Estructura para contener la fecha        */

	lt = time(NULL);	
	prTime = localtime(&lt);

	prTime->tm_year += 1900;
   
	*iDia = prTime->tm_mday;
	*iMes = prTime->tm_mon + 1; 
	*iAno = prTime->tm_year;
	*iHora = prTime->tm_hour;
	*iMins = prTime->tm_min;
	*iSegs = prTime->tm_sec;
} /* fin entertime */

#include <string.h>

/******************************************************************************

Autor: 			Gerardo Uriel Gamez Torres (Banamex/ISD) 
Fecha de creacion:  	20/dic/1999
Ultima modificacion:	20/dic/1999 
Objetivo: 		Lee archivo que contiene dias festivos, para incluirlos
			como dias no habiles. En caso de que no se encuentre el
			archivo se toma los valores por omision, los cuales se
			encuentran en codigo en los arreglos de tabla_mes_fest,
			tabla_dias_fest.
Parametros: 
	- No recibe
Salidas: 
	- Tipo de tabla de dias festivos a usar:
		*INTERNA, valores por omision
		*ARCHIVO, se leyo de un archivo los dias festivos

*******************************************************************************/
int iInitFecha( char *sTrayectoria )
{
	FILE	*ae;			/* apuntador al archivo de entrada */
	char	cad[256];
	char	*aptem, tem[256];
	int	lar1, cuenta_dias = 0;

	sprintf(cad,"%s/dias_festivos.txt",sTrayectoria);
	if( ( ae = fopen( cad, "r" ) ) == NULL )
	{
		//printf("No se pudo abrio archivo de festivos %s\n", cad );
		//printf("Se toma tabla interna\n");
		return( INTERNA );
	}

	while( fgets( cad, 80, ae ) != NULL )
	{
		if( cad[0] == '#' )	/* el # indica linea de comentarios */
			continue;	/* la cual no se considera */
		aptem = strchr( cad, ',' );
		lar1 = aptem - cad;
		aptem++;

		strncpy( tem, cad, lar1 );
		tem[strlen(tem)] = '\0';
		tabla_mes_fest[cuenta_dias] = atoi( tem );
		strcpy( tem, aptem );
		tem[strlen(tem)] = '\0';
		tabla_dias_fest[cuenta_dias++] = atoi( tem );
		memset( tem, 0, strlen(tem) );
	}

	fclose( ae );
	
	Num_dias_fest = cuenta_dias;
	return( ARCHIVO );
} /* fin iIniFecha */
