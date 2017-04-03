SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spFarmTree_CreateCopy]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spFarmTree_CreateCopy]
GO





--##SUMMARY Creates farm tree copy.
--##SUMMARY This procedure is called when we save farm tree in vet case or in monitoring session 
--##SUMMARY or when we select root farm for vet case or monitoring session
--##SUMMARY The next copying rules are implemented in this procedure
--##SUMMARY 1. If new farm is created inside case or session and at the moment of case/session 
--##SUMMARY    saving root farm has no herds, the entire herds structure is copied to root farm
--##SUMMARY 2. If we select existing farm for case/session, the entire root herds sturcture is copied to 
--##SUMMARY    session/case farm
--##SUMMARY 3. We should have the option to use last session/case farm sturcture when we select the root farm.
--##SUMMARY 4. When we change herds structure in the session/case farm, we copy to the root farm new nodes only and update Totals for exisiting ones.
--##SUMMARY    No nodes are deleted during farm copying.
--##SUMMARY 5. After updating species nodes in the target farm the Totals on the herd/farm level are recalcualted.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 06.09.2010

--##RETURNS Doesn't use


/*
--Example of procedure call:
DECLARE @idfSourceFarm bigint
DECLARE @idfTargetFarm bigint


EXECUTE @spFarmTree_CreateCopy
   @idfSourceFarm
  ,@idfTargetFarm OUTPUT
*/







CREATE             PROCEDURE dbo.spFarmTree_CreateCopy
	@idfSourceFarm bigint,--##PARAM @idfSourceFarm - source farm ID
	@idfTargetFarm bigint,--##PARAM @idfTargetFarm - target farm ID
	@idfCase bigint,--##PARAM 
	@idfMonitoringSession bigint, --##PARAM 
	@HACode int --##PARAM @HACode - HA code of copied structure, can be 32(livestock) or 64(avian)
AS



-- Insert new values
-- to Herds

DECLARE @idfHerd bigint
DECLARE @idfTargetHerd bigint
DECLARE @idfTargetSpecies bigint
DECLARE @idfsSpeciesType bigint
DECLARE @intTotalAnimalQty int
DECLARE @strHerdCode NVARCHAR(200)

IF @idfTargetFarm IS NULL
BEGIN
	SELECT @idfTargetFarm = idfRootParty
	From		tlbParty
	WHERE idfParty = @idfSourceFarm
END
IF EXISTS 	(SELECT idfParty
	From		tlbParty
	WHERE idfParty = @idfTargetFarm
		AND idfRootParty IS NULL)
BEGIN
	SET @idfCase = NULL
	SET @idfMonitoringSession = NULL
END

DECLARE crHerd CURSOR Local Forward_only Static For
Select	Distinct	
	tlbParty.idfParty,
	tlbHerd.strHerdCode
From		tlbParty
INNER JOIN tlbHerd ON
	tlbParty.idfParty = tlbHerd.idfHerd
INNER JOIN tlbSpecies ON
	tlbHerd.idfHerd = tlbSpecies.idfHerd
INNER JOIN tlbParty AS speciesParty ON
	tlbSpecies.idfHerd = speciesParty.idfParty
	and speciesParty.intRowStatus = 0
INNER JOIN trtBaseReference ON
	tlbSpecies.idfsSpeciesType = trtBaseReference.idfsBaseReference
	and trtBaseReference.intRowStatus = 0
	and (trtBaseReference.intHACode & @HACode)<>0
Where	    
	tlbHerd.idfFarm = @idfsourceFarm
	AND tlbParty.intRowStatus = 0

OPEN crHerd
Fetch Next From crHerd into @idfHerd,@strHerdCode

