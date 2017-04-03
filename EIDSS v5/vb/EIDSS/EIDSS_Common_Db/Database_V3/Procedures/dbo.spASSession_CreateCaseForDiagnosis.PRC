SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spASSession_CreateCaseForDiagnosis]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spASSession_CreateCaseForDiagnosis]
GO


 

--##SUMMARY Creates case for specified farm in monitoring session
--##SUMMARY During case creation it 
--##SUMMARY 1. Creates case itslef
--##SUMMARY 2. Links farm (including farm structure tree) to the case
--##SUMMARY 3. Links Animals/samples/tests with positive result to the case
--##REMARKS Author: Zurin M.
--##REMARKS Create date: 02.08.2010

--##RETURNS 0 - if case is created successfully
--##RETURNS 1 - source farm doesn't exists
--##RETURNS 2 - case is already created for this farm and monitoring session
--##RETURNS 3 - user hasn't permissions for create vetcase
/*
--Example of a call of procedure:
DECLARE @idfFarm bigint

EXECUTE spASSession_CreateCaseForDiagnosis 
	@idfFarm
	,@idfCase OUTPUT
Print @idfCase
*/

CREATE            Proc	spASSession_CreateCaseForDiagnosis
		@idfFarm bigint
		,@idfDiagnosis bigint
		,@idfsContolMeasureTemplate bigint
		,@idfCase bigint OUTPUT
As
--TODO insert check that case for this farm and diagnosis was created already
--SELECT @idfCase = idfCase
--from tlbParty 
--	inner join tlbFarm as sourceFarm on 
--		sourceFarm.idfFarm = tlbParty.idfParty
--	inner join tlbFarm as targetFarm on 
--		targetFarm.strFarmCode = sourceFarm.strFarmCode
--WHERE 
--	sourceFarm.idfFarm = @idfFarm 
--	and tlbParty.intRowStatus = 0
--	and 

if not @idfCase is null
 	return 2 -- Case is already created for this farm


-- Create case itself
DECLARE @idfTargetFarm bigint
DECLARE @idfObservation bigint
DECLARE @datEnteredDate datetime
DECLARE @idfsSite bigint
DECLARE @ret int

EXEC spsysGetNewID @idfCase OUTPUT
EXEC spsysGetNewID @idfObservation OUTPUT

SET @datEnteredDate = GETDATE()
SET @idfsSite = dbo.fnSiteID()


EXECUTE @ret = spVetCase_Post 
   @idfCase
  ,NULL --@idfOutbreak
  ,NULL --@idfsCaseStatus
  ,10109001 --in progress @idfsCaseProgressStatus
  ,@idfDiagnosis --@idfsShowDiagnosis
  ,10012003-- @idfsCaseType
  ,@datEnteredDate
  ,NULL --@strCaseID
  ,@idfDiagnosis
  ,NULL --@idfsTentativeDiagnosis1
  ,NULL --@idfsTentativeDiagnosis2
  ,NULL --@idfsFinalDiagnosis
  ,NULL --@idfPersonInvestigatedBy
  ,NULL --@idfPersonEnteredBy
  ,NULL --@idfPersonReportedBy
  ,@idfObservation
  ,@idfsContolMeasureTemplate
  ,@idfsSite
  ,NULL --@datReportDate
  ,NULL --@datAssignedDate
  ,NULL --@datInvestigationDate
  ,NULL --@datTentativeDiagnosisDate
  ,NULL --@datTentativeDiagnosis1Date
  ,NULL --@datTentativeDiagnosis2Date
  ,NULL --@datFinalDiagnosisDate
  ,NULL --@strSampleNotes
  ,NULL --@strTestNotes
  ,NULL --@strSummaryNotes
  ,NULL --@strClinicalNotes
  ,NULL --@strFieldAccessionID

if (@ret = -1)
	begin
		set @idfCase = NULL
	 	return 3 -- User hasn't permissions for create vetcase
	end

--Create farm copy for case
EXECUTE spFarm_CreateCopy
   @idfFarm
  ,@idfTargetFarm OUTPUT
  ,@idfCase
  ,NULL
-- Create farm structure copy
EXECUTE spFarmTree_CreateCopy
   @idfFarm
  ,@idfTargetFarm
  ,@idfCase
  ,NULL
  ,32

return 0


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

