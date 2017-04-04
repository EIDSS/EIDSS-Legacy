package com.bv.eidss;

import android.content.Intent;
import android.content.res.Configuration;
import android.content.res.Resources;
import android.os.Bundle;
import android.support.v7.app.ActionBar;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.View;
import android.widget.AdapterView;
import android.widget.FrameLayout;
import android.widget.ListView;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.ASSession;
import com.bv.eidss.model.CaseType;
import com.bv.eidss.model.HumanCase;
import com.bv.eidss.model.Options;


public class EidssBaseActivity extends EidssBaseBlockTimeoutActivity {
     protected FrameLayout frameLayout;

    /**
     * ListView to add navigation drawer item in it.
     * We have made it protected to access it in child class. We will just use it in child class to make item selected according to activity opened.
     */
    protected ListView mDrawerList;


    //private CharSequence mDrawerTitle;
    private CharSequence mTitle;
    CustomDrawerAdapter adapter;

    /**
     * Base layout node of this Activity.
     */
    protected DrawerLayout mDrawerLayout;
    protected Toolbar toolbar;

    /**
     * Static variable for selected item position. Which can be used in child activity to know which item is selected from the list.
     */
    protected static int position;

    /**
     * This flag is used just to check that launcher activity is called first time
     * so that we can open appropriate Activity on launch and make list item position selected accordingly.
     */
    public static boolean isLaunch = true;

