#include	<stdio.h>			/* UNIX		*/
#include	<stdlib.h>			/* UNIX		*/
#include	<string.h>			/* UNIX		*/
#include	<sys/stat.h>		/* UNIX		*/

#include	<sybfront.h>		/* SYBASE	*/
#include	<sybdb.h>			/* SYBASE	*/
#include	"lib_rep.h"			/* C430		*/
#include	"reportes.h"		/* C430		*/
#include        "conexion.h"
#include        "risqldb.h"
#include        <SAPUF_Enlace.h>
#include        "libsbf.h"
#include        "formateo.h"
#include        "arboluni.h"
#include        "volcad.h"
#define		SUCCESS		0
#define		WARNING		1
#define		FAILURE		-1
#ifdef LEN_BUFFER
#undef LEN_BUFFER
#endif

#define		LEN_TYPE	4
#define		LEN_DATA	256
#define		LEN_BUFFER	(LEN_TYPE + LEN_DATA + 32)
#define		LEN_SQL		8196
#include <errno.h>

#define		LEN_UNIDAD	5
#define		LEN_VARENV	128

//#if defined(__cpluplus)
//extern "C" {
//#endif

//#if defined(__cpluplus)
//}
//#endif

char	sDia_Corte[LEN_VARENV];
char	sTipo_Ejec[LEN_VARENV];
char	sFecha_Ini[LEN_VARENV];
char	sFecha_Fin[LEN_VARENV];
char	sFecha_act[LEN_VARENV];
char	sEmpresa_I[LEN_VARENV];
char	sEmpresa_F[LEN_VARENV];
char	sReporte_I[LEN_VARENV];
char	sReporte_F[LEN_VARENV];
char	sB_Totales[LEN_VARENV];

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

