using eidss.model.Enums;
using eidss.model.FlexibleForms.Helpers;

namespace eidss.model.Schema
{
    public partial class ParameterTemplate
    {
        public int TopAbsolute { get; set; }

        /// <summary>
        /// Стандартная схема параметра
        /// </summary>
        public FFParameterScheme Scheme
        {
            get { return ParameterSchemeHelper.ConvertToParameterScheme(intScheme); }
        }

        /// <summary>
        /// Компонент управления в этом параметре
        /// </summary>
        public FFParameterEditors Editor
        {
            get { return ParameterControlTypeHelper.ConvertToParameterControlType(idfsEditor); }
        }

        public FFParameterTypes ParameterType
        {
            get { return ParameterTypeHelper.ConvertToParameterType(idfsParameterType); }
        }

        /// <summary>
        /// Определяет, является ли тип данных параметра числовым
        /// </summary>
        /// <returns></returns>
        public bool IsParameterNumeric()
        {
            var result = false;
            if (idfsParameterType.HasValue)
            {
                var parameterType = idfsParameterType.Value;

                if (
                    parameterType.Equals((long) FFParameterTypes.Numeric)
                    || parameterType.Equals((long) FFParameterTypes.NumericNatural)
                    || parameterType.Equals((long) FFParameterTypes.NumericPositive)
                    || parameterType.Equals((long) FFParameterTypes.NumericInteger)
                    ) result = true;
            }

            return result;
        }

        /// <summary>
        /// Определяет, является ли тип данных параметра числовым
        /// </summary>
        /// <returns></returns>
        public bool IsParameterNumericPositive()
        {
            var result = false;
            if (idfsParameterType.HasValue)
            {
                var parameterType = idfsParameterType.Value;

                if (
                    parameterType.Equals((long)FFParameterTypes.NumericPositive)
                    ) result = true;
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsParameterDate()
        {
            if (idfsParameterType.HasValue)
            {
                var parameterType = idfsParameterType.Value;
                return parameterType.Equals((long) FFParameterTypes.Date);
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsParameterDateTime()
        {
            if (idfsParameterType.HasValue)
            {
                var parameterType = idfsParameterType.Value;
                return parameterType.Equals((long)FFParameterTypes.DateTime);
            }
            return false;
        }

        /// <summary>
        /// Определяет, является ли тип данных параметра относящимся к выпадающим спискам
        /// </summary>
        /// <returns></returns>
        public bool IsParameterComboBox()
        {
            var result = false;
            if (idfsParameterType.HasValue)
            {
                var parameterType = idfsParameterType.Value;

                if (!(
                    (parameterType.Equals((long)FFParameterTypes.Boolean))
                    || (parameterType.Equals((long)FFParameterTypes.Date))
                    || (parameterType.Equals((long)FFParameterTypes.DateTime))
                    || (IsParameterNumeric())
                    || (parameterType.Equals((long)FFParameterTypes.String))
                    )
                    ) result = true;
            }

            return result;
        }
        
        public bool IsMandatory()
        {
            return idfsEditMode.Equals(((long)FFEditModes.Required));
        }
    }
}
