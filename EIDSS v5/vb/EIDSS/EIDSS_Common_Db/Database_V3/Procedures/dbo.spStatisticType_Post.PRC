SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spStatisticType_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spStatisticType_Post]
GO


--##SUMMARY Posts statistic type data. 
--##SUMMARY Called from Generic Statistic Types Editor form . 

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 21.11.2009

--##RETURNS Doesn't use


/*
--Example of a call of procedure:
DECLARE @Action int
DECLARE @idfsBaseReference bigint
DECLARE @strDefault nvarchar(200)
DECLARE @Name nvarchar(200)
DECLARE @idfsReferenceType bigint
DECLARE @idfsStatisticPeriodType bigint
DECLARE @idfsStatisticAreaType bigint
DECLARE @LANGID nvarchar(50)

EXECUTE spStatisticType_Post
   @Action
  ,@idfsBaseReference
  ,@strDefault
  ,@Name
  ,@idfsReferenceType
  ,@idfsStatisticPeriodType
  ,@idfsStatisticAreaType
  ,@LANGID
*/




CREATE             PROCEDURE dbo.spStatisticType_Post 
	@Action AS INT,  --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
	@idfsBaseReference AS BIGINT, --##PARAM @idfsBaseReference - ID of statistic type record
	@strDefault AS NVARCHAR(200), --##PARAM @strDefault - English name of statistic type
	@Name AS NVARCHAR(200), --##PARAM @Name - name of statistic type in language defined by @LANGID
	@idfsReferenceType AS BIGINT, --##PARAM @idfsReferenceType - parameter type
	@idfsStatisticPeriodType AS BIGINT, --##PARAM @idfsStatisticPeriodType - statistic period type, reference to rftStatisticPeriodType (19000091)
	@idfsStatisticAreaType AS BIGINT, --##PARAM @idfsStatisticAreaType - statistic area type, reference to rftStatisticAreaType (19000089)
	@LANGID As nvarchar(50) --##PARAM @LANGID - language ID
AS
BEGIN
	IF @Action = 8
	BEGIN

		DELETE FROM  trtStatisticDataType
		WHERE  idfsStatisticDataType= @idfsBaseReference
		
		EXECUTE spsysBaseReference_Delete  @idfsBaseReference


	END
	ELSE
	BEGIN
		EXEC dbo.spBaseReference_SysPost 
				@idfsBaseReference,
				19000090,  --'rftStatisticDataType',
				@LANGID,
				@strDefault,
				@Name,
				null,
				null
		IF @Action = 4 --Added
		BEGIN
			INSERT INTO trtStatisticDataType
					   (
						idfsStatisticDataType
					   ,idfsReferenceType
					   ,idfsStatisticAreaType
					   ,idfsStatisticPeriodType
						)
				 VALUES
					   (
						@idfsBaseReference
					   ,@idfsReferenceType
					   ,@idfsStatisticAreaType
					   ,@idfsStatisticPeriodType
					   )		
		END
		IF @Action = 16 --Modified
		BEGIN
			UPDATE trtStatisticDataType
			   SET 
				   idfsReferenceType = @idfsReferenceType
				  ,idfsStatisticAreaType = @idfsStatisticAreaType
				  ,idfsStatisticPeriodType = @idfsStatisticPeriodType
			 WHERE  idfsStatisticDataType = @idfsBaseReference
		END
		
	END

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

