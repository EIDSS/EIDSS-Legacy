SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spOutbreak_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spOutbreak_Post]
GO


--##SUMMARY Posts outbreak data for OutbreakDetail form.
--##SUMMARY Called by OutbreakDetail form.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 25.11.2009

--##RETURNS Doesn't use


/*
--Example of procedure call:

DECLARE @Action int
DECLARE @idfOutbreak bigint
DECLARE @idfsDiagnosis bigint
DECLARE @idfsOutbreakStatus bigint
DECLARE @idfGeoLocation bigint
DECLARE @strOutbreakID nvarchar(200)
DECLARE @datStartDate datetime
DECLARE @datFinishDate datetime
DECLARE @strDescription nvarchar(2000)


EXECUTE spOutbreak_Post
   @Action
  ,@idfOutbreak
  ,@idfsDiagnosis
  ,@idfsOutbreakStatus
  ,@idfGeoLocation
  ,@strOutbreakID OUTPUT
  ,@datStartDate
  ,@datFinishDate
  ,@strDescription

*/



CREATE    PROCEDURE dbo.spOutbreak_Post
	@Action int,  --##PARAM @Action - action to be perfomed: 4 - Added, 8 - Deleted, 16 - Modified
	@idfOutbreak bigint,  --##PARAM @idfOutbreak - outbreak ID
    @idfsDiagnosis bigint, --##PARAM @idfsDiagnosis - outbreak diagnosis (reference to rftDiagnosis = 19000019)
    @idfsOutbreakStatus bigint, --##PARAM @idfsOutbreakStatus - outbreak status (reference to rftOutbreakStatus = 19000063)
    @idfGeoLocation bigint, --##PARAM outbreak location
    @strOutbreakID nvarchar (200) OUTPUT, --##PARAM @strOutbreakID - human readable outbreak code
	@datStartDate datetime, --##PARAM @datStartDate - outbreak start date
	@datFinishDate datetime, --##PARAM @datFinishDate - outbreak finish date
	@strDescription nvarchar (2000) --##PARAM @strDescription - outbreak description
as

	IF @Action = 8
	BEGIN
		exec spOutbreak_Delete @idfOutbreak
	END
	IF @Action = 4 --Added
	BEGIN
		IF ISNULL(@strOutbreakID, N'') = N''
			EXEC dbo.spGetNextNumber 10057015, @strOutbreakID OUTPUT , NULL --N'nbtOutbreak'

		INSERT INTO tlbOutbreak
				   (idfOutbreak
				   ,idfsDiagnosis
				   ,idfsOutbreakStatus
				   ,idfGeoLocation
				   ,strOutbreakID
				   ,datStartDate
				   ,datFinishDate
				   ,strDescription)
			 VALUES
				   (@idfOutbreak
				   ,@idfsDiagnosis
				   ,@idfsOutbreakStatus
				   ,@idfGeoLocation
				   ,@strOutbreakID
				   ,@datStartDate
				   ,@datFinishDate
				   ,@strDescription)
	END
	IF @Action = 16 --Modified
	BEGIN
		UPDATE tlbOutbreak
		   SET 
			   idfsDiagnosis = @idfsDiagnosis
			  ,idfsOutbreakStatus = @idfsOutbreakStatus
			  ,idfGeoLocation = @idfGeoLocation
			  ,strOutbreakID = @strOutbreakID
			  ,datStartDate = @datStartDate
			  ,datFinishDate = @datFinishDate
			  ,strDescription = @strDescription
		 WHERE 
				idfOutbreak = @idfOutbreak
	END
		



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

