 SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepHumMicrobiologyResearchCard ]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepHumMicrobiologyResearchCard ]


GO

--##SUMMARY Select data for Microbiology Research Card .
--##REMARKS Author: 
--##REMARKS Create date: 17.01.2011

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

exec spRepHumMicrobiologyResearchCard  'en', 'SGETBTBZ110001'

*/

CREATE  Procedure [dbo].[spRepHumMicrobiologyResearchCard ]
	(
		@LangID		as nvarchar(10), 
		@SampleID	as varchar(36),	 
		@LastName	as nvarchar(200) = null,
		@FirstName	as nvarchar(200) = null
	)
AS	

-- Field description may be found here
-- "https://repos.btrp.net/BTRP/Project_Documents/08x-Implementation/Customizations/GG/Reports/Specification for report development - Microbiology Research Card Human GG v1.0.doc"
-- by number marked red at screen form prototype 

declare	@ReportTable 	table
(	
	strSiteName				nvarchar(200), --1
	strSampleId				nvarchar(200), --2
	datSampleReceived		datetime,		 --3
	datSampleCollected		datetime,		--4
	strNameSurname			nvarchar(200), --6
	strAge					nvarchar(200), --7
	strResearchedSample		nvarchar(200), --8
	strSampleReceivedFrom	nvarchar(200), --9
	strResearchMethod		nvarchar(200), --10
	strResearchResult		nvarchar(max), --11
	strNotes				nvarchar(max), --12
	strDepartment			nvarchar(200), --13
	strTel					nvarchar(200), --14
	strResearchConductedBy	nvarchar(200), --15
	strDepartmentHead		nvarchar(200), --16
	datDateTested			datetime --17

)	

INSERT INTO @ReportTable (
	strSiteName,
	strSampleId,
	datSampleReceived,
	datSampleCollected,
	strNameSurname,
	strAge,
	strResearchedSample,
	strSampleReceivedFrom,
	strResearchMethod,
	strResearchResult,
	strNotes,
	strDepartment,
	strTel,
	strResearchConductedBy,
	strDepartmentHead,
	datDateTested
) 
SELECT 
  bpo.[Name] AS strSiteName,
  cn.strBarcode AS strSampleId,
  ain.datAccession AS datSampleReceived,
  m.datFieldCollectionDate AS datSampleCollected,
  ISNULL(h.strFirstName + ' ', '') + ISNULL(h.strLastName,'') AS strNameSurname,
  CAST(hc.intPatientAge AS NVARCHAR(10)) + N' (' + ref_age.[Name] + N')' AS strAge,
  ref_st.[Name] AS strResearchedSample,
  mcb.[Name]  AS strSampleReceivedFrom,
  NULL AS strResearchMethod,

