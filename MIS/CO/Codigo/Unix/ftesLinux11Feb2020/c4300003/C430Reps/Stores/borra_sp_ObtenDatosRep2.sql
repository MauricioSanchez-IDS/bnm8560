IF OBJECT_ID('dbo.sp_ObtenDatosRep2') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.sp_ObtenDatosRep2
    IF OBJECT_ID('dbo.sp_ObtenDatosRep2') IS NOT NULL
        PRINT '<<< FAILED DROPPING PROCEDURE dbo.sp_ObtenDatosRep2 >>>'
    ELSE
        PRINT '<<< DROPPED PROCEDURE dbo.sp_ObtenDatosRep2 >>>'
END
go

