package com.bv.eidss;

import com.bv.eidss.data.EidssDatabase;
import android.app.Activity;
import android.app.Dialog;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;

public class LocalLoginActivity extends Activity {
    private final int PASSWORD_INVALID_DIALOG_ID = 1;

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
			@SuppressWarnings("deprecation")
			public void onClick(View v) {
	            EditText pwd = (EditText)_this.findViewById(R.id.LoginPassword);
                EidssDatabase db = new EidssDatabase(_this);
                String password = db.Options().getLocalPassword();
                db.close();
                if (pwd.getText().toString().compareTo(password) != 0)
                {
                	showDialog(PASSWORD_INVALID_DIALOG_ID);
                	return;
                }

                _this.setResult(RESULT_OK);
				_this.finish();
			}
		});
    	findViewById(R.id.CancelButton).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				_this.setResult(RESULT_CANCELED);
				_this.finish();
			}
		});
    }

	@Override
    protected Dialog onCreateDialog(int id) {
        switch (id)
        {
	        case PASSWORD_INVALID_DIALOG_ID:
                return EidssAndroidHelpers.ErrorDialog(this, getResources().getString(R.string.PasswordInvalid));
        }
        return null;
    }
	
}
