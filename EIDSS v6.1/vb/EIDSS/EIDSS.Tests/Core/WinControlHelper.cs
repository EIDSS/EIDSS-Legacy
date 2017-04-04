
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace EIDSS.Tests.Core
{
    class WinControlHelper
    {
        public static Control FindControl(Control parentCtl, string ControlName, string parentControlName )
        {
            foreach (Control c in parentCtl.Controls)
            {
                if(c.Name==ControlName && (parentControlName==null || parentCtl.Name==parentControlName))
                    return c;
                Control res = FindControl(c, ControlName, parentControlName);
                if (res != null)
                    return res;
            }
            return null;
        }
        public static DataView GetLookUpEditDatasource(Control parentCtl, string ControlName, string parentControlName )
        {
            Control ctl = FindControl(parentCtl, ControlName, parentControlName);
            if (ctl != null)
                return (DataView) ((LookUpEdit) ctl).Properties.DataSource;
            return null;
        }
    }
}
