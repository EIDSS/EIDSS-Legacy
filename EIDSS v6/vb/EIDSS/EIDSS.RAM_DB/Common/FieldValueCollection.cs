using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eidss.avr.db.Common
{
    public class FieldValueCollection : IEnumerable<FieldValuePair>
    {
        public FieldValueCollection()
        {
            InternalList = new List<FieldValuePair>();
        }

        public FieldValueCollection(int capacity)
        {
            InternalList = new List<FieldValuePair>(capacity);
        }

        public FieldValueCollection(IEnumerable<FieldValuePair> collection, bool needCopy)
        {
            if (collection == null)
            {
                throw (new ArgumentNullException("collection"));
            }
            if (needCopy)
            {
                InternalList = new List<FieldValuePair>();
                foreach (FieldValuePair pair in collection)
                {
                    InternalList.Add(new FieldValuePair(pair.Field, pair.FieldCopy, pair.IsRelated));
                }
            }
            else
            {
                InternalList = collection.ToList();
            }
        }

        public FieldValueCollection(Dictionary<IAvrPivotGridField, List<IAvrPivotGridField>> fieldsAndFieldCopy)
        {
            if (fieldsAndFieldCopy == null)
            {
                throw (new ArgumentNullException("fieldsAndFieldCopy"));
            }

            var related = new List<IAvrPivotGridField>();
            foreach (IAvrPivotGridField field in fieldsAndFieldCopy.Keys)
            {
                if (field.AddMissedValues)
                {
                    related.AddRange(field.GetRelatedFieldChain());
                }
            }
            InternalList = fieldsAndFieldCopy.Select(p => new FieldValuePair(p.Key, p.Value, related.Contains(p.Key))).ToList();
        }

        internal List<FieldValuePair> InternalList { get; set; }

        public bool AddMissedValues
        {
            get { return InternalList.Any(pair => pair.Field.AddMissedValues); }
        }

        public int Count
        {
            get { return InternalList.Count; }
        }

        public FieldValuePair this[int index]
        {
            get { return InternalList[index]; }
            set { InternalList[index] = value; }
        }

        public IEnumerator<FieldValuePair> GetEnumerator()
        {
            return InternalList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            const int maxItemCountToShow = 10;
            var result = new StringBuilder();
            for (int i = 0; i < Math.Min(InternalList.Count, maxItemCountToShow); i++)
            {
                result.AppendFormat("{0}, ", InternalList[i]);
            }
            return result.ToString();
        }
    }
}