package com.bv.eidss.model;

import android.content.ContentValues;
import android.database.Cursor;
import android.os.Parcel;
import android.os.Parcelable;

import org.json.JSONException;
import org.json.JSONObject;
import org.xmlpull.v1.XmlPullParser;
import org.xmlpull.v1.XmlPullParserException;

import java.io.IOException;
import java.util.ArrayList;

public class FFTemplateElement
        implements Parcelable
{
    public int id;
    public long idfsBaseReference;
    public long idfsFormTemplate;
    public long idfsBaseReferenceParent;
    public int intElementType;
    public long idfsEditor;
    public int intReadOnly;
    public int intMandatory;
    public long idfsParameterType;
    public int intOrder;
    public long idfsParameterCaption;

    public FFTemplateElement(){}

    public static FFTemplateElement FromCursor(Cursor cursor) {
        FFTemplateElement ret = new FFTemplateElement();
        ret.id = cursor.getInt(cursor.getColumnIndex("id"));
        ret.idfsBaseReference = cursor.getLong(cursor.getColumnIndex("idfsBaseReference"));
        ret.idfsFormTemplate = cursor.getLong(cursor.getColumnIndex("idfsFormTemplate"));
        ret.idfsBaseReferenceParent = cursor.getLong(cursor.getColumnIndex("idfsBaseReferenceParent"));
        ret.intElementType = cursor.getInt(cursor.getColumnIndex("intElementType"));
        ret.idfsEditor = cursor.getLong(cursor.getColumnIndex("idfsEditor"));
        ret.intReadOnly = cursor.getInt(cursor.getColumnIndex("intReadOnly"));
        ret.intMandatory = cursor.getInt(cursor.getColumnIndex("intMandatory"));
        ret.idfsParameterType = cursor.getLong(cursor.getColumnIndex("idfsParameterType"));
        ret.intOrder = cursor.getInt(cursor.getColumnIndex("intOrder"));
        ret.idfsParameterCaption = cursor.getLong(cursor.getColumnIndex("idfsParameterCaption"));
        return ret;
    }

    protected void FromParcel(Parcel source)
    {
        id = source.readInt();
        idfsBaseReference = source.readLong();
        idfsBaseReferenceParent = source.readLong();
        idfsEditor = source.readLong();
        idfsFormTemplate = source.readLong();
        idfsParameterType = source.readLong();
        intElementType = source.readInt();
        intMandatory = source.readInt();
        intOrder = source.readInt();
        intReadOnly = source.readInt();
        idfsParameterCaption = source.readLong();
    }

    public ContentValues ContentValues() {
        ContentValues ret = new ContentValues();
        ret.put("idfsBaseReference", idfsBaseReference);
        ret.put("idfsFormTemplate", idfsFormTemplate);
        ret.put("idfsBaseReferenceParent", idfsBaseReferenceParent);
        ret.put("intElementType", intElementType);
        ret.put("idfsEditor", idfsEditor);
        ret.put("intReadOnly", intReadOnly);
        ret.put("intMandatory", intMandatory);
        ret.put("idfsParameterType", idfsParameterType);
        ret.put("intOrder", intOrder);
        ret.put("idfsParameterCaption", idfsParameterCaption);
        return ret;
    }

    public FFTemplateElement(JSONObject json) throws JSONException {
        idfsBaseReference = json.getLong("br");
        idfsFormTemplate = json.getLong("ft");
        idfsBaseReferenceParent = json.getLong("brp");
        intElementType = json.getInt("et");
        idfsEditor = json.getLong("ed");
        intReadOnly = json.getInt("rd");
        intMandatory = json.getInt("md");
        idfsParameterType = json.getLong("pt");
        intOrder = json.getInt("od");
        idfsParameterCaption = json.getLong("ptt");
    }

    public FFTemplateElement(XmlPullParser parser) throws XmlPullParserException, IOException {
        idfsBaseReference = Long.parseLong(parser.getAttributeValue("", "br"));
        idfsFormTemplate = Long.parseLong(parser.getAttributeValue("", "ft"));
        idfsBaseReferenceParent = Long.parseLong(parser.getAttributeValue("", "brp"));
        intElementType = Integer.parseInt(parser.getAttributeValue("", "et"));
        idfsEditor = Long.parseLong(parser.getAttributeValue("", "ed"));
        intReadOnly = Integer.parseInt(parser.getAttributeValue("", "rd"));
        intMandatory = Integer.parseInt(parser.getAttributeValue("", "md"));
        idfsParameterType = Long.parseLong(parser.getAttributeValue("", "pt"));
        intOrder = Integer.parseInt(parser.getAttributeValue("", "od"));
        idfsParameterCaption = Long.parseLong(parser.getAttributeValue("", "ptt"));
    }

    public static ArrayList<FFTemplateElement> FromXml(XmlPullParser parser)throws XmlPullParserException, IOException {
        ArrayList<FFTemplateElement> r = new ArrayList<>();
        int eventType = parser.next();
        while (eventType != XmlPullParser.END_DOCUMENT){
            switch (eventType){
                case XmlPullParser.START_TAG:
                    String name = parser.getName();
                    if (name.equalsIgnoreCase("obj")){
                        r.add(new FFTemplateElement(parser));
                    }
                    break;
                case XmlPullParser.END_TAG:
                    name = parser.getName();
                    if (name.equalsIgnoreCase("tems")){
                        return r;
                    }
                    break;
            }
            eventType = parser.next();
        }
        return r;
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeInt(id);
        dest.writeLong(idfsBaseReference);
        dest.writeLong(idfsBaseReferenceParent);
        dest.writeLong(idfsEditor);
        dest.writeLong(idfsFormTemplate);
        dest.writeLong(idfsParameterType);
        dest.writeInt(intElementType);
        dest.writeInt(intMandatory);
        dest.writeInt(intOrder);
        dest.writeInt(intReadOnly);
        dest.writeLong(idfsParameterCaption);
    }

    private FFTemplateElement(Parcel source) {
        FromParcel(source);
    }

    public static final Parcelable.Creator<FFTemplateElement> CREATOR =
            new Parcelable.Creator<FFTemplateElement>() {

                @Override
                public FFTemplateElement createFromParcel(Parcel source) {
                    return new FFTemplateElement(source);
                }

                @Override
                public FFTemplateElement[] newArray(int size) {
                    return new FFTemplateElement[size];
                }
            };
}
