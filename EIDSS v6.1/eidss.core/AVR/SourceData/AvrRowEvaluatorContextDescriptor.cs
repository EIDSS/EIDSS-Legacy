using System;
using System.Collections;
using System.Collections.Generic;
using bv.common.Core;
using DevExpress.Data.Filtering;
using DevExpress.Data.Filtering.Helpers;

namespace eidss.model.AVR.SourceData
{
    public class AvrRowEvaluatorContextDescriptor : EvaluatorContextDescriptor
    {
        private readonly AvrDataTable m_Table;
        private static readonly object m_NoResult = new object();

        private readonly Dictionary<string, int> m_Indexes = new Dictionary<string, int>();

        public AvrRowEvaluatorContextDescriptor(AvrDataTable table)
        {
            m_Table = table;
        }

        private object GetPropertyValue(object source, string property)
        {
            var row = source as AvrDataRowBase;
            if (row != null && m_Table != null)
            {
                int index;
                if (!m_Indexes.TryGetValue(property, out index))
                {
                    var fieldName = AvrPivotGridFieldHelper.GetOriginalNameFromFieldName(property).Substring(5);
                    if (!m_Table.Columns.Contains(fieldName))
                    {
                        var err = string.Format("Could not find filter field '{0} (full name '{1}') in the pivot grid",
                            fieldName, property);
                        throw new AvrException(err);
                    }
                    index = m_Table.Columns[fieldName].Ordinal;
                    m_Indexes.Add(property, index);
                }
                return row[index];
            }
            return m_NoResult;
        }

        public override object GetPropertyValue(object source, EvaluatorProperty propertyPath)
        {
            object res = GetPropertyValue(source, propertyPath.PropertyPath);
            if (res != m_NoResult)
            {
                return res;
            }
            return null;
        }

        public override EvaluatorContext GetNestedContext(object source, string propertyPath)
        {
            throw new NotSupportedException();
        }

        public override IEnumerable GetCollectionContexts(object source, string collectionName)
        {
            throw new NotSupportedException();
        }

        public override IEnumerable GetQueryContexts(object source, string collectionTypeName, CriteriaOperator condition, int top)
        {
            throw new NotSupportedException();
        }
    }
}