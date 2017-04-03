using System;

namespace eidss.model.Avr.Tree
{
    [Serializable]
    public class AvrTreeElement
    {
        public AvrTreeElement()
        {

        }

        public AvrTreeElement
            (long id, long? parentID, long? globalID, AvrTreeElementType elementType, long queryID, string defaultName,
                string nationalName, string description, bool readOnly, bool shared = false, string descriptionEnglish = "",
                long idDescription = -1)
        {
            ID = id;
            ParentID = parentID;
            GlobalID = globalID;
            QueryID = queryID;
            ElementType = elementType;
            DefaultName = defaultName;
            NationalName = nationalName;
            DescriptionID = idDescription;
            Description = description;
            DescriptionEnglish = descriptionEnglish;
            IsPublished = ReadOnly = readOnly;
            IsShared = shared;
        }

        public bool IsPublished { get; set; }

        public bool IsShared { get; set; }

        public long ID{ get; set; }

        public long? ParentID { get; set; }

        public long? GlobalID { get; set; }

        public string DefaultName { get; set; }

        public string NationalName { get; set; }

        public long DescriptionID { get; set; }

        public string Description { get; set; }

        public string DescriptionEnglish { get; set; }

        public bool ReadOnly{ get; set; }

        public long QueryID { get; set; }

        public AvrTreeElementType ElementType { get; set; }

        public bool IsLayout
        {
            get { return ElementType == AvrTreeElementType.Layout; }
        }

        public bool IsQuery
        {
            get { return ElementType == AvrTreeElementType.Query; }
        }

        public bool IsFolder
        {
            get { return ElementType == AvrTreeElementType.Folder; }
        }

        public override string ToString()
        {
            var type = IsLayout ? "Layout" : "Folder";
            return string.Format("{0} ID:{1}, ParentID:{2}, Name:{3}", type, ID, ParentID, DefaultName);
        }

        public bool IsEqual(AvrTreeElement elem)
        {
            return
                (DefaultName == elem.DefaultName)
                && (NationalName == elem.NationalName)
                && (Description == elem.Description)
                && (DescriptionEnglish == elem.DescriptionEnglish)
                && (IsShared == elem.IsShared)
                && (IsPublished == elem.IsPublished);
        }
    }
}