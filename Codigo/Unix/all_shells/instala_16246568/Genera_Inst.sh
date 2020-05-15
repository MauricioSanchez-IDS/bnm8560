#!/bin/ksh
cd /opt/c430/000/instala_16246568
rm Usr*.tar

cd /opt/c430/000/bin/ibm
tar -cvf Usr2.tar *
mv Usr2.tar /opt/c430/000/instala_16246568

cd /opt/c430/000/bin/inte
tar -cvf Usr3.tar *
mv Usr3.tar /opt/c430/000/instala_16246568

cd /opt/c430/000/bin/s011
tar -cvf Usr4.tar envio/*
mv Usr4.tar /opt/c430/000/instala_16246568

cd /opt/c430/000/bin/s011
tar -cvf Usr5.tar recepcion/*
mv Usr5.tar /opt/c430/000/instala_16246568

cd /opt/c430/000/bin/s111
tar -cvf Usr6.tar envio/*
mv Usr6.tar /opt/c430/000/instala_16246568

cd /opt/c430/000/bin/s111
tar -cvf Usr7.tar recepcion/*
mv Usr7.tar /opt/c430/000/instala_16246568

cd /opt/c430/000/bin/s702
tar -cvf Usr8.tar envio/*
mv Usr8.tar /opt/c430/000/instala_16246568

cd /opt/c430/000/bin
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

