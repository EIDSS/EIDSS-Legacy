using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GIS_V4.Tools;
using bv.winclient.Core;
using eidss.gis.Forms;
using eidss.gis.Properties;
using eidss.gis.Serializers;
using eidss.gis.Utils;
using eidss.model.Resources;

namespace eidss.gis.Tools
{
    public class MtSaveMapAs : CommandMapTool
    {
        
        public MtSaveMapAs()
        {
            Bitmap temp = Resources.save_as_icon;
            temp.MakeTransparent();
            m_Image = temp;

            m_Caption = EidssMessages.GetForCurrentLang("gis_Tools_SaveMapProjectAs_Caption", "Save Map Project As");
            m_ToolTipText = EidssMessages.GetForCurrentLang("gis_Tools_SaveMapProjectAs_Text", "Save Map Project As");

            //m_Caption = "Save Map Project As"; //Resources.gis_MtSaveMap_Caption;
            //m_ToolTipText = "Save Map Project As"; //Resources.gis_MtSaveMap_ToolTipText;
        }


        protected override void OnClick()
        {
            // set map project state to New condition
            if (MapImage != null)
            {
                var mapControl = MapImage.Parent;
                if (mapControl != null)
                {
                    var mapForm = mapControl.Parent;
                    if (mapForm != null & mapForm is CustomizeMapForm)
                        ((CustomizeMapForm) mapForm).SaveMapProject(true);
                }
            }
        }

    }
}
