package com.bv.eidss.model.interfaces;

import java.util.List;

public interface IValidatable {
	public ValidateResult Validate(List<String> mandatoryFields, List<String> invisibleFields);
}
