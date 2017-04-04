using System;
using System.Collections.Generic;
using bv.common;
using bv.common.db;
using eidss.avr.BaseComponents;
using eidss.avr.BaseComponents.Views;
using eidss.avr.db.Common;
using eidss.avr.db.DBService;
using eidss.model.Avr;
using eidss.model.Avr.Commands;
using eidss.model.Avr.Tree;

namespace eidss.avr.QueryLayoutTree
{
    public sealed class QueryLayoutTreePresenter : RelatedObjectPresenter
    {
        public QueryLayoutTreePresenter(SharedPresenter sharedPresenter, IQueryLayoutTreeView view)
            : base(sharedPresenter, view)
        {
            view.DBService = new BaseAvrDbService();
        }
         
        
        public override void Process(Command cmd)
        {
        }

        #region Binding

        #endregion

        public List<AvrTreeElement> LoadData()
        {
            return AvrQueryLayoutTreeDbHelper.LoadQueriesLayoutsFolders();
        }

        public void SaveLayoutLocation(long layoutId, long? folderId)
        {
            try
            {
                AvrQueryLayoutTreeDbHelper.SaveLayoutLocation(layoutId, folderId);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(string.Format("Cannot move layout {0} to folder {1}", layoutId, folderId), ex);
                throw;
            }
        }

        public void SaveFolder(long folderId, long? parentFolderId, long queryId, string defaultName, string nationalName)
        {
            try
            {
                AvrQueryLayoutTreeDbHelper.SaveFolder(folderId, parentFolderId, queryId, defaultName, nationalName);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(string.Format("Cannot save folder {0} - {1}", folderId, defaultName), ex);
                throw;
            }
        }

        public long NewId()
        {
            return BaseDbService.NewIntID();
        }
    }
}