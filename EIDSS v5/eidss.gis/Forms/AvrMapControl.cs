using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using bv.common;
using bv.common.Core;
using bv.common.db.Core;
using bv.common.win;
using eidss.gis.Properties;
using eidss.gis.Serializers;
using eidss.gis.Utils;
using GIS_V4.Common;
using GIS_V4.Layers;
using GIS_V4.Rendering;
using GIS_V4.Serializers.ThemeSerializers;
using GradientTheme = GIS_V4.Rendering.GradientTheme;

namespace eidss.gis.Forms
{
    public class AvrMapControl:EidssMapControl
    {

        public AvrMapControl()
        {
            InitBufZonesToolBar();
            InitLightMapProjectToolBar();

            //Debug! Profile map load
            m_mapImage.MapRefreshed += m_mapImage_MapRefreshed;
            m_mapImage.SizeChanged += m_mapImage_SizeChanged;
        }

        /// <summary>
        /// For web version only
        /// </summary>
        /// <param name="web"></param>
        public AvrMapControl(bool web)
        {
            
        }

        /// <summary>
        ///   Clean up any resources being used.
        /// </summary>
        /// <param name="disposing"> true if managed resources should be disposed; otherwise, false. </param>
        protected override void Dispose(bool disposing)
        {
            m_mapImage.MapRefreshed -= m_mapImage_MapRefreshed;
            m_mapImage.SizeChanged -= m_mapImage_SizeChanged;
            base.Dispose(disposing);
        }

        #region Debug! Profile map load
        void m_mapImage_SizeChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(DateTime.Now + "Raw sizechanged" + m_mapImage.Size);
        }

        void m_mapImage_MapRefreshed(object sender, EventArgs e)
        {
            Debug.WriteLine(DateTime.Now + "Raw refreshed");
        }
        #endregion

        /// <summary>
        /// Adds AVR layer to MapControl
        /// </summary>
        /// <param name="mapTitle">Map name</param>
        /// <param name="layerName">AVR layer name</param>
        /// <param name="data">
        /// Data table structure:
        /// long                            id;
        /// double                          x;
        /// double                          y;
        /// bv.common.Enums.GisCaseType     type;
        /// double                          value;
        /// string                          info;
        /// </param>
        /// <param name="isSingle">single or multiple (hum, vet and vector)</param>
        /// <param name="settings">avr map settings</param>
        public void AddEventLayer(string mapTitle, string layerName, DataTable data, bool isSingle, EventLayerSettings settings)
        {
            //OnBeforeEventLayerAdd();
            var connection = ConnectionManager.DefaultInstance.ConnectionString;
            AddEventLayer(mapTitle, layerName, data, isSingle, connection);
            if (settings!=null) SetMapSettings(settings);
            //OnAfterEventLayerAdd();
        }

        /// <summary>
        /// Removes all event (AVR) layers from map control
        /// </summary>
        public void RemoveAllEventLayers()
        {
            try
            {
                for (var i = 0; i < Map.Layers.Count; i++)
                {
                    if (Map.Layers[i] is EventLayer)
                    {
                        Map.Layers.Remove(((EventLayer) Map.Layers[i]).LabelLayer);
                        Map.Layers.Remove(Map.Layers[i]);
                        if (i >= 2) i = i - 2;
                        else i--;
                    }
                }
            }
            catch (Exception ex)
            {
                var erMsg = new ErrorMessage("ErrAVRLayerRemoving", Resources.gis_AvrMapControl_RemoveAllEventLayers_Exception, ex);
                ErrorForm.ShowError(erMsg);
            }

        }

        //public delegate void MapSettingsHandler();
        //public event MapSettingsHandler GettingMapSettings;
        //public event MapSettingsHandler BeforeEventLayerAdd;

        //public void OnBeforeEventLayerAdd()
        //{
        //    var handler = BeforeEventLayerAdd;
        //    if (handler != null)
        //    {
        //        handler();
        //    }
        //}

        //public event MapSettingsHandler AfterEventLayerAdd;
        
        //public void OnAfterEventLayerAdd()
        //{
        //    var handler = AfterEventLayerAdd;
        //    if (handler != null)
        //    {
        //        handler();
        //    }
        //}

        //public void OnGettingMapSettings()
        //{
        //    var handler = GettingMapSettings;
        //    if (handler != null)
        //    {
        //        handler();
        //    }
        //}

