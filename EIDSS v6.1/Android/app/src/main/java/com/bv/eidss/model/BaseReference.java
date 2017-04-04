package com.bv.eidss.model;

import android.database.Cursor;
import android.content.ContentValues;
import android.os.Parcel;
import android.os.Parcelable;

import com.bv.eidss.App;
import com.bv.eidss.R;

import java.io.Serializable;

public class BaseReference implements Serializable, Parcelable {
    public long idfsBaseReference;
    public String name;

    @Override
    public String toString()
    {
        return name;
    }

    public BaseReference(long id, String name)
    {idfsBaseReference = id;this.name = name;}

    public static BaseReference FromCursor(Cursor cursor)
    {
        return new BaseReference(cursor.getLong(cursor.getColumnIndex("idfsBaseReference")), cursor.getString(cursor.getColumnIndex("name")));
    }

    public static BaseReference Empty()
    {
        return new BaseReference(0L, "");//App.getResourcesStatic().getString(R.string.EmptyValue));
    }

    public static BaseReference EmptyNewAnimal() {
        return new BaseReference(0L, App.getResourcesStatic().getString(R.string.LinkNewAnimal));
    }

    public ContentValues ContentValues()
    {
    	ContentValues ret = new ContentValues();
        ret.put("idfsBaseReference", idfsBaseReference);
        ret.put("name", name);
        return ret;
    }


    private BaseReference(Parcel source) {
        idfsBaseReference = source.readLong();
        name = source.readString();
    }

    public static final Creator<BaseReference> CREATOR =
        new Creator<BaseReference>() {

            @Override
            public BaseReference createFromParcel(Parcel source) {
                return new BaseReference(source);
            }

            @Override
            public BaseReference[] newArray(int size) {
                return new BaseReference[size];
            }
        };

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeLong(idfsBaseReference);
        dest.writeString(name);
    }
}
