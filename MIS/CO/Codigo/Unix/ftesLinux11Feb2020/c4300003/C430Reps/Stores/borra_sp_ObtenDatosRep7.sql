IF OBJECT_ID('dbo.sp_ObtenDatosRep7') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.sp_ObtenDatosRep7
    IF OBJECT_ID('dbo.sp_ObtenDatosRep7') IS NOT NULL
        PRINT '<<< FAILED DROPPING PROCEDURE dbo.sp_ObtenDatosRep7 >>>'
    ELSE
        PRINT '<<< DROPPED PROCEDURE dbo.sp_ObtenDatosRep7 >>>'
END
go
