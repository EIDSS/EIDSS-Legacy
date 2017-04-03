GO
/****** Object:  StoredProcedure [dbo].[spRepPostBarcodeLayout]    Script Date: 10/20/2009 16:47:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRepPostBarcodeLayout]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spRepPostBarcodeLayout]

/****** Object:  StoredProcedure [dbo].[spRepPostBarcodeLayout]    Script Date: 11/30/2009 17:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY This procedure returns language, country and organization information related with current site.

--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 30.11.2009

--##RETURNS Don't use

/*
--Example of a call of procedure:

exec spRepPostBarcodeLayout 10057020, "test"
*/ 
 
CREATE PROCEDURE [dbo].[spRepPostBarcodeLayout]
	@idfsNumberName		bigint,
	@strBarcodeLayout	nvarchar(max)
AS
BEGIN
	if  exists 
		(	select  idfsNumberName
			from	dbo.tstBarcodeLayout
			where	idfsNumberName = @idfsNumberName
		)
	exec dbo.spRepDeleteBarcodeLayout @idfsNumberName

	insert into	dbo.tstBarcodeLayout
				(idfsNumberName, strBarcodeLayout)
	values 
				(@idfsNumberName, @strBarcodeLayout)

END
GO