While @@FETCH_STATUS = 0 Begin
	SET @idfTargetHerd = NULL
	Select	@idfTargetHerd = tlbParty.idfParty From	tlbParty
		INNER JOIN tlbHerd ON
			tlbParty.idfParty = tlbHerd.idfHerd
		Where
			tlbHerd.strHerdCode = @strHerdCode	    
			and tlbHerd.idfFarm = @idfTargetFarm
			and tlbParty.intRowStatus = 0 --Check if the herd doesn't exist in the target farm
	IF(@idfTargetHerd is NULL)
	BEGIN -- herd is new BEGIN
		EXEC spsysGetNewID @idfTargetHerd OUTPUT
		print 'insert new herd ' + CASt(ISNULL(@idfTargetHerd,0) as varchar)
		--Party
		INSERT INTO tlbParty
			   (
				idfParty
			   ,idfsPartyType
			   ,idfRootParty
			   ,idfCase
			   ,idfMonitoringSession
			   ,idfsSite
				)
		 VALUES
			   (
				@idfTargetHerd
			   ,10072003 --'pptCaseHerd'@idfsPartyType
			   ,NULL
			   ,@idfCase
			   ,@idfMonitoringSession
			   ,dbo.fnSiteID()
			   )

		--Herd itself
		INSERT INTO tlbHerd
				   (
					idfHerd
				   ,idfFarm
				   ,strHerdCode
				   )
			 VALUES
				   (
					@idfTargetHerd
				   ,@idfTargetFarm
				   ,@strHerdCode
				   )

	END-- herd is new END
	ELSE
	BEGIN
				UPDATE tlbParty
				SET idfCase = @idfCase
					,idfMonitoringSession = @idfMonitoringSession			
				WHERE  idfParty = @idfTargetHerd
						AND (ISNULL(idfCase,0) <> ISNULL(@idfCase,0)
							OR ISNULL(idfMonitoringSession,0) <> ISNULL(@idfMonitoringSession,0))
	END
		--Cursor for source species in the current source herd
		DECLARE  crSpecies cursor Local Forward_only Static For
			Select		
				idfsSpeciesType,
				tlbSpecies.intTotalAnimalQty
			From		tlbParty
			INNER JOIN tlbSpecies ON
				tlbParty.idfParty = tlbSpecies.idfSpecies
			INNER JOIN tlbHerd ON
				tlbHerd.idfHerd = tlbSpecies.idfHerd
			Where	    
				tlbHerd.idfHerd = @idfHerd
				AND tlbParty.intRowStatus = 0
		OPEN crSpecies
		Fetch Next From crSpecies into @idfsSpeciesType, @intTotalAnimalQty
		While @@FETCH_STATUS = 0 Begin --species cursor start
			SET @idfTargetSpecies = NULL
			Select	@idfTargetSpecies = tlbParty.idfParty From	tlbParty
				INNER JOIN tlbSpecies ON
					tlbParty.idfParty = tlbSpecies.idfSpecies
				INNER JOIN tlbHerd ON
					tlbHerd.idfHerd = tlbSpecies.idfHerd
				INNER JOIN tlbParty AS herdParty ON
					tlbHerd.idfHerd = herdParty.idfParty
					and herdParty.intRowStatus = 0
				Where
					tlbHerd.strHerdCode = @strHerdCode	    
					and tlbHerd.idfFarm = @idfTargetFarm
					and tlbSpecies.idfsSpeciesType = @idfsSpeciesType
					and tlbParty.intRowStatus = 0 --Check if the species doesn't exist in the target herd
			IF @idfTargetSpecies  IS NULL
			BEGIN --new species BEGIN
				EXEC spsysGetNewID @idfTargetSpecies OUTPUT
				--Party
					INSERT INTO tlbParty
						   (
							idfParty
						   ,idfsPartyType
						   ,idfRootParty
						   ,idfCase
						   ,idfMonitoringSession
						   ,idfsSite
							)
					 VALUES
						   (
							@idfTargetSpecies
						   ,10072004 --'Species'@idfsPartyType
						   ,NULL
						   ,@idfCase
						   ,@idfMonitoringSession
						   ,dbo.fnSiteID()
						   )

				--Species itself
				INSERT INTO tlbSpecies
						   (idfSpecies
						   ,idfsSpeciesType
						   ,idfHerd
						   ,intTotalAnimalQty
							)
					 VALUES
						   (@idfTargetSpecies
						   ,@idfsSpeciesType
						   ,@idfTargetHerd
						   ,@intTotalAnimalQty
						   )	
			END --new species end
			ELSE
			BEGIN
				Update tlbSpecies 
					set tlbSpecies.intTotalAnimalQty = @intTotalAnimalQty
				WHERE 
					tlbSpecies.idfSpecies = @idfTargetSpecies
				UPDATE tlbParty
				SET idfCase = @idfCase
					,idfMonitoringSession = @idfMonitoringSession			
				WHERE  idfParty = @idfTargetSpecies
						AND (ISNULL(idfCase,0) <> ISNULL(@idfCase,0)
							OR ISNULL(idfMonitoringSession,0) <> ISNULL(@idfMonitoringSession,0))
			END								
	
			Fetch Next From crSpecies into @idfsSpeciesType, @intTotalAnimalQty
		END --species cursor end 
	Close crSpecies
	Deallocate crSpecies

	-- we updated totals for target herd species.
	-- now update total for herd itslef
	DECLARE @herdTotal int
	SET @herdTotal = (SELECT SUM (ISNULL(intTotalAnimalQty,0) )
									FROM tlbSpecies
									INNER JOIN tlbParty ON
										tlbSpecies.idfSpecies = tlbParty.idfParty
										and tlbParty.intRowStatus = 0
									Where idfHerd = @idfTargetHerd)
	Print 'Herd Total = ' + CAST(ISNULL(@herdTotal,0) as varchar) + ' for herd '+ Cast(ISNULL(@idfTargetHerd,0) as varchar)
	Update tlbHerd
	SET 
		tlbHerd.intTotalAnimalQty = @herdTotal
	WHERE 
		idfHerd = @idfTargetHerd
	Fetch Next From crHerd into  @idfHerd,@strHerdCode
End --herd cursor end

Close crHerd
Deallocate crHerd


DECLARE @farmTotal int
SET @farmTotal = (SELECT SUM (ISNULL(tlbSpecies.intTotalAnimalQty,0) )
					FROM tlbHerd
					INNER JOIN tlbParty herdParty ON
						herdParty.idfParty = tlbHerd.idfHerd
						and herdParty.intRowStatus = 0
					INNER JOIN tlbSpecies ON
						tlbHerd.idfHerd = tlbSpecies.idfHerd
					INNER JOIN tlbParty AS speciesParty ON
						tlbSpecies.idfHerd = speciesParty.idfParty
						and speciesParty.intRowStatus = 0
					INNER JOIN trtBaseReference ON
						tlbSpecies.idfsSpeciesType = trtBaseReference.idfsBaseReference
						and trtBaseReference.intRowStatus = 0
						and (trtBaseReference.intHACode & @HACode)<>0
					Where tlbHerd.idfFarm=@idfTargetFarm)
	Print 'Farm Total = ' + CAST(@farmTotal as varchar) + ' for farm '+ Cast(@idfTargetFarm as varchar)
	
----Update farm records
UPDATE [tlbFarm] 
   SET 
       tlbFarm.intLivestockTotalAnimalQty = CASE WHEN (@HACode & 32)<>0 THEN @farmTotal ELSE intLivestockTotalAnimalQty END
      ,tlbFarm.intAvianTotalAnimalQty =  CASE WHEN (@HACode & 64)<>0 THEN @farmTotal ELSE intAvianTotalAnimalQty END
	WHERE 
		tlbFarm.idfFarm=@idfTargetFarm

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

