package com.bv.eidss.model;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.os.Parcel;
import android.os.Parcelable;

import com.bv.eidss.ReferenciesProvider;
import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.generated.ASSample_object;
import com.bv.eidss.model.interfaces.FieldMetadata;
import com.bv.eidss.model.interfaces.IValidatable;
import com.bv.eidss.model.interfaces.ValidateCode;
import com.bv.eidss.model.interfaces.ValidateResult;
import com.bv.eidss.utils.EidssUtils;

import org.json.JSONException;
import org.json.JSONObject;
import org.xmlpull.v1.XmlSerializer;

import java.io.IOException;
import java.util.Iterator;
import java.util.List;
import java.util.UUID;

public class ASSample
        extends ASSample_object
        implements Parcelable, IValidatable {

    private boolean _bChecked;
    public boolean isChecked()  { return _bChecked; }
    public void setChecked(boolean value) { _bChecked = value; }

    public Boolean getChanged() {
        return bChanged;
    }

    public Boolean isEmpty() {
        Iterator itr = fieldMetadata.iterator();
        while(itr.hasNext()) {
            FieldMetadata meta = (FieldMetadata)itr.next();
            if (meta.getName().compareTo(eidss_Animal) == 0){
                if (getAnimalCode() != null && getAnimalCode().trim().length() > 0){
                    //return false;
                }
            } else if(meta.NotEmpty(this)) {
                return false;
            }
        }
        return true;
    }

    public void setUnchanged() { bChanged = false; }

    private ASSample()
    {
        bChanged = false;
    }

    public ASSample(ASSample_object other, ASSession session)
    {
        this.setMonitoringSession(session.getMonitoringSession());
        this.setParent(session.getId());
        bChanged = true;
    }

    public static ASSample CreateNew(long idfMonitoringSession, long parentId)
    {
        ASSample ret = new ASSample();
        ret.setMonitoringSession(idfMonitoringSession);
        ret.setParent(parentId);
        return ret;
    }

    public static ASSample CreateNew(Context context, ASSession session)
    {
        ASSample ret = new ASSample();
        ret._uidOfflineCaseID = UUID.randomUUID().toString();
        ret.setMonitoringSession(session.getMonitoringSession());
        ret.setParent(session.getId());

        ret.SetNewDefault(context, session);

        if (session.farms.size() == 1){
            Farm f = session.farms.get(0);
            ret.setFarm(f.getFarm());
            if (f.species.size() == 1){
                Species sp = f.species.get(0);
                ret.setSpeciesType(sp.getSpeciesType());
            }
        }

        return ret;
    }

    public void SetNewDefault(Context context, ASSession session){
        session.countNewAnimal++;
        EidssDatabase db = new EidssDatabase(context);
        long lNewAnimalCount = db.NewAnimalCount() + session.countNewAnimal;
        setAnimal(-lNewAnimalCount);
        setAnimalCode("(new animal " + String.valueOf(lNewAnimalCount) + ")");
        setMaterial(-1);
    }


	@Override
	public ValidateResult Validate(List<String> mandatoryFields, List<String> invisibleFields) {
        Iterator itr = fieldMetadata.iterator();
        while(itr.hasNext()) {
            FieldMetadata meta = (FieldMetadata)itr.next();
            if (!meta.CheckMandatory(this, mandatoryFields, invisibleFields)){
                return new ValidateResult(ValidateCode.FieldMandatory, meta.getTitle());
            }

            if (meta.getName().compareTo(eidss_Animal) == 0){
                if (getAnimalCode() == null || getAnimalCode().trim().length() == 0){
                    return new ValidateResult(ValidateCode.FieldMandatory, meta.getTitle());
                }
            }
        }
/*
        if (getStartOfSignsDate() != null && getStartOfSignsDate().after(DateHelpers.Today()))
        	return new ValidateResult(ValidateCode.DateOfStartOfSignsCheckCurrent);
        if (_intTotalAnimalQty < _intDeadAnimalQty + _intSickAnimalQty)
        	return new ValidateResult(ValidateCode.SpeciesTotalLessDeadSick);
*/

		return new ValidateResult(ValidateCode.OK);
	}

    private ASSample(Parcel source) {
        FromParcel(source);
    }

    public static final Creator<ASSample> CREATOR =
            new Creator<ASSample>() {

                @Override
                public ASSample createFromParcel(Parcel source) {
                    return new ASSample(source);
                }

                @Override
                public ASSample[] newArray(int size) {
                    return new ASSample[size];
                }
            };

    
    @Override
	public int describeContents() {
        return 0;
	}
	@Override
	public void writeToParcel(Parcel dest, int flag) {
        ToParcel(dest, flag);
	}

    public void ToXml(XmlSerializer serializer) throws IllegalArgumentException, IllegalStateException, IOException{
        serializer.startTag("", "assample");
        super.ToXml(serializer);
        serializer.endTag("", "assample");
    }

    public static ASSample FromCursor(Cursor cursor)
    {
        ASSample ret = new ASSample();
        ret.bChanged = false;
        if (FromCursor(cursor, ret) == null) return null;
        return ret;
    }

    public ContentValues ContentValues()
    {
        return ContentValuesInternal();
    }

    public JSONObject ToJson() throws JSONException {
        JSONObject ret = super.ToJson();
        return ret;
    }

    public void SetFromAnother(ASSample_object source){
        setFarm(source.getFarm());
        setSpeciesType(source.getSpeciesType());
        setAnimalAge(source.getAnimalAge());
        setAnimalCode(source.getAnimalCode());
        setAnimalGender(source.getAnimalGender());
        setColor(source.getColor());
        setDescription(source.getDescription());
        setFieldBarcode(source.getFieldBarcode());
        setName(source.getName());
        setSampleType(source.getSampleType());
        setFieldCollectionDate(source.getFieldCollectionDate());
        setSendToOffice(source.getSendToOffice());
    }

    public void SetForCopy(ASSample_object source){
        setFarm(source.getFarm());
        setSpeciesType(source.getSpeciesType());
        setAnimalAge(source.getAnimalAge());
        setAnimalGender(source.getAnimalGender());
        setSampleType(source.getSampleType());
        setFieldCollectionDate(source.getFieldCollectionDate());
        setSendToOffice(source.getSendToOffice());
    }


    public String GetName(final Context context){
        return getAnimalCode();
    }

    public String GetSummary(final Context context){
        String result = EidssUtils.getStringFromDB(context, ReferenciesProvider.CONTENT_URI, getSpeciesType());
        String result1 = EidssUtils.getStringFromDB(context, ReferenciesProvider.CONTENT_URI, getSampleType());
        String result2 = getFieldBarcode();
        if (result2 == null)
            result2 = "";
        if (!result.isEmpty() && !result1.isEmpty()) result += " - ";
        result += result1;
        if (!result.isEmpty() && !result2.isEmpty()) result += " - ";
        return result + result2;
    }
}
