SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spLabSampleTransfer_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spLabSampleTransfer_Update]
GO

CREATE PROCEDURE [dbo].[spLabSampleTransfer_Update]
	@idfTransferOut bigint,
	@strBarcode nvarchar(200),
	@strNote nvarchar(2000),
	@idfSendToOffice bigint,--target site
	@idfSendByPerson bigint,--who sent
	@datSendDate datetime,--time sent
	@idfsTransferStatus bigint--transfer status
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	update	tlbTransferOut
	set		
			strBarcode=@strBarcode,
			strNote=@strNote,
			idfSendToOffice=@idfSendToOffice,
			idfSendByPerson =@idfSendByPerson,
			datSendDate =@datSendDate,
			idfsTransferStatus =@idfsTransferStatus
	where	idfTransferOut=@idfTransferOut
/*
	UPDATE Activity 
	SET strActivityCode=@strActivityCode, datStartDate=@datStartDate, strNote=@strNote, idfsActivity_Status=@idfsActivity_Status
	WHERE idfActivity=@idfActivity

	IF @idfOffice IS NOT NULL
	BEGIN
		UPDATE Office_For_Activity SET idfOffice=@idfOffice WHERE idfActivity=@idfActivity AND idfsOffice_For_Activity_Type='oatToInstitution' AND intRowStatus=0
		IF @@ROWCOUNT=0
		BEGIN
			INSERT INTO Office_For_Activity(idfActivity,idfOffice,idfsOffice_For_Activity_Type)
			VALUES(@idfActivity,@idfOffice,'oatToInstitution')
		END
	END

	IF @idfsActivity_Status='acsInProgress'
	BEGIN
		UPDATE Employee_For_Activity SET idfEmployee=@idfEmployee WHERE idfActivity=@idfActivity AND idfsEmployee_For_Activity_Type='eatSentBy'
		IF @@ROWCOUNT=0
		BEGIN
			INSERT Employee_For_Activity(idfActivity,idfEmployee,idfsEmployee_For_Activity_Type)
			VALUES(@idfActivity,@idfEmployee,'eatSentBy')
		END
	END
*/
END
GO