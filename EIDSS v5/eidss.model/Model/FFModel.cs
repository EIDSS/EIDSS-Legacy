using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using BLToolkit.EditableObjects;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using BLToolkit.Data;

namespace eidss.model.Schema
{
    public partial class FFModel
    {

        #region Accessor
        public abstract partial class Accessor
            : DataAccessor<ActivityParameter>
            , IObjectAccessor
            , IObjectPost
                    
        {
            private static Accessor g_Instance = CreateInstance<Accessor>();
            public static Accessor Instance(CacheScope cs) 
            { 
                return g_Instance;
            }
            
            public virtual List<ActivityParameter> SelectDetailList(DbManagerProxy manager
                , long? idfsFormTemplate
                , String observationList
                )
            {
                return _SelectList(manager
                    , idfsFormTemplate
                    , observationList
                    );
            }
            
            private List<ActivityParameter> _SelectList(DbManagerProxy manager
                , long? idfsFormTemplate
                , String observationList
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<ActivityParameter> objs = new List<ActivityParameter>();
                    sets[0] = new MapResultSet(typeof(ActivityParameter), objs);
                    
                    manager
                        .SetSpCommand("spFFGetActivityParameters"
                            , manager.Parameter("@observationList", observationList)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);
                    foreach(var obj in objs) 
                    {
                        ActivityParameter.Accessor.Instance(null)._SetupLoad(manager, obj);
                    }
                    
                    return objs;
                }
                catch(DataException e)
                {
                    throw DbModelException.Create(e);
                }
            }


            public bool Validate(DbManagerProxy manager, ActivityParameter obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation)
            {
                return true;
            }
    
            [SprocName("spFFRemoveActivityParameters")]
            protected abstract void _postDelete(DbManagerProxy manager
                , Int64? idfsParameter
                , Int64? idfObservation
                , Int64? idfRow
                );
        
            [SprocName("spFFSaveActivityParameters")]
            protected abstract void _post(DbManagerProxy manager, 
                [Direction.InputOutput("idfRow", "idfActivityParameters")] ActivityParameter obj);
            
            
            public bool Post(DbManagerProxy manager, IObject obj)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    ActivityParameter bo = obj as ActivityParameter;
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as ActivityParameter);
                    if (bTransactionStarted)
                    {
                        if (bSuccess)
                        {
                            manager.CommitTransaction();
                            bo.OnAfterPost();
                        }
                        else
                        {
                            manager.RollbackTransaction();
                        }
                        
                    }
                    if (bSuccess && bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        //bo.m_IsNew = false;
                    }
                }
                catch(Exception e)
                {
                    if (bTransactionStarted)
                    {
                        manager.RollbackTransaction();
                        
                    }
                    
                    if (e is DataException)
                    {
                        throw DbModelException.Create(e as DataException);
                    }
                    else 
                        throw;
                }
                return bSuccess;
            }
            private bool _PostNonTransaction(DbManagerProxy manager, ActivityParameter obj) 
            { 
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
                    _postDelete(manager
                        , obj.idfsParameter
                        , obj.idfObservation
                        , obj.idfRow
                        );
                                    
                }
                else // insert/update
                {
                    if (!obj.IsMarkedToDelete && obj.HasChanges)
                        _post(manager, obj);
                }
                obj.AcceptChanges();
                
                return true;
            }
            
        }

        #endregion
    }
}
