using System;
using bv.common.Core;
using bv.common.win;
using eidss.avr;
using eidss.avr.BaseComponents.Views;
using eidss.avr.LayoutForm;
using eidss.avr.MapForm;
using eidss.model.Reports.OperationContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock2;
using StructureMap;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class ContextTests
    {
        [TestCleanup]
        public void TearDown()
        {
            MemoryManager.Flush();
        }

        [TestMethod]
        public void ConstructorContextTest()
        {
            Console.WriteLine(@"ConstructorContextTest");
            using (new Context(new ContextKeeper(), "ContextName"))
            {
            }
        }

        [TestMethod]
        public void ContextPropertiesTest()
        {
            Console.WriteLine(@"ContextPropertiesTest");
            var keeper = new ContextKeeper();
            Context context;
            using (context = new Context(keeper, "ContextName"))
            {
                Assert.AreEqual("ContextName", context.ContextName);
                Assert.AreEqual(keeper, context.ContextKeeper);
            }
        }

        [TestMethod]
        public void ContextKeeperTest()
        {
            Console.WriteLine(@"ContextKeeperTest");
            IContextKeeper keeper = new ContextKeeper();
            Assert.IsFalse(keeper.ContainsContext("ContextName"));
            keeper.CreateNewContext("ContextName");
            Assert.IsTrue(keeper.ContainsContext("ContextName"));
        }

        [TestMethod]
        public void ContextKeeperRemoveTest()
        {
            Console.WriteLine(@"ContextKeeperRemoveTest");
            var keeper = new ContextKeeper();
            Context context = keeper.CreateNewContext("ContextName");

            Assert.AreEqual("ContextName", context.ContextName);
            Assert.IsTrue(keeper.ContainsContext("ContextName"));
            keeper.Remove("ContextName");
            Assert.IsFalse(keeper.ContainsContext("ContextName"));
        }

        [TestMethod]
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
            keeper.CreateNewContext(ContextValue.OpenEditor);
            Assert.IsFalse(keeper.ContainsContext("ContextName"));
        }

        // todo [ivan] implement
        private static Container StructureMapContainerInit()
        {
            Container c = new Container();
            c.Configure(r => { });
            return c;
        }
        [TestMethod]
        public void ContextKeeperInPresenterTest()
        {
            Console.WriteLine(@"ContextKeeperInPresenterTest");

            using (PresenterFactory.BeginSharedPresenterTransaction(StructureMapContainerInit(), new BaseForm()))
            {
                var mocks = new Mockery();
                var mapView = mocks.NewMock<IMapView>();
                var layoutDetailView = mocks.NewMock<ILayoutDetailView>();
                Expect.Once.On(mapView).EventAdd("SendCommand", Is.Anything);
                Expect.Once.On(mapView).SetProperty("DBService");

                Expect.Once.On(layoutDetailView).EventAdd("SendCommand", Is.Anything);
               
                Expect.Once.On(layoutDetailView).SetProperty("DBService");

                var presenter1 =
                    PresenterFactory.SharedPresenter[mapView] as MapPresenter;
                Assert.IsNotNull(presenter1);
                var presenter2 =
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
}