GO
/****** Object:  StoredProcedure [dbo].[spAsFolderDelete]    Script Date: 10/20/2009 16:47:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAsFolderDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spAsFolderDelete]

/****** Object:  StoredProcedure [dbo].[spAsFolderDelete]    Script Date: 11/30/2009 17:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY delete folders for layouts in analytical module

--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 12.05.2010

--##RETURNS Don't use

/*
--Example of a call of procedure:


EXEC	[dbo].[spAsFolderDelete]	9110000002
*/

CREATE PROCEDURE [dbo].[spAsFolderDelete]
@idflFolder				bigint
AS
BEGIN

-- update reference to this folder

update  dbo.tasLayoutFolder
set		idflParentLayoutFolder = null
where	idflParentLayoutFolder = @idflFolder


update  dbo.tasLayout
set		idflLayoutFolder = null
where	idflLayoutFolder = @idflFolder

-- deleting from folder table
delete
from	dbo.tasLayoutFolder
where	idflLayoutFolder = @idflFolder

-- deleting references
exec dbo.spAsReferenceDelete  @idflFolder


return 0
END
GO