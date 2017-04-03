using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Text;
using System.Xml;

// System.Data.SQLite.dll must be referenced.
// http://sqlite.phxsoftware.com/
//
#if MONO
using Mono.Data.Sqlite;
#else
using System.Data.SQLite;
#endif

namespace BLToolkit.Data.DataProvider
{
    #if !MONO
	using Sql.SqlProvider;
    #endif

    /// <summary>
	/// Implements access to the Data Provider for SQLite.
	/// </summary>
	/// <remarks>
	/// See the <see cref="DbManager.AddDataProvider(DataProviderBase)"/> method to find an example.
	/// </remarks>
	/// <seealso cref="DbManager.AddDataProvider(DataProviderBase)">AddDataManager Method</seealso>
	public sealed class SQLiteDataProvider: DataProviderBase
	{
		/// <summary>
		/// Creates the database connection object.
		/// </summary>
		/// <remarks>
		/// See the <see cref="DbManager.AddDataProvider(DataProviderBase)"/> method to find an example.
		/// </remarks>
		/// <seealso cref="DbManager.AddDataProvider(DataProviderBase)">AddDataManager Method</seealso>
		/// <returns>The database connection object.</returns>
		public override IDbConnection CreateConnectionObject()
		{
            #if MONO
            return new SqliteConnection();
            #else
			return new SQLiteConnection();
            #endif
		}

		/// <summary>
		/// Creates the data adapter object.
		/// </summary>
		/// <remarks>
		/// See the <see cref="DbManager.AddDataProvider(DataProviderBase)"/> method to find an example.
		/// </remarks>
		/// <seealso cref="DbManager.AddDataProvider(DataProviderBase)">AddDataManager Method</seealso>
		/// <returns>A data adapter object.</returns>
		public override DbDataAdapter CreateDataAdapterObject()
		{
            #if MONO
			return new SqliteDataAdapter();
            #else
			return new SQLiteDataAdapter();
            #endif
		}

		/// <summary>
		/// Populates the specified IDbCommand object's Parameters collection with 
		/// parameter information for the stored procedure specified in the IDbCommand.
		/// </summary>
		/// <remarks>
		/// See the <see cref="DbManager.AddDataProvider(DataProviderBase)"/> method to find an example.
		/// </remarks>
		/// <seealso cref="DbManager.AddDataProvider(DataProviderBase)">AddDataManager Method</seealso>
		/// <param name="command">The IDbCommand referencing the stored procedure for which the parameter information is to be derived. The derived parameters will be populated into the Parameters of this command.</param>
		public override bool DeriveParameters(IDbCommand command)
		{
			// SQLiteCommandBuilder does not implement DeriveParameters.
			// This is not surprising, since SQLite has no support for stored procs.
			//
			return false;
		}

		public override object Convert(object value, ConvertType convertType)
		{
			switch (convertType)
			{
				case ConvertType.NameToQueryParameter:
				case ConvertType.NameToCommandParameter:
				case ConvertType.NameToSprocParameter:
					return "@" + value;

				case ConvertType.NameToQueryField:
				case ConvertType.NameToQueryFieldAlias:
				case ConvertType.NameToQueryTableAlias:
					{
						string name = value.ToString();

						if (name.Length > 0 && name[0] == '[')
							return value;
					}

					return "[" + value + "]";

				case ConvertType.NameToDatabase:
				case ConvertType.NameToOwner:
				case ConvertType.NameToQueryTable:
					{
						string name = value.ToString();

						if (name.Length > 0 && name[0] == '[')
							return value;

						if (name.IndexOf('.') > 0)
							value = string.Join("].[", name.Split('.'));
					}

					return "[" + value + "]";

				case ConvertType.SprocParameterToName:
					{
						string name = (string)value;
						return name.Length > 0 && name[0] == '@'? name.Substring(1): name;
					}

				case ConvertType.ExceptionToErrorNumber:
					{
                        #if MONO
						if (value is SqliteException)
							return ((SqliteException)value).ErrorCode;
                        #else
						if (value is SQLiteException)
							return ((SQLiteException)value).ErrorCode;
                        #endif
						break;
					}
			}

			return value;
		}

