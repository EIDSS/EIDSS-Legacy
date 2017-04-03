--##SUMMARY This procedure create triggers for data audit on any (child or base) table with standart fields name.

--##REMARKS Author: Zhdanova A.
--##REMARKS
--##REMARKS Update date: 27.01.2010

--##RETURNS Don't use


/*
--Example of a call of procedure:

exec dbo.[spSpecCreateTriggers2] 'dbo.tlbHuman', 2

exec dbo.[spSpecCreateTriggers] 'trtBaseReference', 2

exec dbo.[spSpecCreateTriggers2] 'dbo.tlbHumanCase', 2

*/

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSpecCreateTriggers2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spSpecCreateTriggers2]
GO

CREATE       proc [dbo].[spSpecCreateTriggers2](
	@TableName varchar(200),--##PARAM @TableName - input: name of table 
	@Print int = 0	--##PARAM @Print - input: ( 0 - create triggers, 1 - print triggers script, 2 - create & print)
	)
AS


EXEC dbo.spsysUpdateTableAndColumnListForAudit @TableName



declare @bloc varchar(2000), @SQL varchar(8000),@SQL2 varchar(8000),@SQL3 varchar(8000),@SQL4 varchar(8000),@SQL5 varchar(8000),@SQL6 varchar(8000)
DECLARE @SQL7 varchar(8000),@SQL8 varchar(8000),@SQL9 varchar(8000),@SQL10 varchar(8000),@SQL11 varchar(8000)
declare @IDColumnName varchar(200),@IDColumnName2 varchar(200), @Column varchar(200)
DECLARE @TableN BIGINT, @IDColumnNameN BIGINT,@IDColumnName2N BIGINT, @ColumnN BIGINT
declare @BaseTableName varchar(200)
DECLARE @BaseTableN BIGINT
declare @IDBaseColumnName varchar(200)
declare @TriggerName varchar(200)
declare @Site bit, @Date bit, @Status bit

set @bloc = ''
set @SQL = ''
set @SQL2 = ''
set @SQL3 = ''
set @SQL4 = ''
set @SQL5 = ''
set @SQL6 = ''
set @SQL7 = ''
set @SQL8 = ''
set @SQL9 = ''
set @SQL10 = ''
set @SQL11 = ''

--- table name
if left(@TableName,4) = 'dbo.'
set @TableName = substring(@TableName,5,len(@TableName))

SELECT @tableN = [idfTable]
FROM [tauTable] WHERE [strName] = @TableName


--- primary key
set @IDColumnName2 = NULL
set @IDColumnName2N = NULL

declare _T cursor fast_forward for
select a.COLUMN_NAME
from INFORMATION_SCHEMA.KEY_COLUMN_USAGE as a
inner join INFORMATION_SCHEMA.TABLE_CONSTRAINTS as b
on a.CONSTRAINT_NAME = b.CONSTRAINT_NAME
where b.CONSTRAINT_TYPE = 'PRIMARY KEY'
and a.TABLE_NAME = @TableName
open _T

fetch next from _T into @IDColumnName

SELECT @IDColumnNameN = [idfColumn]
FROM [tauColumn] WHERE [strName] = @IDColumnName AND [idfTable] = @tableN 

if @@FETCH_Status=0
	BEGIN 
	fetch next from _T into @IDColumnName2
	SELECT @IDColumnName2N = [idfColumn]
	FROM [tauColumn] WHERE [strName] = @IDColumnName2 AND [idfTable] = @tableN 
	END 

close _T
deallocate _T

--- special columns
set @site = 0
set @date = 0
set @Status = 0
if exists(select *
from INFORMATION_SCHEMA.COLUMNS as a
where a.TABLE_NAME = @TableName and a.COLUMN_NAME  = 'idfsSite')
	set @site = 1

if exists(select *
from INFORMATION_SCHEMA.COLUMNS as a
where a.TABLE_NAME = @TableName and a.COLUMN_NAME  = 'datEnteringDate')
	set @Date = 1

if exists(select *
from INFORMATION_SCHEMA.COLUMNS as a
where a.TABLE_NAME = @TableName and a.COLUMN_NAME  = 'intRowStatus')
	set @status = 1

------------------------------------------------------------------
--- base table
declare @TName varchar(200), @CName varchar(200), @RowStatus varchar(200)
declare @p int

