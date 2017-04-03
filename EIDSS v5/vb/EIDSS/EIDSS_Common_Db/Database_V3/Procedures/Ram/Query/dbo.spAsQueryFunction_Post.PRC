GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAsQueryFunction_Post]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spAsQueryFunction_Post]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY Creates a new function for specified query.
--##SUMMARY  If a function with the same name already exists, it will be dropped and re-created.


--##REMARKS Author: Mirnaya O.
--##REMARKS Create date: 25.04.2010

--##RETURNS Don't use

/*
--Example of a call of procedure:
declare	@QueryID	bigint

execute	spAsQueryFunction_Post	@QueryID

*/ 

create procedure	spAsQueryFunction_Post
	 @QueryID	bigint	--##PARAM @QueryID Id of the query that corresponds result function
as
begin
-- TODO: Check rules that determine which search tables should be included to the query with correct join condition
-- TODO: Check multiply join rules (one search table to several search tables)

-- Select the name of the function
declare	@functionName	nvarchar(200)

select	@functionName = q.strFunctionName
from	tasQuery q
where	q.idflQuery = @QueryID

if	@functionName is not null
begin

	-- Generate sql query that creates the function
	declare @query	nvarchar(MAX)

	-- Generate the 'Select' part of the query
	declare @select nvarchar(MAX)
	set @select = 'select	'

	-- Define Separator
	declare @s varchar(20)
	set @s = '		'

	-- Add non FF fields to the 'Select' part
	select	@select	=
			case
				when	IsNull(q.blnAddAllKeyFieldValues, 0) = 1
						and sf.strSearchFieldAlias = 'sflHC_FinalDiagnosisCode'
						and sf.idfsReferenceType is null and sf.idfsGISReferenceType is null
					then	@select	+ 
							IsNull(@s + replace(replace(sf.strFieldText, N'HumanCase_Diagnosis{0}.', N'AllDiagnoses{0}.'), N'{0}', N'') + N' as [' + sf.strSearchFieldAlias + N']', N'')
				when	sf.idfsReferenceType is null and sf.idfsGISReferenceType is null
						and (IsNull(q.blnAddAllKeyFieldValues, 0) = 0 or sf.strSearchFieldAlias <> 'sflHC_FinalDiagnosisCode')
					then	@select	+ 
							IsNull(@s + replace(sf.strFieldText, N'{0}', N'') + N' as [' + sf.strSearchFieldAlias + N']', N'')
				when	sf.idfsReferenceType is not null
					then	@select + 
							IsNull(@s + replace(sf.strFieldText, N'{0}', N'') + N' as [' + sf.strSearchFieldAlias + N'_ID], ' +
							N'IsNull([ref_' + sf.strSearchFieldAlias + N'].[Name], ref_None.[Name]) as [' + sf.strSearchFieldAlias + ']', N'')
				when	sf.idfsGISReferenceType is not null
					then	@select + 
							IsNull(@s + replace(sf.strFieldText, N'{0}', N'') + N' as [' + sf.strSearchFieldAlias + N'_ID], ' +
							N'IsNull([ref_GIS_' + sf.strSearchFieldAlias + N'].[ExtendedName], ref_None.[Name]) as [' + sf.strSearchFieldAlias + N']', N'')
				else		N''
			end,
			@s = ', 
				'
	from		(
		tasQuerySearchField qsf
		inner join	tasQuerySearchObject qso
		on			qso.idfQuerySearchObject = qsf.idfQuerySearchObject
		inner join	tasQuery q
		on			q.idflQuery = qso.idflQuery
				)
	inner join	(
		tasSearchField sf
		inner join	trtBaseReference br_sf
		on			br_sf.idfsBaseReference = sf.idfsSearchField
					and br_sf.intRowStatus = 0
		inner join	tasSearchTable st
		on			st.idfSearchTable = sf.idfSearchTable
				)
	on			sf.idfsSearchField = qsf.idfsSearchField
				and sf.idfsSearchFieldType <> 10081003			-- FF Field
	where		qso.idflQuery = @QueryID

