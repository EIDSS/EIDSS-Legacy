package com.bv.eidss;

import java.io.File;
import java.io.FileOutputStream;
import java.net.SocketTimeoutException;

import org.apache.http.client.HttpResponseException;
import org.apache.http.conn.ConnectTimeoutException;
import org.apache.http.conn.HttpHostConnectException;

import com.bv.eidss.web.WebApiClient;
import com.bv.eidss.data.EidssDatabase;

import android.os.AsyncTask;
import android.os.Bundle;
import android.app.Activity;
import android.app.Dialog;
import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.pm.PackageInfo;

public class AppDownloadActivity extends EidssBaseBlockTimeoutActivity {
    private final int PROGRESS_DIALOG_ID = 0;
    private final int DOWNLOADING_DIALOG_ID = 1;
    public final int ASKFORDOWNLOAD_DIALOG_ID = 6;
    public final int NONEWVERSION_DIALOG_ID = 7;
    private final int ERROR_SAVE_FILE_DIALOG_ID = 8;
    private final int NEWVERSION_DIALOG_ID = 9;
    public int workMode; 
    public int iErr = 0;
    public String versionServer = null;
    public String versionLocal = null;
    public VersionTask mt;
    public DownloadingTask mt1;
    public ProgressDialog mDialog;
    public byte[] appContent;
	private AppDownloadActivity _this;
	public AppDownloadActivity() {
    	_this = this;
	}

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
   	
        Bundle extras = getIntent().getExtras();
        workMode = extras.getInt(EXTRA_ID_MODE, -1);
        
		_this.showDialog(PROGRESS_DIALOG_ID);
		mt = new VersionTask();
		mt.execute(_this);
    }	

	@Override
    protected Dialog onCreateDialog(int id) {
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
			case DOWNLOADING_DIALOG_ID:
				mDialog = EidssAndroidHelpers.ProgressDialog(this, R.string.WaitDownloading, new DialogInterface.OnClickListener(){
	    			public void onClick(DialogInterface dialog, int which) {
						if (mt.cancel(true)){
							mDialog.dismiss();
			            	showDialog(R.string.DownloadingAborted);
						}
	    			}});
				return mDialog;
			case ASKFORDOWNLOAD_DIALOG_ID:
                return EidssAndroidHelpers.QuestionDialog(this, getResources().getString(R.string.NewVersionDownloadConfirm),
                       	new DialogInterface.OnClickListener(){
        						@Override
        						public void onClick(DialogInterface dialog, int which) {
        							dialog.dismiss();
        							_this.setResult(Activity.RESULT_CANCELED);
        							_this.showDialog(DOWNLOADING_DIALOG_ID);
        							mt1 = new DownloadingTask();
        							mt1.execute(_this);
        						}},
                        	new DialogInterface.OnClickListener(){
        						@Override
        						public void onClick(DialogInterface dialog, int which) {
        							dialog.dismiss();
        							_this.setResult(Activity.RESULT_OK);
        							_this.finish();
        						}
        					});
            case ERROR_SAVE_FILE_DIALOG_ID:
                return EidssAndroidHelpers.ErrorDialogAndFinishActivity(this, getResources().getString(R.string.ErrorSaveAppFile));
            case NONEWVERSION_DIALOG_ID:
                return EidssAndroidHelpers.MessageDialogAndFinishActivity(this, getResources().getString(R.string.NoNewVersion));
            case NEWVERSION_DIALOG_ID:
                return EidssAndroidHelpers.MessageDialogAndFinishActivity(this, getResources().getString(R.string.NewVersionDownloaded));
	        case R.string.ConnectionErr:
            case R.string.ConnectionFailed:
            case R.string.LoginFailed:
            case R.string.AccessFailed:
            case R.string.NetworkTimeout:
            case R.string.GeneralError:
	        case R.string.CheckingAborted:
	        case R.string.DownloadingAborted:
				_this.setResult(Activity.RESULT_CANCELED);
	            return EidssAndroidHelpers.ErrorDialogAndFinishActivity(this, getResources().getString(id));
        }
        return null;
    }
	
	@Override
    public void onActivityResult(int requestCode, int resultCode, Intent data)
    {
        if (requestCode == FileBrowser.FILE_BROWSER_MODE_SAVE)
        {       
    		String fullFilename = data.getStringExtra(EXTRA_ID_FILENAME);
        	if (!fullFilename.isEmpty()){
	    		try {
	        		File file = new File(fullFilename);
	        		FileOutputStream filecon = new FileOutputStream(file);
	        		filecon.write(appContent);
	        		filecon.close();
					showDialog(NEWVERSION_DIALOG_ID);
				} catch (Exception e) {
					showDialog(ERROR_SAVE_FILE_DIALOG_ID);
					//e.printStackTrace();
				}
        	}
        	else{
				_this.finish();
        	}
        }
    
        super.onActivityResult(requestCode, resultCode, data);
    }
}

