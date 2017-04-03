SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spPerson_SelectLookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spPerson_SelectLookup]
GO


--##SUMMARY Selects data for person lookup tables

--##REMARKS Author: Zurin M.
--##REMARKS Update date: 19.01.2010

--##RETURNS Doesn't use

/*
--Example of procedure call:

exec  spPerson_SelectLookup 'en', NULL, NULL
*/



CREATE          PROCEDURE dbo.spPerson_SelectLookup
	@LanguageID As nvarchar(50),--##PARAM @LanguageID - language ID
	@OfficeID as bigint = null,--##PARAM @OfficeID - person office, if not NULL only persons related with this office are selected
	@ID as bigint = NULL--##PARAM @ID - person ID, if NOT NULL only person with this ID is selected.
AS
SELECT		
	idfPerson, 
	IsNULL(strFamilyName,N'') + N' ' +
	IsNULL(strFirstName,N'') + N' ' +
	IsNULL(strSecondName,N'') AS FullName,
	fnInstitution.Name As Organization,
	idfOffice, 
	fnReference.Name As Position
from tlbPerson
INNER JOIN tlbEmployee ON
	tlbPerson.idfPerson = tlbEmployee.idfEmployee
	and tlbEmployee.intRowStatus = 0
LEFT OUTER JOIN dbo.fnInstitution(@LanguageID) ON
	tlbPerson.idfInstitution = fnInstitution.idfOffice
LEFT OUTER JOIN dbo.fnReference(@LanguageID,19000073) ON --'rftPosition'
	tlbPerson.idfsStaffPosition = fnReference.idfsReference

where
	idfOffice = isnull(@OfficeID, idfOffice)
	and (@ID IS NULL OR @ID = idfPerson)
order by fnInstitution.Name, FullName, fnReference.Name



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

