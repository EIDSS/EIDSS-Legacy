GO
/****** Object:  StoredProcedure [dbo].[spAsLayoutPublish]    Script Date: 10/20/2009 16:47:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAsLayoutPublish]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spAsLayoutPublish]

/****** Object:  StoredProcedure [dbo].[spAsLayoutPublish]    Script Date: 11/30/2009 17:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY perform layout publishing

--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 12.08.2010

--##RETURNS Don't use

/*

--Example of a call of procedure:

-- exec sp
declare @idfsPublishedLayout bigint
exec spAsLayoutPublish  743970000000, @idfsPublishedLayout output


*/ 

CREATE PROCEDURE [dbo].[spAsLayoutPublish]
	 @idflLayout				bigint,
	 @idfsPublishedLayout		bigint OUTPUT
AS
BEGIN

	declare @bitNewQuery		bit
	declare @idflQuery			bigint
	declare @idflFolder			bigint

	declare @idfsLayout			bigint
    declare @idfsQuery			bigint
    declare @idfsLayoutFolder	bigint
    declare @idfsDescription	bigint
    declare @idfsMapName		bigint
    declare @idfsPivotName		bigint
    declare @idfsChartName		bigint
    
    
	declare @strENLayoutName		nvarchar(2000)
	declare @strLocalLayoutName		nvarchar(2000)
	declare @strENPivotName			nvarchar(2000)
	declare @strLocalPivotName		nvarchar(2000)
	declare @strENDescription		nvarchar(2000)
	declare @strLocalDescription	nvarchar(2000)
	declare @strENMapName			nvarchar(2000)
	declare @strLocalMapName		nvarchar(2000)
	declare @strENChartName			nvarchar(2000)
	declare @strLocalChartName		nvarchar(2000)
	declare @strBaseReferenceCode	varchar(36)

	if	not exists	(	
					select	*
					from	tasLayout
					where	idflLayout = @idflLayout
					)
	begin
		Raiserror (N'Layout with ID=%I64d doesn''t exist.', 15, 1,  @idflLayout)
		return 1
	end
	
	begin tran
	begin try
		select	 @idfsLayout = idfsGlobalLayout 
				,@idflQuery = idflQuery
				,@idflFolder = idflLayoutFolder
				,@idfsDescription = idflDescription
				,@idfsMapName = idflMapName
				,@idfsPivotName = idflPivotName
				,@idfsChartName = idflChartName
				,@strENLayoutName = refENLayout.strName
				,@strENPivotName = refENPivot.strName		
				,@strENDescription = refENDescription.strName	
				,@strENMapName = refENMap.strName			
				,@strENChartName = refENChart.strName	
		from	tasLayout						as tLayout
		inner join	dbo.fnLocalReference('en')	as refENLayout
				on	tLayout.idflLayout = refENLayout.idflBaseReference
		 left join	dbo.fnLocalReference('en')	as refENDescription
				on	tLayout.idflDescription = refENDescription.idflBaseReference
		 left join	dbo.fnLocalReference('en')	as refENPivot
				on	tLayout.idflPivotName = refENPivot.idflBaseReference
		 left join	dbo.fnLocalReference('en')	as refENMap
				on	tLayout.idflMapName = refENMap.idflBaseReference
		 left join	dbo.fnLocalReference('en')	as refENChart
				on	tLayout.idflChartName = refENChart.idflBaseReference
		where	idflLayout = @idflLayout
		
		-- if local layout contains reference to global layout - return
		if (@idfsLayout is not null)
		begin
			Raiserror (N'Layout with ID=%I64d already published.', 15, 1,  @idflLayout)
			return 0
		end
		
		-- let global layout has the same id as local
		set @idfsLayout = @idflLayout
		
		-- if there is global layout with given id - return
		if	 exists	(	
			select	 *
			from	tasglLayout 
			where	idfsLayout = @idfsLayout
				)
		begin
			Raiserror (N'Global layout with ID=%I64d already exists.', 15, 1,  @idfsLayout)
			return 0
		end
		
		select	@idfsQuery = idfsGlobalQuery 
		from	tasQuery 
		where	idflQuery = @idflQuery
		
		--publish query and get global query id if needed
		if (@idfsQuery is null)
		begin
			exec spAsQueryPublish @idflQuery, @idfsQuery output
			set @bitNewQuery = 1
		end
		
		--publish folder and get global folder id if needed	
		if (@idflFolder is not null)
			exec spAsFolderPublish 	@idflFolder, @idfsQuery, @idfsLayoutFolder output

	   
	   -- insert base reference and english translation
		exec spBaseReference_SysPost @idfsLayout, 19000050, 'en', @strENLayoutName, @strENLayoutName, null, null	
		if (@idfsPivotName is not null)
			exec spBaseReference_SysPost @idfsPivotName, 19000124, 'en', @strENPivotName, @strENPivotName, null, null	
		if (@idfsDescription is not null)
			exec spBaseReference_SysPost @idfsDescription, 19000122, 'en', @strENDescription, @strENDescription, null, null	
		if (@idfsMapName is not null)
			exec spBaseReference_SysPost @idfsMapName, 19000126, 'en', @strENMapName, @strENMapName, null, null	
		if (@idfsChartName is not null)
			exec spBaseReference_SysPost @idfsChartName, 19000125, 'en', @strENChartName, @strENChartName, null, null	
	   
	   
	   -- cursor for insert all translation
		declare BaseReferencePostCursor cursor for
		select  strBaseReferenceCode
		from	fnBaseReferenceCode()
		
		open BaseReferencePostCursor
		
		fetch next from BaseReferencePostCursor into @strBaseReferenceCode
		while @@fetch_status = 0
		begin
			select	   @strLocalLayoutName = refLocalLayout.strName
					  ,@strLocalPivotName = refLocalPivot.strName		
					  ,@strLocalDescription = refLocalDescription.strName	
					  ,@strLocalMapName = refLocalMap.strName			
					  ,@strLocalChartName = refLocalChart.strName		
			from		dbo.tasLayout	as tLayout
			inner join	dbo.fnLocalReference(@strBaseReferenceCode)	as refLocalLayout
					on	tLayout.idflLayout = refLocalLayout.idflBaseReference
			 left join	dbo.fnLocalReference(@strBaseReferenceCode)	as refLocalDescription
					on	tLayout.idflDescription = refLocalDescription.idflBaseReference
			 left join	dbo.fnLocalReference(@strBaseReferenceCode)	as refLocalPivot
					on	tLayout.idflPivotName = refLocalPivot.idflBaseReference
			 left join	dbo.fnLocalReference(@strBaseReferenceCode)	as refLocalMap
					on	tLayout.idflMapName = refLocalMap.idflBaseReference
			 left join	dbo.fnLocalReference(@strBaseReferenceCode)	as refLocalChart
					on	tLayout.idflChartName = refLocalChart.idflBaseReference
			where		tLayout.idflLayout = @idflLayout
			
			-- insert translation if language is not english
			if (@strBaseReferenceCode != 'en')
			begin
				exec spBaseReference_SysPost @idfsLayout, 19000050, @strBaseReferenceCode, @strENLayoutName, @strLocalLayoutName, null, null	
				if (@idfsPivotName is not null)
					exec spBaseReference_SysPost @idfsPivotName, 19000124, @strBaseReferenceCode, @strENPivotName, @strLocalPivotName, null, null	
				if (@idfsDescription is not null)
					exec spBaseReference_SysPost @idfsDescription, 19000122, @strBaseReferenceCode, @strENDescription, @strLocalDescription, null, null	
				if (@idfsMapName is not null)
					exec spBaseReference_SysPost @idfsMapName, 19000126, @strBaseReferenceCode, @strENMapName, @strLocalMapName, null, null	
				if (@idfsChartName is not null)
					exec spBaseReference_SysPost @idfsChartName, 19000125, @strBaseReferenceCode, @strENChartName, @strLocalChartName, null, null	
			end
			
			fetch next from BaseReferencePostCursor into @strBaseReferenceCode
		end
		close BaseReferencePostCursor
		deallocate BaseReferencePostCursor
		
		insert into	tasglLayout
				(idfsLayout
				,idfsQuery
				,idfsLayoutFolder
				,idfUserID
				,idfsDescription
				,strBasicXml
				,blnReadOnly
				,idfsMapName
				,idfsPivotName
				,idfsChartName
				,idfsGroupInterval
				,idfsChartType
				,blnShowColsTotals
				,blnShowRowsTotals
				,blnShowColGrandTotals
				,blnShowRowGrandTotals
				,blnShowForSingleTotals
				,blnApplyFilter
				,blnShareLayout
				,blnPivotAxis
				,blnShowXLabels
				,blnShowPointLabels
				,blbZippedBasicXml
				,intGisMinColor			
				,intGisMaxColor			
				,intGisMinOutlineColor		
				,intGisMaxOutlineColor		
				,dblGisMinMarkerSize	
				,dblGisMaxMarkerSize	
				,dblGisMinOutlineWith	
				,dblGisMaxOutlineWith	
				,strGisLegendTitle			 
				,strGisMinAlias			 
				,strGisMaxAlias			 
				,blnGisIsGradient		
				,blnGisUseAliases		
			   )
		select 
				@idfsLayout		
				,@idfsQuery		
				,@idfsLayoutFolder
				,idfUserID
				,@idfsDescription	
				,strBasicXml
				,1
				,@idfsMapName		
				,@idfsPivotName	
				,@idfsChartName	
				,idfsGroupInterval
				,idfsChartType
				,blnShowColsTotals
				,blnShowRowsTotals
				,blnShowColGrandTotals
				,blnShowRowGrandTotals
				,blnShowForSingleTotals
				,blnApplyFilter
				,1
				,blnPivotAxis
				,blnShowXLabels
				,blnShowPointLabels
				,blbZippedBasicXml
				,intGisMinColor			
				,intGisMaxColor			
				,intGisMinOutlineColor		
				,intGisMaxOutlineColor		
				,dblGisMinMarkerSize	
				,dblGisMaxMarkerSize	
				,dblGisMinOutlineWith	
				,dblGisMaxOutlineWith	
				,strGisLegendTitle			 
				,strGisMinAlias			 
				,strGisMaxAlias			 
				,blnGisIsGradient		
				,blnGisUseAliases				  
		from	taslayout 
		where	idflLayout = @idflLayout
		
		update	tasLayout
		set		 idfsGlobalLayout = @idfsLayout
				,blnShareLayout = 1
				,blnReadOnly = 1
		where	idflLayout = @idflLayout	
		
		-- publish query objects if needed
		
		if (@bitNewQuery =1)
			exec spAsQuerySearchObjectPublish @idflLayout
		
		-- delete old Layout Search Field Aggregation
		delete
		from		tasglLayoutSearchFieldAggregation
		where		idfsLayout = @idfsLayout
		
		-- insert Layout Search Field Aggregation
		insert into tasglLayoutSearchFieldAggregation
			   (idfLayoutSearchFieldAggregation
			   ,idfsLayout
			   ,idfsAggregateFunction
			   ,idfQuerySearchField
			   ,idfUnitQuerySearchField
			   ,idfDenominatorQuerySearchField
			   )
		 select
				idfLayoutSearchFieldAggregation
			   ,@idfsLayout
			   ,idfsAggregateFunction
			   ,idfQuerySearchField
			   ,idfUnitQuerySearchField
			   ,idfDenominatorQuerySearchField
		 from	tasLayoutSearchFieldAggregation
		 where	idflLayout = @idflLayout 
		
		commit tran
	end try
	begin catch
		declare @error nvarchar(max)
		set @error = ERROR_PROCEDURE() +': '+ ERROR_MESSAGE()
		rollback tran
		Raiserror (N'Error while publishing query search object: %s', 15, 1, @error)
		return 1
	end catch
	SET @idfsPublishedLayout = @idfsLayout				
	select *	from tasglLayout
	where		idfsLayout = @idfsLayout 
	
--	return 0
END

GO
