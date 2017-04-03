SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAggregateCaseHeader_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAggregateCaseHeader_Post]
GO



--##SUMMARY Post data from header of all aggregate forms.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 03.12.2009

--##RETURNS Doesn't use



/*
--Example of procedure call:

DECLARE @idfAggrCase bigint
DECLARE @idfsAggrCaseType bigint
DECLARE @idfsAdministrativeUnit bigint
DECLARE @idfReceivedByOffice bigint
DECLARE @idfReceivedByPerson bigint
DECLARE @idfSentByOffice bigint
DECLARE @idfSentByPerson bigint
DECLARE @idfEnteredByOffice bigint
DECLARE @idfEnteredByPerson bigint
DECLARE @idfCaseObservation bigint
DECLARE @idfsCaseObservationFormTemplate bigint
DECLARE @idfDiagnosticObservation bigint
DECLARE @idfsDiagnosticObservationFormTemplate bigint
DECLARE @idfProphylacticObservation bigint
DECLARE @idfsProphylacticObservationFormTemplate bigint
DECLARE @idfSanitaryObservation bigint
DECLARE @idfVersion bigint
DECLARE @idfsSanitaryObservationFormTemplate bigint
DECLARE @datReceivedByDate datetime
DECLARE @datSentByDate datetime
DECLARE @datEnteredByDate datetime
DECLARE @datStartDate datetime
DECLARE @datFinishDate datetime
DECLARE @strCaseID nvarchar(200)

EXEC spsysGetNewID @idfAggrCase OUTPUT
SELECT @idfReceivedByOffice=idfOffice FROM tstSite where idfsSite = 2
SELECT TOP 1 @idfReceivedByPerson=idfPerson from dbo.tstUserTable where idfsSite = 2
EXEC spsysGetNewID @idfCaseObservation OUTPUT
SET @idfsAggrCaseType = 10102002 
SET @idfsAdministrativeUnit = 37020000000
SET @idfSentByOffice = @idfReceivedByOffice
SET @idfSentByPerson = @idfReceivedByPerson
SET @idfEnteredByOffice = @idfReceivedByOffice
SET @idfEnteredByPerson = @idfReceivedByPerson
SET @idfsCaseObservationFormTemplate = NULL
SET @idfDiagnosticObservation  = NULL
SET @idfsDiagnosticObservationFormTemplate  = NULL
SET @idfProphylacticObservation  = NULL
SET @idfsProphylacticObservationFormTemplate  = NULL
SET @idfSanitaryObservation  = NULL

SELECT TOP 1 @idfVersion =idfVersion
FROM	tlbAggrMatrixVersionHeader
WHERE 
		idfsAggrCaseType = 71090000000
		and intRowStatus = 0
		and blnIsActive = 1
ORDER BY ISNULL(blnIsDefault, 0) DESC, datStartDate DESC

SET @idfsSanitaryObservationFormTemplate  = NULL
SET @datReceivedByDate = GETDATE()
SET @datSentByDate = GETDATE()
SET @datEnteredByDate = GETDATE()
SET @datStartDate = GETDATE()
SET @datFinishDate = GETDATE()


EXECUTE spAggregateCaseHeader_Post
   @idfAggrCase
  ,@idfsAggrCaseType
  ,@idfsAdministrativeUnit
  ,@idfReceivedByOffice
  ,@idfReceivedByPerson
  ,@idfSentByOffice
  ,@idfSentByPerson
  ,@idfEnteredByOffice
  ,@idfEnteredByPerson
  ,@idfCaseObservation
  ,@idfsCaseObservationFormTemplate
  ,@idfDiagnosticObservation
  ,@idfsDiagnosticObservationFormTemplate
  ,@idfProphylacticObservation
  ,@idfsProphylacticObservationFormTemplate
  ,@idfSanitaryObservation
  ,@idfVersion
  ,@idfsSanitaryObservationFormTemplate
  ,@datReceivedByDate
  ,@datSentByDate
  ,@datEnteredByDate
  ,@datStartDate
  ,@datFinishDate
  ,@strCaseID OUTPUT

Print @strCaseID
*/




CREATE PROC	spAggregateCaseHeader_Post
			@idfAggrCase	bigint --##PARAM @idfAggrCase - aggregate case ID
           ,@idfsAggrCaseType bigint
           ,@idfsAdministrativeUnit bigint
           ,@idfReceivedByOffice bigint
           ,@idfReceivedByPerson bigint
           ,@idfSentByOffice bigint
           ,@idfSentByPerson bigint
           ,@idfEnteredByOffice bigint
           ,@idfEnteredByPerson bigint
           ,@idfCaseObservation bigint
           ,@idfsCaseObservationFormTemplate bigint
           ,@idfDiagnosticObservation bigint
           ,@idfsDiagnosticObservationFormTemplate bigint
           ,@idfProphylacticObservation bigint
           ,@idfsProphylacticObservationFormTemplate bigint
           ,@idfSanitaryObservation bigint
           ,@idfVersion bigint
		   ,@idfDiagnosticVersion bigint
		   ,@idfProphylacticVersion bigint
		   ,@idfSanitaryVersion bigint
           ,@idfsSanitaryObservationFormTemplate bigint
           ,@datReceivedByDate datetime
           ,@datSentByDate datetime
           ,@datEnteredByDate datetime
           ,@datStartDate datetime
           ,@datFinishDate datetime
           ,@strCaseID nvarchar(200) OUTPUT

