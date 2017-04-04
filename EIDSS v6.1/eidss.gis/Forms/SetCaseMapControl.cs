using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using SharpMap.Styles;
using bv.common.db.Core;
using eidss.gis.Serializers;
using GIS_V4.Tools;
using GIS_V4.Tools.Implemented;

namespace eidss.gis.Forms
{
    public class SetCaseMapControl:EidssMapControl
    {
        public mtInputPoint InputTool { get; private set; }

        #region IT IS UGLY HACK!
        private BarItemLink hackButton;
        private BarButtonItem m_hackButtonItem;

        public void RemoveUglyButton()
        {
            barManager.Bars["StatusBar"].RemoveLink(hackButton);
            hackButton.Dispose();
            m_hackButtonItem.Dispose();
        }
        #endregion

        public SetCaseMapControl()
        {
            InitEditToolBar();
            InitLightMapProjectToolBar();

            // connect symbol set
            var strConnection = ConnectionManager.DefaultInstance.ConnectionString;
            SymbolGallery = new SymbolSet(strConnection);
            

            //IT IS UGLY HACK!
            hackButton = barManager.Bars["StatusBar"].AddItem(m_hackButtonItem = new BarButtonItem(barManager, "Temporary") { Border = BorderStyles.Flat });
        }

        public void InitEditToolBar()
        {
            barManager.Form = this;
            barManager.BeginUpdate();
            //create tool and barButton
            var mbb = new MapBarButton();
            InputTool = new mtInputPoint { MapImage = m_mapImage };
            mbb.MapTool = InputTool;

            //create edit bar
            Bar editBar = new Bar(barManager, "EditBar");
            editBar.OptionsBar.AllowDelete = false;
            editBar.OptionsBar.AllowQuickCustomization = false;
            editBar.OptionsBar.DisableClose = true;
            editBar.OptionsBar.DisableCustomization = true;
            editBar.DockStyle = BarDockStyle.Top;
            editBar.CanDockStyle = BarCanDockStyle.Top;
            editBar.OptionsBar.BarState = BarState.Expanded;
            editBar.Visible = true;
            editBar.DockRow = 0;
            editBar.DockCol = 4;
            editBar.ApplyDockRowCol();

            editBar.AddItem(mbb);
            barManager.EndUpdate();
        }


        public override void LoadMap(string mapName)
        {
            m_ErrorFormShowed = false;

            m_mapImage.Map = EidssMapSerializer.Instance.DeserializeFromFile(mapName);
            m_mapImage.Map.Size = m_mapImage.Size;
            m_mapImage.Map.ZoomToBox(mtFixedExtent.Extent); //???
            
            //ADD Temporary LAYER AFTER LOAD MAP!
            Map.Layers.Remove(InputTool.TemporaryLayer);
            Map.Layers.Add(InputTool.TemporaryLayer);

            TranslateToc(mapName);

            // connect symbol set
            var strConnection = ConnectionManager.DefaultInstance.ConnectionString;
            SymbolGallery = new SymbolSet(strConnection);

            RefreshContent();

        }

    }
}