--	cast(	(	select		ref_tt.[Name] + IsNull(N', ' + ref_tr.[Name], N'') + N'; '
--				from		(
--					tlbTesting t_all
--					inner join	fnReference(@LangID, 19000097) ref_tt	-- Test Type
--					on			ref_tt.idfsReference = t_all.idfsTestType
--					left join	fnReference (@LangID, 19000096) ref_tr	-- Test Result
--					on			ref_tr.idfsReference = t_all.idfsTestResult
--							)
--				inner join	tlbContainer cn_all
--				on			cn_all.idfContainer = t_all.idfContainer
--							and cn_all.intRowStatus = 0
--				inner join	tlbBatchTest bt_all
--				on			bt_all.idfBatchTest = t_all.idfBatchTest
--							and bt_all.intRowStatus = 0
--				where		t_all.idfsTestType in
--							(	--Removed from specification--840960000000, --Antibiotic Resistance
--								803570000000, --1% peptone water
--								803580000000, --10% peptone water
--								803590000000, --Acetic agar
--								803610000000, --Adonite fermentation
--								803680000000, --Alkali-Agar
--								803700000000, --AMOS PCR
--								803710000000, --Amylase fermentation
--								803720000000, --Amylum Fermentation
--								803740000000, --api 20 E
--								803750000000, --Arabinose fermentation
--								803760000000, --Arginindihidrolase test
--								803810000000, --B anthracis Anthrax PCR target 1
--								803820000000, --B anthracis Anthrax PCR target 2
--								803830000000, --B anthracis Anthrax PCR target 3
--								803870000000, --Bacteriophage lysis
--								803880000000, --Basic Fuchsin Agar
--								803890000000, --BCYE agar
--								803900000000, --Beta-galactosidase assay
--								803910000000, --Beta-lactamase assay
--								803920000000, --BHI broth
--								804010000000, --Brucella selective agar
--								804040000000, --C monophage
--								804090000000, --Catalase test
--								804110000000, --Chocolate agar
--								804150000000, --Christensen's Citrate Agar
--								804160000000, --Chrome agar
--								804170000000, --CIN agar
--								804250000000, --Cysteine heart agar (CHAB)
--								804260000000, --Cystinase test
--								804270000000, --D- tartrate fermentation
--								804330000000, --Dulcyte fermentation
--								804380000000, --El-tor-monophage
--								804390000000, --EMB agar
--								804400000000, --Endo Agar
--								804410000000, --Enzymecatalase Test
--								804620000000, --Francisella tularensis PCR 1
--								804630000000, --Francisella tularensis PCR 2
--								804640000000, --Gamma phage
--								804650000000, --Gelatine Test
--								804700000000, --Gluconic fermentation
--								804710000000, --Glutaminic acid test
--								804720000000, --Glycerol fermentation
--								804730000000, --Gram stain
--								804740000000, --Growth on chocolate cysteine agar
--								804750000000, --Growth on egg-yolk agar
--								804760000000, --Growth on liquid media
--								804780000000, --H2S production
--								804790000000, --Hecto agar
--								804810000000, --Heine's broth
--								804870000000, --Hugh-Leibson agar
--								804930000000, --Indole test
--								804970000000, --Inositol fermentation
--								805010000000, --Kligler combined agar
--								805020000000, --Lactose Fermentation
--								805090000000, --Lysindecarboxilase
--								805100000000, --MacConkey agar
--								805110000000, --Magnesium Agar
--								805120000000, --Malachite green Stain
--								805130000000, --Maltose fermentaiton
--								805140000000, --Manite fermentation
--								805150000000, --Mannose fermentation
--								805160000000, --Melibiose fermentation
--								805170000000, --MEP agar
--								805180000000, --Methylrot reaction
--								805200000000, --Microscopy
--								805220000000, --Motility Test
--								805230000000, --Mueller Hinton agar
--								805240000000, --Mukati test
--								805260000000, --Na Acetate agar
--								805270000000, --Na Malonate hydrolisis
--								805330000000, --Nitrate Reduction Test
--								805350000000, --Nutrient Broth
--								805360000000, --Optochin Test
--								805370000000, --Ornithindehydrase test
--								805380000000, --Ornitindecarboxilase test
--								805390000000, --Oxidase test
--								805400000000, --PCR
--								805440000000, --Phages: XDF-3, XDF-4, XDF-5
--								805450000000, --Phenylalaninedesaminase test
--								805460000000, --PLET agar
--								805470000000, --Ploskirev Agar
--								805520000000, --Preus's Urea test
--								805530000000, --Quick Tests For Malaria
--								805570000000, --Raffinose fermentation
--								805580000000, --Ramnose fermentation
--								805700000000, --Salicin test
--								805710000000, --Selenite Broth
--								805740000000, --Serum Agar
--								805760000000, --Sheep blood agar
--								805770000000, --Simmons's Citrate agar
--								805780000000, --Sorbite fermentation
--								805790000000, --Sorbitol-MacConkey Agar
--								805800000000, --Soya agar
--								805810000000, --Soya broth
--								805830000000, --SS agar
--								805840000000, --Sucrose fermentation
--								805850000000, --Sugar Broth
--								805870000000, --TCBS-Agar
--								805910000000, --Thayer-Martin agar
--								805930000000, --Thionine agar
--								805940000000, --Toxigenicity
--								805950000000, --Trehalose test
--								805960000000, --Triple Sugar Iron Agar (TSI)
--								806000000000, --Urea Test
--								806020000000, --Voges–Proskauer Test
--								806050000000, --Xylose fermentation
--								806070000000, --Yersinia pestis PCR target 1
--								806080000000, --Yersinia pestis PCR target 2
--								806090000000, --Yersinia phage
--								808090000000  --RT-PCR
--							)
--							and t_all.intRowStatus = 0
--							and cn_all.idfMaterial = m.idfMaterial
--							and cn_all.strBarcode = cn.strBarcode
--							and bt_all.idfPerformedByOffice = bt.idfPerformedByOffice
--				order by	ref_tt.[Name], bt_all.datValidatedDate, t_all.idfTesting
--				for	xml path('')
--			) as nvarchar(max)
--		)	as strResearchResult,
-- Changed in specification
  null as strResearchResult,
  cn.strNote AS strNotes,
  dep.[Name] AS strDepartment,
  bpo.strContactPhone AS strTel,
  ISNULL(pr_t.strFirstName + ' ', '') + ISNULL(pr_t.strFamilyName,'') AS  strResearchConductedBy,
  ISNULL(pr_v.strFirstName + ' ', '') + ISNULL(pr_v.strFamilyName,'') AS  strDepartmentHead,
  bt.datValidatedDate AS datDateTested

