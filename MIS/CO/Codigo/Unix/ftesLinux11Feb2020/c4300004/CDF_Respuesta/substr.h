char *substr(sti,pi,lon)
char *sti;
int pi,lon;
{
   static char stf[100];
   int i,j;

   if ((pi+lon-1) > strlen(sti) || !(lon)) 
      return "Longitud invalida";
   if ((pi < 1) || (pi > strlen(sti)))
      return "Posicion invalida";
   for (i=0; i<lon; i++,pi++)
      stf[i]=sti[pi-1];
   stf[i]=0;
   return ((char *) stf);
}


/*
main(argc,argv)
int argc;
char *argv[];
{
   printf("\n%s\n",substr(argv[1],atoi(argv[2]),atoi(argv[3])));
}
*/
