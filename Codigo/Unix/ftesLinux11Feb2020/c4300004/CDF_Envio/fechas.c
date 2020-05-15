#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <math.h>
#include <string.h>
#include "fechas.h"

#define LEAP( iYear )  ( ( iYear%4 == 0 ) && ( iYear % 100 != 0 ) || ( iYear % 400 == 0 ) )
#define MAX_DIAS_HABILES    100

static char     days[13] = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
static long     lDiasNoHabiles[MAX_DIAS_HABILES]; /* Este arreglo es cargado de catalogo P1313 */
static short    iContadorNoHabiles = 0;

/* Definicion de funciones Estaticas */

static double   Julian( int, int, int );
static void     JulianToDate( double, int *, int *,int * );
static int      iDiaDeLaSemana( int, int, int );

/****************************************************************************
Nombre de la funcion: DiaNoHabil
Version: 1.0
Descripcion: Funcion que valida si una fecha es o no habil, basada en catalogos
             del S080

Autor: Jesus Robledo Martinez
Instalacion: BANAMEX-(1605)

Fecha de creacion: 09/11/2006
Fecha de ultima actualizacion:

Valor de regreso: void
Documentacion de parametros:
PARAMETRO       TIPO                DESCRIPCION
iAnio           int                 Anio en formato AAAA
iMes            int                 Mes en formato MM
iDia            int                 Dia en formato DD

-= Historia de modificaciones =-

Fecha de modificacion:
Autor de modificacion:
Descripcion de modificacion:
*****************************************************************************/
int DiaNoHabil( int iAnio, int iMes, int iDia )
{
    int iDiaSemana;
    short iContador;
    long lAnioCompleto;
    char sAnioCompleto[9];

    iDiaSemana = iDiaDeLaSemana( iAnio, iMes, iDia );
    if( iDiaSemana == 7 || iDiaSemana == 6 ) return( 1 );
    sprintf( sAnioCompleto, "%04d%02d%02d", iAnio, iMes, iDia );
    sAnioCompleto[8] = '\0';
    lAnioCompleto = ( long) atol( sAnioCompleto );
    for( iContador = 0; iContador < iContadorNoHabiles; iContador ++ )
        if( lDiasNoHabiles[iContador] == lAnioCompleto ) return( 1 );
        return(0);
}

/****************************************************************************
Nombre de la funcion: CheckDate
Version: 1.0
Descripcion: Funcion que valida si fecha es valida, por medio de reglas basicas

Autor: Jesus Robledo Martinez
Instalacion: BANAMEX-(1605)

Fecha de creacion: 09/11/2006
Fecha de ultima actualizacion:

Valor de regreso: void
Documentacion de parametros:
PARAMETRO       TIPO                DESCRIPCION
iYear           int                 Anio en formato AAAA
iMonth          int                 Mes en formato MM
iDay            int                 Dia en formato DD

-= Historia de modificaciones =-

Fecha de modificacion:
Autor de modificacion:
Descripcion de modificacion:
*****************************************************************************/

int CheckDate( int iYear,  int iMonth,  int iDay )
{
    int iDim;

    if( iYear < 0 ) return( -1 );
    if( ( iMonth < 1 ) || ( iMonth > 12 ) ) return( -1 );
    iDim = days[iMonth];
    if( ( iMonth == 2 ) && LEAP( iYear ) ) iDim ++;
    if( ( iDay > iDim) || ( iDay < 1 ) ) return( -1 );
    return( 0 );
}

/****************************************************************************
Nombre de la funcion: iInitDate
Version: 1.0
Descripcion: Funcion para inicializar libreria de fechas

Autor: Jesus Robledo Martinez
Instalacion: BANAMEX-(1605)

Fecha de creacion: 09/11/2006
Fecha de ultima actualizacion:

Valor de regreso: void
Documentacion de parametros:
PARAMETRO       TIPO                DESCRIPCION
Ninguno         Ninguno             Ninguno

-= Historia de modificaciones =-

Fecha de modificacion:
Autor de modificacion:
Descripcion de modificacion:
*****************************************************************************/
int iInitDate()
{
    int iAnio, iMes, iDia;
    short iContador;
    int iRetorno;
    long lAnioCurrent[20];
    short iContadorAnioCorriente;
    long lAnioAnterior[20];
    short iContadorAnioAnterior;

    vCurrentDate( &iAnio, &iMes, &iDia );
    iRetorno = iCatalogoDiasInhabiles( lAnioCurrent, &iContadorAnioCorriente, ( short) iAnio );
    memcpy(lDiasNoHabiles,lAnioCurrent,sizeof(long)*iContadorAnioCorriente);
    iContadorNoHabiles += iContadorAnioCorriente;
    iRetorno = iCatalogoDiasInhabiles( lAnioAnterior, &iContadorAnioAnterior, ( short) ( iAnio - 1 ) );
    memcpy(&lDiasNoHabiles[iContadorAnioCorriente],lAnioAnterior,sizeof(long)*iContadorAnioAnterior);
    iContadorNoHabiles += iContadorAnioAnterior;
    return 0;
}

