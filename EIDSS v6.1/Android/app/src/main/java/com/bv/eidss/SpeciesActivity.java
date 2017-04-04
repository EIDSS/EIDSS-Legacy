package com.bv.eidss;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;

import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v7.app.ActionBar;
import android.support.v7.widget.Toolbar;

import com.bv.eidss.data.EidssDatabase;

import com.bv.eidss.generated.Species_binding;
import com.bv.eidss.model.BaseReference;
import com.bv.eidss.model.Species;
import com.bv.eidss.model.interfaces.ValidateCode;
import com.bv.eidss.model.interfaces.ValidateResult;
import com.bv.eidss.utils.DateHelpers;

import java.util.ArrayList;
import java.util.List;


public class SpeciesActivity extends EidssBaseBlockTimeoutActivity
		implements EidssAndroidHelpers.DialogDoneDateListener, EidssAndroidHelpers.DialogDoneListener{

	public final int CANCEL_DIALOG_ID = 3;
	public Species mSpecies;
	int position = -1;	//-1 means new item
	public int mode; // 0 - assession, 1 - livestock, 2 - avian
	public ArrayList<BaseReference> _listSpeciesTypes = new ArrayList<BaseReference>();

	public SpeciesActivity() {

	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.ff_activity);

		final Intent intent = getIntent();
		mSpecies = intent.getParcelableExtra(getResources().getString(R.string.EXTRA_ID_ITEM));
		mode = intent.getIntExtra(getResources().getString(R.string.EXTRA_ID_MODE), 0);
		position = intent.getIntExtra("position", -1);
		_listSpeciesTypes = intent.getParcelableArrayListExtra(getResources().getString(R.string.EXTRA_ID_LIST));

		if (mode == 0 || mode == 1)
			setTitle(getResources().getString(R.string.VetCasePage2));
		else
			setTitle(getResources().getString(R.string.VetCasePage2a));
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
			fragment = new SpeciesFragment();
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

			case Species_binding.datStartOfSignsDate_DialogID:
				mSpecies.setStartOfSignsDate(DateHelpers.Date(year, month, day));
				DateHelpers.DisplayDate(R.id.datStartOfSignsDate, this, mSpecies.getStartOfSignsDate());
				break;

            /*end of place snippet here!*/
		}
	}

	@Override
	public void onDone(int idDialog, boolean isPositive) {
		switch (idDialog) {
			case CANCEL_DIALOG_ID:
				if (!isPositive) {
					FinishThis(RESULT_CANCELED);
				}
				break;
		}
	}

	@Override
	public void onBackPressed() {
		Home();
	}

	public void Home() {
		if (mSpecies.getChanged()) {
			if(position == -1 && mSpecies.isEmpty())
				FinishThis(RESULT_CANCELED);
			else
				Save();
		}
		else
			FinishThis(RESULT_CANCELED);
	}

	public void Save() {
		if (Validate())
			if (!ValidateDuplicate()) {
				EidssAndroidHelpers.AlertOkResultDialog.ShowQuestion(getSupportFragmentManager(), CANCEL_DIALOG_ID, R.string.DuplicateSpecies);
			} else {
				FinishThis(Activity.RESULT_OK);
			}
	}

	private boolean ValidateDuplicate(){
		final Intent intent = getIntent();
		final List<Long> items = (List<Long>)intent.getSerializableExtra(getResources().getString(R.string.EXTRA_ID_ITEMS));
		for (Long it:items)
			if (mSpecies.getSpeciesType() == it)
				return false;

		return true;
	}

	private Boolean Validate() {
		ValidateResult vr = mSpecies.Validate(EidssDatabase.GetMandatoryFields(), EidssDatabase.GetInvisibleFields());
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
			case DateOfStartOfSignsCheckCurrent:
				EidssAndroidHelpers.AlertOkDialog.Warning(getSupportFragmentManager(), R.string.DateOfStartOfSignsCheckCurrent);
				break;
			case SpeciesTotalLessDeadSick:
				EidssAndroidHelpers.AlertOkDialog.Warning(getSupportFragmentManager(), R.string.SpeciesTotalLessDeadSick);
				break;
			default:
				break;
		}
		return false;
	}

	public void FinishThis(int result) {
		Intent intent = getIntent();
		if (result == Activity.RESULT_OK) {
			intent.putExtra(getResources().getString(R.string.EXTRA_ID_ITEM), mSpecies);
			intent.putExtra("position", position);
		}
		setResult(result, intent);
		finish();
	}
}
