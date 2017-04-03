using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eidss.model.Schema;
using eidss.model.Core;
using eidss.model.Enums;

namespace eidss.model.Schema
{
    public partial class AnimalListItem
    {
        public void CopyMainProperties(VetFarmTree spec)
        {
            this._HACode = spec._HACode;
            this.idfSpecies = spec.idfParty;                       
            this.idfCase = spec.idfCase ?? 0;
            this.idfHerd = spec.idfParentParty.Value;
            this.strSpecies = spec.strSpeciesName;
            this.strHerdCode = spec.strHerdName;           
        }


        public static void UpdateTemplate(AnimalListItem obj)
        {
            var templateAnimal = FFPresenterModel.LoadActualTemplate(EidssSiteContext.Instance.CountryID, obj.idfsDiagnosisForCs, FFTypeEnum.LivestockAnimalCS);
            obj.FFPresenterCs.SetProperties(templateAnimal);
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
                    foreach (string s in list)
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
