SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spspecInsertToTranslation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spspecInsertToTranslation]
GO


/*
EXEC spspecInsertToTranslation
*/

CREATE    proc spspecInsertToTranslation
as

SET NOCOUNT ON 

delete		rt
from		EIDSS_Trans.dbo.tlkpReference_Type rt
left join	trtReferenceType rt_act
on			cast(rt_act.idfsReferenceType as varchar(20))  = rt.idfReference_Type
			and rt_act.idfsReferenceType in
				(	19000001,
					19000003,
					19000006,
					19000007,
					19000008,
					19000009,
					19000011,
					19000012,
					19000014,
					19000015,
					19000016,
					19000017,
					19000018,
					19000020,
					19000023,
					19000024,
					19000025,
					19000026,
					19000027,
					19000028,
					19000029,
					19000030,
					19000031,
					19000034,
					19000035,
					19000036,
					19000037,
					19000038,
					19000040,
					19000041,
					19000042,
					19000043,
					19000044,
					19000049,
					19000051,
					19000053,
					19000054,
					--19000055,
					19000056,
					19000057,
					19000059,
					19000060,
					19000061,
					19000062,
					19000063,
					19000064,
					19000065,
					19000067,
					19000068,
					--19000071,
					19000072,
					19000073,
					19000076,
					19000078,
					19000084,
					19000085,
					19000089,
					19000090,
					19000091,
					19000092,
					19000093,
					19000094,
					19000095,
					19000098,
					19000099,
					19000100,
					19000102,
					19000103,
					19000106,
					19000108,
					19000109,
					19000110,
					19000111,
					19000112,
					19000113,
					19000114,
					19000115,
					19000116,
					19000117,
					19000118,
					19000119,
					19000120,
					19000127,
					19000128,
					19000129,
					19000004,
					19000125,
					19000013,
					19000123,
					19000122,
					19000050,
					19000126,
					19000124,
					19000121,
					19000075,
					19000080,
					19000081,
					19000082,
					19000039
				)
where		rt_act.idfsReferenceType is null
PRINT 'New reference type deleted: ' + CAST(@@ROWCOUNT AS VARCHAR(200))

update		rt
set			rt.strTeference_Type_Name = rt_act.strReferenceTypeName
from		EIDSS_Trans.dbo.tlkpReference_Type rt
inner join	trtReferenceType rt_act
on			cast(rt_act.idfsReferenceType as varchar(20))  = rt.idfReference_Type
			and rt_act.idfsReferenceType in
				(	19000001,
					19000003,
					19000006,
					19000007,
					19000008,
					19000009,
					19000011,
					19000012,
					19000014,
					19000015,
					19000016,
					19000017,
					19000018,
					19000020,
					19000023,
					19000024,
					19000025,
					19000026,
					19000027,
					19000028,
					19000029,
					19000030,
					19000031,
					19000034,
					19000035,
					19000036,
					19000037,
					19000038,
					19000040,
					19000041,
					19000042,
					19000043,
					19000044,
					19000049,
					19000051,
					19000053,
					19000054,
					--19000055,
					19000056,
					19000057,
					19000059,
					19000060,
					19000061,
					19000062,
					19000063,
					19000064,
					19000065,
					19000067,
					19000068,
					--19000071,
					19000072,
					19000073,
					19000076,
					19000078,
					19000084,
					19000085,
					19000089,
					19000090,
					19000091,
					19000092,
					19000093,
					19000094,
					19000095,
					19000098,
					19000099,
					19000100,
					19000102,
					19000103,
					19000106,
					19000108,
					19000109,
					19000110,
					19000111,
					19000112,
					19000113,
					19000114,
					19000115,
					19000116,
					19000117,
					19000118,
					19000119,
					19000120,
					19000127,
					19000128,
					19000129,
					19000004,
					19000125,
					19000013,
					19000123,
					19000122,
					19000050,
					19000126,
					19000124,
					19000121,
					19000075,
					19000080,
					19000081,
					19000082,
					19000039
				)
PRINT 'New reference type updated: ' + CAST(@@ROWCOUNT AS VARCHAR(200))

insert into	EIDSS_Trans.dbo.tlkpReference_Type
(	idfReference_Type,
	strTeference_Type_Name
)
select		cast(rt_act.idfsReferenceType as varchar(20)),
			rt_act.strReferenceTypeName
