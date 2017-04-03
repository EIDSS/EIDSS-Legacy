using System;
using System.Diagnostics;
using System.Windows.Forms;
using bv.common.Configuration;
using bv.common.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.gis.Forms;
using eidss.gis.Utils;
using eidss.model.Enums;

namespace eidss.gis
{
    /// <summary>
    /// GIS module initialize
    /// </summary>
    class Initializer
    {
        private static readonly EidssMapControl m_PreloadMap = new EidssMapControl();

        public static void Register(Control parentControl)
        {
            bv.common.Core.Utils.CheckNotNull(parentControl, "parentControl");
            var category = MenuActionManager.Instance.FindAction("MenuConfiguration", MenuActionManager.Instance.System, 960);
            new MenuAction(ShowMapCustomization, MenuActionManager.Instance, category, "MenuMapCustomization", 1020, false, (int)MenuIconsSmall.MapCustomization, -1)
                {
                    Name = "btnMapCustomization",
                    SelectPermission = PermissionHelper.SelectPermission(model.Enums.EIDSSPermissionObject.GIS)
                };
            
            //preload. Maybe do it in thread?
            try
            {
                m_PreloadMap.LoadMap(MapProjectsStorage.DefaultMapPath);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GIS Preload failed: "+ex.Message);
            }
            
        }

        /// <summary>
        /// Show map customization form
        /// </summary>
        public static void ShowMapCustomization()
        {
            using(new TemporaryWaitCursor())
            try
            {
                var customizeMapForm = new CustomizeMapForm();
                BaseFormManager.ShowModal(customizeMapForm, BaseFormManager.MainForm);
            }
            catch (Exception ex)
            {
                if (BaseSettings.ThrowExceptionOnError)
                    throw;
                ErrorForm.ShowError(ex);
            }
            
        }
    }
}
