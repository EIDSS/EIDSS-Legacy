package com.bv.eidss.model.interfaces;

import java.util.List;

public class FieldMetadata<R, T> {
    private String _name;
    private int _title;
    private ICallable<R, T> _get;

    public FieldMetadata(String name, int title, ICallable<R, T> get){
        _name = name;
        _title = title;
        _get = get;
    }

    public int getTitle() { return _title; }

    public String getName() { return _name; }

    public Boolean CheckMandatory(T receiver, List<String> mandatoryFields, List<String> invisibleFields)
    {
        if (!invisibleFields.contains(_name) && mandatoryFields.contains(_name)) {
            return NotEmpty(receiver);
        }
        return true;
    }

    public Boolean NotEmpty(T receiver)
    {
        R ret = _get.call(receiver);
        if (ret == null){
            return false;
        }
        if (ret instanceof Long){
            Long val = (Long) ret;
            if (val == 0)
                return false;
        }
        if (ret instanceof Double){
            Double val = (Double) ret;
            if (val == 0)
                return false;
        }
        if (ret instanceof String){
            String val = (String) ret;
            if (val == null || val.trim().length() == 0)
                return false;
        }
        return true;
    }
}
