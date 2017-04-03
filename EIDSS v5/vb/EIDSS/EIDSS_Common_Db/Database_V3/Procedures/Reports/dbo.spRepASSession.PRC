 SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepASSession]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepASSession]


GO

--##SUMMARY Selects monitoring session details for report.
--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 20.07.2010

--##RETURNS Doesn't use

/*
--Example of a call of procedure:
exec spRepASSession  88200000241, 'ru'
*/

CREATE  Procedure [dbo].[spRepASSession]
	(
		@idfCase bigint,
		@LangID nvarchar(20)
	)
AS	


select   
			tSession.idfMonitoringSession
			,fnRegion.Name		as strRegion
			,tSession.idfsRegion
			,fnRayon.Name		as strRayon
			,tSession.idfsRayon
			,fnSettlement.Name	as strSettlement
			,tSession.idfsSettlement
			,tSession.datEnteredDate
			,(
				select
							fnDiagnosis.[Name] + '; '
				from		tlbMonitoringSessionToDiagnosis	tSTD
				inner join	dbo.fnReference(@LangID,19000019) fnDiagnosis
				on			tSTD.idfsDiagnosis = fnDiagnosis.idfsReference 		
				where		tSTD.idfMonitoringSession = @idfCase
				and			tSTD.intRowStatus = 0
				Order By	tSTD.intOrder	
				for xml path('')
			 )					as strDiseases
	
from		tlbMonitoringSession tSession
-- Get  Rayon, region, reference
left join	fnGisReference(@LangID,19000003) fnRegion
on			fnRegion.idfsReference = tSession.idfsRegion
left join	fnGisReference(@LangID,19000002) fnRayon
on			fnRayon.idfsReference = tSession.idfsRayon
left join	fnGisReference(@LangID,19000004) fnSettlement
on			fnSettlement.idfsReference = tSession.idfsSettlement

where		tSession.idfMonitoringSession = @idfCase
and			tSession.intRowStatus = 0
	
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




