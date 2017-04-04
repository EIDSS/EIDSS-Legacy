package com.bv.eidss;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.DialogFragment;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;
import android.support.v4.app.NavUtils;
import android.support.v4.view.PagerTabStrip;
import android.support.v4.view.ViewPager;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.View;
import android.widget.EditText;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.generated.Species_binding;
import com.bv.eidss.generated.ASSession_binding;
import com.bv.eidss.model.ASSession;
import com.bv.eidss.model.CaseSerializer;
import com.bv.eidss.model.CaseStatus;
import com.bv.eidss.model.CaseType;
import com.bv.eidss.model.ASSession;
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
import java.util.Vector;

public class ASSessionActivity extends EidssBaseBlockTimeoutActivity
        implements EidssAndroidHelpers.DialogDoneListener,
                   EidssAndroidHelpers.DialogDoneDateListener,
                   IGet<Object>

{
    private final int DELETE_DIALOG_ID = 1;
    private final int SAVE_DIALOG_ID = 2;
    public final int CANCEL_DIALOG_ID = 3;
    public final int BACK_DIALOG_ID = 4;
    private final int SYNCHRONIZE_SAVE_DIALOG_ID = 5;
    private final int FILE_SAVE_DIALOG_ID = 6;

    public ASSession mCase;

    private DialogFragment mReturningWithResult;
    //private TabHost mTabHost;

 /*   private class TabFactory implements TabHost.TabContentFactory {

        private final Context mContext;

        public TabFactory(Context context) {
            mContext = context;
        }

        public View createTabContent(String tag) {
            View v = new View(mContext);
            v.setMinimumWidth(0);
            v.setMinimumHeight(0);
            return v;
        }
    }*/

    private class MyFragmentPagerAdapter extends FragmentPagerAdapter {
        private List<Fragment> fragments;

        public MyFragmentPagerAdapter(FragmentManager fm, List<Fragment> fragments) {
            super(fm);
            this.fragments = fragments;
        }

        @Override
        public Fragment getItem(int position) {
            //if (position == 2)
            //    return SpeciesFragment.newInstance();
            //return VetCaseFragment.newInstance(position);
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
                    return getResources().getString(R.string.ASSessionPage0);
                case 1:
                    return getResources().getString(R.string.ASSessionPage1);
                case 2:
                    return getResources().getString(R.string.ASSessionPage2);
                case 3:
                    return getResources().getString(R.string.ASSessionPage3);
                case 4:
                    return getResources().getString(R.string.ASSessionPage4);
                default:
                    return "";
            }
        }

        @Override
        public int getItemPosition(Object item)
        {
            if (item instanceof ASSessionFragment && ((ASSessionFragment) item).ToChange)
            {
                ((ASSessionFragment) item).ToChange = false;
                return POSITION_NONE;
            }
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
            long id = intent.getLongExtra(getResources().getString(R.string.EXTRA_ID_ASSESSION), 0L);
            // load from database full case - with all its lists
            if (id != 0) {
                EidssDatabase db = new EidssDatabase(this);
                List<ASSession> ret = db.ASSessionSelect(id);
                db.close();
                if (ret.size() == 1){
                    mCase = ret.get(0);
                } else{
                    mCase = null;
                }
            }
        }
        if (mCase == null) {
            mCase = ASSession.CreateNew();
        }

        setTitle("");
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        getSupportActionBar().setIcon(R.drawable.eidss_ic_as_big);

        getSupportActionBar().setDisplayShowHomeEnabled(true);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

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
                }
            }
        });
    }

    protected void onSaveInstanceState(Bundle outState) {
        //outState.putString("tab", mTabHost.getCurrentTabTag()); //save the tab selected
        outState.putParcelable("case", mCase);
        super.onSaveInstanceState(outState);
    }

    private void initializeViewPager() {
        List<Fragment> fragments = new Vector<>();
        fragments.add(ASSessionFragment.newInstance(0));
        fragments.add(ASSessionFragment.newInstance(1));
        fragments.add(ASDiseasesFragment.newInstance());
        fragments.add(FarmsFragment.newInstance());
        fragments.add(ASSamplesFragment.newInstance());

        final ViewPager pager = (ViewPager) super.findViewById(R.id.pager);

        pagerAdapter = new MyFragmentPagerAdapter(super.getSupportFragmentManager(), fragments);
        pager.setAdapter(pagerAdapter);
        //this.pager.setOnPageChangeListener(this);

        pager.setOnPageChangeListener(new ViewPager.OnPageChangeListener() {

            @Override
            public void onPageSelected(int position) {
                Log.d("ASSession", "onPageSelected, position = " + position);
            }

            @Override
            public void onPageScrolled(int position, float positionOffset,
                                       int positionOffsetPixels) {
            }

            @Override
            public void onPageScrollStateChanged(int state) {
            }
        });
    }

    private MyFragmentPagerAdapter pagerAdapter;

    private void initializePagerTabStrip() {
        final PagerTabStrip title = (PagerTabStrip) findViewById(R.id.pagerTabStrip);
        title.setTabIndicatorColor(getResources().getColor(R.color.CommonBackground));
        title.setNonPrimaryAlpha(0.48f);
        title.setTextSpacing(4);
        title.setMinimumHeight(100);
    }

    public void ReloadReadOnlyTabs(){
        if (!((ASSessionFragment)pagerAdapter.getItem(1)).ToChange || !((IToChange)pagerAdapter.getItem(2)).ToChange()) {
            ((ASSessionFragment) pagerAdapter.getItem(1)).ToChange = true;
            ((IToChange) pagerAdapter.getItem(2)).setToChange(true);
            pagerAdapter.notifyDataSetChanged();
        }
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
                final Intent intent = new Intent(this, ASSessionActivity.class);
                intent.putExtra(getResources().getString(R.string.EXTRA_ID_ASSESSION), mCase.getId());
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
            getIntent().putExtra(getResources().getString(R.string.EXTRA_ID_ASSESSION), mCase);
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
        intent.putExtra("Type", R.integer.SYNCHRONIZATION_TYPE_ASSESSION);
        startActivityForResult(intent, getResources().getInteger(R.integer.ACTIVITY_ID_SYNCHRONIZE_CASE));
    }

    private void SaveCase() {
        EidssDatabase db = new EidssDatabase(this);
        if (mCase.getId() == 0) {
            db.ASSessionInsert(mCase);
        } else {
            if (mCase.getStatus() != CaseStatus.NEW)
                mCase.setStatusChanged();
            db.ASSessionUpdate(mCase);
        }
        db.close();
    }

    private void DeleteCase() {
        EidssDatabase db = new EidssDatabase(this);
        Long[] id = new Long[]{mCase.getId()};
        db.ASSessionDelete(id);
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
        int title = mCase.getMonitoringSession() == 0 ? R.string.ConfirmToDeleteNewSession : R.string.ConfirmToDeleteSynSession;
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
            case DateOfSessionStartCheckSessionEnd:
                EidssAndroidHelpers.AlertOkDialog.Warning(getSupportFragmentManager(), R.string.DateOfSessionStartCheckSessionEnd);
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

            List<ASSession> ass = new ArrayList<>();
            ass.add(mCase);
            String content = CaseSerializer.writeXml(null, null, ass, country, true);
            File file = new File(fullFilename);
            FileOutputStream filecon = new FileOutputStream(file);
            OutputStreamWriter writer = new OutputStreamWriter(filecon);
            writer.write(content);
            writer.close();
            filecon.close();

            if (mCase.getStatus() == CaseStatus.NEW || mCase.getStatus() == CaseStatus.CHANGED) {
                mCase.setStatusUploaded();
                db.ASSessionUpdate(mCase);
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

            case R.string.SessionPeriodDoesNotMatchCampaignPeriod:
            case R.string.SessionContainsSpeciesAbsentInCampaign:
                ((ASSessionFragment) GetFragment(0)).CampaignLookupSetSelection();
                break;
            case R.string.SessionDiseasesDiffersFromCampaignDiseases:
            case R.string.CampaignDiseasesListIsBlank:
                if (isPositive) {
                    ((ASSessionFragment) GetFragment(0)).SetCampaign();
                } else {
                    ((ASSessionFragment) GetFragment(0)).CampaignLookupSetSelection();
                }
                break;
        }
    }


    @Override
    public void onDone(int idDialog, int year, int month, int day) {
        switch (idDialog) {

            /*place snippet here!*/

            case ASSession_binding.datEndDate_DialogID:
                mCase.setEndDate(DateHelpers.Date(year, month, day));
                DateHelpers.DisplayDate(R.id.datEndDate, this, mCase.getEndDate());
                break;
            case ASSession_binding.datStartDate_DialogID:
                mCase.setStartDate(DateHelpers.Date(year, month, day));
                DateHelpers.DisplayDate(R.id.datStartDate, this, mCase.getStartDate());
                break;

            /*end of place snippet here!*/

        }
    }

    @Override
    public Object get() {
        return mCase;
    }
}
