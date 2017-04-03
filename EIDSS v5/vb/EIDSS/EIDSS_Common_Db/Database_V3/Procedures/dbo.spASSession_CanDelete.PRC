SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spASSession_CanDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spASSession_CanDelete]
GO


--##SUMMARY Checks if Session object can be deleted.
--##SUMMARY This procedure is called from AS Sessions list.
--##SUMMARY We consider that session can be deleted if there no samples this session.


--##REMARKS Author: Zurin M.
--##REMARKS Create date: 11.06.2010

--##RETURNS 0 if session can't be deleted 
--##RETURNS 1 if session can be deleted 

/*
Example of procedure call:

DECLARE @ID bigint
DECLARE @Result BIT
EXEC spASSession_CanDelete @ID, @Result OUTPUT

Print @Result

*/


CREATE   procedure dbo.spASSession_CanDelete
	@ID as bigint --##PARAM @ID - farm ID
	,@Result AS BIT OUTPUT --##PARAM  @Result - 0 if session can't be deleted, 1 in other case
as

IF EXISTS(
SELECT idfAnimal
FROM tlbAnimal
	Inner Join tlbParty animalParty on 
		animalParty.idfParty = tlbAnimal.idfAnimal and animalParty.intRowStatus=0
	Inner Join tlbMaterial ON 
		tlbMaterial.idfParty = tlbAnimal.idfAnimal and tlbMaterial.intRowStatus=0
	WHERE
		animalParty.idfMonitoringSession = @ID
	)
	SET @Result = 0
ELSE
	SET @Result = 1

Return @Result

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

