#define __ARBOLUNI_H
#define MAXTAMUNI       16
#define NIVEL           4
#define EJE_PREFIJO     0
#define GPO_BANCO       1
#define EMP_NUM         2
#define GPO_NUM         3
#define UNIT_ID         4
#define UNIT_PARENT_ID  5
#define NIVEL_NUM       6

struct strUnidad {
    char eje_prefijo[11];
    char gpo_banco[11];
    char emp_num[11];
    char gpo_num[11];
    char unit_id[MAXTAMUNI];
    char unit_parent_id[MAXTAMUNI];
    char nivel_num[NIVEL];
    struct strUnidad *Previo;
    struct strUnidad *Siguiente;
};
typedef struct strUnidad Unidad;

struct strArbol {
    Unidad *Primero;
    Unidad *Ultimo;
    Unidad *Actual;
};
typedef struct strArbol Arbol;

#if defined(__cplusplus)
extern "C" {
#endif

#if defined(_PROTOTYPES)
    void ObtenArbolUni(Arbol *);
    int TraeSubVector(Arbol *, Arbol *, char *, char *,char *, char *);
    int RegUniSiguiente(Arbol *);
    int RegUniPrevio(Arbol *);
    int RegUniPrimero(Arbol *);
    int RegUniUltimo(Arbol *);
    int ObtenValorUni(Arbol *, int, char *);
    int TraeUnidad(Arbol *, Arbol *, char *, char *, char *,char *, int, int);
    void LiberaMemArb(Arbol *);
#else
    void ObtenArbolUni();
    int TraeSubVector();
    int RegUniSiguiente();
    int RegUniPrevio();
    int RegUniPrimero();
    int RegUniUltimo();
    int ObtenValorUni();
    int TraeUnidad();
    void LiberaMemArb();
#endif

#if defined(__cplusplus)
}
#endif

/***************************/
void ObtenArbolUni(NodoArbol)
Arbol *NodoArbol;
{

    RISQL myStr;
    Unidad *NodoUni;
    char *sQry;
    int SeAgrego;
    int ret;
    int retReg;

    NodoArbol->Primero = NULL;
    NodoArbol->Ultimo = NULL;
    NodoArbol->Actual = NULL;
    SeAgrego = 0;

    sQry = (char *) malloc(sizeof(char) * 1000);
    strcpy(sQry, "select eje_prefijo, gpo_banco, emp_num, ");
    strcat(sQry, "gpo_num, substring(rtrim(ltrim(unit_id)),1,5), substring(rtrim(ltrim(unit_parent_id)),1,5), nivel_num ");
    strcat(sQry, "from MTCUNI01 where nivel_num <> 99 ");
    strcat(sQry, " and  eje_prefijo <> 5584 and gpo_banco <> 26 ");
    strcat(sQry, "order by eje_prefijo,gpo_banco,emp_num, nivel_num ");

    myStr.scadena_sql = sQry;
    myStr.icampos = 7;
    myStr.lRegistros = 0;
    EjecutaSQL(&myStr);

    ret = RegistroPrimero(&myStr);
    do {
        /* CREAR NODO */
        NodoUni = (Unidad *) malloc(sizeof(Unidad));

        if (NodoUni == NULL)
            printf("\nMEMORIA INSUFICIENTE PARA CREAR NODO");

        NodoUni->Siguiente = NULL;
        NodoUni->Previo = NULL;

        ret = ObtenCampo(&myStr, 0, NodoUni->eje_prefijo);
        ret = ObtenCampo(&myStr, 1, NodoUni->gpo_banco);
        ret = ObtenCampo(&myStr, 2, NodoUni->emp_num);
        ret = ObtenCampo(&myStr, 3, NodoUni->gpo_num);
        ret = ObtenCampo(&myStr, 4, NodoUni->unit_id);
        ret = ObtenCampo(&myStr, 5, NodoUni->unit_parent_id);
        ret = ObtenCampo(&myStr, 6, NodoUni->nivel_num);

        /* EN CASO DE SER EL PRIMERO */
        if (NodoArbol->Primero == NULL) {
            NodoArbol->Primero = NodoUni;
            NodoArbol->Ultimo = NodoUni;
            NodoArbol->Actual = NodoUni;
            SeAgrego = 1;
        }

        /* ME POSICIONO EN EL PRIMER ELEMENTO DEL ARBOL */
        NodoArbol->Actual = NodoArbol->Primero;

        /* AGREGAR EL NODO A LA LISTA EN BASE AL ORDEN */
        do {
            if ( 
                (strcmp(NodoArbol->Actual->eje_prefijo,
                NodoUni->eje_prefijo) == 0) &&
                (strcmp(NodoArbol->Actual->gpo_banco,
                NodoUni->gpo_banco) == 0) &&
                (strcmp(NodoArbol->Actual->emp_num,
                NodoUni->emp_num) == 0) &&
                (strcmp(NodoArbol->Actual->unit_id,
                NodoUni->unit_parent_id) == 0) 
                                                     ) {
                    NodoUni->Previo = NodoArbol->Actual;
                    NodoUni->Siguiente = NodoArbol->Actual->Siguiente;
                    NodoArbol->Actual->Siguiente = NodoUni;
                    SeAgrego = 1;
                    break;
            }
            if (NodoArbol->Actual != NodoArbol->Ultimo)
            NodoArbol->Actual = NodoArbol->Actual->Siguiente;
        } while (NodoArbol->Actual != NodoArbol->Ultimo);

        /* AGREGAR EL NODO AL FIN SI NO SE ENCONTRO PADRE */
        if (SeAgrego == 0) {
            NodoUni->Previo = NodoArbol->Ultimo;
            NodoArbol->Ultimo->Siguiente = NodoUni;
            NodoArbol->Ultimo = NodoUni;
        }

        NodoArbol->Actual = NodoUni;
        SeAgrego = 0;

        retReg = RegistroSiguiente(&myStr);
    } while (retReg == 0);

/*    NodoArbol->Actual=NodoArbol->Primero;
    while (NodoArbol->Actual != NULL){
 printf("pref %s bco %s emp %s gpo %s uni %s parent %s nivel %s\n",NodoArbol->Actual->eje_prefijo, NodoArbol->Actual->gpo_banco, NodoArbol->Actual->emp_num, NodoArbol->Actual->gpo_num, NodoArbol->Actual->unit_id, NodoArbol->Actual->unit_parent_id, NodoArbol->Actual->nivel_num);
    NodoArbol->Actual=NodoArbol->Actual->Siguiente;
}*/


    LiberaMemCab(&myStr);
 free(sQry);
    return;
}

