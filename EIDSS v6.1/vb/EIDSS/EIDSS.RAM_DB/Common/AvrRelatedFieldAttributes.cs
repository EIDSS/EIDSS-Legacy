namespace eidss.avr.db.Common
{
    public class AvrRelatedFieldAttributes
    {
        public AvrRelatedFieldAttributes(string @alias, string lookupAttribute, bool isUpperLevelRelations)
        {
            Alias = alias;
            LookupAttribute = lookupAttribute;
            IsUpperLevelRelations = isUpperLevelRelations;
        }

        public string Alias { get; private set; }
        public string  LookupAttribute { get; private set; }
        public bool IsUpperLevelRelations { get; private set; }
    }
}