GO
/****** Object:  StoredProcedure [dbo].[spAsLayoutParentPost]    Script Date: 10/20/2009 16:47:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAsLayoutParentPost]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spAsLayoutParentPost]

/****** Object:  StoredProcedure [dbo].[spAsLayoutParentPost]    Script Date: 11/30/2009 17:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY change layout parent folder

--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 12.06.2010

--##RETURNS Don't use

/*

--Example of a call of procedure:

EXEC	[dbo].[spAsLayoutParentPost]
		 @idflLayout			= 151440000000			
		,@idflLayoutFolder		= null		

*/ 

CREATE PROCEDURE [dbo].[spAsLayoutParentPost]
	 @idflLayout				bigint
	,@idflFolder			bigint
	
AS
BEGIN
	
	update	tasLayout
	   set 	idflLayoutFolder = @idflFolder
	where	idflLayout = @idflLayout

	return 0
END
GO
