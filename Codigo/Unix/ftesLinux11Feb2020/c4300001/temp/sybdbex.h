/*
** Confidential property of Sybase, Inc.
** (c) Copyright Sybase, Inc. 1992 to ???
** All rights reserved.
*/

/*
** sybdbex.h:      87.1      12/29/93      19:06:20
**  
**  sybdbex.h
**
*/
/* Sccsid @(#) sybdbex.h 87.1 12/29/93 */

#include <stdlib.h>
#include <string.h>

#if WIN3
#pragma warning(disable: 4035)
#endif


#define USER       "sa" 
#define PASSWORD   "Welcome1"
#define SERVER     "SYB_C40"
#define HOSTNAME   "vm-2d9b-6102"   
#define DBASE      "M111"
#define LANGUAGE   "us_english"
#define SQLBUFLEN  6000
#define ERR_CH     stderr
#define OUT_CH     stdout
extern  void       error();

/* Forward declarations of the error handler and message handler routines. 
*/
int CS_PUBLIC err_handler PROTOTYPE((DBPROCESS *dbproc, 
	int severity, 
	int dberr, 
	int oserr,
	char *dberrstr,
	char *oserrstr
	));

int CS_PUBLIC msg_handler PROTOTYPE((
	DBPROCESS       *dbproc,
	DBINT           msgno,
	int             msgstate,
	int             severity,
	char            *msgtext,
	char            *srvname,
	char            *procname,
	int     	line
	));
