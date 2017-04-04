package com.bv.eidss.model;

import android.content.ContentValues;
import android.database.Cursor;
import android.os.Parcel;
import android.os.Parcelable;

import com.bv.eidss.model.generated.VetCaseSample_object;
import com.bv.eidss.model.interfaces.FieldMetadata;
import com.bv.eidss.model.interfaces.IValidatable;
import com.bv.eidss.model.interfaces.ValidateCode;
import com.bv.eidss.model.interfaces.ValidateResult;
import com.bv.eidss.utils.DateHelpers;

import org.json.JSONException;
import org.json.JSONObject;
import org.xmlpull.v1.XmlSerializer;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

public class VetCaseSample
        extends VetCaseSample_object
        implements Parcelable, IValidatable {

    private boolean _bChecked;
    public boolean isChecked()  { return _bChecked; }
    public void setChecked(boolean value) { _bChecked = value; }

    private VetCaseSample()
    {
        bChanged = false;
    }

    public static VetCaseSample CreateNew(long caseId)
    {
    	VetCaseSample ret = new VetCaseSample();
        ret._uidOfflineCaseID = UUID.randomUUID().toString();
        ret.setParent(caseId);
        return ret;
    }

    public void SetFromAnother(VetCaseSample_object sp)
    {
        setMaterial(sp.getMaterial());
        setSampleType(sp.getSampleType());
        setFieldBarcode(sp.getFieldBarcode());
        setSpeciesType(sp.getSpeciesType());
        setAnimal(sp.getAnimal());
        setBirdStatus(sp.getBirdStatus());
        setFieldCollectionDate(sp.getFieldCollectionDate());
        setSendToOffice(sp.getSendToOffice());
    }

    public Boolean getChanged() {
        return bChanged; }

    public void setUnchanged() { bChanged = false; }


    public Boolean isEmpty() {
        for (FieldMetadata meta : fieldMetadata) {
            if (meta.getName().equalsIgnoreCase(eidss_FieldCollectionDate)) {
                if (meta.NotEmpty(this) && !_datFieldCollectionDate.equals(DateHelpers.Today()))
                    return false;
            } else {
                if (meta.NotEmpty(this))
                    return false;
            }
        }
        return true;
    }

    public ValidateResult Validate(boolean isLivestock, List<String> mandatoryFields, List<String> invisibleFields) {
        ArrayList<String> mandatoryFieldsActual = new ArrayList<>(mandatoryFields);

        if (isLivestock)
            mandatoryFieldsActual.add(eidss_Animal);
        else
            mandatoryFieldsActual.add(eidss_SpeciesType);

        for (FieldMetadata meta : fieldMetadata) {
            if (!meta.CheckMandatory(this, mandatoryFieldsActual, invisibleFields)) {
                return new ValidateResult(ValidateCode.FieldMandatory, meta.getTitle());
            }
        }

        if (getFieldCollectionDate() != null && getFieldCollectionDate().after(DateHelpers.Today()))
            return new ValidateResult(ValidateCode.DateFieldCollectionCheckCurrent);

        return new ValidateResult(ValidateCode.OK);
    }

	@Override
	public ValidateResult Validate(List<String> mandatoryFields, List<String> invisibleFields) {
        for (FieldMetadata meta : fieldMetadata) {
            if (!meta.CheckMandatory(this, mandatoryFields, invisibleFields)) {
                return new ValidateResult(ValidateCode.FieldMandatory, meta.getTitle());
            }
        }

        if (getFieldCollectionDate() != null && getFieldCollectionDate().after(DateHelpers.Today()))
        	return new ValidateResult(ValidateCode.DateFieldCollectionCheckCurrent);

		return new ValidateResult(ValidateCode.OK);
	}

    private VetCaseSample(Parcel source) {
        FromParcel(source);
    }

    public static final Creator<VetCaseSample> CREATOR =
            new Creator<VetCaseSample>() {

                @Override
                public VetCaseSample createFromParcel(Parcel source) {
                    return new VetCaseSample(source);
                }

                @Override
                public VetCaseSample[] newArray(int size) {
                    return new VetCaseSample[size];
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
        serializer.startTag("", "sample");
        super.ToXml(serializer);
        serializer.endTag("", "sample");
    }

    public static VetCaseSample FromCursor(Cursor cursor)
    {
        VetCaseSample ret = new VetCaseSample();
        ret.bChanged = false;
        if (FromCursor(cursor, ret) == null) return null;
        return ret;
    }

    // for Livestock in detail dialog we choose only animal (name of SpeciesType get from animal name) - so now set SpeciesType
    public void setSpeciesTypeFromAnimal(VetCase cs)
    {
        if (cs.IsLivestockCase())
            for (Animal an: cs.animals){
                if(an.getAnimal() == getAnimal()){
                    setSpeciesType(an.getSpeciesType());
                    break;
                }
            }
    }

    public ContentValues ContentValues()
    {
        return ContentValuesInternal();
    }

    public JSONObject ToJson() throws JSONException {
        JSONObject ret = super.ToJson();
        return ret;
    }

}
