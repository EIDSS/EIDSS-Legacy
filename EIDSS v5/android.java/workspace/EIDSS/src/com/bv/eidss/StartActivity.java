package com.bv.eidss;

import com.bv.eidss.data.EidssDatabase;
import android.app.Activity;
import android.app.Dialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;

public class StartActivity extends Activity {
    private final int REFLOAD_DIALOG_ID = 0;

	public StartActivity() {
	}

	@Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        String pwd;
        EidssDatabase db = new EidssDatabase(this);
        pwd = db.Options().getLocalPassword();
        db.close();

        if (pwd == null || pwd.compareTo("") == 0)
        {
			Intent intent = new Intent();
			intent = intent.setClass(getApplicationContext(), SetLocalPasswordActivity.class);
			startActivityForResult(intent, 2);
        }
        else
        {
			Intent intent = new Intent();
			intent = intent.setClass(getApplicationContext(), LocalLoginActivity.class);
			startActivityForResult(intent, 1);
        }
    }
	
	@SuppressWarnings("deprecation")
	@Override
    public void onActivityResult(int requestCode, int resultCode, Intent data)
    {
        if (requestCode == 1)
        {
            if (resultCode == RESULT_OK)
            {
    			Intent intent = new Intent();
    			intent = intent.setClass(getApplicationContext(), MainActivity.class);
    			startActivityForResult(intent, 3);
            }
            else
            {
                finish();
            }
        }
        if (requestCode == 2)
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
        if (requestCode == 3)
        {
            finish();
        }
        if (requestCode == 4)
        {
			Intent intent = new Intent();
			intent = intent.setClass(getApplicationContext(), MainActivity.class);
			startActivityForResult(intent, 3);
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
							startActivityForResult(intent, 4);
						}},
                	new DialogInterface.OnClickListener(){
						@Override
						public void onClick(DialogInterface dialog, int which) {
							Intent intent = new Intent();
							intent = intent.setClass(getApplicationContext(), MainActivity.class);
							startActivityForResult(intent, 3);
						}
					});
        }
        return null;
    }
	
}
