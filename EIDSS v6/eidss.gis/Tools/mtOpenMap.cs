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
using eidss.gis.common;
using eidss.model.Resources;

namespace eidss.gis.Tools
{
    public class MtOpenMap : CommandMapTool
    {
        public MtOpenMap()
        {
            Bitmap temp = Resources.open_icon;
            temp.MakeTransparent();
            m_Image = temp;

            m_Caption = EidssMessages.GetForCurrentLang("gis_Tools_OpenMapProject_Caption", "Open Map Project");// "Open Map Project"; //Resources.gis_MtSaveMap_Caption;
            m_ToolTipText = EidssMessages.GetForCurrentLang("gis_Tools_OpenMapProject_Text", "Open Map Project");// "Open Map Project"; //Resources.gis_MtSaveMap_ToolTipText;
        }

        protected override void OnClick()
        {
            // Open map form
            if (MapImage != null)
            {
                var mapControl = MapImage.Parent;
                if (mapControl != null)
                {
                    var mapForm = mapControl.Parent;
                    if (mapForm != null & mapForm is CustomizeMapForm)
                    {
                        ((CustomizeMapForm) mapForm).OpenMapProject();
                    }
                }
            }
        }
    }
}
