namespace CustomActions
{
  using System;
  using System.DirectoryServices.AccountManagement;
  using Microsoft.Deployment.WindowsInstaller;


  public static class UserValidator
  {
    [CustomAction]
    public static ActionResult ValidateUser(Session session)
    {
      session.Log("Begin ValidateUser");

      var domain = session[Properties.ServiceAccountDomain];
      if (string.IsNullOrEmpty(domain))
      {
        domain = session[Properties.ServiceAccountDomain] = Environment.MachineName;
      }

      using (var validator = GetValidator(domain))
      {
        var account = session[Properties.ServiceAccountName];
        var password = session[Properties.ServiceAccountPassword];
        session[Properties.ServiceAccountValid] = validator.Validate(account, password) ? "1" : "0";
        session[Properties.InvalidAccountText] = FormatBadUserMessage(session, validator.ValidationResult);
      }

      return ActionResult.Success;
    }


    private static Validator GetValidator(string domain)
    {
      if (LocalValidator.IsUserLocal(domain))
      {
        return new LocalValidator();
      }
      return new DomainValidator(domain);
    }

    private static string FormatBadUserMessage(Session session, ValidationResult validationResult)
    {
      switch (validationResult)
      {
        case ValidationResult.BadDomain:
          return session.Format(session[Properties.BadDomain]);
        case ValidationResult.EmptyLogin:
          return session.Format(session[Properties.EmptyLogin]);
        case ValidationResult.NonExistent:
          return session.Format(session[Properties.NonExistentAccount]);
        case ValidationResult.BadLoginPassword:
          return session.Format(session[Properties.InvalidAccount]);
        case ValidationResult.CheckAccountSettings:
          return session.Format(session[Properties.AccountIsDisabled]);
      }
      return string.Empty;
    }

    #region Nested type: DomainValidator

    private class DomainValidator : Validator
    {
      internal DomainValidator(string domain)
      {
        try
        {
          m_context = new PrincipalContext(ContextType.Domain, domain);
        }
        catch (PrincipalServerDownException)
        {
          m_validationResult = ValidationResult.BadDomain;
        }
      }

      internal override bool Validate(string user, string password)
      {
        if (m_context == null)
        {
          return false;
        }

        if (string.IsNullOrEmpty(user))
        {
          m_validationResult = ValidationResult.EmptyLogin;
          return false;
        }

        using (var foundUser = UserPrincipal.FindByIdentity(m_context, IdentityType.SamAccountName, user))
        {
          if (foundUser == null)
          {
            m_validationResult = ValidationResult.NonExistent;
            return false;
          }
          if (!m_context.ValidateCredentials(user, password))
          {
            m_validationResult = ValidationResult.BadLoginPassword;
            return false;
          }
          m_validationResult = ValidationResult.Valid;
          return true;
        }
      }
    }

    #endregion

    #region Nested type: LocalValidator

    private class LocalValidator : Validator
    {
      internal LocalValidator()
      {
        m_context = new PrincipalContext(ContextType.Machine);
      }

      internal static bool IsUserLocal(string machine)
      {
        return Environment.MachineName.Equals(machine, StringComparison.OrdinalIgnoreCase);
      }

      internal override bool Validate(string user, string password)
      {
        if (m_context == null)
        {
          return false;
        }

        if (string.IsNullOrEmpty(user))
        {
          m_validationResult = ValidationResult.EmptyLogin;
          return false;
        }

        using (var foundUser = UserPrincipal.FindByIdentity(m_context, IdentityType.SamAccountName, user))
        {
          if (foundUser != null)
          {
            return ValidateCredentials(user, password);
          }
          m_validationResult = ValidationResult.NonExistent;
          return true;
        }
      }

      private bool ValidateCredentials(string user, string password)
      {
        try
        {
          if (!m_context.ValidateCredentials(user, password))
          {
            m_validationResult = ValidationResult.BadLoginPassword;
            return false;
          }
        }
        catch (PrincipalOperationException)
        {
          m_validationResult = ValidationResult.CheckAccountSettings;
          return false;
        }
        m_validationResult = ValidationResult.Valid;
        return true;
      }
    }

    #endregion

    #region Nested type: ValidationResult

    private enum ValidationResult
    {
      NonExistent,
      BadDomain,
      EmptyLogin,
      BadLoginPassword,
      Valid,
      CheckAccountSettings
    }

    #endregion

    #region Nested type: Validator

    private abstract class Validator : IDisposable
    {
      protected PrincipalContext m_context;
      protected ValidationResult m_validationResult;

      internal ValidationResult ValidationResult
      {
        get { return m_validationResult; }
      }

      #region IDisposable Members

      public void Dispose()
      {
        if (m_context != null)
        {
          m_context.Dispose();
          m_context = null;
        }
      }

      #endregion

      internal abstract bool Validate(string user, string password);
    }

    #endregion
  }
}