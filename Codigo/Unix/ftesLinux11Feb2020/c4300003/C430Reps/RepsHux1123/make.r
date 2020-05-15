SYBASE=/opt/sybase15
LIBDIR=$(SYBASE)/OCS-15_0/lib
SYBLIBS=-L$(LIBDIR) -lsybct64 -lsybcs64 -lsybtcl64 -lsybcomn64 -lsybintl64 -lsybunic64 -lsybdb64 -lcl -lm 
LIBAGENTE=/opt/c046/105/lib -ldes32sapuf64 -lagenteSapuf64 -DSAPUF

CFLAGS= -g +DD64 -DSYB_LP64
INCAGENTE=/opt/c046/105/include
OCS_INCLUDE=${SYBASE}/${SYBASE_OCS}/include
INCLUDE= -I. -I${INCAGENTE} -I${OCS_INCLUDE}
LIBHPUX64=/usr/lib/hpux64

all: rep13.o rep14.o rep16.o rep18.o rep20.o rep22.o rep24.o rep26.o C430Reps.o

rep13.o : rep13.c
	cc -c $(CFLAGS) $(INCLUDE) rep13.c

rep14.o : rep14.c
	cc -c $(CFLAGS) $(INCLUDE) rep14.c

rep16.o : rep16.c
	cc -c $(CFLAGS) $(INCLUDE) rep16.c

rep18.o : rep18.c
	cc -c $(CFLAGS) $(INCLUDE) rep18.c

rep20.o : rep20.c
	cc -c $(CFLAGS) $(INCLUDE) rep20.c

rep22.o : rep22.c
	cc -c $(CFLAGS) $(INCLUDE) rep22.c

rep24.o : rep24.c
	cc -c $(CFLAGS) $(INCLUDE) rep24.c

rep26.o : rep26.c
	cc -c $(CFLAGS) $(INCLUDE) rep26.c

reps.o : reps.c
	cc -c $(CFLAGS) $(INCLUDE) reps.c

C430Reps.o : C430Reps.c
	cc -c $(CFLAGS) $(INCLUDE) C430Reps.c

	
C430Reps: C430Reps.o rep13.o rep14.o rep16.o rep18.o rep20.o rep22.o rep24.o rep26.o reps.o
	cc +DD64 -o C430Reps C430Reps.o rep13.o	rep14.o rep16.o rep18.o rep20.o rep22.o rep24.o rep26.o	reps.o $(SYBLIBS) -L$(LIBAGENTE) 

clean:
	rm -f rep13.o rep14.o rep16.o rep18.o rep20.o rep22.o rep24.o rep26.o reps.o C430Reps.o C430Reps

