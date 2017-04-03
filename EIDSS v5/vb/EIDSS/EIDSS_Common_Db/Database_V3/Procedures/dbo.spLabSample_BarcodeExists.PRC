SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spLabSample_BarcodeExists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spLabSample_BarcodeExists]
GO


GO
/****** Object:  StoredProcedure [dbo].[spLabSample_BarcodeExists]    Script Date: 07/22/2011 12:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spLabSample_BarcodeExists]( 
	@value AS nvarchar(30)
)
AS

begin

SELECT top 1 * from dbo.[tlbContainer] where strBarcode = @value and intRowStatus = 0

end

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