from		tlbTesting t
inner join	(
	tlbContainer cn
	left join	fnDepartment(@langid) dep
	on			dep.idfDepartment = cn.idfInDepartment
			)
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
	tlbBatchTest bt
	inner join	fnInstitution(@LangID) bpo
	on			bpo.idfOffice = bt.idfPerformedByOffice
	inner join	tstSite s
	on			s.idfOffice = bpo.idfOffice
				and s.idfsSite = dbo.fnSiteID()
				and s.intRowStatus = 0
	left join	(
		tlbEmployee e_t
		inner join	tlbPerson pr_t
		on			pr_t.idfPerson = e_t.idfEmployee
				)
	on			e_t.idfEmployee = bt.idfPerformedByPerson
				and e_t.intRowStatus = 0
	left join	(
		tlbEmployee e_v
		inner join	tlbPerson pr_v
		on			pr_v.idfPerson = e_v.idfEmployee
				)
	on			e_v.idfEmployee = bt.idfValidatedByPerson
				and e_v.intRowStatus = 0
			)
on			bt.idfBatchTest = t.idfBatchTest
			and bt.intRowStatus = 0
left join	(
	tlbTesting t_dupl
	inner join	tlbContainer cn_dupl
	on			cn_dupl.idfContainer = t_dupl.idfContainer
				and cn_dupl.intRowStatus = 0
	inner join	tlbBatchTest bt_dupl
	on			bt_dupl.idfBatchTest = t_dupl.idfBatchTest
				and bt_dupl.intRowStatus = 0
			)
