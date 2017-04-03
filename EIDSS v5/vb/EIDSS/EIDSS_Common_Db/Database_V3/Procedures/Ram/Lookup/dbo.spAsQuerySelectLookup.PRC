GO
/****** Object:  StoredProcedure [dbo].[spAsQuerySelectLookup]    Script Date: 10/20/2009 16:47:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAsQuerySelectLookup]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spAsQuerySelectLookup]

/****** Object:  StoredProcedure [dbo].[spAsQuerySelectLookup]    Script Date: 11/30/2009 17:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY select queries for analytical module

--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 12.01.2010

--##RETURNS Don't use

/*
--Example of a call of procedure:

exec spAsQuerySelectLookup 'en'
*/ 
 
CREATE PROCEDURE [dbo].[spAsQuerySelectLookup]
	@LanguageID	as nvarchar(50),
	@QueryID	as bigint = null
AS
BEGIN
	select		tQuery.idflQuery,
				refQuery.strEnglishName		as DefQueryName,
				refQuery.strName			as QueryName,
				tQuery.strFunctionName		as strFunctionName,
				refDescription.strName		as strDescription,
				tQuery.blnReadOnly			as blnReadOnly,
				isnull(brQuery.intOrder,0)	as intOrder,
				case
					when	qsoOutbreak.idfQuerySearchObject is not null
						then	1
					else	0
				end							as blnIsOutbreak,
				case
					when	qsoHumanCase.idfQuerySearchObject is not null
							or qsoHCSample.idfQuerySearchObject is not null
							or qsoHCTest.idfQuerySearchObject is not null
						then	1
					else	0
				end							as blnIsHumanCase,
				case
					when	qsoVetCase.idfQuerySearchObject is not null
							or qsoVCSample.idfQuerySearchObject is not null
							or qsoVCTest.idfQuerySearchObject is not null
						then	1
					else	0
				end							as blnIsVetCase,
				case
					when	qsoASCampaign.idfQuerySearchObject is not null
						then	1
					else	0
				end							as blnIsASCampaign,
				case
					when	qsoASSession.idfQuerySearchObject is not null
							or qsoASSample.idfQuerySearchObject is not null
							or qsoASTest.idfQuerySearchObject is not null
						then	1
					else	0
				end							as blnIsASSession,
				case
					when	qsoHCSample.idfQuerySearchObject is not null
							or qsoVCSample.idfQuerySearchObject is not null
							or qsoASSample.idfQuerySearchObject is not null
						then	1
					else	0
				end							as blnIsSample,
				case
					when	qsoHCTest.idfQuerySearchObject is not null
							or qsoVCTest.idfQuerySearchObject is not null
							or qsoASTest.idfQuerySearchObject is not null
						then	1
					else	0
				end							as blnIsTest
				
		  from	dbo.tasQuery						as tQuery
	inner join	dbo.fnLocalReference(@LanguageID)	as refQuery
			on	refQuery.idflBaseReference = tQuery.idflQuery
	 left join	dbo.fnLocalReference(@LanguageID)	as refDescription
			on	tQuery.idflDescription = refDescription.idflBaseReference
	 left join	dbo.tasQuerySearchObject			as qsoOutbreak
		inner join	fnReference('en', 19000082)		as ref_sob_Outbreak		-- rftSearchObject
				on	ref_sob_Outbreak.idfsReference = qsoOutbreak.idfsSearchObject
					and ref_sob_Outbreak.[Name] = N'Outbreak'
			on  tQuery.idflQuery = qsoOutbreak.idflQuery
	 left join	dbo.tasQuerySearchObject			as qsoHumanCase
		inner join	fnReference('en', 19000082)		as ref_sob_HumanCase	-- rftSearchObject
				on	ref_sob_HumanCase.idfsReference = qsoHumanCase.idfsSearchObject
					and ref_sob_HumanCase.[Name] = N'Human Case'
			on  tQuery.idflQuery = qsoHumanCase.idflQuery
	 left join	dbo.tasQuerySearchObject			as qsoVetCase
		inner join	fnReference('en', 19000082)		as ref_sob_VetCase	-- rftSearchObject
				on	ref_sob_VetCase.idfsReference = qsoVetCase.idfsSearchObject
					and ref_sob_VetCase.[Name] = N'Vet Case'
			on  tQuery.idflQuery = qsoVetCase.idflQuery
	 left join	dbo.tasQuerySearchObject			as qsoASCampaign
		inner join	fnReference('en', 19000082)		as ref_sob_ASCampaign	-- rftSearchObject
				on	ref_sob_ASCampaign.idfsReference = qsoASCampaign.idfsSearchObject
					and ref_sob_ASCampaign.[Name] = N'Active Surveillance Campaign'
			on  tQuery.idflQuery = qsoASCampaign.idflQuery
	 left join	dbo.tasQuerySearchObject			as qsoASSession
		inner join	fnReference('en', 19000082)		as ref_sob_ASSession	-- rftSearchObject
				on	ref_sob_ASSession.idfsReference = qsoASSession.idfsSearchObject
					and ref_sob_ASSession.[Name] = N'Active Surveillance Session'
			on  tQuery.idflQuery = qsoASSession.idflQuery
	 left join	dbo.tasQuerySearchObject			as qsoHCSample
		inner join	fnReference('en', 19000082)		as ref_sob_HCSample		-- rftSearchObject
				on	ref_sob_HCSample.idfsReference = qsoHCSample.idfsSearchObject
					and ref_sob_HCSample.[Name] = N'Human Case Sample'
			on  tQuery.idflQuery = qsoHCSample.idflQuery
	 left join	dbo.tasQuerySearchObject			as qsoHCTest
		inner join	fnReference('en', 19000082)		as ref_sob_HCTest		-- rftSearchObject
				on	ref_sob_HCTest.idfsReference = qsoHCTest.idfsSearchObject
					and ref_sob_HCTest.[Name] = N'Human Case Test'
			on  tQuery.idflQuery = qsoHCTest.idflQuery
	 left join	dbo.tasQuerySearchObject			as qsoVCSample
		inner join	fnReference('en', 19000082)		as ref_sob_VCSample		-- rftSearchObject
				on	ref_sob_VCSample.idfsReference = qsoVCSample.idfsSearchObject
					and ref_sob_VCSample.[Name] = N'Vet Case Sample'
			on  tQuery.idflQuery = qsoVCSample.idflQuery
	 left join	dbo.tasQuerySearchObject			as qsoVCTest
		inner join	fnReference('en', 19000082)		as ref_sob_VCTest		-- rftSearchObject
				on	ref_sob_VCTest.idfsReference = qsoVCTest.idfsSearchObject
					and ref_sob_VCTest.[Name] = N'Vet Case Test'
			on  tQuery.idflQuery = qsoVCTest.idflQuery
	 left join	dbo.tasQuerySearchObject			as qsoASSample
		inner join	fnReference('en', 19000082)		as ref_sob_ASSample		-- rftSearchObject
				on	ref_sob_ASSample.idfsReference = qsoASSample.idfsSearchObject
					and ref_sob_ASSample.[Name] = N'Active Surveillance Sample'
			on  tQuery.idflQuery = qsoASSample.idflQuery
	 left join	dbo.tasQuerySearchObject			as qsoASTest
		inner join	fnReference('en', 19000082)		as ref_sob_ASTest		-- rftSearchObject
				on	ref_sob_ASTest.idfsReference = qsoASTest.idfsSearchObject
					and ref_sob_ASTest.[Name] = N'Active Surveillance Test'
			on  tQuery.idflQuery = qsoASTest.idflQuery
	 left join trtBaseReference brQuery
		on	brQuery.idfsBaseReference = tQuery.idfsGlobalQuery

	where		(@QueryID is null or @QueryID = tQuery.idflQuery)
	order by	intOrder, refQuery.strName

END
GO

