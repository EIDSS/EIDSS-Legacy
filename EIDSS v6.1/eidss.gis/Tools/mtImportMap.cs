using System;
using System.IO;
using System.Windows.Forms;
using bv.model.Model.Core;
using bv.winclient.Core;
using eidss.gis.Properties;
using eidss.gis.Utils;
using eidss.model.Resources;
using GIS_V4.Tools;

namespace eidss.gis.Tools
{

    //TODO[enikulin]: Need code review! Change zip lib!
    //TODO[enikulin]: UserLayers save case!

    public class MtImportMap : CommandMapTool
    {

        public MtImportMap()
        {
            var temp = Resources.importMap;
            temp.MakeTransparent();
            m_Image = temp;

            m_Caption = Resources.gis_MtImportMap_Caption;
            m_ToolTipText = Resources.gis_MtImportMap_ToolTipText;
        }

        protected override void OnClick()
        {
            var strTitle = EidssMessages.GetForCurrentLang("gis_Caption_SaveOpenMpk", "Select map pack");
            var strFilter = EidssMessages.GetForCurrentLang("gis_FilterMpk", "Map pack files | *.mpk");
            var strError = EidssMessages.GetForCurrentLang("gis_OpenMpkError", "Map can't be imported!");
            var strComplete = EidssMessages.GetForCurrentLang("gis_OpenMpkComplete", "Map has been successfully imported!");
            var strCompleteTitle = EidssMessages.GetForCurrentLang("gis_MpkCompleteTitle", "EIDDS Maps");


            var openFileDialog = new OpenFileDialog {Title = strTitle, Filter = strFilter};

            if (openFileDialog.ShowDialog(null) == DialogResult.OK)
            {
                try
                {
                    var outPath = Path.Combine(MapProjectsStorage.CustomProjectsPath);
                    MapPacker.UnpackMap(openFileDialog.FileName, outPath, selectNewName);
                    MapProjectsStorage.UpdateMapProjectList();
                    MessageForm.Show(strComplete, strCompleteTitle, MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    ErrorForm.ShowError(strError, ex);
                }

            }         

        }

        private static bool selectNewName(ref string mapName)
        {
            string message = EidssMessages.Get("gis_Message_SaveMapExist",
                                               "Map with that name already exists. Do you want to save map under a different name?",
                                               ModelUserContext.CurrentLanguage);
            string caption = EidssMessages.Get("Save", "Save", ModelUserContext.CurrentLanguage);
            string title = EidssMessages.Get("gis_Caption_SaveMap", "Select map name", ModelUserContext.CurrentLanguage);
            string strFilter = EidssMessages.Get("gis_Filter_Map", "Map files | *.map", ModelUserContext.CurrentLanguage);

            var result = MessageForm.Show(message, caption, MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                return false;
            else
            {
                var saveFileDialog = new SaveFileDialog
                                         {
                                             Title = title,
                                             OverwritePrompt = true,
                                             Filter = strFilter,
                                             InitialDirectory = MapProjectsStorage.CustomProjectsPath
                                         };

                if (saveFileDialog.ShowDialog(null) == DialogResult.OK)
                    mapName = saveFileDialog.FileName;
                return true;
            }
        }
    }

}
