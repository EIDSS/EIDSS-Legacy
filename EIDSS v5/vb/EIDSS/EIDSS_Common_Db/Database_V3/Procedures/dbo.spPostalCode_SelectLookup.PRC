SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spPostalCode_SelectLookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spPostalCode_SelectLookup]
GO


CREATE       PROCEDURE dbo.spPostalCode_SelectLookup
	@SettlementID as bigint = NULL 
AS
SELECT idfsSettlement, strPostCode
FROM	tlbPostalCode
WHERE	idfsSettlement = isnull(@SettlementID, idfsSettlement)


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