AS
IF EXISTS (SELECT * FROM tlbAggrCase WHERE idfAggrCase = @idfAggrCase)
BEGIN
	IF NOT @idfCaseObservation IS NULL
		EXEC spObservation_Post @idfCaseObservation, @idfsCaseObservationFormTemplate
	IF NOT @idfDiagnosticObservation IS NULL
		EXEC spObservation_Post @idfDiagnosticObservation, @idfsDiagnosticObservationFormTemplate
	IF NOT @idfProphylacticObservation IS NULL
		EXEC spObservation_Post @idfProphylacticObservation, @idfsProphylacticObservationFormTemplate
	IF NOT @idfSanitaryObservation IS NULL
		EXEC spObservation_Post @idfSanitaryObservation, @idfsSanitaryObservationFormTemplate
	UPDATE tlbAggrCase
	SET 
		idfsAggrCaseType = @idfsAggrCaseType
		,idfsAdministrativeUnit = @idfsAdministrativeUnit
		,idfReceivedByOffice = @idfReceivedByOffice
		,idfReceivedByPerson = @idfReceivedByPerson
		,idfSentByOffice = @idfSentByOffice
		,idfSentByPerson = @idfSentByPerson
		,idfEnteredByOffice = @idfEnteredByOffice
		,idfEnteredByPerson = @idfEnteredByPerson
		,idfCaseObservation = @idfCaseObservation
		,idfDiagnosticObservation = @idfDiagnosticObservation
		,idfProphylacticObservation = @idfProphylacticObservation
		,idfSanitaryObservation = @idfSanitaryObservation
		,idfVersion = @idfVersion
		,idfDiagnosticVersion = @idfDiagnosticVersion
		,idfProphylacticVersion = @idfProphylacticVersion
		,idfSanitaryVersion = @idfSanitaryVersion
		,datReceivedByDate = @datReceivedByDate
		,datSentByDate = @datSentByDate
		,datEnteredByDate = @datEnteredByDate
		,datStartDate = @datStartDate
		,datFinishDate = @datFinishDate
		,strCaseID = @strCaseID
	WHERE 
			idfAggrCase = @idfAggrCase
END
ELSE
BEGIN
	DECLARE @NextNumberType BIGINT
	SET @NextNumberType =	CASE @idfsAggrCaseType 
							WHEN 10102001 /*AggregateCase*/ THEN 10057001
							WHEN 10102002 /*VetAggregateCase*/ THEN 10057003
							WHEN 10102003 /*VetAggregateAction*/ THEN 10057002
							END
	
	IF ISNULL(@strCaseID,N'') = N'' OR LEFT(ISNULL(@strCaseID,N''),4)='(new'
	BEGIN
		EXEC dbo.spGetNextNumber @NextNumberType, @strCaseID OUTPUT , NULL 
	END
	IF NOT @idfCaseObservation IS NULL
		EXEC spObservation_Post @idfCaseObservation, @idfsCaseObservationFormTemplate
	IF NOT @idfDiagnosticObservation IS NULL
		EXEC spObservation_Post @idfDiagnosticObservation, @idfsDiagnosticObservationFormTemplate
	IF NOT @idfProphylacticObservation IS NULL
		EXEC spObservation_Post @idfProphylacticObservation, @idfsProphylacticObservationFormTemplate
	IF NOT @idfSanitaryObservation IS NULL
		EXEC spObservation_Post @idfSanitaryObservation, @idfsSanitaryObservationFormTemplate
	INSERT INTO tlbAggrCase
           (idfAggrCase
           ,idfsAggrCaseType
           ,idfsAdministrativeUnit
           ,idfReceivedByOffice
           ,idfReceivedByPerson
           ,idfSentByOffice
           ,idfSentByPerson
           ,idfEnteredByOffice
           ,idfEnteredByPerson
           ,idfCaseObservation
           ,idfDiagnosticObservation
           ,idfProphylacticObservation
           ,idfSanitaryObservation
           ,idfVersion
		   ,idfDiagnosticVersion
		   ,idfProphylacticVersion
		   ,idfSanitaryVersion
           ,datReceivedByDate
           ,datSentByDate
           ,datEnteredByDate
           ,datStartDate
           ,datFinishDate
           ,strCaseID
			)
     VALUES
           (
			@idfAggrCase
           ,@idfsAggrCaseType
           ,@idfsAdministrativeUnit
           ,@idfReceivedByOffice
           ,@idfReceivedByPerson
           ,@idfSentByOffice
           ,@idfSentByPerson
           ,@idfEnteredByOffice
           ,@idfEnteredByPerson
           ,@idfCaseObservation
           ,@idfDiagnosticObservation
           ,@idfProphylacticObservation
           ,@idfSanitaryObservation
           ,@idfVersion
		   ,@idfDiagnosticVersion
		   ,@idfProphylacticVersion
		   ,@idfSanitaryVersion
           ,@datReceivedByDate
           ,@datSentByDate
           ,@datEnteredByDate
           ,@datStartDate
           ,@datFinishDate
           ,@strCaseID
		)
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

