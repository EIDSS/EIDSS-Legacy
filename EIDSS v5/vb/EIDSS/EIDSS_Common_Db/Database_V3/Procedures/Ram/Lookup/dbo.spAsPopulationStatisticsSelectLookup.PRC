GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAsPopulationStatisticsSelectLookup]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spAsPopulationStatisticsSelectLookup]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY Select the population statistics 
--##SUMMARY for all administrative levels by year (including empty year) .

--##REMARKS Author: Mirnaya O.
--##REMARKS Create date: 02.09.2010

--##RETURNS Don't use

/*
--Example of a call of procedure:
exec spAsPopulationStatisticsSelectLookup 'en'

*/ 
 
create procedure	spAsPopulationStatisticsSelectLookup
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
	AdminUnitName	nvarchar(400) collate database_default not null primary key,
	idfsAdminUnit	bigint not null,
	intValue		bigint not null,
	intYear			int null
)

insert into	@Population
(	AdminUnitName,
	idfsAdminUnit,
	intValue,
	intYear
)
select		ray_ref.ExtendedName + 
				IsNull(N'__' + cast(year(st.datStatisticStartDate) as nvarchar(30)), N''),
			ray.idfsRayon, 
			case	
				when	st.varValue is not null 
						and	SQL_VARIANT_PROPERTY(st.varValue, 'BaseType') in 
							('bigint', 'int', 'smallint', 'tinyint')
					then	cast(st.varValue as bigint) 
				else		0
			end,
			year(st.datStatisticStartDate)
from		(
	gisRayon ray
	inner join	fnGisExtendedReference(@LanguageID, 19000002) ray_ref	-- rftRayon
	on			ray_ref.idfsReference = ray.idfsRayon
			)
left join	tlbStatistic st
on			st.idfsArea = ray.idfsRayon
			and st.idfsStatisticDataType = 39850000000	-- Population
			and st.idfsStatisticAreaType = 10089002		-- Rayon
			and st.idfsStatisticPeriodType = 10091005	-- Year
			and st.intRowStatus = 0

left join	tlbStatistic st_max
on			st_max.idfsArea = ray.idfsRayon
			and st_max.idfsStatisticDataType = 39850000000	-- Population
			and st_max.idfsStatisticAreaType = 10089002		-- Rayon
			and st_max.idfsStatisticPeriodType = 10091005	-- Year
			and year(st_max.datStatisticStartDate) = year(st.datStatisticStartDate)
			and st_max.intRowStatus = 0
			and (	st_max.datStatisticStartDate > st.datStatisticStartDate
					or	(	st_max.datStatisticStartDate = st.datStatisticStartDate
							and st_max.idfStatistic > st.idfStatistic
						)
				)
where		ray.idfsCountry = @Country
			and st_max.idfStatistic is null


insert into	@Population
(	AdminUnitName,
	idfsAdminUnit,
	intValue,
	intYear
)
select		ray_ref.ExtendedName,
			ray.idfsRayon, 
			case	
				when	st.varValue is not null 
						and	SQL_VARIANT_PROPERTY(st.varValue, 'BaseType') in 
							('bigint', 'int', 'smallint', 'tinyint')
					then	cast(st.varValue as bigint) 
				else		0
			end,
			null
from		(
	gisRayon ray
	inner join	fnGisExtendedReference(@LanguageID, 19000002) ray_ref	-- rftRayon
	on			ray_ref.idfsReference = ray.idfsRayon
				and ray.idfsCountry = @Country
			)
left join	tlbStatistic st
on			st.idfsArea = ray.idfsRayon
			and st.idfsStatisticDataType = 39850000000	-- Population
			and st.idfsStatisticAreaType = 10089002		-- Rayon
			and st.idfsStatisticPeriodType = 10091005	-- Year
			and st.intRowStatus = 0

left join	tlbStatistic st_max
on			st_max.idfsArea = ray.idfsRayon
			and st_max.idfsStatisticDataType = 39850000000	-- Population
			and st_max.idfsStatisticAreaType = 10089002		-- Rayon
			and st_max.idfsStatisticPeriodType = 10091005	-- Year
			and st_max.intRowStatus = 0
			and (	st_max.datStatisticStartDate > st.datStatisticStartDate
					or	(	st_max.datStatisticStartDate = st.datStatisticStartDate
							and st_max.idfStatistic > st.idfStatistic
						)
				)
left join	@Population p
on			p.AdminUnitName = ray_ref.ExtendedName
where		st_max.idfStatistic is null
			and p.AdminUnitName is null


insert into	@Population
(	AdminUnitName,
	idfsAdminUnit,
	intValue,
	intYear
)
select		reg_ref.ExtendedName + IsNull(N'__' + cast(p.intYear as nvarchar(30)), N''),
			reg.idfsRegion, 
			sum(p.intValue),
			p.intYear
from		@Population p
inner join	gisRayon ray
on			ray.idfsRayon = p.idfsAdminUnit
inner join	(
	gisRegion reg
	inner join	fnGisExtendedReference(@LanguageID, 19000003) reg_ref	-- rftRegion
	on			reg_ref.idfsReference = reg.idfsRegion
			)
on			reg.idfsRegion = ray.idfsRegion
group by	reg_ref.ExtendedName, reg.idfsRegion, p.intYear
		  
insert into	@Population
(	AdminUnitName,
	idfsAdminUnit,
	intValue,
	intYear
)
select		cou_ref.ExtendedName + IsNull(N'__' + cast(p.intYear as nvarchar(30)), N''),
			cou.idfsCountry, 
			sum(p.intValue),
			p.intYear
from		@Population p
inner join	gisRayon ray
on			ray.idfsRayon = p.idfsAdminUnit
inner join	(
	gisCountry cou
	inner join	fnGisExtendedReference(@LanguageID, 19000001) cou_ref	-- rftCountry
	on			cou_ref.idfsReference = cou.idfsCountry
			)
on			cou.idfsCountry = ray.idfsCountry
group by	cou_ref.ExtendedName, cou.idfsCountry, p.intYear

select	AdminUnitName,
		idfsAdminUnit,
		intValue,
		intYear
from	@Population

end

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

