using System.Drawing;
using eidss.model.Enums;
using eidss.model.FlexibleForms.Helpers;

#if MONO
namespace System.Drawing
{
    public struct Size
    {
        public Size(int width, int height)
        {
            
        }
    }

    public struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

    }

    [Flags]
    public enum FontStyle
    {
        Regular = 0,
        Bold = 1,
        Italic = 2,
        Underline = 4,
        Strikeout = 8,
    }

}

#endif

namespace eidss.model.Schema
{
    public abstract partial class Parameter
    {
        /// <summary>
        /// Размер секции по умолчанию
        /// </summary>
        public static Size DefaultParameterSize
        {
            get { return new Size(200, 100); }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Size MaxParameterSize
        {
            get { return new Size(1000, 1000); }
        }

        /// <summary>
        /// Размер лейбла по умолчанию
        /// </summary>
        public static int DefaultLabelSize
        {
            get { return 23; }
        }

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
    }
}
