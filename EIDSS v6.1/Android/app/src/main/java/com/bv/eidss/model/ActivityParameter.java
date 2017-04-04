package com.bv.eidss.model;

import android.content.ContentValues;
import android.database.Cursor;
import android.os.Parcel;
import android.os.Parcelable;

import com.bv.eidss.utils.EidssUtils;

import org.json.JSONException;
import org.json.JSONObject;
import org.xmlpull.v1.XmlSerializer;

import java.io.IOException;
import java.util.Calendar;
import java.util.Date;

public class ActivityParameter
        implements Parcelable
{
    public long id;
	public long idfObservation;
	public long idfsParameter;
	public long idfRow;
	public String Value;
    public int idDialog; //uses for controls who needs this

	public ActivityParameter(){
		idfObservation = idfsParameter = 0;
		idfRow = -1;
		Value = null;
        setChanged(false);
	}

    private Boolean bChanged = false;

    public void setChanged(Boolean value){bChanged = value;}
    public Boolean getChanged(){return bChanged;}

    public ContentValues ContentValues()
    {
        ContentValues ret = new ContentValues();
        if (id != 0) ret.put("id", id);
        ret.put("idfObservation", idfObservation);
        ret.put("idfsParameter", idfsParameter);
        ret.put("idfRow", idfRow);
        ret.put("strValue", Value);
        return ret;
    }

	public String GetKey(){
		return GetKey(idfObservation, idfsParameter, idfRow);
	}

    public static String GetKey(final long idfObservation, final long idfsParameter,final long idfRow){
        return String.format("%d_p%d_r%d", idfObservation, idfsParameter, idfRow);
    }

    /*
    public String ValueText(){
        return Value != null ? String.valueOf(Value) : "";
    }
    */

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeLong(id);
        dest.writeLong(idfObservation);
        dest.writeLong(idfsParameter);
        dest.writeLong(idfRow);
        dest.writeString(Value);
        dest.writeInt(getChanged() ? 1 : 0);
    }

    protected void FromParcel(Parcel source)
    {
        id = source.readLong();
        idfObservation = source.readLong();
        idfsParameter = source.readLong();
        idfRow = source.readLong();
        Value = source.readString();
        int changed =  source.readInt();
        setChanged(changed == 1);
    }

    private ActivityParameter(Parcel source) {
        FromParcel(source);
    }

    public static final Parcelable.Creator<ActivityParameter> CREATOR =
            new Parcelable.Creator<ActivityParameter>() {

                @Override
                public ActivityParameter createFromParcel(Parcel source) {
                    return new ActivityParameter(source);
                }

                @Override
                public ActivityParameter[] newArray(int size) {
                    return new ActivityParameter[size];
                }
            };

    public void SetValue(String val){
        Value = val;
        setChanged(true);
    }

    public void SetValue(long val){
        Value = String.valueOf(val);
        setChanged(true);
    }

    public void SetValue(int val){
        Value = String.valueOf(val);
        setChanged(true);
    }

    /*
    public void SetValue(int year, int month, int day){
        Value = String.valueOf(year) + String.format("##", month)  + String.format("##", day);
    }
    */

    public void SetValue(Boolean val){
        Value = val ? "1" : "0";
        setChanged(true);
    }

    protected void ToXml(XmlSerializer serializer) throws IllegalArgumentException, IllegalStateException, IOException {
        serializer.startTag("", "ap");
        serializer.attribute("", "idfsParameter", String.valueOf(idfsParameter));
        serializer.attribute("", "idfRow", String.valueOf(idfRow));
        serializer.attribute("", "Value", Value);
        serializer.endTag("", "ap");
    }

    public JSONObject ToJson() throws JSONException {
        JSONObject ret = new JSONObject();
        EidssUtils.putToJson(ret, "idfsParameter", idfsParameter);
        EidssUtils.putToJson(ret, "idfRow", idfRow);
        EidssUtils.putToJson(ret, "Value", Value);
        return ret;
    }

    public static ActivityParameter FromJson(JSONObject json) throws JSONException {
        ActivityParameter ret = new ActivityParameter();
        ret.idfsParameter = json.getLong("idfsParameter");
        ret.idfRow = json.getLong("idfRow");
        ret.Value = json.getString("Value");
        return ret;
    }

    public static ActivityParameter FromCursor(Cursor cursor) {
        ActivityParameter ret = new ActivityParameter();
        ret.id = cursor.getInt(cursor.getColumnIndex("id"));
        ret.idfObservation = cursor.getLong(cursor.getColumnIndex("idfObservation"));
        ret.idfsParameter = cursor.getLong(cursor.getColumnIndex("idfsParameter"));
        ret.idfRow = cursor.getLong(cursor.getColumnIndex("idfRow"));
        ret.Value = cursor.getString(cursor.getColumnIndex("strValue"));
        return ret;
    }
}
