#__HP_Changes for Linux Migration -Start
#change sybase path`

#SYBASE=/opt/sybase15
SYBASE=/optware/sybase/ase157sp104
LIBDIR=$(SYBASE)/OCS-15_0/lib
SYBLIBS=-L$(LIBDIR) -lsybct64 -lsybcs64 -lsybtcl64 -lsybcomn64 -lsybintl64 -lsybunic64 -lsybdb64 -lm 
LIBAGENTE=/opt/c046/105/lib -ldes32sapuf64 -lagenteSapuf64 -DSAPUF

#CFLAGS= -g +DD64 -DSYB_LP64
CFLAGS= -g -W -m64 -DSYB_LP64
INCAGENTE=/opt/c046/105/include
OCS_INCLUDE=${SYBASE}/${SYBASE_OCS}/include
INCLUDE= -I. -I${INCAGENTE} -I${OCS_INCLUDE}
#LIBHPUX64=/usr/lib/hpux64
LIBLinux64=/usr/lib

#__HP_Changes for Linux Migration -End
all: rep13.o rep14.o rep16.o rep18.o rep20.o rep22.o rep24.o rep26.o C430Reps.o C430Reps

rep13.o : rep13.c
	cc -m64 -c $(INCLUDE) rep13.c

rep14.o : rep14.c
	cc -m64 -c $(INCLUDE) rep14.c

rep16.o : rep16.c
	cc -m64 -c $(INCLUDE) rep16.c

rep18.o : rep18.c
	cc -m64 -c $(INCLUDE) rep18.c

rep20.o : rep20.c
	cc -m64 -c $(INCLUDE) rep20.c

rep22.o : rep22.c
	cc -m64 -c $(INCLUDE) rep22.c

rep24.o : rep24.c
	cc -m64 -c $(INCLUDE) rep24.c

rep26.o : rep26.c
	cc -m64 -c $(INCLUDE) rep26.c

reps.o : reps.c
	cc -m64 -c $(INCLUDE) reps.c

C430Reps.o : C430Reps.c
	cc -m64 -c $(INCLUDE) C430Reps.c

	
C430Reps: C430Reps.o rep13.o rep14.o rep16.o rep18.o rep20.o rep22.o rep24.o rep26.o reps.o
	cc -m64 -o C430Reps C430Reps.o rep13.o rep14.o rep16.o rep18.o rep20.o rep22.o rep24.o rep26.o reps.o lib_rep.o $(SYBLIBS) -L$(LIBAGENTE) 

clean:
	rm -f rep13.o rep14.o rep16.o rep18.o rep20.o rep22.o rep24.o rep26.o reps.o C430Reps.o C430Reps

