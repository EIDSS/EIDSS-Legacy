using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using GIS_V4.Data.Providers;
using GIS_V4.Forms;
using GIS_V4.Rendering;
using SharpMap.Layers;
using SharpMap.Rendering.Thematics;
using SharpMap.Styles;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.db.Core;
using bv.model.Model.Core;
using bv.winclient.Core;
using eidss.gis.Serializers;
using eidss.gis.Utils;
using eidss.model.Resources;
using GIS_V4.Common;
using GIS_V4.Layers;
using GradientTheme = GIS_V4.Rendering.GradientTheme;
using LayerGroup = GIS_V4.Layers.LayerGroup;

namespace eidss.gis.Forms
{
    public class AvrMapControl:EidssMapControl
    {

        public AvrMapControl()
        {
            InitBufZonesToolBar();
            InitLightMapProjectToolBar();

            //Debug this! Profile map load
            //m_mapImage.MapRefreshed += m_mapImage_MapRefreshed;
            //m_mapImage.SizeChanged += m_mapImage_SizeChanged;
            //m_mapImage.Resize += m_mapImage_Resize;
            
            //m_mapImage.MapZoomChanged += m_mapImage_MapZoomChanged;
        }
        

        //private void m_mapImage_Resize(object sender, EventArgs e)
        //{
        //    //if (m_SettingsAssigned) 
        //    m_Settings = GetMapSettings();
        //    //m_SettingsAssigned = false;
        //}

        //void m_mapImage_MapZoomChanged(double zoom)
        //{
        //    if (m_SettingsAssigned) m_Settings = GetMapSettings();
        //    m_SettingsAssigned = false;
        //}

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
            //if (m_mapImage != null)
            //{
            //    m_mapImage.MapRefreshed -= m_mapImage_MapRefreshed;
            //    m_mapImage.SizeChanged -= m_mapImage_SizeChanged;
            //}
            base.Dispose(disposing);
        }

