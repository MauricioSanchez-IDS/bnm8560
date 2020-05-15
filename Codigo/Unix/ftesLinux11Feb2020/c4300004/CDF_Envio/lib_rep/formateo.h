#define __FORMATEO_H

#if defined(__cplusplus)
extern "C" {
#endif

#if defined(_PROTOTYPES)
int	iNoEspacios(int, int, int);
char	*pcEncabezado(char *, char *, char *, char *, char *, char *, int, char *);
char	*pcPiedePagina(int, int, int, char, char *);
char	*pcTitulos(stFormatoTit *, char *, int, int, char *);
char	*pcDetalle(stFormatoDat *, int, int, PTRRISQL, char *);
char	*pcTitulosOk(stFormatoTit *, char *,char *, int, int, char *);
char	*pcDetalleOk(stFormatoDat *,char *, int, int, PTRRISQL, char *);
#else
int	iNoEspacios();
char	*pcEncabezado();
char	*pcPiedePagina();
char	*pcTitulos();
char	*pcDetalle();
char	*pcTitulosOk();
char	*pcDetalleOk();
#endif

#if defined(__cplusplus)
}
#endif

/* Calcula los espacios requeridos entre el centro de la hoja y la etiqueta izq. o der. */
int iNoEspacios(iCentro, iLonTitCentral, iLonCadIzqDer)
int iCentro;
int iLonTitCentral;
int iLonCadIzqDer;
{
    int iEspacios;

    iEspacios = iCentro - (iLonTitCentral / 2) - iLonCadIzqDer;
    return (iEspacios);
}

char *pcEncabezado(	pcGrupo, pcEmpresa,
					pcUnidad, pcFecGen,
					pcIdRep, pcTitulo,
					iLonLin, cEncab)
/* Genera una cadena de tres lineas de la longitud indicada con el encabezado
determinado por el usuario */
char *pcGrupo;
char *pcEmpresa;
char *pcUnidad;
char *pcFecGen;
char *pcIdRep;
char *pcTitulo;
int iLonLin;
char cEncab[iLongBufCadenas];
{
    char *pcFinal;
    int iCont;

/* Linea 1 del Encabezado */
/* Etiqueta Grupo */
    strcpy(cEncab, szLblGrupo);
    strcat(cEncab, pcGrupo);
/* Espacios entre etiqueta izq. y titulo central */
    for (iCont = 1;
	 iCont <= iNoEspacios(iLonLin / 2, strlen(pcTitulo),
			      strlen(szLblGrupo) + strlen(pcGrupo));
	 iCont++)
	strcat(cEncab, " ");
/* Titulo central Nombre del Reporte*/
    strcat(cEncab, pcTitulo);
/* Espacio entre titulo Central y etiqueta der. */
    for (iCont = 1;
	 iCont <= iNoEspacios(iLonLin / 2, strlen(pcTitulo),
			      strlen(szLblFecGen) + strlen(pcFecGen));
	 iCont++)
	strcat(cEncab, " ");
/* Etiqueta Fecha de generación */
    strcat(cEncab, szLblFecGen);
    strcat(cEncab, pcFecGen);
/* Salto de linea */
    strcat(cEncab, "\n");


/* Linea 2 del Encabezado */
/* Etiqueta empresa */
    strcat(cEncab, szLblEmp);
    strcat(cEncab, pcEmpresa);
/* Espacios entre etiqueta izq y titulo central */
    for (iCont = 1;
	 iCont <= iNoEspacios(iLonLin / 2, strlen(szTitProd),
			      strlen(szLblEmp) + strlen(pcEmpresa));
	 iCont++)
	strcat(cEncab, " ");
/* Titulo Fijo Productos comerciales */
    strcat(cEncab, szTitProd);
/* Salto de linea */
    strcat(cEncab, "\n");


/* Linea 3 del Encabezado */
/* Etiqueta Unidad */
    strcat(cEncab, szLblUnidad);
    strcat(cEncab, pcUnidad);
/* Espacios entre etiqueta izq. y titulo central */
    for (iCont = 1;
	 iCont <= iNoEspacios(iLonLin / 2, strlen(szTitEmp),
			      strlen(szLblUnidad) + strlen(pcUnidad));
	 iCont++)
	strcat(cEncab, " ");
/* Titulo fijo Banamex una empresa de citigroup */
    strcat(cEncab, szTitEmp);
/* Espacios entre titulo central y etiqueta der. */
    for (iCont = 1;
	 iCont <= iNoEspacios(iLonLin / 2, strlen(szTitEmp),
			      strlen(szLblIdRep) + strlen(pcIdRep));
	 iCont++)
	strcat(cEncab, " ");
/* Etiqueta Ident. Reporte */
    strcat(cEncab, szLblIdRep);
    strcat(cEncab, pcIdRep);
/* Salto de linea */
    strcat(cEncab, "\n");

/* Asignando dato para salida */
    pcFinal = (char *) cEncab;
/* Dato a regresar */
    return (pcFinal);
}

