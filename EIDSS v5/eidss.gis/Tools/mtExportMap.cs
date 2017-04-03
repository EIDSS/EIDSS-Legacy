using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using bv.winclient.Core;
using eidss.gis.Forms;
using eidss.gis.Properties;
using eidss.gis.Utils;
using eidss.model.Resources;
using GIS_V4.Tools;
using ICSharpCode.SharpZipLib.Zip;

namespace eidss.gis.Tools
{

    //TODO[enikulin]: Need code review! Change zip lib!
    //TODO[enikulin]: UserLayers save case!

    public class MtExportMap : CommandMapTool
    {

        public MtExportMap()
        {
            Bitmap temp = Resources.exportMap;
            temp.MakeTransparent();
            m_Image = temp;

            m_Caption = Resources.gis_MtExportMap_Caption;
            m_ToolTipText = Resources.gis_MtExportMap_ToolTipText;
        }

        protected override void OnClick()
        {
            if (ZipConstants.DefaultCodePage == 1)
                ZipConstants.DefaultCodePage = 437; //bug in OEMCodePage property TODO[enikulin]: is it need?

            var strTitle = EidssMessages.GetForCurrentLang("gis_Caption_SaveOpenMpk", "Select map pack");
            var strFilter = EidssMessages.GetForCurrentLang("gis_FilterMpk", "Map pack files | *.mpk");
            var strError = EidssMessages.GetForCurrentLang("gis_SaveMpkError", "Map can't be saved!");
            var strComplete = EidssMessages.GetForCurrentLang("gis_SaveMpkComplete", "Map has been successfully exporting!");
            var strCompleteTitle = EidssMessages.GetForCurrentLang("gis_MpkCompleteTitle", "EIDDS Maps");


            var saveFileDialog = new SaveFileDialog {Title = strTitle, OverwritePrompt = true, Filter = strFilter};

            if (saveFileDialog.ShowDialog(null) == DialogResult.OK)
            {
                try
                {
                    var map = m_MapImage.Map;
                    using (new TemporaryWaitCursor())
                    {
                        MapPacker.PackMap(map, Path.GetFileNameWithoutExtension(saveFileDialog.FileName),
                                          saveFileDialog.FileName);
                    }
                    MessageForm.Show(strComplete, strCompleteTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    //TODO[enikulin]: Change this code!
                    //(new EIDSSErrorMessage("errCantSaveMap", strError, ex)
                    ErrorForm.ShowError(strError,ex);
                }

            }            

        }
    }

}
