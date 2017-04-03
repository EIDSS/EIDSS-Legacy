SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spFarmPanel_PostOwnerData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spFarmPanel_PostOwnerData]
GO




--##SUMMARY Posts data for farm owner.
--##SUMMARY If owner with passed @idfOwner exists, procedure updates owner name.
--##SUMMARY In other case new farm owner is created.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 011.11.2009

--##RETURNS Doesn't use


CREATE          PROCEDURE dbo.spFarmPanel_PostOwnerData
	@idfOwner bigint,			--##PARAM @idfOwner - farm owner ID
	@idfRootOwner bigint OUTPUT,--##PARAM @idfOwner - ID of root owner copy
	@idfCase bigint,			--##PARAM @idfCase - Case ID to which current farm belongs
	@idfMonitoringSession bigint,			--##PARAM @idfMonitoringSession - AS Session ID to which current farm belongs
	@strOwnerLastName nvarchar(200),	--##PARAM @strOwnerLastName - farm owner last name
	@strOwnerFirstName nvarchar(200),	--##PARAM @strOwnerFirstName - farm owner first name
	@strOwnerSecondName nvarchar(200)	--##PARAM @strOwnerSecondName - farm owner second name
AS
	IF @idfOwner IS NULL
		RETURN 0
	SET @strOwnerLastName = RTRIM(ISNULL(@strOwnerLastName,N''))
	SET @strOwnerFirstName = RTRIM(ISNULL(@strOwnerFirstName,N''))
	SET @strOwnerSecondName = RTRIM(ISNULL(@strOwnerSecondName,N''))
	--Root owner
	IF @idfRootOwner IS NULL
	BEGIN
		EXEC dbo.spsysGetNewID @idfRootOwner OUTPUT
		INSERT INTO tlbParty(
				idfParty
				,idfsPartyType
				,idfsSite
				,idfCase
				,idfMonitoringSession
			   )
		 VALUES(
				@idfRootOwner
				,10072006 --human
				,dbo.fnSiteID()
				,NULL --@idfCase
				,NULL--@idfMonitoringSession
				)
		INSERT INTO tlbHuman(
					[idfHuman]
				   ,[strLastName]
				   ,[strSecondName]
				   ,[strFirstName]
				)
		 VALUES(
					@idfRootOwner
				   ,@strOwnerLastName
				   ,@strOwnerSecondName
				   ,@strOwnerFirstName
				)		
	END
	ELSE
	BEGIN
			UPDATE tlbHuman
			SET strLastName=@strOwnerLastName,
				strFirstName=@strOwnerFirstName,
				strSecondName=@strOwnerSecondName
			WHERE 
				idfHuman = @idfRootOwner
				AND (strLastName<>@strOwnerLastName
				OR strFirstName<>@strOwnerFirstName
				OR strSecondName<>@strOwnerSecondName)
		
	END
	-- owner that is linked to farm
	IF EXISTS (SELECT idfHuman FROM	tlbHuman
				WHERE (idfHuman = @idfOwner))
	BEGIN
		UPDATE tlbHuman
		SET strLastName=@strOwnerLastName,
			strFirstName=@strOwnerFirstName,
			strSecondName=@strOwnerSecondName
		WHERE 
			idfHuman = @idfOwner
			AND (strLastName<>@strOwnerLastName
			OR strFirstName<>@strOwnerFirstName
			OR strSecondName<>@strOwnerSecondName)
	END
	ELSE
	BEGIN
		INSERT INTO tlbParty(
				idfParty
				,idfRootParty
				,idfsPartyType
				,idfsSite
				,idfCase
				,idfMonitoringSession
			   )
		 VALUES(
				@idfOwner
				,@idfRootOwner
				,10072006 --human
				,dbo.fnSiteID()
				,@idfCase
				,@idfMonitoringSession
				)
		INSERT INTO tlbHuman(
					[idfHuman]
				   ,[strLastName]
				   ,[strSecondName]
				   ,[strFirstName]
				)
		 VALUES(
					@idfOwner
				   ,@strOwnerLastName
				   ,@strOwnerSecondName
				   ,@strOwnerFirstName
				)		
	END
 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

