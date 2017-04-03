GO
/****** Object:  StoredProcedure [dbo].[spAsLayoutSelectAggregateDetail]    Script Date: 10/20/2009 16:47:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAsLayoutSelectAggregateDetail]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spAsLayoutSelectAggregateDetail]

/****** Object:  StoredProcedure [dbo].[spAsLayoutSelectAggregateDetail]    Script Date: 11/30/2009 17:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY select layouts for analytical module

--##REMARKS Author: Mirnaya O.
--##REMARKS Create date: 03.04.2010

--##RETURNS Don't use

/*
--Example of a call of procedure:

exec dbo.spAsLayoutSelectAggregateDetail @LanguageID=N'en',@LayoutID=23480000241
*/ 
 
CREATE PROCEDURE [dbo].[spAsLayoutSelectAggregateDetail]
	@LanguageID	as nvarchar(50),
	@LayoutID	as bigint
AS
select		lsfa.idfLayoutSearchFieldAggregation,
			sf.strSearchFieldAlias + 
			IsNull(	'__' + cast(sob.idfsFormType as varchar(20)) + '__' + 
					cast(qsf.idfsParameter as varchar(20)), '') as SearchFieldAlias,
			lsfa.idflLayout,
			lsfa.idfsAggregateFunction,
			
			sfu.strSearchFieldAlias + 
			IsNull(	'__' + cast(sobu.idfsFormType as varchar(20)) + '__' + 
					cast(qsfu.idfsParameter as varchar(20)), '') as UnitSearchFieldAlias,
				
			sfd.strSearchFieldAlias + 
			IsNull(	'__' + cast(sobd.idfsFormType as varchar(20)) + '__' + 
					cast(qsfd.idfsParameter as varchar(20)), '') as DenominatorSearchFieldAlias,
					
			sfdt.strSearchFieldAlias + 
			IsNull(	'__' + cast(sobdt.idfsFormType as varchar(20)) + '__' + 
					cast(qsfdt.idfsParameter as varchar(20)), '') as DateSearchFieldAlias,
					lsfa.idfUnitQuerySearchField,
					lsfa.idfDenominatorQuerySearchField,
					lsfa.idfDateQuerySearchField
					
									
			
from		(
	tasQuerySearchField qsf
	inner join	tasSearchField sf
	on			sf.idfsSearchField = qsf.idfsSearchField
	inner join	trtBaseReference br_sf
	on			br_sf.idfsBaseReference = sf.idfsSearchField
				and br_sf.intRowStatus = 0

	inner join	(
		tasQuerySearchObject qso
		inner join	tasSearchObject sob
		on			sob.idfsSearchObject = qso.idfsSearchObject
		inner join	trtBaseReference br_sob
		on			br_sob.idfsBaseReference = sob.idfsSearchObject
					and br_sob.intRowStatus = 0
				)
	on			qso.idfQuerySearchObject = qsf.idfQuerySearchObject

	left join	ffParameter p
	on			p.idfsParameter = qsf.idfsParameter
				and p.idfsFormType = sob.idfsFormType
			)

inner join	tasLayoutSearchFieldAggregation	lsfa
on			qsf.idfQuerySearchField = lsfa.idfQuerySearchField


left join	(
	tasQuerySearchField	qsfu
	inner join	tasSearchField sfu
	on			sfu.idfsSearchField = qsfu.idfsSearchField
	inner join	trtBaseReference br_sfu
	on			br_sfu.idfsBaseReference = sfu.idfsSearchField
				and br_sfu.intRowStatus = 0

	inner join	(
		tasQuerySearchObject qsou
		inner join	tasSearchObject sobu
		on			sobu.idfsSearchObject = qsou.idfsSearchObject
		inner join	trtBaseReference br_sobu
		on			br_sobu.idfsBaseReference = sobu.idfsSearchObject
					and br_sobu.intRowStatus = 0
				)
	on			qsou.idfQuerySearchObject = qsfu.idfQuerySearchObject

	left join	ffParameter pu
	on			pu.idfsParameter = qsfu.idfsParameter
				and pu.idfsFormType = sobu.idfsFormType
			)
