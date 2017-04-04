package com.bv.eidss.model;

import android.content.ContentValues;
import android.os.Parcel;
import android.os.Parcelable;
import android.support.v4.util.SimpleArrayMap;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.interfaces.ValidateCode;
import com.bv.eidss.model.interfaces.ValidateResult;
import com.bv.eidss.utils.EidssUtils;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;
import org.xmlpull.v1.XmlSerializer;

import java.io.IOException;
import java.util.ArrayList;

interface IValidatableFF {
    ValidateResult Validate();
}

//
// Created by Eugene Leonov with the help of God on 14.05.2015. :))
//
public class FFModel implements Parcelable, IValidatableFF
{
    public ArrayList<FFTemplateElement> Elements;
    public SimpleArrayMap <String, ActivityParameter> ActivityParameters;

    private long idfsFormType;
    private long idfObservation;
    private long idfsTemplate;
    private FFModel()
    {
    }

    public long GetObservation(){
        return idfObservation;
    }

    public void SetObservation(long idObservation){
        idfObservation = idObservation;
        for(int i = 0; i < ActivityParameters.size(); i++) {
            ActivityParameter ap = ActivityParameters.valueAt(i);
            ap.idfObservation = idfObservation;
        }
    }

    public ActivityParameter GetActivityParameter(final long idParameter, final long idRow){
        ActivityParameter result;
        String key = ActivityParameter.GetKey(idfObservation, idParameter, idRow);
        if (ActivityParameters.containsKey(key)){
            result = ActivityParameters.get(key);
        }
        else{
            result = new ActivityParameter();
            result.idfObservation = idfObservation;
            result.idfsParameter = idParameter;
            result.idfRow = idRow;
            ActivityParameters.put(result.GetKey(), result);
        }
        return result;
    }

    public ActivityParameter GetActivityParameter(final int index) {
        return ActivityParameters.valueAt(index);
    }

    public ActivityParameter GetActivityParameterByDialog(final int idDialog){
        ActivityParameter result = null;
        for(int i = 0; i < ActivityParameters.size(); i++) {
            ActivityParameter ap = ActivityParameters.valueAt(i);
            if (ap.idDialog == idDialog) {
                result = ap;
                break;
            }
        }
        return result;
    }

    public static FFModel CreateNew(long idObservation, long idFormType){
        FFModel ret = new FFModel();
        ret.Init(idObservation, idFormType);
        return ret;
    }

    private void Init(long idObservation, long idFormType){
        idfObservation = idObservation;
        idfsFormType = idFormType;
        Elements = new ArrayList<>();
        ActivityParameters = new SimpleArrayMap<>();
    }

    public static FFModel CreateNew(Parcel parcel){
        FFModel ret = CreateNew(0, 0); //will be filled in FromParcel method
        ret.FromParcel(parcel);
        return ret;
    }

    public ArrayList<ContentValues> GetActivityParametersContentValues(){
        ArrayList<ContentValues> ret = new ArrayList<>();
        for(int i = 0; i < ActivityParameters.size(); i++) {
            ActivityParameter ap = ActivityParameters.valueAt(i);
            if (ap.Value == null)
                continue;
            ret.add(ap.ContentValues());
        }
        return ret;
    }

    private FFTemplateElement GetElement(long id){
        FFTemplateElement result = null;
        for(int i = 0; i < Elements.size(); i++) {
            FFTemplateElement el = Elements.get(i);
            if (el.idfsBaseReference == id) {
                result = el;
                break;
            }
        }
        return result;
    }

    public String GetActivityParameterSummary(){
        String result = "";
        for(int i = 0; i < ActivityParameters.size(); i++) {
            ActivityParameter ap = ActivityParameters.valueAt(i);
            if (ap.Value == null || ap.Value.isEmpty() || ap.Value.equals("0")) continue;
            FFTemplateElement element = GetElement(ap.idfsParameter);
            if (element == null) continue;
            String caption = EidssDatabase.FFGetText(element.idfsParameterCaption);
            if (caption.isEmpty()) continue;
            if (!result.isEmpty()) result += ", ";
            result += caption;
        }
        return result;
    }

