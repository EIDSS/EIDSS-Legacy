package com.bv.eidss;


import android.app.Activity;
import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.NavUtils;
import android.support.v7.app.ActionBar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.LayoutInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.FFReferences;
import com.bv.eidss.model.Options;
import com.bv.eidss.web.VectorBaseReferenceRaw;
import com.bv.eidss.web.VectorBaseReferenceTranslationRaw;
import com.bv.eidss.web.VectorGisBaseReferenceRaw;
import com.bv.eidss.web.VectorGisBaseReferenceTranslationRaw;
import com.bv.eidss.web.VectorInvisibleFieldsRaw;
import com.bv.eidss.web.VectorMandatoryFieldsRaw;
import com.bv.eidss.web.WebApiClient;

import org.apache.http.client.HttpResponseException;
import org.apache.http.conn.ConnectTimeoutException;
import org.apache.http.conn.HttpHostConnectException;
import org.json.JSONException;

import java.net.SocketTimeoutException;
import java.util.Date;
import java.util.Formatter;


public class LoadReferencesFragment extends Fragment
        implements EidssAndroidHelpers.AsyncResponse {

    public EditText orgEdit;
    public EditText usrEdit;
    public EditText pwdEdit;
    public int iErr = 0;
    public String errDetails;
    public String errFunction;

    public String org;
    public String usr;
    public String pwd;

    private LoadReferenceTask task;
    private ProgressDialog progressDialog;
    private boolean isTaskRunning = false;

    public static LoadReferencesFragment newInstance() {
        return new LoadReferencesFragment();
    }

     public LoadReferencesFragment() {
        // Required empty public constructor
    }


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setRetainInstance(true);//to restore dialogs after change orientation
        setHasOptionsMenu(true);
    }

    @Override
    public void onActivityCreated(Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);
        // If we are returning here from a screen orientation
        // and the AsyncTask is still working, re-create and display the
        // progress dialog.
        if (isTaskRunning) {
            showProgressDialog();
        }
    }

    @Override
    public void onDetach() {
        // All dialogs should be closed before leaving the activity in order to avoid
        // the: Activity has leaked window com.android.internal.policy... exception
        if (progressDialog != null && progressDialog.isShowing()) {
            progressDialog.dismiss();
        }
        super.onDetach();
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View v = inflater.inflate(R.layout.load_references_layout, container, false);

        Toolbar toolbar = (Toolbar) v.findViewById(R.id.toolbar);
        ((AppCompatActivity)getActivity()).setSupportActionBar(toolbar);
        final ActionBar ab = ((AppCompatActivity)getActivity()).getSupportActionBar();
        if(ab != null)
            ab.setDisplayHomeAsUpEnabled(true);

        orgEdit = ((EditText)v.findViewById(R.id.LoginOrganization));
        usrEdit = ((EditText)v.findViewById(R.id.LoginName));
        pwdEdit = ((EditText)v.findViewById(R.id.LoginPassword));

        String org = EidssDatabase.GetOptions().getLoginOrganization();
        String usr = EidssDatabase.GetOptions().getLoginUsername();
        orgEdit.setText(org);
        usrEdit.setText(usr);

        v.findViewById(R.id.OkButton).setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                AppVersionTask getAppVer = new AppVersionTask(getActivity(), new AppVersionTask.OnComplete() {
                     @Override
                    public void asyncResponse(int result) {
                         if(result == 0) StartLoadReferences();
                    }
                }, getResources().getInteger(R.integer.APP_DOWNLOAD_MODE_REFS));
                getAppVer.execute();
            }
        });

        pwdEdit.requestFocus();
        return v;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {

        switch (item.getItemId()) {
            case android.R.id.home:
                Intent intent = NavUtils.getParentActivityIntent(getActivity());
                intent.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                startActivity(intent);
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }

    public void StartLoadReferences()
    {
        if (!isTaskRunning) {
            task = new LoadReferenceTask(this);
            task.execute();
        }
    }


    private void showProgressDialog()
    {
        progressDialog = EidssAndroidHelpers.ProgressDialog(getActivity(), R.string.WaitLoading, new DialogInterface.OnClickListener(){
            public void onClick(DialogInterface dialog, int which) {
                if (task.cancel(true)){
                    progressDialog.dismiss();
                    isTaskRunning = false;
                    EidssAndroidHelpers.AlertOkResultDialog.ShowOk(getActivity().getSupportFragmentManager(), ((LoadReferencesActivity)getActivity()).FINISHED_DIALOG_ID, R.string.GetReferencesAborted);
                }
            }});

    }


    @Override
    public void onTaskStarted() {
        isTaskRunning = true;
        showProgressDialog();
    }

    @Override
    public void onTaskFinished(String result) {
        if (progressDialog != null) {
            progressDialog.dismiss();
        }
        isTaskRunning = false;

        if (iErr == 0) {
            EidssAndroidHelpers.AlertOkResultDialog.ShowOk(getActivity().getSupportFragmentManager(), ((LoadReferencesActivity)getActivity()).FINISHED_DIALOG_ID, R.string.ReferencesUpdated);
        } else if(iErr == R.string.ResponseFailed) {
            EidssAndroidHelpers.AlertOkDialog.Show(getActivity().getSupportFragmentManager(),
                    (new Formatter()).format(getActivity().getResources().getString(R.string.ResponseFailed), errFunction).toString());
        } else {
            if (errDetails != null && errDetails.length() > 0){
                EidssAndroidHelpers.AlertOkDialog.Warning(getActivity().getSupportFragmentManager(), errDetails);
            } else {
                EidssAndroidHelpers.AlertOkDialog.Warning(getActivity().getSupportFragmentManager(), iErr);
            }
        }
    }

    final private class LoadReferenceTask extends AsyncTask<Void, Void, String> {
        private final EidssAndroidHelpers.AsyncResponse listener;

        public LoadReferenceTask(EidssAndroidHelpers.AsyncResponse listener) {
            this.listener = listener;
        }
        @Override
        protected void onPreExecute() {
            super.onPreExecute();

            org = orgEdit.getText().toString();
            usr = usrEdit.getText().toString();
            pwd = pwdEdit.getText().toString();

            listener.onTaskStarted();
        }

        @Override
        protected String doInBackground(Void... params) {
            iErr = 0;

            VectorMandatoryFieldsRaw mandatory_fields;
            VectorInvisibleFieldsRaw invisible_fields;
            VectorBaseReferenceRaw refs;
            VectorBaseReferenceTranslationRaw refs_trans;
            VectorGisBaseReferenceRaw gis_refs;
            VectorGisBaseReferenceTranslationRaw gis_refs_trans;
            try {
                String url = EidssDatabase.GetOptions().getServerUrl();
                int timeout = EidssDatabase.GetOptions().getResponseTimeout();
                EidssDatabase.ClearPreloadedReferencies();

                WebApiClient webClient = new WebApiClient(url, org, usr, pwd, timeout);
                errFunction = "LoadFFReferences()";
                FFReferences ffRefs = webClient.LoadFFReferences();
                errFunction = "LoadMandatoryFields()";
                mandatory_fields = webClient.LoadMandatoryFields();
                errFunction = "LoadInvisibleFields()";
                invisible_fields = webClient.LoadInvisibleFields();



                errFunction = "LoadReferences()";
                refs = webClient.LoadReferences(ffRefs.referenceTypes);
                errFunction = "LoadReferenceTranslations()";
                refs_trans = webClient.LoadReferenceTranslations(refs.brTypes);

                errFunction = "LoadGisReferences()";
                gis_refs = webClient.LoadGisReferences();
                errFunction = "LoadGisReferenceTranslations()";
                gis_refs_trans = webClient.LoadGisReferenceTranslations();
                errFunction = "";

                EidssDatabase db = new EidssDatabase(getActivity());
                if (db.LoadReferences(mandatory_fields, invisible_fields, refs, refs_trans, gis_refs, gis_refs_trans, ffRefs)){
                    Options opt = db.Options();
                    opt.setLoginOrganization(org);
                    opt.setLoginUsername(usr);
                    opt.setLastRefUpdt(new Date());
                    if(opt.getRegionDefDef() == 0) {
                        errFunction = "LoadOptions()";
                        Options server_opt = webClient.LoadOptions();
                        errFunction = "";

                        opt.setRegionDefDef(server_opt.getRegionDefDef());
                        opt.setRegionDef(server_opt.getRegionDefDef());
                        opt.setRayonDefDef(server_opt.getRayonDefDef());
                        opt.setRayonDef(server_opt.getRayonDefDef());
                    }
                    db.OptionsUpdate(opt);
                }
                else
                    iErr = R.string.ErrorRefsLoaded;
                db.close();
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
                    iErr = R.string.ResponseFailed;
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
            catch(JSONException e){
                iErr = R.string.ResponseFailed;
                errFunction += ": " + e.getLocalizedMessage();
            }
            catch(Exception e){
                iErr = R.string.GeneralError;
            }

            return "";
        }

        @Override
        protected void onPostExecute(String result) {
            super.onPostExecute(result);

            listener.onTaskFinished(result);
        }
    }
}
