using eidss.gis.Forms;
using eidss.gis.Properties;
using GIS_V4.Forms;
using GIS_V4.Tools;

namespace eidss.gis.Tools
{
    public class MtAddDbLayer : CommandMapTool
    {
        public MtAddDbLayer()
        {
            var temp = Resources.mActionAddLayer;
            temp.MakeTransparent();
            m_Image = temp;

            m_Caption = Resources.gis_mtAddDbLayer_Caption;
            m_ToolTipText = Resources.gis_mtAddDbLayer_ToolTipText;
        }

        
        /// <summary>
        /// Related MapContent control
        /// </summary>
        public MapContent MapContent { get; set; }

        protected override void OnClick()
        {
            var layer = DbLayersForm.SelectDbLayer();
            if (layer != null)
            {
                m_MapImage.Map.Layers.Add(layer);
                m_MapImage.Map.Layers.Add(layer.LabelLayer);

                if(m_MapImage!=null)
                    m_MapImage.Refresh();
                if(MapContent!=null)
                    MapContent.RefreshMapContent();

            }

        }
    }
}