/***************************/
int TraeSubVector(myStrArb, NodoArb,sPrefijo,sBanco,sEmp, sNoUni)
Arbol *myStrArb;
Arbol *NodoArb;
char sPrefijo[5];
char sBanco[3];
char sEmp[PARTAMANO];
char sNoUni[PARTAMANO];
{
    char sNivelTem[NIVEL];
    int InicioArbol = 0;
    int iBandera;

    iBandera = -1;
    RegUniPrimero(myStrArb);
    NodoArb->Primero = myStrArb->Primero;
    NodoArb->Ultimo = myStrArb->Primero;
    NodoArb->Actual = myStrArb->Primero;

    /* RECORRE TODA LA LISTA */
    do {
        /* SI SE ENCUENTRA LA UNIDAD PONER NODOARB->PRIMERO A ESE NODO */
        if ((strcmp(sNoUni, NodoArb->Actual->unit_id) == 0) &&
            (strcmp(sPrefijo, NodoArb->Actual->eje_prefijo) == 0) &&
            (strcmp(sBanco, NodoArb->Actual->gpo_banco) == 0) &&
            (strcmp(sEmp, NodoArb->Actual->emp_num) == 0) &&
            (InicioArbol == 0)) {
            NodoArb->Primero = NodoArb->Actual;
            NodoArb->Ultimo = NodoArb->Actual;
            sprintf(sNivelTem, "%s", NodoArb->Actual->nivel_num);
            InicioArbol = 1;
        }

        if (InicioArbol == 1) {
            if (!strcmp(sEmp, NodoArb->Actual->emp_num) == 0)  {
                NodoArb->Ultimo = NodoArb->Actual->Previo;
                break;
            }
        }

        NodoArb->Ultimo = NodoArb->Actual;
        NodoArb->Actual = NodoArb->Actual->Siguiente;
    } while (NodoArb->Actual != NULL);

    if (NodoArb->Primero != NULL)
        iBandera = 0;
    else
        iBandera = 1;

 /*   NodoArb->Actual=NodoArb->Primero;
    do{
 printf("SUBVECTOR2 pref %s bco %s emp %s gpo %s uni %s parent %s nivel %s\n",NodoArb->Actual->eje_prefijo, NodoArb->Actual->gpo_banco, NodoArb->Actual->emp_num, NodoArb->Actual->gpo_num, NodoArb->Actual->unit_id, NodoArb->Actual->unit_parent_id, NodoArb->Actual->nivel_num);
    NodoArb->Actual=NodoArb->Actual->Siguiente;
}while(NodoArb->Actual->Previo != NodoArb->Ultimo);*/

    return iBandera;
}