final class VersionTask extends AsyncTask<AppDownloadActivity, Void, String>{
	@Override
	protected String doInBackground(AppDownloadActivity... params) {
		final AppDownloadActivity activity = params[0];
		activity.iErr = 0;
		
		try {
	        EidssDatabase db = new EidssDatabase(activity);
	        String url = db.Options().getServerUrl();
	        int timeout = db.Options().getResponseTimeout();
	        db.close();
			
  	        WebApiClient webClient = new WebApiClient(url, "", "", "", timeout);
  	        activity.versionServer = webClient.Version();
   	        PackageInfo pInfo = activity.getPackageManager().getPackageInfo(activity.getPackageName(), 0);
   	        activity.versionLocal = pInfo.versionName;
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
			activity.mDialog.dismiss();
			activity.runOnUiThread(new Runnable() {
				@Override
	            public void run() {
		   	        if (!activity.versionServer.equalsIgnoreCase(activity.versionLocal)){
		   	        	activity.showDialog(activity.ASKFORDOWNLOAD_DIALOG_ID);
		   	        }
		   	        else{
						if (activity.workMode == EidssBaseActivity.APP_DOWNLOAD_MODE_CHCK){
							activity.setResult(Activity.RESULT_OK);
			   	        	activity.showDialog(activity.NONEWVERSION_DIALOG_ID);
						}
						else if (activity.workMode == EidssBaseActivity.APP_DOWNLOAD_MODE_CASE){
							activity.setResult(Activity.RESULT_OK);
							activity.finish();
						}
						else if (activity.workMode == EidssBaseActivity.APP_DOWNLOAD_MODE_REFS){
							activity.setResult(Activity.RESULT_OK);
			   	        	activity.finish();
						}
		   	        }
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

final class DownloadingTask extends AsyncTask<AppDownloadActivity, Void, String>{
	@Override
	protected String doInBackground(AppDownloadActivity... params) {
		final AppDownloadActivity activity = params[0];
		activity.iErr = 0;
		activity.appContent = null;
		
		try {
	        EidssDatabase db = new EidssDatabase(activity);
	        String url = db.Options().getServerUrl();
	        int timeout = db.Options().getResponseTimeout();
	        db.close();
			
  	        WebApiClient webClient = new WebApiClient(url, "", "", "", timeout);
  	        activity.appContent = webClient.App();
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
			activity.mDialog.dismiss();
			activity.runOnUiThread(new Runnable() {
				@Override
	            public void run() {
					Intent intent = new Intent();
			    	intent.setClass(activity.getApplicationContext(), FileBrowser.class);
			    	int md = FileBrowser.FILE_BROWSER_MODE_SAVE;     	
			    	intent.putExtra("mode", md);
			    	intent.putExtra("mask", "EIDSS.apk");
			    	activity.startActivityForResult(intent, md);
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
