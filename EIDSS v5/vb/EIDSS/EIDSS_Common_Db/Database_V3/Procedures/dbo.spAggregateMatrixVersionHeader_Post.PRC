SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'dbo.spAggregateMatrixVersionHeader_Post') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.spAggregateMatrixVersionHeader_Post
GO


--##SUMMARY Posts data for aggregate case matrix version
--##SUMMARY This method is called from posting procedures of specific aggregate case matrix type

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 09.02.2010

--##RETURNS Doesn't use



/*
--Example of procedure call:

EXECUTE spAggregateMatrixVersionHeader_Post 

*/


CREATE       procedure dbo.spAggregateMatrixVersionHeader_Post(
			 @Action INT  --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
			,@idfVersion BIGINT --##PARAM @idfVersion - matrix version
			,@idfsAggrCaseSection BIGINT  --##PARAM @idfsAggrCaseSection  - aggregate section type (i.e. Vet, Human, Prophilactic Measure, Diagnostic Action, Sanitary Action)
			,@MatrixName nvarchar(200)   --##PARAM @MatrixName - the name of the matrix
			,@datStartDate datetime --##PARAM @intNumRow - the date from which matrix should be used
			,@blnIsActive bit --##PARAM @blnIsActive - flag indicating that matrix was activated. Only activated matrixes can be used for agrregate case creation.
			,@blnIsDefault bit --##PARAM @blnIsDefault - flag indicating should matrix be used as default matrix or not
)
as
IF (@Action <> 8 AND @blnIsDefault = 1 )
BEGIN
	SET @blnIsActive = 1
	
	UPDATE tlbAggrMatrixVersionHeader
	SET blnIsDefault = 0 
	WHERE idfsAggrCaseSection = @idfsAggrCaseSection
		  AND idfVersion <> @idfVersion
		  AND blnIsDefault = 1
		  AND intRowStatus = 0		
END
IF @Action = 16
BEGIN
	IF NOT EXISTS (SELECT idfVersion FROM tlbAggrMatrixVersionHeader WHERE	idfVersion = @idfVersion)
		SET @Action=4
END
IF @Action = 4
BEGIN
	INSERT INTO tlbAggrMatrixVersionHeader
           (idfVersion
           ,idfsAggrCaseSection
           ,MatrixName
           ,datStartDate
           ,blnIsActive
           ,blnIsDefault
			)
     VALUES
           (@idfVersion
           ,@idfsAggrCaseSection
           ,@MatrixName
           ,@datStartDate
           ,@blnIsActive
           ,@blnIsDefault
			)
END
IF @Action = 8
BEGIN
	DELETE FROM [tlbAggrMatrixVersion] 
	WHERE idfVersion = @idfVersion

	DELETE FROM tlbAggrMatrixVersionHeader 
	WHERE idfVersion = @idfVersion
END	
IF @Action = 16
	UPDATE	tlbAggrMatrixVersionHeader
	SET 
			idfsAggrCaseSection = @idfsAggrCaseSection
			,MatrixName = @MatrixName
			,datStartDate=@datStartDate
			,blnIsActive = @blnIsActive
			,blnIsDefault = @blnIsDefault
	WHERE	idfVersion = @idfVersion


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

