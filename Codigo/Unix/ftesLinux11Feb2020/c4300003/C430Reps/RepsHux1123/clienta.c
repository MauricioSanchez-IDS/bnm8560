#include "common.h"
#include <errno.h>

#define		LEN_UNIDAD	5
#define		LEN_VARENV	128	

#if defined(__cpluplus)
extern "C" {
#endif

#ifdef	_PROTOTYPES
int	procesa_archivo(stParms);
#else
int	procesa_archivo();
#endif

#if defined(__cpluplus)
}
#endif

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

#if defined(__STDC__) || defined(__cplusplus)
int main(int argc, char *argv[])
#else
int main(argc, argv)
int		argc;
	(void) strncpy(*argv[];
#endif
{
	RISQL		stSQL, stSQL1;
	char		sqlcmd[LEN_SQL], sCadenaFormato[1024];
	int		rsql, rsql1, n = 0,respuesta;
	stParms		Parms;
	char		tipo[10], grupo[10];

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

	/*(void) strcpy(sDia_Corte, getenv("DIA_CORTE"));
	(void) strcpy(sTipo_Ejec, getenv("TIPO_EJEC"));
	(void) strcpy(sFecha_Ini, getenv("FECHA_INI"));
	(void) strcpy(sFecha_Fin, getenv("FECHA_FIN"));
	(void) strcpy(sFecha_act, getenv("FECHA_ACT"));
	(void) strcpy(sEmpresa_I, getenv("EMPRESA_I"));
	(void) strcpy(sEmpresa_F, getenv("EMPRESA_F"));
	(void) strcpy(sReporte_I, getenv("REPORTE_I"));
	(void) strcpy(sReporte_F, getenv("REPORTE_F"));
	(void) strcpy(sB_Totales, getenv("B_TOTALES"));*/

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
					    eje_prefijo = %d and \n \
					    gpo_banco = %d and \n \
					    gpo_num = %d",
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

			fflush(stdout);
	
			/* Procesa reporte */
			respuesta=procesa_archivo(Parms);
			if ( respuesta == SUCCESS )
                        {
				fprintf(stdout, " [SUCCESS]\n");}
			else
                        {   
			     if ( respuesta == WARNING)
				fprintf(stdout, " [NO_DATA]\n");
                             else  
				fprintf(stdout, " [FAILURE]\n");
                        }
			fflush(stdout);
		}

		rsql = RegistroSiguiente(&stSQL);
	} while (! rsql);

	Desconecta();
}

