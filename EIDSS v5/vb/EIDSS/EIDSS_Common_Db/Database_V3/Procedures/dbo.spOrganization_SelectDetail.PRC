SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spOrganization_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spOrganization_SelectDetail]
GO



--##SUMMARY Selects data for OrganizationDetail form

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 21.11.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:
DECLARE @idfOffice bigint

EXECUTE spOrganization_SelectDetail 
	@idfOffice,
	'en'

EXECUTE spOrganization_SelectDetail 
	NULL,
	'en'
*/


CREATE      PROCEDURE dbo.spOrganization_SelectDetail 
	@idfOffice AS BIGINT, --##PARAM @idfOffice - organization ID
	@LANGID As nvarchar(50) --##PARAM @LANGID - language ID
AS
--0 Organization
SELECT  
	idfOffice, 
	EnglishName, 
	EnglishAbbreviation, 
	[Name], 
	Abbreviation, 
	strContactPhone, 
	idfLocation 
FROM 
	dbo.fnInstitution(@LANGID) 
WHERE 
	idfOffice=@idfOffice

--1 Departments
SELECT  idfDepartment, @idfOffice as idfOrganization, DefaultName, [Name] 
FROM 
	dbo.fnDepartment(@LANGID) 
WHERE 
	idfInstitution=@idfOffice



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

