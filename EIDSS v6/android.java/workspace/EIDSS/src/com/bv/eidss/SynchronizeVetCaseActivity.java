 package com.bv.eidss;

import java.net.SocketTimeoutException;
import java.util.Date;
import java.util.Formatter;
import java.util.List;
import java.util.Vector;
import java.util.concurrent.ExecutionException;

import org.apache.http.client.HttpResponseException;
import org.apache.http.conn.ConnectTimeoutException;
import org.apache.http.conn.HttpHostConnectException;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.CaseStatus;
import com.bv.eidss.model.Options;
import com.bv.eidss.model.Species;
import com.bv.eidss.model.VetCase;
import com.bv.eidss.web.VetCaseInfoIn;
import com.bv.eidss.web.VetCaseInfoOut;
import com.bv.eidss.web.WebApiClient;

import android.app.Dialog;
import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;

public class SynchronizeVetCaseActivity extends EidssBaseBlockTimeoutActivity {
    private final int PROGRESS_DIALOG_ID = 0;
    public final int RESULT_DIALOG_ID = 1;
    public ProgressDialog mDialog;
    public String strErrMessage = null;
    public int iErr = 0;
    public int iAdded = 0;
    public int iUpdated = 0;
    public int iDeleted = 0;
    public int iFailed = 0;
    public long lId = 0;
    SynchronizeVetCaseTask mt;
	
	private SynchronizeVetCaseActivity _this;
	public SynchronizeVetCaseActivity() {
    	_this = this;
	}

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTitle(R.string.SynchronizeVetCases);
        setContentView(R.layout.synchronize_layout);
        
        Intent intent = getIntent();
        lId = intent.getLongExtra("Id", 0);
        
        EidssDatabase db = new EidssDatabase(_this);
        String org = db.Options().getLoginOrganization();
        String usr = db.Options().getLoginUsername();
        ((EditText)findViewById(R.id.LoginOrganization)).setText(org);
        ((EditText)findViewById(R.id.LoginName)).setText(usr);
        db.close();
        
    	findViewById(R.id.OkButton).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				Intent intent = new Intent();
		    	intent.putExtra(EXTRA_ID_MODE, APP_DOWNLOAD_MODE_CASE);
		    	intent.setClass(getApplicationContext(), AppDownloadActivity.class);
		    	startActivityForResult(intent, ACTIVITY_ID_APP_DOWNLOAD);
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
    public void onActivityResult(int requestCode, int resultCode, Intent data)
    {
        if (requestCode == ACTIVITY_ID_APP_DOWNLOAD) {
        	if (resultCode == RESULT_OK){
				_this.showDialog(PROGRESS_DIALOG_ID);
				mt = new SynchronizeVetCaseTask();
				mt.execute(_this);
        	}
        }
    
        super.onActivityResult(requestCode, resultCode, data);
    }
    
    @Override
    protected Dialog onCreateDialog(int id) {
    	switch(id)
    	{
    		case PROGRESS_DIALOG_ID:
    			mDialog = EidssAndroidHelpers.ProgressDialog(this, R.string.WaitSynchronizing, new DialogInterface.OnClickListener(){
	    			public void onClick(DialogInterface dialog, int which) {
						if (mt.cancel(true)){
							mDialog.dismiss();
			            	showDialog(R.string.SynchronizationAborted);
						}
	    			}});
    			return mDialog;
            case RESULT_DIALOG_ID:
                return EidssAndroidHelpers.MessageDialog(this, 
                    (new Formatter()).format(_this.getResources().getString(R.string.SynResult), iAdded, iUpdated, iFailed).toString(), 
                	new DialogInterface.OnClickListener(){
						@Override
						public void onClick(DialogInterface dialog, int which) {
							Intent intent = new Intent();
							try {
								VetCase vc = mt.get();
								intent.putExtra("vc", vc);
							} catch (InterruptedException e) {
								// TODO Auto-generated catch block
								e.printStackTrace();
							} catch (ExecutionException e) {
								// TODO Auto-generated catch block
								e.printStackTrace();
							}
							dialog.dismiss();
							_this.setResult(RESULT_OK, intent);
                            _this.finish();
						}
                    });
            case R.string.LoginFailed:
            	if (strErrMessage != null)
                    return EidssAndroidHelpers.ErrorDialog(this, strErrMessage);
                return EidssAndroidHelpers.ErrorDialog(this, getResources().getString(id));
	        case R.string.ConnectionErr:
            case R.string.ConnectionFailed:
            case R.string.AccessFailed:
            case R.string.NetworkTimeout:
            case R.string.GeneralError:
            case R.string.SynchronizationAborted:
                return EidssAndroidHelpers.ErrorDialog(this, getResources().getString(id));
    	}
    	return null;
    }
}


