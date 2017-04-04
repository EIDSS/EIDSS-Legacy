package com.bv.eidss.model;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.os.Parcel;
import android.os.Parcelable;

import com.bv.eidss.R;
import com.bv.eidss.RayonsProvider;
import com.bv.eidss.ReferenciesProvider;
import com.bv.eidss.RegionsProvider;
import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.data.EidssDatabaseFarm;
import com.bv.eidss.model.generated.Farm_object;
import com.bv.eidss.model.interfaces.FieldMetadata;
import com.bv.eidss.model.interfaces.ISpeciesParent;
import com.bv.eidss.model.interfaces.IValidatable;
import com.bv.eidss.model.interfaces.ValidateCode;
import com.bv.eidss.model.interfaces.ValidateResult;
import com.bv.eidss.utils.DateHelpers;
import com.bv.eidss.utils.EidssUtils;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;
import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xmlpull.v1.XmlSerializer;

import java.io.IOException;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.UUID;

public class Farm
        extends Farm_object
        implements Parcelable, IValidatable, ISpeciesParent {

    public List<Species> species;

    private boolean _bChecked;
    public boolean isChecked()  { return _bChecked; }
    public void setChecked(boolean value) { _bChecked = value; }

    public Boolean getChanged() {
        for(Species s:species)
            bChanged = bChanged || s.getChanged();
        return bChanged;
    }

    public Boolean isEmpty(Context context, ASSession session) {
        Iterator itr = fieldMetadata.iterator();
        while(itr.hasNext()) {
            FieldMetadata meta = (FieldMetadata)itr.next();
            if (meta.getName().compareTo(eidss_RootFarm) == 0) {
                if (!(getFarmName() != null && getFarmName().trim().compareTo(context.getResources().getString(R.string.NewFarm)) == 0)) {
                    return false;
                }
            } else if (meta.getName().compareTo(eidss_Region) == 0){
                if (!(getRegion() == (session.getRegion() == 0 ? EidssDatabase.GetOptions().getRegionDef() : session.getRegion()))){
                    return false;
                }
            } else if (meta.getName().compareTo(eidss_Rayon) == 0){
                if (!(getRayon() == (session.getRayon() == 0 ? EidssDatabase.GetOptions().getRayonDef() : session.getRayon()))){
                    return false;
                }
            } else if (meta.getName().compareTo(eidss_FarmCode) == 0){
                    //return false;
            } else if(meta.NotEmpty(this)) {
                return false;
            }
        }
        return true;
    }

    public void setUnchanged() {
        for(Species s:species)
            s.setUnchanged();
        bChanged = false;
    }

    public void clearChangedStatus() {
        for(Species s:species)
            s.clearChanged();
        clearChanged();
    }

    public List<BaseReference> getSpecies(final Context context) {
        List<BaseReference> ret = new ArrayList<>();
        ret.add(BaseReference.Empty());
        for(Species it: species){
            ret.add(new BaseReference(it.getSpeciesType(), it.GetName(context)));
        }

        return ret;
    }

    private Farm()
    {
        species = new ArrayList<>();
        bChanged = false;
    }

    public static Farm CreateNew()
    {
        Farm ret = new Farm();
        return ret;
    }

    public static Farm CreateNew(Context context, ASSession session)
    {
        Farm ret = new Farm();
        ret._uidOfflineCaseID = UUID.randomUUID().toString();
        ret.setDefault(context, session);
        ret.setParent(session.getId());

        if (session.asDiseases.size() == 1){
            ASDisease asd = session.asDiseases.get(0);
            if (asd.getDiagnosis() != 0 && asd.getSpeciesType() != 0){
                Species sp = Species.CreateNew(ret.getId(), true);
                sp.setSpeciesType(asd.getSpeciesType());
                ret.species.add(sp);
            }
        }

        return ret;
    }

    private void setDefault(Context context, ASSession session){
        EidssDatabase db = new EidssDatabase(context);
        session.countNewFarm++;
        long lNewFarmCount = EidssDatabaseFarm.NewFarmCount(db) + session.countNewFarm;
        setFarm(-lNewFarmCount);
        setFarmCode("(new farm " + String.valueOf(lNewFarmCount) + ")");
        setFarmName(context.getResources().getString(R.string.NewFarm));
        setOwnerLastName(null);
        setOwnerFirstName(null);
        setOwnerMiddleName(null);
        setRegion(session.getRegion() == 0 ? EidssDatabase.GetOptions().getRegionDef() : session.getRegion());
        setRayon(session.getRayon() == 0 ? EidssDatabase.GetOptions().getRayonDef() : session.getRayon());
        setSettlement(session.getSettlement());
        setStreetName(null);
        setBuilding(null);
        setHouse(null);
        setApartment(null);
        setPostCode(null);
        setPhone(null);
        setFax(null);
        setEmail(null);
        setLongitude(0);
        setLatitude(0);
    }

    public static Farm CreateNew(long ipParent)
    {
        Farm ret = new Farm();
        ret.setParent(ipParent);
        return ret;
    }

    public void SetFromAnother(Farm_object source){
        setFarmCode(source.getFarmCode());
        setFarmName(source.getFarmName());
        setOwnerLastName(source.getOwnerLastName());
        setOwnerFirstName(source.getOwnerFirstName());
        setOwnerMiddleName(source.getOwnerMiddleName());
        setRegion(source.getRegion());
        setRayon(source.getRayon());
        setSettlement(source.getSettlement());
        setStreetName(source.getStreetName());
        setBuilding(source.getBuilding());
        setHouse(source.getHouse());
        setApartment(source.getApartment());
        setPostCode(source.getPostCode());
        setPhone(source.getPhone());
        setFax(source.getFax());
        setEmail(source.getEmail());
        setLongitude(source.getLongitude());
        setLatitude(source.getLatitude());
    }

    public void SetFromAnotherWithSpecies(Farm source){
        SetFromAnother(source);

        List<Species> listForDelete = new ArrayList<>();
        for(Species sDst:species){
            boolean bFound = false;
            for(Species sSrc:source.species){
                if (sSrc.getSpeciesType() == sDst.getSpeciesType()){
                    bFound = true;
                    break;
                }
            }
            if (!bFound){
                listForDelete.add(sDst);
                bChanged = true;
            }
        }
        for(Species sDst:listForDelete) {
            species.remove(sDst);
            bChanged = true;
        }

        for(Species sSrc:source.species){
            boolean bFound = false;
            for(Species sDst:species){
                if (sSrc.getSpeciesType() == sDst.getSpeciesType()){
                    sDst.SetFromAnother(sSrc);
                    bFound = true;
                    break;
                }
            }
            if (!bFound){
                species.add(sSrc);
                bChanged = true;
            }
        }
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

        if (species.size() == 0)
            return new ValidateResult(ValidateCode.SpeciesMandatory);

        for(Species s:species)
        {
            ValidateResult vc = s.Validate(mandatoryFields, invisibleFields);
            if (vc.getCode() != ValidateCode.OK)
                return vc;
        }

		return new ValidateResult(ValidateCode.OK);
	}

    private Farm(Parcel source) {
        species = new ArrayList<>();
        FromParcel(source);
        source.readTypedList(species, Species.CREATOR);
    }

    public static final Creator<Farm> CREATOR =
            new Creator<Farm>() {

                @Override
                public Farm createFromParcel(Parcel source) {
                    return new Farm(source);
                }

                @Override
                public Farm[] newArray(int size) {
                    return new Farm[size];
                }
            };

    
    @Override
	public int describeContents() {
        return 0;
	}
	@Override
	public void writeToParcel(Parcel dest, int flag) {
        ToParcel(dest, flag);
        dest.writeTypedList(species);
	}

    public void ToXml(XmlSerializer serializer) throws IllegalArgumentException, IllegalStateException, IOException{
        serializer.startTag("", "farm");
        super.ToXml(serializer);
        serializer.startTag("", "species");
        for (Species s: species){
            s.ToXml(serializer);
        }
        serializer.endTag("", "species");
        serializer.endTag("", "farm");
    }

    public static Farm FromCursor(Cursor cursor)
    {
        Farm ret = new Farm();
        ret.bChanged = false;
        if (FromCursor(cursor, ret) == null) return null;
        return ret;
    }

    public ContentValues ContentValues()
    {
        return ContentValuesInternal();
    }

    public void FromJson(JSONObject json) throws JSONException, ParseException
    {
        super.FromJson(json);
        JSONArray jsonArray = json.getJSONArray("species");
        if(jsonArray!=null && jsonArray.length() > 0){
            for (int i = 0; i < jsonArray.length(); i++) {
                Species sp = Species.CreateNew(getId(), true);
                sp.FromJson(jsonArray.getJSONObject(i));
            }
        }
    }

    public static Farm CreateFromJson(JSONObject json) throws JSONException, ParseException
    {
        Farm ret = new Farm();
        ret.FromJson(json);
        return ret;
    }


    public void FromAttr(Attributes attributes) throws SAXException
    {
        _intRowStatus = Integer.parseInt(attributes.getValue("intRowStatus"));
        _uidOfflineCaseID = attributes.getValue("uidOfflineCaseID");
        _idParent = Long.parseLong(attributes.getValue("idParent"));
        _idfFarm = Long.parseLong(attributes.getValue("idfFarm"));
        _idfsHerd = Long.parseLong(attributes.getValue("idfsHerd"));
        _blnIsRoot = true;
        _strFarmName = attributes.getValue("strFarmName");
        _strFarmCode = attributes.getValue("strFarmCode");
        _idfRootFarm = Long.parseLong(attributes.getValue("idfRootFarm"));
        _strOwnerLastName = attributes.getValue("strOwnerLastName");
        _strOwnerFirstName = attributes.getValue("strOwnerFirstName");
        _strOwnerMiddleName = attributes.getValue("strOwnerMiddleName");
        _strPhone = attributes.getValue("strPhone");
        _strFax = attributes.getValue("strFax");
        _strEmail = attributes.getValue("strEmail");
        _idfsRegion = Long.parseLong(attributes.getValue("idfsRegion"));
        _idfsRayon = Long.parseLong(attributes.getValue("idfsRayon"));
        _idfsSettlement = Long.parseLong(attributes.getValue("idfsSettlement"));
        _strStreetName = attributes.getValue("strStreetName");
        _strBuilding = attributes.getValue("strBuilding");
        _strHouse = attributes.getValue("strHouse");
        _strApartment = attributes.getValue("strApartment");
        _strPostCode = attributes.getValue("strPostCode");
    }

    public static Farm CreateFromAttr(Attributes attributes) throws SAXException
    {
        Farm ret = new Farm();
        ret.FromAttr(attributes);
        return ret;
    }

    public JSONObject ToJson() throws JSONException {
        JSONObject ret = super.ToJson();
        JSONArray list = new JSONArray();
        for (Species sp: species){
            list.put(sp.ToJson());
        }
        ret.put("species", list);
        return ret;
    }

    public void SetRoot(final Context context, long id, ASSession session){
        if (id == 0){
            setRootFarm(0);
            setDefault(context, session);
        } else {
            setRootFarm(id);
            Farm_object f = EidssDatabaseFarm.GetRootFarm(new EidssDatabase(context), id);
            SetFromAnother(f);
        }
    }

    public String GetName(final Context context){
        String result = getFarmName();
        String result1 = getOwnerLastName();
        String result2 = getOwnerFirstName();
        String result3 = getOwnerMiddleName();
        if (result == null) result = "";
        if (result1 == null) result1 = "";
        if (result2 == null) result2 = "";
        if (result3 == null) result3 = "";

        if (!result2.isEmpty() && !result3.isEmpty()) result2 += " ";
        result2 += result3;

        if (!result1.isEmpty() && !result2.isEmpty()) result1 += " ";
        result1 += result2;

        if (!result.isEmpty() && !result1.isEmpty()) result += " / ";
        result += result1;
        return result;
    }

    public String GetAddress(final Context context){
        String result = EidssUtils.getStringFromDB(context, RegionsProvider.CONTENT_URI, getRegion());
        String result1 = EidssUtils.getStringFromDB(context, RayonsProvider.CONTENT_URI, getRayon());
        if (!result.isEmpty() && !result1.isEmpty()) result += ", ";
        result += result1;
        return result;
    }

    @Override
    public List<Species> getSpecies() {
        return species;
    }

    @Override
    public void deleteSpecies(int pos) {
        species.remove(pos);
        bChanged = true;
    }

    @Override
    public boolean canDeleteSpecies(int pos, Object parent) {
        Species sp = species.get(pos);
        ASSession session = (ASSession)parent;
        for(ASSample it: session.asSamples){
            if (it.getFarm() == this.getFarm() && it.getSpeciesType() == sp.getSpeciesType()){
                return false;
            }
        }
        return true;
    }

    @Override
    public void setChanged() {
        bChanged = true;
    }

    @Override
    public List<Long> getSpeciesTypes(long self) {
        List<Long> ret = new ArrayList<>();
        for(Species it: species){
            ret.add(it.getSpeciesType());
        }
        ret.remove(self);
        return ret;
    }

    @Override
    public Boolean IsLivestockCase() {
        return true;
    }
    @Override
    public Boolean IsASSession(){
        return true;
    }
}