----	For version 3 we can use idfsParameter to replace the {0} text for FF fields in the 'Select' part
----	-- Create @ParameterOrder table (this table contains orders to replace the {0} text for FF fields in the 'Select' part)
----	declare	@ParameterOrder table
----	(	idfQuerySearchObject	bigint not null,
----		idfsFormType			bigint not null,
----		idfsParameter			bigint not null,
----		intOrder				int not null,
----		primary key nonclustered
----		(	idfQuerySearchObject asc, idfsParameter asc)
----	)
----
----	insert into	@ParameterOrder
----	(	idfQuerySearchObject,
----		idfsFormType,
----		idfsParameter,
----		intOrder
----	)
----	select		qso.idfQuerySearchObject,
----				sob.idfsFormType,
----				p.idfsParameter,
----				(	select		count(*)
----					from		tasQuerySearchField qsf_Order
----					inner join	(
----						tasQuerySearchObject qso_Order
----						inner join	tasSearchObject sob_Order
----						on			sob_Order.idfsSearchObject = qso_Order.idfsSearchObject
----						inner join	trtBaseReference br_ft_Order
----						on			br_ft_Order.idfsBaseReference = sob_Order.idfsFormType
----									and br_ft_Order.idfsReferenceType = 19000034		-- rftFFType
----									and br_ft_Order.intRowStatus = 0
----								)
----					on			qso_Order.idfQuerySearchObject = qsf_Order.idfQuerySearchObject
----					inner join	(
----						tasSearchField sf_Order
----						inner join	trtBaseReference br_sf_Order
----						on			br_sf_Order.idfsBaseReference = sf_Order.idfsSearchField
----						inner join	tasSearchTable st_Order
----						on			st_Order.idfSearchTable = sf_Order.idfSearchTable
----								)
----					on			sf_Order.idfsSearchField = qsf_Order.idfsSearchField
----								and sf_Order.idfsSearchFieldType = 10081003			-- FF Field
----					inner join	(
----						ffParameter p_Order
----						inner join	trtBaseReference br_p_Order
----						on			br_p_Order.idfsBaseReference = p_Order.idfsParameter
----									and br_p_Order.intRowStatus = 0
----								)
----					on			p_Order.idfsParameter = qsf_Order.idfsParameter
----								and p_Order.idfsFormType = sob_Order.idfsFormType
----								and p_Order.intRowStatus = 0
----					where		qso_Order.idflQuery = @QueryID
----								and qso_Order.idfQuerySearchObject = qso.idfQuerySearchObject
----								and	sf_Order.idfSearchTable = sf.idfSearchTable
----								and qsf_Order.idfsParameter <= qsf.idfsParameter
----				)
----	from		tasQuerySearchField qsf
----	inner join	(
----		tasQuerySearchObject qso
----		inner join	tasSearchObject sob
----		on			sob.idfsSearchObject = qso.idfsSearchObject
----		inner join	trtBaseReference br_ft
----		on			br_ft.idfsBaseReference = sob.idfsFormType
----					and br_ft.idfsReferenceType = 19000034		-- rftFFType
----					and br_ft.intRowStatus = 0
----				)
----	on			qso.idfQuerySearchObject = qsf.idfQuerySearchObject
----	inner join	(
----		tasSearchField sf
----		inner join	trtBaseReference br_sf
----		on			br_sf.idfsBaseReference = sf.idfsSearchField
----		inner join	tasSearchTable st
----		on			st.idfSearchTable = sf.idfSearchTable
----				)
----	on			sf.idfsSearchField = qsf.idfsSearchField
----				and sf.idfsSearchFieldType = 10081003			-- FF Field
----	inner join	(
----		ffParameter p
----		inner join	trtBaseReference br_p
----		on			br_p.idfsBaseReference = p.idfsParameter
----					and br_p.intRowStatus = 0
----				)
----	on			p.idfsParameter = qsf.idfsParameter
----				and p.idfsFormType = sob.idfsFormType
----				and p.intRowStatus = 0
----	where		qso.idflQuery = @QueryID


	-- Add FF fields to the 'Select' part
	select		@select	=
				case
					when	pt.idfsReferenceType is null --and pt.idfsGISReferenceType is null
						then	@select	+ 
								IsNull(@s + replace(sf.strFieldText, N'{0}', 
													N'_' + cast(p.idfsParameter as varchar(20)) + 
													N'_qso_' + cast(qso.intOrder as varchar(20))) + 
									N' as [' + sf.strSearchFieldAlias + N'__' + 
									cast(sob.idfsFormType as varchar(20)) + N'__' + 
									cast(p.idfsParameter as varchar(20)) + N']', N'')
					when	pt.idfsReferenceType is not null
						then	@select + 
								IsNull(@s + replace(sf.strFieldText, N'{0}', 
													N'_' + cast(p.idfsParameter as varchar(20)) + 
													N'_qso_' + cast(qso.intOrder as varchar(20))) + 
									N' as [' + sf.strSearchFieldAlias + N'__' + 
									cast(sob.idfsFormType as varchar(20)) + N'__' + 
									cast(p.idfsParameter as varchar(20)) + N'_ID], ' +
								N'IsNull([ref_' + sf.strSearchFieldAlias + N'__' + 
										cast(sob.idfsFormType as varchar(20)) + N'__' + 
										cast(p.idfsParameter as varchar(20)) + 
										N'].[Name], ref_None.[Name]) as [' + 
									sf.strSearchFieldAlias + N'__' + 
									cast(sob.idfsFormType as varchar(20)) + N'__' + 
									cast(p.idfsParameter as varchar(20)) + ']', N'')
	--				when	pt.idfsGISReferenceType is not null
	--					then	@select + 
	--							IsNull(@s + replace(sf.strFieldText, N'{0}', 
	--												N'_' + cast(p.idfsParameter as varchar(20)) + 
	--												N'_qso_' + cast(qso.intOrder as varchar(20))) + 
	--								N' as [' + sf.strSearchFieldAlias + N'__' + 
	--								cast(sob.idfsFormType as varchar(20)) + N'__' + 
	--								cast(p.idfsParameter as varchar(20)) + N'_ID], ' +
	--							N'IsNull([ref_GIS_' + sf.strSearchFieldAlias + N'__' + 
	--									cast(sob.idfsFormType as varchar(20)) + N'__' + 
	--									cast(p.idfsParameter as varchar(20)) + 
	--									N'].[Name], ref_None.[Name]) as [' + 
	--								sf.strSearchFieldAlias + N'__' + 
	--								cast(sob.idfsFormType as varchar(20)) + N'__' + 
	--								cast(p.idfsParameter as varchar(20)) + ']', N'')
					else		N''
				end,
				@s = ', 
				'
	from		tasQuerySearchField qsf
	inner join	(
		tasQuerySearchObject qso
		inner join	tasSearchObject sob
		on			sob.idfsSearchObject = qso.idfsSearchObject
		inner join	trtBaseReference br_ft
		on			br_ft.idfsBaseReference = sob.idfsFormType
					and br_ft.idfsReferenceType = 19000034		-- rftFFType
					and br_ft.intRowStatus = 0
				)
	on			qso.idfQuerySearchObject = qsf.idfQuerySearchObject
	inner join	(
		tasSearchField sf
		inner join	trtBaseReference br_sf
		on			br_sf.idfsBaseReference = sf.idfsSearchField
					and br_sf.intRowStatus = 0
		inner join	tasSearchTable st
		on			st.idfSearchTable = sf.idfSearchTable
				)
	on			sf.idfsSearchField = qsf.idfsSearchField
				and sf.idfsSearchFieldType = 10081003			-- FF Field
	inner join	(
		ffParameter p
		inner join	trtBaseReference br_p
		on			br_p.idfsBaseReference = p.idfsParameter
					and br_p.intRowStatus = 0
		inner join	ffParameterType pt
		on			pt.idfsParameterType = p.idfsParameterType
					and pt.intRowStatus = 0
		inner join	trtBaseReference br_pt
		on			br_pt.idfsBaseReference = pt.idfsParameterType
					and br_pt.intRowStatus = 0
				)
	on			p.idfsParameter = qsf.idfsParameter
				and p.idfsFormType = sob.idfsFormType
				and p.intRowStatus = 0
