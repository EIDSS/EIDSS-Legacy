SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAsQuerySearchObject_DeleteConditions]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAsQuerySearchObject_DeleteConditions]
GO


--##SUMMARY This procedure deletes all query condition groups and search fields conditions 
--##SUMMARY of specified query search object.

--##REMARKS Author: Mirnaya O.
--##REMARKS Create date: 20.04.2010

--##RETURNS Don't use

/*
--Example of a call of procedure:

declare	@idfQuerySearchObject			bigint

execute	spAsQuerySearchObject_DeleteConditions	@idfQuerySearchObject

*/ 


create procedure	spAsQuerySearchObject_DeleteConditions
(
	@idfQuerySearchObject			bigint
)
as

delete		qsfc
from		tasQuerySearchFieldCondition qsfc
inner join	tasQueryConditionGroup qcg
on			qcg.idfQueryConditionGroup = qsfc.idfQueryConditionGroup
where		qcg.idfQuerySearchObject = @idfQuerySearchObject

delete		qcg
from		tasQueryConditionGroup qcg
where		qcg.idfQuerySearchObject = @idfQuerySearchObject


return 0

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

