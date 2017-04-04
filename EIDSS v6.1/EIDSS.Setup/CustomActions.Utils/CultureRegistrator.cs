namespace CustomActions.Utils
{
  using System;
  using bv.common.Core;
  using Microsoft.Deployment.WindowsInstaller;


  public static class CultureRegistrator
  {
    public static void TryRegisterCustomCultures(Session session)
    {
      try
      {
        CustomCultureHelper.UnRegisterAll();
        CustomCultureHelper.RegisterAll();
      }
      catch (Exception ex)
      {
        session.Log(string.IsNullOrEmpty(ex.InnerException.Message) ? ex.Message : ex.InnerException.Message);
      }
    }
  }
}