package com.bv.eidss.model;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.os.Parcel;
import android.os.Parcelable;

import com.bv.eidss.CampaignsProvider;
import com.bv.eidss.R;
import com.bv.eidss.ReferenciesProvider;
import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.generated.ASDisease_object;
import com.bv.eidss.model.generated.ASSample_object;
import com.bv.eidss.model.generated.ASSession_object;
import com.bv.eidss.model.generated.Farm_object;
import com.bv.eidss.model.generated.Species_object;
import com.bv.eidss.model.generated.VetCase_object;
import com.bv.eidss.model.interfaces.Constants;
import com.bv.eidss.model.interfaces.FieldMetadata;
import com.bv.eidss.model.interfaces.ICase;
import com.bv.eidss.model.interfaces.IValidatable;
import com.bv.eidss.model.interfaces.ValidateCode;
import com.bv.eidss.model.interfaces.ValidateResult;
import com.bv.eidss.utils.DateHelpers;
import com.bv.eidss.utils.EidssUtils;
import com.bv.eidss.web.ASSessionInfoOut;
import com.bv.eidss.web.VetCaseInfoOut;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;
import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xmlpull.v1.XmlPullParser;
import org.xmlpull.v1.XmlPullParserException;
import org.xmlpull.v1.XmlSerializer;

import java.io.IOException;
import java.lang.ref.Reference;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.Date;
import java.util.Iterator;
import java.util.List;
import java.util.UUID;

