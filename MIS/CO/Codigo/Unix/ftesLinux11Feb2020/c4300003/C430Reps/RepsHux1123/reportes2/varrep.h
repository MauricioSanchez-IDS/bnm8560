#define	__VARREP_H

#define PARTAMANO			255
#define PARMATTAMANO	        	1000
#define MAXCAMPOS			256
#define iLongBufCadenas	        	900
#define szTitProd			"Productos Comerciales Banamex"
#define szTitEmp			"Una Empresa de Citigroup"
#define szLblGrupo			"Grupo: "
#define szLblEmp			"Empresa: "
#define szLblUnidad			"Unidad: "
#define szLblFecGen			"Fec. Gen.: "
#define szLblIdRep			"Ident. Reporte: "
#define szEtq1				"Pagina "
#define szEtq2				" de "
#define szBUFF                          100000


struct FormatoTitulos {
	char cNomCampo[100];
	int  iLongCampo;
	char cAlineacion;
	char cCaracLlenado[1];
};
typedef struct  FormatoTitulos stFormatoTit;

struct FormatoDatos
{
	int iNumCampo;
	int iLongCampo;
	char cAlineacion;
	char cCaracLlenado[1];
};
typedef struct FormatoDatos stFormatoDat;
typedef char *INFO;

struct strCampo{
	int inumcampo;
	struct strCampo *Previo;
	struct strCampo *Siguiente;
	DBCHAR Dato[PARTAMANO];
};
typedef struct strCampo Campo;



struct strRISQL{
	char *scadena_sql;
	int       icampos;
	long   lRegistros;
	Campo     *Campos;
	long      lnumreg;
	DBPROCESS *dbproc;
};
typedef struct strRISQL RISQL;
typedef RISQL *PTRRISQL;


struct strTitulo{
	int inumcampo;
	char *sNombre;
	DBCHAR sValor[PARTAMANO];
};
typedef struct strTitulo Titulo;


struct argu {
	short int ilen;
	char cNum;
};
typedef struct argu ARGU;

struct Parametros {
	char	sNombreRep[10 + 1];
	char	sFecha[10 + 1]; 
	char	sPrefijo[4 + 1];
	char	sBanco[2 + 1];
	char	sEmpresa[5 + 1];
	char	sUnidad[5 + 1]; 
	char	sFechaIniAMD[8 + 1];
	char	sFechaFinAMD[8 + 1];
	char	sFechaCorteMD[4 + 1];
	char	iNivelIni[2 + 1];
	char	iNivelFin[2 + 1];
	char	sReporte[2 + 1];
	char	sFrecuencia[2 + 1];
	char	sLongEmpresa[2 + 1];
	char	sLongEjecutivo[2 + 1];
	char	sLongUnidad[2 + 1];
	char	sLongReporte[2 + 1];
	char	sArchivoDisco[255 + 1];
	char	sArchivoTemp[255 + 1];
	char	sbGrupo[1 + 1];
	char	sbTotales[1 + 1];
};
typedef struct Parametros stParms;

void ini_parms(Parms)
stParms *Parms;
{
	strcpy(Parms->sNombreRep, "");
	strcpy(Parms->sFecha, "");
	strcpy(Parms->sPrefijo, "");
	strcpy(Parms->sBanco, "");
	strcpy(Parms->sEmpresa, "");
	strcpy(Parms->sUnidad, "");
	strcpy(Parms->sFechaIniAMD, "");
	strcpy(Parms->sFechaFinAMD, "");
	strcpy(Parms->sFechaCorteMD, "");
	strcpy(Parms->iNivelIni, "");
	strcpy(Parms->iNivelFin, "");
	strcpy(Parms->sReporte, "");
	strcpy(Parms->sFrecuencia, "");
	strcpy(Parms->sLongEmpresa, "");
	strcpy(Parms->sLongEjecutivo, "");
	strcpy(Parms->sLongUnidad, "");
	strcpy(Parms->sLongReporte, "");
	strcpy(Parms->sArchivoDisco, "");
	strcpy(Parms->sArchivoTemp, "");
}
