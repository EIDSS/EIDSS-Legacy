using System;
using System.Data;

namespace bv.common.Core
{
	public interface IEventLog
	{
		object CreateEvent(Enum et, object objectID, object diagnosisID, object siteID = null, object userID = null, IDbTransaction transaction = null);
		object CreateProcessedEvent(Enum eventTypeID, object objectID, int processed, object diagnosisID, object siteID = null, object userID = null, IDbTransaction transaction = null);
		void CheckNotificationService(IDbTransaction transaction = null);
		void StartReplication();
	}
}
