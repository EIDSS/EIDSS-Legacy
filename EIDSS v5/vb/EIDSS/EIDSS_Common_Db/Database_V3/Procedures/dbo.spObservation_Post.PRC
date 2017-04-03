SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spObservation_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spObservation_Post]
GO


--##SUMMARY Saves observation with its flexible form template.
--##REMARKS Author: Mirnaya O.
--##REMARKS Update date: 29.12.2009

--##RETURNS Doesn't use



/*
--Example of a call of procedure:
declare	@idfObservation		bigint
declare	@idfsFormTemplate	bigint
exec spObservation_Post
		@idfObservation,
		@idfsFormTemplate
*/

create	procedure	spObservation_Post
(	 @idfObservation	bigint	--##PARAM @idfObservation Observation Id
	,@idfsFormTemplate	bigint	--##PARAM @idfsFormTemplate Id of flexible form template (reference to ffFormTemplate)
)
as

-- Update the value of the @idfsFormTemplate parameter
if not exists	(
		select		*
		from		ffFormTemplate Template
		inner join	trtBaseReference TemplateBR
		on			TemplateBR.idfsBaseReference = Template.idfsFormTemplate
		where		Template.idfsFormTemplate = @idfsFormTemplate
					and Template.intRowStatus = 0
				)
begin
	set	@idfsFormTemplate = null
end

-- Post tlbObservation
if exists	(
	select	*
	from	tlbObservation
	where	idfObservation = @idfObservation
			)
begin
	update	tlbObservation
	set		idfsFormTemplate = @idfsFormTemplate
	where	idfObservation = @idfObservation
end
else begin
	insert into	tlbObservation
	(	idfObservation,
		idfsFormTemplate
	)
	values
	(	@idfObservation,
		@idfsFormTemplate
	)
end

	
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

