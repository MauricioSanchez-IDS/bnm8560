#define __VARREP_H
/* Estructuras necesarias para el reporteador */

#define PARTAMANO			255
#define PARMATTAMANO		1000
#define MAXCAMPOS			256
#define iLongBufCadenas		900
#define szTitProd			"Productos Comerciales Banamex"
#define szTitEmp			"Una Empresa de Citigroup"
#define szLblGrupo			"Grupo: "
#define szLblEmp			"Empresa: "
#define szLblUnidad			"Unidad: "
#define szLblFecGen			"Fec. Gen.: "
#define szLblIdRep			"Ident. Reporte: "
#define szEtq1				"Pagina "
#define szEtq2				" de "

struct FormatoTitulos
{
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
	INFO Dato;
};
typedef struct strCampo Campo;


struct strRegistro{
	long lnumreg;
	struct strRegistro *Previo;
	struct strRegistro *Siguiente;
	Campo *Campos;
};
typedef struct strRegistro Registro;

struct strCabecera{
	Registro *Primero;
	Registro *Ultimo;
	Registro *RegActual;
	Campo    *CamActual;
};
typedef struct strCabecera Cabecera;

struct strTitulo{
	int inumcampo;
	char *sNombre;
	DBCHAR sValor[PARTAMANO];
};
typedef struct strTitulo Titulo;


struct strRISQL{
	char *scadena_sql;
	int icampos;
	long lRegistros;
	Cabecera *Recordset;
};
typedef struct strRISQL RISQL;
typedef RISQL *PTRRISQL;

