SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spStatistic_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spStatistic_Delete]
GO




--##SUMMARY Deletes statistic record

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 26.11.2009

--##RETURNS Doesn't use

/*
--Example of procedure call:

DECLARE @idfStatistic BIGINT
EXECUTE spStatistic_Delete @idfStatistic

*/

CREATE                 PROCEDURE dbo.spStatistic_Delete(
	@ID AS NVARCHAR(50)
)
AS

DELETE FROM tlbStatistic
WHERE idfStatistic = @ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

