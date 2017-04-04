package com.bv.eidss;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;

import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v7.app.ActionBar;
import android.support.v7.widget.Toolbar;

import com.bv.eidss.data.EidssDatabase;

import com.bv.eidss.generated.HumanCaseSample_binding;
import com.bv.eidss.model.HumanCaseSample;
import com.bv.eidss.model.interfaces.ValidateCode;
import com.bv.eidss.model.interfaces.ValidateResult;
import com.bv.eidss.utils.DateHelpers;


public class HumanCaseSampleActivity extends EidssBaseBlockTimeoutActivity
		implements EidssAndroidHelpers.DialogDoneDateListener{
	public HumanCaseSample mCase;
	int position = -1;	//-1 means new item
	long diagnosis = 0L;	//0 means no filtration by diagnosis



	public HumanCaseSampleActivity() {

	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.ff_activity);

		final Intent intent = getIntent();
		mCase = intent.getParcelableExtra(getResources().getString(R.string.EXTRA_ID_ITEM));
		position = intent.getIntExtra("position", -1);
		diagnosis = intent.getLongExtra("diagnosis", 0L);

		setTitle(getResources().getString(R.string.Sample));
		Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
		setSupportActionBar(toolbar);
		final ActionBar ab = getSupportActionBar();
		if(ab != null) {
			ab.setDisplayShowHomeEnabled(true);
			ab.setDisplayHomeAsUpEnabled(true);
		}

		StartFragment();
	}

	private Fragment StartFragment() {
		FragmentManager fm = getSupportFragmentManager();
		Fragment fragment = fm.findFragmentById(R.id.fragment_container);
		if (fragment == null) {
			fragment = new HumanCaseSampleFragment();
			fm.beginTransaction()
					.add(R.id.fragment_container, fragment)
					.commit();
		}
		return fragment;
	}

	@Override
	public void onDone(int idDialog, int year, int month, int day) {
		switch (idDialog) {

            /*place snippet here!*/

			case HumanCaseSample_binding.datFieldCollectionDate_DialogID:
				mCase.setFieldCollectionDate(DateHelpers.Date(year, month, day));
				DateHelpers.DisplayDate(R.id.datFieldCollectionDate, this, mCase.getFieldCollectionDate());
				break;
			case HumanCaseSample_binding.datFieldSentDate_DialogID:
				mCase.setFieldSentDate(DateHelpers.Date(year, month, day));
				DateHelpers.DisplayDate(R.id.datFieldSentDate, this, mCase.getFieldSentDate());
				break;

            /*end of place snippet here!*/
		}
	}

	@Override
	public void onBackPressed() {
		Home();
	}

	public void Home() {
		if (mCase.getChanged()) {
			if(position == -1 && mCase.isEmpty())
				FinishThis(RESULT_CANCELED);
			else
				Save();
		}
		else
			FinishThis(RESULT_CANCELED);
	}

	public void Save() {
		if (Validate())
			FinishThis(Activity.RESULT_OK);
	}

	private Boolean Validate() {
		ValidateResult vr = mCase.Validate(EidssDatabase.GetMandatoryFields(), EidssDatabase.GetInvisibleFields());
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
			case DateFieldCollectionCheckCurrent:
				EidssAndroidHelpers.AlertOkDialog.Warning(getSupportFragmentManager(), R.string.DateFieldCollectionCheckCurrent);
				break;
            case DateFieldCollectionCheckSentDate:
                EidssAndroidHelpers.AlertOkDialog.Warning(getSupportFragmentManager(), R.string.DateFieldCollectionCheckSent);
                break;
			default:
				break;
		}
		return false;
	}

	public void FinishThis(int result) {
		Intent intent = getIntent();
		if (result == Activity.RESULT_OK) {
			intent.putExtra(getResources().getString(R.string.EXTRA_ID_ITEM), mCase);
			intent.putExtra("position", position);
		}
		setResult(result, intent);
		finish();
	}
}
