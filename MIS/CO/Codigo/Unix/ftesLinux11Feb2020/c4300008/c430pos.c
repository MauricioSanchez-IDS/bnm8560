#include <stdio.h>
#include <string.h>

void main(totarg,argu)
int totarg;      
char *argu[];    
{
int len;
char resul[3];
  if ( argu[1] != NULL)
  {
  len=strlen(argu[1]);
  if (len >= 2)
{
  len=len-2; /*regresa las ultimas dos posiciones de cadena*/
  printf("%c%c\n",argu[1][len],argu[1][len+1]);
}
  else
{
  printf("00\n");
}
  }
  else
  {
  printf("00\n");
  }
}
