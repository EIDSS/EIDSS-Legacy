package com.bv.eidss;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.DialogFragment;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;
import android.support.v4.app.NavUtils;
import android.support.v4.content.ContextCompat;
import android.support.v4.view.PagerTabStrip;
import android.support.v4.view.ViewPager;
import android.support.v7.app.ActionBar;
import android.support.v7.widget.Toolbar;
import android.view.View;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.generated.VetCase_binding;
import com.bv.eidss.model.CaseSerializer;
import com.bv.eidss.model.CaseStatus;
import com.bv.eidss.model.CaseType;
import com.bv.eidss.model.FFModel;
import com.bv.eidss.model.FFTypesEnum;
import com.bv.eidss.model.VetCase;
import com.bv.eidss.model.interfaces.IFFModel;
import com.bv.eidss.model.interfaces.IFFOperations;
import com.bv.eidss.model.interfaces.IFieldChanged;
import com.bv.eidss.model.interfaces.IGet;
import com.bv.eidss.model.interfaces.IToChange;
import com.bv.eidss.model.interfaces.ValidateCode;
import com.bv.eidss.model.interfaces.ValidateResult;
import com.bv.eidss.utils.DateHelpers;

import java.io.File;
import java.io.FileOutputStream;
import java.io.OutputStreamWriter;
import java.util.ArrayList;
import java.util.List;

public class VetCaseActivity extends EidssBaseBlockTimeoutActivity
        implements EidssAndroidHelpers.DialogDoneListener,
                   EidssAndroidHelpers.DialogDoneDateListener,
                   IGet<Object>,
                   IFFModel<Object> ,
                   IFFOperations<Object>

{
    private final int DELETE_DIALOG_ID = 1;
    private final int SAVE_DIALOG_ID = 2;
    public final int CANCEL_DIALOG_ID = 3;
    public final int BACK_DIALOG_ID = 4;
    private final int SYNCHRONIZE_SAVE_DIALOG_ID = 5;
    private final int FILE_SAVE_DIALOG_ID = 6;

    public VetCase mCase;

    private DialogFragment mReturningWithResult;

    private MyFragmentPagerAdapter pagerAdapter;

    private FFPresenterFragment FFFarmEpiFragment;
    private FFPresenterFragment FFControlMeasuresFragment;

    private class MyFragmentPagerAdapter extends FragmentPagerAdapter {
        public List<Fragment> fragments;

        public MyFragmentPagerAdapter(FragmentManager fm) {
            super(fm);
            fragments = new ArrayList<>();
        }

        @Override
        public Fragment getItem(int position) {
            return this.fragments.get(position);
        }

        @Override
        public int getCount() {
            return this.fragments.size();
        }

        @Override
        public CharSequence getPageTitle(int position) {
            switch (position) {
                case 0:
                    return getResources().getString(R.string.VetCasePage0);
                case 1:
                    return getResources().getString(R.string.VetCasePage1);
                case 2:
                    return mCase.IsLivestockCase()
                            ? getResources().getString(R.string.VetCasePage2)
                            : getResources().getString(R.string.VetCasePage2a);
                case 3:
                    return getResources().getString(R.string.VetCasePage4a);
                case 4:
                    return mCase.IsLivestockCase()
                            ? getResources().getString(R.string.VetCasePage5)
                            : getResources().getString(R.string.Samples);
                case 5:
                    return mCase.IsLivestockCase()
                            ? getResources().getString(R.string.Animals)
                            : getResources().getString(R.string.VetCasePage3);
                case 6:
                    return mCase.IsLivestockCase()
                            ? getResources().getString(R.string.Samples)
                            : getResources().getString(R.string.VetCasePage3);
                default:
                    return getResources().getString(R.string.VetCasePage3);
            }
        }

        @Override
        public int getItemPosition(Object item)
        {
            if (item instanceof IToChange && ((IToChange) item).ToChange())
            {
                ((IToChange) item).setToChange(false);
                return POSITION_NONE;
            }
            return super.getItemPosition(item);
        }
    }

    //ONLY FOR TEST!!!!
    public void temp_SetAnimalReadonly(boolean readonly){
        boolean toChange = ((IToChange) pagerAdapter.fragments.get(5)).ToChange();
        if (pagerAdapter.fragments.get(5) instanceof AnimalsFragment) {
            ((IToChange) pagerAdapter.fragments.get(5)).setToChange(true);
            ((AnimalsFragment)pagerAdapter.fragments.get(5)).setReadonly(readonly);
        }

        if (pagerAdapter != null && !toChange) pagerAdapter.notifyDataSetChanged();
    }
    //END ONLY FOR TEST!!!!

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.case_main_layout);
        View filter = findViewById(R.id.spinner_list_filter);
        if (filter != null)
            filter.setVisibility(View.GONE);

        final Intent intent = getIntent();
        if (savedInstanceState != null)
            mCase = savedInstanceState.getParcelable("case");
        else {
            long id = intent.getLongExtra(getResources().getString(R.string.EXTRA_ID_VET_CASE), 0L);
            // load from database full case - with all its lists
            if (id != 0) {
                EidssDatabase db = new EidssDatabase(this);
                List<VetCase> ret = db.VetCaseSelect(id);
                db.close();
                mCase = ret.get(0);
            }
        }

        if (mCase == null) {
            long caseType = intent.getLongExtra(getResources().getString(R.string.EXTRA_ID_MODE), CaseType.LIVESTOCK);
            mCase = VetCase.CreateNew(this, caseType);
        }

        setTitle("");
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        final ActionBar ab = getSupportActionBar();
        if(ab != null) {
            if (mCase.getCaseType() == CaseType.LIVESTOCK)
                ab.setIcon(R.drawable.eidss_ic_lvsc_big);
            else
                ab.setIcon(R.drawable.eidss_ic_avc_big);

            ab.setDisplayShowHomeEnabled(true);
            ab.setDisplayHomeAsUpEnabled(true);
        }

        // Intialise ViewPager
        this.initializeViewPager();
