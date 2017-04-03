 SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepJournal60B]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepJournal60B]


GO 
 
--##SUMMARY Select data for 60B Journal.
--##REMARKS Author: 
--##REMARKS Create date: 17.01.2011

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

exec spRepJournal60B 'ka', '2010-01-01', '2012-02-01', null

*/

CREATE  Procedure [dbo].[spRepJournal60B]
	(
		@LangID		as nvarchar(10), 
		@StartDate	as datetime,	 
		@FinishDate	as datetime,
		@Diagnosis	as bigint	=null		-- filter value ofa drop-down list of all diseases accounted in EIDSS as case-based diseases with HA code “Human” or ”Human, Livestock” or “Human, Avian” or “Human, Avian, Livestock” (non-mandatory field).
	)
AS	

-- Field description may be found here
-- "https://repos.btrp.net/BTRP/Project_Documents/08x-Implementation/Customizations/GG/Reports/Specification for report development - 60B Journal Human GG v1.0.doc"
-- by number marked red at screen form prototype 

declare	@ReportTable 	table
(	
	strName						nvarchar(2000), --2	
	strAge						nvarchar(2000), --3
	strGender					nvarchar(2000), --4
	strAddress					nvarchar(2000), --5
	strPlaceOfStudyWork			nvarchar(2000), --6
	datDiseaseOnsetDate			datetime, --7
	datDateOfFirstPresentation		datetime, --8
	strFacilityThatSentNotification NVARCHAR(2000), --9
	strProvisionalDiagnosis			nvarchar(2000), --10
	datDateProvisionalDiagnosis		datetime, --11
	datDateSpecificTreatment		datetime, --12
	datDateSpecimenTaken			nvarchar(max), --13
	strResultAndDate			nvarchar(max), --14
	strVaccinationStatus		nvarchar(2000), --15
	datDateCaseInvestigation	datetime, --16
	strFinalDS					nvarchar(2000), --17
	strFinalClassification		nvarchar(2000), --18
	datDateFinalDS				datetime, --19
	strOutcome					nvarchar(2000), --20
	strCaseStatus				nvarchar(2000), --24
	strComments					nvarchar(2000) --25
)	

declare	@OutbreakID	nvarchar(300)
select	@OutbreakID = IsNull(RTrim(r.[Name]) + N' ', N'')
from	fnReference(@LangID, 19000132) r	-- Additional report Text
where	r.strDefault = N'Outbreak ID'

declare	@CurrentResidence	nvarchar(300)
select	@CurrentResidence = IsNull(RTrim(r.[Name]) + N': ', N'')
from	fnReference(@LangID, 19000132) r	-- Additional report Text
where	r.strDefault = N'Current Residence'

declare	@PermanentResidence	nvarchar(300)
select	@PermanentResidence = IsNull(RTrim(r.[Name]) + N': ', N'')
from	fnReference(@LangID, 19000132) r	-- Additional report Text
where	r.strDefault = N'Permanent Residence'


