using System;

namespace bv.common.Enums
{
    /// <summary>
    /// Case type (in AVR data table)
    /// </summary>
    [Flags]
    public enum GisCaseType
    {
        Unkown = 0x0,
        Human = 0x1,
        Vet = 0x2,
        Vector = 0x4,
        Avian = 0x8,
        Livestock = 0x10,
        HumanVet = Human | Vet,
        HumanVector = Human | Vector,
        VetVector = Vet | Vector,
    }
}
