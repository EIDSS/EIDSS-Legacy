package com.bv.eidss;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Spinner;

import com.bv.eidss.data.EidssDatabase;

public class VetCaseListActivity extends EidssBaseActivity
                                 implements EidssAndroidHelpers.DialogDoneListener{

    public final int DELETE_DIALOG_ID = 1;
    private Fragment fragment;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        mDrawerList.setItemChecked(position, true);
        setTitle("");
        getSupportActionBar().setIcon(R.drawable.eidss_ic_search_vc_big);

        if(!EidssDatabase.IsFFLoaded())
        {
            FFGetDataTask getFF = new FFGetDataTask(this, new FFGetDataTask.OnComplete() {
                @Override
                public void asyncResponse(){}
            });
            getFF.execute();
        }

        StartFragment();
    }

    private Fragment StartFragment()
    {
        FragmentManager fm = getSupportFragmentManager();
        fragment = fm.findFragmentById(R.id.content_frame);
        if (fragment == null) {
            fragment = VetCaseListFragment.newInstance();

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
                VetCaseListFragment fragment = (VetCaseListFragment)StartFragment();
                fragment.onFilterChanged(position);
            }

            @Override
            public void onNothingSelected(AdapterView<?> arg0) {
            }
        });
    }

    @Override
    public void onDone(int idDialog, boolean isPositive) {
        switch (idDialog) {
            case DELETE_DIALOG_ID:
                if (isPositive) {
                    ((VetCaseListFragment)fragment).DeleteCases();
                }
                break;
        }
    }
}
