package com.bv.eidss;

import com.bv.eidss.data.EidssDatabase;
import android.app.Dialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;

public class StartActivity extends EidssBaseActivity {
    private final int REFLOAD_DIALOG_ID = 0;

	public StartActivity() {
	}

	@Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        String pwd;
        DeploymentCountry country = new DeploymentCountry();
        EidssDatabase db = new EidssDatabase(this, country.getDefServerUrl(), country.getDefLoginOrganization(), country.getDefLoginUser());
        pwd = db.Options().getLocalPassword();
        db.close();

        if (pwd == null || pwd.compareTo("") == 0)
        {
			Intent intent = new Intent();
			intent = intent.setClass(getApplicationContext(), SetLocalPasswordActivity.class);
			startActivityForResult(intent, ACTIVITY_ID_SET_LOCAL_PASSWORD);
        }
        else
        {
			Intent intent = new Intent();
			intent = intent.setClass(getApplicationContext(), LocalLoginActivity.class);
			startActivityForResult(intent, ACTIVITY_ID_LOCAL_LOGIN);
        }
    }
	
	@Override
    public void onActivityResult(int requestCode, int resultCode, Intent data)
    {
        if (requestCode == ACTIVITY_ID_LOCAL_LOGIN)
        {
            if (resultCode == RESULT_OK)
            {
    			Intent intent = new Intent();
    			intent = intent.setClass(getApplicationContext(), MainActivity.class);
    			startActivityForResult(intent, ACTIVITY_ID_MAIN);
            }
            else
            {
                finish();
            }
        }
        if (requestCode == ACTIVITY_ID_SET_LOCAL_PASSWORD)
        {
            if (resultCode == RESULT_OK)
            {
                showDialog(REFLOAD_DIALOG_ID);
            }
            else
            {
                finish();
            }
        }
        if (requestCode == ACTIVITY_ID_MAIN)
        {
            finish();
        }
        if (requestCode == ACTIVITY_ID_LOAD_REFERENCES)
        {
			Intent intent = new Intent();
			intent = intent.setClass(getApplicationContext(), MainActivity.class);
			startActivityForResult(intent, ACTIVITY_ID_MAIN);
        }
        super.onActivityResult(requestCode, resultCode, data);
    }

	@Override
    protected Dialog onCreateDialog(int id) {
        switch (id)
        {
	        case REFLOAD_DIALOG_ID:
                return EidssAndroidHelpers.QuestionDialog(this,
            		getResources().getString(R.string.LoadRefOnStart),
                	new DialogInterface.OnClickListener(){
						@Override
						public void onClick(DialogInterface dialog, int which) {
							Intent intent = new Intent();
							intent = intent.setClass(getApplicationContext(), LoadReferencesActivity.class);
							startActivityForResult(intent, ACTIVITY_ID_LOAD_REFERENCES);
						}},
                	new DialogInterface.OnClickListener(){
						@Override
						public void onClick(DialogInterface dialog, int which) {
							Intent intent = new Intent();
							intent = intent.setClass(getApplicationContext(), MainActivity.class);
							startActivityForResult(intent, ACTIVITY_ID_MAIN);
						}
					});
        }
        return null;
    }
	
}
