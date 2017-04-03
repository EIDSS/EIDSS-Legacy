GO
/****** Object:  StoredProcedure [dbo].[spAsLayoutPost]    Script Date: 10/20/2009 16:47:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAsLayoutPost]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spAsLayoutPost]

/****** Object:  StoredProcedure [dbo].[spAsLayoutPost]    Script Date: 11/30/2009 17:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY create layouts for analytical module

--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 12.03.2010

--##RETURNS Don't use

/*

--Example of a call of procedure:



declare @idflQuery bigint
select top 1 @idflQuery = idflQuery from tasQuery
declare @idfUserID bigint
select top 1 @idfUserID = idfUserID from tstUserTable

EXEC	[dbo].[spAsLayoutPost]
		 @strLanguage			= 'en'				
		,@idflLayout			= 708000000000			
		,@strLayoutName			= 'some name'			
		,@strDefaultLayoutName	= 'default name'	
		,@idflQuery				= @idflQuery				
		,@idflLayoutFolder		= null		
		,@idfUserID				= @idfUserID	
		,@idflDescription		= 128760000000	
		,@strDescription		= null	
		,@blbZippedBasicXml		= 0x78DAB3B1AFC8CD51284B2D2ACECCCFB35532D433505248CD4BCE4FC9CC4BB7552A2D49D3B550B2B7B349CECF4BCB4C2F2D4A2C012AB3B3D147E503002DD1182F
		,@blnReadOnly			= 0	
		,@idflPivotName			= 128760000000	
		,@strPivotName			= 'pivot_test'	
		,@idflMapName			= 128750000000	
		,@strMapName			= 'map_test'	
		,@idflChartName			= 128730000000	
		,@strChartName			= 'chart_test'	
		,@idfsGroupInterval		= 10039001	
		,@idfsChartType			= 10013003	
		,@blnShowColsTotals		= 1	
		,@blnShowRowsTotals		= 0	
		,@blnShowColGrandTotals	= 1	
		,@blnShowRowGrandTotals	= 0
		,@blnShowForSingleTotals	= 1
		,@blnApplyFilter			= 0
		,@blnShareLayout		= 1	
		,@blnPivotAxis			= 0	
		,@blnShowXLabels		= 1
		,@blnShowPointLabels	= 0
		
		,@intGisMinColor		=	1234 
		,@intGisMaxColor		=	4231 
		,@intGisMinOutlineColor	=	32412 
		,@intGisMaxOutlineColor	=	2134123 
		,@dblGisMinMarkerSize	=	1 
		,@dblGisMaxMarkerSize	=	2 
		,@dblGisMinOutlineWith	=	3 
		,@dblGisMaxOutlineWith	=	4 
		,@strGisLegendTitle		=	'legend' 
		,@strGisMinAlias		=	'min alias'
		,@strGisMaxAlias		=	'max alias' 
		,@blnGisIsGradient		=	0 
		,@blnGisUseAliases		=	1 
		

		

*/ 

CREATE PROCEDURE [dbo].[spAsLayoutPost]
	 @strLanguage				nvarchar(50)
	,@idflLayout				bigint
	,@strLayoutName				nvarchar(2000)
	,@strDefaultLayoutName		nvarchar(2000)
	,@idflQuery					bigint		
	,@idflLayoutFolder			bigint
	,@idfUserID					bigint
	,@idflDescription			bigint
	,@strDescription			nvarchar(2000)
	,@blbZippedBasicXml			image
	,@blnReadOnly				bit
	,@idflMapName				bigint
	,@strMapName				nvarchar(2000)
	,@idflPivotName				bigint
	,@strPivotName				nvarchar(2000)
	,@idflChartName				bigint
	,@strChartName				nvarchar(2000)
	,@idfsGroupInterval			bigint
	,@idfsChartType				bigint
	,@blnShowColsTotals			bit
	,@blnShowRowsTotals			bit
	,@blnShowColGrandTotals		bit
	,@blnShowRowGrandTotals		bit
	,@blnShowForSingleTotals	bit
	,@blnApplyFilter			bit
	,@blnShareLayout			bit
	,@blnPivotAxis				bit
	,@blnShowXLabels			bit 
	,@blnShowPointLabels		bit
	
	,@intGisMinColor			bigint 
	,@intGisMaxColor			bigint 
	,@intGisMinOutlineColor		bigint 
	,@intGisMaxOutlineColor		bigint 
	,@dblGisMinMarkerSize		float 
	,@dblGisMaxMarkerSize		float 
	,@dblGisMinOutlineWith		float 
	,@dblGisMaxOutlineWith		float 
	,@strGisLegendTitle			nvarchar(2000) 
	,@strGisMinAlias			nvarchar(2000) 
	,@strGisMaxAlias			nvarchar(2000) 
	,@blnGisIsGradient			bit 
	,@blnGisUseAliases			bit 
	
