package com.bv.eidss;

import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;

public class SetLocalPasswordActivity extends EidssBaseBlockTimeoutActivity implements EidssAndroidHelpers.DialogDoneListener {
    final public int REFLOAD_DIALOG_ID = 1;

	@Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.blank_fragment_activity);

        setTitle(R.string.TitleSetLocalPassword);

        FragmentManager fm = getSupportFragmentManager();
        Fragment fragment = fm.findFragmentById(R.id.content_frame);
        if (fragment == null) {
            fragment = new SetLocalPasswordFragment();
            fm.beginTransaction()
                    .add(R.id.content_frame, fragment)
                    .commit();
        }

    }

    @Override
    public void onDone(int idDialog, boolean isPositive) {
        switch (idDialog) {
            case REFLOAD_DIALOG_ID:
                if(isPositive)
                {
                    startActivityForResult(new Intent(this, LoadReferencesActivity.class), getResources().getInteger(R.integer.ACTIVITY_ID_LOAD_REFERENCES));
                }
                else
                {
                    setResult(RESULT_OK);
                    finish();
                }
        }
    }
    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        setResult(RESULT_OK);
        finish();
    }
}
