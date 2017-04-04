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

public class Species_binding
{
    public static final int NO_ACTION_ID = 1000;
    public static final int datStartOfSignsDate_DialogID = 1001;


    public static void Bind(final EidssBaseBindableFragment fragment, final View v, final Species mCase, final List<String> mandatoryFields, final List<String> invisibleFields, final String lang, final int page)
    {
        
        if (page == 0)
        {
        
        fragment.EditTextBind(R.id.intTotalAnimalQty, v, mCase.getTotalAnimalQty() == 0 ? "" : String.valueOf(mCase.getTotalAnimalQty()), new OnEditTextChangeListener(){
            public void onEditTextChanged(String text) {
             if (text.trim().length() == 0)
             mCase.setTotalAnimalQty( 0 );
             else {
             try { mCase.setTotalAnimalQty(Integer.parseInt(text)); } 
             catch (NumberFormatException e) { }
             }
             }}, true, Species.eidss_TotalAnimalQty, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.intDeadAnimalQty, v, mCase.getDeadAnimalQty() == 0 ? "" : String.valueOf(mCase.getDeadAnimalQty()), new OnEditTextChangeListener(){
            public void onEditTextChanged(String text) {
             if (text.trim().length() == 0)
             mCase.setDeadAnimalQty( 0 );
             else {
             try { mCase.setDeadAnimalQty(Integer.parseInt(text)); } 
             catch (NumberFormatException e) { }
             }
             }}, true, Species.eidss_DeadAnimalQty, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.intSickAnimalQty, v, mCase.getSickAnimalQty() == 0 ? "" : String.valueOf(mCase.getSickAnimalQty()), new OnEditTextChangeListener(){
            public void onEditTextChanged(String text) {
             if (text.trim().length() == 0)
             mCase.setSickAnimalQty( 0 );
             else {
             try { mCase.setSickAnimalQty(Integer.parseInt(text)); } 
             catch (NumberFormatException e) { }
             }
             }}, true, Species.eidss_SickAnimalQty, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strNote, v, mCase.getNote(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setNote(text);
                }
            }, true, Species.eidss_Note, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.intAverageAge, v, mCase.getAverageAge() == 0 ? "" : String.valueOf(mCase.getAverageAge()), new OnEditTextChangeListener(){
            public void onEditTextChanged(String text) {
             if (text.trim().length() == 0)
             mCase.setAverageAge( 0 );
             else {
             try { mCase.setAverageAge(Integer.parseInt(text)); } 
             catch (NumberFormatException e) { }
             }
             }}, true, Species.eidss_AverageAge, mandatoryFields, invisibleFields);
        
        fragment.DateBind(R.id.datStartOfSignsDate, v, R.id.datStartOfSignsDateClearButton,
            new View.OnClickListener() {
                @Override
                public void onClick(View arg0) {
                    com.bv.eidss.EidssAndroidHelpers.DatePickerFragment.Show(fragment.getActivity().getSupportFragmentManager(), datStartOfSignsDate_DialogID, null, mCase.getStartOfSignsDate());
                }
            },
            new View.OnClickListener() {
                @Override
                public void onClick(View arg0) {
                    mCase.setStartOfSignsDate(null);
                    DateHelpers.DisplayDate(R.id.datStartOfSignsDate, v, mCase.getStartOfSignsDate());
                }
            }, mCase.getStartOfSignsDate(), Species.eidss_StartOfSignsDate, mandatoryFields, invisibleFields);
        }
    }

    public static Loader<Cursor> onCreateLoader(final int id, final String lang, final Species mCase, Context context)
    {
        String[] sels;
        switch (id)
        {
            default:
                return null;
        }
    }

    public static void onLoadFinished(final int id, Cursor data, final Species mCase)
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
