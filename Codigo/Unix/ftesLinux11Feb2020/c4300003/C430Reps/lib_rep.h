/*============================================================================*/

#define __CONEXION_H

#if defined(__cplusplus)
extern "C" {
#endif

#if defined(_PROTOTYPES)
    void	IniciaBase(void);
    void	ConectaBase(char *, char *, char *, char *, char *, DBPROCESS ** );
    void	Desconecta(void);
#else
    void	IniciaBase();
    void	ConectaBase();
    void	Desconecta();
#endif

#if defined(__cplusplus)
}
#endif

/*============================================================================*/

#define	__VARREP_H

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

struct FormatoTitulos {
	char	cNomCampo[100];
	int	iLongCampo;
	char	cAlineacion;
	char	cCaracLlenado[1];
};
typedef struct FormatoTitulos stFormatoTit;

struct FormatoDatos
{
	int	iNumCampo;
	int	iLongCampo;
	char	cAlineacion;
	char	cCaracLlenado[1];
};
typedef struct FormatoDatos stFormatoDat;
typedef char *INFO;

struct strCampo {
	int			         inumcampo;
	struct strCampo		*Previo;
	struct strCampo		*Siguiente;
	DBCHAR          Dato[PARTAMANO];

};
typedef struct strCampo Campo;


struct strTitulo{
	int					inumcampo;
	char				*sNombre;
	DBCHAR				sValor[PARTAMANO];
};
typedef struct strTitulo Titulo;


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

/*============================================================================*/

#define		__VOLCAD_H

#if defined(__cplusplus)
extern "C" {
#endif

#if defined(_PROTOTYPES)
	char	*trae_subcad(char *, int, int);
	char	*trae_flot(char *, int);
	char	*VolteaCad(char *);
	char	*CambiaInt(int);
	char	*CambiaIntLargo(unsigned long int);
#else
	char	*trae_subcad();
	char	*trae_flot();
	char	*VolteaCad();
	char	*CambiaInt();
	char	*CambiaIntLargo();
#endif

#if defined(__cplusplus)
}
#endif

/*============================================================================*/

#define		__RISQLDB_H

#if defined(__cplusplus)
extern "C" {
#endif

#if defined(_PROTOTYPES)
    int     ObtenRegistro(PTRRISQL, int);
	int		RegistroSiguiente(PTRRISQL);
	int		RegistroPrevio(PTRRISQL);
	int		RegistroPrimero(PTRRISQL);
	int		RegistroUltimo(PTRRISQL);
	int		ObtenCampo(PTRRISQL, int, char *);
	void	LiberaMemCab(PTRRISQL);
        int	EjecutaSQL(PTRRISQL);
	void	obtenvalor(char *, char *);
#else
    int     ObtenRegistro();
	int		RegistroSiguiente();
	int		RegistroPrevio();
	int		RegistroPrimero();
	int		RegistroUltimo();
	int		ObtenCampo();
	void	LiberaMemCab();
        int	EjecutaSQL();
	void	obtenvalor();
#endif

#if defined(__cplusplus)
}
#endif

/*============================================================================*/

#define __ARBOLUNI_H

#define MAXTAMUNI		16
#define NIVEL			4
#define	EJE_PREFIJO 	0
#define	GPO_BANCO		1
#define	EMP_NUM 		2
#define	GPO_NUM			3
#define	UNIT_ID			4
#define	UNIT_PARENT_ID	5
#define	NIVEL_NUM		6

struct strUnidad {
	char				eje_prefijo[11];
	char				gpo_banco[11];
	char				emp_num[11];
	char				gpo_num[11];
	char				unit_id[MAXTAMUNI];
	char				unit_parent_id[MAXTAMUNI];
	char				nivel_num[NIVEL];
	struct strUnidad	*Previo;
	struct strUnidad	*Siguiente;
};
typedef struct strUnidad Unidad; 

struct strArbol {
	struct strUnidad	*Primero;
	struct strUnidad	*Ultimo;
	struct strUnidad	*Actual;
};
typedef struct strArbol Arbol;

#if defined(__cplusplus)
extern "C" {
#endif

#if defined(_PROTOTYPES)
	void	ObtenArbolUni(Arbol *);
	int		TraeSubVector(Arbol *, Arbol *,char *,char *, char *, char *);
	int		RegUniSiguiente(Arbol *);
	int		RegUniPrevio(Arbol *);
	int		RegUniPrimero(Arbol *);
	int		RegUniUltimo(Arbol *);
	int		ObtenValorUni(Arbol *, int, char *);
	int		TraeUnidad(Arbol *, Arbol *, char *, char *,char *,char *, int, int);
	void     	LiberaMemArb(Arbol *);
void    obtenvalorSapuf(char *, char *);        
int     revisaConexion(char *, char *, char *); 
int     ObtenSapuf(char *, char *);             
int     getPassword(char *);             
#else
	void	ObtenArbolUni();
	int		TraeSubVector();
	int		RegUniSiguiente();
	int		RegUniPrevio();
	int		RegUniPrimero();
	int		RegUniUltimo();
	int		ObtenValorUni();
	int		TraeUnidad();
	void	        LiberaMemArb();
void    obtenvalorSapuf();        
int     revisaConexion(); 
int     ObtenSapuf();             
int     getPassword();             
#endif

#if defined(__cplusplus)
}
#endif

/*============================================================================*/
