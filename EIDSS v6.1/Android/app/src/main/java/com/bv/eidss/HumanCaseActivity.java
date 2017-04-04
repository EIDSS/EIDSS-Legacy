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
import android.widget.EditText;
import android.widget.Spinner;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.generated.HumanCase_binding;
import com.bv.eidss.model.BaseReference;
import com.bv.eidss.model.CaseSerializer;
import com.bv.eidss.model.CaseStatus;
import com.bv.eidss.model.FFModel;
import com.bv.eidss.model.FFTypesEnum;
import com.bv.eidss.model.HumanCase;
import com.bv.eidss.model.interfaces.Constants;
import com.bv.eidss.model.interfaces.IFFModel;
import com.bv.eidss.model.interfaces.IFFOperations;
import com.bv.eidss.model.interfaces.IFieldChanged;
import com.bv.eidss.model.interfaces.IGet;
import com.bv.eidss.model.interfaces.IToChange;
import com.bv.eidss.model.interfaces.ValidateCode;
import com.bv.eidss.model.interfaces.ValidateResult;
import com.bv.eidss.utils.DateHelpers;
import com.bv.eidss.utils.EidssUtils;

import java.io.File;
import java.io.FileOutputStream;
import java.io.OutputStreamWriter;
import java.util.ArrayList;
import java.util.List;

