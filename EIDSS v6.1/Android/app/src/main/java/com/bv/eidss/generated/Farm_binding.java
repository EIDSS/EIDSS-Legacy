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

public class Farm_binding
{
    public static final int NO_ACTION_ID = 1033;


    private static com.bv.eidss.GeoLocationHelper mLocationService;

    public static void Bind(final EidssBaseBindableFragment fragment, final View v, final Farm mCase, final List<String> mandatoryFields, final List<String> invisibleFields, final String lang, final int page)
    {
        
        if (page == 0)
        {
        fragment.EditTextBind(R.id.strFarmCode, v, mCase.getFarmCode(), null, false, Farm.eidss_FarmCode, mandatoryFields, invisibleFields);
        
        
        fragment.EditTextBind(R.id.strOwnerLastName, v, mCase.getOwnerLastName(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setOwnerLastName(text);
                }
            }, true, Farm.eidss_OwnerLastName, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strOwnerFirstName, v, mCase.getOwnerFirstName(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setOwnerFirstName(text);
                }
            }, true, Farm.eidss_OwnerFirstName, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strOwnerMiddleName, v, mCase.getOwnerMiddleName(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setOwnerMiddleName(text);
                }
            }, true, Farm.eidss_OwnerMiddleName, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strPhone, v, mCase.getPhone(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setPhone(text);
                }
            }, true, Farm.eidss_Phone, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strFax, v, mCase.getFax(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setFax(text);
                }
            }, true, Farm.eidss_Fax, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strEmail, v, mCase.getEmail(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setEmail(text);
                }
            }, true, Farm.eidss_Email, mandatoryFields, invisibleFields);
        
        
        
        
        fragment.EditTextBind(R.id.strStreetName, v, mCase.getStreetName(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setStreetName(text);
                }
            }, true, Farm.eidss_StreetName, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strBuilding, v, mCase.getBuilding(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setBuilding(text);
                }
            }, true, Farm.eidss_Building, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strHouse, v, mCase.getHouse(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setHouse(text);
                }
            }, true, Farm.eidss_House, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strApartment, v, mCase.getApartment(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setApartment(text);
                }
            }, true, Farm.eidss_Apartment, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strPostCode, v, mCase.getPostCode(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setPostCode(text);
                }
            }, true, Farm.eidss_PostCode, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.dblLongitude, v, mCase.getLongitude() == 0 ? "" : String.valueOf(mCase.getLongitude()), new OnEditTextChangeListener(){
            public void onEditTextChanged(String text) {
             if (text.trim().length() == 0)
             mCase.setLongitude( 0d );
             else {
             try { mCase.setLongitude(Double.parseDouble(text)); } 
             catch (NumberFormatException e) { }
             }
             }}, true, Farm.eidss_Longitude, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.dblLatitude, v, mCase.getLatitude() == 0 ? "" : String.valueOf(mCase.getLatitude()), new OnEditTextChangeListener(){
            public void onEditTextChanged(String text) {
             if (text.trim().length() == 0)
             mCase.setLatitude( 0d );
             else {
             try { mCase.setLatitude(Double.parseDouble(text)); } 
             catch (NumberFormatException e) { }
             }
             }}, true, Farm.eidss_Latitude, mandatoryFields, invisibleFields);
        
        v.findViewById(R.id.GetCoordinatesButton).setOnClickListener(new View.OnClickListener()
        {
            public void onClick(View v) {
            if (mLocationService == null)
                mLocationService = new com.bv.eidss.GeoLocationHelper();
            if (!mLocationService.getLocation(fragment.getActivity(), (com.bv.eidss.model.interfaces.LocationResultListener)fragment))
                com.bv.eidss.EidssAndroidHelpers.AlertOkResultDialog.ShowWarning(fragment.getActivity().getSupportFragmentManager(), NO_ACTION_ID, R.string.LocationProvidersUnavailable);
            }
        });
        }
    }

    public static Loader<Cursor> onCreateLoader(final int id, final String lang, final Farm mCase, Context context)
    {
        String[] sels;
        switch (id)
        {
            default:
                return null;
        }
    }

    public static void onLoadFinished(final int id, Cursor data, final Farm mCase)
    {
        switch (id)
        {
            default:
                break;
        }
    }

    public static void onLoaderReset(final int id) {
        switch (id)
        {
            default:
                break;
        }
    }

}
