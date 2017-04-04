using System;
using System.Collections.Generic;
using System.Linq;
using bv.model.BLToolkit;
using bv.model.Helpers;

namespace bv.model.Model.Core
{
    [Serializable]
    public class FilterParams
    {
        [Serializable]
        public class FilterParam
        {
            public string operation;
            public object value;
            public bool isOr;
        }

        private readonly Dictionary<string, List<FilterParam>> m_Content = new Dictionary<string, List<FilterParam>>();

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, List<FilterParam>> Content
        {
            get {return m_Content; }
        }

        public FilterParams Add(string param, string oper, object val, bool or = false)
        {
            if (!m_Content.ContainsKey(param))
            {
                m_Content.Add(param, new List<FilterParam>());
            }
            m_Content[param].Add(new FilterParam { operation = oper, value = val, isOr = or });
            return this;
        }

        public void Clear()
        {
            m_Content.Clear();
        }

        public bool Contains(string param)
        {
            if (param == ".true.") return true;
            return m_Content.ContainsKey(param);
        }

        public int Count(string param)
        {
            return m_Content[param].Count;
        }
        public string Operation(string param, int index = 0)
        {
            return m_Content[param][index].operation;
        }
        public object Value(string param, int index = 0)
        {
            return m_Content[param][index].value;
        }
        /*public string SqlType(string param, int index = 0)
        {
            switch (m_Content[param][index].value.GetType().Name)
            {
                case "String":
                    return "nvarchar(1024)";
                case "Int32":
                    return "int";
                case "Int64":
                    return "bigint";
                default:
                    return "nvarchar(1024)";
            }
        }*/
        public bool IsOr(string param, int index = 0)
        {
            return m_Content[param][index].isOr;
        }
        public int ValueCount(string param)
        {
            if (m_Content.ContainsKey(param))
            {
                return m_Content[param].Count();
            }
            else
            { return 0; }
        }

        public FilterParams Merge(FilterParams par)
        {
            if (par == null)
                return this;
            FilterParams curPar = new FilterParams();
            foreach (var param in par.m_Content.Keys)
            {
                for (int i = 0; i < par.ValueCount(param); i++)
                {
                    curPar.Add(param, par.Operation(param, i), par.Value(param, i), par.IsOr(param, i));
                }
            }
            foreach (var param in m_Content.Keys)
            {
                for(int i = 0; i< ValueCount (param);i++)
                {
                    curPar.Add(param, Operation(param, i), Value(param, i), IsOr(param, i));
                }
            }

            return curPar;
        }

        public int FiltersCount { get { return m_Content.Count; } }

        public string Serialize()
        {
            return StringSerializator.SerializeObject(this);
        }

        public static FilterParams Deserialize(string data)
        {
            return data == null ? null : StringSerializator.DeserializeObject<FilterParams>(data);
        }


        /*public void AddParameter(string field, DbManagerProxy manager)
        {
            if (Contains(field))

                if (Count(field) == 1)
                {
                    manager.SelectCommand.Parameters.Add(manager.InputParameter("@" + field, ParsingHelper.CorrectLikeValue(Operation(field), Value(field))));
                }
                else
                {
                    for (int i = 0; i < Count(field); i++)
                        manager.SelectCommand.Parameters.Add(manager.InputParameter("@" + field + "_" + i, ParsingHelper.CorrectLikeValue(Operation(field, i), Value(field, i))));
                }
        }*/
    }
}
