package com.bv.eidss;

import android.app.Activity;
import android.content.Context;
import android.database.Cursor;
import android.os.Bundle;
import android.support.v4.app.LoaderManager;
import android.support.v4.content.Loader;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.view.ViewParent;
import android.view.WindowManager;
import android.widget.AdapterView;
import android.widget.LinearLayout;
import android.widget.Spinner;
import android.widget.TextView;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.generated.VetCaseSample_binding;
import com.bv.eidss.model.BaseReference;
import com.bv.eidss.model.BaseReferenceType;
import com.bv.eidss.model.CaseTypeHACode;
import com.bv.eidss.model.Options;
import com.bv.eidss.model.VetCaseSample;
import com.bv.eidss.utils.DateHelpers;
import com.bv.eidss.utils.EidssUtils;

import java.util.List;


public class VetCaseSampleFragment extends EidssBaseBindableFragment
    implements  LoaderManager.LoaderCallbacks<Cursor> {

    private VetCaseSampleActivity mActivity;

    public VetCaseSampleFragment() {
        // Required empty public constructor
    }

    public static VetCaseSampleFragment newInstance() {
        return new VetCaseSampleFragment();
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
            mActivity = (VetCaseSampleActivity) context;
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        final View v;
        v = inflater.inflate(R.layout.vet_case_sample_layout, container, false);

        // Custom Binding
        final List<String> mandatoryFields = EidssDatabase.GetMandatoryFields();
        final List<String> invisibleFields = EidssDatabase.GetInvisibleFields();

        EidssDatabase db = new EidssDatabase(getActivity());
        Options opt = db.Options();
        final long RegionDef = opt.getRegionDef();
        final long RayonDef = opt.getRayonDef();
        db.close();

        // SampleType
        LookupBind(R.id.idfsSampleType, v, mActivity.mCase.getSampleType(), mActivity.diagnosis, 0, BaseReferenceType.rftSampleType, mActivity.isLivestock ? CaseTypeHACode.LIVESTOCK : CaseTypeHACode.AVIAN,
                new AdapterView.OnItemSelectedListener() {
                    public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                        mActivity.mCase.setSampleType(((BaseReference) parent.getSelectedItem()).idfsBaseReference);
                        if (id != 0 && mActivity.mCase.getFieldCollectionDate() == null)
                        {
                            final boolean bChanged = mActivity.mCase.getChanged();
                            mActivity.mCase.setFieldCollectionDate(DateHelpers.Today());
                            DateHelpers.DisplayDate(R.id.datFieldCollectionDate
                                    , v, mActivity.mCase.getFieldCollectionDate());
                            if (!bChanged)
                                mActivity.mCase.setUnchanged();
                        }
                    }

                    public void onNothingSelected(AdapterView<?> arg0) {
                        mActivity.mCase.setSampleType(0);
                    }
                }, true, VetCaseSample.eidss_SampleType, mandatoryFields, invisibleFields);


        // Animal, SpeciesType
        final Spinner spinnerAnimal = (Spinner)v.findViewById(R.id.idfAnimal);
        if (mActivity.isLivestock)
        {
            // create readonly text for SpeciesType
            String speciesTypeText = "";
            for(BaseReference br: mActivity.items)
                if (br.idfsBaseReference == mActivity.mCase.getAnimal()) {
                    if (br.name.contains("/"))
                        speciesTypeText = br.name.substring(0, br.name.indexOf("/"));
                    break;
                }

            View labelView = inflater.inflate(R.layout.template_textview, container, false);
            final TextView speciesType = (TextView) labelView.findViewById(R.id.idLabelCaption);
            speciesType.setText(speciesTypeText);
            ViewParent par = (v.findViewById(R.id.idfsSpeciesType)).getParent();
            ((LinearLayout)par).addView(labelView, 2);

            // list of Animals
            LookupBind(spinnerAnimal, mActivity.items,
                    new AdapterView.OnItemSelectedListener() {
                        public void onItemSelected(AdapterView<?> parent, View vw, int spnPosition, long id) {
                            mActivity.mCase.setAnimal(((BaseReference) parent.getSelectedItem()).idfsBaseReference);
                            final String name = ((BaseReference) parent.getSelectedItem()).name;
                            if (name.contains("/"))
                                speciesType.setText(name.substring(0, name.lastIndexOf("/")));
                            else
                                speciesType.setText("");
                        }

                        public void onNothingSelected(AdapterView<?> parent) {
                            mActivity.mCase.setAnimal(0L);
                            speciesType.setText("");
                        }
                    }, mActivity.mCase.getAnimal(), true, true, false);

            (v.findViewById(R.id.idfsSpeciesType)).setVisibility(View.GONE);
            ((View)(v.findViewById(R.id.idfsBirdStatus)).getParent()).setVisibility(View.GONE);
        }else {
            LookupBind(R.id.idfsSpeciesType, v, mActivity.items,
                    new AdapterView.OnItemSelectedListener() {
                        public void onItemSelected(AdapterView<?> parent, View vw, int spnPosition, long id) {
                            mActivity.mCase.setSpeciesType(((BaseReference) parent.getSelectedItem()).idfsBaseReference);
                        }

                        public void onNothingSelected(AdapterView<?> parent) {
                            mActivity.mCase.setSpeciesType(0);
                        }
                    }, mActivity.mCase.getSpeciesType(), true, VetCaseSample.eidss_SpeciesType, mandatoryFields, invisibleFields);

            EidssUtils.SetMandatoryAndInvisible(v.findViewById(R.id.idfsSpeciesType), true, false, false);


            ((View)spinnerAnimal.getParent()).setVisibility(View.GONE);
        }

        // Sent To
        LookupBind(R.id.idfSendToOffice, v, mActivity.mCase.getSendToOffice(), RegionDef, RayonDef, BaseReferenceType.rftInstitutionName, mActivity.isLivestock ? CaseTypeHACode.LIVESTOCK : CaseTypeHACode.AVIAN,
                new AdapterView.OnItemSelectedListener() {
                    public void onItemSelected(AdapterView<?> parent, View vw, int spnPosition, long id) {
                        mActivity.mCase.setSendToOffice(((BaseReference) parent.getSelectedItem()).idfsBaseReference);
                    }

                    public void onNothingSelected(AdapterView<?> parent) {
                        mActivity.mCase.setSendToOffice(0);
                    }
                }, true, VetCaseSample.eidss_SendToOffice, mandatoryFields, invisibleFields);


        // End of Custom Binding

        VetCaseSample_binding.Bind(this, v, mActivity.mCase, mandatoryFields, invisibleFields, EidssUtils.getCurrentLanguage(), 0);

        // hide soft keyboard
        mActivity.getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_HIDDEN);
        return v;
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
        return VetCaseSample_binding.onCreateLoader(id, EidssUtils.getCurrentLanguage(), mActivity.mCase, mActivity);
    }

    @Override
    public void onLoadFinished(Loader<Cursor> loader, Cursor data) {
        VetCaseSample_binding.onLoadFinished(loader.getId(), data, mActivity.mCase);
    }

    @Override
    public void onLoaderReset(Loader<Cursor> loader) {
        VetCaseSample_binding.onLoaderReset(loader.getId());
    }

}
