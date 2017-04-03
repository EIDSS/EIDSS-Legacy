package com.bv.eidss;

import java.util.Formatter;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.Options;

import android.os.Bundle;
import android.widget.TextView;

public class SystemInfoActivity extends EidssBaseBindableActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        
        setTitle(R.string.SystemInfo);
        setContentView(R.layout.system_info_layout);
/*       
        //Copyright
        TextView textv = (TextView) findViewById(R.id.Copyright);
        Time now = new Time();
        now.setToNow();
        Formatter fmtr = new Formatter();
        String text = fmtr.format(getResources().getString(R.string.Copyright), now.year).toString();
        fmtr.close();
        textv.setText(text);
        
        //EidssVersion
        textv = (TextView) findViewById(R.id.labelEidssVersion);
        textv.setText(getResources().getString(R.string.ApplicationName) + " " + getResources().getString(R.string.Version));
        
        EidssDatabase mDb = new EidssDatabase(this);
        Options o = mDb.Options();
        String vers = o.getEidssVersion();
        ((TextView)findViewById(R.id.EidssVersion)).setText(vers);
        
        mDb.close();
*/        
    }
    
    @Override
    protected void onResume() {
        super.onResume();
        
        // these values can change - so we should fill then in onResume
        EidssDatabase mDb = new EidssDatabase(this);
        Options o = mDb.Options();
        
        //Statistics
        Formatter fmtr = new Formatter();
        long iAll = mDb.HumanCaseCount(0);
        long iSinchronized = mDb.HumanCaseSynchCount();
        String text = fmtr.format(getResources().getString(R.string.HumanCasesTotal), iAll, iSinchronized).toString();
        TextView tv = (TextView) findViewById(R.id.HumanCasesTotal);
        tv.setText(text);
        fmtr.close();
        
        fmtr = new Formatter();
        iAll = mDb.VetCaseCount(0);
        iSinchronized = mDb.VetCaseSynchCount();
        text = fmtr.format(getResources().getString(R.string.VeterinaryCasesTotal), iAll, iSinchronized).toString();
        tv = (TextView) findViewById(R.id.VeterinaryCasesTotal);
        tv.setText(text);
        fmtr.close();
        
        //Dates
        DisplayDateTimeTV(R.id.DateOnlineSynchronization, o.getLastOnlineSyn());
        DisplayDateTimeTV(R.id.DateReferencesUpdate, o.getLastRefUpdt());
        
        mDb.close();
    }

}
