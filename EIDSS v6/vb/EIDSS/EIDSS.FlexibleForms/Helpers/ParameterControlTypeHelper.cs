using System;
using bv.common;

namespace EIDSS.FlexibleForms.Helpers
{
    /// <summary>
    /// Помощник для работы с управляющими компонентами параметров
    /// </summary>
    public static class ParameterControlTypeHelper
    {
        public static int ConvertToInt(this FFParameterEditors pc)
        {
            return Convert.ToInt32(pc);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idfsEditor"></param>
        /// <returns></returns>
        public static FFParameterEditors ConvertToParameterControlType(long? idfsEditor)
        {
            var result = FFParameterEditors.TextBox;

            switch (idfsEditor)
            {
                case 10067008 /*"editText"*/:
                    result = FFParameterEditors.TextBox;
                    break;
                case 10067002/*"editCombo"*/:
                    result = FFParameterEditors.ComboBox;
                    break;
                case 10067001/*"editCheck"*/:
                    result = FFParameterEditors.CheckBox;
                    break;
                case 10067003/*"editDate"*/:
                    result = FFParameterEditors.Date;
                    break;
                case 10067004/*"editDateTime"*/:
                    result = FFParameterEditors.DateTime;
                    break;
                case 10067006/*"editMemo"*/:
                    result = FFParameterEditors.Memo;
                    break;
                case 10067009/*"editUpDown"*/:
                    result = FFParameterEditors.UpDown;
                    break;
            }

            return result;
        }
    }
}
