using System.Web;
using System.Web.UI;
using DevExpress.Web.ASPxTreeList;
using eidss.model.Avr.Tree;

namespace eidss.avr.mweb.Utils
{
    public class QueryLayoutTreeHelper
    {
        public static AvrTreeElement GetTreeElement(TreeListEditFormTemplateContainer container, HttpCookie newElementType)
        {
            if ((long?) DataBinder.Eval(container.DataItem, "ID") == null)
            {
                var elem =  new AvrTreeElement();
                if (newElementType != null)
                {
                    if (newElementType.Value == "folder")
                       elem.ElementType = AvrTreeElementType.Folder;                        
                    else if(newElementType.Value == "layout")
                       elem.ElementType = AvrTreeElementType.Layout;
                    newElementType.Value = "";
                }
                return elem;
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
                (long) DataBinder.Eval(container.DataItem, "DescriptionID"),
                (string)DataBinder.Eval(container.DataItem, "LayoutAuthor"),
                (bool)DataBinder.Eval(container.DataItem, "IsUseArchiveData")
                );
        }
    }
}