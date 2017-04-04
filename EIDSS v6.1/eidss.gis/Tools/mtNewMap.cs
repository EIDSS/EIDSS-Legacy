using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using eidss.model.Resources;
using GIS_V4.Tools;
using bv.winclient.Core;
using eidss.gis.Forms;
using eidss.gis.Properties;
using eidss.gis.Utils;
using eidss.gis.common;

namespace eidss.gis.Tools
{
    public class MtNewMap : CommandMapTool
    {
        public MtNewMap()
        {
            Bitmap temp = Resources.new_icon;
            temp.MakeTransparent();
            m_Image = temp;

            m_Caption = EidssMessages.GetForCurrentLang("gis_Tools_NewMapProject_Caption", "New Map Project"); //"New Map Project"; //Resources.gis_MtSaveMap_Caption;
            m_ToolTipText = EidssMessages.GetForCurrentLang("gis_Tools_NewMapProject_Text", "New Map Project"); //"New Map Project"; //Resources.gis_MtSaveMap_ToolTipText;
        }

        private void CreateNewProject(CustomizeMapForm mapForm)
        {
            mapForm.Text = EidssMessages.GetForCurrentLang("gis_Form_NewMapProject_Text", "New Map Project"); ;
            var mapFileName = MapProjectsStorage.DefaultMapPath;
            mapForm.mapControl.LoadMap(mapFileName);
            mapForm.m_BeforeFirstSaving = true;
            mapForm.UpdateMapStateXml();
            mapForm.mapControl.m_mapImage.Refresh();
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
                    {
                        if (((CustomizeMapForm) mapForm).GetMapProjectState() == MapUtils.MapProjectState.Unsaved)
                        {
                            var msg = EidssMessages.GetForCurrentLang("gis_Form_NewMapProject_SaveMsg", "Would you like to save changes of the current Map Project?");
                                //"Would you like to save changes of the current Map Project?";
                            var caption = "";
                            var dr = MessageForm.Show(msg, caption, MessageBoxButtons.YesNoCancel,
                                                      MessageBoxIcon.Question);
                            if (dr == DialogResult.Yes)
                            {
                                if (((CustomizeMapForm) mapForm).SaveMapProject(false))
                                {
                                    // create new
                                    CreateNewProject((CustomizeMapForm) mapForm);
                                }
                            }
                            else if (dr == DialogResult.No)
                            {
                                CreateNewProject((CustomizeMapForm)mapForm);
                            }
                        }
                        else
                        {
                            // create new
                            CreateNewProject((CustomizeMapForm)mapForm);
                        }
                    }
                }
            }
        }
    }
}