    /**
     * Drawer listener class for drawer open, close etc.
     */
    public ActionBarDrawerToggle mDrawerToggle;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.eidss_activity);

        toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        SetToolbarSpinner();

        frameLayout = (FrameLayout) findViewById(R.id.content_frame);
        mDrawerLayout = (DrawerLayout) findViewById(R.id.drawer_layout);
        mDrawerList = (ListView) findViewById(R.id.left_drawer);

        mTitle = getTitle();

        // set a custom shadow that overlays the main content when the drawer opens
        mDrawerLayout.setDrawerShadow(R.drawable.drawer_shadow, GravityCompat.START);

        initMenu();


        mDrawerList.setOnItemClickListener(new AdapterView.OnItemClickListener() {

            @Override
            public void onItemClick(AdapterView<?> parent, View view,
                                    int position, long id) {

                openActivity(id, position);
            }
        });


        // ActionBarDrawerToggle ties together the the proper interactions between the sliding drawer and the action bar app icon
        mDrawerToggle = new ActionBarDrawerToggle(
                this,						/* host Activity */
                mDrawerLayout, 				/* DrawerLayout object */
                toolbar,
                R.string.OpenDrawer,       /* "open drawer" description for accessibility */
                R.string.CloseDrawer)      /* "close drawer" description for accessibility */ {

            @Override
            public void onDrawerClosed(View drawerView) {
                // this you need to change title for opened menu
                //getSupportActionBar().setTitle(mTitle);
                supportInvalidateOptionsMenu(); // creates call to onPrepareOptionsMenu()
                super.onDrawerClosed(drawerView);
            }

            @Override
            public void onDrawerOpened(View drawerView) {
                // this you need to change title for opened menu
                //getSupportActionBar().setTitle(mDrawerTitle);
                supportInvalidateOptionsMenu(); // creates call to onPrepareOptionsMenu()
                super.onDrawerOpened(drawerView);
            }

            @Override
            public void onDrawerSlide(View drawerView, float slideOffset) {
                super.onDrawerSlide(drawerView, slideOffset);
            }

            @Override
            public void onDrawerStateChanged(int newState) {
                super.onDrawerStateChanged(newState);
            }
        };


        mDrawerLayout.setDrawerListener(mDrawerToggle);

        // enable ActionBar app icon to behave as action to toggle nav drawer
        final ActionBar actionBar = getSupportActionBar();
        actionBar.setDisplayShowHomeEnabled(true);
        actionBar.setDisplayHomeAsUpEnabled(true);
        /**
         * As we are calling BaseActivity from manifest file and this base activity is intended just to add navigation drawer in our app.
         * We have to open some activity with layout on launch. So we are checking if this BaseActivity is called first time then we are opening our first activity.
         * */
    }

    @Override
    public void setTitle(CharSequence title) {
        mTitle = title;
        getSupportActionBar().setTitle(mTitle);
    }

    @Override
    protected void onPostCreate(Bundle savedInstanceState) {
        super.onPostCreate(savedInstanceState);
        mDrawerLayout = (DrawerLayout) findViewById(R.id.drawer_layout);
        mDrawerToggle.syncState(); // important statetment for drawer to
        // identify
        // its state

        if (isLaunch) {
            isLaunch = false;
            mDrawerLayout.openDrawer(mDrawerList);
        }
    }

    private static int _ApplicationMode = 0;
    public static void setApplicationMode(int value)
    {
        _ApplicationMode = value;
    }
    public static int getApplicationMode(EidssDatabase db)
    {
        if (_ApplicationMode == 0) {
            Options o = db.Options();
            _ApplicationMode = o.getApplicationMode();
        }
        return _ApplicationMode;
    }

    protected void initMenu() {


        Resources res = getResources();

        adapter = new CustomDrawerAdapter(this);

        adapter.addItem(DrawerItem.newInstance(res.getString(R.string.ApplicationName), R.drawable.ic_launcher));
        adapter.addItem(DrawerItem.newInstance(res.getString(R.string.Journals)));
        boolean isFirst = true;
        final EidssDatabase mDb = new EidssDatabase(this);
        if ((getApplicationMode(mDb) & res.getInteger(R.integer.APPLICATION_MODE_HUMAN)) > 0) {
            adapter.addItem(DrawerItem.newInstance(res.getInteger(R.integer.ACTIVITY_ID_HUMAN_LIST), res.getString(R.string.HumanCaseList), R.drawable.eidss_ic_search_hc_small, true));
            isFirst = false;
        }

        if ((getApplicationMode(mDb) & res.getInteger(R.integer.APPLICATION_MODE_VETERINARY)) > 0)
            adapter.addItem(DrawerItem.newInstance(res.getInteger(R.integer.ACTIVITY_ID_VET_LIST), res.getString(R.string.VeterinaryCaseList), R.drawable.eidss_ic_search_vc_small, isFirst));

        if ((getApplicationMode(mDb) & res.getInteger(R.integer.APPLICATION_MODE_ASSESSION)) > 0)
            adapter.addItem(DrawerItem.newInstance(res.getInteger(R.integer.ACTIVITY_ID_ASSESSION_LIST), res.getString(R.string.ASSessionList), R.drawable.eidss_ic_search_as_small, isFirst));

        adapter.addItem(DrawerItem.newInstance(res.getString(R.string.Create)));// adding a header to the list
        isFirst = true;
        if ((getApplicationMode(mDb) & res.getInteger(R.integer.APPLICATION_MODE_HUMAN)) > 0) {
            adapter.addItem(DrawerItem.newInstance(res.getInteger(R.integer.ACTIVITY_ID_HUMAN_CASE), res.getString(R.string.HumanCase), R.drawable.eidss_ic_hc_small, true));
            isFirst = false;
        }
        if ((getApplicationMode(mDb) & res.getInteger(R.integer.APPLICATION_MODE_VETERINARY)) > 0) {
            adapter.addItem(DrawerItem.newInstance(res.getInteger(R.integer.ACTIVITY_ID_AVIAN_CASE), res.getString(R.string.AvianCase), R.drawable.eidss_ic_avc_small, isFirst));
            adapter.addItem(DrawerItem.newInstance(res.getInteger(R.integer.ACTIVITY_ID_LIVESTOCK_CASE), res.getString(R.string.LivestockCase), R.drawable.eidss_ic_lvsc_small, false));
        }

        if ((getApplicationMode(mDb) & res.getInteger(R.integer.APPLICATION_MODE_ASSESSION)) > 0)
            adapter.addItem(DrawerItem.newInstance(res.getInteger(R.integer.ACTIVITY_ID_ASSESSION), res.getString(R.string.ASSession), R.drawable.eidss_ic_as_small, isFirst));

        mDb.close();

        adapter.addItem(DrawerItem.newInstance(res.getString(R.string.System))); // adding a header to the list
        adapter.addItem(DrawerItem.newInstance(res.getInteger(R.integer.ACTIVITY_ID_OPTIONS), res.getString(R.string.TitleSettings), R.drawable.eidss_ic_settings_small, true));
        adapter.addItem(DrawerItem.newInstance(res.getInteger(R.integer.ACTIVITY_ID_SYNCHRONIZATION), res.getString(R.string.Synchronization), R.drawable.eidss_ic_sync_small, false));
        adapter.addItem(DrawerItem.newInstance(res.getInteger(R.integer.ACTIVITY_ID_UPDATE), res.getString(R.string.Updates), R.drawable.eidss_ic_updates_small, false));
        adapter.addItem(DrawerItem.newInstance(res.getInteger(R.integer.ACTIVITY_ID_INFO), res.getString(R.string.SystemInfo), R.drawable.eidss_ic_info_small, false));
        adapter.addItem(DrawerItem.newInstance(res.getInteger(R.integer.ACTIVITY_ID_EXIT), res.getString(R.string.Exit), R.drawable.eidss_ic_logout, false));



        mDrawerList.setAdapter(adapter);
    }

    public boolean isDrawerOpen() {
        return mDrawerLayout.isDrawerOpen(mDrawerList);
    }



    protected void SetToolbarSpinner() {
        findViewById(R.id.spinner_list_filter).setVisibility(View.INVISIBLE);
    }


    /**
     * @param id
     *
     * Launching activity when any list item is clicked.
     */

    protected void openActivity(long id, int pos) {
        Resources res = getResources();

        /**
         * We can set title & itemChecked here but as this BaseActivity is parent for other activity,
         * So whenever any activity is going to launch this BaseActivity is also going to be called and
         * it will reset this value because of initialization in onCreate method.
         * So that we are setting this in child activity.
         */
//		mDrawerList.setItemChecked(position, true);
//		setTitle(listArray[position]);



        mDrawerLayout.closeDrawer(mDrawerList);
        EidssBaseActivity.position = pos; //Setting currently selected position in this field so that it will be available in our child activities.

        Intent intent = new Intent();
        intent.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);

        if (id == res.getInteger(R.integer.ACTIVITY_ID_HUMAN_LIST)) {
            intent.setClass(this, HumanCaseListActivity.class);
            startActivity(intent);
        }else if (id == res.getInteger(R.integer.ACTIVITY_ID_VET_LIST)) {
            intent.setClass(this, VetCaseListActivity.class);
            startActivity(intent);
        }else if (id == res.getInteger(R.integer.ACTIVITY_ID_ASSESSION_LIST)) {
            intent.setClass(this, ASSessionListActivity.class);
            startActivity(intent);
        }else if (id == res.getInteger(R.integer.ACTIVITY_ID_HUMAN_CASE)) {
            intent.setClass(this, HumanCaseActivity.class);
            startActivityForResult(intent, res.getInteger(R.integer.ACTIVITY_ID_HUMAN_CASE));
        }else if (id == res.getInteger(R.integer.ACTIVITY_ID_AVIAN_CASE)) {
            intent.setClass(this, VetCaseActivity.class);
            intent.putExtra(res.getString(R.string.EXTRA_ID_MODE), CaseType.AVIAN);
            startActivityForResult(intent, res.getInteger(R.integer.ACTIVITY_ID_VET_CASE));
        }else if (id == res.getInteger(R.integer.ACTIVITY_ID_LIVESTOCK_CASE)) {
            intent.setClass(this, VetCaseActivity.class);
            intent.putExtra(res.getString(R.string.EXTRA_ID_MODE), CaseType.LIVESTOCK);
            startActivityForResult(intent, res.getInteger(R.integer.ACTIVITY_ID_VET_CASE));
        }else if (id == res.getInteger(R.integer.ACTIVITY_ID_ASSESSION)) {
            intent.setClass(this, ASSessionActivity.class);
            intent = intent.putExtra(res.getString(R.string.EXTRA_ID_ASSESSION), ASSession.CreateNew());
            startActivityForResult(intent, res.getInteger(R.integer.ACTIVITY_ID_ASSESSION));
        }else if (id == res.getInteger(R.integer.ACTIVITY_ID_OPTIONS)) {
            intent.setClass(this, SettingsActivity.class);
            startActivity(intent);
        }else if (id == res.getInteger(R.integer.ACTIVITY_ID_SYNCHRONIZATION)) {
            intent.setClass(this, SynchronizationActivity.class);
            startActivity(intent);
        }else if (id == res.getInteger(R.integer.ACTIVITY_ID_UPDATE)) {
            intent.setClass(this, UpdateReferencesActivity.class);
            startActivity(intent);
        }else if (id == res.getInteger(R.integer.ACTIVITY_ID_INFO)) {
            intent.setClass(this, SystemInfoActivity.class);
            startActivity(intent);
        }else if (id == res.getInteger(R.integer.ACTIVITY_ID_EXIT)) {
            intent.setClass(this, StartActivity.class);
            startActivity(intent);
        }else {
            mDrawerLayout.openDrawer(mDrawerList);
        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {

        //getMenuInflater().inflate(R.menu.activity_main, menu);
        return super.onCreateOptionsMenu(menu);
    }

    /* Called whenever we call invalidateOptionsMenu() */
    @Override
    public boolean onPrepareOptionsMenu(Menu menu) {
         // If the nav drawer is open, hide action items related to the content view
        //boolean drawerOpen = mDrawerLayout.isDrawerOpen(mDrawerList);
        return super.onPrepareOptionsMenu(menu);
    }

    /* We can override onBackPressed method to toggle navigation drawer*/
    @Override
    public void onBackPressed() {
        if (mDrawerLayout!=null && mDrawerLayout.isDrawerOpen(GravityCompat.START)) {
            mDrawerLayout.closeDrawers();
            return;
        }
        super.onBackPressed();
    }

    @Override
    public void onConfigurationChanged(Configuration newConfig) {
        super.onConfigurationChanged(newConfig);
        mDrawerToggle.onConfigurationChanged(newConfig);
    }
}