char *pcPiedePagina(iPagAct, iPagTot, iLonLin, cPosPie, cInforma)
/* Genera la cadena del pìe de página en la posición requerida
PosPie = I  indica que el pie se alineará a la izquierda
PosPie = D  indica que el pie se alineará a la derecha
PosPie = C  indica que el pie se centrará  */
int iPagAct;
int iPagTot;
int iLonLin;
char cPosPie;
char cInforma[iLongBufCadenas];
{
    char cNoPag[iLongBufCadenas];
    char cTotPag[iLongBufCadenas];
    int iLenEtq;
    int iCont;
    char *pcFinal;

/* Cambio de Inrteros a Cadenas */
    sprintf(cNoPag, CambiaInt(iPagAct));
    sprintf(cTotPag, CambiaInt(iPagTot));
/* Calculo de la liongitud total dfe la etiqueta */
    iLenEtq =
	strlen(szEtq1) + strlen(cNoPag) + strlen(szEtq2) + strlen(cTotPag);
/* Proceso de colocación de etiqueta */
    if (cPosPie == 'I') {
	strcpy(cInforma, szEtq1);
	strcat(cInforma, cNoPag);
	strcat(cInforma, szEtq2);
	strcat(cInforma, cTotPag);
    } else {
	strcpy(cInforma, " ");
	if (cPosPie == 'D') {
	    for (iCont = 1; iCont <= (iLonLin - iLenEtq - 1); iCont++)
		strcat(cInforma, " ");
	} else {
	    for (iCont = 1; iCont <= ((iLonLin / 2) - (iLenEtq / 2)) - 1;
		 iCont++)
		strcat(cInforma, " ");

	}
	strcat(cInforma, szEtq1);
	strcat(cInforma, cNoPag);
	strcat(cInforma, szEtq2);
	strcat(cInforma, cTotPag);
    };
    strcat(cInforma, "\n");
    pcFinal = (char *) cInforma;
    return (pcFinal);
}

/*
stFormatoTit arFormato[];
char *pcSeparador;
int iElemIni;
int iNoElem;
char cTitulos[iLongBufCadenas];
*/

