using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.common.Core;
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
        public static long GetEventInfo(long eventId, out EventType eventType, out long idfObjectID, out string infoString)
        {
            eventType = eidss.model.Enums.EventType.None;
            idfObjectID = -1;
            infoString = null;
            using (DbManager manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                try
                {
                    manager.SetSpCommand("spEvent_GetCaseType",
                        manager.Parameter("idfEventID", eventId),
                        manager.Parameter(ParameterDirection.Output, "idfCase", DbType.Int64),
                        manager.Parameter(ParameterDirection.Output, "EventType", DbType.Int64),
                        manager.Parameter(ParameterDirection.Output, "CaseType", DbType.Int32),
                        manager.Parameter(ParameterDirection.Output, "strInformationString", DbType.String)
                        ).ExecuteNonQuery();

                    if (!Utils.IsEmpty(manager.Parameter("@EventType").Value))
                        eventType = (EventType)Enum.Parse(typeof(EventType), manager.Parameter("@EventType").Value.ToString());
                    if (!Utils.IsEmpty(manager.Parameter("@idfCase").Value))
                        idfObjectID = (long)manager.Parameter("@idfCase").Value;
                    if (!Utils.IsEmpty(manager.Parameter("@strInformationString").Value))
                        infoString = (string)manager.Parameter("@strInformationString").Value;
                    long caseType = 0;
                    if (long.TryParse(manager.Parameter("@CaseType").Value.ToString(), out caseType))
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


