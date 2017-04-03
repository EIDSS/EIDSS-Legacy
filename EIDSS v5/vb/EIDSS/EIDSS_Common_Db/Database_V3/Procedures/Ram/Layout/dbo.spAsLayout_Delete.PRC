GO
/****** Object:  StoredProcedure [dbo].[spAsLayout_Delete]    Script Date: 10/20/2009 16:47:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAsLayout_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spAsLayout_Delete]

/****** Object:  StoredProcedure [dbo].[spAsLayout_Delete]    Script Date: 11/30/2009 17:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY delete layouts for analytical module

--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 12.04.2010

--##RETURNS Don't use

/*
--Example of a call of procedure:


EXEC	[dbo].[spAsLayout_Delete]	128740000000			
*/ 

CREATE PROCEDURE [dbo].[spAsLayout_Delete]
	 @idflLayout				bigint
AS
BEGIN
	-- get references id
	declare @idflMapName	bigint
	declare @idflChartName	bigint
	declare @idflPivotName	bigint
	declare @idflDescription	bigint

	select	@idflMapName = idflMapName, 
			@idflChartName = idflChartName,
			@idflPivotName = idflPivotName,
			@idflDescription = idflDescription
	  from	dbo.tasLayout
	 where	idflLayout = @idflLayout


	delete 
	  from  tasLayoutSearchFieldAggregation 
	 where	idflLayout = @idflLayout
	 
	 -- deleting from layout table
	delete
	  from	tasLayout
	 where	idflLayout = @idflLayout

	
	-- deleting references	
	exec spAsReferenceDelete  @idflLayout
	exec spAsReferenceDelete  @idflMapName
	exec spAsReferenceDelete  @idflChartName
	exec spAsReferenceDelete  @idflPivotName
	exec spAsReferenceDelete  @idflDescription

	return 0
END
GO