#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX 735
#define NOM 100

/**
  *
  **/

char * obtenNombre( char *cadena ){

	char str[ NOM ];
	int len;

	len = strlen( cadena );

	printf("\n\nLa longitud es: %d\n\n", len );

	return str;
}

/**
  * Funcion cerrarArchivo.
  * 
  * Objetivo.
  *				Cerrar el descriptor de archivo que tiene como argumento.
  *
  *	Entradas.
  *
  *				Apuntador a archivo que contiene un descriptor
  *
  * Salidas.
  *
  *				No regresa nada.
  **/

void cerrarArchivo( FILE *archivo ){

	fclose( archivo );
}

/**
  * Funcion abreArchivo.
  *
  * Objetivo.
  *				Abrir un archivo seg'un el nombre y el modo deseados
  *
  * Entradas.
  *
  *				Se requiere de una cadena que ocntenga el path y el nombre del archivo que se desea abrir.
  *				Como segundo parametro se reuiere de una cadena que nos indique el modo de apertura
  *
  * Salidas.
  *
  *				Regresa un apuntador a archivo, es decir, un descriptor.
  **/

FILE * abreArchivo(  char *source, char *modo ){

	FILE *file;

	file = fopen( source, modo );

	if( file == '\0' ){
	
		printf("\n\nFalló la apertura del archivo!!!\n\n");
		printf("\nNo se encuetra el archivo\n");
		exit( 1 );
	}

	return file;
}


/**
  *	Funcion help.	
  * 
  * Objetivo.
  *				Su objetivo es imprimir la forma de uso del programa y es activada solo al inicio de la ejecuci'on
  *				Imprime la forma de uso para que el usuario pueda ejecutarlo de manera correcta.
  * 
  *	Entradas.
  *				No requiere de parametros de entrada.
  *
  * Salidas.
  *				No regresa ningun dato.
  *
  **/

void help( void ){

	printf("\n\nFaltan parametros para la ejecución!!!\n\n");
	printf("\n\nIntente \"./file path_y_nombre_del_archivo\"\n\n");
}



int main( int argv, char *argc[ ] ){

	
	FILE *archivo = '\0';
	char str[ MAX ];
	char *nombre;

	
	if( argv < 2 ){
	
		help( );
		exit( 1 );
	}

	nombre = obtenNombre( argc[ 1 ] );

	archivo = abreArchivo( argc[ 1 ], "r" );

	while( !feof( archivo ) ){

		fgets( str, MAX, archivo );
		printf( "%s", str );

	}

	cerrarArchivo( archivo );

	return 0;
}