namespace CustomActions
{
  using System.Linq;
  using Microsoft.Deployment.WindowsInstaller;

  public static class InstallerStateManager
  {
    [CustomAction]
    public static ActionResult FindInstalledFeatures(Session session)
    {
      session.Log("Begin FindInstalledFeatures");

      var previousProductCode = session[Properties.RelatedProducts];
      if (!string.IsNullOrEmpty(previousProductCode))
      {
        FindProductInstalledFeatures(session, previousProductCode);
      }

      return ActionResult.Success;
    }

    private static void FindProductInstalledFeatures(Session session, string previousProductCode)
    {
      var previousProduct = ProductInstallation.GetProducts(
                                                            previousProductCode,
                                                            null,
                                                            UserContexts.Machine).FirstOrDefault();
      if (null == previousProduct)
      {
        return;
      }

      foreach (var feature in previousProduct.Features)
      {
        InitializeFeatureProperty(session, feature);
      }
    }

    private static void InitializeFeatureProperty(Session session, FeatureInstallation feature)
    {
      session["FEATURE." + feature.FeatureName.ToUpperInvariant()] =
        feature.State == InstallState.Local ? "1" : null;
    }
  }
}