/***************************/
int RegUniSiguiente(NodoCabecera)
Arbol *NodoCabecera;
{
    int Bandera;
    Bandera = -1;

    if (NodoCabecera->Actual != NodoCabecera->Ultimo) {
        NodoCabecera->Actual = NodoCabecera->Actual->Siguiente;
        Bandera = 0;
    }
    else
        Bandera = 1;

    return Bandera;
}

/***************************/
int RegUniPrevio(NodoCabecera)
Arbol *NodoCabecera;
{
    int Bandera;
    Bandera = -1;

    if (NodoCabecera->Actual != NodoCabecera->Primero) {
        NodoCabecera->Actual = NodoCabecera->Actual->Previo;
        Bandera = 0;
    }
    else
        Bandera = 1;

    return Bandera;
}

/***************************/
int RegUniPrimero(NodoCabecera)
Arbol *NodoCabecera;
{
    int Bandera;
    Bandera = -1;

    if (NodoCabecera->Primero != NULL) {
        NodoCabecera->Actual = NodoCabecera->Primero;
        Bandera = 0;
    }
    else
        Bandera = 1;

    return Bandera;
}

/***************************/
int RegUniUltimo(NodoCabecera)
Arbol *NodoCabecera;
{
    int Bandera;
    Bandera = -1;

    if (NodoCabecera->Primero != NULL) {
        NodoCabecera->Actual = NodoCabecera->Ultimo;
        Bandera = 0;
    }
    else
        Bandera = 1;

    return Bandera;
}

/***************************/
int ObtenValorUni(NodoCabecera, icampo, sCadena)
Arbol *NodoCabecera;
int icampo;
char *sCadena;
{
    int Bandera;
    Bandera = -1;

    switch (icampo) {
        case 0:
            strcpy(sCadena, NodoCabecera->Actual->eje_prefijo);
            Bandera = 0;
            break;
        case 1:
            strcpy(sCadena, NodoCabecera->Actual->gpo_banco);
            Bandera = 0;
            break;
        case 2:
            strcpy(sCadena, NodoCabecera->Actual->emp_num);
            Bandera = 0;
            break;
        case 3:
            strcpy(sCadena, NodoCabecera->Actual->gpo_num);
            Bandera = 0;
            break;
        case 4:
            strcpy(sCadena, NodoCabecera->Actual->unit_id);
            Bandera = 0;
            break;
        case 5:
            strcpy(sCadena, NodoCabecera->Actual->unit_parent_id);
            Bandera = 0;
            break;
        case 6:
            strcpy(sCadena, NodoCabecera->Actual->nivel_num);
            Bandera = 0;
            break;
        default:
            Bandera = 1;
    }
    return Bandera;
}

