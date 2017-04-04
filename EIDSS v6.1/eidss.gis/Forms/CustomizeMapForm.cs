using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml;
using GIS_V4.Forms;
using bv.model.Model.Core;
using DevExpress.XtraEditors;
using bv.winclient.Core;
using eidss.gis.Properties;
using eidss.gis.Serializers;
using eidss.gis.Tools;
using eidss.gis.Utils;
using GIS_V4.Common;
using bv.winclient.BasePanel;
using GIS_V4.Tools;
using eidss.gis.common;
using eidss.model.Resources;

namespace eidss.gis.Forms
{
    public partial class CustomizeMapForm : BvForm
    {
        public bool m_BeforeFirstSaving = true;

        public void OpenMapProject()
        {
            if (GetMapProjectState() == MapUtils.MapProjectState.Unsaved)
            {
                var dr = MessageForm.Show("Would you like to save changes before opening another map project?", "Open",
                                          MessageBoxButtons.YesNoCancel,
                                          MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (m_BeforeFirstSaving)
                    if (SaveMapProject(false))
                    {
                        _OpenMapProjects();
                    }
                }
                else if (dr==DialogResult.No)
                {
                    _OpenMapProjects();
                }
            }
            else
            {
                _OpenMapProjects();
            }
        }

        private void _OpenMapProjects()
        {
            var openForm = new OpenMapForm();
            var mapProjectListNoDefault = MapProjectsStorage.GetCustomMapsNames();
            openForm.SetMapList(mapProjectListNoDefault);
            
            var dr = openForm.ShowDialog();
            if (dr == DialogResult.Yes)
            {
                var name = openForm.MapName;
                Text = name;
                mapControl.LoadMap(MapProjectsStorage.CustomProjectsPath + name + ".map");
                m_BeforeFirstSaving = true;
                UpdateMapStateXml();
                mapControl.m_mapImage.Refresh();
            }
        }

        //public MapUtils.MapProjectState m_MapProjectState = MapUtils.MapProjectState.New;
        //private MapUtils.MapProjectState m_PrevMapProjectState = MapUtils.MapProjectState.New;
        /// <summary>
        /// Try to save (or save as) current map project
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool SaveMapProject(bool isSaveAs, string name = null)
        {
            if (GetMapProjectState() == MapUtils.MapProjectState.Unsaved | isSaveAs)
            {
                return _SaveMapProject(isSaveAs, name);
            }
            else
            {
                // There are no changes in the project
                return true;
            }
        }


