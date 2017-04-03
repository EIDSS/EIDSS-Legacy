using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using bv.model.Model.Core;
using eidss.gis.Data.Providers;
using eidss.model.Core;
using eidss.model.Resources;
using GIS_V4.Serializers;
using eidss.gis.Properties;

namespace eidss.gis.Utils
{
    public static class MapProjectsStorage
    {
        public static readonly string ProjectsPath = Path.GetDirectoryName(Assembly.GetCallingAssembly().CodeBase).Replace("file:\\", "") + @"\MapProjects\";
        public static readonly string CustomProjectsPath = Directory.GetParent(Application.CommonAppDataPath).FullName + @"\CustomMapProjects\";

        
        public static string DefaultMapPath
        {
            get
            {
                string countryCode = EidssSiteContext.Instance.CountryHascCode.Substring(0,2);
                string localizedProject = string.Format("Default.{0}.map", countryCode);
                string mapFileName=File.Exists(Path.Combine(ProjectsPath, localizedProject))?
                    localizedProject:"Default.map";
                return Path.Combine(ProjectsPath, mapFileName);
            }
        }
            
            

        public static string DefaultMapName
        {
            get { return EidssMessages.GetForCurrentLang("strDefault", "Default"); }
        }



        private static List<string> m_MapProjectList = new List<string>();
        
        public static event EventHandler ProjectListUpdated;


        static MapProjectsStorage()
        {
            CheckPrjFolder();
            CheckCustomPrjFolder();
            UpdateMapProjectList();
        }

        public static List<string> ProjectList
        {
            get { return m_MapProjectList;  }
        }

        public static void UpdateMapProjectList()
        {
            m_MapProjectList.Clear();
            CheckCustomPrjFolder();

            //system maps
            m_MapProjectList = new List<string>() { DefaultMapName };//GetMapNames(ProjectsPath);
            //user maps
            m_MapProjectList.AddRange(GetMapNames(CustomProjectsPath));

            if (ProjectListUpdated!=null)
                ProjectListUpdated(null, EventArgs.Empty);
        }
        
        internal static List<string> GetCustomMapsNames()
        {
            return GetMapNames(CustomProjectsPath);
        }


        internal static List<string> GetMapNames(string path, string pattern = "*.map", string except = null)
        {
            var result = new List<string>();
            var directoryInfo = new DirectoryInfo(path);
            foreach (var fileInfo in directoryInfo.GetFiles(pattern))
                if (GetMapName(fileInfo.FullName) != except)
                    result.Add(GetMapName(fileInfo.FullName));
            return result;
        }

        internal static string GetMapFileName(string path, string mapName, string pattern = "*.map")
        {
            var directoryInfo = new DirectoryInfo(path);
            foreach (var fileInfo in directoryInfo.GetFiles(pattern))
                if (GetMapName(fileInfo.FullName) == mapName)
                    return Path.GetFileNameWithoutExtension(fileInfo.FullName);
            return string.Empty;
        }

        internal static string GetMapFullPath(string path, string mapName, string pattern = "*.map")
        {
            var directoryInfo = new DirectoryInfo(path);
            foreach (var fileInfo in directoryInfo.GetFiles(pattern))
                if (GetMapName(fileInfo.FullName) == mapName)
                    return fileInfo.FullName;
            return string.Empty;
        }

        internal static string GetMapName(string fileName)
        {
            var result = string.Empty;
            var xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(fileName);
                var mapNode = xmlDoc.SelectSingleNode("Map");
                var nameNode = mapNode.SelectSingleNode("MapName");
                if (nameNode != null) result = nameNode.InnerText;
                return result;
            }
            catch (Exception ex)
            {
                throw new MapDeserializationException(Resources.gis_MapProjectsStorage_GetMapNameError + ex.Message, ex);
            }
        }


        internal static string TranslateLayerName(string layerName)
        {
            switch (layerName)
            {
                case SystemLayerNames.Countries:
                    return EidssMessages.GetForCurrentLang("gis_LayerNames_Country", "Countries");
                case SystemLayerNames.Regions:
                    return EidssMessages.GetForCurrentLang("gis_LayerNames_Regions", "Regions");
                case SystemLayerNames.Rayons:
                    return EidssMessages.GetForCurrentLang("gis_LayerNames_Rayons", "Rayons");
                case SystemLayerNames.Settlements:
                    return EidssMessages.GetForCurrentLang("gis_LayerNames_Settlements", "Settlements");
                case "gisWKBEarthRoad":
                    return EidssMessages.GetForCurrentLang("gis_LayerNames_EarthRoad", "Earth roads");
                case "gisWKBHighway":
                    return EidssMessages.GetForCurrentLang("gis_LayerNames_Highway", "Highways");
                case "gisWKBInlandWater":
                    return EidssMessages.GetForCurrentLang("gis_LayerNames_InlandWater", "Inland water");
                case "gisWKBLake":
                    return EidssMessages.GetForCurrentLang("gis_LayerNames_Lake", "Lakes");
                case "gisWKBMainRiver":
                    return EidssMessages.GetForCurrentLang("gis_LayerNames_MainRiver", "Main rivers");
                case "gisWKBMajorRoad":
                    return EidssMessages.GetForCurrentLang("gis_LayerNames_MajorRoad", "Major roads");
                case "gisWKBRailroad":
                    return EidssMessages.GetForCurrentLang("gis_LayerNames_Railroad", "Railroads");
                case "gisWKBRiver":
                    return EidssMessages.GetForCurrentLang("gis_LayerNames_River", "Rivers");
                case "gisWKBSea":
                    return EidssMessages.GetForCurrentLang("gis_LayerNames_Sea", "Sea");
                case "gisWKBSmallRiver":
                    return EidssMessages.GetForCurrentLang("gis_LayerNames_SmallRiver", "Small rivers");
                case "gisWKBForest":
                    return EidssMessages.GetForCurrentLang("gis_LayerNames_Forest", "Forests");
                case "gisWKBLanduse":
                    return EidssMessages.GetForCurrentLang("gis_LayerNames_Landuse", "Land use");
                case "gisWKBRuralDistrict":
                    return EidssMessages.GetForCurrentLang("gis_LayerNames_RuralDistrict", "Rural districts");




                default:
                    return layerName;
            }
        }

        #region Internal functions

        internal static void CheckPrjFolder()
        {
            var directoryInfo = new DirectoryInfo(ProjectsPath);
            if (!directoryInfo.Exists) directoryInfo.Create();
        }

        internal static void CheckCustomPrjFolder()
        {
            var directoryInfo = new DirectoryInfo(CustomProjectsPath);
            if (!directoryInfo.Exists) directoryInfo.Create();
        }

        #endregion
    }
}