----	For version 3 we can use idfsParameter to replace the {0} text for FF fields in the 'Select' part
----	inner join	@ParameterOrder pOrder
----	on			pOrder.idfQuerySearchObject = qso.idfQuerySearchObject
----				and pOrder.idfsParameter = p.idfsParameter
	where		qso.idflQuery = @QueryID


	-- Generate the 'From' part of the query

	declare	@from nvarchar(MAX)
	set	@from = N''


	-- Create @AllSearchTable table of all search tables that should be included to the query
	declare	@AllSearchTable table
	(
		idfSearchTable			bigint not null,
		idfParentSearchTable	bigint null,
		strJoinType				varchar(15) collate database_default not null,
		strFrom					nvarchar(4000) collate database_default not null,
		strJoinCondition		nvarchar(2000) collate database_default not null
		primary key nonclustered 
		(idfSearchTable asc) on [PRIMARY]
	)

	-- Add main search table of root object with the 'from' join type
	insert into	@AllSearchTable
	(	idfSearchTable,
		idfParentSearchTable,
		strJoinType,
		strFrom,
		strJoinCondition
	)
	select		st_main.idfSearchTable,
				null,
				'from		',
				st_main.strFrom,
				''
	from		tasQuerySearchObject qso_root
	inner join	tasSearchObject sob
	on			sob.idfsSearchObject = qso_root.idfsSearchObject
	inner join	tasSearchTable st_main
	on			st_main.idfSearchTable = sob.idfMainSearchTable
	where		qso_root.idflQuery = @QueryID
				and qso_root.idfParentQuerySearchObject is null

	-- Add search tables related to selected fields of root object with the correct join type
	insert into	@AllSearchTable
	(	idfSearchTable,
		idfParentSearchTable,
		strJoinType,
		strFrom,
		strJoinCondition
	)
	select	distinct
				st.idfSearchTable,
				stjr.idfParentSearchTable,
				case
					when	st.blnPrimary = 1
						then	'inner join	'
					else	'left join	'
				end,
				st.strFrom,
				stjr.strJoinCondition
	from		(
		tasQuerySearchField qsf
		inner join	tasQuerySearchObject qso_root
		on			qso_root.idfQuerySearchObject = qsf.idfQuerySearchObject
					and qso_root.idfParentQuerySearchObject is null
		inner join	tasSearchObject sob
		on			sob.idfsSearchObject = qso_root.idfsSearchObject
		inner join	tasSearchTable st_main
		on			st_main.idfSearchTable = sob.idfMainSearchTable
				)
	inner join	(
		tasSearchField sf
		inner join	trtBaseReference br_sf
		on			br_sf.idfsBaseReference = sf.idfsSearchField
					and br_sf.intRowStatus = 0
		inner join	tasSearchTable st
		on			st.idfSearchTable = sf.idfSearchTable
				)
	on			sf.idfsSearchField = qsf.idfsSearchField
	inner join	tasSearchTableJoinRule stjr
	on			stjr.idfSearchTable = st.idfSearchTable
				and stjr.idfMainSearchTable = st_main.idfSearchTable
	left join	@AllSearchTable st_all_ex
	on			st_all_ex.idfSearchTable = st.idfSearchTable
	where		qso_root.idflQuery = @QueryID
				and st_all_ex.idfSearchTable is null

	-- Define a sign of the cycle end
	declare @GoOn int
	set @GoOn = 1

	-- Add parent search tables of tables related to fields of root object with the correct join type
	while	@GoOn > 0
	begin
		insert into	@AllSearchTable
		(	idfSearchTable,
			idfParentSearchTable,
			strJoinType,
			strFrom,
			strJoinCondition
		)
		select	distinct
					st_parent.idfSearchTable,
					st_parent_parent.idfSearchTable,
					case
						when	st_parent.blnPrimary = 1
							then	'inner join	'
						else	'left join	'
					end,
					st_parent.strFrom,
					stjr_parent.strJoinCondition
		from		@AllSearchTable st_all
		inner join	tasSearchTableJoinRule stjr
		on			stjr.idfSearchTable = st_all.idfSearchTable
		inner join	(
			tasQuerySearchObject qso_root
			inner join	tasSearchObject sob
			on			sob.idfsSearchObject = qso_root.idfsSearchObject
			inner join	tasSearchTable st_main
			on			st_main.idfSearchTable = sob.idfMainSearchTable
					)
		on			st_main.idfSearchTable = stjr.idfMainSearchTable
					and qso_root.idflQuery = @QueryID
					and qso_root.idfParentQuerySearchObject is null
		inner join	tasSearchTable st_parent
		on			st_parent.idfSearchTable = stjr.idfParentSearchTable

		inner join	(
			tasSearchTableJoinRule stjr_parent
			inner join	tasSearchTable st_parent_parent
			on			st_parent_parent.idfSearchTable = stjr_parent.idfParentSearchTable
					)
		on			stjr_parent.idfMainSearchTable = stjr.idfMainSearchTable
					and stjr_parent.idfSearchTable = st_parent.idfSearchTable

		left join	@AllSearchTable st_all_ex
		on			st_all_ex.idfSearchTable = st_parent.idfSearchTable
		where		st_all_ex.idfSearchTable is null

		set	@GoOn = @@rowcount
	end

	-- Add search tables related to selected fields of child objects with the 'left' join type
	insert into	@AllSearchTable
	(	idfSearchTable,
		idfParentSearchTable,
		strJoinType,
		strFrom,
		strJoinCondition
	)
	select	distinct
				st.idfSearchTable,
				stjr.idfParentSearchTable,
				'left join	',
				st.strFrom,
				stjr.strJoinCondition
	from		(
		tasQuerySearchField qsf
		inner join	tasQuerySearchObject qso_child
		on			qso_child.idfQuerySearchObject = qsf.idfQuerySearchObject
					and qso_child.idfParentQuerySearchObject is not null
				)
	inner join	(
		tasSearchField sf
		inner join	trtBaseReference br_sf
		on			br_sf.idfsBaseReference = sf.idfsSearchField
					and br_sf.intRowStatus = 0
		inner join	tasSearchTable st
		on			st.idfSearchTable = sf.idfSearchTable
				)
	on			sf.idfsSearchField = qsf.idfsSearchField
	inner join	tasSearchTableJoinRule stjr
	on			stjr.idfSearchTable = st.idfSearchTable
	inner join	(
		tasQuerySearchObject qso_root
		inner join	tasSearchObject sob
		on			sob.idfsSearchObject = qso_root.idfsSearchObject
		inner join	tasSearchTable st_main
		on			st_main.idfSearchTable = sob.idfMainSearchTable
				)
	on			qso_root.idfQuerySearchObject = qso_child.idfParentQuerySearchObject
				and qso_root.idflQuery = qso_child.idflQuery
				and st_main.idfSearchTable = stjr.idfMainSearchTable
	left join	@AllSearchTable st_all_ex
	on			st_all_ex.idfSearchTable = st.idfSearchTable
	where		qso_child.idflQuery = @QueryID
				and st_all_ex.idfSearchTable is null


	-- Reset a sign of the cycle end
	set	@GoOn = 1

	-- Add parent search tables of tables related to fields of child objects with the 'left' join type
	while	@GoOn > 0
	begin
		insert into	@AllSearchTable
		(	idfSearchTable,
			idfParentSearchTable,
			strJoinType,
			strFrom,
			strJoinCondition
		)
		select	distinct
					st_parent.idfSearchTable,
					st_parent_parent.idfSearchTable,
					'left join	',
					st_parent.strFrom,
					stjr_parent.strJoinCondition
		from		@AllSearchTable st_all
		inner join	tasSearchTableJoinRule stjr
		on			stjr.idfSearchTable = st_all.idfSearchTable
		inner join	(
			tasQuerySearchObject qso_root
			inner join	tasSearchObject sob
			on			sob.idfsSearchObject = qso_root.idfsSearchObject
			inner join	tasSearchTable st_main
			on			st_main.idfSearchTable = sob.idfMainSearchTable
					)
		on			st_main.idfSearchTable = stjr.idfMainSearchTable
					and qso_root.idflQuery = @QueryID
					and qso_root.idfParentQuerySearchObject is null
		inner join	tasSearchTable st_parent
		on			st_parent.idfSearchTable = stjr.idfParentSearchTable

		inner join	(
			tasSearchTableJoinRule stjr_parent
			inner join	tasSearchTable st_parent_parent
			on			st_parent_parent.idfSearchTable = stjr_parent.idfParentSearchTable
					)
		on			stjr_parent.idfMainSearchTable = stjr.idfMainSearchTable
					and stjr_parent.idfSearchTable = st_parent.idfSearchTable

		left join	@AllSearchTable st_all_ex
		on			st_all_ex.idfSearchTable = st_parent.idfSearchTable
		where		st_all_ex.idfSearchTable is null

		set	@GoOn = @@rowcount
	end

	-- Create @fromTable table of all search tables that should be included to the query 
	-- with updated from (including ordinary and GIS reference tables) condition and level
	declare	@fromTable table
	(	idfSearchTable			bigint not null primary key,
		strFrom					nvarchar(MAX) collate database_default not null,
		fromLevel				int not null
	)

	;
	with	fromTable	(
				idfSearchTable,
				strFrom,
				fromLevel
						)
	as	(	select		st_main.idfSearchTable,
						dbo.fnAsGetFrom	(
								@QueryID, 
								st_main.idfSearchTable, 
								st_main.strJoinType, 
								st_main.strFrom,
								st_main.strJoinCondition
										) as strFrom,
						0 as fromLevel
			from		@AllSearchTable st_main
			where		st_main.idfParentSearchTable is null
			union all
			select		st_all.idfSearchTable,
						dbo.fnAsGetFrom	(
								@QueryID, 
								st_all.idfSearchTable, 
								st_all.strJoinType, 
								st_all.strFrom,
								st_all.strJoinCondition
										) as strFrom,
						fromTable.fromLevel + 1 as fromLevel
			from		@AllSearchTable st_all
			inner join	fromTable
			on			fromTable.idfSearchTable = st_all.idfParentSearchTable
		)

	insert into	@fromTable
	(	idfSearchTable,
		strFrom,
		fromLevel
	)
	select	fTRec.idfSearchTable,
			fTRec.strFrom,
			fTRec.fromLevel
	from	fromTable fTRec

	-- Define current level of from
	declare	@level	int

	select	@level = max(ft.fromLevel) - 1
	from	@fromTable ft

	-- Create @finalFromTable table of all search tables that should be included to the query 
	-- with final from (including ordinary and GIS reference tables and child from conditions) condition and level
	declare	@finalFromTable table
	(	idfSearchTable			bigint not null primary key,
		strFrom					nvarchar(MAX) collate database_default not null,
		fromLevel				int not null
	)

	-- Add search tables with their from conditions of maximum level
	insert into	@finalFromTable
	(	idfSearchTable,
		strFrom,
		fromLevel
	)
	select	ft.idfSearchTable,
			-- Remove brackets and internal join condition ({1}) for single tables,
			-- or replace special brackets to ordinary ones for complex join condition
			case charindex('join', strFrom, charindex('join', strFrom) + 1)
				when	0
					then	replace(replace(replace(ft.strFrom, '{1}', ''), '{(}', ''), '{)}', '')
				else	replace(replace(replace(ft.strFrom, '{1}', ''), '{(}', '('), '{)}', ')')
			end,
			ft.fromLevel
	from	@fromTable ft
	where	ft.fromLevel = @level + 1

	-- Define current final from condition (including child from conditions)
	declare	@strCurFinalFrom	nvarchar(MAX)
	-- Define current from condition (without child from conditions)
	declare	@strCurFrom			nvarchar(MAX)

	-- Define current search table
	declare	@idfCurSearchTable	bigint

	-- Set Separator value
	set @s = '
			'

	-- Add search tables with final from conditions of all levels ordered by their level
	while @level >= 0
	begin
		-- Define cursor for @fromTable table with current level
		declare	TableCursor	cursor local read_only forward_only for
			select	ft.idfSearchTable,
					ft.strFrom
			from	@fromTable ft
			where	ft.fromLevel = @level
		open TableCursor
		fetch next from	TableCursor into	@idfCurSearchTable, @strCurFrom

		while @@fetch_status <> -1
		begin
			set	@strCurFinalFrom = @strCurFrom

			-- Generate final from condition (@strCurFinalFrom) for current search table
			select		@strCurFinalFrom = replace(@strCurFinalFrom, '{1}', fTFin_child.strFrom + @s + '{1}')
			from		@AllSearchTable st_all
			inner join	@finalFromTable fTFin_child
			on			fTFin_child.idfSearchTable = st_all.idfSearchTable
			where		st_all.idfParentSearchTable = @idfCurSearchTable
			order by	fTFin_child.strFrom

			-- Remove internal join condition ({1})
			set	@strCurFinalFrom = replace(@strCurFinalFrom, '{1}', '')

			-- Remove brackets for single tables,
			-- or replace special brackets to ordinary ones for complex join condition
			if (charindex('join', @strCurFinalFrom, charindex('join', @strCurFinalFrom) + 1) = 0)
				set @strCurFinalFrom = replace(replace(@strCurFinalFrom, '{(}', ''), '{)}', '')
			else	set @strCurFinalFrom = replace(replace(@strCurFinalFrom, '{(}', '('), '{)}', ')')

			-- Add generated values to @finalFromTable
			insert into	@finalFromTable
			(	idfSearchTable,
				strFrom, 
				fromLevel	
			)
			values
			(	@idfCurSearchTable,
				@strCurFinalFrom,
				@level
			)

			fetch next from	TableCursor into	@idfCurSearchTable, @strCurFrom

		end
			
		close TableCursor
		deallocate TableCursor

		set @level = @level - 1

	end

	-- Generate final from text
	select		@from = @from + @s + replace(fTFin.strFrom, '{1}', '')
	from		@finalFromTable fTFin
	where		fTFin.fromLevel = 0
	order by	fTFin.strFrom

	-- Add full join for key references
	-- Define @KeyFields table
	declare	@KeyFields	table
	(	strSearchFieldAlias	varchar(50) collate database_default not null primary key,
		intBinKey			int not null,
		blnExists			bit not null
	)

	insert into	@KeyFields	(strSearchFieldAlias, intBinKey, blnExists)
	values	('sflHC_PatientCRRayon', 1, 0)

	insert into	@KeyFields	(strSearchFieldAlias, intBinKey, blnExists)
	values	('sflHC_PatientCRRegion', 2, 0)

	insert into	@KeyFields	(strSearchFieldAlias, intBinKey, blnExists)
	values	('sflHC_FinalDiagnosis', 4, 0)

	insert into	@KeyFields	(strSearchFieldAlias, intBinKey, blnExists)
	values	('sflHC_FinalDiagnosisCode', 8, 0)

	insert into	@KeyFields	(strSearchFieldAlias, intBinKey, blnExists)
	values	('sflVC_FarmAddressRayon', 16, 0)

	insert into	@KeyFields	(strSearchFieldAlias, intBinKey, blnExists)
	values	('sflVC_FarmAddressRegion', 32, 0)

	insert into	@KeyFields	(strSearchFieldAlias, intBinKey, blnExists)
	values	('sflVC_Diagnosis', 64, 0)

	update		kf
	set			kf.blnExists = 1
	from		@KeyFields kf
	inner join	(
		tasSearchField sf
		inner join	trtBaseReference br_sf
		on			br_sf.idfsBaseReference = sf.idfsSearchField
					and br_sf.intRowStatus = 0
		inner join	tasSearchTable st
		on			st.idfSearchTable = sf.idfSearchTable
				)
	on			sf.strSearchFieldAlias = kf.strSearchFieldAlias
				and sf.idfsSearchFieldType <> 10081003			-- FF Field
	inner join	(
		tasQuerySearchField qsf
		inner join	tasQuerySearchObject qso
		on			qso.idfQuerySearchObject = qsf.idfQuerySearchObject
		inner join	tasQuery q
		on			q.idflQuery = qso.idflQuery
				)
	on			qsf.idfsSearchField = sf.idfsSearchField
	where		qso.idflQuery = @QueryID
				and q.blnAddAllKeyFieldValues = 1

	-- Define binary key of key reference field included in the query
	declare	@BinKey	int
	set	@BinKey = 0
	select	@BinKey = sum(intBinKey * blnExists)
	from	@KeyFields

	-- Define Full Join from condition for key references
	declare @FullJoinFrom	nvarchar(MAX)
	set	@FullJoinFrom = dbo.fnAsGetFullJoinFrom	(@BinKey)
	

	-- Add correct full join for key references to final from text
	if charindex('join', @from, 0) > 0
	begin
		set @from = @from + '
