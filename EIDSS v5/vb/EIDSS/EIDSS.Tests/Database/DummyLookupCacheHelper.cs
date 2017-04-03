using bv.common.db.Core;
using bv.common.Objects;

namespace EIDSS.Tests.Database
{
    public enum DummyLookupTables
    {
        Country,
        Rayon,
        Region,
        Settlement,
        Organization,
        Department,
        Person,
        AvianDiagnoses,
        HumanDiagnoses
    }

    public class DummyLookupCacheHelper
    {

        public static void Init()
        {
            LookupCache.Clear();
            LookupCache.LookupTables.Add(DummyLookupTables.Country.ToString(), new LookupTableInfo(DummyLookupTables.Country, true, null, null, null, null));
            LookupCache.LookupTables.Add(DummyLookupTables.Organization.ToString(), new LookupTableInfo(DummyLookupTables.Organization, true, "tlbOffice", null, null, null));
            LookupCache.LookupTables.Add(DummyLookupTables.Department.ToString(), new LookupTableInfo(DummyLookupTables.Department, true, "tlbOffice", null, null, null));
            LookupCache.LookupTables.Add(DummyLookupTables.Person.ToString(), new LookupTableInfo(DummyLookupTables.Person, true, null, null, null, null));
            LookupCache.LookupTables.Add(DummyLookupTables.Rayon.ToString(), new LookupTableInfo(DummyLookupTables.Rayon, true, null, null, null, null));
            LookupCache.LookupTables.Add(DummyLookupTables.Region.ToString(), new LookupTableInfo(DummyLookupTables.Region, true, null, null, null, null));
            LookupCache.LookupTables.Add(DummyLookupTables.Settlement.ToString(), new LookupTableInfo(DummyLookupTables.Settlement, true, null, null, null, null));
            LookupTableInfo table = new LookupTableInfo(DummyLookupTables.AvianDiagnoses, true, "trtDiagnosis", "spDiagnosis_SelectLookup", null, null);
            table.Parameters.Add("@HACode", 1 | 32 | 64);
            LookupCache.LookupTables.Add(DummyLookupTables.AvianDiagnoses.ToString(), table);
            table = new LookupTableInfo(DummyLookupTables.HumanDiagnoses, true, "trtDiagnosis", "spDiagnosis_SelectLookup", null, null);
            table.Parameters.Add("@HACode", 2);
            LookupCache.LookupTables.Add(DummyLookupTables.HumanDiagnoses.ToString(), table);
            LookupCache.Init(true,true);

        }
    }
}