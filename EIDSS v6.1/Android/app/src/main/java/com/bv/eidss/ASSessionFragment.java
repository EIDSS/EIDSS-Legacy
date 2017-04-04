package com.bv.eidss;


import android.app.Activity;
import android.content.Context;
import android.database.Cursor;
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
import android.widget.Spinner;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.generated.ASSession_binding;
import com.bv.eidss.model.BaseReferenceType;
import com.bv.eidss.model.GisBaseReference;
import com.bv.eidss.model.ASSession;
import com.bv.eidss.model.interfaces.Constants;
import com.bv.eidss.utils.EidssUtils;

import java.util.List;


public class ASSessionFragment extends EidssBaseBindableFragment
        implements  LoaderManager.LoaderCallbacks<Cursor> {
    //private static final String ARG_PARAM1 = "as";
    private static final String ARG_PAGE_NUMBER = "arg_page_number";
    private int pageNumber;

    private ASSessionActivity mActivity;

    private static final int LOADER_REGIONS = 1;
    private static final int LOADER_RAYONS = 2;
    private static final int LOADER_SETTLEMENTS = 3;
    private static final int LOADER_CAMPAIGN = 4;
    private static final int LOADER_MonitoringSessionStatus = 5;
    SimpleCursorAdapter mCampaignAdapter, mRayonsAdapter, mSettlementsAdapter;
    Spinner campaigns, regions, rayons, settlements;
    SimpleCursorAdapter adapterMonitoringSessionStatus;
    Spinner spinnerMonitoringSessionStatus;
    public Boolean ToChange = false;

    private static String lang;


    public ASSessionFragment() {
        // Required empty public constructor
    }

    public static ASSessionFragment newInstance(int page) {
        ASSessionFragment fragment = new ASSessionFragment();
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
            mActivity = (ASSessionActivity) context;
        }
    }

    public void CampaignLookupSetSelection(){
        long curCampaign = mCase().getCampaign();
        int selection;
        for (selection = 0; selection < mCampaignAdapter.getCount(); selection++){
            if (mCampaignAdapter.getItemId(selection) == curCampaign){
                break;
            }
        }
        campaigns.setSelection(selection);
    }

    private long idSaveCampaign;
    public void SetCampaign(){
        View v = getView();
        EidssDatabase mDb = new EidssDatabase(mActivity);
        final List<String> mandatoryFields = mDb.MandatoryFields();
        final List<String> invisibleFields = mDb.InvisibleFields();
        mCase().ForceSetCampaign(mDb, idSaveCampaign);
        mDb.close();
        LookupBindReadonly(R.id.idfsCampaignType, v, ReferenciesProvider.CONTENT_URI, mCase().getCampaignType(), ASSession.eidss_CampaignType, mandatoryFields, invisibleFields);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        final View v;
        if(pageNumber == 0)
            v = inflater.inflate(R.layout.as_session_layout_0, container, false);
        else
            v = inflater.inflate(R.layout.as_session_layout_1, container, false);

        final List<String> mandatoryFields = EidssDatabase.GetMandatoryFields();
        final List<String> invisibleFields = EidssDatabase.GetInvisibleFields();

        // Custom Binding
        if(pageNumber == 0)
        {
            spinnerMonitoringSessionStatus = (Spinner)v.findViewById(R.id.idfsMonitoringSessionStatus);
            adapterMonitoringSessionStatus = LookupBind(spinnerMonitoringSessionStatus, v, ReferenciesProvider.NAME,
                    new AdapterView.OnItemSelectedListener(){
                        public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                            if (mCase().getMonitoringSessionStatus() != id) {
                                mCase().setMonitoringSessionStatus(id);
                                if (id == Constants.AsSessionStatus_Closed) {
                                    EidssAndroidHelpers.DisableDate(R.id.datStartDate, R.id.datStartDateClearButton, v);
                                    EidssAndroidHelpers.DisableDate(R.id.datEndDate, R.id.datEndDateClearButton, v);
                                    EidssUtils.setEnabled(campaigns, false);
                                    mActivity.ReloadReadOnlyTabs();
                                } else {
                                    EidssAndroidHelpers.EnableDate(R.id.datStartDate, R.id.datStartDateClearButton, v);
                                    EidssAndroidHelpers.EnableDate(R.id.datEndDate, R.id.datEndDateClearButton, v);
                                    EidssUtils.setEnabled(campaigns, true);
                                    mActivity.ReloadReadOnlyTabs();
                                }
                            }
                        }
                        public void onNothingSelected(AdapterView<?> arg0) {
                            mCase().setMonitoringSessionStatus(0);
                            EidssAndroidHelpers.EnableDate(R.id.datStartDate, R.id.datStartDateClearButton, v);
                            EidssAndroidHelpers.EnableDate(R.id.datEndDate, R.id.datEndDateClearButton, v);
                            EidssUtils.setEnabled(campaigns, true);
                            mActivity.ReloadReadOnlyTabs();
                        }
                    },
                    ASSession.eidss_MonitoringSessionStatus, mandatoryFields, invisibleFields);
            if (adapterMonitoringSessionStatus != null)
                getActivity().getSupportLoaderManager().initLoader(LOADER_MonitoringSessionStatus, null, this);

            campaigns = (Spinner) v.findViewById(R.id.idfCampaign);
            mCampaignAdapter = LookupBind(campaigns, v, ReferenciesProvider.NAME,
                    new AdapterView.OnItemSelectedListener(){
                        public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                            if (mCase().getCampaign() != id) {
                                EidssDatabase mDb = new EidssDatabase(mActivity);
                                int result = mCase().SetCampaign(mDb, id);
                                mDb.close();
                                if (result != 0) {
                                    switch (result) {
                                        case R.string.SessionPeriodDoesNotMatchCampaignPeriod:
                                        case R.string.SessionContainsSpeciesAbsentInCampaign:
                                            EidssAndroidHelpers.AlertOkResultDialog.ShowOk(getActivity().getSupportFragmentManager(), result, result);
                                            break;
                                        case R.string.SessionDiseasesDiffersFromCampaignDiseases:
                                        case R.string.CampaignDiseasesListIsBlank:
                                            idSaveCampaign = id;
                                            EidssAndroidHelpers.AlertOkResultDialog.ShowQuestion(getActivity().getSupportFragmentManager(), result, result);
                                            break;
                                    }
                                } else {
                                    LookupBindReadonly(R.id.idfsCampaignType, v, ReferenciesProvider.CONTENT_URI, mCase().getCampaignType(), ASSession.eidss_CampaignType, mandatoryFields, invisibleFields);
                                }
                            }
                        }
                        public void onNothingSelected(AdapterView<?> arg0) {
                            mCase().setCampaign(0);
                            mCase().setCampaignType(0);
                            LookupBindReadonly(R.id.idfsCampaignType, v, ReferenciesProvider.CONTENT_URI, mCase().getCampaignType(), ASSession.eidss_CampaignType, mandatoryFields, invisibleFields);
                        }
                    },
                    ASSession.eidss_Campaign, mandatoryFields, invisibleFields);
            if (mCampaignAdapter != null)
                mActivity.getSupportLoaderManager().initLoader(LOADER_CAMPAIGN, null, this);

            DisplayDateTime(R.id.datCreateDate, v, mCase().getCreateDate());
        }
        else if(pageNumber == 1) {
            regions = (Spinner) v.findViewById(R.id.idfsRegion);
            rayons = (Spinner) v.findViewById(R.id.idfsRayon);
            settlements = (Spinner) v.findViewById(R.id.idfsSettlement);

            LookupBindBefore(regions, v,
                    new AdapterView.OnItemSelectedListener() {
                        public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                            long ident = ((GisBaseReference) parent.getSelectedItem()).idfsBaseReference;
                            if (mCase().getRegion() != ident) {
                                mCase().setRegion(ident);
                                mCase().setRayon(0);
                                mCase().setSettlement(0);

                                EidssUtils.setEnabled(rayons, false);
                                EidssUtils.setEnabled(settlements, false);

                                // Update rayons spinners
                                updateRayons();
                            }
                        }

                        public void onNothingSelected(AdapterView<?> arg0) {
                        }
                    }, ASSession.eidss_Region, mandatoryFields, invisibleFields);

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

                                EidssUtils.setEnabled(settlements, false);
                                // Update Settlements spinners
                                updateSettlements();
                            }
                        }

                        public void onNothingSelected(AdapterView<?> arg0) {
                        }
                    }, ASSession.eidss_Rayon, mandatoryFields, invisibleFields);
            mSettlementsAdapter = LookupBind(settlements, v, SettlementsProvider.NAME,
                    new AdapterView.OnItemSelectedListener() {
                        public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                            if (mCase().getSettlement() != id) {
                                mCase().setSettlement(id);
                            }
                        }

                        public void onNothingSelected(AdapterView<?> arg0) {
                        }
                    }, ASSession.eidss_Settlement, mandatoryFields, invisibleFields);
        }
        // End of Custom Binding

        ASSession_binding.Bind(this, v, mCase(), mandatoryFields, invisibleFields, lang, pageNumber);

        // business rules - initail states
        if(pageNumber == 0) {
            if (/*mCase().getMonitoringSession() != 0 || */mCase().getMonitoringSessionStatus() == Constants.AsSessionStatus_Closed) {
                EidssAndroidHelpers.DisableDate(R.id.datStartDate, R.id.datStartDateClearButton, v);
                EidssAndroidHelpers.DisableDate(R.id.datEndDate, R.id.datEndDateClearButton, v);
            }
        }else if(pageNumber == 1) {
        }


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
                popupMenu.inflate(R.menu.synchronize_session_one_menu);
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


    public boolean onSyncMenuItemClick(MenuItem item) {
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
    public Loader<Cursor> onCreateLoader(int id, Bundle args) {
        switch (id) {
            case LOADER_MonitoringSessionStatus:
                String[] sels4 = new String[3];
                sels4[0] = lang;
                sels4[1] = String.valueOf(BaseReferenceType.rftMonitoringSessionStatus);
                sels4[2] = String.valueOf(mCase().getMonitoringSessionStatus());
                return new CursorLoader(mActivity, ReferenciesProvider.CONTENT_URI, null, null, sels4, null);
            case LOADER_CAMPAIGN:
                String[] sels3 = new String[1];
                sels3[0] = String.valueOf(mCase().getCampaign());
                return new CursorLoader(mActivity, CampaignsProvider.CONTENT_URI, null, null, sels3, null);
            case LOADER_REGIONS:
                String[] sels = new String[2];
                sels[0] = lang;
                sels[1] = String.valueOf(mCase().getRegion());
                return new CursorLoader(mActivity, RegionsProvider.CONTENT_URI, null, null, sels, null);
            case LOADER_RAYONS:
                String[] sels1 = new String[3];
                sels1[0] = lang;
                sels1[1] = String.valueOf(mCase().getRegion());
                sels1[2] = String.valueOf(mCase().getRayon());
                return new CursorLoader(mActivity, RayonsProvider.CONTENT_URI, null, null, sels1, null);
            case LOADER_SETTLEMENTS:
                String[] sels2 = new String[3];
                sels2[0] = lang;
                sels2[1] = String.valueOf(mCase().getRayon());
                sels2[2] = String.valueOf(mCase().getSettlement());
                return new CursorLoader(mActivity, SettlementsProvider.CONTENT_URI, null, null, sels2, null);
            default:
                return ASSession_binding.onCreateLoader(id, lang, mCase(), mActivity);
        }
    }

    @Override
    public void onLoadFinished(Loader<Cursor> loader, Cursor data) {
        switch (loader.getId()) {
            case LOADER_MonitoringSessionStatus:
                onLoadFinishedMonitoringSessionStatus(data);
                break;
            case LOADER_CAMPAIGN:
                onLoadFinishedCampaign(data);
                break;
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
            default:
                ASSession_binding.onLoadFinished(loader.getId(), data, mCase());
                break;
        }
    }

    private void onLoadFinishedMonitoringSessionStatus(Cursor data)
    {
        adapterMonitoringSessionStatus.swapCursor(data);
        int rowCount = data.getCount();
        if (rowCount > 1)
        {
            // set selected
            int cpos = 0;
            for (int i = 0; i < rowCount; i++){
                data.moveToPosition(i);
                long temp = data.getLong(0);
                if (temp == mCase().getMonitoringSessionStatus())
                {
                    cpos = i;
                    break;
                }
            }
            spinnerMonitoringSessionStatus.setSelection(cpos);
            spinnerMonitoringSessionStatus.setEnabled(mCase().getMonitoringSession() == 0);
        }
        else
        {
            spinnerMonitoringSessionStatus.setEnabled(false);
        }
    }

    private void onLoadFinishedCampaign(Cursor data) {
        mCampaignAdapter.swapCursor(data);
        int rowCount = data.getCount();
        if (rowCount > 1)
        {
            // set selected
            int cpos = 0;
            for (int i = 0; i < rowCount; i++){
                data.moveToPosition(i);
                long temp = data.getLong(0);
                if (temp == mCase().getCampaign())
                {
                    cpos = i;
                    break;
                }
            }
            campaigns.setSelection(cpos);
            EidssUtils.setEnabled(campaigns, mCase().isNewNotClosed());
        }
        else
        {
            EidssUtils.setEnabled(campaigns, false);
        }
    }

    private void onLoadFinishedRegions() {
        boolean found = LookupBindAfter(regions, EidssDatabase.GetRegions(), mCase().getRegion(), true, RegionsProvider.CONTENT_URI);
        if (EidssDatabase.GetRegions().size() > 0)
        {
            regions.setEnabled(mCase().isNewNotClosed());
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
        if (rowCount > 0) {
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
            EidssUtils.setEnabled(rayons, mCase().isNewNotClosed());
            if (cpos > 0)
                updateSettlements();
        } else {
            EidssUtils.setEnabled(rayons, false);
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
            settlements.setEnabled(mCase().isNewNotClosed());
        } else {
            settlements.setEnabled(false);
        }
    }

    @Override
    public void onLoaderReset(Loader<Cursor> loader) {
        switch (loader.getId()) {
            case LOADER_MonitoringSessionStatus:
                adapterMonitoringSessionStatus.swapCursor(null);
                break;
            case LOADER_CAMPAIGN:
                mCampaignAdapter.swapCursor(null);
                break;
            case LOADER_REGIONS:
                //mRegionsAdapter.swapCursor(null);
                break;
            case LOADER_RAYONS:
                mRayonsAdapter.swapCursor(null);
                break;
            case LOADER_SETTLEMENTS:
                mSettlementsAdapter.swapCursor(null);
                break;
            default:
                ASSession_binding.onLoaderReset(loader.getId());
                break;
        }
    }

    private void updateRayons() {
        mActivity.getSupportLoaderManager().restartLoader(LOADER_RAYONS, null, this);
    }

    private void updateSettlements() {
        mActivity.getSupportLoaderManager().restartLoader(LOADER_SETTLEMENTS, null, this);
    }

    private ASSession mCase() {
        return (ASSession)mActivity.get();
    }
}