on			t_dupl.idfsTestType in
			(	--Removed from specification--840960000000, --Antibiotic Resistance
				803570000000, --1% peptone water
				803580000000, --10% peptone water
				803590000000, --Acetic agar
				803610000000, --Adonite fermentation
				803680000000, --Alkali-Agar
				803700000000, --AMOS PCR
				803710000000, --Amylase fermentation
				803720000000, --Amylum Fermentation
				803740000000, --api 20 E
				803750000000, --Arabinose fermentation
				803760000000, --Arginindihidrolase test
				803810000000, --B anthracis Anthrax PCR target 1
				803820000000, --B anthracis Anthrax PCR target 2
				803830000000, --B anthracis Anthrax PCR target 3
				803870000000, --Bacteriophage lysis
				803880000000, --Basic Fuchsin Agar
				803890000000, --BCYE agar
				803900000000, --Beta-galactosidase assay
				803910000000, --Beta-lactamase assay
				803920000000, --BHI broth
				804010000000, --Brucella selective agar
				804040000000, --C monophage
				804090000000, --Catalase test
				804110000000, --Chocolate agar
				804150000000, --Christensen's Citrate Agar
				804160000000, --Chrome agar
				804170000000, --CIN agar
				804250000000, --Cysteine heart agar (CHAB)
				804260000000, --Cystinase test
				804270000000, --D- tartrate fermentation
				804330000000, --Dulcyte fermentation
				804380000000, --El-tor-monophage
				804390000000, --EMB agar
				804400000000, --Endo Agar
				804410000000, --Enzymecatalase Test
				804620000000, --Francisella tularensis PCR 1
				804630000000, --Francisella tularensis PCR 2
				804640000000, --Gamma phage
				804650000000, --Gelatine Test
				804700000000, --Gluconic fermentation
				804710000000, --Glutaminic acid test
				804720000000, --Glycerol fermentation
				804730000000, --Gram stain
				804740000000, --Growth on chocolate cysteine agar
				804750000000, --Growth on egg-yolk agar
				804760000000, --Growth on liquid media
				804780000000, --H2S production
				804790000000, --Hecto agar
				804810000000, --Heine's broth
				804870000000, --Hugh-Leibson agar
				804930000000, --Indole test
				804970000000, --Inositol fermentation
				805010000000, --Kligler combined agar
				805020000000, --Lactose Fermentation
				805090000000, --Lysindecarboxilase
				805100000000, --MacConkey agar
				805110000000, --Magnesium Agar
				805120000000, --Malachite green Stain
				805130000000, --Maltose fermentaiton
				805140000000, --Manite fermentation
				805150000000, --Mannose fermentation
				805160000000, --Melibiose fermentation
				805170000000, --MEP agar
				805180000000, --Methylrot reaction
				805200000000, --Microscopy
				805220000000, --Motility Test
				805230000000, --Mueller Hinton agar
				805240000000, --Mukati test
				805260000000, --Na Acetate agar
				805270000000, --Na Malonate hydrolisis
				805330000000, --Nitrate Reduction Test
				805350000000, --Nutrient Broth
				805360000000, --Optochin Test
				805370000000, --Ornithindehydrase test
				805380000000, --Ornitindecarboxilase test
				805390000000, --Oxidase test
				805400000000, --PCR
				805440000000, --Phages: XDF-3, XDF-4, XDF-5
				805450000000, --Phenylalaninedesaminase test
				805460000000, --PLET agar
				805470000000, --Ploskirev Agar
				805520000000, --Preus's Urea test
				805530000000, --Quick Tests For Malaria
				805570000000, --Raffinose fermentation
				805580000000, --Ramnose fermentation
				805700000000, --Salicin test
				805710000000, --Selenite Broth
				805740000000, --Serum Agar
				805760000000, --Sheep blood agar
				805770000000, --Simmons's Citrate agar
				805780000000, --Sorbite fermentation
				805790000000, --Sorbitol-MacConkey Agar
				805800000000, --Soya agar
				805810000000, --Soya broth
				805830000000, --SS agar
				805840000000, --Sucrose fermentation
				805850000000, --Sugar Broth
				805870000000, --TCBS-Agar
				805910000000, --Thayer-Martin agar
				805930000000, --Thionine agar
				805940000000, --Toxigenicity
				805950000000, --Trehalose test
				805960000000, --Triple Sugar Iron Agar (TSI)
				806000000000, --Urea Test
				806020000000, --Voges–Proskauer Test
				806050000000, --Xylose fermentation
				806070000000, --Yersinia pestis PCR target 1
				806080000000, --Yersinia pestis PCR target 2
				806090000000, --Yersinia phage
				808090000000  --RT-PCR
			)
			and t_dupl.intRowStatus = 0
			and cn_dupl.idfMaterial = m.idfMaterial
			and cn_dupl.strBarcode = cn.strBarcode
			and bt_dupl.idfPerformedByOffice = bt.idfPerformedByOffice
			and	(	(bt_dupl.datValidatedDate is not null and bt.datValidatedDate is null)
					or	(bt_dupl.datValidatedDate is not null and bt.datValidatedDate is not null and bt_dupl.datValidatedDate > bt.datValidatedDate)
					or	(bt_dupl.datValidatedDate is null and bt.datValidatedDate is null and t_dupl.idfTesting > t.idfTesting)
				)
