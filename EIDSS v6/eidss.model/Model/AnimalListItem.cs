using System;
using System.Linq;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Enums;

namespace eidss.model.Schema
{
    public partial class AnimalListItem
    {
        public void CopyMainProperties(VetFarmTree spec)
        {
            //this._HACode = spec._HACode;
            this.idfSpecies = spec.idfParty;
            this.idfCase = spec.idfCase ?? this.idfCase;
            this.idfHerd = spec.idfParentParty.Value;
            this.strSpecies = spec.strSpeciesName;
            this.strHerdCode = spec.strHerdName;           
        }

        protected static void CustomValidations(AnimalListItem obj)
        {
            var acc = FFPresenterModel.Accessor.Instance(null);
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                acc.Validate(manager, obj.FFPresenterCs, true, false, true);
            }
        }

        public static void UpdateTemplate(AnimalListItem obj)
        {
            var templateAnimal = FFPresenterModel.LoadActualTemplate(EidssSiteContext.Instance.CountryID, obj.idfsDiagnosisForCs, FFTypeEnum.LivestockAnimalCS);
            obj.FFPresenterCs.SetProperties(templateAnimal, obj.idfAnimal);
            obj.idfsFormTemplate = templateAnimal.idfsFormTemplate;
        }

        public static string GetClinicalSigns(FFPresenterModel presenter)
        {
            string result = string.Empty;

            if (presenter.CurrentTemplate.ParameterTemplates.Count(p=>p.ParameterType == FFParameterTypes.Boolean) > 0)
            {
                var list = presenter.CurrentTemplate.ParameterTemplates.Where(p => p.ParameterType == FFParameterTypes.Boolean)
                    .Join(presenter.ActivityParameters, x => x.idfsParameter, y => y.idfsParameter, (x, y) => new { LabelText = x.NationalName, Checked = y.ToBool() })
                    .Where(v => v.Checked)
                    .Select(s => s.LabelText)
                    .ToArray();

                if (list.Length > 0)
                {
                    foreach (var s in list)
                    {
                        result += String.Format(", {0}", s);
                    }
                    if (result.Length > 0)
                        result = result.Substring(2);
                }
                    
            }
            
            return result;
        }
    }
}
