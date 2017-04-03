SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAggregateDiagnosticActionMatrix_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAggregateDiagnosticActionMatrix_Post]
GO


--##SUMMARY Posts data from AggregateDiagnosticActionMTXDetail form
--##SUMMARY All matrix posting procedures work using next rules:
--##SUMMARY - the record is never deleted from matrix table itself, deletion is perfomed in the matrix version table only
--##SUMMARY - the record is never updated in the matrix table itself, update is performed in the matrix version table only
--##SUMMARY - before any operation on the posted row we check if matrix row with posted natural keys exists and reset matrix row key
--##SUMMARY - to existing value if needed. Thus matrix row key uniquely identifies the value of natural matrix primary key.
--##SUMMARY - New record is inserted to root matix table only if there is no record with such primary key.
--##SUMMARY - The names of generic primary key fields for specific matrix version parameters must end with "Row" suffix (this assumption is used in the client application).
--##SUMMARY - Diagnostic Action matrix uses the next natural keys - Diagnosis, SpeciesType, DiagnosisAction.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 05.12.2009

--##RETURNS Doesn't use



/*
--Example of procedure call:

EXECUTE spAggregateDiagnosticActionMatrix_Post 

*/


CREATE       procedure dbo.spAggregateDiagnosticActionMatrix_Post(
			 @Action INT  --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
			,@idfAggrDiagnosticActionMTX BIGINT OUTPUT --##PARAM @idfAggrDiagnosticActionMTX  - record ID
			,@idfSpeciesRow BIGINT OUTPUT   --##PARAM @idfSpeciesRow - generic primary key for species parameter
			,@idfsSpeciesType BIGINT   --##PARAM @idfsSpeciesType - species type
			,@idfDiagnosisRow BIGINT OUTPUT --##PARAM @idfDiagnosisRow- generic primary key for diagnosis parameter
			,@idfsDiagnosis BIGINT --##PARAM @idfsDiagnosis - diagnosis
			,@idfOIECodeRow BIGINT OUTPUT --##PARAM @idfOIECodeRow - generic primary key for diagnosis code parameter
			,@idfDiagnosticActionRow BIGINT OUTPUT --##PARAM @idfDiagnosticActionRow - generic primary key for diagnostic action parameter
			,@idfsDiagnosticAction BIGINT --##PARAM @idfsDiagnosticAction - diagnostic action
			,@idfVersion BIGINT --##PARAM @idfVersion - matrix version
			,@intNumRow BIGINT --##PARAM @intNumRow - row number inside matrix version
)
as

--Check if record with passed natural key exists already
DECLARE @idfRow bigint

SELECT @idfRow = idfAggrDiagnosticActionMTX 
FROM tlbAggrDiagnosticActionMTX 
WHERE 
	idfsSpeciesType = @idfsSpeciesType
	AND idfsDiagnosis = @idfsDiagnosis
	AND idfsDiagnosticAction = @idfsDiagnosticAction
	AND intRowStatus = 0
--if record exists reset matrix primary key to set correspondence between matrix generic primary key and natural primary key key
IF NOT @idfRow IS NULL
	SET @idfAggrDiagnosticActionMTX = @idfRow

--Insert new record to matrix if it doesn't exist
IF @Action = 4
BEGIN
	if ISNULL(@idfAggrDiagnosticActionMTX,-1)<0
		EXEC spsysGetNewID @idfAggrDiagnosticActionMTX OUTPUT
	IF (NOT EXISTS (SELECT * FROM tlbAggrDiagnosticActionMTX WHERE idfAggrDiagnosticActionMTX = @idfAggrDiagnosticActionMTX))
		INSERT INTO tlbAggrDiagnosticActionMTX
			(
				idfAggrDiagnosticActionMTX
				,idfsSpeciesType
				,idfsDiagnosis
				,idfsDiagnosticAction
			)
		VALUES
			(
				@idfAggrDiagnosticActionMTX
				,@idfsSpeciesType
				,@idfsDiagnosis
				,@idfsDiagnosticAction
			)
END
--We never delete the matrix row itself, only its version shoudl be deleted
--Update also has no sence because we only insert absent matrix key sequence values and never delete the old one.

/*
				,@idfsParameterInvestigationType2 = 231670000000
				,@idfsParameterSpecies2 = 239030000000
				,@idfsParameterDisease2 = 226930000000
				,@idfsParameterOIECode2 = 234430000000
*/


--Post Matrix parameters
EXECUTE spAggregateMatrixVersion_Post
   @Action
  ,@idfDiagnosisRow OUTPUT
  ,@idfVersion
  ,@idfAggrDiagnosticActionMTX
  ,226930000000 --Disease
  ,@idfsDiagnosis
  ,@intNumRow
  ,0 

IF @Action = 8 -- Delete
	RETURN --we delete all matrix columns duirng first spAggregateMatrixVersion_Post call,so we don't need to call it again

DECLARE @OIECode NVARCHAR(200)
SELECT @OIECode = strOIECode FROM trtDiagnosis WHERE idfsDiagnosis = @idfsDiagnosis

EXECUTE spAggregateMatrixVersion_Post
   @Action
  ,@idfOIECodeRow OUTPUT
  ,@idfVersion
  ,@idfAggrDiagnosticActionMTX
  ,234430000000 --OIEcode
  ,@OIECode
  ,@intNumRow
  ,1

EXECUTE spAggregateMatrixVersion_Post
   @Action
  ,@idfSpeciesRow OUTPUT
  ,@idfVersion
  ,@idfAggrDiagnosticActionMTX
  ,239030000000 --Species
  ,@idfsSpeciesType
  ,@intNumRow
  ,2

EXECUTE spAggregateMatrixVersion_Post
   @Action
  ,@idfDiagnosticActionRow OUTPUT
  ,@idfVersion
  ,@idfAggrDiagnosticActionMTX
  ,231670000000 --Diagnostic action type
  ,@idfsDiagnosticAction
  ,@intNumRow
  ,3

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

