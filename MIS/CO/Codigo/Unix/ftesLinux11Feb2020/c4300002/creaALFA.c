/*******************************************************************************
*   Program : creaALFA.c
*   Porpuse : Genera el archivo de Altas, Bajas y Cambios para el
*             Sistema ALFA
*    Provider: EISSA Information Technologies Provider
*    Owner    : Banco Nacional de Mexico
*   Design  : ISC. Ivan Troy Santaella Martinez
*   Update  : Lic. Angel Pérez Quintanar
*******************************************************************************/

/*******************************************************************************
*        INCLUDE's
*******************************************************************************/
#include    "libsbf.h"

/*******************************************************************************
*        VARIABLES EXTERNAS
*******************************************************************************/

/* Buffer's generales */
extern char            sqlcmd[];
extern char            caderror[];

/* Conexion Sybase */
extern DBPROCESS    *dbproc;
extern LOGINREC        *login;

/* Variables de ambiente */
extern VAR_ENTORNO    vars_entorno[];

/* Mensajes de log */
extern char            *mensaje_estado[];

/*******************************************************************************
*        PROTOTIPOS DE FUNCIONES
*******************************************************************************/
#if defined(__cplusplus)
extern "C" {
#endif

#ifdef _PROTOTYPES
    void    inicializa();
    void    generaALFA();
    void    elimina();
    int        generaReg1();
    int        generaReg3();
    int        generaReg4();
    void    integra();
#else
    void    inicializa();
    void    generaALFA();
    void    elimina();
    int        generaReg1();
    int        generaReg3();
    int        generaReg4();
    void    integra();
#endif

#if defined(__cplusplus)
}
#endif

/*******************************************************************************
*        FUNCION PRINCIPAL
*******************************************************************************/


#if defined(__STDC__) || defined(__cplusplus)
int main(int argc, char *argv[])
#else
int main(argc, argv)
int argc;
char *argv[];
#endif
{
    (void) inicializa();
if (argc > 1)
    if (! strcmp(argv[1], "-vars")) {
        putvars_entorno();
    }
    generaALFA();
    exit(SUCCESS);
}

void inicializa()
{

    /* Inicializa la DB-Library */
    if (dbinit() == FAIL) {
        strcpy(caderror, "Error al inicializar la DB-Library.");
        Log(__FILE__, "inicializa", __LINE__, caderror);
        exit(FAILURE);
    }
    /* Instala los manejadores de error y mensaje de DB-Library */
    dberrhandle((EHANDLEFUNC) err_handler);
    dbmsghandle((MHANDLEFUNC) msg_handler);

    dbsetversion(DBVERSION_100);

    /* Especifica informacion del login */
    if (! (login = dblogin())) {
        strcpy(caderror, "Error al ejecutar dblogin.");
        Log(__FILE__, "inicializa", __LINE__, caderror);
        exit(FAILURE);
    }

    DBSETLUSER(login, getenv("GE_USER"));
    DBSETLPWD(login, getenv("GE_PASSWORD"));
    DBSETLHOST(login, getenv("GE_HOSTNAME"));
    DBSETLAPP(login, getenv("GE_APPNAME"));
    DBSETLCHARSET(login,"roman8");
    DBSETLENCRYPT(login, TRUE);

    /* Obtiene una estructura DBPROCESS para comunicacion con el servidor */
    if (! (dbproc = dbopen(login, getenv("GE_SERVER")))) {
        strcpy(caderror, "Error al ejecutar dbopen.");
        Log(__FILE__, "inicializa", __LINE__, caderror);
        exit(FAILURE);
    }

    /* Abre la base de datos */
    if (dbuse(dbproc, getenv("GE_DBASE")) == FAIL) {
        sprintf(caderror, "Error al accesar a la base de datos %s.",
                vars_entorno[GE_DBASE].valor);
        Log(__FILE__, "inicializa", __LINE__, caderror);
        exit(FAILURE);
    }

    /* Obtiene las variables de entorno */
    getvars_entorno();
    if (! testvars_entorno()) {
        strcpy(caderror, "No se han definido las variables de entorno.");
        Log(__FILE__, "inicializa", __LINE__, caderror);
        exit(FAILURE);
    }
}

void generaALFA()
{
    char archivo[1024];
    /* Elimina las tablas y archivos temporales */
    elimina();

    /* Genera los registros individuales */
    generaReg1();
    generaReg3();
    generaReg4();

    /* Integra el archivo SBF */
    puts("ALFA: Integrando el archivo ALFA.");
    integra();
}

void elimina()
{
    remove(vars_entorno[NOM_ARCH_R1].valor);
    remove(vars_entorno[NOM_ARCH_R3].valor);
    remove(vars_entorno[NOM_ARCH_R4].valor);
    remove(vars_entorno[NOM_ARCH_ALFA].valor);

    borra_tabla("TMP_ALFA_R3");
    borra_tabla("TMP_ALFA_TOTALES");
}

