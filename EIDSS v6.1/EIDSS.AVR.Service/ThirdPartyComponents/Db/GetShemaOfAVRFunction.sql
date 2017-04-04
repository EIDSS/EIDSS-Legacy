/*
SELECT *
FROM sys.objects
WHERE [name] like 'fn_AVR%'
OR [name] like 'fnM%'
*/
--fnM0BSearchQuery__8957000086489570000864


select  	o.name, o.object_id, count(distinct c.column_id ) as count
from sys.columns  c
inner join sys.objects o
on c.object_id = o.object_id
group by o.name, o.object_id
having o.[name] like 'fn_AVR%'
OR o.[name] like 'fnM%'
OR o.[name] like 'fn0%'





select  '[' + c.name + '] [' + 	t.name + ']' +
		case 
			when (CAST(t.name as nvarchar(128)) like '%char%') 
				then '(' + CAST(c.max_length as nvarchar(16))+')'
			else ''
		end +
		' NULL, '
		
		as xxx,
		c.name + ',' as yyy,
		* 
from sys.columns c
inner join sys.types t
on c.system_type_id = t.system_type_id
and c.user_type_id = t.user_type_id
where object_id = 2097311873
--where object_id = 1316017011



--select * from sys.types where system_type_id = 231