char *pcTitulos(arFormato, pcSeparador, iElemIni, iNoElem, cTitulos)
/* Genera la cadena de encabezados para los campos del reporte */
stFormatoTit *arFormato;
char *pcSeparador;
int iElemIni;
int iNoElem;
char *cTitulos;
{
    int iCont;
    int jCont;
    char *pcFinal;
    int iSep1;

/* Recorre el número de campos */
    for (iCont = iElemIni; iCont <= iNoElem; iCont++) {
/* Deside donde se colocara el titulo I=izquierda, D=derecha, cualquier otro al centro de su longitud */
	if (arFormato[iCont].cAlineacion == 'I') {	/* Pone cadena a la izq */
	    if (iCont == 0) {
		strcpy(cTitulos, arFormato[iCont].cNomCampo);
	    } else {
		strcat(cTitulos, arFormato[iCont].cNomCampo);
	    }
	    for (jCont = strlen(arFormato[iCont].cNomCampo);
		 jCont <= arFormato[iCont].iLongCampo; jCont++) {
		strcat(cTitulos, arFormato[iCont].cCaracLlenado);
	    }
	} else {
	    if (arFormato[iCont].cAlineacion == 'D') {	/*Pone cadena a la derecha */
		iSep1 =
		    arFormato[iCont].iLongCampo -
		    strlen(arFormato[iCont].cNomCampo);
		for (jCont = 1; jCont <= iSep1; jCont++) {
		    if ((jCont == 1) && (iCont == 0)) {
			strcpy(cTitulos, arFormato[iCont].cCaracLlenado);
		    } else {
			strcat(cTitulos, arFormato[iCont].cCaracLlenado);
		    }
		}
		strcat(cTitulos, arFormato[iCont].cNomCampo);
	    } else {		/* Pone la cadena al centro */
		iSep1 =
		    ((arFormato[iCont].iLongCampo) -
		     (strlen(arFormato[iCont].cNomCampo))) / 2;
		for (jCont = 1; jCont <= iSep1; jCont++) {
		    if ((jCont == 1) && (iCont == 0)) {
			strcpy(cTitulos, arFormato[iCont].cCaracLlenado);
		    } else {
			strcat(cTitulos, arFormato[iCont].cCaracLlenado);
		    }
		}
		strcat(cTitulos, arFormato[iCont].cNomCampo);
		iSep1 = iSep1 + strlen(arFormato[iCont].cNomCampo);
		for (jCont = iSep1; jCont <= arFormato[iCont].iLongCampo;
		     jCont++) {
		    strcat(cTitulos, arFormato[iCont].cCaracLlenado);
		}
	    }
	}
    }
/*Obtiene la longitud de los titulos */
    iSep1 = strlen(cTitulos);
    strcat(cTitulos, "\n");
/*Agrega separador de titulos */
    if (pcSeparador != 0 ) {
	for (iCont = 1; iCont <= iSep1; iCont++) {
	    strcat(cTitulos, pcSeparador);
	}
    strcat(cTitulos, "\n");
    }
/* Regresa la cadena de los titulos */
    pcFinal = (char *) cTitulos;
    return pcFinal;
}

