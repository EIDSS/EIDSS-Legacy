SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spFarm_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spFarm_Delete]
GO


--##SUMMARY Deletes farm object.
--##SUMMARY When called from FarmList/FarmDetail forms it deletes only farm object. In this case spFarm_CanDelete
--##SUMMARY procedure should enable farm deleting only if there is no case related farms that refer given farm as root farm.
--##SUMMARY Also can be called from spVetCase_Delete procedure. In this case it deletes only case related farm, root farm object left in the system

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 15.11.2009

--##RETURNS Doesn't use

/*
Example of procedure call:

DECLARE @ID bigint
EXEC spFarm_Delete @ID

*/


CREATE   procedure dbo.spFarm_Delete
	@ID as bigint --##PARAM @ID - farm ID
as

--Store farm links for futher deleting
DECLARE @idfFarmLocation bigint
DECLARE @idfFarmAddress bigint
SELECT
	@idfFarmLocation = idfFarmLocation
	,@idfFarmAddress = idfFarmAddress
FROM tlbFarm
WHERE
	tlbFarm.idfFarm = @ID



--Store  observations that should be deleted into temporary table
DECLARE @Observation Table
(
	idfObservation bigint
)
--Farm observation
insert into @Observation
(
idfObservation
)
SELECT
	idfObservation
FROM tlbFarm
WHERE
	tlbFarm.idfFarm = @ID

--Species observations
insert into @Observation
(
idfObservation
)
SELECT
	idfObservation
FROM tlbSpecies
inner join tlbHerd on
		tlbSpecies.idfHerd = tlbHerd.idfHerd
where	tlbHerd.idfFarm = @ID

--Animal observations
insert into @Observation
(
idfObservation
)
SELECT
	tlbAnimal.idfObservation
FROM tlbAnimal
inner join tlbSpecies on
		tlbSpecies.idfSpecies = tlbAnimal.idfSpecies
inner join tlbHerd on
		tlbSpecies.idfHerd = tlbHerd.idfHerd
where	tlbHerd.idfFarm = @ID

--Store  parties that should be deleted into temporary table
DECLARE @Party Table
(
	idfParty bigint
)

INSERT INTO @Party
	(idfParty)
SELECT
	idfFarm
FROM tlbFarm
WHERE
	tlbFarm.idfFarm = @ID

INSERT INTO @Party
	(idfParty)
SELECT
	idfHerd
FROM tlbHerd
WHERE
	tlbHerd.idfFarm = @ID

INSERT INTO @Party
	(idfParty)
SELECT
	idfSpecies
from	tlbSpecies
inner join tlbHerd on
		tlbSpecies.idfHerd = tlbHerd.idfHerd
where	tlbHerd.idfFarm = @ID

INSERT INTO @Party
	(idfParty)
SELECT
	idfAnimal
from	tlbAnimal
inner join tlbSpecies on
		tlbSpecies.idfSpecies = tlbAnimal.idfSpecies
inner join tlbHerd on
		tlbSpecies.idfHerd = tlbHerd.idfHerd
where	tlbHerd.idfFarm = @ID
INSERT INTO @Party
	(idfParty)
SELECT
	idfHuman
from	tlbFarm
where	tlbFarm.idfFarm = @ID

-- Delete animal information
delete	tlbAnimal
from	tlbAnimal
inner join tlbSpecies on
		tlbSpecies.idfSpecies = tlbAnimal.idfSpecies
inner join tlbHerd on
		tlbSpecies.idfHerd = tlbHerd.idfHerd
where	tlbHerd.idfFarm = @ID

delete	tlbSpecies
from	tlbSpecies
inner join tlbHerd on
		tlbSpecies.idfHerd = tlbHerd.idfHerd
where	tlbHerd.idfFarm = @ID


delete	tlbHerd
where	idfFarm = @ID

delete	tlbHuman
from	tlbHuman
inner join tlbFarm on
		tlbHuman.idfHuman = tlbFarm.idfHuman
where	tlbFarm.idfHuman = @ID

--delete farm itself

delete	tlbFarm
where	idfFarm = @ID

delete  tlbParty
where	idfParty in (Select idfParty from @Party)

--Delete farm location and address
delete	tlbGeoLocation
where	idfGeoLocation=@idfFarmLocation

delete	tlbGeoLocation
where	idfGeoLocation=@idfFarmAddress

-- Delete farm observation
DELETE dbo.tlbActivityParameters
WHERE 	idfObservation in (Select idfObservation from @Observation)

delete	tlbObservation
where	idfObservation in (Select idfObservation from @Observation)


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