on			qsfu.idfQuerySearchField = lsfa.idfUnitQuerySearchField
			and qsou.idflQuery = qso.idflQuery


-- denominator field
left join	(
	tasQuerySearchField	qsfd
	inner join	tasSearchField sfd
	on			sfd.idfsSearchField = qsfd.idfsSearchField
	inner join	trtBaseReference br_sfd
	on			br_sfd.idfsBaseReference = sfd.idfsSearchField
				and br_sfd.intRowStatus = 0

	inner join	(
		tasQuerySearchObject qsod
		inner join	tasSearchObject sobd
		on			sobd.idfsSearchObject = qsod.idfsSearchObject
		inner join	trtBaseReference br_sobd
		on			br_sobd.idfsBaseReference = sobd.idfsSearchObject
					and br_sobd.intRowStatus = 0
				)
	on			qsod.idfQuerySearchObject = qsfd.idfQuerySearchObject

	left join	ffParameter pd
	on			pd.idfsParameter = qsfd.idfsParameter
				and pd.idfsFormType = sobd.idfsFormType
			)
on			qsfd.idfQuerySearchField = lsfa.idfDenominatorQuerySearchField
			and qsod.idflQuery = qso.idflQuery

							
-- date field

left join	(
	tasQuerySearchField	qsfdt
	inner join	tasSearchField sfdt
	on			sfdt.idfsSearchField = qsfdt.idfsSearchField
	inner join	trtBaseReference br_sfdt
	on			br_sfdt.idfsBaseReference = sfdt.idfsSearchField
				and br_sfdt.intRowStatus = 0

	inner join	(
		tasQuerySearchObject qsodt
		inner join	tasSearchObject sobdt
		on			sobdt.idfsSearchObject = qsodt.idfsSearchObject
		inner join	trtBaseReference br_sobdt
		on			br_sobdt.idfsBaseReference = sobdt.idfsSearchObject
					and br_sobdt.intRowStatus = 0
				)
	on			qsodt.idfQuerySearchObject = qsfdt.idfQuerySearchObject

	left join	ffParameter pdt
	on			pdt.idfsParameter = qsfdt.idfsParameter
				and pdt.idfsFormType = sobdt.idfsFormType
			)
on			qsfdt.idfQuerySearchField = lsfa.idfDateQuerySearchField
			and qsodt.idflQuery = qso.idflQuery							
							
where		lsfa.idflLayout = @LayoutID
	
	


/*

select * from 	
	tasQuerySearchField	qsfdt
	inner join	tasSearchField sfdt
	on			sfdt.idfsSearchField = qsfdt.idfsSearchField
	inner join	trtBaseReference br_sfdt
	on			br_sfdt.idfsBaseReference = sfdt.idfsSearchField
				and br_sfdt.intRowStatus = 0

	inner join	(
		tasQuerySearchObject qsodt
		inner join	tasSearchObject sobdt
		on			sobdt.idfsSearchObject = qsodt.idfsSearchObject
		inner join	trtBaseReference br_sobdt
		on			br_sobdt.idfsBaseReference = sobdt.idfsSearchObject
					and br_sobdt.intRowStatus = 0
				)
	on			qsodt.idfQuerySearchObject = qsfdt.idfQuerySearchObject

	left join	ffParameter pdt
	on			pdt.idfsParameter = qsfdt.idfsParameter
				and pdt.idfsFormType = sobdt.idfsFormType
			
--on		qsfdt.idfQuerySearchField = lsfa.idfDateQuerySearchField
--732330000000 734470000000
			where  qsodt.idflQuery = 38780000000	
			
			
			and qsfdt.idfQuerySearchField=734470000000
			
			*/

GO
