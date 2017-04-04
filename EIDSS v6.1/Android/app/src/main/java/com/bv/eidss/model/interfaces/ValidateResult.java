package com.bv.eidss.model.interfaces;

public class ValidateResult {
    private ValidateCode _code;
    private int _mandatory;
    private String _mandatory_str;

    public ValidateCode getCode() { return _code; }
    public int getMandatory() { return _mandatory; }
    public String getMandatoryStr() { return _mandatory_str; }

    public ValidateResult(ValidateCode code)
    {
        _code = code;
        _mandatory = 0;
    }
    public ValidateResult(ValidateCode code, int mandatory)
    {
        _code = code;
        _mandatory = mandatory;
    }
    public ValidateResult(ValidateCode code, String mandatory)
    {
        _code = code;
        _mandatory_str = mandatory;
    }
}
