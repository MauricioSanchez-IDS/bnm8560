#include <stdio.h>

#include <stdlib.h>

#include <string.h>



char * redondeo( char *cifra ){



	int lon;							//Longitud

	int punto;							//Posicion del Punto

	int caso;							//Primer digito distinto de cero despues del punto

	const decimales = 6;				//Decimales trabajadas

	const decimales_normal = 100;		//Decimales del caso normal

	char *entero;						//Cadena que contiene al entero

	char decimal[ 2 + 6 + 1 ];			//Cadena que contiene los decimales

	long int n_entero;					//Contiene la parte entera

	long int factor = 1;				//factor de multiplicacion/divicion caso critico

	long int aux;						//Variable de paso

	float n_decimal;					//Contiene la parte decimal

	const int presicion = 2;

	char resultado[ 15 + 1 ];



	//Recuperamos la longitud

	lon = strlen( cifra );



	//Buscamos el punto

	for( int i = 0 ; i < lon ; i++ )

		if( cifra[ i ] == '.' )

			punto = i;



	//Buscamos la primer decimal distinto de cero

	for( int i = punto; i < punto + decimales ; i++ )

		if( cifra[ i ] > 48 && cifra[ i ] < 58 ){

			caso = i - punto;

			break;

		}

			



	//Recuperamos la parte entera

	//Reservamos memoria para entero

	entero = (char *)malloc( sizeof(char) * punto );



	//Copiamos la parte entera

	strncpy( entero, cifra, punto );

	entero[ punto ] = '\0';



	n_entero = atol( entero );



	//Recuperamos la parte flotante

	strcpy( decimal, "0." );

	

	for( int i = punto + 1, k = 2 ; k < 9 ; i++, k++ )

		if( i >= lon )

			decimal[ k ] = '0';

		else

			decimal[ k ] = cifra[ i ];



	decimal[ 8 ] = '\0';

	n_decimal = atof( decimal );



	//Caso Critico

	if( punto == 1 ){



		//Obtengo el factor

		for( int i = 0  ; i < caso + presicion ; i++ )

			factor = factor * 10;



		//Desplazo el punto 

		n_decimal *= factor;



		//caso de redondeo hacia arriba

		if( (n_decimal - (long int)n_decimal) >= 0.5 ){

			n_decimal = n_decimal + 1;

			aux = (long int)(n_decimal);

			n_decimal = ((float)aux/(float)factor);

		}



		//Caso de redondeo hacia abajo

		else{

			aux = (long int)(n_decimal);

			n_decimal = ((float)aux/(float)factor);

		}



		n_decimal += n_entero;	

	}



	//Caso Normal

	else{



		//Obtengo el factor

		factor = 1 * decimales_normal;



		//Desplazo el punto 

		n_decimal *= factor;



		//caso de redondeo hacia arriba

		if( (n_decimal - (long int)n_decimal) >= 0.5 ){

			n_decimal = n_decimal + 1;

			aux = (long int)(n_decimal);

			n_decimal = ((float)aux/(float)factor);

		}



		//Caso de redondeo hacia abajo

		else{

			aux = (long int)(n_decimal);

			n_decimal = ((float)aux/(float)factor);

		}



		n_decimal += n_entero;

	}



	printf( "\nAqui: %f", n_decimal );



	sprintf( resultado, "%016.7f", n_decimal );

	

	if( punto == 1 )

		for( int i = 14 ; i < 16 ; i++ )

			resultado[ i ] = '0';

	else

		for( int i = 11 ; i < 16 ; i++ )

			resultado[ i ] = '0';

	

	free( entero );



	printf("\nEl Resultado: %s", resultado );



	return resultado;

}



void ayuda( void ){



	printf("\nDebe proporcionar una cifra.\n");

	printf("\nModo de Uso: redondea 12.2373636\n");

}



int main( int argv, char * args[ ] ){



	char *resultado;



	if( argv < 2 )

		ayuda( );



	else

		resultado = redondeo( args[ 1 ] );



	printf("\nEl Resultado: %s", resultado );

	

	return 0;

}