from		trtReferenceType rt_act
left join	EIDSS_Trans.dbo.tlkpReference_Type rt_ex
on			rt_ex.idfReference_Type = cast(rt_act.idfsReferenceType as varchar(20))
where		rt_act.idfsReferenceType in
			(	19000001,
				19000003,
				19000006,
				19000007,
				19000008,
				19000009,
				19000011,
				19000012,
				19000014,
				19000015,
				19000016,
				19000017,
				19000018,
				19000020,
				19000023,
				19000024,
				19000025,
				19000026,
				19000027,
				19000028,
				19000029,
				19000030,
				19000031,
				19000034,
				19000035,
				19000036,
				19000037,
				19000038,
				19000040,
				19000041,
				19000042,
				19000043,
				19000044,
				19000049,
				19000051,
				19000053,
				19000054,
				--19000055,
				19000056,
				19000057,
				19000059,
				19000060,
				19000061,
				19000062,
				19000063,
				19000064,
				19000065,
				19000067,
				19000068,
				--19000071,
				19000072,
				19000073,
				19000076,
				19000078,
				19000084,
				19000085,
				19000089,
				19000090,
				19000091,
				19000092,
				19000093,
				19000094,
				19000095,
				19000098,
				19000099,
				19000100,
				19000102,
				19000103,
				19000106,
				19000108,
				19000109,
				19000110,
				19000111,
				19000112,
				19000113,
				19000114,
				19000115,
				19000116,
				19000117,
				19000118,
				19000119,
				19000120,
				19000127,
				19000128,
				19000129,
				19000004,
				19000125,
				19000013,
				19000123,
				19000122,
				19000050,
				19000126,
				19000124,
				19000121,
				19000075,
				19000080,
				19000081,
				19000082,
				19000039
			)
			and rt_ex.idfReference_Type is null
PRINT 'New reference type inserted: ' + CAST(@@ROWCOUNT AS VARCHAR(200))

delete	snt
from	trtStringNameTranslation snt
where	ISNULL(RTRIM(snt.strTextString),'') in ('','NULL')

declare	@col	int

insert into	trtStringNameTranslation
(	idfsBaseReference,
	idfsLanguage,
	strTextString,
	intRowStatus
)
select		br.idfsBaseReference, 
			dbo.fnGetLanguageCode('en'),
			br.strDefault,
			0
from		trtBaseReference br
left join	trtStringNameTranslation snt
on			snt.idfsBaseReference = br.idfsBaseReference
			and snt.idfslanguage = dbo.fnGetLanguageCode('en')
where		br.intRowStatus = 0
			and snt.idfsBaseReference is null
set	@col = @@ROWCOUNT	

update		snt
set			snt.strTextString = br.strDefault,
			snt.intRowStatus = 0
from		trtStringNameTranslation snt
inner join	trtBaseReference br
on			br.idfsBaseReference = snt.idfsBaseReference
			and br.intRowStatus = 0
where		snt.idfslanguage = dbo.fnGetLanguageCode('en')
			and snt.intRowStatus = 1
set	@col = @@ROWCOUNT + @col 
PRINT 'Set new English values (correction): ' + CAST(@col AS VARCHAR(200))

delete		r
from		EIDSS_Trans.dbo.tlkpReference r
left join	(
	trtStringNameTranslation snt
	inner join	trtBaseReference br_lng
	on			br_lng.idfsBaseReference = snt.idfsLanguage
	inner join	trtBaseReference br
	on			br.idfsBaseReference = snt.idfsBaseReference
				and br.intRowStatus = 0
				and br.idfsReferenceType in
					(	19000001,
						19000003,
						19000006,
						19000007,
						19000008,
						19000009,
						19000011,
						19000012,
						19000014,
						19000015,
						19000016,
						19000017,
						19000018,
						19000020,
						19000023,
						19000024,
						19000025,
						19000026,
						19000027,
						19000028,
						19000029,
						19000030,
						19000031,
						19000034,
						19000035,
						19000036,
						19000037,
						19000038,
						19000040,
						19000041,
						19000042,
						19000043,
						19000044,
						19000049,
						19000051,
						19000053,
						19000054,
						--19000055,
						19000056,
						19000057,
						19000059,
						19000060,
						19000061,
						19000062,
						19000063,
						19000064,
						19000065,
						19000067,
						19000068,
						--19000071,
						19000072,
						19000073,
						19000076,
						19000078,
						19000084,
						19000085,
						19000089,
						19000090,
						19000091,
						19000092,
						19000093,
						19000094,
						19000095,
						19000098,
						19000099,
						19000100,
						19000102,
						19000103,
						19000106,
						19000108,
						19000109,
						19000110,
						19000111,
						19000112,
						19000113,
						19000114,
						19000115,
						19000116,
						19000117,
						19000118,
						19000119,
						19000120,
						19000127,
						19000128,
						19000129,
						19000004,
						19000125,
						19000013,
						19000123,
						19000122,
						19000050,
						19000126,
						19000124,
						19000121,
						19000075,
						19000080,
						19000081,
						19000082,
						19000039
					)
	inner join	EIDSS_Trans.dbo.tlkpLanguage l
	on			l.idfLanguage = br_lng.strBaseReferenceCode
			)
on			cast(snt.idfsBaseReference as varchar(20)) = r.idfReference
			and br_lng.strBaseReferenceCode = r.idfLanguage
			and snt.intRowStatus = 0
where		snt.idfsBaseReference is null
PRINT 'New reference deleted: ' + CAST(@@ROWCOUNT AS VARCHAR(200))

update		r
set			r.strReference_Text = snt.strTextString,
			r.idfReference_Type = cast(br.idfsReferenceType as varchar(20))
