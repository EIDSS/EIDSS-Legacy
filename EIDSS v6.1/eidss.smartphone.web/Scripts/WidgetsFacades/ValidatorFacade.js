var validatorFacade = (function () {
    
    return {
        addForValidationSummary: function (formId) {
            var validatorData = $("#"+formId).kendoValidator({
                validateOnBlur: false,
                messages: {
                    required: ""
                },
                errorTemplate: "<span></span>"
            }).data("kendoValidator");
            return validatorData;
        },
        
        validate: function (validatorData) {
            return validatorData.validate();
        }
    };

})();