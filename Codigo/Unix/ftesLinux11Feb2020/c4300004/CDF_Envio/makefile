#__HP_Changes for Linux Migration -Start
#change sybase path# 
#SYBASE=/opt/sybase15
SYBASE=/optware/sybase/ase157sp104
INCDIR=$(SYBASE)/OCS-15_0/include
LIBDIR=$(SYBASE)/OCS-15_0/lib
HEADERS=$(INCDIR)/sybfront.h 
#SYBLIBS=-L$(LIBDIR) -lsybct64 -lsybcs64 -lsybtcl64 -lsybcomn64 -lsybintl64 -lsybdb64 -lcl -lm
SYBLIBS=-L$(LIBDIR) -lsybct64 -lsybcs64 -lsybtcl64 -lsybcomn64 -lsybintl64 -lsybdb64 -lm
DBLIBS= ./libsybdb.a
#INCEISSA= .
#INCLUDE = -I. -I$INCEISSA 
#__HP_Changes for Linux Migration -End
INCLUDE=-I
DSYS=BSD42
DVERSION=

all: r1000 r3000 r4000 r4300 r4100 r4200 r5000 genarchb r9999 validaEstructCDF 
#all: r1000 r3000 r4000 r4300 r4100 r4200 genarchb r9999 validaEstructCDF 

r1000: r1000.c
	cc -std=c99 -m64 -I$(INCDIR) -I. r1000.c $(SYBLIBS) -g -o r1000

r3000: r3000.c
	cc -m64 -I$(INCDIR) -I. r3000.c $(SYBLIBS) -g -o r3000

r4000: r4000.c
	cc -m64 -I$(INCDIR) -I. r4000.c $(SYBLIBS) -g -o r4000

r4300: r4300.c
	cc -m64 -I$(INCDIR) -I. r4300.c $(SYBLIBS) -g -o r4300

r4100: r4100.c
	cc -m64 -I$(INCDIR) -I. r4100.c $(SYBLIBS) -g -o r4100

r4200: r4200.c
	cc -m64 -I$(INCDIR) -I. r4200.c $(SYBLIBS) -g -o r4200

r5000: r5000.c
	cc -std=c99 -m64 -I$(INCDIR) -I. r5000.c fechas.lib $(SYBLIBS) -g -o r5000
	#cc -std=c99 -m64 -I$(INCDIR) -I. r5000.c $(SYBLIBS) -g -o r5000

r9999: r9999.c
	cc -m64 -I$(INCDIR) -I. r9999.c $(SYBLIBS) -g -o r9999

validaEstructCDF: validaEstructCDF.c
	cc -m64 -I$(INCDIR) -I. validaEstructCDF.c $(SYBLIBS) -g -o validaEstructCDF

genarchb: genarchb.c
	cc -std=c99 -m64 -I$(INCDIR) -I. genarchb.c $(SYBLIBS) -g -o genarchb