INSERT INTO @ReportTable (
	strName,
	strAge,
	strGender,
	strAddress,
	strPlaceOfStudyWork,
	datDiseaseOnsetDate,
	datDateOfFirstPresentation,
	strFacilityThatSentNotification,
	strProvisionalDiagnosis,
	datDateProvisionalDiagnosis,
	datDateSpecificTreatment,
	datDateSpecimenTaken,
	strResultAndDate,
	strVaccinationStatus,
	datDateCaseInvestigation,
	strFinalDS,
	strFinalClassification,
	datDateFinalDS,
	strOutcome,
	strCaseStatus,
	strComments
) 
SELECT
  h.strLastName + ISNULL(N' ' + h.strFirstName, N'') + ISNULL(N' ' + h.strSecondName, N'') AS strName,
  CAST(hc.intPatientAge AS VARCHAR(10)) + N' (' + ref_AgeType.[Name] + N')' +
    CASE WHEN	(IsNull(hc.intPatientAge, 100) < 15 AND  IsNull(hc.idfsHumanAgeType, 10042003) = 10042003 /*years*/)
				or (IsNull(hc.idfsHumanAgeType, 10042003) <> 10042003 /*years*/)
         THEN IsNull(N', ' + CONVERT(varchar(10), h.datDateofBirth , 104), N'')
         ELSE N'' 
    END AS strAge,
  ref_hg.[Name] AS strGender,
  IsNull(@CurrentResidence, N'') + 
		dbo.fnCreateAddressString
				(	@LangID,
					gl_cr.Country,
					gl_cr.Region,
					gl_cr.Rayon,
					gl_cr.PostalCode,
					gl_cr.SettlementType,
					gl_cr.Settlement,
					gl_cr.Street,
					gl_cr.House,
					gl_cr.Building,
					gl_cr.Appartment,
					gl_cr.ResidentType
				) +
    CASE WHEN dbo.fnCreateAddressString
				(	@LangID,
					gl_cr.Country,
					gl_cr.Region,
					gl_cr.Rayon,
					gl_cr.PostalCode,
					gl_cr.SettlementType,
					gl_cr.Settlement,
					gl_cr.Street,
					gl_cr.House,
					gl_cr.Building,
					gl_cr.Appartment,
					gl_cr.ResidentType
				) <> 
			dbo.fnCreateAddressString
				(	@LangID,
					gl_r.Country,
					gl_r.Region,
					gl_r.Rayon,
					gl_r.PostalCode,
					gl_r.SettlementType,
					gl_r.Settlement,
					gl_r.Street,
					gl_r.House,
					gl_r.Building,
					gl_r.Appartment,
					gl_r.ResidentType
				)
				and IsNull(gl_r.Region, N'') <> N''
         THEN '; ' +  IsNull(@PermanentResidence, N'') + 
				dbo.fnCreateAddressString
						(	@LangID,
							gl_r.Country,
							gl_r.Region,
							gl_r.Rayon,
							gl_r.PostalCode,
							gl_r.SettlementType,
							gl_r.Settlement,
							gl_r.Street,
							gl_r.House,
							gl_r.Building,
							gl_r.Appartment,
							gl_r.ResidentType
						)
		ELSE N''
    END AS strAddress,
  IsNull(h.strEmployerName + '; ', N'') + 
    CASE WHEN IsNull(gl_em.Region, N'') <> N''
         THEN 		IsNull(dbo.fnCreateAddressString
					(	@LangID,
						gl_em.Country,
						gl_em.Region,
						gl_em.Rayon,
						gl_em.PostalCode,
						gl_em.SettlementType,
						gl_em.Settlement,
						gl_em.Street,
						gl_em.House,
						gl_em.Building,
						gl_em.Appartment,
						gl_em.ResidentType
					), '')
		ELSE N''
	END AS   strPlaceOfStudyWork,
  hc.datOnSetDate AS datDiseaseOnsetDate,
  hc.datFirstSoughtCareDate AS datDateOfFirstPresentation,
  hc.strSentByLastName + ISNULL(' ' + hc.strSentByFirstName, '') + ISNULL(' ' + hc.strSentByPatronymicName,'')+ ISNULL(', ' + CONVERT(varchar(10),hc.datNotificationDate, 104),'') AS strFacilityThatSentNotification,
  ref_diag.[Name] AS strProvisionalDiagnosis,
  hc.datTentativeDiagnosisDate AS datDateProvisionalDiagnosis,
  CASE WHEN hc.idfsYNAntimicrobialTherapy = 10100001 THEN
        (SELECT TOP 1 a.datFirstAdministeredDate 
          FROM tlbAntimicrobialTherapy a
          WHERE a.idfHumanCase = ct.idfCase 
				and a.intRowStatus = 0
          ORDER BY 1 ASC)
     ELSE NULL END AS datDateSpecificTreatment,
	CAST((SELECT 	
  	          ref_st_collected.[Name] +
  	          ISNULL(', ' + CONVERT(VARCHAR, m_collected.datFieldCollectionDate, 103), '') + '; '
			FROM tlbMaterial m_collected
			inner join	fnReference(@LangID, 19000087 /*rftSpecimenType*/) ref_st_collected
  						ON ref_st_collected.idfsReference = m_collected.idfsSpecimenType
			WHERE m_collected.idfParty = h.idfHuman
					and m_collected.intRowStatus = 0
			order by	m_collected.datFieldCollectionDate 	                
  	        for xml path('')		
    ) AS NVARCHAR(MAX))  AS datDateSpecimenTaken,
	CAST((SELECT 	
  	          ref_st.[Name] +
  	          ISNULL(', ' + ref_tt.[Name], '') +
  	          ISNULL(', ' + ref_tr.[Name], '') +
  	          ISNULL(', ' + CONVERT(VARCHAR, b.datValidatedDate, 103), '') + '; '
  	        FROM	(
				tlbTesting t
  	            INNER JOIN fnReference(@LangID, 19000097 /*rftTestType*/)  AS ref_tt
  	            ON ref_tt.idfsReference = t.idfsTestType
					)
			inner join	tlbContainer cn
			on			cn.idfContainer = t.idfContainer
						and cn.intRowStatus = 0
			inner join	(
				tlbMaterial m
  	                INNER JOIN fnReference(@LangID, 19000087 /*rftSpecimenType*/) ref_st
  	                ON ref_st.idfsReference = m.idfsSpecimenType
						)
  	            ON m.idfMaterial = cn.idfMaterial AND
  	               m.intRowStatus = 0
  	            LEFT OUTER JOIN tlbBatchTest b
  	            ON t.idfBatchTest = b.idfBatchTest
					and b.intRowStatus = 0
  	            
  	            LEFT JOIN fnReference(@LangID, 19000096 /*rftTestResult*/)  AS ref_tr
  	            ON ref_tr.idfsReference = t.idfsTestResult
  	         WHERE t.introwStatus = 0 AND
  	                m.idfParty = h.idfHuman
  	        order by	b.datValidatedDate
  	        for xml path('')		
    ) AS NVARCHAR(MAX))  AS strResultAndDate,
  --------------------------------------------------------------------------------------------------------------------
  CASE 
--------------------
    /*Number of immunizations received + Date of last vaccination*/ --1077370000000
    WHEN ct.idfsShowDiagnosis IN
        (   784090000000/*Acute viral hepatitis B*/ ) 
        THEN ISNULL(ref_ap1.NAME + ', ','') + CONVERT(VARCHAR(10), CAST(ap18.varValue AS DATETIME), 103) 