		public override void AttachParameter(IDbCommand command, IDbDataParameter parameter)
		{
			if (parameter.Direction == ParameterDirection.Input || parameter.Direction == ParameterDirection.InputOutput)
			{
				if (parameter.Value is XmlDocument)
				{
					parameter.Value = Encoding.UTF8.GetBytes(((XmlDocument) parameter.Value).InnerXml);
					parameter.DbType = DbType.Binary;
				}
			}

			base.AttachParameter(command, parameter);
		}

		/// <summary>
		/// Returns connection type.
		/// </summary>
		/// <remarks>
		/// See the <see cref="DbManager.AddDataProvider(DataProviderBase)"/> method to find an example.
		/// </remarks>
		/// <seealso cref="DbManager.AddDataProvider(DataProviderBase)">AddDataManager Method</seealso>
		/// <value>An instance of the <see cref="Type"/> class.</value>
		public override Type ConnectionType
		{
            #if MONO
            get { return typeof(SqliteConnection); }
            #else
			get { return typeof(SQLiteConnection); }
            #endif
		}

		/// <summary>
		/// Returns the data provider name.
		/// </summary>
		/// <remarks>
		/// See the <see cref="DbManager.AddDataProvider(DataProviderBase)"/> method to find an example.
		/// </remarks>
		/// <seealso cref="DbManager.AddDataProvider(DataProviderBase)">AddDataProvider Method</seealso>
		/// <value>Data provider name.</value>
		public override string Name
		{
			get { return DataProvider.ProviderName.SQLite; }
		}

#if FW3
		public override ISqlProvider CreateSqlProvider()
		{
			return new SQLiteSqlProvider(this);
		}
#endif

#if !MONO
		public class SQLiteMappingSchema : Mapping.MappingSchema
		{
			#region Convert

			public override XmlReader ConvertToXmlReader(object value)
			{
				if (value is byte[])
					value = Encoding.UTF8.GetString((byte[])value);

				return base.ConvertToXmlReader(value);
			}

			public override XmlDocument ConvertToXmlDocument(object value)
			{
				if (value is byte[])
					value = Encoding.UTF8.GetString((byte[])value);

				return base.ConvertToXmlDocument(value);
			}

			#endregion
		}
#endif

        /// <summary>
		/// SQLite built-in text processor is ANSI-only  Just override it.
		/// </summary>
#if MONO
		[SqliteFunction(Name = "lower", Arguments = 1, FuncType = FunctionType.Scalar)]
		internal class LoverFunction : SqliteFunction
#else
		[SQLiteFunction(Name = "lower", Arguments = 1, FuncType = FunctionType.Scalar)]
		internal class LoverFunction : SQLiteFunction
#endif
        {
			public override object Invoke(object[] args)
			{
				Debug.Assert(args != null && args.Length == 1);
				object arg = args[0];

				Debug.Assert(arg is string || arg is DBNull || arg is byte[]);
				return
					arg is string? ((string)arg).ToLower():
					arg is byte[]? Encoding.UTF8.GetString((byte[])arg).ToLower():
					arg;
			}
		}

		/// <summary>
		/// SQLite built-in text processor is ANSI-only  Just override it.
		/// </summary>
#if MONO
		[SqliteFunction(Name = "upper", Arguments = 1, FuncType = FunctionType.Scalar)]
		internal class UpperFunction : SqliteFunction
#else
		[SQLiteFunction(Name = "upper", Arguments = 1, FuncType = FunctionType.Scalar)]
		internal class UpperFunction : SQLiteFunction
#endif
        {
			public override object Invoke(object[] args)
			{
				Debug.Assert(args != null && args.Length == 1);
				object arg = args[0];

				Debug.Assert(arg is string || arg is DBNull || arg is byte[]);
				return
					arg is string? ((string)arg).ToUpper():
					arg is byte[]? Encoding.UTF8.GetString((byte[])arg).ToUpper():
					arg;
			}
		}
	}
}
