package com.bv.eidss;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v7.widget.Toolbar;
import android.widget.AutoCompleteTextView;
import android.widget.TextView;

import com.bv.eidss.barcode.BarcodeTestActivity;
import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.generated.ASSample_binding;
import com.bv.eidss.model.ASSample;
import com.bv.eidss.model.ASSession;
import com.bv.eidss.model.interfaces.ValidateCode;
import com.bv.eidss.model.interfaces.ValidateResult;
import com.bv.eidss.utils.DateHelpers;


public class ASSampleActivity extends BarcodeTestActivity
		implements EidssAndroidHelpers.DialogDoneListener,
                   EidssAndroidHelpers.DialogDoneDateListener{
	public final int CANCEL_DIALOG_ID = 3;

	public ASSample mASSample;
    public ASSession mASSession;
	int position = -1;	//-1 means new ASSample
	//public List<BaseReference> mSpeciesTypes;


	private ASSampleActivity _this;

	public ASSampleActivity() {
		_this = this;
	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.ff_activity);

		final Intent intent = getIntent();
		mASSample = intent.getParcelableExtra(getResources().getString(R.string.EXTRA_ID_ITEM));
        mASSession = intent.getParcelableExtra(getResources().getString(R.string.EXTRA_ID_ASSESSION));
		position = intent.getIntExtra("position", -1);

        setTitle(getResources().getString(R.string.ASSample));
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
			fragment = new ASSampleFragment();
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
                AutoCompleteTextView ac = (AutoCompleteTextView)findViewById(R.id.idfAnimal);
                ac.setText(result);
			}
		}

		super.onActivityResult(requestCode, resultCode, data);
	}


	@Override
	public void onBackPressed() {
		Home();
	}

	public void Home() {
		if (mASSample.getChanged()) {
			if(position == -1 && mASSample.isEmpty())
				FinishThis(RESULT_CANCELED);
			else
				Save();
		}
		else
			FinishThis(RESULT_CANCELED);
	}

    public void Copy() {
        SaveAndCopy();
    }

	public void Save() {
		if (Validate()) {
			FinishThis(Activity.RESULT_OK);
		}
	}

    public void SaveAndCopy() {
        if (Validate()) {
            FinishThis(Activity.RESULT_FIRST_USER);
        }
    }

    private Boolean Validate() {
		ValidateResult vr = mASSample.Validate(EidssDatabase.GetMandatoryFields(), EidssDatabase.GetInvisibleFields());
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
			intent.putExtra(getResources().getString(R.string.EXTRA_ID_ITEM), mASSample);
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

    @Override
    public void onDone(int idDialog, int year, int month, int day) {
        switch (idDialog) {

            /*place snippet here!*/

            case ASSample_binding.datFieldCollectionDate_DialogID:
                mASSample.setFieldCollectionDate(DateHelpers.Date(year, month, day));
                DateHelpers.DisplayDate(R.id.datFieldCollectionDate, this, mASSample.getFieldCollectionDate());
                break;

            /*end of place snippet here!*/

        }

    }
}
