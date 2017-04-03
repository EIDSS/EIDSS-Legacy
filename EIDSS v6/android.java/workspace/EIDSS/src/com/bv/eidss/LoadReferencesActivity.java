package com.bv.eidss;

import java.net.SocketTimeoutException;
import java.util.Date;

import org.apache.http.client.HttpResponseException;
import org.apache.http.conn.ConnectTimeoutException;
import org.apache.http.conn.HttpHostConnectException;

import com.bv.eidss.web.VectorBaseReferenceRaw;
import com.bv.eidss.web.VectorBaseReferenceTranslationRaw;
import com.bv.eidss.web.VectorGisBaseReferenceRaw;
import com.bv.eidss.web.VectorGisBaseReferenceTranslationRaw;
import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.Options;
import com.bv.eidss.web.WebApiClient;

import android.app.Dialog;
import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;

public class LoadReferencesActivity extends EidssBaseBlockTimeoutActivity {
    private final int PROGRESS_DIALOG_ID = 0;
    public ProgressDialog mDialog;
    public int iErr = 0;
    private LoadReferenceTask task = null;
	
	private LoadReferencesActivity _this;
	public LoadReferencesActivity() {
    	_this = this;
	}

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTitle(R.string.TitleLoadReferences);
        setContentView(R.layout.load_references_layout);

        EidssDatabase db = new EidssDatabase(_this);
        String org = db.Options().getLoginOrganization();
        String usr = db.Options().getLoginUsername();
        ((EditText)findViewById(R.id.LoginOrganization)).setText(org);
        ((EditText)findViewById(R.id.LoginName)).setText(usr);
        db.close();
        
    	findViewById(R.id.OkButton).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				Intent intent = new Intent();
		    	intent.putExtra(EXTRA_ID_MODE, APP_DOWNLOAD_MODE_REFS);
		    	intent.setClass(getApplicationContext(), AppDownloadActivity.class);
		    	startActivityForResult(intent, ACTIVITY_ID_APP_DOWNLOAD);
			}
		});
    	findViewById(R.id.CancelButton).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				_this.finish();
			}
		});
    }

	@Override
    public void onActivityResult(int requestCode, int resultCode, Intent data)
    {
        if (requestCode == ACTIVITY_ID_APP_DOWNLOAD) {
        	if (resultCode == RESULT_OK){
				_this.showDialog(PROGRESS_DIALOG_ID);
				task = new LoadReferenceTask();
				task.execute(_this);
        	}
        }
    
        super.onActivityResult(requestCode, resultCode, data);
    }
    
    
    @Override
    protected Dialog onCreateDialog(int id) {
    	switch(id)
    	{
    		case PROGRESS_DIALOG_ID:
    			mDialog = EidssAndroidHelpers.ProgressDialog(this, R.string.WaitLoading, new DialogInterface.OnClickListener(){
	    			public void onClick(DialogInterface dialog, int which) {
						if (task.cancel(true)){
							mDialog.dismiss();
			            	showDialog(R.string.SynchronizationAborted);
						}
	    			}});
    			return mDialog;
	        case R.string.ConnectionErr:
            case R.string.ConnectionFailed:
            case R.string.LoginFailed:
            case R.string.AccessFailed:
            case R.string.NetworkTimeout:
            case R.string.GeneralError:
            case R.string.SynchronizationAborted:
                return EidssAndroidHelpers.ErrorDialog(this, getResources().getString(id));
            case R.string.ReferencesUpdated:
            	return EidssAndroidHelpers.MessageDialog(this, getResources().getString(id), new DialogInterface.OnClickListener(){
					public void onClick(DialogInterface dialog, int which) {
						finish();
					}});
    	}
    	return null;
    }
}


final class LoadReferenceTask extends AsyncTask<LoadReferencesActivity, Void, Void>{
	@Override
	protected Void doInBackground(LoadReferencesActivity... params) {
		final LoadReferencesActivity activity = params[0];
		activity.iErr = 0;
		VectorBaseReferenceRaw refs = null;
		VectorBaseReferenceTranslationRaw refs_trans = null; 
		VectorGisBaseReferenceRaw gis_refs = null;
		VectorGisBaseReferenceTranslationRaw gis_refs_trans = null;
		String org = "";
		String usr = "";
		try {
	        EidssDatabase db = new EidssDatabase(activity);
	        String url = db.Options().getServerUrl();
	        int timeout = db.Options().getResponseTimeout();
	        db.close();
	        org = ((EditText)activity.findViewById(R.id.LoginOrganization)).getText().toString();
	        usr = ((EditText)activity.findViewById(R.id.LoginName)).getText().toString();
	        String pwd = ((EditText)activity.findViewById(R.id.LoginPassword)).getText().toString();
	        
	        WebApiClient webClient = new WebApiClient(url, org, usr, pwd, timeout);
	        refs = webClient.LoadReferences();
	        refs_trans = webClient.LoadReferenceTranslations();
	        gis_refs = webClient.LoadGisReferences();
	        gis_refs_trans = webClient.LoadGisReferenceTranslations();
		}
		catch(HttpResponseException e){
			if (e.getStatusCode() == 401){
				activity.iErr = R.string.LoginFailed;
			}
			else if (e.getStatusCode() == 403){
				activity.iErr = R.string.AccessFailed;
			}
			else{
				activity.iErr = R.string.ConnectionFailed;
			}
		}
		catch(HttpHostConnectException e){
			activity.iErr = R.string.ConnectionErr;
		}
		catch(SocketTimeoutException e){
			activity.iErr = R.string.NetworkTimeout;
		}
		catch(ConnectTimeoutException e){
			activity.iErr = R.string.ConnectionFailed;
		}
		catch(Exception e){
			activity.iErr = R.string.GeneralError;
		}

		if (activity.iErr == 0){
	        EidssDatabase db = new EidssDatabase(activity);
	        if (db.LoadReferences(refs, refs_trans, gis_refs, gis_refs_trans)){
	        	Options opt = db.Options();
                opt.setLoginOrganization(org);
                opt.setLoginUsername(usr);
                opt.setLastRefUpdt(new Date());
                db.OptionsUpdate(opt);
	        }
	        db.close();
			
			activity.mDialog.dismiss();
			activity.runOnUiThread(new Runnable() {
	            public void run() {
	            	activity.showDialog(R.string.ReferencesUpdated);
	            }
	        });
		}
		else{
			activity.mDialog.dismiss();
			activity.runOnUiThread(new Runnable() {
	            public void run() {
	            	activity.showDialog(activity.iErr);
	            }
	        });
		}
		return null;
	}
}