public class HumanCaseActivity extends EidssBaseBlockTimeoutActivity
        implements  EidssAndroidHelpers.DialogDoneListener,
                    EidssAndroidHelpers.DialogDoneDateListener,
                    IGet<Object>,
                    IFFModel<Object>,
                    IFFOperations<Object>
                    {
    private final int DELETE_DIALOG_ID = 1;
    private final int SAVE_DIALOG_ID = 2;
    public final int CANCEL_DIALOG_ID = 3;
    private final int BACK_DIALOG_ID = 4;
    private final int SYNCHRONIZE_SAVE_DIALOG_ID = 5;
    private final int FILE_SAVE_DIALOG_ID = 6;
    public final int DATE_BIRTH_DIALOG_ID = 12;

     private final int NUM_SAMPLES_PAGE = 4;


    public HumanCase mCase;

    private MyFragmentPagerAdapter pagerAdapter;

    private FFPresenterFragment FFCS;
    private FFPresenterFragment FFEpi;

    private DialogFragment mReturningWithResult;

    private class MyFragmentPagerAdapter extends FragmentPagerAdapter {
        public List<Fragment> fragments;

        public MyFragmentPagerAdapter(FragmentManager fm) {
            super(fm);
            fragments = new ArrayList<>();
        }

        @Override
        public Fragment getItem(int position) {
            return fragments.get(position);
        }

        @Override
        public int getCount() {
            return fragments.size();
        }

        @Override
        public CharSequence getPageTitle(int position) {
            switch (position) {
                case 0:
                    return getResources().getString(R.string.HumanCasePage0);
                case 1:
                    return getResources().getString(R.string.HumanCasePage1);
                case 2:
                    return getResources().getString(R.string.HumanCasePage2);
                case 3:
                    return getResources().getString(R.string.HumanCasePage2a);
                case NUM_SAMPLES_PAGE:
                    return getResources().getString(R.string.Samples);
                case 5:
                    return getResources().getString(R.string.HumanCasePage4);
                case 6:
                    return getResources().getString(R.string.HumanCasePage5);
                default:
                    return getResources().getString(R.string.HumanCasePage3);
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
            long id = intent.getLongExtra(getResources().getString(R.string.EXTRA_ID_HUMAN_CASE), 0L);
            // load from database full case - with all its lists
            if (id != 0) {
                EidssDatabase db = new EidssDatabase(this);
                List<HumanCase> ret = db.HumanCaseSelect(id);
                db.close();
                mCase = ret.get(0);
            }
        }

        if (mCase == null)
            mCase = HumanCase.CreateNew();

        setTitle("");
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        final ActionBar ab = getSupportActionBar();
        if(ab != null) {
            ab.setIcon(R.drawable.eidss_ic_hc_big);
            ab.setDisplayShowHomeEnabled(true);
            ab.setDisplayHomeAsUpEnabled(true);
        }

        // Intialise ViewPager
        initializeViewPager();
        initializePagerTabStrip();


        // business rules
        final Activity _this = this;
        mCase.setFieldChangedHandler(new IFieldChanged() {
            @Override
            public void FieldChanged(String name, Object oldVal, Object newVal) {
                switch (name) {
                    case "idfsTentativeDiagnosis":
                        if ((long) oldVal != (long) newVal) {
                            if ((long) newVal == 0) {
                                mCase.setTentativeDiagnosisDate(null);
                                DateHelpers.DisplayDate(R.id.datTentativeDiagnosisDate, _this, mCase.getTentativeDiagnosisDate());
                                EidssAndroidHelpers.DisableDate(R.id.datTentativeDiagnosisDate, R.id.datTentativeDiagnosisDateClearButton, _this);
                            } else if ((long) oldVal == 0) {
                                EidssAndroidHelpers.EnableDate(R.id.datTentativeDiagnosisDate, R.id.datTentativeDiagnosisDateClearButton, _this);
                            }
                        }
                        break;
                    case "idfsPersonIDType":
                        if ((long) oldVal != (long) newVal) {
                            if ((long) newVal == 0) {
                                mCase.setPersonID("");
                                EidssAndroidHelpers.DisableTextbox(R.id.strPersonID, _this);
                            } else {
                                EidssAndroidHelpers.EnableTextbox(R.id.strPersonID, _this, (long) newVal != Constants.PersonalIDType_Unknown);
                            }
                        }
                        break;
                    case "idfsHospitalizationStatus":
                        if ((long) oldVal != (long) newVal) {
                            if ((long) newVal == Constants.PatientLocationType_Hospital) {
                                EidssAndroidHelpers.EnableAutoCompleteTextView(R.id.idfHospital, _this);
                            } else {
                                EidssAndroidHelpers.DisableAutoCompleteTextView(R.id.idfHospital, _this);
                            }
                        }
                        break;
                    case "idfsYNHospitalization":
                        if ((long) oldVal != (long) newVal) {
                            if ((long) newVal == Constants.YesNoUnknownValues_Yes) {
                                EidssAndroidHelpers.EnableTextbox(R.id.strHospitalizationPlace, _this);
                                EidssAndroidHelpers.EnableDate(R.id.datHospitalizationDate, R.id.datHospitalizationDateClearButton, _this);
                            } else if ((long) oldVal == Constants.YesNoUnknownValues_Yes) {
                                mCase.setHospitalizationPlace("");
                                mCase.setHospitalizationDate(null);
                                DateHelpers.DisplayDate(R.id.datHospitalizationDate, _this, mCase.getHospitalizationDate());
                                EidssAndroidHelpers.DisableTextbox(R.id.strHospitalizationPlace, _this);
                                EidssAndroidHelpers.DisableDate(R.id.datHospitalizationDate, R.id.datHospitalizationDateClearButton, _this);
                            }
                        }
                        break;
                    case "idfsYNSpecimenCollected":
                        if ((long) oldVal != (long) newVal) {
                            if ((long) newVal == Constants.YesNoUnknownValues_No) {
                                EidssAndroidHelpers.EnableSpinner(R.id.idfsNotCollectedReason, _this, true);
                            } else if ((long) oldVal == Constants.YesNoUnknownValues_No) {
                                mCase.setNotCollectedReason(0);
                                EidssAndroidHelpers.DisableSpinner(R.id.idfsNotCollectedReason, _this);
                            }
                            if ((long) newVal == Constants.YesNoUnknownValues_Yes)
                                SetSamplesReadonly(false);
                            else
                                SetSamplesReadonly(true);
                        }
                        break;
                }
            }
        });
        if (mCase.getYNSpecimenCollected() == Constants.YesNoUnknownValues_Yes)
            SetSamplesReadonly(false);
        else
            SetSamplesReadonly(true);

        //add FF
        if (mCase.getTentativeDiagnosis() > 0){
            RecalculateFF(mCase.getTentativeDiagnosis());
        }
    }

    protected void onSaveInstanceState(Bundle outState) {
        //outState.putString("tab", mTabHost.getCurrentTabTag()); //save the tab selected
        outState.putParcelable("case", mCase);
        super.onSaveInstanceState(outState);
    }

    private void initializeViewPager() {
        pagerAdapter = new MyFragmentPagerAdapter(super.getSupportFragmentManager());

        pagerAdapter.fragments.add(HumanCaseFragment.newInstance(0));
        pagerAdapter.fragments.add(HumanCaseFragment.newInstance(1));
        pagerAdapter.fragments.add(HumanCaseFragment.newInstance(2));
        pagerAdapter.fragments.add(HumanCaseFragment.newInstance(3));
        pagerAdapter.fragments.add(HumanCaseSamplesFragment.newInstance());
        FFCS = FFPresenterFragment.newInstance(FFTypesEnum.HumanClinicalSigns);
        pagerAdapter.fragments.add(FFCS);
        FFEpi = FFPresenterFragment.newInstance(FFTypesEnum.HumanEpiInvestigations);
        pagerAdapter.fragments.add(FFEpi);
        pagerAdapter.fragments.add(HumanCaseFragment.newInstance(4));
        //


        ViewPager pager = (ViewPager) super.findViewById(R.id.pager);
        pager.setAdapter(pagerAdapter);
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
            //super.onBackPressed();
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

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        if (requestCode == getResources().getInteger(R.integer.ACTIVITY_ID_SYNCHRONIZE_CASE)) {
            if (resultCode == Activity.RESULT_OK) {
                final Intent intent = new Intent(this, HumanCaseActivity.class);
                intent.putExtra(getResources().getString(R.string.EXTRA_ID_HUMAN_CASE), mCase.getId());
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

    public void FinishThis(int result) {
        if (result == RESULT_OK) {
            getIntent().putExtra(getResources().getString(R.string.EXTRA_ID_HUMAN_CASE), mCase);
        }
        setResult(result, getIntent());
        mCase.setFieldChangedHandler(null);
        //finish();

        Intent intent = NavUtils.getParentActivityIntent(this);
        intent.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
        startActivity(intent);
    }

    private void SaveCase() {
        EidssDatabase db = new EidssDatabase(this);
        if (mCase.getId() == 0) {
            db.HumanCaseInsert(mCase);
        } else {
            if (mCase.getStatus() != CaseStatus.NEW)
                mCase.setStatusChanged();
            db.HumanCaseUpdate(mCase);
        }
        db.close();
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

    public void Save() {
        if (ValidateCase()) {
            if (mCase.getChanged())
                EidssAndroidHelpers.AlertOkResultDialog.ShowQuestion(getSupportFragmentManager(), SAVE_DIALOG_ID, R.string.ConfirmSaveCase);
            else
                FinishThis(Activity.RESULT_OK);
        }
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
            case DateOfBirthCheckCurrent:
                EidssAndroidHelpers.AlertOkDialog.Warning(getSupportFragmentManager(), R.string.DateOfBirthCheckCurrent);
                break;
            case DateOfSymptomCheckCurrent:
                EidssAndroidHelpers.AlertOkDialog.Warning(getSupportFragmentManager(), R.string.DateOfSymptomCheckCurrent);
                break;
            case DateOfDiagnosisCheckCurrent:
                EidssAndroidHelpers.AlertOkDialog.Warning(getSupportFragmentManager(), R.string.DateOfDiagnosisCheckCurrent);
                break;
            case DateOfDiagnosisCheckNotification:
                EidssAndroidHelpers.AlertOkDialog.Warning(getSupportFragmentManager(), R.string.DateOfDiagnosisCheckNotification);
                break;
            case DateOfBirthCheckDiagnosis:
                EidssAndroidHelpers.AlertOkDialog.Warning(getSupportFragmentManager(), R.string.DateOfBirthCheckDiagnosis);
                break;
            case DateOfBirthCheckNotification:
                EidssAndroidHelpers.AlertOkDialog.Warning(getSupportFragmentManager(), R.string.DateOfBirthCheckNotification);
                break;
            case DateOfSymptomCheckDiagnosis:
                EidssAndroidHelpers.AlertOkDialog.Warning(getSupportFragmentManager(), R.string.DateOfSymptomCheckDiagnosis);
                break;
            case AgeType:
                EidssAndroidHelpers.AlertOkDialog.Warning(getSupportFragmentManager(), R.string.AgeTypeCheck);
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
        try {
            EidssDatabase db = new EidssDatabase(this);
            long country = db.GisCountry(DeploymentCountry.getDefCountry()).idfsBaseReference;

            List<HumanCase> hcs = new ArrayList<>();
            hcs.add(mCase);
            String content = CaseSerializer.writeXml(hcs, null, null, country, true);
            File file = new File(fullFilename);
            FileOutputStream filecon = new FileOutputStream(file);
            OutputStreamWriter writer = new OutputStreamWriter(filecon);
            writer.write(content);
            writer.close();
            filecon.close();

            if (mCase.getStatus() == CaseStatus.NEW || mCase.getStatus() == CaseStatus.CHANGED) {
                mCase.setStatusUploaded();
                db.HumanCaseUpdate(mCase);
            }
            db.close();
            mReturningWithResult = EidssAndroidHelpers.AlertOkDialog.Show(R.string.CasesUnloaded);
        } catch (Exception e) {
            mReturningWithResult = EidssAndroidHelpers.AlertOkDialog.Warning(R.string.ErrorCasesUnloaded);
        }
    }

    private void Synchronize() {
        Intent intent = new Intent(this, SynchronizeCasesActivity.class);
        intent.putExtra("Id", mCase.getId());
        intent.putExtra("Type", R.integer.SYNCHRONIZATION_TYPE_HUMAN);
        startActivityForResult(intent, getResources().getInteger(R.integer.ACTIVITY_ID_SYNCHRONIZE_CASE));
    }

    private void DeleteCase() {
        EidssDatabase db = new EidssDatabase(this);
        db.HumanCaseDelete(new Long[]{mCase.getId()});
        db.close();
    }

    @Override
    public void onDone(int idDialog, boolean isPositive) {
        switch (idDialog) {
            case HumanCase_binding.NO_ACTION_ID:
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
            default:
                break;
        }
    }

    @Override
    public void onDone(final int idDialog, final int year, final int month, final int day) {
        switch (idDialog) {
            case DATE_BIRTH_DIALOG_ID:
                mCase.setDateofBirth(DateHelpers.Date(year, month, day));
                DateHelpers.DisplayDate(R.id.datDateofBirth, this, mCase.getDateofBirth());

                final EditText ed = (EditText) this.findViewById(R.id.intPatientAge);
                final Spinner sp = (Spinner) this.findViewById(R.id.idfsHumanAgeType);

                mCase.setPatientAge(mCase.CalcPatientAge());
                mCase.setHumanAgeType(mCase.CalcPatientAgeType());
                ed.setText(String.valueOf(mCase.getPatientAge()));
                BaseReferenceAdapter ad = (BaseReferenceAdapter) sp.getAdapter();
                for (int i = 0; i < ad.getCount(); i++) {
                    if (((BaseReference) ad.getItem(i)).idfsBaseReference == mCase.getHumanAgeType()) {
                        sp.setSelection(i);
                        break;
                    }
                }
                EidssUtils.setEnabled(ed, false);
                EidssUtils.setEnabled(sp, false);
                break;


           /*place snippet here!*/

            case HumanCase_binding.datCompletionPaperFormDate_DialogID:
                mCase.setCompletionPaperFormDate(DateHelpers.Date(year, month, day));
                DateHelpers.DisplayDate(R.id.datCompletionPaperFormDate, this, mCase.getCompletionPaperFormDate());
                break;
            case HumanCase_binding.datTentativeDiagnosisDate_DialogID:
                mCase.setTentativeDiagnosisDate(DateHelpers.Date(year, month, day));
                DateHelpers.DisplayDate(R.id.datTentativeDiagnosisDate, this, mCase.getTentativeDiagnosisDate());
                break;
            case HumanCase_binding.datDateofBirth_DialogID:
                mCase.setDateofBirth(DateHelpers.Date(year, month, day));
                DateHelpers.DisplayDate(R.id.datDateofBirth, this, mCase.getDateofBirth());
                break;
            case HumanCase_binding.datOnSetDate_DialogID:
                mCase.setOnSetDate(DateHelpers.Date(year, month, day));
                DateHelpers.DisplayDate(R.id.datOnSetDate, this, mCase.getOnSetDate());
                break;
            case HumanCase_binding.datExposureDate_DialogID:
                mCase.setExposureDate(DateHelpers.Date(year, month, day));
                DateHelpers.DisplayDate(R.id.datExposureDate, this, mCase.getExposureDate());
                break;
            case HumanCase_binding.datFirstSoughtCareDate_DialogID:
                mCase.setFirstSoughtCareDate(DateHelpers.Date(year, month, day));
                DateHelpers.DisplayDate(R.id.datFirstSoughtCareDate, this, mCase.getFirstSoughtCareDate());
                break;
            case HumanCase_binding.datHospitalizationDate_DialogID:
                mCase.setHospitalizationDate(DateHelpers.Date(year, month, day));
                DateHelpers.DisplayDate(R.id.datHospitalizationDate, this, mCase.getHospitalizationDate());
                break;

            /*end of place snippet here!*/
        }
    }

    @Override
    public Object get() {
        return mCase;
    }

    @Override
    public FFModel getFFModel(long idFormType){
        FFModel result = null;
        if (idFormType == FFTypesEnum.HumanClinicalSigns){
            result = mCase.FFModelCS;
        }
        else if (idFormType == FFTypesEnum.HumanEpiInvestigations){
            result = mCase.FFModelEpi;
        }
        return result;
    }

    @Override
    public FFPresenterFragment getFFFragment(long idFormType){
        FFPresenterFragment result = null;
        if (idFormType == FFTypesEnum.HumanClinicalSigns){
            result = FFCS;
        }
        else if (idFormType == FFTypesEnum.HumanEpiInvestigations){
            result = FFEpi;
        }
        return result;
    }

    @Override
    public void SetDeterminant(long id) {
        mCase.setTentativeDiagnosis(id);
        RecalculateFF(id);
    }

    private void RecalculateFF(long id){
        //recalculate FF
        EidssDatabase db = new EidssDatabase(this);
        mCase.FFModelCS.LoadTemplate(db, id);
        mCase.FFModelEpi.LoadTemplate(db, id);
        db.close();

        FFCS.setToChange(true);
        FFEpi.setToChange(true);

        pagerAdapter.notifyDataSetChanged();
    }

    public void SetSamplesReadonly(boolean readonly){
        boolean toChange = ((IToChange) pagerAdapter.fragments.get(NUM_SAMPLES_PAGE)).ToChange();
        if (pagerAdapter.fragments.get(NUM_SAMPLES_PAGE) instanceof HumanCaseSamplesFragment) {
            ((IToChange) pagerAdapter.fragments.get(NUM_SAMPLES_PAGE)).setToChange(true);
            ((HumanCaseSamplesFragment)pagerAdapter.fragments.get(NUM_SAMPLES_PAGE)).setReadonly(readonly);
        }

        if (pagerAdapter != null && !toChange) pagerAdapter.notifyDataSetChanged();
    }

}
