/* NOMBRE       : C430CreateTempTables.h                                     */
/* DESCRIPCION  : Definicion de constantes y funciones utilizadas en el      */
/*                programa C430CreateTempTables.                             */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 11/09/2003                                                 */
/* CONTROL DE                                                                */
/* VERSIONES    : V.1.0                                                      */
/* CONTROL DE MODIFICACION                                                   */
/*      IS      NOMBRE                  FECHA           DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     11/09/2003     Primera Version         */
/*     FUN Felipe Uribe Negrón        21/12/2004     Segunda Version         */
/* Copyright Derechos Reservados Banamex S.A. de C.V 2003a                   */
/*   Observaciones:                                                          */
/*                                                                           */

/* Definicion de constantes numericas. */

/* Longitudes de campo. */

#define LEN1 1
#define LEN2 2
#define LEN3 3
#define LEN4 4
#define LEN5 5
#define LEN6 6
#define LEN7 7
#define LEN8 8
#define LEN9 9
#define LEN10 10
#define LEN12 12
#define LEN13 13
#define LEN14 14
#define LEN15 15
#define LEN16 16
#define LEN17 17
#define LEN18 18
#define LEN19 19
#define LEN20 20 
#define LEN23 23 
#define LEN25 25 
#define LEN26 26 
#define LEN30 30 
#define LEN35 35 
#define LEN36 36
#define LEN40 40
#define LEN45 45 
#define LEN50 50 
#define LEN60 60
#define LEN70 70 
#define LEN100 100
#define LEN150 150
#define LEN169 169
#define LEN193 193						/* FUN 21122004 */
#define LEN201 201
#define LEN204 204						/* FUN 21122004 */
#define LEN255 255 
#define LEN326 326
#define LEN336 336						/* FUN 21122004 */
#define LEN344 344 
#define LEN362 362 
#define LEN507 507 
#define LEN584 584 
#define LEN610 610 
#define LEN630 630 
#define LEN679 679 
#define LEN701 701 
#define LEN759 759						/* FUN 21122004 */
#define LEN799 799 
#define LEN821 821 
#define LEN823 823 
#define LEN834 834 
#define LEN835 835 
#define LEN855 855 
#define LEN885 885 
#define LEN1000 1000
#define LEN2000 2000
#define LEN5000 5000

/* Posiciones de Registros. */

/* Registro 0000. */

#define POS1_0000 1
#define POS5_0000 5
#define POS8_0000 8
#define POS108_0000 108
#define POS114_0000 114
#define POS117_0000 117
#define POS125_0000 125
#define POS130_0000 130						/* FUN 21122004 */
#define POS131_0000 131						/* FUN 21122004 */
#define POS191_0000 191						/* FUN 21122004 */
#define POS192_0000 192						/* FUN 21122004 */
#define POS951_0000 951

/* Registro 1000. */

#define POS1_1000 1
#define POS5_1000 5
#define POS8_1000 8
#define POS14_1000 14
#define POS17_1000 17
#define POS67_1000 67
#define POS117_1000 117
#define POS127_1000 127
#define POS177_1000 177
#define POS187_1000 187
#define POS197_1000 197
#define POS212_1000 212
#define POS227_1000 227
#define POS242_1000 242
#define POS257_1000 257
#define POS272_1000 272
#define POS951_1000 951

/* Registro 1001. */

#define POS1_1001 1
#define POS5_1001 5
#define POS8_1001 8
#define POS14_1001 14
#define POS17_1001 17
#define POS67_1001 67
#define POS117_1001 117
#define POS951_1001 951

/* Registro 2000. */

