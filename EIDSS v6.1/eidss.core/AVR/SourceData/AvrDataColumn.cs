using System;
using System.Collections;
using System.Data;
using bv.common.Core;

namespace eidss.model.AVR.SourceData
{
    public class AvrDataColumn
    {
        private string m_ColumnName;
        private AvrDataColumnCollection m_Collection;

        public AvrDataColumn(string columnName, Type dataType)
        {
            Utils.CheckNotNullOrEmpty(columnName, "columnName");

            m_ColumnName = columnName;
            DataType = dataType;

            ExtendedProperties = new PropertyCollection();
        }

        public string Caption { set; get; }

        public string ColumnName
        {
            get { return m_ColumnName; }
            set
            {
                if (Collection != null)
                {
                    if (Collection.Contains(value))
                    {
                        throw new DuplicateNameException("The collection already has a column with the specified name");
                    }
                    var oldProperty = (AvrMethodDescriptor) Collection.Properties[m_ColumnName];
                    Collection.Properties.Add(new AvrMethodDescriptor(value, oldProperty.Method, oldProperty.MethodReturnType));
                    Collection.Properties.Remove(oldProperty);
                }
                m_ColumnName = value;
            }
        }

        public Type DataType { get; private set; }

        public PropertyCollection ExtendedProperties { get; protected  internal set; }

        protected internal AvrDataColumnCollection Collection
        {
            get { return m_Collection; }
            set
            {
                if (ReferenceEquals(m_Collection, value))
                {
                    return;
                }
                if (m_Collection != null && value != null)
                {
                    throw new ArgumentException("The column already belongs to another collection");
                }

                m_Collection = value;
            }
        }

        public int Ordinal { get; protected internal set; }

        public AvrDataColumn Clone()
        {
            var clone = new AvrDataColumn(ColumnName, DataType)
            {
                Caption = Caption,
                Ordinal = Ordinal,
                ExtendedProperties = new PropertyCollection()
            };
            
            foreach (DictionaryEntry entry in ExtendedProperties)
            {
               clone.ExtendedProperties.Add(entry.Key, entry.Value);
            }

            return clone;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1}), Type={2}", ColumnName, Caption, DataType);
        }
    }
}