int generaReg1()
{
    int         i = 0;
    FILE        *pfreg1;
    ROW_TYPE_1  reg1;
    char        m_registro_tipo1[LEN_RECORD + 1];

    DBCHAR        tipo_registro[LEN_R1_TIPO_REGISTRO + 1];
    DBCHAR        id_sistema[LEN_R1_ID_SISTEMA + 1];
    DBCHAR        fecha_archivo[LEN_R1_FECHA_ARCHIVO + 1];
    DBCHAR        secuencia[LEN_R1_SECUENCIA + 1];
    DBCHAR        cuenta_empresa[LEN_R1_CUENTA_EMPRESA + 1];
    DBCHAR        filler[LEN_R1_FILLER + 1];

    RETCODE        result_code;

printf("### :%s\n NOM_ARCH_LOG :%s\n vars_ent.var:%s\n",vars_entorno[NOM_ARCH_R1].valor,getenv("NOM_ARCH_LOG"), vars_entorno[NOM_ARCH_LOG].valor);    
//printf("### :%s\n  vars_ent.var:%s\n",vars_entorno[NOM_ARCH_R1].valor,vars_entorno[NOM_ARCH_LOG].valor);    
if ((pfreg1 = fopen(vars_entorno[NOM_ARCH_R1].valor, "w")) == NULL) {
        sprintf(caderror, "Error al crear el archivo de disco %s.",
                vars_entorno[NOM_ARCH_R1].valor);
        Log(__FILE__, "generaReg1", __LINE__, caderror);
        exit(FAILURE);
    }

    *sqlcmd = NULL;
    strcpy(sqlcmd, " select ");
    strcat(sqlcmd, "    convert(char(1),'1') as tipo_registro, ");
    strcat(sqlcmd, "     convert(char(4),'C430') as id_sistema, ");
    strcat(sqlcmd, "     convert(char(8),'");
    strcat(sqlcmd, getenv("FECHA_ACTUAL"));
    strcat(sqlcmd, "') as fecha_archivo, ");
    strcat(sqlcmd, "     convert(char(1),'1') as secuencia, ");
    strcat(sqlcmd, "     convert(char(16), ");
    strcat(sqlcmd, "    convert(char(4),ltrim(rtrim(str(a.eje_prefijo)))) + ");
    strcat(sqlcmd, "    convert(char(2),ltrim(rtrim(str(a.gpo_banco)))) + ");
    strcat(sqlcmd, "     ltrim(rtrim(isnull(replicate(  '0', ");
    strcat(sqlcmd, "     (select pgs_long_emp from MTCPGS01 b where ");
    strcat(sqlcmd, "     a.eje_prefijo = b.pgs_rep_prefijo and ");
    strcat(sqlcmd, "    a.gpo_banco = b.pgs_rep_banco) - char_length(ltrim(rtrim(str(a.emp_num))))), '') + ");
    strcat(sqlcmd, "    ltrim(rtrim(str(a.emp_num))) ))  + ");
    strcat(sqlcmd, "     ltrim(rtrim(isnull(replicate(  '0', ");
    strcat(sqlcmd, "     (select pgs_long_eje from MTCPGS01 c where ");
    strcat(sqlcmd, "     a.eje_prefijo = c.pgs_rep_prefijo and ");
    strcat(sqlcmd, "    a.gpo_banco = c.pgs_rep_banco) - char_length(ltrim(rtrim(str(a.eje_num))))), '') + ");
    strcat(sqlcmd, "    ltrim(rtrim(str(a.eje_num))) ))  + ");
    strcat(sqlcmd, "    ltrim(rtrim(convert(char(1),d.eje_roll_over))) + ");
    strcat(sqlcmd, "    ltrim(rtrim(convert(char(1),d.eje_digit))) ) as cuenta_empresa, ");
    strcat(sqlcmd, "     convert(char(150),'') as filler ");
    strcat(sqlcmd, " from ");
    strcat(sqlcmd, "        MTCEJE01 a, ");
    strcat(sqlcmd, "        MTCTHS01 d, ");
    strcat(sqlcmd, "        MTCEMP01 e ");
    strcat(sqlcmd, " where ");
    strcat(sqlcmd, "        e.gpo_num = 267 and ");
    strcat(sqlcmd, "        a.emp_num = e.emp_num and ");
    strcat(sqlcmd, "        a.eje_prefijo = d.eje_prefijo and ");
    strcat(sqlcmd, "        a.gpo_banco = d.gpo_banco and ");
    strcat(sqlcmd, "        a.emp_num = d.emp_num and ");
    strcat(sqlcmd, "        a.eje_num = 0 ");

    dbcmd(dbproc, sqlcmd);

    if (dbsqlexec(dbproc) == FAIL) {
        sprintf(caderror, "Error al ejecutar la sentencia SQL: %s.", sqlcmd);
        Log(__FILE__, "generaReg1", __LINE__, caderror);
        exit(FAILURE);
    }

    while ((result_code = dbresults(dbproc)) != NO_MORE_RESULTS) {
        if (result_code == SUCCEED) {
            dbbind(dbproc, 1, NTBSTRINGBIND, (DBINT) 0, (BYTE DBFAR *) tipo_registro);
            dbbind(dbproc, 2, NTBSTRINGBIND, (DBINT) 0, (BYTE DBFAR *) id_sistema);
            dbbind(dbproc, 3, NTBSTRINGBIND, (DBINT) 0, (BYTE DBFAR *) fecha_archivo);
            dbbind(dbproc, 4, NTBSTRINGBIND, (DBINT) 0, (BYTE DBFAR *) secuencia);
            dbbind(dbproc, 5, NTBSTRINGBIND, (DBINT) 0, (BYTE DBFAR *) cuenta_empresa);
            dbbind(dbproc, 6, NTBSTRINGBIND, (DBINT) 0, (BYTE DBFAR *) filler);

            while (dbnextrow(dbproc) != NO_MORE_ROWS) 
	    {
                ++i;

                if ( i == 1)
                {
                    sprintf(reg1.m_tipo_registro, FOR_R1_TIPO_REGISTRO, tipo_registro);
                    sprintf(reg1.m_id_sistema, FOR_R1_ID_SISTEMA, id_sistema);
                    sprintf(reg1.m_fecha_archivo, FOR_R1_FECHA_ARCHIVO, fecha_archivo);
                    sprintf(reg1.m_secuencia, FOR_R1_SECUENCIA, secuencia);
                    sprintf(reg1.m_cuenta_empresa, FOR_R1_CUENTA_EMPRESA, cuenta_empresa);
                    sprintf(reg1.m_filler, FOR_R1_FILLER, filler);

                    (void *) memset((void *) m_registro_tipo1, (int) '\0', (size_t) (LEN_RECORD + 1));
                    strcpy(m_registro_tipo1, reg1.m_tipo_registro);
                    strcat(m_registro_tipo1, reg1.m_id_sistema);
                    strcat(m_registro_tipo1, reg1.m_fecha_archivo);
                    strcat(m_registro_tipo1, reg1.m_secuencia);
                    strcat(m_registro_tipo1, reg1.m_cuenta_empresa);
                    strcat(m_registro_tipo1, reg1.m_filler);
                    m_registro_tipo1[LEN_RECORD] = NULL;
                }

                if (strlen(m_registro_tipo1) != LEN_RECORD) {
                    sprintf(caderror, "Error en la longitud del registro %6d.", i);
                    Log(__FILE__, "generaReg1", __LINE__, caderror);
                    exit(FAILURE);
                }

                if (fprintf(pfreg1, FORMATO_REG, m_registro_tipo1) != (LEN_RECORD + 1)) {
                    sprintf(caderror, "Error al escribir el registro %6d.", i);
                    Log(__FILE__, "generaReg1", __LINE__, caderror);
                    exit(FAILURE);
                }
            }
        }
    }

    sprintf(caderror, "Registros generados:%6d.", i);
    Log(__FILE__, "generaReg1", __LINE__, caderror);

    if (fclose(pfreg1)) {
        sprintf(caderror, "%s", strerror(errno));
        Log(__FILE__, "generaReg1", __LINE__, caderror);
        exit(FAILURE);
    }
    return 0;
}

