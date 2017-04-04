using eidss.model.Schema;
using System;
using System.Linq;
using System.Xml.Linq;

namespace eidss.smartphone.web.Models
{
    public partial class ASDiseaseInfoIn : InfoInBase
    {
        public ASDiseaseInfoIn()
        {
        }

        public ASDiseaseInfoIn(AsSessionDisease d)
        {
            idfCampaign = 0;
            idfMonitoringSession = d.idfMonitoringSession;
            idfsDiagnosis = d.idfsDiagnosis;
            idfsSpeciesType = d.idfsSpeciesType.GetValueOrDefault();
            idfsSampleType = d.idfsSampleType.GetValueOrDefault();
        }

        public void FillAsSessionDisease(AsSessionDisease d)
        {
            d.Diagnosis = d.DiagnosisLookup.FirstOrDefault(i => i.idfsDiagnosis == idfsDiagnosis);
            d.SpeciesType = d.SpeciesTypeLookup.FirstOrDefault(i => i.idfsBaseReference == idfsSpeciesType);
            d.SampleType = d.SampleTypeLookup.FirstOrDefault(i => i.idfsReference == idfsSampleType);
        }
        public ASDiseaseInfoIn(AsDisease d)
        {
            idfCampaign = d.idfCampaign;
            idfMonitoringSession = 0;
            idfsDiagnosis = d.idfsDiagnosis;
            idfsSpeciesType = d.idfsSpeciesType.GetValueOrDefault();
            idfsSampleType = d.idfsSampleType.GetValueOrDefault();
        }

        public static ASDiseaseInfoIn Init(XElement xml)
        {
            ASDiseaseInfoIn ret = new ASDiseaseInfoIn(xml);
            return ret;
        }
   }
}