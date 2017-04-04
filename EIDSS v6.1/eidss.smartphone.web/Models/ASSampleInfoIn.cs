using eidss.model.Schema;
using System;
using System.Linq;
using System.Xml.Linq;
using bv.model.Helpers;

namespace eidss.smartphone.web.Models
{
    public partial class ASSampleInfoIn : InfoInBase
    {
        public ASSampleInfoIn()
        {
        }


        public ASSampleInfoIn(AsSessionAnimalSample s)
        {
            uidOfflineCaseID = s.uidOfflineCaseID.StrOrEmpty();
            idfMonitoringSession = s.idfMonitoringSession.GetValueOrDefault();
            idfFarm = s.idfFarm;
            idfsSpeciesType = s.idfsSpeciesType;
            idfAnimal = s.idfAnimal;
            strAnimalCode = s.strAnimalCode;
            idfsAnimalAge = s.idfsAnimalAge.GetValueOrDefault();
            strColor = s.strColor;
            idfsAnimalGender = s.idfsAnimalGender.GetValueOrDefault();
            strName = s.strName;
            strDescription = s.strDescription;
            idfMaterial = s.idfMaterial.GetValueOrDefault();
            idfsSampleType = s.idfsSampleType.GetValueOrDefault();
            strFieldBarcode = s.strFieldBarcode;
            datFieldCollectionDate = s.datFieldCollectionDate.GetValueOrDefault();
            idfSendToOffice = s.idfSendToOffice.GetValueOrDefault();
        }

        public void FillAsSessionSample(AsSessionAnimalSample a)
        {
            a.uidOfflineCaseID = new Guid(uidOfflineCaseID);
            a.Farms = a.FarmsLookup.FirstOrDefault(i => i.idfFarm == idfFarm);
            a.Species = a.SpeciesLookup.FirstOrDefault(i => i.idfsSpeciesTypeReference == idfsSpeciesType);
            a.strAnimalCode = strAnimalCode;
            a.Animals = a.AnimalsLookup.FirstOrDefault(i => i.strAnimalCode == strAnimalCode);
            a.AnimalAge = a.AnimalAgeLookup.FirstOrDefault(i => i.idfsReference == idfsAnimalAge);
            a.strColor = strColor;
            a.AnimalGender = a.AnimalGenderLookup.FirstOrDefault(i => i.idfsBaseReference == idfsAnimalGender);
            a.strName = strName;
            a.strDescription = strDescription;
            a.SampleType = a.SampleTypeLookup.FirstOrDefault(i => i.idfsReference == idfsSampleType);
            a.strFieldBarcode = strFieldBarcode;
            a.datFieldCollectionDate = datFieldCollectionDate == DateTime.MinValue ? new DateTime?() : datFieldCollectionDate;
            a.strSendToOffice = "_";
            a.idfSendToOffice = idfSendToOffice == 0 ? new long?() : idfSendToOffice;
        }

        public static ASSampleInfoIn Init(XElement xml)
        {
            ASSampleInfoIn ret = new ASSampleInfoIn(xml);
            return ret;
        }
   }
}