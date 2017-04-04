package com.bv.eidss.web;

import com.bv.eidss.model.BaseReferenceType;

import java.util.ArrayList;


@SuppressWarnings("serial")
public class VectorBaseReferenceRaw extends ArrayList<BaseReferenceRaw> {

    public ArrayList<Long> brTypes = new ArrayList<>();

    public VectorBaseReferenceRaw(ArrayList<Long> ffTypes){
        //full list of resources
        brTypes.add(BaseReferenceType.rftDiagnosis);
        brTypes.add(BaseReferenceType.rftAnimalAgeList);
        brTypes.add(BaseReferenceType.rftAnimalCondition);
        brTypes.add(BaseReferenceType.rftAnimalSex);
        brTypes.add(BaseReferenceType.rftSampleType);
        brTypes.add(BaseReferenceType.rftSampleTypeForDiagnosis);
        brTypes.add(BaseReferenceType.rftHumanAgeType);
        brTypes.add(BaseReferenceType.rftHumanGender);
        brTypes.add(BaseReferenceType.rftFinalState);
        brTypes.add(BaseReferenceType.rftHospStatus);
        brTypes.add(BaseReferenceType.rftInstitutionName);
        brTypes.add(BaseReferenceType.rftCaseClassification);
        brTypes.add(BaseReferenceType.rftYesNoValue);
        brTypes.add(BaseReferenceType.rftNationality);
        brTypes.add(BaseReferenceType.rftPersonIDType);
        brTypes.add(BaseReferenceType.rftOutcome);
        brTypes.add(BaseReferenceType.rftNotCollectedReason);
        brTypes.add(BaseReferenceType.rftCaseType);
        brTypes.add(BaseReferenceType.rftCaseReportType);
        brTypes.add(BaseReferenceType.rftSpeciesList);
        brTypes.add(BaseReferenceType.rftFFRuleMessage);
        brTypes.add(BaseReferenceType.rftFFTemplate);
        brTypes.add(BaseReferenceType.rftFFType);
        brTypes.add(BaseReferenceType.rftParameter);
        brTypes.add(BaseReferenceType.rftParametersFixedPresetValue);
        brTypes.add(BaseReferenceType.rftCampaignType);
        brTypes.add(BaseReferenceType.rftMonitoringSessionStatus);
        //FF
        brTypes.add(BaseReferenceType.rftParameterTooltip);
        brTypes.add(BaseReferenceType.rftSection);
        brTypes.add(BaseReferenceType.rftFlexibleFormLabelText);

        if(ffTypes != null) {
            for (long r: ffTypes) {
                if (!brTypes.contains(r)) brTypes.add(r);
            }
        }

        for(long tp : brTypes){
            AddRefType(tp);
        }
    }

    public void AddRefType(long type)	{
        BaseReferenceRaw r = new BaseReferenceRaw();
        r.idfsBaseReference = 0L;
        r.idfsReferenceType = type;
        r.intHACode = 482;
        r.strDefault = "";
        r.intFeature1 = 0L;
        r.intFeature2 = 0L;
        this.add(r);
    }
}
