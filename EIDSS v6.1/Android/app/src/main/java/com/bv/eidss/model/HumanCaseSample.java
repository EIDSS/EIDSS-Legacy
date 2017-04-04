package com.bv.eidss.model;

import android.content.ContentValues;
import android.database.Cursor;
import android.os.Parcel;
import android.os.Parcelable;

import com.bv.eidss.model.generated.Animal_object;
import com.bv.eidss.model.generated.HumanCaseSample_object;
import com.bv.eidss.model.interfaces.FieldMetadata;
import com.bv.eidss.model.interfaces.IValidatable;
import com.bv.eidss.model.interfaces.ValidateCode;
import com.bv.eidss.model.interfaces.ValidateResult;
import com.bv.eidss.utils.DateHelpers;

import org.json.JSONException;
import org.json.JSONObject;
import org.xmlpull.v1.XmlSerializer;

import java.io.IOException;
import java.util.Iterator;
import java.util.List;
import java.util.UUID;

public class HumanCaseSample
        extends HumanCaseSample_object
        implements Parcelable, IValidatable {

    private boolean _bChecked;
    public boolean isChecked()  { return _bChecked; }
    public void setChecked(boolean value) { _bChecked = value; }

    public Boolean getChanged() {
        return bChanged; }

    public void setUnchanged() { bChanged = false; }

    private HumanCaseSample()
    {
        bChanged = false;
    }

    public static HumanCaseSample CreateNew(long caseId)
    {
    	HumanCaseSample ret = new HumanCaseSample();
        ret._uidOfflineCaseID = UUID.randomUUID().toString();
        ret.setParent(caseId);
        return ret;
    }

    public void SetFromAnother(HumanCaseSample_object sp)
    {
        setMaterial(sp.getMaterial());
        setSampleType(sp.getSampleType());
        setFieldBarcode(sp.getFieldBarcode());
        setFieldCollectionDate(sp.getFieldCollectionDate());
        setSendToOffice(sp.getSendToOffice());
        setFieldSentDate(sp.getFieldSentDate());
    }

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


	@Override
	public ValidateResult Validate(List<String> mandatoryFields, List<String> invisibleFields) {
        for (FieldMetadata meta : fieldMetadata) {
            if (!meta.CheckMandatory(this, mandatoryFields, invisibleFields)) {
                return new ValidateResult(ValidateCode.FieldMandatory, meta.getTitle());
            }
        }

        if (getFieldCollectionDate() != null && getFieldCollectionDate().after(DateHelpers.Today()))
            return new ValidateResult(ValidateCode.DateFieldCollectionCheckCurrent);
        if (getFieldCollectionDate() != null && getFieldSentDate() != null && getFieldCollectionDate().after(getFieldSentDate()))
            return new ValidateResult(ValidateCode.DateFieldCollectionCheckSentDate);

		return new ValidateResult(ValidateCode.OK);
	}

    private HumanCaseSample(Parcel source) {
        FromParcel(source);
    }

    public static final Creator<HumanCaseSample> CREATOR =
            new Creator<HumanCaseSample>() {

                @Override
                public HumanCaseSample createFromParcel(Parcel source) {
                    return new HumanCaseSample(source);
                }

                @Override
                public HumanCaseSample[] newArray(int size) {
                    return new HumanCaseSample[size];
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

    public static HumanCaseSample FromCursor(Cursor cursor)
    {
        HumanCaseSample ret = new HumanCaseSample();
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

}
