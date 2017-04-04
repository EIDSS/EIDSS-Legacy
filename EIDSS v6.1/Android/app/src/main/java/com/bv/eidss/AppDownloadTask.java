package com.bv.eidss;


import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.AsyncTask;
import android.support.v4.app.FragmentActivity;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.web.WebApiClient;

import org.apache.http.client.HttpResponseException;
import org.apache.http.conn.ConnectTimeoutException;
import org.apache.http.conn.HttpHostConnectException;

import java.net.SocketTimeoutException;

public class AppDownloadTask extends AsyncTask<Void, Void, Integer> {
    public final static int NEWVERSION_DIALOG_ID = 9;

    private final OnComplete listener;
    private FragmentActivity context;

    ProgressDialog progressDialog = null;
    byte[] appContent = null;

    public AppDownloadTask(FragmentActivity a, OnComplete listener) {
        this.listener = listener;
        context = a;
    }

    // Interface to be implemented by calling activity
    public interface OnComplete {
        public void asyncResponse(byte[] response);
    }

    @Override
    protected void onPreExecute() {
        super.onPreExecute();

        progressDialog = EidssAndroidHelpers.ProgressDialog(context, R.string.WaitDownloading, new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int which) {
                if (cancel(true)) {
                    progressDialog.dismiss();
                    EidssAndroidHelpers.AlertOkResultDialog.ShowWarning(context.getSupportFragmentManager(), NEWVERSION_DIALOG_ID, R.string.DownloadingAborted);
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
            appContent = webClient.App();
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
                iErr = R.string.ServerError;
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
            Intent intent = new Intent(context, FileBrowser.class);
            int md = context.getResources().getInteger(R.integer.FILE_BROWSER_MODE_SAVE);
            intent.putExtra(context.getResources().getString(R.string.EXTRA_ID_MODE), md);
            intent.putExtra("mask", "EIDSS.apk");
            context.startActivityForResult(intent, md);
        } else {
            EidssAndroidHelpers.AlertOkDialog.Warning(context.getSupportFragmentManager(), result);
        }

        listener.asyncResponse(appContent);
    }

    protected void onCancelled(Integer result) {
        if (progressDialog != null && progressDialog.isShowing()) {
            progressDialog.dismiss();
        }
    }
}
