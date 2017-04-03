 SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepAntibioticResistanceCard]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepAntibioticResistanceCard]


GO

--##SUMMARY Select data for Antibiotic Resistance.
--##REMARKS Author: 
--##REMARKS Create date: 17.01.2011

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

exec spRepAntibioticResistanceCard 'ru', 'aa'

*/

CREATE  Procedure [dbo].[spRepAntibioticResistanceCard]
	(
		@LangID		as nvarchar(10), 
		@SampleID	as varchar(36),	 
		@LastName	as nvarchar(200) = null,
		@FirstName	as nvarchar(200) = null
	)
AS	

-- Field description may be found here
-- "https://repos.btrp.net/BTRP/Project_Documents/08x-Implementation/Customizations/GG/Reports/Specification for report development - Antibiotic Resistance Card GG v1.0.doc"
-- by number marked red at screen form prototype 

declare	@ReportTable 	table
(	
	strCulture				nvarchar(200), --1
	datDateTestConducted	datetime,		--3
	strAmikacin 			nvarchar(200), --8
	strAmpicillin 			nvarchar(200), --9
	strAmoxicillinClavAcid 	nvarchar(200), --10
	strAmoxicillin 			nvarchar(200), --11
	strAztreonam 			nvarchar(200), --12
	strAzithromicin 		nvarchar(200), --13
	strCarbenicillin 		nvarchar(200), --14
	strCefazolin 			nvarchar(200), --15
	strCefotaxime 			nvarchar(200), --16
	strCeftazidime 			nvarchar(200), --17
	strCefotaxine  			nvarchar(200), --18
	strCefoperazone 		nvarchar(200), --19
	strChoramphenicol 		nvarchar(200), --20
	strCeftriaxone 			nvarchar(200), --21
	strCefepime 			nvarchar(200), --22
	strCefoxitine 			nvarchar(200), --23
	strCiprofloxacin 		nvarchar(200), --24
	strColistineColomycin 	nvarchar(200), --25
	strCefuroxime 			nvarchar(200), --26
	strCephalotin 			nvarchar(200), --27
	strClindamycin 			nvarchar(200), --28
	strDoxycycline 			nvarchar(200), --29
	strErythromycin 		nvarchar(200), --30
	strFosfumycin 			nvarchar(200), --31
	strGentamicin 			nvarchar(200), --32
	strImipenem 			nvarchar(200), --33
	strNorfloxacin 			nvarchar(200), --34
	strNalidixicAcid 		nvarchar(200), --35
	strNitrofurantoin 		nvarchar(200), --36
	strNetilmicin 			nvarchar(200), --37
	strOfloxacin 			nvarchar(200), --38
	strOxacillin 			nvarchar(200), --39
	strPenicillin 			nvarchar(200), --40
	strPiperacillin 		nvarchar(200), --41
	strRifampin 			nvarchar(200), --42
	strStreptomicin 		nvarchar(200), --43
	strSulfonamides 		nvarchar(200), --44
	strTetracycline 		nvarchar(200), --45
	strTicarcillin 			nvarchar(200), --46
	strTobramycin 			nvarchar(200), --47
	strTrimethoprimSulfo 	nvarchar(200), --48
	strVancomycin			nvarchar(200), -- 49
	strResearchConductedBy	nvarchar(200) --50
)	