' + @FullJoinFrom
	end


	-- Add join condition for blank value to the final from text
	if charindex('join', @from, 0) > 0
	begin
		set @from = @from + '

left join	fnReference(@LangID, 19000044) ref_None	-- ''rftInformationString''
on			ref_None.idfsReference = 10044002		-- (none)
'
	end

	-- Generate the 'Where' part of the query
	declare @where nvarchar(MAX)
	set @where = '
'
	-- Set Separator value
	set	@s = ' 
			'

	-- Create @whereTable table of all condition groups (conditions within one pair of brackets) 
	-- that should be applied to the query with updated conditions and level
	declare	@whereTable table
	(				
		idfQueryConditionGroup	bigint not null primary key,
		strWhere				nvarchar(MAX) collate database_default not null,  
		strJoinOperator			varchar(20) collate database_default null,
		strChildJoinOperator	varchar(20) collate database_default null,
		whereLevel				int not null
	)

	;
	with	whereTable	(
				idfQueryConditionGroup,
				strWhere,
				strJoinOperator,
				strChildJoinOperator,
				whereLevel
						)
	as	(	select		qcg.idfQueryConditionGroup,
						'({3})' as strWhere,
						case
							when	qcg.blnUseNot = 1
								then	cast('and not ' as varchar(20))
							else	cast('and ' as varchar(20))
						end as strJoinOpearator,
						case	
							when	qcg.blnJoinByOr = 1
								then	'or '
							else	'and '
						end as strChildJoinOperator,
						0 as whereLevel
			from		(
				tasQueryConditionGroup qcg
				inner join	tasQuerySearchObject qso
				on			qso.idfQuerySearchObject = qcg.idfQuerySearchObject
							and qso.idflQuery = @QueryID
						)
			left join	(
				tasQuerySearchFieldCondition qsfc
				left join	tasQuerySearchFieldCondition qsfc_min
				on			qsfc_min.idfQueryConditionGroup = qsfc.idfQueryConditionGroup
							and qsfc_min.idfQuerySearchFieldCondition < qsfc.idfQuerySearchFieldCondition
						)
			on			qsfc.idfQueryConditionGroup = qcg.idfQueryConditionGroup
						and qsfc_min.idfQuerySearchFieldCondition is null
			left join	(
				tasQueryConditionGroup qcg_child
				left join	tasQueryConditionGroup qcg_child_min
				on			qcg_child_min.idfParentQueryConditionGroup = qcg_child.idfParentQueryConditionGroup
							and qcg_child_min.idfQueryConditionGroup < qcg_child.idfQueryConditionGroup
						)
			on			qcg_child.idfParentQueryConditionGroup = qcg.idfQueryConditionGroup
						and qcg_child_min.idfQueryConditionGroup is null
			where		qcg.idfParentQueryConditionGroup is null
						and (	qsfc.idfQuerySearchFieldCondition is not null
								or qcg_child.idfQueryConditionGroup is not null)
			union all
			select		qcg.idfQueryConditionGroup,
						'({3})' as strWhere,
						case
							when	qcg.blnUseNot = 1
								then	cast((whereTable.strChildJoinOperator + 'not ') as varchar(20))
							else	cast(whereTable.strChildJoinOperator as varchar(20))
						end as strJoinOpearator,
						case	
							when	qcg.blnJoinByOr = 1
								then	'or '
							else	'and '
						end as strChildJoinOperator,
						whereTable.whereLevel + 1 as whereLevel
			from		(
				tasQueryConditionGroup qcg
				inner join	tasQuerySearchObject qso
				on			qso.idfQuerySearchObject = qcg.idfQuerySearchObject
							and qso.idflQuery = @QueryID
						)
			inner join	whereTable
			on			whereTable.idfQueryConditionGroup = qcg.idfParentQueryConditionGroup
		)


	insert into	@whereTable
	(				
		idfQueryConditionGroup,
		strWhere,  
		strJoinOperator,
		strChildJoinOperator,
		whereLevel
	)
	select	wTRec.idfQueryConditionGroup,
			wTRec.strWhere,
			wTRec.strJoinOperator,
			wTRec.strChildJoinOperator,
			wTRec.whereLevel
	from	whereTable wTRec

	-- Remove join operator before the first condition related to search object
	update		wt
	set			wt.strJoinOperator = 
				case
					when	(len(wt.strJoinOperator) >= 4)
							and (substring(wt.strJoinOperator, len(wt.strJoinOperator) - 4, 3) = 'not')
						then	'not '
					else	''
				end
	from		@whereTable wt
	left join	@whereTable wt_min
	on			wt_min.whereLevel = wt.whereLevel
				and wt_min.idfQueryConditionGroup < wt.idfQueryConditionGroup
	where		wt.whereLevel = 0
				and wt_min.idfQueryConditionGroup is null


	-- Update where condititions for bracket groups

	-- Define current bracket group
	declare	@idfQueryConditionGroup bigint
	-- Define join operator for child bracket groups and conditions of current bracket group 
	declare	@strChildJoinOperator varchar(20)
	-- Define correct join operator for child conditions of current bracket group 
	-- (with removed join operator for the first child condition or bracket group in the current bracket group)
	declare	@strJoin varchar(20)
	-- Define where condition for current bracket group
	declare	@strWhere nvarchar(MAX)

	-- Define cursor for @whereTable table
	declare	TableCursor Cursor local read_only forward_only for
		select		wt.idfQueryConditionGroup, wt.strChildJoinOperator
		from		@whereTable wt
	open TableCursor
	fetch next from TableCursor into @idfQueryConditionGroup, @strChildJoinOperator
	while @@fetch_status <> -1
	begin
		set	@strWhere = ''
		set	@strJoin = ''
		if	(len(@strChildJoinOperator) >= 4)
			and (substring(@strChildJoinOperator, len(@strChildJoinOperator) - 4, 3) = 'not')
			set @strJoin = 'not '

		select		@strWhere = @strWhere + @strJoin +
					dbo.fnAsGetSearchCondition
						(	IsNull(p.idfsParameterType, sf.idfsSearchFieldType),
							IsNull(pt.idfsReferenceType, sf.idfsReferenceType),
							sf.idfsGISReferenceType,
							replace	(	sf.strFieldText, 
										N'{0}', 
										IsNull	(	N'_' + cast(p.idfsParameter as varchar(20)) + 
														N'_qso_' + cast(qso.intOrder as varchar(20)), 
													N''
												)
									),
							qsfc.strOperator,
							qsfc.intOperatorType,
							qsfc.blnUseNot,
							qsfc.varValue
						),
					@strJoin = @strChildJoinOperator
		from		tasQuerySearchFieldCondition qsfc
		inner join	(
			tasQuerySearchField qsf
			inner join	tasSearchField sf
			on			sf.idfsSearchField = qsf.idfsSearchField
			inner join	trtBaseReference br_sf
			on			br_sf.idfsBaseReference = sf.idfsSearchField
						and br_sf.intRowStatus = 0
					)
		on			qsf.idfQuerySearchField = qsfc.idfQuerySearchField
		inner join	(
			tasQuerySearchObject qso
			inner join	tasSearchObject sob
			on			sob.idfsSearchObject = qso.idfsSearchObject
			left join	trtBaseReference br_ft
			on			br_ft.idfsBaseReference = sob.idfsFormType
						and br_ft.idfsReferenceType = 19000034		-- rftFFType
						and br_ft.intRowStatus = 0
					)
		on			qso.idfQuerySearchObject = qsf.idfQuerySearchObject
		left join	(
			ffParameter p
			inner join	trtBaseReference br_p
			on			br_p.idfsBaseReference = p.idfsParameter
						and br_p.intRowStatus = 0
			inner join	ffParameterType pt
			on			pt.idfsParameterType = p.idfsParameterType
						and pt.intRowStatus = 0
			inner join	trtBaseReference br_pt
			on			br_pt.idfsBaseReference = pt.idfsParameterType
						and br_pt.intRowStatus = 0
					)
		on			p.idfsParameter = qsf.idfsParameter
					and p.idfsFormType = sob.idfsFormType
					and p.intRowStatus = 0
		where		qsfc.idfQueryConditionGroup = @idfQueryConditionGroup

		update	wt
		set		wt.strWhere = replace(wt.strWhere, '{3}', @strWhere + '{3}')
		from	@whereTable wt
		where	wt.idfQueryConditionGroup = @idfQueryConditionGroup

		fetch next from TableCursor into @idfQueryConditionGroup, @strChildJoinOperator
	end
	close TableCursor
	deallocate TableCursor 

	-- Create @finalWhereTable table of all bracket groups that should be included to the query 
	-- with final where condition (including child bracket group conditions) and level
	declare	@finalWhereTable table
	(	idfQueryConditionGroup	bigint not null primary key,
		strWhere				nvarchar(MAX) collate database_default not null,
		strJoinOperator			varchar(20) collate database_default not null,
		whereLevel				int not null
	)

	-- Select maximum level of from
	set	@level = -2
	select	@level = max(wt.whereLevel) - 1
	from	@whereTable wt

	-- Add group brackets with their where conditions of maximum level
	insert into	@finalWhereTable
	(	idfQueryConditionGroup,
		strWhere, 
		strJoinOperator,
		whereLevel
	)
	select	wt.idfQueryConditionGroup,
			replace(wt.strWhere, '{3}', ''),
			wt.strJoinOperator,
			wt.whereLevel
	from	@whereTable wt
	where	whereLevel = @level + 1

	-- Define current final where condition (including child where conditions)
	declare	@strCurFinalWhere	nvarchar(MAX)
	-- Define join operator for current bracket group
	declare	@strJoinOperator	nvarchar(20)

	-- Add bracket groups with final where conditions of all levels ordered by their level
	while @level >= 0
	begin
		-- Define cursor for @whereTable table with current level
		declare	TableCursor	cursor local read_only forward_only for
			select	wt.idfQueryConditionGroup, 
					wt.strWhere,
					wt.strJoinOperator,
					wt.strChildJoinOperator
			from	@whereTable wt
			where	wt.whereLevel = @level
		open TableCursor
		fetch next from	TableCursor into
			@idfQueryConditionGroup, @strWhere, @strJoinOperator, @strChildJoinOperator

		while @@fetch_status <> -1
		begin
			set	@strCurFinalWhere = @strWhere

			-- Remove join operator before the first child condition or bracket group of current bracket group
			if @strWhere = '({3})'
			begin
				update		wtFin_child
				set			wtFin_child.strJoinOperator =
							case
								when	(len(wtFin_child.strJoinOperator) >= 4) 
										and (substring(wtFin_child.strJoinOperator, len(wtFin_child.strJoinOperator) - 4, 3) = 'not')
									then	'not '
								else		''
							end
				from		tasQueryConditionGroup qcg
				inner join	@finalWhereTable wtFin_child
				on			wtFin_child.idfQueryConditionGroup = qcg.idfQueryConditionGroup
				left join	(
					tasQueryConditionGroup qcg_min
					inner join	@finalWhereTable wtFin_child_min
					on			wtFin_child_min.idfQueryConditionGroup = qcg_min.idfQueryConditionGroup
							)
				on			qcg_min.idfParentQueryConditionGroup = qcg.idfParentQueryConditionGroup
							and qcg_min.idfQueryConditionGroup < qcg.idfQueryConditionGroup
				where		qcg.idfParentQueryConditionGroup = @idfQueryConditionGroup
							and qcg_min.idfQueryConditionGroup is null
			end

			-- Generate final where condition (@strCurFinalWhere) for current bracket group
			select		@strCurFinalWhere = replace(@strCurFinalWhere, '{3}', wtFin_child.strJoinOperator + wtFin_child.strWhere + '{3}')
						
			from		tasQueryConditionGroup qcg
			inner join	@finalWhereTable wtFin_child
			on			wtFin_child.idfQueryConditionGroup = qcg.idfQueryConditionGroup
			where		qcg.idfParentQueryConditionGroup = @idfQueryConditionGroup
			order by	qcg.idfQueryConditionGroup


			-- Add generated values to @finalWhereTable
			insert into	@finalWhereTable
			(	idfQueryConditionGroup,
				strWhere, 
				strJoinOperator,
				whereLevel
			)
			values
			(
				@idfQueryConditionGroup,
				replace(@strCurFinalWhere, '{3}', ''),
				@strJoinOperator,
				@level
			)

			fetch next from TableCursor into 
				@idfQueryConditionGroup, @strWhere, @strJoinOperator, @strChildJoinOperator
		end
		close TableCursor
		deallocate TableCursor 

		set @level = @level - 1
	end

	-- Generate final where text
	select		@where = @where + @s + wtFin.strJoinOperator + replace(wtFin.strWhere, '{3}', '')
	from		@finalWhereTable wtFin
	where		wtFin.whereLevel = 0
	order by	wtFin.strJoinOperator, wtFin.strWhere

	-- Define condition for intRowStatus of main table
	declare	@intRowStatusWhere		nvarchar(300)
	set	@intRowStatusWhere = N''

	-- Define name of main table
	declare	@MainSearchTableName	nvarchar(200)
	set	@MainSearchTableName = null
	select		@MainSearchTableName = st.strTableName
	from		tasSearchTable st
	inner join	@fromTable ft
	on			ft.idfSearchTable = st.idfSearchTable
				and ft.fromLevel = 0

	if		@MainSearchTableName = N'AS Campaign'
			set	@intRowStatusWhere = N'ASCampaign.intRowStatus = 0 '
	else if	@MainSearchTableName = N'AS Session'
			set	@intRowStatusWhere = N'ASSession.intRowStatus = 0 '
	else if	@MainSearchTableName = N'Outbreak'
			set	@intRowStatusWhere = N'Outbreak.intRowStatus = 0 '

	-- Add @intRowStatusWhere to where condition if it is not empty
	if (len(rtrim(ltrim(@where))) > 10) and (len(@intRowStatusWhere) > 10)
		set @where = @intRowStatusWhere + 'and ' + @where
	else if	(len(rtrim(ltrim(@where))) <= 10)
		set	@where = @intRowStatusWhere

	-- Define additional condition in case the Add all reference values check-box is selected 
	-- and key fields are included in the query. 
	declare	@FullJoinCondition	nvarchar(500)
	set	@FullJoinCondition = N''

	if @BinKey > 0 and (len(rtrim(ltrim(@where))) > 10)
	begin
		if	@MainSearchTableName = N'Human Case'
			set	@FullJoinCondition = N'(HCCase.idfCase is null) '
		else if	@MainSearchTableName = N'Vet Case'
			set	@FullJoinCondition = N'(VCase.idfCase is null) '
		else if	@MainSearchTableName = N'AS Campaign'
			set	@FullJoinCondition = N'(ASCampaign.idfCampaign is null) '
		else if	@MainSearchTableName = N'AS Session'
			set	@FullJoinCondition = N'(ASSession.idfMonitoringSession is null) '
		else if	@MainSearchTableName = N'Outbreak'
			set	@FullJoinCondition = N'(Outbreak.idfOutbreak is null) '

		if	(len(rtrim(ltrim(@FullJoinCondition))) > 10)
		set @where = @where + N' or ' + @FullJoinCondition
	
	end


	-- Add 'where ' to where condition if it is not empty
	if (len(rtrim(ltrim(@where))) > 10)
		set @where = N'where ' + @where
	else
		set	@where = N''


	-- Create query function
	declare @sqlCmd nvarchar(2000)
	set @sqlCmd = '
SET QUOTED_IDENTIFIER ON 
'
	exec sp_executeSQL @sqlCmd

	set @sqlCmd = '
SET ANSI_NULLS ON 
'
	exec sp_executeSQL @sqlCmd
	set @sqlCmd = '

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N''[dbo].[' + @functionName + ']'') AND type in (N''FN'', N''IF'', N''TF'', N''FS'', N''FT''))
DROP FUNCTION [dbo].[' + @functionName + ']
'
	exec sp_executeSQL @sqlCmd

	set @query = '

CREATE FUNCTION [dbo].[' + @functionName + ']
(
	@LangID	as nvarchar(50)
)
returns table
as
return
' + @select + @from + @where + '

'
	exec sp_executeSQL @query 

	set @sqlCmd = '
SET QUOTED_IDENTIFIER OFF 
'
	exec sp_executeSQL @sqlCmd

	set @sqlCmd = '
SET ANSI_NULLS ON 
'
	exec sp_executeSQL @sqlCmd

	end
end


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
