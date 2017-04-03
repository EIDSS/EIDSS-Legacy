Imports bv.common.db.Core
Imports bv.common.Objects
Namespace Tests
    Public Enum LookupTables
        Country
        Rayon
        Region
        Settlement
        Organization
        Department
        Person
        AvianDiagnoses
        HumanDiagnoses
    End Enum
    Public Class DummyLookupCacheHelper
        Public Shared Sub Init()
            Dim table As LookupTableInfo
            LookupCache.Clear()
            LookupCache.LookupTables.Add(LookupTables.Country.ToString, New LookupTableInfo(LookupTables.Country, True))
            LookupCache.LookupTables.Add(LookupTables.Organization.ToString, New LookupTableInfo(LookupTables.Organization, True, "Office"))
            LookupCache.LookupTables.Add(LookupTables.Department.ToString, New LookupTableInfo(LookupTables.Department, True, "Office"))
            LookupCache.LookupTables.Add(LookupTables.Person.ToString, New LookupTableInfo(LookupTables.Person, True))
            LookupCache.LookupTables.Add(LookupTables.Rayon.ToString, New LookupTableInfo(LookupTables.Rayon, True))
            LookupCache.LookupTables.Add(LookupTables.Region.ToString, New LookupTableInfo(LookupTables.Region, True))
            LookupCache.LookupTables.Add(LookupTables.Settlement.ToString, New LookupTableInfo(LookupTables.Settlement, True))
            table = New LookupTableInfo(LookupTables.AvianDiagnoses, True, "Diagnosis_List", "spDiagnosis_List_HACode_SelectLookup")
            table.Parameters.Add("@HA_Code", 1 Or 32 Or 64)
            LookupCache.LookupTables.Add(LookupTables.AvianDiagnoses.ToString, table)
            table = New LookupTableInfo(LookupTables.HumanDiagnoses, True, "Diagnosis_List", "spDiagnosis_List_HACode_SelectLookup")
            table.Parameters.Add("@HA_Code", 2)
            LookupCache.LookupTables.Add(LookupTables.HumanDiagnoses.ToString, table)
            LookupCache.Init()

        End Sub
    End Class

End Namespace