char *pcDetalle(arFormDatos, iCampoIni, iCampoFin, NodoCabecera, cDetalle)
/* Genera la cadena de detalle para los reportes */
stFormatoDat arFormDatos[];
int iCampoIni;
int iCampoFin;
PTRRISQL NodoCabecera;
char cDetalle[iLongBufCadenas];
{
    int iCont;
    int jCont;
    char *pcFinal;
    int iSep1;
    char pcDato[iLongBufCadenas];

/* Recorre el número de campos */
    for (iCont = iCampoIni; iCont <= iCampoFin; iCont++) {
	ObtenCampo(NodoCabecera, iCont, pcDato);
/* Deside donde se colocara el dato I=izquierda, D=derecha, cualquier otro al centro de su longitud */
	if (arFormDatos[iCont].cAlineacion == 'I') {	/* Pone cadena a la izq */
	    if (iCont == 0) {
		strcpy(cDetalle, pcDato);
	    } else {
		strcat(cDetalle, pcDato);
	    }

	    for (jCont = strlen(pcDato);
		 jCont <= arFormDatos[iCont].iLongCampo; jCont++) {
		strcat(cDetalle, arFormDatos[iCont].cCaracLlenado);
	    }
	} else {
	    if (arFormDatos[iCont].cAlineacion == 'D') {	/*Pone cadena a la derecha */
		iSep1 = arFormDatos[iCont].iLongCampo - strlen(pcDato);
		for (jCont = 1; jCont <= iSep1; jCont++) {
		    if ((jCont == 1) && (iCont == 0)) {
			strcpy(cDetalle, arFormDatos[iCont].cCaracLlenado);
		    } else {
			strcat(cDetalle, arFormDatos[iCont].cCaracLlenado);
		    }
		}
		strcat(cDetalle, pcDato);
	    } else {		/* Pone la cadena al centro */
		iSep1 =
		    ((arFormDatos[iCont].iLongCampo) -
		     (strlen(pcDato))) / 2;
		for (jCont = 1; jCont <= iSep1; jCont++) {
		    if ((jCont == 1) && (iCont == 0)) {
			strcpy(cDetalle, arFormDatos[iCont].cCaracLlenado);
		    } else {
			strcat(cDetalle, arFormDatos[iCont].cCaracLlenado);
		    }
		}
		strcat(cDetalle, pcDato);
		iSep1 = iSep1 + strlen(pcDato);
		for (jCont = iSep1; jCont <= arFormDatos[iCont].iLongCampo;
		     jCont++) {
		    strcat(cDetalle, arFormDatos[iCont].cCaracLlenado);
		}
	    }
	}
    }
    strcat(cDetalle, "\n");
/* Regresa la cadena de los titulos */
    pcFinal = (char *) cDetalle;
    return (pcFinal);
}

char *pcTitulosOk(arFormato,pcSepLineas,sepCampos,iElemIni,iNoElem,cTitulos)
/* Genera la cadena de encabezados para los campos del reporte */
stFormatoTit *arFormato;
char *pcSepLineas;
char *sepCampos;
int iElemIni;
int iNoElem;
char *cTitulos;
{
    int iCont;
    int jCont;
    char *pcFinal;
    int iSep1;

/* Recorre el número de campos */
    for (iCont = iElemIni; iCont <= iNoElem; iCont++) {
/* Deside donde se colocara el titulo I=izquierda, D=derecha, cualquier otro al centro de su longitud */
	if (arFormato[iCont].cAlineacion == 'I') {	/* Pone cadena a la izq */
	    if (iCont == 0) {
		strcpy(cTitulos, arFormato[iCont].cNomCampo);
	    } else {
		strcat(cTitulos, arFormato[iCont].cNomCampo);
	    }
	    for (jCont = strlen(arFormato[iCont].cNomCampo);
		 jCont < arFormato[iCont].iLongCampo; jCont++) {
		strcat(cTitulos, arFormato[iCont].cCaracLlenado);
	    }
	} else {
	    if (arFormato[iCont].cAlineacion == 'D') {	/*Pone cadena a la derecha */
		iSep1 =
		    arFormato[iCont].iLongCampo -
		    strlen(arFormato[iCont].cNomCampo);
		for (jCont = 1; jCont < iSep1; jCont++) {
		    if ((jCont == 1) && (iCont == 0)) {
			strcpy(cTitulos, arFormato[iCont].cCaracLlenado);
		    } else {
			strcat(cTitulos, arFormato[iCont].cCaracLlenado);
		    }
		}
		strcat(cTitulos, arFormato[iCont].cNomCampo);
	    } else {		/* Pone la cadena al centro */
		iSep1 =
		    ((arFormato[iCont].iLongCampo) -
		     (strlen(arFormato[iCont].cNomCampo))) / 2;
		for (jCont = 1; jCont < iSep1; jCont++) {
		    if ((jCont == 1) && (iCont == 0)) {
			strcpy(cTitulos, arFormato[iCont].cCaracLlenado);
		    } else {
			strcat(cTitulos, arFormato[iCont].cCaracLlenado);
		    }
		}
		strcat(cTitulos, arFormato[iCont].cNomCampo);
		iSep1 = iSep1 + strlen(arFormato[iCont].cNomCampo);
		for (jCont = iSep1; jCont < arFormato[iCont].iLongCampo;
		     jCont++) {
		    strcat(cTitulos, arFormato[iCont].cCaracLlenado);
		}
	    }
	}
        /* agrega entre campo y campo el separador de campos, excepto al final*/
        if ( iCont < iNoElem ){ 
          strcat(cTitulos,sepCampos);
        }
    }
/*Obtiene la longitud de los titulos */
    iSep1 = strlen(cTitulos);
    strcat(cTitulos, "\n");
/*Agrega separador de titulos */
    if ( strcmp(pcSepLineas,"") != 0 ) {
	for (iCont = 1; iCont <= iSep1; iCont++) {
	    strcat(cTitulos, pcSepLineas);
	}
    strcat(cTitulos, "\n");
    }
/* Regresa la cadena de los titulos */
    pcFinal = (char *) cTitulos;
    return pcFinal;
}

