#!/usr/bin/ksh
PATH=$PATH:/opt/c430/000/bin
##__HP changes for Linux migration - start -change /bin/sh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end
exec 1>>$(paths.sh 04 LOG)/masterc430.log
exec 2>&1
n=$(ps -ef | grep -v grep | grep -v boot | grep /opt/c430/000/bin/masterc430| grep $(whoami) | wc -l)
if [ $n -eq 0 ]
then
	echo "Reiniciando master..."
	$(paths.sh 04 CRO)/masterc430.sh
fi