--------------------    
    /*Are patient’s immunization records available*/    
    WHEN ct.idfsShowDiagnosis IN
        (   784130000000 /*AFP/Acute poliomyelitis*/) 
        /*Show combination of following: 
        1) "Are patient's immunization records available"; 
        2) if value in 1 is not blank then "-" otherwise nothing; 
        3) If "Are patient's immunization records available" = "Yes" use following algorithm: 
               show "OPV-5" field name + "-" + "OPV-5" value -> 
               if missing or "Unknown" show "OPV-4" field name + "-" + "OPV-4" value -> 
               if missing or "Unknown" show "OPV-3" field name + "-" + "OPV-3" value -> 
               if missing or "Unknown" show "OPV-2" field name + "-" + "OPV-2" value -> 
               if missing or "Unknown" show "OPV-1" field name + "-" + "OPV-1" value; 
        4) if value in 6) is not blank then show name of section "Additional OPV doses received during mass campaigns"; 
        5) if value in 6) is not blank then ":" otherwise nothing; 
        6) value in "Third" field name + "-" + "Third" value -> 
           if missing or "Unknown" show "Second" field name + "-" + "Second" value -> 
           if missing or "Unknown" show "First" field name + "-" + "First" value; 
        7) if value in 6) i not blank then ";" otherwise nothing; 
        8) value in "Date of last OPV dose received".*/
        THEN 
            /*1), 2)*/
             ISNULL(ref_ap2.NAME + '- ', '')
            /*3)*/  
             +
             CASE WHEN ref_ap2.idfsReference = 10100001 /*yes*/
                  THEN 
                    CASE WHEN ref_ap26.NAME IS NOT NULL AND ref_ap26.idfsReference <> 995360000000 /*Unknown*/ 
                         THEN (SELECT [NAME] 
                                FROM fnReference(@langID, 19000066/*rftParameter*/) 
                                WHERE idfsReference = 1095630000000 /*"OPV-5" field*/
                               ) + '-' + ref_ap26.NAME
                         ELSE
                         CASE WHEN ref_ap25.NAME IS NOT NULL AND ref_ap25.idfsReference <> 995360000000 /*Unknown*/ 
                             THEN (SELECT [NAME] 
                                    FROM fnReference(@langID, 19000066/*rftParameter*/) 
                                    WHERE idfsReference = 989090000000 /*"OPV-4" field*/
                                   ) + '-' + ref_ap25.NAME
                             ELSE
                             CASE WHEN ref_ap24.NAME IS NOT NULL AND ref_ap24.idfsReference <> 995360000000 /*Unknown*/ 
                                 THEN (SELECT [NAME] 
                                        FROM fnReference(@langID, 19000066/*rftParameter*/) 
                                        WHERE idfsReference = 1095550000000 /*"OPV-3" field*/
                                       ) + '-' + ref_ap24.NAME
                                 ELSE
                                 CASE WHEN ref_ap23.NAME IS NOT NULL AND ref_ap23.idfsReference <> 995360000000 /*Unknown*/ 
                                     THEN (SELECT [NAME] 
                                            FROM fnReference(@langID, 19000066/*rftParameter*/) 
                                            WHERE idfsReference = 1095510000000 /*"OPV-2" field*/
                                           ) + '-' + ref_ap23.NAME
                                     ELSE
                                     CASE WHEN ref_ap22.NAME IS NOT NULL AND ref_ap22.idfsReference <> 995360000000 /*Unknown*/ 
                                         THEN (SELECT [NAME] 
                                                FROM fnReference(@langID, 19000066/*rftParameter*/) 
                                                WHERE idfsReference = 1095470000000 /*"OPV-1" field*/
                                               ) + '-' + ref_ap22.NAME
                                         ELSE ''
                                     END /*OPV-1*/                                      
                                 END /*OPV-2*/                              
                             END /*OPV-3*/                              
                         END /*OPV-4*/   
                     END /*OPV-5*/          
                  ELSE ''
             END --CASE WHEN ref_ap2.idfsReference = 10100001 /*yes*/    
            /*4),5)*/  
             +
             CASE WHEN ref_ap29.NAME /*"Third" field*/ IS NOT NULL OR 
                       ref_ap28.NAME /*"Second" field*/ IS NOT NULL OR
                       ref_ap27.NAME /*"First" field*/ IS NOT NULL
                  THEN (SELECT snt.strTextString FROM trtStringNameTranslation snt
                           WHERE snt.idfsBaseReference = 1013460000000 /*section name - Additional OPV doses received during mass campaigns*/
                                  AND snt.idfsLanguage = dbo.fnGetLanguageCode(@LangID) 
                                  AND snt.intRowStatus = 0                
                        ) + ':' +
                            /*6)*/  
                            CASE WHEN ref_ap29.NAME IS NOT NULL AND ref_ap29.idfsReference <> 995360000000 /*Unknown*/ 
                                 THEN (SELECT [NAME] 
                                        FROM fnReference(@langID, 19000066/*rftParameter*/) 
                                        WHERE idfsReference = 1126700000000 /*"Third" field*/
                                       ) + '-' + ref_ap29.NAME
                                 ELSE
                                 CASE WHEN ref_ap28.NAME IS NOT NULL AND ref_ap28.idfsReference <> 995360000000 /*Unknown*/ 
                                     THEN (SELECT [NAME] 
                                            FROM fnReference(@langID, 19000066/*rftParameter*/) 
                                            WHERE idfsReference = 1114560000000 /*"Second" field*/
                                           ) + '-' + ref_ap28.NAME
                                     ELSE
                                     CASE WHEN ref_ap27.NAME IS NOT NULL AND ref_ap27.idfsReference <> 995360000000 /*Unknown*/ 
                                         THEN (SELECT [NAME] 
                                                FROM fnReference(@langID, 19000066/*rftParameter*/) 
                                                WHERE idfsReference = 1068560000000 /*"First" field*/
                                               ) + '-' + ref_ap27.NAME
                                         ELSE ''
                                     END /*First*/               
                                 END /*Second*/
                             END /*Third*/  
                             /*7)*/
                             + ';'                       
                  ELSE ''
             END  
            /*8)*/  
             +    
            CONVERT(VARCHAR(10), CAST(ap30.varValue AS DATETIME), 103) 

--------------------    
    /*Was specific vaccination administered? + Date of last vaccination*/
    WHEN ct.idfsShowDiagnosis IN
        (
            784220000000, /*Anthrax*/
            784230000000, /*Anthrax - Cutaneous*/
            784240000000, /*Anthrax - Gastrointestinal*/
            784250000000, /*Anthrax - Oropharyngeal*/
            784260000000, /*Anthrax - Pulmonary*/
            784440000000, /*Botulism*/
            784560000000, /*Brucellosis*/
            784570000000, /*Brucellosis - Abortus*/
            784580000000, /*Brucellosis - Canis*/
            784590000000, /*Brucellosis - Melitensis*/
            784600000000, /*Brucellosis - Other*/
            784620000000, /*Brucellosis - Suis*/
            784630000000, /*Brucellosis - Unspecified*/
            784790000000, /*Crimean-Congo Hemorrhagic Fever (CCHF)*/
            785230000000, /*Hemorrhagic Fever with Renal Syndrome*/
            785320000000, /*Infant Botulism*/
            785420000000, /*Influenza due to a new subtype of Influenza virus*/
            785840000000, /*Plague*/
            785850000000, /*Plague - Bubonic*/
            785860000000, /*Plague - Pneumonic*/
            785870000000, /*Plague - Septicemic*/
            786140000000, /*Smallpox*/
            786270000000, /*Tick-borne viral encephalitis*/
            786370000000, /*Tularemia*/
            786380000000, /*Tularemia - Gastrointestinal*/
            786400000000, /*Tularemia - General*/
            786410000000, /*Tularemia - Oculo-bubonic*/
            786420000000, /*Tularemia - Oropharyngeal*/
            786430000000, /*Tularemia - Pulmonary*/
            786440000000 /*Tularemia - Ulcero-bubonic*/
        ) 
        THEN ISNULL(ref_ap3.NAME + ', ','') + CONVERT(VARCHAR(10), CAST(ap18_2.varValue AS DATETIME), 103) 