        public EventLayerSettings GetMapSettings()
        {
            //OnGettingMapSettings();
            //if (GettingMapSettings != null) GettingMapSettings();
            try
            {
                EventLayerSettings result = null;
                EventLayer eventLayer = null;

                if (m_mapImage.Map == null) return null;
                if (m_mapImage.Map.Layers.Count == 0) return null;

                //Serialize event layer theme and remember layer index
                var index = -1;
                foreach (var layer in m_mapImage.Map.Layers)
                {
                    index++;
                    if (!(layer is EventLayer)) continue;
                    eventLayer = (EventLayer) layer;
                    
                    result = new EventLayerSettings
                                 {
                                     LayerSettings = ThemeSerializer.SerializeAsDocument(eventLayer.Theme),
                                     Position = index
                                 };

                    //#region TMP APPROACH: Solves vector/case entity problem
                    //var tbl = ((EventDataProvider) eventLayer.DataSource).EventTable;
                    //if ((tbl.Columns.Contains("human") && tbl.Columns.Contains("vet") && tbl.Columns.Contains("vector")))
                    //    result = null;
                    //#endregion
                    
                    break;
                }

                if (result != null)
                {
                    if (eventLayer != null)
                    {
                        if (eventLayer.LabelLayer != null) m_mapImage.Map.Layers.Remove(eventLayer.LabelLayer);
                        m_mapImage.Map.Layers.Remove(eventLayer);
                    }

                    result.MapSettings = EidssMapSerializer.Instance.SerializeAsDocument(m_mapImage.Map, "Map");

                    if (eventLayer != null)
                    {
                        m_mapImage.Map.Layers.Insert(result.Position, eventLayer);
                        m_mapImage.Map.Layers.Add(eventLayer.LabelLayer);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                var erMsg = new ErrorMessage("ErrGetMapSettings", Resources.gis_AvrMapControl_GetMapSettings_Exception, ex);
                ErrorForm.ShowError(erMsg); 
                return null;
            }
        }

        public void SetMapSettings(EventLayerSettings settings)
        {
            //Map settings defenition
            try
            {
                if (settings == null || m_mapImage.Map == null) return;

                if (settings.MapSettings == null && settings.LayerSettings == null)
                {
                    RefreshMap();
                    RefreshContent();
                    return;
                }

                //Temporarely remove event layer and event labels
                EventLayer eventLayer = null;

                foreach (var layer in m_mapImage.Map.Layers)
                {
                    if (!(layer is EventLayer)) continue;
                    eventLayer = (EventLayer) layer;
                    break;
                }

                if (eventLayer != null)
                {
                    if (eventLayer.LabelLayer != null) m_mapImage.Map.Layers.Remove(eventLayer.LabelLayer);
                    var pos = m_mapImage.Map.Layers.IndexOf(eventLayer);
                    m_mapImage.Map.Layers.Remove(eventLayer);

                    //Restore map settings
                    if (settings.MapSettings != null)
                        m_mapImage.Map = EidssMapSerializer.Instance.DeserializeFromDocument(settings.MapSettings);

                    //Apply event layer settings and add it to map to specified position
                    if (settings.LayerSettings != null)
                    {
                        //TODO[tkobilov] Make multiple AVR layer settings
                        var theme = ThemeSerializer.DeserializeFromDocument(settings.LayerSettings);
                        if (theme is PieTheme && eventLayer.Theme is PieTheme)
                            eventLayer.Theme = theme;
                        if (theme is GradientTheme && theme.GetType() == eventLayer.Theme.GetType())
                        {
                            //if (((VectorStyle) ((GradientTheme) theme).MinStyle).MarkerType ==
                            //    ((VectorStyle) (((GradientTheme) eventLayer.Theme)).MinStyle).MarkerType)

                            if (eventLayer.Theme is GradientTheme)
                            {
                                var min = ((GradientTheme)(eventLayer.Theme)).Min;
                                var max = ((GradientTheme)(eventLayer.Theme)).Max;
                                eventLayer.Theme = theme;
                                ((GradientTheme)(eventLayer.Theme)).Min = min;
                                ((GradientTheme)(eventLayer.Theme)).Max = max;
                            }
                            else
                                eventLayer.Theme = theme;

                            
                        }
                        if (theme is RuleBasedTheme && eventLayer.Theme is RuleBasedTheme /*&& !(eventLayer.Theme is PieTheme)*/) eventLayer.Theme = theme;
                    }
                    
                    if (settings.LayerSettings != null)
                        m_mapImage.Map.Layers.Insert(settings.Position, eventLayer);
                    else m_mapImage.Map.Layers.Insert(pos, eventLayer);

                    m_mapImage.Map.Layers.Add(eventLayer.LabelLayer);
                }
            }
            catch (Exception ex)
            {
                var erMsg = new ErrorMessage("ErrMapSettingsDefenition", Resources.gis_AvrMapControl_SetMapSettings_Exception, ex);
                ErrorForm.ShowError(erMsg); 
            }

            //Refresh map and map content
            try
            {
                RefreshMap();
                RefreshContent();
            }
            catch (Exception ex)
            {
                var erMsg = new ErrorMessage("ErrRefreshingMap", Resources.gis_AvrMapControl_SetMapSettings_RefreshException, ex);
                ErrorForm.ShowError(erMsg); 
            }
        }

        public override void LoadMap(string mapName)
        {
            m_ErrorFormShowed = false;

            m_mapImage.Map = EidssMapSerializer.Instance.DeserializeFromFile(mapName);
            m_mapImage.Map.Size = m_mapImage.Size;
            m_mapImage.Map.ZoomToBox(mtFixedExtent.Extent);
            TranslateToc(mapName);
            
            //ADD EVENT LAYER AFTER LOAD MAP!
            RefreshContent();
            OnMapLoad(mapName);
        }
        
        /// <summary>
        /// Init default map project
        /// </summary>
        public void InitMap()
        {
            MapSpatRef = CoordinateSystems.SphericalMercatorCS;
            LoadMap(MapProjectsStorage.DefaultMapPath);
            MapSelector.UpdateValue(MapProjectsStorage.DefaultMapName);
        }


        public delegate void LeavingMapHandler(object sender, CancelEventArgs e);

        public event LeavingMapHandler LeavingMap;

        public CancelEventArgs OnLeavingMap(CancelEventArgs e)
        {
            var handler = LeavingMap;
            if (handler != null)
            {
                handler(this, e);
            }
            return e;
        }
    }
}
