using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using BLToolkit.Data;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.db;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.avr.db.CacheReceiver;
using eidss.avr.db.Common;
using eidss.avr.db.DBService;
using eidss.avr.db.DBService.QueryBuilder;
using eidss.avr.mweb.Models;
using eidss.avr.mweb.Utils;
using eidss.model.Avr;
using eidss.model.Avr.Chart;
using eidss.model.AVR.DataBase;
using eidss.model.Avr.Export;
using eidss.model.Avr.Tree;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Resources;
using eidss.web.common.Utils;
using ExportType = eidss.model.Avr.Commands.Export.ExportType;

namespace eidss.avr.mweb.Controllers
{
    [AuthorizeEIDSS]
    public class QueryLayoutTreeController : Controller
    {
        [HttpGet]
        public ActionResult QueryLayoutTree()
        {
            AvrQueryLayoutTreeDbHelper.InitWarnings();
            List<AvrTreeElement> model = RefreshTree();
            return View(model);
        }

        [ValidateInput(false)]
        public ActionResult QueryLayoutTreePartial()
        {
            List<AvrTreeElement> model;

            if (Session["QueryTree"] != null)
            {
                model = Session["QueryTree"] as List<AvrTreeElement>;
            }
            else
            {
                model = RefreshTree();
            }

            return PartialView("QueryLayoutTreePartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult QueryLayoutTreeUpdatePartial(AvrTreeElement treeElement)
        {
            //TODO выводим ошибки ввода куда?
            if (ModelState.IsValid)
            {
                //проверим, были ли изменения
                if (treeElement.ID > 0)
                {
                    List<AvrTreeElement> tree = GetQueryTree();
                    AvrTreeElement elem = tree.FirstOrDefault(c => c.ID == treeElement.ID);
                    if ((elem != null) && treeElement.IsEqual(elem))
                    {
                        //TODO в противном случае надо показать диалог подтверждения сохранения
                        return PartialView("QueryLayoutTreePartial", GetQueryTree());
                    }
                }

                long id = 0;
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
                {
                    try
                    {
                        manager.BeginTransaction();
                        if (treeElement.IsLayout)
                        {
                            AvrQueryLayoutTreeDbHelper.SaveLayoutMetadata(
                                ModelUserContext.CurrentLanguage
                                , treeElement.ID
                                , treeElement.DefaultName
                                , treeElement.NationalName
                                , (long)DBGroupInterval.gitDateYear
                                , treeElement.QueryID
                                , treeElement.DescriptionID
                                , treeElement.Description
                                , treeElement.DescriptionEnglish
                                , treeElement.ReadOnly
                                , treeElement.IsShared
                                );
                            AvrQueryLayoutTreeDbHelper.SaveLayoutLocation(treeElement.ID,
                                treeElement.ParentID != treeElement.QueryID
                                    ? treeElement.ParentID
                                    : null);
                            id = treeElement.ID;
                        }
                        else if (treeElement.IsFolder)
                        {
                            if (treeElement.ParentID == treeElement.QueryID)
                            {
                                treeElement.ParentID = null;
                            }
                            AvrQueryLayoutTreeDbHelper.SaveFolder(treeElement.ID, treeElement.ParentID,
                                treeElement.QueryID,
                                treeElement.DefaultName, treeElement.NationalName);
                            id = treeElement.ID;
                        }

                        //long publishedId = 0;
                        //var eventType = EventType.AVRLayoutFolderPublishedLocal; //только для инициализации
                        //if (id > 0)
                        //{
                        //    if (treeElement.IsPublished && !treeElement.ReadOnly)
                        //    {
                        //        PublishRoutines(treeElement.ID, manager, treeElement.ElementType, true, out publishedId, out eventType);
                        //    }
                        //    else if (!treeElement.IsPublished && treeElement.ReadOnly && treeElement.GlobalID.HasValue)
                        //    {
                        //        PublishRoutines(treeElement.GlobalID.Value, manager, treeElement.ElementType, false, out publishedId,
                        //            out eventType);
                        //    }
                        //}
                        manager.CommitTransaction();

                        if (id > 0)
                        {
                            if (treeElement.IsPublished && !treeElement.ReadOnly)
                            {
                                PublishUnpublish(treeElement.ID, treeElement.ElementType, true);
                            }
                            else if (!treeElement.IsPublished && treeElement.ReadOnly && treeElement.GlobalID.HasValue)
                            {
                                PublishUnpublish(treeElement.ID, treeElement.ElementType, false);
                            }
                        }
                        //if (publishedId > 0)
                        //{
                        //    EidssEventLog.Instance.CreateProcessedEvent(eventType,
                        //        publishedId > 0 ? publishedId : 0, 0,
                        //        EidssUserContext.User.ID,
                        //        manager.Transaction);
                        //}
                    }
                    catch (Exception)
                    {
                        manager.RollbackTransaction();
                        throw;
                    }
                }
                /* TODO вызов обрушивает систему
                LookupManager.ClearByTable("Layout");
                LookupManager.ClearByTable("LayoutFolder");
                LookupManager.ClearByTable("Query");
                LookupManager.ClearAndReloadOnIdle();*/
            }

            RefreshTree();
            return PartialView("QueryLayoutTreePartial", GetQueryTree());
        }

        private bool CanMoveFolder(List<AvrTreeElement> tree, long id, long parentId)
        {
            //проверим, можно ли переместить объект
            //чтобы не было перемещения в свой же дочерний объект
            bool can = false;
            AvrTreeElement node = tree.SingleOrDefault(c => c.ID == id);
            if (node != null)
            {
                List<AvrTreeElement> children = tree.Where(c => c.ParentID == node.ID).ToList();
                //попытка перемещения в потомка
                can = children.All(c => c.ID != parentId);
                if (can)
                {
                    foreach (AvrTreeElement child in children)
                    {
                        if (!CanMoveFolder(tree, child.ID, parentId))
                        {
                            can = false;
                            break;
                        }
                    }
                }
            }
            return can;
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult QueryLayoutTreeMovePartial(long id, long? parentId)
        {
            /*
             Правила:
             * 1) Query (корневой узел) переносить нельзя
             * 2) Layout можно присоединять только к Folder и Query
             * 3) Folder можно присоединять только к Folder и Query, но целевой Folder не может быть дочерним к перетаскиваемому.
             * 4) Объекты можно переносить только в рамках одного Query
             * 5) Published layout cannot be moved
             */

            List<AvrTreeElement> tree = GetQueryTree();
            AvrTreeElement node = tree.SingleOrDefault(c => c.ID == id);
            if (node != null && !node.IsQuery && parentId.HasValue && !node.IsPublished)
            {
                AvrTreeElement newParent = tree.SingleOrDefault(c => c.ID == parentId.Value);
                if (newParent != null && node.QueryID == newParent.QueryID && !newParent.IsLayout)
                {
                    long? pid = newParent.IsQuery ? null : (long?)newParent.ID;
                    if (node.IsLayout)
                    {
                        AvrQueryLayoutTreeDbHelper.SaveLayoutLocation(node.ID, pid);
                    }
                    else if (node.IsFolder)
                    {
                        // check if it is moving to the children or if there is published layout in it
                        bool can = true;
                        if (newParent.IsFolder)
                        {
                            can = CanMoveFolder(tree, node.ID, parentId.Value);
                        }

                        if (can)
                        {
                            AvrQueryLayoutTreeDbHelper.SaveFolder(node.ID, pid,
                                node.QueryID,
                                node.DefaultName,
                                node.NationalName);
                        }
                    }
                    RefreshTree();
                }
            }
            return PartialView("QueryLayoutTreePartial", GetQueryTree());
        }

        [HttpPost]
        public JsonResult CanDeleteTreeNode(long id)
        {
            var tree = GetQueryTree();
            var node = tree.FirstOrDefault(c => c.ID == id);
            var errStr = String.Empty;
            if (node != null && !node.IsPublished)
            {
                if (node.IsFolder)
                {
                    //нужно проверить, что у этого каталога нет дочерних элементов
                    //иначе его нельзя удалять
                    using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        var ps = new List<object>
                            {
                                manager.Parameter("ID", id),
                                manager.Parameter(ParameterDirection.Output, "Result", DbType.Boolean)
                            };

                        var command = manager.SetSpCommand("dbo.spAsFolder_CanDelete", ps.ToArray());

                        var result = Convert.ToBoolean(command.ExecuteScalar<bool>(ScalarSourceType.OutputParameter, "Result"));
                        if (!result)
                        {
                            errStr = EidssMessages.Get("QueryLayoutTree_CantDeleteWithChildren");
                        }
                    }

                    /*
                    if (tree.Any(c => c.ParentID == node.ID))
                    {
                        errStr = EidssMessages.Get("QueryLayoutTree_CantDeleteWithChildren");
                    }
                    */
                }
            }
            else
            {
                errStr = EidssMessages.Get("QueryLayoutTree_CantDeletePublished");
            }

            // show confirmation
            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                {
                    result = errStr.Length == 0 ? "OK" : "ERROR",
                    errorString = errStr
                }
            };
        }

        [HttpPost]
        public ActionResult QueryLayoutTreeDeletePartial(long id)
        {
            //все проверки в CanDelete
            List<AvrTreeElement> tree = GetQueryTree();
            AvrTreeElement node = tree.FirstOrDefault(c => c.ID == id);
            string errStr = String.Empty;
            try
            {
                if (node != null)
                {
                    if (node.IsFolder)
                    {
                        //AvrQueryLayoutTreeDbHelper.DeleteFolder(node.ID);
                        using (var avrDbService = new Folder_DB())
                        {
                            avrDbService.Delete(node.ID);
                        }
                    }
                    else if (node.IsLayout)
                    {
                        using (var avrDbService = new WebLayoutDB())
                        {
                            avrDbService.Delete(node.ID);
                        }
                    }

                    RefreshTree();
                }
            }
            catch (Exception exc)
            {
                errStr = exc.Message;
            }
            return PartialView("QueryLayoutTreePartial", GetQueryTree());
            /*
            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                {
                    result = errStr.Length == 0 ? "OK" : "ERROR",
                    errorString = errStr
                }
            };
             */
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult QueryLayoutTreeAddPartial(AvrTreeElement newNode)
        {
            //делаем дочерний элемент
            HttpCookie cc = Request.Cookies["newElementType"];
            string errStr = String.Empty;
            if ((cc != null) && AvrPermissions.InsertPermission && !IsFolderDepthTooBig(newNode))
            {
                bool createFolder = (newNode.IsFolder || (newNode.IsQuery && cc.Value == "folder"));
                bool createLayout = (newNode.IsLayout || (newNode.IsQuery && cc.Value == "layout"));
                if (createFolder || createLayout)
                {
                    newNode.ElementType = createFolder ? AvrTreeElementType.Folder : AvrTreeElementType.Layout;

                    using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
                    {
                        try
                        {
                            manager.BeginTransaction();
                            long nodeId = NewId();
                            long? parentId = newNode.ParentID != newNode.QueryID ? newNode.ParentID : null;
                            if (createFolder)
                            {
                                AvrQueryLayoutTreeDbHelper.SaveFolder(
                                    nodeId
                                    , parentId
                                    , newNode.QueryID
                                    , newNode.DefaultName
                                    , newNode.NationalName);
                            }
                            else
                            {
                                AvrQueryLayoutTreeDbHelper.SaveLayoutMetadata(
                                    ModelUserContext.CurrentLanguage
                                    , nodeId
                                    , newNode.DefaultName
                                    , newNode.NationalName
                                    , (long)DBGroupInterval.gitDateYear
                                    , newNode.QueryID
                                    , NewId()
                                    , newNode.Description
                                    , newNode.DescriptionEnglish
                                    , false
                                    , newNode.IsShared
                                    );
                                AvrQueryLayoutTreeDbHelper.SaveLayoutLocation(nodeId, parentId);
                            }
                            //long publishedId = 0;
                            //var eventType = EventType.AVRLayoutFolderPublishedLocal; //только для инициализации
                            //if (newNode.IsPublished)
                            //{
                            //    PublishRoutines(nodeId, manager,
                            //        createFolder ? AvrTreeElementType.Folder : AvrTreeElementType.Layout,
                            //        true, out publishedId, out eventType);
                            //}

                            manager.CommitTransaction();
                            if (newNode.IsPublished)
                            {
                                PublishUnpublish(nodeId,
                                    createFolder ? AvrTreeElementType.Folder : AvrTreeElementType.Layout,
                                    true);
                            }
                            //if (publishedId > 0)
                            //{
                            //    EidssEventLog.Instance.CreateProcessedEvent(eventType,
                            //        publishedId > 0 ? publishedId : 0, 0,
                            //        EidssUserContext.User.ID,
                            //        manager.Transaction);
                            //}
                        }
                        catch (Exception exc)
                        {
                            errStr = exc.Message;
                            //TODO куда писать ошибки?
                            manager.RollbackTransaction();
                            throw;
                        }
                    }
                }
            }
            else
            {
                errStr = "error";
            }
            if (errStr.Length == 0)
            {
                RefreshTree();
            }
            return PartialView("QueryLayoutTreePartial", GetQueryTree());
        }

        private List<AvrTreeElement> GetQueryTree()
        {
            return Session["QueryTree"] as List<AvrTreeElement>;
        }

        private List<AvrTreeElement> RefreshTree()
        {
            LookupManager.ClearAndReload("LayoutFolder");
            LookupManager.ClearAndReload("Layout");
            LookupManager.ClearAndReload("Query");
            LookupManager.ClearAndReloadOnIdle();
            var model = AvrQueryLayoutTreeDbHelper.LoadQueriesLayoutsFolders();
            Session["QueryTree"] = model;
            return model;
        }

        private bool IsFolderDepthTooBig(AvrTreeElement node)
        {
            int count = GetParentDepth(node);
            if (node.IsLayout)
            {
                count--;
            }
            return ShowMessageIfFolderDepthTooBig(count);
        }

        private int GetParentDepth(AvrTreeElement node)
        {
            int count = 0;

            var model = Session["QueryTree"] as List<AvrTreeElement>;

            while (node != null)
            {
                if (!node.IsLayout)
                {
                    count++;
                }

                node = model.SingleOrDefault(c => c.ID == node.ParentID);
            }
            return count;
        }

        private static bool ShowMessageIfFolderDepthTooBig(int count)
        {
            int maxDepth = Math.Min(Config.GetIntSetting("MaxRamFolderDepth", 16), 30);
            bool isFolderDepthTooBig = count >= maxDepth;

            return isFolderDepthTooBig;
        }

        private long NewId()
        {
            return BaseDbService.NewIntID();
        }

        private void GetPublishParams
            (bool isPublish, AvrTreeElementType type, out string spName, out string inputParamName, out string outputParamName,
                out EventType eventType)
        {
            outputParamName = null;
            switch (type)
            {
                case AvrTreeElementType.Layout:
                    if (isPublish)
                    {
                        spName = "spAsLayoutPublish";
                        inputParamName = "@idflLayout";
                        outputParamName = "@idfsLayout";
                        eventType = EventType.AVRLayoutPublishedLocal;
                    }
                    else
                    {
                        spName = "spAsLayoutUnpublish";
                        inputParamName = "@idfsLayout";
                        outputParamName = "@idflLayout";
                        eventType = EventType.AVRLayoutUnpublishedLocal;
                    }
                    break;
                case AvrTreeElementType.Folder:
                    if (isPublish)
                    {
                        spName = "spAsFolderPublish";
                        inputParamName = "@idflLayoutFolder";
                        outputParamName = "@idfsLayoutFolder";
                        eventType = EventType.AVRLayoutFolderPublishedLocal;
                    }
                    else
                    {
                        spName = "spAsFolderUnpublish";
                        inputParamName = "@idfsLayoutFolder";
                        outputParamName = "@idflLayoutFolder";
                        eventType = EventType.AVRLayoutFolderUnpublishedLocal;
                    }
                    break;
                case AvrTreeElementType.Query:
                    if (isPublish)
                    {
                        spName = "spAsQueryPublish";
                        inputParamName = "@idflQuery";
                        outputParamName = "@idfsQuery";
                        eventType = EventType.AVRQueryPublishedLocal;
                    }
                    else
                    {
                        spName = "spAsQueryUnpublish";
                        inputParamName = "@idfsQuery";
                        outputParamName = "@idflQuery";
                        eventType = EventType.AVRQueryUnpublishedLocal;
                    }
                    break;
                default:
                    throw new AvrException("Unsupported AvrTreeElementType " + type);
            }
        }

        private void PublishUnpublish(long id, AvrTreeElementType type, bool isPublish)
        {

            switch (type)
            {
                case AvrTreeElementType.Query:
                    using (var service = new Query_DB())
                    {
                        service.PublishUnpublish(id, isPublish);
                    }
                    break;
                case AvrTreeElementType.Layout:
                    using (var service = new WebLayoutDB())
                    {
                        service.PublishUnpublish(id, isPublish);
                    }
                    break;
                case AvrTreeElementType.Folder:
                    using (var service = new Folder_DB())
                    {
                        service.PublishUnpublish(id, isPublish);
                    }
                    break;
                default:
                    throw new AvrException("Unsupported AvrTreeElementType " + type);
            }

        }

        //private void PublishRoutines
        //    (long id, DbManagerProxy manager, AvrTreeElementType type, bool isPublish, out long eventObjectId, out EventType eventType)
        //{
        //    //TODO может быть, в какой-то хелпер перенести?
        //    string spName;
        //    string inputParamName;
        //    string outputParamName;

        //    GetPublishParams(isPublish, type, out spName, out inputParamName, out outputParamName, out eventType);

        //    var ps = new List<object> {manager.Parameter(inputParamName, id)};
        //    ps.Add(manager.Parameter(ParameterDirection.Output, outputParamName, DbType.Int64));

        //    DbManager command = manager.SetSpCommand(spName, ps.ToArray());

        //    eventObjectId = Convert.ToInt64(command.ExecuteScalar<long>(ScalarSourceType.OutputParameter));
        //}

        [HttpPost]
        public JsonResult EditTreeNode(AvrTreeElement node, FormCollection coll)
        {
            bool isNew = node.ID == 0;
            string errstr;
            string mesText = "Error";

            bool isLayout;
            Boolean.TryParse(coll["IsLayout"], out isLayout);
            string nationalName = isLayout ? Translator.GetString("LayoutNameNational") : Translator.GetString("FolderNameNational");
            string defaultName = isLayout ? Translator.GetString("LayoutNameEnglish") : Translator.GetString("FolderNameEnglish");

            bool isEnglish;
            Boolean.TryParse(coll["IsEnglish"], out isEnglish);

            bool isValid = true;
            if (String.IsNullOrEmpty(node.DefaultName))
            {
                isValid = false;
                mesText = String.Format(Translator.GetBvMessageString("ErrMandatoryFieldRequired"), defaultName);
            }
            else if (!isEnglish && String.IsNullOrEmpty(node.NationalName))
            {
                isValid = false;
                mesText = String.Format(Translator.GetBvMessageString("ErrMandatoryFieldRequired"), nationalName);
            }

            if (isValid)
            {
                if (isNew)
                {
                    HttpCookie cc = Request.Cookies["newElementType"];
                    if (cc != null)
                    {
                        bool createFolder = (node.IsFolder || (node.IsQuery && cc.Value == "folder"));
                        bool createLayout = (node.IsLayout || (node.IsQuery && cc.Value == "layout"));
                        if (createFolder)
                        {
                            node.ElementType = AvrTreeElementType.Folder;
                        }
                        else if (createLayout)
                        {
                            node.ElementType = AvrTreeElementType.Layout;
                        }
                    }
                }
                errstr = AvrQueryLayoutTreeDbHelper.ValidateElementName(node, isNew);
                mesText = String.IsNullOrEmpty(errstr) ? Translator.GetBvMessageString("Save data?") : errstr;
            }
            else
            {
                errstr = "error";
            }

            // show confirmation
            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                {
                    result = errstr.Length > 0 ? "EXISTS" : "ASK",
                    messageText = mesText,
                    yesFunction = String.Format("treeList.UpdateEdit();"),
                    noFunction = String.Empty,
                    errorString = mesText
                }
            };
        }

        public ActionResult ExportQuery(long queryId, int exportType)
        {
            AvrServiceAccessability access = AvrServiceAccessability.Check();
            var result = new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                {
                    result = access.IsOk ? "OK" : "ERROR",
                    url = access.IsOk
                        ? Url.Action("ExportQueryRoutines", new { queryId, exportType })
                        : Url.Action("AvrServError", new { error = access.ErrorMessage }),
                }
            };

            return result;
        }

