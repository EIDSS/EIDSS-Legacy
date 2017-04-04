using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using bv.common.Configuration;
using bv.common.Core;
using BLToolkit.Data;
using DevExpress.Data.Filtering;
using DevExpress.Data.Filtering.Helpers;
using eidss.model.AVR.ServiceData;
using eidss.model.AVR.SourceData;

namespace eidss.model.WindowsService.Serialization
{
    public static class BinarySerializer
    {
        private static readonly Type m_TypeOfString = typeof (String);
        private static readonly Type m_TypeOfDateTime = typeof (DateTime);
        private static readonly Type m_TypeOfInt64 = typeof (Int64);
        private static readonly Type m_TypeOfInt32 = typeof (Int32);
        private static readonly Type m_TypeOfInt16 = typeof (Int16);
        private static readonly Type m_TypeOfDecimal = typeof (Decimal);
        private static readonly Type m_TypeOfDouble = typeof (Double);
        private static readonly Type m_TypeOfSingle = typeof (Single);
        private static readonly Type m_TypeOfBoolean = typeof (Boolean);
        private static readonly Type m_TypeOfByte = typeof (Byte);

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

            using (IDataReader reader = command.ExecuteReader())
            {
                if (reader == null)
                {
                    throw new CustomSerializationException(string.Format("Could not get DataReader from command {0}",
                        command.Command.CommandText));
                }

                List<BaseColumnModel> columnModels = GetSchemaColumnModels(reader.GetSchemaTable());

                var result = new QueryTableModel(queryId, lang) {UseArchivedData = isArchive};

                QueryTablePacketDTO packet = SerializeBodyPacket(reader, columnModels, isArchive, maxPacketRows);
                while (packet.RowCount != 0)
                {
                    result.BodyPackets.Add(packet);
                    packet = SerializeBodyPacket(reader, columnModels, isArchive, maxPacketRows);
                }

                // note : header should be serialized afer body because of possible columnModels change inside SerializeBodyPacket
                result.Header = SerializeHeader(columnModels, isArchive);
                return result;
            }
        }

        #endregion

        #region Serialize/Deserialize whole DataTable

        public static BaseTableDTO SerializeFromTable(DataTable table, int maxPacketRows = 0)
        {
            var columnModels = new List<BaseColumnModel>();

            foreach (DataColumn column in table.Columns)
            {
                var columnModel = new BaseColumnModel(column.ColumnName, column.Caption, column.DataType);
                columnModels.Add(columnModel);
            }

            DataTableReader reader = table.CreateDataReader();
            BaseTablePacketDTO packet = SerializeBodyPacket(reader, columnModels, maxPacketRows);
            var result = new BaseTableDTO {TableName = table.TableName};
            while (packet.RowCount != 0)
            {
                result.BodyPackets.Add(packet);
                packet = SerializeBodyPacket(reader, columnModels, maxPacketRows);
            }
            result.Header = SerializeHeader(columnModels);
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
                var column = new DataColumn(columnModel.Name, columnModel.FinalType) {Caption = columnModel.Caption};
                result.Columns.Add(column);
            }
            result.EndInit();

            AvrDataTable avrTable = new AvrDataTable(result);

            result.BeginLoadData();
            Type[] types = deserializedHeader.Select(c => c.FinalType).ToArray();

            foreach (BaseTablePacketDTO packet in dto.BodyPackets)
            {
                DeserializeBodyPacket(packet, types, avrTable);
            }
            avrTable.AcceptChanges();

            foreach (AvrDataRowBase avrRow in avrTable.Rows)
            {
                object[] array = new object[avrRow.Count];
                for (int j = 0; j < avrRow.Count; j++)
                {
                    array[j] = avrRow[j];
                }
                result.Rows.Add(array);
            }

            result.AcceptChanges();
            result.EndLoadData();

