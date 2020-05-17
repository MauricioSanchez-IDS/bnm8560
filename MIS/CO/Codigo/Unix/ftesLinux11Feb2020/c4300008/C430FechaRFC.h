#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>

int obtenLongitudes( char *rfc, int *longitud ){

	longitud[ 0 ] = 0;
	longitud[ 1 ] = 0;
	longitud[ 2 ] = 0;

	longitud[ 0 ] = strlen( rfc );

	for( longitud[ 1 ] = 0 ; longitud[ 1 ] < longitud[ 0 ] ; longitud[ 1 ]++ )
		if( isdigit( rfc[ longitud[ 1 ] ] ))
			break;

	for( longitud[ 2 ] = longitud[ 1 ] ; isdigit( rfc[ longitud[ 2 ] ] ) ; longitud[ 2 ]++ );

	if( longitud[ 0 ] == longitud[ 1 ])
		return 0;
		
	if( ( longitud[ 2 ] - longitud[ 1 ] ) < 6 )
		return 0;

	return 1;
}

void extraeFecha( char *rfc, int *longitud, int *fecha ){

	char anio[ 3 ];
	char mes[ 3 ];
	char dia[ 3 ];
	int i, j;

	for( i = longitud[ 1 ], j = 0 ; i < longitud[ 1 ] + 2 ; i++, j++ )
		anio[ j ] = rfc[ i ];

	anio[ 2 ] = '\0';

	for( j = 0 ; i < longitud[ 1 ] + 4 ; i++, j++ )
		mes[ j ] = rfc[ i ];

	mes[ 2 ] = '\0';

	for( j = 0 ; i < longitud[ 2 ] ; i++, j++ )
		dia[ j ] = rfc[ i ];

	dia[ 2 ] = '\0';

	fecha[ 0 ] = atof( anio );
	fecha[ 1 ] = atof( mes );
	fecha[ 2 ] = atof( dia );
}

int validaAnio( int anio ){

	time_t fecha;
	char buffer[ 256 ];
	struct tm *loctime;
	int aux;

	fecha = time( NULL );
	loctime = localtime( &fecha );
	strftime( buffer, 256, "%y", loctime);

	aux = atol( buffer ) - anio;

	if( aux <= 0 )
		anio += 1900;

	else
		anio += 2000;

	return anio;
}

int validaMesDia( int *fecha ){

	int mes31[ ] = { 1, 3, 5, 7, 8, 10, 12 };
	int anioviciesto = 0;
	int i;

	if( fecha[ 1 ] == 2 ){

		if( fecha[ 0 ] % 4 == 0 )
			anioviciesto = 1;

		if( fecha[ 2 ] < 29 && anioviciesto == 0 )
			return 1;

		else if( fecha[ 2 ] <= 29 && anioviciesto == 1 )
			return 1;

		else{
			return 0;
		}
	}

	else{
		if( fecha[ 2 ] == 31 ){
			for( i = 0 ; i < 7 ; i++ )
				if( mes31[ i ] == fecha[ 2 ] )
					return 1;
			if( i <= 7 )
				return 0;
		}
	}

	return 1;
}

int validaFecha( int * fecha ){

	int aux;
	fecha[ 0 ] = validaAnio( fecha[ 0 ] );
	aux = validaMesDia( fecha );

	if( (fecha[ 0 ] < 0) ||
	    (aux == 0 ) ||
	    ( fecha[ 1 ] > 12 || fecha[ 1 ] <= 0 ) ||
	    ( fecha[ 2 ] <= 0 || fecha[ 2 ] > 31 ) ){
		fecha[ 0 ] = 0;
		fecha[ 1 ] = 0;
		fecha[ 2 ] = 0;
		return 0;
	}

	return 1;
}

int obtenFecha( char *rfc, char *fecha ){

	int longitud[ 3 ];
	int fecha_int[ 3 ];

	if( rfc[ 0 ] == '\0' )
		return 0;

	if ( obtenLongitudes( rfc, longitud ) == 0 )
		return 0;

	extraeFecha( rfc, longitud, fecha_int );

	if( validaFecha( fecha_int ) == 0 )
		return 0;

	sprintf( fecha, "%d%02d%02d", fecha_int[ 0 ], fecha_int[ 1 ], fecha_int[ 2 ] );

	return 1;
}

