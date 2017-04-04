
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[hmisLog]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[hmisLog] (
		[hmisLog] [bigint] IDENTITY(1,1) NOT NULL,
		[datImport] [datetime] NOT NULL,
		[strHmisCaseId] [nvarchar](36) NOT NULL,
		[strHmisICD10Code] [nvarchar](36) NOT NULL,
		[strHmisPatientLastName] [nvarchar](128) NULL,
		[strHmisRegionId] [nvarchar](36) NULL,
		[strHmisRayonId] [nvarchar](36) NULL,
		[intStatus] [int] NOT NULL,
		[strComments] [nvarchar](256) NULL,
		[idfsHumanCase] [bigint] NULL
	CONSTRAINT [XPKhmisLog] PRIMARY KEY CLUSTERED 
	(
		[hmisLog] ASC
	)
	) ON [PRIMARY]

	ALTER TABLE [dbo].[hmisLog]  WITH NOCHECK ADD  CONSTRAINT [FK_hmisLog_tlbHumanCase__idfsHumanCase] FOREIGN KEY([idfsHumanCase])
	REFERENCES [dbo].[tlbHumanCase] ([idfHumanCase])
	NOT FOR REPLICATION 

	CREATE NONCLUSTERED INDEX [IX_hmisLog__strHmisCaseId_strHmisICD10Code] ON [dbo].[hmisLog] 
	(
		[strHmisCaseId] ASC,
		[strHmisICD10Code] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
END
GO



IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[hmisLog_SelectDetail]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[hmisLog_SelectDetail]
GO

CREATE PROCEDURE [dbo].[hmisLog_SelectDetail]
( 
	@strHmisCaseId AS varchar(36),
	@strHmisICD10Code AS varchar(36)
)
	
AS
SELECT 
	[hmisLog],
	[datImport],
	[strHmisCaseId],
	[strHmisICD10Code],
	[strHmisPatientLastName],
	[strHmisRegionId],
	[strHmisRayonId],
	[intStatus],
	[strComments],
	[idfsHumanCase]
FROM hmisLog
WHERE 
	strHmisCaseId = @strHmisCaseId
	and strHmisICD10Code = @strHmisICD10Code

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[hmisLog_Post]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[hmisLog_Post]
GO

CREATE PROCEDURE [dbo].[hmisLog_Post]
( 
		 @Action as int,  --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
		@hmisLog bigint,
		@datImport datetime,
		@strHmisCaseId nvarchar(36),
		@strHmisICD10Code nvarchar(36),
		@strHmisPatientLastName nvarchar(128),
		@strHmisRegionId nvarchar(36),
		@strHmisRayonId nvarchar(36),
		@intStatus int,
		@strComments nvarchar(256),
		@idfsHumanCase bigint
)
AS
IF @Action = 4 --insert
BEGIN
	INSERT INTO hmisLog
           (
			datImport,
			strHmisCaseId,
			strHmisICD10Code,
			strHmisPatientLastName,
			strHmisRegionId,
			strHmisRayonId,
			intStatus,
			strComments,
			idfsHumanCase
			)
     VALUES
           (
			@datImport,
			@strHmisCaseId,
			@strHmisICD10Code,
			@strHmisPatientLastName,
			@strHmisRegionId,
			@strHmisRayonId,
			@intStatus,
			@strComments,
			@idfsHumanCase
           )
END
ELSE IF @Action=16 --Update
BEGIN
	UPDATE hmisLog
	   SET 
			datImport = @datImport,
			strHmisCaseId = @strHmisCaseId,
			strHmisICD10Code = @strHmisICD10Code,
			strHmisPatientLastName = @strHmisPatientLastName,
			strHmisRegionId = @strHmisRegionId,
			strHmisRayonId = @strHmisRayonId,
			intStatus = @intStatus,
			strComments = @strComments,
			idfsHumanCase = @idfsHumanCase
	 WHERE 
		hmisLog=@hmisLog
END

GO

