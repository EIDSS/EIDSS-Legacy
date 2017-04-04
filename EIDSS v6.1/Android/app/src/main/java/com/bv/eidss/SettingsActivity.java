package com.bv.eidss;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v7.app.ActionBar;

public class SettingsActivity extends EidssBaseActivity
        implements  EidssAndroidHelpers.DialogDoneListener {
    public final int OK_DIALOG_ID = 3;
    public final int BACK_DIALOG_ID = 4;
    public final int RESTORE_DIALOG_ID = 5;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        mDrawerList.setItemChecked(position, true);
        setTitle("");
        final ActionBar ab = getSupportActionBar();
        if(ab != null)
            ab.setIcon(R.drawable.eidss_ic_settings_big);


        StartFragment();
    }

    private Fragment StartFragment()
    {
        FragmentManager fm = getSupportFragmentManager();
        Fragment fragment = fm.findFragmentById(R.id.content_frame);
        if (fragment == null) {
            fragment = new SettingsFragment();
            fm.beginTransaction()
                    .add(R.id.content_frame, fragment)
                    .commit();
        }
        return fragment;
    }

    @Override
    public void onBackPressed()
    {
        SettingsFragment fragment = (SettingsFragment)StartFragment();
        if(fragment.getChanged())
            EidssAndroidHelpers.AlertOkResultDialog.ShowQuestion(getSupportFragmentManager(), BACK_DIALOG_ID, R.string.ConfirmCancelCase);
        else
            super.onBackPressed();
    }

    @Override
    public void onDone(int idDialog, boolean isPositive) {
        switch (idDialog) {
            case OK_DIALOG_ID:
                finish();
                startActivity(getIntent());
                break;
            case BACK_DIALOG_ID:
                if(isPositive)
                    super.onBackPressed();
                break;
            case RESTORE_DIALOG_ID:
                if(isPositive)
                    ((SettingsFragment)StartFragment()).restoreDefaults();
                break;
            default:
                break;
        }
    }
}