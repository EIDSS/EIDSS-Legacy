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

public class ASSample_binding
{
    public static final int NO_ACTION_ID = 1028;
    public static final int datFieldCollectionDate_DialogID = 1029;

    private static final int LOADER_AnimalGender = 1100;
    private static SimpleCursorAdapter adapterAnimalGender;
    private static Spinner spinnerAnimalGender;

    public static void Bind(final EidssBaseBindableFragment fragment, final View v, final ASSample mCase, final List<String> mandatoryFields, final List<String> invisibleFields, final String lang, final int page)
    {
        
        if (page == 0)
        {
        
        
        
        v.findViewById(R.id.ScanAnimalIdButton).setOnClickListener(new View.OnClickListener()
        {
            public void onClick(View v) {
                ((com.bv.eidss.barcode.BarcodeTestActivity)fragment.getActivity()).launchSimpleActivity(v);
            }
        });
        
        
        fragment.EditTextBind(R.id.strColor, v, mCase.getColor(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setColor(text);
                }
            }, true, ASSample.eidss_Color, mandatoryFields, invisibleFields);
        
        spinnerAnimalGender = (Spinner)v.findViewById(R.id.idfsAnimalGender);
        adapterAnimalGender = fragment.LookupBind(spinnerAnimalGender, v, ReferenciesProvider.NAME,
            new AdapterView.OnItemSelectedListener(){
                public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                    if (mCase.getAnimalGender() != id)
                      mCase.setAnimalGender(id);
                }
                public void onNothingSelected(AdapterView<?> arg0) {
                    mCase.setAnimalGender(0);
                }
            }, 
            ASSample.eidss_AnimalGender, mandatoryFields, invisibleFields);
        if (adapterAnimalGender != null)
            fragment.getActivity().getSupportLoaderManager().initLoader(LOADER_AnimalGender, null, (ASSampleFragment)fragment);
        
        fragment.EditTextBind(R.id.strName, v, mCase.getName(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setName(text);
                }
            }, true, ASSample.eidss_Name, mandatoryFields, invisibleFields);
        
        fragment.EditTextBind(R.id.strDescription, v, mCase.getDescription(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setDescription(text);
                }
            }, true, ASSample.eidss_Description, mandatoryFields, invisibleFields);
        
        
        fragment.EditTextBind(R.id.strFieldBarcode, v, mCase.getFieldBarcode(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setFieldBarcode(text);
                }
            }, true, ASSample.eidss_FieldBarcode, mandatoryFields, invisibleFields);
        
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
            }, mCase.getFieldCollectionDate(), ASSample.eidss_FieldCollectionDate, mandatoryFields, invisibleFields);
        
        }
    }

    public static Loader<Cursor> onCreateLoader(final int id, final String lang, final ASSample mCase, Context context)
    {
        String[] sels;
        switch (id)
        {
                case LOADER_AnimalGender:
                        sels = new String[4];
                        sels[0] = lang;
                        sels[1] = String.valueOf(BaseReferenceType.rftAnimalSex);
                        sels[2] = String.valueOf(CaseTypeHACode.LIVESTOCK);
                        sels[3] = String.valueOf(mCase.getAnimalGender());
                        return new CursorLoader(context, ReferenciesProvider.CONTENT_URI, null, null, sels, null);
            default:
                return null;
        }
    }

    public static void onLoadFinished(final int id, Cursor data, final ASSample mCase)
    {
        switch (id)
        {
                case LOADER_AnimalGender:
                        onLoadFinishedAnimalGender(data, mCase);
                        break;
            default:
                break;
        }
    }

    public static void onLoaderReset(final int id) {
        switch (id)
        {
                case LOADER_AnimalGender:
                        adapterAnimalGender.swapCursor(null);
                        break;
            default:
                break;
        }
    }

    private static void onLoadFinishedAnimalGender(Cursor data, final ASSample mCase)
    {
        adapterAnimalGender.swapCursor(data);
        int rowCount = data.getCount();
        if (rowCount > 1)
        {
            // set selected
            int cpos = 0;
            for (int i = 0; i < rowCount; i++){
                data.moveToPosition(i);
                long temp = data.getLong(0);
                if (temp == mCase.getAnimalGender())
                {
                    cpos = i;
                    break;
                }
            }
            spinnerAnimalGender.setSelection(cpos);
            spinnerAnimalGender.setEnabled(true);
        }
        else
        {
            spinnerAnimalGender.setEnabled(false);
        }
    }
}
