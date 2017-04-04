using System;
using bv.common.Core;

namespace eidss.model.Schema
{
    public partial class ActivityParameter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return varValue != null ? varValue.ToString() : String.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string ToString(ActivityParameter activityParameter)
        {
            return
                activityParameter != null
                    ? activityParameter.varValue != null ? activityParameter.varValue.ToString() : String.Empty
                    : String.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetUserValue()
        {
            return Utils.IsEmpty(strNameValue) ? ToString() : strNameValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ToInt()
        {
            return varValue != null ? Convert.ToInt32(varValue) : 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int ToInt(ActivityParameter activityParameter)
        {
            return
                activityParameter != null
                    ? activityParameter.varValue != null ? Convert.ToInt32(activityParameter.varValue) : 0
                    : 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime ToDateTime()
        {
            return varValue != null ? Convert.ToDateTime(varValue) : DateTime.Now;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DateTime ToDateTime(ActivityParameter activityParameter)
        {
            return
                activityParameter != null
                    ? activityParameter.varValue != null ? Convert.ToDateTime(activityParameter.varValue) : DateTime.Now
                    : DateTime.Now;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public long ToLong()
        {
            return varValue != null ? Convert.ToInt64(varValue) : 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static long ToLong(ActivityParameter activityParameter)
        {
            long result = 0;
            if ((activityParameter != null) && (activityParameter.varValue != null))
            {
                result = activityParameter.varValue.ToString().Length > 0
                             ? Convert.ToInt64(activityParameter.varValue)
                             : 0;
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime ToDate()
        {
            return varValue != null ? Convert.ToDateTime(varValue).Date : DateTime.Now.Date;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DateTime ToDate(ActivityParameter activityParameter)
        {
            return
                activityParameter != null
                    ? activityParameter.varValue != null
                          ? Convert.ToDateTime(activityParameter.varValue).Date
                          : DateTime.Now.Date
                    : DateTime.Now.Date;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ToBool()
        {
            return varValue != null && Convert.ToBoolean(varValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool ToBool(ActivityParameter activityParameter)
        {
            return
                activityParameter != null && (activityParameter.varValue != null && Convert.ToBoolean(activityParameter.varValue));
        }

        /// <summary>
        /// Увеличивает значение поля, чтобы указать движку, что объект поменялся (это костыль, пока не работает правильно движок)
        /// </summary>
        public void IncreaseFakeField()
        {
            if (Utils.IsEmpty(FakeField))
                FakeField = 1;
            else
                FakeField++;
        }

        /// <summary>
        /// Выставляется в true, если этому параметру присваивались какие-то реальные значения
        /// </summary>
        //public bool HasRealChanges { get; set; }
        private bool m_bHasRealChanges;
        public bool HasRealChanges
        {
            get
            {
                return m_bHasRealChanges;
            }
            set
            {
                m_bHasRealChanges = value;
                if (value) SetChange();
            }
        }
    }
}
