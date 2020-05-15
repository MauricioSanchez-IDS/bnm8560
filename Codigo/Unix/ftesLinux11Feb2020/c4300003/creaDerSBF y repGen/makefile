#__HP_Changes for Linux Migration -Start
#change sybase path
#SYBASE=/opt/sybase15
SYBASE=/optware/sybase/ase157sp104
INCDIR=$(SYBASE)/OCS-15_0/include
LIBDIR=$(SYBASE)/OCS-15_0/lib
#CFLAGS=+DD64 +Z
CFLAGS=-m64
SYBLIBS=-L$(LIBDIR) -lsybct64 -lsybcs64 -lsybtcl64 -lsybcomn64 -lsybintl64 -lsybdb64 -lsybunic64

#all:DerSBFDailyCycle DerSBFDailyCycleTran

all:creaDerSBF repGen

#DerSBFDailyCycle:
#	cc $(CFLAGS) -I$(INCDIR) -I.  DerSBFDailyCycle.c $(SYBLIBS) -o DerSBFDailyCycle

#DerSBFDailyCycleTran:
#	cc $(CFLAGS) -I$(INCDIR) -I.  DerSBFDailyCycleTran.c $(SYBLIBS) -o DerSBFDailyCycleTran

#DerSBFDailyCycleTran_1:
#	cc $(CFLAGS) -I$(INCDIR) -I.  DerSBFDailyCycleTran_1.c $(SYBLIBS) -o DerSBFDailyCycleTran_1

creaDerSBF:
	cc $(CFLAGS) -I$(INCDIR) -I.  creaDerSBF.c $(SYBLIBS) -o creaDerSBF

repGen:
	cc $(CFLAGS) -I$(INCDIR) -I.  repGen.c $(SYBLIBS) -o repGen

#clean:
#	 rm DerSBFDailyCycle DerSBFDailyCycleTran DerSBFDailyCycleTr an_1 creaDerSBF intelar repGen
#
clean:
	rm creaDerSBF
#__HP_Changes for Linux Migration -End
