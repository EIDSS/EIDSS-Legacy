package com.bv.eidss.model;

import java.io.IOException;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.UUID;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;
import org.xmlpull.v1.XmlSerializer;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.os.Parcel;
import android.os.Parcelable;

import com.bv.eidss.R;
import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.data.EidssDatabaseFarm;
import com.bv.eidss.model.generated.Animal_object;
import com.bv.eidss.model.generated.Farm_object;
import com.bv.eidss.model.generated.Species_object;
import com.bv.eidss.model.generated.VetCaseSample_object;
import com.bv.eidss.model.generated.VetCase_object;
import com.bv.eidss.model.interfaces.FieldMetadata;
import com.bv.eidss.model.interfaces.ICase;
import com.bv.eidss.model.interfaces.ISpeciesParent;
import com.bv.eidss.model.interfaces.IValidatable;
import com.bv.eidss.model.interfaces.ValidateCode;
import com.bv.eidss.model.interfaces.ValidateResult;
import com.bv.eidss.utils.DateHelpers;
import com.bv.eidss.web.VetCaseInfoOut;

public class VetCase
        extends VetCase_object
        implements Parcelable, IValidatable, ICase, ISpeciesParent {

    public List<Species> species;
    public List<Animal> animals;
    public List<VetCaseSample> samples;

    private boolean _bChecked;
    public boolean isChecked()  { return _bChecked; }
    public void setChecked(boolean value) { _bChecked = value; }

    public FFModel FFControlMeasures;
    public FFModel FFFarmEpi;

    private String _strAddress;
    public String getAddress() { return _strAddress; }
    private String _strTentativeDiagnosis;
    public String getStrTentativeDiagnosis() { return _strTentativeDiagnosis; }

    public List<Species> getSpecies(){return species;}

    private VetCase()
    {
        species = new ArrayList<>();
        animals = new ArrayList<>();
        samples = new ArrayList<>();
        bChanged = false;
    }

    public static VetCase CreateNew(Context context, long CaseType)
    {
        VetCase ret = new VetCase();
        ret._idfCaseType = CaseType;
        ret._intStatus = CaseStatus.NEW;
        ret._uidOfflineCaseID = UUID.randomUUID().toString();
        ret._strCaseID = "(new)";
        //ret.species.add(Species.CreateNew(0, ret.IsLivestockCase()));
        ret._idfsRegion = EidssDatabase.GetOptions().getRegionDef();
        ret._idfsRayon = EidssDatabase.GetOptions().getRayonDef();
        ret._datCreateDate = new Date();
        ret.setFarmDefault(context);
        ret.InitFF();
        ret.bChanged = true;
        return ret;
    }

    public Boolean getChanged() {
        for(Species s:species)
            bChanged = bChanged || s.getChanged();
        for(Animal s:animals)
            bChanged = bChanged || s.getChanged();
        for(VetCaseSample s:samples)
            bChanged = bChanged || s.getChanged();
        if (!bChanged)  bChanged = FFFarmEpi != null ? FFFarmEpi.getChanged() : false;
        if (!bChanged && IsLivestockCase())  bChanged = FFControlMeasures != null ? FFControlMeasures.getChanged() : false;
    	return bChanged;
    }

    public void setUnchanged() {
        for(Species s:species)
        	s.setUnchanged();
        for(Animal s:animals)
            s.setUnchanged();
        for(VetCaseSample s:samples)
            s.setUnchanged();
    	bChanged = false;
    }
    public void setChanged(){
        bChanged = true;
    }

    public void clearChangedStatus() {
        for(Species s:species)
            s.clearChanged();
        for(Animal s:animals)
            s.clearChanged();
        for(VetCaseSample s:samples)
            s.clearChanged();
        clearChanged();
    }

    public void deleteSpecies(int pos) {
        species.remove(pos);
        bChanged = true;
    }

    @Override
    public boolean canDeleteSpecies(int pos, Object parent) {
        Species sp = species.get(pos);
        for(Animal it: animals){
            if (it.getSpeciesType() == sp.getSpeciesType()){
                return false;
            }
        }
        return true;
    }

    public List<BaseReference> getSpecies(final Context context) {
        List<BaseReference> ret = new ArrayList<>();
        ret.add(BaseReference.Empty());
        for(Species it: species){
            ret.add(new BaseReference(it.getSpeciesType(), it.GetName(context)));
        }

        return ret;
    }

    public List<Long> getSpeciesTypes(long self) {
        List<Long> ret = new ArrayList<>();
        for(Species it: species){
            ret.add(it.getSpeciesType());
        }
        ret.remove(self);
        return ret;
    }

    public List<BaseReference> getAnimals(final Context context) {
        List<BaseReference> ret = new ArrayList<>();
        ret.add(BaseReference.Empty());
        for(Animal it: animals){
            ret.add(new BaseReference(it.getAnimal(), it.GetNameForSample(context)));
        }

        return ret;
    }
    public int getNumForNewAnimal() {
        int ret = 1;
        for (Animal sp: animals){
            if(sp.getAnimalCode().startsWith(Animal.def))
            {
                String temp = sp.getAnimalCode().substring(Animal.def.length());
                temp = temp.substring(0, temp.length()-1);
                int num = Integer.parseInt(temp);
                if(ret < num + 1)
                    ret = num + 1;
            }
        }
        return ret;
    }
    public long getIdForNewAnimal() {
        long ret = -1;
        for (Animal sp: animals){
            if(sp.getAnimal() < 0)
            {
                long temp = sp.getAnimal();
                if(ret >= temp)
                    ret = temp - 1;
            }
        }
        return ret;
    }

    private void InitFF(){
        FFControlMeasures = FFModel.CreateNew(getObservation(), FFTypesEnum.LivestockControlMeasures);//0 for a new case
        FFFarmEpi = FFModel.CreateNew(getObservationFarm(), IsLivestockCase() ? FFTypesEnum.LivestockFarmEPI : FFTypesEnum.AvianFarmEPI);//0 for a new case
    }

    public void SetFromOut(VetCaseInfoOut ci){
        setCase(ci.getCase());
        setCaseID(ci.getCaseID());
        setHerd(ci.getHerd());
        //setFarm(ci.getFarm());
        //setRootFarm(ci.getRootFarm());
        setFarmCode(ci.getFarmCode());
        setSentByOffice(ci.getSentByOffice());
        setSentByPerson(ci.getSentByPerson());
        setModificationDate(ci.getModificationDate());

        // Sync for FF
        setObservation(ci.getObservation());
        setObservationFarm(ci.getObservationFarm());
        FFControlMeasures.SetObservation(getObservation());
        FFFarmEpi.SetObservation(getObservationFarm());

        for (Species_object sp: ci.species){
            boolean bFound = false;
            for(int i = 0; i < species.size(); i++){
                Species vcs = species.get(i);
                if (vcs.getSpeciesType() == sp.getSpeciesType()) {
                    vcs.setParent(getId());
                    vcs.SetFromAnother(sp);
                    bFound = true;
                    break;
                }
            }
            if (!bFound) {
                Species vcs = Species.CreateNew(getId(), ci.IsLivestockCase());
                vcs.SetFromAnother(sp);
                species.add(vcs);
            }
        }

        for (Animal_object an: ci.animals){
            boolean bFound = false;
            for(int i = 0; i < animals.size(); i++){
                Animal vcs = animals.get(i);
                if (vcs.getOfflineCaseID().equals(an.getOfflineCaseID())) {
                    vcs.setParent(getId());
                    vcs.SetFromAnother(an);
                    bFound = true;
                    break;
                }
            }
            if (!bFound) {
                Animal vcs = Animal.CreateNew(getId());
                vcs.SetFromAnother(an);
                animals.add(vcs);
            }

        }

        for (VetCaseSample_object sm: ci.samples){
            boolean bFound = false;
            for(int i = 0; i < samples.size(); i++){
                VetCaseSample vcs = samples.get(i);
                if (vcs.getOfflineCaseID().equals(sm.getOfflineCaseID())) {
                    vcs.setParent(getId());
                    vcs.SetFromAnother(sm);
                    bFound = true;
                    break;
                }
            }
            if (!bFound) {
                VetCaseSample vcs = VetCaseSample.CreateNew(getId());
                vcs.SetFromAnother(sm);
                samples.add(vcs);
            }

        }
        /*
        FFControlMeasures.ActivityParameters.clear();
        for(int i = 0; i < ci.ActivityParameters.size(); i++){
            ActivityParameter ap = ci.ActivityParameters.get(i);
            FFControlMeasures.ActivityParameters.put(ap.GetKey(), ap);
        }
        */

        clearChangedStatus();
    }

	@Override
	public ValidateResult Validate(List<String> mandatoryFields, List<String> invisibleFields) {
        for (FieldMetadata meta : fieldMetadata) {
            if (!meta.CheckMandatory(this, mandatoryFields, invisibleFields)) {
                return new ValidateResult(ValidateCode.FieldMandatory, meta.getTitle());
            }
        }

        if (getTentativeDiagnosisDate() != null && getTentativeDiagnosisDate().after(DateHelpers.Today()))
        	return new ValidateResult(ValidateCode.DateOfDiagnosisCheckCurrent);
        if (getTentativeDiagnosisDate() != null && getReportDate() != null && getReportDate().after(getTentativeDiagnosisDate()))
        	return new ValidateResult(ValidateCode.DateOfEnteredCheckDiagnosis);
        if (getReportDate() != null && getReportDate().after(DateHelpers.Today()))
        	return new ValidateResult(ValidateCode.DateOfReportCheckCurrent);

        if (species.size() == 0)
            return new ValidateResult(ValidateCode.SpeciesMandatory);
        for(Species s:species)
        {
            ValidateResult vc = s.Validate(mandatoryFields, invisibleFields);
            if (vc.getCode() != ValidateCode.OK)
                return vc;
        }
        for(Animal s:animals)
        {
            ValidateResult vc = s.Validate(mandatoryFields, invisibleFields);
            if (vc.getCode() != ValidateCode.OK)
                return vc;
        }
        for(VetCaseSample s:samples)
        {
            ValidateResult vc = s.Validate(IsLivestockCase(), mandatoryFields, invisibleFields);
            if (vc.getCode() != ValidateCode.OK)
                return vc;
        }

        if (FFControlMeasures != null) {
            ValidateResult vr = FFControlMeasures.Validate();
            if (vr.getCode() != ValidateCode.OK)
                return vr;
        }
        if (FFFarmEpi != null) {
            ValidateResult vr = FFFarmEpi.Validate();
            if (vr.getCode() != ValidateCode.OK)
                return vr;
        }

		return  new ValidateResult(ValidateCode.OK);
	}

	public static void updateStatusUploaded(List<VetCase> vcs){
        for (VetCase vc: vcs){
        	if (vc.getStatus() == CaseStatus.NEW || vc.getStatus() == CaseStatus.CHANGED){
        		vc.setStatusUploaded();
        	}
        }
	}


    public static VetCase FromCursor(Cursor cursor)
    {
        VetCase ret = new VetCase();
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
        if(cursor.getColumnIndex("strTentativeDiagnosis") >= 0)
            ret._strTentativeDiagnosis = cursor.getString(cursor.getColumnIndex("strTentativeDiagnosis"));

        ret.InitFF();
        ret.FFControlMeasures.SetObservation(ret.getObservation());
        ret.FFFarmEpi.SetObservation(ret.getObservationFarm());

        return ret;
    }

    public ContentValues ContentValues()
    {
        return ContentValuesInternal();
    }

    public static final Parcelable.Creator<VetCase> CREATOR = new Parcelable.Creator<VetCase>()
    {
        public VetCase createFromParcel(Parcel in) {
            return new VetCase(in);
        }

        public VetCase[] newArray(int size) {
            return new VetCase[size];
        }
    };

    private VetCase(Parcel source)
    {
        species = new ArrayList<>();
        animals = new ArrayList<>();
        samples = new ArrayList<>();
        bChanged = false;
        FromParcel(source);
        source.readTypedList(species, Species.CREATOR);
        source.readTypedList(animals, Animal.CREATOR);
        source.readTypedList(samples, VetCaseSample.CREATOR);
        FFControlMeasures = FFModel.CreateNew(source);
        FFFarmEpi = FFModel.CreateNew(source);
    }

    @Override
    public int describeContents() {
        return 4;
    }

    @Override
    public void writeToParcel(Parcel dest, int flag) {
        ToParcel(dest, flag);
        dest.writeTypedList(species);
        dest.writeTypedList(animals);
        dest.writeTypedList(samples);
        if (FFControlMeasures != null) FFControlMeasures.writeToParcel(dest, flag);
        if (FFFarmEpi != null) FFFarmEpi.writeToParcel(dest, flag);
    }

    private void ToXml(long country, XmlSerializer serializer) throws IllegalArgumentException, IllegalStateException, IOException{
        serializer.startTag("", "case");
        serializer.attribute("", "country", String.valueOf(country));
        ToXml(serializer);
        serializer.startTag("", "species");
        for (Species sp: species){
            sp.ToXml(serializer);
        }
        serializer.endTag("", "species");
        serializer.startTag("", "animals");
        for (Animal sp: animals){
            sp.ToXml(serializer);
        }
        serializer.endTag("", "animals");
        serializer.startTag("", "samples");
        for (VetCaseSample sp: samples){
            sp.ToXml(serializer);
        }
        serializer.endTag("", "samples");
        FFControlMeasures.ToXml(serializer);
        FFFarmEpi.ToXml(serializer);
        serializer.endTag("", "case");
    }

    public static void ToXml(List<VetCase> vcs, long country, XmlSerializer serializer, Boolean bAll) throws IllegalArgumentException, IllegalStateException, IOException{
        serializer.startTag("", "vet");
        for (VetCase vc: vcs){
            if (bAll || vc.getStatus() == CaseStatus.NEW || vc.getStatus() == CaseStatus.CHANGED || vc.getStatus() == CaseStatus.UNLOADED){
                vc.ToXml(country, serializer);
            }
        }
        serializer.endTag("", "vet");
    }

/*    public static void FromXml(List<VetCase> hcs, XmlPullParser parser)throws XmlPullParserException, IOException, ParseException {
        int eventType = parser.next();
        VetCase r = null;
        while (eventType != XmlPullParser.END_DOCUMENT){
            switch (eventType){
                case XmlPullParser.START_TAG:
                    String name = parser.getName();
                    if (name.equalsIgnoreCase("case")){
                        r = new VetCase();
                        r.FromXml(parser);
                        hcs.add(r);
                    }
                    if (name.equalsIgnoreCase("kind")){
                        Species s = Species.CreateNew(r.getId(), r.IsLivestockCase());
                        s.FromXml(parser);
                        r.species.add(s);
                    }
                    break;
                case XmlPullParser.END_TAG:
                    name = parser.getName();
                    if (name.equalsIgnoreCase("vet")){
                        return;
                    }
                    break;
            }
            eventType = parser.next();
        }
    }
*/
    public Boolean IsLivestockCase(){
        return getCaseType() == CaseType.LIVESTOCK;
    }
    @Override
    public Boolean IsASSession(){
        return false;
    }

    public static int GetVetCaseHaCode(long caseType)
    {
    	if(caseType == CaseType.AVIAN) return CaseTypeHACode.AVIAN;
    	if(caseType == CaseType.LIVESTOCK) return CaseTypeHACode.LIVESTOCK;
    	return 0;
    }
    public void FromJson(JSONObject json) throws JSONException, ParseException
    {
        super.FromJson(json);
        JSONArray jsonArray = json.getJSONArray("species");
        if(jsonArray!=null && jsonArray.length() > 0){
            for (int i = 0; i < jsonArray.length(); i++) {
                Species sp = Species.CreateNew(getId(), IsLivestockCase());
                sp.FromJson(jsonArray.getJSONObject(i));
            }
        }
        jsonArray = json.getJSONArray("animals");
        if(jsonArray!=null && jsonArray.length() > 0){
            for (int i = 0; i < jsonArray.length(); i++) {
                Animal sp = Animal.CreateNew(getId());
                sp.FromJson(jsonArray.getJSONObject(i));
            }
        }
        jsonArray = json.getJSONArray("samples");
        if(jsonArray!=null && jsonArray.length() > 0){
            for (int i = 0; i < jsonArray.length(); i++) {
                VetCaseSample sp = VetCaseSample.CreateNew(getId());
                sp.FromJson(jsonArray.getJSONObject(i));
            }
        }
        //TODO FF
    }

    public JSONObject ToJson() throws JSONException {
        JSONObject ret = super.ToJson();
        JSONArray list = new JSONArray();
        for (Species sp: species){
            list.put(sp.ToJson());
        }
        ret.put("species", list);
        list = new JSONArray();
        for (Animal sp: animals){
            list.put(sp.ToJson());
        }
        ret.put("animals", list);
        list = new JSONArray();
        for (VetCaseSample sp: samples){
            list.put(sp.ToJson());
        }
        ret.put("samples", list);
        ret.put("FFControlMeasures", FFControlMeasures.ToJson());
        ret.put("FFFarmEpi", FFFarmEpi.ToJson());
        return ret;
    }


    private void setFarmDefault(Context context){
        EidssDatabase db = new EidssDatabase(context);
        long lNewFarmCount = EidssDatabaseFarm.NewFarmCount(db) + 1;
        setFarm(-lNewFarmCount);
        setFarmCode("(new farm " + String.valueOf(lNewFarmCount) + ")");
        setFarmName(context.getResources().getString(R.string.NewFarm));
        setOwnerLastName(null);
        setOwnerFirstName(null);
        setOwnerMiddleName(null);
        setRegion(EidssDatabase.GetOptions().getRegionDef());
        setRayon(EidssDatabase.GetOptions().getRayonDef());
        setSettlement(0);
        setStreetName(null);
        setBuilding(null);
        setHouse(null);
        setApartment(null);
        setPostCode(null);
        setPhone(null);
        //setFax(null);
        //setEmail(null);
        setLongitude(0);
        setLatitude(0);
    }

    private void setFarmFromAnother(Farm_object source){
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
        //setFax(source.getFax());
        //setEmail(source.getEmail());
        setLongitude(source.getLongitude());
        setLatitude(source.getLatitude());
    }

    public void SetRoot(final Context context, long id){
        if (id == 0){
            setRootFarm(0);
            setFarmDefault(context);
        } else {
            setRootFarm(id);
            Farm_object f = EidssDatabaseFarm.GetRootFarm(new EidssDatabase(context), id);
            setFarmFromAnother(f);
        }
    }

}
