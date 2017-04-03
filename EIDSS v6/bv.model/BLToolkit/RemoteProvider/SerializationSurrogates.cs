using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace bv.model.BLToolkit.RemoteProvider
{
    class SqlCommandSerializer
    {
        public static byte[] ToByteArray(SqlCommand cmd)
        {
            /*
            var ss = new SurrogateSelector();
            ss.AddSurrogate(typeof(SqlCommand), new StreamingContext(StreamingContextStates.All), new SqlCommandSurrogate());
            ss.AddSurrogate(typeof(SqlParameter), new StreamingContext(StreamingContextStates.All), new SqlParameterSurrogate());
            return Serializer.ToByteArray(cmd, ss);
            */
            using (MemoryStream stm = new MemoryStream())
            {
                BinaryWriter writer = new BinaryWriter(stm);
                writer.Write(cmd.CommandText);
                writer.Write(cmd.CommandType.ToString());
                writer.Write(cmd.Parameters.Count);
                for (int i = 0; i < cmd.Parameters.Count; i++)
                {
                    writer.Write(cmd.Parameters[i].ParameterName);
                    writer.Write(cmd.Parameters[i].DbType.ToString());
                    writer.Write(cmd.Parameters[i].Direction.ToString());
                    if (cmd.Parameters[i].Value == null)
                    {
                        writer.Write("(null)");
                        writer.Write("");
                    }
                    else
                    {
                        string type = cmd.Parameters[i].Value.GetType().Name;
                        writer.Write(type);
                        switch (type)
                        {
                            case "DBNull":
                                writer.Write("");
                                break;
                            case "Boolean":
                                writer.Write((bool)cmd.Parameters[i].Value);
                                break;
                            case "Double":
                                writer.Write((double)cmd.Parameters[i].Value);
                                break;
                            case "Decimal":
                                writer.Write((decimal)cmd.Parameters[i].Value);
                                break;
                            case "Int16":
                                writer.Write((Int16)cmd.Parameters[i].Value);
                                break;
                            case "Int32":
                                writer.Write((Int32)cmd.Parameters[i].Value);
                                break;
                            case "Int64":
                                writer.Write((Int64)cmd.Parameters[i].Value);
                                break;
                            case "String":
                                writer.Write(cmd.Parameters[i].Value.ToString());
                                break;
                            case "DateTime":
                                writer.Write(((DateTime)cmd.Parameters[i].Value).ToString("yyyy-MM-dd HH:mm:ss.fffffff"));
                                break;
                            case "Byte[]":
                                writer.Write(((byte[])cmd.Parameters[i].Value).Length);
                                writer.Write((byte[])cmd.Parameters[i].Value);
                                break;
                            default:
                                writer.Write(cmd.Parameters[i].Value.ToString());
                                break;
                        }
                    }
                    writer.Write(cmd.Parameters[i].Size);
                    writer.Write(cmd.Parameters[i].IsNullable);
                }
                stm.Position = 0L;
                using (BinaryReader mr = new BinaryReader(stm))
                {
                    return mr.ReadBytes((int)stm.Length);
                }
            }
        }
        public static SqlCommand FromByteArray(byte[] array)
        {
            /*
            var ss = new SurrogateSelector();
            ss.AddSurrogate(typeof(SqlCommand), new StreamingContext(StreamingContextStates.All), new SqlCommandSurrogate());
            ss.AddSurrogate(typeof(SqlParameter), new StreamingContext(StreamingContextStates.All), new SqlParameterSurrogate());
            return Serializer.FromByteArray<SqlCommand>(array, ss);
            */
            SqlCommand cmd = new SqlCommand();
            using (MemoryStream stm = new MemoryStream(array))
            {
                using (BinaryReader reader = new BinaryReader(stm))
                {
                    cmd.CommandText = reader.ReadString();
                    cmd.CommandType = SurrogateEnumSetter.Parse<CommandType>(reader.ReadString());
                    int parcnt = reader.ReadInt32();
                    for (int i = 0; i < parcnt; i++)
                    {
                        string name = reader.ReadString();
                        SqlParameter par = cmd.Parameters.AddWithValue(name, null);
                        par.DbType = SurrogateEnumSetter.Parse<DbType>(reader.ReadString());
                        par.Direction = SurrogateEnumSetter.Parse<ParameterDirection>(reader.ReadString());
                        string type = reader.ReadString();
                        switch(type)
                        {
                            case "DBNull":
                                reader.ReadString();
                                par.Value = DBNull.Value;
                                break;
                            case "Boolean":
                                par.Value = reader.ReadBoolean();
                                break;
                            case "Double":
                                par.Value = reader.ReadDouble();
                                break;
                            case "Decimal":
                                par.Value = reader.ReadDecimal();
                                break;
                            case "Int16":
                                par.Value = reader.ReadInt16();
                                break;
                            case "Int32":
                                par.Value = reader.ReadInt32();
                                break;
                            case "Int64":
                                par.Value = reader.ReadInt64();
                                break;
                            case "String":
                                par.Value = reader.ReadString();
                                break;
                            case "DateTime":
                                par.Value = DateTime.ParseExact(reader.ReadString(), "yyyy-MM-dd HH:mm:ss.fffffff", null);
                                break;
                            case "Byte[]":
                                par.Value = reader.ReadBytes(reader.ReadInt32());
                                break;
                            case "(null)":
                                reader.ReadString();
                                par.Value = null;
                                break;
                            default:
                                reader.ReadString();
                                par.Value = null;
                                break;
                        }
                        par.Size = reader.ReadInt32();
                        par.IsNullable = reader.ReadBoolean();
                    }
                }
            }
            return cmd;
        }
    }

    class SurrogateEnumSetter
    {
        public static T Parse<T>(SerializationInfo info, string name)
            where T : struct
        {
            T t;
            Enum.TryParse<T>(info.GetString(name), out t);
            return t;
        }

        public static T Parse<T>(string val)
            where T : struct
        {
            T t;
            Enum.TryParse<T>(val, out t);
            return t;
        }
    }

    class SqlCommandSurrogate : ISerializationSurrogate
    {
        #region ISerializationSurrogate Members

        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            SqlCommand comm = (SqlCommand)obj;
            info.AddValue("CommandText", comm.CommandText);
            info.AddValue("CommandType", comm.CommandType.ToString());
            info.AddValue("ParametersCount", comm.Parameters.Count);
            for (int i = 0; i < comm.Parameters.Count; i++)
            {
                info.AddValue("Parameter" + i, comm.Parameters[i]);
            }
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            SqlCommand comm = (SqlCommand)obj;
            comm.CommandText = info.GetString("CommandText");
            comm.CommandType = SurrogateEnumSetter.Parse<CommandType>(info, "CommandType");
            int parcount = info.GetInt32("ParametersCount");
            for (int i = 0; i < parcount; i++)
            {
                SqlParameter par = (SqlParameter)info.GetValue("Parameter" + i, typeof(SqlParameter));
                comm.Parameters.Add(par);
            }
            return null;
        }

        #endregion
    }

    class SqlParameterSurrogate : ISerializationSurrogate
    {
        #region ISerializationSurrogate Members

        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            SqlParameter par = (SqlParameter)obj;
            info.AddValue("ParameterName", par.ParameterName);
            info.AddValue("DbType", par.DbType.ToString());
            info.AddValue("Direction", par.Direction.ToString());
            info.AddValue("Value", par.Value);
            info.AddValue("Size", par.Size);
            info.AddValue("IsNullable", par.IsNullable);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            SqlParameter par = (SqlParameter)obj;
            par.ParameterName = info.GetString("ParameterName");
            par.DbType = SurrogateEnumSetter.Parse<DbType>(info, "DbType");
            par.Direction = SurrogateEnumSetter.Parse<ParameterDirection>(info, "Direction");
            par.Value = info.GetValue("Value", typeof(object));
            par.Size = info.GetInt32("Size");
            par.IsNullable = info.GetBoolean("IsNullable");
            return null;
        }

        #endregion
    }
}
