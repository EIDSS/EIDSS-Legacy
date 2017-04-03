using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using BLToolkit.Data;
using bv.common.Configuration;
using bv.common.Core;
using eidss.model.AVR.ServiceData;

namespace eidss.model.WindowsService.Serialization
{
    public static class BinarySerializer
    {
        public static int MaxPacketRows
        {
            get { return Config.GetIntSetting("SelectTopMaxCount", 10000); }
        }

        #region Serialize from DB Command

        public static QueryTableModel SerializeFromCommand
            (DbManager command, long queryId, string lang, bool isArchive, int maxPacketRows = 0)
        {
            if (maxPacketRows <= 0)
            {
                maxPacketRows = MaxPacketRows;
            }

            var result = new QueryTableModel(queryId, lang) {UseArchivedData = isArchive};

            using (IDataReader reader = command.ExecuteReader())
            {
                if (reader == null)
                {
                    throw new CustomSerializationException(string.Format("Could not get DataReader from command {0}",
                        command.Command.CommandText));
                }
                DataTable schemaTable = reader.GetSchemaTable();

                Type[] types;
                result.Header = SerializeHeader(schemaTable, out types, isArchive);

                QueryTablePacketDTO packet = SerializeBodyPacket(reader, types, isArchive, maxPacketRows);
                while (packet.RowCount != 0)
                {
                    result.BodyPackets.Add(packet);
                    packet = SerializeBodyPacket(reader, types, isArchive, maxPacketRows);
                }
            }

            return result;
        }

        #endregion

        #region Serialize/Deserialize whole DataTable

        public static BaseTableDTO SerializeFromTable(DataTable table, int maxPacketRows = 0)
        {
            var result = new BaseTableDTO {TableName = table.TableName};
            Type[] types;

            DataTableReader reader = table.CreateDataReader();
            Func<int, BaseColumnModel> getColumnModel = i =>
            {
                DataColumn column = table.Columns[i];
                return new BaseColumnModel(column.ColumnName, column.Caption, column.DataType);
            };
            result.Header = SerializeHeader(reader.GetSchemaTable(), getColumnModel, out types);

            BaseTablePacketDTO packet = SerializeBodyPacket(reader, types, maxPacketRows);
            while (packet.RowCount != 0)
            {
                result.BodyPackets.Add(packet);
                packet = SerializeBodyPacket(reader, types, maxPacketRows);
            }
            return result;
        }

        public static DataTable DeserializeToTable(BaseTableDTO dto)
        {
            List<BaseColumnModel> deserializedHeader = DeserializeHeader(dto.Header);
            var result = new DataTable();
            result.BeginInit();
            result.TableName = dto.TableName;
            foreach (BaseColumnModel columnModel in deserializedHeader)
            {
                var column = new DataColumn(columnModel.Name, columnModel.Type) {Caption = columnModel.Caption};
                result.Columns.Add(column);
            }
            result.EndInit();

            result.BeginLoadData();
            Type[] types = deserializedHeader.Select(c => c.Type).ToArray();
            foreach (BaseTablePacketDTO packet in dto.BodyPackets)
            {
                object[,] deserializedPacket = DeserializeBodyPacket(packet, types);
                int rowCount = deserializedPacket.GetLength(0);
                int columnCount = deserializedPacket.GetLength(1);

                for (int i = 0; i < rowCount; i++)
                {
                    var rowData = new object[columnCount];
                    for (int j = 0; j < columnCount; j++)
                    {
                        rowData[j] = deserializedPacket[i, j];
                    }
                    result.Rows.Add(rowData);
                }
            }
            result.AcceptChanges();
            result.EndLoadData();

            return result;
        }

        #endregion

        #region Serialize/Deserialize  Header

