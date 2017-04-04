package com.bv.eidss;

import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.DialogFragment;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;

import java.io.File;
import java.io.FileOutputStream;


public class SynchronizeCasesActivity extends EidssBaseBlockTimeoutActivity implements EidssAndroidHelpers.DialogDoneListener {
    final public int FINISHED_DIALOG_ID = 0;
    public byte[] appContent;
    private DialogFragment mReturningWithResult;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setTitle(R.string.SynchronizeAllCases);
        setContentView(R.layout.blank_fragment_activity);

        StartFragment();
    }

    private Fragment StartFragment()
    {
        FragmentManager fm = getSupportFragmentManager();
        Fragment fragment = fm.findFragmentById(R.id.content_frame);
        if (fragment == null) {
            Bundle extras = getIntent().getExtras();
            long lId = 0;
            int iType = R.integer.SYNCHRONIZATION_TYPE_ALL;
            if(extras != null) {
                lId = extras.getLong("Id", 0);
                iType = extras.getInt("Type", R.integer.SYNCHRONIZATION_TYPE_ALL);
            }

            fragment = SynchronizeCasesFragment.newInstance(lId, iType);
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
            case FINISHED_DIALOG_ID:
                finish();
                break;
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
                else {
                    SynchronizeCasesFragment fragment = (SynchronizeCasesFragment)StartFragment();
                    fragment.StartSynchronizeCases();
                }
                break;
            case AppVersionTask.NEWVERSION_DIALOG_ID:
                SynchronizeCasesFragment fragment = (SynchronizeCasesFragment)StartFragment();
                fragment.StartSynchronizeCases();
                break;
            case AppVersionTask.ERROR_DIALOG_ID:
                finish();
                break;
        }    }
}
