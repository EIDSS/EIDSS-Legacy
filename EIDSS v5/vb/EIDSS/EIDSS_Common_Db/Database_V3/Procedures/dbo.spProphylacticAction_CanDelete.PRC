SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spProphylacticAction_CanDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spProphylacticAction_CanDelete]
GO


--##SUMMARY Checks if Prophylactic Action can be deleted.
--##SUMMARY This procedure is called from MeasureReference Editor.
--##SUMMARY We consider that Prophylactic Action can be deleted if there is no reference to this action from Prophylactic Action Matrix
--##SUMMARY from any other table



--##REMARKS Author: Zurin M.
--##REMARKS Create date: 07.06.2010

--##RETURNS 0 if Prophylactic Action can't be deleted 
--##RETURNS 1 if Prophylactic Action can be deleted 

/*
Example of procedure call:

DECLARE @ID bigint
DECLARE @Result BIT
EXEC spProphylacticAction_CanDelete 1, @Result OUTPUT

Print @Result

*/


CREATE   procedure dbo.spProphylacticAction_CanDelete
	@ID as bigint --##PARAM @ID - farm ID
	,@Result AS BIT OUTPUT --##PARAM  @Result - 0 if case can't be deleted, 1 in other case
as

IF EXISTS(SELECT * from dbo.tlbAggrProphylacticActionMTX  where idfsProphilacticAction = @ID and intRowStatus = 0)
	SET @Result = 0
ELSE
	SET @Result = 1

Return @Result

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

