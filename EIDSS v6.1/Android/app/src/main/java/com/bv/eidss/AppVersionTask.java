package com.bv.eidss;


import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.content.pm.PackageInfo;
import android.os.AsyncTask;
import android.support.v4.app.FragmentActivity;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.web.WebApiClient;

import org.apache.http.client.HttpResponseException;
import org.apache.http.conn.ConnectTimeoutException;
import org.apache.http.conn.HttpHostConnectException;

import java.net.SocketTimeoutException;

public class AppVersionTask extends AsyncTask<Void, Void, Integer> {
    public final static int ASKFORDOWNLOAD_DIALOG_ID = 6;
    public final static int ERROR_DIALOG_ID = 7;
    public final static int NEWVERSION_DIALOG_ID = 9;

    private final OnComplete listener;
    private FragmentActivity context;
    private int mWorkMode;

    ProgressDialog progressDialog = null;
    int versionServer = 0;
    int versionLocal = 0;

    public AppVersionTask(FragmentActivity a, OnComplete listener, int workMode) {
        this.listener = listener;
        context = a;
        mWorkMode = workMode;
    }
    // Interface to be implemented by calling activity
    public interface OnComplete {
        public void asyncResponse(int response);
    }

    @Override
    protected void onPreExecute() {
        super.onPreExecute();

        progressDialog = EidssAndroidHelpers.ProgressDialog(context, R.string.CheckForUpdates, new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int which) {
                if (cancel(true)) {
                    progressDialog.dismiss();
                    EidssAndroidHelpers.AlertOkResultDialog.ShowWarning(context.getSupportFragmentManager(), NEWVERSION_DIALOG_ID, R.string.CheckingAborted);
                }
            }
        });
    }

    @Override
    protected Integer doInBackground(Void... params) {
        Integer iErr = 0;
        String errDetails;

        try {
            EidssDatabase db = new EidssDatabase(context);
            String url = db.Options().getServerUrl();
            int timeout = db.Options().getResponseTimeout();
            db.close();

            WebApiClient webClient = new WebApiClient(url, "", "", "", timeout);
            versionServer = Integer.parseInt(webClient.Version());
            PackageInfo pInfo = context.getPackageManager().getPackageInfo(context.getPackageName(), 0);
            versionLocal = pInfo.versionCode;
        }
        catch(HttpResponseException e){
            if (e.getStatusCode() == 401){
                iErr = R.string.LoginFailed;
                errDetails = e.getMessage();
            }
            else if (e.getStatusCode() == 403){
                iErr = R.string.AccessFailed;
            }
            else{
                iErr = R.string.ConnectionFailed;
            }
        }
        catch(HttpHostConnectException e){
            iErr = R.string.ConnectionErr;
        }
        catch(SocketTimeoutException e){
            iErr = R.string.NetworkTimeout;
        }
        catch(ConnectTimeoutException e){
            iErr = R.string.ConnectionFailed;
        }
        catch(Exception e){
            iErr = R.string.GeneralError;
        }

        return iErr;
    }

    @Override
    protected void onPostExecute(Integer result) {
        super.onPostExecute(result);

        if (progressDialog != null && progressDialog.isShowing()) {
            progressDialog.dismiss();
        }

        if (result == 0) {
            if (versionServer > versionLocal){
                EidssAndroidHelpers.AlertOkResultDialog.ShowQuestion(context.getSupportFragmentManager(), ASKFORDOWNLOAD_DIALOG_ID, R.string.NewVersionDownloadConfirm);
                result = 1;
            }
            else{
                if (mWorkMode == context.getResources().getInteger(R.integer.APP_DOWNLOAD_MODE_CHCK)){
                    EidssAndroidHelpers.AlertOkResultDialog.ShowOk(context.getSupportFragmentManager(), NEWVERSION_DIALOG_ID, R.string.NoNewVersion);
                }
            }
        } else {
            EidssAndroidHelpers.AlertOkResultDialog.ShowWarning(context.getSupportFragmentManager(), ERROR_DIALOG_ID, result);
        }

        listener.asyncResponse(result);
    }

    protected void onCancelled(Integer result) {
        if (progressDialog != null && progressDialog.isShowing()) {
            progressDialog.dismiss();
        }
    }}
