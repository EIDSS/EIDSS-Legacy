using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EIDSS.RAM_DB.Components;
using bv.common.Core;
using EIDSS.Enums;
using EIDSS.RAM_DB.Common;

namespace EIDSS.RAM.Components
{
    public partial class RamFieldIcons : UserControl
    {
        private static readonly RamFieldIcons m_Instance;
        private static readonly ImageList m_ImageList;
        private static Dictionary<string, Type> m_FieldDataTypes;
        private static Image m_StringImage;
        private static Image m_IntegerImage;
        private static Image m_DateImage;
        private static Image m_BooleanImage;
        private static Image m_FloatImage;

        static RamFieldIcons()
        {
            m_Instance = new RamFieldIcons();
            m_ImageList = new ImageList(m_Instance.components) {TransparentColor = Color.Transparent};
            m_ImageList.Images.Add("System.String", StringImage);
            m_ImageList.Images.Add("System.Int32", IntegerImage);
            m_ImageList.Images.Add("System.Int64", IntegerImage);
            m_ImageList.Images.Add("System.Decimal", FloatImage);
            m_ImageList.Images.Add("System.Single", FloatImage);
            m_ImageList.Images.Add("System.Double", FloatImage);
            m_ImageList.Images.Add("System.Float", FloatImage);
            m_ImageList.Images.Add("System.DateTime", DateImage);
            m_ImageList.Images.Add("System.Boolean", BooleanImage);
        }

        private RamFieldIcons()
        {
            InitializeComponent();
        }

        public static Size ImageSize
        {
            get { return m_Instance.InternalImageList.ImageSize; }
        }

        public static Image StringImage
        {
            get { return m_StringImage ?? (m_StringImage = m_Instance.InternalImageList.Images[0]); }
        }

        public static Image IntegerImage
        {
            get { return m_IntegerImage ?? (m_IntegerImage = m_Instance.InternalImageList.Images[1]); }
        }

        public static Image FloatImage
        {
            get { return m_FloatImage ?? (m_FloatImage = m_Instance.InternalImageList.Images[1]); }
        }

        public static Image DateImage
        {
            get { return m_DateImage ?? (m_DateImage = m_Instance.InternalImageList.Images[2]); }
        }

        public static Image BooleanImage
        {
            get { return m_BooleanImage ?? (m_BooleanImage = m_Instance.InternalImageList.Images[3]); }
        }

        public static ImageList ImageList
        {
            get { return m_ImageList; }
        }

        private ImageList InternalImageList
        {
            get { return m_InternalImageList; }
        }

        public static Type GetFieldType(string fieldName)
        {
            if ((m_FieldDataTypes == null) || (!m_FieldDataTypes.ContainsKey(fieldName)))
            {
                DataTable lookupTable = QueryLookupHelper.GetQueryLookupTable();
                m_FieldDataTypes = GetFieldDataTypes(lookupTable);
            }
            if (!m_FieldDataTypes.ContainsKey(fieldName))
            {
                throw new RamException("Cannot load type for field " + fieldName);
            }
            return m_FieldDataTypes[fieldName];
        }

        internal static Dictionary<string, Type> GetFieldDataTypes(DataTable lookupTable)
        {
            var result = new Dictionary<string, Type>();
            foreach (KeyValuePair<string, SearchFieldType> pair in QueryLookupHelper.GetFieldTypes(lookupTable))
            {
                Type value;
                switch (pair.Value)
                {
                    case SearchFieldType.Bit:
                        value = typeof (bool);
                        break;
                    case SearchFieldType.Date:
                        value = typeof (DateTime);
                        break;
                    case SearchFieldType.Float:
                        value = typeof (float);
                        break;
                    case SearchFieldType.ID:
                    case SearchFieldType.Integer:
                        value = typeof (long);
                        break;
                    default:
                        value = typeof (string);
                        break;
                }
                result.Add(pair.Key, value);
                result.Add(pair.Key + RamPivotGridHelper.CopySuffix, value);
            }
            return result;
        }
    }
}