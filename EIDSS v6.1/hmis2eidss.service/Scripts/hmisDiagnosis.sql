
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_hmisDiagnosis_trtDiagnosis__idfsDiagnosis]') AND parent_object_id = OBJECT_ID(N'[dbo].[hmisDiagnosis]'))
ALTER TABLE [dbo].[hmisDiagnosis] DROP CONSTRAINT [FK_hmisDiagnosis_trtDiagnosis__idfsDiagnosis]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[hmisDiagnosis]') AND type in (N'U'))
DROP TABLE [dbo].[hmisDiagnosis]
GO

CREATE TABLE [dbo].[hmisDiagnosis] (
	[hmisDiagnosis] [bigint] IDENTITY(1,1) NOT NULL,
	[strHmisICD10Code] [nvarchar](36) NOT NULL,
	[strHmisDiagnosis] [nvarchar](36) NOT NULL,
	[idfsDiagnosis] [bigint] NOT NULL
CONSTRAINT [XPKhmisDiagnosis] PRIMARY KEY CLUSTERED 
(
	[hmisDiagnosis] ASC
)
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[hmisDiagnosis]  WITH NOCHECK ADD  CONSTRAINT [FK_hmisDiagnosis_trtDiagnosis__idfsDiagnosis] FOREIGN KEY([idfsDiagnosis])
REFERENCES [dbo].[trtDiagnosis] ([idfsDiagnosis])
NOT FOR REPLICATION 
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[hmisDiagnosis_SelectLookup]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[hmisDiagnosis_SelectLookup]
GO

CREATE procedure [dbo].[hmisDiagnosis_SelectLookup] (
	@LangID as nvarchar(50) --##PARAM @LangID - language ID
)
as
select	hmisDiagnosis.hmisDiagnosis
		, trtDiagnosis.idfsDiagnosis
		, hmisDiagnosis.strHmisICD10Code
		, hmisDiagnosis.strHmisDiagnosis
		, d.name
		, trtDiagnosis.strIDC10
		, trtDiagnosis.strOIECode 
		, d.intHACode
		, d.intRowStatus
from	dbo.fnReferenceRepair(@LangID, 19000019) d--rftDiagnosis
inner join trtDiagnosis
	on trtDiagnosis.idfsDiagnosis = d.idfsReference
inner join hmisDiagnosis
	on trtDiagnosis.idfsDiagnosis = hmisDiagnosis.idfsDiagnosis
GO

