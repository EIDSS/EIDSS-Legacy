namespace CustomActions.Utils
{
  using System;
  using Microsoft.Deployment.WindowsInstaller;


  public class CryptorWrapper
  {
    private readonly Session m_session;

    public CryptorWrapper(Session session)
    {
      m_session = session;
    }

    public string ResultUser { get; private set; }
    public string ResultPassword { get; private set; }

    public static string GetDomain(string user)
    {
      return user.Split(new[] { '\\' }, 2, StringSplitOptions.RemoveEmptyEntries)[0];
    }

    public static string GetUser(string user)
    {
      return user.Split(new[] { '\\' }, 2, StringSplitOptions.RemoveEmptyEntries)[1];
    }

    public void EncryptAccountDetails(string userToEncryptProperty, string passwordToEncryptProperty,
      string domainProperty = null)
    {
      var userToEncrypt = m_session[userToEncryptProperty];
      var passwordToEncrypt = m_session[passwordToEncryptProperty];

      if (!string.IsNullOrEmpty(domainProperty))
      {
        var domain = m_session[domainProperty];
        userToEncrypt = domain + @"\" + userToEncrypt;
      }

      if (string.IsNullOrEmpty(userToEncrypt))
      {
        m_session.Log("Nothing to encrypt! Put user name to property \"{0}\"", userToEncryptProperty);
      }

      if (string.IsNullOrEmpty(passwordToEncrypt))
      {
        m_session.Log("Nothing to encrypt! Put password to property \"{0}\"", passwordToEncryptProperty);
      }

      if (!string.IsNullOrEmpty(userToEncrypt) && !string.IsNullOrEmpty(passwordToEncrypt))
      {
        ResultUser = bv.common.Core.Cryptor.Encrypt(userToEncrypt);
        ResultPassword = bv.common.Core.Cryptor.Encrypt(passwordToEncrypt, userToEncrypt);
      }
    }

    public void DecryptAccountDetails(Session session, string userToDecryptProperty, string passwordToDecryptProperty)
    {
      var userToDecrypt = session[userToDecryptProperty];
      var passwordToDecrypt = session[passwordToDecryptProperty];

      if (string.IsNullOrEmpty(userToDecrypt))
      {
        session.Log("Nothing to decrypt! Put encrypted user name to property \"{0}\"", userToDecryptProperty);
      }

      if (string.IsNullOrEmpty(userToDecrypt))
      {
        session.Log("Nothing to decrypt! Put encrypted password to property \"{0}\"", passwordToDecryptProperty);
      }

      if (!string.IsNullOrEmpty(userToDecrypt) && !string.IsNullOrEmpty(passwordToDecrypt))
      {
        var user = bv.common.Core.Cryptor.Decrypt(userToDecrypt);
        ResultUser = user;
        if (!string.IsNullOrEmpty(user))
        {
          ResultPassword = bv.common.Core.Cryptor.Decrypt(passwordToDecrypt, user);
        }
      }
    }
  }
}