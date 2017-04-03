SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepHumChangedDiagnosis]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepHumChangedDiagnosis]
GO

--##SUMMARY Selects data for DepartmentDetail form

--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 3.12.2009

--##RETURNS Doesn't use

/*
Example of a call of procedure:

EXEC spRepHumChangedDiagnosis 'EN', '19010101', '20511201'

*/

CREATE PROCEDURE [dbo].[spRepHumChangedDiagnosis](
      @LangID VARCHAR(36), 
      @SD AS NVARCHAR(20),
      @ED AS NVARCHAR(20)
  
  )
AS
	/* Commented because permissions not ready yet
	DECLARE @TypePer int
	SET @TypePer = dbo.fn_ObjectTypePermission('objHumanCase', null, 'ObjectOperationRead')
	*/
	DECLARE 
	  @DateStart DATETIME,
	  @DateEnd DATETIME

	SET @DateStart = CAST(@SD AS DATETIME)
	SET @DateEnd = CAST(@ED AS DATETIME)


	SELECT 
	  DiagName.[Name] AS Diagnosis,
	  Count(DiagName.idfsReference) AS CountDiagnosis,
	  Count(CASE WHEN ShowDiagName.idfsReference <> DiagName.idfsReference 
					THEN 1 
					ELSE NULL 
			END) AS  CountChangedDiagnosis 
	  
	FROM		dbo.tlbCase AS CaseTable
	LEFT JOIN	tlbHumanCase AS HumanCase
		   ON	HumanCase.idfHumanCase = CaseTable.idfCase

	LEFT JOIN	fnReference(@LangID, 19000019 /*'rftDiagnosis'*/) AS ShowDiagName
		   ON   ShowDiagName.idfsReference = CaseTable.idfsShowDiagnosis    

	LEFT JOIN	fnReference(@LangID, 19000019 /*'rftDiagnosis'*/) AS DiagName
		   ON   DiagName.idfsReference = HumanCase.idfsTentativeDiagnosis    

	/* Commented because permissions not ready yet
	   LEFT JOIN	dbo.fn_ObjectDirectPermission_HumanCase('ObjectOperationRead', NULL) ObjectPermission
		ON ObjectPermission.idfActivity = Activity.idfActivity

	   WHERE	(ObjectPermission.intPermission IN (2, 4) OR 
				 ObjectPermission.intPermission IS NULL AND @TypePer <> 1)
	*/
		WHERE	CaseTable.idfsCaseStatus = 350000000 /*'casConfirmed'*/
		  AND	CaseTable.intRowStatus = 0  
		  AND	DATEDIFF(D, @DateStart, CaseTable.datEnteredDate) >= 0  -- Activity.datStartDate
		  AND	DATEDIFF(D, @DateEnd, HumanCase.datCompletionPaperFormDate) <= 0  -- Activity.datFinishDate

	 GROUP BY	DiagName.[Name]
