package com.bv.eidss.model;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.os.Parcel;
import android.os.Parcelable;

import com.bv.eidss.ReferenciesProvider;
import com.bv.eidss.model.generated.Animal_object;
import com.bv.eidss.model.interfaces.FieldMetadata;
import com.bv.eidss.model.interfaces.IValidatable;
import com.bv.eidss.model.interfaces.ValidateCode;
import com.bv.eidss.model.interfaces.ValidateResult;
import com.bv.eidss.utils.EidssUtils;

import org.json.JSONException;
import org.json.JSONObject;
import org.xmlpull.v1.XmlSerializer;

import java.io.IOException;
import java.util.List;
import java.util.UUID;

public class Animal
        extends Animal_object
        implements Parcelable, IValidatable {

    private boolean _bChecked;
    public boolean isChecked()  { return _bChecked; }
    public void setChecked(boolean value) { _bChecked = value; }

    public static final String def = "(new animal ";

    public Boolean getChanged() {
        if (!bChanged)  bChanged = FFPresenterCs != null ? FFPresenterCs.getChanged() : false;
        return bChanged; }

    public Boolean isEmpty() {
        for (FieldMetadata meta : fieldMetadata) {
            if (meta.getName().equalsIgnoreCase(eidss_AnimalCode)) {
                if (meta.NotEmpty(this) && !_strAnimalCode.startsWith(def))
                    return false;
            } else {
                if (meta.NotEmpty(this))
                    return false;
            }
        }
        return true;
    }

    public void setUnchanged() { bChanged = false; }

    public FFModel FFPresenterCs;

    private void InitFF(){
        FFPresenterCs = FFModel.CreateNew(getObservation(),FFTypesEnum.LivestockAnimalCS);
    }

    private Animal()
    {
        InitFF();
        bChanged = false;
    }

    public static Animal CreateNew(long caseId)
    {
        Animal ret = new Animal();
        ret._uidOfflineCaseID = UUID.randomUUID().toString();
        ret.setParent(caseId);
        return ret;
    }
    public static Animal CreateNew(long caseId, int num, long animalID)
    {
        Animal ret = new Animal();
        ret._uidOfflineCaseID = UUID.randomUUID().toString();
        ret.setAnimalCode(def + num + ")");
        ret.setParent(caseId);
        ret.setAnimal(animalID);
        return ret;
    }

    public void SetFromAnother(Animal_object sp)
    {
        setHerd(sp.getHerd());
        setAnimal(sp.getAnimal());
        setSpeciesType(sp.getSpeciesType());
        setAnimalCode(sp.getAnimalCode());
        setAnimalAge(sp.getAnimalAge());
        setAnimalCondition(sp.getAnimalCondition());
        setAnimalGender(sp.getAnimalGender());

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
/*
        if (getStartOfSignsDate() != null && getStartOfSignsDate().after(DateHelpers.Today()))
        	return new ValidateResult(ValidateCode.DateOfStartOfSignsCheckCurrent);
        if (_intTotalAnimalQty < _intDeadAnimalQty + _intSickAnimalQty)
        	return new ValidateResult(ValidateCode.SpeciesTotalLessDeadSick);
*/
        if (FFPresenterCs != null) {
            ValidateResult vr = FFPresenterCs.Validate();
            if (vr.getCode() != ValidateCode.OK)
                return vr;
        }

		return new ValidateResult(ValidateCode.OK);
	}

    private Animal(Parcel source) {
        FromParcel(source);
        FFPresenterCs = FFModel.CreateNew(source);
    }

    public static final Creator<Animal> CREATOR =
            new Creator<Animal>() {

                @Override
                public Animal createFromParcel(Parcel source) {
                    return new Animal(source);
                }

                @Override
                public Animal[] newArray(int size) {
                    return new Animal[size];
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
        serializer.startTag("", "animal");
        super.ToXml(serializer);
        FFPresenterCs.ToXml(serializer);
        serializer.endTag("", "animal");
    }

    public static Animal FromCursor(Cursor cursor)
    {
        Animal ret = new Animal();
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

    public String GetSummary(final Context context){
        String result = EidssUtils.getStringFromDB(context, ReferenciesProvider.CONTENT_URI, getSpeciesType()) + "";
        String result1 = EidssUtils.getStringFromDB(context, ReferenciesProvider.CONTENT_URI, getAnimalAge()) + "";
        String result2 = EidssUtils.getStringFromDB(context, ReferenciesProvider.CONTENT_URI, getAnimalCondition()) + "";
        if (!result.isEmpty() && !result1.isEmpty()) result += ", ";
        result += result1;
        if (!result.isEmpty() && !result2.isEmpty()) result += ", ";
        return result + result2;
    }

    public String GetNameForSample(final Context context){
        String result = EidssUtils.getStringFromDB(context, ReferenciesProvider.CONTENT_URI, getSpeciesType()) + "";
        if (!result.isEmpty() && !getAnimalCode().isEmpty()) result += "/";
        result += getAnimalCode();
        return result;
    }
}