/*        // Initialise the TabHost
        this.initialiseTabHost();
        if (savedInstanceState != null) {
            mTabHost.setCurrentTabByTag(savedInstanceState.getString("tab")); //set the tab as per the saved state
        }*/
        initializePagerTabStrip();

        // business rules
        final Activity _this = this;
        mCase.setFieldChangedHandler(new IFieldChanged() {
            @Override
            public void FieldChanged(String name, Object oldVal, Object newVal) {
                switch (name) {
                    case "idfsTentativeDiagnosis":
                        long idfsTentativeDiagnosisOld = (long) oldVal;
                        long idfsTentativeDiagnosisNew = (long) newVal;
                        if (idfsTentativeDiagnosisOld != idfsTentativeDiagnosisNew) {
                            if (idfsTentativeDiagnosisNew == 0) {
                                mCase.setTentativeDiagnosisDate(null);
                                DateHelpers.DisplayDate(R.id.datTentativeDiagnosisDate, _this, mCase.getTentativeDiagnosisDate());
                                EidssAndroidHelpers.DisableDate(R.id.datTentativeDiagnosisDate, R.id.datTentativeDiagnosisDateClearButton, _this);
                            } else if (idfsTentativeDiagnosisOld == 0) {
                                mCase.setTentativeDiagnosisDate(DateHelpers.Today());
                                DateHelpers.DisplayDate(R.id.datTentativeDiagnosisDate, _this, mCase.getTentativeDiagnosisDate());
                                EidssAndroidHelpers.EnableDate(R.id.datTentativeDiagnosisDate, R.id.datTentativeDiagnosisDateClearButton, _this);
                            }
                            SetDeterminant(idfsTentativeDiagnosisNew);
                        }
                        break;
                }
            }
        });
    }

    protected void onSaveInstanceState(Bundle outState) {
        outState.putParcelable("case", mCase);
        super.onSaveInstanceState(outState);
    }

    private void initializeViewPager() {
        pagerAdapter = new MyFragmentPagerAdapter(super.getSupportFragmentManager());

        pagerAdapter.fragments.add(VetCaseFragment.newInstance(0));
        pagerAdapter.fragments.add(VetCaseFragment.newInstance(1));
        pagerAdapter.fragments.add(SpeciesesFragment.newInstance(SpeciesFromVetCaseActivity.class, null, mCase));

        FFFarmEpiFragment = FFPresenterFragment.newInstance(
                mCase.IsLivestockCase()
                ? FFTypesEnum.LivestockFarmEPI
                : FFTypesEnum.AvianFarmEPI
                );
        pagerAdapter.fragments.add(FFFarmEpiFragment);

        if (mCase.IsLivestockCase()){
            FFControlMeasuresFragment = FFPresenterFragment.newInstance(FFTypesEnum.LivestockControlMeasures);
            pagerAdapter.fragments.add(FFControlMeasuresFragment);
            pagerAdapter.fragments.add(AnimalsFragment.newInstance());
        }

        pagerAdapter.fragments.add(VetCaseSamplesFragment.newInstance());

        RecalculateFF(mCase.getTentativeDiagnosis(), false);
        //
        final ViewPager pager = (ViewPager) super.findViewById(R.id.pager);

        pager.setAdapter(pagerAdapter);
        //this.pager.setOnPageChangeListener(this);
    }

    private void initializePagerTabStrip() {
        final PagerTabStrip title = (PagerTabStrip) findViewById(R.id.pagerTabStrip);
        title.setTabIndicatorColor(ContextCompat.getColor(this, R.color.CommonBackground));
        title.setNonPrimaryAlpha(0.48f);
        title.setTextSpacing(4);
        title.setMinimumHeight(100);
    }

    @Override
    public void onBackPressed() {
        if (mCase.getChanged())
            EidssAndroidHelpers.AlertOkResultDialog.ShowQuestion(getSupportFragmentManager(), BACK_DIALOG_ID, R.string.ConfirmCancelCase);
        else
            FinishThis(RESULT_CANCELED);
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        if (requestCode == getResources().getInteger(R.integer.ACTIVITY_ID_SYNCHRONIZE_CASE)) {
            if (resultCode == Activity.RESULT_OK) {
                final Intent intent = new Intent(this, VetCaseActivity.class);
                intent.putExtra(getResources().getString(R.string.EXTRA_ID_VET_CASE), mCase.getId());
                FinishThis(Activity.RESULT_OK);
                startActivity(intent);
            }
        } else if (requestCode == getResources().getInteger(R.integer.FILE_BROWSER_MODE_SAVE)) {
            String fullFilename = data.getStringExtra(getResources().getString(R.string.EXTRA_ID_FILENAME));
            if (resultCode == Activity.RESULT_OK && !fullFilename.isEmpty()) {
                SaveInFile(fullFilename);
            }
        }

        super.onActivityResult(requestCode, resultCode, data);
    }


    @Override
    protected void onResume() {
        super.onResume();
        if (mReturningWithResult != null) {
            // Commit your transactions here.
            mReturningWithResult.show(getSupportFragmentManager(), "dialog");
        }
        // Reset the boolean flag back to false for next time.
        mReturningWithResult = null;
    }


    public void FinishThis(int result) {
        if (result == Activity.RESULT_OK) {
            getIntent().putExtra(getResources().getString(R.string.EXTRA_ID_VET_CASE), mCase);
        }
        setResult(result, getIntent());
        mCase.setFieldChangedHandler(null);
        //finish();

        Intent intent = NavUtils.getParentActivityIntent(this);
        intent.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
        startActivity(intent);
    }

    private void Synchronize() {
        Intent intent = new Intent(this, SynchronizeCasesActivity.class);
        intent.putExtra("Id", mCase.getId());
        intent.putExtra("Type", R.integer.SYNCHRONIZATION_TYPE_VET);
        startActivityForResult(intent, getResources().getInteger(R.integer.ACTIVITY_ID_SYNCHRONIZE_CASE));
    }

    private void SaveCase() {
        EidssDatabase db = new EidssDatabase(this);
        if (mCase.getId() == 0) {
            db.VetCaseInsert(mCase);
        } else {
            if (mCase.getStatus() != CaseStatus.NEW)
                mCase.setStatusChanged();
            db.VetCaseUpdate(mCase);
        }
        db.close();
    }

    private void DeleteCase() {
        EidssDatabase db = new EidssDatabase(this);
        Long[] id = new Long[]{mCase.getId()};
        db.VetCaseDelete(id);
        db.close();
    }

    public void Save() {
        if (ValidateCase()) {
            if (mCase.getChanged())
                EidssAndroidHelpers.AlertOkResultDialog.ShowQuestion(getSupportFragmentManager(), SAVE_DIALOG_ID, R.string.ConfirmSaveCase);
            else
                FinishThis(Activity.RESULT_OK);
        }
    }

    public void OffLine() {
        if (mCase.getChanged())
            EidssAndroidHelpers.AlertOkResultDialog.ShowQuestion(getSupportFragmentManager(), FILE_SAVE_DIALOG_ID, R.string.ConfirmSaveSynchCase);
        else
            SaveToFile();
    }

    public void OnLine() {
        if (mCase.getChanged())
            EidssAndroidHelpers.AlertOkResultDialog.ShowQuestion(getSupportFragmentManager(), SYNCHRONIZE_SAVE_DIALOG_ID, R.string.ConfirmSaveSynchCase);
        else
            Synchronize();
    }

    public void Remove() {
        int title = mCase.getCase() == 0 ? R.string.ConfirmToDeleteNewCase : R.string.ConfirmToDeleteSynCase;
        EidssAndroidHelpers.AlertOkResultDialog.ShowQuestion(getSupportFragmentManager(), DELETE_DIALOG_ID, title);
    }

    public void Home() {
        if (mCase.getChanged())
            EidssAndroidHelpers.AlertOkResultDialog.ShowQuestion(getSupportFragmentManager(), CANCEL_DIALOG_ID, R.string.ConfirmCancelCase);
        else
            FinishThis(Activity.RESULT_CANCELED);
    }

    private Boolean ValidateCase() {
        ValidateResult vc = mCase.Validate(EidssDatabase.GetMandatoryFields(), EidssDatabase.GetInvisibleFields());
        if (vc.getCode() == ValidateCode.OK)
            return true;

        switch (vc.getCode()) {
            case FieldMandatory:
                String errMes = String.format(getResources().getString(R.string.FieldMandatory), getResources().getString(vc.getMandatory()));
                EidssAndroidHelpers.AlertOkDialog.Warning(getSupportFragmentManager(), errMes);
                break;
            case FieldMandatoryStr:
                String errMess = String.format(getResources().getString(R.string.FieldMandatory), vc.getMandatoryStr());
                EidssAndroidHelpers.AlertOkDialog.Warning(getSupportFragmentManager(), errMess);
                break;
            case DateOfDiagnosisCheckCurrent:
                EidssAndroidHelpers.AlertOkDialog.Warning(getSupportFragmentManager(), R.string.DateOfDiagnosisCheckCurrent);
                break;
            case DateOfEnteredCheckDiagnosis:
                EidssAndroidHelpers.AlertOkDialog.Warning(getSupportFragmentManager(), R.string.DateOfEnteredCheckDiagnosis);
                break;
            case DateOfReportCheckCurrent:
                EidssAndroidHelpers.AlertOkDialog.Warning(getSupportFragmentManager(), R.string.DateOfReportCheckCurrent);
                break;
            case SpeciesMandatory:
                EidssAndroidHelpers.AlertOkDialog.Warning(getSupportFragmentManager(), R.string.SpeciesMandatory);
                break;
            default:
                break;
        }
        return false;
    }

    private void SaveToFile() {
        Intent intent = new Intent(this, FileBrowser.class);
        int md = getResources().getInteger(R.integer.FILE_BROWSER_MODE_SAVE);
        intent.putExtra("mode", md);
        intent.putExtra("mask", "Case.eidss");
        startActivityForResult(intent, md);
    }

    public void SaveInFile(String fullFilename) {
        EidssDatabase db = new EidssDatabase(this);
        try {
            long country = db.GisCountry(DeploymentCountry.getDefCountry()).idfsBaseReference;

            List<VetCase> vcs = new ArrayList<>();
            vcs.add(mCase);
            String content = CaseSerializer.writeXml(null, vcs, null, country, true);
            File file = new File(fullFilename);
            FileOutputStream filecon = new FileOutputStream(file);
            OutputStreamWriter writer = new OutputStreamWriter(filecon);
            writer.write(content);
            writer.close();
            filecon.close();

            if (mCase.getStatus() == CaseStatus.NEW || mCase.getStatus() == CaseStatus.CHANGED) {
                mCase.setStatusUploaded();
                db.VetCaseUpdate(mCase);
            }
            db.close();
            mReturningWithResult = EidssAndroidHelpers.AlertOkDialog.Show(R.string.CasesUnloaded);
        } catch (Exception e) {
            db.close();
            mReturningWithResult = EidssAndroidHelpers.AlertOkDialog.Warning(R.string.ErrorCasesUnloaded);
        }
    }

    private Fragment GetFragment(int fragmentPosition) {
        FragmentManager fm = getSupportFragmentManager();
        return fm.findFragmentByTag(getFragmentTag(R.id.pager, fragmentPosition));
    }

    private static String getFragmentTag(int viewPagerId, int fragmentPosition) {
        return "android:switcher:" + viewPagerId + ":" + fragmentPosition;
    }

    @Override
    public void onDone(int idDialog, boolean isPositive) {
        switch (idDialog) {
            case VetCase_binding.NO_ACTION_ID:
                break;
            case CANCEL_DIALOG_ID:
                if (isPositive) {
                    FinishThis(RESULT_CANCELED);
                }
                break;
            case BACK_DIALOG_ID:
                if (isPositive) {
                    FinishThis(RESULT_CANCELED);
                }
                break;
            case DELETE_DIALOG_ID:
                if (isPositive) {
                    DeleteCase();
                    FinishThis(Activity.RESULT_FIRST_USER + 1);
                }
                break;
            case SAVE_DIALOG_ID:
                if (isPositive) {
                    SaveCase();
                    FinishThis(Activity.RESULT_OK);
                }
                break;
            case SYNCHRONIZE_SAVE_DIALOG_ID:
                if (!isPositive) {
                    Synchronize();
                } else if (ValidateCase()) {
                    SaveCase();
                    Synchronize();
                }
                break;
            case FILE_SAVE_DIALOG_ID:
                if (!isPositive) {
                    SaveToFile();
                } else if (ValidateCase()) {
                    SaveCase();
                    SaveToFile();
                }
                break;
        }
    }

    @Override
    public void onDone(int idDialog, int year, int month, int day) {
        switch (idDialog) {


            /*place snippet here!*/

            case VetCase_binding.datReportDate_DialogID:
                mCase.setReportDate(DateHelpers.Date(year, month, day));
                DateHelpers.DisplayDate(R.id.datReportDate, this, mCase.getReportDate());
                break;
            case VetCase_binding.datTentativeDiagnosisDate_DialogID:
                mCase.setTentativeDiagnosisDate(DateHelpers.Date(year, month, day));
                DateHelpers.DisplayDate(R.id.datTentativeDiagnosisDate, this, mCase.getTentativeDiagnosisDate());
                break;

            /*end of place snippet here!*/
        }
    }

    @Override
    public Object get() {
        return mCase;
    }

    @Override
    public FFModel getFFModel(long idFormType) {
        FFModel result;
        if (idFormType == FFTypesEnum.LivestockControlMeasures){
            result = mCase.FFControlMeasures;
        }
        else{
            result = mCase.FFFarmEpi;
        }
        return result;
    }

    @Override
    public FFPresenterFragment getFFFragment(long idFormType) {
        if (idFormType == FFTypesEnum.LivestockControlMeasures)
            return FFControlMeasuresFragment;
        else
            return FFFarmEpiFragment;
    }

    @Override
    public void SetDeterminant(long id) {
        RecalculateFF(id, false);
    }

    private void RecalculateFF(long id, Boolean needReloadAp){
        //recalculate FF
        EidssDatabase db = new EidssDatabase(this);
        mCase.FFControlMeasures.LoadTemplate(db, 0); //It doesn't depend on diagnosis
        mCase.FFFarmEpi.LoadTemplate(db, id);
        if (needReloadAp){

        }

        db.close();
        if (pagerAdapter != null) pagerAdapter.notifyDataSetChanged();
    }
}