--------------------    
    /*Vaccinated against rubella*/    
    WHEN ct.idfsShowDiagnosis IN
        (   784760000000 /*Congenital rubella syndrome*/) 
        THEN (SELECT snt.strTextString FROM trtStringNameTranslation snt
                WHERE snt.idfsBaseReference = 0 /*name of section "Maternal history"*/
                      AND snt.idfsLanguage = dbo.fnGetLanguageCode(@LangID) 
                      AND snt.intRowStatus = 0                
              ) + ':' + ref_ap4.NAME
--------------------    
    /*Number of received doses (any vaccine with diphtheria component) + Date of last vaccination */    
    WHEN ct.idfsShowDiagnosis IN
        (   784820000000 /*Diphtheria*/) 
        THEN ISNULL(ref_ap5.NAME + ', ','') + CONVERT(VARCHAR(10), CAST(ap18.varValue AS DATETIME), 103) --1077370000000
--------------------    
    /*Rabies vaccine given? + If "Yes", indicate dates of doses*/    
    WHEN ct.idfsShowDiagnosis IN
        (   785290000000 /*Hydrophobia*/) 
        THEN ISNULL(ref_ap6.NAME+ '; ','') + CAST(ap19.varValue AS NVARCHAR(300))
        
--------------------    
    /*Number of received doses (any vaccine with measles component) + Date of last vaccination*/    
    WHEN ct.idfsShowDiagnosis IN
        (   785550000000 /*Measles*/) 
        THEN ISNULL(ref_ap7.NAME + ', ','') + CONVERT(VARCHAR(10), CAST(ap18.varValue AS DATETIME), 103) 
    
--------------------    
    /*Hib vaccination status + If "Yes", number of vaccines received + Date of last vaccination*/    
    WHEN ct.idfsShowDiagnosis IN
        (   785560000000, /*Meningitis due to Haemophilus Influenza B*/
            785570000000, /*Meningitis due to M. tuberculosis*/
            785580000000, /*Meningitis due to N. meningitids*/
            785590000000, /*Meningitis due to S. pneumoniae*/
            785730000000  /*Other Bacterial Meningitis*/) 
        THEN ISNULL(ref_ap8.NAME + ', ','') + 
             ISNULL(ref_ap20.NAME + ', ','') + 
             CONVERT(VARCHAR(10), CAST(ap18.varValue AS DATETIME), 103) 
        
--------------------    
    /*Number of received doses (any vaccine with mumps component) + Date of last vaccination*/    
    WHEN ct.idfsShowDiagnosis IN
        (   785640000000 /*Mumps*/) 
        THEN ISNULL(ref_ap9.NAME+ ', ','') + CONVERT(VARCHAR(10), CAST(ap18.varValue AS DATETIME), 103) 
        
--------------------    
    /*Mother’s tetanus toxoid history prior to child’s disease (known doses only) + Interval since last tetanus toxoid dose (years)*/    
    WHEN ct.idfsShowDiagnosis IN
        (   785670000000 /*Neonatal Tetanus*/) 
        THEN ISNULL(ref_ap10.NAME + '; ', '') + CAST(ap21.varValue AS NVARCHAR(300))
        
--------------------    
    /*Number of received doses (any vaccine with pertussis component) + Date of last vaccination*/    
    WHEN ct.idfsShowDiagnosis IN
        (   785820000000 /*Pertussis*/) 
        THEN ISNULL(ref_ap11.NAME+ ', ','') + CONVERT(VARCHAR(10), CAST(ap18.varValue AS DATETIME), 103)
        
--------------------    
    /*Number of received doses (any vaccine with rubella component) + Date of last vaccination*/    
    WHEN ct.idfsShowDiagnosis IN
        (   786070000000 /*Rubella*/) 
        THEN ISNULL(ref_ap12.NAME+ ', ','')  + CONVERT(VARCHAR(10), CAST(ap18.varValue AS DATETIME), 103)       
        
--------------------    
    /*Include doses of ALL tetanus-containing toxoids. Exclude doses received after this particular injury + 
     Interval since last tetanus toxoid dose (years)*/    
    WHEN ct.idfsShowDiagnosis IN
        (   786250000000 /*Tetanus*/) 
        THEN ISNULL(ref_ap13.NAME  + '; ','') + CAST(ap21_2.varValue AS NVARCHAR(300))
        
--------------------    
    /*Revaccination + Date of revaccination*/    
    WHEN ct.idfsShowDiagnosis IN
        (   784080000000, /*Acute viral hepatitis A*/
            784100000000, /*Acute viral hepatitis C*/
            784110000000, /*Acute viral hepatitis E*/
            784280000000, /*Arthropods transmitted viral fevers and viral hemorrhagic fevers*/
            784700000000, /*Cholera*/
            785000000000, /*Esherichiosis*/
            785030000000, /*Fever of unknown etiology*/
            785040000000, /*Flea-borne typhus*/
            785280000000, /*Hospitalized cases of Influenza-like illness*/
            785470000000, /*Leptospirosis*/
            785490000000, /*Listeriosis*/
            785500000000, /*Lyme Disease*/
            785520000000, /*Malaria*/
            785610000000, /*Meningococcaemia*/
            785750000000, /*Other Salmonella infections*/
            785790000000, /*Paratyphoid fevers A, B, C*/
            785930000000, /*Post vaccination unusual reactions and complications*/
            785960000000, /*Q fever*/
            785980000000, /*Radiological lesions*/
            785990000000, /*Relapsing fever*/
            786120000000, /*Severe Acute Respiratory Syndrome*/
            786130000000, /*Shigellosis*/
            786300000000, /*Trichinosis*/
            786460000000, /*Typhoid fever*/
            786470000000, /*Unconfirmed Viral infections of CNS*/
            786480000000, /*Unspecified infectious diarrheal diseases*/
            786560000000, /*Yellow fever*/
            786570000000  /*Yersiniosis*/) 
            AND ref_ap15.idfsReference = 10100001
        THEN ISNULL(ref_ap15.NAME + ', ','') + CONVERT(VARCHAR(10), CAST(ap17.varValue AS DATETIME), 103)

