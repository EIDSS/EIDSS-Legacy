GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAsPopulationGenderStatisticsSelectLookup]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spAsPopulationGenderStatisticsSelectLookup]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY Select the latest population statistics for genders.

--##REMARKS Author: Mirnaya O.
--##REMARKS Create date: 22.12.2010

--##RETURNS Don't use

/*
--Example of a call of procedure:
exec spAsPopulationGenderStatisticsSelectLookup 'ru'

*/ 
 
create procedure	spAsPopulationGenderStatisticsSelectLookup
	@LanguageID	as nvarchar(50)
as
begin


declare @Country bigint
set	@Country = null

select		@Country = s.idfsCountry
from		tstSite s
inner join	tstLocalSiteOptions lso
on			lso.strName = N'SiteID'
			and lso.strValue = cast(s.idfsSite as nvarchar(200))

declare	@Population table
(
	strGenderName	nvarchar(400) collate database_default not null primary key,
	idfsHumanGender	bigint not null,
	intValue		bigint not null,
	intYear			int null
)

insert into	@Population
(	strGenderName,
	idfsHumanGender,
	intValue,
	intYear
)
select		hg.[Name] + 
				IsNull(N'__' + cast(year(st.datStatisticStartDate) as nvarchar(30)), N''),
			hg.idfsReference, 
			case	
				when	st.varValue is not null 
						and	SQL_VARIANT_PROPERTY(st.varValue, 'BaseType') in 
							('bigint', 'int', 'smallint', 'tinyint')
					then	cast(st.varValue as bigint) 
				else		0
			end,
			year(st.datStatisticStartDate)
from		fnReference(@LanguageID, 19000043) hg		-- Human Gender
left join	tlbStatistic st
on			st.idfsMainBaseReference = hg.idfsReference
			and st.idfsArea = @Country
			and st.idfsStatisticDataType = 840900000000	-- Population by Gender
			and st.idfsStatisticAreaType = 10089001		-- Country
			and st.idfsStatisticPeriodType = 10091005	-- Year
			and st.intRowStatus = 0

left join	tlbStatistic st_max
on			st_max.idfsMainBaseReference = hg.idfsReference
			and st_max.idfsArea = @Country
			and st_max.idfsStatisticDataType = 840900000000	-- Population by Gender
			and st_max.idfsStatisticAreaType = 10089001		-- Country
			and st_max.idfsStatisticPeriodType = 10091005	-- Year
			and year(st_max.datStatisticStartDate) = year(st.datStatisticStartDate)
			and st_max.intRowStatus = 0
			and (	st_max.datStatisticStartDate > st.datStatisticStartDate
					or	(	st_max.datStatisticStartDate = st.datStatisticStartDate
							and st_max.idfStatistic > st.idfStatistic
						)
				)
where		st_max.idfStatistic is null


insert into	@Population
(	strGenderName,
	idfsHumanGender,
	intValue,
	intYear
)
select		hg.[Name],
			hg.idfsReference, 
			case	
				when	st.varValue is not null 
						and	SQL_VARIANT_PROPERTY(st.varValue, 'BaseType') in 
							('bigint', 'int', 'smallint', 'tinyint')
					then	cast(st.varValue as bigint) 
				else		0
			end,
			null
from		fnReference(@LanguageID, 19000043) hg		-- Human Gender
left join	tlbStatistic st
on			st.idfsMainBaseReference = hg.idfsReference
			and st.idfsArea = @Country
			and st.idfsStatisticDataType = 840900000000	-- Population by Gender
			and st.idfsStatisticAreaType = 10089001		-- Country
			and st.idfsStatisticPeriodType = 10091005	-- Year
			and st.intRowStatus = 0

left join	tlbStatistic st_max
on			st_max.idfsMainBaseReference = hg.idfsReference
			and st_max.idfsArea = @Country
			and st_max.idfsStatisticDataType = 840900000000	-- Population by Gender
			and st_max.idfsStatisticAreaType = 10089001		-- Country
			and st_max.idfsStatisticPeriodType = 10091005	-- Year
			and st_max.intRowStatus = 0
			and (	st_max.datStatisticStartDate > st.datStatisticStartDate
					or	(	st_max.datStatisticStartDate = st.datStatisticStartDate
							and st_max.idfStatistic > st.idfStatistic
						)
				)
left join	@Population p
on			p.strGenderName = hg.[Name]
where		st_max.idfStatistic is null
			and p.strGenderName is null

select	strGenderName,
		idfsHumanGender,
		intValue,
		intYear
from	@Population

end

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

