SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spOrganization_SelectLookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spOrganization_SelectLookup]
GO


--##SUMMARY Selects lookup list of organizations.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 13.12.2009

--##RETURNS Doesn't use


/*
--Example of procedure call:
exec spOrganization_SelectLookup 'en', NULL
*/

CREATE      PROCEDURE dbo.spOrganization_SelectLookup
	@LanguageID As nvarchar(50), --##PARAM @LanguageID - language ID
	@ID as bigint = NULL --##PARAM @ID - organization ID, if not null only record with this organization is selected

AS
SELECT  idfOffice as idfInstitution, [Name], Abbreviation, idfsOfficeName, idfsOfficeAbbreviation 
FROM 
	dbo.fnInstitution(@LanguageID) 
WHERE
	(@ID IS NULL OR @ID = idfOffice)
ORDER BY
	Abbreviation 




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

