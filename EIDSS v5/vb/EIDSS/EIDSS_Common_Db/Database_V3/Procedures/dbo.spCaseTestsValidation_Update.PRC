SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCaseTestsValidation_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spCaseTestsValidation_Update]
GO

CREATE PROCEDURE [dbo].[spCaseTestsValidation_Update]
	@idfTestValidation bigint,
	@idfTesting bigint,
	@idfsDiagnosis bigint,
	
	@idfsInterpretedStatus bigint,
	@idfInterpretedByPerson bigint,
	@datInterpretationDate datetime,
	@strInterpretedComment nvarchar(200),
	
	@blnValidateStatus bit,
	@idfValidatedByPerson bigint,
	@datValidationDate datetime,
	@strValidateComment nvarchar(200)
AS
BEGIN
	SET NOCOUNT ON;

	update	tlbTestValidation
	set
			idfsDiagnosis=@idfsDiagnosis,
			idfsInterpretedStatus=@idfsInterpretedStatus,
			idfInterpretedByPerson=@idfInterpretedByPerson,
			datInterpretationDate=@datInterpretationDate,
			strInterpretedComment=@strInterpretedComment,
			
			blnValidateStatus=@blnValidateStatus,
			idfValidatedByPerson=@idfValidatedByPerson,
			datValidationDate=@datValidationDate,
			strValidateComment=@strValidateComment
	where	idfTestValidation=@idfTestValidation
	if @@rowcount=0
	begin
		insert into tlbTestValidation
					(
						idfTestValidation,
						idfTesting,
						idfsDiagnosis,
						idfsInterpretedStatus,
						idfInterpretedByPerson,
						datInterpretationDate,
						strInterpretedComment,
						
						blnValidateStatus,
						idfValidatedByPerson,
						datValidationDate,
						strValidateComment
					)
		values		(
						@idfTestValidation,
						@idfTesting,
						@idfsDiagnosis,
						@idfsInterpretedStatus,
						@idfInterpretedByPerson,
						@datInterpretationDate,
						@strInterpretedComment,
				
						@blnValidateStatus,
						@idfValidatedByPerson,
						@datValidationDate,
						@strValidateComment
					)
	end

/*
	UPDATE CaseTestValidation
	SET idfsDiagnosis=@idfsDiagnosis,
		intRuleStatus=@intInterpretedStatus,strRuleComment=@strInterpretedComment,
		intValidateStatus=@intValidatedStatus,strValidateComment=@strValidatedComment
	WHERE idfActivity=@idfActivity

	UPDATE Employee_For_Activity
	SET idfEmployee=@InterpretedBy,datBegin=@InterpretedDate
	WHERE idfActivity=@idfActivity AND idfsEmployee_for_Activity_Type='eatInterpretedBy'
	IF @@ROWCOUNT=0
	BEGIN
		INSERT INTO Employee_For_Activity(idfActivity,idfEmployee,datBegin,idfsEmployee_for_Activity_Type)
		VALUES (@idfActivity,@InterpretedBy,@InterpretedDate,'eatInterpretedBy')
	END

	IF NOT @ValidatedBy IS NULL
	BEGIN
		UPDATE Employee_For_Activity
		SET idfEmployee=@ValidatedBy,datBegin=@ValidatedDate
		WHERE idfActivity=@idfActivity AND idfsEmployee_for_Activity_Type='eatValidatedBy'
		IF @@ROWCOUNT=0
		BEGIN
			INSERT INTO Employee_For_Activity(idfActivity,idfEmployee,datBegin,idfsEmployee_for_Activity_Type)
			VALUES (@idfActivity,@ValidatedBy,@ValidatedDate,'eatValidatedBy')
		END
	END
*/
END
