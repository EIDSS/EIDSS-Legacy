package com.bv.eidss;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.BaseReferenceType;
import com.bv.eidss.model.CaseTypeHACode;
import com.bv.eidss.model.Options;
import com.bv.eidss.utils.EidssUtils;

import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Spinner;

public class HumanCaseListActivity extends EidssBaseActivity
                                    implements EidssAndroidHelpers.DialogDoneListener{

    public final int DELETE_DIALOG_ID = 1;
    private Fragment fragment;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        mDrawerList.setItemChecked(position, true);
        setTitle("");
        getSupportActionBar().setIcon(R.drawable.eidss_ic_search_hc_big);

        StartFragment();

        (new GetHospitalsTask()).execute();
        (new GetRegionsTask()).execute();

        if(!EidssDatabase.IsFFLoaded())
        {
            FFGetDataTask getFF = new FFGetDataTask(this, new FFGetDataTask.OnComplete() {
                @Override
                public void asyncResponse(){}
            });
            getFF.execute();
        }
    }

    private Fragment StartFragment()
    {
        FragmentManager fm = getSupportFragmentManager();
        fragment = fm.findFragmentById(R.id.content_frame);
        if (fragment == null) {
            fragment = HumanCaseListFragment.newInstance();

            fm.beginTransaction()
                    .add(R.id.content_frame, fragment)
                    .commit();
        }
        return fragment;
    }

    @Override
    protected void SetToolbarSpinner() {
        Spinner spinnerCaseStatusFilter = (Spinner)findViewById(R.id.spinner_list_filter);
        spinnerCaseStatusFilter.setVisibility(View.VISIBLE);

        ArrayAdapter<CharSequence> adapter = ArrayAdapter.createFromResource(this, R.array.CaseStatusFilterItems, R.layout.custom_menu_spinner);
        adapter.setDropDownViewResource(R.layout.custom_menu_spinner_item);
        spinnerCaseStatusFilter.setAdapter(adapter);
        spinnerCaseStatusFilter.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View v, int position, long id) {
                HumanCaseListFragment fragment = (HumanCaseListFragment)StartFragment();
                fragment.onFilterChanged(position);
            }

            @Override
            public void onNothingSelected(AdapterView<?> arg0) {
            }
        });
    }


    final private class GetHospitalsTask extends AsyncTask<Void, Void, Void> {
        @Override
        protected Void doInBackground(Void... params) {
            if(EidssDatabase.GetHospitals() == null)
            {
                Options opt = EidssDatabase.GetOptions();
                String[] sels;
                if (opt.getRayonDef() == 0) {
                    sels = new String[5];
                    sels[4] = "0";
                } else {
                    sels = new String[6];
                    sels[4] = String.valueOf(opt.getRayonDef());
                    sels[5] = "0";
                }
                sels[0] = EidssUtils.getCurrentLanguage();
                sels[1] = String.valueOf(BaseReferenceType.rftInstitutionName);
                sels[2] = String.valueOf(CaseTypeHACode.HUMAN);
                sels[3] = String.valueOf(opt.getRegionDef());

                EidssDatabase.SetHospitals(getContentResolver().query(ReferenciesProvider.CONTENT_URI, null, null, sels, null));
            }
            return null;
        }
    }

    final private class GetRegionsTask extends AsyncTask<Void, Void, Void> {
        @Override
        protected Void doInBackground(Void... params) {
            if(EidssDatabase.GetRegions() == null)
            {
                String[] sels = new String[2];
                sels[0] = EidssUtils.getCurrentLanguage();
                sels[1] = "0";

                EidssDatabase.SetRegions(getContentResolver().query(RegionsProvider.CONTENT_URI, null, null, sels, null));
            }
            return null;
        }
    }

    @Override
    public void onDone(int idDialog, boolean isPositive) {
        switch (idDialog) {
            case DELETE_DIALOG_ID:
                if (isPositive) {
                    ((HumanCaseListFragment)fragment).DeleteCases();
                }
                break;
        }
    }

}