char *pcDetalleOk(arFormDatos,sepCampos,iCampoIni,iCampoFin,NodoCabecera,cDetalle)
/* Genera la cadena de detalle para los reportes */
stFormatoDat arFormDatos[];
int iCampoIni;
int iCampoFin;
char *sepCampos;
PTRRISQL NodoCabecera;
char cDetalle[iLongBufCadenas];
{
    int iCont;
    int jCont;
    char *pcFinal;
    int iSep1;
    char pcDato[iLongBufCadenas];

/* Recorre el número de campos */
    for (iCont = iCampoIni; iCont <= iCampoFin; iCont++) {
	ObtenCampo(NodoCabecera, iCont, pcDato);
/* Deside donde se colocara el dato I=izquierda, D=derecha, cualquier otro al centro de su longitud */
	if (arFormDatos[iCont].cAlineacion == 'I') {	/* Pone cadena a la izq */
	    if (iCont == 0) {
		strcpy(cDetalle, pcDato);
	    } else {
		strcat(cDetalle, pcDato);
	    }

	    for (jCont = strlen(pcDato);
		 jCont < arFormDatos[iCont].iLongCampo; jCont++) {
		strcat(cDetalle, arFormDatos[iCont].cCaracLlenado);
	    }
	} else {
	    if (arFormDatos[iCont].cAlineacion == 'D') {	/*Pone cadena a la derecha */
		iSep1 = arFormDatos[iCont].iLongCampo - strlen(pcDato);
		for (jCont = 0; jCont < iSep1; jCont++) {
		    if ((jCont == 1) && (iCont == 0)) {
			strcpy(cDetalle, arFormDatos[iCont].cCaracLlenado);
		    } else {
			strcat(cDetalle, arFormDatos[iCont].cCaracLlenado);
		    }
		}
		strcat(cDetalle, pcDato);
	    } else {		/* Pone la cadena al centro */
		iSep1 =
		    ((arFormDatos[iCont].iLongCampo) -
		     (strlen(pcDato))) / 2;
		for (jCont = 1; jCont < iSep1; jCont++) {
		    if ((jCont == 1) && (iCont == 0)) {
			strcpy(cDetalle, arFormDatos[iCont].cCaracLlenado);
		    } else {
			strcat(cDetalle, arFormDatos[iCont].cCaracLlenado);
		    }
		}
		strcat(cDetalle, pcDato);
		iSep1 = iSep1 + strlen(pcDato);
		for (jCont = iSep1; jCont < arFormDatos[iCont].iLongCampo;
		     jCont++) {
		    strcat(cDetalle, arFormDatos[iCont].cCaracLlenado);
		}
	    }
	}
        /* agrega entre campo y campo el separador de campos, excepto al final*/
        if ( iCont < iCampoFin  ){ 
          strcat(cDetalle,sepCampos);
        }
    }
    strcat(cDetalle, "\n");
/* Regresa la cadena de los titulos */
    pcFinal = (char *) cDetalle;
    return (pcFinal);
}


