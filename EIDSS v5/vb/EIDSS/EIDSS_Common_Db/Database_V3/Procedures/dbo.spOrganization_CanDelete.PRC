SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spOrganization_CanDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spOrganization_CanDelete]
GO

--##SUMMARY Checks if organization record can be deleted. Called before record deleting

--##REMARKS Author: Zurin M.
--##REMARKS Update date: 19.01.2010

--##RETURNS Doesn't use

/*
--Example of procedure call:
DECLARE @ID AS BIGINT
DECLARE @Result AS INT
SET @ID = 758210000000
exec dbo.spOrganization_CanDelete @ID, @Result Output

Print @Result
*/

CREATE            PROCEDURE dbo.spOrganization_CanDelete( 
	@ID AS BIGINT,--##PARAM @ID - organization ID
	@Result AS BIT OUTPUT --##PARAM @Result - 0 if record can't be deleted, 1 in other case
)
AS

-- If Organization belongs to any EIDSS Site it's forbidden to delete it

IF Exists
(
select * from tstSite 
 where intRowStatus = 0
  and idfOffice=@ID
)
begin	
  SET @Result=0
end
  -- It's forbidden to delete organization if there are persons related with this organization
ELSE IF Exists
	(
	  select * from 
			tlbPerson
		inner join
			tlbEmployee
		on	tlbEmployee.idfEmployee = tlbPerson.idfPerson
			and tlbEmployee.intRowStatus = 0
	  where tlbPerson.idfInstitution=@ID
	)
   begin
     SET @Result=0
   end
   ELSE IF Exists
	(
	  select * from 
			tlbContainer
		inner join
			tlbOffice Department
		on	Department.idfOffice = tlbContainer.idfInDepartment
			and Department.intRowStatus = 0
		inner join
			tlbOffice Organization
		on	Department.idfOffice = Organization.idfOffice
			and Organization.intRowStatus = 0
	  where Organization.idfOffice=@ID
		and tlbContainer.intRowStatus = 0
	)
   begin
     SET @Result=0
   end
   ELSE IF Exists
	(
	  select * from 
			tlbTestValidation
		inner join
			tlbOffice
		on	tlbOffice.idfOffice = tlbTestValidation.idfValidatedByOffice
			and tlbOffice.intRowStatus = 0
	  where tlbTestValidation.idfValidatedByOffice=@ID
		and tlbTestValidation.intRowStatus = 0
	)
   begin
     SET @Result=0
   end
   ELSE IF Exists
	(
	  select * from 
			tlbTestValidation
		inner join
			tlbOffice
		on	tlbOffice.idfOffice = tlbTestValidation.idfInterpretedByOffice
			and tlbOffice.intRowStatus = 0
	  where tlbTestValidation.idfInterpretedByOffice=@ID
		and tlbTestValidation.intRowStatus = 0
	)
   begin
     SET @Result=0
   end

   ELSE IF Exists
	(
	  select * from 
			tlbExtBatchTest
		inner join
			tlbOffice
		on	tlbOffice.idfOffice = tlbExtBatchTest.idfPerformedByOffice
			and tlbOffice.intRowStatus = 0
	  where tlbExtBatchTest.idfPerformedByOffice=@ID
		and tlbExtBatchTest.intRowStatus = 0
	)
   begin
     SET @Result=0
   end

   ELSE IF Exists
	(
	  select * from 
			tlbTransferOUT
		inner join
			tlbOffice
		on	(tlbOffice.idfOffice = tlbTransferOUT.idfSendToOffice
			or tlbOffice.idfOffice = tlbTransferOUT.idfSendFromOffice)
			and tlbOffice.intRowStatus = 0
	  where tlbOffice.idfOffice=@ID
		and tlbTransferOUT.intRowStatus = 0
	)
   begin
     SET @Result=0
   end

   ELSE IF Exists
	(
	  select * from 
			tlbHumanCase
		inner join tlbCase
		on tlbCase.idfCase = tlbHumanCase.idfHumanCase
		inner join
			tlbOffice
		on	(tlbOffice.idfOffice = tlbHumanCase.idfReceivedByOffice
			or tlbOffice.idfOffice = tlbHumanCase.idfInvestigatedByOffice
			or tlbOffice.idfOffice = tlbHumanCase.idfSentByOffice)
			and tlbOffice.intRowStatus = 0
	  where tlbOffice.idfOffice=@ID
		and tlbCase.intRowStatus = 0
	)
   begin
     SET @Result=0
   end
   ELSE IF Exists
	(
	  select * from 
			tlbMaterial
		inner join
			tlbOffice
		on	tlbOffice.idfOffice = tlbMaterial.idfFieldCollectedByOffice
			and tlbOffice.intRowStatus = 0
	  where tlbOffice.idfOffice=@ID
		and tlbMaterial.intRowStatus = 0
	)
   begin
     SET @Result=0
   end

   ELSE IF Exists
	(
	  select * from 
			tlbAggrCase
		inner join
			tlbOffice
		on	(tlbOffice.idfOffice = tlbAggrCase.idfSentByOffice
			or tlbOffice.idfOffice = tlbAggrCase.idfEnteredByOffice
			or tlbOffice.idfOffice = tlbAggrCase.idfReceivedByOffice)
			and tlbOffice.intRowStatus = 0
	  where tlbOffice.idfOffice=@ID
		and tlbAggrCase.intRowStatus = 0
	)
   begin
     SET @Result=0
   end
   ELSE IF Exists
	(
	  select * from 
			tstSite
		inner join
			tlbOffice
		on	tlbOffice.idfOffice = tstSite.idfOffice
			and tlbOffice.intRowStatus = 0
	  where tlbOffice.idfOffice=@ID
		and tstSite.intRowStatus = 0
	)
   begin
     SET @Result=0
   end
   ELSE IF Exists
	(
	  select * from 
			tlbBatchTest
		inner join
			tlbOffice
		on	(tlbOffice.idfOffice = tlbBatchTest.idfPerformedByOffice
			or tlbOffice.idfOffice = tlbBatchTest.idfValidatedByOffice)
			and tlbOffice.intRowStatus = 0
	  where tlbOffice.idfOffice=@ID
		and tlbBatchTest.intRowStatus = 0
	)
   begin
     SET @Result=0
   end
	ELSE
	BEGIN
		SET @Result=1
	END

Return @Result



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

