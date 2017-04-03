using System;
using System.ComponentModel;
using System.Windows.Forms;
using GIS_V4.Layers;
using bv.common;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using eidss.gis.Forms;
using eidss.model.Resources;
using GIS_V4.Forms;
using GIS_V4.Tools;
using eidss.gis.Utils;
using bv.winclient.Core;

namespace eidss.gis.Tools
{

    public class MapSelector : StateViewer
    {

        public MapSelector()
        {
            MapProjectsStorage.UpdateMapProjectList();
            MapProjectsStorage.ProjectListUpdated += OnListUpdated;
        }


        public MapContent Content { get; set; }

        protected override void Dispose(bool disposing)
        {
            MapProjectsStorage.ProjectListUpdated -= OnListUpdated;
            base.Dispose(disposing);
            m_MapControl = null;
        }


        #region << ControlForVisualize >>

        private BarEditItem m_MapSelectBarItem;

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DefaultValue(null)]
        public BarEditItem ControlForVisualize
        {
            get { return m_MapSelectBarItem; }
            set
            {
                m_MapSelectBarItem = value;
                if (m_MapSelectBarItem != null)
                {
                    m_MapSelectBarItem.EditValueChanged += m_MapSelectBarItem_EditValueChanged;
                    UpdateList();
                }
            }
        }

        #endregion

        private bool m_SelfRefresh;
        private string m_OldMapName = string.Empty;

        private void OnListUpdated(object sender, EventArgs e)
        {
            UpdateList();
        }


        #region Map is going to be changed

        public delegate void MapChangeHandler(CancelEventArgs e);

        public event MapChangeHandler MapChanging;

        public void OnMapChanging(CancelEventArgs e)
        {
            var handler = MapChanging;
            if (handler != null)
            {
                handler(e);
            }
        }

        #endregion

        void m_MapSelectBarItem_EditValueChanged(object sender, EventArgs e)
        {
            if (m_SelfRefresh)
                return;

            var cea = new CancelEventArgs();
            OnMapChanging(cea);
            if (cea.Cancel)
            {
                m_MapSelectBarItem.EditValueChanged -= m_MapSelectBarItem_EditValueChanged;
                m_MapSelectBarItem.EditValue = m_OldMapName;
                m_MapSelectBarItem.EditValueChanged += m_MapSelectBarItem_EditValueChanged;
                return;
            }

            if (m_MapControl != null && m_MapControl.Map != null && m_MapControl.Image != null)
            {
                var selectedValue = m_MapSelectBarItem.EditValue as String;

                string mapFileName;
                
                if (selectedValue == MapProjectsStorage.DefaultMapName )
                {
                    mapFileName = MapProjectsStorage.DefaultMapPath;
                }
                else
                {
                    mapFileName = MapProjectsStorage.GetMapFullPath(MapProjectsStorage.CustomProjectsPath, selectedValue);
                }
                

                var msg = EidssMessages.GetForCurrentLang("gis_Message_OpenMap", "Would you like to open this map?");
                var caption = EidssMessages.GetForCurrentLang("gis_Caption_OpenMap", "Open map: ");
                var errMsg = EidssMessages.GetForCurrentLang("gis_ErrMessage_OpenMap", "Can't open selected map.");

                if (MessageForm.Show(msg, caption + selectedValue, MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var extent = m_MapControl.Map.Envelope.Clone();
                    
                    try
                    {
                        //check AVR layers and store it for future use

                        if (m_MapControl.Parent is AvrMapControl)
                        {
                            EventLayer eventLayer = null;
                            foreach (var layer in m_MapControl.Map.Layers)
                            {
                                if (!(layer is EventLayer)) continue;
                                eventLayer = (EventLayer) layer;
                                break;
                            }

                            (m_MapControl.Parent as EidssMapControl).LoadMap(mapFileName);
                            if (eventLayer != null) m_MapControl.Map.Layers.Add(eventLayer);
                            Content.RefreshMapContent();
                        }
                        else
                        {
                            (m_MapControl.Parent as EidssMapControl).LoadMap(mapFileName);
                            
                        }

                        m_OldMapName = selectedValue;
                    }
                    catch (Exception ex)
                    {
                        bv.common.win.ErrorForm.ShowError(new ErrorMessage(errMsg, ex));
                        //return old value
                        m_SelfRefresh = true;
                        m_MapSelectBarItem.EditValue = m_OldMapName;
                        m_SelfRefresh = false;
                        return;
                    }

                    m_MapControl.Map.ZoomToBox(extent);
                    
                    m_MapControl.Refresh();
                    
                    //deactivate all edit tools 
                    if ((m_MapControl.Parent as MapControl).DefaultTool is ControllerMapTool)
                        ((m_MapControl.Parent as MapControl).DefaultTool as ControllerMapTool).IsActive = true;
                    
                }
                else
                {
                    //return old value
                    m_SelfRefresh = true;
                    m_MapSelectBarItem.EditValue = m_OldMapName;
                    m_SelfRefresh = false;
                }
                
            }

        }

        

        void UpdateList()
        {
            var cmb = m_MapSelectBarItem.Edit as RepositoryItemComboBox;
            if(cmb != null)
            {
                m_SelfRefresh = true;
                cmb.TextEditStyle = TextEditStyles.DisableTextEditor;

                //refresh list
                cmb.Items.Clear();
                cmb.Items.AddRange(MapProjectsStorage.ProjectList);
                
                //try set prev value
                if(cmb.Items.Contains(m_OldMapName))
                    m_MapSelectBarItem.EditValue = m_OldMapName;

                m_SelfRefresh = false;
            }
        }

        /// <summary>
        /// Programmatically update value, without event raise
        /// </summary>
        public void UpdateValue(string value)
        {
             var cmb = m_MapSelectBarItem.Edit as RepositoryItemComboBox;
             if (cmb != null)
             {
                 m_SelfRefresh = true;
                 m_MapSelectBarItem.EditValue = value;
                 m_OldMapName = value;
                 m_SelfRefresh = false;
             }
        }
    }
}