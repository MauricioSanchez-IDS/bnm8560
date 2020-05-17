#!/bin/ksh
cd /opt/c430/000/bin
tar -cvf c430.tar .ssh *
cd /opt/c430/000/instala_16246568/c430
rm -rf *
mv /opt/c430/000/bin/c430.tar . 
tar -xvf c430.tar
rm -rf 16235812
rm -rf 16246568
rm -rf 812
rm -rf Compiladores
rm -rf inputData
rm list*
rm sapufbk sapuf.old
rm s111/recepcion/respaldo/*
rm c430.tar
rm cmp.sh
rm *.txt
tar -cvf CR.tar .ssh *
cd ..
rm CR.tar
mv c430/CR.tar .