/***************************/
int TraeUnidad(myStrArb, NodoArb, sPrefijo,sBanco,sEmp,sNoUni,NivIni,NivFin)
Arbol *myStrArb;
Arbol *NodoArb;
char *sPrefijo;
char *sBanco;
char *sEmp;
char *sNoUni;
int NivIni;
int NivFin;
{
    Arbol NodoArbTem;
    RISQL myStr;
    Unidad *NodoUni;
    char sNivIni[NIVEL];
    char sNivFin[NIVEL];
    char sQry[200];
    char sNoUniTem[MAXTAMUNI];
    int ret;
    int Bandera;
    Bandera = -1;
    if (NivIni > NivFin)
        return 1;

    NodoArb->Primero = NULL;
    NodoArb->Ultimo = NULL;
    NodoArb->Actual = NULL;

    strcpy(sQry, "select distinct substring(rtrim(ltrim(unit_id)),1,5) from MTCUNI01 where eje_prefijo = ");
    strcat(sQry, sPrefijo);
    strcat(sQry, " and gpo_banco = ");
    strcat(sQry, sBanco);
    strcat(sQry, " and emp_num = ");
    strcat(sQry, sEmp);
    strcat(sQry, " and nivel_num = 1 ");
    myStr.scadena_sql = sQry;
    myStr.icampos = 1;
    EjecutaSQL(&myStr);
    ret = RegistroPrimero(&myStr);
    ret = ObtenCampo(&myStr, 0, sNoUniTem);
    LiberaMemCab(&myStr);

    /* CARGA LA ESTRUCTURA NODOARBTEM CON APUNTADORES A UN SEGMENTO
    DEL VECTOR PRINCIPAL DE MTCUNI01 QUE CORRESPONDE A LA EMPRESA */
    ret = TraeSubVector(myStrArb, &NodoArbTem, sPrefijo,sBanco,sEmp, sNoUniTem);
    /* ME POSICIONO EN EL PRIMER REGISTRO */
    ret = RegUniPrimero(&NodoArbTem);
    /* SOLO SI SE REQUIEREN NIVELES ESPECIFICOS */
    if (NivIni != 0 && NivFin != 0) {
        do {
	    /* SI EL NODO CUBRE LOS CRITERIOS AGREGO AL VECTOR DE REGRESO */
            if ((atoi(NodoArbTem.Actual->nivel_num) >= NivIni) &&
                (atoi(NodoArbTem.Actual->nivel_num) <= NivFin)) {
                NodoUni = (Unidad *) malloc(sizeof(Unidad));
                if (NodoUni == NULL) {
                    printf ("\n MEMORIA INSUFICIENTE PARA CREAR NODO");
                    return -1;
                }

                /* LLENADO DE NODO */
                sprintf(NodoUni->eje_prefijo, "%s", NodoArbTem.Actual->eje_prefijo);
                sprintf(NodoUni->gpo_banco, "%s", NodoArbTem.Actual->gpo_banco);
                sprintf(NodoUni->emp_num, "%s", NodoArbTem.Actual->emp_num);
                sprintf(NodoUni->gpo_num, "%s", NodoArbTem.Actual->gpo_num);
                sprintf(NodoUni->unit_id, "%s", NodoArbTem.Actual->unit_id);
                sprintf(NodoUni->unit_parent_id, "%s", NodoArbTem.Actual->unit_parent_id);
                sprintf(NodoUni->nivel_num, "%s", NodoArbTem.Actual->nivel_num);

                /* EN CASO DE SER EL PRIMERO */
                    if (NodoArb->Primero == NULL){
                        NodoArb->Primero = NodoUni;
			NodoArb->Ultimo = NodoUni;
			NodoArb->Actual = NodoUni;
                      }
                    else {
			 NodoUni->Previo = NodoArb->Ultimo;
			 NodoArb->Ultimo->Siguiente = NodoUni;
			 NodoArb->Ultimo = NodoUni;
                     }
                    Bandera = 0;
                     }
                     else {
                       if (Bandera != 0)
                         Bandera = 1;
                     }
                /* ME MUEVO AL SIGUIENTE NODO */
                  ret = RegUniSiguiente(&NodoArbTem);
               } while (ret == 0);
         }
         else {
            /* TRAE UN SUBVECTOR */
            if (strcmp(sNoUni, "0") == 0) {
                ret = TraeSubVector(&NodoArbTem, NodoArb, sPrefijo,sBanco,sEmp, sNoUniTem);
                Bandera = 0;
            }
            else {
                ret = TraeSubVector(&NodoArbTem, NodoArb, sPrefijo,sBanco,sEmp, sNoUni);
                Bandera = 0;
            }
        }
    return Bandera;
}

/***************************/
void LiberaMemArb(myStrArb)
Arbol *myStrArb;
{
    /* LIBERA MEMORIA USADA POR UN ARBOL */
    if ((myStrArb->Primero->Previo == NULL)
        && (myStrArb->Ultimo->Siguiente == NULL)) {
        myStrArb->Actual = myStrArb->Ultimo;

        do {
            myStrArb->Actual = myStrArb->Ultimo->Previo;
            free(myStrArb->Ultimo);
            myStrArb->Ultimo = myStrArb->Actual;
        } while (myStrArb->Actual != myStrArb->Primero);

        free(myStrArb->Actual);
        myStrArb->Actual = NULL;
        myStrArb->Ultimo = NULL;
        myStrArb->Primero = NULL;
    }
    return;
}

