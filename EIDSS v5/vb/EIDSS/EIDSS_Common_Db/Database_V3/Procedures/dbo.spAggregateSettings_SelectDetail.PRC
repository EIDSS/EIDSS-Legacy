SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAggregateSettings_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAggregateSettings_SelectDetail]
GO


--##SUMMARY Selects data for AggregateSettings form
--##SUMMARY that defines minimal adninistrative unit and period type for different aggregate cases types.
--##SUMMARY If NULL is passed as input aggregate case type, settings for this type only is selected.
--##SUMMARY In other case all settings are selected.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 01.12.2009

--##RETURNS Doesn't use



/*
--Example of procedure call:
DECLARE @idfsAggrCaseType bigint
SET  @idfsAggrCaseType = 10102001
EXECUTE spAggregateSettings_SelectDetail 
	@idfsAggrCaseType

*/


CREATE       procedure dbo.spAggregateSettings_SelectDetail
			@idfsAggrCaseType bigint --##PARAM @idfsAggrCaseType - aggregate case type
as
SELECT * FROM fnAggregateSettings(@idfsAggrCaseType)
	


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

