using System;
using System.Collections.Generic;
using System.Windows.Forms;
using bv.common;
using bv.winclient.Core;
using eidss.gis.Data;
using eidss.gis.Forms;
using eidss.gis.Properties;
using eidss.gis.Tools.ToolForms;
using GIS_V4.Tools;

namespace eidss.gis.Tools
{
    public class MtAddBufZonesLayer : CommandMapTool
    {
        public MtAddBufZonesLayer()
        {
            var temp = Resources.add_buff_24x24;
            temp.MakeTransparent();
            m_Image = temp;

            m_Caption = Resources.gis_MtAddBufZonesLayer_Caption;
            m_ToolTipText = Resources.gis_MtAddBufZonesLayer_ToolTipText;
        }

        public delegate void CreateBufZoneLayerHandler(KeyValuePair<Guid, string> e);

        public event CreateBufZoneLayerHandler OnCreateBufZone;
        

        protected override void OnClick()
        {
            var bufZonesLayer = new BufZonesLayer {IsAVR = m_MapImage.Parent is AvrMapControl};
            if (bufZonesLayer.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    var eidssUserBufZoneLayer = UserDbLayersManager.CreateBufZoneLayer(bufZonesLayer.ZoneLayerName,
                                                                                       bufZonesLayer.Description,
                                                                                       bufZonesLayer.PivotalLayer);
                    //MapImage.Map.Layers.Add(eidssUserBufZoneLayer);

                    if (OnCreateBufZone != null)
                        OnCreateBufZone(new KeyValuePair<Guid, string>(eidssUserBufZoneLayer.LayerDbGuid,
                                                                       eidssUserBufZoneLayer.LayerName));
                    //MapControl.RefreshContent();
                    MapImage.Refresh();
                    //ZoneLayerStorage.UpdateZoneLayerDict(); //not need more
                }
                catch (Exception ex)
                {
                    ErrorForm.ShowError(ex);
                }
                
            }
        }
    }
}
