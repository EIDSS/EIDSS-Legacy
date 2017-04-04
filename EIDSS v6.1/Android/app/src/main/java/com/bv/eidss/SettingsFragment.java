package com.bv.eidss;

import android.app.Activity;
import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.res.Resources;
import android.database.Cursor;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.Parcel;
import android.os.Parcelable;
import android.support.v4.app.LoaderManager;
import android.support.v4.content.CursorLoader;
import android.support.v4.content.Loader;
import android.support.v4.widget.SimpleCursorAdapter;
import android.support.v7.widget.SwitchCompat;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.MotionEvent;
import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.PopupWindow;
import android.widget.Spinner;
import android.widget.TextView;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.GisBaseReference;
import com.bv.eidss.model.LanguageItem;
import com.bv.eidss.model.Options;
import com.bv.eidss.utils.CheckOneToHundred;
import com.bv.eidss.utils.EidssContextUtils;
import com.bv.eidss.web.WebApiClient;


public class SettingsFragment extends EidssBaseBindableFragment
        implements EidssAndroidHelpers.AsyncResponse, LoaderManager.LoaderCallbacks<Cursor> {
    private static final String SAVE_SETTINGS = "SAVE_SETTINGS";
    private static final int LOADER_REGIONS = 1;
    private static final int LOADER_RAYONS = 2;

    SimpleCursorAdapter mRayonsAdapter;
    DropDownListAdapter mModeAdapter;

    private SettingsFragment _this;
    public int iErr = 0;

    // widgets
    public EditText srvto;
    public EditText url;
    EditText recsl;
    EditText appto;
    PopupWindow appm_pw;
    TextView appm;
    Spinner lng;
    Spinner regions;
    Spinner rayons;
    SwitchCompat fltrByDgn;

    private Settings settings;

    //readonly settings
    public String urlt;
    public String srvt;

    private CheckTask checkTask;
    private ProgressDialog progressDialog;
    private boolean isTaskRunning = false;

    public SettingsFragment() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setRetainInstance(true);//to restore dialogs after change orientation
        setHasOptionsMenu(true);
        _this = this;
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
        final LayoutInflater infl = inflater;
        if (savedInstanceState != null) {
            settings = (Settings) savedInstanceState.get(SAVE_SETTINGS);
        } else {
            settings = new Settings(EidssDatabase.GetOptions());
        }

        View v = inflater.inflate(R.layout.settings_layout, container, false);

        recsl = (EditText) v.findViewById(R.id.NumberRecordsList);
        recsl.addTextChangedListener(new CheckOneToHundred());
        url = (EditText) v.findViewById(R.id.ServerUrl);
        appto = (EditText) v.findViewById(R.id.ApplicationLockingTimeout);
        appto.addTextChangedListener(new CheckOneToHundred());
        srvto = (EditText) v.findViewById(R.id.ServerResponseTimeout);
        srvto.addTextChangedListener(new CheckOneToHundred());
        appm = (TextView) v.findViewById(R.id.ApplicationMode);
        int id = Resources.getSystem().getIdentifier("spinner_background_holo_light", "drawable", "android");
        appm.setBackgroundResource(id);

        lng = (Spinner) v.findViewById(R.id.Language);
        lng.setBackgroundResource(id);
        regions = (Spinner) v.findViewById(R.id.idfsRegion);
        regions.setBackgroundResource(id);
        rayons = (Spinner) v.findViewById(R.id.idfsRayon);
        rayons.setBackgroundResource(id);
        fltrByDgn = (SwitchCompat) v.findViewById(R.id.blnFilterByDgn);

        if (EidssDatabase.GetOptions().getRegionDefDef() > 0)
            EidssContextUtils.setTextAppearance((TextView) v.findViewById(R.id.idfsRegionHeader), R.style.DetailItem_Header_Mandatory);


        final CharSequence[] mModesArray = App.getResourcesStatic().getTextArray(R.array.ApplicationMode_array);
        mModeAdapter = new DropDownListAdapter(getActivity(), mModesArray, appm, settings.iApplicationMode);
        appm.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                initiatePopUp(getActivity(), infl);
            }
        });

        ArrayAdapter<LanguageItem> langAdapter = new ArrayAdapter<>(getActivity(),
            R.layout.custom_spinner, EidssAndroidHelpers.GetSupportedLanguagesList());
        langAdapter.setDropDownViewResource(R.layout.custom_spinner_item);
        lng.setAdapter(langAdapter);

        LookupBindBefore(regions, v,
            new AdapterView.OnItemSelectedListener() {
                public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                    long ident = ((GisBaseReference) parent.getSelectedItem()).idfsBaseReference;
                    if (settings.region != ident) {

                        settings.region = ident;
                        settings.rayon = 0;

                        rayons.setEnabled(false);

                        updateRayons();
                    }
                }

                public void onNothingSelected(AdapterView<?> arg0) {
                }
            }, "", null, null);

        if (EidssDatabase.GetRegions() != null)
            onLoadFinishedRegions();
        else
            getActivity().getSupportLoaderManager().initLoader(LOADER_REGIONS, null, this);

        mRayonsAdapter = LookupBind(rayons, v, RayonsProvider.NAME,
            new AdapterView.OnItemSelectedListener() {
                public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                    if (settings.rayon != id) {
                        settings.rayon = id;
                    }
                }

                public void onNothingSelected(AdapterView<?> arg0) {
                }
            }, "", null, null);

        //fltrByDgn.setShowText(true);
        fltrByDgn.setOnCheckedChangeListener(
            new CompoundButton.OnCheckedChangeListener() {
                @Override
                public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                    settings.bFltrByDgn = isChecked;
                }
            }
        );

        v.findViewById(R.id.CheckConnection).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (!isTaskRunning) {
                    checkTask = new CheckTask(_this);
                    checkTask.execute();
                }
            }
        });
        v.findViewById(R.id.SetPasswordButton).setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                startActivity((new Intent()).setClass(getActivity(), ChangeLocalPasswordActivity.class));
            }
        });
        v.findViewById(R.id.RestoreDefaults).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                EidssAndroidHelpers.AlertOkResultDialog.ShowQuestion(getActivity().getSupportFragmentManager(), ((SettingsActivity) getActivity()).RESTORE_DIALOG_ID, R.string.ConfirmRestoreDefaults);
            }
        });

        setValuesOnScreen(settings);

        // hide soft keyboard
        getActivity().getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_HIDDEN);
        return v;
    }

    @Override
    public void onResume() {
        super.onResume();
        if (settings.region != EidssDatabase.GetOptions().getRegionDef() ||
            settings.rayon != EidssDatabase.GetOptions().getRayonDef())
            getActivity().finish();
    }

    @Override
    public void onSaveInstanceState(Bundle outState) {
        super.onSaveInstanceState(outState);
        getValuesFromScreen();
        outState.putParcelable(SAVE_SETTINGS, settings);
    }

    @Override
    public void onCreateOptionsMenu(Menu menu, MenuInflater inflater) {

        inflater.inflate(R.menu.save_toolbar, menu);
    }

    /* Called whenever we call invalidateOptionsMenu() */
    @Override
    public void onPrepareOptionsMenu(Menu menu) {
        // If the nav drawer is open, hide action items related to the content view
        EidssBaseActivity act = (EidssBaseActivity) getActivity();
        if (act != null) {
            boolean drawerOpen = act.isDrawerOpen();
            menu.findItem(R.id.Save).setVisible(!drawerOpen);
        }
        super.onPrepareOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case android.R.id.home:
                if (getChanged())
                    EidssAndroidHelpers.AlertOkResultDialog.ShowQuestion(getActivity().getSupportFragmentManager(), ((SettingsActivity) getActivity()).BACK_DIALOG_ID, R.string.ConfirmCancelCase);
                return true;
            case R.id.Save:
                if (Save())
                    EidssAndroidHelpers.AlertOkResultDialog.ShowOk(getActivity().getSupportFragmentManager(), ((SettingsActivity) getActivity()).OK_DIALOG_ID, R.string.SettingsSaveOk);
                return true;

            default:
                return super.onOptionsItemSelected(item);
        }
    }

    private void setValuesOnScreen(Settings settings) {
        recsl.setText(String.format("%d", settings.iPageSize));
        url.setText(settings.sServerUrl);
        appto.setText(String.format("%d", settings.iLockTimeout));
        srvto.setText(String.format("%d", settings.iResponseTimeout));

        appm.setText(mModeAdapter.putSelected(settings.iApplicationMode));

        for (int i = 0; i < lng.getAdapter().getCount(); i++) {
            if (((LanguageItem) lng.getAdapter().getItem(i)).id.compareTo(settings.sLanguage) == 0) {
                lng.setSelection(i);
                break;
            }
        }

        if (regions.isEnabled()) {
            for (int i = 0; i < EidssDatabase.GetRegions().size(); i++) {
                if (EidssDatabase.GetRegions().get(i).idfsBaseReference == settings.region) {
                    regions.setSelection(i);
                    updateRayons();
                    break;
                }
            }
        } else if (rayons.isEnabled()) {
            updateRayons();
        }

        fltrByDgn.setChecked(settings.bFltrByDgn);
    }

    private void getValuesFromScreen() {
        settings.iPageSize = Integer.parseInt(recsl.getText().toString());
        settings.sServerUrl = url.getText().toString();
        settings.iLockTimeout = Integer.parseInt(appto.getText().toString());
        settings.iResponseTimeout = Integer.parseInt(srvto.getText().toString());

        settings.iApplicationMode = mModeAdapter.getSelected();
        settings.sLanguage = ((LanguageItem) lng.getSelectedItem()).id;
    }

    public void restoreDefaults() {
        Options o = EidssDatabase.GetOptions();
        settings.GetDefSettings(o);

        EidssBaseBlockTimeoutActivity.timeoutLock=settings.iLockTimeout;
        EidssBaseActivity.setApplicationMode(settings.iApplicationMode);

        setValuesOnScreen(settings);
    }


    public boolean getChanged() {
        getValuesFromScreen();
        Options o = EidssDatabase.GetOptions();
        try {
            if (o.getPageSize() != settings.iPageSize ||
                o.getLockTimeout() != settings.iLockTimeout ||
                o.getResponseTimeout() != settings.iResponseTimeout
               )
                return true;
        } catch (NumberFormatException nfe) {
            EidssAndroidHelpers.AlertOkDialog.Show(getActivity().getSupportFragmentManager(), nfe.getLocalizedMessage());
            return true;
        }
        return  o.getApplicationMode() != settings.iApplicationMode ||
                !o.getDefLang().equals(settings.sLanguage) ||
                !o.getServerUrl().equals(settings.sServerUrl) ||
                o.getRegionDef() != settings.region ||
                o.getRayonDef() != settings.rayon ||
                o.getFltrByDgn() != settings.bFltrByDgn;
    }

    public boolean Save(){
        if (Validate()) {
            final EidssDatabase db = new EidssDatabase(getActivity());
            Options o = EidssDatabase.GetOptions();
            try {
                o.setPageSize(settings.iPageSize);
                o.setLockTimeout(settings.iLockTimeout);
                EidssBaseBlockTimeoutActivity.timeoutLock = settings.iLockTimeout;
                o.setResponseTimeout(settings.iResponseTimeout);
            } catch (NumberFormatException nfe) {
                db.close();
                EidssAndroidHelpers.AlertOkDialog.Show(getActivity().getSupportFragmentManager(), nfe.getLocalizedMessage());
                return false;
            }
            o.setApplicationMode(settings.iApplicationMode);
            EidssBaseActivity.setApplicationMode(settings.iApplicationMode);
            o.setDefLang(settings.sLanguage);
            o.setServerUrl(settings.sServerUrl);
            o.setRegionDef(settings.region);
            o.setRayonDef(settings.rayon);
            o.setFltrByDgn(settings.bFltrByDgn);
            db.OptionsUpdate(o);
            db.close();
            EidssAndroidHelpers.SetLocale();
            EidssDatabase.setAppLang();
            EidssDatabase.ClearLabels();
            return true;
        }

        return false;
    }


    private Boolean Validate() {
        getValuesFromScreen();

        if (EidssDatabase.GetOptions().getRegionDefDef() > 0 && settings.region == 0) {
            String errMes = String.format(getResources().getString(R.string.FieldMandatory), getResources().getString(R.string.DefaultRegion));
            EidssAndroidHelpers.AlertOkDialog.Warning(getActivity().getSupportFragmentManager(), errMes);
            return false;
        }
        return true;
    }

    @Override
    public void onTaskStarted() {
        isTaskRunning = true;
        showProgressDialog();
     }

    private void showProgressDialog()
    {
        progressDialog = EidssAndroidHelpers.ProgressDialog(getActivity(), R.string.WaitChecking, new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int which) {
                if (checkTask.cancel(true)) {
                    progressDialog.dismiss();
                    isTaskRunning = false;
                    EidssAndroidHelpers.AlertOkDialog.Warning(getActivity().getSupportFragmentManager(), R.string.CheckingAborted);
                }
            }
        });

    }

    @Override
    public void onTaskFinished(String result) {
        if (progressDialog != null) {
            progressDialog.dismiss();
        }
        isTaskRunning = false;

        if (iErr == 0) {
            EidssAndroidHelpers.AlertOkDialog.Show(getActivity().getSupportFragmentManager(),R.string.ConnectionOk);
        } else {
            EidssAndroidHelpers.AlertOkDialog.Warning(getActivity().getSupportFragmentManager(),iErr);
        }
    }

    final private class CheckTask extends AsyncTask<Void, Void, String> {
        private final EidssAndroidHelpers.AsyncResponse listener;

        public CheckTask(EidssAndroidHelpers.AsyncResponse listener) {
            this.listener = listener;
        }
        @Override
        protected void onPreExecute() {
            super.onPreExecute();

            urlt = url.getText().toString();
            srvt = srvto.getText().toString();

            listener.onTaskStarted();
        }

        @Override
        protected String doInBackground(Void... params) {
            iErr = 0;

            try {
                int timeout = 1;
                try {
                    timeout = Integer.parseInt(srvt);
                } catch(NumberFormatException nfe) {
                    Log.d("SettingsFragment", nfe.getMessage());
                }

                WebApiClient webClient = new WebApiClient(urlt, "", "", "", timeout);
                webClient.Check();
            }
            catch(Exception e){
                iErr = R.string.ConnectionErr;
            }

            return "";
        }

        @Override
        protected void onPostExecute(String result) {
            super.onPostExecute(result);

            listener.onTaskFinished(result);
        }
    }


    @Override
    public Loader<Cursor> onCreateLoader(int id, Bundle args)
    {
        String[] sels;
        switch (id)
        {
            case LOADER_REGIONS:
                sels = new String[2];
                sels[0] = settings.sLanguage;
                sels[1] = String.valueOf(settings.region);
                return new CursorLoader(getActivity(), RegionsProvider.CONTENT_URI, null, null, sels, null);
            case LOADER_RAYONS:
                sels = new String[3];
                sels[0] = settings.sLanguage;
                sels[1] = String.valueOf(settings.region);
                sels[2] = String.valueOf(settings.rayon);
                return new CursorLoader(getActivity(), RayonsProvider.CONTENT_URI, null, null, sels, null);
            default:
                return null;
        }
    }

    @Override
    public void onLoadFinished(Loader<Cursor> loader, Cursor data)
    {
        switch (loader.getId())
        {
            case LOADER_REGIONS:
                EidssDatabase.SetRegions(data);
                onLoadFinishedRegions();
                break;
            case LOADER_RAYONS:
                onLoadFinishedRayons(data);
                break;
            default:
                break;
        }
    }

    private void onLoadFinishedRegions()
    {
        boolean found = LookupBindAfter(regions, EidssDatabase.GetRegions(),settings.region, true, RegionsProvider.CONTENT_URI);
        if (EidssDatabase.GetRegions().size() > 0)
        {
            regions.setEnabled(true);
            if (settings.region > 0 && found) {
                updateRayons();
            }
        }
        else
        {
            regions.setEnabled(false);
            rayons.setEnabled(false);
        }
    }

    private void onLoadFinishedRayons(Cursor data)
    {
        mRayonsAdapter.swapCursor(data);
        int rowCount = data.getCount();
        if (rowCount > 0)
        {
            // set selected
            int cpos = 0;
            for(int i = 0; i < rowCount; i++){
                data.moveToPosition(i);
                long temp = data.getLong(0);
                if ( temp == settings.rayon){
                    cpos = i;
                    break;
                }
            }
            rayons.setSelection(cpos);
            rayons.setEnabled(true);
        }
        else
        {
            rayons.setEnabled(false);
        }
    }

    @Override
    public void onLoaderReset(Loader<Cursor> loader)
    {
        switch (loader.getId())
        {
            case LOADER_RAYONS:
                mRayonsAdapter.swapCursor(null);
                break;
            default:
                break;
        }
    }

    private void updateRayons()
    {
        getActivity().getSupportLoaderManager().restartLoader(LOADER_RAYONS, null, this);
    }
    /*
     * Function to set up the pop-up window which acts as drop-down list
     * */
    private void initiatePopUp(Activity activity, LayoutInflater inflater){
        //get the pop-up window i.e.  drop-down layout
        LinearLayout layout = (LinearLayout)inflater.inflate(R.layout.list_popup, (ViewGroup) activity.findViewById(R.id.PopUpView));

        //get the view to which drop-down layout is to be anchored
        final LinearLayout layout1 = (LinearLayout) activity.findViewById(R.id.ApplicationModeList);
        appm_pw = new PopupWindow(layout, ViewGroup.LayoutParams.WRAP_CONTENT, ViewGroup.LayoutParams.WRAP_CONTENT, true);

        //Pop-up window background cannot be null if we want the pop-up to listen touch events outside its window
        appm_pw.setBackgroundDrawable(new ColorDrawable(Color.WHITE));
        appm_pw.setTouchable(true);

        //let pop-up be informed about touch events outside its window. This  should be done before setting the content of pop-up
        appm_pw.setOutsideTouchable(true);
        appm_pw.setHeight(ViewGroup.LayoutParams.WRAP_CONTENT);

        //dismiss the pop-up i.e. drop-down when touched anywhere outside the pop-up
        appm_pw.setTouchInterceptor(new View.OnTouchListener() {

            public boolean onTouch(View v, MotionEvent event) {
                if (event.getAction() == MotionEvent.ACTION_OUTSIDE) {
                    appm_pw.dismiss();
                    return true;
                }
                return false;
            }
        });

        //provide the source layout for drop-down
        appm_pw.setContentView(layout);

        //anchor the drop-down to bottom-left corner of 'layout1'
        appm_pw.showAsDropDown(layout1);

        //populate the drop-down list
        final ListView list = (ListView) layout.findViewById(R.id.dropDownList);

        list.setAdapter(mModeAdapter);
    }

}

