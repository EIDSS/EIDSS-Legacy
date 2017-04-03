using System;
using System.Web.UI;

namespace eidss.ram.web
{
    public partial class SiteMaster : MasterPage
    {
        public string LayoutWarningText
        {
            get { return LayoutWarning.InnerText; }
            set { LayoutWarning.InnerText = value; }
        }

        public string LayoutHeaderText
        {
            get { return LayoutHeader.InnerText; }
            set { LayoutHeader.InnerText = value; }
        }

        public string QueryPathText
        {
            get { return QueryPath.Value; }
            set { QueryPath.Value = value; }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}