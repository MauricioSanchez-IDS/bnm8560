#include "commons.h"
#include <ctype.h>
#include <strings.h>

static char	pgmname[LEN_BUFFER];
char		args[16][16];


struct services {
	int		id;
	int		n_parms;
	int		(*function)();
	char	name[10];
	int		enable;
};

struct services rep_svcs[11] = {
	{13, 14, SVCREP13, "SVCREP13", 1},
	{14, 14, SVCREP14, "SVCREP14", 1},
	{15, 13, SVCREP16, "SVCREP16", 1},
	{16, 13, SVCREP16, "SVCREP16", 1},
	{18, 13, SVCREP18, "SVCREP18", 1},
	{20, 13, SVCREP20, "SVCREP20", 1},
	{22, 13, SVCREP22, "SVCREP22", 1},
	{23, 14, SVCREP24, "SVCREP23", 1},
	{24, 14, SVCREP24, "SVCREP24", 1},
	{25, 14, SVCREP26, "SVCREP25", 1},
	{26, 14, SVCREP26, "SVCREP26", 1}
};

#if defined(__STDC__) || defined(__cplusplus)
int tpsvrinit(int argc, char **argv)
#else
int tpsvrinit(argc, argv)
int     argc;
char    **argv;
#endif
{
FILE *a;           
char comando[250]; 
int i;             
char passwd[250];
char variableAmbiente[250];

	strcpy(pgmname, argv[0]);
	userlog("%s activo.", pgmname);


sprintf(comando,                              
        "%s",               
        "/opt/c430/000/bin/password.sh > /opt/c617/tuxedo80/d1/bin/pc430tuxRep");
        system(comando);            
if ((a = fopen("/opt/c617/tuxedo80/d1/bin/pc430tuxRep", "r")) == NULL){
      printf("No se puede abrir el Archivo pc430tuxRep\n");
      userlog("MOVSRepsCredito  SE PUDO OBTENER EL PWD DE SAPUF");
      return -1;
}
else
{
fgets(passwd,30,a);
for(i=0; i<29;i++)
   if( passwd[i]== ' ' || passwd[i]=='\n')
       passwd[i]='\0';
sprintf(comando,"%s","rm /opt/c617/tuxedo80/d1/bin/pc430tuxRep");
/*sprintf(comando,"%s","chmod 777 /opt/c617/tuxedo80/d1/bin/pc430tuxRep");*/
system(comando);
      userlog("MOVSRepsCredito SI PUDO OBTENER EL PWD DE SAPUF \n");
sprintf(variableAmbiente,"PASSC430DBO=%s",passwd);
tuxputenv(variableAmbiente);                             
}

	return (SUCCESS);
}

#if defined(__STDC__) || defined(__cplusplus)
void tpsvrdone(void)
#else
void tpsvrdone()
#endif
{
	userlog("%s inactivo.", pgmname);
}

