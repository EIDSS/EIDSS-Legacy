namespace CustomActions.Utils
{
  using System;
  using System.Data.SqlClient;
  using System.Globalization;
  using Microsoft.Deployment.WindowsInstaller;


  public static class DbChecker
  {
    private const int DefaultTimeoutInSeconds = 3;

    public static bool TestConnection(
      Session session,
      string serverProperty,
      string databaseProperty,
      string userProperty,
      string passwordPropety)
    {
      var server = session[serverProperty];
      var database = session[databaseProperty];
      var user = session[userProperty];
      var password = session[passwordPropety];

      return TestConnection(server, database, user, password);
    }

    public static bool TestConnection(string server, string database, string user, string password)
    {
      if (!IsCorrect(server, database, user, password))
      {
        return false;
      }

      var connectionString = string.Format(
        CultureInfo.InvariantCulture,
        "Persist Security Info=False;User ID={0};Password={1};Initial Catalog={2};Data Source={3};Connection timeout = {4}",
        user,
        password,
        database,
        server,
        DefaultTimeoutInSeconds);

      SqlConnection connection = null;
      SqlCommand cmd = null;
      try
      {
        connection = new SqlConnection(connectionString);
        connection.Open();
        cmd = new SqlCommand("Select 0", connection) { CommandTimeout = DefaultTimeoutInSeconds };
        cmd.ExecuteNonQuery();
        connection.Close();
        connection.Dispose();
        cmd.Dispose();
        return true;
      }
      catch (Exception)
      {
        if (null != connection)
        {
          connection.Close();
          connection.Dispose();
        }
        if (null != cmd)
        {
          cmd.Dispose();
        }
        return false;
      }
    }

    public static bool IsUserAdmin(string server, string user, string password)
    {
      var connectionString = string.Format(
        CultureInfo.InvariantCulture,
        "Persist Security Info=False;User ID={0};Password={1};Data Source={2};Connection timeout = {3}",
        user,
        password,
        server,
        DefaultTimeoutInSeconds);

      SqlConnection connection = null;
      SqlCommand cmd = null;
      try
      {
        connection = new SqlConnection(connectionString);
        connection.Open();
        cmd = new SqlCommand(
          "SELECT p.name AS [Name] ,r.type_desc,r.is_disabled,r.create_date , r.modify_date,r.default_database_name" +
          "\r\n" +
          "FROM" + "\r\n" +
          "sys.server_principals r" + "\r\n" +
          "INNER JOIN sys.server_role_members m ON r.principal_id = m.role_principal_id" + "\r\n" +
          "INNER JOIN sys.server_principals p ON" + "\r\n" +
          "p.principal_id = m.member_principal_id" + "\r\n" +
          "WHERE r.type = 'R' and r.name = N'sysadmin'",
          connection)
        {
          CommandTimeout = DefaultTimeoutInSeconds
        };
        return IsUserAdmin(cmd, user);
      }
      catch (Exception)
      {
      }
      finally
      {
        if (null != connection)
        {
          connection.Close();
          connection.Dispose();
        }
        if (null != cmd)
        {
          cmd.Dispose();
        }
      }
      return false;
    }

    private static bool IsUserAdmin(SqlCommand command, string user)
    {
      var adminFound = false;
      using (var adminsReader = command.ExecuteReader())
      {
        while (adminsReader.Read())
        {
          adminFound |= ((string) adminsReader[0]).Equals(user, StringComparison.OrdinalIgnoreCase);
        }
      }
      return adminFound;
    }

    private static bool IsCorrect(string server, string database, string user, string password)
    {
      return !string.IsNullOrEmpty(server) &&
             !string.IsNullOrEmpty(database) &&
             !string.IsNullOrEmpty(user) &&
             !string.IsNullOrEmpty(password);
    }

    public static bool DoesUserExist(string server, string user, string password, string userIdToCheck)
    {
      var connectionString = string.Format(
        CultureInfo.InvariantCulture,
        "Persist Security Info=False;User ID={0};Password={1};Data Source={2};Connection timeout = {3}",
        user,
        password,
        server,
        DefaultTimeoutInSeconds);

      SqlConnection connection = null;
      SqlCommand cmd = null;
      try
      {
        connection = new SqlConnection(connectionString);
        connection.Open();
        cmd = new SqlCommand(
          "select loginname from master.dbo.syslogins where name = @loginName",
          connection)
        {
          CommandTimeout = DefaultTimeoutInSeconds
        };
        cmd.Parameters.AddWithValue("loginName", userIdToCheck);
        return null != cmd.ExecuteScalar();
      }
      catch (Exception)
      {
      }
      finally
      {
        if (null != connection)
        {
          connection.Close();
          connection.Dispose();
        }
        if (null != cmd)
        {
          cmd.Dispose();
        }
      }
      return false;
    }
  }
}