set @BaseTableName = @TableName
set @IDBaseColumnName = @IDColumnName

IF NOT  @status = 1
begin
	set @p = 1
	while @p = 1
		begin
		select	@Tname = cc.name, @CName = c.name, @RowStatus = d.COLUMN_NAME
		from INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS as a
		inner join INFORMATION_SCHEMA.KEY_COLUMN_USAGE as a1 on a.CONSTRAINT_NAME = a1.CONSTRAINT_NAME
		left join INFORMATION_SCHEMA.KEY_COLUMN_USAGE as b1 on a.UNIQUE_CONSTRAINT_NAME = b1.CONSTRAINT_NAME
		left join sys.indexes as c1 on a.UNIQUE_CONSTRAINT_NAME = c1.name
		left join sys.index_columns as c2 on c2.object_id =c1.object_id and c2.index_id = c1.index_id
		left join sys.columns as c on c.object_id = c2.object_id and c.column_id = c2.column_id
		left join sys.objects as cc on c.object_id = cc.object_id
		left join INFORMATION_SCHEMA.COLUMNS as d on cc.name = d.TABLE_NAME and d.COLUMN_NAME = 'intRowStatus'
		where  a1.TABLE_NAME = @BaseTableName and a1.COLUMN_NAME=@IDBaseColumnName
			
		if @@rowcount = 0 set @p = 0
		
		if @Tname is not null and @Cname is not null
			begin
			set @BaseTableName = @Tname
			set @IDBaseColumnName = @CName
			end
		else
			set @p = 0
		
		if @RowStatus is not null set @p = 0
		
--		PRINT @Tname

		end

	if @print >=1 print '---- Base Table: ' + @BaseTableName
	if @print >=1 print '---- Base ID Column: ' + @IDBaseColumnName 

	if @Rowstatus is null
	begin
		set @BaseTableName = @TableName
		set @IDBaseColumnName = @IDColumnName
	end

	SELECT @BaseTableN = [idfTable]
	FROM [tauTable] WHERE [strName] = @BaseTableName
end			

------------------------------------------------------------------
------- INSERT ---------------------------------------------------

set @TriggerName = 'tr'+ @TableName + 'Insert'

set @SQL = '
if exists (select * from dbo.sysobjects where id = object_id(N''[dbo].[' + @TriggerName + ']'') and OBJECTPROPERTY(id, N''IsTrigger'') = 1)
drop trigger [dbo].[' + @TriggerName + ']'

if @print >= 1 print @SQL
if @print >= 1 print 'GO'
if (@print >= 2 or @print = 0) exec(@SQL)

set @SQL = '
create  trigger ' + @TriggerName + ' on dbo.'+ @TableName + '	
for insert
NOT FOR REPLICATION
as
if((TRIGGER_NESTLEVEL()<2) AND (dbo.fnTriggersWork ()=1))
begin
	'
if (@Site = 1 or @date = 1 or @Status = 1)
begin
	set @sql = @sql + '
	update a
	set ' 
	if @site = 1 set @SQL = @SQL + 'idfsSite = isnull(a.idfsSite, dbo.fnSiteID())'
	if @date = 1
		begin
		if @site = 1 set @SQL = @SQL + ','
		set @SQL = @SQL + ' datEnteringDate = getdate()'
		end
	if @status = 1
		begin
		if @site = 1 or @date = 1 set @SQL = @SQL + ','
		set @SQL = @SQL + ' intRowStatus = 0'
		end
	set @sql = @sql +
'
	from dbo.'+ @TableName + ' as a inner join inserted as b on a.' + @IDColumnName + ' = b.' + @IDColumnName 
	if @IDColumnName2 is not null
		set @sql = @sql + '
	and a.' + @IDColumnName2 + ' = b.' + @IDColumnName2
end

set @sql = @sql + '

	declare @event bigint
	exec [dbo].[spGetDataAuditEvent] @event output
