using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using eidss.gis.Serializers;
using SharpMap.Layers;
using SharpMap.Data.Providers;
using ICSharpCode.SharpZipLib.Zip;
using System.Xml;
using SharpMap;
using GdalRasterLayer = GIS_V4.Layers.GdalRasterLayer;

namespace eidss.gis.Utils
{
    //TODO[enikulin]: Need code review! Change zip lib! Vector and raster layer from SharpMap or GIS_V4?

    public static class MapPacker
    {
        static MapPacker()
        {
            if (ZipConstants.DefaultCodePage == 1)
                ZipConstants.DefaultCodePage = 437; //Bug in ZipLib 
        }

        private const string FileTagName = "Filename";
        private const string MapNameTagName = "MapName";

        /// <summary>
        /// Packaging map
        /// </summary>
        /// <param name="map">Map for packaging</param>
        /// <param name="mapName">Name of the map</param>
        /// <param name="packetOutputPath">Output file path</param>
        public static void PackMap(Map map, string mapName, string packetOutputPath)
        {
            string mapFilePath = null;
            try
            {
                ZipFile zipFile = ZipFile.Create(packetOutputPath);

                //maping full name -> short name in arch
                var filenames = new Dictionary<string, string>();

                //add layers data to arc;
                foreach (ILayer layer in map.Layers)
                {
                    string fileName = null;

                    //if shp file get its fileName
                    var vectorLayer = layer as VectorLayer;
                    if (vectorLayer != null)
                    {
                        var prov = vectorLayer.DataSource as ShapeFile;
                        if (prov != null)
                            fileName = prov.Filename;
                    }

                    //if raster get its filename
                    var rastLayer = layer as GdalRasterLayer;
                    if (rastLayer != null)
                        fileName = rastLayer.Filename;



                    //add to arc
                    if (fileName != null)
                    {
                        //search FullPath (if already exist - continue)
                        if (filenames.ContainsKey(fileName))
                            continue; //file already added to arch

                        string shortName = Path.GetFileName(fileName);

                        //search shortName in dictionary (if exist, rename it)
                        if (filenames.ContainsValue(shortName))
                            shortName = Path.GetFileNameWithoutExtension(shortName) + Guid.NewGuid() + Path.GetExtension(shortName);

                        //add to dictionary
                        filenames.Add(fileName, shortName);

                        zipFile.BeginUpdate();
                        CompressFileWithAdditional(fileName, Path.GetFileNameWithoutExtension(shortName), zipFile);
                        zipFile.CommitUpdate();
                    }
                }


                //add  map file to arc
                string mapFileName = mapName + ".map";
                mapFilePath = Path.GetTempPath() + Guid.NewGuid() + ".map";  //+ mapName

                //save as temporary file
                EidssMapSerializer.Instance.SerializeAsFile(map, mapFilePath);
                PrePackParseMapFile(mapFilePath, filenames, mapName);

                //pack map file
                zipFile.BeginUpdate();
                zipFile.Add(mapFilePath, mapFileName);
                zipFile.CommitUpdate();


                //close zip file
                zipFile.Close();

                //delete temporary map file
                File.Delete(mapFilePath);
            }
            catch (Exception)
            {
                //if(File.Exists(packetOutputPath))
                //    File.Delete(packetOutputPath);
                //if (File.Exists(mapFilePath))
                //    File.Delete(mapFilePath);
                throw;
            }
        }



        public delegate bool GetNewMapName(ref string mapName);

        /// <summary>
        /// Unpackaging map
        /// </summary>
        /// <param name="packPath">Path to pack file</param>
        /// <param name="mapOutputFolder">Output folder for unpacking map</param>
        /// <param name="newMapNameDelegate">Delegeate for request new mapName</param>
        public static void UnpackMap(string packPath, string mapOutputFolder, GetNewMapName newMapNameDelegate)
        {
            string newMapDir = Path.Combine(mapOutputFolder, "Map_"+Guid.NewGuid());
            string mapFilePath=null;
            string newMapFilePath = null;

            try
            {
                Directory.CreateDirectory(newMapDir);

                //extract map
                var fastZip = new FastZip();
                fastZip.ExtractZip(packPath, newMapDir, null);

                //copy map file and set new file path
                string[] mapFiles = Directory.GetFiles(newMapDir, "*.map");

                if (mapFiles.Length != 1)
                    throw new ApplicationException(string.Format("MapPack has {0} map files!", mapFiles.Length));
                
                mapFilePath = mapFiles[0];
                newMapFilePath = Path.Combine(mapOutputFolder, Path.GetFileName(mapFilePath));

                //system map directory already contains map with such name
                if (File.Exists(newMapFilePath))
                {
                    if (!newMapNameDelegate(ref newMapFilePath))
                    {
                        Directory.Delete(newMapDir, true);
                        return;
                    }
                }

                File.Copy(mapFilePath, newMapFilePath, true);
                File.Delete(mapFilePath);
                PostUnpackParseMapFile(newMapFilePath, newMapDir);
            }
            catch (Exception)
            {
                if(Directory.Exists(newMapDir))
                    Directory.Delete(newMapDir, true);
                if(File.Exists(newMapFilePath))
                    File.Delete(newMapFilePath);
                if (File.Exists(mapFilePath))
                    File.Delete(mapFilePath);
                throw;
            }
            
        }


        //TODO[enikulin]: make private
        public static void CompressFileWithAdditional(string filePath, string entryName, ZipFile zipFile)
        {
            var file = new FileInfo(filePath);
            var files = file.Directory.GetFiles(Path.GetFileNameWithoutExtension(filePath) + ".*");

            foreach (FileInfo fileInfo in files)
            {
                zipFile.Add(fileInfo.FullName, entryName + Path.GetExtension(fileInfo.FullName));
            }
        }

        public static void PrePackParseMapFile(string mapFilePath, Dictionary<string , string> fileNamesDict, string mapName) 
        {
            var xmlDoc=new XmlDocument();
            xmlDoc.Load(mapFilePath);

            var filenameNodes = xmlDoc.GetElementsByTagName(FileTagName);

            //remake paths
            foreach (XmlNode fileNode in filenameNodes)
            {
               fileNode.InnerText = fileNamesDict.ContainsKey(fileNode.InnerText) ? 
                                            fileNamesDict[fileNode.InnerText] :
                                            Path.GetFileName(fileNode.InnerText);
            }

            //rename map
            var mapnameNode = xmlDoc.GetElementsByTagName(MapNameTagName);
            if (mapnameNode.Count != 1)
                Debug.WriteLine("Map file is broken!");
            else
                mapnameNode[0].InnerText = mapName;

            xmlDoc.Save(mapFilePath);
        }

        public static void PostUnpackParseMapFile(string mapFilePath, string dataPath)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(mapFilePath);

            var filenames = xmlDoc.GetElementsByTagName(FileTagName);

            foreach (XmlNode fileNode in filenames)
            {
                fileNode.InnerText = Path.Combine(dataPath, fileNode.InnerText);
            }

            xmlDoc.Save(mapFilePath);
        }
    }
}