#define POS1_2000 1
#define POS5_2000 5
#define POS8_2000 8
#define POS14_2000 14
#define POS17_2000 17
#define POS20_2000 20
#define POS45_2000 45
#define POS46_2000 46
#define POS71_2000 71
#define POS96_2000 96
#define POS116_2000 116						/* FUN 21122004 */
#define POS117_2000 117						/* FUN 21122004 */
#define POS157_2000 157						/* FUN 21122004 */
#define POS158_2000 158						/* FUN 21122004 */
#define POS159_2000 159						/* FUN 21122004 */
#define POS199_2000 199						/* FUN 21122004 */
#define POS200_2000 200						/* FUN 21122004 */
#define POS201_2000 201						/* FUN 21122004 */
#define POS241_2000 241						/* FUN 21122004 */
#define POS242_2000 242						/* FUN 21122004 */
#define POS243_2000 243						/* FUN 21122004 */
#define POS283_2000 283						/* FUN 21122004 */
#define POS284_2000 284						/* FUN 21122004 */
#define POS324_2000 324						/* FUN 21122004 */
#define POS349_2000 349						/* FUN 21122004 */
#define POS374_2000 374						/* FUN 21122004 */
#define POS384_2000 384						/* FUN 21122004 */
#define POS404_2000 404						/* FUN 21122004 */
#define POS434_2000 434						/* FUN 21122004 */
#define POS452_2000 452						/* FUN 21122004 */
#define POS470_2000 470						/* FUN 21122004 */
#define POS485_2000 485						/* FUN 21122004 */
#define POS493_2000 493						/* FUN 21122004 */
#define POS495_2000 495						/* FUN 21122004 */
#define POS513_2000 513						/* FUN 21122004 */
#define POS573_2000 573						/* FUN 21122004 */
#define POS593_2000 593						/* FUN 21122004 */
#define POS613_2000 613						/* FUN 21122004 */
#define POS633_2000 633						/* FUN 21122004 */
#define POS634_2000 634						/* FUN 21122004 */
#define POS684_2000 684						/* FUN 21122004 */
#define POS685_2000 685						/* FUN 21122004 */
#define POS686_2000 686						/* FUN 21122004 */
#define POS746_2000 746						/* FUN 21122004 */
#define POS747_2000 747						/* FUN 21122004 */
#define POS951_2000 951

/* Registro 2001. */

#define POS1_2001 1
#define POS5_2001 5
#define POS8_2001 8
#define POS14_2001 14
#define POS17_2001 17
#define POS20_2001 20
#define POS45_2001 45
#define POS70_2001 70
#define POS220_2001 220
#define POS221_2001 221
#define POS241_2001 241
#define POS242_2001 242
#define POS245_2001 245
#define POS247_2001 247
#define POS255_2001 255
#define POS257_2001 257
#define POS275_2001 275
#define POS293_2001 293
#define POS323_2001 323
#define POS349_2001 349
#define POS357_2001 357
#define POS365_2001 365
#define POS368_2001 368
#define POS386_2001 386
#define POS404_2001 404
#define POS412_2001 412
#define POS421_2001 421
#define POS446_2001 446
#define POS450_2001 450
#define POS451_2001 451
#define POS471_2001 471
#define POS479_2001 479
#define POS480_2001 480
#define POS481_2001 481
#define POS506_2001 506
#define POS507_2001 507
#define POS508_2001 508
#define POS516_2001 516
#define POS517_2001 517
#define POS525_2001 525						/* FUN 21122004 */
#define POS543_2001 543						/* FUN 21122004 */
#define POS544_2001 544						/* FUN 21122004 */
#define POS569_2001 569						/* FUN 21122004 */
#define POS570_2001 570						/* FUN 21122004 */
#define POS588_2001 588						/* FUN 21122004 */
#define POS591_2001 591						/* FUN 21122004 */
#define POS592_2001 592						/* FUN 21122004 */
#define POS593_2001 593						/* FUN 21122004 */
#define POS595_2001 595						/* FUN 21122004 */
#define POS613_2001 613						/* FUN 21122004 */
#define POS615_2001 615						/* FUN 21122004 */
#define POS951_2001 951

/* Registro 5000. */

#define POS1_5000 1
#define POS5_5000 5
#define POS8_5000 8
#define POS14_5000 14
#define POS17_5000 17
#define POS25_5000 25
#define POS50_5000 50
#define POS58_5000 58
#define POS66_5000 66
#define POS74_5000 74
#define POS92_5000 92
#define POS93_5000 93
#define POS99_5000 99
#define POS107_5000 107
#define POS119_5000 119
#define POS121_5000 121
#define POS136_5000 136
#define POS159_5000 159
#define POS165_5000 165
#define POS168_5000 168
#define POS183_5000 183
#define POS187_5000 187
#define POS206_5000 206
#define POS222_5000 222
#define POS262_5000 262
#define POS277_5000 277
#define POS282_5000 282
#define POS292_5000 292
#define POS295_5000 295
#define POS315_5000 315
#define POS316_5000 316
#define POS341_5000 341
#define POS344_5000 344
#define POS362_5000 362
#define POS365_5000 365
#define POS383_5000 383
#define POS386_5000 386
#define POS404_5000 404
#define POS407_5000 407
#define POS425_5000 425
#define POS428_5000 428
#define POS446_5000 446
#define POS449_5000 449
#define POS467_5000 467
#define POS470_5000 470
#define POS488_5000 488
#define POS491_5000 491
#define POS509_5000 509
#define POS512_5000 512
#define POS530_5000 530
#define POS544_5000 544
#define POS545_5000 545
#define POS546_5000 546
#define POS571_5000 571
#define POS589_5000 589
#define POS590_5000 590
#define POS608_5000 608
#define POS609_5000 609
#define POS634_5000 634
#define POS635_5000 635
#define POS636_5000 636
#define POS640_5000 640
#define POS644_5000 644
#define POS694_5000 694
#define POS709_5000 709
#define POS713_5000 713
#define POS714_5000 714
#define POS715_5000 715
#define POS732_5000 732
#define POS750_5000 750						/* FUN 21122004 */
#define POS758_5000 758						/* FUN 21122004 */
#define POS951_5000 951

