using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using bv.common;
using eidss.gis.Forms;
using eidss.gis.Properties;
using eidss.gis.Serializers;
using eidss.gis.Utils;
using eidss.model.Resources;
using GIS_V4.Tools;
using bv.winclient.Core;

namespace eidss.gis.Tools
{

    public class MtSaveMap : CommandMapTool
    {

        public MtSaveMap()
        {
            Bitmap temp = Resources.mActionFileSave;
            temp.MakeTransparent();
            m_Image = temp;

            m_Caption = Resources.gis_MtSaveMap_Caption;
            m_ToolTipText = Resources.gis_MtSaveMap_ToolTipText;
        }


        protected override void OnClick()
        {

            string msg = EidssMessages.Get("gis_Message_SaveMap", "Would you like save customized map?", bv.model.Model.Core.ModelUserContext.CurrentLanguage);
            string caption = EidssMessages.Get("Save", "Save", bv.model.Model.Core.ModelUserContext.CurrentLanguage);
            if (MessageForm.Show(msg, caption, MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    var saveMapForm = new SaveMapForm();

                    var mapProjectListNoDefault = MapProjectsStorage.GetCustomMapsNames();

                    saveMapForm.SetMapList(mapProjectListNoDefault);
                    if (saveMapForm.ShowDialog() == DialogResult.OK)
                    {
                        if (saveMapForm.MapName == MapProjectsStorage.DefaultMapName)
                        {
                            //TODO: need localization
                            //string msg = EidssMessages.Get("gis_Message_SaveMap", "Would you like save customized map?", bv.model.Model.Core.ModelUserContext.CurrentLanguage);
                            //string caption = EidssMessages.Get("Save", "Save", bv.model.Model.Core.ModelUserContext.CurrentLanguage);
                            MessageForm.Show(Resources.gis_MtSaveMap_SaveOverDefaultError,
                                                           caption, MessageBoxButtons.OK,
                                                           MessageBoxIcon.Warning);
                            return;
                        }
                        EidssMapSerializer.Instance.SerializeAsFile(m_MapImage.Map, MapProjectsStorage.CustomProjectsPath + saveMapForm.MapName + ".map");
                        MapProjectsStorage.UpdateMapProjectList();

                        //may be more clear method for update?
                        if ( ((MapImage.Parent) as EidssMapControl) != null)
                            ((MapImage.Parent) as EidssMapControl).MapSelector.UpdateValue(saveMapForm.MapName);
                    }
                }
                catch (Exception ex)
                {
                    bv.common.win.ErrorForm.ShowError(new ErrorMessage(ex.Message, ex));
                }
        }
    }

}
