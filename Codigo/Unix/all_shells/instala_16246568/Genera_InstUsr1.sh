#!/bin/ksh
cd /opt/c430/000/instala_16246568
rm Usr1.tar

cd /opt/c430/000/bin
cp .profile profile
tar -cvf c430.tar *
cd /opt/c430/000/instala_16246568/c430
rm -rf *
mv /opt/c430/000/bin/c430.tar . 
tar -xvf c430.tar
rm -rf ibm
rm -rf inte 
rm -rf s011
rm -rf s111
rm -rf s702
rm -rf Compiladores
rm c430.tar
tar -cvf Usr1.tar * 
mv Usr1.tar /opt/c430/000/instala_16246568

