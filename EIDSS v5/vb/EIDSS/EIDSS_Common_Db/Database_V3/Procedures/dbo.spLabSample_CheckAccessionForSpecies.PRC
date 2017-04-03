SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spLabSample_CheckAccessionForSpecies]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spLabSample_CheckAccessionForSpecies]
GO

CREATE            PROCEDURE dbo.spLabSample_CheckAccessionForSpecies( 
	@idfSpecies AS bigint--,
	--@LANGID NVARCHAR(50)
)
AS

IF Exists(
	SELECT top 1 * from tlbAccessionIN 
	inner join tlbMaterial on
		tlbMaterial.idfMaterial = tlbAccessionIN.idfMaterial
		and tlbMaterial.intRowStatus=0
	inner join tlbAnimal on
		tlbAnimal.idfAnimal = tlbMaterial.idfParty
	inner join tlbParty on 
		tlbAnimal.idfAnimal = tlbParty.idfParty
		and tlbParty.intRowStatus=0
	where tlbAnimal.idfSpecies = @idfSpecies
	)
	select 1;
else if Exists(
	SELECT top 1 * from tlbAccessionIN 
	inner join tlbMaterial on
		tlbMaterial.idfMaterial = tlbAccessionIN.idfMaterial
		and tlbMaterial.intRowStatus=0
	inner join tlbSpecies on
		tlbSpecies.idfSpecies = tlbMaterial.idfParty
	inner join tlbParty on 
		tlbSpecies.idfSpecies = tlbParty.idfParty
		and tlbParty.intRowStatus=0
	where tlbSpecies.idfSpecies = @idfSpecies
	)
	select 1;

else
	select 0;


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

