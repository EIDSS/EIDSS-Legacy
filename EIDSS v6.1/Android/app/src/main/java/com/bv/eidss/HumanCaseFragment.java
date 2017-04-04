package com.bv.eidss;


import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.location.Location;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.LoaderManager;
import android.support.v4.content.CursorLoader;
import android.support.v4.content.Loader;
import android.support.v4.widget.SimpleCursorAdapter;
import android.support.v7.widget.PopupMenu;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.widget.AdapterView;
import android.widget.AutoCompleteTextView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.generated.HumanCase_binding;
import com.bv.eidss.model.BaseReference;
import com.bv.eidss.model.BaseReferenceType;
import com.bv.eidss.model.CaseTypeHACode;
import com.bv.eidss.model.GisBaseReference;
import com.bv.eidss.model.HumanCase;
import com.bv.eidss.model.Options;
import com.bv.eidss.model.interfaces.Constants;
import com.bv.eidss.model.interfaces.LocationResultListener;
import com.bv.eidss.utils.DateHelpers;
import com.bv.eidss.utils.EidssUtils;
import com.bv.eidss.utils.OnEditTextChangeListener;

import java.util.List;


public class HumanCaseFragment extends EidssBaseBindableFragment
        implements  LoaderManager.LoaderCallbacks<Cursor>,
                    LocationResultListener {
    private static final String ARG_PAGE_NUMBER = "arg_page_number";
    private int pageNumber;

    private HumanCaseActivity mActivity;

    private static String lang;

    private static final int LOADER_REGIONS = 1;
    private static final int LOADER_RAYONS = 2;
    private static final int LOADER_SETTLEMENTS = 3;
    private static final int LOADER_InstitutionName = 4;

    private static SimpleCursorAdapter mRayonsAdapter, mSettlementsAdapter;
    private static Spinner regions, rayons, settlements;

    private static AutoCompleteTextView acHospital, acSoughtCareFacility;

    private static final int LOADER_NotCollectedReason = 5;
    private static SimpleCursorAdapter adapterNotCollectedReason;
    private static Spinner spinnerNotCollectedReason;


    public HumanCaseFragment() {
        // Required empty public constructor
    }

    public static HumanCaseFragment newInstance(int page) {
        HumanCaseFragment fragment = new HumanCaseFragment();
        Bundle args = new Bundle();
        //args.putParcelable(ARG_PARAM1, Case);
        args.putInt(ARG_PAGE_NUMBER, page);
        fragment.setArguments(args);

        return fragment;
    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);

        if (context instanceof Activity) {
            mActivity = (HumanCaseActivity) context;
        }
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setHasOptionsMenu(true);

        if (getArguments() != null) {
            pageNumber = getArguments().getInt(ARG_PAGE_NUMBER);
        }
        lang = EidssUtils.getCurrentLanguage();
        Log.d("HumanCaseFragment", "onCreate");
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        final View v;
        if(pageNumber == 0)
            v = inflater.inflate(R.layout.human_case_layout_0, container, false);
        else if(pageNumber == 1)
            v = inflater.inflate(R.layout.human_case_layout_1, container, false);
        else if(pageNumber == 2)
            v = inflater.inflate(R.layout.human_case_layout_2, container, false);
        else if(pageNumber == 3)
            v = inflater.inflate(R.layout.human_case_layout_3, container, false);
        else
            v = inflater.inflate(R.layout.human_case_layout_4, container, false);

        Log.d("HumanCaseFragment", Integer.toString(pageNumber));

        final List<String> mandatoryFields = EidssDatabase.GetMandatoryFields();
        final List<String> invisibleFields = EidssDatabase.GetInvisibleFields();

        // Custom Binding
        if(pageNumber == 0) {
            DisplayDateTime(R.id.datCreateDate, v, mCase().getCreateDate());
            LookupBind(R.id.idfsTentativeDiagnosis, v, mCase().getTentativeDiagnosis(), BaseReferenceType.rftDiagnosis, CaseTypeHACode.HUMAN,
                    new AdapterView.OnItemSelectedListener() {
                        public void onItemSelected(AdapterView<?> list, View arg1, int arg2, long arg3) {
                            long itemId = ((BaseReference) list.getSelectedItem()).idfsBaseReference;
                            mCase().setTentativeDiagnosis(itemId);
                            mActivity.SetDeterminant(itemId);
                        }

                        public void onNothingSelected(AdapterView<?> arg0) {
                            mCase().setTentativeDiagnosis(0);
                            mActivity.SetDeterminant(0);
                        }
                    }, true, HumanCase.eidss_TentativeDiagnosis, mandatoryFields, invisibleFields);
        }else if(pageNumber == 1) {
            LookupBind(R.id.idfsHumanAgeType, v, mCase().getHumanAgeType(), BaseReferenceType.rftHumanAgeType, CaseTypeHACode.HUMAN,
                    new AdapterView.OnItemSelectedListener() {
                        public void onItemSelected(AdapterView<?> list, View arg1, int arg2, long arg3) {
                            mCase().setHumanAgeType(((BaseReference) list.getSelectedItem()).idfsBaseReference);
                        }

                        public void onNothingSelected(AdapterView<?> arg0) {
                            mCase().setHumanAgeType(0);
                        }
                    }, mCase().getDateofBirth() == null, HumanCase.eidss_HumanAgeType, mandatoryFields, invisibleFields);

            DateBind(R.id.datDateofBirth, v, R.id.datDateofBirthClearButton,
                    new View.OnClickListener() {
                        public void onClick(View arg0) {
                            com.bv.eidss.EidssAndroidHelpers.DatePickerFragment.Show(mActivity.getSupportFragmentManager(), mActivity.DATE_BIRTH_DIALOG_ID, null, mCase().getDateofBirth());
                        }
                    },
                    new View.OnClickListener() {
                        public void onClick(View arg0) {
                            mCase().setDateofBirth(null);
                            DateHelpers.DisplayDate(R.id.datDateofBirth, mActivity, null);
                            final EditText ed = (EditText) mActivity.findViewById(R.id.intPatientAge);
                            final Spinner sp = (Spinner) mActivity.findViewById(R.id.idfsHumanAgeType);
                            EidssUtils.setEnabled(ed, true, mandatoryFields.contains(HumanCase.eidss_PatientAge));
                            EidssUtils.setEnabled(sp, true, mandatoryFields.contains(HumanCase.eidss_HumanAgeType));
                        }
                    },
                    mCase().getDateofBirth(), HumanCase.eidss_DateofBirth, mandatoryFields, invisibleFields);

            EditTextBind(R.id.intPatientAge, v, mCase().getPatientAge() == 0 ? "" : String.valueOf(mCase().getPatientAge()), new OnEditTextChangeListener() {
                public void onEditTextChanged(String text) {
                    if (text.trim().length() == 0)
                        mCase().setPatientAge(0);
                    else {
                        try {
                            mCase().setPatientAge(Integer.parseInt(text));
                        } catch (NumberFormatException e) {
                            Log.d("HumanCase", "NumberFormatException: " + e.getMessage());
                        }
                    }
                }
            }, mCase().getDateofBirth() == null, HumanCase.eidss_PatientAge, mandatoryFields, invisibleFields);
        }else if(pageNumber == 2) {

            regions = (Spinner) v.findViewById(R.id.idfsRegionCurrentResidence);
            rayons = (Spinner) v.findViewById(R.id.idfsRayonCurrentResidence);
            settlements = (Spinner) v.findViewById(R.id.idfsSettlementCurrentResidence);

            LookupBindBefore(regions, v,
                    new AdapterView.OnItemSelectedListener() {
                        public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                            long ident = ((GisBaseReference) parent.getSelectedItem()).idfsBaseReference;
                            if (mCase().getRegionCurrentResidence() != ident) {

                                mCase().setRegionCurrentResidence(ident);
                                mCase().setRayonCurrentResidence(0);
                                mCase().setSettlementCurrentResidence(0);

                                rayons.setEnabled(false);
                                settlements.setEnabled(false);

                                updateRayons();
                            }
                        }

                        public void onNothingSelected(AdapterView<?> arg0) {
                        }
                    }, HumanCase.eidss_RegionCurrentResidence, mandatoryFields, invisibleFields);

            if(EidssDatabase.GetRegions() != null)
                onLoadFinishedRegions();
            else
                mActivity.getSupportLoaderManager().initLoader(LOADER_REGIONS, null, this);

            mRayonsAdapter = LookupBind(rayons, v, RayonsProvider.NAME,
                    new AdapterView.OnItemSelectedListener() {
                        public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                            if (mCase().getRayonCurrentResidence() != id) {
                                mCase().setRayonCurrentResidence(id);
                                mCase().setSettlementCurrentResidence(0);

                                settlements.setEnabled(false);
                                // Update Settlements spinners
                                updateSettlements();
                            }
                        }

                        public void onNothingSelected(AdapterView<?> arg0) {
                        }
                    }, HumanCase.eidss_RayonCurrentResidence, mandatoryFields, invisibleFields);
            mSettlementsAdapter = LookupBind(settlements, v, SettlementsProvider.NAME,
                    new AdapterView.OnItemSelectedListener() {
                        public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                            if (mCase().getSettlementCurrentResidence() != id) {
                                mCase().setSettlementCurrentResidence(id);
                            }
                            EidssAndroidHelpers.DisableAddress(id == 0, v);
                        }

                        public void onNothingSelected(AdapterView<?> arg0) {
                        }
                    }, HumanCase.eidss_SettlementCurrentResidence, mandatoryFields, invisibleFields);

        } else if(pageNumber == 3) {
            acHospital = (AutoCompleteTextView)(v.findViewById(R.id.idfHospital));
            LookupBindAuto(acHospital,
                    new AdapterView.OnItemClickListener(){
                        @Override
                        public void onItemClick(AdapterView<?> list, View arg1, int pos, long id) {
                            Object item = list.getItemAtPosition(pos);
                            long itemId = ((BaseReference) item).idfsBaseReference;
                            mCase().setHospital(itemId);
                        }
                    }, HumanCase.eidss_Hospital, mandatoryFields, invisibleFields);

            acSoughtCareFacility = (AutoCompleteTextView)(v.findViewById(R.id.idfSoughtCareFacility));
            LookupBindAuto(acSoughtCareFacility,
                    new AdapterView.OnItemClickListener(){
                        @Override
                        public void onItemClick(AdapterView<?> list, View arg1, int pos, long id) {
                            Object item = list.getItemAtPosition(pos);
                            long itemId = ((BaseReference) item).idfsBaseReference;
                            mCase().setSoughtCareFacility(itemId);
                        }
                    }, HumanCase.eidss_SoughtCareFacility, mandatoryFields, invisibleFields);

            if(EidssDatabase.GetHospitals() != null)
            {
                LookupBindAutoAfter(acHospital, EidssDatabase.GetHospitals(), mCase().getHospital(), true);
                LookupBindAutoAfter(acSoughtCareFacility, EidssDatabase.GetHospitals(), mCase().getSoughtCareFacility(), true);
            }
            else {
                mActivity.getSupportLoaderManager().initLoader(LOADER_InstitutionName, null, this);
                EidssUtils.setEnabled(acHospital, false);
                EidssUtils.setEnabled(acSoughtCareFacility, false);
            }

            spinnerNotCollectedReason = (Spinner)v.findViewById(R.id.idfsNotCollectedReason);
            adapterNotCollectedReason = LookupBind(spinnerNotCollectedReason, v, ReferenciesProvider.NAME,
                    new AdapterView.OnItemSelectedListener(){
                        public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                            if (mCase().getNotCollectedReason() != id)
                                mCase().setNotCollectedReason(id);
                        }
                        public void onNothingSelected(AdapterView<?> arg0) {
                            mCase().setNotCollectedReason(0);
                        }
                    },
                    HumanCase.eidss_NotCollectedReason, mandatoryFields, invisibleFields);
            if (adapterNotCollectedReason != null)
                mActivity.getSupportLoaderManager().initLoader(LOADER_NotCollectedReason, null, this);
        }
        // End of Custom Binding

        HumanCase_binding.Bind(this, v, mCase(), mandatoryFields, invisibleFields, lang, pageNumber);

        // business rules - initial states
        if(pageNumber == 0) {
            if (mCase().getTentativeDiagnosis() == 0) {
                EidssAndroidHelpers.DisableDate(R.id.datTentativeDiagnosisDate, R.id.datTentativeDiagnosisDateClearButton, v);
            }
        }else if(pageNumber == 1) {
            if (mCase().getPersonIDType() == 0) {
                EidssAndroidHelpers.DisableTextbox(R.id.strPersonID, v);
            } else {
                EidssAndroidHelpers.EnableTextbox(R.id.strPersonID, v, mCase().getPersonIDType() != Constants.PersonalIDType_Unknown);
            }
        }else if(pageNumber == 2) {
            EidssAndroidHelpers.DisableAddress(mCase().getSettlementCurrentResidence() == 0, v);

        }else if(pageNumber == 3) {
            if (mCase().getHospitalizationStatus() == Constants.PatientLocationType_Hospital) {
                EidssAndroidHelpers.EnableAutoCompleteTextView(R.id.idfHospital, v);
            } else {
                EidssAndroidHelpers.DisableAutoCompleteTextView(R.id.idfHospital, v);
            }

            if (mCase().getYNHospitalization() == Constants.YesNoUnknownValues_Yes) {
                EidssAndroidHelpers.EnableTextbox(R.id.strHospitalizationPlace, v);
                EidssAndroidHelpers.EnableDate(R.id.datHospitalizationDate, R.id.datHospitalizationDateClearButton, v);
            } else {
                EidssAndroidHelpers.DisableTextbox(R.id.strHospitalizationPlace, v);
                EidssAndroidHelpers.DisableDate(R.id.datHospitalizationDate, R.id.datHospitalizationDateClearButton, v);
            }

            final Spinner spinnerYNSpecimenCollected = (Spinner)v.findViewById(R.id.idfsYNSpecimenCollected);
            spinnerYNSpecimenCollected.setOnItemSelectedListener(
                    new AdapterView.OnItemSelectedListener(){
                         public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                             if (mCase().getYNSpecimenCollected() != id)
                                 if (id !=  Constants.YesNoUnknownValues_Yes && mCase().samples.size() > 0) {
                                     EidssAndroidHelpers.AlertOkDialog.Show(mActivity.getSupportFragmentManager(), R.string.SamplesRegistered);
                                     for (int i = 0; i < spinnerYNSpecimenCollected.getAdapter().getCount(); i++){
                                         if (((Cursor)spinnerYNSpecimenCollected.getAdapter().getItem(i)).getLong(0) == Constants.YesNoUnknownValues_Yes){
                                             spinnerYNSpecimenCollected.setSelection(i);
                                             break;
                                         }
                                     }
                                 }else
                                     mCase().setYNSpecimenCollected(id);
                         }
                         public void onNothingSelected(AdapterView<?> arg0) {
                             mCase().setYNSpecimenCollected(0);
                         }
                     }
            );
            if (mCase().getYNSpecimenCollected() == Constants.YesNoUnknownValues_No) {
                EidssAndroidHelpers.EnableSpinner(R.id.idfsNotCollectedReason, v, true);
            } else {
                EidssAndroidHelpers.DisableSpinner(R.id.idfsNotCollectedReason, v);
            }

        }


        // hide soft keyboard
        mActivity.getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_HIDDEN);
        return v;
    }


    @Override
    public void  onCreateOptionsMenu(Menu menu, MenuInflater inflater) {

        inflater.inflate(R.menu.case_toolbar, menu);
    }

    /* Called whenever we call invalidateOptionsMenu() */
    @Override
    public void onPrepareOptionsMenu(Menu menu) {
        menu.findItem(R.id.Save).setVisible(mCase().getChanged());
        menu.findItem(R.id.Remove).setVisible(mCase().getId() != 0);
        //menu.findItem(R.id.Refresh).setVisible(mCase().getId() != 0);
        //return super.onPrepareOptionsMenu(menu);
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
                popupMenu.setOnMenuItemClickListener(new PopupMenu.OnMenuItemClickListener()
                {
                    @Override
                    public boolean onMenuItemClick(MenuItem item)
                    {
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
        switch(item.getItemId()){
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
            EidssAndroidHelpers.AlertOkResultDialog.ShowWarning(mActivity.getSupportFragmentManager(), HumanCase_binding.NO_ACTION_ID, R.string.LocationCouldNotGet);
    }

    @Override
    public Loader<Cursor> onCreateLoader(int id, Bundle args)
    {
        String[] sels;
        switch (id)
        {
            case LOADER_REGIONS:
                sels = new String[2];
                sels[0] = lang;
                sels[1] = String.valueOf(mCase().getRegionCurrentResidence());
                return new CursorLoader(mActivity, RegionsProvider.CONTENT_URI, null, null, sels, null);
            case LOADER_RAYONS:
                sels = new String[3];
                sels[0] = lang;
                sels[1] = String.valueOf(mCase().getRegionCurrentResidence());
                sels[2] = String.valueOf(mCase().getRayonCurrentResidence());
                return new CursorLoader(mActivity, RayonsProvider.CONTENT_URI, null, null, sels, null);
            case LOADER_SETTLEMENTS:
                sels = new String[3];
                sels[0] = lang;
                sels[1] = String.valueOf(mCase().getRayonCurrentResidence());
                sels[2] = String.valueOf(mCase().getSettlementCurrentResidence());
                return new CursorLoader(mActivity, SettlementsProvider.CONTENT_URI, null, null, sels, null);
            case LOADER_InstitutionName:
                Options opt = EidssDatabase.GetOptions();
                if (opt.getRayonDef() == 0) {
                    sels = new String[5];
                    sels[4] = "0";
                } else {
                    sels = new String[6];
                    sels[4] = String.valueOf(opt.getRayonDef());
                    sels[5] = "0";
                }
                sels[0] = lang;
                sels[1] = String.valueOf(BaseReferenceType.rftInstitutionName);
                sels[2] = String.valueOf(CaseTypeHACode.HUMAN);
                sels[3] = String.valueOf(opt.getRegionDef());
                return new CursorLoader(mActivity, ReferenciesProvider.CONTENT_URI, null, null, sels, null);
            case LOADER_NotCollectedReason:
                sels = new String[3];
                sels[0] = lang;
                sels[1] = String.valueOf(BaseReferenceType.rftNotCollectedReason);
                sels[2] = String.valueOf(mCase().getNotCollectedReason());
                return new CursorLoader(mActivity, ReferenciesProvider.CONTENT_URI, null, null, sels, null);
            default:
                return HumanCase_binding.onCreateLoader(id, lang, mCase(), mActivity);
        }
    }

    @Override
    public void onLoadFinished(Loader<Cursor> loader, Cursor data)
    {
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
                onLoadFinishedSettlements(data, mCase());
                break;
            case LOADER_InstitutionName:
                onLoadFinishedInstitutionName(data);
                break;
            case LOADER_NotCollectedReason:
                onLoadFinishedNotCollectedReason(data, mCase());
                break;
            default:
                HumanCase_binding.onLoadFinished(loader.getId(), data, mCase());
                break;
        }
    }

    private void onLoadFinishedRegions()
    {
        boolean found = LookupBindAfter(regions, EidssDatabase.GetRegions(), mCase().getRegionCurrentResidence(), true, RegionsProvider.CONTENT_URI);
        if (EidssDatabase.GetRegions().size() > 1)
        {
            regions.setEnabled(true);
            if (mCase().getRegionCurrentResidence() > 0 && found) {
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

    private void onLoadFinishedRayons(Cursor data)
    {
        mRayonsAdapter.swapCursor(data);
        int rowCount = data.getCount();
        if (rowCount > 1)
        {
            // set selected
            int cpos = 0;
            for(int i = 0; i < rowCount; i++){
                data.moveToPosition(i);
                long temp = data.getLong(0);
                if ( temp == mCase().getRayonCurrentResidence()){
                    cpos = i;
                    break;
                }
            }
            rayons.setSelection(cpos);
            rayons.setEnabled(true);
            if (cpos > 0)// 0 line - empty string
                updateSettlements();
        }
        else
        {
            rayons.setEnabled(false);
        }
    }

    private void onLoadFinishedSettlements(Cursor data, final HumanCase mCase)
    {
        mSettlementsAdapter.swapCursor(data);
        int rowCount = data.getCount();
        if (rowCount > 1)
        {
            // set selected
            int cpos = 0;
            for (int i = 0; i < rowCount; i++){
                data.moveToPosition(i);
                long temp = data.getLong(0);
                if (temp == mCase.getSettlementCurrentResidence()){
                    cpos = i;
                    break;
                }
            }
            settlements.setSelection(cpos);
            settlements.setEnabled(true);
        }
        else
        {
            settlements.setEnabled(false);
        }
    }

    private void onLoadFinishedInstitutionName(Cursor data)
    {
        EidssDatabase.SetHospitals(data);

        LookupBindAutoAfter(acHospital, EidssDatabase.GetHospitals(), mCase().getHospital(), true);
        LookupBindAutoAfter(acSoughtCareFacility, EidssDatabase.GetHospitals(), mCase().getSoughtCareFacility(), true);
    }

    private void onLoadFinishedNotCollectedReason(Cursor data, final HumanCase mCase)
    {
        adapterNotCollectedReason.swapCursor(data);
        int rowCount = data.getCount();
        if (rowCount > 1)
        {
            // set selected
            int cpos = 0;
            for (int i = 0; i < rowCount; i++){
                data.moveToPosition(i);
                long temp = data.getLong(0);
                if (temp == mCase.getNotCollectedReason())
                {
                    cpos = i;
                    break;
                }
            }
            spinnerNotCollectedReason.setSelection(cpos);
            spinnerNotCollectedReason.setEnabled(true);
        }
        else
        {
            spinnerNotCollectedReason.setEnabled(false);
        }
    }

    @Override
    public void onLoaderReset(Loader<Cursor> loader)
    {
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
            case LOADER_NotCollectedReason:
                adapterNotCollectedReason.swapCursor(null);
                break;
            default:
                HumanCase_binding.onLoaderReset(loader.getId());
                break;
        }
    }

    private void updateRayons()
    {
        //Bundle bundle = new Bundle();
        //bundle.putString(RayonsProvider.COLUMN_REGION_CODE, regionCode);

        mActivity.getSupportLoaderManager().restartLoader(LOADER_RAYONS, null, this);
    }

    private void updateSettlements()
    {
        mActivity.getSupportLoaderManager().restartLoader(LOADER_SETTLEMENTS, null, this);
    }

    private HumanCase mCase() {
        return (HumanCase)mActivity.get();
    }
}
