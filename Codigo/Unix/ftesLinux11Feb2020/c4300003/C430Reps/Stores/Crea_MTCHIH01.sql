use M111
go

CREATE TABLE dbo.MTCHIH01(
    eje_prefijo            smallint        NOT NULL,
    gpo_banco              smallint        NOT NULL,
    emp_num                int             NOT NULL,
    eje_num                int             NOT NULL,
    eje_roll_over          tinyint         NOT NULL,
    eje_digit              tinyint         NOT NULL,
    his_valor_amd          int             NOT NULL,
    hih_corte_a            smallint        NOT NULL,
    hih_corte_md           smallint        NOT NULL,
    hih_proceso_amd        int             NOT NULL,
    hih_num_compras        smallint        NOT NULL,
    hih_num_disp           smallint        NOT NULL,
    hih_saldo_anterior     float           NOT NULL,
    hih_pagos_y_abonos     float           NOT NULL,
    hih_filler2            char(3)         NOT NULL,
    hih_compras_y_disp     float           NOT NULL,
    hih_filler3            char(4)         NOT NULL,
    hih_tipo_reg           char(1)         NOT NULL,
    hih_situacion_cuenta   char(1)         NOT NULL,
    hih_comisiones         float           NOT NULL,
    hih_intereses          float           NOT NULL,
    hih_saldo_prom_com     int             NOT NULL,
    hih_filler4            char(15)        NOT NULL,
    hih_num_meses_vencidos smallint        NOT NULL,
    hih_num_movs_ent       float           NOT NULL,
    hih_pago_tot           smallint        NOT NULL,
    hih_filler5            char(1)         NOT NULL)
go
IF OBJECT_ID('dbo.MTCHIH01') IS NOT NULL
    PRINT '<<< CREATED TABLE dbo.MTCHIH01 >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE dbo.MTCHIH01 >>>'
go
/*
 * Creating Indexes for Table dbo.MTCHIH01
 */



CREATE CLUSTERED INDEX XIF18MTCHIH01
    ON dbo.MTCHIH01(eje_prefijo,gpo_banco,emp_num,eje_num) 
go
IF OBJECT_ID('dbo.XIF18MTCHIH01') IS NOT NULL
    PRINT '<<< CREATED INDEX dbo.XIF18MTCHIH01>>>'
ELSE
    PRINT '<<< FAILED CREATING INDEX dbo.XIF18MTCHIH01>>>'
go


