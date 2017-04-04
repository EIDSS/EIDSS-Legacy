package com.bv.eidss;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.res.Resources;
import android.database.Cursor;
import android.os.Bundle;
import android.support.v4.app.LoaderManager;
import android.support.v4.content.CursorLoader;
import android.support.v4.content.Loader;
import android.support.v4.widget.SimpleCursorAdapter;
import android.text.TextUtils;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.widget.AdapterView;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.Spinner;
import android.widget.TextView;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.generated.ASDisease_binding;
import com.bv.eidss.model.ASDisease;
import com.bv.eidss.model.BaseReference;
import com.bv.eidss.model.BaseReferenceType;
import com.bv.eidss.model.CaseTypeHACode;
import com.bv.eidss.utils.EidssUtils;

import java.util.List;


public class ASDiseaseFragment extends EidssBaseBindableFragment
    implements  LoaderManager.LoaderCallbacks<Cursor> {

    private ASDiseaseActivity mActivity;

    private final int LOADER_Diagnosis = 1100;
    private SimpleCursorAdapter adapterDiagnosis;
    private Spinner spinnerDiagnosis;
    private final int LOADER_SpeciesType = 1101;
    private SimpleCursorAdapter adapterSpeciesType;
    private Spinner spinnerSpeciesType;
    private final int LOADER_SampleType = 1102;
    private SimpleCursorAdapter adapterSampleType;
    private Spinner spinnerSampleType;

    public ASDiseaseFragment() {
        // Required empty public constructor
    }

    public static ASDiseaseFragment newInstance() {
        return new ASDiseaseFragment();
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setHasOptionsMenu(true);
    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        if (context instanceof Activity){
            mActivity = (ASDiseaseActivity) context;
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        final View v;
        v = inflater.inflate(R.layout.as_disease_layout, container, false);

        // Custom Binding
        final List<String> mandatoryFields = EidssDatabase.GetMandatoryFields();
        final List<String> invisibleFields = EidssDatabase.GetInvisibleFields();

        spinnerDiagnosis = (Spinner)v.findViewById(R.id.idfsDiagnosis);
        adapterDiagnosis = LookupBind(spinnerDiagnosis, v, ReferenciesProvider.NAME,
                new AdapterView.OnItemSelectedListener(){
                    public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                        if (mActivity.mASDisease.getDiagnosis() != id) {
                            mActivity.mASDisease.setDiagnosis(id);
                            mActivity.mASDisease.setSpeciesType(0);
                            mActivity.mASDisease.setSampleType(0);
                            updateSpeciesType();
                            updateSampleTypes();
                        }
                    }
                    public void onNothingSelected(AdapterView<?> arg0) {
                        mActivity.mASDisease.setDiagnosis(0);
                        mActivity.mASDisease.setSpeciesType(0);
                        mActivity.mASDisease.setSampleType(0);
                        updateSpeciesType();
                        updateSampleTypes();
                    }
                },
                ASDisease.eidss_Diagnosis, mandatoryFields, invisibleFields);
        if (adapterDiagnosis != null)
            getActivity().getSupportLoaderManager().initLoader(LOADER_Diagnosis, null, this);

        spinnerSpeciesType = (Spinner)v.findViewById(R.id.idfsSpeciesType);
        adapterSpeciesType = LookupBind(spinnerSpeciesType, v, ReferenciesProvider.NAME,
                new AdapterView.OnItemSelectedListener(){
                    public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                        if (mActivity.mASDisease.getSpeciesType() != id) {
                            mActivity.mASDisease.setSpeciesType(id);
                            mActivity.mASDisease.setSampleType(0);
                            updateSampleTypes();
                        }
                    }
                    public void onNothingSelected(AdapterView<?> arg0) {
                        mActivity.mASDisease.setSpeciesType(0);
                        mActivity.mASDisease.setSampleType(0);
                        updateSampleTypes();
                    }
                },
                ASDisease.eidss_SpeciesType, mandatoryFields, invisibleFields);
        if (adapterSpeciesType != null)
            getActivity().getSupportLoaderManager().initLoader(LOADER_SpeciesType, null, this);

        spinnerSampleType = (Spinner)v.findViewById(R.id.idfsSampleType);
        adapterSampleType = LookupBind(spinnerSampleType, v, ReferenciesProvider.NAME,
                new AdapterView.OnItemSelectedListener(){
                    public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                        if (mActivity.mASDisease.getSampleType() != id)
                            mActivity.mASDisease.setSampleType(id);
                    }
                    public void onNothingSelected(AdapterView<?> arg0) {
                        mActivity.mASDisease.setSampleType(0);
                    }
                },
                ASDisease.eidss_SampleType, mandatoryFields, invisibleFields);
        if (adapterSampleType != null)
            getActivity().getSupportLoaderManager().initLoader(LOADER_SampleType, null, this);

        // End of Custom Binding

        ASDisease_binding.Bind(this, v, mActivity.mASDisease, mandatoryFields, invisibleFields, EidssUtils.getCurrentLanguage(), 0);

        // hide soft keyboard
        mActivity.getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_HIDDEN);
        return v;
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent intent) {
    }

    @Override
    public void onCreateOptionsMenu(Menu menu, MenuInflater inflater) {
        inflater.inflate(R.menu.case_toolbar, menu);
    }

    /* Called whenever we call invalidateOptionsMenu() */
    @Override
    public void onPrepareOptionsMenu(Menu menu) {
        menu.findItem(R.id.Save).setVisible(false);
        menu.findItem(R.id.Remove).setVisible(false);
        menu.findItem(R.id.Refresh).setVisible(false);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {

        switch (item.getItemId()) {
            case android.R.id.home:
                mActivity.Home();
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }

    @Override
    public Loader<Cursor> onCreateLoader(int id, Bundle args) {
        String lang = EidssUtils.getCurrentLanguage();
        String[] sels;
        switch (id)
        {
            case LOADER_Diagnosis:
                if (mActivity.mASSession.getCampaign() != 0) {
                    sels = new String[3];
                    sels[0] = EidssUtils.getCurrentLanguage();
                    sels[1] = String.valueOf(mActivity.mASSession.getCampaign());
                    sels[2] = String.valueOf(mActivity.mASDisease.getDiagnosis());
                    return new CursorLoader(mActivity, ASCampaignDiseasesProvider.CONTENT_URI, null, null, sels, null);
                } else {
                    sels = new String[4];
                    sels[0] = EidssUtils.getCurrentLanguage();
                    sels[1] = String.valueOf(BaseReferenceType.rftDiagnosis);
                    sels[2] = String.valueOf(CaseTypeHACode.LIVESTOCK);
                    sels[3] = String.valueOf(mActivity.mASDisease.getDiagnosis());
                    return new CursorLoader(mActivity, ReferenciesProvider.CONTENT_URI, null, null, sels, null);
                }
            case LOADER_SpeciesType:
                if (mActivity.mASSession.getCampaign() != 0) {
                    sels = new String[4];
                    sels[0] = EidssUtils.getCurrentLanguage();
                    sels[1] = String.valueOf(mActivity.mASSession.getCampaign());
                    sels[2] = String.valueOf(mActivity.mASDisease.getDiagnosis());
                    sels[3] = String.valueOf(mActivity.mASDisease.getSpeciesType());
                    return new CursorLoader(mActivity, ASCampaignSpeciesTypesProvider.CONTENT_URI, null, null, sels, null);
                } else {
                    sels = new String[4];
                    sels[0] = lang;
                    sels[1] = String.valueOf(BaseReferenceType.rftSpeciesList);
                    sels[2] = String.valueOf(CaseTypeHACode.LIVESTOCK);
                    sels[3] = String.valueOf(mActivity.mASDisease.getSpeciesType());
                    return new CursorLoader(mActivity, ReferenciesProvider.CONTENT_URI, null, null, sels, null);
                }
            case LOADER_SampleType:
                if (mActivity.mASSession.getCampaign() != 0) {
                    sels = new String[5];
                    sels[0] = EidssUtils.getCurrentLanguage();
                    sels[1] = String.valueOf(mActivity.mASSession.getCampaign());
                    sels[2] = String.valueOf(mActivity.mASDisease.getDiagnosis());
                    sels[3] = String.valueOf(mActivity.mASDisease.getSpeciesType());
                    sels[4] = String.valueOf(mActivity.mASDisease.getSampleType());
                    return new CursorLoader(mActivity, ASCampaignSampleTypesProvider.CONTENT_URI, null, null, sels, null);
                } else {
                    sels = new String[5];
                    sels[0] = lang;
                    sels[1] = String.valueOf(BaseReferenceType.rftSampleType);
                    sels[2] = String.valueOf(CaseTypeHACode.LIVESTOCK);
                    sels[3] = String.valueOf(mActivity.mASDisease.getDiagnosis());
                    sels[4] = String.valueOf(mActivity.mASDisease.getSampleType());
                    return new CursorLoader(mActivity, ReferenciesProvider.CONTENT_URI, null, null, sels, null);
                }
            default:
                return ASDisease_binding.onCreateLoader(id, EidssUtils.getCurrentLanguage(), mActivity.mASDisease, mActivity);
        }
    }

    @Override
    public void onLoadFinished(Loader<Cursor> loader, Cursor data) {
        switch (loader.getId())
        {
            case LOADER_Diagnosis:
                onLoadFinishedDiagnosis(data, mActivity.mASDisease);
                break;
            case LOADER_SpeciesType:
                onLoadFinishedSpeciesType(data, mActivity.mASDisease);
                break;
            case LOADER_SampleType:
                onLoadFinishedSampleType(data, mActivity.mASDisease);
                break;
            default:
                ASDisease_binding.onLoadFinished(loader.getId(), data, mActivity.mASDisease);
                break;
        }

    }

    @Override
    public void onLoaderReset(Loader<Cursor> loader) {
        switch (loader.getId())
        {
            case LOADER_Diagnosis:
                adapterDiagnosis.swapCursor(null);
                break;
            case LOADER_SpeciesType:
                adapterSpeciesType.swapCursor(null);
                break;
            case LOADER_SampleType:
                adapterSampleType.swapCursor(null);
                break;
            default:
                ASDisease_binding.onLoaderReset(loader.getId());
                break;
        }
    }

    private void updateSpeciesType() {
        mActivity.getSupportLoaderManager().restartLoader(LOADER_SpeciesType, null, this);
    }

    private void updateSampleTypes() {
        mActivity.getSupportLoaderManager().restartLoader(LOADER_SampleType, null, this);
    }

    private void onLoadFinishedDiagnosis(Cursor data, final ASDisease mCase)
    {
        adapterDiagnosis.swapCursor(data);
        int rowCount = data.getCount();
        if (rowCount > 1)
        {
            // set selected
            int cpos = 0;
            for (int i = 0; i < rowCount; i++){
                data.moveToPosition(i);
                long temp = data.getLong(0);
                if (temp == mCase.getDiagnosis())
                {
                    cpos = i;
                    break;
                }
            }
            spinnerDiagnosis.setSelection(cpos);
            spinnerDiagnosis.setEnabled(true);
        }
        else
        {
            spinnerDiagnosis.setEnabled(false);
        }
    }
    private void onLoadFinishedSpeciesType(Cursor data, final ASDisease mCase)
    {
        adapterSpeciesType.swapCursor(data);
        int rowCount = data.getCount();
        if (rowCount > 1)
        {
            // set selected
            int cpos = 0;
            for (int i = 0; i < rowCount; i++){
                data.moveToPosition(i);
                long temp = data.getLong(0);
                if (temp == mCase.getSpeciesType())
                {
                    cpos = i;
                    break;
                }
            }
            spinnerSpeciesType.setSelection(cpos);
            spinnerSpeciesType.setEnabled(true);
        }
        else
        {
            spinnerSpeciesType.setEnabled(false);
        }
    }
    private void onLoadFinishedSampleType(Cursor data, final ASDisease mCase)
    {
        adapterSampleType.swapCursor(data);
        int rowCount = data.getCount();
        if (rowCount > 1)
        {
            // set selected
            int cpos = 0;
            for (int i = 0; i < rowCount; i++){
                data.moveToPosition(i);
                long temp = data.getLong(0);
                if (temp == mCase.getSampleType())
                {
                    cpos = i;
                    break;
                }
            }
            spinnerSampleType.setSelection(cpos);
            spinnerSampleType.setEnabled(true);
        }
        else
        {
            spinnerSampleType.setEnabled(false);
        }
    }


}
