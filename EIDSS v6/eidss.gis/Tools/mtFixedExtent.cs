using System.Drawing;
using GIS_V4.Tools;
using SharpMap.Geometries;
using eidss.gis.Properties;

namespace eidss.gis.Tools
{
    
    public class MtFixedExtent : CommandMapTool
    {
        public BoundingBox Extent { get; set; }

        public MtFixedExtent()
        {
            Bitmap temp = Resources.mActionZoomFullExtent;
            temp.MakeTransparent();
            m_Image = temp;

            m_Caption = Resources.gis_mtFixedExtent_Caption;
            m_ToolTipText = Resources.gis_MtFixedExtent_ToolTipText;
        }

        protected override void OnClick()
        {
            if (m_MapImage != null && m_MapImage.Map != null && m_MapImage.Map.Layers.Count > 0)
            {
                m_MapImage.Map.ZoomToBox(Extent);
                m_MapImage.Refresh();
            }
        }

    }
}
