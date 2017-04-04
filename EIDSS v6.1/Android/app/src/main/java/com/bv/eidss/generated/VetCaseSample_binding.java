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

public class VetCaseSample_binding
{
    public static final int NO_ACTION_ID = 1050;
    public static final int datFieldCollectionDate_DialogID = 1051;

    private static final int LOADER_BirdStatus = 1100;
    private static SimpleCursorAdapter adapterBirdStatus;
    private static Spinner spinnerBirdStatus;

    public static void Bind(final EidssBaseBindableFragment fragment, final View v, final VetCaseSample mCase, final List<String> mandatoryFields, final List<String> invisibleFields, final String lang, final int page)
    {
        
        if (page == 0)
        {
        
        fragment.EditTextBind(R.id.strFieldBarcode, v, mCase.getFieldBarcode(), 
            new OnEditTextChangeListener() {
                @Override
                public void onEditTextChanged(String text) {
                    mCase.setFieldBarcode(text);
                }
            }, true, VetCaseSample.eidss_FieldBarcode, mandatoryFields, invisibleFields);
        
        
        
        spinnerBirdStatus = (Spinner)v.findViewById(R.id.idfsBirdStatus);
        adapterBirdStatus = fragment.LookupBind(spinnerBirdStatus, v, ReferenciesProvider.NAME,
            new AdapterView.OnItemSelectedListener(){
                public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                    if (mCase.getBirdStatus() != id)
                      mCase.setBirdStatus(id);
                }
                public void onNothingSelected(AdapterView<?> arg0) {
                    mCase.setBirdStatus(0);
                }
            }, 
            VetCaseSample.eidss_BirdStatus, mandatoryFields, invisibleFields);
        if (adapterBirdStatus != null)
            fragment.getActivity().getSupportLoaderManager().initLoader(LOADER_BirdStatus, null, (VetCaseSampleFragment)fragment);
        
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
            }, mCase.getFieldCollectionDate(), VetCaseSample.eidss_FieldCollectionDate, mandatoryFields, invisibleFields);
        
        }
    }

    public static Loader<Cursor> onCreateLoader(final int id, final String lang, final VetCaseSample mCase, Context context)
    {
        String[] sels;
        switch (id)
        {
                case LOADER_BirdStatus:
                        sels = new String[4];
                        sels[0] = lang;
                        sels[1] = String.valueOf(BaseReferenceType.rftAnimalCondition);
                        sels[2] = String.valueOf(CaseTypeHACode.AVIAN);
                        sels[3] = String.valueOf(mCase.getBirdStatus());
                        return new CursorLoader(context, ReferenciesProvider.CONTENT_URI, null, null, sels, null);
            default:
                return null;
        }
    }

    public static void onLoadFinished(final int id, Cursor data, final VetCaseSample mCase)
    {
        switch (id)
        {
                case LOADER_BirdStatus:
                        onLoadFinishedBirdStatus(data, mCase);
                        break;
            default:
                break;
        }
    }

    public static void onLoaderReset(final int id) {
        switch (id)
        {
                case LOADER_BirdStatus:
                        adapterBirdStatus.swapCursor(null);
                        break;
            default:
                break;
        }
    }

    private static void onLoadFinishedBirdStatus(Cursor data, final VetCaseSample mCase)
    {
        adapterBirdStatus.swapCursor(data);
        int rowCount = data.getCount();
        if (rowCount > 1)
        {
            // set selected
            int cpos = 0;
            for (int i = 0; i < rowCount; i++){
                data.moveToPosition(i);
                long temp = data.getLong(0);
                if (temp == mCase.getBirdStatus())
                {
                    cpos = i;
                    break;
                }
            }
            spinnerBirdStatus.setSelection(cpos);
            spinnerBirdStatus.setEnabled(true);
        }
        else
        {
            spinnerBirdStatus.setEnabled(false);
        }
    }
}