int generaReg3()
{
    int            i = 0;
    FILE        *pfreg3;
    ROW_TYPE_3    reg3;
    char        m_registro_tipo3[LEN_RECORD + 1];

    DBCHAR        tipo_registro[LEN_R3_TIPO_REGISTRO + 1];
    DBCHAR        numero_movimiento[LEN_R3_NUMERO_MOVIMIENTO + 1];
    DBCHAR        numero_nomina[LEN_R3_NUMERO_NOMINA + 1];
    DBCHAR        rfc[LEN_R3_RFC + 1];
    DBCHAR        nombre_empleado[LEN_R3_NOMBRE_EMPLEADO + 1];
    DBCHAR        numero_tarjeta[LEN_R3_NUMERO_TARJETA + 1];
    DBCHAR        tipo_movimiento[LEN_R3_TIPO_MOVIMIENTO + 1];
    DBCHAR        fecha_movimiento[LEN_R3_FECHA_MOVIMIENTO + 1];
    DBCHAR        numero_empleado[LEN_R3_NUMERO_EMPLEADO + 1];
    DBCHAR        gl_number_part_1[LEN_R3_GL_NUMBER_PART_1 + 1];
    DBCHAR        gl_number_part_2[LEN_R3_GL_NUMBER_PART_2 + 1];
    DBCHAR        filler[LEN_R3_FILLER + 1];

    RETCODE        result_code;

    if ((pfreg3 = fopen(vars_entorno[NOM_ARCH_R3].valor, "w")) == NULL) {
        sprintf(caderror, "Error al crear el archivo de disco %s.",
                vars_entorno[NOM_ARCH_R3].valor);
        Log(__FILE__, "generaReg3", __LINE__, caderror);
        exit(FAILURE);
    }

    *sqlcmd = NULL;
    if (! strcmp(vars_entorno[TIPO_ARCH].valor, "CARGA")) {
        strcpy(sqlcmd, " select distinct ");
        strcat(sqlcmd, "        convert(char(1),3) as t_reg, ");
        strcat(sqlcmd, "        convert(char(6),'0') as n_reg, ");
        strcat(sqlcmd, "        convert(char(10),ltrim(rtrim(a.eje_num_nom))) as nomina, ");
        strcat(sqlcmd, "        convert(char(15),ltrim(rtrim(a.eje_rfc))) as rfc, ");
        strcat(sqlcmd, "        convert(char(40),ltrim(rtrim(a.eje_nombre))) as nombre, ");
        strcat(sqlcmd, "        convert(char(16), ");
        strcat(sqlcmd, "        convert(char(4),ltrim(rtrim(str(a.eje_prefijo)))) + ");
        strcat(sqlcmd, "        convert(char(2),ltrim(rtrim(str(a.gpo_banco)))) + ");
        strcat(sqlcmd, "        ltrim(rtrim(isnull(replicate(  '0', ");
        strcat(sqlcmd, "        (select b.pgs_long_emp from MTCPGS01 b where ");
        strcat(sqlcmd, "        a.eje_prefijo = b.pgs_rep_prefijo and ");
        strcat(sqlcmd, "        a.gpo_banco = b.pgs_rep_banco) - ");
        strcat(sqlcmd, "        char_length(ltrim(rtrim(str(a.emp_num))))), '') + ");
        strcat(sqlcmd, "        ltrim(rtrim(str(a.emp_num))) ))  + ");
        strcat(sqlcmd, "        ltrim(rtrim(isnull(replicate(  '0', ");
        strcat(sqlcmd, "        (select c.pgs_long_eje from MTCPGS01 c where ");
        strcat(sqlcmd, "        a.eje_prefijo = c.pgs_rep_prefijo and ");
        strcat(sqlcmd, "        a.gpo_banco = c.pgs_rep_banco) - ");
        strcat(sqlcmd, "        char_length(ltrim(rtrim(str(a.eje_num))))), '') + ");
        strcat(sqlcmd, "        ltrim(rtrim(str(a.eje_num))) ))  + ");
        strcat(sqlcmd, "        ltrim(rtrim(convert(char(1),d.eje_roll_over))) + ");
        strcat(sqlcmd, "        ltrim(rtrim(convert(char(1),d.eje_digit))) ) as cuenta, ");
        strcat(sqlcmd, "        convert(char(1),'A') as t_mov, ");
        strcat(sqlcmd, "        convert(char(8),a.eje_fecha_alta) as fecha_mov, ");
        strcat(sqlcmd, "        convert(char(1),'') as numero_emp, ");
        strcat(sqlcmd, "        convert(char(1),'') as gl_number_part_1, ");
        strcat(sqlcmd, "        convert(char(1),'') as gl_number_part_2, ");
        strcat(sqlcmd, "        convert(char(1),'') as filler, ");
        strcat(sqlcmd, "         ths_situacion_cta ");
        strcat(sqlcmd, " into     ");
        strcat(sqlcmd, "         TMP_ALFA_R3 ");
        strcat(sqlcmd, " from ");
        strcat(sqlcmd, "        MTCEJE01 a, ");
        strcat(sqlcmd, "        MTCTHS01 d, ");
        strcat(sqlcmd, "        MTCEMP01 e ");
        strcat(sqlcmd, " where ");
        strcat(sqlcmd, "        e.gpo_num = 267 and ");
        strcat(sqlcmd, "        a.emp_num = e.emp_num and ");
        strcat(sqlcmd, "        a.eje_prefijo = d.eje_prefijo and ");
        strcat(sqlcmd, "        a.gpo_banco = d.gpo_banco and ");
        strcat(sqlcmd, "         a.emp_num = d.emp_num and ");
        strcat(sqlcmd, "         a.eje_num = d.eje_num and ");
        strcat(sqlcmd, "        a.eje_num != 0 and ");
        strcat(sqlcmd, "        ltrim(rtrim(a.eje_num_nom)) != '' and ");
        strcat(sqlcmd, "        ltrim(rtrim(a.eje_num_nom)) != NULL and ");
        strcat(sqlcmd, "        ltrim(rtrim(a.eje_num_nom)) != '0' ");
        strcat(sqlcmd, "        and d.ths_situacion_cta not in ('C', 'E') ");
        strcat(sqlcmd, " union  ");
        strcat(sqlcmd, " select distinct ");
        strcat(sqlcmd, "        convert(char(1),3) as t_reg, ");
        strcat(sqlcmd, "        convert(char(6),'0') as n_reg, ");
        strcat(sqlcmd, "        convert(char(10),ltrim(rtrim(a.eje_num_nom))) as nomina, ");
        strcat(sqlcmd, "        convert(char(15),ltrim(rtrim(a.eje_rfc))) as rfc, ");
        strcat(sqlcmd, "        convert(char(40),ltrim(rtrim(a.eje_nombre))) as nombre, ");
        strcat(sqlcmd, "        convert(char(16), ");
        strcat(sqlcmd, "        convert(char(4),ltrim(rtrim(str(a.eje_prefijo)))) + ");
        strcat(sqlcmd, "        convert(char(2),ltrim(rtrim(str(a.gpo_banco)))) + ");
        strcat(sqlcmd, "        ltrim(rtrim(isnull(replicate(  '0', ");
        strcat(sqlcmd, "        (select b.pgs_long_emp from MTCPGS01 b where ");
        strcat(sqlcmd, "        a.eje_prefijo = b.pgs_rep_prefijo and ");
        strcat(sqlcmd, "        a.gpo_banco = b.pgs_rep_banco) - ");
        strcat(sqlcmd, "        char_length(ltrim(rtrim(str(a.emp_num))))), '') + ");
        strcat(sqlcmd, "        ltrim(rtrim(str(a.emp_num))) ))  + ");
        strcat(sqlcmd, "        ltrim(rtrim(isnull(replicate(  '0', ");
        strcat(sqlcmd, "        (select c.pgs_long_eje from MTCPGS01 c where ");
        strcat(sqlcmd, "        a.eje_prefijo = c.pgs_rep_prefijo and ");
        strcat(sqlcmd, "        a.gpo_banco = c.pgs_rep_banco) - ");
        strcat(sqlcmd, "        char_length(ltrim(rtrim(str(a.eje_num))))), '') + ");
        strcat(sqlcmd, "        ltrim(rtrim(str(a.eje_num))) ))  + ");
        strcat(sqlcmd, "        ltrim(rtrim(convert(char(1),d.eje_roll_over))) + ");
        strcat(sqlcmd, "        ltrim(rtrim(convert(char(1),d.eje_digit))) ) as cuenta, ");
        strcat(sqlcmd, "        convert(char(1),'B') as t_mov, ");
        strcat(sqlcmd, "        convert(char(8),a.eje_fecha_alta) as fecha_mov, ");
        strcat(sqlcmd, "        convert(char(1),'') as numero_emp, ");
        strcat(sqlcmd, "        convert(char(1),'') as gl_number_part_1, ");
        strcat(sqlcmd, "        convert(char(1),'') as gl_number_part_2, ");
        strcat(sqlcmd, "        convert(char(1),'') as filler, ");
        strcat(sqlcmd, "         ths_situacion_cta ");
        strcat(sqlcmd, " from ");
        strcat(sqlcmd, "        MTCEJE01 a, ");
        strcat(sqlcmd, "        MTCTHS01 d, ");
        strcat(sqlcmd, "        MTCEMP01 e ");
        strcat(sqlcmd, " where ");
        strcat(sqlcmd, "        e.gpo_num = 267 and ");
        strcat(sqlcmd, "        a.emp_num = e.emp_num and ");
        strcat(sqlcmd, "        a.eje_prefijo = d.eje_prefijo and ");
        strcat(sqlcmd, "        a.gpo_banco = d.gpo_banco and ");
        strcat(sqlcmd, "         a.emp_num = d.emp_num and ");
        strcat(sqlcmd, "         a.eje_num = d.eje_num and ");
        strcat(sqlcmd, "        a.eje_num != 0 and ");
        strcat(sqlcmd, "        ltrim(rtrim(a.eje_num_nom)) != '' and ");
        strcat(sqlcmd, "        ltrim(rtrim(a.eje_num_nom)) != NULL and ");
        strcat(sqlcmd, "        ltrim(rtrim(a.eje_num_nom)) != '0'  ");
        strcat(sqlcmd, "         and d.ths_situacion_cta in ('C', 'E') ");
        strcat(sqlcmd, " order by ");
        strcat(sqlcmd, "         cuenta ");

        strcat(sqlcmd, " insert into TMP_ALFA_R3 ");
        strcat(sqlcmd, " select distinct ");
        strcat(sqlcmd, "  convert(char(1),3) as t_reg, ");
        strcat(sqlcmd, "  convert(char(6),'0') as n_reg, ");
        strcat(sqlcmd, "  convert(char(10),ltrim(rtrim(a.eje_num_nom))) as nomina, ");
        strcat(sqlcmd, "  convert(char(15),ltrim(rtrim(a.eje_rfc))) as rfc, ");
        strcat(sqlcmd, "  convert(char(40),ltrim(rtrim(a.eje_nombre))) as nombre, ");
        strcat(sqlcmd, "  convert(char(16), ");
        strcat(sqlcmd, "  convert(char(4),ltrim(rtrim(str(a.eje_prefijo)))) + ");
        strcat(sqlcmd, "  convert(char(2),ltrim(rtrim(str(a.gpo_banco)))) + ");
        strcat(sqlcmd, "  ltrim(rtrim(isnull(replicate('0', ");
        strcat(sqlcmd, "  (select b.pgs_long_emp from MTCPGS01 b where ");
        strcat(sqlcmd, "  a.eje_prefijo = b.pgs_rep_prefijo and ");
        strcat(sqlcmd, "  a.gpo_banco = b.pgs_rep_banco) - ");
        strcat(sqlcmd, "  char_length(ltrim(rtrim(str(a.emp_num))))), '') + ");
        strcat(sqlcmd, "  ltrim(rtrim(str(a.emp_num))))) + ");
        strcat(sqlcmd, "  ltrim(rtrim(isnull(replicate('0', ");
        strcat(sqlcmd, "  (select c.pgs_long_eje from MTCPGS01 c where ");
        strcat(sqlcmd, "  a.eje_prefijo = c.pgs_rep_prefijo and ");
        strcat(sqlcmd, "  a.gpo_banco = c.pgs_rep_banco) - ");
        strcat(sqlcmd, "  char_length(ltrim(rtrim(str(a.eje_num))))), '') + ");
        strcat(sqlcmd, "  ltrim(rtrim(str(a.eje_num))))) + ");
        strcat(sqlcmd, "  ltrim(rtrim(convert(char(1),d.eje_roll_over))) + ");
        strcat(sqlcmd, "  ltrim(rtrim(convert(char(1),d.eje_digit)))) as cuenta, ");
        strcat(sqlcmd, "  convert(char(1),'B') as t_mov, ");
        strcat(sqlcmd, "  convert(char(8),d.pla_situacion_amd) as fecha_mov, ");
        strcat(sqlcmd, "  convert(char(1),'') as numero_emp, ");
        strcat(sqlcmd, "  convert(char(1),'') as gl_number_part_1, ");
        strcat(sqlcmd, "  convert(char(1),'') as gl_number_part_2, ");
        strcat(sqlcmd, "  convert(char(1),'') as filler, ");
        strcat(sqlcmd, "  'x' as situacion_cta ");
        strcat(sqlcmd, " from ");
        strcat(sqlcmd, "  MTCEJE01 a, ");
        strcat(sqlcmd, "  MTCPLA01 d, ");
        strcat(sqlcmd, "  MTCEMP01 e ");
        strcat(sqlcmd, " where ");
        strcat(sqlcmd, "  e.gpo_num = 267 and ");
        strcat(sqlcmd, "  a.emp_num = e.emp_num and ");
        strcat(sqlcmd, "  a.eje_prefijo = d.eje_prefijo and ");
        strcat(sqlcmd, "  a.gpo_banco = d.gpo_banco and ");
        strcat(sqlcmd, "  a.emp_num = d.emp_num and ");
        strcat(sqlcmd, "  a.eje_num = d.eje_num and ");
        strcat(sqlcmd, "  a.eje_num != 0 and ");
        strcat(sqlcmd, "  ltrim(rtrim(a.eje_num_nom)) != '' and ");
        strcat(sqlcmd, "  ltrim(rtrim(a.eje_num_nom)) != NULL and ");
        strcat(sqlcmd, "  ltrim(rtrim(a.eje_num_nom)) != '0'  ");
        strcat(sqlcmd, "  and d.pla_situacion_plastico in ('L', 'U') ");
        strcat(sqlcmd, " order by ");
        strcat(sqlcmd, "  cuenta ");
    }
    else {
        *sqlcmd = NULL;
        strcpy(sqlcmd, " select distinct ");
        strcat(sqlcmd, "        convert(char(1),3) as t_reg, ");
        strcat(sqlcmd, "        convert(char(6),'0') as n_reg, ");
        strcat(sqlcmd, "        convert(char(10),ltrim(rtrim(a.eje_num_nom))) as nomina, ");
        strcat(sqlcmd, "        convert(char(15),ltrim(rtrim(a.eje_rfc))) as rfc, ");
        strcat(sqlcmd, "        convert(char(40),ltrim(rtrim(a.eje_nombre))) as nombre, ");
        strcat(sqlcmd, "        convert(char(16), ");
        strcat(sqlcmd, "        convert(char(4),ltrim(rtrim(str(a.eje_prefijo)))) + ");
        strcat(sqlcmd, "        convert(char(2),ltrim(rtrim(str(a.gpo_banco)))) + ");
        strcat(sqlcmd, "        ltrim(rtrim(isnull(replicate(  '0', ");
        strcat(sqlcmd, "        (select b.pgs_long_emp from MTCPGS01 b where ");
        strcat(sqlcmd, "        a.eje_prefijo = b.pgs_rep_prefijo and ");
        strcat(sqlcmd, "        a.gpo_banco = b.pgs_rep_banco) - ");
        strcat(sqlcmd, "        char_length(ltrim(rtrim(str(a.emp_num))))), '') + ");
        strcat(sqlcmd, "        ltrim(rtrim(str(a.emp_num))) ))  + ");
        strcat(sqlcmd, "        ltrim(rtrim(isnull(replicate(  '0', ");
        strcat(sqlcmd, "        (select c.pgs_long_eje from MTCPGS01 c where ");
        strcat(sqlcmd, "        a.eje_prefijo = c.pgs_rep_prefijo and ");
        strcat(sqlcmd, "        a.gpo_banco = c.pgs_rep_banco) - ");
        strcat(sqlcmd, "        char_length(ltrim(rtrim(str(a.eje_num))))), '') + ");
        strcat(sqlcmd, "        ltrim(rtrim(str(a.eje_num))) ))  + ");
        strcat(sqlcmd, "        ltrim(rtrim(convert(char(1),d.eje_roll_over))) + ");
        strcat(sqlcmd, "        ltrim(rtrim(convert(char(1),d.eje_digit))) ) as cuenta, ");
        strcat(sqlcmd, "        convert(char(1),'A') as t_mov, ");
        strcat(sqlcmd, "        convert(char(8),a.eje_fecha_alta) as fecha_mov, ");
        strcat(sqlcmd, "        convert(char(1),'') as numero_emp, ");
        strcat(sqlcmd, "        convert(char(1),'') as gl_number_part_1, ");
        strcat(sqlcmd, "        convert(char(1),'') as gl_number_part_2, ");
        strcat(sqlcmd, "        convert(char(1),'') as filler, ");
        strcat(sqlcmd, "         ths_situacion_cta ");
        strcat(sqlcmd, " into     ");
        strcat(sqlcmd, "         TMP_ALFA_R3 ");
        strcat(sqlcmd, " from ");
        strcat(sqlcmd, "        MTCEJE01 a, ");
        strcat(sqlcmd, "        MTCTHS01 d, ");
        strcat(sqlcmd, "        MTCEMP01 e ");
        strcat(sqlcmd, " where ");
        strcat(sqlcmd, "        e.gpo_num = 267 and ");
        strcat(sqlcmd, "        a.emp_num = e.emp_num and ");
        strcat(sqlcmd, "        a.eje_prefijo = d.eje_prefijo and ");
        strcat(sqlcmd, "        a.gpo_banco = d.gpo_banco and ");
        strcat(sqlcmd, "         a.emp_num = d.emp_num and ");
        strcat(sqlcmd, "         a.eje_num = d.eje_num and ");
        strcat(sqlcmd, "        a.eje_num != 0 and ");
        strcat(sqlcmd, "        ltrim(rtrim(a.eje_num_nom)) != '' and ");
        strcat(sqlcmd, "        ltrim(rtrim(a.eje_num_nom)) != NULL and ");
        strcat(sqlcmd, "        ltrim(rtrim(a.eje_num_nom)) != '0' ");
        strcat(sqlcmd, "        and d.ths_situacion_cta not in ('C', 'E') ");
        strcat(sqlcmd, "        and a.eje_fecha_alta between ");
        strcat(sqlcmd, vars_entorno[FECHA_INI].valor);
        strcat(sqlcmd, "         and ");
        strcat(sqlcmd, vars_entorno[FECHA_FIN].valor);
        strcat(sqlcmd, " union  ");
        strcat(sqlcmd, " select distinct ");
        strcat(sqlcmd, "        convert(char(1),3) as t_reg, ");
        strcat(sqlcmd, "        convert(char(6),'0') as n_reg, ");
        strcat(sqlcmd, "        convert(char(10),ltrim(rtrim(a.eje_num_nom))) as nomina, ");
        strcat(sqlcmd, "        convert(char(15),ltrim(rtrim(a.eje_rfc))) as rfc, ");
        strcat(sqlcmd, "        convert(char(40),ltrim(rtrim(a.eje_nombre))) as nombre, ");
        strcat(sqlcmd, "        convert(char(16), ");
        strcat(sqlcmd, "        convert(char(4),ltrim(rtrim(str(a.eje_prefijo)))) + ");
        strcat(sqlcmd, "        convert(char(2),ltrim(rtrim(str(a.gpo_banco)))) + ");
        strcat(sqlcmd, "        ltrim(rtrim(isnull(replicate(  '0', ");
        strcat(sqlcmd, "        (select b.pgs_long_emp from MTCPGS01 b where ");
        strcat(sqlcmd, "        a.eje_prefijo = b.pgs_rep_prefijo and ");
        strcat(sqlcmd, "        a.gpo_banco = b.pgs_rep_banco) - ");
        strcat(sqlcmd, "        char_length(ltrim(rtrim(str(a.emp_num))))), '') + ");
        strcat(sqlcmd, "        ltrim(rtrim(str(a.emp_num))) ))  + ");
        strcat(sqlcmd, "        ltrim(rtrim(isnull(replicate(  '0', ");
        strcat(sqlcmd, "        (select c.pgs_long_eje from MTCPGS01 c where ");
        strcat(sqlcmd, "        a.eje_prefijo = c.pgs_rep_prefijo and ");
        strcat(sqlcmd, "        a.gpo_banco = c.pgs_rep_banco) - ");
        strcat(sqlcmd, "        char_length(ltrim(rtrim(str(a.eje_num))))), '') + ");
        strcat(sqlcmd, "        ltrim(rtrim(str(a.eje_num))) ))  + ");
        strcat(sqlcmd, "        ltrim(rtrim(convert(char(1),d.eje_roll_over))) + ");
        strcat(sqlcmd, "        ltrim(rtrim(convert(char(1),d.eje_digit))) ) as cuenta, ");
        strcat(sqlcmd, "        convert(char(1),'B') as t_mov, ");
        strcat(sqlcmd, "        convert(char(8),a.eje_fecha_alta) as fecha_mov, ");
        strcat(sqlcmd, "        convert(char(1),'') as numero_emp, ");
        strcat(sqlcmd, "        convert(char(1),'') as gl_number_part_1, ");
        strcat(sqlcmd, "        convert(char(1),'') as gl_number_part_2, ");
        strcat(sqlcmd, "        convert(char(1),'') as filler, ");
        strcat(sqlcmd, "         ths_situacion_cta ");
        strcat(sqlcmd, " from ");
        strcat(sqlcmd, "        MTCEJE01 a, ");
        strcat(sqlcmd, "        MTCTHS01 d, ");
        strcat(sqlcmd, "        MTCEMP01 e ");
        strcat(sqlcmd, " where ");
        strcat(sqlcmd, "        e.gpo_num = 267 and ");
        strcat(sqlcmd, "        a.emp_num = e.emp_num and ");
        strcat(sqlcmd, "        a.eje_prefijo = d.eje_prefijo and ");
        strcat(sqlcmd, "        a.gpo_banco = d.gpo_banco and ");
        strcat(sqlcmd, "         a.emp_num = d.emp_num and ");
        strcat(sqlcmd, "         a.eje_num = d.eje_num and ");
        strcat(sqlcmd, "        a.eje_num != 0 and ");
        strcat(sqlcmd, "        ltrim(rtrim(a.eje_num_nom)) != '' and ");
        strcat(sqlcmd, "        ltrim(rtrim(a.eje_num_nom)) != NULL and ");
        strcat(sqlcmd, "        ltrim(rtrim(a.eje_num_nom)) != '0'  ");
        strcat(sqlcmd, "         and d.ths_situacion_cta in ('C', 'E') ");
        strcat(sqlcmd, " order by ");
        strcat(sqlcmd, "         cuenta ");

        strcat(sqlcmd, " insert into TMP_ALFA_R3 ");
        strcat(sqlcmd, " select distinct ");
        strcat(sqlcmd, "        convert(char(1),3) as t_reg, ");
        strcat(sqlcmd, "        convert(char(6),'0') as n_reg, ");
        strcat(sqlcmd, "        convert(char(10),ltrim(rtrim(a.eje_num_nom))) as nomina, ");
        strcat(sqlcmd, "        convert(char(15),ltrim(rtrim(a.eje_rfc))) as rfc, ");
        strcat(sqlcmd, "        convert(char(40),ltrim(rtrim(a.eje_nombre))) as nombre, ");
        strcat(sqlcmd, "        convert(char(16), ");
        strcat(sqlcmd, "        convert(char(4),ltrim(rtrim(str(a.eje_prefijo)))) + ");
        strcat(sqlcmd, "        convert(char(2),ltrim(rtrim(str(a.gpo_banco)))) + ");
        strcat(sqlcmd, "        ltrim(rtrim(isnull(replicate(  '0', ");
        strcat(sqlcmd, "        (select b.pgs_long_emp from MTCPGS01 b where ");
        strcat(sqlcmd, "        a.eje_prefijo = b.pgs_rep_prefijo and ");
        strcat(sqlcmd, "        a.gpo_banco = b.pgs_rep_banco) - ");
        strcat(sqlcmd, "        char_length(ltrim(rtrim(str(a.emp_num))))), '') + ");
        strcat(sqlcmd, "        ltrim(rtrim(str(a.emp_num))) ))  + ");
        strcat(sqlcmd, "        ltrim(rtrim(isnull(replicate(  '0', ");
        strcat(sqlcmd, "        (select c.pgs_long_eje from MTCPGS01 c where ");
        strcat(sqlcmd, "        a.eje_prefijo = c.pgs_rep_prefijo and ");
        strcat(sqlcmd, "        a.gpo_banco = c.pgs_rep_banco) - ");
        strcat(sqlcmd, "        char_length(ltrim(rtrim(str(a.eje_num))))), '') + ");
        strcat(sqlcmd, "        ltrim(rtrim(str(a.eje_num))) ))  + ");
        strcat(sqlcmd, "        ltrim(rtrim(convert(char(1),d.eje_roll_over))) + ");
        strcat(sqlcmd, "        ltrim(rtrim(convert(char(1),d.eje_digit))) ) as cuenta, ");
        strcat(sqlcmd, "        convert(char(1),'C') as t_mov, ");
        strcat(sqlcmd, "        convert(char(8),a.eje_fecha_cam) as fecha_mov, ");
        strcat(sqlcmd, "        convert(char(1),'') as numero_emp, ");
        strcat(sqlcmd, "        convert(char(1),'') as gl_number_part_1, ");
        strcat(sqlcmd, "        convert(char(1),'') as gl_number_part_2, ");
        strcat(sqlcmd, "        convert(char(1),'') as filler, ");
        strcat(sqlcmd, "         ths_situacion_cta ");
        strcat(sqlcmd, " from ");
        strcat(sqlcmd, "        MTCEJE01 a, ");
        strcat(sqlcmd, "        MTCTHS01 d, ");
        strcat(sqlcmd, "        MTCEMP01 e ");
        strcat(sqlcmd, " where ");
        strcat(sqlcmd, "        e.gpo_num = 267 and ");
        strcat(sqlcmd, "        a.emp_num = e.emp_num and ");
        strcat(sqlcmd, "        a.eje_prefijo = d.eje_prefijo and ");
        strcat(sqlcmd, "        a.gpo_banco = d.gpo_banco and ");
        strcat(sqlcmd, "        a.emp_num = d.emp_num and ");
        strcat(sqlcmd, "        a.eje_num = d.eje_num and ");
        strcat(sqlcmd, "        a.eje_num != 0 and ");
        strcat(sqlcmd, "        ltrim(rtrim(a.eje_num_nom)) != '' and ");
        strcat(sqlcmd, "        ltrim(rtrim(a.eje_num_nom)) != NULL and ");
        strcat(sqlcmd, "        ltrim(rtrim(a.eje_num_nom)) != '0' ");
        strcat(sqlcmd, "        and d.ths_situacion_cta not in ('C', 'E') ");
        strcat(sqlcmd, "        and a.eje_fecha_cam between ");
        strcat(sqlcmd, vars_entorno[FECHA_INI].valor);
        strcat(sqlcmd, "         and ");
        strcat(sqlcmd, vars_entorno[FECHA_FIN].valor);

        strcat(sqlcmd, " insert into TMP_ALFA_R3 ");
        strcat(sqlcmd, " select distinct ");
        strcat(sqlcmd, "  convert(char(1),3) as t_reg, ");
        strcat(sqlcmd, "  convert(char(6),'0') as n_reg, ");
        strcat(sqlcmd, "  convert(char(10),ltrim(rtrim(a.eje_num_nom))) as nomina, ");
        strcat(sqlcmd, "  convert(char(15),ltrim(rtrim(a.eje_rfc))) as rfc, ");
        strcat(sqlcmd, "  convert(char(40),ltrim(rtrim(a.eje_nombre))) as nombre, ");
        strcat(sqlcmd, "  convert(char(16), ");
        strcat(sqlcmd, "  convert(char(4),ltrim(rtrim(str(a.eje_prefijo)))) + ");
        strcat(sqlcmd, "  convert(char(2),ltrim(rtrim(str(a.gpo_banco)))) + ");
        strcat(sqlcmd, "  ltrim(rtrim(isnull(replicate('0', ");
        strcat(sqlcmd, "  (select b.pgs_long_emp from MTCPGS01 b where ");
        strcat(sqlcmd, "  a.eje_prefijo = b.pgs_rep_prefijo and ");
        strcat(sqlcmd, "  a.gpo_banco = b.pgs_rep_banco) - ");
        strcat(sqlcmd, "  char_length(ltrim(rtrim(str(a.emp_num))))), '') + ");
        strcat(sqlcmd, "  ltrim(rtrim(str(a.emp_num))))) + ");
        strcat(sqlcmd, "  ltrim(rtrim(isnull(replicate('0', ");
        strcat(sqlcmd, "  (select c.pgs_long_eje from MTCPGS01 c where ");
        strcat(sqlcmd, "  a.eje_prefijo = c.pgs_rep_prefijo and ");
        strcat(sqlcmd, "  a.gpo_banco = c.pgs_rep_banco) - ");
        strcat(sqlcmd, "  char_length(ltrim(rtrim(str(a.eje_num))))), '') + ");
        strcat(sqlcmd, "  ltrim(rtrim(str(a.eje_num))))) + ");
        strcat(sqlcmd, "  ltrim(rtrim(convert(char(1),d.eje_roll_over))) + ");
        strcat(sqlcmd, "  ltrim(rtrim(convert(char(1),d.eje_digit)))) as cuenta, ");
        strcat(sqlcmd, "  convert(char(1),'B') as t_mov, ");
        strcat(sqlcmd, "  convert(char(8),d.pla_situacion_amd) as fecha_mov, ");
        strcat(sqlcmd, "  convert(char(1),'') as numero_emp, ");
        strcat(sqlcmd, "  convert(char(1),'') as gl_number_part_1, ");
        strcat(sqlcmd, "  convert(char(1),'') as gl_number_part_2, ");
        strcat(sqlcmd, "  convert(char(1),'') as filler, ");
        strcat(sqlcmd, "  'x' as situacion_cta ");
        strcat(sqlcmd, " from ");
        strcat(sqlcmd, "  MTCEJE01 a, ");
        strcat(sqlcmd, "  MTCPLA01 d, ");
        strcat(sqlcmd, "  MTCEMP01 e ");
        strcat(sqlcmd, " where ");
        strcat(sqlcmd, "  e.gpo_num = 267 and ");
        strcat(sqlcmd, "  a.emp_num = e.emp_num and ");
        strcat(sqlcmd, "  a.eje_prefijo = d.eje_prefijo and ");
        strcat(sqlcmd, "  a.gpo_banco = d.gpo_banco and ");
        strcat(sqlcmd, "  a.emp_num = d.emp_num and ");
        strcat(sqlcmd, "  a.eje_num = d.eje_num and ");
        strcat(sqlcmd, "  a.eje_num != 0 and ");
        strcat(sqlcmd, "  ltrim(rtrim(a.eje_num_nom)) != '' and ");
        strcat(sqlcmd, "  ltrim(rtrim(a.eje_num_nom)) != NULL and ");
        strcat(sqlcmd, "  ltrim(rtrim(a.eje_num_nom)) != '0'  ");
        strcat(sqlcmd, "  and d.pla_situacion_plastico in ('L', 'U') ");
        strcat(sqlcmd, "  and d.pla_situacion_amd between ");
        strcat(sqlcmd, vars_entorno[FECHA_INI].valor);
        strcat(sqlcmd, " and ");
        strcat(sqlcmd, vars_entorno[FECHA_FIN].valor);
        strcat(sqlcmd, " order by ");
        strcat(sqlcmd, "  cuenta ");

        strcat(sqlcmd, " insert into TMP_ALFA_R3 ");
        strcat(sqlcmd, " select distinct ");
        strcat(sqlcmd, "  convert(char(1),3) as t_reg, ");
        strcat(sqlcmd, "  convert(char(6),'0') as n_reg, ");
        strcat(sqlcmd, "  convert(char(10),ltrim(rtrim(a.eje_num_nom))) as nomina, ");
        strcat(sqlcmd, "  convert(char(15),ltrim(rtrim(a.eje_rfc))) as rfc, ");
        strcat(sqlcmd, "  convert(char(40),ltrim(rtrim(a.eje_nombre))) as nombre, ");
        strcat(sqlcmd, "  convert(char(16), ");
        strcat(sqlcmd, "  convert(char(4),ltrim(rtrim(str(a.eje_prefijo)))) + ");
        strcat(sqlcmd, "  convert(char(2),ltrim(rtrim(str(a.gpo_banco)))) + ");
        strcat(sqlcmd, "  ltrim(rtrim(isnull(replicate('0', ");
        strcat(sqlcmd, "  (select b.pgs_long_emp from MTCPGS01 b where ");
        strcat(sqlcmd, "  a.eje_prefijo = b.pgs_rep_prefijo and ");
        strcat(sqlcmd, "  a.gpo_banco = b.pgs_rep_banco) - ");
        strcat(sqlcmd, "  char_length(ltrim(rtrim(str(a.emp_num))))), '') + ");
        strcat(sqlcmd, "  ltrim(rtrim(str(a.emp_num))))) + ");
        strcat(sqlcmd, "  ltrim(rtrim(isnull(replicate('0', ");
        strcat(sqlcmd, "  (select c.pgs_long_eje from MTCPGS01 c where ");
        strcat(sqlcmd, "  a.eje_prefijo = c.pgs_rep_prefijo and ");
        strcat(sqlcmd, "  a.gpo_banco = c.pgs_rep_banco) - ");
        strcat(sqlcmd, "  char_length(ltrim(rtrim(str(a.eje_num))))), '') + ");
        strcat(sqlcmd, "  ltrim(rtrim(str(a.eje_num))))) + ");
        strcat(sqlcmd, "  ltrim(rtrim(convert(char(1),d.eje_roll_over))) + ");
        strcat(sqlcmd, "  ltrim(rtrim(convert(char(1),d.eje_digit)))) as cuenta, ");
        strcat(sqlcmd, "  convert(char(1),'A') as t_mov, ");
        strcat(sqlcmd, "  convert(char(8),d.pla_situacion_amd) as fecha_mov, ");
        strcat(sqlcmd, "  convert(char(1),'') as numero_emp, ");
        strcat(sqlcmd, "  convert(char(1),'') as gl_number_part_1, ");
        strcat(sqlcmd, "  convert(char(1),'') as gl_number_part_2, ");
        strcat(sqlcmd, "  convert(char(1),'') as filler, ");
        strcat(sqlcmd, "  'x' as situacion_cta ");
        strcat(sqlcmd, " from ");
        strcat(sqlcmd, "  MTCEJE01 a, ");
        strcat(sqlcmd, "  MTCPLA01 d, ");
        strcat(sqlcmd, "  MTCEMP01 e ");
        strcat(sqlcmd, " where ");
        strcat(sqlcmd, "  e.gpo_num = 267 and ");
        strcat(sqlcmd, "  a.emp_num = e.emp_num and ");
        strcat(sqlcmd, "  a.eje_prefijo = d.eje_prefijo and ");
        strcat(sqlcmd, "  a.gpo_banco = d.gpo_banco and ");
        strcat(sqlcmd, "  a.emp_num = d.emp_num and ");
        strcat(sqlcmd, "  a.eje_num = d.eje_num and ");
        strcat(sqlcmd, "  a.eje_num != 0 and ");
        strcat(sqlcmd, "  ltrim(rtrim(a.eje_num_nom)) != '' and ");
        strcat(sqlcmd, "  ltrim(rtrim(a.eje_num_nom)) != NULL and ");
        strcat(sqlcmd, "  ltrim(rtrim(a.eje_num_nom)) != '0'  ");
        strcat(sqlcmd, "  and d.pla_grabacion_causa = 'E'  ");
        strcat(sqlcmd, "  and d.pla_situacion_amd between ");
        strcat(sqlcmd, vars_entorno[FECHA_INI].valor);
        strcat(sqlcmd, " and ");
        strcat(sqlcmd, vars_entorno[FECHA_FIN].valor);
        strcat(sqlcmd, " order by ");
        strcat(sqlcmd, "  cuenta ");
    }
    dbcmd(dbproc, sqlcmd);

    if (dbsqlexec(dbproc) == FAIL) {
        sprintf(caderror, "Error al ejecutar la sentencia SQL: %s.", sqlcmd);
        Log(__FILE__, "generaReg3", __LINE__, caderror);
        exit(FAILURE);
    }

    /* Procesa los comando hasta que no haya mas. */
    while ((result_code = dbresults(dbproc)) != NO_MORE_RESULTS);

    *sqlcmd = NULL;
    strcpy(sqlcmd, " select distinct ");
    strcat(sqlcmd, "         convert(char(1),t_reg) as t_reg, ");
    strcat(sqlcmd, "         convert(char(6),n_reg) as n_reg, ");
    strcat(sqlcmd, "         convert(char(10),nomina) as nomina, ");
    strcat(sqlcmd, "         convert(char(15),rfc) as rfc, ");
    strcat(sqlcmd, "         convert(char(40),nombre) as nombre, ");
    strcat(sqlcmd, "         convert(char(16),cuenta) as cuenta, ");
    strcat(sqlcmd, "         convert(char(1),t_mov) as t_mov, ");
    strcat(sqlcmd, "         convert(char(8),fecha_mov) as fecha_mov, ");
    strcat(sqlcmd, "         convert(char(1),numero_emp) as numero_emp, ");
    strcat(sqlcmd, "         convert(char(1),gl_number_part_1) as gl_number_part_1, ");
    strcat(sqlcmd, "         convert(char(1),gl_number_part_2) as gl_number_part_2, ");
    strcat(sqlcmd, "         convert(char(1),filler) as filler ");
    strcat(sqlcmd, " from ");
    strcat(sqlcmd, "         TMP_ALFA_R3 ");
    dbcmd(dbproc, sqlcmd);

    /* Envia los comandos al servidor y comienza la ejecucion. */
    if (dbsqlexec(dbproc) == FAIL) {
        sprintf(caderror, "Error al ejecutar la sentencia SQL: %s.", sqlcmd);
        Log(__FILE__, "generaReg3", __LINE__, caderror);
        exit(FAILURE);
    }

    /* Procesa los comando hasta que no haya mas. */
    while ((result_code = dbresults(dbproc)) != NO_MORE_RESULTS) {

        /* Si se ejecuto satisfactoriamente */
        if (result_code == SUCCEED) {

            /* Vincula las variables del programa. */
            dbbind(dbproc, 1, NTBSTRINGBIND, (DBINT) 0, (BYTE DBFAR *) tipo_registro);
            dbbind(dbproc, 2, NTBSTRINGBIND, (DBINT) 0, (BYTE DBFAR *) numero_movimiento);
            dbbind(dbproc, 3, NTBSTRINGBIND, (DBINT) 0, (BYTE DBFAR *) numero_nomina);
            dbbind(dbproc, 4, NTBSTRINGBIND, (DBINT) 0, (BYTE DBFAR *) rfc);
            dbbind(dbproc, 5, NTBSTRINGBIND, (DBINT) 0, (BYTE DBFAR *) nombre_empleado);
            dbbind(dbproc, 6, NTBSTRINGBIND, (DBINT) 0, (BYTE DBFAR *) numero_tarjeta);
            dbbind(dbproc, 7, NTBSTRINGBIND, (DBINT) 0, (BYTE DBFAR *) tipo_movimiento);
            dbbind(dbproc, 8, NTBSTRINGBIND, (DBINT) 0, (BYTE DBFAR *) fecha_movimiento);
            dbbind(dbproc, 9, NTBSTRINGBIND, (DBINT) 0, (BYTE DBFAR *) numero_empleado);
            dbbind(dbproc,10, NTBSTRINGBIND, (DBINT) 0, (BYTE DBFAR *) gl_number_part_1);
            dbbind(dbproc,11, NTBSTRINGBIND, (DBINT) 0,( BYTE DBFAR *) gl_number_part_2);
            dbbind(dbproc,12, NTBSTRINGBIND, (DBINT) 0, (BYTE DBFAR *) filler);

            /* Mientras existan registros. */
            while (dbnextrow(dbproc) != NO_MORE_ROWS) {
                char n_reg[10];
                ++i; sprintf(n_reg, "%d", i);

                /* Aplica formato a las variables. */
                sprintf(reg3.m_tipo_registro, FOR_R3_TIPO_REGISTRO, tipo_registro);
                sprintf(reg3.m_numero_movimiento, FOR_R3_NUMERO_MOVIMIENTO, n_reg);
                sprintf(reg3.m_numero_nomina, FOR_R3_NUMERO_NOMINA, numero_nomina);
                sprintf(reg3.m_rfc, FOR_R3_RFC, rfc);
                sprintf(reg3.m_nombre_empleado, FOR_R3_NOMBRE_EMPLEADO, nombre_empleado);
                sprintf(reg3.m_numero_tarjeta, FOR_R3_NUMERO_TARJETA, numero_tarjeta);
                sprintf(reg3.m_tipo_movimiento, FOR_R3_TIPO_MOVIMIENTO, tipo_movimiento);
                sprintf(reg3.m_fecha_movimiento, FOR_R3_FECHA_MOVIMIENTO, fecha_movimiento);
                sprintf(reg3.m_numero_empleado, FOR_R3_NUMERO_EMPLEADO, numero_empleado);
                sprintf(reg3.m_gl_number_part_1, FOR_R3_GL_NUMBER_PART_1, gl_number_part_1);
                sprintf(reg3.m_gl_number_part_2, FOR_R3_GL_NUMBER_PART_2, gl_number_part_2);
                sprintf(reg3.m_filler, FOR_R3_FILLER, filler);

                /* Arma el registro. */
                (void *) memset((void *) m_registro_tipo3, (int) '\0', (size_t) (LEN_RECORD + 1));
                strcpy(m_registro_tipo3, reg3.m_tipo_registro);
                strcat(m_registro_tipo3, reg3.m_numero_movimiento);
                strcat(m_registro_tipo3, reg3.m_numero_nomina);
                strcat(m_registro_tipo3, reg3.m_rfc);
                strcat(m_registro_tipo3, reg3.m_nombre_empleado);
                strcat(m_registro_tipo3, reg3.m_numero_tarjeta);
                strcat(m_registro_tipo3, reg3.m_tipo_movimiento);
                strcat(m_registro_tipo3, reg3.m_fecha_movimiento);
                strcat(m_registro_tipo3, reg3.m_numero_empleado);
                strcat(m_registro_tipo3, reg3.m_gl_number_part_1);
                strcat(m_registro_tipo3, reg3.m_gl_number_part_2);
                strcat(m_registro_tipo3, reg3.m_filler);
                m_registro_tipo3[LEN_RECORD] = NULL;

                if (strlen(m_registro_tipo3) != LEN_RECORD) {
                    sprintf(caderror, "Error en la longitud del registro %6d.", i);
                    Log(__FILE__, "generaReg3", __LINE__, caderror);
                    exit(FAILURE);
                }

                if (fprintf(pfreg3, FORMATO_REG, m_registro_tipo3) != (LEN_RECORD + 1)) {
                    sprintf(caderror, "Error al escribir el registro %6d.", i);
                    Log(__FILE__, "generaReg3", __LINE__, caderror);
                    exit(FAILURE);
                }
            }
        }
    }
    sprintf(caderror, "Registros generados:%6d.", i);
    Log(__FILE__, "generaReg3", __LINE__, caderror);

    if (fclose(pfreg3)) {
        sprintf(caderror, "%s", strerror(errno));
        Log(__FILE__, "generaReg3", __LINE__, caderror);
        exit(FAILURE);
    }
    return 0;
}

