package com.bv.eidss.web;

import com.bv.eidss.model.GisBaseReferenceType;

import java.util.ArrayList;

@SuppressWarnings("serial")
public class VectorGisBaseReferenceRaw extends ArrayList<GisBaseReferenceRaw> {

    public VectorGisBaseReferenceRaw(){
        AddGisRefType(GisBaseReferenceType.rftCountry);
        AddGisRefType(GisBaseReferenceType.rftRegion);
        AddGisRefType(GisBaseReferenceType.rftRayon);
        AddGisRefType(GisBaseReferenceType.rftSettlement);
    }

    private void AddGisRefType(long type)	{
        GisBaseReferenceRaw r = new GisBaseReferenceRaw();
        r.idfsBaseReference = 0;
        r.idfsReferenceType = type;
        r.strDefault = "";
        this.add(r);
    }
}
