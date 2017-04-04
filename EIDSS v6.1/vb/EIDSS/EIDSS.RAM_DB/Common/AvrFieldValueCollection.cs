using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eidss.avr.db.Common
{
    public class AvrFieldValueCollection : IEnumerable<AvrFieldValuePair>
    {
        public AvrFieldValueCollection()
        {
            InternalList = new List<AvrFieldValuePair>();
        }

        public AvrFieldValueCollection(int capacity)
        {
            InternalList = new List<AvrFieldValuePair>(capacity);
        }

        public AvrFieldValueCollection(IEnumerable<AvrFieldValuePair> collection, bool needCopy)
        {
            if (collection == null)
            {
                throw (new ArgumentNullException("collection"));
            }
            if (needCopy)
            {
                InternalList = new List<AvrFieldValuePair>();
                foreach (AvrFieldValuePair item in collection)
                {
                    var newItem = new AvrFieldValuePair(item.Field, item.FieldCopy, item.IsRelated)
                    {
                        Value = item.Value,
                        LinkedFieldValues = item.LinkedFieldValues
                    };
                    InternalList.Add(newItem);
                }
            }
            else
            {
                InternalList = collection.ToList();
            }
        }

        public AvrFieldValueCollection(Dictionary<IAvrPivotGridField, List<IAvrPivotGridField>> fieldsAndFieldCopy)
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
            InternalList = fieldsAndFieldCopy.Select(p => new AvrFieldValuePair(p.Key, p.Value, related.Contains(p.Key))).ToList();
        }

        internal List<AvrFieldValuePair> InternalList { get; set; }

        public bool AddMissedValues
        {
            get { return InternalList.Any(pair => pair.Field.AddMissedValues); }
        }

        public int Count
        {
            get { return InternalList.Count; }
        }

        public AvrFieldValuePair this[int index]
        {
            get { return InternalList[index]; }
            set { InternalList[index] = value; }
        }

        public IEnumerator<AvrFieldValuePair> GetEnumerator()
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