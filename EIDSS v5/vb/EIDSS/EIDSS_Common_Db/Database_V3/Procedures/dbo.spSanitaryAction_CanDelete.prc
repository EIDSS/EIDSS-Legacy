SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSanitaryAction_CanDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spSanitaryAction_CanDelete]
GO


--##SUMMARY Checks if Sanitary Action can be deleted.
--##SUMMARY This procedure is called from MeasureReference Editor.
--##SUMMARY We consider that Sanitary Action can be deleted if there is no reference to this action from Sanitary Action Matrix
--##SUMMARY from any other table



--##REMARKS Author: Zurin M.
--##REMARKS Create date: 07.06.2010

--##RETURNS 0 if Sanitary Action can't be deleted 
--##RETURNS 1 if Sanitary Action can be deleted 

/*
Example of procedure call:

DECLARE @ID bigint
DECLARE @Result BIT
EXEC spSanitaryAction_CanDelete 1, @Result OUTPUT

Print @Result

*/


CREATE   procedure dbo.spSanitaryAction_CanDelete
	@ID as bigint --##PARAM @ID - farm ID
	,@Result AS BIT OUTPUT --##PARAM  @Result - 0 if case can't be deleted, 1 in other case
as

IF EXISTS(SELECT * from dbo.tlbAggrMatrixVersion  where varValue = @ID and intRowStatus = 0)
	SET @Result = 0
ELSE
	SET @Result = 1

Return @Result

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

