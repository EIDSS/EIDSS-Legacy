 SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepHumSerologyResearchCard]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepHumSerologyResearchCard]


GO

--##SUMMARY Select data for Serology Research Card .
--##REMARKS Author: 
--##REMARKS Create date: 17.01.2011

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

exec spRepHumSerologyResearchCard 'ru', 'SGETBTBZ110001'

*/

CREATE  Procedure [dbo].[spRepHumSerologyResearchCard]
	(
		@LangID		as nvarchar(10), 
		@SampleID	as varchar(36),	 
		@LastName	as nvarchar(200) = null,
		@FirstName	as nvarchar(200) = null
	)
AS	

-- Field description may be found here
-- "https://repos.btrp.net/BTRP/Project_Documents/08x-Implementation/Customizations/GG/Reports/Specification for report development - Serology Research Card Human GG v1.0.doc"
-- by number marked red at screen form prototype 

declare	@ReportTable 	table
(	
	strSiteName				nvarchar(200), --1
	strSampleId				nvarchar(200), --2
	datSampleReceived		datetime,	   --3
	strNameSurname			nvarchar(200), --4
	strAge					nvarchar(200), --5
	strResearchedSample		nvarchar(200), --6
	strSampleReceivedFrom	nvarchar(200), --7

	strResearchMethod		nvarchar(200), --9
	strConductedResearch	nvarchar(200), --10
	strDiagnosticalMeaning	nvarchar(200), --13

	strNotes				nvarchar(max), --14
	strDepartment			nvarchar(200), --15
	strTel					nvarchar(200), --16
	strResearchConductedBy	nvarchar(200), --17
	strDepartmentHead		nvarchar(200), --18
	datDateTested			datetime		--19
)	

INSERT INTO @ReportTable (
	strSiteName,
	strSampleId,
	datSampleReceived,
	strNameSurname,
	strAge,
	strResearchedSample,
	strSampleReceivedFrom,
	strResearchMethod,
	strConductedResearch,
	strDiagnosticalMeaning,
	strNotes,
	strDepartment,
	strTel,
	strResearchConductedBy,
	strDepartmentHead,
	datDateTested
) 
SELECT 
  bpo.[Name] AS strSiteName,
  cn_last.strBarcode AS strSampleId,
  ain.datAccession AS datSampleReceived,
  ISNULL(h.strFirstName + ' ', '') + ISNULL(h.strLastName,'') AS strNameSurname,
  CAST(hc.intPatientAge AS NVARCHAR(10)) + N' (' + ref_age.[Name] + N')' AS strAge,
  ref_st.[Name] AS strResearchedSample,
  mcb.[Name]  AS strSampleReceivedFrom,
  
  ref_tt.[Name] AS strResearchMethod,
  ref_td.[Name] AS strConductedResearch,
  ref_tr.[Name] AS strDiagnosticalMeaning,
  
  cn_last.strNote AS strNotes,
  dep.[Name] AS strDepartment,
  bpo.strContactPhone AS strTel,
  ISNULL(pr_t.strFirstName + ' ', '') + ISNULL(pr_t.strFamilyName,'') AS  strResearchConductedBy,
  ISNULL(pr_v.strFirstName + ' ', '') + ISNULL(pr_v.strFamilyName,'') AS  strDepartmentHead,
  bt_last.datValidatedDate AS datDateTested
from		(
	tlbTesting t
	inner join	fnReference(@LangID, 19000097) ref_tt	-- Test Type
	on			ref_tt.idfsReference = t.idfsTestType
	inner join	(
		tlbBatchTest bt
		inner join	tstSite s
		on			s.idfOffice = bt.idfPerformedByOffice
					and s.idfsSite = dbo.fnSiteID()
					and s.intRowStatus = 0
				)
	on			bt.idfBatchTest = t.idfBatchTest
				and bt.intRowStatus = 0
	left join	fnReference (@LangID, 19000096) ref_tr	-- Test Result
	on			t.idfsTestResult = ref_tr.idfsReference
	left join	fnReference(@LangID, 19000019) ref_td	-- Diagnosis
	on			ref_td.idfsReference = t.idfsDiagnosis
			)
inner join	tlbContainer cn
on			cn.idfContainer = t.idfContainer
			and cn.intRowStatus = 0
inner join	(
	tlbMaterial m
	inner join	fnReference(@LangID, 19000087) ref_st	-- Sample Type
	on			ref_st.idfsReference = m.idfsSpecimenType
	left join	tlbAccessionIn ain
	on			ain.idfMaterial = m.idfMaterial
	left join	fnInstitution(@LangID) mcb
	on			mcb.idfOffice = m.idfFieldCollectedByOffice
			)
