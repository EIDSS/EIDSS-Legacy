DECLARE @idfVersion bigint
DECLARE @idfsDiagnosis bigint
DECLARE @dt datetime
SET @dt = GETDATE()
DECLARE @idfHumanCaseMtx bigint
DECLARE @idfDiagnosisRow bigint
DECLARE @idfIDCCodeRow bigint
DECLARE @idfAggrVetCaseMTX bigint
DECLARE @idfSpeciesRow bigint
DECLARE @idfOIECodeRow bigint

if NOT EXISTS (SELECT * from dbo.tlbAggrMatrixVersionHeader where idfsAggrCaseSection = 71190000000 and blnIsActive = 1 and intRowStatus = 0)
BEGIN
	SELECT TOP 1 @idfsDiagnosis = idfsDiagnosis FROM dbo.trtDiagnosis
	inner join dbo.fnReference('en',19000019) ON 
		dbo.fnReference.idfsReference = idfsDiagnosis
	WHERE 
		idfsUsingType = 10020002 AND 
		(dbo.fnReference.intHACode & 2 > 0)

	EXEC spsysGetNewID @idfVersion OUTPUT 
	EXECUTE spAggregateMatrixVersionHeader_Post 
	   4
	  ,@idfVersion
	  ,71190000000
	  ,'Human matrix'
	  ,@dt
	  ,1


	EXECUTE spAggregateHumanCaseMatrix_Post 
	   4
	  ,@idfHumanCaseMtx OUTPUT
	  ,@idfVersion
	  ,@idfDiagnosisRow OUTPUT
	  ,@idfsDiagnosis
	  ,@idfIDCCodeRow OUTPUT
	  ,0

	EXECUTE spAggregateHumanCaseMatrix_SelectDetail 
END

--Vet Case matrix
if NOT EXISTS (SELECT * from dbo.tlbAggrMatrixVersionHeader where idfsAggrCaseSection = 71090000000 and blnIsActive = 1 and intRowStatus = 0)
BEGIN

	SELECT TOP 1 @idfsDiagnosis = idfsDiagnosis FROM dbo.trtDiagnosis
	inner join dbo.fnReference('en',19000019) ON 
		dbo.fnReference.idfsReference = idfsDiagnosis
	WHERE 
		idfsUsingType = 10020002 AND 
		(dbo.fnReference.intHACode & 96 > 0)

	EXEC spsysGetNewID @idfVersion OUTPUT 
	EXECUTE spAggregateMatrixVersionHeader_Post 
	   4
	  ,@idfVersion
	  ,71090000000
	  ,'Vet matrix'
	  ,@dt
	  ,1


	EXECUTE spAggregateVetCaseMatrix_Post
	   4
	  ,@idfAggrVetCaseMTX OUTPUT
	  ,@idfSpeciesRow OUTPUT
	  ,39170000000
	  ,@idfDiagnosisRow OUTPUT
	  ,@idfOIECodeRow OUTPUT
	  ,@idfsDiagnosis
	  ,@idfVersion
	  ,0
END

--Diagnostic matrix
if NOT EXISTS (SELECT * from dbo.tlbAggrMatrixVersionHeader where idfsAggrCaseSection = 71460000000 and blnIsActive = 1 and intRowStatus = 0)
BEGIN

	SELECT TOP 1 @idfsDiagnosis = idfsDiagnosis FROM dbo.trtDiagnosis
	inner join dbo.fnReference('en',19000019) ON 
		dbo.fnReference.idfsReference = idfsDiagnosis
	WHERE 
		idfsUsingType = 10020002 AND 
		(dbo.fnReference.intHACode & 96 > 0)

	EXEC spsysGetNewID @idfVersion OUTPUT 
	EXECUTE spAggregateMatrixVersionHeader_Post 
	   4
	  ,@idfVersion
	  ,71460000000
	  ,'Diagnostic matrix'
	  ,@dt
	  ,1

	DECLARE @idfAggrDiagnosticActionMTX bigint
	DECLARE @idfDiagnosticActionRow bigint

	EXECUTE spAggregateDiagnosticActionMatrix_Post
	   4
	  ,@idfAggrDiagnosticActionMTX OUTPUT
	  ,@idfSpeciesRow OUTPUT
	  ,39170000000
	  ,@idfDiagnosisRow OUTPUT
	  ,@idfsDiagnosis
	  ,@idfOIECodeRow OUTPUT
	  ,@idfDiagnosticActionRow OUTPUT
	  ,2650000000
	  ,@idfVersion
	  ,0
END
