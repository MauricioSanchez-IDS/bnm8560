#include <sybdb.h>
#include <sybfront.h>


/*definicion de longitudes*/
#define FTONUMCAMPO        4
#define FTONOMCAMPO       35
#define FTOPOSICIONINI     4
#define FTOPOSICIONFIN     4
#define FTOLONGITUD        4
#define FTOTIPODATO        1
#define FTOFILL            1
#define FTOJUSTIFICADO     1
#define FTOFORMATO        25

/*definicion de tipos de datos*/

DBCHAR ftoNumCampo[FTONUMCAMPO+1];
DBCHAR ftoNomCampo[FTONOMCAMPO+1];
DBCHAR ftoPosicionIni[FTOPOSICIONINI+1];
DBCHAR ftoPosicionFin[FTOPOSICIONFIN+1];
DBCHAR ftoLongitud[FTOLONGITUD+1];
DBCHAR ftoTipoDato[FTOTIPODATO+1];
DBCHAR ftoFill[FTOFILL+1];
DBCHAR ftoJustificado[FTOJUSTIFICADO+1];
DBCHAR ftoFormato[FTOFORMATO+1];
