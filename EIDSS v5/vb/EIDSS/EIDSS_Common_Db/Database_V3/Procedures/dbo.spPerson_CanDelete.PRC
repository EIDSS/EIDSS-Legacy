SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spPerson_CanDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spPerson_CanDelete]
GO


--##SUMMARY Checks if Person object can be deleted.
--##SUMMARY This procedure is called from Persons list.
--##SUMMARY We consider that person can be deleted if there is no reference to this person 
--##SUMMARY from any other table



--##REMARKS Author: Zurin M.
--##REMARKS Create date: 28.05.2010

--##RETURNS 0 if Person can't be deleted 
--##RETURNS 1 if Person can be deleted 

/*
Example of procedure call:

DECLARE @ID bigint
DECLARE @Result BIT
EXEC spPerson_CanDelete 1, @Result OUTPUT

Print @Result

*/


CREATE   procedure dbo.spPerson_CanDelete
	@ID as bigint --##PARAM @ID - farm ID
	,@Result AS BIT OUTPUT --##PARAM  @Result - 0 if case can't be deleted, 1 in other case
as

IF EXISTS(SELECT * from  tlbBatchTest where idfPerformedByPerson = @ID and intRowStatus = 0)
	SET @Result = 0
ELSE IF EXISTS(SELECT * from  tlbBatchTest where idfValidatedByPerson = @ID and intRowStatus = 0)
	SET @Result = 0
ELSE IF EXISTS(SELECT * from  tlbTransferIn where idfReceivedByPerson = @ID and intRowStatus = 0)
	SET @Result = 0
ELSE IF EXISTS(SELECT * from  tlbTransferOut where idfSendByPerson = @ID and intRowStatus = 0)
	SET @Result = 0
ELSE IF EXISTS(SELECT * from  tlbContainer where idfDestroyedByPerson = @ID and intRowStatus = 0)
	SET @Result = 0
ELSE IF EXISTS(SELECT * from  tlbAccessionIn where idfAccesionByPerson = @ID and intRowStatus = 0)
	SET @Result = 0
ELSE IF EXISTS(SELECT * from  tlbTestValidation where (idfValidatedByPerson = @ID OR idfInterpretedByPerson = @ID))
	SET @Result = 0
ELSE IF EXISTS(SELECT * from  tlbMaterial where idfFieldCollectedByPerson = @ID and intRowStatus = 0)
	SET @Result = 0
ELSE IF EXISTS(SELECT * from  tlbVetCase where (idfPersonEnteredBy = @ID OR idfPersonReportedBy = @ID OR idfPersonInvestigatedBy = @ID))
	SET @Result = 0
ELSE IF EXISTS(SELECT * from  tlbVetCaseLog where idfPerson = @ID and intRowStatus = 0)
	SET @Result = 0
ELSE IF EXISTS(SELECT * from  tstUserTable where idfPerson = @ID and intRowStatus = 0)
	SET @Result = 0
ELSE IF EXISTS(SELECT * from  tlbAggrCase where (idfReceivedByPerson = @ID OR idfSentByPerson = @ID OR idfEnteredByPerson = @ID) and intRowStatus = 0)
	SET @Result = 0
ELSE
	SET @Result = 1

Return @Result

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

