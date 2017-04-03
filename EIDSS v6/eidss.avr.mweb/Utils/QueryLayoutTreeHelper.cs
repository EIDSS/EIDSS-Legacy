using System.Web.UI;
using DevExpress.Web.ASPxTreeList;
using eidss.model.Avr.Tree;

namespace eidss.avr.mweb.Utils
{
    public class QueryLayoutTreeHelper
    {
        public static AvrTreeElement GetTreeElement(TreeListEditFormTemplateContainer container)
        {
            if ((long?) DataBinder.Eval(container.DataItem, "ID") == null)
            {
                return new AvrTreeElement();
            }
            return new AvrTreeElement((long) DataBinder.Eval(container.DataItem, "ID"),
                (long?) DataBinder.Eval(container.DataItem, "ParentID"),
                (long?) DataBinder.Eval(container.DataItem, "GlobalID"),
                (AvrTreeElementType) DataBinder.Eval(container.DataItem, "ElementType"),
                (long) DataBinder.Eval(container.DataItem, "QueryID"),
                (string) DataBinder.Eval(container.DataItem, "DefaultName"),
                (string) DataBinder.Eval(container.DataItem, "NationalName"),
                (string) DataBinder.Eval(container.DataItem, "Description"),
                (bool) DataBinder.Eval(container.DataItem, "ReadOnly"),
                (bool) DataBinder.Eval(container.DataItem, "IsShared"),
                (string)DataBinder.Eval(container.DataItem, "DescriptionEnglish"),
                (long) DataBinder.Eval(container.DataItem, "DescriptionID")
                );
        }
    }
}