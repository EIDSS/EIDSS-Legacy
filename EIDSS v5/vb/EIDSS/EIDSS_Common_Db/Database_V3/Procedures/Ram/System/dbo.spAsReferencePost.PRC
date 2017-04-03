GO
/****** Object:  StoredProcedure [dbo].[spAsReferencePost]    Script Date: 10/20/2009 16:47:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAsReferencePost]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spAsReferencePost]

/****** Object:  StoredProcedure [dbo].[spAsReferencePost]    Script Date: 11/30/2009 17:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY post record to locBaseReference

--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 12.01.2010

--##RETURNS Don't use

/*
--Example of a call of procedure:


EXEC	[dbo].[spAsReferencePost]
		 @strLanguage			= 'en'				
		,@idflBaseReference		= 716230000000			
		,@strBaseReferenceName	= 'some name 12'			
*/ 

CREATE PROCEDURE [dbo].[spAsReferencePost]
	 @strLanguage				nvarchar(50)
	,@idflBaseReference			bigint
	,@strBaseReferenceName		nvarchar(2000)
AS
BEGIN
	-- insering into locBaseReference
	if not exists	(
					select	idflBaseReference 
					  from	locBaseReference
					 where	idflBaseReference = @idflBaseReference
					)
	begin
		insert into locBaseReference
           (idflBaseReference)
		values
           (@idflBaseReference)
	end
	
	-- insering into locStringNameTranslation
	if not exists	(
					select	idflBaseReference 
					  from	locStringNameTranslation
					 where	idflBaseReference = @idflBaseReference
					   and	idfsLanguage = dbo.fnGetLanguageCode(@strLanguage)
					)
	begin
		insert into locStringNameTranslation
           (idflBaseReference, idfsLanguage, strTextString)
		values
           (@idflBaseReference, dbo.fnGetLanguageCode(@strLanguage), @strBaseReferenceName)
	end
	else begin
		-- updating string name
		update	locStringNameTranslation
		   set	strTextString = @strBaseReferenceName
		 where	idflBaseReference = @idflBaseReference
		   and	idfsLanguage = dbo.fnGetLanguageCode(@strLanguage)
		   and	strTextString <> @strBaseReferenceName
	end

	return 0
END

GO
