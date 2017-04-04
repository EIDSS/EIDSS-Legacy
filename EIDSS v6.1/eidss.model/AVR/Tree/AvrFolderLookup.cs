using eidss.model.Avr.Tree;

namespace eidss.model.Schema
{
    public partial class AvrFolderLookup
    {
        public static explicit operator AvrTreeElement(AvrFolderLookup folder)
        {
            var treeElement = new AvrTreeElement(folder.idflFolder,
                folder.idflParentFolder ?? folder.idflQuery,
                folder.idfsGlobalFolder,
                AvrTreeElementType.Folder,
                folder.idflQuery,
                folder.strDefaultFolderName,
                folder.strFolderName,
                string.Empty,
                folder.blnReadOnly,
                false);
            return treeElement;
        }
    }
}