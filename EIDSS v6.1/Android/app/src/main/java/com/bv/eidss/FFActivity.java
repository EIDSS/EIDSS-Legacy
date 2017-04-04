package com.bv.eidss;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v7.widget.Toolbar;
import android.view.Menu;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.FFModel;
import com.bv.eidss.model.FFTypesEnum;
import com.bv.eidss.model.interfaces.IFFModel;
import com.bv.eidss.model.interfaces.IFFOperations;


public class FFActivity extends EidssBaseBlockTimeoutActivity
		implements EidssAndroidHelpers.DialogDoneListener,
		IFFModel<Object>,
		IFFOperations<Object>
{
	public void OnLine() {

	}

    public void OffLine() {

    }

    public void Remove() {

    }

	public void Home() {
		FinishThis(Activity.RESULT_OK);
	}

	public void FinishThis(int result) {
		Intent intent = getIntent();
		if (result == Activity.RESULT_OK) {
			intent.putExtra("ffmodel", FFModel);
		}
		setResult(result, intent);
		finish();
	}

	public void Save() {
		FinishThis(Activity.RESULT_OK);
	}

	@Override
	public FFModel getFFModel(long idFormType) {
		return FFModel;
	}

	private FFModel FFModel; //TODO

	private FFPresenterFragment FFFragment;

	@Override
	public FFPresenterFragment getFFFragment(long idFormType) {
		return FFFragment;
	}


	@Override
	public void SetDeterminant(long id) {
		RecalculateFF(id, false);
	}

	private void RecalculateFF(long id, Boolean needReloadAp){
		//recalculate FF
		EidssDatabase db = new EidssDatabase(this);
		FFModel.LoadTemplate(db, id);
		if (needReloadAp){

		}
		db.close();
	}


	public FFActivity(){}

	@Override
	public boolean onPrepareOptionsMenu(Menu menu) {
		menu.findItem(R.id.Remove).setVisible(false);
		menu.findItem(R.id.Refresh).setVisible(false);
		menu.findItem(R.id.Save).setVisible(false);
		return super.onPrepareOptionsMenu(menu);
	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.ff_activity);

		Bundle extras = getIntent().getExtras();
		long idDeterminant = extras.getLong("idSpeciesType");
		FFModel = getIntent().getParcelableExtra("ffmodel");
		String caption = extras.getString("caption");
		SetDeterminant(idDeterminant);

		setTitle(caption);
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
			FFFragment = FFPresenterFragment.newInstance(FFTypesEnum.None);
			fm.beginTransaction()
					.add(R.id.fragment_container, FFFragment)
					.commit();
			return FFFragment;
		}
		return fragment;
	}




	@Override
	public void onDone(int idDialog, boolean isPositive) {
		switch (idDialog) {
		}


	}

}
