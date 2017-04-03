namespace eidss.webui.Areas.FlexForms.Models.FlexNodes
{
    /// <summary>
    /// base class for item that represents flex form entity
    /// </summary>
    public class FlexItem
    {
        public FlexItem(object ffObject)
        {
            LinkedObject = ffObject;
        }

        //private int mWidth = ReportSettings.DefaultItemWidth;
        //private int mHeight = ReportSettings.DefaultItemHeight;
        //private int mTop;
        //private int mLeft;
        //private Color mColor = ReportSettings.DefaultItemColor;

        /// <summary>
        /// 
        /// </summary>
        public int Order { get; protected set; }

        /// <summary>
        /// Связанный объект
        /// </summary>
        public object LinkedObject { get; protected set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public Color Color
        //{
        //    get { return mColor; }
        //    protected set { mColor = value; }
        //}

        //public int Width
        //{
        //    get { return mWidth; }
        //    set { mWidth = value; }
        //}

        //public int Height
        //{
        //    get { return mHeight; }
        //    internal set { mHeight = value; }
        //}

        //public int Top
        //{
        //    get { return mTop; }
        //    internal set { mTop = value; }
        //}

        //public int Left
        //{
        //    get { return mLeft; }
        //    protected set { mLeft = value; }
        //}
    }
}