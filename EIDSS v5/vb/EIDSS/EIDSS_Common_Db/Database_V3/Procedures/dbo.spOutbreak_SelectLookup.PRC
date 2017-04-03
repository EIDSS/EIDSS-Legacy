SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spOutbreak_SelectLookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spOutbreak_SelectLookup]
GO



CREATE           PROCEDURE [dbo].[spOutbreak_SelectLookup]
as
SELECT [idfOutbreak]
      ,strOutbreakID
  FROM tlbOutbreak 		
where		intRowStatus = 0






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

