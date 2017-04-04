package com.bv.eidss.model;

import com.bv.eidss.App;

public class LanguageItem
{
    public String id;
    public String name;

    public LanguageItem(String id){
        this.id = id;
        int resourceId = App.getResourcesStatic().getIdentifier(id, "string", App.getPackageNameStatic());
        this.name = App.getResourcesStatic().getString(resourceId);
    }

    @Override
    public String toString() {
        return name;
    }
}