class Settings implements Parcelable {
    int iPageSize;
    String sServerUrl;
    int iLockTimeout;
    int iResponseTimeout;
    int iApplicationMode;
    String sLanguage;
    long region;
    long rayon;
    Boolean bFltrByDgn;

    public Settings(Options o) {
        iPageSize = o.getPageSize();
        sServerUrl = o.getServerUrl();
        iLockTimeout = o.getLockTimeout();
        iResponseTimeout = o.getResponseTimeout();

        iApplicationMode = o.getApplicationMode();
        sLanguage = o.getDefLang();
        region = o.getRegionDef();
        rayon = o.getRayonDef();
        bFltrByDgn = o.getFltrByDgn();
    }

    public Settings(Parcel source) {
        iPageSize = source.readInt();
        sServerUrl = source.readString();
        iLockTimeout = source.readInt();
        iResponseTimeout = source.readInt();

        iApplicationMode = source.readInt();
        sLanguage = source.readString();
        region = source.readLong();
        rayon = source.readLong();
        bFltrByDgn = source.readInt() == 1;
    }

    public void GetDefSettings(Options o) {
        iPageSize = o.getPageSizeDef();
        sServerUrl = o.getServerUrlDef();
        iLockTimeout = o.getLockTimeoutDef();
        iResponseTimeout = o.getResponseTimeoutDef();

        iApplicationMode = o.getApplicationModeDef();
        region = o.getRegionDefDef();
        rayon = o.getRayonDefDef();
        bFltrByDgn = false;
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flag) {
        dest.writeInt(iPageSize);
        dest.writeString(sServerUrl);
        dest.writeInt(iLockTimeout);
        dest.writeInt(iResponseTimeout);

        dest.writeInt(iApplicationMode);
        dest.writeString(sLanguage);
        dest.writeLong(region);
        dest.writeLong(rayon);
        if (bFltrByDgn == null) { dest.writeInt(0); } else { dest.writeInt(bFltrByDgn ? 1 : 0); }
    }

    public static final Parcelable.Creator<Settings> CREATOR = new Parcelable.Creator<Settings>()
    {
        public Settings createFromParcel(Parcel in) {
            return new Settings(in);
        }

        public Settings[] newArray(int size) {
            return new Settings[size];
        }
    };
}
