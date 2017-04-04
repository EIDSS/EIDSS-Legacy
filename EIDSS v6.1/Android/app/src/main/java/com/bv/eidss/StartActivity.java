package com.bv.eidss;

import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.FragmentActivity;

import com.bv.eidss.data.EidssDatabase;

import java.util.List;

public class StartActivity extends FragmentActivity {

	public StartActivity() {
	}


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        final DeploymentCountry country = new DeploymentCountry();
        final EidssDatabase db = new EidssDatabase(this, country.getDefServerUrl(), country.getDefLoginOrganization(), country.getDefLoginUser());
        final String pwd = db.Options().getLocalPassword();
        db.close();

        if (pwd == null || pwd.compareTo("") == 0)
        {
            startActivityForResult(new Intent(getApplicationContext(), SetLocalPasswordActivity.class), getResources().getInteger(R.integer.ACTIVITY_ID_SET_LOCAL_PASSWORD));
        }
        else
        {
            EidssAndroidHelpers.SetLocale();
            startActivityForResult(new Intent(getApplicationContext(), LocalLoginActivity.class), getResources().getInteger(R.integer.ACTIVITY_ID_LOCAL_LOGIN));
        }
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data)
    {
        if (resultCode == RESULT_OK)
        {
            EidssBaseActivity.isLaunch = true;
            final EidssDatabase db = new EidssDatabase(this);
            db.MandatoryFields();// read here mandatory and invisible fields into static variables
            db.InvisibleFields();
            if ((EidssBaseActivity.getApplicationMode(db) & getResources().getInteger(R.integer.APPLICATION_MODE_HUMAN)) > 0)
                startActivityForResult(new Intent(this, HumanCaseListActivity.class), getResources().getInteger(R.integer.ACTIVITY_ID_HUMAN_LIST));
            else if ((EidssBaseActivity.getApplicationMode(db) & getResources().getInteger(R.integer.APPLICATION_MODE_VETERINARY)) > 0)
                startActivityForResult(new Intent(this, VetCaseListActivity.class), getResources().getInteger(R.integer.ACTIVITY_ID_VET_LIST));
            else if ((EidssBaseActivity.getApplicationMode(db) & getResources().getInteger(R.integer.APPLICATION_MODE_ASSESSION)) > 0)
                startActivityForResult(new Intent(this, ASSessionListActivity.class), getResources().getInteger(R.integer.ACTIVITY_ID_ASSESSION_LIST));
            else
                startActivityForResult(new Intent(this, SettingsActivity.class), getResources().getInteger(R.integer.ACTIVITY_ID_OPTIONS));
            db.close();
        }
        else
        {
            finish();
        }
        super.onActivityResult(requestCode, resultCode, data);
    }
}
