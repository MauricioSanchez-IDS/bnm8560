#! /bin/ksh
##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

cat $1 | awk ' { if ( match($0,"\r") == 0 ) {gsub("$","\r",$0)} {print $0} }' > $HOME/temp.txt
mv $HOME/temp.txt $1
