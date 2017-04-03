SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spStreet_SelectLookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spStreet_SelectLookup]
GO


CREATE        PROCEDURE dbo.spStreet_SelectLookup
	@idfsSettlement as bigint = NULL 
AS
SELECT	strStreetName, idfsSettlement
FROM	tlbStreet
WHERE	idfsSettlement = isnull(@idfsSettlement, idfsSettlement)


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

