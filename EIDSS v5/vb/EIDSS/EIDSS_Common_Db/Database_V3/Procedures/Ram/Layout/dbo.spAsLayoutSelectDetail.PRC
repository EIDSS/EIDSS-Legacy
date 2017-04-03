GO
/****** Object:  StoredProcedure [dbo].[spAsLayoutSelectDetail]    Script Date: 10/20/2009 16:47:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAsLayoutSelectDetail]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spAsLayoutSelectDetail]

/****** Object:  StoredProcedure [dbo].[spAsLayoutSelectDetail]    Script Date: 11/30/2009 17:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY select layouts for analytical module

--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 03.04.2010

--##RETURNS Don't use

/*
--Example of a call of procedure:

exec spAsLayoutSelectDetail 'en', 709590000000
select * from dbo.fnLocalReference('en') where idflBaseReference = 709590000000
*/ 
 
CREATE PROCEDURE [dbo].[spAsLayoutSelectDetail]
	@LanguageID	as nvarchar(50),
	@LayoutID	as bigint
AS
BEGIN


	select	   tLayout.idflLayout
			  ,refLayout.strName		as strLayoutName
			  ,refLayout.strEnglishName	as strDefaultLayoutName
			  ,tLayout.idflPivotName
			  ,refPivot.strName			as strPivotName
			  ,tLayout.idflDescription
			  ,refDescription.strName	as strDescription 
			  ,tLayout.idflQuery
			  ,tLayout.idflLayoutFolder
			  ,tLayout.idfUserID
			  ,tLayout.strBasicXml
			  ,tLayout.blbZippedBasicXml
			  ,tLayout.blnReadOnly
			  ,tLayout.idflMapName 
			  ,refMap.strName			as strMapName 
			  ,tLayout.idflChartName 
			  ,refChart.strName			as strChartName
			  ,tLayout.idfsGroupInterval
			  ,refGroupInterval.[Name]	as strGroupIntervalName
			  ,tLayout.idfsChartType
			  ,refChartType.[Name]		as strChartTypeName
			  ,tLayout.blnShowColsTotals
			  ,tLayout.blnShowRowsTotals
			  ,tLayout.blnShowColGrandTotals
			  ,tLayout.blnShowRowGrandTotals
			  ,tLayout.blnShowForSingleTotals
			  ,tLayout.blnApplyFilter
			  ,tLayout.blnShareLayout
			  ,tLayout.blnPivotAxis
			  ,tLayout.blnShowXLabels
			  ,tLayout.blnShowPointLabels
			,tLayout.intGisMaxColor
			,tLayout.intGisMinColor
			,tLayout.intGisMaxOutlineColor
			,tLayout.intGisMinOutlineColor
			,tLayout.dblGisMaxMarkerSize
			,tLayout.dblGisMaxOutlineWith
			,tLayout.dblGisMinMarkerSize
			,tLayout.dblGisMinOutlineWith
			,tLayout.strGisLegendTitle
			,tLayout.strGisMaxAlias
			,tLayout.strGisMinAlias
			,tLayout.blnGisIsGradient
			,tLayout.blnGisUseAliases

			  
		  
	from		dbo.tasLayout	as tLayout
	inner join	dbo.fnLocalReference(@LanguageID)	as refLayout
			on	tLayout.idflLayout = refLayout.idflBaseReference
	 left join	dbo.fnLocalReference(@LanguageID)	as refDescription
			on	tLayout.idflDescription = refDescription.idflBaseReference
	 left join	dbo.fnLocalReference(@LanguageID)	as refPivot
			on	tLayout.idflPivotName = refPivot.idflBaseReference
	 left join	dbo.fnLocalReference(@LanguageID)	as refMap
			on	tLayout.idflMapName = refMap.idflBaseReference
	 left join	dbo.fnLocalReference(@LanguageID)	as refChart
			on	tLayout.idflChartName = refChart.idflBaseReference
	 left join	fnReference(@LanguageID, 19000039 /*'rftGroupInterval'*/)	as refGroupInterval
			on	refGroupInterval.idfsReference = tLayout.idfsGroupInterval
	 left join	fnReference(@LanguageID, 19000013 /*'rftChart'*/)	as refChartType
			on	refChartType.idfsReference = tLayout.idfsChartType
		   
		 where	@LayoutID = tLayout.idflLayout
		   

	 

END
GO
