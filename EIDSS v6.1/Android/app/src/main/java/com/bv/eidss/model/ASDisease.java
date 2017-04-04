package com.bv.eidss.model;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.os.Parcel;
import android.os.Parcelable;

import com.bv.eidss.ReferenciesProvider;
import com.bv.eidss.model.generated.ASDisease_object;
import com.bv.eidss.model.interfaces.FieldMetadata;
import com.bv.eidss.model.interfaces.IValidatable;
import com.bv.eidss.model.interfaces.ValidateCode;
import com.bv.eidss.model.interfaces.ValidateResult;
import com.bv.eidss.utils.DateHelpers;
import com.bv.eidss.utils.EidssUtils;

import org.json.JSONException;
import org.json.JSONObject;
import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xmlpull.v1.XmlSerializer;

import java.io.IOException;
import java.text.ParseException;
import java.util.Iterator;
import java.util.List;
import java.util.UUID;

public class ASDisease
        extends ASDisease_object
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
            if(meta.NotEmpty(this))
                return false;
        }
        return true;
    }

    public void setUnchanged() { bChanged = false; }

    private ASDisease()
    {
        bChanged = false;
        _uidOfflineCaseID = UUID.randomUUID().toString();
    }

    public ASDisease(ASDisease_object other, ASSession session)
    {
        this.setDiagnosis(other.getDiagnosis());
        this.setSpeciesType(other.getSpeciesType());
        this.setSampleType(other.getSampleType());
        this.setMonitoringSession(session.getMonitoringSession());
        this.setParent(session.getId());
        bChanged = true;
    }

    public static ASDisease CreateNew(long idfMonitoringSession, long idParent)
    {
        ASDisease ret = new ASDisease();
        ret.setMonitoringSession(idfMonitoringSession);
        ret.setParent(idParent);
        return ret;
    }

    public static ASDisease CreateNewFromCampaign(long idfCampaign)
    {
        ASDisease ret = new ASDisease();
        ret.setCampaign(idfCampaign);
        return ret;
    }


    public void FromAttr(Attributes attributes) throws SAXException, ParseException
    {
        _idfMonitoringSession = Long.parseLong(attributes.getValue("idfMonitoringSession"));
        _idfCampaign = Long.parseLong(attributes.getValue("idfCampaign"));
        _idfsDiagnosis = Long.parseLong(attributes.getValue("idfsDiagnosis"));
        _idfsSpeciesType = Long.parseLong(attributes.getValue("idfsSpeciesType"));
        _idfsSampleType = Long.parseLong(attributes.getValue("idfsSampleType"));
    }

    public static ASDisease CreateFromAttr(Attributes attributes) throws SAXException, ParseException
    {
        ASDisease ret = new ASDisease();
        ret.FromAttr(attributes);
        return ret;
    }


	@Override
	public ValidateResult Validate(List<String> mandatoryFields, List<String> invisibleFields) {
        Iterator itr = fieldMetadata.iterator();
        while(itr.hasNext()) {
            FieldMetadata meta = (FieldMetadata)itr.next();
            if (!meta.CheckMandatory(this, mandatoryFields, invisibleFields)){
                return new ValidateResult(ValidateCode.FieldMandatory, meta.getTitle());
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

    protected String _uidOfflineCaseID;
    public String getOfflineCaseID(){return _uidOfflineCaseID;}

    private ASDisease(Parcel source) {
        FromParcel(source);
        _uidOfflineCaseID = source.readString();
    }

    public static final Creator<ASDisease> CREATOR =
            new Creator<ASDisease>() {

                @Override
                public ASDisease createFromParcel(Parcel source) {
                    return new ASDisease(source);
                }

                @Override
                public ASDisease[] newArray(int size) {
                    return new ASDisease[size];
                }
            };

    
    @Override
	public int describeContents() {
        return 0;
	}
	@Override
	public void writeToParcel(Parcel dest, int flag) {
        ToParcel(dest, flag);
        if (_uidOfflineCaseID == null || _uidOfflineCaseID.length() == 0){
            _uidOfflineCaseID = UUID.randomUUID().toString();
        }
        dest.writeString(_uidOfflineCaseID);
	}

    public void ToXml(XmlSerializer serializer) throws IllegalArgumentException, IllegalStateException, IOException{
        serializer.startTag("", "asdisease");
        super.ToXml(serializer);
        serializer.endTag("", "asdisease");
    }

    public static ASDisease FromCursor(Cursor cursor)
    {
        ASDisease ret = new ASDisease();
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

    public String GetSummary(final Context context){
        String result = EidssUtils.getStringFromDB(context, ReferenciesProvider.CONTENT_URI, getDiagnosis()) + "";
        String result1 = EidssUtils.getStringFromDB(context, ReferenciesProvider.CONTENT_URI, getSpeciesType()) + "";
        String result2 = EidssUtils.getStringFromDB(context, ReferenciesProvider.CONTENT_URI, getSampleType()) + "";
        if (!result.isEmpty() && !result1.isEmpty()) result += " / ";
        result += result1;
        if (!result.isEmpty() && !result2.isEmpty()) result += " / ";
        return result + result2;
    }
}