--------------------    
    /*Was vaccination administered? + Date of vaccination*/    
    WHEN ct.idfsShowDiagnosis IN
        (   784080000000, /*Acute viral hepatitis A*/
            784100000000, /*Acute viral hepatitis C*/
            784110000000, /*Acute viral hepatitis E*/
            784280000000, /*Arthropods transmitted viral fevers and viral hemorrhagic fevers*/
            784700000000, /*Cholera*/
            785000000000, /*Esherichiosis*/
            785030000000, /*Fever of unknown etiology*/
            785040000000, /*Flea-borne typhus*/
            785280000000, /*Hospitalized cases of Influenza-like illness*/
            785470000000, /*Leptospirosis*/
            785490000000, /*Listeriosis*/
            785500000000, /*Lyme Disease*/
            785520000000, /*Malaria*/
            785610000000, /*Meningococcaemia*/
            785750000000, /*Other Salmonella infections*/
            785790000000, /*Paratyphoid fevers A, B, C*/
            785930000000, /*Post vaccination unusual reactions and complications*/
            785960000000, /*Q fever*/
            785980000000, /*Radiological lesions*/
            785990000000, /*Relapsing fever*/
            786120000000, /*Severe Acute Respiratory Syndrome*/
            786130000000, /*Shigellosis*/
            786300000000, /*Trichinosis*/
            786460000000, /*Typhoid fever*/
            786470000000, /*Unconfirmed Viral infections of CNS*/
            786480000000, /*Unspecified infectious diarrheal diseases*/
            786560000000, /*Yellow fever*/
            786570000000  /*Yersiniosis*/) 
            AND ref_ap15.idfsReference <> 10100001
        THEN ISNULL(ref_ap14.NAME + ', ','') + CONVERT(VARCHAR(10), CAST(ap16.varValue AS DATETIME), 103)        
        
        
    ELSE NULL
  END AS strVaccinationStatus,
----------------------------------------------------------------------------------------------
  hc.datInvestigationStartDate AS datDateCaseInvestigation,
  ISNULL(ref_diag_f.[Name], ref_diag.[Name]) AS strFinalDS,
  ref_cs.[Name] AS strFinalClassification,
  CASE WHEN hc.datFinalDiagnosisDate IS NULL AND ref_diag_f.idfsReference IS NULL 
        THEN hc.datTentativeDiagnosisDate
        ELSE hc.datFinalDiagnosisDate 
       END AS datDateFinalDS,
  ref_outcome.[Name] +  CASE WHEN hc.idfsOutcome = 10760000000 /*outRecovered*/ 
                                THEN ISNULL(', ' + CONVERT(VARCHAR(10),hc.datDischargeDate, 104), '')
                             WHEN hc.idfsOutcome = 10770000000 /*outDied*/ 
                                THEN ISNULL(', ' + CONVERT(VARCHAR(10),h.datDateOfDeath, 104), '')
                             ELSE ''
                         END AS strOutcome      ,
  IsNull(@OutbreakID, N'') + o.strOutbreakID  AS  strCaseStatus,
	IsNull(hc.strNote + N'; ', N'') + ISNULL(hc.strClinicalNotes + N'; ', N'') + ISNULL(hc.strSummaryNotes + N';', N'') as strComments	                      
         
  
  
