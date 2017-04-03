package com.bv.eidss;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.Options;

import android.app.Activity;
import android.app.Dialog;
import android.graphics.Typeface;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.View;
import android.widget.EditText;
import android.widget.Button;

public class SetLocalPasswordActivity extends EidssBaseBlockTimeoutActivity {
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
        final Button btnContinue = (Button)_this.findViewById(R.id.OkButton);
    	btnContinue.setEnabled(false);
        final EditText pwd = (EditText)_this.findViewById(R.id.LoginPassword);
        final EditText pwd2 = (EditText)_this.findViewById(R.id.LoginPassword2);
        pwd.setTypeface( Typeface.DEFAULT );  
        pwd2.setTypeface( Typeface.DEFAULT );  
        
        pwd.addTextChangedListener(new TextWatcher(){
            public void afterTextChanged(Editable s) {
                if(s.length() >= PASSWORD_MIN_LENGTH & pwd2.length() >= PASSWORD_MIN_LENGTH)
                	btnContinue.setEnabled(true);
                else
                	btnContinue.setEnabled(false);
            }
            public void beforeTextChanged(CharSequence s, int start, int count, int after){}
            public void onTextChanged(CharSequence s, int start, int before, int count){}
        }); 
        pwd2.addTextChangedListener(new TextWatcher(){
            public void afterTextChanged(Editable s) {
                if(s.length() >= PASSWORD_MIN_LENGTH & pwd.length() >= PASSWORD_MIN_LENGTH)
                	btnContinue.setEnabled(true);
                else
                	btnContinue.setEnabled(false);
            }
            public void beforeTextChanged(CharSequence s, int start, int count, int after){}
            public void onTextChanged(CharSequence s, int start, int before, int count){}
        }); 
        btnContinue.setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
                if (pwd.getText().toString().compareTo(pwd2.getText().toString()) != 0)
                {
                    showDialog(PASSWORD_NOT_SAME_DIALOG_ID);
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
	        case PASSWORD_NOT_SAME_DIALOG_ID:
                return EidssAndroidHelpers.ErrorDialog(this, getResources().getString(R.string.PasswordNotSame));
        }
        return null;
    }
	
}
