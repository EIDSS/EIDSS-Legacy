using System;
using eidss.model.Avr.Tree;

namespace eidss.avr.db.AvrEventArgs.AvrEventArgs
{
    public class AvrTreeSelectedElementEventArgs : EventArgs
    {
        public AvrTreeSelectedElementEventArgs()
        {
            QueryId = -1;
            FolderId = -1;
        }

        public AvrTreeSelectedElementEventArgs
            (long queryId, long elementId, long? parentId, long folderId, AvrTreeElementType type, string treeElementPath)
        {
            QueryId = queryId;
            ElementId = elementId;
            ParentId = parentId;
            FolderId = folderId;
            Type = type;
            TreeElementPath = treeElementPath;
        }

        public long QueryId { get; set; }

        public long? ElementId { get; set; }

        public long? ParentId { get; set; }

        public long FolderId { get; set; }

        public AvrTreeElementType Type { get; set; }

        public string TreeElementPath { get; set; }
    }
}