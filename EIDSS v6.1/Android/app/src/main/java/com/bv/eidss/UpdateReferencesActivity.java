package com.bv.eidss;

import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.DialogFragment;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;

import java.io.File;
import java.io.FileOutputStream;

public class UpdateReferencesActivity extends EidssBaseActivity implements EidssAndroidHelpers.DialogDoneListener {
    public byte[] appContent;
    private DialogFragment mReturningWithResult;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        mDrawerList.setItemChecked(position, true);
        setTitle("");
        getSupportActionBar().setIcon(R.drawable.eidss_ic_updates_big);

        StartFragment();

    }

    private Fragment StartFragment()
    {
        FragmentManager fm = getSupportFragmentManager();
        Fragment fragment = fm.findFragmentById(R.id.content_frame);
        if (fragment == null) {
            fragment = UpdateReferencesFragment.newInstance();
            fm.beginTransaction()
                    .add(R.id.content_frame, fragment)
                    .commit();
        }
        return fragment;
    }

    @Override
    protected void onResume() {
        super.onResume();
        if (mReturningWithResult != null) {
            // Commit your transactions here.
            mReturningWithResult.show(getSupportFragmentManager(),"dialog");
        }
        // Reset the boolean flag back to false for next time.
        mReturningWithResult = null;
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data)
    {
        if (requestCode == getResources().getInteger(R.integer.FILE_BROWSER_MODE_SAVE)) {
            String fullFilename = data.getStringExtra(getResources().getString(R.string.EXTRA_ID_FILENAME));
            if (!fullFilename.isEmpty()) {
                try {
                    File file = new File(fullFilename);
                    FileOutputStream filecon = new FileOutputStream(file);
                    filecon.write(appContent);
                    filecon.close();
                    mReturningWithResult = EidssAndroidHelpers.AlertOkResultDialog.ShowOk(AppDownloadTask.NEWVERSION_DIALOG_ID, R.string.NewVersionDownloaded);
                } catch (Exception e) {
                    mReturningWithResult = EidssAndroidHelpers.AlertOkResultDialog.ShowOk(AppVersionTask.ERROR_DIALOG_ID, R.string.ErrorSaveAppFile);
                }
            }
        }

        super.onActivityResult(requestCode, resultCode, data);
    }

    @Override
    public void onDone(int idDialog, boolean isPositive) {
        switch (idDialog) {
            case AppVersionTask.ASKFORDOWNLOAD_DIALOG_ID:
                if(isPositive)
                {
                    AppDownloadTask getAppVer = new AppDownloadTask(this, new AppDownloadTask.OnComplete() {
                        @Override
                        public void asyncResponse(byte[] result) {
                            appContent = result;
                        }
                    });
                    getAppVer.execute();
                }
                break;
            case AppVersionTask.NEWVERSION_DIALOG_ID:
                break;
            case AppVersionTask.ERROR_DIALOG_ID:
                finish();
                break;
        }    }
}