on			m.idfMaterial = cn.idfMaterial
			and m.intRowStatus = 0
inner join	(
	tlbParty p
	inner join	tlbHuman h
	on			h.idfHuman = p.idfParty
			)
on			p.idfParty = m.idfParty
			and p.idfsPartyType = 10072006	-- Human
			and p.intRowStatus = 0
inner join	(
	tlbCase c
	inner join	tlbHumanCase hc
	on			hc.idfHumanCase = c.idfCase
	left join	fnReference(@LangID, 19000042) ref_age	-- Human Age Type
	on			ref_age.idfsReference = hc.idfsHumanAgeType
			)
on			c.idfCase = p.idfCase
			and c.intRowStatus = 0
inner join	(
	tlbBatchTest bt_last
	inner join	tlbTesting t_last
	on			t_last.idfBatchTest = bt_last.idfBatchTest
	inner join	(
		tlbContainer cn_last
		left join	fnDepartment(@langid) dep
		on			dep.idfDepartment = cn_last.idfInDepartment
				)
	on			cn_last.idfContainer = t_last.idfContainer
				and cn_last.intRowStatus = 0
	inner join	fnInstitution(@LangID) bpo
	on			bpo.idfOffice = bt_last.idfPerformedByOffice
	left join	(
		tlbEmployee e_t
		inner join	tlbPerson pr_t
		on			pr_t.idfPerson = e_t.idfEmployee
				)
	on			e_t.idfEmployee = bt_last.idfPerformedByPerson
				and e_t.intRowStatus = 0
	left join	(
		tlbEmployee e_v
		inner join	tlbPerson pr_v
		on			pr_v.idfPerson = e_v.idfEmployee
				)
	on			e_v.idfEmployee = bt_last.idfValidatedByPerson
				and e_v.intRowStatus = 0
			)
on			cn_last.idfMaterial = m.idfMaterial
			and cn_last.strBarcode = cn.strBarcode
			and bt_last.idfPerformedByOffice = bt.idfPerformedByOffice
			and bt_last.intRowStatus = 0
			and t_last.idfsTestType in
				(	803600000000, --Acriflavine agglutination test
					803620000000, --Agglutination Test
					803840000000, --B anthracis DFA Polyaccharide
					803970000000, --Botulinum toxin
					804120000000, --Cholerae Agglutination Test for Vibrio cholerae O1 antibody
					804130000000, --Cholerae Agglutination Test for Vibrio cholerae O139 antibody
					804140000000, --Cholerae RO diagnostic serum
					804420000000, --Enzyme-linked immunosorbent assay (ELISA). Antibody detection
					804430000000, --Enzyme-linked immunosorbent assay (ELISA). Antigen and Antibody detection
					804440000000, --Enzyme-linked immunosorbent assay (ELISA). Antigen detection; Immunochromatography
					804450000000, --Enzyme-linked immunosorbent assay (ELISA). IgG and IgM detection
					804460000000, --Enzyme-linked immunosorbent assay (ELISA). IgG and IgM detection, by phases
					804470000000, --Enzyme-linked immunosorbent assay (ELISA). IgG and IgM detection; Ag detection
					804610000000, --Francisella tularensis DFA
					804800000000, --Hedelson Reaction
					804880000000, --Hyperimmune V. cholerae serotype Inaba serum
					804890000000, --Hyperimmune V. cholerae serotype Ozava serum
					805290000000, --Neutralization Reaction
					805480000000, --Policlonal Serum Agglutination Test
					805690000000, --S.pneumoniae And Streptococcus B serum Latex Agglutination Test
					805730000000, --Serotype agglutination test
					806030000000, --Wright Reaction
					806060000000, --Y. pestis DFA F1antigen
					804770000000, --H.influenzae "b" Serum Latex Agglutination Test
					805040000000, --Latex Agglutination test for N.meningitidis A,B,C,W135 Serogroups
					803850000000  --B anthracis DFA Poly-D-glutamic acid
				)
left join		(
	tlbBatchTest bt_dupl
	inner join	tlbTesting t_dupl
	on			t_dupl.idfBatchTest = bt_dupl.idfBatchTest
	inner join	tlbContainer cn_dupl
	on			cn_dupl.idfContainer = t_dupl.idfContainer
				and cn_dupl.intRowStatus = 0
				)
