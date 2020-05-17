#define __VOLCAD_H

#if defined(__cplusplus)
extern "C" {
#endif

#if defined(_PROTOTYPES)
char	*trae_subcad(char *, int, int); 
char	*trae_flot(char *, int);
char	*VolteaCad(char *);
char	*CambiaInt(int);
char	*CambiaIntLargo(unsigned long int);
#else
char	*trae_subcad();
char	*trae_flot();
char	*VolteaCad();
char	*CambiaInt();
char	*CambiaIntLargo();
#endif

#if defined(__cplusplus)
}
#endif

char *trae_subcad(linea, ini, fin)
char *linea;
int ini;
int fin;
{
    int i, j;
    char aux[2000];
    char reg[2000];
    i = 0;
    j = 0;
    reg[0] = NULL;
    ini = ini - 1;
    fin = fin - 1;
    strcpy(aux, linea);
    while (aux[i] != 0) {
	if (i >= ini && i <= fin)
	    reg[j++] = aux[i];
	i++;
    }
    reg[j] = 0;
    return reg;
}

char *trae_flot(linea, punto)
char *linea;
int punto;
{
    int longi;
    char Aux[20];
    char Dec[20];
    Aux[0] = 0;
    Dec[0] = 0;

    longi = strlen(linea);

    if (punto > longi)
		return "0";

    strcpy(Aux, trae_subcad(linea, 1, (longi - punto)));
    strcpy(Dec, trae_subcad(linea, (longi - punto + 1), longi));
    strcat(Aux, ".");
    strcat(Aux, Dec);
    return Aux;
}

char *VolteaCad(esto)
char esto[13];
{
    int a, i, count;
    char estoes[12 + 1];

    i = strlen(esto);
    count = i - 1;
    i = 0;

    while (count >= 0)
		estoes[i++] = esto[count--];

    estoes[i] = 0;
    return (estoes);
}

char *CambiaInt(entero)
int entero;
{
    int guarda, i, count;
    char caden[12 + 1];
    char caden2[12 + 1];
    caden2[0] = NULL;
    i = 0;

    if (entero == 0) {
	caden[i++] = '0';
    }
    strcpy(caden2, "");
    while (entero > 0) {
		guarda = entero % 10;
		entero = entero / 10;
		switch (guarda) {
			case 0: caden[i] = '0'; break;
			case 1: caden[i] = '1'; break;
			case 2: caden[i] = '2'; break;
			case 3: caden[i] = '3'; break;
			case 4: caden[i] = '4'; break;
			case 5: caden[i] = '5'; break;
			case 6: caden[i] = '6'; break;
			case 7: caden[i] = '7'; break;
			case 8: caden[i] = '8'; break;
			case 9: caden[i] = '9'; break;
		}
		i++;
    }
    caden[i] = 0;
    strcpy(caden2, VolteaCad(caden));
    return (caden2);
}

char *CambiaIntLargo(entero)
unsigned long int entero;
{
    int guarda, i, count;
    char caden[12 + 1];
    char caden2[12 + 1];
    caden2[0] = NULL;
    i = 0;

    if (entero == 0) {
	caden[i++] = '0';
    }
    strcpy(caden2, "");
    while (entero > 0) {
	guarda = entero % 10;
	entero = entero / 10;
	switch (guarda) {
	case 0:
	    caden[i] = '0';
	    break;
	case 1:
	    caden[i] = '1';
	    break;
	case 2:
	    caden[i] = '2';
	    break;
	case 3:
	    caden[i] = '3';
	    break;
	case 4:
	    caden[i] = '4';
	    break;
	case 5:
	    caden[i] = '5';
	    break;
	case 6:
	    caden[i] = '6';
	    break;
	case 7:
	    caden[i] = '7';
	    break;
	case 8:
	    caden[i] = '8';
	    break;
	case 9:
	    caden[i] = '9';
	    break;
	}
	i++;

    }
    caden[i] = 0;
    strcpy(caden2, VolteaCad(caden));
    return (caden2);
}
