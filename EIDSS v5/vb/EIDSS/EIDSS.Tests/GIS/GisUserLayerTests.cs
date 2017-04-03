using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Extensions.Forms;
using NUnit.Framework;
using EIDSS.GISControl.Common.Data.Providers;
using bv.common.db.Core;
using SharpMap.Styles;
using SharpMap.Geometries;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using Point = SharpMap.Geometries.Point;

namespace EIDSS.Tests.GIS
{
    //[TestFixture]
    public class GisUserLayerTests : BaseTests
    {
        string connStr = ConnectionManager.DefaultInstance.ConnectionString;

        [TearDown]
        new public void TearDown()
        {
            CleanTables();
        }

        private void CleanTables()
        {
            string cleanQuery = "DELETE FROM dbo.gisUserFeature; DELETE FROM dbo.gisUserLayer;";
            using(SqlConnection connection=new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(cleanQuery, connection))
                    cmd.ExecuteNonQuery();
                connection.Close();
            }
        }


        //------------- UserLayers

        [Test]
        [Ignore("Wait DB")]
        public void GetAllLayers()
        {
            EditableMsSql.GetUserLayer(connStr, 5);

            CleanTables();
            List<UserDbLayerInfo> layers = EditableMsSql.GetUserLayers(connStr);
            Assert.AreEqual(layers.Count, 0);

            
        }

        [Test]
        [Ignore("Wait DB")]
        public void CreateUserLayer()
        {
            //generate layer name
            string layerName = "Layer" + Guid.NewGuid();

            //create new layer
            UserDbLayerInfo info=new UserDbLayerInfo(layerName, new VectorStyle());
            EditableMsSql.AddUserLayer(connStr, info);

            //check layer exists (not very good - need check in table directly)
            List<UserDbLayerInfo> layers = EditableMsSql.GetUserLayers(connStr);
            Assert.IsTrue(layers.Exists(delegate(UserDbLayerInfo layer) { return (layer.Name == layerName); }));
        }
        
        [Test]
        [Ignore("Wait DB")]
        [ExpectedException(typeof(SqlException))]
        public void CreateUserLayer_NameDuplicate()
        {
            //generate layer name
            string layerName = "Layer" + Guid.NewGuid();

            //create new layer
            UserDbLayerInfo info = new UserDbLayerInfo(layerName, new VectorStyle());
            EditableMsSql.AddUserLayer(connStr, info);

            //check layer exists (not very good - need check in table directly)
            List<UserDbLayerInfo> layers = EditableMsSql.GetUserLayers(connStr);
            Assert.IsTrue(layers.Exists(delegate(UserDbLayerInfo layer) { return (layer.Name == layerName); }));

            //add layer with duplicate name - must be ex
            EditableMsSql.AddUserLayer(connStr, info);
        }

        [Test]
        [Ignore("Wait DB")]
        public void DeleteUserLayer()
        {
            //generate layer name
            string layerName = "Layer" + Guid.NewGuid();

            //create new layer
            UserDbLayerInfo info = new UserDbLayerInfo(layerName, new VectorStyle());
            EditableMsSql.AddUserLayer(connStr, info);

            //check layer exists (not very good - need check in table directly)
            List<UserDbLayerInfo> layers = EditableMsSql.GetUserLayers(connStr);
            Assert.IsTrue(layers.Exists(delegate(UserDbLayerInfo layer) { return (layer.Name == layerName); }));

            //delete layer
            info=layers.Find(delegate(UserDbLayerInfo layer) { return (layer.Name == layerName); });
            EditableMsSql.RemoveUserLayer(connStr, info);

            //check layer exists (not very good - need check in table directly)
            layers = EditableMsSql.GetUserLayers(connStr);
            Assert.IsFalse(layers.Exists(delegate(UserDbLayerInfo layer) { return (layer.Name == layerName); }));
        }