/****************************************************************************
Nombre de la funcion: vCurrentDate
Version: 1.0
Descripcion: Funcion que regresa la fecha del sistema

Autor: Jesus Robledo Martinez
Instalacion: BANAMEX-(1605)

Fecha de creacion: 09/11/2006
Fecha de ultima actualizacion:

Valor de regreso: void
Documentacion de parametros:
PARAMETRO       TIPO                DESCRIPCION
iAnio           int                 Anio en formato AAAA
iMes            int                 Mes en formato MM
iDia            int                 Dia en formato DD


-= Historia de modificaciones =-

Fecha de modificacion:
Autor de modificacion:
Descripcion de modificacion:
*****************************************************************************/
void vCurrentDate( int *iAnio, int *iMes, int *iDia )
{
    time_t  tm;
    struct  tm *ptrTm;

    tm = time( NULL );
    ptrTm = localtime( &tm );
    ptrTm->tm_year += 1900;
    *iDia = ptrTm->tm_mday;
    *iMes = ptrTm->tm_mon + 1;
    *iAnio = ptrTm->tm_year;
}

/****************************************************************************
Nombre de la funcion: iObtenDiaSiguienteAnteriorHabil_2K
Version: 1.0
Descripcion: Funcion calcula siguiente/anterior dia habil basada en un dia habil
             donde siguiente anterior puede ser un numero positivo o negativo.

Autor: Jesus Robledo Martinez
Instalacion: BANAMEX-(1605)

Fecha de creacion: 09/11/2006
Fecha de ultima actualizacion:

Valor de regreso: void
Documentacion de parametros:
PARAMETRO       TIPO                DESCRIPCION
lInFecha        long                Fecha Origen ( Dia habil )
iContador       int                 Numero de dias adelante o atras
lOuFecha        long *              Fecha Calculada


-= Historia de modificaciones =-

Fecha de modificacion:
Autor de modificacion:
Descripcion de modificacion:
*****************************************************************************/
int iObtenDiaSiguienteAnteriorHabil_2K( long lInFecha, int iContador, long *lOuFecha )
{
    int     iAnio, iMes, iDia;
    double  dJul, dJulIni;
    int     iInAnio, iInMes, iInDia;
    int     iOuAnio, iOuMes, iOuDia;
    char    sInFecha[9];
    char    sOuFecha[9];

    sprintf( sInFecha, "%08ld", lInFecha );
    sInFecha[8] = '\0';
    iInDia = atoi( &sInFecha[6] );
    sInFecha[6] = '\0';
    iInMes = atoi( &sInFecha[4] );
    sInFecha[4] = '\0';
    iInAnio = atoi( sInFecha );
    dJul = dJulIni = Julian( iInAnio, iInMes, iInDia );
    if( CheckDate( iInAnio, iInMes, iInDia ) < 0 || dJul < 0 ) return( -1 );
    if( iContador > 0 ){
        while( iContador != 0 ){
            JulianToDate( dJul, &iAnio, &iMes, &iDia );
            if( !DiaNoHabil( iAnio, iMes, iDia ) && dJul != dJulIni )
                iContador --;
            dJul ++;
        }
        JulianToDate( -- dJul, &iOuAnio, &iOuMes, &iOuDia );
    }else{
        if( dJul < ( iContador < 0? ( -1 ) * iContador : iContador ) ){
            /* Fecha Minima es 01-01-1980 */
                        return( -2 );
                }
        while( iContador != 0 ){
            JulianToDate( dJul, &iAnio, &iMes, &iDia );
            if( !DiaNoHabil( iAnio, iMes, iDia ) && dJul != dJulIni )
                iContador ++;
            dJul --;
                }
        JulianToDate( ++ dJul, &iOuAnio, &iOuMes, &iOuDia );
        }
    sprintf( sOuFecha, "%04d%02d%02d", iOuAnio, iOuMes, iOuDia  );
    *lOuFecha = ( long) atol( sOuFecha );
    return( 0 );
}

