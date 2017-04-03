using System;
using System.Collections.Generic;
using System.Data;
using EIDSS;
using EIDSS.RAM.QueryBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.common.db.Core;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class FilterValueHashTests
    {
        [TestMethod]
        public void AddTest()
        {
            using (var hash = new FilterValueHash())
            {
                var expected = new object[] {1, 2};
                hash["xxx"] = expected;
                object[] actual = hash["xxx"];
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void UpdateTest()
        {
            using (var hash = new FilterValueHash())
            {
                hash["xxx"] = new object[0];
                var expected = new object[] {1, 2};
                hash["xxx"] = expected;
                object[] actual = hash["xxx"];
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void ContainsTest()
        {
            using (var hash = new FilterValueHash())
            {
                Assert.IsFalse(hash.ContainsKey("xxx"));
                hash["xxx"] = new object[0];
                Assert.IsTrue(hash.ContainsKey("xxx"));
            }
        }

        [TestMethod]
        public void DoesntContainsTest()
        {
            using (var hash = new FilterValueHash())
            {
                try
                {
                    object[] actual = hash["xxx"];
                }
                catch (Exception ex)
                {
                    Assert.IsTrue(ex is KeyNotFoundException);
                }
            }
        }

        [TestMethod]
        public void ClearTest()
        {
            var hash = new FilterValueHash();

            hash["xxx"] = new object[0];
            hash[GisRefereneceType.Country] = new DataView();
            
            Assert.IsTrue(hash.ContainsKey("xxx"));
            Assert.IsNotNull(hash[GisRefereneceType.Country]);

            hash.Clear();

            Assert.IsFalse(hash.ContainsKey("xxx"));
            Assert.IsNull(hash[GisRefereneceType.Settlement]);
        }

        [TestMethod]
        public void LookupTest()
        {
            using (var hash = new FilterValueHash())
            {
                Assert.IsNull(hash[GisRefereneceType.Country]);
                Assert.IsNull(hash[GisRefereneceType.Region]);
                Assert.IsNull(hash[GisRefereneceType.Rayon]);
                Assert.IsNull(hash[GisRefereneceType.Settlement]);

                hash[GisRefereneceType.Country] = new DataView();
                hash[GisRefereneceType.Region] = new DataView();
                hash[GisRefereneceType.Rayon] = new DataView();
                hash[GisRefereneceType.Settlement] = new DataView();

                Assert.IsNotNull(hash[GisRefereneceType.Country]);
                Assert.IsNotNull(hash[GisRefereneceType.Region]);
                Assert.IsNotNull(hash[GisRefereneceType.Rayon]);
                Assert.IsNotNull(hash[GisRefereneceType.Settlement]);

            }
        }
    }
}