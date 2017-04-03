using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.model.Model.Core;
using eidss.model.Enums;
using BLToolkit.Data;
using bv.model.BLToolkit;
using System.Data;
using EventType = eidss.model.Enums.EventType;
namespace eidss.model.Schema
{
    public partial class EventLogList
    {
        public static long GetCaseType(long eventId, out EventType eventType, out long idfObjectID)
        {
            eventType = eidss.model.Enums.EventType.None;
            idfObjectID = -1;
            using (DbManager manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                try
                {
                    manager.SetSpCommand("spEvent_GetCaseType",
                        manager.Parameter("idfEventID", eventId),
                        manager.Parameter(ParameterDirection.Output, "idfCase", DbType.Int64),
                        manager.Parameter(ParameterDirection.Output, "EventType", DbType.Int64),
                        manager.Parameter(ParameterDirection.Output, "CaseType", DbType.Int32)
                        ).ExecuteNonQuery();

                    if (manager.Parameter("@EventType").Value != null)
                        eventType = (EventType)Enum.Parse(typeof(EventType), manager.Parameter("@EventType").Value.ToString());
                    if (manager.Parameter("@idfCase").Value != null)
                        idfObjectID = (long)manager.Parameter("@idfCase").Value;
                    int caseType = 0;
                    if (int.TryParse(manager.Parameter("@CaseType").Value.ToString(), out caseType))
                        return caseType;
                    return 0;
                }
                catch
                {
                    return -1;
                }

            }
        }
        
    }
}


