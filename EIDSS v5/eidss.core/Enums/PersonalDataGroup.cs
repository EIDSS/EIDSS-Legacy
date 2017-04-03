using System;

namespace eidss.model.Enums
{
    public enum PersonalDataGroup : long
    {
        None = 0,
        Human_PersonName = 1,
        Human_PersonAge = 2,
        Human_PersonSex = 3,
        Human_CurrentResidence_Settlement = 4,
        Human_CurrentResidence_Details = 5,
        Human_CurrentResidence_Coordinates = 6,
        Human_Employer_Settlement = 7,
        Human_Employer_Details = 8,
        Human_PermanentResidence_Settlement = 9,
        Human_PermanentResidence_Details = 10,
        Human_PermanentResidence_Coordinates = 11,
        Human_Contact_Settlement = 12,
        Human_Contact_Details = 13,
        Vet_Farm_Settlement = 14,
        Vet_Farm_Details = 15,
        Vet_Farm_Coordinates = 16
    }
}
