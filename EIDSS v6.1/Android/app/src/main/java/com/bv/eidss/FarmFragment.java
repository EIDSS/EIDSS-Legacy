package com.bv.eidss;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.location.Location;
import android.os.Bundle;
import android.support.v4.app.LoaderManager;
import android.support.v4.content.CursorLoader;
import android.support.v4.content.Loader;
import android.support.v4.widget.SimpleCursorAdapter;
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
import com.bv.eidss.generated.Farm_binding;
import com.bv.eidss.model.BaseReference;
import com.bv.eidss.model.Farm;
import com.bv.eidss.model.GisBaseReference;
import com.bv.eidss.model.interfaces.LocationResultListener;
import com.bv.eidss.utils.EidssUtils;
import com.bv.eidss.utils.OnEditTextChangeListener;

import java.util.List;


public class FarmFragment extends EidssBaseBindableFragment
    implements  LoaderManager.LoaderCallbacks<Cursor>,
        LocationResultListener {

    private FarmActivity mActivity;

    private static final int LOADER_REGIONS = 1;
    private static final int LOADER_RAYONS = 2;
    private static final int LOADER_SETTLEMENTS = 3;
    //private static final int LOADER_FARM = 4;

    SimpleCursorAdapter /*mFarmAdapter,*/ mRayonsAdapter, mSettlementsAdapter;
    Spinner /*farms,*/ regions, rayons, settlements;

    public FarmFragment() {
        // Required empty public constructor
    }

    public static FarmFragment newInstance() {
        return new FarmFragment();
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
            mActivity = (FarmActivity) context;
        }
    }

    private String buildFarmComposeName(String name, Farm f){
        return name + " / " + (f == null ? "" : (
            (f.getOwnerLastName() == null ? "" : f.getOwnerLastName() + " ") +
            (f.getOwnerFirstName() == null ? "" : f.getOwnerFirstName() + " ") +
            (f.getOwnerMiddleName() == null ? "" : f.getOwnerMiddleName() + " ")
        ));
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        final View v = inflater.inflate(R.layout.farm_layout, container, false);

        final List<String> mandatoryFields = EidssDatabase.GetMandatoryFields();
        final List<String> invisibleFields = EidssDatabase.GetInvisibleFields();

        regions = (Spinner) v.findViewById(R.id.idfsRegion);
        rayons = (Spinner) v.findViewById(R.id.idfsRayon);
        settlements = (Spinner) v.findViewById(R.id.idfsSettlement);
        //farms = (Spinner) v.findViewById(R.id.idfRootFarm);

        EidssDatabase mDb = new EidssDatabase(getContext());
        SQLiteDatabase db = mDb.getReadableDatabase();
        String[] selectionArgs = new String[]{String.valueOf(mActivity.mFarm.getRootFarm())};
        String sql = mActivity.mFarm.getRootFarm() == 0
            ? EidssDatabase.select_sql_farms_prov.replace("[NewFarm]", buildFarmComposeName(mActivity.mFarm.getFarmName(), mActivity.mFarm))
            : EidssDatabase.select_sql_farms_prov.replace("[NewFarm]", mActivity.getResources().getString(R.string.NewFarm));
        Cursor data = db.rawQuery(sql, selectionArgs);
        final List<BaseReference> list = EidssDatabase.GetReferenceListFromCursor(data);
        db.close();
        LookupBind(R.id.idfRootFarm, v, mActivity.mFarm.getRootFarm(), list,
                new AdapterView.OnItemClickListener() {
                    @Override
                    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                        long itemId = ((BaseReference) parent.getItemAtPosition(position)).idfsBaseReference;
                        if (itemId != mActivity.mFarm.getRootFarm()) {
                            mActivity.mFarm.SetRoot(mActivity, itemId, mActivity.mASSession);
                            bind(v);
                        }
                    }
                },
                new OnEditTextChangeListener() {
                    @Override
                    public void onEditTextChanged(String text) {

                        for(int i = 0; i < list.size(); i++){
                            BaseReference item = list.get(i);
                            if (item.idfsBaseReference == mActivity.mFarm.getRootFarm()){
                                mActivity.mFarm.setFarmName(text);
                                item.name = buildFarmComposeName(text, mActivity.mFarm);
                                break;
                            }
                        }

                    }
                },
                true, Farm.eidss_RootFarm, mandatoryFields, invisibleFields);

        bind(v);

        // hide soft keyboard
        mActivity.getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_HIDDEN);
        return v;
    }

    private void bind(final View v){
        final List<String> mandatoryFields = EidssDatabase.GetMandatoryFields();
        final List<String> invisibleFields = EidssDatabase.GetInvisibleFields();

        /*mFarmAdapter = LookupBind(farms, v, FarmsProvider.NAME,
                new AdapterView.OnItemSelectedListener(){
                    public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                        if (mActivity.mFarm.getRootFarm() != id) {
                            mActivity.mFarm.SetRoot(mActivity, id, mActivity.mASSession);
                            bind(v);
                        }
                    }
                    public void onNothingSelected(AdapterView<?> arg0) {
                        mActivity.mFarm.SetRoot(mActivity, 0, mActivity.mASSession);
                        bind(v);
                    }
                },
                Farm.eidss_RootFarm, mandatoryFields, invisibleFields);
        if (mFarmAdapter != null)
            mActivity.getSupportLoaderManager().initLoader(LOADER_FARM, null, this);*/

        LookupBindBefore(regions, v,
                new AdapterView.OnItemSelectedListener() {
                    public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                        long ident = ((GisBaseReference) parent.getSelectedItem()).idfsBaseReference;
                        if (mActivity.mFarm.getRegion() != ident) {
                            mActivity.mFarm.setRegion(ident);
                            mActivity.mFarm.setRayon(0);
                            mActivity.mFarm.setSettlement(0);

                            rayons.setEnabled(false);
                            settlements.setEnabled(false);

                            // Update rayons spinners
                            updateRayons();
                        }
                    }

                    public void onNothingSelected(AdapterView<?> arg0) {
                    }
                }, Farm.eidss_Region, mandatoryFields, invisibleFields);

        if(EidssDatabase.GetRegions() != null)
            onLoadFinishedRegions();
        else
            mActivity.getSupportLoaderManager().initLoader(LOADER_REGIONS, null, this);

        mRayonsAdapter = LookupBind(rayons, v, RayonsProvider.NAME,
                new AdapterView.OnItemSelectedListener() {
                    public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                        if (mActivity.mFarm.getRayon() != id) {
                            mActivity.mFarm.setRayon(id);
                            mActivity.mFarm.setSettlement(0);

                            settlements.setEnabled(false);
                            // Update Settlements spinners
                            updateSettlements();
                        }
                    }

                    public void onNothingSelected(AdapterView<?> arg0) {
                    }
                }, Farm.eidss_Rayon, mandatoryFields, invisibleFields);
        mSettlementsAdapter = LookupBind(settlements, v, SettlementsProvider.NAME,
                new AdapterView.OnItemSelectedListener() {
                    public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                        if (mActivity.mFarm.getSettlement() != id) {
                            mActivity.mFarm.setSettlement(id);
                        }
                    }

                    public void onNothingSelected(AdapterView<?> arg0) {
                    }
                }, Farm.eidss_Settlement, mandatoryFields, invisibleFields);

        // End of Custom Binding

        Farm_binding.Bind(this, v, mActivity.mFarm, mandatoryFields, invisibleFields, EidssUtils.getCurrentLanguage(), 0);
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
    public void onLocationResultAvailable(Location location) {
        if (location != null) {
            mActivity.mFarm.setLongitude(location.getLongitude());
            mActivity.mFarm.setLatitude(location.getLatitude());
            mActivity.runOnUiThread(new Runnable() {
                @Override
                public void run() {
                    ((EditText) mActivity.findViewById(R.id.dblLongitude)).setText(String.format("%.4f", mActivity.mFarm.getLongitude()));
                    ((EditText) mActivity.findViewById(R.id.dblLatitude)).setText(String.format("%.4f", mActivity.mFarm.getLatitude()));
                }
            });
        }else
            EidssAndroidHelpers.AlertOkResultDialog.ShowWarning(mActivity.getSupportFragmentManager(), Farm_binding.NO_ACTION_ID, R.string.LocationCouldNotGet);
    }

    @Override
    public Loader<Cursor> onCreateLoader(int id, Bundle args) {
        String lang = EidssUtils.getCurrentLanguage();
        String[] sels;
        switch (id)
        {
            case LOADER_REGIONS:
                sels = new String[2];
                sels[0] = lang;
                sels[1] = String.valueOf(mActivity.mFarm.getRegion());
                return new CursorLoader(mActivity, RegionsProvider.CONTENT_URI, null, null, sels, null);
            case LOADER_RAYONS:
                sels = new String[3];
                sels[0] = lang;
                sels[1] = String.valueOf(mActivity.mFarm.getRegion());
                sels[2] = String.valueOf(mActivity.mFarm.getRayon());
                return new CursorLoader(mActivity, RayonsProvider.CONTENT_URI, null, null, sels, null);
            case LOADER_SETTLEMENTS:
                sels = new String[3];
                sels[0] = lang;
                sels[1] = String.valueOf(mActivity.mFarm.getRayon());
                sels[2] = String.valueOf(mActivity.mFarm.getSettlement());
                return new CursorLoader(mActivity, SettlementsProvider.CONTENT_URI, null, null, sels, null);
            /*case LOADER_FARM:
                sels = new String[1];
                sels[0] = String.valueOf(mActivity.mFarm.getRootFarm());
                return new CursorLoader(mActivity, FarmsProvider.CONTENT_URI, null, null, sels, null);*/
            default:
                return Farm_binding.onCreateLoader(id, EidssUtils.getCurrentLanguage(), mActivity.mFarm, mActivity);
        }
    }

    @Override
    public void onLoadFinished(Loader<Cursor> loader, Cursor data) {
        switch (loader.getId())
        {
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
                Farm_binding.onLoadFinished(loader.getId(), data, mActivity.mFarm);
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
                if (temp == mActivity.mFarm.getRootFarm())
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
        boolean found = LookupBindAfter(regions, EidssDatabase.GetRegions(), mActivity.mFarm.getRegion(), true, RegionsProvider.CONTENT_URI);
        if (EidssDatabase.GetRegions().size() > 1)
        {
            //regions.setEnabled(mActivity.mFarm.getMonitoringSessionStatus() != Constants.AsSessionStatus_Closed);
            regions.setEnabled(/*mActivity.mFarm.getFarm() == 0 && */mActivity.mFarm.getRootFarm() == 0);
            if (mActivity.mFarm.getRegion() > 0 && found) {
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
                if (temp == mActivity.mFarm.getRayon()) {
                    cpos = i;
                    break;
                }
            }
            rayons.setSelection(cpos);
            //rayons.setEnabled(mActivity.mFarm.getMonitoringSessionStatus() != Constants.AsSessionStatus_Closed);
            rayons.setEnabled(/*mActivity.mFarm.getFarm() == 0 && */mActivity.mFarm.getRootFarm() == 0);
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
                if (temp == mActivity.mFarm.getSettlement()) {
                    cpos = i;
                    break;
                }
            }
            settlements.setSelection(cpos);
            //settlements.setEnabled(mActivity.mFarm.getMonitoringSessionStatus() != Constants.AsSessionStatus_Closed);
            settlements.setEnabled(/*mActivity.mFarm.getFarm() == 0 && */mActivity.mFarm.getRootFarm() == 0);
        } else {
            settlements.setEnabled(false);
        }
    }

    @Override
    public void onLoaderReset(Loader<Cursor> loader) {
        switch (loader.getId())
        {
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
                Farm_binding.onLoaderReset(loader.getId());
                break;
        }
    }

    private void updateRayons() {
        mActivity.getSupportLoaderManager().restartLoader(LOADER_RAYONS, null, this);
    }

    private void updateSettlements() {
        mActivity.getSupportLoaderManager().restartLoader(LOADER_SETTLEMENTS, null, this);
    }

}