FROM tlbCase ct
    INNER JOIN 
    (tlbHumanCase hc
        INNER JOIN 
        (tlbParty pp
              INNER JOIN 
              (tlbHuman h
                  LEFT OUTER JOIN fnReference(@LangID, 19000043/*rftHumanGender*/) ref_hg
                  ON ref_hg.idfsReference = h.idfsHumanGender
                   
                  left join		fnAddressAsRow(@LangID) gl_cr
					on			gl_cr.idfGeoLocation = h.idfCurrentResidenceAddress
                   
                  left join		fnAddressAsRow(@LangID) gl_r
					on			gl_r.idfGeoLocation = h.idfRegistrationAddress
                   
                  left join		fnAddressAsRow(@LangID) gl_em
					on			gl_em.idfGeoLocation = h.idfEmployerAddress
              )
              ON pp.idfParty = h.idfHuman
        )  
        ON  pp.idfCase = hc.idfHumanCase AND
            pp.intRowStatus = 0
        LEFT OUTER JOIN fnReference(@LangID, 19000042/*rftHumanAgeType*/) ref_AgeType
        ON ref_AgeType.idfsReference = hc.idfsHumanAgeType
        
        INNER JOIN fnReference(@LangID, 19000019/*rftDiagnosis*/) ref_diag
        ON ref_diag.idfsReference = hc.idfsTentativeDiagnosis
        
        LEFT OUTER JOIN fnReference(@LangID, 19000019/*rftDiagnosis*/) ref_diag_f
        ON ref_diag_f.idfsReference = hc.idfsfinalDiagnosis
        
        LEFT OUTER JOIN fnReference(@LangID, 19000011/*rftCaseStatus*/) ref_cs
        ON ref_cs.idfsReference = hc.idfsFinalCaseStatus

        LEFT OUTER JOIN fnReference(@langID, 19000064 /*rftOutcome*/) ref_outcome
        ON ref_outcome.idfsReference = hc.idfsOutcome
        
        LEFT OUTER JOIN 
        (tlbObservation obs1
            INNER JOIN tlbActivityParameters ap1
            ON ap1.idfObservation = obs1.idfObservation AND
               ap1.idfsParameter = 1093560000000  /*Number of immunizations received*/ AND 
               ap1.intRowStatus = 0
            LEFT JOIN fnReference(@langID, 988850000000 /*Immunization 5+*/)  ref_ap1
            ON ref_ap1.idfsReference = ap1.varValue 
        )
        ON obs1.idfObservation = hc.idfEPIObservation AND
           obs1.intRowStatus = 0
           
        LEFT OUTER JOIN 
        (tlbObservation obs2
            INNER JOIN tlbActivityParameters ap2
            ON ap2.idfObservation = obs2.idfObservation AND
               ap2.idfsParameter = 1030120000000  /*Are patient’s immunization records available*/ AND 
               ap2.intRowStatus = 0
            LEFT JOIN fnReference(@langID, 217140000000 /*Y_N_Unk*/)  ref_ap2
            ON ref_ap2.idfsReference = ap2.varValue 
        )
        ON obs2.idfObservation = hc.idfEPIObservation AND
           obs2.intRowStatus = 0
     
        LEFT OUTER JOIN 
        (tlbObservation obs3
            INNER JOIN tlbActivityParameters ap3
            ON ap3.idfObservation = obs3.idfObservation AND
               ap3.idfsParameter = 1132920000000  /*Was specific vaccination administered?*/ AND 
               ap3.intRowStatus = 0
            LEFT JOIN fnReference(@langID, 217140000000 /*Y_N_Unk*/)  ref_ap3
            ON ref_ap3.idfsReference = ap3.varValue 
        )
        ON obs3.idfObservation = hc.idfEPIObservation AND
           obs3.intRowStatus = 0  
              
        LEFT OUTER JOIN 
        (tlbObservation obs4
            INNER JOIN tlbActivityParameters ap4
            ON ap4.idfObservation = obs4.idfObservation AND
               ap4.idfsParameter = 1130400000000  /*Vaccinated against rubella*/ AND 
               ap4.intRowStatus = 0
            LEFT JOIN fnReference(@langID, 0217140000000 /*Y_N_Unk*/)  ref_ap4
            ON ref_ap4.idfsReference = ap4.varValue 
        )
        ON obs4.idfObservation = hc.idfEPIObservation AND
           obs4.intRowStatus = 0     
           
        LEFT OUTER JOIN 
        (tlbObservation obs5
            INNER JOIN tlbActivityParameters ap5
            ON ap5.idfObservation = obs5.idfObservation AND
               ap5.idfsParameter = 1092960000000  /*Number of received doses (any vaccine with diphtheria component)*/ AND 
               ap5.intRowStatus = 0
            LEFT JOIN fnReference(@langID, 988850000000 /*Immunization 5+*/)  ref_ap5
            ON ref_ap5.idfsReference = ap5.varValue 
        )
        ON obs5.idfObservation = hc.idfEPIObservation AND
           obs5.intRowStatus = 0             
           
        LEFT OUTER JOIN 
        (tlbObservation obs6
            INNER JOIN tlbActivityParameters ap6
            ON ap6.idfObservation = obs6.idfObservation AND
               ap6.idfsParameter = 1108340000000  /*Rabies vaccine given?*/ AND 
               ap6.intRowStatus = 0
            LEFT JOIN fnReference(@langID, 217140000000 /*Y_N_Unk*/)  ref_ap6
            ON ref_ap6.idfsReference = ap6.varValue 
        )
        ON obs6.idfObservation = hc.idfEPIObservation AND
           obs6.intRowStatus = 0             
           
           
        LEFT OUTER JOIN 
        (tlbObservation obs7
            INNER JOIN tlbActivityParameters ap7
            ON ap7.idfObservation = obs7.idfObservation AND
               ap7.idfsParameter = 1093000000000  /*Number of received doses (any vaccine with measles component)*/ AND 
               ap7.intRowStatus = 0
            LEFT JOIN fnReference(@langID, 988820000000 /*Immunization 3+*/)  ref_ap7
            ON ref_ap7.idfsReference = ap7.varValue 
        )
        ON obs7.idfObservation = hc.idfEPIObservation AND
           obs7.intRowStatus = 0             
           
           
        LEFT OUTER JOIN 
        (tlbObservation obs8
            INNER JOIN tlbActivityParameters ap8
            ON ap8.idfObservation = obs8.idfObservation AND
               ap8.idfsParameter = 1072490000000  /*Hib vaccination status*/ AND 
               ap8.intRowStatus = 0
            LEFT JOIN fnReference(@langID, 217140000000 /*Y_N_Unk*/)  ref_ap8
            ON ref_ap8.idfsReference = ap8.varValue 
        )
        ON obs8.idfObservation = hc.idfEPIObservation AND
           obs8.intRowStatus = 0                 
           
        LEFT OUTER JOIN 
        (tlbObservation obs9
            INNER JOIN tlbActivityParameters ap9
            ON ap9.idfObservation = obs9.idfObservation AND
               ap9.idfsParameter = 1093040000000  /*Number of received doses (any vaccine with mumps component)*/ AND 
               ap9.intRowStatus = 0
            LEFT JOIN fnReference(@langID, 988820000000 /*Immunization 3+*/)  ref_ap9
            ON ref_ap9.idfsReference = ap9.varValue 
        )
        ON obs9.idfObservation = hc.idfEPIObservation AND
           obs9.intRowStatus = 0      
                   
        LEFT OUTER JOIN 
        (tlbObservation obs10
            INNER JOIN tlbActivityParameters ap10
            ON ap10.idfObservation = obs10.idfObservation AND
               ap10.idfsParameter = 1087740000000  /*Mother’s tetanus toxoid history prior to child’s disease (known doses only)*/ AND 
               ap10.intRowStatus = 0
            LEFT JOIN fnReference(@langID, 988850000000 /*Immunization 5+*/)  ref_ap10
            ON ref_ap10.idfsReference = ap10.varValue 
        )
        ON obs10.idfObservation = hc.idfEPIObservation AND
           obs10.intRowStatus = 0      
              
        LEFT OUTER JOIN 
        (tlbObservation obs11
            INNER JOIN tlbActivityParameters ap11
            ON ap11.idfObservation = obs11.idfObservation AND
               ap11.idfsParameter = 1093080000000  /*Number of received doses (any vaccine with pertussis component)*/ AND 
               ap11.intRowStatus = 0
            LEFT JOIN fnReference(@langID, 988850000000 /*Immunization 5+*/)  ref_ap11
            ON ref_ap11.idfsReference = ap11.varValue 
        )
        ON obs11.idfObservation = hc.idfEPIObservation AND
           obs11.intRowStatus = 0      
                            
        LEFT OUTER JOIN 
        (tlbObservation obs12
            INNER JOIN tlbActivityParameters ap12
            ON ap12.idfObservation = obs12.idfObservation AND
               ap12.idfsParameter = 1093120000000  /*Number of received doses (any vaccine with rubella component)*/ AND 
               ap12.intRowStatus = 0
            LEFT JOIN fnReference(@langID, 988820000000 /*Immunization 3+*/)  ref_ap12
            ON ref_ap12.idfsReference = ap12.varValue 
        )
        ON obs12.idfObservation = hc.idfEPIObservation AND
           obs12.intRowStatus = 0      
               
        LEFT OUTER JOIN 
        (tlbObservation obs13
            INNER JOIN tlbActivityParameters ap13
            ON ap13.idfObservation = obs13.idfObservation AND
               ap13.idfsParameter = 1078420000000  /*Include doses of ALL tetanus-containing toxoids. Exclude doses received after this particular injury*/ AND 
               ap13.intRowStatus = 0
            LEFT JOIN fnReference(@langID, 988850000000 /*Immunization 5+*/)  ref_ap13
            ON ref_ap13.idfsReference = ap13.varValue 
        )
        ON obs13.idfObservation = hc.idfEPIObservation AND
           obs13.intRowStatus = 0                 
               
        LEFT OUTER JOIN 
        (tlbObservation obs14
            INNER JOIN tlbActivityParameters ap14
            ON ap14.idfObservation = obs14.idfObservation AND
               ap14.idfsParameter = 1133460000000  /*Was vaccination administered?*/ AND 
               ap14.intRowStatus = 0
            LEFT JOIN fnReference(@langID, 217140000000 /*Y_N_Unk*/)  ref_ap14
            ON ref_ap14.idfsReference = ap14.varValue 
        )
        ON obs14.idfObservation = hc.idfEPIObservation AND
           obs14.intRowStatus = 0                      
                     
        LEFT OUTER JOIN 
        (tlbObservation obs15
            INNER JOIN tlbActivityParameters ap15
            ON ap15.idfObservation = obs15.idfObservation AND
               ap15.idfsParameter = 1111680000000  /*Revaccination*/ AND 
               ap15.intRowStatus = 0
            LEFT JOIN fnReference(@langID, 217140000000 /*Y_N_Unk*/)  ref_ap15
            ON ref_ap15.idfsReference = ap15.varValue 
        )
        ON obs15.idfObservation = hc.idfEPIObservation AND
           obs15.intRowStatus = 0 
        LEFT OUTER JOIN 
        (tlbObservation obs16
            INNER JOIN tlbActivityParameters ap16
            ON ap16.idfObservation = obs16.idfObservation AND
               ap16.idfsParameter = 1051530000000  /*Date of vaccination*/ AND 
               ap16.intRowStatus = 0
        )
        ON obs16.idfObservation = hc.idfEPIObservation AND
           obs16.intRowStatus = 0            
           
                        
        LEFT OUTER JOIN 
        (tlbObservation obs17
            INNER JOIN tlbActivityParameters ap17
            ON ap17.idfObservation = obs17.idfObservation AND
               ap17.idfsParameter = 1051000000000  /*Date of revaccination*/ AND 
               ap17.intRowStatus = 0
        )
        ON obs17.idfObservation = hc.idfEPIObservation AND
           obs17.intRowStatus = 0     
        LEFT OUTER JOIN 
        (tlbObservation obs18
            INNER JOIN tlbActivityParameters ap18
            ON ap18.idfObservation = obs18.idfObservation AND
               ap18.idfsParameter = 1077370000000  /*Date of last vaccination*/ AND 
               ap18.intRowStatus = 0
        )
        ON obs18.idfObservation = hc.idfEPIObservation AND
           obs18.intRowStatus = 0   
                     
        LEFT OUTER JOIN 
        (tlbObservation obs18_2
            INNER JOIN tlbActivityParameters ap18_2
            ON ap18_2.idfObservation = obs18_2.idfObservation AND
               ap18_2.idfsParameter = 1118520000000  /*Date of last vaccination*/ AND 
               ap18_2.intRowStatus = 0
        )
        ON obs18_2.idfObservation = hc.idfEPIObservation AND
           obs18_2.intRowStatus = 0             

        LEFT OUTER JOIN 
        (tlbObservation obs19
            INNER JOIN tlbActivityParameters ap19
            ON ap19.idfObservation = obs19.idfObservation AND
               ap19.idfsParameter = 1052100000000  /*If "Yes", indicate dates of doses*/ AND 
               ap19.intRowStatus = 0
        )
        ON obs19.idfObservation = hc.idfEPIObservation AND
           obs19.intRowStatus = 0     

        LEFT OUTER JOIN 
        (tlbObservation obs20
            INNER JOIN tlbActivityParameters ap20
            ON ap20.idfObservation = obs20.idfObservation AND
               ap20.idfsParameter = 1093560000000  /*If "Yes", number of vaccines received*/ AND 
               ap20.intRowStatus = 0
            LEFT JOIN fnReference(@langID, 988850000000 /*Immunization 5+*/)  ref_ap20
            ON ref_ap20.idfsReference = ap20.varValue 
        )
        ON obs20.idfObservation = hc.idfEPIObservation AND
           obs20.intRowStatus = 0 

        LEFT OUTER JOIN 
        (tlbObservation obs21
            INNER JOIN tlbActivityParameters ap21
            ON ap21.idfObservation = obs21.idfObservation AND
               ap21.idfsParameter = 1079450000000  /*Interval since last tetanus toxoid dose (years)*/ AND 
               ap21.intRowStatus = 0     
        )
        ON obs21.idfObservation = hc.idfEPIObservation AND
           obs21.intRowStatus = 0  

        LEFT OUTER JOIN 
        (tlbObservation obs21_2
            INNER JOIN tlbActivityParameters ap21_2
            ON ap21_2.idfObservation = obs21_2.idfObservation AND
               ap21_2.idfsParameter = 1079410000000  /*Interval since last tetanus toxoid dose (years)*/ AND 
               ap21_2.intRowStatus = 0     
        )
        ON obs21_2.idfObservation = hc.idfEPIObservation AND
           obs21_2.intRowStatus = 0  

        LEFT OUTER JOIN 
        (tlbObservation obs22
            INNER JOIN tlbActivityParameters ap22
            ON ap22.idfObservation = obs22.idfObservation AND
               ap22.idfsParameter = 1095470000000  /*OPV-1*/ AND 
               ap22.intRowStatus = 0
            LEFT JOIN fnReference(@langID, 989090000000 /*OPV Doses*/)  ref_ap22
            ON ref_ap22.idfsReference = ap22.varValue 
        )
        ON obs22.idfObservation = hc.idfEPIObservation AND
           obs22.intRowStatus = 0 

        LEFT OUTER JOIN 
        (tlbObservation obs23
            INNER JOIN tlbActivityParameters ap23
            ON ap23.idfObservation = obs23.idfObservation AND
               ap23.idfsParameter = 1095510000000  /*OPV-2*/ AND 
               ap23.intRowStatus = 0
            LEFT JOIN fnReference(@langID, 989090000000 /*OPV Doses*/)  ref_ap23
            ON ref_ap23.idfsReference = ap23.varValue 
        )
        ON obs23.idfObservation = hc.idfEPIObservation AND
           obs23.intRowStatus = 0

        LEFT OUTER JOIN 
        (tlbObservation obs24
            INNER JOIN tlbActivityParameters ap24
            ON ap24.idfObservation = obs24.idfObservation AND
               ap24.idfsParameter = 1095550000000  /*OPV-3*/ AND 
               ap24.intRowStatus = 0
            LEFT JOIN fnReference(@langID, 989090000000 /*OPV Doses*/)  ref_ap24
            ON ref_ap24.idfsReference = ap24.varValue 
        )
        ON obs24.idfObservation = hc.idfEPIObservation AND
           obs24.intRowStatus = 0

        LEFT OUTER JOIN 
        (tlbObservation obs25
            INNER JOIN tlbActivityParameters ap25
            ON ap25.idfObservation = obs25.idfObservation AND
               ap25.idfsParameter = 1095590000000  /*OPV-4*/ AND 
               ap25.intRowStatus = 0
            LEFT JOIN fnReference(@langID, 989090000000 /*OPV Doses*/)  ref_ap25
            ON ref_ap25.idfsReference = ap25.varValue 
        )
        ON obs25.idfObservation = hc.idfEPIObservation AND
           obs25.intRowStatus = 0

        LEFT OUTER JOIN 
        (tlbObservation obs26
            INNER JOIN tlbActivityParameters ap26
            ON ap26.idfObservation = obs26.idfObservation AND
               ap26.idfsParameter = 1095630000000  /*OPV-5*/ AND 
               ap26.intRowStatus = 0
            LEFT JOIN fnReference(@langID, 989090000000 /*OPV Doses*/)  ref_ap26
            ON ref_ap26.idfsReference = ap26.varValue 
        )
        ON obs26.idfObservation = hc.idfEPIObservation AND
           obs26.intRowStatus = 0

        LEFT OUTER JOIN 
        (tlbObservation obs27
            INNER JOIN tlbActivityParameters ap27
            ON ap27.idfObservation = obs27.idfObservation AND
               ap27.idfsParameter = 1068560000000  /*First*/ AND 
               ap27.intRowStatus = 0
            LEFT JOIN fnReference(@langID, 989090000000 /*OPV Doses*/)  ref_ap27
            ON ref_ap27.idfsReference = ap27.varValue 
        )
        ON obs27.idfObservation = hc.idfEPIObservation AND
           obs27.intRowStatus = 0

        LEFT OUTER JOIN 
        (tlbObservation obs28
            INNER JOIN tlbActivityParameters ap28
            ON ap28.idfObservation = obs28.idfObservation AND
               ap28.idfsParameter = 1114560000000  /*Second*/ AND 
               ap28.intRowStatus = 0
            LEFT JOIN fnReference(@langID, 989090000000 /*OPV Doses*/)  ref_ap28
            ON ref_ap28.idfsReference = ap28.varValue 
        )
        ON obs28.idfObservation = hc.idfEPIObservation AND
           obs28.intRowStatus = 0

        LEFT OUTER JOIN 
        (tlbObservation obs29
            INNER JOIN tlbActivityParameters ap29
            ON ap29.idfObservation = obs29.idfObservation AND
               ap29.idfsParameter = 1126700000000  /*Third*/ AND 
               ap29.intRowStatus = 0
            LEFT JOIN fnReference(@langID, 989090000000 /*OPV Doses*/)  ref_ap29
            ON ref_ap29.idfsReference = ap29.varValue 
        )
        ON obs29.idfObservation = hc.idfEPIObservation AND
           obs29.intRowStatus = 0

        LEFT OUTER JOIN 
        (tlbObservation obs30
            INNER JOIN tlbActivityParameters ap30
            ON ap30.idfObservation = obs30.idfObservation AND
               ap30.idfsParameter = 1049380000000  /*Date of last OPV dose received*/ AND 
               ap30.intRowStatus = 0     
        )
        ON obs30.idfObservation = hc.idfEPIObservation AND
           obs30.intRowStatus = 0  


           
    )
    ON   ct.idfCase = hc.idfHumanCase AND
         ct.idfsSite = dbo.fnSiteID() AND
         ct.intRowStatus = 0 AND 
         DATEDIFF(D, @StartDate, ISNULL(hc.datNotificationDate, ct.datEnteredDate)) >= 0 AND
         DATEDIFF(D, @FinishDate, ISNULL(hc.datNotificationDate, ct.datEnteredDate)) <= 0 AND
			(IsNull(hc.idfsFinalDiagnosis, hc.idfsTentativeDiagnosis) = @Diagnosis OR @Diagnosis is null)

    LEFT OUTER JOIN tlbOutbreak o
    ON ct.idfOutbreak = o.idfOutbreak
		and o.intRowStatus = 0


select * 
from @ReportTable

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 