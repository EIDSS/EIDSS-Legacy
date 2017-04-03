GO
/****** Object:  StoredProcedure [dbo].[spRepDeleteBarcodeLayout]    Script Date: 10/20/2009 16:47:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRepDeleteBarcodeLayout]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spRepDeleteBarcodeLayout]

/****** Object:  StoredProcedure [dbo].[spRepDeleteBarcodeLayout]    Script Date: 11/30/2009 17:11:49 ******/
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

exec spRepDeleteBarcodeLayout 10057020
*/ 
 
CREATE PROCEDURE [dbo].[spRepDeleteBarcodeLayout]
	@idfsNumberName bigint
AS
BEGIN
	delete 
	from	dbo.tstBarcodeLayout
	where	idfsNumberName = @idfsNumberName

END
GO
