SYBASE=/opt/sybase15/OCS-15_0
INCDIR=$(SYBASE)/include
LIBDIR=$(SYBASE)/lib
LIBAGENTE=/opt/c046/105/lib -ldes32sapuf64 -lagenteSapuf64
INCAGENTE=/opt/c046/105/include
HEADERS=$(INCDIR)/sybfront.h $(INCDIR)/sybdb.h $(INCAGENTE)/SAPUF_Enlace.h
DBLIBS=/opt/sybase15/OCS-15_0/lib/libsybdb64.so
INCLUDE=-I. -I$(INCDIR)
DSYS=BSD42
DVERSION=

all: C430Reps

#C430Reps: $(HEADERS) C430Reps.c
C430Reps: C430Reps.c
	cc +DD64 -DSYB_LP64 -Ae -g -v $(INCLUDE) -I$(INCAGENTE) -L$(LIBDIR) $(LIBDIR)/libsybdb64.so \
	-L$(LIBAGENTE) -I/opt/tuxedo/V80/include reps.c C430Reps.c -o C430Reps

#cc +DD64 -Ae -g -v $(INCLUDE) -I$(INCAGENTE) -L$(LIBDIR) $(LIBDIR)/libsybdb64.so \

clean:
	rm C430Reps
