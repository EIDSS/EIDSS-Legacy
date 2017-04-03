using System;
using eidss.model.Trace;
using eidss.model.WcfService;
using EIDSS.Reports.Service.WcfFacade;

namespace EIDSS.Reports.Service.WcfService
{
    public sealed class ReportHostKeeper : ServiceHostKeeper
    {
        protected override void InitEidssCore()
        {
            base.InitEidssCore();
            EIDSS_LookupCacheHelper.Init();
        }

        protected override Type ServiceType
        {
            get { return typeof (ReportFacade); }
        }

        protected override string DefaultServiceHostURL
        {
            get { return "http://localhost:8097/"; }
        }

        protected override string ServiceHostURLConfigName
        {
            get { return "ReportServiceHostURL"; }
        }

        protected override string TraceCategory
        {
            get { return TraceHelper.ReportsCategory; }
        }
    }
}