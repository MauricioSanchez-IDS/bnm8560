/* NOMBRE       : C430GetCompanies.h                                         */
/* DESCRIPCION  : Definicion de constantes y funciones utilizadas en el      */
/*                programa C430GetCompanies.                                 */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 19/08/2003                                                 */
/* CONTROL DE                                                                */
/* VERSIONES    : V.1.0                                                      */
/* CONTROL DE MODIFICACION                                                   */
/*      IS      NOMBRE                  FECHA           DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     19/08/2003     Primera Version         */
/*     FUN Felipe Uribe Negrón        22/12/2004     Segunda Version         */
/* Copyright Derechos Reservados Banamex S.A. de C.V 2003a                   */
/*   Observaciones:                                                          */
/*                                                                           */

/* Definicion de constantes numericas. */

/* Longitudes de campo. */

#define LEN1 1
#define LEN2 2
#define LEN3 3
#define LEN4 4
#define LEN5 5
#define LEN6 6
#define LEN7 7
#define LEN8 8
#define LEN9 9
#define LEN10 10
#define LEN12 12
#define LEN13 13
#define LEN14 14
#define LEN15 15
#define LEN16 16
#define LEN17 17
#define LEN18 18
#define LEN19 19
#define LEN20 20 
#define LEN23 23 
#define LEN25 25 
#define LEN26 26 
#define LEN30 30 
#define LEN35 35 
#define LEN36 36
#define LEN40 40
#define LEN45 45 
#define LEN50 50 
#define LEN60 60
#define LEN70 70 
#define LEN100 100
#define LEN150 150
#define LEN169 169
#define LEN193 193			  /*FUN 22122004*/
#define LEN201 201
#define LEN204 204			  /*FUN 22122004*/
#define LEN255 255 
#define LEN326 326
#define LEN336 336			  /*FUN 22122004*/
#define LEN344 344 
#define LEN362 362 
#define LEN507 507 
#define LEN584 584 
#define LEN610 610 
#define LEN630 630 
#define LEN679 679 
#define LEN701 701 
#define LEN759 759			  /*FUN 22122004*/
#define LEN799 799 
#define LEN821 821 
#define LEN823 823 
#define LEN834 834 
#define LEN835 835 
#define LEN855 855 
#define LEN885 885 
#define LEN1000 1000

/* Formatos de Campos. */

/* Cadena. */

#define FMTSTR    "%s"
#define FMTSLONG1 "%1s"

/* Definicion de Estructuras. */

/* Empresas. */
                                  
struct strCompany {
   int  iPreffix;
   int  iBankGroup;
   int  iCompanyID;
   int  iChargeOffDate;
};                                
                                  
typedef struct strCompany Company;

/* Usos diversos. */

#define ERREXIT -1    /* Salida de aplicacion con estatus de error. */ 
#define STDEXIT 0     /* Salida de aplicacion con exito. */ 
#define DEBUG1  1     /* Para analisis de salidas. */
#define EOLN   '\0'   /* Fin de linea. */
#define EMPSTR "\0"   /* Cadena Vacia. */


#ifdef DEBUG1
#undef DEBUG1
#endif

/* Macro para deteccion de espacios en blanco. */
 
#define ISWORDSPACE(c) (c == ' ' || c == '\t')

/* Definicion de prototipos de funciones. */
                                            
#if defined(__cplusplus)                    
extern "C" {                                
#endif                  
                        
#ifdef _PROTOTYPES      

   void error_handler();
   void warning_handler();
   int  iC430GetComp(char *[]);

#else
                                              
   void error_handler();
   void warning_handler();
   int  iC430GetComp();

#endif                  
                        
#if defined(__cplusplus)
}                       
#endif
