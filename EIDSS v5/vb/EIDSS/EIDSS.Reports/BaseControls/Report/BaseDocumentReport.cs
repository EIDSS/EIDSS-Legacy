using System;
using System.Collections.Generic;
using bv.common.Core;
using bv.model.BLToolkit;

namespace EIDSS.Reports.BaseControls.Report
{
    public partial class BaseDocumentReport : BaseReport
    {
        public BaseDocumentReport()
        {
            InitializeComponent();
        }

        public virtual void SetParameters(DbManagerProxy manager, string lang, Dictionary<string, string> parameters)
        {
            Utils.CheckNotNullOrEmpty(lang, "lang");
            Utils.CheckNotNull(parameters, "parameters");

            long organizationId;
            if (TryGetLongParameter(parameters, "@OrganizationID", out organizationId))
            {
                SetLanguage(manager, lang, organizationId);
            }
            else
            {
                SetLanguage(manager, lang);
            }
        }

        protected internal static string GetStringParameter(IDictionary<string, string> parameters, string paramName)
        {
            Utils.CheckNotNullOrEmpty(paramName, "paramName");
            Utils.CheckNotNull(parameters, "parameters");

            string outValue;
            if (!parameters.TryGetValue(paramName, out outValue))
            {
                throw new ArgumentException(string.Format("Could not get parameter {0}.", paramName));
            }
            if (string.IsNullOrEmpty(outValue))
            {
                throw new ArgumentException(string.Format("Parameter {0} contains empty value", paramName));
            }
            return outValue;
        }

        protected internal static long GetLongParameter(IDictionary<string, string> parameters, string paramName)
        {
            return long.Parse(GetStringParameter(parameters, paramName));
        }

        protected internal static bool TryGetStringParameter
            (IDictionary<string, string> parameters, string paramName, out string paramValue)
        {
            Utils.CheckNotNullOrEmpty(paramName, "paramName");
            Utils.CheckNotNull(parameters, "parameters");

            if (parameters.TryGetValue(paramName, out paramValue) && !string.IsNullOrEmpty(paramValue))
            {
                return true;
            }
            return false;
        }

        protected internal static bool TryGetLongParameter(IDictionary<string, string> parameters, string paramName, out long paramValue)
        {
            string param;
            paramValue = 0;
            if (TryGetStringParameter(parameters, paramName, out param))
            {
                return long.TryParse(param, out paramValue);
            }
            return false;
        }
    }
}