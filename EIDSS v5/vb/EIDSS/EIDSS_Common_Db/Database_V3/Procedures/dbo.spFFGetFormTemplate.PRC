GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFFGetFormTemplate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spFFGetFormTemplate]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE Procedure [dbo].[spFFGetFormTemplate]
(
	@idfsDiagnosis BIGINT,
	@idfsFormType BIGINT,
	@idfsFormTemplate BIGINT OUTPUT
)
As
BEGIN

DECLARE @idfsCountry AS BIGINT
SET @idfsCountry = CAST (dbo.fnCurrentCountry() as NVARCHAR)

Declare @tmpTemplate as Table(idfsFormTemplate bigint, IsUNITemplate BIT)

Insert Into @tmpTemplate EXECUTE spFFGetActualTemplate 
   @idfsCountry
  ,@idfsDiagnosis
  ,@idfsFormType

Select TOP 1 @idfsFormTemplate = idfsFormTemplate
From @tmpTemplate

IF @idfsFormTemplate = -1
	SET @idfsFormTemplate = NULL
	
END

