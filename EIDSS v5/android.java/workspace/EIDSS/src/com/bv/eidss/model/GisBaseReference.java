package com.bv.eidss.model;

import android.database.Cursor;
import android.content.ContentValues;

public class GisBaseReference {
    public long idfsBaseReference;
    public String name;

    @Override
    public String toString()
    {
        return name;
    }

    public static GisBaseReference FromCursor(Cursor cursor)
    {
    	GisBaseReference ret = new GisBaseReference();
        ret.idfsBaseReference = cursor.getLong(cursor.getColumnIndex("idfsBaseReference"));
        ret.name = cursor.getString(cursor.getColumnIndex("name"));
        return ret;
    }

    public ContentValues ContentValues()
    {
    	ContentValues ret = new ContentValues();
        ret.put("idfsBaseReference", idfsBaseReference);
        ret.put("name", name);
        return ret;
    }
}
