SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spFarmPanel_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spFarmPanel_Post]
GO





--##SUMMARY Posts data from FarmDetail panel.
--##SUMMARY FarmDetail panel is used on 2 form types - on FarmDetail form and on Vet Case forms.
--##SUMMARY In the case FarmDetail form it displays data for root farm object, i.e for farm that is not linked to any case 
--##SUMMARY and contains dat that was entered last time for the farm in any form. If user edits farm data on the FarmDetail form,
--##SUMMARY the changes are saved for this root farm record only and doesn't affect to case related farms
--##SUMMARY Vet Case forms displays copy of farm data linked to the case. If user selects farm from existing farms list, the farm copy is created and attached to case.
--##SUMMARY If user creates new farm for case, the root farm is also created as copy of the new farm.
--##SUMMARY If farm was changed on the vet case form, the changes are saved for both case farm copy and root farm.
--##SUMMARY Thus root farm always contains most recently farm data, but case farm copy contains farm data actual at the time of vet case creation.



--##REMARKS Author: Zurin M.
--##REMARKS Create date: 15.12.2009

--##RETURNS Doesn't use


/*
--Example of procedure call:

DECLARE @Action int
DECLARE @idfFarm bigint
DECLARE @idfRootFarm bigint
DECLARE @idfCase bigint
DECLARE @idfMonitoringSession bigint
DECLARE @strContactPhone nvarchar(200)
DECLARE @strInternationalName nvarchar(200)
DECLARE @strNationalName nvarchar(200)
DECLARE @strFarmCode nvarchar(200)
DECLARE @strFax nvarchar(200)
DECLARE @strEmail nvarchar(200)
DECLARE @idfFarmLocation bigint
DECLARE @idfFarmAddress bigint
DECLARE @blnIsLivestock bit
DECLARE @blnIsAvian bit
DECLARE @idfOwner bigint
DECLARE @strOwnerLastName nvarchar(200)
DECLARE @strOwnerFirstName nvarchar(200)
DECLARE @strOwnerMiddleName nvarchar(200)

EXECUTE spFarmPanel_Post
   @Action
  ,@idfFarm
  ,@idfRootFarm OUTPUT
  ,@idfCase
  ,@idfMonitoringSession
  ,@strContactPhone
  ,@strInternationalName
  ,@strNationalName
  ,@strFarmCode OUTPUT
  ,@strFax
  ,@strEmail
  ,@idfFarmLocation
  ,@idfFarmAddress
  ,@blnIsLivestock
  ,@blnIsAvian
  ,@idfOwner
  ,@strOwnerLastName
  ,@strOwnerFirstName
  ,@strOwnerMiddleName
*/







CREATE             PROCEDURE dbo.spFarmPanel_Post
	@Action INT, --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
	@idfFarm bigint,--##PARAM @idfFarm - farm ID
	@idfRootFarm bigint OUTPUT,--##PARAM @idfRootFarm - root farm ID, during posting data for root farm must be NULL
	@idfCase bigint,--##PARAM @idfCase - case to which farm is attached, during posting data for root farm must be NULL
	@idfMonitoringSession bigint,--##PARAM @idfMonitoringSession - monitoring to which farm is attached, during posting data for root farm must be NULL
	@strContactPhone NVARCHAR(200), --##PARAM @strContactPhone - farm phone
	@strInternationalName NVARCHAR(200), --##PARAM @strInternationalName - farm name in English
	@strNationalName NVARCHAR(200), --##PARAM @strNationalName - farm name in current national language
	@strFarmCode NVARCHAR(200) OUTPUT,--##PARAM @strFarmCode - unique human readable farm code (can be used as farm barcode), if NULL, assigned inside procedure
	@strFax NVARCHAR(200),--##PARAM @strFax - farm fax
	@strEmail NVARCHAR(200),--##PARAM @strEmail - farm email
	@idfFarmLocation bigint,--##PARAM @idfFarmLocation - reference to farm location
	@idfFarmAddress bigint,--##PARAM @idfFarmAddress - reference to farm address
	@blnIsLivestock bit,--##PARAM @blnIsLivestock - flag that set to 1 for livestock farm,, if procedure is called from avian case must be set to NULL to avoid overriding of parent farm flag
	@blnIsAvian bit,--##PARAM @blnIsAvian - flag that set to 1 for avian farm, if procedure is called from livestock case/session must be set to NULL to avoid overriding of parent farm flag
	@idfOwner bigint,--##PARAM @idfOwner - refernece to farm owner
	@idfRootOwner bigint OUTPUT,--##PARAM @idfRootOwner - refernece to root copy of farm owner
	@strOwnerLastName NVARCHAR(200),--##PARAM @strOwnerLastName - farm owner last name
	@strOwnerFirstName NVARCHAR(200),--##PARAM @strOwnerFirstName - farm owner first name
	@strOwnerMiddleName NVARCHAR(200)--##PARAM @strOwnerMiddleName - farm owner middle name

AS

Print 'posting farm ' + CAST(@idfFarm as VARCHAR) + ' root farm ' +   ISNULL(CAST(@idfRootFarm as VARCHAR),'NULL')

DECLARE @IsRootFarm bit

IF (@idfCase IS NULL and @idfMonitoringSession IS NULL)
	SET @IsRootFarm = 1
ELSE
	SET @IsRootFarm = 0

IF ISNULL(@strFarmCode,N'') = N'' OR LEFT(ISNULL(@strFarmCode,N''),4)='(new'
BEGIN
	EXEC dbo.spGetNextNumber 10057010, @strFarmCode OUTPUT , NULL --N'nbtFarmNumber'