AS
BEGIN
	if	not exists	(	
					select	*
					from	tasQuery
					where	idflQuery = @idflQuery
					)
	begin
		Raiserror (N'Query with ID=%I64d doesnt exist.', 15, 1,  @idflQuery)
		return 1
	end

	-- inserting or updating references	
	if (@strLanguage <> 'en')
	begin
		exec spAsReferencePost @strLanguage, @idflLayout,	@strLayoutName
	end
	exec spAsReferencePost 'en',		 @idflLayout,	@strDefaultLayoutName
	exec spAsReferencePost @strLanguage, @idflMapName,	@strMapName
	exec spAsReferencePost @strLanguage, @idflChartName,@strChartName
	exec spAsReferencePost @strLanguage, @idflDescription, @strDescription
	exec spAsReferencePost @strLanguage, @idflPivotName,@strPivotName
	
	-- inserting into layout
	if not exists	(
					select	* 
					  from	tasLayout
					 where	idflLayout = @idflLayout
					)
	begin
        insert into tasLayout
           (idflLayout, idflQuery, idfUserID, idfsGroupInterval)
		values
           (@idflLayout, @idflQuery, @idfUserID, @idfsGroupInterval)
	end
	
	update	tasLayout
	   set 	idflLayoutFolder = @idflLayoutFolder
			,idfUserID = @idfUserID
			,strBasicXml = NULL
			,blbZippedBasicXml = @blbZippedBasicXml
			,blnReadOnly = @blnReadOnly
			
			,idflMapName = @idflMapName
			,idflPivotName = @idflPivotName
			,idflChartName = @idflChartName
			,idflDescription = @idflDescription
			,idfsGroupInterval = @idfsGroupInterval
			,idfsChartType = @idfsChartType
			
			,blnShowColsTotals = @blnShowColsTotals
			,blnShowRowsTotals = @blnShowRowsTotals
			,blnShowColGrandTotals = @blnShowColGrandTotals
			,blnShowRowGrandTotals = @blnShowRowGrandTotals
			,blnShowForSingleTotals = @blnShowForSingleTotals
			,blnApplyFilter = @blnApplyFilter
			,blnShareLayout = @blnShareLayout
			,blnPivotAxis = @blnPivotAxis
			,blnShowXLabels = @blnShowXLabels
			,blnShowPointLabels = @blnShowPointLabels
			
			,intGisMinColor			= @intGisMinColor			
			,intGisMaxColor			= @intGisMaxColor			
			,intGisMinOutlineColor	= @intGisMinOutlineColor		
			,intGisMaxOutlineColor	= @intGisMaxOutlineColor		
			,dblGisMinMarkerSize	= @dblGisMinMarkerSize		
			,dblGisMaxMarkerSize	= @dblGisMaxMarkerSize		
			,dblGisMinOutlineWith	= @dblGisMinOutlineWith		
			,dblGisMaxOutlineWith	= @dblGisMaxOutlineWith		
			,strGisLegendTitle		= @strGisLegendTitle			 
			,strGisMinAlias			= @strGisMinAlias			 
			,strGisMaxAlias			= @strGisMaxAlias			 
			,blnGisIsGradient		= @blnGisIsGradient			
			,blnGisUseAliases		= @blnGisUseAliases			
	
	where	idflLayout = @idflLayout

	return 0

END

GO
