
namespace eidss.model.Enums
{
    public enum FFTypeEnum : long
	{
        None,
        //'VetClinicalSigns = 10034001
        //'VetEpiInvestigations = 10034002
        HumanLabTestsDetails = 10034003,
        Reports = 10034004,
        AggregateCase = 10034005,
        //'AvianAnimalCS = 10034006
        AvianFarmEPI = 10034007,
        AvianSpeciesCS = 10034008,
        FarmDetails = 10034009,
        HumanClinicalSigns = 10034010,
        HumanEpiInvestigations = 10034011,
        HumanAggregateCase = 10034012,
        LivestockAnimalCS = 10034013,
        LivestockControlMeasures = 10034014,
        LivestockFarmEPI = 10034015,
        LivestockSpeciesCS = 10034016,
        ServiceType = 10034017,
        TestDetails = 10034018,
        TestRun = 10034019,
        VetLabTestDetails = 10034020,
        VetAggregateCase = 10034021,
        /// <summary>
        /// Sanitary action
        /// </summary>
        VetEpizooticAction = 10034022,
        /// <summary>
        /// Diagnostic action
        /// </summary>
        VetEpizooticActionDiagnosisInv = 10034023,
        /// <summary>
        /// Prophilactic action
        /// </summary>
        VetEpizooticActionTreatment = 10034024,
        //'VetWildHerdCS = 10034025
        //'WildVetClinicalSigns = 10034026
        WildVetEpiInvestigations = 10034027,
        VectorTypeSpecificData = 10034025
	}
	public enum AggregateCaseSectionEnum : long
	{
	    VetCase = 71090000000
        ,DiagnosticAction = 71460000000
        ,ProphylacticAction = 71300000000
        ,HumanCase = 71190000000
        ,SanitaryAction = 71260000000
        //,FormN1 = 82350000000
        ,Unknown = -1
	}
}
