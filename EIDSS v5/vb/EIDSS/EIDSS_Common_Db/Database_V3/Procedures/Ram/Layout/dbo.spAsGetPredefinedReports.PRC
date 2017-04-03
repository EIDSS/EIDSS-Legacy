SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'dbo.spAsGetPredefinedReports') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.spAsGetPredefinedReports
GO

--##SUMMARY Gets predefined layouts(reports)

--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 02.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

EXEC spAsGetPredefinedReports 'en'

*/

CREATE     Proc	spAsGetPredefinedReports
	@LangID	nvarchar(50)
AS
	SELECT		lay.idflLayout, rfLay.[Name], rfSob.intHACode
	FROM		tasLayout lay
	INNER JOIN	fnReference(@LangID, 19000050 /*'rftLayoutName'*/) rfLay
	ON			rfLay.idfsReference = lay.idflPivotName
	INNER JOIN	tasQuerySearchObject qso
	ON			qso.idflQuery = lay.idflQuery
	AND			qso.idfParentQuerySearchObject IS NULL
	INNER JOIN  fnReference(@LangID, 19000082 /*'rftSearchObject'*/) rfSob
	ON			rfSob.idfsReference = qso.idfsSearchObject
	WHERE		lay.blnReadOnly=1
	ORDER BY	rfLay.[Name]

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