#if defined(__STDC__) || defined(__cplusplus)
int main(int argc, char *argv[])
#else
int main(argc, argv)
int		argc;
char            *argv[];
#endif
{
	RISQL		stSQL, stSQL1;
	char		sqlcmd[LEN_SQL], sCadenaFormato[1024];
	int		rsql, rsql1, n = 0,respuesta;
	stParms		Parms;
	char		tipo[10], grupo[10];
        char            argRep[16][16];

        char    empresa[100];
        char    comando[100];
	(void) memset((void *) sDia_Corte, (int) '\0', (size_t) LEN_VARENV);
	(void) memset((void *) sTipo_Ejec, (int) '\0', (size_t) LEN_VARENV);
	(void) memset((void *) sFecha_Ini, (int) '\0', (size_t) LEN_VARENV);
	(void) memset((void *) sFecha_Fin, (int) '\0', (size_t) LEN_VARENV);
	(void) memset((void *) sFecha_act, (int) '\0', (size_t) LEN_VARENV);
	(void) memset((void *) sEmpresa_I, (int) '\0', (size_t) LEN_VARENV);
	(void) memset((void *) sEmpresa_F, (int) '\0', (size_t) LEN_VARENV);
	(void) memset((void *) sReporte_I, (int) '\0', (size_t) LEN_VARENV);
	(void) memset((void *) sReporte_F, (int) '\0', (size_t) LEN_VARENV);
	(void) memset((void *) sB_Totales, (int) '\0', (size_t) LEN_VARENV);

	(void) strncpy(sDia_Corte, getenv("DIA_CORTE"), LEN_VARENV);
	(void) strncpy(sTipo_Ejec, getenv("TIPO_EJEC"), LEN_VARENV);
	(void) strncpy(sFecha_Ini, getenv("FECHA_INI"), LEN_VARENV);
	(void) strncpy(sFecha_Fin, getenv("FECHA_FIN"), LEN_VARENV);
	(void) strncpy(sFecha_act, getenv("FECHA_ACT"), LEN_VARENV);
	(void) strncpy(sEmpresa_I, getenv("EMPRESA_I"), LEN_VARENV);
	(void) strncpy(sEmpresa_F, getenv("EMPRESA_F"), LEN_VARENV);
	(void) strncpy(sReporte_I, getenv("REPORTE_I"), LEN_VARENV);
	(void) strncpy(sReporte_F, getenv("REPORTE_F"), LEN_VARENV);
	(void) strncpy(sB_Totales, getenv("B_TOTALES"), LEN_VARENV);
	if (!strlen(sDia_Corte) || !strlen(sTipo_Ejec) ||
		!strlen(sFecha_Ini) || !strlen(sFecha_Fin) ||
		!strlen(sFecha_act) || !strlen(sEmpresa_I) ||
		!strlen(sEmpresa_F) || !strlen(sReporte_I) ||
		!strlen(sReporte_F) || !strlen(sB_Totales)) {
		fprintf(stdout, "Variables de ambiente indefinidas.\n");
		fflush(stdout);
		exit(FAILURE);
	}
	(void) memset((void *) sqlcmd, '\0', LEN_SQL);
	sprintf(sqlcmd,
			"SELECT \n \
				a.eje_prefijo as Prefijo, \n \
				a.gpo_banco as Banco, \n \
				a.emp_num as Empresa, \n \
				ltrim(rtrim(a.unit_id)) as Unidad, \n \
				ltrim(rtrim(a.report_id)) as Reporte, \n \
				upper(ltrim(rtrim(a.reporting_freq))) as Frecuencia, \n \
				b.pgs_long_emp as LongEmpresa, \n \
				b.pgs_long_eje as LongEjecutivo, \n \
				b.pgs_long_uni as LongUnidad, \n \
				b.pgs_long_rep as LongReporte, \n \
				ltrim(rtrim(convert(char(1),a.report_level))) as NivelRep, \n \
				ltrim(rtrim(convert(char(8),a.report_type))) as TipoRep, \n \
				ltrim(rtrim(convert(char(8),a.gpo_num))) as NumeroGrupo \n \
			FROM \n \
				MTCURP01 a, \n \
				MTCPGS01 b, \n \
				MTCREP01 c \n \
			WHERE \n \
				a.eje_prefijo = b.pgs_rep_prefijo and \n \
				a.gpo_banco = b.pgs_rep_banco and \n \
				upper(ltrim(rtrim(a.reporting_gen))) = 'Y' and \n \
				upper(ltrim(rtrim(a.unit_id))) != '' and \n \
				convert(int,a.report_id) between %s and %s and \n \
				convert(int,a.emp_num) between %s and %s and \n \
				upper(ltrim(rtrim(a.reporting_freq))) = '%s' and \n \
				a.report_id = c.report_id and \n \
				ltrim(rtrim(c.rep_tipo_prod)) = '%s' and \n \
				ltrim(rtrim(b.pgs_tipo_prod)) = '%s' \n \
			ORDER BY a.eje_prefijo, a.gpo_banco, a.emp_num",
				sReporte_I, sReporte_F,
				sEmpresa_I, sEmpresa_F,
				(! strcmp(sTipo_Ejec, "CYCLE") ? "C": "D"),
				getenv("TIPO_PROD"),
				getenv("TIPO_PROD"));
	IniciaBase();

	stSQL.scadena_sql = sqlcmd;
	stSQL.icampos = 13;
	stSQL.lRegistros = 0;
	EjecutaSQL(&stSQL);

	if (! stSQL.lRegistros) {
		fprintf(stdout, "No existe calificacion de reportes.\n");
		fflush(stdout);
		exit(SUCCESS);
	}
	rsql = RegistroPrimero(&stSQL);
	do {
		ini_parms(&Parms);

		(void) memset((void *) tipo, (int) '\0', (size_t) 10);
		(void) memset((void *) grupo, (int) '\0', (size_t) 10);

		ObtenCampo(&stSQL, (int)  0, (char *) Parms.sPrefijo);
		ObtenCampo(&stSQL, (int)  1, (char *) Parms.sBanco);
		ObtenCampo(&stSQL, (int)  2, (char *) Parms.sEmpresa);
		ObtenCampo(&stSQL, (int)  3, (char *) Parms.sUnidad);
		ObtenCampo(&stSQL, (int)  4, (char *) Parms.sReporte);
		ObtenCampo(&stSQL, (int)  5, (char *) Parms.sFrecuencia);
		ObtenCampo(&stSQL, (int)  6, (char *) Parms.sLongEmpresa);
		ObtenCampo(&stSQL, (int)  7, (char *) Parms.sLongEjecutivo);
		ObtenCampo(&stSQL, (int)  8, (char *) Parms.sLongUnidad);
		ObtenCampo(&stSQL, (int)  9, (char *) Parms.sLongReporte);
		ObtenCampo(&stSQL, (int) 10, (char *) Parms.iNivelIni);
		ObtenCampo(&stSQL, (int) 11, (char *) tipo);
		ObtenCampo(&stSQL, (int) 12, (char *) grupo);
		if (atoi(tipo) == 0) {
			(void) memset((void *) sqlcmd, '\0', LEN_SQL);
			sprintf(sqlcmd,
					"SELECT \n \
					    min(emp_num) \n \
					FROM \n \
					    MTCEMP01 \n \
					WHERE \n \
					    eje_prefijo = %ld and \n \
					    gpo_banco = %ld and \n \
					    gpo_num = %ld",
					Parms.sPrefijo,
					Parms.sBanco,
					grupo);

			stSQL1.scadena_sql = sqlcmd;

			stSQL1.icampos = 1;
			stSQL1.lRegistros = 0;
			EjecutaSQL(&stSQL1);

			ObtenCampo(&stSQL1, (int) 0, (char *) Parms.sEmpresa);
			strcpy(Parms.sbGrupo, "1");
		}
		else
			strcpy(Parms.sbGrupo, "0");

		if (strlen(Parms.sUnidad) <= LEN_UNIDAD) {

            /* Llena parametros fijos */
			strcpy(Parms.sNombreRep, "REP_");
			strcat(Parms.sNombreRep, Parms.sReporte);
			strcpy(Parms.sArchivoTemp, "file_c.tmp");
			strcpy(Parms.iNivelFin, "9");

			/* Obtiene fechas */
			strcpy(Parms.sFecha, sFecha_act);
			strcpy(Parms.sFechaIniAMD, sFecha_Ini);
			strcpy(Parms.sFechaFinAMD, sFecha_Fin);
			strcpy(Parms.sFechaCorteMD, sDia_Corte);
			strcpy(Parms.sbTotales, sB_Totales);

			/* Nombre de aarchivo */
			sprintf(sCadenaFormato,
					"%%s/%%s%%s%%0%dd/%%s.%%0%dd.rpt%%0%dd.TXT",
					atoi(Parms.sLongEmpresa),
					atoi(Parms.sLongUnidad),
					atoi(Parms.sLongReporte));

			sprintf(Parms.sArchivoDisco, sCadenaFormato, getenv("DIR_ARCH"),
					Parms.sPrefijo, Parms.sBanco, atoi(Parms.sEmpresa),
					Parms.sFecha, atoi(Parms.sUnidad), atoi(Parms.sReporte));
			fprintf(stdout,
					"%04d. [%4s %2s %5s %6s %2s %1s %1s %1s %1s %1s] => [%s]",
					++n, Parms.sPrefijo, Parms.sBanco, Parms.sEmpresa,
					Parms.sUnidad, Parms.sReporte, Parms.sFrecuencia,
					Parms.sLongEmpresa, Parms.sLongEjecutivo,
					Parms.sLongUnidad, Parms.sLongReporte,
					Parms.sArchivoDisco);

/*                        fprintf(stdout,"Antes del fflush \n"); */

			fflush(stdout);

            (void) memset((void *) empresa, '\0', sizeof(empresa));

/*            fprintf(stdoUt,"Despues de memset \n");  */

            sprintf(sCadenaFormato, "%%s/%%s%%s%%0%dd", atoi(Parms.sLongEmpresa));
            sprintf(empresa, sCadenaFormato, getenv("DIR_ARCH"),
                            Parms.sPrefijo, Parms.sBanco, atoi(Parms.sEmpresa)),
            mkdir(  empresa,
                            S_IRUSR | S_IWUSR | S_IXUSR |
                            S_IRGRP | S_IWGRP | S_IXGRP |
                            S_IROTH | S_IWOTH | S_IXOTH);
            if( errno == -1)
            {
            (void) fprintf(stderr, "lin 592 \n");
                fprintf(stdout, "fallo el mkdir errno=%d\n",errno);
            }

            switch (atoi(Parms.sReporte)) {
            case 13 :
            case 14 :
            case 18 :
            case 22 :
            case 24 :
            case 26 :
                 sprintf(Parms.sFechaIniAMD, "%s", "00000000");
                 sprintf(Parms.sFechaFinAMD, "%s", "00000000");
                 break;
            case 25 :
                 sprintf(Parms.sFechaCorteMD, "%s", "0000");
                 break;
            default :
                 fprintf(stdout, " [NO_EXIS]\n");
                 break;

            } /*fin del switch*/

            switch (atoi(Parms.sReporte)) {
            case 13 :
            case 14 :
            case 18 :
            case 22 :
            case 24 :
            case 26 :
            case 25 :
                strcpy(argRep[0],Parms.sReporte);
                strcpy(argRep[1],Parms.sNombreRep);
                strcpy(argRep[2], Parms.sFecha);
                strcpy(argRep[3], Parms.sPrefijo);
                strcpy(argRep[4], Parms.sBanco);
                strcpy(argRep[5], Parms.sEmpresa);
                strcpy(argRep[6], Parms.sUnidad);
                strcpy(argRep[7], Parms.sFechaIniAMD);
                strcpy(argRep[8], Parms.sFechaFinAMD);
                strcpy(argRep[9], Parms.sFechaCorteMD);
                strcpy(argRep[10], Parms.iNivelIni);
                strcpy(argRep[11], Parms.iNivelFin);
                strcpy(argRep[12], Parms.sArchivoTemp);
                strcpy(argRep[13], Parms.sbGrupo);
                strcpy(argRep[14], Parms.sbTotales);

/*                fprintf(stdout,"Voy a ejecutar reporte \n");  */
                respuesta=SVCREPS(15, argRep);
/*                fprintf(stdout,"Sali de ejecutar reporte , respuesta : %d \n",respuesta);  */
                if ( respuesta == 0 )
                {
                sprintf(comando, "cp file_c.tmp %s",Parms.sArchivoDisco);
                system(comando);
/*                fprintf(stdout,"Sali de ejecutar comando , errno : %d \n",errno); */
                if( errno == -1)
                {
                    (void) fprintf(stderr, "lin 335 \n");
                    fprintf(stdout, "fallo el cp file_c.tmp %d\n",errno);
                    fprintf(stdout, " [FAILURE]\n");
                }
                else
                {
                    fprintf(stdout, " [SUCCESS]\n");
                }
                }
                else
                {
                    if ( respuesta ==  1 )
                    fprintf(stdout, " [NO_DATA]\n");
                    else
                    fprintf(stdout, " [FAILURE]\n");
                }
                break;
            } /*fin del switch*/


		} /*fin del if UNIDAD*/

		rsql = RegistroSiguiente(&stSQL);
	} while (! rsql);
	Desconecta();
}