on			cn_dupl.idfMaterial = m.idfMaterial
			and cn_dupl.strBarcode = cn.strBarcode
			and bt_dupl.idfPerformedByOffice = bt.idfPerformedByOffice
			and bt_dupl.intRowStatus = 0
			and t_dupl.idfsTestType in
				(	803600000000, --Acriflavine agglutination test
					803620000000, --Agglutination Test
					803840000000, --B anthracis DFA Polyaccharide
					803970000000, --Botulinum toxin
					804120000000, --Cholerae Agglutination Test for Vibrio cholerae O1 antibody
					804130000000, --Cholerae Agglutination Test for Vibrio cholerae O139 antibody
					804140000000, --Cholerae RO diagnostic serum
					804420000000, --Enzyme-linked immunosorbent assay (ELISA). Antibody detection
					804430000000, --Enzyme-linked immunosorbent assay (ELISA). Antigen and Antibody detection
					804440000000, --Enzyme-linked immunosorbent assay (ELISA). Antigen detection; Immunochromatography
					804450000000, --Enzyme-linked immunosorbent assay (ELISA). IgG and IgM detection
					804460000000, --Enzyme-linked immunosorbent assay (ELISA). IgG and IgM detection, by phases
					804470000000, --Enzyme-linked immunosorbent assay (ELISA). IgG and IgM detection; Ag detection
					804610000000, --Francisella tularensis DFA
					804800000000, --Hedelson Reaction
					804880000000, --Hyperimmune V. cholerae serotype Inaba serum
					804890000000, --Hyperimmune V. cholerae serotype Ozava serum
					805290000000, --Neutralization Reaction
					805480000000, --Policlonal Serum Agglutination Test
					805690000000, --S.pneumoniae And Streptococcus B serum Latex Agglutination Test
					805730000000, --Serotype agglutination test
					806030000000, --Wright Reaction
					806060000000, --Y. pestis DFA F1antigen
					804770000000, --H.influenzae "b" Serum Latex Agglutination Test
					805040000000, --Latex Agglutination test for N.meningitidis A,B,C,W135 Serogroups
					803850000000  --B anthracis DFA Poly-D-glutamic acid
				)
			and	(	(bt_dupl.datValidatedDate is not null and bt_last.datValidatedDate is null)
					or	(bt_dupl.datValidatedDate is not null and bt_last.datValidatedDate is not null and bt_dupl.datValidatedDate > bt_last.datValidatedDate)
					or	(bt_dupl.datValidatedDate is null and bt_last.datValidatedDate is null and t_dupl.idfTesting > t_last.idfTesting)
				)
where	t.idfsTestType in
		(	803600000000, --Acriflavine agglutination test
			803620000000, --Agglutination Test
			803840000000, --B anthracis DFA Polyaccharide
			803970000000, --Botulinum toxin
			804120000000, --Cholerae Agglutination Test for Vibrio cholerae O1 antibody
			804130000000, --Cholerae Agglutination Test for Vibrio cholerae O139 antibody
			804140000000, --Cholerae RO diagnostic serum
			804420000000, --Enzyme-linked immunosorbent assay (ELISA). Antibody detection
			804430000000, --Enzyme-linked immunosorbent assay (ELISA). Antigen and Antibody detection
			804440000000, --Enzyme-linked immunosorbent assay (ELISA). Antigen detection; Immunochromatography
			804450000000, --Enzyme-linked immunosorbent assay (ELISA). IgG and IgM detection
			804460000000, --Enzyme-linked immunosorbent assay (ELISA). IgG and IgM detection, by phases
			804470000000, --Enzyme-linked immunosorbent assay (ELISA). IgG and IgM detection; Ag detection
			804610000000, --Francisella tularensis DFA
			804800000000, --Hedelson Reaction
			804880000000, --Hyperimmune V. cholerae serotype Inaba serum
			804890000000, --Hyperimmune V. cholerae serotype Ozava serum
			805290000000, --Neutralization Reaction
			805480000000, --Policlonal Serum Agglutination Test
			805690000000, --S.pneumoniae And Streptococcus B serum Latex Agglutination Test
			805730000000, --Serotype agglutination test
			806030000000, --Wright Reaction
			806060000000, --Y. pestis DFA F1antigen
			804770000000, --H.influenzae "b" Serum Latex Agglutination Test
			805040000000, --Latex Agglutination test for N.meningitidis A,B,C,W135 Serogroups
			803850000000  --B anthracis DFA Poly-D-glutamic acid
		)
		and t.intRowStatus = 0
		and t_dupl.idfTesting is null
		and cn.strBarcode = @SampleID
		and ((h.strLastName like @LastName + '%') OR IsNull(@LastName, N'') = N'')
		and ((h.strFirstName like @FirstName + '%') OR IsNull(@FirstName, N'') = N'')


select * 
from @ReportTable

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 