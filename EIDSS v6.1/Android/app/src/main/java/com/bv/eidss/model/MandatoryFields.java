package com.bv.eidss.model;

import android.database.Cursor;
import android.content.ContentValues;

public class MandatoryFields {
    public long idfMandatoryField;
    public String strFieldAlias;

    @Override
    public String toString()
    {
        return strFieldAlias;
    }

    public static MandatoryFields FromCursor(Cursor cursor)
    {
        MandatoryFields ret = new MandatoryFields();
        ret.idfMandatoryField = cursor.getLong(cursor.getColumnIndex("idfMandatoryField"));
        ret.strFieldAlias = cursor.getString(cursor.getColumnIndex("strFieldAlias"));
        return ret;
    }

    public ContentValues ContentValues()
    {
    	ContentValues ret = new ContentValues();
        ret.put("idfMandatoryField", idfMandatoryField);
        ret.put("strFieldAlias", strFieldAlias);
        return ret;
    }

}