int generaReg4()
{
    int            i = 0;
    FILE        *pfreg4;
    ROW_TYPE_4    reg4;
    char        m_registro_tipo4[LEN_RECORD + 1];

    DBCHAR        tipo_registro[LEN_R4_TIPO_REGISTRO + 1];
    DBCHAR        numero_altas[LEN_R4_NUMERO_ALTAS + 1];
    DBCHAR        numero_bajas[LEN_R4_NUMERO_BAJAS + 1];
    DBCHAR        numero_cambios[LEN_R4_NUMERO_CAMBIOS + 1];
    DBCHAR        numero_carga[LEN_R4_NUMERO_CARGA + 1];
    DBCHAR        filler[LEN_R4_FILLER + 1];

    RETCODE        result_code;

    if ((pfreg4 = fopen(vars_entorno[NOM_ARCH_R4].valor, "w")) == NULL) {
        sprintf(caderror, "Error al crear el archivo de disco %s.",
                vars_entorno[NOM_ARCH_R4].valor);
        Log(__FILE__, "generaReg4", __LINE__, caderror);
        exit(FAILURE);
    }

    *sqlcmd = NULL;
    strcpy(sqlcmd, " create table TMP_ALFA_TOTALES( ");
    strcat(sqlcmd, " total_altas    int, ");
    strcat(sqlcmd, " total_bajas    int, ");
    strcat(sqlcmd, " total_cambios    int, ");
    strcat(sqlcmd, " total_carga    int, ");
    strcat(sqlcmd, " ) ");
    strcat(sqlcmd, "  ");
    strcat(sqlcmd, " declare @valor1 int, @valor2 int, @valor3 int, @valor4 int ");
    strcat(sqlcmd, " select @valor1 = (select count(*) from TMP_ALFA_R3 where t_mov = 'A') ");
    strcat(sqlcmd, " select @valor2 = (select count(*) from TMP_ALFA_R3 where t_mov = 'B') ");
    strcat(sqlcmd, " select @valor3 = (select count(*) from TMP_ALFA_R3 where t_mov = 'C') ");
    strcat(sqlcmd, " select @valor4 = (select count(*) from TMP_ALFA_R3 where t_mov = 'I') ");
    strcat(sqlcmd, " insert into TMP_ALFA_TOTALES values(@valor1, @valor2, @valor3, @valor4) ");
    dbcmd(dbproc, sqlcmd);

    /* Envia los comandos al servidor y comienza la ejecucion. */
    if (dbsqlexec(dbproc) == FAIL) {
        sprintf(caderror, "Error al ejecutar la sentencia SQL: %s.", sqlcmd);
        Log(__FILE__, "generaReg3", __LINE__, caderror);
        exit(FAILURE);
    }

    /* Procesa los comando hasta que no haya mas. */
    while ((result_code = dbresults(dbproc)) != NO_MORE_RESULTS);

    *sqlcmd = NULL;
    strcpy(sqlcmd, " select ");
    strcat(sqlcmd, "         convert(char(1),'4') as t_reg, ");
    strcat(sqlcmd, "         ltrim(rtrim(str(total_altas))) as altas, ");
    strcat(sqlcmd, "         ltrim(rtrim(str(total_bajas))) as bajas, ");
    strcat(sqlcmd, "         ltrim(rtrim(str(total_cambios))) as cambios, ");
    strcat(sqlcmd, "         ltrim(rtrim(str(total_carga))) as carga, ");
    strcat(sqlcmd, "         convert(char(155),'') as filler ");
    strcat(sqlcmd, " from ");
    strcat(sqlcmd, "         TMP_ALFA_TOTALES ");
    dbcmd(dbproc, sqlcmd);

    /* Envia los comandos al servidor y comienza la ejecucion. */
    if (dbsqlexec(dbproc) == FAIL) {
        sprintf(caderror, "Error al ejecutar la sentencia SQL: %s.", sqlcmd);
        Log(__FILE__, "generaReg3", __LINE__, caderror);
        exit(FAILURE);
    }

    /* Procesa los comando hasta que no haya mas. */
    while ((result_code = dbresults(dbproc)) != NO_MORE_RESULTS) {

        /* Si se ejecuto satisfactoriamente */
        if (result_code == SUCCEED) {

            /* Vincula las variables del programa. */
            dbbind(dbproc, 1, NTBSTRINGBIND, (DBINT) 0, (BYTE DBFAR *) tipo_registro);
            dbbind(dbproc, 2, NTBSTRINGBIND, (DBINT) 0, (BYTE DBFAR *) numero_altas);
            dbbind(dbproc, 3, NTBSTRINGBIND, (DBINT) 0, (BYTE DBFAR *) numero_bajas);
            dbbind(dbproc, 4, NTBSTRINGBIND, (DBINT) 0, (BYTE DBFAR *) numero_cambios);
            dbbind(dbproc, 5, NTBSTRINGBIND, (DBINT) 0, (BYTE DBFAR *) numero_carga);
            dbbind(dbproc, 6, NTBSTRINGBIND, (DBINT) 0, (BYTE DBFAR *) filler);

            /* Mientras existan registros. */
            while (dbnextrow(dbproc) != NO_MORE_ROWS) {
                ++i;

                /* Aplica formato a las variables. */
                sprintf(reg4.m_tipo_registro, FOR_R4_TIPO_REGISTRO, tipo_registro);
                sprintf(reg4.m_numero_altas, FOR_R4_NUMERO_ALTAS, numero_altas);
                sprintf(reg4.m_numero_bajas, FOR_R4_NUMERO_BAJAS, numero_bajas);
                sprintf(reg4.m_numero_cambios, FOR_R4_NUMERO_CAMBIOS, numero_cambios);
                sprintf(reg4.m_numero_carga, FOR_R4_NUMERO_CARGA, numero_carga);
                sprintf(reg4.m_filler, FOR_R4_FILLER, filler);

                /* Arma el registro. */
                (void *) memset((void *) m_registro_tipo4, (int) '\0', (size_t) (LEN_RECORD + 1));
                strcpy(m_registro_tipo4, reg4.m_tipo_registro);
                strcat(m_registro_tipo4, reg4.m_numero_altas);
                strcat(m_registro_tipo4, reg4.m_numero_bajas);
                strcat(m_registro_tipo4, reg4.m_numero_cambios);
                strcat(m_registro_tipo4, reg4.m_numero_carga);
                strcat(m_registro_tipo4, reg4.m_filler);
                m_registro_tipo4[LEN_RECORD] = NULL;

                if (strlen(m_registro_tipo4) != LEN_RECORD) {
                    sprintf(caderror, "Error en la longitud del registro %6d.", i);
                    Log(__FILE__, "generaReg4", __LINE__, caderror);
                    exit(FAILURE);
                }

                if (fprintf(pfreg4, FORMATO_REG, m_registro_tipo4) != (LEN_RECORD + 1)) {
                    sprintf(caderror, "Error al escribir el registro %6d.", i);
                    Log(__FILE__, "generaReg4", __LINE__, caderror);
                    exit(FAILURE);
                }
            }
        }
    }
    sprintf(caderror, "Registros generados:%6d.", i);
    Log(__FILE__, "generaReg4", __LINE__, caderror);

    if (fclose(pfreg4)) {
        sprintf(caderror, "%s", strerror(errno));
        Log(__FILE__, "generaReg4", __LINE__, caderror);
        exit(FAILURE);
    }
    return 0;
}