        internal static QueryTablePacketDTO SerializeHeader(DataTable schemaTable, out Type[] types, bool isArchive)
        {
            Func<int, BaseColumnModel> getColumnModel = i =>
            {
                DataRow shemaRow = schemaTable.Rows[i];
                var type = (Type) shemaRow["DataType"];
                string name = shemaRow["ColumnName"].ToString();
                return new BaseColumnModel(name, name, type);
            };
            BaseTablePacketDTO baseHeader = SerializeHeader(schemaTable, getColumnModel, out types);
            QueryTablePacketDTO header = QueryTablePacketDTO.FromBaseTablePacketDTO(baseHeader, isArchive);
            return header;
        }

        internal static BaseTablePacketDTO SerializeHeader
            (DataTable schemaTable, Func<int, BaseColumnModel> getColumnModel, out Type[] types)
        {
            using (Stream stream = new MemoryStream())
            {
                using (var writer = new BinaryWriter(stream))
                {
                    types = new Type[schemaTable.Rows.Count];
                    for (int j = 0; j < schemaTable.Rows.Count; j++)
                    {
                        BaseColumnModel columnModel = getColumnModel(j);

                        types[j] = columnModel.Type;
                        writer.Write(columnModel.Name);
                        writer.Write(columnModel.Caption);
                        writer.Write(types[j].ToString());
                    }

                    writer.Flush();
                    var streamLength = (int) stream.Length;
                    stream.Seek(0, SeekOrigin.Begin);

                    var header = new BaseTablePacketDTO(schemaTable.Rows.Count, streamLength);
                    int readed = stream.Read(header.BinaryBody, 0, streamLength);
                    Debug.Assert(streamLength == readed, "not all bytes readed");
                    return header;
                }
            }
        }

        internal static List<BaseColumnModel> DeserializeHeader(BaseTablePacketDTO header)
        {
            var result = new List<BaseColumnModel>();
            using (Stream stream = new MemoryStream())
            {
                stream.Write(header.BinaryBody, 0, header.BinaryBody.Length);
                stream.Flush();
                stream.Seek(0, SeekOrigin.Begin);
                using (var reader = new BinaryReader(stream))
                {
                    for (int i = 0; i < header.RowCount; i++)
                    {
                        string name = reader.ReadString();
                        string caption = reader.ReadString();
                        Type type = Type.GetType(reader.ReadString());
                        result.Add(new BaseColumnModel(name, caption, type));
                    }
                }
            }
            return result;
        }

        #endregion

        #region Serialize/Deserialize Body packets

        internal static QueryTablePacketDTO SerializeBodyPacket(IDataReader reader, Type[] types, bool isArchive, int maxPacketRows = 0)
        {
            BaseTablePacketDTO basePacket = SerializeBodyPacket(reader, types, maxPacketRows);
            QueryTablePacketDTO packet = QueryTablePacketDTO.FromBaseTablePacketDTO(basePacket, isArchive);
            return packet;
        }

        internal static BaseTablePacketDTO SerializeBodyPacket(IDataReader reader, Type[] types, int maxPacketRows = 0)
        {
            if (maxPacketRows <= 0)
            {
                maxPacketRows = MaxPacketRows;
            }

            BaseTablePacketDTO packet;
            int rowsCount = 0;
            using (Stream stream = new MemoryStream())
            {
                using (var writer = new BinaryWriter(stream))
                {
                    while (rowsCount < maxPacketRows && reader.Read())
                    {
                        rowsCount++;
                        for (int j = 0; j < types.Length; j++)
                        {
                            bool hasValue = !reader.IsDBNull(j);
                            writer.Write(hasValue);
                            if (hasValue)
                            {
                                Type type = types[j];
                                if (type == typeof (String))
                                {
                                    writer.Write(reader.GetString(j));
                                }
                                else if (type == typeof (Int64))
                                {
                                    writer.Write(reader.GetInt64(j));
                                }
                                else if (type == typeof (Int32))
                                {
                                    writer.Write(reader.GetInt32(j));
                                }
                                else if (type == typeof (Int16))
                                {
                                    writer.Write(reader.GetInt16(j));
                                }
                                else if (type == typeof (DateTime))
                                {
                                    writer.Write(reader.GetDateTime(j).Ticks);
                                }
                                else if (type == typeof (Double))
                                {
                                    writer.Write(reader.GetDouble(j));
                                }
                                else if (type == typeof (Decimal))
                                {
                                    writer.Write(reader.GetDecimal(j));
                                }
                                else if (type == typeof (Single))
                                {
                                    writer.Write(reader.GetFloat(j));
                                }
                                else if (type == typeof (Boolean))
                                {
                                    writer.Write(reader.GetBoolean(j));
                                }
                                else if (type == typeof (Byte))
                                {
                                    writer.Write(reader.GetByte(j));
                                }
                            }
                        }
                    }

                    stream.Flush();
                    var streamLength = (int) stream.Length;

                    packet = new BaseTablePacketDTO(rowsCount, streamLength);
                    stream.Seek(0, SeekOrigin.Begin);
                    int readed = stream.Read(packet.BinaryBody, 0, streamLength);
                    Debug.Assert(streamLength == readed, "not all bytes readed");
                }
            }
            return packet;
        }

