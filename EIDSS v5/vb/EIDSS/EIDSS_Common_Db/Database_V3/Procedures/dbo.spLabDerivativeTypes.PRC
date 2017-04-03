
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spLabDerivativeTypes]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spLabDerivativeTypes]
GO

/*
	exec spLabDerivativeTypes 'en'
*/

CREATE PROCEDURE dbo.spLabDerivativeTypes
	@LangID nvarchar(50)
AS
BEGIN
	select		trtDerivativeForSampleType.idfDerivativeForSampleType,
				trtDerivativeForSampleType.idfsSampleType,
				trtDerivativeForSampleType.idfsDerivativeType,
				Types.Name as [Name]
	from		trtDerivativeForSampleType
	left join	fnReference_Full(@LangID)Types
	on			Types.idfsReference=trtDerivativeForSampleType.idfsDerivativeType
	where		intRowStatus=0
END
GO
