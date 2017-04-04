using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Schema;
using eidss.model.Core;


namespace eidss.smartphone.web.Models
{
    public partial class VetCaseSampleInfoIn : InfoInBase
    {
        public VetCaseSampleInfoIn()
        {
        }

        public VetCaseSampleInfoIn(VetCaseSample s)
        {
            uidOfflineCaseID = s.uidOfflineCaseID.HasValue ? s.uidOfflineCaseID.Value.ToString("D") : "";
            idfMaterial = s.idfMaterial;
            idfsSampleType = s.idfsSampleType;
            strFieldBarcode = s.strFieldBarcode == null ? "" : s.strFieldBarcode;
            idfAnimal = s.Animal == null ? 0 : s.Animal.idfAnimal;
            idfsSpeciesType = s.idfsSpeciesType.HasValue ? s.idfsSpeciesType.Value : 0;
            idfsBirdStatus = s.idfsBirdStatus.HasValue ? s.idfsBirdStatus.Value : 0;
            datFieldCollectionDate = s.datFieldCollectionDate.HasValue ? s.datFieldCollectionDate.Value : new DateTime();
            idfSendToOffice = s.idfSendToOffice.HasValue ? s.idfSendToOffice.Value : 0;
        }

        public static VetCaseSampleInfoIn Init(XElement xml)
        {
            VetCaseSampleInfoIn ret = new VetCaseSampleInfoIn(xml);
            return ret;
        }

        public void FillVetCaseSample(VetCaseSample s, int? hacode, long? idfSpecies)
        {
            s.uidOfflineCaseID = String.IsNullOrEmpty(uidOfflineCaseID) ? new Guid?() : new Guid(uidOfflineCaseID);
            s._HACode = hacode;
            s.SampleTypeForDiagnosis = s.SampleTypeForDiagnosisLookup.FirstOrDefault(c => c.idfsReference == idfsSampleType);
            s.strFieldBarcode = strFieldBarcode;

            if (hacode == (int)eidss.model.Enums.HACode.Livestock)
                s.Animal = idfAnimal == 0 ? null :
                    s.AnimalLookup.FirstOrDefault(c => c.idfAnimal == idfAnimal);
            else
                s.FarmTree = idfSpecies.HasValue ? (idfSpecies.Value > 0 ? s.FarmTreeLookup.FirstOrDefault(c => c.idfParty == idfSpecies.Value) : null) : null;

            s.idfsSpeciesType = idfsSpeciesType;
            s.BirdStatus = idfsBirdStatus == 0 ? null :
                s.BirdStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsBirdStatus);
            s.datFieldCollectionDate = datFieldCollectionDate;
        }

   }
}