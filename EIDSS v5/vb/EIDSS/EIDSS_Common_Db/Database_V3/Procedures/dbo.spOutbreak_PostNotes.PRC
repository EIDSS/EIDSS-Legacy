SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spOutbreak_PostNotes]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spOutbreak_PostNotes]
GO




--##SUMMARY Posts outbreak cases related with outbreak.
--##SUMMARY Called by OutbreakDetail form.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 25.11.2009

--##RETURNS Doesn't use


/*
--Example of procedure call:

DECLARE @Action int
DECLARE @idfOutbreakNote bigint
DECLARE @idfOutbreak bigint
DECLARE @strNote nvarchar(2000)
DECLARE @datNoteDate datetime
DECLARE @idfPerson bigint


EXECUTE spOutbreak_PostNotes
   @Action
  ,@idfOutbreakNote
  ,@idfOutbreak
  ,@strNote
  ,@datNoteDate
  ,@idfPerson

*/


CREATE    PROCEDURE dbo.spOutbreak_PostNotes
	@Action int, --##PARAM @Action - action to be perfomed: 4 - Added, 8 - Deleted, 16 - Modified
	@idfOutbreakNote bigint OUTPUT, --##PARAM @idfOutbreakNote - outbreak note ID
	@idfOutbreak bigint, --##PARAM @idfOutbreak - outbreak ID
    @strNote nvarchar(2000), --##PARAM @strNote - outbreak note 
    @datNoteDate datetime, --##PARAM @datNoteDate - outbreak note date
    @idfPerson bigint --##PARAM @idfPerson - ID of person that created outbreak note 

as
	IF @Action = 4
	BEGIN
		IF ISNULL(@idfOutbreakNote,0) <=0
			EXEC spsysGetNewID @idfOutbreakNote OUTPUT
		INSERT INTO tlbOutbreakNote
				   (
					idfOutbreakNote
				   ,idfOutbreak
				   ,strNote
				   ,datNoteDate
				   ,idfPerson
					)
			 VALUES
				   (
					@idfOutbreakNote
				   ,@idfOutbreak
				   ,@strNote
				   ,@datNoteDate
				   ,@idfPerson
					)
			END

	IF @Action = 8
	BEGIN
		DELETE FROM tlbOutbreakNote 
		WHERE idfOutbreakNote = @idfOutbreakNote
	END

	IF @Action = 16
	BEGIN
		UPDATE tlbOutbreakNote
		   SET idfOutbreakNote = @idfOutbreakNote
			  ,idfOutbreak = @idfOutbreak
			  ,strNote = @strNote
			  ,datNoteDate = @datNoteDate
			  ,idfPerson = @idfPerson
		 WHERE 
			  idfOutbreakNote = @idfOutbreakNote
	END		



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

