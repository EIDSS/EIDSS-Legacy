SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGetNextAliquotNumber]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGetNextAliquotNumber]
GO


CREATE                   PROCEDURE dbo.spGetNextAliquotNumber( 
	@idfContainer bigint,
	@AliquotQty AS INT = 1,
	@NextNumberValue AS NVARCHAR(1000) OUTPUT
)
AS
DECLARE @SampleBarCode NVARCHAR (200)
DECLARE @strBarcode NVARCHAR(200)

SELECT		@SampleBarCode = [Root].strBarcode 
FROM		tlbContainer
INNER JOIN	tlbcontainer [Root]
ON			[Root].idfContainer=tlbContainer.idfRootParentContainer
WHERE		tlbContainer.idfContainer=@idfContainer
/*
IF @@ROWCOUNT=0
BEGIN
	RAISERROR ('Can''t create aliqot. There is no parent sample for this aliquot', 16, 1)
	return -1
END
IF ISNULL(@SampleBarCode,N'')=N''
BEGIN
	RAISERROR ('Can''t create aliqot. Parent sample has no barcode', 16, 1)
	return -1
END
*/
DECLARE @EnabledNumbers VARCHAR(100)
SET @EnabledNumbers='0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,'
DECLARE @Num VARCHAR(2)

DECLARE crAliquot CURSOR FAST_FORWARD FOR 
SELECT	strBarcode
FROM	tlbContainer
WHERE	intRowStatus=0 AND
		strBarcode LIKE (@SampleBarCode+'%')
OPEN crAliquot
FETCH NEXT FROM crAliquot INTO @strBarcode
WHILE @@FETCH_STATUS = 0
BEGIN
	IF LEN(@strBarcode)>LEN(@SampleBarCode)
	BEGIN
		SET @Num = SUBSTRING(@strBarcode,LEN(@SampleBarCode)+1,1)+','
		SET @EnabledNumbers = REPLACE(@EnabledNumbers, @Num,'')
	END
	
	FETCH NEXT FROM crAliquot INTO @strBarcode
END
CLOSE crAliquot
DEALLOCATE crAliquot
/*
IF @EnabledNumbers=''
BEGIN
	RAISERROR ('Can''t create aliquot. Maximum aliquot number (36) is exceeded', 16, 1)
	return -1
END
*/
DEClARE @I INT
SET @I=1
SET @NextNumberValue=''
WHILE @I<2*@AliquotQty AND @I<LEN(@EnabledNumbers)
BEGIN
	SET @NextNumberValue = @NextNumberValue+@SampleBarCode+SUBSTRING(@EnabledNumbers,@I,1)+','
	SET @I=@I+2
END

RETURN 0


/*
DECLARE @RC INT
DECLARE @NextNumberValue NVARCHAR(200)
EXEC @RC = dbo.spGetNextAliquotNumber '0d62c82e-23e2-44d6-a54c-aff10268221c',2,@NextNumberValue OUT
PRINT @NextNumberValue
*/
















GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