final class SynchronizeVetCaseTask extends AsyncTask<SynchronizeVetCaseActivity, Void, VetCase>{
	@Override
	protected VetCase doInBackground(SynchronizeVetCaseActivity... params) {
		final SynchronizeVetCaseActivity activity = params[0];
		activity.iErr = 0;
		
		Vector<VetCaseInfoOut> vcs_out = new Vector<VetCaseInfoOut>(); 
		List<VetCase> vcs = null;
		VetCase vc = null;
		String org = "";
		String usr = "";
		try {
	        EidssDatabase db = new EidssDatabase(activity);
	        String url = db.Options().getServerUrl();
	        int timeout = db.Options().getResponseTimeout();
	        String lang = db.getCurrentLanguage();
	        long country = db.GisCountry(db.getCurrentLanguage()).idfsBaseReference;
	        vcs = db.VetCaseSelect(activity.lId);
	        db.close();

	        org = ((EditText)activity.findViewById(R.id.LoginOrganization)).getText().toString();
	        usr = ((EditText)activity.findViewById(R.id.LoginName)).getText().toString();
	        String pwd = ((EditText)activity.findViewById(R.id.LoginPassword)).getText().toString();
	        
	        for(int i = 0; i < vcs.size(); i++){
	        	vc = vcs.get(i);
	        	if (vc.getStatus() == CaseStatus.NEW || vc.getStatus() == CaseStatus.CHANGED || vc.getStatus() == CaseStatus.UNLOADED){
        		
	    	        VetCaseInfoIn vcin = new VetCaseInfoIn(vc, lang, country);

	    	        WebApiClient webClient = new WebApiClient(url, org, usr, pwd, timeout);
	    	        VetCaseInfoOut out = webClient.VetCaseSave(vcin);
	    	        vcs_out.add(out);
	        	}
	        }

		}
		catch(HttpResponseException e){
			if (e.getStatusCode() == 401){
				String errMessage = e.getMessage();
				activity.iErr = R.string.LoginFailed;
				if (errMessage != null && errMessage != "")
					activity.strErrMessage = errMessage;  
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

	        activity.iAdded = 0;
            activity.iUpdated = 0;
            activity.iFailed = 0;
	        
            for(int i = 0; i < vcs_out.size(); i++){
	        	VetCaseInfoOut ci = vcs_out.get(i);
		        for(int j = 0; j < vcs.size(); j++){
		        	vc = vcs.get(j);
		        	if (ci.offlineCaseID.compareTo(vc.getOfflineCaseID()) == 0) {
		        		if (ci.isFailed){
	        				activity.iFailed++;
                            vc.setLastSynError(ci.lastErrorDescription);
    		        		db.VetCaseUpdate(vc);
		        		}
		        		else if(ci.isCreated || ci.isUpdated){
		        			if (ci.isCreated)
	                        	activity.iAdded++;
	                        else if (ci.isUpdated)
	                        	activity.iUpdated++;
                            vc.setCase(ci.id);
                            vc.setCaseID(ci.caseID);
                            vc.setFarmCode(ci.farmCode);
                            for (Species sp: vc.species){
                        		sp.setHerd(ci.herd);
                        	}
                            vc.setSentByOffice(ci.reportedByOrganization);
                            vc.setSentByPerson(ci.reportedByPerson);
                            vc.setLastSynError("");
                            vc.setStatusSyn();
    		        		db.VetCaseUpdate(vc);
		        		}
		        	}
		        }
	        }
	        
        	Options opt = db.Options();
            opt.setLoginOrganization(org);
            opt.setLoginUsername(usr);
            opt.setLastOnlineSyn(new Date());
            db.OptionsUpdate(opt);
            db.close();
			
			activity.mDialog.dismiss();
			activity.runOnUiThread(new Runnable() {
				@Override
	            public void run() {
	            	activity.showDialog(activity.RESULT_DIALOG_ID);
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
		return vc;
	}
}
