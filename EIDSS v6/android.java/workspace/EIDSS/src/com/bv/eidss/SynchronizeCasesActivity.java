package com.bv.eidss;

import java.net.SocketTimeoutException;
import java.util.Date;
import java.util.Formatter;
import java.util.List;
import java.util.Vector;

import org.apache.http.client.HttpResponseException;
import org.apache.http.conn.ConnectTimeoutException;
import org.apache.http.conn.HttpHostConnectException;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.HumanCase;
import com.bv.eidss.model.CaseStatus;
import com.bv.eidss.model.Options;
import com.bv.eidss.model.Species;
import com.bv.eidss.model.VetCase;
import com.bv.eidss.web.HumanCaseInfoIn;
import com.bv.eidss.web.HumanCaseInfoOut;
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

public class SynchronizeCasesActivity extends EidssBaseBlockTimeoutActivity {
    private final int PROGRESS_DIALOG_ID = 0;
    public final int RESULT_DIALOG_ID = 1;
    public ProgressDialog mDialog;
    public String strErrMessage = null;
    public int iErr = 0;
    public int iAdded = 0;
    public int iUpdated = 0;
    public int iFailed = 0;
    SynchronizeAllCasesTask mt;
	
	private SynchronizeCasesActivity _this;
	public SynchronizeCasesActivity() {
    	_this = this;
	}

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTitle(R.string.SynchronizeAllCases);
        setContentView(R.layout.synchronize_layout);
        
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
				mt = new SynchronizeAllCasesTask();
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
							dialog.dismiss();
							_this.setResult(RESULT_OK);
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


final class SynchronizeAllCasesTask extends AsyncTask<SynchronizeCasesActivity, Void, Void>{
	@Override
	protected Void doInBackground(SynchronizeCasesActivity... params) {
		final SynchronizeCasesActivity activity = params[0];
		activity.iErr = 0;
		activity.strErrMessage = null;
		
		Vector<HumanCaseInfoOut> hcs_out = new Vector<HumanCaseInfoOut>(); 
		List<HumanCase> hcs = null;
		HumanCase hc = null;
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
	        hcs = db.HumanCaseSelect(0, 0);
	        vcs = db.VetCaseSelect((long)0);
	        db.close();

	        org = ((EditText)activity.findViewById(R.id.LoginOrganization)).getText().toString();
	        usr = ((EditText)activity.findViewById(R.id.LoginName)).getText().toString();
	        String pwd = ((EditText)activity.findViewById(R.id.LoginPassword)).getText().toString();
	        
            // get human cases from service
	        for(int i = 0; i < hcs.size(); i++){
	        	hc = hcs.get(i);
	        	if (hc.getStatus() == CaseStatus.NEW || hc.getStatus() == CaseStatus.CHANGED || hc.getStatus() == CaseStatus.UNLOADED){
	    	        HumanCaseInfoIn hcin = new HumanCaseInfoIn(hc, lang, country);
	        		
	    	        WebApiClient webClient = new WebApiClient(url, org, usr, pwd, timeout);
	    	        HumanCaseInfoOut out = webClient.HumanCaseSave(hcin);
	    	        hcs_out.add(out);
	        	}
	        }
	        
            // get veterinary cases from service
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
	        
            // update human cases in database
            for(int i = 0; i < hcs_out.size(); i++){
	        	HumanCaseInfoOut ci = hcs_out.get(i);
		        for(int j = 0; j < hcs.size(); j++){
		        	hc = hcs.get(j);
		        	if (ci.offlineCaseID.compareTo(hc.getOfflineCaseID()) == 0) {
		        		if (ci.isFailed){
	        				activity.iFailed++;
                            hc.setLastSynError(ci.lastErrorDescription);
    		        		db.HumanCaseUpdate(hc);
		        		}
		        		else if (ci.isCreated)
                        {
                        	activity.iAdded++;

                            hc.setCase(ci.id);
                            hc.setCaseID(ci.caseID);
                            hc.setNotificationDate(ci.notificationDate);
                            hc.setSentByOffice(ci.notificationSentBy);
                            hc.setSentByPerson(ci.notificationSentByPerson);
                            hc.setLastSynError("");
                            hc.setStatusSyn();
    		        		db.HumanCaseUpdate(hc);
                        }
                        else if (ci.isUpdated){
                        	activity.iUpdated++;
                            hc.setCase(ci.id);
                            hc.setCaseID(ci.caseID);
                            hc.setLastSynError("");
                            hc.setStatusSyn();
    		        		db.HumanCaseUpdate(hc);
                        }
		        	}
		        }
	        }
	        
            // update veterinary cases in database
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
		        		else if (ci.isCreated)
                        {
                        	activity.iAdded++;
                        }
                        else if (ci.isUpdated){
                        	activity.iUpdated++;
                        	
                        }
		        		if(ci.isCreated || ci.isUpdated){
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
		return null;
	}
}
