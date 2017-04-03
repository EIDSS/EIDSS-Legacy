SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spLabSampleTransfer_Manage]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spLabSampleTransfer_Manage]
GO

CREATE PROCEDURE [dbo].[spLabSampleTransfer_Manage]
	@idfTransferOut bigint,
	@idfContainer bigint,
	--@idfMaterial bigint,
	@add integer
AS
BEGIN
	if @add>0
	BEGIN

		DECLARE @transfer nvarchar(200)
		DECLARE @tid bigint
		DECLARE @barcode nvarchar(200)

		SELECT		@transfer=tlbTransferOut.strBarcode,
					@tid=tlbTransferOut.idfTransferOut,
					@barcode=tlbContainer.strBarcode
		FROM		tlbTransferOutContainerList
		INNER JOIN	tlbTransferOut
		ON			tlbTransferOut.idfTransferOut=tlbTransferOutContainerList.idfTransferOut AND
					tlbTransferOut.intRowStatus=0
		INNER JOIN	tlbContainer
		ON			tlbContainer.idfContainer=tlbTransferOutContainerList.idfContainer AND
					tlbContainer.intRowStatus=0
		WHERE		tlbTransferOutContainerList.idfContainer=@idfContainer AND
					tlbTransferOutContainerList.intRowStatus=0
		
		IF @tid is not null
		BEGIN
			   RAISERROR ('errSampleInTransfer %s %s', 16, 1, @barcode,@transfer)
		END

		INSERT INTO tlbTransferOutContainerList
		(idfContainer,idfTransferOut)
		VALUES(@idfContainer,@idfTransferOut)
/*	
		DECLARE @TID nvarchar(200)
		SELECT @TID=strActivityCode
		FROM Activity
		INNER JOIN Container_Participation 
		ON	Container_Participation.idfActivity=Activity.idfActivity
			AND Activity.intRowStatus=0
			AND Activity.idfsActivity_Type='actTransferOut'
			AND Container_Participation.intRowStatus=0
			AND Container_Participation.idfContainer=@idfContainer
		
		IF @TID IS NOT NULL
		BEGIN
			   RAISERROR ('%s', 16, 1, @TID)
		END

		INSERT INTO Container_Participation(idfActivity,idfContainer)
		VALUES(@idfActivity,@idfContainer)
		INSERT INTO Material_Participation(idfActivity,idfMaterial,idfsMaterial_Participation_Type)
		VALUES(@idfActivity,@idfMaterial,'mptDefault')*/
	END
	ELSE
	BEGIN
/*		DELETE FROM Container_Participation
		WHERE idfActivity=@idfActivity AND idfContainer=@idfContainer
		DELETE FROM Material_Participation
		WHERE idfActivity=@idfActivity AND idfMaterial=@idfMaterial*/
		DELETE FROM tlbTransferOutContainerList
		WHERE	idfTransferOut=@idfTransferOut and idfContainer=@idfContainer
	END
END
GO