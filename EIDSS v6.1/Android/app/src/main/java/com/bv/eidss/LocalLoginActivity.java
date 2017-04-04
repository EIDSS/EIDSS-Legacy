package com.bv.eidss;

import com.bv.eidss.data.EidssDatabase;
import android.app.Activity;
import android.os.Bundle;
import android.support.v4.app.FragmentActivity;
import android.view.View;
import android.widget.EditText;

public class LocalLoginActivity extends FragmentActivity {

	private Activity _this;
	public LocalLoginActivity() {
    	_this = this;
	}
    
	@Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTitle(R.string.TitleLocalLogin);
        setContentView(R.layout.local_login_layout);

    	findViewById(R.id.OkButton).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
	            final EditText pwd = (EditText)_this.findViewById(R.id.LoginPassword);
                EidssDatabase db = new EidssDatabase(_this);
                String password = db.Options().getLocalPassword();
                db.close();
                if (pwd.getText().toString().compareTo(password) != 0)
                {
                    EidssAndroidHelpers.AlertOkDialog.Warning(getSupportFragmentManager(), R.string.PasswordInvalid);
                	return;
                }

                setResult(RESULT_OK);
				finish();
			}
		});

    }

}
