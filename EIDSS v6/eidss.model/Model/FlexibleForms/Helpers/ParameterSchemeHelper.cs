using System;
using eidss.model.Enums;

namespace eidss.model.FlexibleForms.Helpers
{
    /// <summary>
    /// Помощник для работы со схемами параметров
    /// </summary>
    public static class ParameterSchemeHelper
    {
        public static int ConvertToInt(this FFParameterScheme ps)
        {
            return Convert.ToInt32(ps);
        }

        /// <summary>
        /// Проверяет, относится ли установленная схема к горизонтальным
        /// </summary>
        /// <param name="ps"></param>
        /// <returns></returns>
        public static bool IsHorizontalOrientation(this FFParameterScheme ps)
        {
            return ((ps == FFParameterScheme.Left) || (ps == FFParameterScheme.Right));
        }

        /// <summary>
        /// Проверяет, относится ли установленная схема к горизонтальным
        /// </summary>
        /// <param name="ps"></param>
        /// <returns></returns>
        public static bool IsHorizontalOrientation(int ps)
        {
            return IsHorizontalOrientation(ConvertToParameterScheme(ps));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ps"></param>
        /// <returns></returns>
        public static FFParameterScheme ConvertToParameterScheme(int ps)
        {
            FFParameterScheme result = FFParameterScheme.Left;

            switch (ps)
            {
                case 0:
                    result = FFParameterScheme.Left;
                    break;
                case 1:
                    result = FFParameterScheme.Right;
                    break;
                case 2:
                    result = FFParameterScheme.Top;
                    break;
                case 3:
                    result = FFParameterScheme.Bottom;
                    break;
            }

            return result;
        }
    }
}
