package com.bv.eidss;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;

import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v7.widget.Toolbar;
import android.widget.TextView;


import com.bv.eidss.barcode.BarcodeTestActivity;
import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.Animal;


import com.bv.eidss.model.BaseReference;
import com.bv.eidss.model.BaseReferenceType;
import com.bv.eidss.model.CaseTypeHACode;
import com.bv.eidss.model.interfaces.ValidateCode;
import com.bv.eidss.model.interfaces.ValidateResult;
import com.bv.eidss.utils.EidssUtils;

import java.util.ArrayList;
import java.util.List;


public class AnimalActivity extends BarcodeTestActivity {
	public Animal mAnimal;
	int position = -1;	//-1 means new animal
	public List<BaseReference> mSpeciesTypes;


	private AnimalActivity _this;

	public AnimalActivity() {
		_this = this;
	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.ff_activity);

		final Intent intent = getIntent();
		mAnimal = intent.getParcelableExtra(getResources().getString(R.string.EXTRA_ID_ITEM));
		position = intent.getIntExtra("position", -1);

        mSpeciesTypes = (List<BaseReference>)intent.getSerializableExtra(getResources().getString(R.string.EXTRA_ID_ITEMS));

		setTitle(getResources().getString(R.string.Animal));
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
			fragment = new AnimalFragment();
			fm.beginTransaction()
					.add(R.id.fragment_container, fragment)
					.commit();
		}
		return fragment;
	}

	@Override
	public void onActivityResult(int requestCode, int resultCode, Intent data){
		if (requestCode == getResources().getInteger(R.integer.REQUEST_BARCODE)) {
			if (resultCode == Activity.RESULT_OK) {
				String result = data.getStringExtra("barcode");
				((TextView) findViewById(R.id.strAnimalCode)).setText(result);
			}
		}

		super.onActivityResult(requestCode, resultCode, data);
	}


	@Override
	public void onBackPressed() {
		Home();
	}

	public void Home() {
		if (mAnimal.getChanged()) {
			if(position == -1 && mAnimal.isEmpty())
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
		ValidateResult vr = mAnimal.Validate(EidssDatabase.GetMandatoryFields(), EidssDatabase.GetInvisibleFields());
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
			intent.putExtra(getResources().getString(R.string.EXTRA_ID_ITEM), mAnimal);
			intent.putExtra("position", position);
		}
		setResult(result, intent);
		finish();
	}
}