DECLARE 
  @Ant_Resistance_ReferenceType BIGINT,
	@strCulture				nvarchar(200), --1
	@datDateTestConducted	datetime,		--3
	@strResearchConductedBy	nvarchar(200), --50
	@idfObservation BIGINT,
	
  @ffp_Amikacin BIGINT,
	@ffp_Ampicillin BIGINT, --9
	@ffp_AmoxicillinClavAcid BIGINT, --10
	@ffp_Amoxicillin BIGINT, --11
	@ffp_Aztreonam BIGINT, --12
	@ffp_Azithromicin BIGINT, --13
	@ffp_Carbenicillin BIGINT, --14
	@ffp_Cefazolin BIGINT, --15
	@ffp_Cefotaxime BIGINT, --16
	@ffp_Ceftazidime BIGINT, --17
	@ffp_Cefotaxine BIGINT, --18
	@ffp_Cefoperazone BIGINT, --19
	@ffp_Choramphenicol BIGINT, --20
	@ffp_Ceftriaxone BIGINT, --21
	@ffp_Cefepime BIGINT, --22
	@ffp_Cefoxitine BIGINT, --23
	@ffp_Ciprofloxacin BIGINT, --24
	@ffp_ColistineColomycin BIGINT, --25
	@ffp_Cefuroxime BIGINT, --26
	@ffp_Cephalotin BIGINT, --27
	@ffp_Clindamycin BIGINT, --28
	@ffp_Doxycycline BIGINT, --29
	@ffp_Erythromycin BIGINT, --30
	@ffp_Fosfumycin BIGINT, --31
	@ffp_Gentamicin BIGINT, --32
	@ffp_Imipenem BIGINT, --33
	@ffp_Norfloxacin BIGINT, --34
	@ffp_NalidixicAcid BIGINT, --35
	@ffp_Nitrofurantoin BIGINT, --36
	@ffp_Netilmicin BIGINT, --37
	@ffp_Ofloxacin BIGINT, --38
	@ffp_Oxacillin BIGINT, --39
	@ffp_Penicillin BIGINT, --40
	@ffp_Piperacillin BIGINT, --41
	@ffp_Rifampin BIGINT, --42
	@ffp_Streptomicin BIGINT, --43
	@ffp_Sulfonamides BIGINT, --44
	@ffp_Tetracycline BIGINT, --45
	@ffp_Ticarcillin BIGINT, --46
	@ffp_Tobramycin BIGINT, --47
	@ffp_TrimethoprimSulfo BIGINT, --48
	@ffp_Vancomycin BIGINT,

	@strAmikacin 			nvarchar(200), --8
	@strAmpicillin 			nvarchar(200), --9
	@strAmoxicillinClavAcid 	nvarchar(200), --10
	@strAmoxicillin 			nvarchar(200), --11
	@strAztreonam 			nvarchar(200), --12
	@strAzithromicin 		nvarchar(200), --13
	@strCarbenicillin 		nvarchar(200), --14
	@strCefazolin 			nvarchar(200), --15
	@strCefotaxime 			nvarchar(200), --16
	@strCeftazidime 			nvarchar(200), --17
	@strCefotaxine  			nvarchar(200), --18
	@strCefoperazone 		nvarchar(200), --19
	@strChoramphenicol 		nvarchar(200), --20
	@strCeftriaxone 			nvarchar(200), --21
	@strCefepime 			nvarchar(200), --22
	@strCefoxitine 			nvarchar(200), --23
	@strCiprofloxacin 		nvarchar(200), --24
	@strColistineColomycin 	nvarchar(200), --25
	@strCefuroxime 			nvarchar(200), --26
	@strCephalotin 			nvarchar(200), --27
	@strClindamycin 			nvarchar(200), --28
	@strDoxycycline 			nvarchar(200), --29
	@strErythromycin 		nvarchar(200), --30
	@strFosfumycin 			nvarchar(200), --31
	@strGentamicin 			nvarchar(200), --32
	@strImipenem 			nvarchar(200), --33
	@strNorfloxacin 			nvarchar(200), --34
	@strNalidixicAcid 		nvarchar(200), --35
	@strNitrofurantoin 		nvarchar(200), --36
	@strNetilmicin 			nvarchar(200), --37
	@strOfloxacin 			nvarchar(200), --38
	@strOxacillin 			nvarchar(200), --39
	@strPenicillin 			nvarchar(200), --40
	@strPiperacillin 		nvarchar(200), --41
	@strRifampin 			nvarchar(200), --42
	@strStreptomicin 		nvarchar(200), --43
	@strSulfonamides 		nvarchar(200), --44
	@strTetracycline 		nvarchar(200), --45
	@strTicarcillin 			nvarchar(200), --46
	@strTobramycin 			nvarchar(200), --47
	@strTrimethoprimSulfo 	nvarchar(200), --48
	@strVancomycin			nvarchar(200) -- 49
	
  SET @ffp_Amikacin = 1027790000000 
	SET @ffp_Ampicillin = 1027990000000  --9
	SET @ffp_AmoxicillinClavAcid = 1027950000000  --10
	SET @ffp_Amoxicillin = 1027910000000  --11
	SET @ffp_Aztreonam = 1032620000000  --12
	SET @ffp_Azithromicin = 1032500000000  --13
	SET @ffp_Carbenicillin = 1034910000000  --14
	SET @ffp_Cefazolin = 1035130000000  --15
	SET @ffp_Cefotaxime = 1035250000000  --16
	SET @ffp_Ceftazidime = 1035370000000  --17
	SET @ffp_Cefotaxine = 1035290000000  --18
	SET @ffp_Cefoperazone = 1035210000000  --19
	SET @ffp_Choramphenicol = 1036070000000  --20
	SET @ffp_Ceftriaxone = 1035410000000  --21
	SET @ffp_Cefepime = 1035170000000  --22
	SET @ffp_Cefoxitine = 1035330000000  --23
	SET @ffp_Ciprofloxacin = 1036150000000  --24
	SET @ffp_ColistineColomycin = 1038030000000  --25
	SET @ffp_Cefuroxime = 1035450000000  --26
	SET @ffp_Cephalotin = 1035570000000  --27
	SET @ffp_Clindamycin = 1036830000000  --28
	SET @ffp_Doxycycline = 1061070000000  --29
	SET @ffp_Erythromycin = 1066040000000  --30
	SET @ffp_Fosfumycin = 1069120000000  --31
	SET @ffp_Gentamicin = 1069400000000  --32
	SET @ffp_Imipenem = 1077330000000  --33
	SET @ffp_Norfloxacin = 1091380000000  --34
	SET @ffp_NalidixicAcid = 1088660000000  --35
	SET @ffp_Nitrofurantoin = 1091180000000  --36
	SET @ffp_Netilmicin = 1090820000000  --37
	SET @ffp_Ofloxacin = 1094970000000  --38
	SET @ffp_Oxacillin = 1098680000000  --39
	SET @ffp_Penicillin = 1101260000000  --40
	SET @ffp_Piperacillin = 1103060000000  --41
	SET @ffp_Rifampin = 1111720000000  --42
	SET @ffp_Streptomicin = 1119610000000  --43
	SET @ffp_Sulfonamides = 1119970000000  --44
	SET @ffp_Tetracycline = 1126460000000  --45
	SET @ffp_Ticarcillin = 1126910000000  --46
	SET @ffp_Tobramycin = 1127110000000  --47
	SET @ffp_TrimethoprimSulfo = 1129160000000  --48
	SET @ffp_Vancomycin = 1130840000000

  SET @Ant_Resistance_ReferenceType = 19000069
  
SELECT 
  @strCulture = cont.strBarcode,
  @datDateTestConducted = bt.datValidatedDate,
  @strResearchConductedBy = ISNULL(pr.strFirstName + ' ', '') + 
                            ISNULL(pr.strSecondName + ' ', '') +
							ISNULL(pr.strFamilyName, ''),
  @idfObservation = o.idfObservation                          
from		tlbTesting t
inner join	fnReference(@LangID, 19000097) r_tt	-- Test Type
on			r_tt.idfsReference = t.idfsTestType
inner join	tlbContainer cont
on			cont.idfContainer = t.idfContainer
			and cont.intRowStatus = 0
inner join	tlbMaterial m
on			m.idfMaterial = cont.idfMaterial
			and m.intRowStatus = 0
