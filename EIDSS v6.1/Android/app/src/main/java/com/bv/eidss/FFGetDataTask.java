package com.bv.eidss;


import android.content.Intent;
import android.os.AsyncTask;
import android.support.v4.app.FragmentActivity;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.utils.EidssUtils;


public class FFGetDataTask extends AsyncTask<Void, Void, Void> {
    private final OnComplete listener;
    private FragmentActivity context;

    public FFGetDataTask(FragmentActivity a, OnComplete listener) {
        this.listener = listener;
        context = a;
    }

    // Interface to be implemented by calling activity
    public interface OnComplete {
        public void asyncResponse();
    }

    @Override
    protected Void doInBackground(Void... params) {
        if(!EidssDatabase.IsFFLoaded())
        {
            String[] sels = new String[1];
            sels[0] = EidssUtils.getCurrentLanguage();

            EidssDatabase.AddFFData(context.getContentResolver().query(ReferenciesProvider.CONTENT_URI, null, null, sels, null));
        }
        return null;
    }

    @Override
    protected void onPostExecute(Void v) {
        super.onPostExecute(v);


        listener.asyncResponse();
    }
}
