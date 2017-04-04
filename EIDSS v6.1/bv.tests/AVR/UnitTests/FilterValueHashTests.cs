using System;
using System.Collections.Generic;
using System.Data;
using EIDSS;
using eidss.avr.QueryBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            hash[LookupTables.Country] = new DataView();

            Assert.IsTrue(hash.ContainsKey("xxx"));
            Assert.IsNotNull(hash[LookupTables.Country]);

            hash.Clear();

            Assert.IsFalse(hash.ContainsKey("xxx"));
            Assert.IsNull(hash[LookupTables.Settlement]);
        }

        [TestMethod]
        public void LookupTest()
        {
            using (var hash = new FilterValueHash())
            {
                Assert.IsNull(hash[LookupTables.Country]);
                Assert.IsNull(hash[LookupTables.Region]);
                Assert.IsNull(hash[LookupTables.Rayon]);
                Assert.IsNull(hash[LookupTables.Settlement]);

                hash[LookupTables.Country] = new DataView();
                hash[LookupTables.Region] = new DataView();
                hash[LookupTables.Rayon] = new DataView();
                hash[LookupTables.Settlement] = new DataView();

                Assert.IsNotNull(hash[LookupTables.Country]);
                Assert.IsNotNull(hash[LookupTables.Region]);
                Assert.IsNotNull(hash[LookupTables.Rayon]);
                Assert.IsNotNull(hash[LookupTables.Settlement]);
            }
        }
    }
}