#if defined(__STDC__) || defined(__cplusplus)
void SRVC_REPS_C(TPSVCINFO *svcinfo)
#else
void SRVC_REPS_C(svcinfo)
TPSVCINFO *svcinfo;
#endif
{
	FBFR32	*request, *response;
	FILE	*pf;
	long	request_len, revent;
	char	type[LEN_TYPE + 1], data[LEN_DATA + 1];
	long	len_type, len_data;
	int		i = 0, band = TRUE, occ = 0, j ,es_num;
	char	rep_id[4];
	int		n = 0, ret = 0, r_id = 0;
	int		index = 0;
        int longitud;

	
	if ((request =
		(FBFR32 *) tpalloc("FML32", NULL, (long) 4096)) == (FBFR32 *) NULL) {
		userlog("tpalloc failed: tperrno = %d.\n", tperrno);
		tpreturn(TPFAIL, 0L, NULL, 0L, 0L);
	}

	if ((response =
		(FBFR32 *) tpalloc("FML32", NULL, (long) 4096)) == (FBFR32 *) NULL) {
		userlog("tpalloc failed: tperrno = %d.\n", tperrno);
		tpfree((char *) request);
		tpreturn(TPFAIL, 0L, NULL, 0L, 0L);
	}
	
	if (tprecv(svcinfo->cd,
				(char **) &request,
				&request_len, TPNOCHANGE, &revent) != FAILURE) {
		userlog("tprecv without event.");
		tpfree((char *) request);
		tpfree((char *) response);
		tpreturn(TPFAIL, 0L, NULL, 0L, 0L);
	}

	switch (tperrno) {
		case TPEEVENT:
			switch ((int) revent) {
				case TPEV_SENDONLY:
				case TPEV_SVCSUCC:
				case TPEV_SVCFAIL:
					break;
				case TPEV_DISCONIMM:
					tpfree((char *) request);
					tpfree((char *) response);
					userlog("pase por la linea 101 \n");
					tpreturn(TPSUCCESS, 0L, NULL, 0L, 0L);
			}
			break;
		default:
			userlog("tprecv failed: tperrno = %d.\n", tperrno);
			tpfree((char *) request);
			tpfree((char *) response);
			tpreturn(TPFAIL, 0L, NULL, 0L, 0L);
	}

	(void) memset((void *) type, '\0', LEN_TYPE + 1);
	(void) memset((void *) data, '\0', LEN_DATA + 1);

	if (Fget32(	(FBFR32 *) request,
				(FLDID32) F_TYPE,
				(FLDOCC32) 0,
				(char *) type,
				(FLDLEN32 *) &len_type) == FAILURE) {
		(void) fprintf(stderr, "Fget32 failed: Ferror32 = %d.\n", Ferror32);
		(void) fflush(stderr);
		tpfree((char *) request);
		tpfree((char *) response);
		tpreturn(TPFAIL, 0L, NULL, 0L, 0L);
	}
	
	if (Fget32(	(FBFR32 *) request,
				(FLDID32) F_DATA,
				(FLDOCC32) 0,
				(char *) data,
				(FLDLEN32 *) &len_data) == FAILURE) {
		(void) fprintf(stderr, "Fget32 failed: Ferror32 = %d.\n", Ferror32);
		(void) fflush(stderr);
		tpfree((char *) request);
		tpfree((char *) response);
		tpreturn(TPFAIL, 0L, NULL, 0L, 0L);
	}

	/*sscanf(data, "%s ", rep_id);
	r_id = atoi(rep_id);*/

        n = copia_params(args, data);
        strcpy(rep_id,args[0]);
        r_id=0;
        if (args[0] != NULL)
        {
          r_id=strlen(rep_id);
          es_num = 1;
          for (j = 0; j < r_id; j++) 
          {
             if (!isdigit(rep_id[j])) 
             {
                es_num = 0;
                break;
             }
          }
        }
   /* Si no es numerico el primer argumento existe un error. */
   if(es_num == 0 )
   {
      userlog("Existe un error en el server el reporte id='%s'\n", args[0]);
      r_id=0;
      tpfree((char *) request);
      tpfree((char *) response);
      tpreturn(TPFAIL, 0L, NULL, 0L, 0L);
   }
userlog("El reporte solicitado es %s \n",args[0]);

    r_id=atoi(rep_id);
    for (i = 0; i < 11; ++i){
     if (r_id == rep_svcs[i].id){
       if (rep_svcs[i].enable == 1)
       { break; }
       else {  
         userlog("El reporte '%d' no es valido\n", r_id);
         tpfree((char *) request);
         tpfree((char *) response);
         tpreturn(TPFAIL, 0L, NULL, 0L, 0L);
    }}}

    if (n != rep_svcs[i].n_parms)
    { 
        userlog("los argu no son validos %d \n", n);
        tpfree((char *) request);
        tpfree((char *) response);
        tpreturn(TPFAIL, 0L, NULL, 0L, 0L);
    }
    
	ret = (int) (*(rep_svcs[i].function))(n, args);
	/*userlog("despues del server ret=%d\n",ret);*/

	switch (ret) {
		case 0:  strcpy(data, "REPORT_SUCCESS"); break;
		case 1:  strcpy(data, "REPORT_NO_DATA"); break;
		case -1: strcpy(data, "REPORT_FAILURE"); break;
	}

	(void) strcpy(type, "0000");
	if (Fchg32(	(FBFR32 *) response,			
				(FLDID32) F_TYPE,			
				(FLDOCC32) occ,			
				(char *) type,
				(FLDLEN32) LEN_TYPE) == FAILURE) {
		userlog("Fchg32 failed: Ferror32 = %d.\n", Ferror32);			
		tpfree((char *) request);
		tpfree((char *) response);
		tpreturn(TPFAIL, 0L, NULL, 0L, 0L);
	}			

	if (Fchg32(	(FBFR32 *) response,			
				(FLDID32) F_DATA,			
				(FLDOCC32) occ,			
				(char *) data,			
				(FLDLEN32) LEN_DATA) == FAILURE) {			
		userlog("Fchg32 failed: Ferror32 = %d.\n", Ferror32);			
		tpfree((char *) request);
		tpfree((char *) response);
		tpreturn(TPFAIL, 0L, NULL, 0L, 0L);
	}			

	if (tpsend(	svcinfo->cd,
				(char *) response,
				0,
				TPRECVONLY,
				&revent) == FAILURE) {
	switch (tperrno) {
		case TPEEVENT:
			switch ((int) revent) {
				case TPEV_DISCONIMM:
					tpfree((char *) request);
					tpfree((char *) response);
                        		userlog("pase por la linea 198 \n");
					tpreturn(TPSUCCESS, 0L, NULL, 0L, 0L);
					}
		default:
			userlog("tpsend failed: tperrno = %d.\n", tperrno);
			tpfree((char *) request);
			tpfree((char *) response);
			tpreturn(TPFAIL, 0L, NULL, 0L, 0L);
			}
		}

	if (Fdelall32(response, F_TYPE) < 0) {
		userlog("Fdelall32 failed 1.");
		F_error("Fdelall32 failed 11.");
		tpfree((char *) request);
		tpfree((char *) response);
		tpreturn(TPFAIL, 0L, NULL, 0L, 0L);
	}

	if (Fdelall32(response, F_DATA) < 0) {
		userlog("Fdelall32 failed 111.");
		F_error("Fdelall32 failed 1111.");
		tpfree((char *) request);
		tpfree((char *) response);
		tpreturn(TPFAIL, 0L, NULL, 0L, 0L);
	}
	if (ret == 0) {

	if ((pf = fopen("file_c.tmp", "rb")) == NULL) {
		userlog("fopen failed.\n");
		tpfree((char *) request);
		tpfree((char *) response);
		tpreturn(TPFAIL, 0L, NULL, 0L, 0L);
	}

	do {
		if (tprecv(	svcinfo->cd,
					(char **) &request,
					&request_len,
					TPNOCHANGE,
					&revent) != FAILURE) {
			userlog("tprecv without event.");
			tpfree((char *) request);
			tpfree((char *) response);
			tpreturn(TPFAIL, 0L, NULL, 0L, 0L);
		}

		switch (tperrno) {
			case TPEEVENT:
				switch ((int) revent) {
					case TPEV_SENDONLY:
					case TPEV_SVCSUCC:
					case TPEV_SVCFAIL:
						break;
					case TPEV_DISCONIMM:
						tpfree((char *) request);
						tpfree((char *) response);
						userlog("linea 338 \n");
						tpreturn(TPSUCCESS, 0L, NULL, 0L, 0L);
				}
				/*userlog("lin 309\n");
			tpfree((char *) request);
			tpfree((char *) response);
			userlog("linea 347 \n");
				tpreturn(TPFAIL, 0L, NULL, 0L, 0L);*/
				break;
			default:
				userlog("line 351tprecv tperrno=%d\n", tperrno);
				tpfree((char *) request);
				tpfree((char *) response);
				tpreturn(TPFAIL, 0L, NULL, 0L, 0L);
		}

		do {
			(void) memset((void *) type, '\0', LEN_TYPE + 1);
			(void) memset((void *) data, '\0', LEN_DATA + 1);

			if (! feof(pf)) {
				fgets(data, LEN_DATA, pf);
				data[LEN_DATA] = NULL;
				(void) strcpy(type, "0000");
				if (Fchg32((FBFR32 *) response,
					(FLDID32) F_TYPE,
					(FLDOCC32) occ,
					(char *) type,
					(FLDLEN32) LEN_TYPE) == FAILURE) {
				userlog("370 Fchg32 Ferror32=%d.\n", Ferror32);
				 tpfree((char *) request);
				 tpfree((char *) response);
                                 fclose(pf);
			         tpreturn(TPFAIL, 0L, NULL, 0L, 0L);
				}			
	
				if (Fchg32((FBFR32 *) response,
					(FLDID32) F_DATA,
					(FLDOCC32) occ,
					(char *) data,
					(FLDLEN32) LEN_DATA) == FAILURE) {
				  userlog("382 Fchg32 Ferror32=%d\n", Ferror32);
				  tpfree((char *) request);
				  tpfree((char *) response);
                                  fclose(pf);
				tpreturn(TPFAIL, 0L, NULL, 0L, 0L);
				}			
				++occ;
			}
			else {
				band = FALSE;
				break;
			}
	
		} while (Funused32(response) >= LEN_BUFFER);

		if (tpsend(	svcinfo->cd,
					(char *) response,
					0,
					TPRECVONLY,
					&revent) == FAILURE) {
			switch (tperrno) {
			case TPEEVENT:
				switch ((int) revent) {
				case TPEV_DISCONIMM:
					tpfree((char *) request);
					tpfree((char *) response);
					userlog("linea 409\n");
                                        fclose(pf);
					tpreturn(TPSUCCESS, 0L, NULL, 0L, 0L);
				}
			default:
				userlog("412 failed: tperrno = %d.\n", tperrno);
				tpfree((char *) request);
                                fclose(pf);
				tpfree((char *) response);
				tpreturn(TPFAIL, 0L, NULL, 0L, 0L);
			}
		}
	
		if (Fdelall32(response, F_TYPE) < 0) {
                        fclose(pf);
			userlog("Fdelall32 failed 2.");
			F_error("Fdelall32 failed 22.");
			tpfree((char *) request);
			tpfree((char *) response);
			tpreturn(TPFAIL, 0L, NULL, 0L, 0L);
		}

		if (Fdelall32(response, F_DATA) < 0) {
                        fclose(pf);
			userlog("Fdelall32 failed 222.");
			F_error("Fdelall32 failed 2222.");
			tpfree((char *) request);
			tpfree((char *) response);
			tpreturn(TPFAIL, 0L, NULL, 0L, 0L);
		}

		occ = 0;

	} while (band);
        fclose(pf);
	if (tprecv(	svcinfo->cd,
				(char **) &request,
				&request_len,
				TPNOCHANGE,
				&revent) != FAILURE) {
		userlog("tprecv without event.");
		tpfree((char *) request);
		tpfree((char *) response);
		tpreturn(TPFAIL, 0L, NULL, 0L, 0L);
	}

	switch (tperrno) {
		case TPEEVENT:
			switch ((int) revent) {
				case TPEV_SENDONLY:
				case TPEV_SVCSUCC:
				case TPEV_SVCFAIL:
					break;
				case TPEV_DISCONIMM:
					tpfree((char *) request);
					tpfree((char *) response);
	                        	userlog("pase por la linea 464 \n");
					tpreturn(TPSUCCESS, 0L, NULL, 0L, 0L);
			}
			break;
		default:
			userlog("tprecv failed: tperrno = %d.\n", tperrno);
			tpfree((char *) request);
			tpfree((char *) response);
			tpreturn(TPFAIL, 0L, NULL, 0L, 0L);
	}

	(void) strcpy(type, "0000");
	if (Fchg32(	(FBFR32 *) response,
				(FLDID32) F_TYPE,
				(FLDOCC32) 0,			
				(char *) type,
				(FLDLEN32) LEN_TYPE) == FAILURE) {
		userlog("Fadd32 failed: Ferror32 = %d.\n", Ferror32);
		tpfree((char *) request);
		tpfree((char *) response);
		tpreturn(TPFAIL, 0L, NULL, 0L, 0L);
	}

	(void) strcpy(data, "EOF");
	if (Fchg32(	(FBFR32 *) response,
				(FLDID32) F_DATA,
				(FLDOCC32) 0,			
				(char *) data,
				(FLDLEN32) LEN_DATA) == FAILURE) {
		userlog("Fadd32 failed: Ferror32 = %d.\n", Ferror32);
		tpfree((char *) request);
		tpfree((char *) response);
		tpreturn(TPFAIL, 0L, NULL, 0L, 0L);
	}
	tpfree((char *) request);
	/*tpfree((char *) response);*/
	tpreturn(TPSUCCESS, 0L, (char *)response, 0L, 0L);
      }
      else
      {
        tpfree((char *) request);
        tpfree((char *) response);
	tpreturn(TPFAIL, 0L, NULL, 0L, 0L);
      }
}

int copia_params(cads, cad)
char cads[16][16];
char *cad;
{
	int		i = 0;
	char	*p;

	p = (char *) strtok(cad, " ");
	while (p != NULL) {
		strcpy(cads[i], p);
                i++;
		p = (char *) strtok(NULL, " ");
	}
	return i;
}
