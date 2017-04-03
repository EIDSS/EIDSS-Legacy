set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFFGetParameterReferenceType]')) DROP PROCEDURE [dbo].[spFFGetParameterReferenceType]
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date: 29.09.09
-- Description:
-- =============================================
CREATE PROCEDURE dbo.spFFGetParameterReferenceType
(
	@LangID Nvarchar(50) = Null
	,@idfsParameterType Bigint = Null
	,@OnlyLists Bit = Null	-- нужно ли выводить только списочные типы, игнорируя элементарные типы
)	
AS
BEGIN	
	SET NOCOUNT ON;

	If (@LangID Is Null) Set @LangID = 'en';

    select 
		idfsParameterType	
		,RT.strDefault as [DefaultName]
		,Isnull(RT.Name, RT.strDefault) as [NationalName]
		,PT.idfsReferenceType
		,case isnull(PT.idfsReferenceType, -1)
			when -1 then '2'
			when 19000069 /*'rftParametersFixedPresetValue'*/ then '0'
			else '1'
			end as [System]
		,@LangID as [LangID]

	from dbo.ffParameterType as PT
	left join fnReference(@LangID, 19000071 /*'rftParameterType'*/) as RT
	on RT.idfsReference=PT.idfsParameterType
    Where 
    (PT.idfsParameterType = @idfsParameterType Or @idfsParameterType Is null)
	And
	(PT.intRowStatus = 0)
	And 
	(@OnlyLists Is Null Or (@OnlyLists Is Not null And PT.idfsReferenceType Is Not Null))
    ORDER BY [NationalName]
End
Go