void integra()
{
    FILE    *pf_r1, *pf_r3, *pf_r4, *pf_out;
    char    buffer1[LEN_BUFFER + 1];

    if (! (pf_r1 = fopen(vars_entorno[NOM_ARCH_R1].valor, "r"))) {
        sprintf(caderror, "%s", strerror(errno));
        Log(__FILE__, "integra", __LINE__, caderror);
        exit(FAILURE);
    }

    if (! (pf_r3 = fopen(vars_entorno[NOM_ARCH_R3].valor, "r"))) {
        sprintf(caderror, "%s", strerror(errno));
        Log(__FILE__, "integra", __LINE__, caderror);
        exit(FAILURE);
    }

    if (! (pf_r4 = fopen(vars_entorno[NOM_ARCH_R4].valor, "r"))) {
        sprintf(caderror, "%s", strerror(errno));
        Log(__FILE__, "integra", __LINE__, caderror);
        exit(FAILURE);
    }

    if (! (pf_out = fopen(vars_entorno[NOM_ARCH_ALFA].valor, "w"))) {
        sprintf(caderror, "%s", strerror(errno));
        Log(__FILE__, "integra", __LINE__, caderror);
        exit(FAILURE);
    }

    (void) rewind(pf_r1);
    (void) rewind(pf_r3);
    (void) rewind(pf_r4);

    memset((void *) buffer1, NULL, LEN_BUFFER + 1);

    if (! fread((void *) buffer1, LEN_BUFFER, 1, pf_r1)) {
        sprintf(caderror, "%s", strerror(errno));
        Log(__FILE__, "integra", __LINE__, caderror);
        exit(FAILURE);
    }

    if (! fwrite((void *) buffer1, LEN_BUFFER, 1, pf_out)) {
        sprintf(caderror, "%s", strerror(errno));
        Log(__FILE__, "integra", __LINE__, caderror);
        exit(FAILURE);
    }

    do {
        if (! fread((void *) buffer1, LEN_BUFFER, 1, pf_r3))
            break;

        if (! fwrite((void *) buffer1, LEN_BUFFER, 1, pf_out)) {
            sprintf(caderror, "%s", strerror(errno));
            Log(__FILE__, "integra", __LINE__, caderror);
            exit(FAILURE);
        }

    } while (TRUE);

    if (! fread((void *) buffer1, LEN_BUFFER, 1, pf_r4)) {
        sprintf(caderror, "%s", strerror(errno));
        Log(__FILE__, "integra", __LINE__, caderror);
        exit(FAILURE);
    }

    if (! fwrite((void *) buffer1, LEN_BUFFER, 1, pf_out)) {
        sprintf(caderror, "%s", strerror(errno));
        Log(__FILE__, "integra", __LINE__, caderror);
        exit(FAILURE);
    }

    if (fflush(pf_out)) {
        sprintf(caderror, "%s", strerror(errno));
        Log(__FILE__, "integra", __LINE__, caderror);
        exit(FAILURE);
    }

    if (fclose(pf_out)) {
        sprintf(caderror, "%s", strerror(errno));
        Log(__FILE__, "integra", __LINE__, caderror);
        exit(FAILURE);
    }
}
