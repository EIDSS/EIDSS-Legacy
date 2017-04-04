package com.bv.eidss;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;

public class SystemInfoActivity extends EidssBaseActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        
        mDrawerList.setItemChecked(position, true);
        setTitle("");
        getSupportActionBar().setIcon(R.drawable.eidss_ic_info_big);

        FragmentManager fm = getSupportFragmentManager();
        Fragment fragment = fm.findFragmentById(R.id.content_frame);
        if (fragment == null) {
            fragment = new SystemInfoFragment();
            fm.beginTransaction()
                    .add(R.id.content_frame, fragment)
                    .commit();
        }

    }

}
