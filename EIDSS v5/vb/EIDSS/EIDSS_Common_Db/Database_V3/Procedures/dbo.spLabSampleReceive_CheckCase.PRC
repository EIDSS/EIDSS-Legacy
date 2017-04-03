SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spLabSampleReceive_CheckCase]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spLabSampleReceive_CheckCase]
GO

CREATE PROCEDURE spLabSampleReceive_CheckCase
	@idfCase bigint
AS
BEGIN

	select	tlbHumanCase.idfsYNSpecimenCollected,
			tlbHumanCase.strNotCollectedReason
	from	tlbHumanCase
	where	idfHumanCase=@idfCase
END
GO

