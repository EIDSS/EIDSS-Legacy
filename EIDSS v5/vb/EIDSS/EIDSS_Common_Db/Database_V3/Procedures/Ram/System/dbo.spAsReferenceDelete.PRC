GO
/****** Object:  StoredProcedure [dbo].[spAsReferenceDelete]    Script Date: 10/20/2009 16:47:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAsReferenceDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spAsReferenceDelete]

/****** Object:  StoredProcedure [dbo].[spAsReferenceDelete]    Script Date: 11/30/2009 17:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY delete record from locBaseReference and translations

--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 12.04.2010

--##RETURNS Don't use

/*
--Example of a call of procedure:

EXEC	dbo.spAsReferenceDelete 126330000000		
				
*/ 

CREATE PROCEDURE [dbo].[spAsReferenceDelete]
	@idflBaseReference			bigint
AS
BEGIN
	-- delete from locStringNameTranslation
	delete	
	  from	locStringNameTranslation
	 where	idflBaseReference = @idflBaseReference
	-- delete from locBaseReference
	delete
	  from	locBaseReference
	 where	idflBaseReference = @idflBaseReference

	return 0
END

GO
