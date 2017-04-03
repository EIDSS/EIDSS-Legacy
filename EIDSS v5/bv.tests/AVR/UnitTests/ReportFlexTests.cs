using System.Collections.Generic;
using EIDSS.FlexibleForms.Helpers.ReportHelper.Tree;
using EIDSS.Reports.Flexible.Visitors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class ReportFlexTests
    {
        [TestMethod]
        public void ShouldProcessAstableVisitorTest()
        {
            FlexNode root = FlexNode.CreateRoot();
            root.ProcessAsTable = true;
            root.Add("1");
            Assert.IsFalse(root[0].ProcessAsTable);
            root.AcceptForward(new ShouldProcessAsTableVisitor());
            Assert.IsTrue(root[0].ProcessAsTable);
        }

        [TestMethod]
        public void OrderedChildListTest()
        {
            FlexNode root = FlexNode.CreateRoot();
            root.ProcessAsTable = true;
            root.Add("1");
            root.Add("2");
            root.Add("3");
            Assert.AreEqual(3, root.ChildListCount);

            root[2].DataItem.Top = 1;
            root[2].DataItem.Left = 100;
            root[1].DataItem.Top = 10;
            root[1].DataItem.Left = 10;
            root[0].DataItem.Top = 20;
            root[0].DataItem.Left = 1;

            var ordered = new List<FlexNode>(root.OrderedChildList);

            Assert.AreSame(root[0], ordered[2]);
            Assert.AreSame(root[1], ordered[1]);
            Assert.AreSame(root[2], ordered[0]);


        }
    }
}