        private bool _SaveMapProject(bool isSaveAs, string name = null)
        {
            try
            {
                if (name != null | isSaveAs | m_BeforeFirstSaving)
                {
                    // Act as a Save As
                    var saveMapForm = new SaveMapForm();
                    var mapProjectListNoDefault = MapProjectsStorage.GetCustomMapsNames();
                    
                    saveMapForm.SetMapList(mapProjectListNoDefault);
                    saveMapForm.MapName = Text;
                    
                    var dr = saveMapForm.ShowDialog();
                    if ( dr == DialogResult.Yes)
                    {
                        try
                        {
                            if (saveMapForm.MapName == MapProjectsStorage.DefaultMapName)
                            {
                                string caption = EidssMessages.Get("Save", "Save", bv.model.Model.Core.ModelUserContext.CurrentLanguage);
                                MessageForm.Show(Resources.gis_MtSaveMap_SaveOverDefaultError,
                                                               caption, MessageBoxButtons.OK,
                                                               MessageBoxIcon.Warning);
                                return false; // as a Cancel
                            }
                            EidssMapSerializer.Instance.SerializeAsFile(mapControl.m_mapImage.Map,
                                                                        ((EidssMapControl)
                                                                         (mapControl.m_mapImage).Parent).MapSettings,
                                                                        MapProjectsStorage.CustomProjectsPath +
                                                                        saveMapForm.MapName + ".map");
                            MapProjectsStorage.UpdateMapProjectList();

                            //may be more clear method for update?
                            if (((mapControl.m_mapImage.Parent) as EidssMapControl) != null)
                                ((mapControl.m_mapImage.Parent) as EidssMapControl).MapSelector.UpdateValue(
                                    saveMapForm.MapName);
                            Text = saveMapForm.MapName;
                            m_BeforeFirstSaving = false;
                            UpdateMapStateXml();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            ErrorForm.ShowError(ex);
                            return false; // as a Cancel
                        }
                    }
                    else if (dr == DialogResult.No)
                    {
                        // no changes saved
                        return true;
                    }
                    else
                    {
                        // cancel
                        return false;
                    }
                }
                else
                {
                    // Act as a Save
                    EidssMapSerializer.Instance.SerializeAsFile(mapControl.m_mapImage.Map,
                                                                        ((EidssMapControl)
                                                                         (mapControl.m_mapImage).Parent).MapSettings,
                                                                        MapProjectsStorage.CustomProjectsPath +
                                                                        name + ".map");
                    MapProjectsStorage.UpdateMapProjectList();

                    //may be more clear method for update?
                    if (((mapControl.m_mapImage.Parent) as EidssMapControl) != null)
                        ((mapControl.m_mapImage.Parent) as EidssMapControl).MapSelector.UpdateValue(name);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private XmlDocument mapStateXml = new XmlDocument();

        public void UpdateMapStateXml()
        {
            mapStateXml = EidssMapSerializer.Instance.SerializeAsDocument(mapControl.m_mapImage.Map, "Map",
                                                                            mapControl.MapSettings);
            m_BeforeFirstSaving = true;
        }

        public MapUtils.MapProjectState GetMapProjectState()
        {
            var curMapXml = EidssMapSerializer.Instance.SerializeAsDocument(mapControl.m_mapImage.Map, "Map",
                                                                            mapControl.MapSettings);
            if (curMapXml.InnerText==mapStateXml.InnerText) return MapUtils.MapProjectState.Saved;
            return MapUtils.MapProjectState.Unsaved;
        }



        public CustomizeMapForm()
        {
            InitializeComponent();

            //init toolbars
            
            mapControl.InitBufZonesToolBar();
            mapControl.InitMapProjectToolBar();
            
            ////add SaveMap Tool to Project panel
            //var mbb = new MapBarButton();
            //var mTool = new MtSaveMap { MapImage = mapControl.m_mapImage };
            //mbb.MapTool = mTool;
            //mapControl.barManager.Bars["MapProjects"].AddItem(mbb);

            
            //TODO[enikulin]: add user rights

            //Debug! Profile map load
            mapControl.m_mapImage.MapRefreshed += m_mapImage_MapRefreshed;
            mapControl.m_mapImage.SizeChanged += m_mapImage_SizeChanged;
            //IApplicationForm initialization
            Sizable = true;
            HelpTopicId = "MapsConfiguration";
            Text = EidssMessages.GetForCurrentLang("gis_Form_NewMapProject_Text", "New Map Project"); ;

            FormClosing += CustomizeMapForm_FormClosing;
        }

        void CustomizeMapForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GetMapProjectState() == MapUtils.MapProjectState.Unsaved)
            {
                var text = EidssMessages.GetForCurrentLang("gis_CustomForm_SaveChangesRequest",
                    "Would you like to save changes before closing this form?");
                var dr = MessageForm.Show(text, "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    SaveMapProject(false);
                }
                else if (dr == DialogResult.No)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = false;
            }
        }


        #region Debug! Profile map load
        void m_mapImage_SizeChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(DateTime.Now + "Raw sizechanged" + mapControl.m_mapImage.Size.ToString());

        }

        void m_mapImage_MapRefreshed(object sender, EventArgs e)
        {
            Debug.WriteLine(DateTime.Now + "Raw refreshed");
        }
        #endregion


        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            
            using (new TemporaryWaitCursor())
            {
                //load map 
                mapControl.MapSpatRef = CoordinateSystems.SphericalMercatorCS;

                DateTime start = DateTime.Now;
                mapControl.LoadMap(MapProjectsStorage.DefaultMapPath);
                Debug.WriteLine("Loaded:" + (DateTime.Now - start).TotalMilliseconds);
                Debug.WriteLine("Loaded:" + DateTime.Now);
                mapControl.MapSelector.UpdateValue(MapProjectsStorage.DefaultMapName);
                UpdateMapStateXml();
                mapControl.RefreshMap();
            }
            
        }
       

        #region IApplicationForm Members

        public override string Caption
        {
            get { return Resources.gis_CustomizeMapForm_Caption; }
        }

        #endregion


      
    }
}
