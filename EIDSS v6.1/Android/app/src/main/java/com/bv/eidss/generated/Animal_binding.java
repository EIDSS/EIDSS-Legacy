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

public class Animal_binding
{
    public static final int NO_ACTION_ID = 1026;

    private static final int LOADER_AnimalGender = 1100;
    private static SimpleCursorAdapter adapterAnimalGender;
    private static Spinner spinnerAnimalGender;
    private static final int LOADER_AnimalCondition = 1101;
    private static SimpleCursorAdapter adapterAnimalCondition;
    private static Spinner spinnerAnimalCondition;

    public static void Bind(final EidssBaseBindableFragment fragment, final View v, final Animal mCase, final List<String> mandatoryFields, final List<String> invisibleFields, final String lang, final int page)
    {
        
        if (page == 0)
        {
        
        fragment.EditTextBind(R.id.strAnimalCode, v, mCase.getAnimalCode(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setAnimalCode(text);
                }
            }, true, Animal.eidss_AnimalCode, mandatoryFields, invisibleFields);
        
        v.findViewById(R.id.ScanAnimalIdButton).setOnClickListener(new View.OnClickListener()
        {
            public void onClick(View v) {
                ((com.bv.eidss.barcode.BarcodeTestActivity)fragment.getActivity()).launchSimpleActivity(v);
            }
        });
        
        
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
            Animal.eidss_AnimalGender, mandatoryFields, invisibleFields);
        if (adapterAnimalGender != null)
            fragment.getActivity().getSupportLoaderManager().initLoader(LOADER_AnimalGender, null, (AnimalFragment)fragment);
        
        spinnerAnimalCondition = (Spinner)v.findViewById(R.id.idfsAnimalCondition);
        adapterAnimalCondition = fragment.LookupBind(spinnerAnimalCondition, v, ReferenciesProvider.NAME,
            new AdapterView.OnItemSelectedListener(){
                public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                    if (mCase.getAnimalCondition() != id)
                      mCase.setAnimalCondition(id);
                }
                public void onNothingSelected(AdapterView<?> arg0) {
                    mCase.setAnimalCondition(0);
                }
            }, 
            Animal.eidss_AnimalCondition, mandatoryFields, invisibleFields);
        if (adapterAnimalCondition != null)
            fragment.getActivity().getSupportLoaderManager().initLoader(LOADER_AnimalCondition, null, (AnimalFragment)fragment);
        }
    }

    public static Loader<Cursor> onCreateLoader(final int id, final String lang, final Animal mCase, Context context)
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
                case LOADER_AnimalCondition:
                        sels = new String[3];
                        sels[0] = lang;
                        sels[1] = String.valueOf(BaseReferenceType.rftAnimalCondition);
                        sels[2] = String.valueOf(mCase.getAnimalCondition());
                        return new CursorLoader(context, ReferenciesProvider.CONTENT_URI, null, null, sels, null);
            default:
                return null;
        }
    }

    public static void onLoadFinished(final int id, Cursor data, final Animal mCase)
    {
        switch (id)
        {
                case LOADER_AnimalGender:
                        onLoadFinishedAnimalGender(data, mCase);
                        break;
                case LOADER_AnimalCondition:
                        onLoadFinishedAnimalCondition(data, mCase);
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
                case LOADER_AnimalCondition:
                        adapterAnimalCondition.swapCursor(null);
                        break;
            default:
                break;
        }
    }

    private static void onLoadFinishedAnimalGender(Cursor data, final Animal mCase)
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
    private static void onLoadFinishedAnimalCondition(Cursor data, final Animal mCase)
    {
        adapterAnimalCondition.swapCursor(data);
        int rowCount = data.getCount();
        if (rowCount > 1)
        {
            // set selected
            int cpos = 0;
            for (int i = 0; i < rowCount; i++){
                data.moveToPosition(i);
                long temp = data.getLong(0);
                if (temp == mCase.getAnimalCondition())
                {
                    cpos = i;
                    break;
                }
            }
            spinnerAnimalCondition.setSelection(cpos);
            spinnerAnimalCondition.setEnabled(true);
        }
        else
        {
            spinnerAnimalCondition.setEnabled(false);
        }
    }
}
