package com.bv.eidss.model;

import android.database.Cursor;
import android.content.ContentValues;

public class InvisibleFields {
    public long idfInvisibleField;
    public String strFieldAlias;

    @Override
    public String toString()
    {
        return strFieldAlias;
    }

    public static InvisibleFields FromCursor(Cursor cursor)
    {
        InvisibleFields ret = new InvisibleFields();
        ret.idfInvisibleField = cursor.getLong(cursor.getColumnIndex("idfInvisibleField"));
        ret.strFieldAlias = cursor.getString(cursor.getColumnIndex("strFieldAlias"));
        return ret;
    }

    public ContentValues ContentValues()
    {
    	ContentValues ret = new ContentValues();
        ret.put("idfInvisibleField", idfInvisibleField);
        ret.put("strFieldAlias", strFieldAlias);
        return ret;
    }

}
