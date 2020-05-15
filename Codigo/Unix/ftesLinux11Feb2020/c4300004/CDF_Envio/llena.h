#include <stdio.h>
#include <string.h>

buscap(c,j)
char *c;
int j;
{
   int i;

   i=0;
   while ((c[i] != '.'))
      i++;
   return((i<j) ? i : -1);
}
char *formatea(cadena,lf,chr,just,mask,tdato,li)
char *cadena,chr,just,*mask,tdato;
int  lf,li;
{
   static char st[251];
   char ch;
   int  i,j,k,l,msk;

   i=0;
   ch=(((chr=='B')||(chr=='b')) ? ' ' : chr);
   switch (tdato) {
   case 'A': 
      switch (just) {
      case 'I': {
         if (li) strcpy(st,cadena);
         while (i<lf-li)
            st[li+i++]=ch;
         st[li+i]=0;
         break;
      }
      case 'D': {
         while(i<lf-li)
            st[i++]=ch;
         if (li) while(st[i++]=*cadena++);
         else st[i]=0;
         break;
      }
      default: return "Error, tipo de justificado invalido";
      }
      break;
   case 'D': 
      if (lf == 5)
         return((char *) cadena);
      if (lf == 8)
         return((char *) cadena);
      if (lf == 17)
         return " ";
   case 'N':
      if (!mask)
         msk=0;
      else
         if (!strcmp(mask,"99999999.9999999"))
            msk=7;
         else 
            if (!strcmp(mask,"99999999999.9999"))
               msk=4;
            else 
	       if (!strcmp(mask,"9999999999.99"))
                msk=2;
               else 
                msk=0;
      st[lf]=0;
      if ((i=buscap(cadena,(int) strlen(cadena))) != -1) {
         if (((j=strlen(cadena)-i-1) > msk) || ((k=i+msk) > lf))
            return "error, existen mas decimales o la lf < al minimo necesario";
         k=lf-1;
         for (l=0; l<(msk-j); l++)
            st[k--]=ch; 
         for (l=0; l<j; l++)
            st[k--]=cadena[i+j-l];
         for (l=i-1; l>=0; l--)
            st[k--]=cadena[l];
         for (l=1; l<=(lf-i-msk); l++)
            st[k--]=ch;
      }
      else {
         if (msk) {
            if ((i=strlen(cadena)+msk) > lf)
               return "error en longitud final, es menor al minimo necesario";
            for (i=1; i<=msk; i++)
               st[lf-i]=ch;
         } 
         i=1+msk;
         for (k=strlen(cadena); k>0; k--)
            st[lf-i++]=cadena[k-1];
         for (k=lf-strlen(cadena)-msk; k>0; k--)
            st[lf-i++]=ch;
      }
      break;
   default: return "Error, tipo de dato invalido";
   }
   return((char *) st);
}
