using System;

namespace eidss.model.AVR.Db
{
    [Serializable]
    public class DatabaseNames
    {
        public DatabaseNames(string eidssActualDbName, string eidssArchiveDbName, string avrDbName)
        {
            EidssActualDbName = eidssActualDbName;
            EidssArchiveDbName = eidssArchiveDbName;
            AvrDbName = avrDbName;
        }

        public string EidssActualDbName { get; private set; }
        public string EidssArchiveDbName { get; private set; }
        public string AvrDbName { get; private set; }
    }
}