public class ASSession
        extends ASSession_object
        implements Parcelable, IValidatable, ICase {

    public List<ASDisease> asDiseases;
    public List<Farm> farms;
    public List<ASSample> asSamples;
    public long countNewFarm = 0;
    public long countNewAnimal = 0;

    private boolean _bChecked;
    public boolean isChecked()  { return _bChecked; }
    public void setChecked(boolean value) { _bChecked = value; }

    public Boolean getChanged() {
        for(ASDisease s:asDiseases)
            bChanged = bChanged || s.getChanged();
        for(Farm f:farms)
            bChanged = bChanged || f.getChanged();
        for(ASSample s:asSamples)
            bChanged = bChanged || s.getChanged();
    	return bChanged;
    }

    public void setUnchanged() {
        for(ASDisease s:asDiseases)
            s.setUnchanged();
        for(Farm f:farms)
            f.setUnchanged();
        for(ASSample s:asSamples)
            s.setUnchanged();
    	bChanged = false;
    }
    public void setChanged(){
        bChanged = true;
    }

    public void clearChangedStatus() {
        for(ASDisease s:asDiseases)
            s.clearChanged();
        for(Farm f:farms)
            f.clearChanged();
        for(ASSample s:asSamples)
            s.clearChanged();
        clearChanged();
    }

    public void setCreateDate(Date value) { _datCreateDate = value; }

    private ASSession()
    {
        asDiseases = new ArrayList<>();
        farms = new ArrayList<>();
        asSamples = new ArrayList<>();
        bChanged = false;
    }

    private ASSession(Date createDate)
    {
        _intStatus = CaseStatus.SYNCHRONIZED;
        _datCreateDate = createDate;
        asDiseases = new ArrayList<>();
        farms = new ArrayList<>();
        asSamples = new ArrayList<>();
        bChanged = false;
    }

    public static ASSession CreateNew()
    {
    	ASSession ret = new ASSession();
        ret._intStatus = CaseStatus.NEW;
        ret._uidOfflineCaseID = UUID.randomUUID().toString();
        ret._strMonitoringSessionID = "(new)";
        ret._idfsMonitoringSessionStatus = Constants.AsSessionStatus_Open;
        ret._datStartDate = new Date();
        ret._idfsRegion = EidssDatabase.GetOptions().getRegionDef();
        ret._idfsRayon = EidssDatabase.GetOptions().getRayonDef();
        ret._datCreateDate = new Date();
        ret.bChanged = true;
        return ret;
    }

    public void SetFromOut(ASSessionInfoOut ci){
        // Sync group 3
        setMonitoringSession(ci.getMonitoringSession());
        setMonitoringSessionID(ci.getMonitoringSessionID());
        setModificationDate(ci.getModificationDate());

        // Sync group 2
        setStartDate(ci.getStartDate());
        setEndDate(ci.getEndDate());


        asDiseases.clear();
        for (ASDisease_object sp: ci.asDiseases){
            asDiseases.add(new ASDisease(sp, this));
        }

        for(Farm_object fSrv:ci.farms){
            boolean bFind = false;
            for(Farm fObj:farms){
                if (fSrv.getFarm() == fObj.getFarm()){
                    // not update - leave device version
                    bFind = true;
                    break;
                } else if (fObj.getFarm() <= 0 && fSrv.getOfflineCaseID().compareTo(fObj.getOfflineCaseID()) == 0){
                    // update new
                    fObj.setFarm(fSrv.getFarm());
                    fObj.setHerd(fSrv.getHerd());
                    fObj.setFarmCode(fSrv.getFarmCode());
                    bFind = true;
                    break;
                }
            }
            if (!bFind){
                // insert
                Farm newFarm = Farm.CreateNew(getId());
                newFarm.setFarm(fSrv.getFarm());
                newFarm.setHerd(fSrv.getHerd());
                newFarm.SetFromAnother(fSrv);
                newFarm.setParent(getId());
                farms.add(newFarm);
            }
        }

        for (ASSample_object spSrv: ci.asSamples){
            boolean bFind = false;
            for(ASSample spObj:asSamples){
                if ((spSrv.getOfflineCaseID() != null && spObj.getOfflineCaseID() != null && spSrv.getOfflineCaseID().compareTo(spObj.getOfflineCaseID()) == 0) ||
                    (spSrv.getAnimal() == spObj.getAnimal() && spSrv.getMaterial() == spObj.getMaterial())) {
                    // update
                    spObj.setMonitoringSession(getMonitoringSession());
                    spObj.SetFromAnother(spSrv);
                    spObj.setAnimal(spSrv.getAnimal());
                    spObj.setMaterial(spSrv.getMaterial());
                    bFind = true;
                    break;
                }
            }
            if (!bFind){
                // not insert not our samples !!
                /*ASSample newASSample = ASSample.CreateNew(getMonitoringSession(), getId());
                newASSample.SetFromAnother(spSrv);
                newASSample.setAnimal(spSrv.getAnimal());
                newASSample.setMaterial(spSrv.getMaterial());
                newASSample.setParent(getId());
                asSamples.add(newASSample);*/
            }
        }

        clearChangedStatus();
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

        if (getStartDate() != null && getEndDate() != null && getStartDate().after(getEndDate()))
            return new ValidateResult(ValidateCode.DateOfSessionStartCheckSessionEnd);

        for(ASDisease s:asDiseases)
        {
            ValidateResult vc = s.Validate(mandatoryFields, invisibleFields);
            if (vc.getCode() != ValidateCode.OK)
                return vc;
        }

        for(Farm f:farms)
        {
            ValidateResult vc = f.Validate(mandatoryFields, invisibleFields);
            if (vc.getCode() != ValidateCode.OK)
                return vc;
        }

        for(ASSample s:asSamples)
        {
            ValidateResult vc = s.Validate(mandatoryFields, invisibleFields);
            if (vc.getCode() != ValidateCode.OK)
                return vc;
        }

        return  new ValidateResult(ValidateCode.OK);
	}

	public static void updateStatusUploaded(List<ASSession> vcs){
        for (ASSession vc: vcs){
        	if (vc.getStatus() == CaseStatus.NEW || vc.getStatus() == CaseStatus.CHANGED){
        		vc.setStatusUploaded();
        	}
        }
	}

    public ArrayList<BaseReference> getSpeciesTypes(final Context context) {
        ArrayList<BaseReference> ret = new ArrayList<>();
        List<Long> check = new ArrayList<>();
        ret.add(BaseReference.Empty());
        for(ASDisease s:asDiseases) {
            long st = s.getSpeciesType();
            if (!check.contains(st)) {
                String name = EidssUtils.getStringFromDB(context, ReferenciesProvider.CONTENT_URI, st);
                ret.add(new BaseReference(st, name));
                check.add(st);
            }
        }

        return ret;
    }

    private String _strAddress;
    public String getAddress() { return _strAddress; }
    private String _strCampaignName;
    public String getCampaignName() { return _strCampaignName; }
    private String _strSesionStatus;
    public String getSesionStatus() { return _strSesionStatus; }

    public static ASSession FromCursor(Cursor cursor)
    {
        ASSession ret = new ASSession();
        if (FromCursor(cursor, ret) == null)
            return null;

        if(cursor.getColumnIndex("strRegion") >= 0) {
            String region = cursor.getString(cursor.getColumnIndex("strRegion"));
            String rayon = cursor.getString(cursor.getColumnIndex("strRayon"));
            String settlement = cursor.getString(cursor.getColumnIndex("strSettlement"));
            ret._strAddress = region + ", " + rayon;
            if(!settlement.isEmpty())
                ret._strAddress += ", " + settlement;
        }
        if(cursor.getColumnIndex("strCampaignName") >= 0) {
            ret._strCampaignName = cursor.getString(cursor.getColumnIndex("strCampaignName"));
        }
        if(cursor.getColumnIndex("strSesionStatus") >= 0) {
            ret._strSesionStatus = cursor.getString(cursor.getColumnIndex("strSesionStatus"));
        }

        return ret;
    }

    public ContentValues ContentValues()
    {
        return ContentValuesInternal();
    }

    public static final Creator<ASSession> CREATOR = new Creator<ASSession>()
    {
        public ASSession createFromParcel(Parcel in) {
            return new ASSession(in);
        }

        public ASSession[] newArray(int size) {
            return new ASSession[size];
        }
    };

    private ASSession(Parcel source)
    {
        asDiseases = new ArrayList<>();
        farms = new ArrayList<>();
        asSamples = new ArrayList<>();
        bChanged = false;
        FromParcel(source);
        countNewFarm = source.readLong();
        countNewAnimal = source.readLong();
        source.readTypedList(asDiseases, ASDisease.CREATOR);
        source.readTypedList(farms, Farm.CREATOR);
        source.readTypedList(asSamples, ASSample.CREATOR);
    }

    public void SetIdForAllChildren()
    {
        for (ASDisease sp: asDiseases){
            sp.setParent(getId());
        }
        for (Farm f: farms){
            f.setParent(getId());
        }
        for (ASSample sp: asSamples){
            sp.setParent(getId());
        }
    }

    @Override
    public int describeContents() {
        return 4;
    }

    @Override
    public void writeToParcel(Parcel dest, int flag) {
        ToParcel(dest, flag);
        dest.writeLong(countNewFarm);
        dest.writeLong(countNewAnimal);
        dest.writeTypedList(asDiseases);
        dest.writeTypedList(farms);
        dest.writeTypedList(asSamples);
    }

    private void ToXml(long country, XmlSerializer serializer) throws IllegalArgumentException, IllegalStateException, IOException{
        serializer.startTag("", "case");
        serializer.attribute("", "country", String.valueOf(country));
        ToXml(serializer);
        serializer.startTag("", "asdiseases");
        for (ASDisease sp: asDiseases){
            sp.ToXml(serializer);
        }
        serializer.endTag("", "asdiseases");
        serializer.startTag("", "farms");
        for (Farm f: farms){
            f.ToXml(serializer);
        }
        serializer.endTag("", "farms");
        serializer.startTag("", "assamples");
        for (ASSample sp: asSamples){
            sp.ToXml(serializer);
        }
        serializer.endTag("", "assamples");
        serializer.endTag("", "case");
    }

    public static void ToXml(List<ASSession> vcs, long country, XmlSerializer serializer, Boolean bAll) throws IllegalArgumentException, IllegalStateException, IOException{
        serializer.startTag("", "as");
        for (ASSession vc: vcs){
            if (bAll || vc.getStatus() == CaseStatus.NEW || vc.getStatus() == CaseStatus.CHANGED || vc.getStatus() == CaseStatus.UNLOADED){
                vc.ToXml(country, serializer);
            }
        }
        serializer.endTag("", "as");
    }

    public static void FromXml(List<ASSession> hcs, XmlPullParser parser)throws XmlPullParserException, IOException, ParseException {
        int eventType = parser.next();
        ASSession r = null;
        while (eventType != XmlPullParser.END_DOCUMENT){
            switch (eventType){
                case XmlPullParser.START_TAG:
                    String name = parser.getName();
                    if (name.equalsIgnoreCase("case")){
                        r = new ASSession();
                        r.FromXml(parser);
                        hcs.add(r);
                    }
                    break;
                case XmlPullParser.END_TAG:
                    name = parser.getName();
                    if (name.equalsIgnoreCase("as")){
                        return;
                    }
                    break;
            }
            eventType = parser.next();
        }
    }

    public void FromJson(JSONObject json) throws JSONException, ParseException
    {
        super.FromJson(json);
        JSONArray jsonArray = json.getJSONArray("asdiseases");
        if(jsonArray!=null && jsonArray.length() > 0){
            for (int i = 0; i < jsonArray.length(); i++) {
                ASDisease sp = ASDisease.CreateNew(getMonitoringSession(), getId());
                sp.FromJson(jsonArray.getJSONObject(i));
                sp.setParent(getId());
                asDiseases.add(sp);
            }
        }
        jsonArray = json.getJSONArray("farms");
        if(jsonArray!=null && jsonArray.length() > 0){
            for (int i = 0; i < jsonArray.length(); i++) {
                Farm f = Farm.CreateNew();
                f.FromJson(jsonArray.getJSONObject(i));
                f.setParent(getId());
                farms.add(f);
            }
        }
        jsonArray = json.getJSONArray("assamples");
        if(jsonArray!=null && jsonArray.length() > 0){
            for (int i = 0; i < jsonArray.length(); i++) {
                ASSample sp = ASSample.CreateNew(getMonitoringSession(), getId());
                sp.FromJson(jsonArray.getJSONObject(i));
                sp.setParent(getId());
                asSamples.add(sp);
            }
        }
    }

    public static ASSession CreateFromJson(JSONObject json) throws JSONException, ParseException
    {
        ASSession ret = new ASSession(DateHelpers.ParseWithT(json.getString("datCreateDate")));
        ret.FromJson(json);
        return ret;
    }



    public void FromAttr(Attributes attributes) throws SAXException, ParseException
    {
        _datModificationDate = DateHelpers.ParseWithT(attributes.getValue("datModificationDate"));
        _uidOfflineCaseID = attributes.getValue("uidOfflineCaseID");
        _strMonitoringSessionID = attributes.getValue("strMonitoringSessionID");
        _idfMonitoringSession = Long.parseLong(attributes.getValue("idfMonitoringSession"));
        _idfsMonitoringSessionStatus = Long.parseLong(attributes.getValue("idfsMonitoringSessionStatus"));
        _datStartDate = DateHelpers.ParseWithT(attributes.getValue("datStartDate"));
        _datEndDate = DateHelpers.ParseWithT(attributes.getValue("datEndDate"));
        _idfCampaign = Long.parseLong(attributes.getValue("idfCampaign"));
        _idfsCampaignType = Long.parseLong(attributes.getValue("idfsCampaignType"));
        _idfsRegion = Long.parseLong(attributes.getValue("idfsRegion"));
        _idfsRayon = Long.parseLong(attributes.getValue("idfsRayon"));
        _idfsSettlement = Long.parseLong(attributes.getValue("idfsSettlement"));
    }

    public static ASSession CreateFromAttr(Attributes attributes) throws SAXException, ParseException
    {
        ASSession ret = new ASSession();
        ret.FromAttr(attributes);
        return ret;
    }


    public JSONObject ToJson() throws JSONException {
        JSONObject ret = super.ToJson();
        JSONArray list = new JSONArray();
        for (ASDisease sp: asDiseases){
            list.put(sp.ToJson());
        }
        ret.put("asdiseases", list);

        list = new JSONArray();
        for (Farm f: farms){
            list.put(f.ToJson());
        }
        ret.put("farms", list);

        list = new JSONArray();
        for (ASSample s: asSamples){
            list.put(s.ToJson());
        }
        ret.put("assamples", list);

        return ret;
    }


    public void ForceSetCampaign(EidssDatabase db, long idCampaign){
        ASCampaign campaign = db.GetCampaign(idCampaign);
        setCampaign(idCampaign);
        setCampaignType(campaign.idfsCampaignType);
        asDiseases.clear();
        for (ASDisease sp: campaign.asDiseases){
            asDiseases.add(new ASDisease(sp, this));
        }
    }

    public int SetCampaign(EidssDatabase db, long idCampaign){
        ASCampaign campaign = db.GetCampaign(idCampaign);

        // The AS Session period (defined by fields <Session Start Date> - <Session End Date>) shall be less or equal to the AS Campaign period (defined by fields <Campaign Start Date> - <Campaign End Date>), to which the Session is linked. If the AS Session period does not match or is bigger than the AS Campaign period, the system shall not allow to link the Session to the Campaign, the following warning message shall appear: The Session's period must match the Campaign's period with button [Ok]. By clicking [Ok] button, the warning message shall be closed, the Active Surveillance Sessions List V17 form shall stay opened.
        if (getStartDate() != null && campaign.datCampaignDateStart != null && getStartDate().compareTo(campaign.datCampaignDateStart) < 0) {
            return R.string.SessionPeriodDoesNotMatchCampaignPeriod;
        }
        if (getStartDate() != null && campaign.datCampaignDateEnd != null && getStartDate().compareTo(campaign.datCampaignDateEnd) > 0) {
            return R.string.SessionPeriodDoesNotMatchCampaignPeriod;
        }
        if (getEndDate() != null && campaign.datCampaignDateEnd != null && getEndDate().compareTo(campaign.datCampaignDateEnd) > 0) {
            return R.string.SessionPeriodDoesNotMatchCampaignPeriod;
        }
        if (getEndDate() != null && campaign.datCampaignDateStart != null && getEndDate().compareTo(campaign.datCampaignDateStart) < 0) {
            return R.string.SessionPeriodDoesNotMatchCampaignPeriod;
        }

        // Records on Active Surveillance Session form-> Animals/Samples tab. If on this tab there is a record with <Species> and <Sample Type>, which is missing in Disease and Species List for the AS Campaign, then a warning message shall be shown: Can't associate current Session with selected Campaign. The Session contains some species/sample types that are absent in the selected Campaign. Please remove Session species/sample types that are not included to campaign or select another campaign. with the button [Ok]. By clicking [Ok] button, AS Session shall not be linked to AS Campaign, the warning message shall be closed.
        // TODO
        // return R.string.SessionContainsSpeciesAbsentInCampaign

        List<ASDisease> listForInsert = new ArrayList<ASDisease>();
        List<ASDisease> listForRemove = new ArrayList<ASDisease>();
        for (ASDisease campDis: campaign.asDiseases){
            boolean bFound = false;
            for (ASDisease sessDis: this.asDiseases){
                if (campDis.getDiagnosis() == sessDis.getDiagnosis() &&
                    campDis.getSpeciesType() == sessDis.getSpeciesType() &&
                    campDis.getSampleType() == sessDis.getSampleType()) {
                    bFound = true;
                    break;
                }
            }
            if (!bFound){
                listForInsert.add(campDis);
            }
        }
        for (ASDisease sessDis: this.asDiseases){
            boolean bFound = false;
            for (ASDisease campDis: campaign.asDiseases){
                if (campDis.getDiagnosis() == sessDis.getDiagnosis() &&
                    campDis.getSpeciesType() == sessDis.getSpeciesType() &&
                    campDis.getSampleType() == sessDis.getSampleType()) {
                    bFound = true;
                    break;
                }
            }
            if (!bFound){
                listForRemove.add(sessDis);
            }
        }

        /* If Disease and Species List for the AS Session is not blank and the Disease and Species List for the AS Campaign is blank, a warning message appears: The Diseases And Species List in the Active Surveillance Campaign is blank. Remove records from the Diseases And Species List in the Active Surveillance Session? with button [Yes]/[No] buttons. By selectin [No] AS Session shall NOT be linked to AS Campaign. By selectin [Yes] AS Session shall be linked to AS Campaign AND Disease and Species List of the AS Session shall be cleared.*/
        if (this.asDiseases.size() > 0 && campaign.asDiseases.size() == 0 && idCampaign != 0){
            return R.string.CampaignDiseasesListIsBlank;
        }

        /* If Disease and Species List for the AS Session is the same as Disease and Species List for the AS Campaign, then AS Session shall be linked to AS Campaign.*/
        if (listForInsert.size() == 0 && listForRemove.size() == 0){
        }
        /* If Disease and Species List for the AS Session represents a subset of campaign's Disease and Species List, the AS Session shall be linked to the AS Campaign AND all the missing rows form AS Campaign Disease and Species List shall be added to the AS Session's Disease and Species List.*/
        /* If Disease and Species List for the AS Session is blank and the Disease and Species List for the AS Campaign is not blank, the AS Session shall be linked to the AS Campaign AND Disease and Species List of the AS Session shall be replaced by Disease and Species List of the AS Campaign.*/
        else if (listForInsert.size() > 0 && listForRemove.size() == 0){
        }
        /* If Disease and Species List for the AS Session differs from the Disease and Species List for the AS Campaign or can't be represented as subset of campaign's Disease and Species List, a warning message appears: The Diseases And Species List in the Active Surveillance Session differs from the Diseases And Species List in the chosen Active Surveillance Campaign. Rewrite the Diseases And Species List in the Active Surveillance Session based on the list in Active Surveillance Campaign? with button [Yes]/[No] buttons. By selectin [No] AS Session shall NOT be linked to AS Campaign. By selectin [Yes] AS Session shall be linked to AS Campaign AND Disease and Species List of the AS Session shall be replaced by Disease and Species List of the AS Campaign.*/
        else if (listForRemove.size() > 0 && idCampaign != 0){
            return R.string.SessionDiseasesDiffersFromCampaignDiseases;
        }

        setCampaign(idCampaign);
        setCampaignType(campaign.idfsCampaignType);
        if (idCampaign != 0) {
            if (listForInsert.size() != 0 || listForRemove.size() != 0){
                asDiseases.clear();
                for (ASDisease sp : listForInsert) {
                    asDiseases.add(new ASDisease(sp, this));
                }
            }
        }
        return 0;
    }

    public List<BaseReference> getFarms(final Context context) {
        List<BaseReference> ret = new ArrayList<>();
        ret.add(BaseReference.Empty());
        for(Farm it: farms){
            ret.add(new BaseReference(it.getFarm(), it.GetName(context)));
        }
        return ret;
    }

    public List<BaseReference> getSpecies(final Context context, long farmId) {
        List<BaseReference> ret = new ArrayList<>();
        ret.add(BaseReference.Empty());
        for(Farm it: farms){
            if (it.getFarm() == farmId){
                for(Species its: it.getSpecies()){
                    ret.add(new BaseReference(its.getSpeciesType(), its.GetName(context)));
                }
                break;
            }
        }
        return ret;
    }

    public List<BaseReference> getSampleTypes(final Context context, long speciesId) {
        List<BaseReference> ret = new ArrayList<>();
        ret.add(BaseReference.Empty());
        for(ASDisease it: asDiseases){
            if (it.getSpeciesType() == speciesId) {
                if (it.getSampleType() > 0) {
                    boolean bFound = false;
                    for(BaseReference b: ret){
                        if (b.idfsBaseReference == it.getSampleType()){
                            bFound = true;
                            break;
                        }
                    }
                    if (!bFound) {
                        ret.add(new BaseReference(it.getSampleType(), EidssUtils.getStringFromDB(context, ReferenciesProvider.CONTENT_URI, it.getSampleType())));
                    }
                }
            }
        }
        return ret;
    }

    public List<BaseReference> getAnimals(long farmId, long speciesId, ASSample that, int position) {
        List<BaseReference> ret = new ArrayList<>();
        if (farmId != 0 && speciesId != 0) {
            if (position >= 0){
                ret.add(BaseReference.EmptyNewAnimal());
            }
            for (ASSample a : asSamples) {
                if (a.getFarm() == farmId && a.getSpeciesType() == speciesId) {
                    boolean bFound = false;
                    for (BaseReference b : ret) {
                        if (b.idfsBaseReference == a.getAnimal()) {
                            bFound = true;
                            break;
                        }
                    }
                    if (!bFound) {
                        ret.add(new BaseReference(a.getAnimal(), a.getAnimalCode()));
                    }
                }
            }

            boolean bFound = false;
            for (BaseReference b : ret) {
                if (b.idfsBaseReference == that.getAnimal()) {
                    bFound = true;
                    break;
                }
            }
            if (!bFound) {
                ret.add(new BaseReference(that.getAnimal(), that.getAnimalCode()));
            }
        }
        return ret;
    }

    public Boolean isNewNotClosed(){
        return getMonitoringSession() == 0 && getMonitoringSessionStatus() != Constants.AsSessionStatus_Closed;
    }
}