inner join	tlbParty p
on			p.idfParty = m.idfParty
			and p.idfsPartyType = 10072006	-- Human
			and p.intRowStatus = 0
inner join	tlbHuman h
on			h.idfHuman = p.idfParty
inner join	tlbCase c
on			c.idfCase = p.idfCase
			and c.intRowStatus = 0
inner join	tlbHumanCase hc
on			hc.idfHumanCase = c.idfCase
inner join	(
	tlbBatchTest bt
	inner join	tstSite s
	on			s.idfOffice = bt.idfPerformedByOffice
				and s.idfsSite = dbo.fnSiteID()
				and s.intRowStatus = 0
	left join	(
		tlbEmployee e
		inner join	tlbPerson pr
		on			pr.idfPerson = e.idfEmployee
				)
	on			e.idfEmployee = bt.idfPerformedByPerson
				and e.intRowStatus = 0
			)
on			bt.idfBatchTest = t.idfBatchTest
			and bt.intRowStatus = 0
left join	tlbObservation o
on			o.idfObservation = t.idfObservation
			and o.intRowStatus = 0
left join	(
	tlbTesting t_dupl
	inner join	tlbContainer cont_dupl
	on			cont_dupl.idfContainer = t_dupl.idfContainer
				and cont_dupl.intRowStatus = 0
	inner join	tlbBatchTest bt_dupl
	on			bt_dupl.idfBatchTest = t_dupl.idfBatchTest
				and bt_dupl.intRowStatus = 0
			)
on			t_dupl.idfsTestType = t.idfsTestType
			and t_dupl.intRowStatus = 0
			and bt_dupl.idfPerformedByPerson = bt.idfPerformedByPerson
			and cont_dupl.idfMaterial = m.idfMaterial
			and cont_dupl.strBarcode = cont.strBarcode
			and	(	(bt_dupl.datValidatedDate is not null and bt.datValidatedDate is null)
					or	(bt_dupl.datValidatedDate is not null and bt.datValidatedDate is not null and bt_dupl.datValidatedDate > bt.datValidatedDate)
					or	(bt_dupl.datValidatedDate is null and bt.datValidatedDate is null and t_dupl.idfTesting > t.idfTesting)
				)
where	t.idfsTestType = 840960000000	--Antibiotic Resistance
		and t.intRowStatus = 0
		and t_dupl.idfTesting is null
		and cont.strBarcode = @SampleID
		and ((h.strLastName like @LastName + '%') OR IsNull(@LastName, N'') = N'')
		and ((h.strFirstName like @FirstName + '%') OR IsNull(@FirstName, N'') = N'')

SELECT 
	@strAmikacin = ref_Amikacin.[Name],
	@strAmpicillin = ref_Ampicillin.[Name],
	@strAmoxicillinClavAcid = ref_AmoxicillinClavAcid.[Name],
	@strAmoxicillin = ref_Amoxicillin.[Name],
	@strAztreonam = ref_Aztreonam.[Name],
	@strAzithromicin = ref_Azithromicin.[Name],
	@strCarbenicillin = ref_Carbenicillin.[Name],
	@strCefazolin = ref_Cefazolin.[Name],
	@strCefotaxime = ref_Cefotaxime.[Name],
	@strCeftazidime = ref_Ceftazidime.[Name],
	@strCefotaxine = ref_Cefotaxine.[Name],
	@strCefoperazone = ref_Cefoperazone.[Name],
	@strChoramphenicol = ref_Choramphenicol.[Name],
	@strCeftriaxone = ref_Ceftriaxone.[Name],
	@strCefepime = ref_Cefepime.[Name],
	@strCefoxitine = ref_Cefoxitine.[Name],
	@strCiprofloxacin = ref_Ciprofloxacin.[Name],
	@strColistineColomycin = ref_ColistineColomycin.[Name],
	@strCefuroxime = ref_Cefuroxime.[Name],
	@strCephalotin = ref_Cephalotin.[Name],
	@strClindamycin = ref_Clindamycin.[Name],
	@strDoxycycline = ref_Doxycycline.[Name],
	@strErythromycin = ref_Erythromycin.[Name],
	@strFosfumycin = ref_Fosfumycin.[Name],
	@strGentamicin = ref_Gentamicin.[Name],
	@strImipenem = ref_Imipenem.[Name],
	@strNorfloxacin = ref_Norfloxacin.[Name],
	@strNalidixicAcid = ref_NalidixicAcid.[Name],
	@strNitrofurantoin = ref_Nitrofurantoin.[Name],
	@strNetilmicin = ref_Netilmicin.[Name],
	@strOfloxacin = ref_Ofloxacin.[Name],
	@strOxacillin = ref_Oxacillin.[Name],
	@strPenicillin = ref_Penicillin.[Name],
	@strPiperacillin = ref_Piperacillin.[Name],
	@strRifampin = ref_Rifampin.[Name],
	@strStreptomicin = ref_Streptomicin.[Name],
	@strSulfonamides = ref_Sulfonamides.[Name],
	@strTetracycline = ref_Tetracycline.[Name],
	@strTicarcillin = ref_Ticarcillin.[Name],
	@strTobramycin = ref_Tobramycin.[Name],
	@strTrimethoprimSulfo = ref_TrimethoprimSulfo.[Name],
	@strVancomycin = ref_Vancomycin.[Name]

