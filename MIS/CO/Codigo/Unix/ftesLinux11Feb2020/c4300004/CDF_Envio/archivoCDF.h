#include <stdio.h>
#include <malloc.h>
#include <stdlib.h>
#include <string.h>

/***************************** DEFINICION DE ESTRUCTURAS ***********************************************/
/*  Estructura para campos de la tabla  de los registros */
struct nodo  {
	int ftoNumCampo;
	char ftoNomCampo[45];
	int ftoLongitud;
	char ftoTipoDato;
	char ftoFill;
	char ftoJustificado;
	char ftoFormato[15];
};

/* Inserta en el arreglo el elemento temp*/
insertaReg(temp, n, arreglo)
struct nodo temp;
int n;
struct nodo arreglo[];
{
	arreglo[n] = temp;
}