            return result;
        }

        #endregion

        #region Serialize/Deserialize  Header

        internal static QueryTablePacketDTO SerializeHeader(List<BaseColumnModel> columnModelList, bool isArchive)
        {
            BaseTablePacketDTO baseHeader = SerializeHeader(columnModelList);
            QueryTablePacketDTO header = QueryTablePacketDTO.FromBaseTablePacketDTO(baseHeader, isArchive);
            return header;
        }

        internal static List<BaseColumnModel> GetSchemaColumnModels(DataTable schemaTable)
        {
            var result = new List<BaseColumnModel>();
            foreach (DataRow shemaRow in schemaTable.Rows)
            {
                var type = (Type) shemaRow["DataType"];
                string name = shemaRow["ColumnName"].ToString();
                result.Add(new BaseColumnModel(name, type));
            }
            return result;
        }

        internal static BaseTablePacketDTO SerializeHeader(List<BaseColumnModel> columnModelList)
        {
            using (Stream stream = new MemoryStream())
            {
                using (var writer = new BinaryWriter(stream))
                {
                    foreach (BaseColumnModel columnModel in columnModelList)
                    {
                        writer.Write(columnModel.Name);
                        writer.Write(columnModel.Caption);
                        writer.Write(columnModel.FinalType.ToString());
                    }
                    writer.Flush();
                    var streamLength = (int) stream.Length;
                    stream.Seek(0, SeekOrigin.Begin);

                    var header = new BaseTablePacketDTO(columnModelList.Count, streamLength);
                    int readed = stream.Read(header.BinaryBody, 0, streamLength);
                    Debug.Assert(streamLength == readed, "not all bytes readed");
                    return header;
                }
            }
        }

        internal static List<BaseColumnModel> DeserializeHeader(BaseTablePacketDTO header)
        {
            var result = new List<BaseColumnModel>();
            using (Stream stream = new MemoryStream(header.BinaryBody.Length))
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

        internal static QueryTablePacketDTO SerializeBodyPacket
            (IDataReader reader, List<BaseColumnModel> columnModels, bool isArchive, int maxPacketRows = 0)
        {
            BaseTablePacketDTO basePacket = SerializeBodyPacket(reader, columnModels, maxPacketRows);
            QueryTablePacketDTO packet = QueryTablePacketDTO.FromBaseTablePacketDTO(basePacket, isArchive);
            return packet;
        }

        internal static BaseTablePacketDTO SerializeBodyPacket
            (IDataReader reader, List<BaseColumnModel> columnModels, int maxPacketRows = 0)
        {
            if (maxPacketRows <= 0)
            {
                maxPacketRows = MaxPacketRows;
            }

            BaseTablePacketDTO packet;
            int rowsCount = 0;

            var internStringsDict = new Dictionary<int, List<string>>();
            for (int i = 0; i < columnModels.Count; i++)
            {
                internStringsDict[i] = new List<string>();
            }
            using (Stream stream = new MemoryStream())
            {
                using (var writer = new BinaryWriter(stream))
                {
                    while (rowsCount < maxPacketRows && reader.Read())
                    {
                        rowsCount++;
                        for (int i = 0; i < columnModels.Count; i++)
                        {
                            bool hasValue = !reader.IsDBNull(i);

                            if (hasValue)
                            {
                                if (!WriteReaderValueToStream(writer, reader, i, columnModels[i].InitilalType, internStringsDict[i]))
                                {
                                    // if value is boxed, i.e. has object type. It is usualy when uses sql_variant
                                    object value = reader.GetValue(i);
                                    bool result = false;
                                    if (value != null)
                                    {
                                        result = columnModels[i].TryChangeType(value.GetType())
                                            ? UnboxAndWriteObjectToStream(writer, value, columnModels[i].FinalType)
                                            : ParseAndWriteObjectToStream(writer, value.ToString(), columnModels[i].FinalType);
                                    }

                                    if (!result)
                                    {
                                        writer.Write(false);
                                    }
                                }
                            }
                            else
                            {
                                writer.Write(false);
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

        internal static bool WriteReaderValueToStream
            (BinaryWriter writer, IDataReader reader, int position, Type type, List<string> internStrings)
        {
            if (type == typeof (String))
            {
                string value = reader.GetString(position);
                if (string.IsNullOrEmpty(value))
                {
                    writer.Write(false);
                }
                else
                {
                    sbyte status = 1;
                    if (internStrings.Count < sbyte.MaxValue)
                    {
                        int index = internStrings.IndexOf(value);
                        if (index < 0)
                        {
                            internStrings.Add(value);
                        }
                        else
                        {
                            status = (sbyte) (index + 2);
                        }
                    }
                    writer.Write(status);
                    if (status < 2)
                    {
                        writer.Write(value);
                    }
                }
                return true;
            }
            if (type == typeof (Int64))
            {
                writer.Write(true);
                writer.Write(reader.GetInt64(position));
                return true;
            }
            if (type == typeof (Int32))
            {
                writer.Write(true);
                writer.Write(reader.GetInt32(position));
                return true;
            }
            if (type == typeof (Int16))
            {
                writer.Write(true);
                writer.Write(reader.GetInt16(position));
                return true;
            }
            if (type == typeof (DateTime))
            {
                writer.Write(true);
                writer.Write(reader.GetDateTime(position).Ticks);
                return true;
            }
            if (type == typeof (Double))
            {
                writer.Write(true);
                writer.Write(reader.GetDouble(position));
                return true;
            }
            if (type == typeof (Decimal))
            {
                writer.Write(true);
                writer.Write(reader.GetDecimal(position));
                return true;
            }
            if (type == typeof (Single))
            {
                writer.Write(true);
                writer.Write(reader.GetFloat(position));
                return true;
            }
            if (type == typeof (Boolean))
            {
                writer.Write(true);
                writer.Write(reader.GetBoolean(position));
                return true;
            }
            if (type == typeof (Byte))
            {
                writer.Write(true);
                writer.Write(reader.GetByte(position));
                return true;
            }
            return false;
        }

        private static bool UnboxAndWriteObjectToStream(BinaryWriter writer, object value, Type type)
        {
            if (type == typeof (String))
            {
                string str = value.ToString();
                if (string.IsNullOrEmpty(str))
                {
                    writer.Write(false);
                }
                else
                {
                    writer.Write(true);
                    writer.Write(str);
                }
                return true;
            }
            if (type == typeof (Int64))
            {
                writer.Write(true);
                writer.Write((Int64) value);
                return true;
            }
            if (type == typeof (Int32))
            {
                writer.Write(true);
                writer.Write((Int32) value);
                return true;
            }
            if (type == typeof (Int16))
            {
                writer.Write(true);
                writer.Write((Int16) value);
                return true;
            }
            if (type == typeof (DateTime))
            {
                writer.Write(true);
                writer.Write(((DateTime) value).Ticks);
                return true;
            }
            if (type == typeof (Double))
            {
                writer.Write(true);
                writer.Write((Double) value);
                return true;
            }
            if (type == typeof (Decimal))
            {
                writer.Write(true);
                writer.Write((Decimal) value);
                return true;
            }
            if (type == typeof (Single))
            {
                writer.Write(true);
                writer.Write((Single) value);
                return true;
            }
            if (type == typeof (Boolean))
            {
                writer.Write(true);
                writer.Write((Boolean) value);
                return true;
            }
            if (type == typeof (Byte))
            {
                writer.Write(true);
                writer.Write((Byte) value);
                return true;
            }
            return false;
        }

        private static bool ParseAndWriteObjectToStream(BinaryWriter writer, string value, Type type)
        {
            if (type == m_TypeOfString)
            {
                if (string.IsNullOrEmpty(value))
                {
                    writer.Write(false);
                }
                else
                {
                    writer.Write(true);
                    writer.Write(value);
                }
                return true;
            }
            if (type == m_TypeOfDateTime)
            {
                DateTime parsed;
                if (DateTime.TryParse(value, out parsed))
                {
                    writer.Write(true);
                    writer.Write(parsed.Ticks);
                    return true;
                }
            }
            if (type == m_TypeOfInt64)
            {
                Int64 parsed;
                if (Int64.TryParse(value, out parsed))
                {
                    writer.Write(true);
                    writer.Write(parsed);
                    return true;
                }
            }
            if (type == m_TypeOfInt32)
            {
                Int32 parsed;
                if (Int32.TryParse(value, out parsed))
                {
                    writer.Write(true);
                    writer.Write(parsed);
                    return true;
                }
            }
            if (type == m_TypeOfInt16)
            {
                Int16 parsed;
                if (Int16.TryParse(value, out parsed))
                {
                    writer.Write(true);
                    writer.Write(parsed);
                    return true;
                }
            }

            if (type == m_TypeOfDouble)
            {
                Double parsed;
                if (Double.TryParse(value, out parsed))
                {
                    writer.Write(true);
                    writer.Write(parsed);
                    return true;
                }
            }
            if (type == m_TypeOfDecimal)
            {
                Decimal parsed;
                if (Decimal.TryParse(value, out parsed))
                {
                    writer.Write(true);
                    writer.Write(parsed);
                    return true;
                }
            }
            if (type == m_TypeOfSingle)
            {
                Single parsed;
                if (Single.TryParse(value, out parsed))
                {
                    writer.Write(true);
                    writer.Write(parsed);
                    return true;
                }
            }
            if (type == m_TypeOfBoolean)
            {
                Boolean parsed;
                if (Boolean.TryParse(value, out parsed))
                {
                    writer.Write(true);
                    writer.Write(parsed);
                    return true;
                }
            }
            if (type == m_TypeOfByte)
            {
                Byte parsed;
                if (Byte.TryParse(value, out parsed))
                {
                    writer.Write(true);
                    writer.Write(parsed);
                    return true;
                }
            }
            return false;
        }

        public static void DeserializeBodyPacket(BaseTablePacketDTO packet, Type[] types, AvrDataTable table)
        {
            Utils.CheckNotNull(packet, "packet");

            DeserializeBodyPacket(packet.RowCount, types, table, packet.StreamCreator);
        }

        public static void DeserializeBodyPacket(StreamTablePacketDTO packet, Type[] types, AvrDataTable table)
        {
            Utils.CheckNotNull(packet, "packet");

            DeserializeBodyPacket(packet.RowCount, types, table, packet.StreamCreator);
        }

        public static void DeserializeBodyPacket(int rowsCount, Type[] types, AvrDataTable table, Func<Stream> streamCreator)
        {
            Utils.CheckNotNull(types, "types");
            Utils.CheckNotNull(streamCreator, "streamCreator");
            Stream stream = streamCreator();
            if (stream == null)
            {
                throw new AvrException("Could not deserialize avr table packet: stream creator is null");
            }

            int colsCount = types.Length;
            var internIndexes = new int[colsCount];
            var internStrings = new string[colsCount][];
            for (int i = 0; i < internStrings.Length; i++)
            {
                internStrings[i] = new string[sbyte.MaxValue];
            }

            ExpressionEvaluator filter = null;
            if (!string.IsNullOrEmpty(table.RowFilterExpression))
            {
                var descriptor = new AvrRowEvaluatorContextDescriptor(table);
                var criteriaOperator = CriteriaOperator.Parse(table.RowFilterExpression);
                filter = new ExpressionEvaluator(descriptor, criteriaOperator);
            }

            var rowDTO = CreateAvrDataRowDTO(types);
            using (var reader = new BinaryReader(stream))
            {
                for (int i = 0; i < rowsCount; i++)
                {
                    for (int j = 0; j < colsCount; j++)
                    {
                        sbyte status = reader.ReadSByte();

                        if (status > 0)
                        {
                            Type type = types[j];

                            if (type == m_TypeOfString)
                            {
                                string val;
                                var internIndex = internIndexes[j];
                                if (internIndex < sbyte.MaxValue)
                                {
                                    if (status == 1)
                                    {
                                        val = reader.ReadString();
                                        internStrings[j][internIndex] = val;
                                        internIndexes[j] = internIndex + 1;
                                    }
                                    else
                                    {
                                        val = internStrings[j][status - 2];
                                    }
                                }
                                else
                                {
                                    val = reader.ReadString();
                                }

                                rowDTO.SetObject(j, val);
                            }
                            else if (type == m_TypeOfDateTime)
                            {
                                var value = new DateTime(reader.ReadInt64());
                                rowDTO.SetDateTime(j, value);
                            }
                            else if (type == m_TypeOfInt32)
                            {
                                rowDTO.SetInt(j, reader.ReadInt32());
                            }
                            else if (type == m_TypeOfInt64)
                            {
                                rowDTO.SetObject(j, reader.ReadInt64());
                            }
                            else if (type == m_TypeOfInt16)
                            {
                                rowDTO.SetObject(j, reader.ReadInt16());
                            }
                            else if (type == m_TypeOfDouble)
                            {
                                rowDTO.SetObject(j, reader.ReadDouble());
                            }
                            else if (type == m_TypeOfDecimal)
                            {
                                rowDTO.SetObject(j, reader.ReadDecimal());
                            }
                            else if (type == m_TypeOfSingle)
                            {
                                rowDTO.SetObject(j, reader.ReadSingle());
                            }
                            else if (type == m_TypeOfBoolean)
                            {
                                rowDTO.SetObject(j, reader.ReadBoolean());
                            }
                            else if (type == m_TypeOfByte)
                            {
                                rowDTO.SetObject(j, reader.ReadByte());
                            }
                        }
                    }

                    AvrDataRowBase newRow = table.NewRow(rowDTO);
                    if (filter == null || filter.Fit(newRow))
                    {
                        table.ThreadSafeAdd(newRow);
                    }

                    rowDTO.Reset();
                }
            }

            stream.Dispose();
        }

        private static AvrDataRowDTO CreateAvrDataRowDTO(Type[] types)
        {
            int dateTimeCount = 0;
            int intCount = 0;
            int objectCount = 0;
            foreach (var type in types)
            {
                if (type == m_TypeOfDateTime)
                {
                    dateTimeCount++;
                }
                else if (type == m_TypeOfInt32)
                {
                    intCount++;
                }
                else
                {
                    objectCount++;
                }
            }
            var rowDTO = new AvrDataRowDTO(dateTimeCount, intCount, objectCount);
            return rowDTO;
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