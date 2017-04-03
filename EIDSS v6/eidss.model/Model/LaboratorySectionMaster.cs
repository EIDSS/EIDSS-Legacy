using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using BLToolkit.EditableObjects;
using BLToolkit.Mapping;
using bv.model.BLToolkit;
using bv.model.Helpers;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Enums;

namespace eidss.model.Schema
{

    public partial class LaboratorySectionMaster
    {
        private void ClearIsNew()
        {
            m_IsNew = false;
        }

        public bool IsHasChanges(bool bMyPref)
        {
            if (bMyPref)
            {
                return /*LaboratorySectionMyPrefItems.IsDirty
                       || */LaboratorySectionMyPrefItems.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0;
            }

            return /*LaboratorySectionItems.IsDirty
                   || */LaboratorySectionItems.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0;
        }


        public void DeepAcceptChanges(bool bMyPref)
        {
            if (bMyPref)
                LaboratorySectionMyPrefItems.DeepAcceptChanges();
            else
                LaboratorySectionItems.DeepAcceptChanges();
        }

        partial class Accessor
        {

            public bool PostHalf(DbManagerProxy manager, IObject obj, bool bMyPref)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    LaboratorySectionMaster bo = obj as LaboratorySectionMaster;


                    if (!manager.IsTransactionStarted)
                    {

                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransactionHalf(manager, obj as LaboratorySectionMaster, false);
                    if (bTransactionStarted)
                    {
                        if (bSuccess)
                        {
                            bo.DeepAcceptChanges(bMyPref);
                            manager.CommitTransaction();

                        }
                        else
                        {
                            manager.RollbackTransaction();
                        }

                    }
                    if (bSuccess && bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        bo.m_IsNew = false;
                    }
                    if (bSuccess && bTransactionStarted)
                    {
                        bo.OnAfterPost();
                    }
                }
                catch (Exception e)
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
            private bool _PostNonTransactionHalf(DbManagerProxy manager, LaboratorySectionMaster obj, bool bMyPref)
            {
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {

                    if (!bMyPref && obj.LaboratorySectionItems != null)
                    {
                        foreach (var i in obj.LaboratorySectionItems)
                        {
                            i.MarkToDelete();
                            if (!LaboratorySectionItemsAccessor.Post(manager, i, true))
                                return false;
                        }
                    }

                    if (bMyPref && obj.LaboratorySectionMyPrefItems != null)
                    {
                        foreach (var i in obj.LaboratorySectionMyPrefItems)
                        {
                            i.MarkToDelete();
                            if (!LaboratorySectionMyPrefItemsAccessor.Post(manager, i, true))
                                return false;
                        }
                    }

                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                        if (!Validate(manager, obj, true, true, true))
                            return false;


                    // posting extenters - begin
                    var list = bMyPref ? obj.LaboratorySectionMyPrefItems : obj.LaboratorySectionItems;
                    list
                      .Where(c => c.idfsSampleStatus == (long)eidss.model.Enums.SampleStatus.OutOfRepository && c.OriginalSampleStatus != (long)eidss.model.Enums.SampleStatus.OutOfRepository)
                      .GroupBy(c => c.idfSendToOfficeOut).ToList().ForEach(g =>
                      {
                          g.GroupBy(c => c.datSendDate).ToList().ForEach(i =>
                          {
                              var sample = i.First();
                              var strBarcode = manager.SetSpCommand("dbo.spGetNextNumber", (long)NumberingObjectEnum.SampleTransfer, DBNull.Value, DBNull.Value)
                                  .ExecuteScalar<string>(ScalarSourceType.OutputParameter, "NextNumberValue");
                              var idfTransferOut = manager.SetSpCommand("dbo.spsysGetNewID", DBNull.Value)
                                  .ExecuteScalar<long>(ScalarSourceType.OutputParameter);
                              manager.SetSpCommand("dbo.spLabSampleTransfer_Post",
                                    4, //@Action INT,  --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
                                  idfTransferOut, //@idfTransferOut bigint,
                                  strBarcode, //@strBarcode nvarchar(200),
                                    "", //@strNote nvarchar(2000),
                                    EidssUserContext.User.OrganizationID, //@idfSendFromOffice bigint,--target site
                                    sample.idfSendToOfficeOut, //@idfSendToOffice bigint,--target site
                                    sample.idfSendByPerson, //@idfSendByPerson bigint,--who sent
                                    sample.datSendDate, //@datSendDate datetime,--time sent
                                    (long)eidss.model.Enums.TestStatus.InProcess //@idfsTransferStatus bigint--transfer status
                                  ).ExecuteNonQuery();

                              i.ToList().ForEach(j =>
                              {
                                  manager.SetSpCommand("dbo.spLabSampleTransfer_Send",
                                        j.idfMaterial, //@idfMaterial bigint,
                                        sample.idfSendToOfficeOut, //@idfSentToOffice bigint,
                                      sample.datSendDate //@datSendDate datetime 
                                      ).ExecuteNonQuery();

                                  manager.SetSpCommand("dbo.spLabSampleTransfer_Manage",
                                        idfTransferOut, //@idfTransferOut bigint,
                                        j.idfMaterial, //@idfMaterial bigint,
                                        1 //@add integer
                                      ).ExecuteNonQuery();

                                  manager.SetEventParams(false, new object[] { EventType.NewSampleTransferInLocal, idfTransferOut, "" });

                              });
                          });
                      });

                    // posting extenters - end

                    if (obj.IsNew)
                    {
                        if (!bMyPref && obj.LaboratorySectionItems != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.LaboratorySectionItems)
                                if (!LaboratorySectionItemsAccessor.Post(manager, i, true))
                                    return false;
                            obj.LaboratorySectionItems.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.LaboratorySectionItems.Remove(c));
                            obj.LaboratorySectionItems.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (!bMyPref && obj._LaboratorySectionItems != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._LaboratorySectionItems)
                                if (!LaboratorySectionItemsAccessor.Post(manager, i, true))
                                    return false;
                            obj._LaboratorySectionItems.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._LaboratorySectionItems.Remove(c));
                            obj._LaboratorySectionItems.AcceptChanges();
                        }
                    }

                    if (obj.IsNew)
                    {
                        if (bMyPref && obj.LaboratorySectionMyPrefItems != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.LaboratorySectionMyPrefItems)
                                if (!LaboratorySectionMyPrefItemsAccessor.Post(manager, i, true))
                                    return false;
                            obj.LaboratorySectionMyPrefItems.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.LaboratorySectionMyPrefItems.Remove(c));
                            obj.LaboratorySectionMyPrefItems.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (bMyPref && obj._LaboratorySectionMyPrefItems != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._LaboratorySectionMyPrefItems)
                                if (!LaboratorySectionMyPrefItemsAccessor.Post(manager, i, true))
                                    return false;
                            obj._LaboratorySectionMyPrefItems.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._LaboratorySectionMyPrefItems.Remove(c));
                            obj._LaboratorySectionMyPrefItems.AcceptChanges();
                        }
                    }

                    // posted extenters - begin
                    // posted extenters - end

                }
                //obj.AcceptChanges();

                return true;
            }

        }
    }
}
