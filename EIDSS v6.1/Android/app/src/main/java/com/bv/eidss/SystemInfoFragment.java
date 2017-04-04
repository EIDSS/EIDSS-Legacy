package com.bv.eidss;

import android.content.pm.PackageInfo;
import android.content.pm.PackageManager;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.Options;

import java.text.DateFormat;
import java.util.Date;


public class SystemInfoFragment extends Fragment {

    public static SystemInfoFragment newInstance() {
        return new SystemInfoFragment();
    }

    public SystemInfoFragment() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setHasOptionsMenu(true);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        return inflater.inflate(R.layout.system_info_layout, container, false);
    }

    @Override
    public void onResume() {
        super.onResume();

        // these values can change - so we should fill then in onResume
        EidssDatabase mDb = new EidssDatabase(getActivity());
        Options o = mDb.Options();
/* commented because of new requirements
        //Statistics
        Formatter fmtr = new Formatter();
        long iAll = mDb.HumanCaseCount(0);
        long iSinchronized = mDb.HumanCaseSynchCount();
        String text = fmtr.format(getResources().getString(R.string.HumanCasesTotal), iAll, iSinchronized).toString();
        TextView tv = (TextView) getActivity().findViewById(R.id.HumanCasesTotal);
        tv.setText(text);
        fmtr.close();

        fmtr = new Formatter();
        iAll = mDb.VetCaseCount(0);
        iSinchronized = mDb.VetCaseSynchCount();
        text = fmtr.format(getResources().getString(R.string.VeterinaryCasesTotal), iAll, iSinchronized).toString();
        tv = (TextView) getActivity().findViewById(R.id.VeterinaryCasesTotal);
        tv.setText(text);
        fmtr.close();
*/
        //Dates
        DisplayDateTimeTV(R.id.DateOnlineSynchronization, o.getLastOnlineSyn());
        DisplayDateTimeTV(R.id.DateReferencesUpdate, o.getLastRefUpdt());

        mDb.close();

        //EidssVersion
        String version = "unknown";
        PackageManager manager = getActivity().getPackageManager();
        try {
            PackageInfo info = manager.getPackageInfo(getActivity().getPackageName(), 0);
            version = info.versionName;
        } catch (PackageManager.NameNotFoundException e) {
            Log.d("SystemInfo", e.getMessage());
        }
        TextView tv = (TextView)  getActivity().findViewById(R.id.labelEidssVersion);
        tv.setText(getResources().getString(R.string.Version) + " " + version);
    }

    private void DisplayDateTimeTV(int id, Date dt)
    {
        TextView ed = (TextView)getActivity().findViewById(id);
        if (dt == null) ed.setText("");
        else ed.setText(DateFormat.getDateTimeInstance(DateFormat.MEDIUM, DateFormat.MEDIUM).format(dt));
    }

}