/* Registro 6001. */

#define POS1_6001 1
#define POS3_6001 3
#define POS5_6001 5
#define POS11_6001 11
#define POS14_6001 14
#define POS30_6001 30
#define POS45_6001 45
#define POS68_6001 68
#define POS80_6001 80
#define POS92_6001 92
#define POS104_6001 104
#define POS116_6001 116
#define POS131_6001 131
#define POS144_6001 144
#define POS156_6001 156
#define POS157_6001 157
#define POS162_6001 162
#define POS164_6001 164
#define POS165_6001 165
#define POS170_6001 170
#define POS171_6001 171
#define POS176_6001 176
#define POS178_6001 178
#define POS179_6001 179
#define POS184_6001 184
#define POS185_6001 185
#define POS190_6001 190
#define POS192_6001 192
#define POS193_6001 193
#define POS198_6001 198
#define POS199_6001 199
#define POS204_6001 204
#define POS206_6001 206
#define POS207_6001 207
#define POS212_6001 212
#define POS213_6001 213
#define POS218_6001 218
#define POS220_6001 220
#define POS221_6001 221
#define POS226_6001 226
#define POS227_6001 227
#define POS232_6001 232
#define POS234_6001 234
#define POS235_6001 235
#define POS240_6001 240
#define POS241_6001 241
#define POS246_6001 246
#define POS248_6001 248
#define POS249_6001 249
#define POS254_6001 254
#define POS255_6001 255
#define POS260_6001 260
#define POS262_6001 262
#define POS263_6001 263
#define POS268_6001 268
#define POS269_6001 269
#define POS274_6001 274
#define POS276_6001 276
#define POS277_6001 277
#define POS282_6001 282
#define POS283_6001 283
#define POS288_6001 288
#define POS290_6001 290
#define POS291_6001 291
#define POS296_6001 296
#define POS297_6001 297
#define POS302_6001 302
#define POS304_6001 304
#define POS305_6001 305
#define POS310_6001 310
#define POS311_6001 311
#define POS316_6001 316
#define POS318_6001 318
#define POS319_6001 319
#define POS324_6001 324
#define POS325_6001 325
#define POS330_6001 330
#define POS332_6001 332
#define POS333_6001 333
#define POS338_6001 338
#define POS339_6001 339
#define POS344_6001 344
#define POS346_6001 346
#define POS347_6001 347
#define POS352_6001 352
#define POS353_6001 353
#define POS358_6001 358
#define POS360_6001 360
#define POS361_6001 361
#define POS366_6001 366
#define POS367_6001 367
#define POS372_6001 372
#define POS374_6001 374
#define POS375_6001 375
#define POS380_6001 380
#define POS388_6001 388
#define POS413_6001 413
#define POS433_6001 433
#define POS439_6001 439
#define POS442_6001 442
#define POS443_6001 443
#define POS444_6001 444
#define POS951_6001 951

/* Registro 6002. */

#define POS1_6002 1
#define POS3_6002 3
#define POS5_6002 5
#define POS11_6002 11
#define POS14_6002 14
#define POS30_6002 30
#define POS33_6002 33
#define POS39_6002 39
#define POS49_6002 49
#define POS52_6002 52
#define POS62_6002 62
#define POS75_6002 75
#define POS87_6002 87
#define POS91_6002 91
#define POS106_6002 106
#define POS141_6002 141
#define POS153_6002 153
#define POS168_6002 168
#define POS180_6002 180
#define POS195_6002 195
#define POS207_6002 207
#define POS211_6002 211
#define POS226_6002 226
#define POS238_6002 238
#define POS250_6002 250
#define POS951_6002 951

/* Registro 6004. */

