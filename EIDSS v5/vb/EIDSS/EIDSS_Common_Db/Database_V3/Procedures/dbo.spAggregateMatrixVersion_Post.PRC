SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAggregateMatrixVersion_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAggregateMatrixVersion_Post]
GO


--##SUMMARY Posts data for aggregate case matrix version
--##SUMMARY This method is called from posting procedures of specific aggregate case matrix type

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 09.02.2010

--##RETURNS Doesn't use



/*
--Example of procedure call:

EXECUTE spAggregateMatrixVersion_Post 

*/


CREATE       procedure dbo.spAggregateMatrixVersion_Post(
			 @Action INT  --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
			,@idfAggrMatrixVersion BIGINT OUTPUT --##PARAM @idfAggrMatrixVersion - generic primary key
			,@idfVersion BIGINT --##PARAM @idfVersion - matrix version
			,@idfRow BIGINT  --##PARAM @idfAggrVetCaseMTX  - record ID
			,@idfsParameter BIGINT  --##PARAM 
			,@varValue sql_variant   --##PARAM @idfsSpeciesType - species type
			,@intNumRow int --##PARAM @intNumRow - sequence number of posted row in matrix
			,@intColumnOrder int --##PARAM @intColumnOrder - sequence number of posted column in matrix
)
as
IF ISNULL(@idfAggrMatrixVersion,-1)<0
BEGIN
	EXEC spsysGetNewID @idfAggrMatrixVersion OUTPUT
	SET @Action = 4
END
IF @Action = 4
BEGIN
INSERT INTO [tlbAggrMatrixVersion](
			idfAggrMatrixVersion
		   ,[idfVersion]
           ,[idfRow]
           ,[idfsParameter]
           ,[varValue]
           ,[intNumRow]
		   ,[intColumnOrder]
			)
     VALUES(
			@idfAggrMatrixVersion
		   ,@idfVersion
           ,@idfRow
           ,@idfsParameter
           ,@varValue
           ,@intNumRow
		   ,@intColumnOrder
			)	

END
IF @Action = 8
	DELETE FROM [tlbAggrMatrixVersion] 
	WHERE idfRow = @idfRow
	
IF @Action = 16
UPDATE [tlbAggrMatrixVersion]
SET 
	 idfRow = @idfRow
    ,[varValue] = @varValue
    ,[intNumRow] = @intNumRow
    ,[intColumnOrder] = @intColumnOrder
WHERE  
	idfAggrMatrixVersion = @idfAggrMatrixVersion

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

