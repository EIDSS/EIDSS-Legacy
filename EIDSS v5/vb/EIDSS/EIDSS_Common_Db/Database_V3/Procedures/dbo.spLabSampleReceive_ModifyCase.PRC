SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spLabSampleReceive_ModifyCase]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spLabSampleReceive_ModifyCase]
GO

CREATE PROCEDURE [dbo].[spLabSampleReceive_ModifyCase] 
	@idfCase bigint,
	@strSampleNotes nvarchar(1000)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF EXISTS (
		SELECT tlbMaterial.idfMaterial
		FROM		tlbMaterial
		inner join	tlbParty
		on			tlbMaterial.idfParty=tlbParty.idfParty and
					tlbParty.idfCase=@idfCase and
					tlbMaterial.intRowStatus=0 and
					tlbParty.intRowStatus=0
		inner join	tlbHumanCase
		on			tlbHumanCase.idfHumanCase=@idfCase and
					(tlbHumanCase.idfsYNSpecimenCollected is null 
						or tlbHumanCase.idfsYNSpecimenCollected <> 10100001)
	)
	BEGIN
		UPDATE tlbHumanCase 
		SET idfsYNSpecimenCollected=10100001
		WHERE idfHumanCase=@idfCase
	END

	UPDATE tlbCase
	SET strSampleNotes=@strSampleNotes
	WHERE idfCase=@idfCase

END

GO