    public Boolean getChanged(){
        for(int i = 0; i < ActivityParameters.size(); i++) {
            ActivityParameter ap = ActivityParameters.valueAt(i);
            if (ap.getChanged()) return true;
        }
        return false;
    }

    public long getTemplate(){return idfsTemplate;}

    public long LoadTemplate(EidssDatabase db, long idDeterminant){
        idfsTemplate = 0;
        Elements.clear();
        Elements = db.FFTemplateElementsSelect(idDeterminant, idfsFormType);
        if (Elements.size() > 0) {
            FFTemplateElement te = Elements.get(0);
            if (te != null) idfsTemplate = te.idfsFormTemplate;
        }
        return idfsTemplate;
    }



    public static final Parcelable.Creator<FFModel> CREATOR = new Parcelable.Creator<FFModel>()
    {
        public FFModel createFromParcel(Parcel in) {
            return new FFModel(in);
        }

        public FFModel[] newArray(int size) {
            return new FFModel[size];
        }
    };

    public FFModel(Parcel source) {
        Init(0, 0);
        FromParcel(source);
    }

    @Override
    public int describeContents() {
        return 0;
    } //4?

    @Override
    public void writeToParcel(Parcel dest, int flag) {ToParcel(dest);}

    @Override
    public ValidateResult Validate() {
        for(int i = 0; i < ActivityParameters.size(); i++) {
            ActivityParameter ap = ActivityParameters.valueAt(i);
            FFTemplateElement element = GetElement(ap.idfsParameter);

            if (element != null && element.intMandatory == 1){
                if (ap.Value == null || ap.Value.isEmpty())// || ap.Value.equals("0")
                    return new ValidateResult(ValidateCode.FieldMandatoryStr, EidssDatabase.FFGetText(element.idfsParameterCaption));
            }
        }

        return new ValidateResult(ValidateCode.OK);
    }

    protected void ToParcel(Parcel dest)
    {
        dest.writeLong(idfObservation);
        dest.writeLong(idfsFormType);
        dest.writeTypedList(Elements);
        ArrayList<ActivityParameter> apList = new ArrayList<>();
        for(int i = 0; i < ActivityParameters.size(); i++) {
            ActivityParameter ap = ActivityParameters.valueAt(i);
            if (ap.Value == null)
                continue;
            apList.add(ap);
        }
        dest.writeTypedList(apList);
    }

    protected void FromParcel(Parcel source)
    {
        idfObservation = source.readLong();
        idfsFormType = source.readLong();
        source.readTypedList(Elements, FFTemplateElement.CREATOR);
        ArrayList<ActivityParameter> apList = new ArrayList<>();
        source.readTypedList(apList, ActivityParameter.CREATOR);
        for(int i = 0; i < apList.size(); i++) {
            ActivityParameter apl = apList.get(i);
            String key = apl.GetKey();
            ActivityParameters.put(key, apl);
        }
    }

    protected void ToXml(XmlSerializer serializer) throws IllegalArgumentException, IllegalStateException, IOException {
        serializer.startTag("", "ffmodel");
        serializer.attribute("", "idfObservation", String.valueOf(idfObservation));
        serializer.attribute("", "idfsFormType", String.valueOf(idfsFormType));
        serializer.startTag("", "activityparameters");
        for (int i = 0; i < ActivityParameters.size(); i++){
            ActivityParameter ap = ActivityParameters.valueAt(i);
            if (ap.Value == null)
                continue;
            ap.ToXml(serializer);
        }
        serializer.endTag("", "activityparameters");
        serializer.endTag("", "ffmodel");
    }

    public JSONObject ToJson() throws JSONException {
        JSONObject ret = new JSONObject();
        EidssUtils.putToJson(ret, "idfObservation", idfObservation);
        EidssUtils.putToJson(ret, "idfsFormType", idfsFormType);
        JSONArray list = new JSONArray();
        for (int i = 0; i < ActivityParameters.size(); i++) {
            ActivityParameter ap = ActivityParameters.valueAt(i);
            if (ap.Value == null)
                continue;
            list.put(ap.ToJson());
        }
        ret.put("parameters", list);
        return ret;
    }
}