'

	set @sql = @sql + '
	insert into dbo.tstNewID(idfTable, idfKey1, idfKey2)
	select '+ cast(@TableN as varchar(50)) +',
		a.'+@IDColumnName + case when NOT (@IDColumnName2 is NULL) then ', a.'+@IDColumnName2 + ' ' ELSE ', null' end +'
	from inserted as a 
	'
		
	set @sql = @sql + '
	INSERT INTO dbo.tauDataAuditDetailCreate(idfDataAuditDetailCreate, idfDataAuditEvent, idfObjectTable, 
		idfObject, idfObjectDetail)
	select distinct GetID.NewID,@event,'+ CAST(@Tablen AS VARCHAR(50)) +',
		a.'+@IDColumnName +','+ case when @IDColumnName2 is null then 'null' else ' a.'+@IDColumnName2 end + '
	from inserted as a'

	set @sql = @sql + '
	inner join dbo.tstNewID as GetID
		on GetID.idfTable =  '+ cast(@TableN as varchar(50)) +' AND
		GetID.idfKey1 = a.'+@IDColumnName + ' ' + case when @IDColumnName2 is NOT null then ' AND GetID.idfKey2 = a.'+@IDColumnName2 + ' ' ELSE '' end + '
'
		set @sql = @sql + '		
	delete a
	from dbo.tstNewID as a
	inner join dbo.tauDataAuditDetailCreate as b
		on a.NewID = b.idfDataAuditDetailCreate
'

set @sql = @sql + '
end '

if @print >= 1 print @SQL
if @print >= 1 print 'GO'
if (@print >= 2 or @print = 0) exec(@SQL)

-------------------------------------------------------------------------------------------
------------------------------------------- DELETE ----------------------------------------
set @TriggerName = 'tr'+ @TableName + 'Delete'

set @SQL = '
if exists (select * from dbo.sysobjects where id = object_id(N''[dbo].[' + @TriggerName + ']'') and OBJECTPROPERTY(id, N''IsTrigger'') = 1)
drop trigger [dbo].[' + @TriggerName + ']'

if @print >= 1 print @SQL
if @print >= 1 print 'GO'
if (@print >= 2 or @print = 0) exec(@SQL)

--if @Status = 1 
	set @SQL = '
CREATE      trigger ' + @TriggerName + ' on dbo.'+ @TableName + '
INSTEAD OF  delete
NOT FOR REPLICATION
as

if((TRIGGER_NESTLEVEL()<2) AND (dbo.fnTriggersWork ()=1))
begin
'
--else
--	set @SQL = '
--CREATE      trigger ' + @TriggerName + ' on dbo.'+ @TableName + '
--FOR  delete
--NOT FOR REPLICATION
--as
--
--if (dbo.fnTriggersWork ()=1)
--begin
--'


if (@date = 1 or @Status = 1)
begin
	set @sql = @sql + '
	update a
	set ' 
	if @date = 1
		begin
		set @SQL = @SQL + ' datEnteringDate = getdate()'
		end
	if @status = 1
		begin
		if  @date = 1 set @SQL = @SQL + ','
		set @SQL = @SQL + ' intRowStatus = 1'
		end
	set @sql = @sql +
'
	from dbo.'+ @TableName + ' as a inner join deleted as b on a.' + @IDColumnName + ' = b.' + @IDColumnName 
	if @IDColumnName2 is not null
		set @sql = @sql + '
	and a.' + @IDColumnName2 + ' = b.' + @IDColumnName2
	 if @status = 1
		set @sql = @sql + '
	--where a.intRowStatus <> 1'
end

IF NOT @BaseTableName = @TableName
BEGIN 
----- Parent Status Update
set @sql = @sql + '
--- Parent Status Update
	update a
	set  intRowStatus = 1'
	set @sql = @sql +
'
	from dbo.'+ @BaseTableName + ' as a inner join deleted as b on a.' + @IDBaseColumnName + ' = b.' + @IDColumnName 
END 

set @sql = @sql + '
	declare @event bigint
	exec [dbo].[spGetDataAuditEvent] @event output

'
	set @sql = @sql + '
	insert into dbo.tstNewID(idfTable, idfKey1, idfKey2)
	select '+ cast(@TableN as varchar(50)) +',
		a.'+@IDColumnName + case when NOT (@IDColumnName2 is NULL) then ', a.'+@IDColumnName2 + ' ' ELSE ', null' end +'
	from deleted as a 
	'
		
	set @sql = @sql + '
	INSERT INTO dbo.tauDataAuditDetailDelete(idfDataAuditDetailDelete, idfDataAuditEvent, idfObjectTable, 
		idfObject, idfObjectDetail)
	select distinct GetID.NewID,@event,'+ CAST(@Tablen AS VARCHAR(50)) +',
		a.'+@IDColumnName +','+ case when @IDColumnName2 is null then 'null' else ' a.'+@IDColumnName2 end + '
	from deleted as a'

	set @sql = @sql + '
	inner join dbo.tstNewID as GetID
		on GetID.idfTable =  '+ cast(@TableN as varchar(50)) +' AND
		GetID.idfKey1 = a.'+@IDColumnName + ' ' + case when @IDColumnName2 is NOT null then ' AND GetID.idfKey2 = a.'+@IDColumnName2 + ' ' ELSE '' end + '
