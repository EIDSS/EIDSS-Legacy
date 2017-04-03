 SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepGetBarcode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepGetBarcode]


GO

--##SUMMARY Select data for barcode.
--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 13.01.2010

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

exec spRepGetBarcode 10057020, 72380000000

*/

CREATE  Procedure [dbo].[spRepGetBarcode]
	(
	    @TemplateID	as bigint,
		@ObjID	    as bigint
	)
AS	
	select	'top id'	as strTop,
			'barcode'	as strBarcode,
			'bottom id'	as strBottom
	
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

