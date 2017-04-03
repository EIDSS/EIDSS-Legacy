SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSite_GetParentSite]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spSite_GetParentSite]
GO





--##SUMMARY Returns record with Site ID of site that is parent of passed site .

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 24.02.2010

--##RETURNS doesn't use



/*
--Example of procedure call:

DECLARE @SiteID bigint
SET @SiteID = 2
EXECUTE spSite_GetParentSite
   @SiteID


*/


CREATE          PROCEDURE dbo.spSite_GetParentSite (
	@SiteID AS BIGINT--##PARAM @SiteID  - site ID
)

AS

SELECT TOP 1
		idfsParentSite
FROM	tstSiteRelation
WHERE
	idfsRelativeSite = @SiteID
	and idfsSiteRelationType = 10084002 --'srtSubordinated'
	and intRowStatus = 0





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

