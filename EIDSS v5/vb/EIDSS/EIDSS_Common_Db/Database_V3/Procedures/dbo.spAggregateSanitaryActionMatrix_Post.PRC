SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAggregateSanitaryActionMatrix_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAggregateSanitaryActionMatrix_Post]
GO


--##SUMMARY Posts data from AggregateSanitaryActionMTXDetail form
--##SUMMARY All matrix posting procedures work using next rules:
--##SUMMARY - the record is never deleted from matrix table itself, deletion is perfomed in the matrix version table only
--##SUMMARY - the record is never updated in the matrix table itself, update is performed in the matrix version table only
--##SUMMARY - before any operation on the posted row we check if matrix row with posted natural keys exists and reset matrix row key
--##SUMMARY - to existing value if needed. Thus matrix row key uniquely identifies the value of natural matrix primary key.
--##SUMMARY - New record is inserted to root matix table only if there is no record with such primary key.
--##SUMMARY - The names of generic primary key fields for specific matrix version parameters must end with "Row" suffix (this assumption is used in the client application).
--##SUMMARY - Sanitary Action matrix uses the next natural keys - SanitryAction.


--##REMARKS Author: Zurin M.
--##REMARKS Create date: 15.02.2010

--##RETURNS Doesn't use



/*
--Example of procedure call:

DECLARE @Action int
DECLARE @idfsDiagnosis bigint
DECLARE @idfVersion bigint
DECLARE @intNumRow bigint


EXECUTE spAggregateSanitaryActionMatrix_Post
   @Action
  ,@idfsDiagnosis
  ,@idfVersion
  ,@intNumRow

*/


CREATE       procedure dbo.spAggregateSanitaryActionMatrix_Post(
			 @Action INT  --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
			,@idfSanitaryActionMTX BIGINT OUTPUT   --##PARAM @idfSanitaryActionMTX - original primary key  for matrix row
			,@idfVersion BIGINT --##PARAM @idfVersion - matrix version
			,@idfActionTypeRow BIGINT OUTPUT   --##PARAM @idfActionTypeRow - generic primary key for sanitary action parameter
			,@idfActionCodeRow BIGINT OUTPUT   --##PARAM @idfActionCodeRow - generic primary key for sanitary action code parameter
			,@idfsSanitaryAction BIGINT --##PARAM idfsSanitaryAction - sanitary action ID
			,@intNumRow BIGINT --##PARAM @intNumRow - row number inside matrix version
)
as
/*
				,@idfsParameterMeasureType4 = 233190000000
				,@idfsParameterMeasureCode4 = 233150000000
*/

SET @idfSanitaryActionMTX = @idfsSanitaryAction
EXECUTE spAggregateMatrixVersion_Post
   @Action
  ,@idfActionTypeRow OUTPUT
  ,@idfVersion
  ,@idfsSanitaryAction
  ,233190000000 --Sanitary action type
  ,@idfsSanitaryAction
  ,@intNumRow
  ,0

IF @Action = 8 -- Delete
	RETURN --we delete all matrix columns duirng first spAggregateMatrixVersion_Post call,so we don't need to call it again

DECLARE @strActionCode NVARCHAR(200)
SELECT @strActionCode = strActionCode FROM trtSanitaryAction WHERE idfsSanitaryAction = @idfsSanitaryAction
EXECUTE spAggregateMatrixVersion_Post
   @Action
  ,@idfActionCodeRow OUTPUT
  ,@idfVersion
  ,@idfsSanitaryAction
  ,233150000000 --Sanitary action code
  ,@strActionCode
  ,@intNumRow
  ,1



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