        [Test]
        [Ignore("Wait DB")]
        public void UpdateUserLayer()
        {
            //generate layer name
            string layerName = "Layer" + Guid.NewGuid();

            //create new layer
            UserDbLayerInfo info = new UserDbLayerInfo(layerName, new VectorStyle());
            EditableMsSql.AddUserLayer(connStr, info);

            //check layer exists (not very good - need check in table directly)
            List<UserDbLayerInfo> layers = EditableMsSql.GetUserLayers(connStr);
            Assert.IsTrue(layers.Exists(delegate(UserDbLayerInfo layer) { return (layer.Name == layerName); }));

            //check default values
            info = layers.Find(delegate(UserDbLayerInfo layer) { return (layer.Name == layerName); });
            Assert.IsNull(info.Description);
            DateTime lastUpdated = info.LastUpdate;

            //set new values and update 
            string layerNameNew = layerName+Guid.NewGuid();
            info.Name = layerNameNew;
            info.LayerStyle.Outline.DashCap = DashCap.Triangle;
            info.Description = connStr; //for sample
            EditableMsSql.UpdateUserLayer(connStr,info);

            //check updated values
            layers = EditableMsSql.GetUserLayers(connStr);
            
            //check name update
            Assert.IsTrue(layers.Exists(delegate(UserDbLayerInfo layer) { return (layer.Name == layerNameNew); })); //layer with new name must be exists
            Assert.IsFalse(layers.Exists(delegate(UserDbLayerInfo layer) { return (layer.Name == layerName); })); //and with old name - not

            info = layers.Find(delegate(UserDbLayerInfo layer) { return (layer.Name == layerNameNew); });

            //check style update
            Assert.AreEqual(info.LayerStyle.Outline.DashCap, DashCap.Triangle); 

            //check description update
            Assert.AreEqual(info.Description, connStr);


            //check lastupdate date 
            Assert.AreNotEqual(info.LastUpdate,lastUpdated); 
        }


        //------------- UserFeatures

        [Test]
        [Ignore("Wait DB")]
        public void AddGeoms()
        {
            //generate layer name
            string layerName = "Layer" + Guid.NewGuid();

            //create new layer
            UserDbLayerInfo info = new UserDbLayerInfo(layerName, new VectorStyle());
            EditableMsSql.AddUserLayer(connStr, info);

            //check layer exists (not very good - need check in table directly)
            List<UserDbLayerInfo> layers = EditableMsSql.GetUserLayers(connStr);
            Assert.IsTrue(layers.Exists(delegate(UserDbLayerInfo layer) { return (layer.Name == layerName); }));

            //get added layer
            info = layers.Find(delegate(UserDbLayerInfo layer) { return (layer.Name == layerName); });
            
            //check layer features count 
            EditableMsSql userLayer = new EditableMsSql(connStr, info.LayerId);
            int countInLayer=userLayer.GetFeatureCount();
            Assert.AreEqual(countInLayer, 0);

            //add new features
            int countNewFeatures = 10;
            string featName = "Test";
            string featDesc = "Test desc";
            Geometry featGeom = new Point(5, 5);
            float featRadius = 100;
            for (int i = 0; i < countNewFeatures; i++)
            {
                UserDbFeature feature = new UserDbFeature(featName, featDesc, featGeom, featRadius);
                userLayer.AddUserFeature(feature);
            }

            //check layer features count 
            countInLayer = userLayer.GetFeatureCount();
            Assert.AreEqual(countInLayer, countNewFeatures);

            //check features
            List<long> ids=userLayer.GetObjectIDsInView(userLayer.GetExtents().Grow(100, 100));
            foreach (long id in ids)
            {
                UserDbFeature feat = userLayer.GetUserFeature(id);
                Assert.AreEqual(feat.Name, featName);
                Assert.AreEqual(feat.Description, featDesc);
                Assert.AreEqual(feat.Geometry, featGeom);
                Assert.AreEqual(feat.Radius, featRadius);
                Assert.AreEqual(feat.LayerId, info.LayerId);
            }
        }

