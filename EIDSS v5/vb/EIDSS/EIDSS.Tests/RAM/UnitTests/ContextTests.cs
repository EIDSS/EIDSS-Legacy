#region Using

using System;
using System.Data;
using bv.common.win;
using EIDSS.RAM;
using EIDSS.RAM.Presenters;
using EIDSS.RAM_DB.Views;
using EIDSS.Reports.OperationContext;
using NMock2;
using NUnit.Framework;
using Is = NMock2.Is;

#endregion

namespace EIDSS.Tests.RAM.UnitTests
{
    [TestFixture]
    public class ContextTests
    {

        [TearDown]
        public void TearDown()
        {
            GC.Collect();
        }
        [Test]
        public void ConstructorContextTest()
        {
            Console.WriteLine(@"ConstructorContextTest");
            using (new Context(new ContextKeeper(), "ContextName"))
            {
            }
        }

        [Test]
        public void ContextPropertiesTest()
        {
            Console.WriteLine(@"ContextPropertiesTest");
            ContextKeeper keeper = new ContextKeeper();
            Context context;
            using (context = new Context(keeper, "ContextName"))
            {
                Assert.AreEqual("ContextName", context.ContextName);
                Assert.AreEqual(keeper, context.ContextKeeper);
            }
        }

        [Test]
        public void ContextKeeperTest()
        {
            Console.WriteLine(@"ContextKeeperTest");
            IContextKeeper keeper = new ContextKeeper();
            Assert.IsFalse(keeper.ContainsContext("ContextName"));
            keeper.CreateNewContext("ContextName");
            Assert.IsTrue(keeper.ContainsContext("ContextName"));
        }

        [Test]
        public void ContextKeeperRemoveTest()
        {
            Console.WriteLine(@"ContextKeeperRemoveTest");
            ContextKeeper keeper = new ContextKeeper();
            Context context = keeper.CreateNewContext("ContextName");

            Assert.AreEqual("ContextName", context.ContextName);
            Assert.IsTrue(keeper.ContainsContext("ContextName"));
            keeper.Remove("ContextName");
            Assert.IsFalse(keeper.ContainsContext("ContextName"));
        }

        [Test]
        public void ContextKeeperUsingTest()
        {
            Console.WriteLine(@"ContextKeeperUsingTest");
            IContextKeeper keeper = new ContextKeeper();
            using (keeper.CreateNewContext("ContextName"))
            {
                Assert.IsTrue(keeper.ContainsContext("ContextName"));
                keeper.CreateNewContext(ContextValue.DefineBinding);
                using (keeper.CreateNewContext("ContextName"))
                {
                    Assert.IsTrue(keeper.ContainsContext("ContextName"));
                }
                Assert.IsTrue(keeper.ContainsContext("ContextName"));
            }
            keeper.CreateNewContext(ContextValue.DeleteQuery);
            Assert.IsFalse(keeper.ContainsContext("ContextName"));
        }

        [Test]
        public void ContextKeeperInPresenterTest()
        {
            Console.WriteLine(@"ContextKeeperInPresenterTest");
            
            PresenterFactory.Init(new BaseForm());
            Mockery mocks = new Mockery();
            IPivotReportView pivotReportView = mocks.NewMock<IPivotReportView>();
            ILayoutDetailView layoutDetailView = mocks.NewMock<ILayoutDetailView>();
            Expect.Once.On(pivotReportView).EventAdd("SendCommand", Is.Anything);
            Expect.Once.On(pivotReportView).SetProperty("DBService");
            
            Expect.Once.On(layoutDetailView).EventAdd("SendCommand", Is.Anything);
            Expect.Once.On(layoutDetailView).EventAdd("CopyLayoutCreating", Is.Anything);
            Expect.Once.On(layoutDetailView).SetProperty("DBService");
            

            PivotReportPresenter presenter1 =
                PresenterFactory.SharedPresenter[pivotReportView] as PivotReportPresenter;
            Assert.IsNotNull(presenter1);
            LayoutDetailPresenter presenter2 =
                PresenterFactory.SharedPresenter[layoutDetailView] as LayoutDetailPresenter;
            Assert.IsNotNull(presenter2);

            using (presenter1.SharedPresenter.ContextKeeper.CreateNewContext("ContextName"))
            {
                Assert.IsTrue(presenter1.SharedPresenter.ContextKeeper.ContainsContext("ContextName"));
                Assert.IsTrue(presenter2.SharedPresenter.ContextKeeper.ContainsContext("ContextName"));
            }
            Assert.IsFalse(presenter1.SharedPresenter.ContextKeeper.ContainsContext("ContextName"));
            Assert.IsFalse(presenter2.SharedPresenter.ContextKeeper.ContainsContext("ContextName"));
        }
    }
}