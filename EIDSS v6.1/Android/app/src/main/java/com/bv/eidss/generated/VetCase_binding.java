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

public class VetCase_binding
{
    public static final int NO_ACTION_ID = 1047;
    public static final int datTentativeDiagnosisDate_DialogID = 1048;
    public static final int datReportDate_DialogID = 1049;

    private static final int LOADER_CaseReportType = 1100;
    private static SimpleCursorAdapter adapterCaseReportType;
    private static Spinner spinnerCaseReportType;

    private static com.bv.eidss.GeoLocationHelper mLocationService;

    public static void Bind(final EidssBaseBindableFragment fragment, final View v, final VetCase mCase, final List<String> mandatoryFields, final List<String> invisibleFields, final String lang, final int page)
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
            }, true, VetCase.eidss_LocalIdentifier, mandatoryFields, invisibleFields);
        
        spinnerCaseReportType = (Spinner)v.findViewById(R.id.idfsCaseReportType);
        adapterCaseReportType = fragment.LookupBind(spinnerCaseReportType, v, ReferenciesProvider.NAME,
            new AdapterView.OnItemSelectedListener(){
                public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                    if (mCase.getCaseReportType() != id)
                      mCase.setCaseReportType(id);
                }
                public void onNothingSelected(AdapterView<?> arg0) {
                    mCase.setCaseReportType(0);
                }
            }, 
            VetCase.eidss_CaseReportType, mandatoryFields, invisibleFields);
        if (adapterCaseReportType != null)
            fragment.getActivity().getSupportLoaderManager().initLoader(LOADER_CaseReportType, null, (VetCaseFragment)fragment);
        
        
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
            }, mCase.getTentativeDiagnosisDate(), VetCase.eidss_TentativeDiagnosisDate, mandatoryFields, invisibleFields);
        
        fragment.DateBind(R.id.datReportDate, v, R.id.datReportDateClearButton,
            new View.OnClickListener() {
                @Override
                public void onClick(View arg0) {
                    com.bv.eidss.EidssAndroidHelpers.DatePickerFragment.Show(fragment.getActivity().getSupportFragmentManager(), datReportDate_DialogID, null, mCase.getReportDate());
                }
            },
            new View.OnClickListener() {
                @Override
                public void onClick(View arg0) {
                    mCase.setReportDate(null);
                    DateHelpers.DisplayDate(R.id.datReportDate, v, mCase.getReportDate());
                }
            }, mCase.getReportDate(), VetCase.eidss_ReportDate, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strSentByOffice, v, mCase.getSentByOffice(), null, false, VetCase.eidss_SentByOffice, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strSentByPerson, v, mCase.getSentByPerson(), null, false, VetCase.eidss_SentByPerson, mandatoryFields, invisibleFields);
        
        fragment.LookupBindReadonly(R.id.idfInvestigatedByPerson, v, ReferenciesProvider.CONTENT_URI, mCase.getInvestigatedByPerson(), VetCase.eidss_InvestigatedByPerson, mandatoryFields, invisibleFields);
        
        fragment.DateBind(R.id.datAssignedDate, v, 0, null, null,
            mCase.getAssignedDate(), VetCase.eidss_AssignedDate, mandatoryFields, invisibleFields);
        
        fragment.DateBind(R.id.datInvestigationDate, v, 0, null, null,
            mCase.getInvestigationDate(), VetCase.eidss_InvestigationDate, mandatoryFields, invisibleFields);
        
        fragment.LookupBindReadonly(R.id.idfsFinalCaseStatus, v, ReferenciesProvider.CONTENT_URI, mCase.getFinalCaseStatus(), VetCase.eidss_FinalCaseStatus, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strFinalDiagnosis, v, mCase.getFinalDiagnosis(), null, false, VetCase.eidss_FinalDiagnosis, mandatoryFields, invisibleFields);
        
        fragment.DateBind(R.id.datFinalDiagnosisDate, v, 0, null, null,
            mCase.getFinalDiagnosisDate(), VetCase.eidss_FinalDiagnosisDate, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strComment, v, mCase.getComment(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setComment(text);
                }
            }, true, VetCase.eidss_Comment, mandatoryFields, invisibleFields);
        
        fragment.LookupBindReadonly(R.id.idfsYNTestsConducted, v, ReferenciesProvider.CONTENT_URI, mCase.getYNTestsConducted(), VetCase.eidss_YNTestsConducted, mandatoryFields, invisibleFields);
        
        }
        if (page == 1)
        {
        fragment.EditTextBind(R.id.strFarmCode, v, mCase.getFarmCode(), null, false, VetCase.eidss_FarmCode, mandatoryFields, invisibleFields);
        
        
        fragment.EditTextBind(R.id.strOwnerLastName, v, mCase.getOwnerLastName(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setOwnerLastName(text);
                }
            }, true, VetCase.eidss_OwnerLastName, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strOwnerFirstName, v, mCase.getOwnerFirstName(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setOwnerFirstName(text);
                }
            }, true, VetCase.eidss_OwnerFirstName, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strOwnerMiddleName, v, mCase.getOwnerMiddleName(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setOwnerMiddleName(text);
                }
            }, true, VetCase.eidss_OwnerMiddleName, mandatoryFields, invisibleFields);
        
        
        
        
        fragment.EditTextBind(R.id.strStreetName, v, mCase.getStreetName(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setStreetName(text);
                }
            }, true, VetCase.eidss_StreetName, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strBuilding, v, mCase.getBuilding(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setBuilding(text);
                }
            }, true, VetCase.eidss_Building, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strHouse, v, mCase.getHouse(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setHouse(text);
                }
            }, true, VetCase.eidss_House, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strApartment, v, mCase.getApartment(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setApartment(text);
                }
            }, true, VetCase.eidss_Apartment, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strPostCode, v, mCase.getPostCode(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setPostCode(text);
                }
            }, true, VetCase.eidss_PostCode, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.dblLongitude, v, mCase.getLongitude() == 0 ? "" : String.valueOf(mCase.getLongitude()), new OnEditTextChangeListener(){
            public void onEditTextChanged(String text) {
             if (text.trim().length() == 0)
             mCase.setLongitude( 0d );
             else {
             try { mCase.setLongitude(Double.parseDouble(text)); } 
             catch (NumberFormatException e) { }
             }
             }}, true, VetCase.eidss_Longitude, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.dblLatitude, v, mCase.getLatitude() == 0 ? "" : String.valueOf(mCase.getLatitude()), new OnEditTextChangeListener(){
            public void onEditTextChanged(String text) {
             if (text.trim().length() == 0)
             mCase.setLatitude( 0d );
             else {
             try { mCase.setLatitude(Double.parseDouble(text)); } 
             catch (NumberFormatException e) { }
             }
             }}, true, VetCase.eidss_Latitude, mandatoryFields, invisibleFields);
        
        v.findViewById(R.id.GetCoordinatesButton).setOnClickListener(new View.OnClickListener()
        {
            public void onClick(View v) {
            if (mLocationService == null)
                mLocationService = new com.bv.eidss.GeoLocationHelper();
            if (!mLocationService.getLocation(fragment.getActivity(), (com.bv.eidss.model.interfaces.LocationResultListener)fragment))
                com.bv.eidss.EidssAndroidHelpers.AlertOkResultDialog.ShowWarning(fragment.getActivity().getSupportFragmentManager(), NO_ACTION_ID, R.string.LocationProvidersUnavailable);
            }
        });
        
        fragment.EditTextBind(R.id.strPhone, v, mCase.getPhone(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setPhone(text);
                }
            }, true, VetCase.eidss_Phone, mandatoryFields, invisibleFields);
        }
    }

    public static Loader<Cursor> onCreateLoader(final int id, final String lang, final VetCase mCase, Context context)
    {
        String[] sels;
        switch (id)
        {
                case LOADER_CaseReportType:
                        sels = new String[3];
                        sels[0] = lang;
                        sels[1] = String.valueOf(BaseReferenceType.rftCaseReportType);
                        sels[2] = String.valueOf(mCase.getCaseReportType());
                        return new CursorLoader(context, ReferenciesProvider.CONTENT_URI, null, null, sels, null);
            default:
                return null;
        }
    }

    public static void onLoadFinished(final int id, Cursor data, final VetCase mCase)
    {
        switch (id)
        {
                case LOADER_CaseReportType:
                        onLoadFinishedCaseReportType(data, mCase);
                        break;
            default:
                break;
        }
    }

    public static void onLoaderReset(final int id) {
        switch (id)
        {
                case LOADER_CaseReportType:
                        adapterCaseReportType.swapCursor(null);
                        break;
            default:
                break;
        }
    }

    private static void onLoadFinishedCaseReportType(Cursor data, final VetCase mCase)
    {
        adapterCaseReportType.swapCursor(data);
        int rowCount = data.getCount();
        if (rowCount > 1)
        {
            // set selected
            int cpos = 0;
            for (int i = 0; i < rowCount; i++){
                data.moveToPosition(i);
                long temp = data.getLong(0);
                if (temp == mCase.getCaseReportType())
                {
                    cpos = i;
                    break;
                }
            }
            spinnerCaseReportType.setSelection(cpos);
            spinnerCaseReportType.setEnabled(true);
        }
        else
        {
            spinnerCaseReportType.setEnabled(false);
        }
    }
}
