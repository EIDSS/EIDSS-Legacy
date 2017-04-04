package com.bv.eidss;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;
import android.support.v4.content.ContextCompat;
import android.support.v4.view.PagerTabStrip;
import android.support.v4.view.ViewPager;
import android.support.v7.app.ActionBar;
import android.support.v7.widget.Toolbar;
import android.view.View;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.generated.Farm_binding;
import com.bv.eidss.model.CaseType;
import com.bv.eidss.model.FFTypesEnum;
import com.bv.eidss.model.Farm;
import com.bv.eidss.model.ASSession;
import com.bv.eidss.model.interfaces.IFFModel;
import com.bv.eidss.model.interfaces.IFFOperations;
import com.bv.eidss.model.interfaces.IGet;
import com.bv.eidss.model.interfaces.IToChange;
import com.bv.eidss.model.interfaces.ValidateCode;
import com.bv.eidss.model.interfaces.ValidateResult;

import java.util.ArrayList;
import java.util.List;


public class FarmActivity extends EidssBaseBlockTimeoutActivity
		implements EidssAndroidHelpers.DialogDoneListener,
        IGet<Object>,
        IFFOperations<Object>
        {
	public final int CANCEL_DIALOG_ID = 3;

	public Farm mFarm;
    public ASSession mASSession;
	int position = -1;	//-1 means new Farm
	//public List<BaseReference> mSpeciesTypes;

    private MyFragmentPagerAdapter pagerAdapter;

    @Override
    public Object get() {
        return mFarm;
    }

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
                    return getResources().getString(R.string.FarmPage0);
                case 1:
                    return getResources().getString(R.string.FarmPage1);
                default:
                    return null;
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


	private FarmActivity _this;

	public FarmActivity() {
		_this = this;
	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

        setContentView(R.layout.case_main_layout);
        View filter = findViewById(R.id.spinner_list_filter);
        if (filter != null)
            filter.setVisibility(View.GONE);

		final Intent intent = getIntent();
		mFarm = intent.getParcelableExtra(getResources().getString(R.string.EXTRA_ID_ITEM));
        mASSession = intent.getParcelableExtra(getResources().getString(R.string.EXTRA_ID_ASSESSION));
		position = intent.getIntExtra("position", -1);

		/*List<Long> specTypes = (ArrayList<Long>)intent.getSerializableExtra(getResources().getString(R.string.EXTRA_ID_ITEMS));
		EidssDatabase mDb = new EidssDatabase(_this);
		List<BaseReference> species = mDb.Reference(BaseReferenceType.rftSpeciesList, EidssUtils.getCurrentLanguage(), CaseTypeHACode.LIVESTOCK, 0);
		mDb.close();
		mSpeciesTypes = new ArrayList<>();
		for(BaseReference sp: species){
			if(specTypes.contains(sp.idfsBaseReference))
				mSpeciesTypes.add(sp);
		}
		mSpeciesTypes.add(0, new BaseReference(0, ""));*/

        setTitle(getResources().getString(R.string.Farm));
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        getSupportActionBar().setDisplayShowHomeEnabled(true);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        // Intialise ViewPager
        initializeViewPager();
        initializePagerTabStrip();


		//StartFragment();
	}

    private void initializeViewPager() {
        pagerAdapter = new MyFragmentPagerAdapter(super.getSupportFragmentManager());
        pagerAdapter.fragments.add(FarmFragment.newInstance());
        pagerAdapter.fragments.add(SpeciesesFragment.newInstance(SpeciesFromFarmActivity.class, mASSession.getSpeciesTypes(this), mASSession));
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

	/*private Fragment StartFragment() {
		FragmentManager fm = getSupportFragmentManager();
		Fragment fragment = fm.findFragmentById(R.id.fragment_container);
		if (fragment == null) {
			fragment = new FarmFragment();
			fm.beginTransaction()
					.add(R.id.fragment_container, fragment)
					.commit();
		}
		return fragment;
	}*/

	@Override
	public void onActivityResult(int requestCode, int resultCode, Intent data){
		super.onActivityResult(requestCode, resultCode, data);
	}


	@Override
	public void onBackPressed() {
		Home();
	}

	public void Home() {
		if (mFarm.getChanged()) {
			if(position == -1 && mFarm.isEmpty(this, mASSession))
				FinishThis(RESULT_CANCELED);
			else
				Save();
		}
		else
			FinishThis(RESULT_CANCELED);
	}

	public void Save() {
		if (Validate()) {
            if (!ValidateBoundaries()) {
                EidssAndroidHelpers.AlertOkResultDialog.ShowQuestion(getSupportFragmentManager(), CANCEL_DIALOG_ID, R.string.FarmIsOutsideOfTheASSessionBoundaries);
            } else {
                FinishThis(Activity.RESULT_OK);
            }
		}
	}

    @Override
    public void Remove() {

    }

    private boolean ValidateBoundaries(){
        if (mASSession.getRegion() != 0 && mFarm.getRegion() != 0 && mASSession.getRegion() != mFarm.getRegion())
            return false;
        if (mASSession.getRayon() != 0 && mFarm.getRayon() != 0 && mASSession.getRayon() != mFarm.getRayon())
            return false;
        if (mASSession.getSettlement() != 0 && mFarm.getSettlement() != 0 && mASSession.getSettlement() != mFarm.getSettlement())
            return false;
        return true;
    }

    private void CorrectBoundaries(){
        if (mFarm.getFarm() == 0 && mFarm.getRootFarm() == 0) { // only for new, not synchronized and not root farms
            boolean bNeedRefresh = false;
            if (mASSession.getSettlement() != 0 && mFarm.getSettlement() != 0 && mASSession.getSettlement() != mFarm.getSettlement()) {
                mFarm.setSettlement(0);
                bNeedRefresh = true;
            }
            if (mASSession.getRayon() != 0 && mFarm.getRayon() != 0 && mASSession.getRayon() != mFarm.getRayon()) {
                mFarm.setRayon(0);
                bNeedRefresh = true;
            }
            if (mASSession.getRegion() != 0 && mFarm.getRegion() != 0 && mASSession.getRegion() != mFarm.getRegion()) {
                mFarm.setRegion(0);
                bNeedRefresh = true;
            }
            if (bNeedRefresh) {
                FragmentManager fm = getSupportFragmentManager();
                Fragment f = fm.getFragments().get(0);
                fm.beginTransaction().detach(f).attach(f).commit();
            }
        }
    }


	private Boolean Validate() {
		ValidateResult vr = mFarm.Validate(EidssDatabase.GetMandatoryFields(), EidssDatabase.GetInvisibleFields());
		if (vr.getCode() == ValidateCode.OK)
			return true;

		switch (vr.getCode()) {
			case FieldMandatory:
				String errMes = String.format(getResources().getString(R.string.FieldMandatory), getResources().getString(vr.getMandatory()));
				EidssAndroidHelpers.AlertOkDialog.Warning(getSupportFragmentManager(), errMes);
				break;
			case FieldMandatoryStr:
				String errMess = String.format(getResources().getString(R.string.FieldMandatory), vr.getMandatoryStr());
				EidssAndroidHelpers.AlertOkDialog.Warning(getSupportFragmentManager(), errMess);
				break;
            case SpeciesMandatory:
                EidssAndroidHelpers.AlertOkDialog.Warning(getSupportFragmentManager(), R.string.SpeciesMandatory);
                break;
			default:
				break;
		}
		return false;
	}

	public void FinishThis(int result) {
		Intent intent = getIntent();
		if (result == Activity.RESULT_OK) {
			intent.putExtra(getResources().getString(R.string.EXTRA_ID_ITEM), mFarm);
			intent.putExtra("position", position);
		}
		setResult(result, intent);
		finish();
	}

	@Override
	public void onDone(int idDialog, boolean isPositive) {
		switch (idDialog) {
            case Farm_binding.NO_ACTION_ID:
                break;
			case CANCEL_DIALOG_ID:
				if (!isPositive) {
                    CorrectBoundaries();
				} else {
                    FinishThis(Activity.RESULT_OK);
                }
				break;
		}
	}
}
