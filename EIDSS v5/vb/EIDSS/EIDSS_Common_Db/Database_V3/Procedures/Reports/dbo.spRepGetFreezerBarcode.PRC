 SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepGetFreezerBarcode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepGetFreezerBarcode]


GO

--##SUMMARY Select data for Freezer barcode.
--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 16.01.2010

--##RETURNS Doesn't use 

/*
--Example of a call of procedure:

exec spRepGetFreezerBarcode 72930000000
exec spRepGetFreezerBarcode 72940000000
select *from dbo.tlbFreezerSubdivision
*/

CREATE  Procedure [dbo].[spRepGetFreezerBarcode]
	(
		@ObjID	    as bigint
	)
AS	

	if Exists (
				select	idfFreezer 
				  from	dbo.tlbFreezer 
				 where	idfFreezer = @ObjID
				   and  intRowStatus = 0
			  )
	begin
				select	null		as idfSubdivision, 
						idfFreezer,
						strBarcode
				from	dbo.tlbFreezer 
				where	idfFreezer = @ObjID
	end
	else begin
				select	idfSubdivision,
						idfFreezer,
						strBarcode
				from	dbo.tlbFreezerSubdivision
				where	idfSubdivision = @ObjID
	end
	
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