END


if @IsRootFarm = 0 --this is the case related farm, we should update root farm info
BEGIN
	DECLARE @idfRootFarmLocation bigint
	DECLARE @idfRootFarmAddress bigint
	
	if  @idfRootFarm IS NULL 
	BEGIN
		EXEC dbo.spsysGetNewID @idfRootFarm OUTPUT
	END
	DECLARE @dummyID bigint
	DECLARE @RootAction int
	DECLARE @idfRootFarmOwner bigint
	SELECT 
		@idfRootFarmLocation = idfFarmLocation 
		,@idfRootFarmAddress = idfFarmAddress
		,@idfRootFarmOwner = idfHuman
	FROM tlbFarm 
	WHERE idfFarm = @idfRootFarm
	
	if @@ROWCOUNT>0
		SET @RootAction = 16
	else
	BEGIN
		SET @RootAction = 4
		EXEC dbo.spsysGetNewID @idfRootFarmLocation OUTPUT
		EXEC dbo.spsysGetNewID @idfRootFarmAddress OUTPUT
	END
	Print 'posting root farm ' + ISNULL(CAST(@idfRootFarm as VARCHAR),'NULL') + ' Action ' + CAST(@RootAction as varchar)
	EXEC spGeoLocation_CreateCopy	@idfFarmLocation, @idfRootFarmLocation
	EXEC spGeoLocation_CreateCopy	@idfFarmAddress, @idfRootFarmAddress
	IF @idfRootFarmOwner IS NULL
		EXEC dbo.spsysGetNewID @idfRootFarmOwner OUTPUT
	
	EXEC dbo.spFarmPanel_Post 
			@RootAction,
			@idfRootFarm, --update root farm data
			@dummyID output, --@idfRootFarm should be null for root farm
			null, --@idfCase should be null for root farm
			null, --@idfMonitoringSession should be null for root farm
			@strContactPhone, 
			@strInternationalName, 
			@strNationalName, 
			@strFarmCode OUTPUT,
			@strFax,
			@strEmail,
			@idfRootFarmLocation,
			@idfRootFarmAddress,
			@blnIsLivestock,
			@blnIsAvian,
			@idfRootFarmOwner,
			@idfRootOwner OUTPUT,
			@strOwnerLastName,
			@strOwnerFirstName,
			@strOwnerMiddleName
	Update tlbParty
	SET idfRootParty = @idfRootFarm
	where 
		idfParty = @idfFarm
		and idfRootParty <> @idfRootFarm
END

IF @Action=16 --Modified
BEGIN
	EXEC spFarmPanel_PostOwnerData	@idfOwner,
									@idfRootOwner OUTPUT,
									@idfCase,
									@idfMonitoringSession,
									@strOwnerLastName,
									@strOwnerFirstName,
									@strOwnerMiddleName
	UPDATE tlbFarm
	SET
		strContactPhone=@strContactPhone, 
		strInternationalName=@strInternationalName, 
		strNationalName=@strNationalName, 
		strFarmCode=@strFarmCode,
		strFax=@strFax,
		strEmail=@strEmail,
		idfFarmLocation=@idfFarmLocation,
		idfFarmAddress=@idfFarmAddress,
		idfHuman=@idfOwner,
		blnIsLivestock = ISNULL(@blnIsLivestock,blnIsLivestock),
		blnIsAvian = ISNULL(@blnIsAvian,blnIsAvian),
		strOwnerLastName = @strOwnerLastName,
		strOwnerFirstName = @strOwnerFirstName,
		strOwnerMiddleName = @strOwnerMiddleName

	WHERE 
		idfFarm=@idfFarm

END
IF @Action=8 --Deleted
BEGIN
	EXEC dbo.spFarm_Delete @idfFarm
	Return 0
END

IF @Action=4 --Added
BEGIN
	EXEC spFarmPanel_PostOwnerData	@idfOwner,
									@idfRootOwner OUTPUT,
									@idfCase,
									@idfMonitoringSession,
									@strOwnerLastName,
									@strOwnerFirstName,
									@strOwnerMiddleName
	
Print 'inserting party idfParty = ' + CAST(@idfFarm as VARCHAR)+', idfRootParty = ' +  ISNULL(CAST(@idfRootFarm as VARCHAR),'NULL')

	INSERT INTO tlbParty(
		idfParty
		,idfsPartyType
		,idfsSite
		,idfRootParty
		,idfCase
		,idfMonitoringSession
	   )
	 VALUES(
			@idfFarm
			,10072005 --Farm,
			,dbo.fnSiteID()
			,@idfRootFarm
			,@idfCase
			,@idfMonitoringSession
			)

	INSERT INTO tlbFarm(
		idfFarm, 
		strContactPhone, 
		strInternationalName, 
		strNationalName, 
		strFarmCode,
		strFax,
		strEmail,
		idfFarmLocation,
		idfFarmAddress,
		idfHuman,
		blnIsLivestock,
		blnIsAvian,
		strOwnerLastName,
		strOwnerFirstName,
		strOwnerMiddleName
	)
	VALUES	(
		@idfFarm, 
		@strContactPhone, 
		@strInternationalName, 
		@strNationalName, 
		@strFarmCode,
		@strFax,
		@strEmail,
		@idfFarmLocation,
		@idfFarmAddress,
		@idfOwner,
		@blnIsLivestock,
		@blnIsAvian,
		@strOwnerLastName,
		@strOwnerFirstName,
		@strOwnerMiddleName

	)

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

