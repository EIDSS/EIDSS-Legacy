using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using eidss.gis.Data;
using eidss.gis.Layers;
using eidss.gis.Utils;
using GIS_V4.Forms;
using GIS_V4.Tools;

namespace eidss.gis.Tools
{
    public class MtZoneLayerSelector : StateViewer
    {
        public MtZoneLayerSelector()
        {
            ZoneLayerStorage.ZoneLayerDictUpdated += OnListUpdated;
        }

        private void OnListUpdated(object sender, EventArgs e)
        {
            UpdateList();
        }

        protected override void Dispose(bool disposing)
        {
            ZoneLayerStorage.ZoneLayerDictUpdated -= OnListUpdated;
            base.Dispose(disposing);
            m_MapControl = null;
        }

        protected override void AfterMapControlChange()
        {
            base.AfterMapControlChange();
            if (MapControl!=null) MapControl.Map.Layers.ListChanged+=Layers_ListChanged;
        }

        void Layers_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemDeleted)
            {
                var isFound = false;
                foreach (var layer in MapControl.Map.Layers)
                {
                    if (layer is EidssUserBufZoneLayer)
                        if (((EidssUserBufZoneLayer)layer).LayerDbGuid == ((KeyValuePairWrapper)m_ZoneLayerSelectBarItem.EditValue).Key)
                        {
                            isFound = true;
                            break;
                        }
                }
                if (isFound) m_ZoneLayerSelectBarItem.EditValue = null;
            }
        }

        private void SelectEditValue(KeyValuePair<Guid, string> editValue)
        {
            m_ZoneLayerSelectBarItem.EditValue = new KeyValuePairWrapper(editValue.Key,editValue.Value);
            m_SelectedZoneLayerGuid = editValue.Key;
        }

        #region << ControlForVisualize >>

        private BarEditItem m_ZoneLayerSelectBarItem;

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DefaultValue(null)]
        public BarEditItem ControlForVisualize
        {
            get { return m_ZoneLayerSelectBarItem; }
            set
            {
                m_ZoneLayerSelectBarItem = value;
                m_ZoneLayerSelectBarItem.Visibility = BarItemVisibility.OnlyInCustomizing;
                if (m_ZoneLayerSelectBarItem != null)
                {
                    m_ZoneLayerSelectBarItem.EditValueChanged += m_ZoneLayerSelectBarItem_EditValueChanged;
                    UpdateList();
                }
            }
        }

        #endregion

        private bool m_SelfRefresh;

        public delegate void ItemSelectHandler(KeyValuePair<Guid, string> e);
        public event ItemSelectHandler OnItemSelect;

        private bool IsZoneLayerAlreadyAdded(KeyValuePairWrapper keyValuePairWrapper)
        {
            return MapControl.Map.Layers.OfType<EidssUserBufZoneLayer>().Any(layer => (layer).LayerDbGuid == keyValuePairWrapper.Key);
        }

        void m_ZoneLayerSelectBarItem_EditValueChanged(object sender, EventArgs e)
        {
            if (m_SelfRefresh)
                return;
            //get selected name 
            var selectedValue = m_ZoneLayerSelectBarItem.EditValue;
            MapControl.ActiveTool = null;
            if (OnItemSelect != null)
                OnItemSelect( /*(KeyValuePair<Guid, string>)*/ ((KeyValuePairWrapper) selectedValue).ToKeyValuePair());

            if (IsZoneLayerAlreadyAdded((KeyValuePairWrapper) selectedValue)) return;

            //var msg = EidssMessages.Get("gis_Message_AddZoneLayer", "Would you like to add this buffer zone layer?", ModelUserContext.CurrentLanguage);
            //var caption = EidssMessages.Get("gis_Caption_AddZoneLayer", "Add buffer zone layer: ", ModelUserContext.CurrentLanguage);
            //var errMsg = EidssMessages.Get("gis_ErrMessage_AddZoneLayer", "Can't add selected buffer zone layer.", ModelUserContext.CurrentLanguage);
            
            //var captEx = caption + ((KeyValuePairWrapper) selectedValue).Value.ToString();
            //var dialogResult = MessageForm.Show(msg, captEx, MessageBoxButtons.YesNo,
            //                                                           MessageBoxIcon.Question);
            
            //if ( dialogResult == DialogResult.Yes)
            //{
                var eidssUserDbLayer =
                    UserDbLayersManager.GetUserLayer( /*((KeyValuePair<Guid, string>) selectedValue).Key*/
                        ((KeyValuePairWrapper) selectedValue).Key);
                MapControl.Map.Layers.Add(eidssUserDbLayer);
                MapControl.Map.Layers.Add(eidssUserDbLayer.LabelLayer);

                MapControl.Refresh();
                ((MapControl) (MapControl.Parent)).RefreshContent();
            //}
        }
        
        void UpdateList()
        {
            var cmb = m_ZoneLayerSelectBarItem.Edit as RepositoryItemComboBox;
            if (cmb != null)
            {
                cmb.TextEditStyle = TextEditStyles.DisableTextEditor;
                m_SelfRefresh = true;

                //save prevision 
                var prevValue = m_ZoneLayerSelectBarItem.EditValue as String;

                //refresh list
                m_ZoneLayerSelectBarItem.EditValue = null;
                m_ZoneLayerSelectBarItem_EditValueChanged(this, null);
                cmb.Items.Clear();
                cmb.Items.AddRange(ZoneLayerStorage.ZoneLayerDict);

                //try set prev value
                if (cmb.Items.Contains(prevValue))
                    m_ZoneLayerSelectBarItem.EditValue = prevValue;
                
                m_SelfRefresh = false;
            }
        }

        //public MapControl MapControl { get; set; }

        private MtAddBufZonesLayer m_AddBufZoneLayer;
        public MtAddBufZonesLayer AddBufZoneLayer
        {
            get { return m_AddBufZoneLayer; }
            set 
            { 
                m_AddBufZoneLayer = value;
                m_AddBufZoneLayer.OnCreateBufZone += m_AddBufZoneLayer_OnCreateBufZone;
            }
        }
        
        void m_AddBufZoneLayer_OnCreateBufZone(KeyValuePair<Guid, string> e)
        {
            SelectEditValue(e);
        }

        private Guid m_SelectedZoneLayerGuid = Guid.Empty;
        public Guid SelectedZoneLayerGuid
        {
            get { return m_SelectedZoneLayerGuid; }
        }

        public void DeactivateZoneLayer()
        {
            
        }
    }
}
