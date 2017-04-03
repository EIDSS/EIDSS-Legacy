GO
/****** Object:  StoredProcedure [dbo].[spAsAggregateFunctionSelectLookup]    Script Date: 10/20/2009 16:47:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAsAggregateFunctionSelectLookup]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spAsAggregateFunctionSelectLookup]

/****** Object:  StoredProcedure [dbo].[spAsAggregateFunctionSelectLookup]    Script Date: 11/30/2009 17:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY select aggregate function list for analytical module

--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 12.01.2010

--##RETURNS Don't use

/*
--Example of a call of procedure:

exec spAsAggregateFunctionSelectLookup 'ru'
*/ 
  
CREATE PROCEDURE [dbo].[spAsAggregateFunctionSelectLookup]
	@LanguageID	as nvarchar(50)
AS
BEGIN
	select		tRef.strBaseReferenceCode	as idfsAggregateFunction,
				tRef.idfsBaseReference		as idfAggregateFunction,
				fnRef.strDefault			as AggregateFunctionNameDef,
				fnRef.[Name]				as AggregateFunctionName,
				tRef.intOrder
		  from	dbo.fnReference(@LanguageID, 19000004 /*'rftAggregateFunction'*/) as fnRef
	inner join	dbo.trtBaseReference		as tRef
			on	tRef.idfsBaseReference = fnRef.idfsReference
	  order by	tRef.intOrder, AggregateFunctionName

END
GO