where	t.idfsTestType in
		(	840960000000, --Antibiotic Resistance
			803570000000, --1% peptone water
			803580000000, --10% peptone water
			803590000000, --Acetic agar
			803610000000, --Adonite fermentation
			803680000000, --Alkali-Agar
			803700000000, --AMOS PCR
			803710000000, --Amylase fermentation
			803720000000, --Amylum Fermentation
			803740000000, --api 20 E
			803750000000, --Arabinose fermentation
			803760000000, --Arginindihidrolase test
			803810000000, --B anthracis Anthrax PCR target 1
			803820000000, --B anthracis Anthrax PCR target 2
			803830000000, --B anthracis Anthrax PCR target 3
			803870000000, --Bacteriophage lysis
			803880000000, --Basic Fuchsin Agar
			803890000000, --BCYE agar
			803900000000, --Beta-galactosidase assay
			803910000000, --Beta-lactamase assay
			803920000000, --BHI broth
			804010000000, --Brucella selective agar
			804040000000, --C monophage
			804090000000, --Catalase test
			804110000000, --Chocolate agar
			804150000000, --Christensen's Citrate Agar
			804160000000, --Chrome agar
			804170000000, --CIN agar
			804250000000, --Cysteine heart agar (CHAB)
			804260000000, --Cystinase test
			804270000000, --D- tartrate fermentation
			804330000000, --Dulcyte fermentation
			804380000000, --El-tor-monophage
			804390000000, --EMB agar
			804400000000, --Endo Agar
			804410000000, --Enzymecatalase Test
			804620000000, --Francisella tularensis PCR 1
			804630000000, --Francisella tularensis PCR 2
			804640000000, --Gamma phage
			804650000000, --Gelatine Test
			804700000000, --Gluconic fermentation
			804710000000, --Glutaminic acid test
			804720000000, --Glycerol fermentation
			804730000000, --Gram stain
			804740000000, --Growth on chocolate cysteine agar
			804750000000, --Growth on egg-yolk agar
			804760000000, --Growth on liquid media
			804780000000, --H2S production
			804790000000, --Hecto agar
			804810000000, --Heine's broth
			804870000000, --Hugh-Leibson agar
			804930000000, --Indole test
			804970000000, --Inositol fermentation
			805010000000, --Kligler combined agar
			805020000000, --Lactose Fermentation
			805090000000, --Lysindecarboxilase
			805100000000, --MacConkey agar
			805110000000, --Magnesium Agar
			805120000000, --Malachite green Stain
			805130000000, --Maltose fermentaiton
			805140000000, --Manite fermentation
			805150000000, --Mannose fermentation
			805160000000, --Melibiose fermentation
			805170000000, --MEP agar
			805180000000, --Methylrot reaction
			805200000000, --Microscopy
			805220000000, --Motility Test
			805230000000, --Mueller Hinton agar
			805240000000, --Mukati test
			805260000000, --Na Acetate agar
			805270000000, --Na Malonate hydrolisis
			805330000000, --Nitrate Reduction Test
			805350000000, --Nutrient Broth
			805360000000, --Optochin Test
			805370000000, --Ornithindehydrase test
			805380000000, --Ornitindecarboxilase test
			805390000000, --Oxidase test
			805400000000, --PCR
			805440000000, --Phages: XDF-3, XDF-4, XDF-5
			805450000000, --Phenylalaninedesaminase test
			805460000000, --PLET agar
			805470000000, --Ploskirev Agar
			805520000000, --Preus's Urea test
			805530000000, --Quick Tests For Malaria
			805570000000, --Raffinose fermentation
			805580000000, --Ramnose fermentation
			805700000000, --Salicin test
			805710000000, --Selenite Broth
			805740000000, --Serum Agar
			805760000000, --Sheep blood agar
			805770000000, --Simmons's Citrate agar
			805780000000, --Sorbite fermentation
			805790000000, --Sorbitol-MacConkey Agar
			805800000000, --Soya agar
			805810000000, --Soya broth
			805830000000, --SS agar
			805840000000, --Sucrose fermentation
			805850000000, --Sugar Broth
			805870000000, --TCBS-Agar
			805910000000, --Thayer-Martin agar
			805930000000, --Thionine agar
			805940000000, --Toxigenicity
			805950000000, --Trehalose test
			805960000000, --Triple Sugar Iron Agar (TSI)
			806000000000, --Urea Test
			806020000000, --Voges–Proskauer Test
			806050000000, --Xylose fermentation
			806070000000, --Yersinia pestis PCR target 1
			806080000000, --Yersinia pestis PCR target 2
			806090000000, --Yersinia phage
			808090000000  --RT-PCR
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
