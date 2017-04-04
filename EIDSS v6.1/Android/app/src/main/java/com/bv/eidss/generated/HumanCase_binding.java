package com.bv.eidss.generated;

import android.content.Context;
import android.database.Cursor;
import android.support.v4.content.CursorLoader;
import android.support.v4.content.Loader;
import android.support.v4.widget.SimpleCursorAdapter;
import android.view.View;
import android.widget.CompoundButton;
import android.widget.AdapterView;

import com.bv.eidss.EidssBaseBindableFragment;
import com.bv.eidss.HumanCaseFragment;
import com.bv.eidss.VetCaseFragment;
import com.bv.eidss.AnimalFragment;
import com.bv.eidss.ASDiseaseFragment;
import com.bv.eidss.ASSampleFragment;
import com.bv.eidss.FarmFragment;
import com.bv.eidss.HumanCaseSampleFragment;
import com.bv.eidss.VetCaseSampleFragment;
import com.bv.eidss.ASSessionFragment;
import com.bv.eidss.R;
import com.bv.eidss.ReferenciesProvider;
import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.BaseReference;
import com.bv.eidss.model.BaseReferenceType;
import com.bv.eidss.model.CaseTypeHACode;
import com.bv.eidss.model.HumanCase;
import com.bv.eidss.model.VetCase;
import com.bv.eidss.model.ASSession;
import android.content.Intent;
import android.widget.Spinner;
import com.bv.eidss.model.Species;
import com.bv.eidss.model.Animal;
import com.bv.eidss.model.ASDisease;
import com.bv.eidss.model.ASSample;
import com.bv.eidss.model.Farm;
import com.bv.eidss.model.HumanCaseSample;
import com.bv.eidss.model.VetCaseSample;
import com.bv.eidss.utils.DateHelpers;
import com.bv.eidss.utils.EidssUtils;
import com.bv.eidss.utils.OnEditTextChangeListener;

import java.util.List;

public class HumanCase_binding
{
    public static final int NO_ACTION_ID = 1034;
    public static final int datCompletionPaperFormDate_DialogID = 1035;
    public static final int datTentativeDiagnosisDate_DialogID = 1036;
    public static final int datDateofBirth_DialogID = 1037;
    public static final int datOnSetDate_DialogID = 1038;
    public static final int datExposureDate_DialogID = 1039;
    public static final int datFirstSoughtCareDate_DialogID = 1040;
    public static final int datHospitalizationDate_DialogID = 1041;

    private static final int LOADER_HumanGender = 1100;
    private static SimpleCursorAdapter adapterHumanGender;
    private static Spinner spinnerHumanGender;
    private static final int LOADER_PersonIDType = 1101;
    private static SimpleCursorAdapter adapterPersonIDType;
    private static Spinner spinnerPersonIDType;
    private static final int LOADER_Nationality = 1102;
    private static SimpleCursorAdapter adapterNationality;
    private static Spinner spinnerNationality;
    private static final int LOADER_FinalState = 1103;
    private static SimpleCursorAdapter adapterFinalState;
    private static Spinner spinnerFinalState;
    private static final int LOADER_HospitalizationStatus = 1104;
    private static SimpleCursorAdapter adapterHospitalizationStatus;
    private static Spinner spinnerHospitalizationStatus;
    private static final int LOADER_InitialCaseStatus = 1105;
    private static SimpleCursorAdapter adapterInitialCaseStatus;
    private static Spinner spinnerInitialCaseStatus;
    private static final int LOADER_YNHospitalization = 1106;
    private static SimpleCursorAdapter adapterYNHospitalization;
    private static Spinner spinnerYNHospitalization;
    private static final int LOADER_YNSpecimenCollected = 1107;
    private static SimpleCursorAdapter adapterYNSpecimenCollected;
    private static Spinner spinnerYNSpecimenCollected;

    private static com.bv.eidss.GeoLocationHelper mLocationService;

