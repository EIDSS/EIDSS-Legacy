package com.bv.eidss;

import android.os.Bundle;
import android.app.Activity;
import android.content.Intent;
import android.view.View;
import android.widget.EditText;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.Options;

public class OptionsActivity extends Activity {

	private Activity _this;
	public OptionsActivity() {
    	_this = this;
	}
	
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTitle(R.string.TitleSettings);
        setContentView(R.layout.options_layout);
   	
        final EditText url = (EditText)findViewById(R.id.ServerUrl);
        
        EidssDatabase db = new EidssDatabase(this);
        url.setText(db.Options().getServerUrl());
        db.close();
        
    	findViewById(R.id.OkButton).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
		        EidssDatabase db = new EidssDatabase(_this);
                Options o = db.Options();
		        o.setServerUrl(url.getText().toString());
                db.OptionsUpdate(o);
                db.close();
				_this.finish();
			}
		});
    	findViewById(R.id.CancelButton).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				_this.finish();
			}
		});
    	findViewById(R.id.LoadReferencesButton).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				_this.startActivity((new Intent()).setClass(getApplicationContext(), LoadReferencesActivity.class));
			}
		});
    	findViewById(R.id.SetPasswordButton).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				_this.startActivity((new Intent()).setClass(getApplicationContext(), ChangeLocalPasswordActivity.class));
			}
		});
    	
    }
	
}
