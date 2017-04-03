SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spLabSampleReceive_PostDetail]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spLabSampleReceive_PostDetail]
GO

CREATE PROCEDURE [dbo].[spLabSampleReceive_PostDetail]
	@idfContainer bigint,
	@idfMaterial bigint,
	@strBarcode nvarchar(200),
	@datAccession datetime,
	@strCondition nvarchar(200),
	@idfsAccessionCondition bigint,
	@strNote nvarchar(200),
	@idfSubdivision bigint,
	@idfDepartment bigint,
	@idfAccesionByPerson bigint
AS
BEGIN
	SET NOCOUNT ON;

	IF @idfsAccessionCondition=10108001 or @idfsAccessionCondition=10108002 --accepted in Good Condition or accepter in Poor Condition
	BEGIN
		--create associated container
		INSERT INTO	tlbContainer(
						idfContainer,
						idfRootParentContainer,
						datCreationDate,
						idfMaterial,
						idfsContainerStatus,
						strBarcode,
						strNote,
						idfSubdivision,
						idfInDepartment)
		VALUES(
						@idfContainer,
						@idfContainer,
						@datAccession,
						@idfMaterial,
						10015007,--'cotInRepository',
						@strBarcode,
						@strNote,
						@idfSubdivision,
						@idfDepartment)

		exec spLabSample_Store @idfSubdivision=@idfSubdivision,@idfContainer=@idfContainer
	END
	ELSE
	BEGIN
		SET @idfContainer=NULL
	END

	--mark material as located on this site
	exec spLabSampleOnSite @idfMaterial

	--declare @accession bigint
	--exec spsysgetnewid @accession out

	INSERT INTO tlbAccessionIN(
					--idfAccessionIn,
					idfContainer,
					idfMaterial,
					strCondition,
					idfsAccessionCondition,
					idfAccesionByPerson,
					datAccession/*,
					strNote*/
				)
	VALUES(
					--@accession,
					@idfContainer,
					@idfMaterial,
					@strCondition,
					@idfsAccessionCondition,
					@idfAccesionByPerson,
					@datAccession/*,
					@strNote*/
			)
END
GO