    public static void Bind(final EidssBaseBindableFragment fragment, final View v, final HumanCase mCase, final List<String> mandatoryFields, final List<String> invisibleFields, final String lang, final int page)
    {
        
        if (page == 0)
        {
        fragment.EditTextBind(R.id.strCaseID, v, mCase.getCaseID(), null, false, null, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strLocalIdentifier, v, mCase.getLocalIdentifier(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setLocalIdentifier(text);
                }
            }, true, HumanCase.eidss_LocalIdentifier, mandatoryFields, invisibleFields);
        
        fragment.DateBind(R.id.datCompletionPaperFormDate, v, R.id.datCompletionPaperFormDateClearButton,
            new View.OnClickListener() {
                @Override
                public void onClick(View arg0) {
                    com.bv.eidss.EidssAndroidHelpers.DatePickerFragment.Show(fragment.getActivity().getSupportFragmentManager(), datCompletionPaperFormDate_DialogID, null, mCase.getCompletionPaperFormDate());
                }
            },
            new View.OnClickListener() {
                @Override
                public void onClick(View arg0) {
                    mCase.setCompletionPaperFormDate(null);
                    DateHelpers.DisplayDate(R.id.datCompletionPaperFormDate, v, mCase.getCompletionPaperFormDate());
                }
            }, mCase.getCompletionPaperFormDate(), null, mandatoryFields, invisibleFields);
        
        
        fragment.DateBind(R.id.datTentativeDiagnosisDate, v, R.id.datTentativeDiagnosisDateClearButton,
            new View.OnClickListener() {
                @Override
                public void onClick(View arg0) {
                    com.bv.eidss.EidssAndroidHelpers.DatePickerFragment.Show(fragment.getActivity().getSupportFragmentManager(), datTentativeDiagnosisDate_DialogID, null, mCase.getTentativeDiagnosisDate());
                }
            },
            new View.OnClickListener() {
                @Override
                public void onClick(View arg0) {
                    mCase.setTentativeDiagnosisDate(null);
                    DateHelpers.DisplayDate(R.id.datTentativeDiagnosisDate, v, mCase.getTentativeDiagnosisDate());
                }
            }, mCase.getTentativeDiagnosisDate(), HumanCase.eidss_TentativeDiagnosisDate, mandatoryFields, invisibleFields);
        
        fragment.DateBind(R.id.datNotificationDate, v, 0, null, null,
            mCase.getNotificationDate(), HumanCase.eidss_NotificationDate, mandatoryFields, invisibleFields);
        
        fragment.LookupBindReadonly(R.id.idfSentByOffice, v, ReferenciesProvider.CONTENT_URI, mCase.getSentByOffice(), HumanCase.eidss_SentByOffice, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strSentByPerson, v, mCase.getSentByPerson(), null, false, HumanCase.eidss_SentByPerson, mandatoryFields, invisibleFields);
        
        fragment.LookupBindReadonly(R.id.idfReceivedByOffice, v, ReferenciesProvider.CONTENT_URI, mCase.getReceivedByOffice(), HumanCase.eidss_ReceivedByOffice, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strReceivedByPerson, v, mCase.getReceivedByPerson(), null, false, HumanCase.eidss_ReceivedByPerson, mandatoryFields, invisibleFields);
        
        fragment.LookupBindReadonly(R.id.idfInvestigatedByOffice, v, ReferenciesProvider.CONTENT_URI, mCase.getInvestigatedByOffice(), HumanCase.eidss_InvestigatedByOffice, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strEpidemiologistsName, v, mCase.getEpidemiologistsName(), null, false, HumanCase.eidss_EpidemiologistsName, mandatoryFields, invisibleFields);
        
        fragment.DateBind(R.id.datInvestigationStartDate, v, 0, null, null,
            mCase.getInvestigationStartDate(), HumanCase.eidss_InvestigationStartDate, mandatoryFields, invisibleFields);
        
        }
        if (page == 1)
        {
        fragment.EditTextBind(R.id.strFamilyName, v, mCase.getFamilyName(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setFamilyName(text);
                }
            }, true, HumanCase.eidss_FamilyName, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strFirstName, v, mCase.getFirstName(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setFirstName(text);
                }
            }, true, HumanCase.eidss_FirstName, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strSecondName, v, mCase.getSecondName(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setSecondName(text);
                }
            }, true, HumanCase.eidss_SecondName, mandatoryFields, invisibleFields);
        
        
        
        
        spinnerHumanGender = (Spinner)v.findViewById(R.id.idfsHumanGender);
        adapterHumanGender = fragment.LookupBind(spinnerHumanGender, v, ReferenciesProvider.NAME,
            new AdapterView.OnItemSelectedListener(){
                public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                    if (mCase.getHumanGender() != id)
                      mCase.setHumanGender(id);
                }
                public void onNothingSelected(AdapterView<?> arg0) {
                    mCase.setHumanGender(0);
                }
            }, 
            HumanCase.eidss_HumanGender, mandatoryFields, invisibleFields);
        if (adapterHumanGender != null)
            fragment.getActivity().getSupportLoaderManager().initLoader(LOADER_HumanGender, null, (HumanCaseFragment)fragment);
        
        spinnerPersonIDType = (Spinner)v.findViewById(R.id.idfsPersonIDType);
        adapterPersonIDType = fragment.LookupBind(spinnerPersonIDType, v, ReferenciesProvider.NAME,
            new AdapterView.OnItemSelectedListener(){
                public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                    if (mCase.getPersonIDType() != id)
                      mCase.setPersonIDType(id);
                }
                public void onNothingSelected(AdapterView<?> arg0) {
                    mCase.setPersonIDType(0);
                }
            }, 
            HumanCase.eidss_PersonIDType, mandatoryFields, invisibleFields);
        if (adapterPersonIDType != null)
            fragment.getActivity().getSupportLoaderManager().initLoader(LOADER_PersonIDType, null, (HumanCaseFragment)fragment);
        
        fragment.EditTextBind(R.id.strPersonID, v, mCase.getPersonID(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setPersonID(text);
                }
            }, true, HumanCase.eidss_PersonID, mandatoryFields, invisibleFields);
        
        spinnerNationality = (Spinner)v.findViewById(R.id.idfsNationality);
        adapterNationality = fragment.LookupBind(spinnerNationality, v, ReferenciesProvider.NAME,
            new AdapterView.OnItemSelectedListener(){
                public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                    if (mCase.getNationality() != id)
                      mCase.setNationality(id);
                }
                public void onNothingSelected(AdapterView<?> arg0) {
                    mCase.setNationality(0);
                }
            }, 
            HumanCase.eidss_Nationality, mandatoryFields, invisibleFields);
        if (adapterNationality != null)
            fragment.getActivity().getSupportLoaderManager().initLoader(LOADER_Nationality, null, (HumanCaseFragment)fragment);
        
        }
        if (page == 2)
        {
        
        
        
        fragment.EditTextBind(R.id.strStreetName, v, mCase.getStreetName(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setStreetName(text);
                }
            }, true, HumanCase.eidss_StreetName, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strBuilding, v, mCase.getBuilding(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setBuilding(text);
                }
            }, true, HumanCase.eidss_Building, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strHouse, v, mCase.getHouse(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setHouse(text);
                }
            }, true, HumanCase.eidss_House, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strApartment, v, mCase.getApartment(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setApartment(text);
                }
            }, true, HumanCase.eidss_Apartment, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strPostCode, v, mCase.getPostCode(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setPostCode(text);
                }
            }, true, HumanCase.eidss_PostCode, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.dblLongitude, v, mCase.getLongitude() == 0 ? "" : String.valueOf(mCase.getLongitude()), new OnEditTextChangeListener(){
            public void onEditTextChanged(String text) {
             if (text.trim().length() == 0)
             mCase.setLongitude( 0d );
             else {
             try { mCase.setLongitude(Double.parseDouble(text)); } 
             catch (NumberFormatException e) { }
             }
             }}, true, HumanCase.eidss_Longitude, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.dblLatitude, v, mCase.getLatitude() == 0 ? "" : String.valueOf(mCase.getLatitude()), new OnEditTextChangeListener(){
            public void onEditTextChanged(String text) {
             if (text.trim().length() == 0)
             mCase.setLatitude( 0d );
             else {
             try { mCase.setLatitude(Double.parseDouble(text)); } 
             catch (NumberFormatException e) { }
             }
             }}, true, HumanCase.eidss_Latitude, mandatoryFields, invisibleFields);
        
        v.findViewById(R.id.GetCoordinatesButton).setOnClickListener(new View.OnClickListener()
        {
            public void onClick(View v) {
            if (mLocationService == null)
                mLocationService = new com.bv.eidss.GeoLocationHelper();
            if (!mLocationService.getLocation(fragment.getActivity(), (com.bv.eidss.model.interfaces.LocationResultListener)fragment))
                com.bv.eidss.EidssAndroidHelpers.AlertOkResultDialog.ShowWarning(fragment.getActivity().getSupportFragmentManager(), NO_ACTION_ID, R.string.LocationProvidersUnavailable);
            }
        });
        
        fragment.EditTextBind(R.id.strHomePhone, v, mCase.getHomePhone(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setHomePhone(text);
                }
            }, true, HumanCase.eidss_HomePhone, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strPermanentResidencePhone, v, mCase.getPermanentResidencePhone(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setPermanentResidencePhone(text);
                }
            }, true, HumanCase.eidss_PermanentResidencePhone, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strEmployerName, v, mCase.getEmployerName(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setEmployerName(text);
                }
            }, true, HumanCase.eidss_EmployerName, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strWorkPhone, v, mCase.getWorkPhone(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setWorkPhone(text);
                }
            }, true, HumanCase.eidss_WorkPhone, mandatoryFields, invisibleFields);
        
        }
        if (page == 3)
        {
        spinnerFinalState = (Spinner)v.findViewById(R.id.idfsFinalState);
        adapterFinalState = fragment.LookupBind(spinnerFinalState, v, ReferenciesProvider.NAME,
            new AdapterView.OnItemSelectedListener(){
                public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                    if (mCase.getFinalState() != id)
                      mCase.setFinalState(id);
                }
                public void onNothingSelected(AdapterView<?> arg0) {
                    mCase.setFinalState(0);
                }
            }, 
            HumanCase.eidss_FinalState, mandatoryFields, invisibleFields);
        if (adapterFinalState != null)
            fragment.getActivity().getSupportLoaderManager().initLoader(LOADER_FinalState, null, (HumanCaseFragment)fragment);
        
        spinnerHospitalizationStatus = (Spinner)v.findViewById(R.id.idfsHospitalizationStatus);
        adapterHospitalizationStatus = fragment.LookupBind(spinnerHospitalizationStatus, v, ReferenciesProvider.NAME,
            new AdapterView.OnItemSelectedListener(){
                public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                    if (mCase.getHospitalizationStatus() != id)
                      mCase.setHospitalizationStatus(id);
                }
                public void onNothingSelected(AdapterView<?> arg0) {
                    mCase.setHospitalizationStatus(0);
                }
            }, 
            HumanCase.eidss_HospitalizationStatus, mandatoryFields, invisibleFields);
        if (adapterHospitalizationStatus != null)
            fragment.getActivity().getSupportLoaderManager().initLoader(LOADER_HospitalizationStatus, null, (HumanCaseFragment)fragment);
        
        
        spinnerInitialCaseStatus = (Spinner)v.findViewById(R.id.idfsInitialCaseStatus);
        adapterInitialCaseStatus = fragment.LookupBind(spinnerInitialCaseStatus, v, ReferenciesProvider.NAME,
            new AdapterView.OnItemSelectedListener(){
                public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                    if (mCase.getInitialCaseStatus() != id)
                      mCase.setInitialCaseStatus(id);
                }
                public void onNothingSelected(AdapterView<?> arg0) {
                    mCase.setInitialCaseStatus(0);
                }
            }, 
            HumanCase.eidss_InitialCaseStatus, mandatoryFields, invisibleFields);
        if (adapterInitialCaseStatus != null)
            fragment.getActivity().getSupportLoaderManager().initLoader(LOADER_InitialCaseStatus, null, (HumanCaseFragment)fragment);
        
        fragment.DateBind(R.id.datOnSetDate, v, R.id.datOnSetDateClearButton,
            new View.OnClickListener() {
                @Override
                public void onClick(View arg0) {
                    com.bv.eidss.EidssAndroidHelpers.DatePickerFragment.Show(fragment.getActivity().getSupportFragmentManager(), datOnSetDate_DialogID, null, mCase.getOnSetDate());
                }
            },
            new View.OnClickListener() {
                @Override
                public void onClick(View arg0) {
                    mCase.setOnSetDate(null);
                    DateHelpers.DisplayDate(R.id.datOnSetDate, v, mCase.getOnSetDate());
                }
            }, mCase.getOnSetDate(), HumanCase.eidss_OnSetDate, mandatoryFields, invisibleFields);
        
        fragment.DateBind(R.id.datExposureDate, v, R.id.datExposureDateClearButton,
            new View.OnClickListener() {
                @Override
                public void onClick(View arg0) {
                    com.bv.eidss.EidssAndroidHelpers.DatePickerFragment.Show(fragment.getActivity().getSupportFragmentManager(), datExposureDate_DialogID, null, mCase.getExposureDate());
                }
            },
            new View.OnClickListener() {
                @Override
                public void onClick(View arg0) {
                    mCase.setExposureDate(null);
                    DateHelpers.DisplayDate(R.id.datExposureDate, v, mCase.getExposureDate());
                }
            }, mCase.getExposureDate(), HumanCase.eidss_ExposureDate, mandatoryFields, invisibleFields);
        
        
        fragment.DateBind(R.id.datFirstSoughtCareDate, v, R.id.datFirstSoughtCareDateClearButton,
            new View.OnClickListener() {
                @Override
                public void onClick(View arg0) {
                    com.bv.eidss.EidssAndroidHelpers.DatePickerFragment.Show(fragment.getActivity().getSupportFragmentManager(), datFirstSoughtCareDate_DialogID, null, mCase.getFirstSoughtCareDate());
                }
            },
            new View.OnClickListener() {
                @Override
                public void onClick(View arg0) {
                    mCase.setFirstSoughtCareDate(null);
                    DateHelpers.DisplayDate(R.id.datFirstSoughtCareDate, v, mCase.getFirstSoughtCareDate());
                }
            }, mCase.getFirstSoughtCareDate(), HumanCase.eidss_FirstSoughtCareDate, mandatoryFields, invisibleFields);
        
        spinnerYNHospitalization = (Spinner)v.findViewById(R.id.idfsYNHospitalization);
        adapterYNHospitalization = fragment.LookupBind(spinnerYNHospitalization, v, ReferenciesProvider.NAME,
            new AdapterView.OnItemSelectedListener(){
                public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                    if (mCase.getYNHospitalization() != id)
                      mCase.setYNHospitalization(id);
                }
                public void onNothingSelected(AdapterView<?> arg0) {
                    mCase.setYNHospitalization(0);
                }
            }, 
            HumanCase.eidss_YNHospitalization, mandatoryFields, invisibleFields);
        if (adapterYNHospitalization != null)
            fragment.getActivity().getSupportLoaderManager().initLoader(LOADER_YNHospitalization, null, (HumanCaseFragment)fragment);
        
        fragment.EditTextBind(R.id.strHospitalizationPlace, v, mCase.getHospitalizationPlace(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setHospitalizationPlace(text);
                }
            }, true, HumanCase.eidss_HospitalizationPlace, mandatoryFields, invisibleFields);
        
        fragment.DateBind(R.id.datHospitalizationDate, v, R.id.datHospitalizationDateClearButton,
            new View.OnClickListener() {
                @Override
                public void onClick(View arg0) {
                    com.bv.eidss.EidssAndroidHelpers.DatePickerFragment.Show(fragment.getActivity().getSupportFragmentManager(), datHospitalizationDate_DialogID, null, mCase.getHospitalizationDate());
                }
            },
            new View.OnClickListener() {
                @Override
                public void onClick(View arg0) {
                    mCase.setHospitalizationDate(null);
                    DateHelpers.DisplayDate(R.id.datHospitalizationDate, v, mCase.getHospitalizationDate());
                }
            }, mCase.getHospitalizationDate(), HumanCase.eidss_HospitalizationDate, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strComment, v, mCase.getComment(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setComment(text);
                }
            }, true, HumanCase.eidss_Comment, mandatoryFields, invisibleFields);
        
        spinnerYNSpecimenCollected = (Spinner)v.findViewById(R.id.idfsYNSpecimenCollected);
        adapterYNSpecimenCollected = fragment.LookupBind(spinnerYNSpecimenCollected, v, ReferenciesProvider.NAME,
            new AdapterView.OnItemSelectedListener(){
                public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                    if (mCase.getYNSpecimenCollected() != id)
                      mCase.setYNSpecimenCollected(id);
                }
                public void onNothingSelected(AdapterView<?> arg0) {
                    mCase.setYNSpecimenCollected(0);
                }
            }, 
            HumanCase.eidss_YNSpecimenCollected, mandatoryFields, invisibleFields);
        if (adapterYNSpecimenCollected != null)
            fragment.getActivity().getSupportLoaderManager().initLoader(LOADER_YNSpecimenCollected, null, (HumanCaseFragment)fragment);
        
        
        fragment.LookupBindReadonly(R.id.idfsYNTestsConducted, v, ReferenciesProvider.CONTENT_URI, mCase.getYNTestsConducted(), HumanCase.eidss_YNTestsConducted, mandatoryFields, invisibleFields);
        
        }
        if (page == 4)
        {
        fragment.LookupBindReadonly(R.id.idfsFinalCaseStatus, v, ReferenciesProvider.CONTENT_URI, mCase.getFinalCaseStatus(), HumanCase.eidss_FinalCaseStatus, mandatoryFields, invisibleFields);
        
        fragment.DateBind(R.id.datFinalCaseClassificationDate, v, 0, null, null,
            mCase.getFinalCaseClassificationDate(), HumanCase.eidss_FinalCaseClassificationDate, mandatoryFields, invisibleFields);
        
        fragment.LookupBindReadonly(R.id.idfsFinalDiagnosis, v, ReferenciesProvider.CONTENT_URI, mCase.getFinalDiagnosis(), HumanCase.eidss_FinalDiagnosis, mandatoryFields, invisibleFields);
        
        fragment.DateBind(R.id.datFinalDiagnosisDate, v, 0, null, null,
            mCase.getFinalDiagnosisDate(), HumanCase.eidss_FinalDiagnosisDate, mandatoryFields, invisibleFields);
        
        fragment.BooleanBindReadOnly(R.id.blnClinicalDiagBasis, v, mCase.getClinicalDiagBasis(), HumanCase.eidss_ClinicalDiagBasis, mandatoryFields, invisibleFields);
        
        fragment.BooleanBindReadOnly(R.id.blnEpiDiagBasis, v, mCase.getEpiDiagBasis(), HumanCase.eidss_EpiDiagBasis, mandatoryFields, invisibleFields);
        
        fragment.BooleanBindReadOnly(R.id.blnLabDiagBasis, v, mCase.getLabDiagBasis(), HumanCase.eidss_LabDiagBasis, mandatoryFields, invisibleFields);
        
        fragment.LookupBindReadonly(R.id.idfsOutcome, v, ReferenciesProvider.CONTENT_URI, mCase.getOutcome(), HumanCase.eidss_Outcome, mandatoryFields, invisibleFields);
        
        fragment.LookupBindReadonly(R.id.idfsYNRelatedToOutbreak, v, ReferenciesProvider.CONTENT_URI, mCase.getYNRelatedToOutbreak(), HumanCase.eidss_YNRelatedToOutbreak, mandatoryFields, invisibleFields);
        }
    }

    public static Loader<Cursor> onCreateLoader(final int id, final String lang, final HumanCase mCase, Context context)
    {
        String[] sels;
        switch (id)
        {
                case LOADER_HumanGender:
                        sels = new String[3];
                        sels[0] = lang;
                        sels[1] = String.valueOf(BaseReferenceType.rftHumanGender);
                        sels[2] = String.valueOf(mCase.getHumanGender());
                        return new CursorLoader(context, ReferenciesProvider.CONTENT_URI, null, null, sels, null);
                case LOADER_PersonIDType:
                        sels = new String[3];
                        sels[0] = lang;
                        sels[1] = String.valueOf(BaseReferenceType.rftPersonIDType);
                        sels[2] = String.valueOf(mCase.getPersonIDType());
                        return new CursorLoader(context, ReferenciesProvider.CONTENT_URI, null, null, sels, null);
                case LOADER_Nationality:
                        sels = new String[3];
                        sels[0] = lang;
                        sels[1] = String.valueOf(BaseReferenceType.rftNationality);
                        sels[2] = String.valueOf(mCase.getNationality());
                        return new CursorLoader(context, ReferenciesProvider.CONTENT_URI, null, null, sels, null);
                case LOADER_FinalState:
                        sels = new String[3];
                        sels[0] = lang;
                        sels[1] = String.valueOf(BaseReferenceType.rftFinalState);
                        sels[2] = String.valueOf(mCase.getFinalState());
                        return new CursorLoader(context, ReferenciesProvider.CONTENT_URI, null, null, sels, null);
                case LOADER_HospitalizationStatus:
                        sels = new String[3];
                        sels[0] = lang;
                        sels[1] = String.valueOf(BaseReferenceType.rftHospStatus);
                        sels[2] = String.valueOf(mCase.getHospitalizationStatus());
                        return new CursorLoader(context, ReferenciesProvider.CONTENT_URI, null, null, sels, null);
                case LOADER_InitialCaseStatus:
                        sels = new String[5];
                        sels[0] = lang;
                        sels[1] = String.valueOf(BaseReferenceType.rftCaseClassification);
                        sels[2] = String.valueOf(CaseTypeHACode.HUMAN);
                        sels[3] = String.valueOf(1);
                        sels[4] = String.valueOf(mCase.getInitialCaseStatus());
                        return new CursorLoader(context, ReferenciesProvider.CONTENT_URI, null, null, sels, null);
                case LOADER_YNHospitalization:
                        sels = new String[3];
                        sels[0] = lang;
                        sels[1] = String.valueOf(BaseReferenceType.rftYesNoValue);
                        sels[2] = String.valueOf(mCase.getYNHospitalization());
                        return new CursorLoader(context, ReferenciesProvider.CONTENT_URI, null, null, sels, null);
                case LOADER_YNSpecimenCollected:
                        sels = new String[3];
                        sels[0] = lang;
                        sels[1] = String.valueOf(BaseReferenceType.rftYesNoValue);
                        sels[2] = String.valueOf(mCase.getYNSpecimenCollected());
                        return new CursorLoader(context, ReferenciesProvider.CONTENT_URI, null, null, sels, null);
            default:
                return null;
        }
    }

    public static void onLoadFinished(final int id, Cursor data, final HumanCase mCase)
    {
        switch (id)
        {
                case LOADER_HumanGender:
                        onLoadFinishedHumanGender(data, mCase);
                        break;
                case LOADER_PersonIDType:
                        onLoadFinishedPersonIDType(data, mCase);
                        break;
                case LOADER_Nationality:
                        onLoadFinishedNationality(data, mCase);
                        break;
                case LOADER_FinalState:
                        onLoadFinishedFinalState(data, mCase);
                        break;
                case LOADER_HospitalizationStatus:
                        onLoadFinishedHospitalizationStatus(data, mCase);
                        break;
                case LOADER_InitialCaseStatus:
                        onLoadFinishedInitialCaseStatus(data, mCase);
                        break;
                case LOADER_YNHospitalization:
                        onLoadFinishedYNHospitalization(data, mCase);
                        break;
                case LOADER_YNSpecimenCollected:
                        onLoadFinishedYNSpecimenCollected(data, mCase);
                        break;
            default:
                break;
        }
    }

    public static void onLoaderReset(final int id) {
        switch (id)
        {
                case LOADER_HumanGender:
                        adapterHumanGender.swapCursor(null);
                        break;
                case LOADER_PersonIDType:
                        adapterPersonIDType.swapCursor(null);
                        break;
                case LOADER_Nationality:
                        adapterNationality.swapCursor(null);
                        break;
                case LOADER_FinalState:
                        adapterFinalState.swapCursor(null);
                        break;
                case LOADER_HospitalizationStatus:
                        adapterHospitalizationStatus.swapCursor(null);
                        break;
                case LOADER_InitialCaseStatus:
                        adapterInitialCaseStatus.swapCursor(null);
                        break;
                case LOADER_YNHospitalization:
                        adapterYNHospitalization.swapCursor(null);
                        break;
                case LOADER_YNSpecimenCollected:
                        adapterYNSpecimenCollected.swapCursor(null);
                        break;
            default:
                break;
        }
    }

    private static void onLoadFinishedHumanGender(Cursor data, final HumanCase mCase)
    {
        adapterHumanGender.swapCursor(data);
        int rowCount = data.getCount();
        if (rowCount > 1)
        {
            // set selected
            int cpos = 0;
            for (int i = 0; i < rowCount; i++){
                data.moveToPosition(i);
                long temp = data.getLong(0);
                if (temp == mCase.getHumanGender())
                {
                    cpos = i;
                    break;
                }
            }
            spinnerHumanGender.setSelection(cpos);
            spinnerHumanGender.setEnabled(true);
        }
        else
        {
            spinnerHumanGender.setEnabled(false);
        }
    }
    private static void onLoadFinishedPersonIDType(Cursor data, final HumanCase mCase)
    {
        adapterPersonIDType.swapCursor(data);
        int rowCount = data.getCount();
        if (rowCount > 1)
        {
            // set selected
            int cpos = 0;
            for (int i = 0; i < rowCount; i++){
                data.moveToPosition(i);
                long temp = data.getLong(0);
                if (temp == mCase.getPersonIDType())
                {
                    cpos = i;
                    break;
                }
            }
            spinnerPersonIDType.setSelection(cpos);
            spinnerPersonIDType.setEnabled(true);
        }
        else
        {
            spinnerPersonIDType.setEnabled(false);
        }
    }
    private static void onLoadFinishedNationality(Cursor data, final HumanCase mCase)
    {
        adapterNationality.swapCursor(data);
        int rowCount = data.getCount();
        if (rowCount > 1)
        {
            // set selected
            int cpos = 0;
            for (int i = 0; i < rowCount; i++){
                data.moveToPosition(i);
                long temp = data.getLong(0);
                if (temp == mCase.getNationality())
                {
                    cpos = i;
                    break;
                }
            }
            spinnerNationality.setSelection(cpos);
            spinnerNationality.setEnabled(true);
        }
        else
        {
            spinnerNationality.setEnabled(false);
        }
    }
    private static void onLoadFinishedFinalState(Cursor data, final HumanCase mCase)
    {
        adapterFinalState.swapCursor(data);
        int rowCount = data.getCount();
        if (rowCount > 1)
        {
            // set selected
            int cpos = 0;
            for (int i = 0; i < rowCount; i++){
                data.moveToPosition(i);
                long temp = data.getLong(0);
                if (temp == mCase.getFinalState())
                {
                    cpos = i;
                    break;
                }
            }
            spinnerFinalState.setSelection(cpos);
            spinnerFinalState.setEnabled(true);
        }
        else
        {
            spinnerFinalState.setEnabled(false);
        }
    }
    private static void onLoadFinishedHospitalizationStatus(Cursor data, final HumanCase mCase)
    {
        adapterHospitalizationStatus.swapCursor(data);
        int rowCount = data.getCount();
        if (rowCount > 1)
        {
            // set selected
            int cpos = 0;
            for (int i = 0; i < rowCount; i++){
                data.moveToPosition(i);
                long temp = data.getLong(0);
                if (temp == mCase.getHospitalizationStatus())
                {
                    cpos = i;
                    break;
                }
            }
            spinnerHospitalizationStatus.setSelection(cpos);
            spinnerHospitalizationStatus.setEnabled(true);
        }
        else
        {
            spinnerHospitalizationStatus.setEnabled(false);
        }
    }
    private static void onLoadFinishedInitialCaseStatus(Cursor data, final HumanCase mCase)
    {
        adapterInitialCaseStatus.swapCursor(data);
        int rowCount = data.getCount();
        if (rowCount > 1)
        {
            // set selected
            int cpos = 0;
            for (int i = 0; i < rowCount; i++){
                data.moveToPosition(i);
                long temp = data.getLong(0);
                if (temp == mCase.getInitialCaseStatus())
                {
                    cpos = i;
                    break;
                }
            }
            spinnerInitialCaseStatus.setSelection(cpos);
            spinnerInitialCaseStatus.setEnabled(true);
        }
        else
        {
            spinnerInitialCaseStatus.setEnabled(false);
        }
    }
    private static void onLoadFinishedYNHospitalization(Cursor data, final HumanCase mCase)
    {
        adapterYNHospitalization.swapCursor(data);
        int rowCount = data.getCount();
        if (rowCount > 1)
        {
            // set selected
            int cpos = 0;
            for (int i = 0; i < rowCount; i++){
                data.moveToPosition(i);
                long temp = data.getLong(0);
                if (temp == mCase.getYNHospitalization())
                {
                    cpos = i;
                    break;
                }
            }
            spinnerYNHospitalization.setSelection(cpos);
            spinnerYNHospitalization.setEnabled(true);
        }
        else
        {
            spinnerYNHospitalization.setEnabled(false);
        }
    }
    private static void onLoadFinishedYNSpecimenCollected(Cursor data, final HumanCase mCase)
    {
        adapterYNSpecimenCollected.swapCursor(data);
        int rowCount = data.getCount();
        if (rowCount > 1)
        {
            // set selected
            int cpos = 0;
            for (int i = 0; i < rowCount; i++){
                data.moveToPosition(i);
                long temp = data.getLong(0);
                if (temp == mCase.getYNSpecimenCollected())
                {
                    cpos = i;
                    break;
                }
            }
            spinnerYNSpecimenCollected.setSelection(cpos);
            spinnerYNSpecimenCollected.setEnabled(true);
        }
        else
        {
            spinnerYNSpecimenCollected.setEnabled(false);
        }
    }
}