/****************************************************************************
Nombre de la funcion: Julian
Version: 1.0
Descripcion: Funcion calcula la fecha juliana de dada una fecha Gregoriana a 8
             digitos
Autor: Jesus Robledo Martinez
Instalacion: BANAMEX-(1605)

Fecha de creacion: 09/11/2006
Fecha de ultima actualizacion:

Valor de regreso: void
Documentacion de parametros:
PARAMETRO       TIPO                DESCRIPCION
iAnio           int                 Anio en formato AAAA
iMes            int                 Mes en formato MM
iDia            int                 Dia en formato DD


-= Historia de modificaciones =-

Fecha de modificacion:
Autor de modificacion:
Descripcion de modificacion:
*****************************************************************************/
static double Julian( int iAnio, int iMes, int iDia )
{
        static unsigned int   Yr, Mth;
        static double NoLeap, Leap, Days, Yrs, Fraccion, Entero;

    if( iAnio < 0 ) Yr = iAnio + 1;
    else Yr = iAnio;
    Mth = iMes;
    if( iMes < 3 ){
                Mth = Mth + 12;
                Yr  = Yr - 1;
        }
        Yrs = 365.25 * Yr;
    Fraccion = modf( ( double) Yrs, ( double *) &Entero );
    if( Yrs < 0 && Fraccion != 0) Yrs = Entero + 1;
    else Yrs=Entero;
    Entero = 30.6001 * ( Mth + 1 );
    Fraccion = modf( Entero, &Entero );
    Days = ( double)( Yrs + Entero + iDia ) - 723244.0;
    if( Days < ( double) -145068.0 ) return Days;
    else{
        Yrs = Yr / 100;
        Fraccion = modf ( Yrs, &Entero );
        if( Yrs < 0 && Fraccion != 0) Yrs = Entero - 1;
        Fraccion = modf( Yrs, &Entero );
                NoLeap = Entero;
        Yrs = NoLeap / 4;
        Fraccion = modf( Yrs, &Entero );
        if( Yrs < 0 && Fraccion != 0 ) Yrs = Entero - 1;
        Fraccion = modf( Yrs, &Entero );
                Leap = 2 - NoLeap + Entero;
                Leap = Leap + Days;
        return( Leap );
        }
}

/****************************************************************************
Nombre de la funcion: JulianToDate
Version: 1.0
Descripcion: Funcion que pasa un fecha juliana a formato Anio, Mes, Dia
Autor: Jesus Robledo Martinez
Instalacion: BANAMEX-(1605)

Fecha de creacion: 09/11/2006
Fecha de ultima actualizacion:

Valor de regreso: void
Documentacion de parametros:
PARAMETRO       TIPO                DESCRIPCION
JuliaDate       double              Fecha Juliana
iAnio           int  *              Anio en formato AAAA
iMes            int  *              Mes en formato MM
iDia            int  *              Dia en formato DD


-= Historia de modificaciones =-

Fecha de modificacion:
Autor de modificacion:
Descripcion de modificacion:
*****************************************************************************/
static void JulianToDate( double JulianDate, int *iAnio, int *iMes, int *iDia )
{
    static double   JulCalDay, TempDay, Correction, Century, Days, Mo, JulDate, Fraccion, Entero;

        JulDate = JulianDate + 2444239L;
    Fraccion = modf( JulDate, &JulDate );
    if( JulianDate < -145078L ) JulCalDay = JulDate;
    else{
        TempDay = ( JulDate - 1867216.25 ) / 36524.25;
        Fraccion = modf( TempDay, &TempDay );
                JulCalDay = JulDate + 1 + TempDay;
                TempDay = TempDay / 4;
        Fraccion = modf( TempDay, &Entero );
        if( TempDay < 0 && Fraccion != 0 ) TempDay=Entero-1;
        Fraccion = modf( TempDay, &Entero );
                JulCalDay = JulCalDay - Entero;
        }
        Correction = JulCalDay + 1524;
    Century = ( Correction - 122.1 ) / 365.25;
    Fraccion = modf( Century, &Century );
        Days = Century *  365.25;
    Fraccion = modf( Days, &Days );
    Mo = ( Correction - Days ) / 30.6001;
    Fraccion = modf( Mo, &Mo );
        Entero = Mo * 30.6001;
    Fraccion = modf( Entero, &Entero );
    Entero = Correction - Days - Entero;
    Fraccion = modf( Entero, &Entero );
    *iDia = ( int) Entero;
    if (Mo>13.5) Entero = Mo-13;
    else Entero = Mo-1;
    Fraccion = modf( Entero, &Entero );
    *iMes = ( int) Entero;
    if( Entero > 2 ) Entero = Century - 4716;
    else Entero = Century - 4715;
    Fraccion = modf( Entero, &Entero );
    *iAnio = ( int) Entero;
}

/****************************************************************************
Nombre de la funcion: iDiaDeLaSemana
Version: 1.0
Descripcion: Funcion que de dada una fecha regresa el dia de la semana
Autor: Jesus Robledo Martinez
Instalacion: BANAMEX-(1605)

Fecha de creacion: 09/11/2006
Fecha de ultima actualizacion:

Valor de regreso: void
Documentacion de parametros:
PARAMETRO       TIPO                DESCRIPCION
iAnio           int  *              Anio en formato AAAA
iMes            int  *              Mes en formato MM
iDia            int  *              Dia en formato DD


-= Historia de modificaciones =-

Fecha de modificacion:
Autor de modificacion:
Descripcion de modificacion:
*****************************************************************************/
static int iDiaDeLaSemana( int iAnio, int iMes, int iDia )
{
    int iIndicador; /* Enero y Febrero son tratados como mes 13 y 14 febrary are treated */
                    /* as month 13 and 14 of past year */

    if( ( iMes == 1 ) || ( iMes == 2 ) ){
        iMes += 12;
        iAnio --;
        }
    iIndicador = ( iDia + 2 * iMes + 3 * ( iMes + 1 ) / 5 + iAnio + iAnio / 4 - iAnio / 100 + iAnio / 400 ) % 7;
    return( iIndicador + 1 );
}