FROM tlbObservation o
    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Amikacin
        INNER JOIN ffParameter ffp_Amikacin
            ON ap_Amikacin.idfsParameter = ffp_Amikacin.idfsParameter AND
            ffp_Amikacin.idfsFormType = 10034018 AND
            ffp_Amikacin.idfsParameter = @ffp_Amikacin and
            ffp_Amikacin.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Amikacin
            ON cast(ap_Amikacin.varvalue as bigint) = ref_Amikacin.idfsReference
    )    
    ON o.idfObservation = ap_Amikacin.idfObservation AND
       ap_Amikacin.intRowStatus = 0 
       
    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Ampicillin
        INNER JOIN ffParameter ffp_Ampicillin
            ON ap_Ampicillin.idfsParameter = ffp_Ampicillin.idfsParameter AND
            ffp_Ampicillin.idfsFormType = 10034018 AND
            ffp_Ampicillin.idfsParameter = @ffp_Ampicillin and
            ffp_Ampicillin.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Ampicillin
            ON ap_Ampicillin.varvalue = ref_Ampicillin.idfsReference
    )    
    ON o.idfObservation = ap_Ampicillin.idfObservation AND
       ap_Ampicillin.intRowStatus = 0 
       
    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_AmoxicillinClavAcid
        INNER JOIN ffParameter ffp_AmoxicillinClavAcid
            ON ap_AmoxicillinClavAcid.idfsParameter = ffp_AmoxicillinClavAcid.idfsParameter AND
            ffp_AmoxicillinClavAcid.idfsFormType = 10034018 AND
            ffp_AmoxicillinClavAcid.idfsParameter = @ffp_AmoxicillinClavAcid and
            ffp_AmoxicillinClavAcid.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_AmoxicillinClavAcid
            ON ap_AmoxicillinClavAcid.varvalue = ref_AmoxicillinClavAcid.idfsReference
    )    
    ON o.idfObservation = ap_AmoxicillinClavAcid.idfObservation AND
       ap_AmoxicillinClavAcid.intRowStatus = 0 
       
    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Amoxicillin
        INNER JOIN ffParameter ffp_Amoxicillin
            ON ap_Amoxicillin.idfsParameter = ffp_Amoxicillin.idfsParameter AND
            ffp_Amoxicillin.idfsFormType = 10034018 AND
            ffp_Amoxicillin.idfsParameter = @ffp_Amoxicillin and
            ffp_Amoxicillin.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Amoxicillin
            ON ap_Amoxicillin.varvalue = ref_Amoxicillin.idfsReference
    )    
    ON o.idfObservation = ap_Amoxicillin.idfObservation AND
       ap_Amoxicillin.intRowStatus = 0 

    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Aztreonam
        INNER JOIN ffParameter ffp_Aztreonam
            ON ap_Aztreonam.idfsParameter = ffp_Aztreonam.idfsParameter AND
            ffp_Aztreonam.idfsFormType = 10034018 AND
            ffp_Aztreonam.idfsParameter = @ffp_Aztreonam and
            ffp_Aztreonam.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Aztreonam
            ON ap_Aztreonam.varvalue = ref_Aztreonam.idfsReference
    )    
    ON o.idfObservation = ap_Aztreonam.idfObservation AND
       ap_Aztreonam.intRowStatus = 0 
       
    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Azithromicin
        INNER JOIN ffParameter ffp_Azithromicin
            ON ap_Azithromicin.idfsParameter = ffp_Azithromicin.idfsParameter AND
            ffp_Azithromicin.idfsFormType = 10034018 AND
            ffp_Azithromicin.idfsParameter = @ffp_Azithromicin and
            ffp_Azithromicin.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Azithromicin
            ON ap_Azithromicin.varvalue = ref_Azithromicin.idfsReference
    )    
    ON o.idfObservation = ap_Azithromicin.idfObservation AND
       ap_Azithromicin.intRowStatus = 0 
       
    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Carbenicillin
        INNER JOIN ffParameter ffp_Carbenicillin
            ON ap_Carbenicillin.idfsParameter = ffp_Carbenicillin.idfsParameter AND
            ffp_Carbenicillin.idfsFormType = 10034018 AND
            ffp_Carbenicillin.idfsParameter = @ffp_Carbenicillin and
            ffp_Carbenicillin.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Carbenicillin
            ON ap_Carbenicillin.varvalue = ref_Carbenicillin.idfsReference
    )    
    ON o.idfObservation = ap_Carbenicillin.idfObservation AND
       ap_Carbenicillin.intRowStatus = 0 


    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Cefazolin
        INNER JOIN ffParameter ffp_Cefazolin
            ON ap_Cefazolin.idfsParameter = ffp_Cefazolin.idfsParameter AND
            ffp_Cefazolin.idfsFormType = 10034018 AND
            ffp_Cefazolin.idfsParameter = @ffp_Cefazolin and
            ffp_Cefazolin.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Cefazolin
            ON ap_Cefazolin.varvalue = ref_Cefazolin.idfsReference
    )    
    ON o.idfObservation = ap_Cefazolin.idfObservation AND
       ap_Cefazolin.intRowStatus = 0 

    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Cefotaxime
        INNER JOIN ffParameter ffp_Cefotaxime
            ON ap_Cefotaxime.idfsParameter = ffp_Cefotaxime.idfsParameter AND
            ffp_Cefotaxime.idfsFormType = 10034018 AND
            ffp_Cefotaxime.idfsParameter = @ffp_Cefotaxime and
            ffp_Cefotaxime.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Cefotaxime
            ON ap_Cefotaxime.varvalue = ref_Cefotaxime.idfsReference
    )    
    ON o.idfObservation = ap_Cefotaxime.idfObservation AND
       ap_Cefotaxime.intRowStatus = 0 

    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Ceftazidime
        INNER JOIN ffParameter ffp_Ceftazidime
            ON ap_Ceftazidime.idfsParameter = ffp_Ceftazidime.idfsParameter AND
            ffp_Ceftazidime.idfsFormType = 10034018 AND
            ffp_Ceftazidime.idfsParameter = @ffp_Ceftazidime and
            ffp_Ceftazidime.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Ceftazidime
            ON ap_Ceftazidime.varvalue = ref_Ceftazidime.idfsReference
    )    
    ON o.idfObservation = ap_Ceftazidime.idfObservation AND
       ap_Ceftazidime.intRowStatus = 0 
              
    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Cefotaxine
        INNER JOIN ffParameter ffp_Cefotaxine
            ON ap_Cefotaxine.idfsParameter = ffp_Cefotaxine.idfsParameter AND
            ffp_Cefotaxine.idfsFormType = 10034018 AND
            ffp_Cefotaxine.idfsParameter = @ffp_Cefotaxine and
            ffp_Cefotaxine.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Cefotaxine
            ON ap_Cefotaxine.varvalue = ref_Cefotaxine.idfsReference
    )    
    ON o.idfObservation = ap_Cefotaxine.idfObservation AND
       ap_Cefotaxine.intRowStatus = 0 

    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Cefoperazone
        INNER JOIN ffParameter ffp_Cefoperazone
            ON ap_Cefoperazone.idfsParameter = ffp_Cefoperazone.idfsParameter AND
            ffp_Cefoperazone.idfsFormType = 10034018 AND
            ffp_Cefoperazone.idfsParameter = @ffp_Cefoperazone and
            ffp_Cefoperazone.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Cefoperazone
            ON ap_Cefoperazone.varvalue = ref_Cefoperazone.idfsReference
    )    
    ON o.idfObservation = ap_Cefoperazone.idfObservation AND
       ap_Cefoperazone.intRowStatus = 0 


    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Choramphenicol
        INNER JOIN ffParameter ffp_Choramphenicol
            ON ap_Choramphenicol.idfsParameter = ffp_Choramphenicol.idfsParameter AND
            ffp_Choramphenicol.idfsFormType = 10034018 AND
            ffp_Choramphenicol.idfsParameter = @ffp_Choramphenicol and
            ffp_Choramphenicol.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Choramphenicol
            ON ap_Choramphenicol.varvalue = ref_Choramphenicol.idfsReference
    )    
    ON o.idfObservation = ap_Choramphenicol.idfObservation AND
       ap_Choramphenicol.intRowStatus = 0 


    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Ceftriaxone
        INNER JOIN ffParameter ffp_Ceftriaxone
            ON ap_Ceftriaxone.idfsParameter = ffp_Ceftriaxone.idfsParameter AND
            ffp_Ceftriaxone.idfsFormType = 10034018 AND
            ffp_Ceftriaxone.idfsParameter = @ffp_Ceftriaxone and
            ffp_Ceftriaxone.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Ceftriaxone
            ON ap_Ceftriaxone.varvalue = ref_Ceftriaxone.idfsReference
    )    
    ON o.idfObservation = ap_Ceftriaxone.idfObservation AND
       ap_Ceftriaxone.intRowStatus = 0 

    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Cefepime
        INNER JOIN ffParameter ffp_Cefepime
            ON ap_Cefepime.idfsParameter = ffp_Cefepime.idfsParameter AND
            ffp_Cefepime.idfsFormType = 10034018 AND
            ffp_Cefepime.idfsParameter = @ffp_Cefepime and
            ffp_Cefepime.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Cefepime
            ON ap_Cefepime.varvalue = ref_Cefepime.idfsReference
    )    
    ON o.idfObservation = ap_Cefepime.idfObservation AND
       ap_Cefepime.intRowStatus = 0 

    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Cefoxitine
        INNER JOIN ffParameter ffp_Cefoxitine
            ON ap_Cefoxitine.idfsParameter = ffp_Cefoxitine.idfsParameter AND
            ffp_Cefoxitine.idfsFormType = 10034018 AND
            ffp_Cefoxitine.idfsParameter = @ffp_Cefoxitine and
            ffp_Cefoxitine.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Cefoxitine
            ON ap_Cefoxitine.varvalue = ref_Cefoxitine.idfsReference
    )    
    ON o.idfObservation = ap_Cefoxitine.idfObservation AND
       ap_Cefoxitine.intRowStatus = 0 

    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Ciprofloxacin
        INNER JOIN ffParameter ffp_Ciprofloxacin
            ON ap_Ciprofloxacin.idfsParameter = ffp_Ciprofloxacin.idfsParameter AND
            ffp_Ciprofloxacin.idfsFormType = 10034018 AND
            ffp_Ciprofloxacin.idfsParameter = @ffp_Ciprofloxacin and
            ffp_Ciprofloxacin.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Ciprofloxacin
            ON ap_Ciprofloxacin.varvalue = ref_Ciprofloxacin.idfsReference
    )    
    ON o.idfObservation = ap_Ciprofloxacin.idfObservation AND
       ap_Ciprofloxacin.intRowStatus = 0 

    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_ColistineColomycin
        INNER JOIN ffParameter ffp_ColistineColomycin
            ON ap_ColistineColomycin.idfsParameter = ffp_ColistineColomycin.idfsParameter AND
            ffp_ColistineColomycin.idfsFormType = 10034018 AND
            ffp_ColistineColomycin.idfsParameter = @ffp_ColistineColomycin and
            ffp_ColistineColomycin.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_ColistineColomycin
            ON ap_ColistineColomycin.varvalue = ref_ColistineColomycin.idfsReference
    )    
    ON o.idfObservation = ap_ColistineColomycin.idfObservation AND
       ap_ColistineColomycin.intRowStatus = 0 

    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Cefuroxime
        INNER JOIN ffParameter ffp_Cefuroxime
            ON ap_Cefuroxime.idfsParameter = ffp_Cefuroxime.idfsParameter AND
            ffp_Cefuroxime.idfsFormType = 10034018 AND
            ffp_Cefuroxime.idfsParameter = @ffp_Cefuroxime and
            ffp_Cefuroxime.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Cefuroxime
            ON ap_Cefuroxime.varvalue = ref_Cefuroxime.idfsReference
    )    
    ON o.idfObservation = ap_Cefuroxime.idfObservation AND
       ap_Cefuroxime.intRowStatus = 0 

    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Cephalotin
        INNER JOIN ffParameter ffp_Cephalotin
            ON ap_Cephalotin.idfsParameter = ffp_Cephalotin.idfsParameter AND
            ffp_Cephalotin.idfsFormType = 10034018 AND
            ffp_Cephalotin.idfsParameter = @ffp_Cephalotin and
            ffp_Cephalotin.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Cephalotin
            ON ap_Cephalotin.varvalue = ref_Cephalotin.idfsReference
    )    
    ON o.idfObservation = ap_Cephalotin.idfObservation AND
       ap_Cephalotin.intRowStatus = 0 

    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Clindamycin
        INNER JOIN ffParameter ffp_Clindamycin
            ON ap_Clindamycin.idfsParameter = ffp_Clindamycin.idfsParameter AND
            ffp_Clindamycin.idfsFormType = 10034018 AND
            ffp_Clindamycin.idfsParameter = @ffp_Clindamycin and
            ffp_Clindamycin.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Clindamycin
            ON ap_Clindamycin.varvalue = ref_Clindamycin.idfsReference
    )    
    ON o.idfObservation = ap_Clindamycin.idfObservation AND
       ap_Clindamycin.intRowStatus = 0 


    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Doxycycline
        INNER JOIN ffParameter ffp_Doxycycline
            ON ap_Doxycycline.idfsParameter = ffp_Doxycycline.idfsParameter AND
            ffp_Doxycycline.idfsFormType = 10034018 AND
            ffp_Doxycycline.idfsParameter = @ffp_Doxycycline and
            ffp_Doxycycline.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Doxycycline
            ON ap_Doxycycline.varvalue = ref_Doxycycline.idfsReference
    )    
    ON o.idfObservation = ap_Doxycycline.idfObservation AND
       ap_Doxycycline.intRowStatus = 0 

    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Erythromycin
        INNER JOIN ffParameter ffp_Erythromycin
            ON ap_Erythromycin.idfsParameter = ffp_Erythromycin.idfsParameter AND
            ffp_Erythromycin.idfsFormType = 10034018 AND
            ffp_Erythromycin.idfsParameter = @ffp_Erythromycin and
            ffp_Erythromycin.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Erythromycin
            ON ap_Erythromycin.varvalue = ref_Erythromycin.idfsReference
    )    
    ON o.idfObservation = ap_Erythromycin.idfObservation AND
       ap_Erythromycin.intRowStatus = 0 

    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Fosfumycin
        INNER JOIN ffParameter ffp_Fosfumycin
            ON ap_Fosfumycin.idfsParameter = ffp_Fosfumycin.idfsParameter AND
            ffp_Fosfumycin.idfsFormType = 10034018 AND
            ffp_Fosfumycin.idfsParameter = @ffp_Fosfumycin and
            ffp_Fosfumycin.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Fosfumycin
            ON ap_Fosfumycin.varvalue = ref_Fosfumycin.idfsReference
    )    
    ON o.idfObservation = ap_Fosfumycin.idfObservation AND
       ap_Fosfumycin.intRowStatus = 0 

    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Gentamicin
        INNER JOIN ffParameter ffp_Gentamicin
            ON ap_Gentamicin.idfsParameter = ffp_Gentamicin.idfsParameter AND
            ffp_Gentamicin.idfsFormType = 10034018 AND
            ffp_Gentamicin.idfsParameter = @ffp_Gentamicin and
            ffp_Gentamicin.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Gentamicin
            ON ap_Gentamicin.varvalue = ref_Gentamicin.idfsReference
    )    
    ON o.idfObservation = ap_Gentamicin.idfObservation AND
       ap_Gentamicin.intRowStatus = 0 
       

    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Imipenem
        INNER JOIN ffParameter ffp_Imipenem
            ON ap_Imipenem.idfsParameter = ffp_Imipenem.idfsParameter AND
            ffp_Imipenem.idfsFormType = 10034018 AND
            ffp_Imipenem.idfsParameter = @ffp_Imipenem and
            ffp_Imipenem.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Imipenem
            ON ap_Imipenem.varvalue = ref_Imipenem.idfsReference
    )    
    ON o.idfObservation = ap_Imipenem.idfObservation AND
       ap_Imipenem.intRowStatus = 0 
       
    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Norfloxacin
        INNER JOIN ffParameter ffp_Norfloxacin
            ON ap_Norfloxacin.idfsParameter = ffp_Norfloxacin.idfsParameter AND
            ffp_Norfloxacin.idfsFormType = 10034018 AND
            ffp_Norfloxacin.idfsParameter = @ffp_Norfloxacin and
            ffp_Norfloxacin.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Norfloxacin
            ON ap_Norfloxacin.varvalue = ref_Norfloxacin.idfsReference
    )    
    ON o.idfObservation = ap_Norfloxacin.idfObservation AND
       ap_Norfloxacin.intRowStatus = 0 
       
    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_NalidixicAcid
        INNER JOIN ffParameter ffp_NalidixicAcid
            ON ap_NalidixicAcid.idfsParameter = ffp_NalidixicAcid.idfsParameter AND
            ffp_NalidixicAcid.idfsFormType = 10034018 AND
            ffp_NalidixicAcid.idfsParameter = @ffp_NalidixicAcid and
            ffp_NalidixicAcid.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_NalidixicAcid
            ON ap_NalidixicAcid.varvalue = ref_NalidixicAcid.idfsReference
    )    
    ON o.idfObservation = ap_NalidixicAcid.idfObservation AND
       ap_NalidixicAcid.intRowStatus = 0        
       
    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Nitrofurantoin
        INNER JOIN ffParameter ffp_Nitrofurantoin
            ON ap_Nitrofurantoin.idfsParameter = ffp_Nitrofurantoin.idfsParameter AND
            ffp_Nitrofurantoin.idfsFormType = 10034018 AND
            ffp_Nitrofurantoin.idfsParameter = @ffp_Nitrofurantoin and
            ffp_Nitrofurantoin.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Nitrofurantoin
            ON ap_Nitrofurantoin.varvalue = ref_Nitrofurantoin.idfsReference
    )    
    ON o.idfObservation = ap_Nitrofurantoin.idfObservation AND
       ap_Nitrofurantoin.intRowStatus = 0               

    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Netilmicin
        INNER JOIN ffParameter ffp_Netilmicin
            ON ap_Netilmicin.idfsParameter = ffp_Netilmicin.idfsParameter AND
            ffp_Netilmicin.idfsFormType = 10034018 AND
            ffp_Netilmicin.idfsParameter = @ffp_Netilmicin and
            ffp_Netilmicin.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Netilmicin
            ON ap_Netilmicin.varvalue = ref_Netilmicin.idfsReference
    )    
    ON o.idfObservation = ap_Netilmicin.idfObservation AND
       ap_Netilmicin.intRowStatus = 0               

    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Ofloxacin
        INNER JOIN ffParameter ffp_Ofloxacin
            ON ap_Ofloxacin.idfsParameter = ffp_Ofloxacin.idfsParameter AND
            ffp_Ofloxacin.idfsFormType = 10034018 AND
            ffp_Ofloxacin.idfsParameter = @ffp_Ofloxacin and
            ffp_Ofloxacin.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Ofloxacin
            ON ap_Ofloxacin.varvalue = ref_Ofloxacin.idfsReference
    )    
    ON o.idfObservation = ap_Ofloxacin.idfObservation AND
       ap_Ofloxacin.intRowStatus = 0          

    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Oxacillin
        INNER JOIN ffParameter ffp_Oxacillin
            ON ap_Oxacillin.idfsParameter = ffp_Oxacillin.idfsParameter AND
            ffp_Oxacillin.idfsFormType = 10034018 AND
            ffp_Oxacillin.idfsParameter = @ffp_Oxacillin and
            ffp_Oxacillin.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Oxacillin
            ON ap_Oxacillin.varvalue = ref_Oxacillin.idfsReference
    )    
    ON o.idfObservation = ap_Oxacillin.idfObservation AND
       ap_Oxacillin.intRowStatus = 0          

    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Penicillin
        INNER JOIN ffParameter ffp_Penicillin
            ON ap_Penicillin.idfsParameter = ffp_Penicillin.idfsParameter AND
            ffp_Penicillin.idfsFormType = 10034018 AND
            ffp_Penicillin.idfsParameter = @ffp_Penicillin and
            ffp_Penicillin.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Penicillin
            ON ap_Penicillin.varvalue = ref_Penicillin.idfsReference
    )    
    ON o.idfObservation = ap_Penicillin.idfObservation AND
       ap_Penicillin.intRowStatus = 0          

    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Piperacillin
        INNER JOIN ffParameter ffp_Piperacillin
            ON ap_Piperacillin.idfsParameter = ffp_Piperacillin.idfsParameter AND
            ffp_Piperacillin.idfsFormType = 10034018 AND
            ffp_Piperacillin.idfsParameter = @ffp_Piperacillin and
            ffp_Piperacillin.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Piperacillin
            ON ap_Piperacillin.varvalue = ref_Piperacillin.idfsReference
    )    
    ON o.idfObservation = ap_Piperacillin.idfObservation AND
       ap_Piperacillin.intRowStatus = 0          

    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Rifampin
        INNER JOIN ffParameter ffp_Rifampin
            ON ap_Rifampin.idfsParameter = ffp_Rifampin.idfsParameter AND
            ffp_Rifampin.idfsFormType = 10034018 AND
            ffp_Rifampin.idfsParameter = @ffp_Rifampin and
            ffp_Rifampin.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Rifampin
            ON ap_Rifampin.varvalue = ref_Rifampin.idfsReference
    )    
    ON o.idfObservation = ap_Rifampin.idfObservation AND
       ap_Rifampin.intRowStatus = 0          
              
    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Streptomicin 
        INNER JOIN ffParameter ffp_Streptomicin 
            ON ap_Streptomicin .idfsParameter = ffp_Streptomicin .idfsParameter AND
            ffp_Streptomicin .idfsFormType = 10034018 AND
            ffp_Streptomicin .idfsParameter = @ffp_Streptomicin  and
            ffp_Streptomicin .intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Streptomicin 
            ON ap_Streptomicin .varvalue = ref_Streptomicin .idfsReference
    )    
    ON o.idfObservation = ap_Streptomicin .idfObservation AND
       ap_Streptomicin .intRowStatus = 0                    
          
    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Sulfonamides
        INNER JOIN ffParameter ffp_Sulfonamides
            ON ap_Sulfonamides.idfsParameter = ffp_Sulfonamides.idfsParameter AND
            ffp_Sulfonamides.idfsFormType = 10034018 AND
            ffp_Sulfonamides.idfsParameter = @ffp_Sulfonamides and
            ffp_Sulfonamides.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Sulfonamides
            ON ap_Sulfonamides.varvalue = ref_Sulfonamides.idfsReference
    )    
    ON o.idfObservation = ap_Sulfonamides.idfObservation AND
       ap_Sulfonamides.intRowStatus = 0           
       
    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Tetracycline
        INNER JOIN ffParameter ffp_Tetracycline
            ON ap_Tetracycline.idfsParameter = ffp_Tetracycline.idfsParameter AND
            ffp_Tetracycline.idfsFormType = 10034018 AND
            ffp_Tetracycline.idfsParameter = @ffp_Tetracycline and
            ffp_Tetracycline.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Tetracycline
            ON ap_Tetracycline.varvalue = ref_Tetracycline.idfsReference
    )    
    ON o.idfObservation = ap_Tetracycline.idfObservation AND
       ap_Tetracycline.intRowStatus = 0           
              
    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Ticarcillin
        INNER JOIN ffParameter ffp_Ticarcillin
            ON ap_Ticarcillin.idfsParameter = ffp_Ticarcillin.idfsParameter AND
            ffp_Ticarcillin.idfsFormType = 10034018 AND
            ffp_Ticarcillin.idfsParameter = @ffp_Ticarcillin and
            ffp_Ticarcillin.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Ticarcillin
            ON ap_Ticarcillin.varvalue = ref_Ticarcillin.idfsReference
    )    
    ON o.idfObservation = ap_Ticarcillin.idfObservation AND
       ap_Ticarcillin.intRowStatus = 0                  
                 
    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Tobramycin
        INNER JOIN ffParameter ffp_Tobramycin
            ON ap_Tobramycin.idfsParameter = ffp_Tobramycin.idfsParameter AND
            ffp_Tobramycin.idfsFormType = 10034018 AND
            ffp_Tobramycin.idfsParameter = @ffp_Tobramycin and
            ffp_Tobramycin.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Tobramycin
            ON ap_Tobramycin.varvalue = ref_Tobramycin.idfsReference
    )    
    ON o.idfObservation = ap_Tobramycin.idfObservation AND
       ap_Tobramycin.intRowStatus = 0     
       
    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_TrimethoprimSulfo
        INNER JOIN ffParameter ffp_TrimethoprimSulfo
            ON ap_TrimethoprimSulfo.idfsParameter = ffp_TrimethoprimSulfo.idfsParameter AND
            ffp_TrimethoprimSulfo.idfsFormType = 10034018 AND
            ffp_TrimethoprimSulfo.idfsParameter = @ffp_TrimethoprimSulfo and
            ffp_TrimethoprimSulfo.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_TrimethoprimSulfo
            ON ap_TrimethoprimSulfo.varvalue = ref_TrimethoprimSulfo.idfsReference
    )    
    ON o.idfObservation = ap_TrimethoprimSulfo.idfObservation AND
       ap_TrimethoprimSulfo.intRowStatus = 0          
       
    LEFT OUTER JOIN
    (
     tlbActivityParameters ap_Vancomycin
        INNER JOIN ffParameter ffp_Vancomycin
            ON ap_Vancomycin.idfsParameter = ffp_Vancomycin.idfsParameter AND
            ffp_Vancomycin.idfsFormType = 10034018 AND
            ffp_Vancomycin.idfsParameter = @ffp_Vancomycin and
            ffp_Vancomycin.intRowStatus = 0
        INNER JOIN fnReference(@LangID, @Ant_Resistance_ReferenceType) ref_Vancomycin
            ON ap_Vancomycin.varvalue = ref_Vancomycin.idfsReference
    )    
    ON o.idfObservation = ap_Vancomycin.idfObservation AND
       ap_Vancomycin.intRowStatus = 0              
                        
        
