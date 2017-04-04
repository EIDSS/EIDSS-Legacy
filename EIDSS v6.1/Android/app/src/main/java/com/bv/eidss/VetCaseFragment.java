package com.bv.eidss;


import android.app.Activity;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.location.Location;
import android.os.Bundle;
import android.support.v4.app.LoaderManager;
import android.support.v4.content.CursorLoader;
import android.support.v4.content.Loader;
import android.support.v4.widget.SimpleCursorAdapter;
import android.support.v7.widget.PopupMenu;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.widget.AdapterView;
import android.widget.EditText;
import android.widget.Spinner;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.generated.VetCase_binding;
import com.bv.eidss.model.BaseReference;
import com.bv.eidss.model.BaseReferenceType;
import com.bv.eidss.model.GisBaseReference;
import com.bv.eidss.model.VetCase;
import com.bv.eidss.model.interfaces.LocationResultListener;
import com.bv.eidss.utils.EidssUtils;
import com.bv.eidss.utils.OnEditTextChangeListener;

import java.util.List;


public class VetCaseFragment extends EidssBaseBindableFragment
        implements  LoaderManager.LoaderCallbacks<Cursor>,
        LocationResultListener {
    //private static final String ARG_PARAM1 = "vc";
    private static final String ARG_PAGE_NUMBER = "arg_page_number";
    private int pageNumber;

    private VetCaseActivity mActivity;

    private static final int LOADER_REGIONS = 1;
    private static final int LOADER_RAYONS = 2;
    private static final int LOADER_SETTLEMENTS = 3;
    //private static final int LOADER_FARM = 4;
    SimpleCursorAdapter /*mFarmAdapter,*/ mRayonsAdapter, mSettlementsAdapter;
    Spinner /*farms,*/ regions, rayons, settlements;

    //private VetCase mCase;
    private static String lang;


    public VetCaseFragment() {
        // Required empty public constructor
    }

    public static VetCaseFragment newInstance(int page) {
        VetCaseFragment fragment = new VetCaseFragment();
        Bundle args = new Bundle();
        //args.putParcelable(ARG_PARAM1, Case);
        args.putInt(ARG_PAGE_NUMBER, page);
        fragment.setArguments(args);

        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        if (getArguments() != null) {
            //mCase = getArguments().getParcelable(ARG_PARAM1);
            pageNumber = getArguments().getInt(ARG_PAGE_NUMBER);
        }
        setHasOptionsMenu(true);
        lang = EidssUtils.getCurrentLanguage();
    }


    @Override
    public void onAttach(Context context) {
        super.onAttach(context);

        if (context instanceof Activity){
            mActivity = (VetCaseActivity) context;
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        final View v;
        if(pageNumber == 0)
            v = inflater.inflate(R.layout.vet_case_layout_0, container, false);
        else
            v = inflater.inflate(R.layout.vet_case_layout_1, container, false);

        bind(v);

        // hide soft keyboard
        mActivity.getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_HIDDEN);
        return v;
    }

    private String buildFarmComposeName(String name, VetCase f){
        return name + " / " + (f == null ? "" : (
                (f.getOwnerLastName() == null ? "" : f.getOwnerLastName() + " ") +
                (f.getOwnerFirstName() == null ? "" : f.getOwnerFirstName() + " ") +
                (f.getOwnerMiddleName() == null ? "" : f.getOwnerMiddleName() + " ")
        ));
    }

    private void bind(final View v) {
        final List<String> mandatoryFields = EidssDatabase.GetMandatoryFields();
        final List<String> invisibleFields = EidssDatabase.GetInvisibleFields();

        // Custom Binding
        if(pageNumber == 0)
        {
            DisplayDateTime(R.id.datCreateDate, v, mCase().getCreateDate());

            // this is custom binding because of hacode
            LookupBind(R.id.idfsTentativeDiagnosis, v, mCase().getTentativeDiagnosis(), BaseReferenceType.rftDiagnosis, VetCase.GetVetCaseHaCode(mCase().getCaseType()),
                    new AdapterView.OnItemSelectedListener() {
                        public void onItemSelected(AdapterView<?> list, View arg1, int arg2, long arg3) {
                            long itemId = ((BaseReference) list.getSelectedItem()).idfsBaseReference;
                            mCase().setTentativeDiagnosis(itemId);
                        }

                        public void onNothingSelected(AdapterView<?> arg0) {
                            mCase().setTentativeDiagnosis(0);
                        }
                    }, true, VetCase.eidss_TentativeDiagnosis, mandatoryFields, invisibleFields);
        }
        else if(pageNumber == 1) {
            regions = (Spinner) v.findViewById(R.id.idfsRegion);
            rayons = (Spinner) v.findViewById(R.id.idfsRayon);
            settlements = (Spinner) v.findViewById(R.id.idfsSettlement);
            //farms = (Spinner) v.findViewById(R.id.idfRootFarm);

            /*mFarmAdapter = LookupBind(farms, v, FarmsProvider.NAME,
                    new AdapterView.OnItemSelectedListener(){
                        public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                            if (mCase().getRootFarm() != id) {
                                mCase().SetRoot(mActivity, id);
                                bind(v);
                            }
                        }
                        public void onNothingSelected(AdapterView<?> arg0) {
                            mCase().SetRoot(mActivity, 0);
                            bind(v);
                        }
                    },
                    VetCase.eidss_RootFarm, mandatoryFields, invisibleFields);
            if (mFarmAdapter != null)
                mActivity.getSupportLoaderManager().initLoader(LOADER_FARM, null, this);*/

            EidssDatabase mDb = new EidssDatabase(getContext());
            SQLiteDatabase db = mDb.getReadableDatabase();
            String[] selectionArgs = new String[]{String.valueOf(mCase().getRootFarm())};
            String sql = mCase().getRootFarm() == 0
                    ? EidssDatabase.select_sql_farms_prov.replace("[NewFarm]", buildFarmComposeName(mCase().getFarmName(), mCase()))
                    : EidssDatabase.select_sql_farms_prov.replace("[NewFarm]", mActivity.getResources().getString(R.string.NewFarm));
            Cursor data = db.rawQuery(sql, selectionArgs);
            final List<BaseReference> list = EidssDatabase.GetReferenceListFromCursor(data);
            db.close();
            LookupBind(R.id.idfRootFarm, v, mCase().getRootFarm(), list,
                    new AdapterView.OnItemClickListener() {
                        @Override
                        public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                            long itemId = ((BaseReference) parent.getItemAtPosition(position)).idfsBaseReference;
                            if (itemId != mCase().getRootFarm()) {
                                mCase().SetRoot(mActivity, itemId);
                                bind(v);
                            }
                        }
                    },
                    new OnEditTextChangeListener() {
                        @Override
                        public void onEditTextChanged(String text) {

                            for(int i = 0; i < list.size(); i++){
                                BaseReference item = list.get(i);
                                if (item.idfsBaseReference == mCase().getRootFarm()){
                                    mCase().setFarmName(text);
                                    item.name = buildFarmComposeName(text, mCase());
                                    break;
                                }
                            }

                        }
                    },
                    true, VetCase.eidss_RootFarm, mandatoryFields, invisibleFields);

            LookupBindBefore(regions, v,
                    new AdapterView.OnItemSelectedListener() {
                        public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                            long ident = ((GisBaseReference) parent.getSelectedItem()).idfsBaseReference;
                            if (mCase().getRegion() != ident) {
                                mCase().setRegion(ident);
                                mCase().setRayon(0);
                                mCase().setSettlement(0);

                                rayons.setEnabled(false);
                                settlements.setEnabled(false);

                                // Update rayons spinners
                                updateRayons();
                            }
                        }

                        public void onNothingSelected(AdapterView<?> arg0) {
                        }
                    }, VetCase.eidss_Region, mandatoryFields, invisibleFields);

            if(EidssDatabase.GetRegions() != null)
                onLoadFinishedRegions();
            else
                mActivity.getSupportLoaderManager().initLoader(LOADER_REGIONS, null, this);

            mRayonsAdapter = LookupBind(rayons, v, RayonsProvider.NAME,
                    new AdapterView.OnItemSelectedListener() {
                        public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                            if (mCase().getRayon() != id) {
                                mCase().setRayon(id);
                                mCase().setSettlement(0);

                                settlements.setEnabled(false);
                                // Update Settlements spinners
                                updateSettlements();
                            }
                        }

                        public void onNothingSelected(AdapterView<?> arg0) {
                        }
                    }, VetCase.eidss_Rayon, mandatoryFields, invisibleFields);
            mSettlementsAdapter = LookupBind(settlements, v, SettlementsProvider.NAME,
                    new AdapterView.OnItemSelectedListener() {
                        public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                            if (mCase().getSettlement() != id) {
                                mCase().setSettlement(id);
                            }
                            EidssAndroidHelpers.DisableAddress(id == 0, v);
                        }

                        public void onNothingSelected(AdapterView<?> arg0) {
                        }
                    }, VetCase.eidss_Settlement, mandatoryFields, invisibleFields);
        }
        // End of Custom Binding

        VetCase_binding.Bind(this, v, mCase(), mandatoryFields, invisibleFields, lang, pageNumber);

        // business rules - initail states
        if(pageNumber == 0) {
            if (mCase().getTentativeDiagnosis() == 0) {
                EidssAndroidHelpers.DisableDate(R.id.datTentativeDiagnosisDate, R.id.datTentativeDiagnosisDateClearButton, v);
            }
        }else if(pageNumber == 1) {
            EidssAndroidHelpers.DisableAddress(mCase().getSettlement() == 0, v);
        }
    }

    @Override
    public void onCreateOptionsMenu(Menu menu, MenuInflater inflater) {

        inflater.inflate(R.menu.case_toolbar, menu);
    }

    /* Called whenever we call invalidateOptionsMenu() */
    @Override
    public void onPrepareOptionsMenu(Menu menu) {
        menu.findItem(R.id.Remove).setVisible(mCase().getId() != 0);
        //menu.findItem(R.id.Refresh).setVisible(mCase().getId() != 0);

        View unSelectButton = mActivity.findViewById(R.id.unSelect);
        if (unSelectButton != null)
            unSelectButton.setVisibility(View.GONE);
        View separator = mActivity.findViewById(R.id.toolbarSeparator);
        if (separator != null)
            separator.setVisibility(View.GONE);
        View numberOfSelected = mActivity.findViewById(R.id.numberOfSelected);
        if (numberOfSelected != null)
            numberOfSelected.setVisibility(View.GONE);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {

        switch (item.getItemId()) {
            case android.R.id.home:
                mActivity.Home();
                return true;
            case R.id.Save:
                mActivity.Save();
                return true;
            case R.id.Remove:
                mActivity.Remove();
                return true;
            case R.id.Refresh:
                final View menuItemView = mActivity.findViewById(R.id.Refresh);
                PopupMenu popupMenu = new PopupMenu(mActivity, menuItemView);//, R.style.PopupMenu
                popupMenu.inflate(R.menu.synchronize_one_menu);
                popupMenu.setOnMenuItemClickListener(new PopupMenu.OnMenuItemClickListener() {
                    @Override
                    public boolean onMenuItemClick(MenuItem item) {
                        onSyncMenuItemClick(item);
                        return true;
                    }
                });
                popupMenu.show();
                return true;

            default:
                return super.onOptionsItemSelected(item);
        }
    }


    public boolean onSyncMenuItemClick(android.view.MenuItem item) {
        switch (item.getItemId()) {
            case R.id.IDM_ONLINE:
                mActivity.OnLine();
                break;
            case R.id.IDM_OFFLINE:
                mActivity.OffLine();
                break;
            default:
                return super.onContextItemSelected(item);
        }
        return true;

    }

    @Override
    public void onLocationResultAvailable(Location location) {
        if (location != null) {
            mCase().setLongitude(location.getLongitude());
            mCase().setLatitude(location.getLatitude());
            mActivity.runOnUiThread(new Runnable() {
                @Override
                public void run() {
                    ((EditText) mActivity.findViewById(R.id.dblLongitude)).setText(String.format("%.4f", mCase().getLongitude()));
                    ((EditText) mActivity.findViewById(R.id.dblLatitude)).setText(String.format("%.4f", mCase().getLatitude()));
                }
            });
        }else
            EidssAndroidHelpers.AlertOkResultDialog.ShowWarning(mActivity.getSupportFragmentManager(), VetCase_binding.NO_ACTION_ID, R.string.LocationCouldNotGet);
    }

    @Override
    public Loader<Cursor> onCreateLoader(int id, Bundle args) {
        String[] sels;
        switch (id) {
            case LOADER_REGIONS:
                sels = new String[2];
                sels[0] = lang;
                sels[1] = String.valueOf(mCase().getRegion());
                return new CursorLoader(mActivity, RegionsProvider.CONTENT_URI, null, null, sels, null);
            case LOADER_RAYONS:
                sels = new String[3];
                sels[0] = lang;
                sels[1] = String.valueOf(mCase().getRegion());
                sels[2] = String.valueOf(mCase().getRayon());
                return new CursorLoader(mActivity, RayonsProvider.CONTENT_URI, null, null, sels, null);
            case LOADER_SETTLEMENTS:
                sels = new String[3];
                sels[0] = lang;
                sels[1] = String.valueOf(mCase().getRayon());
                sels[2] = String.valueOf(mCase().getSettlement());
                return new CursorLoader(mActivity, SettlementsProvider.CONTENT_URI, null, null, sels, null);
            /*case LOADER_FARM:
                sels = new String[1];
                sels[0] = String.valueOf(mCase().getRootFarm());
                return new CursorLoader(mActivity, FarmsProvider.CONTENT_URI, null, null, sels, null);*/
            default:
                return VetCase_binding.onCreateLoader(id, lang, mCase(), mActivity);
        }
    }

    @Override
    public void onLoadFinished(Loader<Cursor> loader, Cursor data) {
        switch (loader.getId()) {
            case LOADER_REGIONS:
                EidssDatabase.SetRegions(data);
                onLoadFinishedRegions();
                break;
            case LOADER_RAYONS:
                onLoadFinishedRayons(data);
                break;
            case LOADER_SETTLEMENTS:
                onLoadFinishedSettlements(data);
                break;
            /*case LOADER_FARM:
                onLoadFinishedFarm(data);
                break;*/
            default:
                VetCase_binding.onLoadFinished(loader.getId(), data, mCase());
                break;
        }
    }

    /*private void onLoadFinishedFarm(Cursor data) {
        mFarmAdapter.swapCursor(data);
        int rowCount = data.getCount();
        if (rowCount > 1)
        {
            // set selected
            int cpos = 0;
            for (int i = 0; i < rowCount; i++){
                data.moveToPosition(i);
                long temp = data.getLong(0);
                if (temp == mCase().getRootFarm())
                {
                    cpos = i;
                    break;
                }
            }
            farms.setSelection(cpos);
            farms.setEnabled(true);
        }
        else
        {
            farms.setEnabled(false);
        }
    }*/

    private void onLoadFinishedRegions() {
        boolean found = LookupBindAfter(regions, EidssDatabase.GetRegions(), mCase().getRegion(), true, RegionsProvider.CONTENT_URI);
        if (EidssDatabase.GetRegions().size() > 1)
        {
            regions.setEnabled(true);
            if (mCase().getRegion() > 0 && found) {
                updateRayons();
                updateSettlements();
            }
        }
        else
        {
            regions.setEnabled(false);
            rayons.setEnabled(false);
            settlements.setEnabled(false);
        }
    }

    private void onLoadFinishedRayons(Cursor data) {
        mRayonsAdapter.swapCursor(data);
        int rowCount = data.getCount();
        if (rowCount > 1) {
            // set selected
            int cpos = 0;
            for (int i = 0; i < rowCount; i++) {
                data.moveToPosition(i);
                long temp = data.getLong(0);
                if (temp == mCase().getRayon()) {
                    cpos = i;
                    break;
                }
            }
            rayons.setSelection(cpos);

            rayons.setEnabled(true);
            if (cpos > 0)
                updateSettlements();
        } else {
            rayons.setEnabled(false);
        }
    }

    private void onLoadFinishedSettlements(Cursor data) {
        mSettlementsAdapter.swapCursor(data);
        int rowCount = data.getCount();
        if (rowCount > 1) {
            // set selected
            int cpos = 0;
            for (int i = 0; i < rowCount; i++) {
                data.moveToPosition(i);
                long temp = data.getLong(0);
                if (temp == mCase().getSettlement()) {
                    cpos = i;
                    break;
                }
            }
            settlements.setSelection(cpos);
            settlements.setEnabled(true);
        } else {
            settlements.setEnabled(false);
        }
    }

    @Override
    public void onLoaderReset(Loader<Cursor> loader) {
        switch (loader.getId()) {
            case LOADER_REGIONS:
                //mRegionsAdapter.swapCursor(null);
                break;
            case LOADER_RAYONS:
                mRayonsAdapter.swapCursor(null);
                break;
            case LOADER_SETTLEMENTS:
                mSettlementsAdapter.swapCursor(null);
                break;
            /*case LOADER_FARM:
                mFarmAdapter.swapCursor(null);
                break;*/
            default:
                VetCase_binding.onLoaderReset(loader.getId());
                break;
        }
    }

    private void updateRayons() {
        mActivity.getSupportLoaderManager().restartLoader(LOADER_RAYONS, null, this);
    }

    private void updateSettlements() {
        mActivity.getSupportLoaderManager().restartLoader(LOADER_SETTLEMENTS, null, this);
    }

    private VetCase mCase() {
        return (VetCase)mActivity.get();
    }
}
