package com.bv.eidss.model;

import android.content.ContentValues;
import android.database.Cursor;

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
        ret.idfsBaseReference = cursor.getLong(cursor.getColumnIndex("_id"));
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
