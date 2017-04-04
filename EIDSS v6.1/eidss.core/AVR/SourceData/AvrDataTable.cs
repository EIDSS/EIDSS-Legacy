using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using bv.common.Core;

using eidss.model.AVR.ServiceData;

namespace eidss.model.AVR.SourceData
{
    public class AvrDataTable : List<AvrDataRowBase>, ITypedList, IDisposable
    {
        private AvrDataColumnCollection m_Columns;
        private int m_AcceptedCount;
        private readonly object m_SyncLock = new object();

        public AvrDataTable()
        {
        }

        public AvrDataTable(DataTable source)
        {
            Utils.CheckNotNull(source, "source");

            TableName = source.TableName;
            foreach (DataColumn sourceColumn in source.Columns)
            {
                Columns.Add(sourceColumn.ColumnName, sourceColumn.Caption, sourceColumn.DataType);
            }

            int arrayLength = source.Columns.Count;
            foreach (DataRow row in source.Rows)
            {
                var array = new object[arrayLength];

                for (int i = 0; i < arrayLength; i++)
                {
                    array[i] = row[i];
                }
                AvrDataRow newRow = NewRow(array);
                Rows.Add(newRow);
            }
        }

        public AvrDataTable(QueryTableHeaderModel headerModel, int capacity)
            : base(capacity)
        {
            Utils.CheckNotNull(headerModel, "headerModel");

            foreach (BaseColumnModel columnModel in headerModel.ColumnTypeByName)
            {
                Columns.Add(columnModel.Name, columnModel.Caption, columnModel.FinalType);
            }
        }

        public string TableName { get; set; }

        public List<AvrDataRowBase> Rows
        {
            get { return this; }
        }

        public AvrDataColumnCollection Columns
        {
            get { return m_Columns ?? (m_Columns = new AvrDataColumnCollection(this)); }
        }

        public string RowFilterExpression { get; set; }

        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            return Columns.Properties;
        }

        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return ""; // was used by 1.1 datagrid
        }

        public void ThreadSafeClear()
        {
            lock (m_SyncLock)
            {
                Rows.Clear();
            }
        }

        public void ThreadSafeAdd(AvrDataRowBase row)
        {
            lock (m_SyncLock)
            {
                Rows.Add(row);
            }
        }

        public AvrDataRow NewRow()
        {
            var array = new object[Columns.DistinctCount];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = AvrDataRowBase.DbNullValue;
            }
            return new AvrDataRow(array);
        }

        public AvrDataRow NewRow(object[] array)
        {
            return new AvrDataRow(array);
        }

        public AvrDataRowEx NewRow(AvrDataRowDTO dto)
        {
            return new AvrDataRowEx(dto);
        }

//        public AvrDataRowBase[] Select(string filterExpression)
//        {
//            //todo: [ivan] implement
//            return Rows.ToArray();
//        }

        public void DenyColumn(string columnName)
        {
            Columns.Deny(columnName);
        }

        public AvrDataColumn AddCopyColumn(string originalColumnName, string copyColumnName)
        {
            return Columns.AddCopy(originalColumnName, copyColumnName);
        }

        public void AcceptChanges()
        {
            m_AcceptedCount = Rows.Count;
        }

        public void RejectChanges()
        {
            if (m_AcceptedCount > 0)
            {
                Rows.RemoveRange(m_AcceptedCount, Rows.Count - m_AcceptedCount);
            }
            else
            {
                Rows.Clear();
            }
        }

        public AvrDataTable Clone()
        {
            var clone = new AvrDataTable();
            clone.Columns.CopyCollectionFrom(Columns);
            return clone;
        }

        public AvrDataTable Copy()
        {
            AvrDataTable newTable = Clone();
            IEnumerable<AvrDataRowBase> newRows = Rows.Select(row => row.Clone());
            newTable.Rows.AddRange(newRows);
            return newTable;
        }

        public void Dispose()
        {
            Columns.Dispose();
            Clear();
        }

        public DataTable ToDataTable()
        {
            DataTable result = new DataTable(TableName);

            int[] indexes = new int[Columns.Count];

            for (int i = 0; i < Columns.Count; i++)
            {
                var column = Columns[i];
                indexes[i] = column.Ordinal;
                var dataColumn = new DataColumn(column.ColumnName, column.DataType) {Caption = column.Caption};
                foreach (DictionaryEntry entry in column.ExtendedProperties)
                {
                    dataColumn.ExtendedProperties.Add(entry.Key, entry.Value);
                }
                result.Columns.Add(dataColumn);
            }

            foreach (var row in Rows)
            {
                object[] array = new object[Columns.Count];

                for (int i = 0; i < array.Length; i++)
                {
                    var index = indexes[i];
                    array[i] = row[index];
                }
                result.Rows.Add(array);
            }
            return result;
        }

        public override string ToString()
        {
            return string.Format("Cols:{0}, Rows:{1}", Columns.Count, Rows.Count);
        }
    }
}