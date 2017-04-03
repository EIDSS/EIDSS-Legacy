package com.bv.eidss;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.Options;
import android.app.Activity;
import android.app.Dialog;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;

public class SetLocalPasswordActivity extends Activity {
    private final int PASSWORD_NOT_SET_DIALOG_ID = 1;
    private final int PASSWORD_NOT_SAME_DIALOG_ID = 2;

	private Activity _this;
	public SetLocalPasswordActivity() {
    	_this = this;
	}
    
	@Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTitle(R.string.TitleSetLocalPassword);
        setContentView(R.layout.set_local_password_layout);

    	findViewById(R.id.OkButton).setOnClickListener(new View.OnClickListener() {
			@SuppressWarnings("deprecation")
			public void onClick(View v) {
	            EditText pwd = (EditText)_this.findViewById(R.id.LoginPassword);
	            EditText pwd2 = (EditText)_this.findViewById(R.id.LoginPassword2);
                if (pwd.getText().toString().compareTo(pwd2.getText().toString()) != 0)
                {
                    showDialog(PASSWORD_NOT_SAME_DIALOG_ID);
                    return;
                }
                if (pwd.getText().length() < 6)
                {
                    showDialog(PASSWORD_NOT_SET_DIALOG_ID);
                    return;
                }
                EidssDatabase db = new EidssDatabase(_this);
                Options opt = db.Options();
                opt.setLocalPassword(pwd.getText().toString());
                db.OptionsUpdate(opt);
                db.close();
                
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
	        case PASSWORD_NOT_SET_DIALOG_ID:
                return EidssAndroidHelpers.ErrorDialog(this, getResources().getString(R.string.PasswordNotSet));
	        case PASSWORD_NOT_SAME_DIALOG_ID:
                return EidssAndroidHelpers.ErrorDialog(this, getResources().getString(R.string.PasswordNotSame));
        }
        return null;
    }
	
}
