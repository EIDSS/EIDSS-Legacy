namespace CustomActions.Utils
{
  using System;
  using System.Collections.Generic;
  using System.Globalization;
  using System.Linq;
  using Microsoft.Deployment.WindowsInstaller;


  public sealed class MsiDatabaseWrapper
  {
    private readonly Session m_session;

    public MsiDatabaseWrapper(Session session)
    {
      m_session = session;
    }

    public void InsertRecord(string tableName, object[] objects)
    {
      var db = m_session.Database;
      var table = db.Tables[tableName];
      if (null == table)
      {
        return;
      }

      View view = null;
      try
      {
        view = db.OpenView(table.SqlInsertString + " TEMPORARY");
        //view = db.OpenView(table.SqlInsertString);
        InsertRecord(view, objects);
      }
      catch
      {
      }
      if (view != null)
      {
        view.Close();
      }
    }

    private static void InsertRecord(View view, object[] objects)
    {
      using (var record = new Record(objects))
      {
        view.Execute(record);
        //view.Modify(ViewModifyMode.InsertTemporary, record);
      }
    }

    public void DeleteRecord(string tableName, Field searchField)
    {
      var db = m_session.Database;
      var table = db.Tables[tableName];
      if (null == table)
      {
        return;
      }

      var sqlDeleteString = String.Format(
        CultureInfo.InvariantCulture,
        "Delete from `{0}` where `{1}`='{2}'",
        table,
        searchField.Name,
        searchField.Value);

      View view = null;
      try
      {
        view = db.OpenView(sqlDeleteString);
        view.Execute();
      }
      catch
      {
      }
      if (view != null)
      {
        view.Close();
      }
    }

    public void FormatFields(string tableName, List<int> fields)
    {
      var db = m_session.Database;
      var table = db.Tables[tableName];
      if (null == table)
      {
        return;
      }

      View view = null;
      Record record = null;
      try
      {
        view = db.OpenView(table.SqlSelectString);
        view.Execute();
        for (var i = 0; i < db.CountRows(table.Name); ++i)
        {
          record = view.Fetch();

          var primaryColumn = db.Tables[tableName].PrimaryKeys[0];
          DeleteRecord(tableName, new Field(primaryColumn, record.GetString(primaryColumn)));

          FormatFields(record, fields);
          view.Modify(ViewModifyMode.InsertTemporary, record);
          record.Close();
        }
      }
      catch
      {
      }
      if (view != null)
      {
        view.Close();
      }
      if (record != null)
      {
        record.Close();
      }
    }

    private void FormatFields(Record record, IEnumerable<int> fields)
    {
      foreach (var field in fields)
      {
        FormatField(record, field);
      }
    }

    private void FormatField(Record record, int column)
    {
      var value = record.GetString(column);
      record.SetString(column, m_session.Format(value));
    }

    public void ReplaceRecord(string tableName, Field searchField, Field replaceField)
    {
      var db = m_session.Database;
      var table = db.Tables[tableName];
      if (null == table)
      {
        return;
      }

      View view = null;
      Record record = null;
      try
      {
        view = db.OpenView(table.SqlSelectString + string.Format(" WHERE `{0}` = '{1}'", searchField.Name, searchField.Value));
        view.Execute();

        for (var i = 0; i < view.Count(); ++i)
        {
          record = view.Fetch();

          var primaryColumn = db.Tables[tableName].PrimaryKeys[0];
          DeleteRecord(tableName, new Field(primaryColumn, record.GetString(primaryColumn)));

          record.SetString(replaceField.Name, replaceField.Value.ToString());
          view.Modify(ViewModifyMode.InsertTemporary, record);
          record.Close();
        }
      }
      catch
      {
      }
      if (view != null)
      {
        view.Close();
      }
      if (record != null)
      {
        record.Close();
      }
    }

    public sealed class Field
    {
      private readonly string m_name;
      private readonly object m_value;
      public string Name { get { return m_name; } }
      public object Value { get { return m_value; } }

      public Field(string name, object value)
      {
        m_name = name ?? string.Empty;
        m_value = value ?? string.Empty;
      }
    }
  }
}