WHERE o.idfObservation = @idfObservation






INSERT into @ReportTable
(	strCulture, --1
	datDateTestConducted,		--3
	strAmikacin, --8
	strAmpicillin, --9
	strAmoxicillinClavAcid, --10
	strAmoxicillin, --11
	strAztreonam, --12
	strAzithromicin, --13
	strCarbenicillin, --14
	strCefazolin, --15
	strCefotaxime, --16
	strCeftazidime, --17
	strCefotaxine, --18
	strCefoperazone, --19
	strChoramphenicol, --20
	strCeftriaxone, --21
	strCefepime, --22
	strCefoxitine, --23
	strCiprofloxacin, --24
	strColistineColomycin, --25
	strCefuroxime, --26
	strCephalotin, --27
	strClindamycin, --28
	strDoxycycline, --29
	strErythromycin, --30
	strFosfumycin, --31
	strGentamicin, --32
	strImipenem , --33
	strNorfloxacin, --34
	strNalidixicAcid, --35
	strNitrofurantoin, --36
	strNetilmicin, --37
	strOfloxacin , --38
	strOxacillin, --39
	strPenicillin , --40
	strPiperacillin , --41
	strRifampin , --42
	strStreptomicin, --43
	strSulfonamides , --44
	strTetracycline, --45
	strTicarcillin, --46
	strTobramycin, --47
	strTrimethoprimSulfo, --48
	strVancomycin, -- 49
	strResearchConductedBy
)
VALUES 
(
	@strCulture, --1
	@datDateTestConducted,		--3
	@strAmikacin, --8
	@strAmpicillin, --9
	@strAmoxicillinClavAcid, --10
	@strAmoxicillin, --11
	@strAztreonam, --12
	@strAzithromicin, --13
	@strCarbenicillin, --14
	@strCefazolin, --15
	@strCefotaxime, --16
	@strCeftazidime, --17
	@strCefotaxine, --18
	@strCefoperazone, --19
	@strChoramphenicol, --20
	@strCeftriaxone, --21
	@strCefepime, --22
	@strCefoxitine, --23
	@strCiprofloxacin, --24
	@strColistineColomycin, --25
	@strCefuroxime, --26
	@strCephalotin, --27
	@strClindamycin, --28
	@strDoxycycline, --29
	@strErythromycin, --30
	@strFosfumycin, --31
	@strGentamicin, --32
	@strImipenem, --33
	@strNorfloxacin, --34
	@strNalidixicAcid, --35
	@strNitrofurantoin, --36
	@strNetilmicin, --37
	@strOfloxacin, --38
	@strOxacillin, --39
	@strPenicillin, --40
	@strPiperacillin, --41
  @strRifampin, --42
	@strStreptomicin, --43
	@strSulfonamides, --44
	@strTetracycline, --45
	@strTicarcillin, --46
	@strTobramycin, --47
	@strTrimethoprimSulfo, --48
	@strVancomycin, -- 49
	@strResearchConductedBy --50
)



select * 
from @ReportTable

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
