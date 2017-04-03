SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGetQueryPage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGetQueryPage]
GO
--##SUMMARY Returns specific part of query recods.
--##SUMMARY This procedure is used by list forms to displayed paged lists. It returns data for specific page there.
--##SUMMARY The server cursors are used for page retrieving as compromise between speed and universality.
--##SUMMARY Procedure fills 3 tables. First table is empty and contains the resulting table structure only.
--##SUMMARY Second one contains one record with single column that contains the total number of records returned by the query
--##SUMMARY Third table returns requested records range

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 28.11.2009

--##RETURNS Doesn't use


/*Example of procedure call:
DECLARE @text NVARCHAR(4000)
SET @text = 'select TOP 1 With TIES '
SET @text = @text + 'fn_VetCase_SelectList.* from fn_VetCase_SelectList (''en'') '
SET @text = @text + 'inner join  tlbParty anParty on anParty.idfCase = fn_VetCase_SelectList.[idfCase] and  anParty.intRowStatus = 0 '
SET @text = @text + 'inner Join tlbAnimal a on a.idfAnimal=anParty.idfParty  and a.intRowStatus = 0  and anParty.idfsPartyType = 10072002 '
SET @text = @text + 'inner join  tlbParty sParty on sParty.idfCase = fn_VetCase_SelectList.[idfCase] and  sParty.intRowStatus = 0 '
SET @text = @text + 'inner Join tlbSpecies s on s.idfSpecies=sParty.idfParty  and s.intRowStatus = 0  and sParty.idfsPartyType = 10072004 '
SET @text = @text + 'ORDER BY ROW_NUMBER() OVER(PARTITION BY fn_VetCase_SelectList.idfCase ORDER BY fn_VetCase_SelectList.strCaseID) '
Print @text
EXEC spGetQueryPage @text, 1000, 50

DECLARE @text NVARCHAR(4000)
SET @text = 'select '
SET @text = @text + '* from fn_VetCase_SelectList (''en'') ' 
SET @text = @text + 'inner join  ( select distinct idfCase from tlbParty  '
SET @text = @text + 'inner Join tlbAnimal a on a.idfAnimal=tlbParty.idfParty  and a.intRowStatus = 0 and tlbParty.idfsPartyType = 10072002 '
SET @text = @text + 'where tlbParty.intRowStatus = 0 '
SET @text = @text + ') anParty on anParty.idfCase = fn_VetCase_SelectList.[idfCase] '

SET @text = @text + 'inner join  ( select distinct idfCase from tlbParty  '
SET @text = @text + 'inner Join tlbSpecies s on s.idfSpecies=tlbParty.idfParty  and s.intRowStatus = 0 and tlbParty.idfsPartyType = 10072004 '
SET @text = @text + 'where tlbParty.intRowStatus = 0 '
SET @text = @text + ') sParty on sParty.idfCase = fn_VetCase_SelectList.[idfCase] '
EXEC spGetQueryPage @text, 1000, 50


exec spGetQueryPage 'SELECT * FROM gisSettlement', 1, 1000
exec spGetQueryPage 'SELECT * FROM fn_VetCase_SelectList(''en'')' , 1000, 50


*/
CREATE  Proc spGetQueryPage
		@queryText ntext, --##PARAM @queryText - text of query to execute
		@firstRecordNum  int, --##PARAM @firstRecordNum - the number of first record that should be returned
		@maxRecordCount  int --##PARAM @maxRecordCount - the number of recordû that should be returned

As
SET NOCOUNT ON
DECLARE @handle int, @rows int

EXEC sp_cursoropen 
  @handle OUT, 
  @queryText, 
  1, -- Keyset-driven cursor
  1, -- Read-only
  @rows OUT SELECT @rows; -- Contains total rows count


EXEC sp_cursorfetch 
  @handle, 
  16,     -- Absolute row index
  @firstRecordNum, -- Fetch from row
  @maxRecordCount  -- Rows count to fetch

EXEC sp_cursorclose @handle;

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


/*
*/