using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading;
using System.Web.Mvc;
using BLToolkit.Data;
using EIDSS;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.avr.db.CacheReceiver;
using eidss.avr.db.Common;
using eidss.avr.db.DBService;
using eidss.avr.db.DBService.Access;
using eidss.avr.mweb.Utils;
using bv.common.db;
using eidss.model.Avr;
using eidss.model.Avr.Chart;
using eidss.model.AVR.Db;
using eidss.model.Avr.Export;
using eidss.model.Avr.Tree;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Resources;
using eidss.web.common.Utils;
using Convert = System.Convert;
using ExportType = eidss.model.Avr.Commands.Export.ExportType;

namespace eidss.avr.mweb.Controllers
{
    [AuthorizeEIDSS]
    public class QueryLayoutTreeController : Controller
    {
        [HttpGet]
        public ActionResult QueryLayoutTree()
        {
            var model = AvrQueryLayoutTreeDbHelper.LoadQueriesLayoutsFolders();
            Session["QueryTree"] = model;

            return View(model);
        }

        [ValidateInput(false)]
        public ActionResult QueryLayoutTreePartial()
        {
            List<AvrTreeElement> model;

            if (Session["QueryTree"] != null)
                model = Session["QueryTree"] as List<AvrTreeElement>;
            else
                model = AvrQueryLayoutTreeDbHelper.LoadQueriesLayoutsFolders();

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
                    var tree = GetQueryTree();
                    var elem = tree.FirstOrDefault(c => c.ID == treeElement.ID);
                    if ((elem != null) && treeElement.IsEqual(elem))
                    {
                        //TODO в противном случае надо показать диалог подтверждения сохранения
                        return PartialView("QueryLayoutTreePartial", GetQueryTree());
                    }
                }
                

                long id = 0;
                using (var manager = DbManagerFactory.Factory.Create())
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
                                , (long) DBGroupInterval.gitDateYear
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

                        long publishedId = 0;
                        var eventType = EventType.AVRLayoutFolderPublishedLocal; //только для инициализации
                        if (id > 0)
                        {
                            if (treeElement.IsPublished && !treeElement.ReadOnly)
                            {
                                PublishRoutines(treeElement.ID, manager, treeElement.ElementType, true, out publishedId, out eventType);
                            }
                            else if (!treeElement.IsPublished && treeElement.ReadOnly && treeElement.GlobalID.HasValue)
                            {
                                PublishRoutines(treeElement.GlobalID.Value, manager, treeElement.ElementType, false, out publishedId, out eventType);
                            }
                        }
                        manager.CommitTransaction();