        public static object[,] DeserializeBodyPacket(BaseTablePacketDTO packet, Type[] types)
        {
            int rowsCount = packet.RowCount;
            int colsCount = types.Length;
            var result = new object[rowsCount, colsCount];
            using (Stream stream = new MemoryStream())
            {
                stream.Write(packet.BinaryBody, 0, packet.BinaryBody.Length);
                stream.Flush();
                stream.Seek(0, SeekOrigin.Begin);
                using (var reader = new BinaryReader(stream))
                {

                    {
                        for (int i = 0; i < rowsCount; i++)
                        {
                            for (int j = 0; j < colsCount; j++)
                            {
                                bool hasValue = reader.ReadBoolean();
                                if (hasValue)
                                {
                                    Type type = types[j];
                                    if (type == typeof (String))
                                    {
                                        result[i, j] = reader.ReadString();
                                    }
                                    else if (type == typeof (Int64))
                                    {
                                        result[i, j] = reader.ReadInt64();
                                    }
                                    else if (type == typeof (Int32))
                                    {
                                        result[i, j] = reader.ReadInt32();
                                    }
                                    else if (type == typeof (Int16))
                                    {
                                        result[i, j] = reader.ReadInt16();
                                    }
                                    else if (type == typeof (DateTime))
                                    {
                                        result[i, j] = new DateTime(reader.ReadInt64());
                                    }
                                    else if (type == typeof (Double))
                                    {
                                        result[i, j] = reader.ReadDouble();
                                    }
                                    else if (type == typeof (Decimal))
                                    {
                                        result[i, j] = reader.ReadDecimal();
                                    }
                                    else if (type == typeof (Single))
                                    {
                                        result[i, j] = reader.ReadSingle();
                                    }
                                    else if (type == typeof (Boolean))
                                    {
                                        result[i, j] = reader.ReadBoolean();
                                    }
                                    else if (type == typeof (Byte))
                                    {
                                        result[i, j] = reader.ReadByte();
                                    }
                                }
                                else
                                {
                                    result[i, j] = DBNull.Value;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        #endregion

        #region Serialize/Deserialize String

        public static byte[] SerializeFromString(string str)
        {
            Utils.CheckNotNull(str, "str");
            var bytes = new byte[str.Length * sizeof (char)];
            Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static string DeserializeToString(byte[] bytes)
        {
            Utils.CheckNotNull(bytes, "bytes");
            var chars = new char[bytes.Length / sizeof (char)];
            Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        #endregion

        #region MD5 from String

        public static string MD5FromString(string str)
        {
            if (Utils.IsEmpty(str))
            {
                str = BaseSettings.Asterisk;
            }
            byte[] serialized = SerializeFromString(str);

            MD5 md5 = MD5.Create();
            byte[] hashBytes = md5.ComputeHash(serialized);
            string hashString = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            return hashString;
        }

        #endregion
    }
}