#if defined(__STDC__) || defined(__cplusplus)
int procesa_archivo(stParms Parms)
#else
int procesa_archivo(Parms)
stParms	Parms;
#endif
{
	int		cd = 0,
			band = 0;
	int		i = 0,
			n = 0;
	long	recvfml32_len,
			revent;
	char	type[LEN_TYPE + 1],
			data[LEN_DATA + 1];
	long	len_type,
			len_data;
	FBFR32 	*sendfml32,
			*recvfml32;
	FILE	*pf = NULL;
	char	*pos1 = NULL,
			*pos2 = NULL;
	char	empresa[100],
			sCadenaFormato[1024];

	if (tpinit((TPINIT *) NULL) == FAILURE) {
		(void) fprintf(stderr, "tpinit failed: tperrno = %d.\n", tperrno);
		(void) fflush(stderr);
		return (FAILURE);
	}

	if ((sendfml32 =
		(FBFR32 *) tpalloc("FML32", NULL, (long) 4096)) == (FBFR32 *) NULL) {
		(void) fprintf(stderr, "tpalloc failed: tperrno = %d.\n", tperrno);
		(void) fflush(stderr);
		if (tpterm() == FAILURE) {
			(void) fprintf(stderr, "tpterm failed: tperrno = %d.\n", tperrno);
			(void) fflush(stderr);
			return (FAILURE);
		}
		return (FAILURE);
	}

	if ((recvfml32 =
		(FBFR32 *) tpalloc("FML32", NULL, (long) 4096)) == (FBFR32 *) NULL) {
		(void) fprintf(stderr, "tpalloc failed: tperrno = %d.\n", tperrno);
		(void) fflush(stderr);
		tpfree((char *) sendfml32);
		if (tpterm() == FAILURE) {
			(void) fprintf(stderr, "tpterm failed: tperrno = %d.\n", tperrno);
			(void) fflush(stderr);
			return (FAILURE);
		}
		return (FAILURE);
	}

	if ((cd = tpconnect("SRVC_REPS_C", NULL, 0, TPSENDONLY)) == FAILURE) {
		(void) fprintf(stderr, "tpconnect failed: tperrno = %d.\n", tperrno);
		(void) fflush(stderr);
		tpfree((char *) sendfml32);
		tpfree((char *) recvfml32);
		if (tpterm() == FAILURE) {
			(void) fprintf(stderr, "tpterm failed: tperrno = %d.\n", tperrno);
			(void) fflush(stderr);
			return (FAILURE);
		}
		return (FAILURE);
	}

	(void) memset((void *) type, '\0', LEN_TYPE + 1);
	(void) memset((void *) data, '\0', LEN_DATA + 1);

	switch (atoi(Parms.sReporte)) {
		case 13:
			sprintf(Parms.sFechaIniAMD, "%s", "00000000");
			sprintf(Parms.sFechaFinAMD, "%s", "00000000");
			sprintf(data, "%s %s %s %s %s %s %s %s %s %s %s %s %s %s", 
					Parms.sReporte, Parms.sNombreRep, Parms.sFecha,
					Parms.sPrefijo, Parms.sBanco, Parms.sEmpresa, Parms.sUnidad,
					Parms.sFechaIniAMD, Parms.sFechaFinAMD, Parms.sFechaCorteMD,
					Parms.iNivelIni, Parms.iNivelFin, Parms.sArchivoTemp,
					Parms.sbGrupo);
			break;
		case 14:
			sprintf(Parms.sFechaIniAMD, "%s", "00000000");
			sprintf(Parms.sFechaFinAMD, "%s", "00000000");
			sprintf(data, "%s %s %s %s %s %s %s %s %s %s %s %s %s %s", 
					Parms.sReporte, Parms.sNombreRep, Parms.sFecha,
					Parms.sPrefijo, Parms.sBanco, Parms.sEmpresa, Parms.sUnidad,
					Parms.sFechaIniAMD, Parms.sFechaFinAMD, Parms.sFechaCorteMD,
					Parms.iNivelIni, Parms.iNivelFin, Parms.sArchivoTemp,
					Parms.sbGrupo);
			break;
		case 15:
		case 16:
			strcpy(Parms.sFechaCorteMD, "0000");
			sprintf(data, "%s %s %s %s %s %s %s %s %s %s %s %s %s", 
					Parms.sReporte, Parms.sNombreRep, Parms.sFecha,
					Parms.sPrefijo, Parms.sBanco, Parms.sEmpresa, Parms.sUnidad,
					Parms.sFechaIniAMD, Parms.sFechaFinAMD,
					Parms.iNivelIni, Parms.iNivelFin, Parms.sArchivoTemp,
					Parms.sbGrupo);
			break;
		case 18:
			sprintf(Parms.sFechaIniAMD, "%s", "00000000");
			sprintf(Parms.sFechaFinAMD, "%s", "00000000");
			sprintf(data, "%s %s %s %s %s %s %s %s %s %s %s %s %s", 
					Parms.sReporte, Parms.sNombreRep, Parms.sFecha,
					Parms.sPrefijo, Parms.sBanco, Parms.sEmpresa, Parms.sUnidad,
					Parms.sFechaCorteMD,
					Parms.iNivelIni, Parms.iNivelFin, Parms.sArchivoTemp,
					Parms.sbGrupo, Parms.sbTotales);
			break;
		case 20:
			sprintf(Parms.sFechaIniAMD, "%s", "00000000");
			sprintf(Parms.sFechaFinAMD, "%s", "00000000");
			sprintf(data, "%s %s %s %s %s %s %s %s %s %s %s %s %s", 
					Parms.sReporte, Parms.sNombreRep, Parms.sFecha,
					Parms.sPrefijo, Parms.sBanco, Parms.sEmpresa, Parms.sUnidad,
					Parms.sFechaCorteMD,
					Parms.iNivelIni, Parms.iNivelFin, Parms.sArchivoTemp,
					Parms.sbGrupo, Parms.sbTotales);
			break;
		case 22:
			sprintf(Parms.sFechaIniAMD, "%s", "00000000");
			sprintf(Parms.sFechaFinAMD, "%s", "00000000");
			sprintf(data, "%s %s %s %s %s %s %s %s %s %s %s %s %s", 
					Parms.sReporte, Parms.sNombreRep, Parms.sFecha,
					Parms.sPrefijo, Parms.sBanco, Parms.sEmpresa, Parms.sUnidad,
					Parms.sFechaCorteMD,
					Parms.iNivelIni, Parms.iNivelFin, Parms.sArchivoTemp,
					Parms.sbGrupo, Parms.sbTotales);
			break;
		case 23:
			strcpy(Parms.sFechaCorteMD, "0000");
			sprintf(data, "%s %s %s %s %s %s %s %s %s %s %s %s %s %s", 
					Parms.sReporte, Parms.sNombreRep, Parms.sFecha,
					Parms.sPrefijo, Parms.sBanco, Parms.sEmpresa, Parms.sUnidad,
					Parms.sFechaIniAMD, Parms.sFechaFinAMD, Parms.sFechaCorteMD,
					Parms.iNivelIni, Parms.iNivelFin, Parms.sArchivoTemp,
					Parms.sbGrupo);
			break;
		case 24:
			sprintf(Parms.sFechaIniAMD, "%s", "00000000");
			sprintf(Parms.sFechaFinAMD, "%s", "00000000");
			sprintf(data, "%s %s %s %s %s %s %s %s %s %s %s %s %s %s", 
					Parms.sReporte, Parms.sNombreRep, Parms.sFecha,
					Parms.sPrefijo, Parms.sBanco, Parms.sEmpresa, Parms.sUnidad,
					Parms.sFechaIniAMD, Parms.sFechaFinAMD, Parms.sFechaCorteMD,
					Parms.iNivelIni, Parms.iNivelFin, Parms.sArchivoTemp,
					Parms.sbGrupo);
			break;
		case 25:
			sprintf(Parms.sFechaCorteMD, "%s", "0000");
			sprintf(data, "%s %s %s %s %s %s %s %s %s %s %s %s %s %s", 
					Parms.sReporte, Parms.sNombreRep, Parms.sFecha,
					Parms.sPrefijo, Parms.sBanco, Parms.sEmpresa, Parms.sUnidad,
					Parms.sFechaIniAMD, Parms.sFechaFinAMD, Parms.sFechaCorteMD,
					Parms.iNivelIni, Parms.iNivelFin, Parms.sArchivoTemp,
					Parms.sbGrupo);
			break;
		case 26:
			sprintf(Parms.sFechaIniAMD, "%s", "00000000");
			sprintf(Parms.sFechaFinAMD, "%s", "00000000");
			sprintf(data, "%s %s %s %s %s %s %s %s %s %s %s %s %s %s", 
					Parms.sReporte, Parms.sNombreRep, Parms.sFecha,
					Parms.sPrefijo, Parms.sBanco, Parms.sEmpresa, Parms.sUnidad,
					Parms.sFechaIniAMD, Parms.sFechaFinAMD, Parms.sFechaCorteMD,
					Parms.iNivelIni, Parms.iNivelFin, Parms.sArchivoTemp,
					Parms.sbGrupo);
			break;
		default:
		        tpfree((char *) sendfml32);
		        tpfree((char *) recvfml32);
			if (tpterm() == FAILURE) {			
				(void) fprintf(stderr,
								"tpterm failed: tperrno = %d.\n", tperrno);
				(void) fflush(stderr);			
				return (FAILURE);			
			}			
			return (FAILURE);
	}

	if (Fchg32(	(FBFR32 *) sendfml32,			
				(FLDID32) F_TYPE,			
				(FLDOCC32) 0,			
				(char *) "0000",			
				(FLDLEN32) LEN_TYPE) == FAILURE) {			
		(void) fprintf(stderr, "Fchg32 failed: Ferror32 = %d.\n", Ferror32);
		(void) fflush(stderr);			
		tpfree((char *) sendfml32);
		tpfree((char *) recvfml32);
		if (tpterm() == FAILURE) {			
			(void) fprintf(stderr, "tpterm failed: tperrno = %d.\n", tperrno);
			(void) fflush(stderr);			
			return (FAILURE);			
		}			
		return (FAILURE);
	}

	if (Fchg32(	(FBFR32 *) sendfml32,			
				(FLDID32) F_DATA,			
				(FLDOCC32) 0,
				(char *) data,
				(FLDLEN32) LEN_DATA) == FAILURE) {			
		fprintf(stderr, "Fchg32 failed: Ferror32 = %d.\n", Ferror32);			
		fflush(stderr);			
		tpfree((char *) sendfml32);
		tpfree((char *) recvfml32);
		if (tpterm() == FAILURE) {			
			fprintf(stderr, "tpterm failed: tperrno = %d.\n", tperrno);			
			fflush(stderr);			
			return (FAILURE);			
		}			
		return (FAILURE);			
	}			

	if (tpsend(cd, (char *) sendfml32, 0L, TPRECVONLY, &revent) == FAILURE) {
		(void) fprintf(stderr, "tpsend failed: tperrno = %d.\n", tperrno);
		(void) fflush(stderr);
		tpfree((char *) sendfml32);
		tpfree((char *) recvfml32);
		if (tpterm() == FAILURE) {
			(void) fprintf(stderr, "tpterm failed: tperrno = %d.\n", tperrno);
			(void) fflush(stderr);
			return (FAILURE);
		}
		return (FAILURE);
	}

	if (tprecv(	cd,
				(char **) &recvfml32,
				&recvfml32_len,
				TPNOCHANGE,
				&revent) != FAILURE) {
		(void) fprintf(	stderr,
						"lin 456 tprecv failed: tperrno = %d.\n", tperrno, revent);
		(void) fflush(stderr);
		tpfree((char *) sendfml32);
		tpfree((char *) recvfml32);
		if (tpterm() == FAILURE) {
			(void) fprintf(stderr, "tpterm failed: tperrno = %d.\n", tperrno);
			(void) fflush(stderr);
			return (FAILURE);
		}
		return (FAILURE);
	}
	
	if ((tperrno != TPEEVENT) ||
		((revent != TPEV_SENDONLY) &&
		(revent != TPEV_SVCSUCC) &&
		(revent != TPEV_SVCFAIL))) {
		(void) fprintf(stderr, " lin 472 tprecv failed: tperrno = %d.\n", tperrno);
(void) fprintf(stderr, " lin 472 tprecv failed: tperrdetail = %d: tpstrerrordetail %s.\n", tperrordetail(0),tpstrerrordetail(tperrordetail(0),0));
		(void) fflush(stderr);
		tpfree((char *) sendfml32);
		tpfree((char *) recvfml32);
		if (tpterm() == FAILURE) {
			(void) fprintf(stderr, "tpterm failed: tperrno = %d.\n", tperrno);
			(void) fflush(stderr);
			return (FAILURE);
		}
		return (FAILURE);
	}

	switch (revent) {
		case TPEV_SENDONLY:
			break;
		case TPEV_SVCFAIL:
		        tpfree((char *) recvfml32);
		        tpfree((char *) recvfml32);
		case TPEV_SVCSUCC:
			if (tpterm() == FAILURE) {
				(void) fprintf(	stderr,
								"tpterm failed: tperrno = %d.\n", tperrno);
				(void) fflush(stderr);
				return (FAILURE);
			}
			return (SUCCESS);
			break;
		        tpfree((char *) recvfml32);
		        tpfree((char *) sendfml32);
			if (tpterm() == FAILURE) {
				(void) fprintf(	stderr,
								"tpterm failed: tperrno = %d.\n", tperrno);
				(void) fflush(stderr);
				return (FAILURE);
			}
			return (FAILURE);
			break;
	}

	(void) memset((void *) type, '\0', LEN_TYPE + 1);
	(void) memset((void *) data, '\0', LEN_DATA + 1);

	len_type = (long) sizeof(type);
	len_data = (long) sizeof(data);

	if (Fget32(	(FBFR32 *) recvfml32,
				(FLDID32) F_TYPE,
				(FLDOCC32) i,
				(char *) type,
				(FLDLEN32 *) &len_type) == FAILURE) {
		(void) fprintf(stderr, "Fget32 failed: Ferror32 = %d.\n", Ferror32);
		(void) fflush(stderr);
		tpfree((char *) sendfml32);
		tpfree((char *) recvfml32);
		if (tpterm() == FAILURE) {
			(void) fprintf(stderr, "tpterm failed: tperrno = %d.\n", tperrno);
			(void) fflush(stderr);
			return (FAILURE);
		}
		return (FAILURE);
	}
	
	if (Fget32(	(FBFR32 *) recvfml32,
				(FLDID32) F_DATA,
				(FLDOCC32) i,
				(char *) data,
				(FLDLEN32 *) &len_data) == FAILURE) {
		(void) fprintf(stderr, "Fget32 failed: Ferror32 = %d.\n", Ferror32);
		(void) fflush(stderr);
		tpfree((char *) sendfml32);
		tpfree((char *) recvfml32);
		if (tpterm() == FAILURE) {
			(void) fprintf(stderr, "tpterm failed: tperrno = %d.\n", tperrno);
			(void) fflush(stderr);
			return (FAILURE);
		}
		return (FAILURE);
	}

	if (! strcmp(data, "REPORT_FAILURE")) {
		tpfree((char *) sendfml32);
		tpfree((char *) recvfml32);
		if (tpterm() == FAILURE) {
			(void) fprintf(stderr, "tpterm failed: tperrno = %d.\n", tperrno);
			(void) fflush(stderr);
			return (FAILURE);
		}
		return (FAILURE);
	}
	else if (! strcmp(data, "REPORT_NO_DATA")) {
		tpfree((char *) sendfml32);
		tpfree((char *) recvfml32);
		if (tpterm() == FAILURE) {
			(void) fprintf(stderr, "tpterm failed: tperrno = %d.\n", tperrno);
			(void) fflush(stderr);
			return (FAILURE);
		}
		return (WARNING);
	}

	if (Fdelall32(recvfml32, F_TYPE) < 0) {
		userlog("Fdelall32 failed.");
		F_error("Fdelall32 failed.");
		tpfree((char *) sendfml32);
		tpfree((char *) recvfml32);
		exit(FAILURE);
	}

	if (Fdelall32(recvfml32, F_DATA) < 0) {
		userlog("Fdelall32 failed.");
		F_error("Fdelall32 failed.");
		tpfree((char *) sendfml32);
		tpfree((char *) recvfml32);
		exit(FAILURE);
	}

	(void) memset((void *) empresa, '\0', sizeof(empresa)); 
	sprintf(sCadenaFormato, "%%s/%%s%%s%%0%dd", atoi(Parms.sLongEmpresa));
	sprintf(empresa, sCadenaFormato, getenv("DIR_ARCH"),
			Parms.sPrefijo, Parms.sBanco, atoi(Parms.sEmpresa)),
	mkdir(	empresa,
			S_IRUSR | S_IWUSR | S_IXUSR |
			S_IRGRP | S_IWGRP | S_IXGRP |
			S_IROTH | S_IWOTH | S_IXOTH);
        if( errno == -1)
        {
	(void) fprintf(stderr, "lin 592 \n");
	    fprintf(stdout, "fallo el mkdir errno=%d\n",errno);
        }

	if ((pf = fopen(Parms.sArchivoDisco, "w")) == NULL) {
		(void) fprintf(stderr, "fopen failed.\n");
		(void) fflush(stderr);
		tpfree((char *) sendfml32);
		tpfree((char *) recvfml32);
		if (tpterm() == FAILURE) {
			(void) fprintf(stderr, "lin 601 tpterm failed: tperrno = %d.\n", tperrno);
			(void) fflush(stderr);
			return (FAILURE);
		}
		return (FAILURE);
	}

	do {
		if (tpsend(	cd,
					(char *) sendfml32,
					0L,
					TPRECVONLY,
					&revent) == FAILURE) {
			(void) fprintf(	stderr,
							"tpsend failed: tperrno = %d.\n", tperrno);
			(void) fflush(stderr);
			tpfree((char *) sendfml32);
			tpfree((char *) recvfml32);
			if (tpterm() == FAILURE) {
				(void) fprintf(	stderr,
								"tpterm failed: tperrno = %d.\n", tperrno);
				(void) fflush(stderr);
				return (FAILURE);
			}
			return (FAILURE);
		}

		if (tprecv(	cd,
					(char **) &recvfml32,
					&recvfml32_len,
					TPNOCHANGE,
					&revent) != FAILURE) {
			(void) fprintf(	stderr,
							"linea 627 tprecv failed: tperrno = %d.\n", tperrno, revent);
			(void) fflush(stderr);
			tpfree((char *) sendfml32);
			tpfree((char *) recvfml32);
			if (tpterm() == FAILURE) {
				(void) fprintf(	stderr,
								"tpterm failed: tperrno = %d.\n", tperrno);
				(void) fflush(stderr);
				return (FAILURE);
			}
			return (FAILURE);
		}
	
		if ((tperrno != TPEEVENT) ||
			((revent != TPEV_SENDONLY) &&
			(revent != TPEV_SVCSUCC) &&
			(revent != TPEV_SVCFAIL))) {
			(void) fprintf(stderr, " linea 645 tprecv failed: tperrno = %d.\n", tperrno);
			(void) fflush(stderr);
			tpfree((char *) sendfml32);
			tpfree((char *) recvfml32);
			if (tpterm() == FAILURE) {
				(void) fprintf(	stderr,
								"tpterm failed: tperrno = %d.\n", tperrno);
				(void) fflush(stderr);
				return (FAILURE);
			}
			return (FAILURE);
		}

		n = Foccur32(recvfml32, F_DATA);

		for (i = 0; i < n; i++) {
			(void) memset((void *) type, '\0', LEN_TYPE + 1);
			(void) memset((void *) data, '\0', LEN_DATA + 1);

			len_type = (long) sizeof(type);
			len_data = (long) sizeof(data);

			if (Fget32(	(FBFR32 *) recvfml32,
						(FLDID32) F_TYPE,
						(FLDOCC32) i,
						(char *) type,
						(FLDLEN32 *) &len_type) == FAILURE) {
				(void) fprintf(	stderr,
								"Fget32 failed: Ferror32 = %d.\n", Ferror32);
				(void) fflush(stderr);
				tpfree((char *) sendfml32);
				tpfree((char *) recvfml32);
				if (tpterm() == FAILURE) {
					(void) fprintf(	stderr,
									"tpterm failed: tperrno = %d.\n", tperrno);
					(void) fflush(stderr);
					return (FAILURE);
				}
				return (FAILURE);
			}
	
			if (Fget32(	(FBFR32 *) recvfml32,
						(FLDID32) F_DATA,
						(FLDOCC32) i,
						(char *) data,
						(FLDLEN32 *) &len_data) == FAILURE) {
				(void) fprintf(	stderr,
								"Fget32 failed: Ferror32 = %d.\n", Ferror32);
				(void) fflush(stderr);
				tpfree((char *) sendfml32);
				tpfree((char *) recvfml32);
				if (tpterm() == FAILURE) {
					(void) fprintf(	stderr,
									"tpterm failed: tperrno = %d.\n", tperrno);
					(void) fflush(stderr);
					return (FAILURE);
				}
				return (FAILURE);
			}
	               if ( strcmp(data,"EOF") != 0 )
			(void) fprintf(pf, "%s", data);
			(void) fflush(pf);
		}

		switch (revent) {
			case TPEV_SENDONLY:
				band = 1;
				break;
			case TPEV_SVCSUCC:
			case TPEV_SVCFAIL:
				band = 0;
				break;
		}

		if (Fdelall32(recvfml32, F_TYPE) < 0) {
			userlog("Fdelall32 failed.");
			F_error("Fdelall32 failed.");
			tpfree((char *) sendfml32);
			tpfree((char *) recvfml32);
			exit(FAILURE);
		}

		if (Fdelall32(recvfml32, F_DATA) < 0) {
			userlog("Fdelall32 failed.");
			F_error("Fdelall32 failed.");
			tpfree((char *) sendfml32);
			tpfree((char *) recvfml32);
			exit(FAILURE);
		}

	} while (band);

	tpfree((char *) sendfml32);
	tpfree((char *) recvfml32);
	if (tpterm() == FAILURE) {
		fprintf(stderr, "tpterm failed: tperrno = %d.\n", tperrno);
		fflush(stderr);
	
	}
	return (SUCCESS);
}
