package com.bv.eidss;

import android.app.Dialog;
import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.Spinner;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.Options;
import com.bv.eidss.utils.CheckOneToHundred;
import com.bv.eidss.web.WebApiClient;

public class SettingsActivity extends EidssBaseBlockTimeoutActivity {
    private final int PROGRESS_DIALOG_ID = 0;
    private final int ERROR_DIALOG_ID = 2;
	private SettingsActivity _this;
	public SettingsActivity() {
    	_this = this;
	}
	CheckTask mt;
	public EditText srvto;
	public EditText url;
    public int iErr = 0;
    public ProgressDialog mDialog;
	
	@Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTitle(R.string.TitleSettings);
        setContentView(R.layout.settings_layout);
   	
        final EditText recsl = (EditText)findViewById(R.id.NumberRecordsList);
        recsl.addTextChangedListener(new CheckOneToHundred());
        url = (EditText)findViewById(R.id.ServerUrl);
        final EditText appto = (EditText)findViewById(R.id.ApplicationLockingTimeout);
        appto.addTextChangedListener(new CheckOneToHundred());
        srvto = (EditText)findViewById(R.id.ServerResponseTimeout);
        srvto.addTextChangedListener(new CheckOneToHundred());
        
        final EidssDatabase db = new EidssDatabase(this);
        Options o = db.Options();
        
        recsl.setText(Integer.toString(o.getPageSize(),10));
        url.setText(o.getServerUrl());
        appto.setText(Integer.toString(o.getLockTimeout(),10));
        srvto.setText(Integer.toString(o.getResponseTimeout(),10));
        
        final Spinner appm = (Spinner) findViewById(R.id.ApplicationMode);
        ArrayAdapter<CharSequence> adapter = ArrayAdapter.createFromResource(this,
        		R.array.ApplicationMode_array, android.R.layout.simple_spinner_item);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        appm.setAdapter(adapter);
        appm.setSelection(o.getApplicationMode()-1);
        
        db.close();
        
        findViewById(R.id.OkButton).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
                Options o = db.Options();
                int myNum;
                try {
                    myNum = Integer.parseInt(recsl.getText().toString());
			        o.setPageSize(myNum);
                    myNum = Integer.parseInt(appto.getText().toString());
			        o.setLockTimeout(myNum);
	                EidssBaseBlockTimeoutActivity.timeoutLock = myNum;
                    myNum = Integer.parseInt(srvto.getText().toString());
			        o.setResponseTimeout(myNum);
                } catch(NumberFormatException nfe) {
                	Bundle bundle = new Bundle();
                	bundle.putString("text", "Could not parse " + nfe);
                    showDialog(ERROR_DIALOG_ID, bundle);
                    return;
                }
                myNum = appm.getSelectedItemPosition()+1;
                o.setApplicationMode(myNum);
                MainActivity.ApplicationMode = myNum;
		        o.setServerUrl(url.getText().toString());
                db.OptionsUpdate(o);
                db.close();
				finish();
			}
		});
    	findViewById(R.id.CheckConnection).setOnClickListener(new View.OnClickListener() {
			@Override
			public void onClick(View v) {
				_this.showDialog(PROGRESS_DIALOG_ID);
				mt = new CheckTask();
				mt.execute(_this);
			}
		});
    	findViewById(R.id.RestoreDefaults).setOnClickListener(new View.OnClickListener() {
			@Override
			public void onClick(View v) {
                Options o = db.Options();
                recsl.setText(Integer.toString(o.getPageSizeDef(),10));
                url.setText(o.getServerUrlDef());
                int myNum = o.getLockTimeoutDef();
                appto.setText(Integer.toString(myNum));
                EidssBaseBlockTimeoutActivity.timeoutLock = myNum;
                srvto.setText(Integer.toString(o.getResponseTimeoutDef(),10));
                myNum = o.getApplicationModeDef()-1;
                appm.setSelection(myNum);
                MainActivity.ApplicationMode = myNum;
                db.close();
			}
		});
    	findViewById(R.id.CancelButton).setOnClickListener(new View.OnClickListener() {
			@Override
			public void onClick(View v) {
				finish();
			}
		});
    }

	@Override
    protected Dialog onCreateDialog(int id, Bundle bundle) {
        switch (id)
        {
			case PROGRESS_DIALOG_ID:
    			mDialog = EidssAndroidHelpers.ProgressDialog(this, R.string.WaitChecking, new DialogInterface.OnClickListener(){
	    			public void onClick(DialogInterface dialog, int which) {
						if (mt.cancel(true)){
							mDialog.dismiss();
			            	showDialog(R.string.CheckingAborted);
						}
	    			}});
    			return mDialog;
	        case ERROR_DIALOG_ID:
	            return EidssAndroidHelpers.ErrorDialog(this, bundle.getString("text"));
	        case R.string.ConnectionOk:
	        case R.string.ConnectionErr:
	        case R.string.CheckingAborted:
	            return EidssAndroidHelpers.ErrorDialog(this, getResources().getString(id));
        }
        return null;
    }

}

final class CheckTask extends AsyncTask<SettingsActivity, Void, String>{
	@Override
	protected String doInBackground(SettingsActivity... params) {
		final SettingsActivity activity = params[0];
		activity.iErr = 0;
		
		try {
	        String url = activity.url.getText().toString();
	        int timeout = 1;
            try {
            	timeout = Integer.parseInt(activity.srvto.getText().toString());
            } catch(NumberFormatException nfe) {}
	        
  	        WebApiClient webClient = new WebApiClient(url, "", "", "", timeout);
   	        webClient.Check();
		}
		catch(Exception e){
			activity.iErr = R.string.ConnectionErr;
		}

		if (activity.iErr == 0){
			activity.mDialog.dismiss();
			activity.runOnUiThread(new Runnable() {
				@Override
	            public void run() {
	            	activity.showDialog(R.string.ConnectionOk);
	            }
	        });
		}
		else{
			activity.mDialog.dismiss();
			activity.runOnUiThread(new Runnable() {
				@Override
	            public void run() {
	            	activity.showDialog(activity.iErr);
	            }
	        });
		}
		return "";
	}
}
