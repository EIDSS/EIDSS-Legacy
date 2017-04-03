using eidss.model.Enums;

namespace eidss.model.FlexibleForms.Helpers
{
    public static class ParameterTypeHelper
    {
        public static FFParameterTypes ConvertToParameterType(long? parameterType)
        {
            FFParameterTypes result = FFParameterTypes.String;

            switch (parameterType)
            {
                case 10071025:
                    result = FFParameterTypes.Boolean;
                    break;
                case 10071007:
                    result = FFParameterTypes.Numeric;
                    break;
                case 10071059:
                    result = FFParameterTypes.NumericNatural;
                    break;
                case 10071060:
                    result = FFParameterTypes.NumericPositive;
                    break;
                case 10071061:
                    result = FFParameterTypes.NumericInteger;
                    break;
                case 10071045:
                    result = FFParameterTypes.String;
                    break;
                case 10071030:
                    result = FFParameterTypes.DateTime;
                    break;
                case 10071029:
                    result = FFParameterTypes.Date;
                    break;
                default:
                    result = FFParameterTypes.String;
                    break;
            }
            return result;
        }
    }
}
