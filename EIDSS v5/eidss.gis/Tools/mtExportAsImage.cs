using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using bv.model.Model.Core;
using eidss.gis.Properties;
using eidss.model.Resources;
using GIS_V4.Tools;

namespace eidss.gis.Tools
{

    //TODO[enikulin]: Need code review! Change zip lib!
    //TODO[enikulin]: UserLayers save case!

    public class MtExportAsImage : CommandMapTool
    {

        public MtExportAsImage()
        {
            Bitmap temp = Resources.mActionSaveMapAsImage;
            temp.MakeTransparent();
            m_Image = temp;

            m_Caption = Resources.gis_MtExportAsImage_Caption;
            m_ToolTipText = Resources.gis_MtExportAsImage_ToolTipText;
        }

        protected override void OnClick()
        {
            
            //need add new extensions
            var strFilter = EidssMessages.Get("gis_FilterJpg", "JPEG Files|*.jpg", ModelUserContext.CurrentLanguage);

            var saveFileDialog = new SaveFileDialog {Filter = strFilter, DefaultExt = "jpg"};
            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var bitmap = m_MapImage.GetMapImage(297, 210, 300);
                bitmap.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
            }
        }
    }

}
