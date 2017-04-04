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
import android.view.WindowManager;
import android.widget.AdapterView;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.generated.HumanCaseSample_binding;
import com.bv.eidss.model.BaseReference;
import com.bv.eidss.model.BaseReferenceType;
import com.bv.eidss.model.CaseTypeHACode;
import com.bv.eidss.model.HumanCaseSample;
import com.bv.eidss.model.Options;
import com.bv.eidss.utils.DateHelpers;
import com.bv.eidss.utils.EidssUtils;

import java.util.List;


public class HumanCaseSampleFragment extends EidssBaseBindableFragment
    implements  LoaderManager.LoaderCallbacks<Cursor> {

    private HumanCaseSampleActivity mActivity;

    public HumanCaseSampleFragment() {
        // Required empty public constructor
    }

    public static HumanCaseSampleFragment newInstance() {
        return new HumanCaseSampleFragment();
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
            mActivity = (HumanCaseSampleActivity) context;
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        final View v;
        v = inflater.inflate(R.layout.human_case_sample_layout, container, false);

        // Custom Binding
        final List<String> mandatoryFields = EidssDatabase.GetMandatoryFields();
        final List<String> invisibleFields = EidssDatabase.GetInvisibleFields();

        EidssDatabase db = new EidssDatabase(getActivity());
        Options opt = db.Options();
        final long RegionDef = opt.getRegionDef();
        final long RayonDef = opt.getRayonDef();
        db.close();

        // SampleType
        LookupBind(R.id.idfsSampleType, v, mActivity.mCase.getSampleType(), mActivity.diagnosis, 0, BaseReferenceType.rftSampleType, CaseTypeHACode.HUMAN,
                new AdapterView.OnItemSelectedListener() {
                    public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                        mActivity.mCase.setSampleType(((BaseReference) parent.getSelectedItem()).idfsBaseReference);
                        if (id != 0 && mActivity.mCase.getFieldCollectionDate() == null)
                        {
                            final boolean bChanged = mActivity.mCase.getChanged();
                            mActivity.mCase.setFieldCollectionDate(DateHelpers.Today());
                            DateHelpers.DisplayDate(R.id.datFieldCollectionDate, v, mActivity.mCase.getFieldCollectionDate());
                            if (!bChanged)
                                mActivity.mCase.setUnchanged();
                        }
                    }

                    public void onNothingSelected(AdapterView<?> arg0) {
                        mActivity.mCase.setSampleType(0);
                    }
                }, true, HumanCaseSample.eidss_SampleType, mandatoryFields, invisibleFields);



        // Sent To
        LookupBind(R.id.idfSendToOffice, v, mActivity.mCase.getSendToOffice(), RegionDef, RayonDef, BaseReferenceType.rftInstitutionName, CaseTypeHACode.HUMAN,
                new AdapterView.OnItemSelectedListener() {
                    public void onItemSelected(AdapterView<?> parent, View vw, int spnPosition, long id) {
                        mActivity.mCase.setSendToOffice(((BaseReference) parent.getSelectedItem()).idfsBaseReference);
                    }

                    public void onNothingSelected(AdapterView<?> parent) {
                        mActivity.mCase.setSendToOffice(0);
                    }
                }, true, HumanCaseSample.eidss_SendToOffice, mandatoryFields, invisibleFields);


        // End of Custom Binding

        HumanCaseSample_binding.Bind(this, v, mActivity.mCase, mandatoryFields, invisibleFields, EidssUtils.getCurrentLanguage(), 0);

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
        return HumanCaseSample_binding.onCreateLoader(id, EidssUtils.getCurrentLanguage(), mActivity.mCase, mActivity);
    }

    @Override
    public void onLoadFinished(Loader<Cursor> loader, Cursor data) {
        HumanCaseSample_binding.onLoadFinished(loader.getId(), data, mActivity.mCase);
    }

    @Override
    public void onLoaderReset(Loader<Cursor> loader) {
        HumanCaseSample_binding.onLoaderReset(loader.getId());
    }

}