        #region Debug! Profile map load
        void m_mapImage_SizeChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(DateTime.Now + "Raw sizechanged" + m_mapImage.Size);
        }
        
        void m_mapImage_SomeTimeAfterMapRefreshed(object sender, EventArgs e)
        {
            if (e == null) return;
            Freezed = false;
            m_mapImage.SomeTimeAfterMapRefreshed -= m_mapImage_SomeTimeAfterMapRefreshed;
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
        [Obsolete("This method is for 5-th version only. Use AddEventLayer(DataSet dataSource, EventLayerSettings settings) instead.")]
        public void AddEventLayer(string mapTitle, string layerName, DataTable data, bool isSingle, EventLayerSettings settings)
        {
            //OnBeforeEventLayerAdd();
            var connection = ConnectionManager.DefaultInstance.ConnectionString;
            AddEventLayer(mapTitle, layerName, data, isSingle, connection);
            if (settings!=null) SetMapSettings(settings);
            //OnAfterEventLayerAdd();
        }

        public void AddEventLayer(DataSet dataSource, EventLayerSettings settings)
        {
            bv.common.Core.Utils.CheckNotNull(dataSource, "dataSource");
            bv.common.Core.Utils.CheckNotNull(settings, "settings");
            if (dataSource.Tables.Count != 2)
            {
                throw new AvrException("Map DataSet should have 2 tables.");
            }

            DataTable data = dataSource.Tables[0];
            DataTable dictionary = dataSource.Tables[1];

            CheckTableColumnExists(data, "id");
            CheckTableColumnExists(data, "x");
            CheckTableColumnExists(data, "y");

            CheckTableColumnExists(dictionary, "ColumnName");
            CheckTableColumnExists(dictionary, "ColumnDescription");
            CheckTableColumnExists(dictionary, "blnIsGradient");
            CheckTableColumnExists(dictionary, "blnIsChart");


            string mapTitle = dataSource.DataSetName;
            string layerName = EidssMessages.Get("gis_avrData", "AVR Data", ModelUserContext.CurrentLanguage);
            string connection = ConnectionManager.DefaultInstance.ConnectionString;
            
            
            // todo: [Timur] Implement
            Freezed = true;
            m_mapImage.SomeTimeAfterMapRefreshed +=m_mapImage_SomeTimeAfterMapRefreshed;

            AddEventLayer(mapTitle, layerName, dataSource, connection);
            
            if (settings != null)
            {
                SetMapSettings(settings);
            }

            m_Settings = _GetMapSettings();
        }

        private void CheckTableColumnExists(DataTable table, string columnName)
        {
            if (!table.Columns.Contains(columnName))
            {
                throw new AvrException(string.Format("Table {0} dosn't have column {1}", table.TableName, columnName));
            }
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
                    var l = (Layer) (Map.Layers[i]);
                    if ("eventgroup".Equals(l.Tag)/*Map.Layers[i] is EventLayer*/)
                    {
                        //Map.Layers.Remove(((EventLayer) Map.Layers[i]).LabelLayer);
                        Map.Layers.Remove(Map.Layers[i]);
                        if (i >= 2) i = i - 2;
                        else i--;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorForm.ShowError("ErrAVRLayerRemoving", "", ex);
            }

        }

        private EventLayerSettings m_Settings;

        public bool HasChanges()
        {
            var tmpSettings = _GetMapSettings();

            if (tmpSettings == null) return false;
            if (tmpSettings.MapSettings == null) return false;

            if (m_Settings == null) return false;

            if (m_Settings.MapSettings == null) return false;

            var curMapSettings = (XmlDocument) tmpSettings.MapSettings.Clone();
            var initMapSettings = (XmlDocument) m_Settings.MapSettings.Clone();

            var ex1 = curMapSettings.GetElementsByTagName("Envelope")[0];
            var ex2 = initMapSettings.GetElementsByTagName("Envelope")[0];

            if (curMapSettings.GetElementsByTagName("Envelope").Count > 0)
                curMapSettings.ChildNodes[0].RemoveChild(ex1);
            if (initMapSettings.GetElementsByTagName("Envelope").Count > 0)
                initMapSettings.ChildNodes[0].RemoveChild(ex2);

            return !(tmpSettings.Position == m_Settings.Position &
                     tmpSettings.LayerSettings.InnerText == m_Settings.LayerSettings.InnerText &
                     curMapSettings.InnerText == initMapSettings.InnerText);
        }

        private EventLayerSettings _GetMapSettings()
        {
            EventLayerSettings result = null;

            LayerGroup layerGroup = null;
            var index = -1;

            if (Map == null) return null;
            if (Map.Layers == null) return null;

            foreach (var layer in Map.Layers)
            {
                index++;
                if (!(layer is LayerGroup)) continue;
                layerGroup = (LayerGroup)layer;
                if (layerGroup.Tag.ToString() != "eventgroup") continue;

                var xmlDoc = new XmlDocument();
                var xmlElement = xmlDoc.CreateElement("AVR_Group");
                GIS_V4.Serializers.LayerSerializers.LayerGroupSerializer.Instance.Serialize(layerGroup, xmlElement);

                xmlDoc.AppendChild(xmlElement);

                result = new EventLayerSettings { LayerSettings = xmlDoc, Position = index };

                break;
            }

            if (result != null)
            {
                //if (layerGroup.LabelLayer != null) m_mapImage.Map.Layers.Remove(layerGroup.LabelLayer);
                m_mapImage.Map.Layers.Remove(layerGroup);

                result.MapSettings = EidssMapSerializer.Instance.SerializeAsDocument(m_mapImage.Map, "Map",
                    ((AvrMapControl) m_mapImage.Parent).MapSettings);

                m_mapImage.Map.Layers.Insert(result.Position, layerGroup);
                //m_mapImage.Map.Layers.Add(layerGroup.LabelLayer);
            }
            
            return result;
        }

        public EventLayerSettings GetMapSettings()
        {
            //OnGettingMapSettings();
            //if (GettingMapSettings != null) GettingMapSettings();
            try
            {
                EventLayerSettings result = _GetMapSettings();
                m_Settings = result;

                return result;
            }
            catch (Exception ex)
            {
                ErrorForm.ShowError("ErrGetMapSettings", "", ex);
                return null;
            }
        }

        private ITheme ReplaceColumnName(EventLayer layerSerialized)
        {
            if (layerSerialized.Theme == null)
            {
                // nothing to replace
                return layerSerialized.Theme;
            }
            else if (layerSerialized.Theme is GradientTheme)
            {
                //var colName = ((GradientTheme)layerSerialized.Theme).ColumnName;
                
                //var first = colName.IndexOf("gisEnd", StringComparison.Ordinal);
                //var last = colName.IndexOf("__", StringComparison.Ordinal);

                //foreach (var column in ((EventDataProvider) layerFromAvr.DataSource).EventTable.Columns)
                //{
                //    if (column.ToString().Contains(colName.Substring(first, last - first)))
                //    {
                //        ((GradientTheme) layerSerialized.Theme).ColumnName = column.ToString();
                //        return layerSerialized.Theme;
                //    }
                //}
                
                var input = ((GradientTheme)layerSerialized.Theme).ColumnName;

                const string pattern = @"gisBegin_[\s\S\d\D\w\W]*_gisEnd";
                const string replacement = "";

                var rgx = new Regex(pattern);

                ((GradientTheme)layerSerialized.Theme).ColumnName = rgx.Replace(input, replacement);
            }
            else if (layerSerialized.Theme is GraduatedTheme)
            {
                //var colName = ((GraduatedTheme)layerSerialized.Theme).FieldName;

                //var first = colName.IndexOf("gisEnd", StringComparison.Ordinal);
                //var last = colName.IndexOf("__", StringComparison.Ordinal);

                //foreach (var column in ((EventDataProvider)layerFromAvr.DataSource).EventTable.Columns)
                //{
                //    if (column.ToString().Contains(colName.Substring(first, last - first)))
                //    {
                //        ((GraduatedTheme)layerSerialized.Theme).FieldName = column.ToString();
                //        return layerSerialized.Theme;
                //    }
                //}

                var input = ((GraduatedTheme)layerSerialized.Theme).FieldName;
                
                const string pattern = @"gisBegin_[\s\d\w]*_gisEnd";
                const string replacement = "";
                
                var rgx = new Regex(pattern);
                
                ((GraduatedTheme) layerSerialized.Theme).FieldName = rgx.Replace(input, replacement);

                // redefine rules
                foreach (var rule in ((GraduatedTheme)layerSerialized.Theme).Rules)
                {
                    input = rule.Condition;
                    rule.Condition = rgx.Replace(input, replacement);
                }

            }
            else if (((EventLayer)layerSerialized).Theme is RuleBasedTheme)
            {
                
            }
            else
            {
                
            }

            return layerSerialized.Theme;

        }

        private bool ThemeIsCompatible(ITheme theme, EventLayer layer)
        {
            //var result = true;
            char[] charsToTrim = {'[', ']'};

            if (theme is GraduatedTheme)
            {
                var colName = ((GraduatedTheme)theme).FieldName;
                var first = colName.IndexOf("gisEnd", StringComparison.Ordinal);
                var last = colName.IndexOf("__", StringComparison.Ordinal);

                foreach (var column in ((EventDataProvider)layer.DataSource).EventTable.Columns)
                {
                    if (column.ToString().Contains(((GraduatedTheme)theme).FieldName.Substring(first, last - first)))
                        return true;
                }

                return false;

                //return
                //    ((EventDataProvider) layer.DataSource).EventTable.Columns.Contains(
                //        ((GraduatedTheme) theme).FieldName.Trim(charsToTrim));
            }
            if (theme is GradientTheme)
            {
                var colName = ((GradientTheme) theme).ColumnName;
                var first = colName.IndexOf("gisEnd", StringComparison.Ordinal);
                var last = colName.IndexOf("__", StringComparison.Ordinal);

                foreach (var column in ((EventDataProvider)layer.DataSource).EventTable.Columns)
                {
                    if (column.ToString().Contains(((GradientTheme) theme).ColumnName.Substring(first, last - first)))
                        return true;
                }

                return false;

                //return
                //    ((EventDataProvider)layer.DataSource).EventTable.Columns.Contains(((GradientTheme)theme).ColumnName.Substring(first, last - first));
                //((GradientTheme) theme).ColumnName.Trim(charsToTrim));
            }
            if (theme is BarChartTheme)
            {
                var lstItems = ((BarChartTheme) theme).BarChartItems;
                return
                    lstItems.Select(
                        barChartItem =>
                        ((EventDataProvider) layer.DataSource).EventTable.Columns.Contains(barChartItem.ColumnName))
                            .All(boolContains => boolContains);
            }
            if (theme is RuleBasedTheme)
            {
                
            }

            return true;
        }

        //private bool m_SettingsAssigned = false;
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
                LayerGroup eventGroup = null;

                foreach (LayerGroup layer in m_mapImage.Map.Layers.OfType<LayerGroup>())
                {
                    eventGroup = layer;
                    if (eventGroup.Tag.ToString() != "eventgroup") continue;

                    eventGroup = layer;
                    break;
                }

                if (eventGroup != null)
                {
                    var pos = m_mapImage.Map.Layers.IndexOf(eventGroup);
                    m_mapImage.Map.Layers.Remove(eventGroup);

                    //Restore map settings
                    if (settings.MapSettings != null)
                    {
                        // TODO: tkobilov - Check all problem types without try-catch
                        try
                        {
                            m_mapImage.Map = EidssMapSerializer.Instance.DeserializeFromDocument(settings.MapSettings);
                            m_mapImage.MapSettings =
                                EidssMapSerializer.Instance.DeserializeSettingsFromDocument(settings.MapSettings);
                        }
                        catch (Exception ex)
                        {
                            Trace.TraceWarning("Can't open map project referenced in MapSettings. Let's use Default map project." + ex);
                        }

                    }
                    //Apply event layer settings and add it to map to specified position
                    if (settings.LayerSettings != null)
                    {
                        //eventGroup =
                        //    GIS_V4.Serializers.LayerSerializers.LayerGroupSerializer.Instance.Deserialize(
                        //        settings.LayerSettings.GetElementById("AVR_Group"));

                        LayerGroup tmpGroup;
                        tmpGroup =
                            GIS_V4.Serializers.LayerSerializers.LayerGroupSerializer.Instance.Deserialize(
                                (XmlElement) settings.LayerSettings.ChildNodes[0]);

                        foreach (var lyr in tmpGroup.Layers)
                        {
                            if (lyr is GIS_V4.Layers.LabelLayer)
                            {
                                foreach (var _lyr in eventGroup.Layers)
                                {
                                    if (_lyr is EventLayer) continue;
                                    if (_lyr is GIS_V4.Layers.LabelLayer)
                                    {
                                        if ((lyr.Tag.ToString() == "event_gradient" &
                                            _lyr.Tag.ToString() == "event_gradient") ||
                                            (lyr.Tag.ToString() == "event_chart" &
                                            _lyr.Tag.ToString() == "event_chart"))
                                        _lyr.Style = lyr.Style;
                                        _lyr.MaxVisible = lyr.MaxVisible;
                                        _lyr.MinVisible = lyr.MinVisible;
                                        ((GIS_V4.Layers.LabelLayer)_lyr).Priority = ((GIS_V4.Layers.LabelLayer)lyr).Priority;
                                        _lyr.Enabled = lyr.Enabled;
                                    }
                                }
                            }
                            if (lyr is EventLayer)
                            {
                                foreach (var _lyr in eventGroup.Layers)
                                {
                                    if (_lyr is GIS_V4.Layers.LabelLayer) continue;
                                    if (_lyr is EventLayer)
                                    {
                                        if (lyr.Tag.ToString() == "event_gradient" &
                                            _lyr.Tag.ToString() == "event_gradient")
                                        {
                                            if (ThemeIsCompatible(((EventLayer) lyr).Theme, (EventLayer) _lyr))
                                            {
                                                // change column name
                                                //((EventLayer) lyr).Theme = ReplaceColumnName((EventLayer) lyr);
                                                
                                                ((EventLayer) _lyr).Theme = ((EventLayer) lyr).Theme;
                                                _lyr.LayerName = lyr.LayerName;
                                                _lyr.Enabled = lyr.Enabled;
                                                _lyr.MaxVisible = lyr.MaxVisible;
                                                _lyr.MinVisible = lyr.MinVisible;
                                                _lyr.Transparency = lyr.Transparency;
                                            }
                                            else
                                            {
                                                MessageForm.Show(
                                                    "Previously saved settings can’t be applied to Gradient layer. Probably you have already changed gradient field of the AVR layer. Default settings will be applied.",
                                                    "Uncompatible Gradient Layer Settings", MessageBoxButtons.OK,
                                                    MessageBoxIcon.Warning);
                                            }
                                        }
                                        if (lyr.Tag.ToString() == "event_chart" & _lyr.Tag.ToString() == "event_chart")
                                        {
                                            if (ThemeIsCompatible(((EventLayer) lyr).Theme, (EventLayer) _lyr))
                                            {
                                                ((EventLayer) _lyr).Theme = ((EventLayer) lyr).Theme;
                                                _lyr.LayerName = lyr.LayerName;
                                                _lyr.Enabled = lyr.Enabled;
                                                _lyr.MaxVisible = lyr.MaxVisible;
                                                _lyr.MinVisible = lyr.MinVisible;
                                                _lyr.Transparency = lyr.Transparency;
                                            }
                                            else
                                            {
                                                MessageForm.Show(
                                                    "Previously saved settings can’t be applied to Chart layer. Probably you have already changed the list of chart fields of the AVR layer. Default settings will be applied.",
                                                    "Uncompatible Chart Layer Settings", MessageBoxButtons.OK,
                                                    MessageBoxIcon.Warning);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //((EventLayer) eventGroup.Layers[0]).Theme = ((EventLayer) tmpGroup.Layers[0]).Theme;
                        //((EventLayer) eventGroup.Layers[2]).Theme = ((EventLayer) tmpGroup.Layers[1]).Theme;
                        
                        
                        m_mapImage.Map.Layers.Insert(settings.Position, eventGroup);
                    }
                    else m_mapImage.Map.Layers.Insert(pos, eventGroup);
                }
            }
            catch (Exception ex)
            {
                ErrorForm.ShowError("ErrMapSettingsDefenition","", ex); 
            }

            // connect symbol set
            var strConnection = ConnectionManager.DefaultInstance.ConnectionString;
            SymbolGallery = new SymbolSet(strConnection);
            try
            {
                UseDynamicData();
            }
            catch(Exception){}

            //Refresh map and map content
            try
            {
                RefreshMap();
                RefreshContent();
            }
            catch (Exception ex)
            {
                ErrorForm.ShowError("ErrRefreshingMap","", ex);
            }

            //m_Settings = _GetMapSettings();
            //m_SettingsAssigned = true;
        }

        public override void LoadMap(string mapName)
        {
            m_ErrorFormShowed = false;

            if (File.Exists(mapName))
            {
                try
                {
                    m_mapImage.Map = EidssMapSerializer.Instance.DeserializeFromFile(mapName);
                }
                catch (Exception)
                {
                    m_mapImage.Map = EidssMapSerializer.Instance.DeserializeFromFile(MapProjectsStorage.DefaultMapPath);
                }
            }
            else
            {
                m_mapImage.Map = EidssMapSerializer.Instance.DeserializeFromFile(MapProjectsStorage.DefaultMapPath);
            }
                
            

            m_mapImage.Map.Size = m_mapImage.Size;
            m_mapImage.Map.ZoomToBox(mtFixedExtent.Extent);
            
            //ADD EVENT LAYER AFTER LOAD MAP!
            RefreshContent();

            TranslateToc(mapName);

            // connect symbol set
            var strConnection = ConnectionManager.DefaultInstance.ConnectionString;
            SymbolGallery = new SymbolSet(strConnection);

            try
            {
                UseDynamicData();
            }
            catch (Exception)
            {
            }

            OnMapLoad(mapName);
        }
        
        /// <summary>
        /// Init default map project
        /// </summary>
        public void InitMap()
        {
            MapSpatRef = CoordinateSystems.SphericalMercatorCS;
            var defPath = string.IsNullOrEmpty(BaseSettings.DefaultMapProject) 
                ? MapProjectsStorage.DefaultMapPath 
                : BaseSettings.DefaultMapProject;
            LoadMap(defPath);
            MapSelector.UpdateValue(GisInterface.GetMapName(defPath));
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