        [Test]
        [Ignore("Wait DB")]
        public void UpdGeoms()
        {
            //generate layer name
            string layerName = "Layer" + Guid.NewGuid();

            //create new layer
            UserDbLayerInfo info = new UserDbLayerInfo(layerName, new VectorStyle());
            EditableMsSql.AddUserLayer(connStr, info);

            //check layer exists (not very good - need check in table directly)
            List<UserDbLayerInfo> layers = EditableMsSql.GetUserLayers(connStr);
            Assert.IsTrue(layers.Exists(delegate(UserDbLayerInfo layer) { return (layer.Name == layerName); }));

            //get added layer
            info = layers.Find(delegate(UserDbLayerInfo layer) { return (layer.Name == layerName); });

            //check layer features count 
            EditableMsSql userLayer = new EditableMsSql(connStr, info.LayerId);
            int countInLayer = userLayer.GetFeatureCount();
            Assert.AreEqual(countInLayer, 0);

            //add new feature
            string featName = "Test";
            string featDesc = "Test desc";
            Geometry featGeom = new Point(5, 5);
            float featRadius = 100;
            
            UserDbFeature feature = new UserDbFeature(featName, featDesc, featGeom, featRadius);
            userLayer.AddUserFeature(feature);
            

            //check layer features count 
            countInLayer = userLayer.GetFeatureCount();
            Assert.AreEqual(countInLayer, 1); //only one added feat

            //check feature
            List<long> ids = userLayer.GetObjectIDsInView(userLayer.GetExtents().Grow(100, 100));
            UserDbFeature feat = userLayer.GetUserFeature(ids[0]);
            Assert.AreEqual(feat.Name, featName);
            Assert.AreEqual(feat.Description, featDesc);
            Assert.AreEqual(feat.Geometry, featGeom);
            Assert.AreEqual(feat.Radius, featRadius);
            Assert.AreEqual(feat.LayerId, info.LayerId);


            //set new value
            feat.Name = featName = "TestUpd";
            feat.Description = featDesc = "TestUpd desc";
            feat.Geometry = featGeom = new Point(10, 10);
            feat.Radius = featRadius = 200;

            userLayer.UpdateUserFeature(feat);


            //check layer features count 
            countInLayer = userLayer.GetFeatureCount();
            Assert.AreEqual(countInLayer, 1); //only one added feat

            //check updated feature
            ids = userLayer.GetObjectIDsInView(userLayer.GetExtents().Grow(100, 100));
            feat = userLayer.GetUserFeature(ids[0]);
            Assert.AreEqual(feat.Name, featName);
            Assert.AreEqual(feat.Description, featDesc);
            Assert.AreEqual(feat.Geometry, featGeom);
            Assert.AreEqual(feat.Radius, featRadius);
            Assert.AreEqual(feat.LayerId, info.LayerId);
        }

        [Test]
        [Ignore("Wait DB")]
        public void DelGeoms()
        {
            //generate layer name
            string layerName = "Layer" + Guid.NewGuid();

            //create new layer
            UserDbLayerInfo info = new UserDbLayerInfo(layerName, new VectorStyle());
            EditableMsSql.AddUserLayer(connStr, info);

            //check layer exists (not very good - need check in table directly)
            List<UserDbLayerInfo> layers = EditableMsSql.GetUserLayers(connStr);
            Assert.IsTrue(layers.Exists(delegate(UserDbLayerInfo layer) { return (layer.Name == layerName); }));

            //get added layer
            info = layers.Find(delegate(UserDbLayerInfo layer) { return (layer.Name == layerName); });

            //check layer features count 
            EditableMsSql userLayer = new EditableMsSql(connStr, info.LayerId);
            int countInLayer = userLayer.GetFeatureCount();
            Assert.AreEqual(countInLayer, 0);

            //add new features
            int countNewFeatures = 10;
            string featName = "Test";
            string featDesc = "Test desc";
            Geometry featGeom = new Point(5, 5);
            float featRadius = 100;
            for (int i = 0; i < countNewFeatures; i++)
            {
                UserDbFeature feature = new UserDbFeature(featName, featDesc, featGeom, featRadius);
                userLayer.AddUserFeature(feature);
            }

            //check layer features count 
            countInLayer = userLayer.GetFeatureCount();
            Assert.AreEqual(countInLayer, countNewFeatures);

           
            
            //delete all features
            List<long> ids = userLayer.GetObjectIDsInView(userLayer.GetExtents().Grow(100, 100));
            foreach (long id in ids)
                userLayer.RemoveUserFeature(id);

            //check layer features count 
            countInLayer = userLayer.GetFeatureCount();
            Assert.AreEqual(countInLayer, 0); //all maust be deleted
        }
    }
}