        public ActionResult AvrServError(string error)
        {
            return PartialView("AvrServiceError", error);
            //return View("AvrServiceError", error);
        }

        public FileResult ExportQueryRoutines(long queryId, int exportType)
        {
            if (exportType != 0 && exportType != 1 && exportType != 2)
            {
                throw new ArgumentException(EidssMessages.Get("ExportTypeError"), "exportType");
            }

            // export to Access. It's impossible without creating temp file
            if (exportType == 2)
            {
                const int effortCount = 10;
                int effortNum = 1;
                WindowsLogHelper.WriteToEventLogWindows("Try to export data to MS Access", EventLogEntryType.Information);
                //var path = Path.Combine(Path.GetTempPath(), DateTime.Now.Ticks.ToString());
                string path = Path.Combine(Server.MapPath("~/App_Data/ExportQueryFiles"), DateTime.Now.Ticks.ToString());
                string filename = Path.ChangeExtension(path, "mdb");
                WindowsLogHelper.WriteToEventLogWindows(String.Format("Full path = {0}", filename), EventLogEntryType.Information);
                AccessExporter.ExportAnyCPU(queryId, ModelUserContext.CurrentLanguage, filename);
                //Thread.Sleep(6000);
                var fileBytes = new byte[0];
                while (effortNum <= effortCount)
                {
                    try
                    {
                        effortNum++;
                        fileBytes = System.IO.File.ReadAllBytes(filename);
                        break;
                    }
                    catch (Exception)
                    {
                        Thread.Sleep(1000);
                    }
                }

                if (fileBytes.Length == 0)
                {
                    throw new ArgumentException(EidssMessages.Get("Cantreadfile"));
                }
                //пробуем удалить файл
                effortNum = 1;
                while (effortNum <= effortCount)
                {
                    try
                    {
                        effortNum++;
                        System.IO.File.Delete(filename);
                        break;
                    }
                    // ReSharper disable EmptyGeneralCatchClause
                    catch (Exception)
                    // ReSharper restore EmptyGeneralCatchClause
                    {
                    }
                }
                return File(fileBytes, MediaTypeNames.Application.Octet, Path.GetFileName(filename));
            }

            // Export to Excel
            ExportType type = exportType == 0
                ? ExportType.Xls
                : ExportType.Xlsx;
            CachedQueryResult queryResult = ServiceClientHelper.ExecQuery(queryId, false, true);

            if (!string.IsNullOrEmpty(queryResult.ErrorMessage))
            {
                //todo:[mike]     return queryResult.ErrorMessage to user   
            }


            List<byte[]> fileBytesList = NpoiExcelWrapper.QueryLineListToExcel(queryResult.QueryTable, type);
            if (fileBytesList.Count == 0)
            {
                throw new AvrDataException(string.Format("Could not export query '{0}' to Excel", queryId));
            }

            // todo: [ELeonov] Should return multifile result if fileBytesList contains more than one element (see task 9516)
            return File(fileBytesList[0], MediaTypeNames.Application.Octet, "QueryLineList." + type);
        }