#define POS1_6004 1
#define POS3_6004 3
#define POS5_6004 5
#define POS11_6004 11
#define POS14_6004 14
#define POS30_6004 30
#define POS33_6004 33
#define POS43_6004 43
#define POS53_6004 53
#define POS61_6004 61
#define POS69_6004 69
#define POS70_6004 70
#define POS83_6004 83
#define POS90_6004 90
#define POS102_6004 102
#define POS114_6004 114
#define POS126_6004 126
#define POS138_6004 138
#define POS150_6004 150
#define POS165_6004 165
#define POS177_6004 177
#define POS189_6004 189
#define POS201_6004 201
#define POS213_6004 213
#define POS225_6004 225
#define POS237_6004 237
#define POS249_6004 249
#define POS261_6004 261
#define POS273_6004 273
#define POS285_6004 285
#define POS297_6004 297
#define POS309_6004 309
#define POS321_6004 321
#define POS951_6004 951

/* Registro 6005. */

#define POS1_6005 1
#define POS3_6005 3
#define POS5_6005 5
#define POS11_6005 11
#define POS14_6005 14
#define POS30_6005 30
#define POS33_6005 33
#define POS58_6005 58
#define POS98_6005 98
#define POS123_6005 123
#define POS126_6005 126
#define POS128_6005 128
#define POS129_6005 129
#define POS137_6005 137
#define POS143_6005 143
#define POS144_6005 144
#define POS156_6005 156
#define POS161_6005 161
#define POS163_6005 163
#define POS175_6005 175
#define POS187_6005 187
#define POS191_6005 191
#define POS206_6005 206
#define POS218_6005 218
#define POS230_6005 230
#define POS242_6005 242
#define POS254_6005 254
#define POS266_6005 266
#define POS271_6005 271
#define POS283_6005 283
#define POS295_6005 295
#define POS307_6005 307
#define POS319_6005 319
#define POS331_6005 331
#define POS343_6005 343
#define POS355_6005 355
#define POS367_6005 367
#define POS951_6005 951

/* Registro 9000. */

#define POS1_9000 1
#define POS5_9000 5
#define POS8_9000 8
#define POS108_9000 108
#define POS114_9000 114
#define POS117_9000 117
#define POS125_9000 125
#define POS143_9000 143
#define POS161_9000 161
#define POS179_9000 179
#define POS197_9000 197
#define POS215_9000 215
#define POS233_9000 233
#define POS251_9000 251
#define POS269_9000 269
#define POS287_9000 287
#define POS305_9000 305
#define POS323_9000 323
#define POS341_9000 341
#define POS951_9000 951

/* Formatos de Campos. */

/* Cadena. */

#define FMTSTR    "%s"
#define FMTSLONG1 "%1s"

/* Constantes de Cadena. */

/* Genericos. */

#define PREFFIXCCF "CCF"
#define PREFFIXINDNC "NC"
#define PREFFIXIND "IND"

/* Para Registros. */

#define FMTREC0000 "0000"
#define FMTREC1000 "1000"
#define FMTREC1001 "1001"
#define FMTREC2000 "2000"
#define FMTREC2001 "2001"
#define FMTREC5000 "5000"
#define FMTREC6001 "6001"
#define FMTREC6002 "6002"
#define FMTREC6004 "6004"
#define FMTREC6005 "6005"
#define FMTREC9000 "9000"

/* Numericos. */

#define FMTZERO      0
#define FMTZEROFLOAT 0.0
#define FMT100PERC   100.0
#define FMTINT       "%d"
#define FMTFLO       "%f"
#define FMTCUR       "%0.2f"

/* Usos diversos. */

#define ERREXIT -1       /* Salida de aplicacion con estatus de error. */ 
#define STDEXIT 0        /* Salida de aplicacion con exito. */ 
#define DEBUG1  1        /* Para analisis de salidas. */
#define EOLN   '\0'      /* Fin de linea. */
#define EMPSTR "\0"      /* Cadena Vacia. */
#define SPACE " "        /* Cadena con Espacio en Blanco. */
#define SPACEC ' '       /* Espacio en Blanco (caracter). */
#define UNDERSCORE "_"   /* Guion Bajo. */ 
#define NEWLINE "\n"     /* Nueva Linea. */


#ifdef DEBUG1 
#undef DEBUG1 
#endif


/* Macro para deteccion de espacios en blanco. */
 
#define ISWORDSPACE(c) (c == ' ' || c == '\t')


/* Definicion de prototipos de funciones. */

#if defined(__cplusplus)
extern "C" {            
#endif                  
                        
#ifdef _PROTOTYPES      

   void error_handler();
   void warning_handler();
   int  iC430CreateTables_CCF(char *[]);

#else
                                              
   void error_handler();
   void warning_handler();
   int  iC430CreateTables_CCF();

#endif                  
                        
#if defined(__cplusplus)
}                       
#endif
