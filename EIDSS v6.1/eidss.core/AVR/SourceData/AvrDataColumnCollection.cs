using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using bv.common.Core;
using eidss.model.AVR.DataBase;

namespace eidss.model.AVR.SourceData
{
    public class AvrDataColumnCollection : IEnumerable<AvrDataColumn>, IDisposable
    {
        private readonly List<AvrDataColumn> m_Columns = new List<AvrDataColumn>();
        private readonly PropertyDescriptorCollection m_Properties = new PropertyDescriptorCollection(new PropertyDescriptor[0]);
        private readonly AvrDataTable m_ParentTable;
        private readonly AvrDataRowCounter m_Counter;

        public AvrDataColumnCollection(AvrDataTable parentTable)
        {
            Utils.CheckNotNull(parentTable, "parenTable");
            m_ParentTable = parentTable;
            m_Counter = new AvrDataRowCounter();
        }

        public AvrDataColumn this[int index]
        {
            get { return m_Columns[index]; }
        }

        public AvrDataColumn this[string index]
        {
            get
            {
                Utils.CheckNotNullOrEmpty(index, "index");
                return m_Columns.Find(c => c.ColumnName == index);
            }
        }

        public PropertyDescriptorCollection Properties
        {
            get { return m_Properties; }
        }

        public int Count
        {
            get { return m_Columns.Count; }
        }

        public int DistinctCount { get; private set; }

        public AvrDataRowCounter Counter
        {
            get { return m_Counter; }
        }

        public int IndexOf(AvrDataColumn item)
        {
            Utils.CheckNotNull(item, "item");
            return m_Columns.IndexOf(item);
        }

        public void Add(string columnName, Type dataType)
        {
            Add(columnName, columnName, dataType);
        }

        public void Add(string columnName, string columnCaption, Type dataType)
        {
            Utils.CheckNotNullOrEmpty(columnName, "columnName");

            if (Contains(columnName))
            {
                throw new DuplicateNameException("The collection already has a column with the specified name");
            }
            if (m_ParentTable.Count > 0)
            {
                throw new InvalidOperationException("Could not add new column because AvrTable already contains data");
            }

            var column = new AvrDataColumn(columnName, dataType)
            {
                Collection = this,
                Caption = columnCaption,
                Ordinal = DistinctCount
            };
            m_Columns.Add(column);

            var copyColumn = new AvrDataColumn(columnName + QueryHelper.CopySuffix, dataType)
            {
                Collection = this,
                Caption = columnCaption,
                Ordinal = DistinctCount
            };
            m_Columns.Add(copyColumn);

            m_Counter.AddType(dataType);

            DistinctCount++;
            int index = DistinctCount - 1;
            AvrMethodDelegate method = p => p[index];

            Properties.Add(new AvrMethodDescriptor(column.ColumnName, method, column.DataType));
            Properties.Add(new AvrMethodDescriptor(copyColumn.ColumnName, method, column.DataType));
        }

        public AvrDataColumn AddCopy(string originalColumnName, string copyColumnName)
        {
            Utils.CheckNotNullOrEmpty(originalColumnName, "originalColumnName");
            Utils.CheckNotNullOrEmpty(copyColumnName, "copyColumnName");

            if (!Contains(originalColumnName))
            {
                throw new ArgumentException("The collection doesn't have a column with the specified name", "originalColumnName");
            }
            if (Contains(copyColumnName))
            {
                throw new DuplicateNameException("The collection already has a column with the specified name");
            }

            AvrDataColumn originalColumn = this[originalColumnName];
            var copyColumn = new AvrDataColumn(copyColumnName, originalColumn.DataType)
            {
                Caption = originalColumn.Caption,
                Ordinal = originalColumn.Ordinal,
                ExtendedProperties = new PropertyCollection()
            };
            foreach (DictionaryEntry entry in originalColumn.ExtendedProperties)
            {
                copyColumn.ExtendedProperties.Add(entry.Key, entry.Value);
            }
            m_Columns.Add(copyColumn);
            var prop = (AvrMethodDescriptor) Properties[originalColumnName];
            Properties.Add(new AvrMethodDescriptor(copyColumnName, prop.Method, prop.MethodReturnType));
            return copyColumn;
        }

        public void Deny(string columnName)
        {
            Utils.CheckNotNullOrEmpty(columnName, "columnName");
            var oldProperty = (AvrMethodDescriptor) Properties[columnName];
            Properties.Remove(oldProperty);
            Properties.Add(new AvrMethodDescriptor(oldProperty.Name, p => DBNull.Value, oldProperty.MethodReturnType));
        }

        public void CopyCollectionFrom(AvrDataColumnCollection collection)
        {
            Utils.CheckNotNull(collection, "collection");
            if (m_ParentTable.Count > 0)
            {
                throw new InvalidOperationException("Could not add new column because AvrTable already contains data");
            }

            DistinctCount = collection.DistinctCount;
            foreach (AvrDataColumn originalColumn in collection)
            {
                AvrDataColumn cloneColumn = originalColumn.Clone();
                cloneColumn.Collection = this;
                cloneColumn.Ordinal = originalColumn.Ordinal;
                m_Columns.Add(cloneColumn);
            }
            foreach (AvrMethodDescriptor prop in collection.Properties)
            {
                Properties.Add(new AvrMethodDescriptor(prop.Name, prop.Method, prop.MethodReturnType));
            }
        }

        public bool Contains(string name)
        {
            Utils.CheckNotNullOrEmpty(name, "name");
            return m_Columns.Any(c => c.ColumnName == name);
        }

        public bool Contains(AvrDataColumn item)
        {
            return m_Columns.Contains(item);
        }

        public void Remove(AvrDataColumn item)
        {
            if (m_Columns.Contains(item))
            {
                PropertyDescriptor descriptor = Properties[item.ColumnName];
                Properties.Remove(descriptor);
                m_Columns.Remove(item);
                item.Collection = null;
            }
        }

        public IEnumerator<AvrDataColumn> GetEnumerator()
        {
            return m_Columns.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {
            DistinctCount = 0;
            foreach (AvrDataColumn column in m_Columns)
            {
                column.Collection = null;
            }
            m_Columns.Clear();
            Properties.Clear();
        }
    }
}