from		EIDSS_Trans.dbo.tlkpReference r
inner join	(
	trtStringNameTranslation snt
	inner join	trtBaseReference br_lng
	on			br_lng.idfsBaseReference = snt.idfsLanguage
	inner join	trtBaseReference br
	on			br.idfsBaseReference = snt.idfsBaseReference
				and br.intRowStatus = 0
				and br.idfsReferenceType in
					(	19000001,
						19000003,
						19000006,
						19000007,
						19000008,
						19000009,
						19000011,
						19000012,
						19000014,
						19000015,
						19000016,
						19000017,
						19000018,
						19000020,
						19000023,
						19000024,
						19000025,
						19000026,
						19000027,
						19000028,
						19000029,
						19000030,
						19000031,
						19000034,
						19000035,
						19000036,
						19000037,
						19000038,
						19000040,
						19000041,
						19000042,
						19000043,
						19000044,
						19000049,
						19000051,
						19000053,
						19000054,
						--19000055,
						19000056,
						19000057,
						19000059,
						19000060,
						19000061,
						19000062,
						19000063,
						19000064,
						19000065,
						19000067,
						19000068,
						--19000071,
						19000072,
						19000073,
						19000076,
						19000078,
						19000084,
						19000085,
						19000089,
						19000090,
						19000091,
						19000092,
						19000093,
						19000094,
						19000095,
						19000098,
						19000099,
						19000100,
						19000102,
						19000103,
						19000106,
						19000108,
						19000109,
						19000110,
						19000111,
						19000112,
						19000113,
						19000114,
						19000115,
						19000116,
						19000117,
						19000118,
						19000119,
						19000120,
						19000127,
						19000128,
						19000129,
						19000004,
						19000125,
						19000013,
						19000123,
						19000122,
						19000050,
						19000126,
						19000124,
						19000121,
						19000075,
						19000080,
						19000081,
						19000082,
						19000039
					)
	inner join	EIDSS_Trans.dbo.tlkpLanguage l
	on			l.idfLanguage = br_lng.strBaseReferenceCode
			)
on			cast(snt.idfsBaseReference as varchar(20)) = r.idfReference
			and br_lng.strBaseReferenceCode = r.idfLanguage
			and snt.intRowStatus = 0
PRINT 'New reference updated: ' + CAST(@@ROWCOUNT AS VARCHAR(200))

insert into	EIDSS_Trans.dbo.tlkpReference
(	strReference_Text, 
	idfReference, 
	idfReference_Type, 
	idfLanguage
)
select		snt.strTextString, 
			cast(snt.idfsBaseReference as varchar(20)),
			cast(br.idfsReferenceType as varchar(20)),
			br_lng.strBaseReferenceCode
from		trtStringNameTranslation snt
inner join	trtBaseReference br_lng
on			br_lng.idfsBaseReference = snt.idfsLanguage
inner join	trtBaseReference br
on			br.idfsBaseReference = snt.idfsBaseReference
			and br.intRowStatus = 0
			and br.idfsReferenceType in
				(	19000001,
					19000003,
					19000006,
					19000007,
					19000008,
					19000009,
					19000011,
					19000012,
					19000014,
					19000015,
					19000016,
					19000017,
					19000018,
					19000020,
					19000023,
					19000024,
					19000025,
					19000026,
					19000027,
					19000028,
					19000029,
					19000030,
					19000031,
					19000034,
					19000035,
					19000036,
					19000037,
					19000038,
					19000040,
					19000041,
					19000042,
					19000043,
					19000044,
					19000049,
					19000051,
					19000053,
					19000054,
					--19000055,
					19000056,
					19000057,
					19000059,
					19000060,
					19000061,
					19000062,
					19000063,
					19000064,
					19000065,
					19000067,
					19000068,
					--19000071,
					19000072,
					19000073,
					19000076,
					19000078,
					19000084,
					19000085,
					19000089,
					19000090,
					19000091,
					19000092,
					19000093,
					19000094,
					19000095,
					19000098,
					19000099,
					19000100,
					19000102,
					19000103,
					19000106,
					19000108,
					19000109,
					19000110,
					19000111,
					19000112,
					19000113,
					19000114,
					19000115,
					19000116,
					19000117,
					19000118,
					19000119,
					19000120,
					19000127,
					19000128,
					19000129,
					19000004,
					19000125,
					19000013,
					19000123,
					19000122,
					19000050,
					19000126,
					19000124,
					19000121,
					19000075,
					19000080,
					19000081,
					19000082,
					19000039
				)
inner join	EIDSS_Trans.dbo.tlkpLanguage l
on			l.idfLanguage = br_lng.strBaseReferenceCode
left join	EIDSS_Trans.dbo.tlkpReference r
on			r.idfReference = cast(snt.idfsBaseReference as varchar(20))
			and r.idfLanguage = br_lng.strBaseReferenceCode
where		snt.intRowStatus = 0
			and r.idfReference is null
PRINT 'New reference inserted: ' + CAST(@@ROWCOUNT AS VARCHAR(200))

SET NOCOUNT OFF 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

