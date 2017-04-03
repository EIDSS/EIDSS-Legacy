using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.model.BLToolkit;
using eidss.model.Enums;

namespace eidss.model.Schema
{
    public partial class AsSessionTableViewItem
    {
        public void UpdateAnimal(AsSessionAnimal asSessionAnimal)
        {            
            asSessionAnimal.strAnimalCode = this.strAnimalCode;
            asSessionAnimal.strColor = this.strColor;
            asSessionAnimal.strName = this.strName;
            asSessionAnimal.AnimalAge = this.AnimalAge;
            asSessionAnimal.AnimalGender = this.AnimalGender;
            asSessionAnimal.idfSpecies = this.idfSpecies;
        }

        public void UpdateSample(AsSessionSample sample)
        {
            sample.SampleType = this.SampleType;
            sample.strFieldBarcode = this.strFieldBarcode;
            sample.datFieldCollectionDate = this.datFieldCollectionDate;
            sample.idfsSpecimenType = this.idfsSpecimenType.HasValue ? this.idfsSpecimenType.Value : 0;
            sample.idfMonitoringSession = this.idfMonitoringSession;
        }

        private void UpdateLineAnimal()
        {
            this.strColor = Animal.strColor;
            this.AnimalGender = Animal.AnimalGender;
            this.AnimalAge = Animal.AnimalAge;
            this.strAnimalCode = Animal.strAnimalCode;
            this.strName = Animal.strName;         
        }

        private void UpdateLineSample()
        {
            idfsSpecimenType = Sample.idfsSpecimenType;
            strFieldBarcode = Sample.strFieldBarcode;
            datFieldCollectionDate = Sample.datFieldCollectionDate;
            strSpecimenName = Sample.strSpecimenName;
        }

        private void UpdateLineFarm()
        {
            idfFarmActual = Farm.idfRootFarm;
            strFarmCode = Farm.strFarmCode;
        }
    }

    public partial class AsSessionFarmSpeciesListItem
    {
        public partial class Accessor
        {
            /*public virtual List<AsSessionFarmSpeciesListItem> SelectDetailList(DbManagerProxy manager
                    , Int64? idfMonitoringSession
                    )
            {
                return _SelectList(manager
                    , idfMonitoringSession
                    , null
                    , delegate(AsSessionFarmSpeciesListItem obj)
                    {

                    }
                    , delegate(AsSessionFarmSpeciesListItem obj)
                    {

                    }
                    );
            }*/
        }
    }
}