                        if (publishedId > 0)
                        {
                            EidssEventLog.Instance.CreateProcessedEvent(eventType,
                                                         publishedId > 0 ? publishedId : 0, 0,
                                                         EidssUserContext.User.ID,
                                                         manager.Transaction);
                        }
                    }
                    catch (Exception exc)
                    {
                        //TODO куда писать ошибки?
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
            var can = false;
            var node = tree.SingleOrDefault(c => c.ID == id);
            if (node != null)
            {
                var children = tree.Where(c => c.ParentID == node.ID).ToList();
                //попытка перемещения в потомка
                can = children.All(c => c.ID != parentId);
                if (can)
                {
                    foreach (var child in children)
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
             */

            var tree = GetQueryTree();
            var node = tree.SingleOrDefault(c => c.ID == id);
            if ((node != null) && !node.IsQuery && parentId.HasValue)
            {
                var newParent = tree.SingleOrDefault(c => c.ID == parentId.Value);
                if ((newParent != null) && (node.QueryID == newParent.QueryID) && !newParent.IsLayout)
                {
                    var pid = newParent.IsQuery ? null : (long?) newParent.ID;
                    if (node.IsLayout)
                    {
                        AvrQueryLayoutTreeDbHelper.SaveLayoutLocation(node.ID, pid);
                        LookupManager.ClearAndReload("Layout");
                    }
                    else if (node.IsFolder)
                    {
                        //проверим, не переносят ли его к его потомкам
                        var can = true;
                        if (newParent.IsFolder) can = CanMoveFolder(tree, node.ID, parentId.Value);
                       
                        if (can)
                        {
                            AvrQueryLayoutTreeDbHelper.SaveFolder(node.ID, pid,
                                                                  node.QueryID,
                                                                  node.DefaultName,
                                                                  node.NationalName);

                            LookupManager.ClearAndReload("LayoutFolder");
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
            if ((node != null) && (!node.IsPublished))
            {
                if (node.IsFolder)
                {
                    //нужно проверить, что у этого каталога нет дочерних элементов
                    //иначе его нельзя удалять

                    if (tree.Any(c => c.ParentID == node.ID))
                    {
                        errStr = EidssMessages.Get("QueryLayoutTree_CantDeleteWithChildren");
                    }
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
            var tree = GetQueryTree();
            var node = tree.FirstOrDefault(c => c.ID == id);
            var errStr = String.Empty;
            try
            {
                if (node != null)
                {
                    if (node.IsFolder)
                    {
                        AvrQueryLayoutTreeDbHelper.DeleteFolder(node.ID);
                    }
                    else if (node.IsLayout)
                    {
                        using (var avrDbService = new BaseDbService())
                        {
                            avrDbService.Delete(node.ID, "AsLayout");
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
            var cc = Request.Cookies["newElementType"];
            var errStr = String.Empty;
            if ((cc != null) && AvrPermissions.InsertPermission && !IsFolderDepthTooBig(newNode))
            {
                var createFolder = (newNode.IsFolder || (newNode.IsQuery && cc.Value == "folder"));
                var createLayout = (newNode.IsLayout || (newNode.IsQuery && cc.Value == "layout"));
                if (createFolder || createLayout)
                {
                    newNode.ElementType = createFolder ? AvrTreeElementType.Folder : AvrTreeElementType.Layout;


                    using (var manager = DbManagerFactory.Factory.Create())
                    {
                        try
                        {
                            manager.BeginTransaction();
                            var nodeId = NewId();
                            var parentId = newNode.ParentID != newNode.QueryID ? newNode.ParentID : null;
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
                                    , (long) DBGroupInterval.gitDateYear
                                    , newNode.QueryID
                                    , NewId()
                                    , newNode.Description
                                    , newNode.DescriptionEnglish
                                    , false
                                    , newNode.IsShared
                                    );
                                AvrQueryLayoutTreeDbHelper.SaveLayoutLocation(nodeId, parentId);
                            }
                            long publishedId = 0;
                            var eventType = EventType.AVRLayoutFolderPublishedLocal; //только для инициализации
                            if (newNode.IsPublished)
                            {
                                PublishRoutines(nodeId, manager,
                                                createFolder ? AvrTreeElementType.Folder : AvrTreeElementType.Layout,
                                                true, out publishedId, out eventType);
                            }

                            manager.CommitTransaction();

                            if (publishedId > 0)
                            {
                                EidssEventLog.Instance.CreateProcessedEvent(eventType,
                                                                             publishedId > 0 ? publishedId : 0, 0,
                                                                             EidssUserContext.User.ID,
                                                                             manager.Transaction);
                            }
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
            if (errStr.Length == 0) RefreshTree();
            return PartialView("QueryLayoutTreePartial", GetQueryTree());
        }

        private List<AvrTreeElement> GetQueryTree()
        {
            return Session["QueryTree"] as List<AvrTreeElement>;
        }

        private void RefreshTree()
        {
            LookupManager.ClearAndReload("LayoutFolder");
            LookupManager.ClearAndReload("Layout");
            //LookupManager.ClearAndReload("Query");
            LookupManager.ClearAndReloadOnIdle();
            Session["QueryTree"] = AvrQueryLayoutTreeDbHelper.LoadQueriesLayoutsFolders();
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
            var maxDepth = Math.Min(Config.GetIntSetting("MaxRamFolderDepth", 16), 30);
            var isFolderDepthTooBig = count >= maxDepth;
            
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

        private void PublishRoutines(long id, DbManagerProxy manager, AvrTreeElementType type, bool isPublish, out long eventObjectId, out EventType eventType)
        {
            //TODO может быть, в какой-то хелпер перенести?
            string spName;
            string inputParamName;
            string outputParamName;

            GetPublishParams(isPublish, type, out spName, out inputParamName, out outputParamName, out eventType);

            var ps = new List<object> {manager.Parameter(inputParamName, id)};
            ps.Add(manager.Parameter(ParameterDirection.Output, outputParamName, DbType.Int64));
            
            var command = manager.SetSpCommand(spName, ps.ToArray());

            eventObjectId = Convert.ToInt64(command.ExecuteScalar<long>(ScalarSourceType.OutputParameter));
        }

        [HttpPost]
        public JsonResult EditTreeNode(AvrTreeElement node)
        {
            var isValid = true;
            //TODO валидация
            
            //if (node.NationalName == null) node.NationalName = node.DefaultName;
            //if (string.IsNullOrEmpty(node.DefaultName)) isValid = false;

            if (isValid)
            {
                var isNew = node.ID == 0;
                if (isNew)
                {
                    var cc = Request.Cookies["newElementType"];
                    if (cc != null)
                    {
                        var createFolder = (node.IsFolder || (node.IsQuery && cc.Value == "folder"));
                        var createLayout = (node.IsLayout || (node.IsQuery && cc.Value == "layout"));
                        if (createFolder) node.ElementType = AvrTreeElementType.Folder;
                        else if (createLayout) node.ElementType = AvrTreeElementType.Layout;
                    }
                }

                var errstr = AvrQueryLayoutTreeDbHelper.ValidateElementName(node, isNew);
                // show confirmation
                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        result = errstr.Length > 0 ? "EXISTS" : "ASK",
                        messageText = Translator.GetBvMessageString("Save data?"),
                        yesFunction = String.Format("treeList.UpdateEdit();"),
                        noFunction = String.Empty,
                        errorString = errstr
                    }
                };
            }
            // finish, don't show confirmation
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "no" };
        }

        public ActionResult ExportQuery(long queryId, int exportType)
        {
            var access = AvrServiceAccessability.Check();
            var result = new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                {
                    result = access.IsOk ? "OK" : "ERROR",
                    url = access.IsOk ? 
                    Url.Action("ExportQueryRoutines", new {queryId, exportType})
                    :
                    Url.Action("AvrServError", new { error = access.ErrorMessage }),
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
                var effortNum = 1;
                WindowsLogHelper.WriteToEventLogWindows("Try to export data to MS Access", EventLogEntryType.Information);
                //var path = Path.Combine(Path.GetTempPath(), DateTime.Now.Ticks.ToString());
                var path = Path.Combine(Server.MapPath("~/App_Data/ExportQueryFiles"), DateTime.Now.Ticks.ToString());
                var filename = Path.ChangeExtension(path, "mdb");
                WindowsLogHelper.WriteToEventLogWindows(String.Format("Full path = {0}", filename), EventLogEntryType.Information);
                AccessExporter.ExportAnyCPU(queryId, filename);
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
                    catch (Exception exc)
                    {
                        Thread.Sleep(1000);
                    }
                }

                if (fileBytes.Length == 0) throw new ArgumentException(EidssMessages.Get("Cantreadfile"));
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
                    catch (Exception exc)
                    {
                    }
                }
                return File(fileBytes, MediaTypeNames.Application.Octet, Path.GetFileName(filename));
            }


            // Export to Excel
            var type = exportType == 0
                ? ExportType.Xls
                : ExportType.Xlsx;
            var queryResult = ServiceClientHelper.ExecQuery(queryId, false);
            var resultTable = QueryHelper.GetTableWithoutCopiedColumns(queryResult.QueryTable);
            var fileBytesList = NpoiExcelWrapper.QueryLineListToExcel(resultTable, type);
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
            var tree = GetQueryTree();
            var elem = tree.FirstOrDefault(c => c.ID == id);
            var wasError = false;
            var errStr = String.Empty;
            long idLayoutCopy = 0;

            if ((elem == null) || !elem.IsLayout)
            {
                wasError = true;
            }
            else
            {
                var xml = AvrQueryLayoutTreeDbHelper.GetCopyLayoutNameXml(elem);
                
                using (var manager = DbManagerFactory.Factory.Create())
                {
                    //TODO если можно как-то получить несколько output-параметров, то надо переделать на BLToolkit-команду
                    var cmd = new SqlCommand("dbo.spAsLayout_CreateCopy", (SqlConnection)manager.Connection){CommandType = CommandType.StoredProcedure};
                    cmd.Parameters.Add(new SqlParameter("@idflOriginalLayout", SqlDbType.BigInt, 4) { Value = id });
                    cmd.Parameters.Add(new SqlParameter("@idflLayoutCopy", SqlDbType.BigInt) {Direction = ParameterDirection.Output});
                    cmd.Parameters.Add(new SqlParameter("@xmlLayoutName", SqlDbType.NVarChar, 4000) {Value = xml});
                    cmd.Parameters.Add(new SqlParameter("@errorCode", SqlDbType.BigInt) {Direction = ParameterDirection.Output});
                   
                    /*
                    var command = manager.SetSpCommand("dbo.spAsLayout_CreateCopy",
                        manager.Parameter("idflOriginalLayout", id),
                        manager.Parameter(ParameterDirection.Output, "idflLayoutCopy", DbType.Int64),
                        manager.Parameter("xmlLayoutName", xml),
                        manager.Parameter(ParameterDirection.Output, "errorCode", DbType.String)
                        );
                     * command.ExecuteNonQuery();
                    */
                    cmd.ExecuteNonQuery();

                    idLayoutCopy = Convert.ToInt64(cmd.Parameters["@idflLayoutCopy"].Value);
                    var errCode = cmd.Parameters["@errorCode"].Value.ToString();
                    if (errCode.Length > 0)
                    {
                        var ic = Convert.ToInt32(errCode);
                        if (ic > 0) errStr = EidssMessages.Get(String.Format("AVRCopy_Error_{0}", ic));
                    }
                
                    if (errStr.Length > 0) wasError = true;
                }
            }
            
            if (!wasError) RefreshTree();

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
    }
}
