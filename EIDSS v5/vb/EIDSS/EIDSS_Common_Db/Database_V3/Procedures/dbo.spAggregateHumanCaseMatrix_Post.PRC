SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAggregateHumanCaseMatrix_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAggregateHumanCaseMatrix_Post]
GO


--##SUMMARY Posts data from AggregateHumanCaseMTXDetail form
--##SUMMARY All matrix posting procedures work using next rules:
--##SUMMARY - the record is never deleted from matrix table itself, deletion is perfomed in the matrix version table only
--##SUMMARY - the record is never updated in the matrix table itself, update is performed in the matrix version table only
--##SUMMARY - before any operation on the posted row we check if matrix row with posted natural keys exists and reset matrix row key
--##SUMMARY - to existing value if needed. Thus matrix row key uniquely identifies the value of natural matrix primary key.
--##SUMMARY - New record is inserted to root matix table only if there is no record with such primary key.
--##SUMMARY - The names of generic primary key fields for specific matrix version parameters must end with "Row" suffix (this assumption is used in the client application).
--##SUMMARY - We consider tlbDiagnosis table as Human Case matrix table.
--##SUMMARY - Human Case matrix uses the next natural keys - Diagnosis.
--##SUMMARY - All diagnosis are exists already in matrix table, so we should just update matrix version table.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 11.02.2010

--##RETURNS Doesn't use



/*
--Example of procedure call:

DECLARE @Action int
DECLARE @idfsDiagnosis bigint
DECLARE @idfVersion bigint
DECLARE @intNumRow bigint


EXECUTE spAggregateHumanCaseMatrix_Post
   @Action
  ,@idfsDiagnosis
  ,@idfVersion
  ,@intNumRow

*/


CREATE       procedure dbo.spAggregateHumanCaseMatrix_Post(
			 @Action INT  --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
			,@idfHumanCaseMtx BIGINT OUTPUT--##PARAM @idfsDiagnosis - diagnosis
			,@idfVersion BIGINT --##PARAM @idfVersion - matrix version
			,@idfDiagnosisRow BIGINT OUTPUT --##PARAM @idfDiagnosisRow- generic primary key for diagnosis parameter
			,@idfsDiagnosis BIGINT --##PARAM @idfsDiagnosis - diagnosis
			,@idfIDCCodeRow BIGINT OUTPUT --##PARAM @idfIDCCodeRow - generic primary key for diagnosis code parameter
			,@intNumRow BIGINT --##PARAM @intNumRow - row number inside matrix version
)
as
/*
				@idfsParameterDiagnosis0 = 226890000000
				,@idfsParameterICD10Code0 = 229630000000
*/
SET @idfHumanCaseMtx = @idfsDiagnosis
EXECUTE spAggregateMatrixVersion_Post
   @Action
  ,@idfDiagnosisRow OUTPUT
  ,@idfVersion
  ,@idfsDiagnosis
  ,226890000000 --Disease
  ,@idfsDiagnosis
  ,@intNumRow
  ,0

IF @Action = 8 -- Delete
	RETURN --we delete all matrix columns duirng first spAggregateMatrixVersion_Post call,so we don't need to call it again

DECLARE @IDCCode NVARCHAR(200)
SELECT @IDCCode = strIDC10 FROM trtDiagnosis WHERE idfsDiagnosis = @idfsDiagnosis
EXECUTE spAggregateMatrixVersion_Post
   @Action
  ,@idfIDCCodeRow OUTPUT
  ,@idfVersion
  ,@idfsDiagnosis
  ,229630000000 --IDC10Code
  ,@IDCCode
  ,@intNumRow
  ,1



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

