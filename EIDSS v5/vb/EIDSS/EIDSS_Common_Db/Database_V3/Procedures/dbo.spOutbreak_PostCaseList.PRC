SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spOutbreak_PostCaseList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spOutbreak_PostCaseList]
GO




--##SUMMARY Posts outbreak cases related with outbreak.
--##SUMMARY Called by OutbreakDetail form.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 25.11.2009

--##RETURNS Doesn't use


/*
--Example of procedure call:

DECLARE @Action int
DECLARE @idfOutbreak bigint
DECLARE @idfCase bigint

EXECUTE spOutbreak_PostCaseList
   @Action
  ,@idfOutbreak
  ,@idfCase

*/


CREATE    PROCEDURE dbo.spOutbreak_PostCaseList
	@Action int, --##PARAM @Action - action to be perfomed: 4 - Added, 8 - Deleted, 16 - Modified
	@idfOutbreak bigint, --##PARAM @idfOutbreak - outbreak ID
    @idfCase bigint --##PARAM @idfCase - ID of case related with outbreak
as

	IF @Action = 8 
	BEGIN
		--at the moment of deletion case can be moved to other outbreak in many ways, so we need this check to avoid deletion error
		IF EXISTS( SELECT * FROM tlbCase WHERE idfOutbreak = @idfOutbreak and idfCase = @idfCase)		
		BEGIN
			update dbo.tlbHumanCase
			set idfsYNRelatedToOutbreak = null
			WHERE 
				idfHumanCase = @idfCase

			update tlbCase
			set idfOutbreak = null
			WHERE 
				idfOutbreak = @idfOutbreak
				and idfCase = @idfCase

		END

	END
	ELSE IF NOT EXISTS( SELECT * FROM tlbCase WHERE idfOutbreak = @idfOutbreak and idfCase = @idfCase)
	BEGIN
--		DECLARE @oldCaseID bigint
--		SELECT TOP 1 @oldCaseID=idfCase FROM tlbCase WHERE idfOutbreak = @idfOutbreak and idfCase <> @idfCase and intRowStatus=0
--		if NOT @oldCaseID IS NULL
--			EXEC spOutbreak_PostCaseList 8, @idfOutbreak, @oldCaseID
		update tlbCase
		set idfOutbreak = @idfOutbreak
		WHERE 
			idfCase = @idfCase

		update dbo.tlbHumanCase
		set idfsYNRelatedToOutbreak = 10100001
		WHERE 
			idfHumanCase = @idfCase
	END
		



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

