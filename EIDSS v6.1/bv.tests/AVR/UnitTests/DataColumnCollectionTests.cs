using System;
using System.Data;
using System.Linq;
using eidss.model.AVR.SourceData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class DataColumnCollectionTests
    {
        [TestMethod]
        [ExpectedException(typeof (DuplicateNameException))]
        public void DuplicateInitColumnCollectionTest()
        {
            new AvrDataColumnCollection(new AvrDataTable())
            {
                {"xx", typeof (int)},
                {"xx", typeof (int)}
            };
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void EmptyColumnCollectionTest()
        {
            new AvrDataColumn("", typeof (int));
        }

        [TestMethod]
        [ExpectedException(typeof (DuplicateNameException))]
        public void DuplicateChangeColumnCollectionTest()
        {
            var collection = new AvrDataColumnCollection(new AvrDataTable())
            {
                {"xx", typeof (int)},
                {"yy", typeof (int)}
            };

            collection[0].ColumnName = "yy";
        }

        [TestMethod]
        public void ColumnCollectionTest()
        {
            var collection = new AvrDataColumnCollection(new AvrDataTable())
            {
                {"xx", typeof (int)},
                {"yy", typeof (string)},
                {"zz", typeof (DateTime)}
            };

            Assert.AreEqual(3, collection.DistinctCount);
            Assert.AreEqual(6, collection.Count);
            Assert.AreEqual("xx", collection[0].ColumnName);
            Assert.AreEqual("yy", collection[2].ColumnName);
            Assert.AreEqual("zz", collection[4].ColumnName);

            Assert.IsTrue(collection.Contains("yy"));
            Assert.IsTrue(collection.Contains(collection[0]));

            Assert.AreEqual(collection["xx"], collection[0]);
            Assert.AreEqual(collection["yy"], collection[2]);

            Assert.IsFalse(collection.Contains("abc"));

            AvrDataColumn columnY = collection["yy"];
            Assert.AreEqual(collection, columnY.Collection);
            
            collection.Remove(columnY);
            Assert.IsNull(columnY.Collection);

            Assert.AreEqual(5, collection.Count);

            collection.Add("yy", typeof (string));
            Assert.AreEqual(7, collection.Count);
        }
    }
}