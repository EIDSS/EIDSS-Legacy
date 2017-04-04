using System.Drawing;
using System.Windows.Forms;
using bv.winclient.Core;

namespace eidss.avr.PivotComponents
{
    public partial class AvrFieldIcons : BvXtraUserControl
    {
        private static readonly AvrFieldIcons m_Instance;
        private static readonly ImageList m_ImageList;

        private static Image m_StringImage;
        private static Image m_IntegerImage;
        private static Image m_DateImage;
        private static Image m_BooleanImage;
        private static Image m_FloatImage;

        private static Image m_StringBorderedImage;
        private static Image m_IntegerBorderedImage;
        private static Image m_DateBorderedImage;
        private static Image m_BooleanBorderedImage;
        private static Image m_FloatBorderedImage;

        public const string BorderedImageSuffix  = "_Bordered";

        static AvrFieldIcons()
        {
            m_Instance = new AvrFieldIcons();
            m_ImageList = new ImageList {TransparentColor = Color.Transparent};
            m_ImageList.Images.Add("System.String", StringImage);
            m_ImageList.Images.Add("System.Int32", IntegerImage);
            m_ImageList.Images.Add("System.Int64", IntegerImage);
            m_ImageList.Images.Add("System.Decimal", FloatImage);
            m_ImageList.Images.Add("System.Single", FloatImage);
            m_ImageList.Images.Add("System.Double", FloatImage);
            m_ImageList.Images.Add("System.Float", FloatImage);
            m_ImageList.Images.Add("System.DateTime", DateImage);
            m_ImageList.Images.Add("System.Boolean", BooleanImage);

            m_ImageList.Images.Add("System.String" + BorderedImageSuffix, StringBorderedImage);
            m_ImageList.Images.Add("System.Int32" + BorderedImageSuffix, IntegerBorderedImage);
            m_ImageList.Images.Add("System.Int64" + BorderedImageSuffix, IntegerBorderedImage);
            m_ImageList.Images.Add("System.Decimal" + BorderedImageSuffix, FloatBorderedImage);
            m_ImageList.Images.Add("System.Single" + BorderedImageSuffix, FloatBorderedImage);
            m_ImageList.Images.Add("System.Double" + BorderedImageSuffix, FloatBorderedImage);
            m_ImageList.Images.Add("System.Float" + BorderedImageSuffix, FloatBorderedImage);
            m_ImageList.Images.Add("System.DateTime" + BorderedImageSuffix, DateBorderedImage);
            m_ImageList.Images.Add("System.Boolean" + BorderedImageSuffix, BooleanBorderedImage);

        }

        private AvrFieldIcons()
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

        public static Image StringBorderedImage
        {
            get { return m_StringBorderedImage ?? (m_StringBorderedImage = m_Instance.InternalImageList.Images[4]); }
        }
        public static Image IntegerBorderedImage
        {
            get { return m_IntegerBorderedImage ?? (m_IntegerBorderedImage = m_Instance.InternalImageList.Images[5]); }
        }

        public static Image FloatBorderedImage
        {
            get { return m_FloatBorderedImage ?? (m_FloatBorderedImage = m_Instance.InternalImageList.Images[5]); }
        }

        public static Image DateBorderedImage
        {
            get { return m_DateBorderedImage ?? (m_DateBorderedImage = m_Instance.InternalImageList.Images[6]); }
        }

        public static Image BooleanBorderedImage
        {
            get { return m_BooleanBorderedImage ?? (m_BooleanBorderedImage = m_Instance.InternalImageList.Images[7]); }
        }


        public static ImageList ImageList
        {
            get { return m_ImageList; }
        }

        private ImageList InternalImageList
        {
            get { return m_InternalImageList; }
        }
    }
}