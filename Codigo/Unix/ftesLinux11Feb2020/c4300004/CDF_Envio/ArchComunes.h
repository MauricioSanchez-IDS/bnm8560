 #include <stdio.h>
#include <stdlib.h>
#include <string.h>

/*****  RUTINAS PARA VALIDAR CONTENIDO DE CAMPOS  *****/
blancos(char* ArchivoSalida, char *ent, char *leye, char *num)
{
char *p = ent;
// HP char *a = archivoSalida;
  while(*p!=NULL)
  {
    if (*p!=SP)
    {
      printf("ERROR No son blancos en el campo %s =%s=(%s)\n",leye,ent,num);
    }
    p++;
  }
}/* blancos*/
/********************************************************************************************/
/** SOLO NUMEROS ESPACIOS DOSPUNTOS **/
numespdosp(char* ArchivoSalida,char *ent,char *leye,char *num)
{
char *p = ent;
// HPchar *a = ArchivoSalida;
  while(*p!=NULL)
  {
    if ((*p < '0' || *p > '9') && *p != SP && *p !=DOSPUNTOS)
    {
      printf("ERROR No son numeros o espacios o dos puntos el campo %s =%s= (%s)\n", leye,ent,num);
    }
    p++;
  }
}/* numespdosp */
/********************************************************************************************/
/**  VERIFICA CAMPO NUMERICO JUSTIFICADO DERECHA LLENADO CON BLANCOS  **/
numJDFB(char* ArchivoSalida, char *ent,char *leye,char *num)
{
char *p = ent;
//HP char *a = ArchivoSalida;
int inicionum = 0;

  while(*p != NULL)
  {
    if ((*p == SP) && (inicionum == 1))
    {
       printf("ERROR Campo numerico no justificado derecha con blancos en %s =%s= (%s)\n", leye, ent, num);
       break;
    }
    if ((*p != SP) && (inicionum == 0))
    {
      inicionum = 1;
    }
    p++;
  }
}
/********************************************************************************************/
/**  VERIFICA CAMPO NUMERICO JUSTIFICADO IZQUIERDA LLENADO CON BLANCOS  **/
numJIFB(char* ArchivoSalida, char *ent,char *leye,char *num)
{
char *p = ent;
//HP char *a = ArchivoSalida;
int pos = 1;
int inicionum = 0;
int terminonum = 0;

  while(*p != NULL)
  {
    if (*p != SP)
    {
      if (terminonum == 1)
      {
        printf("ERROR Campo numerico no justificado izquierda con blancos en %s =%s= (%s)\n", leye, ent, num);
        break;
      }
      if ((pos > 1) && (inicionum == 0))
      {
        printf("ERROR Campo numerico no justificado izquierda con blancos en %s =%s= (%s)\n", leye, ent, num);
        break;
      }
      else
      {
        inicionum = 1;
      }
    }
    else
    {
      if ((pos > 1) && (inicionum == 1))
        terminonum = 1;
    }
    pos++;
    p++;
  }
}
/********************************************************************************************/
/**  VERIFICA CAMPO NUMERICO JUSTIFICADO DERECHA LLENADO CON CEROS  **/
numJDF0(char* ArchivoSalida, char *ent,char *leye,char *num)
{
char *p = ent;
// HP char *a = ArchivoSalida;
  while(*p != NULL)
  {
    if (*p == SP)
    {
      printf("ERROR Campo numerico no justificado derecha con ceros en %s =%s= (%s)\n", leye, ent, num);
    break;
    }
    p++;
  }
}
/**  VERIFICA CAMPO NUMERICO **/
numeros(char* ArchivoSalida, char *ent,char *leye,char *num, char *Jus,char *Fill)
/*numeros(ArchivoSalida,ent,leye,num, JusFill)*/
{
char *p = ent;
char datJus = Jus[0];
char datFill = Fill[0]; 
  if (datFill == '0')
  /*if (*dat == '0')*/
  {
    while(*p!=NULL)
    {
      if (*p < '0' || *p > '9')
      {
        printf("ERROR No son numeros en el campo %s =%s= (%s)\n",leye, ent,num);
        break;
      }
      p++;
    }
    if (datJus == 'D')
    /*if (*(dat+1) == 'D')*/
    {
      numJDF0(ArchivoSalida, ent, leye, num);
    }
  }
  else if(datFill == 'B')
  /*else if(*dat == 'B')*/
  { 
    while(*p!=NULL)
    {
      if ((*p < '0' || *p > '9') && (*p != SP ))
      {
         printf("ERROR No son numeros o espacios en el campo %s =%s= (%s)\n",leye, ent,num);
         break;
      }
      p++;
    }
    if (datJus == 'I')                             
    /*if (*(dat+1) == 'I')*/                             
    {                                            
      numJIFB(ArchivoSalida, ent, leye, num);    
    }                                            
    else if (datJus == 'D')                             
    /*else if (*(dat+1) == 'D')*/                             
    {                                            
      numJDFB(ArchivoSalida, ent, leye, num);    
    }                                            
  }
}/* numeros */
/*********************************************************************************************/
/** VERIFICA CAMPO DE ALFAS **/
letras(char* ArchivoSalida, char *ent,char *leye,char *num)
{
char *p = ent;
// HP char *a = ArchivoSalida;
  while(*p!=NULL)
  {
    /*if (*p > 'z' || *p < SP)*/
    if (*p > 'z' && *p < 'A' && *p < SP)
    {
      printf("ERROR No son alfas en el campo %s =%s= (%s)\n",leye,ent,num);
      break;
    }
    p++;
  }
}/* letras */
/********************************************************************************************/
/** VALIDA FECHAS **/
fecha(char* ArchivoSalida, char *ent,char *leye,char *num)
{
char *p = ent;
// HP char *a = ArchivoSalida;
char anio[5];
char mes[3];
char dia[3];
char *data = ent;
int bis;
int i;

  while(*p!=NULL)
  {  
    if ((*p < '0' || *p > '9') && *p != SP && *p != DOSPUNTOS)
    {  
      printf("ERROR simbolos no validos para una fecha %s =%s= (%s)\n", leye,ent,num);
    }
    p++;
  }
  anio[0] = *data;
  anio[1] = *(data+1);
  anio[2] = *(data+2);
  anio[3] = *(data+3);
  anio[4] = '\0';
  mes[0] = *(data+4);
  mes[1] = *(data+5);
  mes[2] = '\0';
  dia[0] = *(data+6);
  dia[1] = *(data+7);
  dia[2] = '\0';
 
  if (atoi(anio) % 4 == 0 && atoi(anio) % 100 != 0 || atoi(anio) % 400 == 0)
  {
    bis = 1;
  }
  else
  {
    bis = 0;
  }
  if (atoi(mes) >= 1 && atoi(mes) <= 12)
  {
    switch (atoi(mes))
    {
      case 1:
      case 3:
      case 5:
      case 7:
      case 8:
      case 10:
      case 12:
        if (!(atoi(dia)>=1 && atoi(dia)<=31))
          printf("ERROR valor del dia no corresponde para una fecha %s =%s= (%s)\n", leye,ent,num);
        break;
      case 2:
        if (!(atoi(dia)>=1 && atoi(dia) <= (28 + bis)))
          printf("ERROR valor del dia no corresponde para una fecha %s =%s= (%s)\n", leye,ent,num);
        break;
      case 4:
      case 6:
      case 9:
      case 11:
        if (!(atoi(dia)>=1 && atoi(dia)<=30))
          printf("ERROR valor del dia no corresponde para una fecha %s =%s= (%s)\n", leye,ent,num);
        break;  
    }
  }
  else
  {
     printf("ERROR valor del mes no corresponde para una fecha %s =%s= (%s)\n", leye,ent,num);
  }
}/* fecha*/
/*********************************************************************************************/
valFormatogral(char* ArchivoSalida, char *ent,char *leye,char* num, char *tipDat, char *Jus, char *Fill)
/* valFormatogral(ArchivoSalida, ent, leye, num, tipDat, JusFill) */
{
char *dat=tipDat;
  switch (*dat)
  {
    case 'A':
      letras(ArchivoSalida, ent, leye, num);
      break;
    case 'N':
      numeros(ArchivoSalida, ent, leye, num, Jus,Fill);
      /*numeros(ArchivoSalida, ent, leye, num, JusFill);*/
      break;
    case 'D':
      fecha(ArchivoSalida, ent, leye, num);
      break;
  }
}
/********************************************************************************************/
ceros(char* ArchivoSalida, char *ent,char *leye,char *num)
{
char *p = ent;
// HP char *a = ArchivoSalida;
  while(*p!=NULL)
  {
    if (*p!='0')
    {
      printf("ERROR No son puros ceros en el campo %s =%s=(%s)\n",leye,ent, num);
    }
    p++;
  }
} /* ceros */

/** SOLO NUMEROS ESPACIOS GUIONES **/
numespgui(char* ArchivoSalida, char *ent,char *leye,char *num)
{
char *p = ent;
// HP char *a = ArchivoSalida;
  while(*p!=NULL)
  {
    if ((*p < '0' || *p > '9') && *p != SP && *p != SIGNOMENOS)
    {
      printf("ERROR No son numeros o espacios o guiones en el campo %s =%s=(%s)\n",leye,ent,num);
    }
    p++;
  }
}
/********************************************************************************************/
vacia(char* ArchivoSalida, char *ent,char *leye,char *num)
{
char *p = ent;
// HP char *a = ArchivoSalida;
char hay = 0;

  while(*p!=NULL)
  {
    if (*p!=SP)
      hay=1;
    p++; 
  } 
  if (!hay)
  {
    printf("ERROR Debe haber caracteres en este campo %s =%s=(%s)\n", leye, ent, num);
  }
} /* vacia */

