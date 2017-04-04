package com.bv.eidss;


import android.app.Activity;
import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v7.app.ActionBarActivity;
import android.support.v7.widget.Toolbar;
import android.view.LayoutInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.ASSession;
import com.bv.eidss.model.CaseStatus;
import com.bv.eidss.model.HumanCase;
import com.bv.eidss.model.Options;
import com.bv.eidss.model.VetCase;
import com.bv.eidss.web.ASSessionInfoOut;
import com.bv.eidss.web.HumanCaseInfoOut;
import com.bv.eidss.web.VetCaseInfoOut;
import com.bv.eidss.web.WebApiClient;

import org.apache.http.client.HttpResponseException;
import org.apache.http.conn.ConnectTimeoutException;
import org.apache.http.conn.HttpHostConnectException;

import java.net.SocketTimeoutException;
import java.util.Date;
import java.util.Formatter;
import java.util.List;
import java.util.Vector;

public class SynchronizeCasesFragment extends Fragment
        implements EidssAndroidHelpers.AsyncResponse,
                   EidssAndroidHelpers.AsyncResponseH,
                   EidssAndroidHelpers.AsyncResponseV,
                   EidssAndroidHelpers.AsyncResponseA
                   {
    private static final String ARG_PARAM1 = "id";
    private static final String ARG_PARAM2 = "type";
    private long lId = 0;
    private int iType = R.integer.SYNCHRONIZATION_TYPE_ALL;

    public String org;
    public String usr;
    public String pwd;

    public EditText orgEdit;
    public EditText usrEdit;
    public EditText pwdEdit;
    public String strErrMessage = null;
    public int iErr = 0;
    public int iAdded = 0;
    public int iUpdated = 0;
    public int iFailed = 0;
    private AsyncTask task;
    private ProgressDialog progressDialog;
    private boolean isTaskRunning = false;

    public static SynchronizeCasesFragment newInstance(long id, int type) {
        SynchronizeCasesFragment fragment = new SynchronizeCasesFragment();
        Bundle args = new Bundle();
        args.putLong(ARG_PARAM1, id);
        args.putInt(ARG_PARAM2, type);
        fragment.setArguments(args);

        return fragment;
    }

    public SynchronizeCasesFragment() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setRetainInstance(true);//to restore dialogs after change orientation
        setHasOptionsMenu(true);
        if (getArguments() != null) {
            lId = getArguments().getLong(ARG_PARAM1);
            iType = getArguments().getInt(ARG_PARAM2);
        }
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
        View v = inflater.inflate(R.layout.synchronize_layout, container, false);

        if(iType == R.integer.SYNCHRONIZATION_TYPE_ALL)
            getActivity().setTitle(R.string.SynchronizeAllCases);
        else if(iType == R.integer.SYNCHRONIZATION_TYPE_HUMAN)
            getActivity().setTitle(R.string.SynchronizeHumanCases);
        else if(iType == R.integer.SYNCHRONIZATION_TYPE_VET)
            getActivity().setTitle(R.string.SynchronizeVetCases);
        else if(iType == R.integer.SYNCHRONIZATION_TYPE_ASSESSION)
            getActivity().setTitle(R.string.SynchronizeAsSession);

        Toolbar toolbar = (Toolbar) v.findViewById(R.id.toolbar);
        if(toolbar != null)
            ((ActionBarActivity)getActivity()).setSupportActionBar(toolbar);
        ((ActionBarActivity)getActivity()).getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        orgEdit = ((EditText)v.findViewById(R.id.LoginOrganization));
        usrEdit = ((EditText)v.findViewById(R.id.LoginName));
        pwdEdit = ((EditText)v.findViewById(R.id.LoginPassword));

        EidssDatabase db = new EidssDatabase(getActivity());
        String org = db.Options().getLoginOrganization();
        String usr = db.Options().getLoginUsername();
        orgEdit.setText(org);
        usrEdit.setText(usr);
        db.close();

        v.findViewById(R.id.OkButton).setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                AppVersionTask getAppVer = new AppVersionTask(getActivity(), new AppVersionTask.OnComplete() {
                    @Override
                    public void asyncResponse(int result) {
                        if(result == 0) StartSynchronizeCases();
                    }
                }, getResources().getInteger(R.integer.APP_DOWNLOAD_MODE_CASE));
                getAppVer.execute();
            }
        });

        pwdEdit.requestFocus();
        return v;
    }


    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            // Respond to the action bar's Up/Home button
            case android.R.id.home:
                getActivity().finish();
        }
        return super.onOptionsItemSelected(item);
    }

    public void StartSynchronizeCases()
    {
        if (!isTaskRunning) {
            if(iType == R.integer.SYNCHRONIZATION_TYPE_ALL) {
                task = new SynchronizeAllCasesTask(this);
                ((SynchronizeAllCasesTask)task).execute();
            }else if(iType == R.integer.SYNCHRONIZATION_TYPE_HUMAN) {
                task = new SynchronizeHumanCasesTask(this);
                ((SynchronizeHumanCasesTask)task).execute();
            }else if(iType == R.integer.SYNCHRONIZATION_TYPE_VET) {
                task = new SynchronizeVetCasesTask(this);
                ((SynchronizeVetCasesTask)task).execute();
            }else if(iType == R.integer.SYNCHRONIZATION_TYPE_ASSESSION) {
                task = new SynchronizeAsSessionTask(this);
                ((SynchronizeAsSessionTask)task).execute();
            }
        }
    }

    private void showProgressDialog()
    {
        progressDialog = EidssAndroidHelpers.ProgressDialog(getActivity(), R.string.WaitSynchronizing, new DialogInterface.OnClickListener(){
            public void onClick(DialogInterface dialog, int which) {
                if (task.cancel(true)){
                    progressDialog.dismiss();
                    isTaskRunning = false;
                    EidssAndroidHelpers.AlertOkResultDialog.ShowOk(getActivity().getSupportFragmentManager(), ((SynchronizeCasesActivity)getActivity()).FINISHED_DIALOG_ID, R.string.SynchronizationAborted);
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
            EidssAndroidHelpers.AlertOkResultDialog.ShowOk(getActivity().getSupportFragmentManager(), ((SynchronizeCasesActivity)getActivity()).FINISHED_DIALOG_ID,
                    (new Formatter()).format(getActivity().getResources().getString(R.string.SynResult), iAdded, iUpdated, iFailed).toString());
        } else {
            getActivity().setResult(Activity.RESULT_CANCELED);

            if(strErrMessage != null)
                EidssAndroidHelpers.AlertOkResultDialog.ShowOk(getActivity().getSupportFragmentManager(), ((SynchronizeCasesActivity)getActivity()).FINISHED_DIALOG_ID, strErrMessage);
            else
                EidssAndroidHelpers.AlertOkDialog.Warning(getActivity().getSupportFragmentManager(), iErr);
        }
    }

    @Override
    public void onTaskFinished(HumanCase result) {
        if (progressDialog != null) {
            progressDialog.dismiss();
        }
        isTaskRunning = false;

        if (iErr == 0) {
            Intent intent = new Intent();
            intent.putExtra("hc", result);
            getActivity().setResult(Activity.RESULT_OK, intent);

            EidssAndroidHelpers.AlertOkResultDialog.ShowOk(getActivity().getSupportFragmentManager(), ((SynchronizeCasesActivity)getActivity()).FINISHED_DIALOG_ID,
                    (new Formatter()).format(getActivity().getResources().getString(R.string.SynResult), iAdded, iUpdated, iFailed).toString());
        } else {
            getActivity().setResult(Activity.RESULT_CANCELED);

            if(strErrMessage != null)
                EidssAndroidHelpers.AlertOkResultDialog.ShowOk(getActivity().getSupportFragmentManager(), ((SynchronizeCasesActivity)getActivity()).FINISHED_DIALOG_ID, strErrMessage);
            else
                EidssAndroidHelpers.AlertOkDialog.Warning(getActivity().getSupportFragmentManager(), iErr);
        }
    }

    @Override
    public void onTaskFinished(VetCase result) {
        if (progressDialog != null) {
            progressDialog.dismiss();
        }
        isTaskRunning = false;

        if (iErr == 0) {
            Intent intent = new Intent();
            intent.putExtra("vc", result);
            getActivity().setResult(Activity.RESULT_OK, intent);

            EidssAndroidHelpers.AlertOkResultDialog.ShowOk(getActivity().getSupportFragmentManager(), ((SynchronizeCasesActivity)getActivity()).FINISHED_DIALOG_ID,
                    (new Formatter()).format(getActivity().getResources().getString(R.string.SynResult), iAdded, iUpdated, iFailed).toString());
        } else {
            getActivity().setResult(Activity.RESULT_CANCELED);

            if(strErrMessage != null)
                EidssAndroidHelpers.AlertOkResultDialog.ShowOk(getActivity().getSupportFragmentManager(), ((SynchronizeCasesActivity)getActivity()).FINISHED_DIALOG_ID, strErrMessage);
            else
                EidssAndroidHelpers.AlertOkDialog.Warning(getActivity().getSupportFragmentManager(), iErr);
        }
    }

    @Override
    public void onTaskFinished(ASSession result) {
       if (progressDialog != null) {
           progressDialog.dismiss();
       }
       isTaskRunning = false;

       if (iErr == 0) {
           Intent intent = new Intent();
           intent.putExtra("as", result);
           getActivity().setResult(Activity.RESULT_OK, intent);

           EidssAndroidHelpers.AlertOkResultDialog.ShowOk(getActivity().getSupportFragmentManager(), ((SynchronizeCasesActivity)getActivity()).FINISHED_DIALOG_ID,
                   (new Formatter()).format(getActivity().getResources().getString(R.string.SynResult), iAdded, iUpdated, iFailed).toString());
       } else {
           getActivity().setResult(Activity.RESULT_CANCELED);

           if(strErrMessage != null)
               EidssAndroidHelpers.AlertOkResultDialog.ShowOk(getActivity().getSupportFragmentManager(), ((SynchronizeCasesActivity)getActivity()).FINISHED_DIALOG_ID, strErrMessage);
           else
               EidssAndroidHelpers.AlertOkDialog.Warning(getActivity().getSupportFragmentManager(), iErr);
       }
    }



    final private class SynchronizeAllCasesTask extends AsyncTask<Void, Void, String> {
        private final EidssAndroidHelpers.AsyncResponse listener;

        public SynchronizeAllCasesTask(EidssAndroidHelpers.AsyncResponse listener) {
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
            strErrMessage = null;

            /*
            String org = orgEdit.getText().toString();
            String usr = usrEdit.getText().toString();
            String pwd = pwdEdit.getText().toString();
            */

            Vector<HumanCaseInfoOut> hcs_out = new Vector<>();
            List<HumanCase> hcs = null;
            HumanCase hc;
            Vector<VetCaseInfoOut> vcs_out = new Vector<>();
            List<VetCase> vcs = null;
            VetCase vc;
            Vector<ASSessionInfoOut> ass_out = new Vector<>();
            List<ASSession> ass = null;
            ASSession as;

            try {
                EidssDatabase db = new EidssDatabase(getActivity());
                String url = db.Options().getServerUrl();
                int timeout = db.Options().getResponseTimeout();
                hcs = db.HumanCaseSelect(0L);//long means select with child lists
                vcs = db.VetCaseSelect(0L);//long means select with child lists
                ass = db.ASSessionSelect(0L);//long means select with child lists
                db.close();

                // get human cases from service
                for(int i = 0; i < hcs.size(); i++){
                    hc = hcs.get(i);
                    if (hc.getStatus() == CaseStatus.NEW || hc.getStatus() == CaseStatus.CHANGED || hc.getStatus() == CaseStatus.UNLOADED){
                        WebApiClient webClient = new WebApiClient(url, org, usr, pwd, timeout);
                        HumanCaseInfoOut out = webClient.HumanCaseSave(hc);
                        hcs_out.add(out);
                    }
                }

                // get veterinary cases from service
                for(int i = 0; i < vcs.size(); i++){
                    vc = vcs.get(i);
                    if (vc.getStatus() == CaseStatus.NEW || vc.getStatus() == CaseStatus.CHANGED || vc.getStatus() == CaseStatus.UNLOADED){
                        WebApiClient webClient = new WebApiClient(url, org, usr, pwd, timeout);
                        VetCaseInfoOut out = webClient.VetCaseSave(vc);
                        vcs_out.add(out);
                    }
                }

                for(int i = 0; i < ass.size(); i++){
                    as = ass.get(i);
                    if (as.getStatus() == CaseStatus.NEW || as.getStatus() == CaseStatus.CHANGED || as.getStatus() == CaseStatus.UNLOADED){
                        WebApiClient webClient = new WebApiClient(url, org, usr, pwd, timeout);
                        ASSessionInfoOut out = webClient.ASSessionSave(as);
                        ass_out.add(out);
                    }
                }

            }
            catch(HttpResponseException e){
                if (e.getStatusCode() == 401){
                    String errMessage = e.getMessage();
                    iErr = R.string.LoginFailed;
                    if (errMessage != null && !errMessage.isEmpty())
                        strErrMessage = errMessage;
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

            if (iErr == 0){
                EidssDatabase db = new EidssDatabase(getActivity());

                iAdded = 0;
                iUpdated = 0;
                iFailed = 0;

                // update human cases in database
                for(int i = 0; i < hcs_out.size(); i++){
                    HumanCaseInfoOut ci = hcs_out.get(i);
                    for(int j = 0; j < hcs.size(); j++){
                        hc = hcs.get(j);
                        if (ci.getOfflineCaseID().compareTo(hc.getOfflineCaseID()) == 0) {
                            if (ci.isFailed){
                                iFailed++;
                                hc.setLastSynError(ci.lastErrorDescription);
                                db.HumanCaseUpdate(hc);
                            }
                            else if (ci.isCreated || ci.isUpdated)
                            {
                                if (ci.isCreated) iAdded++;
                                if (ci.isUpdated) iUpdated++;
                                Boolean isNeedToReloadTemplates = ci.getFinalDiagnosis() != hc.getFinalDiagnosis();
                                hc.SetFromOut(ci);
                                hc.setLastSynError(ci.lastErrorDescription);
                                hc.setStatusSyn();
                                db.HumanCaseUpdate(hc);
                                if (isNeedToReloadTemplates){
                                    long fd = hc.getFinalDiagnosis();
                                    hc.FFModelCS.LoadTemplate(db, fd);
                                    hc.FFModelEpi.LoadTemplate(db, fd);
                                }
                            }
                        }
                    }
                }

                // update veterinary cases in database
                for(int i = 0; i < vcs_out.size(); i++){
                    VetCaseInfoOut ci = vcs_out.get(i);
                    for(int j = 0; j < vcs.size(); j++){
                        vc = vcs.get(j);
                        if (ci.getOfflineCaseID().compareTo(vc.getOfflineCaseID()) == 0) {
                            if (ci.isFailed){
                                iFailed++;
                                vc.setLastSynError(ci.lastErrorDescription);
                                db.VetCaseUpdate(vc);
                            }
                            else if (ci.isCreated)
                            {
                                iAdded++;
                            }
                            else if (ci.isUpdated){
                                iUpdated++;

                            }
                            if(ci.isCreated || ci.isUpdated){
                                vc.SetFromOut(ci);
                                vc.setLastSynError(ci.lastErrorDescription);
                                vc.setStatusSyn();
                                db.VetCaseUpdate(vc);
                                //if (isNeedToReloadTemplates){ //TODO are we need it here?
                                long d = vc.getTentativeDiagnosis();//actually, I don't know what diagnosis to use
                                vc.FFFarmEpi.LoadTemplate(db, d);
                                if (vc.IsLivestockCase()) vc.FFControlMeasures.LoadTemplate(db, 0); //we don't need the diagnosis here
                                //}
                            }
                        }
                    }
                }

                // update assessions in database
                for(int i = 0; i < ass_out.size(); i++){
                    ASSessionInfoOut ci = ass_out.get(i);
                    for(int j = 0; j < ass.size(); j++){
                        as = ass.get(j);
                        if (ci.getOfflineCaseID().compareTo(as.getOfflineCaseID()) == 0) {
                            if (ci.isFailed){
                                iFailed++;
                                as.setLastSynError(ci.lastErrorDescription);
                                db.ASSessionUpdate(as);
                                strErrMessage = ci.lastErrorDescription;
                                if(lId > 0)
                                    iErr = 1;
                            }
                            else if(ci.isCreated || ci.isUpdated){
                                if (ci.isCreated)
                                    iAdded++;
                                else if (ci.isUpdated)
                                    iUpdated++;
                                as.SetFromOut(ci);
                                as.setLastSynError(ci.lastErrorDescription);
                                as.setStatusSyn();
                                db.ASSessionUpdate(as);
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
             }
            return "";
        }

        @Override
        protected void onPostExecute(String result) {
            super.onPostExecute(result);

            listener.onTaskFinished(result);
        }
    }

    final private class SynchronizeHumanCasesTask extends AsyncTask<Void, Void, HumanCase> {
        private final EidssAndroidHelpers.AsyncResponseH listener;

        public SynchronizeHumanCasesTask(EidssAndroidHelpers.AsyncResponseH listener) {
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

        private String org;
        private String usr;
        private String pwd;

        @Override
        protected HumanCase doInBackground(Void... params) {
            iErr = 0;
            strErrMessage = null;

            /*
            String org = orgEdit.getText().toString();
            String usr = usrEdit.getText().toString();
            String pwd = pwdEdit.getText().toString();
            */

            Vector<HumanCaseInfoOut> hcs_out = new Vector<>();
            List<HumanCase> hcs = null;
            HumanCase c = null;
            try {
                EidssDatabase db = new EidssDatabase(getActivity());
                String url = db.Options().getServerUrl();
                int timeout = db.Options().getResponseTimeout();
                hcs = db.HumanCaseSelect(lId);
                db.close();

                // get human cases from service
                for(int i = 0; i < hcs.size(); i++){
                    c = hcs.get(i);
                    if (c.getStatus() == CaseStatus.NEW || c.getStatus() == CaseStatus.CHANGED || c.getStatus() == CaseStatus.UNLOADED){
                        WebApiClient webClient = new WebApiClient(url, org, usr, pwd, timeout);
                        HumanCaseInfoOut out = webClient.HumanCaseSave(c);
                        hcs_out.add(out);
                    }
                }

            }
            catch(HttpResponseException e){
                if (e.getStatusCode() == 401){
                    String errMessage = e.getMessage();
                    iErr = R.string.LoginFailed;
                    if (errMessage != null && !errMessage.isEmpty())
                        strErrMessage = errMessage;
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

            if (iErr == 0){
                EidssDatabase db = new EidssDatabase(getActivity());

                iAdded = 0;
                iUpdated = 0;
                iFailed = 0;

                // update human cases in database
                for(int i = 0; i < hcs_out.size(); i++){
                    HumanCaseInfoOut ci = hcs_out.get(i);
                    for(int j = 0; j < hcs.size(); j++){
                        c = hcs.get(j);
                        if (ci.getOfflineCaseID().compareTo(c.getOfflineCaseID()) == 0) {
                            if (ci.isFailed){
                                iFailed++;
                                c.setLastSynError(ci.lastErrorDescription);
                                db.HumanCaseUpdate(c);
                                strErrMessage = ci.lastErrorDescription;
                                if(lId > 0)
                                    iErr = 1;
                            }
                            else if (ci.isCreated || ci.isUpdated)
                            {
                                if (ci.isCreated) iAdded++;
                                if (ci.isUpdated) iUpdated++;
                                Boolean isNeedToReloadTemplates = (lId > 0) && (ci.getFinalDiagnosis() != c.getFinalDiagnosis());
                                c.SetFromOut(ci);
                                c.setLastSynError(ci.lastErrorDescription);
                                c.setStatusSyn();
                                db.HumanCaseUpdate(c);
                                if (isNeedToReloadTemplates){
                                    long fd = c.getFinalDiagnosis();
                                    c.FFModelCS.LoadTemplate(db, fd);
                                    c.FFModelEpi.LoadTemplate(db, fd);
                                }
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
            }
            return c;
        }

        @Override
        protected void onPostExecute(HumanCase result) {
            super.onPostExecute(result);

            listener.onTaskFinished(result);
        }
    }

    final private class SynchronizeVetCasesTask extends AsyncTask<Void, Void, VetCase> {
        private final EidssAndroidHelpers.AsyncResponseV listener;

        public SynchronizeVetCasesTask(EidssAndroidHelpers.AsyncResponseV listener) {
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
        protected VetCase doInBackground(Void... params) {
            iErr = 0;
            strErrMessage = null;

            /*
            String org = orgEdit.getText().toString();
            String usr = usrEdit.getText().toString();
            String pwd = pwdEdit.getText().toString();
            */

            Vector<VetCaseInfoOut> vcs_out = new Vector<>();
            List<VetCase> vcs = null;
            VetCase vc = null;
            try {
                EidssDatabase db = new EidssDatabase(getActivity());
                String url = db.Options().getServerUrl();
                int timeout = db.Options().getResponseTimeout();
                vcs = db.VetCaseSelect(lId);
                db.close();

                // get vet cases from service
                for(int i = 0; i < vcs.size(); i++){
                    vc = vcs.get(i);
                    if (vc.getStatus() == CaseStatus.NEW || vc.getStatus() == CaseStatus.CHANGED || vc.getStatus() == CaseStatus.UNLOADED){
                        WebApiClient webClient = new WebApiClient(url, org, usr, pwd, timeout);
                        VetCaseInfoOut out = webClient.VetCaseSave(vc);
                        vcs_out.add(out);
                    }
                }

            }
            catch(HttpResponseException e){
                if (e.getStatusCode() == 401){
                    String errMessage = e.getMessage();
                    iErr = R.string.LoginFailed;
                    if (errMessage != null && !errMessage.isEmpty())
                        strErrMessage = errMessage;
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

            if (iErr == 0){
                EidssDatabase db = new EidssDatabase(getActivity());

                iAdded = 0;
                iUpdated = 0;
                iFailed = 0;

                // update vet cases in database
                for(int i = 0; i < vcs_out.size(); i++){
                    VetCaseInfoOut ci = vcs_out.get(i);
                    for(int j = 0; j < vcs.size(); j++){
                        vc = vcs.get(j);
                        if (ci.getOfflineCaseID().compareTo(vc.getOfflineCaseID()) == 0) {
                            if (ci.isFailed){
                                iFailed++;
                                vc.setLastSynError(ci.lastErrorDescription);
                                db.VetCaseUpdate(vc);
                                strErrMessage = ci.lastErrorDescription;
                                if(lId > 0)
                                    iErr = 1;
                            }
                            else if(ci.isCreated || ci.isUpdated){
                                if (ci.isCreated)
                                    iAdded++;
                                else if (ci.isUpdated)
                                    iUpdated++;
                                vc.SetFromOut(ci);
                                vc.setLastSynError(ci.lastErrorDescription);
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
            }
            return vc;
        }

        @Override
        protected void onPostExecute(VetCase result) {
            super.onPostExecute(result);

            listener.onTaskFinished(result);
        }
    }


    final private class SynchronizeAsSessionTask extends AsyncTask<Void, Void, ASSession> {
        private final EidssAndroidHelpers.AsyncResponseA listener;

        public SynchronizeAsSessionTask(EidssAndroidHelpers.AsyncResponseA listener) {
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
        protected ASSession doInBackground(Void... params) {
            iErr = 0;
            strErrMessage = null;

            /*
            String org = orgEdit.getText().toString();
            String usr = usrEdit.getText().toString();
            String pwd = pwdEdit.getText().toString();
            */

            Vector<ASSessionInfoOut> ass_out = new Vector<>();
            List<ASSession> ass = null;
            ASSession as = null;
            try {
                EidssDatabase db = new EidssDatabase(getActivity());
                String url = db.Options().getServerUrl();
                int timeout = db.Options().getResponseTimeout();
                ass = db.ASSessionSelect(lId);
                db.close();

                for(int i = 0; i < ass.size(); i++){
                    as = ass.get(i);
                    if (as.getStatus() == CaseStatus.NEW || as.getStatus() == CaseStatus.CHANGED || as.getStatus() == CaseStatus.UNLOADED){
                        WebApiClient webClient = new WebApiClient(url, org, usr, pwd, timeout);
                        ASSessionInfoOut out = webClient.ASSessionSave(as);
                        ass_out.add(out);
                    }
                }

            }
            catch(HttpResponseException e){
                if (e.getStatusCode() == 401){
                    String errMessage = e.getMessage();
                    iErr = R.string.LoginFailed;
                    if (errMessage != null && !errMessage.isEmpty())
                        strErrMessage = errMessage;
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

            if (iErr == 0){
                EidssDatabase db = new EidssDatabase(getActivity());

                iAdded = 0;
                iUpdated = 0;
                iFailed = 0;

                // update assessions in database
                for(int i = 0; i < ass_out.size(); i++){
                    ASSessionInfoOut ci = ass_out.get(i);
                    for(int j = 0; j < ass.size(); j++){
                        as = ass.get(j);
                        if (ci.getOfflineCaseID().compareTo(as.getOfflineCaseID()) == 0) {
                            if (ci.isFailed){
                                iFailed++;
                                as.setLastSynError(ci.lastErrorDescription);
                                db.ASSessionUpdate(as);
                                strErrMessage = ci.lastErrorDescription;
                                if(lId > 0)
                                    iErr = 1;
                            }
                            else if(ci.isCreated || ci.isUpdated){
                                if (ci.isCreated)
                                    iAdded++;
                                else if (ci.isUpdated)
                                    iUpdated++;
                                as.SetFromOut(ci);
                                as.setLastSynError(ci.lastErrorDescription);
                                as.setStatusSyn();
                                db.ASSessionUpdate(as);
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
            }
            return as;
        }

        @Override
        protected void onPostExecute(ASSession result) {
            super.onPostExecute(result);

            listener.onTaskFinished(result);
        }
    }

}
