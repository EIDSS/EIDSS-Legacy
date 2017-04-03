SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spOrganization_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spOrganization_Delete]
GO



--##SUMMARY Deletes organization record.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 21.11.2009

--##RETURNS Doesn't use

/*
--Example of procedure call:
DECLARE @idfOffice BIGINT
EXEC spOrganization_Delete @idfOffice
*/

CREATE     PROCEDURE dbo.spOrganization_Delete( 
	@idfOffice AS bigint
)
AS
DECLARE @NameID bigint
DECLARE @AbbrID bigint
declare @AddressID bigint

SELECT 
	@NameID = idfsOfficeName,
	@AbbrID = idfsOfficeAbbreviation,
	@AddressID = idfLocation
FROM 
	tlbOffice 
WHERE 
	idfOffice=@idfOffice


DELETE FROM dbo.tlbOffice
WHERE idfParentOffice = @idfOffice

DELETE FROM dbo.tlbOffice
WHERE idfOffice = @idfOffice

delete dbo.tlbGeolocation
where idfGeoLocation = @AddressID


DELETE FROM trtStringNameTranslation 
WHERE idfsBaseReference = @NameID

DELETE FROM 	dbo.trtStringNameTranslation 
WHERE idfsBaseReference = @AbbrID

DELETE FROM 	dbo.trtBaseReference
WHERE 
	idfsBaseReference = @NameID 

DELETE FROM dbo.trtBaseReference
WHERE 
	idfsBaseReference = @AbbrID


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

