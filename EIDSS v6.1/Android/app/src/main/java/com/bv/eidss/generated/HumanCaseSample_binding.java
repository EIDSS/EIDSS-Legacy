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

public class HumanCaseSample_binding
{
    public static final int NO_ACTION_ID = 1042;
    public static final int datFieldCollectionDate_DialogID = 1043;
    public static final int datFieldSentDate_DialogID = 1044;


    public static void Bind(final EidssBaseBindableFragment fragment, final View v, final HumanCaseSample mCase, final List<String> mandatoryFields, final List<String> invisibleFields, final String lang, final int page)
    {
        
        if (page == 0)
        {
        
        fragment.EditTextBind(R.id.strFieldBarcode, v, mCase.getFieldBarcode(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setFieldBarcode(text);
                }
            }, true, HumanCaseSample.eidss_FieldBarcode, mandatoryFields, invisibleFields);
        
        fragment.DateBind(R.id.datFieldCollectionDate, v, R.id.datFieldCollectionDateClearButton,
            new View.OnClickListener() {
                @Override
                public void onClick(View arg0) {
                    com.bv.eidss.EidssAndroidHelpers.DatePickerFragment.Show(fragment.getActivity().getSupportFragmentManager(), datFieldCollectionDate_DialogID, null, mCase.getFieldCollectionDate());
                }
            },
            new View.OnClickListener() {
                @Override
                public void onClick(View arg0) {
                    mCase.setFieldCollectionDate(null);
                    DateHelpers.DisplayDate(R.id.datFieldCollectionDate, v, mCase.getFieldCollectionDate());
                }
            }, mCase.getFieldCollectionDate(), HumanCaseSample.eidss_FieldCollectionDate, mandatoryFields, invisibleFields);
        
        
        fragment.DateBind(R.id.datFieldSentDate, v, R.id.datFieldSentDateClearButton,
            new View.OnClickListener() {
                @Override
                public void onClick(View arg0) {
                    com.bv.eidss.EidssAndroidHelpers.DatePickerFragment.Show(fragment.getActivity().getSupportFragmentManager(), datFieldSentDate_DialogID, null, mCase.getFieldSentDate());
                }
            },
            new View.OnClickListener() {
                @Override
                public void onClick(View arg0) {
                    mCase.setFieldSentDate(null);
                    DateHelpers.DisplayDate(R.id.datFieldSentDate, v, mCase.getFieldSentDate());
                }
            }, mCase.getFieldSentDate(), HumanCaseSample.eidss_FieldSentDate, mandatoryFields, invisibleFields);
        }
    }

    public static Loader<Cursor> onCreateLoader(final int id, final String lang, final HumanCaseSample mCase, Context context)
    {
        String[] sels;
        switch (id)
        {
            default:
                return null;
        }
    }

    public static void onLoadFinished(final int id, Cursor data, final HumanCaseSample mCase)
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
