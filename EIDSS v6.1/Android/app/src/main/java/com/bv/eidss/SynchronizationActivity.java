package com.bv.eidss;

import com.bv.eidss.data.EidssDatabase;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;

public class SynchronizationActivity extends EidssBaseActivity implements EidssAndroidHelpers.DialogDoneListener {
    final public int QUESTION_DIALOG_ID = 6;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        mDrawerList.setItemChecked(position, true);
        setTitle("");
        getSupportActionBar().setIcon(R.drawable.eidss_ic_sync_big);
        getSupportActionBar().setDisplayShowHomeEnabled(true);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        StartFragment();
    }

    private Fragment StartFragment()
    {
        FragmentManager fm = getSupportFragmentManager();
        Fragment fragment = fm.findFragmentById(R.id.content_frame);
        if (fragment == null) {
            fragment = SynchronizationFragment.newInstance();
            fm.beginTransaction()
                    .add(R.id.content_frame, fragment)
                    .commit();
        }
        return fragment;
    }

    @Override
    public void onDone(int idDialog, boolean isPositive) {
        switch (idDialog) {
            case QUESTION_DIALOG_ID:
                if(isPositive)
                {
                    final EidssDatabase db = new EidssDatabase(this);
                    db.SinchronizedCasesDelete();
                    db.close();

                    EidssAndroidHelpers.AlertOkDialog.Show(getSupportFragmentManager(), R.string.SynchronizedDeleteOk);
                }
        }
    }
}

