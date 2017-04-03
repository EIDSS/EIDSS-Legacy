SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spFarm_CanDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spFarm_CanDelete]
GO


--##SUMMARY Checks if Farm object can be deleted.
--##SUMMARY This procedure is called from farms list and thus can be applied to the root farms only.
--##SUMMARY We consider that farm can be deleted if there no child farms related to the case, i. e if farm is created directly from farms list
--##SUMMARY and no cases refer to this farm.


--##REMARKS Author: Zurin M.
--##REMARKS Create date: 15.11.2009

--##RETURNS 0 if farm can't be deleted 
--##RETURNS 1 if farm can be deleted 

/*
Example of procedure call:

DECLARE @ID bigint
DECLARE @Result BIT
EXEC spFarm_CanDelete @ID, @Result OUTPUT

Print @Result

*/


CREATE   procedure dbo.spFarm_CanDelete
	@ID as bigint --##PARAM @ID - farm ID
	,@Result AS BIT OUTPUT --##PARAM  @Result - 0 if case can't be deleted, 1 in other case
as

IF EXISTS(SELECT idfParty from  tlbParty where idfRootParty = @ID and intRowStatus = 0)
	SET @Result = 0
ELSE
	SET @Result = 1

Return @Result

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

