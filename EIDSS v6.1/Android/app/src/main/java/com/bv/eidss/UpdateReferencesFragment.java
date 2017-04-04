package com.bv.eidss;


import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.Options;
import com.bv.eidss.web.LstSAXXMLHandler;
import com.bv.eidss.web.RefSAXXMLHandler;
import java.util.Date;


public class UpdateReferencesFragment extends Fragment implements EidssAndroidHelpers.AsyncResponseI{
    public Object[] ret;
    private LoadReferenceTask task;
    private LoadListsTask taskLists;
    private ProgressDialog progressDialog;
    private boolean isTaskRunning = false;

    public static UpdateReferencesFragment newInstance() {
        return new UpdateReferencesFragment();
    }

    public UpdateReferencesFragment() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
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
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        View v = inflater.inflate(R.layout.update_references_layout, container, false);

        v.findViewById(R.id.LoadListsOnline).setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                startActivity((new Intent()).setClass(getActivity(), LoadListsActivity.class));
            }
        });
        v.findViewById(R.id.LoadListsFile).setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                Intent intent = new Intent();
                intent.setClass(getActivity(), FileBrowser.class);
                int md = getResources().getInteger(R.integer.FILE_BROWSER_MODE_LIST);
                intent.putExtra(getResources().getString(R.string.EXTRA_ID_MODE), md);
                intent.putExtra("mask", "Lists*.eidss");
                startActivityForResult(intent, md);
            }
        });

        v.findViewById(R.id.LoadReferencesOnline).setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                startActivity((new Intent()).setClass(getActivity(), LoadReferencesActivity.class));
            }
        });
        v.findViewById(R.id.LoadReferencesFile).setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                Intent intent = new Intent();
                intent.setClass(getActivity(), FileBrowser.class);
                int md = getResources().getInteger(R.integer.FILE_BROWSER_MODE_LOAD);
                intent.putExtra(getResources().getString(R.string.EXTRA_ID_MODE), md);
                intent.putExtra("mask", "References*.eidss");
                startActivityForResult(intent, md);
            }
        });
        v.findViewById(R.id.CheckForUpdates).setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                AppVersionTask getAppVer = new AppVersionTask(getActivity(), new AppVersionTask.OnComplete() {
                    @Override
                    public void asyncResponse(int result) {
                    }
                }, getResources().getInteger(R.integer.APP_DOWNLOAD_MODE_CHCK));
                getAppVer.execute();
            }
        });
        return v;
    }


    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data)
    {
        if (requestCode == getResources().getInteger(R.integer.FILE_BROWSER_MODE_LOAD)) {
            String fullFilename = data.getStringExtra(getResources().getString(R.string.EXTRA_ID_FILENAME));
            StartLoadReferences(fullFilename);
        }else if (requestCode == getResources().getInteger(R.integer.FILE_BROWSER_MODE_LIST)) {
            String fullFilename = data.getStringExtra(getResources().getString(R.string.EXTRA_ID_FILENAME));
            StartLoadLists(fullFilename);
        }

        super.onActivityResult(requestCode, resultCode, data);
    }

    public void StartLoadReferences(String fullFilename)
    {
        if (!isTaskRunning) {
            task = new LoadReferenceTask(this);
            task.execute(fullFilename);
        }
    }

    public void StartLoadLists(String fullFilename)
    {
        if (!isTaskRunning) {
            taskLists = new LoadListsTask(this);
            taskLists.execute(fullFilename);
        }
    }

    private void showProgressDialog()
    {
        progressDialog = EidssAndroidHelpers.ProgressDialog(getActivity(),
            taskLists != null ? R.string.WaitLoadingLists : R.string.WaitLoading,
            new DialogInterface.OnClickListener(){
            public void onClick(DialogInterface dialog, int which) {
                if (task != null && task.cancel(true)){
                    progressDialog.dismiss();
                    progressDialog = null;
                    isTaskRunning = false;
                    EidssAndroidHelpers.AlertOkDialog.Show(getActivity().getSupportFragmentManager(), R.string.GetReferencesAborted);
                }
                if (taskLists != null && taskLists.cancel(true)){
                    progressDialog.dismiss();
                    progressDialog = null;
                    isTaskRunning = false;
                    EidssAndroidHelpers.AlertOkDialog.Show(getActivity().getSupportFragmentManager(), R.string.GetListsAborted);
                }
            }});

    }

    @Override
    public void onTaskStarted() {
        isTaskRunning = true;
        showProgressDialog();
    }

    @Override
    public void onTaskFinished(Integer iErr) {
        if (iErr > 0 && progressDialog != null) {
            progressDialog.dismiss();
            progressDialog = null;
        }
        isTaskRunning = false;

        if (iErr == 1){
            EidssAndroidHelpers.AlertOkDialog.Warning(getActivity().getSupportFragmentManager(), R.string.ErrorOutOfDate);
        }else if (iErr == 2){
            EidssAndroidHelpers.AlertOkDialog.Warning(getActivity().getSupportFragmentManager(), R.string.ErrorWrongFormat);
        }else if (iErr == 3){
            EidssAndroidHelpers.AlertOkDialog.Warning(getActivity().getSupportFragmentManager(), R.string.ErrorRefsLoaded);
        }else if (iErr == 4){
            EidssAndroidHelpers.AlertOkDialog.Warning(getActivity().getSupportFragmentManager(), R.string.ErrorListsLoaded);
        }else{
            if (progressDialog != null) {
                progressDialog.dismiss();
                progressDialog = null;
            }
            EidssAndroidHelpers.AlertOkDialog.Show(getActivity().getSupportFragmentManager(),
                    taskLists != null ? R.string.ListsUpdated : R.string.ReferencesUpdated);
        }
    }

    final private class LoadReferenceTask extends AsyncTask<String, Void, Integer> {
        private final EidssAndroidHelpers.AsyncResponseI listener;

        public LoadReferenceTask(EidssAndroidHelpers.AsyncResponseI listener) {
            this.listener = listener;
         }
        @Override
        protected void onPreExecute() {
            super.onPreExecute();

            listener.onTaskStarted();
        }

        @Override
        protected Integer doInBackground(String... fullFilename) {
            int iErr;
            try{
                EidssDatabase db = new EidssDatabase(getActivity());
                Options opt = db.Options();
                Date lastUpdate = opt.getLastRefUpdt();
                EidssDatabase.ClearPreloadedReferencies();

                //long start = new Date().getTime();

                RefSAXXMLHandler refSAXXMLHandler = new RefSAXXMLHandler(fullFilename[0], lastUpdate, db);
                iErr = refSAXXMLHandler.parseDocument();


                //long diff = new Date().getTime() - start;
                //System.out.println(String.format("Difference from start to end : %d", diff));
            }
            catch(NullPointerException e){
                iErr = 2;
            }
            catch(Exception e){
                iErr = 3;
            }

            return iErr;
        }

        @Override
        protected void onPostExecute(Integer result) {
            super.onPostExecute(result);

            listener.onTaskFinished(result);
        }
    }

    final private class LoadListsTask extends AsyncTask<String, Void, Integer> {
        private final EidssAndroidHelpers.AsyncResponseI listener;

        public LoadListsTask(EidssAndroidHelpers.AsyncResponseI listener) {
            this.listener = listener;
        }
        @Override
        protected void onPreExecute() {
            super.onPreExecute();

            listener.onTaskStarted();
        }

        @Override
        protected Integer doInBackground(String... fullFilename) {
            int iErr;
            try{
                EidssDatabase db = new EidssDatabase(getActivity());
                LstSAXXMLHandler lstSAXXMLHandler = new LstSAXXMLHandler(fullFilename[0], db);
                iErr = lstSAXXMLHandler.parseDocument();
            }
            catch(NullPointerException e){
                iErr = 2;
            }
            catch(Exception e){
                iErr = 4;
            }

            return iErr;
        }

        @Override
        protected void onPostExecute(Integer result) {
            super.onPostExecute(result);

            listener.onTaskFinished(result);
        }
    }

}