        [HttpPost]
        public JsonResult CopyNode(long id)
        {
            //проверим, что это именно Layout
            List<AvrTreeElement> tree = GetQueryTree();
            AvrTreeElement elem = tree.FirstOrDefault(c => c.ID == id);
            bool wasError = false;
            string errStr = String.Empty;
            long idLayoutCopy = 0;

            if ((elem == null) || !elem.IsLayout)
            {
                wasError = true;
            }
            else
            {

                AvrServiceCopyLayoutResult result = ServiceClientHelper.AvrServiceCopyLayout(id);
                if (result.IsOk)
                {
                    idLayoutCopy = result.Model;
                }
                else
                {
                    errStr = result.ErrorMessage;
                    wasError = true;
                }

            }

            if (!wasError)
            {
                RefreshTree();
            }

            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                {
                    result = wasError ? "ERROR" : "OK",
                    idflLayoutCopy = idLayoutCopy,
                    errorString = errStr,
                    url = Url.Action("QueryLayoutTree", GetQueryTree()),
                }
            };
        }

        [HttpGet]
        public JsonResult CheckLayout(long layoutId, bool forceViewShowing, bool forceLayoutShowing)
        {
            bool isNewLayout = false;
            bool isQueryCasheExists = false;
            string error = String.Empty;
            try
            {
                using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    var ps = new List<object>
                    {
                        manager.Parameter("LayoutID", layoutId),
                    };

                    var command = manager.SetSpCommand("dbo.spAsLayoutIsNew", ps.ToArray());

                    isNewLayout = command.ExecuteScalar<int>(ScalarSourceType.ReturnValue) == 1;

                    List<AvrTreeElement> tree = GetQueryTree();
                    AvrTreeElement elem = tree.FirstOrDefault(c => c.ID == layoutId);
                    if (elem != null)
                    {
                        isQueryCasheExists = ServiceClientHelper.DoesCachedQueryExists(elem.QueryID,
                            ModelUserContext.CurrentLanguage, elem.IsUseArchiveData);
                    }

                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                {
                    err = error,
                    isQueryExists = isQueryCasheExists? "Yes": "No",
                    isNewLayout = isNewLayout? "Yes" : "No",
                    okFunction = string.Format("queryTreeList.showLayoutViewInternal({0}, {1}, {2}, {3}, '{4}');", layoutId, Bool2JsBool(isNewLayout), Bool2JsBool(forceViewShowing), Bool2JsBool(forceLayoutShowing), isNewLayout ? Translator.GetMessageString("msgCantShowView") : ""),
                    Message = !isQueryCasheExists ? Translator.GetMessageString("msgShouldOpenLayout") : (isNewLayout ? Translator.GetMessageString("msgCantShowView") : "")
                }
            };
        }

        private string Bool2JsBool(bool value)
        {
            return value ? "true" : "false";
        }
        public ActionResult OnRefreshData(string queryId)
        {
            if (!string.IsNullOrEmpty(queryId))
                RefreshQueryData(bv.common.Core.Utils.ToLong(queryId));
            return new JsonResult();
        }

        private string RefreshQueryData(long queryId)
        {
            AvrServiceAccessability access = AvrServiceAccessability.Check();
            if (!access.IsOk)
            {
                return access.ErrorMessage;
            }
            ServiceClientHelper.AvrServiceClearQueryCache(queryId);
            ServiceClientHelper.RefreshQuery(queryId);
            return string.Empty;
        }

    }
}