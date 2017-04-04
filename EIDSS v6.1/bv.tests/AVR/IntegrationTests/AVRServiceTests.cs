using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.db;
using bv.common.Diagnostics;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.tests.AVR.Helpers;
using bv.tests.common;
using bv.tests.PortManagement;
using bv.tests.Reports;
using DevExpress.XtraEditors;
using eidss.avr.db.AvrEventArgs.AvrEventArgs;
using eidss.avr.db.CacheReceiver;
using eidss.avr.db.Common;
using eidss.avr.db.Complexity;
using eidss.avr.db.DBService;
using eidss.avr.LayoutForm;
using eidss.avr.MainForm;
using eidss.model.Avr.Tree;
using eidss.model.Avr.View;
using eidss.model.AVR.DataBase;
using eidss.model.AVR.ServiceData;
using eidss.model.AVR.SourceData;
using eidss.model.Core.CultureInfo;
using eidss.model.Trace;
using eidss.model.WindowsService;
using eidss.model.WindowsService.Serialization;
using EIDSS.AVR.Service.Scheduler;
using EIDSS.AVR.Service.WcfFacade;
using EIDSS.AVR.Service.WcfService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace bv.tests.AVR.IntegrationTests
{
    [TestClass]
    public class AVRServiceTests
    {
        private static AvrHostKeeper m_HostKeeper;

        private static int m_HumanFieldCount;
        private static int m_VetFieldCount;

        private static TraceHelper m_Trace;
        private const long HumanQueryId = 49539640000000;
        private static string m_ExportUtilFilePath;
        private const int MaxRecursiveLevel = 4;
        private static int m_RecursiveLevel;
        private static readonly string m_MachineConfigName = string.Format("general_{0}.config", Environment.MachineName);

        private static IContainer m_Container;

        // todo [ivan] implement
        private static Container StructureMapContainerInit()
        {
            Container c = new Container();
            c.Configure(r => { r.For<ITraceStrategy>().Use<TraceHelper>(); });
            c.Configure(r => { r.For<ISchedulerConfigurationStrategy>().Use<SchedulerConfigurationStrategy>(); });
            return c;
        }

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            m_Container = StructureMapContainerInit();
            m_Trace = new TraceHelper(TraceHelper.AVRCategory);

            SetFreePortToAvrAndReport();

            DbManagerFactory.SetSqlFactory(new ConnectionCredentials(null, "AvrService").ConnectionString, DatabaseType.Avr);
            DbManagerFactory.SetSqlFactory(new ConnectionCredentials(null, "Archive").ConnectionString, DatabaseType.Archive);
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
            m_HumanFieldCount = DataHelper.GetQueryFieldsCount(49539640000000);
            m_VetFieldCount = DataHelper.GetQueryFieldsCount(49542020000000);

            m_HostKeeper = new AvrHostKeeper(m_Container);

            m_HostKeeper.Open();

            Assembly asm = Assembly.GetExecutingAssembly();
            string exeLocation = Path.GetDirectoryName(Utils.ConvertFileName(asm.Location)) ?? string.Empty;
            if (!Directory.Exists(exeLocation))
            {
                int index = exeLocation.IndexOf("DevelopersBranch_v6", StringComparison.OrdinalIgnoreCase);
                if (index > 0)
                {
                    Directory.CreateDirectory(exeLocation);
                    string realPath = exeLocation.Substring(0, index) +
                                      @"DevelopersBranch_v6\eidss.main\bin\Debug\eidss.avr.export.x86.exe";
                    File.Copy(realPath, exeLocation + @"\eidss.avr.export.x86.exe");
                }
            }

            m_ExportUtilFilePath = Utils.GetFilePathNearAssembly(asm, @"eidss.avr.export.x86.exe");

            DbManagerFactory.SetSqlFactory(new ConnectionCredentials(null, "AvrService").ConnectionString, DatabaseType.Avr);
            DbManagerFactory.SetSqlFactory(new ConnectionCredentials(null, "Archive").ConnectionString, DatabaseType.Archive);
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
            try
            {
                m_HostKeeper.Close();
            }
            catch (Exception ex)
            {
                m_Trace.TraceError(ex);
            }
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            BaseReportTests.LoadAssemblies();
            BaseReportTests.InitDBAndLogin();
        }

        [TestMethod]
        public void AvrServiceHelperCheckAvrServiceAccessTest()
        {
            using (var wrapper = new AvrServiceClientWrapper(m_HostKeeper.CurrentServiceHostURL))
            {
                AvrServiceAccessability access = AvrServiceAccessability.Check(wrapper);
                Assert.IsTrue(access.IsOk);
            }
        }

        [TestMethod]
        public void DoesCachedQueryExistsTest()
        {
            ServiceClientHelper.CallAvrServiceToForceLOHMemoryAllocations();

            bool exists = ServiceClientHelper.DoesCachedQueryExists(-1, "en", false);
            Assert.IsFalse(exists);

            var queryId = 49539640000000;
            ServiceClientHelper.AvrServiceClearQueryCache(queryId);
            exists = ServiceClientHelper.DoesCachedQueryExists(queryId, ModelUserContext.CurrentLanguage, false);
            Assert.IsFalse(exists);

            CachedQueryResult result = ServiceClientHelper.GetAvrServiceQueryResult(queryId, false);
            Assert.IsNotNull(result);

            exists = ServiceClientHelper.DoesCachedQueryExists(queryId, ModelUserContext.CurrentLanguage, false);
            Assert.IsTrue(exists);
            exists = ServiceClientHelper.DoesCachedQueryExists(queryId, ModelUserContext.CurrentLanguage, true);
            Assert.IsFalse(exists);
        }

        [TestMethod]
        public void AvrServiceHelperGetAvrServiceQueryResultTest()
        {
            ServiceClientHelper.CallAvrServiceToForceLOHMemoryAllocations();

            CachedQueryResult result = ServiceClientHelper.GetAvrServiceQueryResult(49539640000000, false);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.QueryTable);
        }

        [TestMethod]
        public void AvrServiceHelperGetAvrServicePivotResultTest()
        {
            ServiceClientHelper.CallAvrServiceToForceLOHMemoryAllocations();

            AvrServicePivotResult result = ServiceClientHelper.GetAvrServicePivotResult("xxx", -1);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsNotNull(result.Model.ViewHeader);
            Assert.IsNotNull(result.Model.ViewData);
        }

        [TestMethod]
        public void AvrServiceHelperGetAvrServiceChartResultTest()
        {
            var tableModel = new ChartTableModel(-1, ModelUserContext.CurrentLanguage,
                ExportChartToJpgTests.CreateChartData(), null, null, null, 1000, 750);
            AvrServiceChartResult result = ServiceClientHelper.GetAvrServiceChartResult(tableModel);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsOk, result.ErrorMessage);
            Assert.IsNotNull(result.Model);
            Assert.IsNotNull(result.Model.JpgBytes);

            Assert.IsTrue(result.Model.JpgBytes.Length > 0);
            ExportTests.AssertJpeg(result.Model.JpgBytes);
            //File.WriteAllBytes("filexxx.jpg", result.Model);
        }

        [TestMethod]
        public void AvrServiceCopyLayoutTest()
        {
            long id = VirtualLayoutCopierTests.GetFirstlayoutId();
            if (id > 0)
            {
                var tasks = new List<Action>();
                // todo [ivan] change VirtualLayoutCopier to use different connections and test multithread 
                for (int i = 0; i < 1; i++)
                {
                    var copyTask = new Action(() =>
                    {
                        //Assert.IsTrue(false);
                        AvrServiceCopyLayoutResult result = ServiceClientHelper.AvrServiceCopyLayout(id);
                        Assert.IsNotNull(result);
                        Assert.IsTrue(result.IsOk, result.ErrorMessage);
                        Assert.IsTrue(result.Model > 0);
                    });
                    tasks.Add(copyTask);
                }
                Parallel.Invoke(new ParallelOptions {MaxDegreeOfParallelism = 2}, tasks.ToArray());
            }
        }

        [TestMethod]
        public void AvrServiceGetHeaderAndBodyTest()
        {
            using (var wrapper = new AvrServiceClientWrapper(m_HostKeeper.CurrentServiceHostURL))
            {
                const long queryId = 49539640000000;
                const string lang = "en";
                using (new StopwathTransaction("InvalidatePivotCache - 1"))
                {
                    wrapper.InvalidateQueryCacheForLanguage(queryId, lang);
                }
                using (new StopwathTransaction("InvalidatePivotCache - 2"))
                {
                    wrapper.InvalidateQueryCacheForLanguage(queryId, lang);
                }
                using (new StopwathTransaction("GetCachedQueryTableHeader - 1"))
                {
                    wrapper.GetCachedQueryTableHeader(queryId, lang, false);
                }
                using (new StopwathTransaction("GetCachedQueryTableHeader - 2"))
                {
                    wrapper.GetCachedQueryTableHeader(queryId, lang, false);
                }
                QueryTableHeaderDTO headerDTO;
                using (new StopwathTransaction("GetCachedQueryTableHeader - 3"))
                {
                    headerDTO = wrapper.GetCachedQueryTableHeader(queryId, lang, false);
                }

                for (int i = 0; i < headerDTO.PacketCount; i++)
                {
                    using (new StopwathTransaction("Get packet #" + i))
                    {
                        wrapper.GetCachedQueryTablePacket(headerDTO.QueryCacheId, i, headerDTO.PacketCount);
                    }
                }
            }
        }

        [TestMethod]
        public void AvrServiceArchiveTest()
        {
            const long humQueryId = 49539640000000;
            using (var wrapper = new AvrServiceClientWrapper(m_HostKeeper.CurrentServiceHostURL))
            {
                var receiver = new AvrCacheReceiver(wrapper);
                AvrDataTable dataTable;
                using (new StopwathTransaction("++++ Hum - GetCachedQueryTable - en 1"))
                {
                    CachedQueryResult result = receiver.GetCachedQueryTable(humQueryId, "en", true,
                        string.Empty, new LayoutSilentValidatorWaiter());
                    Assert.IsNotNull(result);
                    dataTable = result.QueryTable;
                }
                Assert.IsNotNull(dataTable);

                Assert.AreEqual(m_HumanFieldCount * 2, dataTable.Columns.Count);
                Assert.IsTrue(1500 * 2 < dataTable.Rows.Count);
            }
        }

        [TestMethod]
        public void AvrServiceFullProcessTest()
        {
            const long humQueryId = 49539640000000;
            const long vetQueryId = 49542020000000;
            using (var wrapper = new AvrServiceClientWrapper(m_HostKeeper.CurrentServiceHostURL))
            {
                AvrDataTable dataTable;
                using (new StopwathTransaction("++++ Hum - GetCachedQueryTable - en 1"))
                {
                    var receiver = new AvrCacheReceiver(wrapper);
                    receiver.GetCachedQueryTable(humQueryId, "en", false, string.Empty, new LayoutSilentValidatorWaiter());
                }
                using (new StopwathTransaction("++++ Hum - GetCachedQueryTable - ru"))
                {
                    var receiver = new AvrCacheReceiver(wrapper);
                    receiver.GetCachedQueryTable(humQueryId, "ru", false, string.Empty, new LayoutSilentValidatorWaiter());
                }
                using (new StopwathTransaction("++++ Hum - GetCachedQueryTable - en 2"))
                {
                    var receiver = new AvrCacheReceiver(wrapper);
                    CachedQueryResult result = receiver.GetCachedQueryTable(humQueryId, "en", false, string.Empty,
                        new LayoutSilentValidatorWaiter());
                    Assert.IsNotNull(result);
                    dataTable = result.QueryTable;
                }

                Assert.IsNotNull(dataTable);

                Assert.AreEqual(m_HumanFieldCount * 2, dataTable.Columns.Count);
                Assert.IsTrue(1500 < dataTable.Rows.Count);

                using (new StopwathTransaction("++++ Vet - InvalidateQueryCache - en"))
                {
                    wrapper.InvalidateQueryCacheForLanguage(vetQueryId, "en");
                }
                using (new StopwathTransaction("++++ Vet - GetCachedQueryTable - en 1"))
                {
                    var receiver = new AvrCacheReceiver(wrapper);
                    receiver.GetCachedQueryTable(vetQueryId, "en", false, string.Empty, new LayoutSilentValidatorWaiter());
                }
                using (new StopwathTransaction("++++ Vet - GetCachedQueryTable - en 2"))
                {
                    var receiver = new AvrCacheReceiver(wrapper);
                    CachedQueryResult result = receiver.GetCachedQueryTable(vetQueryId, "en", false, string.Empty,
                        new LayoutSilentValidatorWaiter());
                    Assert.IsNotNull(result);
                    dataTable = result.QueryTable;
                }
                Assert.IsNotNull(dataTable);
                Assert.AreEqual(m_VetFieldCount * 2, dataTable.Columns.Count);
                Assert.IsTrue(1000 < dataTable.Rows.Count);
            }

            using (var wrapper = new AvrServiceClientWrapper(m_HostKeeper.CurrentServiceHostURL))
            {
                using (new StopwathTransaction("++++ Hum - new Client - GetCachedQueryTable - en 1"))
                {
                    var receiver = new AvrCacheReceiver(wrapper);
                    receiver.GetCachedQueryTable(humQueryId, "en", false, string.Empty, new LayoutSilentValidatorWaiter());
                }

                using (new StopwathTransaction("++++ Hum - new Client -  GetCachedQueryTable - en 2"))
                {
                    var receiver = new AvrCacheReceiver(wrapper);
                    receiver.GetCachedQueryTable(humQueryId, "en", false, string.Empty, new LayoutSilentValidatorWaiter());
                }
            }
        }

        [TestMethod]
        public void AvrServiceViewChartTest()
        {
            using (var wrapper = new AvrServiceClientWrapper(m_HostKeeper.CurrentServiceHostURL))
            {
                var receiver = new AvrCacheReceiver(wrapper);
                AvrPivotViewModel view;
                long layoutId = LayoutFormSave();
                using (new StopwathTransaction("++++ GetView ++++"))
                {
                    view = receiver.GetCachedView("xxx", layoutId, "ru");
                }
                Assert.IsNotNull(view);
                Assert.IsNotNull(view.ViewData);
                Assert.IsNotNull(view.ViewHeader);

                ChartExportDTO chartBytes;
                using (new StopwathTransaction("++++ GetChart ++++"))
                {
                    var tableModel = new ChartTableModel(layoutId, "ru", ExportChartToJpgTests.CreateChartData(), null, DBChartType.chrBar,
                        null,
                        1000, 750);

                    chartBytes = receiver.ExportChartToJpg(tableModel);
                }
                Assert.IsNotNull(chartBytes);
                Assert.IsNotNull(chartBytes.JpgBytes);
                Assert.IsTrue(chartBytes.JpgBytes.Length > 0);
                ExportTests.AssertJpeg(chartBytes.JpgBytes);
                //File.WriteAllBytes("filexx.jpg", chartBytes);
            }
        }

        [TestMethod]
        public void AvrServiceViewSaveInvalidateTest()
        {
            using (var wrapper = new AvrServiceClientWrapper(m_HostKeeper.CurrentServiceHostURL))
            {
                var receiver = new AvrCacheReceiver(wrapper);
                AvrPivotViewModel view;
                long layoutId = LayoutFormSave();
                using (new StopwathTransaction("++++ GetView ++++"))
                {
                    view = receiver.GetCachedView("xxx", layoutId, "ru");
                }
                Assert.IsNotNull(view);
                Assert.IsNotNull(view.ViewData);
                Assert.IsNotNull(view.ViewHeader);

                using (new StopwathTransaction("++++ InvalidateView ++++"))
                {
                    wrapper.InvalidateViewCache(layoutId);
                }
            }
        }

        [TestMethod]
        public void LayoutFormLoadSaveTest()
        {
            LayoutFormLoadSave(false);
        }

        [TestMethod]
        public void InternalExportTest()
        {
            Assert.IsTrue(File.Exists(m_ExportUtilFilePath));

            // Start the child process.
            var process = new Process
            {
                StartInfo =
                {
                    // Redirect the output stream of the child process.
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    FileName = m_ExportUtilFilePath,
                },
            };
            process.Start();

            // Read the output stream first and then wait  for the child process to exit 
            string output = process.StandardOutput.ReadToEnd();
            Assert.IsNotNull(output);
            AvrAccessExportResult result = AvrAccessExportResult.Deserialize(output);
            Assert.IsNotNull(result);
            process.WaitForExit();
        }

        [TestMethod]
        public void ExportNonExistingQueryTest()
        {
            AvrAccessExportResult result = AccessExporter.ExportX86(1, "en", GetTempFilePath());
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsOk);
        }

        [TestMethod]
        public void ExportSuccessEnX86Test()
        {
            AvrAccessExportResult result = AccessExporter.ExportX86(HumanQueryId, "en", GetTempFilePath());
            Assert.IsNotNull(result);
            Console.WriteLine(result.ExceptionString);
            Assert.IsTrue(result.IsOk);
        }

        [TestMethod]
        public void ExportSuccessRuX86Test()
        {
            AvrAccessExportResult result = AccessExporter.ExportX86(HumanQueryId, "ru", GetTempFilePath());
            Assert.IsNotNull(result);
            Console.WriteLine(result.ExceptionString);
            Assert.IsTrue(result.IsOk);
        }

        [TestMethod]
        public void ExportFailsX64Test()
        {
            AvrAccessExportResult result = AccessExporter.ExportX64(HumanQueryId, "en", GetTempFilePath());
            Assert.IsNotNull(result);
            Console.WriteLine(result.ExceptionString);
            Assert.IsFalse(result.IsOk);
        }

        [TestMethod]
        public void LayoutBindingTest()
        {
            AvrMainForm avrMainForm;
            LayoutDetailPanel layoutDetail = ViewHelper.CreateLayoutControls(out avrMainForm);

            object id = -1;
            layoutDetail.LoadData(ref id);

            avrMainForm.Dispose();
        }

        [TestMethod]
        public void NewLayoutLoadDataTest()
        {
            //PresenterFactory.Init(new BaseForm());

            var avrMainForm = new AvrMainForm();
            var args = new AvrTreeSelectedElementEventArgs(BaseReportTests.QueryId, -1, BaseReportTests.QueryId, -1,
                AvrTreeElementType.Layout);

            avrMainForm.OpenEditor(args, true);

            avrMainForm.Dispose();
        }

        [TestMethod]
        public void NewQueryLoadDataTest()
        {
            var avrMainForm = new AvrMainForm();
            var args = new AvrTreeSelectedElementEventArgs(BaseReportTests.QueryId, -1, null, -1, AvrTreeElementType.Query);
            avrMainForm.OpenEditor(args, true);
            avrMainForm.Dispose();
        }

        [TestMethod]
        public void GetCachedViewTest()
        {
            BaseReportTests.InitDBAndLogin();

            var facade = new AVRFacade(m_Container);
            long layoutId = LayoutFormSave();

            List<long> queryIdList = facade.GetQueryIdList();
            Assert.IsNotNull(queryIdList);
            Assert.IsTrue(queryIdList.Count > 0);

            List<long> layoutIdList = facade.GetLayoutIdList();
            Assert.IsNotNull(layoutIdList);
            Assert.IsTrue(layoutIdList.Count > 0);

            ViewDTO model = facade.GetCachedView("xxx", layoutId, "en");

            Assert.IsNotNull(model);
            Assert.IsNotNull(model.BinaryViewHeader);
            Assert.IsNotNull(model.Header);
            Assert.IsNotNull(model.BodyPackets);

            byte[] unzippedViewStructure = BinaryCompressor.Unzip(model.BinaryViewHeader);
            string xmlViewStructure = BinarySerializer.DeserializeToString(unzippedViewStructure);
            AvrView view = AvrViewSerializer.Deserialize(xmlViewStructure);
            string viewXmlNew = AvrViewSerializer.Serialize(view);
            Assert.IsNotNull(viewXmlNew);

            BaseTableDTO unzippedDTO = BinaryCompressor.Unzip(model);
            DataTable viewData = BinarySerializer.DeserializeToTable(unzippedDTO);
            string dataXmlNew = DataTableSerializer.Serialize(viewData);
            Assert.IsNotNull(dataXmlNew);
        }

        #region Helper methods

        private static string GetTempFilePath()
        {
            return Guid.NewGuid().ToString().Substring(4) + ".mdb";
        }

        public static long LayoutFormSave()
        {
            using (new CultureInfoTransaction(new CultureInfo("ru-RU")))
            {
                AvrMainForm avrMainForm;
                ViewHelper.CreateLayoutControls(out avrMainForm);
                var newLayoutArgs = new AvrTreeSelectedElementEventArgs(BaseReportTests.QueryId, -1, BaseReportTests.QueryId, -1,
                    AvrTreeElementType.Layout);
                avrMainForm.OpenEditor(newLayoutArgs, true);

                LayoutDetailPanel layoutDetail = null;
                foreach (IRelatedObject child in avrMainForm.Children)
                {
                    if (child is LayoutDetailPanel)
                    {
                        layoutDetail = child as LayoutDetailPanel;
                    }
                }
                Assert.IsNotNull(layoutDetail);
                Assert.IsNotNull(layoutDetail.baseDataSet);

                string defaultLayoutName = "Some layout_" + Guid.NewGuid();
                string layoutName = "Russian layout_" + Guid.NewGuid();
                string description = "Description " + Guid.NewGuid();
                DataRow dataRow = layoutDetail.baseDataSet.Tables["Layout"].Rows[0];

                BindLayoutDataTable(layoutDetail, dataRow, defaultLayoutName, layoutName, description, true, 10039002);

                layoutDetail.LayoutPost();
                Assert.IsTrue(avrMainForm.ForcePost(), "Layout could not be posted: " + avrMainForm.DbService.LastError);

                var layoutId = (long) dataRow["idflLayout"];
                Assert.IsTrue(layoutId > -1);

                avrMainForm.Dispose();

                return layoutId;
            }
        }

        private void LayoutFormLoadSave(bool needBind)
        {
            using (new CultureInfoTransaction(new CultureInfo("ru-RU")))
            {
                AvrMainForm avrMainForm;
                ViewHelper.CreateLayoutControls(out avrMainForm);
                var newLayoutArgs = new AvrTreeSelectedElementEventArgs(BaseReportTests.QueryId, -1, BaseReportTests.QueryId, -1,
                    AvrTreeElementType.Layout);
                avrMainForm.OpenEditor(newLayoutArgs, true);

                LayoutDetailPanel layoutDetail = null;
                foreach (IRelatedObject child in avrMainForm.Children)
                {
                    if (child is LayoutDetailPanel)
                    {
                        layoutDetail = child as LayoutDetailPanel;
                    }
                }
                Assert.IsNotNull(layoutDetail);
                Assert.IsNotNull(layoutDetail.baseDataSet);

                string defaultLayoutName = "Some layout " + Guid.NewGuid();
                string layoutName = "Russian layout " + Guid.NewGuid();
                string mapName = "Russian map " + Guid.NewGuid();
                string chartName = "Russian chart " + Guid.NewGuid();
                string description = "Description " + Guid.NewGuid();
                DataRow dataRow = layoutDetail.baseDataSet.Tables["Layout"].Rows[0];

                if (needBind)
                {
                    BindLayoutControls(layoutDetail, dataRow, defaultLayoutName, layoutName, chartName,
                        mapName, description, true, 2);
                }
                else
                {
                    BindLayoutDataTable(layoutDetail, dataRow, defaultLayoutName, layoutName, description, true, 10039002);
                }
                layoutDetail.LayoutPost();
                Assert.IsTrue(avrMainForm.ForcePost(), "Layout could not be posted: " + avrMainForm.DbService.LastError);

                var layoutId = (long) dataRow["idflLayout"];
                Assert.IsTrue(layoutId > -1);

                avrMainForm.OpenEditor(newLayoutArgs, true);

                var existLayoutArgs = new AvrTreeSelectedElementEventArgs(BaseReportTests.QueryId, layoutId, BaseReportTests.QueryId, -1,
                    AvrTreeElementType.Layout);

                avrMainForm.OpenEditor(existLayoutArgs);

                foreach (IRelatedObject child in avrMainForm.Children)
                {
                    if (child is LayoutDetailPanel)
                    {
                        layoutDetail = child as LayoutDetailPanel;
                    }
                }
                Assert.IsNotNull(layoutDetail);
                Assert.IsNotNull(layoutDetail.baseDataSet);

                dataRow = layoutDetail.baseDataSet.Tables["Layout"].Rows[0];
                AssertData(dataRow, defaultLayoutName, layoutName, description, true, 10039002);

                defaultLayoutName = "Some layout " + Guid.NewGuid();
                layoutName = "Russian layout " + Guid.NewGuid();
                mapName = "Russian map " + Guid.NewGuid();
                chartName = "Russian chart " + Guid.NewGuid();
                description = "Description " + Guid.NewGuid();

                if (needBind)
                {
                    BindLayoutControls(layoutDetail, dataRow, defaultLayoutName, layoutName, chartName, mapName, description, false, 3);
                }
                else
                {
                    BindLayoutDataTable(layoutDetail, dataRow, defaultLayoutName, layoutName, description,
                        false, 10039004);
                }
                layoutDetail.LayoutPost();
                AssertData(dataRow, defaultLayoutName, layoutName, description, false, 10039004);
                avrMainForm.Dispose();
            }
        }

        private void BindLayoutControls
            (Control layoutDetail, DataRow dataRow, string defaultLayoutName,
                string layoutName, string chartName, string mapName, string description, bool blnValue,
                long checkIndex)
        {
            dataRow["idflQuery"] = BaseReportTests.QueryId;
            //pivot
            var tbDefaultLayoutName = FindAndCheck<TextEdit>(layoutDetail, "tbDefaultLayoutName");
            var tbLayoutName = FindAndCheck<TextEdit>(layoutDetail, "tbLayoutName");

            var tbChartName = FindAndCheck<TextEdit>(layoutDetail, "tbChartName");

            var memDescription = FindAndCheck<MemoEdit>(layoutDetail, "memDescription");
            var ceShareLayout = FindAndCheck<CheckEdit>(layoutDetail, "ceShareLayout");
            var chkApplyFilter = FindAndCheck<CheckEdit>(layoutDetail, "chkApplyFilter");
            var cbGroupInterval = FindAndCheck<LookUpEdit>(layoutDetail, "cbGroupInterval");
            var ccbShowTotals = FindAndCheck<CheckedComboBoxEdit>(layoutDetail, "ccbShowTotals");
            // chart
            var checkShowXAxesLabels = FindAndCheck<CheckEdit>(layoutDetail, "checkShowXAxesLabels");
            var checkPointLabels = FindAndCheck<CheckEdit>(layoutDetail, "checkPointLabels");
            var checkPivotAxes = FindAndCheck<CheckEdit>(layoutDetail, "checkPivotAxes");
            var cbChart = FindAndCheck<LookUpEdit>(layoutDetail, "cbChart");
            //map
            var tbMapName = FindAndCheck<TextEdit>(layoutDetail, "tbMapName");

            using (var bindingHelper = new BindingHelper(dataRow))
            {
                //pivot
                bindingHelper.CheckTextBinding(tbDefaultLayoutName, "strDefaultLayoutName", defaultLayoutName);
                bindingHelper.CheckTextBinding(tbLayoutName, "strLayoutName", layoutName);

                bindingHelper.CheckTextBinding(memDescription, "strDescription", description);
                bindingHelper.CheckBoolBinding(ceShareLayout, "blnShareLayout", blnValue);
                bindingHelper.CheckBoolBinding(chkApplyFilter, "blnApplyPivotGridFilter", blnValue);
                bindingHelper.CheckComboBinding(cbGroupInterval, "idfsGroupInterval", checkIndex);
                bindingHelper.CheckComboBinding(ccbShowTotals, blnValue);

                //chart
                bindingHelper.CheckTextBinding(tbChartName, "strChartName", chartName);
                bindingHelper.CheckBoolBinding(checkShowXAxesLabels, "blnShowXLabels", blnValue);
                bindingHelper.CheckBoolBinding(checkPivotAxes, "blnPivotAxis", blnValue);
                bindingHelper.CheckBoolBinding(checkPointLabels, "blnShowPointLabels", blnValue);
                bindingHelper.CheckComboBinding(cbChart, "idfsChartType", checkIndex);
                //map
                bindingHelper.CheckTextBinding(tbMapName, "strMapName", mapName);
            }
        }

        private static void BindLayoutDataTable
            (Control layoutDetail, DataRow dataRow, string defaultLayoutName,
                string layoutName, string description, bool blnValue, long groupInterval)
        {
            var tbDefaultLayoutName = FindAndCheck<TextEdit>(layoutDetail, "DefLayoutNameTextEdit");
            tbDefaultLayoutName.Text = defaultLayoutName;
            var tbLayoutName = FindAndCheck<TextEdit>(layoutDetail, "NationalLayoutNameTextEdit");
            tbLayoutName.Text = layoutName;

            dataRow["idflQuery"] = BaseReportTests.QueryId;
            dataRow["strDefaultLayoutName"] = defaultLayoutName;
            dataRow["strLayoutName"] = layoutName;
            //            //todo:[ivan] move to the MapPanel DbService 
            //dataRow["strChartName"] = chartName;
            //dataRow["strMapName"] = mapName;
            dataRow["strDescription"] = description;
            dataRow["blnShareLayout"] = blnValue;
            dataRow["blnApplyPivotGridFilter"] = blnValue;
            dataRow["idfsDefaultGroupDate"] = groupInterval;
            //dataRow["blnShowXLabels"] = blnValue;
            //dataRow["blnShowPointLabels"] = blnValue;
            //dataRow["blnPivotAxis"] = blnValue;

            dataRow["blnShowColsTotals"] = blnValue;
            dataRow["blnShowRowsTotals"] = !blnValue;
            dataRow["blnShowColGrandTotals"] = blnValue;
            dataRow["blnShowRowGrandTotals"] = !blnValue;
            dataRow["blnShowForSingleTotals"] = blnValue;
            //  dataRow["blnShowPointLabels"] = blnValue;
            // dataRow["idfsChartType"] = chartType;
        }

        private static void AssertData
            (DataRow dataRow, string defaultLayoutName, string layoutName, string description,
                bool blnValue, long groupInterval)
        {
            Assert.AreEqual(dataRow["strDefaultLayoutName"], defaultLayoutName);
            Assert.AreEqual(dataRow["strLayoutName"], layoutName);

            //     Assert.AreEqual(dataRow["strChartName"], chartName);
            //     Assert.AreEqual(dataRow["strMapName"], mapName);
            Assert.AreEqual(dataRow["strDescription"], description);
            Assert.AreEqual(dataRow["blnShareLayout"], blnValue);
            Assert.AreEqual(dataRow["blnApplyPivotGridFilter"], blnValue);
            Assert.AreEqual(dataRow["idfsDefaultGroupDate"], groupInterval);
            //   Assert.AreEqual(dataRow["blnShowXLabels"], blnValue);
            //  Assert.AreEqual(dataRow["blnShowPointLabels"], blnValue);
            //   Assert.AreEqual(dataRow["blnPivotAxis"], blnValue);

            Assert.AreEqual(dataRow["blnShowColsTotals"], blnValue);
            Assert.AreEqual(dataRow["blnShowRowsTotals"], !blnValue);
            Assert.AreEqual(dataRow["blnShowColGrandTotals"], blnValue);
            Assert.AreEqual(dataRow["blnShowRowGrandTotals"], !blnValue);
            Assert.AreEqual(dataRow["blnShowForSingleTotals"], blnValue);
            //    Assert.AreEqual(dataRow["blnShowPointLabels"], blnValue);
            //      Assert.AreEqual(dataRow["idfsChartType"], chartType);
        }

        private static T FindAndCheck<T>(Control parent, string name) where T : Control
        {
            var found = Find<T>(parent, name);
            Assert.IsNotNull(found);
            return found;
        }

        private static T Find<T>(Control parent, string name) where T : Control
        {
            if ((parent.Name == name) && (parent is T))
            {
                return (T) parent;
            }
            foreach (Control child in parent.Controls)
            {
                var result = Find<T>(child, name);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }

        private static void SetFreePortToAvrAndReport()
        {
            if (Config.GetBoolSetting("UsePortManager"))
            {
                var executingPath = Utils.GetExecutingPath();
                string appPath = Path.GetDirectoryName(executingPath);
                if (appPath == null)
                {
                    throw new ApplicationException(string.Format("Could not find path {0}", executingPath));
                }
                var dir = new DirectoryInfo(appPath);
                var fileName = FindFileRecursive(dir, m_MachineConfigName);
                if (string.IsNullOrEmpty(fileName))
                {
                    throw new ApplicationException("Could not find machine config");
                }

                FileAttributes attr = File.GetAttributes(fileName);
                if ((attr & FileAttributes.ReadOnly) != 0)
                {
                    attr = attr & (~FileAttributes.ReadOnly);
                    File.SetAttributes(fileName, attr);
                }
                var configText = File.ReadAllText(fileName);
                ushort port1 = 8072;
                ushort port2 = 8098;

                using (var portManager = new PortManagerContractClient())
                {
                    port1 = portManager.GetFreePort(port1, ushort.MaxValue);
                    port2 = portManager.GetFreePort(port2, ushort.MaxValue);
                }

                var appendSettings = string.Format(@"

        <add key=""AVRServiceHostURL"" value=""http://localhost:{0}/"" /> 
        <add key=""ReportServiceHostURL"" value=""http://localhost:{1}/"" /> 
    </appSettings>", port1, port2);
                var updatedText = configText.Replace("</appSettings>", appendSettings);
                File.WriteAllText(fileName, updatedText);
                Config.ReloadSettings();
            }
        }

        public static string FindFileRecursive(DirectoryInfo dir, string fileName)
        {
            if (m_RecursiveLevel >= MaxRecursiveLevel || dir == null)
            {
                return null;
            }
            m_RecursiveLevel += 1;
            try
            {
                var foundFile = FindConfigFileInFolder(dir.FullName, fileName);
                if (!string.IsNullOrEmpty(foundFile))
                {
                    return foundFile;
                }

                if (dir.Parent == null)
                {
                    return null;
                }
                return FindFileRecursive(dir.Parent, fileName);
            }
            catch (Exception ex)
            {
                Dbg.Debug("error during cofig reading: {0}", ex);
                return null;
            }
            finally
            {
                m_RecursiveLevel -= 1;
            }
        }

        public static string FindConfigFileInFolder(string dir, string fileName)
        {
            if (!dir.EndsWith("\\"))
            {
                dir = dir + "\\";
            }
            string configPath = dir + fileName;
            if (File.Exists(configPath))
            {
                return configPath;
            }
            return null;
        }

        #endregion
    }
}