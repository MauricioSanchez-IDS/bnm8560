/*******************************************************************************
*		CODIGOS DE PAIS DE DOS Y TRES POSICIONES agrega yuria 14/03/05
*           Y CON CODIGOS DE MONEDA
*******************************************************************************/


#define		LEN_COD2	2	
#define		LEN_COD3	3	
#define		TOTAL_PAISES 	300

int N_CODS_MONED;                                           
int N_CODS_PAIS;                                            

typedef struct {
	char	cod2[LEN_COD2 + 1];
	char	cod3[LEN_COD3 + 1];
	char	moneda_num[LEN_COD3 + 1];
	char	moneda_alf[LEN_COD3 + 1];
} CODIGO_PAIS;

typedef struct {
	char	moneda_num[LEN_COD3 + 1];
	char	moneda_alf[LEN_COD3 + 1];
	float	tasa_rango1;
	float	tasa_rango2;
} MONEDAS;

CODIGO_PAIS pais[TOTAL_PAISES];
MONEDAS monedas_usuales[TOTAL_PAISES];


