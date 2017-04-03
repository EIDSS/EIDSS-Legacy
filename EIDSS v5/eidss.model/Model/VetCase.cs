using System.Linq;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Enums;

namespace eidss.model.Schema
{
    public partial class VetCase
    {
        /*
        partial void Created(bv.model.BLToolkit.DbManagerProxy manager)
        {
            SetParent();
        }
        partial void Loaded(bv.model.BLToolkit.DbManagerProxy manager)
        {
            SetParent();
        }

        private void SetParent()
        {
            Farm.VCase = this;
            Farm.Address.VCase = this;
            Farm.Location.VCase = this;
        }
        private void ClearParent()
        {
            Farm.VCase = null;
            Farm.Address.VCase = null;
            Farm.Location.VCase = null;
        }
        */
        /*
        public override object Clone()
        {
            ClearParent();
            VetCase ret = base.Clone() as VetCase;
            SetParent();
            ret.SetParent();
            return ret;
        }
        */

        /// <summary>
        /// 
        /// </summary>
        private bool IsLivestock
        {
            get { return _HACode.HasValue ? _HACode.Value == (int) HACode.Livestock : false; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="needRecalculateTemplate">Нужно ли полностью пересчитывать шаблон, например, при смене диагноза</param>
        private void SetFFChildren(bool needRecalculateTemplate)
        {
            if (needRecalculateTemplate)
            {
                var templateFarm = FFPresenterModel.LoadActualTemplate(EidssSiteContext.Instance.CountryID,
                                                                       idfsDiagnosis,
                                                                       IsLivestock
                                                                           ? FFTypeEnum.LivestockFarmEPI
                                                                           : FFTypeEnum.AvianFarmEPI);

                Farm.FFPresenterEpi.SetProperties(templateFarm);
                Farm.idfsFormTemplate = templateFarm.idfsFormTemplate;
            }
            //
            var farmTrees = Farm.FarmTree.Where(ft => ft.idfsPartyType == (long)PartyTypeEnum.Species);
            if (farmTrees.Count() > 0)
            {                
                var templateFarmTree = farmTrees.ToList()[0].FFPresenterCs.CurrentTemplate;

                if (needRecalculateTemplate || (templateFarmTree == null))
                {
                    templateFarmTree = FFPresenterModel.LoadActualTemplate(EidssSiteContext.Instance.CountryID,
                                                                           idfsDiagnosis,
                                                                           IsLivestock
                                                                               ? FFTypeEnum.LivestockSpeciesCS
                                                                               : FFTypeEnum.AvianSpeciesCS);
                }

                foreach (var ft in farmTrees)
                {
                    if (needRecalculateTemplate || (ft.FFPresenterCs.CurrentTemplate == null))
                    {
                        ft.FFPresenterCs.SetProperties(templateFarmTree);
                        ft.idfsFormTemplate = templateFarmTree.idfsFormTemplate;
                    }
                }
            }

            //Animal List
            if (IsLivestock && (AnimalList.Count() > 0))
            {
                var templateAnimal = AnimalList[0].FFPresenterCs.CurrentTemplate;
                if (needRecalculateTemplate)
                {
                    templateAnimal = FFPresenterModel.LoadActualTemplate(EidssSiteContext.Instance.CountryID,
                                                                         idfsDiagnosis, FFTypeEnum.LivestockAnimalCS);
                }
                foreach (var a in AnimalList)
                {
                    if (needRecalculateTemplate || (a.FFPresenterCs.CurrentTemplate == null))
                    {
                        a.FFPresenterCs.SetProperties(templateAnimal);
                        a.idfsFormTemplate = templateAnimal.idfsFormTemplate;
                    }
                }
            }

            //Case test
            if (CaseTests.Count > 0)
            {
                var templateCaseTest = CaseTests[0].FFPresenter.CurrentTemplate;
                if (needRecalculateTemplate)
                {
                    templateCaseTest = FFPresenterModel.LoadActualTemplate(EidssSiteContext.Instance.CountryID,
                                                                               idfsDiagnosis, FFTypeEnum.TestDetails);
                }
                foreach (var ct in CaseTests)
                {
                    if (needRecalculateTemplate || (ct.FFPresenter.CurrentTemplate == null))
                    {
                        ct.FFPresenter.SetProperties(templateCaseTest);
                        ct.idfsFormTemplate = templateCaseTest.idfsFormTemplate;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected void SetNewFFTemplatesValues()
        {
            if (IsLivestock)
            {
                //VetCase
                var template = FFPresenterModel.LoadActualTemplate(EidssSiteContext.Instance.CountryID, idfsDiagnosis, FFTypeEnum.LivestockControlMeasures);
                FFPresenterControlMeasures.SetProperties(template);
            }
            //проставляем дочерним объектам
            SetFFChildren(true);
        }

        /// <summary>
        /// 
        /// </summary>
        public partial class Accessor
        {
           
            protected void CustomSampleValidator(VetCase data)
            {
                if (data.strSampleNotes == "AAA")
                    throw new ValidationModelException("AAA", "", "", new string[] { }, null, false);
            }

            

            /*
                        protected void SetLookupFilters(VetCase data)
                        {
                            data.TentativeDiagnosisLookup =
                                data.TentativeDiagnosisLookup
                                .Where(c => (c.intHACode.GetValueOrDefault(0) & (data.CaseType.strDefault == "Livestock" ? 32 : 64)) != 0)
                                    .ToList();

                            data.TentativeDiagnosis1Lookup =
                                data.TentativeDiagnosis1Lookup
                                .Where(c => (c.intHACode.GetValueOrDefault(0) & (data.CaseType.strDefault == "Livestock" ? 32 : 64)) != 0)
                                    .ToList();

                            data.TentativeDiagnosis2Lookup =
                                data.TentativeDiagnosis2Lookup
                                .Where(c => (c.intHACode.GetValueOrDefault(0) & (data.CaseType.strDefault == "Livestock" ? 32 : 64)) != 0)
                                    .ToList();

                            //data.FinalDiagnosisLookup =
                            //    data.FinalDiagnosisLookup
                            //    .Where(c => (c.intHACode.GetValueOrDefault(0) & (data.CaseType.strDefault == "Livestock" ? 32 : 64)) != 0)
                            //        .ToList();
                        }
            */
        }
    }
}