'
		set @sql = @sql + '		
	delete a
	from dbo.tstNewID as a
	inner join dbo.tauDataAuditDetailDelete as b
		on a.NewID = b.idfDataAuditDetailDelete
'

set @sql = @sql + '
end'

--if @Status = 1
--	begin 
	set @sql = @sql + '
else
delete a
from dbo.'+ @TableName + ' as a inner join deleted as b on a.' + @IDColumnName + ' = b.' + @IDColumnName + '
'
	if @IDColumnName2 is not null
		set @sql = @sql + '
and a.' + @IDColumnName2 + ' = b.' + @IDColumnName2
--	end

if @print >= 1 print @SQL
if @print >= 1 print 'GO'
if (@print >= 2 or @print = 0) exec(@SQL)

-----------------------------------------------------------------------------------------
------------- Update --------------------------------------------------------------------

set @bloc = ''
set @SQL = ''
set @SQL2 = ''
set @SQL3 = ''
set @SQL4 = ''
set @SQL5 = ''
set @SQL6 = ''
set @SQL7 = ''
set @SQL8 = ''
set @SQL9 = ''
set @SQL10 = ''
set @SQL11 = ''

set @TriggerName = 'tr'+ @TableName + 'Update'

set @SQL = '
if exists (select * from dbo.sysobjects where id = object_id(N''[dbo].[' + @TriggerName + ']'') and OBJECTPROPERTY(id, N''IsTrigger'') = 1)
drop trigger [dbo].[' + @TriggerName + ']'

if @print >= 1 print @SQL
if @print >= 1 print 'GO'
if (@print >= 2 or @print = 0) exec(@SQL)


set @SQL = '
CREATE        trigger ' + @TriggerName + ' on dbo.'+ @TableName + '
FOR UPDATE
NOT FOR REPLICATION
as
if((TRIGGER_NESTLEVEL()<2) AND (dbo.fnTriggersWork ()=1))
begin
	if  (UPDATE(' + @IDColumnName + ') 
		and exists (select * from deleted as a 
			left join inserted as b on a.'+ @IDColumnName +' = b.'+ @IDColumnName +' where b.'+ @IDColumnName +' is null))'
if @IDColumnName2 is not null set @sql = @sql + ' 
		or (UPDATE(' + @IDColumnName2 + ')
		and exists (select * from deleted as a 
			left join inserted as b on a.'+ @IDColumnName +' = b.'+ @IDColumnName +' 
			and a.'+ @IDColumnName2 +' = b.'+@IDColumnName2+' where b.'+@IDColumnName+' is null))'

set @sql = @sql + '
		begin
		raiserror(''Update Trigger: Illegal data changing error!'',16,1)
		ROLLBACK TRANSACTION
		end
	else
		begin' 

if ( @date = 1)
begin
	set @sql = @sql + '
		update a
		set ' 
	set @SQL = @SQL + ' datEnteringDate = getdate()'
	set @sql = @sql +
'
		from dbo.'+ @TableName + ' as a inner join inserted as b on a.' + @IDColumnName + ' = b.' + @IDColumnName 
	if @IDColumnName2 is not null
		set @sql = @sql + '
		and a.' + @IDColumnName2 + ' = b.' + @IDColumnName2
end

set @sql = @sql + '
		declare @event bigint
		exec [dbo].[spGetDataAuditEvent] @event output

'

set @SQL2 = ''
declare _C3 cursor fast_forward for
select a.COLUMN_NAME, b.[idfColumn]
from INFORMATION_SCHEMA.COLUMNS as a
INNER JOIN [tauColumn] AS b
	ON a.COLUMN_NAME = b.[strName]
INNER JOIN [tauTable] AS c
	ON b.[idfTable] = c.[idfTable]
	AND a.TABLE_NAME = c.[strName]
