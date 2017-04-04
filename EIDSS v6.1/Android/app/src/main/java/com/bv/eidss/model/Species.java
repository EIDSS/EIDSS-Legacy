package com.bv.eidss.model;

import java.io.IOException;
import java.util.List;

import org.json.JSONException;
import org.json.JSONObject;
import org.xmlpull.v1.XmlSerializer;

import com.bv.eidss.R;
import com.bv.eidss.ReferenciesProvider;
import com.bv.eidss.model.generated.Species_object;
import com.bv.eidss.model.interfaces.FieldMetadata;
import com.bv.eidss.model.interfaces.IValidatable;
import com.bv.eidss.model.interfaces.ValidateCode;
import com.bv.eidss.model.interfaces.ValidateResult;
import com.bv.eidss.utils.DateHelpers;
import com.bv.eidss.utils.EidssUtils;

import android.content.ContentValues;
import android.content.Context;
import android.content.res.Resources;
import android.database.Cursor;
import android.os.Parcel;
import android.os.Parcelable;

public class Species
        extends Species_object
        implements Parcelable, IValidatable {

    private boolean _bChecked;
    public boolean isChecked()  { return _bChecked; }
    public void setChecked(boolean value) { _bChecked = value; }

    public Boolean getChanged() {
        if (!bChanged)  bChanged = FFPresenterCs != null ? FFPresenterCs.getChanged() : false;
        return bChanged; }

    public void setUnchanged() { bChanged = false; }

    public Boolean isEmpty() {
        for (FieldMetadata meta : fieldMetadata) {
            if (meta.getName().equalsIgnoreCase(eidss_StartOfSignsDate)) {
                if (meta.NotEmpty(this) && !_datStartOfSignsDate.equals(DateHelpers.Today()))
                    return false;
            } else {
                if (meta.NotEmpty(this))
                    return false;
            }
        }
        return true;
    }

    public FFModel FFPresenterCs;

    private void InitFF(Boolean isLivestock){
        FFPresenterCs = FFModel.CreateNew(getObservation(),isLivestock ? FFTypesEnum.LivestockSpeciesCS : FFTypesEnum.AvianSpeciesCS);//0 for a new case
    }

    private Species()
    {
        InitFF(true);
        bChanged = false;
    }

    public static Species CreateNew(long caseId, Boolean isLivestock)
    {
    	Species ret = new Species();
        ret.setParent(caseId);
        ret.InitFF(isLivestock);
        return ret;
    }

    public void SetFromAnother(Species_object sp)
    {
        //setHerd(sp.getHerd());
        setSpeciesType(sp.getSpeciesType());
        setDeadAnimalQty(sp.getDeadAnimalQty());
        setSickAnimalQty(sp.getSickAnimalQty());
        setTotalAnimalQty(sp.getTotalAnimalQty());
        setNote(sp.getNote());
        setAverageAge(sp.getAverageAge());
        setStartOfSignsDate(sp.getStartOfSignsDate());
        setObservation(sp.getObservation());
        FFPresenterCs.SetObservation(getObservation());
    }

	@Override
	public ValidateResult Validate(List<String> mandatoryFields, List<String> invisibleFields) {
        for (FieldMetadata meta : fieldMetadata) {
            if (!meta.CheckMandatory(this, mandatoryFields, invisibleFields)) {
                return new ValidateResult(ValidateCode.FieldMandatory, meta.getTitle());
            }
        }

        if (getStartOfSignsDate() != null && getStartOfSignsDate().after(DateHelpers.Today()))
        	return new ValidateResult(ValidateCode.DateOfStartOfSignsCheckCurrent);
        if (_intTotalAnimalQty < _intDeadAnimalQty + _intSickAnimalQty)
        	return new ValidateResult(ValidateCode.SpeciesTotalLessDeadSick);

        if (FFPresenterCs != null) {
            ValidateResult vr = FFPresenterCs.Validate();
            if (vr.getCode() != ValidateCode.OK)
                return vr;
        }

		return new ValidateResult(ValidateCode.OK);
	}

    private Species(Parcel source) {
        FromParcel(source);
        FFPresenterCs = FFModel.CreateNew(source);
    }
	
    public static final Parcelable.Creator<Species> CREATOR = 
            new Parcelable.Creator<Species>() {

                @Override
                public Species createFromParcel(Parcel source) {
                    return new Species(source);
                }

                @Override
                public Species[] newArray(int size) {
                    return new Species[size];
                }
            };

    
    @Override
	public int describeContents() {
        return 0;
	}
	@Override
	public void writeToParcel(Parcel dest, int flag) {
        ToParcel(dest, flag);
        if (FFPresenterCs != null) FFPresenterCs.writeToParcel(dest, flag);
	}

    public void ToXml(XmlSerializer serializer) throws IllegalArgumentException, IllegalStateException, IOException{
        serializer.startTag("", "kind");
        super.ToXml(serializer);
        FFPresenterCs.ToXml(serializer);
        serializer.endTag("", "kind");
    }

    public static Species FromCursor(Cursor cursor)
    {
        Species ret = new Species();
        ret.bChanged = false;
        if (FromCursor(cursor, ret) == null) return null;
        ret.FFPresenterCs.SetObservation(ret.getObservation());
        return ret;
    }

    public ContentValues ContentValues()
    {
        return ContentValuesInternal();
    }

    public JSONObject ToJson() throws JSONException {
        JSONObject ret = super.ToJson();
        ret.put("FFPresenterCs", FFPresenterCs.ToJson());
        return ret;
    }

    public String GetName(final Context context){
        return EidssUtils.getStringFromDB(context, ReferenciesProvider.CONTENT_URI, getSpeciesType()) + "";
    }

    public String GetSummary(final Resources res){
        String result = String.format("%s: %d", res.getString(R.string.Total), getTotalAnimalQty());
        return result;
    }
}
