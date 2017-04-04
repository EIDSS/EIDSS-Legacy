package com.bv.eidss;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v7.widget.Toolbar;
import android.widget.TextView;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.ASDisease;
import com.bv.eidss.model.ASSession;
import com.bv.eidss.model.BaseReference;
import com.bv.eidss.model.BaseReferenceType;
import com.bv.eidss.model.CaseTypeHACode;
import com.bv.eidss.model.interfaces.ValidateCode;
import com.bv.eidss.model.interfaces.ValidateResult;
import com.bv.eidss.utils.EidssUtils;

import java.util.ArrayList;
import java.util.List;


public class ASDiseaseActivity extends EidssBaseBlockTimeoutActivity
		implements EidssAndroidHelpers.DialogDoneListener {
	public final int CANCEL_DIALOG_ID = 3;

	public ASDisease mASDisease;
    public ASSession mASSession;
	int position = -1;	//-1 means new ASDisease
	//public List<BaseReference> mSpeciesTypes;


	private ASDiseaseActivity _this;

	public ASDiseaseActivity() {
		_this = this;
	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.ff_activity);

		final Intent intent = getIntent();
		mASDisease = intent.getParcelableExtra(getResources().getString(R.string.EXTRA_ID_ITEM));
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

		setTitle(getResources().getString(R.string.ASDisease));
		Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
		setSupportActionBar(toolbar);
		getSupportActionBar().setDisplayShowHomeEnabled(true);
		getSupportActionBar().setDisplayHomeAsUpEnabled(true);

		StartFragment();
	}

	private Fragment StartFragment() {
		FragmentManager fm = getSupportFragmentManager();
		Fragment fragment = fm.findFragmentById(R.id.fragment_container);
		if (fragment == null) {
			fragment = new ASDiseaseFragment();
			fm.beginTransaction()
					.add(R.id.fragment_container, fragment)
					.commit();
		}
		return fragment;
	}

	@Override
	public void onActivityResult(int requestCode, int resultCode, Intent data){
		super.onActivityResult(requestCode, resultCode, data);
	}


	@Override
	public void onBackPressed() {
		Home();
	}

	public void Home() {
		if (mASDisease.getChanged()) {
			if(position == -1 && mASDisease.isEmpty())
				FinishThis(RESULT_CANCELED);
			else
				Save();
		}
		else
			FinishThis(RESULT_CANCELED);
	}

	public void Save() {
		if (Validate()) {
			if (!ValidateDuplicate()) {
				EidssAndroidHelpers.AlertOkResultDialog.ShowQuestion(getSupportFragmentManager(), CANCEL_DIALOG_ID, R.string.DuplicateDiagnosisSpeciesSample);
			} else {
				FinishThis(Activity.RESULT_OK);
			}
		}
	}

	private boolean ValidateDuplicate(){
		for (ASDisease ad:mASSession.asDiseases) {
            if (mASDisease.getOfflineCaseID().compareTo(ad.getOfflineCaseID()) != 0) {
                if (ad.getDiagnosis() == mASDisease.getDiagnosis() && ad.getSpeciesType() == mASDisease.getSpeciesType() && ad.getSampleType() == mASDisease.getSampleType())
                    return false;
            }
		}
		return true;
	}

	private Boolean Validate() {
		ValidateResult vr = mASDisease.Validate(EidssDatabase.GetMandatoryFields(), EidssDatabase.GetInvisibleFields());
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
			default:
				break;
		}
		return false;
	}

	public void FinishThis(int result) {
		Intent intent = getIntent();
		if (result == Activity.RESULT_OK) {
			intent.putExtra(getResources().getString(R.string.EXTRA_ID_ITEM), mASDisease);
			intent.putExtra("position", position);
		}
		setResult(result, intent);
		finish();
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
}