where a.TABLE_NAME = @Tablename
order by ORDINAL_POSITION

open _C3
fetch next from _C3 into @column, @columnN
while @@fetch_status = 0
	BEGIN
--	PRINT @column
	set @Bloc = '
		insert into dbo.tstNewID(idfTable, idfKey1, idfKey2)
		select '+ cast(@TableN as varchar(50)) +',
			a.'+@IDColumnName + case when NOT (@IDColumnName2 is NULL) then ', a.'+@IDColumnName2 + ' ' ELSE ', null' end +'
		from inserted as a full join deleted as b on a.' + @IDColumnName + ' = b.' + @IDColumnName 
	
		if @IDColumnName2 is not null
			set @Bloc = @Bloc + '
		and a.' + @IDColumnName2 + ' = b.' + @IDColumnName2

		set @Bloc = @Bloc + '
		where (a.'+@column +' <> b.'+@column +') 
			or(a.'+@column +' is not null and b.'+@column +' is null)
			or(a.'+@column +' is null and b.'+@column +' is not null)
'
		set @Bloc = @Bloc + '
		insert into dbo.tauDataAuditDetailUpdate(
			idfDataAuditDetailUpdate, idfDataAuditEvent, idfObjectTable, idfColumn, 
			idfObject, idfObjectDetail, 
			strOldValue, strNewValue)
		select GetID.NewID,@event,'+cast(@TableN as varchar(50)) +', '+cast(@columnN as varchar(50)) +',
			a.'+@IDColumnName +','+ case when @IDColumnName2 is null then 'null' else 'a.'+@IDColumnName2 end + ',
			b.'+@column +',a.'+@column +' 
		from inserted as a full join deleted as b on a.' + @IDColumnName + ' = b.' + @IDColumnName 

		if @IDColumnName2 is not null
			set @Bloc = @Bloc + '
		and a.' + @IDColumnName2 + ' = b.' + @IDColumnName2
	
		set @Bloc = @Bloc + '
		inner join dbo.tstNewID as GetID
			on GetID.idfTable =  '+ cast(@TableN as varchar(50)) +' AND
			GetID.idfKey1 = a.'+@IDColumnName + ' ' + case when @IDColumnName2 is NOT null then ' AND GetID.idfKey2 = a.'+@IDColumnName2 + ' ' ELSE '' end + '
		where (a.'+@column +' <> b.'+@column +') 
			or(a.'+@column +' is not null and b.'+@column +' is null)
			or(a.'+@column +' is null and b.'+@column +' is not null)
'
		set @Bloc = @Bloc + '		
		delete a
		from dbo.tstNewID as a
		inner join dbo.tauDataAuditDetailUpdate as b
		on a.NewID = b.idfDataAuditDetailUpdate
'

	if len(@sql)<6000 set @sql = @sql + @bloc
	else if len(@sql2)<6000 set @sql2 = @sql2 + @bloc
		else if len(@sql3)<6000 set @sql3 = @sql3 + @bloc
			else if len(@sql4)<6000 set @sql4 = @sql4 + @bloc
				else if len(@sql5)<6000 set @sql5 = @sql5 + @bloc
					else if len(@sql6)<6000 set @sql6 = @sql6 + @bloc
					else if len(@sql7)<6000 set @sql7 = @sql7 + @bloc
					else if len(@sql8)<6000 set @sql8 = @sql8 + @bloc
					else if len(@sql9)<6000 set @sql9 = @sql9 + @bloc
					else if len(@sql10)<6000 set @sql10 = @sql10 + @bloc
					else if len(@sql11)<6000 set @sql11 = @sql11 + @bloc
						else raiserror('Too long string during update trigger creation!',16,1)

	fetch next from _C3 into @column, @columnN
	end
close _C3
deallocate _C3

set @sql10 = @sql10 + '
		end
end
'

if @print >= 1 
	begin
	print @SQL
	print @SQL2
	print @SQL3
	print @SQL4
	print @SQL5
	print @SQL6
	print @SQL7
	print @SQL8
	print @SQL9
	print @SQL10
	PRINT @sql11
	print 'GO'
	end
if (@print >= 2 or @print = 0) exec(@SQL + @SQL2 + @SQL3 + @SQL4 + @SQL5 + @SQL6 + @SQL7 + @SQL8 + @SQL9 + @SQL10 + @SQL11)


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

