using System;
using System.Data;
using System.Drawing;

namespace eidss.model.Model.FlexibleForms.Helpers
{
    public static class HelperFunctions
    {
        /// <summary>
        /// Определение стиля шрифта
        /// </summary>
        /// <param name="intFontStyle"></param>
        /// <returns></returns>
        public static FontStyle ConvertToFontStyle(int intFontStyle)
        {
            var result = FontStyle.Regular;
            switch (intFontStyle)
            {
                case 1:
                    result = FontStyle.Bold;
                    break;
                case 2:
                    result = FontStyle.Italic;
                    break;
                case 8:
                    result = FontStyle.Strikeout;
                    break;
                case 4:
                    result = FontStyle.Underline;
                    break;
            }
            return result;
        }

        /// <summary>
        /// Определяет, принадлежит ли столбец боковику
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public static bool IsStubColumn(DataColumn column)
        {
            const string typeKey = "columnType";
            if ((!column.ExtendedProperties.ContainsKey(typeKey))) return false;

            var otkey = column.ExtendedProperties[typeKey];
            if (otkey == null) return false;
            return Convert.ToInt32(otkey) == 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public static int GetColumnWidth(DataColumn column)
        {
            const string widthKey = "width";
            if ((!column.ExtendedProperties.ContainsKey(widthKey))) return 0;

            var width = column.ExtendedProperties[widthKey];
            return width == null ? 0 : Convert.ToInt32(width);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public static long GetColumnParameter(DataColumn column)
        {
            const string paramKey = "idfsParameter";
            if ((!column.ExtendedProperties.ContainsKey(paramKey))) return 0;

            var idfsParameter = column.ExtendedProperties[paramKey];
            return idfsParameter == null ? 0 : Convert.ToInt64(idfsParameter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public static long GetColumnSection(DataColumn column)
        {
            const string sectionKey = "idfsSection";
            if ((!column.ExtendedProperties.ContainsKey(sectionKey))) return 0;

            var idfsSection = column.ExtendedProperties[sectionKey];
            return idfsSection == null ? 0 : Convert.ToInt64(idfsSection);
        }

        /// <summary>
        /// Получает уникальный ключ для значения на веб-форме, чтобы его можно было однозначно распарсить на HttpPost
        /// </summary>
        public static string GetParameterKey(long idfObservation, long idfsParameter, long idfRow, long key)
        {
            //Key - ИД корневого объекта, которому принадлежит ФФ (например, Human Case, Vet Case, Vs Session)
            return String.Format("{0}_p{1}_r{2}_k{3}", GetParameterKeyObservationPart(idfObservation), idfsParameter, idfRow, key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idfObservation"></param>
        /// <returns></returns>
        public static string GetParameterKeyObservationPart(long idfObservation)
        {
            return String.Format("o{0}", idfObservation);
        }
    }
}
