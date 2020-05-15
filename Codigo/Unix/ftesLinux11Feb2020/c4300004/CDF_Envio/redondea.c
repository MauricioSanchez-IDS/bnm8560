#include <stdio.h>
#include <string.h>
#include <stdlib.h>

char * redondea( char *cifra ){

	char res[ 16 ];
	long int n_entero;
	long int n_fraccion;
	float resultado;
	char *entero;
	char *fraccion;
	int presicion;
	int longitud;
	int lon_frac;
	int punto;
	int caso;
	int factor = 1;
	char ch;

	//Sacamos la longitud del numero
	longitud = strlen( cifra );

	//Sacamos la localizacion del punto
	for( int i = 0 ; i < longitud ; i++ )
		if( cifra[ i ] == '.' ){
			punto = i;
			break;
		}

	//Separamos la parte entera
	entero = (char *) malloc( sizeof( char ) * (punto + 1) );	//asignamos memoria
	strncpy( entero, cifra, punto );				//Copiamos la parte entera
	entero[ punto + 1 ] = '\0';					//Nulo al final
	n_entero = atol( entero );

	//Separamos la parte fraccionaria
	fraccion = (char *)malloc( sizeof( char ) * 9 );		//Asignando memoria


	for( int i = punto + 1, j = 0 ; j < 8 ; i++, j++ )		//Copiando
		if( i < longitud )
			fraccion[ j ] = cifra[ i ];
		else							//Relleno de 0
			fraccion[ j ] = '0';

	fraccion[ 7 ] = '\0';						//Nulo al final

	for( int i = 0 ; i < 8 ; i++ )					//Primer digito distinto de 0 despues del punto
		if( fraccion[ i ] > 48 && fraccion[ i ] < 58 ){
			caso = i;
			break;
		}


	if( n_entero <= 0 )						//Presicion Caso Critico
		presicion = 4;
	else{								//Presicion Caso normal
		if( n_entero  < 10 )
			presicion = 4;
		else
			presicion = 3;
		caso = 0;
	}


	for( int i = caso + presicion ; i < 7 ; i++ )			//Quito los digitos inservibles
		fraccion[ i ] = '0';

	for( int i = 7 ; i >= 0 ; i-- )
		if( fraccion[ i ] >48 && fraccion[ i ] < 58 )
			break;
		else
			factor *= 10;

	n_fraccion = atol( fraccion );					//Convertimos a numero

	ch = fraccion[ caso + presicion - 1 ];

	if( atol(&ch) >= 5 )
		n_fraccion += (factor);					//Redondeo

	n_fraccion -= (atol( &ch ) * (factor/10));

	resultado = n_entero + ((float)n_fraccion / (float)10000000);

	sprintf(res, "%016.7f", resultado);

	free( fraccion );
	free( entero );
	return cifra;

}

void ayuda( void ){

	printf("\nDebes proporcionar 1 valor\n");
	printf("\n./redondea valor");
}

int main( int argv, char *args[ ] ){

	float res;
	char *resultado;

	if( argv < 2 )
		ayuda( );

	else{
		res = redondea( args[1] );
		printf("\nResultado: %s", resultado );
	}

	return 0;
}
