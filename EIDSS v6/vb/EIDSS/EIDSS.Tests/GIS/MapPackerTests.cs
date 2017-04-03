using System;
using System.Collections.Generic;
using System.Text;
using EIDSS.GISControl.Common.MapPacker;
using NUnit.Framework;
using EIDSS.GISControl.Common;
using System.IO;
using EIDSS.GISControl.Common.Serializers;
using System.Windows.Forms;


namespace EIDSS.Tests.GIS
{
    class MapPackerTests : BaseTests
    {
        [Test]
        [Ignore("devel code")]
        public void TestMapPack()
        {
            string mapFile = @"C:\Temp\tests\test2.map";

            //string inputMap
            string packetOutputPath=@"c:\temp\Test.mpk";


            Map map = MapSerializer.DeserializeFromFile(mapFile, null);

            MapPacker.PackMap(map, "TestMap", packetOutputPath);

            Assert.IsTrue(File.Exists(packetOutputPath));
        }

        [Test]
        [Ignore("devel code")]
        public void TestMapUnPack()
        {
            string packetOutputPath = @"c:\temp\Test.mpk";
            MapPacker.UnpackMap(packetOutputPath, @"C:\Temp\tests2", NewMapName);
        }

        public bool NewMapName(ref string mapName)
        {
            mapName = Path.Combine(Path.GetDirectoryName(mapName), Path.GetFileNameWithoutExtension(mapName)+Guid.NewGuid()+Path.GetExtension(mapName));
            return true;
        }

        [Test]
        [Ignore("devel code")]
        public void TestMapPack2()
        {
            SaveFileDialog saveFileDialog=new SaveFileDialog();
            saveFileDialog.CheckFileExists = true;
            saveFileDialog.Filter.Insert(0, "Map pack files | *.mpk");

            DialogResult dr=saveFileDialog.ShowDialog(null);

            //MessageBox.Show("Would you like export map: {0}?");
                        
            string mapFile = @"C:\Temp\tests\test2.map";

            //string inputMap
            string packetOutputPath = @"c:\temp\Test.mpk";


            Map map = MapSerializer.DeserializeFromFile(mapFile, null);

            MapPacker.PackMap(map, "TestMap", packetOutputPath);

            Assert.IsTrue(File.Exists(packetOutputPath));
        }
    }
}
