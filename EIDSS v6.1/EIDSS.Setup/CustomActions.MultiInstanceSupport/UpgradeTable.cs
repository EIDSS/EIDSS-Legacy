using System;
using System.Text;
using Microsoft.Deployment.WindowsInstaller;

namespace CustomActions
{
  public static class UpgradeTable
  {
    private const string UpgradeTabple = "Upgrade";
    private const string UpgradeCodeProperty = "UpgradeCode";
    private const string ProductVersionProperty = "ProductVersion";

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0"), CustomAction]
    public static ActionResult FillUpgradeTable(Session session)
    {
      session.Log("Begin FillUpgradeTable");

      View view = null;
      try
      {
        view = session.Database.OpenView("select * from " + UpgradeTabple);
        view.Execute();

        AddRow_UpgradeDetected(session, view);
        //AddRow_DowngradeDetected(session, view);

        //NOTE: no need to call commit..

        LogUpgradeTable(session);
      }
      finally
      {
        if (view != null)
        {
          view.Close();
        }
      }
      session.Log("End FillUpgradeTable");
      return ActionResult.Success;
    }

    private static void AddRow_UpgradeDetected(Session session, View view)
    {
      var record = new Record(7);
      try
      {
        record.SetString((int)Fields.UpgradeCode, session[UpgradeCodeProperty]);
        record.SetString((int)Fields.VersionMin, "0");
        //record.SetString((int)Fields.VersionMax, session[ProductVersionProperty]);
        //record.SetInteger((int)Fields.Attributes, (int)(UpgradeAttributes.MigrateFeatures | UpgradeAttributes.VersionMaxInclusive));
        record.SetInteger((int)Fields.Attributes, (int)(UpgradeAttributes.MigrateFeatures | UpgradeAttributes.VersionMinInclusive));
        record.SetString((int)Fields.ActionProperty, "WIX_UPGRADE_DETECTED");
        view.Modify(ViewModifyMode.InsertTemporary, record);
      }
      finally
      {
        record.Close();
      }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
    private static void LogUpgradeTable(Session session)
    {
      View view = null;
      Record record = null;
      try
      {
        view = session.Database.OpenView("select * from " + UpgradeTabple);
        view.Execute();

        while (null != (record = view.Fetch()))
        {
          var messageBuilder = new StringBuilder();
          foreach (Fields field in Enum.GetValues(typeof(Fields)))
          {
            messageBuilder.AppendFormat("{0}: {1}\t", field, record[(int)field]);
          }
          session.Log(messageBuilder.ToString());

          record.Close();
        }
      }
      finally
      {
        if (null != record)
        {
          record.Close();
        }
        if (view != null)
        {
          view.Close();
        }
      }
    }

    private enum Fields
    {
      UpgradeCode = 1,
      VersionMin = 2,
      VersionMax = 3,
      Language = 4,
      Attributes = 5,
      Remove = 6,
      ActionProperty = 7
    }

  }
}
