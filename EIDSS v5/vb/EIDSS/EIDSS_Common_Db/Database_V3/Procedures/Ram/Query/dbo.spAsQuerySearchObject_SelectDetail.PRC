GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAsQuerySearchObject_SelectDetail]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spAsQuerySearchObject_SelectDetail]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY This procedure selects specified query search object 
--##SUMMARY and related search fields and coonditions' tree.

--##REMARKS Author: Mirnaya O.
--##REMARKS Create date: 19.04.2010

--##RETURNS Don't use

/*
--Example of a call of procedure:

declare	@ID	bigint
exec spAsQuerySearchObject_SelectDetail @ID, 'en'
*/ 
 
create procedure	spAsQuerySearchObject_SelectDetail
	@ID			bigint,
	@LangID		nvarchar(50)
as

-- tasQuerySearchObject
select		qso.idfQuerySearchObject,
			qso.idflQuery,
			qso.idfsSearchObject,
			qso.intOrder
from		tasQuerySearchObject qso
where		qso.idfQuerySearchObject = @ID

-- tasQuerySearchField
execute spAsQuerySearchObject_SelectFieldList @ID, @LangID

-- tasQueryConditionGroup
exec spAsQuerySearchObject_SelectConditionGroupTree @ID, @LangID



GO
