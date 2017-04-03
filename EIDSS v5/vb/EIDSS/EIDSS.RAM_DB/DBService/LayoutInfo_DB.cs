using System;
using System.Collections.Generic;
using System.Data;
using bv.common;
using bv.common.Core;
using bv.common.db.Core;
using bv.model.Model.Core;
using eidss.model.Core;
using EIDSS.RAM_DB.Common;
using EIDSS.RAM_DB.DBService.Models;

namespace EIDSS.RAM_DB.DBService
{
    public class LayoutInfo_DB : BaseRamDbService
    {
        private readonly SharedModel m_SharedModel;

        public LayoutInfo_DB(SharedModel sharedModel)
        {
            m_SharedModel = sharedModel;
        }

        public static List<LayoutTreeElement> LoadFolders(long queryId, bool readOnly)
        {
            DataView viewFolder = LookupCache.Get(LookupTables.LayoutFolder);

            string filter = string.Format("idflQuery = {0} ", queryId);
            if (readOnly)
            {
                filter += " and (blnReadOnly = 1)";
            }
            viewFolder.RowFilter = filter;
            viewFolder.Sort = "idflQuery, intOrder, strFolderName";

            var treeElements = new List<LayoutTreeElement>();
            foreach (DataRowView row in viewFolder)
            {
                var idflFolder = (long) row["idflFolder"];
                long? idflParent = (row["idflParentFolder"] is DBNull) ? null : (long?) row["idflParentFolder"];
                var strDefaultName = (string) row["strDefaultFolderName"];
                var strName = (string) row["strFolderName"];
                var idflQuery = (long) row["idflQuery"];
                bool blnReadOnly = (row["blnReadOnly"] is DBNull) ? false : (bool) row["blnReadOnly"];

                treeElements.Add(new LayoutTreeElement(idflFolder, idflParent, idflQuery, false,
                                                       strDefaultName, strName, blnReadOnly, true));
            }
            return treeElements;
        }

        public static List<LayoutTreeElement> LoadLayouts(long queryId, long userId, bool readOnly)
        {
            string filter = string.Format("idflQuery = {0} and (blnShareLayout = 1 or idfUserID = '{1}')",
                                          queryId, EidssUserContext.User.ID??-1);
            if (readOnly)
            {
                filter += " and (blnReadOnly = 1)";
            }

            DataView viewLayout = LookupCache.Get(LookupTables.Layout);
            viewLayout.RowFilter = filter;
            viewLayout.Sort = "idflQuery, intOrder, strLayoutName";

            var treeElements = new List<LayoutTreeElement>();
            foreach (DataRowView row in viewLayout)
            {
                var idflLayout = (long) row["idflLayout"];
                long? idflFolder = (row["idflFolder"] is DBNull) ? null : (long?) row["idflFolder"];
                var strDefaultName = (string) row["strDefaultLayoutName"];
                var strName = (string) row["strLayoutName"];
                var idflQuery = (long) row["idflQuery"];
                bool blnReadOnly = (row["blnReadOnly"] is DBNull) ? false : (bool) row["blnReadOnly"];
                bool blnShareLayout = (row["blnShareLayout"] is DBNull) ? false : (bool) row["blnShareLayout"];

                treeElements.Add(new LayoutTreeElement(idflLayout, idflFolder, idflQuery, true,
                                                       strDefaultName, strName, blnReadOnly, blnShareLayout));
            }
            return treeElements;
        }

        public void SaveLayoutAndFolders(List<LayoutTreeElement> original, List<LayoutTreeElement> final)
        {
            lock (Connection)
            {
                try
                {
                    if (Connection.State != ConnectionState.Open)
                    {
                        Connection.Open();
                    }
                    using (IDbTransaction transaction = Connection.BeginTransaction())
                    {
                        try
                        {
                            SaveLayoutAndFoldersInternal(original, final, transaction);

                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            AuditManager.ClearAuditContext(transaction, Connection);
                            throw;
                        }
                    }
                }
                finally
                {
                    if (Connection.State == ConnectionState.Open)
                    {
                        Connection.Close();
                    }
                }
            }
        }

        private void SaveLayoutAndFoldersInternal
            (List<LayoutTreeElement> original, List<LayoutTreeElement> final,
             IDbTransaction transaction)
        {
            final.Sort(GetComparison(true));

            foreach (LayoutTreeElement element in final)
            {
                PostElementInfo(element, transaction);
            }

            original.Sort(GetComparison(false));
            foreach (LayoutTreeElement element in original)
            {
                if (!element.IsLayout && !final.Contains(element))
                {
                    DeleteElementInfo(element, transaction);
                }
            }

            LookupCache.NotifyChange("Layout", transaction, ID);
            LookupCache.NotifyChange("LayoutFolder", transaction, ID);
        }

        private void PostElementInfo(LayoutTreeElement element, IDbTransaction transaction)
        {
            Utils.CheckNotNull(element, "element");
            if (!element.IsChanged)
            {
                return;
            }
            try
            {
                if (element.IsLayout)
                {
                    using (IDbCommand cmd = CreateSPCommand("spAsLayoutParentPost", transaction))
                    {
                        AddAndCheckParam(cmd, "@idflLayout", element.ID);
                        AddAndCheckParam(cmd, "@idflFolder", GetParentId(element));
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    using (IDbCommand cmd = CreateSPCommand("spAsFolderPost", transaction))
                    {
                        AddAndCheckParam(cmd, "@strLanguage", ModelUserContext.CurrentLanguage);
                        AddAndCheckParam(cmd, "@idflFolder", element.ID);
                        AddAndCheckParam(cmd, "@idflParentFolder", GetParentId(element));
                        AddAndCheckParam(cmd, "@strFolderName", element.NationalName);
                        AddAndCheckParam(cmd, "@strDefaultFolderName", element.DefaultName);
                        AddAndCheckParam(cmd, "@idflQuery", element.QueryID);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(string.Format("Cannot save element {0}", element), ex);
                throw;
            }
        }

        private void DeleteElementInfo(LayoutTreeElement element, IDbTransaction transaction)
        {
            Utils.CheckNotNull(element, "element");
            if (element.IsLayout)
            {
                throw new RamDbException("Layout cannot be deleted");
            }
            if (element.ReadOnly)
            {
                throw new RamDbException("Readonly folder cannot be deleted");
            }
            try
            {
                using (IDbCommand cmd = CreateSPCommand("spAsFolderDelete", transaction))
                {
                    AddAndCheckParam(cmd, "@idflFolder", element.ID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(string.Format("Cannot delete folder {0}", element), ex);
                throw;
            }
        }

        private static object GetParentId(LayoutTreeElement element)
        {
            object parentId = DBNull.Value;
            if (element.ParentID.HasValue && element.ParentID.Value > 0)
            {
                parentId = element.ParentID.Value;
            }
            return parentId;
        }

        private static Comparison<LayoutTreeElement> GetComparison(bool forward)
        {
            return delegate(LayoutTreeElement e1, LayoutTreeElement e2)
                       {
                           int compare = Comparer<long?>.Default.Compare(e1.ParentID, e2.ParentID);
                           return forward
                                      ? compare
                                      : -compare;
                       };
        }
    }
}