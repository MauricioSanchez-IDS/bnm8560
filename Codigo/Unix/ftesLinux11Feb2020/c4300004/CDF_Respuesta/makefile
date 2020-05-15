#__HP_Changes for Linux Migration -Start
#change sybase path
#SYBASE=/opt/sybase15
SYBASE=/optware/sybase/ase157sp104
INCDIR=$(SYBASE)/OCS-15_0/include
LIBDIR=$(SYBASE)/OCS-15_0/lib
#CFLAGS=+DD64 +Z
CFLAGS=-m64
SYBLIBS=-L$(LIBDIR) -lsybct64 -lsybcs64 -lsybtcl64 -lsybcomn64 -lsybintl64 -lsybdb64 -lsybunic64
#__HP_Changes for Linux Migration -End
all: validaErrCDF valoraMTC

validaErrCDF:
	cc $(CFLAGS) -I$(INCDIR) -I/opt/c046/105/include -I.  validaErrCDF.c -L/opt/c046/105/lib/libagenteSapuf64.so $(SYBLIBS) -o validaErrCDF

#ActRech:
#	cc $(CFLAGS) -I$(INCDIR) -I.  ActRech.c $(SYBLIBS) -o ActRech

valoraMTC:
	cc $(CFLAGS) -I$(INCDIR) -I.  valoraMTC.c $(SYBLIBS) -o valoraMTC
