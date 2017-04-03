SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spDiagnosis_CanClearHACode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spDiagnosis_CanClearHACode]
GO


--##SUMMARY Checks if diagnosis HACode can be cleared.
--##SUMMARY This procedure is called from Clinical Diagnosis Editor.
--##SUMMARY We consider that HACode can be cleared if there is no reference to this 
--##SUMMARY Diagnosis from next tables:
--##SUMMARY tlbHumanCase
--##SUMMARY tlbVetCase
--##SUMMARY tlbCase
--##SUMMARY tlbAggrMatrixVersion
--##SUMMARY tlbAggrProphylacticActionMTX
--##SUMMARY tlbAggrDiagnosticActionMTX
--##SUMMARY tlbAggrVetCaseMTX



--##REMARKS Author: Zurin M.
--##REMARKS Create date: 29.10.2010

--##RETURNS 0 if diagnosis HACode can't be cleared 
--##RETURNS 1 if diagnosis HACode can be cleared

/*
Example of procedure call:

DECLARE @ID bigint
DECLARE @Result BIT
EXEC spDiagnosis_CanClearHACode 1, 2, @Result OUTPUT

Print @Result

*/


CREATE   procedure dbo.spDiagnosis_CanClearHACode
	@ID as bigint --##PARAM @ID - diagnosis ID
	,@HACodeFlag as int --##PARAM @HACodeFlag - HACode (representing single item in enumeration) that should be tested
	,@Result AS BIT OUTPUT --##PARAM  @Result - 0 if case can't be deleted, 1 in other case
as
IF @ID IS NULL 
BEGIN
		SET @Result = 1
		Return @Result
END
IF @HACodeFlag = 2 AND EXISTS(
		SELECT * from dbo.tlbHumanCase 
		INNER JOIN tlbCase ON
			tlbHumanCase.idfHumanCase = tlbCase.idfCase
			and tlbCase.intRowStatus=0
		where  idfsFinalDiagnosis= @ID or idfsTentativeDiagnosis = @ID )
	SET @Result = 0
ELSE IF @HACodeFlag = 32 AND EXISTS(
		SELECT * from dbo.tlbVetCase  
		INNER JOIN tlbCase ON
			tlbVetCase.idfVetCase = tlbCase.idfCase
			and tlbCase.intRowStatus=0
		where  
			(idfsFinalDiagnosis= @ID 
			or idfsTentativeDiagnosis = @ID  
			or idfsTentativeDiagnosis1 = @ID 
			or idfsTentativeDiagnosis2 = @ID
			or tlbCase.idfsShowDiagnosis= @ID) 
			and tlbCase.idfsCaseType = 10012003)--livestock cases
	SET @Result = 0
ELSE IF @HACodeFlag = 64 AND EXISTS(
		SELECT * from dbo.tlbVetCase  
		INNER JOIN tlbCase ON
			tlbVetCase.idfVetCase = tlbCase.idfCase
			and tlbCase.intRowStatus=0
		where  
			(idfsFinalDiagnosis= @ID 
			or idfsTentativeDiagnosis = @ID  
			or idfsTentativeDiagnosis1 = @ID 
			or idfsTentativeDiagnosis2 = @ID
			or tlbCase.idfsShowDiagnosis= @ID) 
			and tlbCase.idfsCaseType = 10012004)--avian cases
	SET @Result = 0

ELSE IF  @HACodeFlag = 2 AND EXISTS(SELECT * from dbo.tlbCase  where  idfsShowDiagnosis= @ID and intRowStatus = 0 and tlbCase.idfsCaseType = 10012001)--human cases
	SET @Result = 0
ELSE IF (@HACodeFlag & 96)<>0 AND EXISTS(SELECT * from dbo.tlbAggrDiagnosticActionMTX  where  idfsDiagnosis= @ID and intRowStatus = 0)
	SET @Result = 0
ELSE IF (@HACodeFlag & 96)<>0 AND EXISTS(SELECT * from dbo.tlbAggrProphylacticActionMTX  where  idfsDiagnosis= @ID and intRowStatus = 0)
	SET @Result = 0
ELSE IF (@HACodeFlag & 96)<>0 AND EXISTS(SELECT * from dbo.tlbAggrVetCaseMTX  where  idfsDiagnosis= @ID and intRowStatus = 0)
	SET @Result = 0
ELSE IF @HACodeFlag = 2 AND EXISTS(SELECT * from dbo.tlbAggrMatrixVersion  
				INNER JOIN dbo.tlbAggrMatrixVersionHeader
				ON tlbAggrMatrixVersion.idfAggrMatrixVersion = tlbAggrMatrixVersionHeader.idfVersion
				where  varValue= @ID
				AND tlbAggrMatrixVersion.intRowStatus = 0 
				AND tlbAggrMatrixVersionHeader.intRowStatus = 0
				AND  tlbAggrMatrixVersionHeader.idfsAggrCaseSection = 71190000000 --human case 
			)
	SET @Result = 0
ELSE IF @HACodeFlag <> 2 AND EXISTS(SELECT * from dbo.tlbAggrMatrixVersion  
				INNER JOIN dbo.tlbAggrMatrixVersionHeader
				ON tlbAggrMatrixVersion.idfAggrMatrixVersion = tlbAggrMatrixVersionHeader.idfVersion
				where  varValue= @ID
				AND tlbAggrMatrixVersion.intRowStatus = 0 
				AND tlbAggrMatrixVersionHeader.intRowStatus = 0
				AND  tlbAggrMatrixVersionHeader.idfsAggrCaseSection <> 71190000000 --human case 
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

