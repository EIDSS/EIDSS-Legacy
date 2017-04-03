using System;

namespace eidss.model.Enums
{
    [Flags]
    public enum HACode
    {
        None = 0,
        Animal = 1,
        Human = 2,
        HumanAnimal = 3,
        Exophyte = 4,
        Plant = 8,
        Soil = 16,
        Livestock = 32,
        Avian = 64,
        Vector = 128,
        Syndromic = 256,
        LivestockAvian = Livestock | Avian,
        HumanLivestockAvian = Human | Livestock | Avian,
        HumanLivestockAvianVector = Human | Livestock | Avian | Vector,
        All = unchecked((int)0xFFFFFFFF)
    }
}
