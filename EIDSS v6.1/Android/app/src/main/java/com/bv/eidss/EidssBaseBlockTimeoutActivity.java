package com.bv.eidss;

import com.bv.eidss.data.EidssDatabase;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.ActionBarActivity;
import android.text.format.Time;

public class EidssBaseBlockTimeoutActivity extends ActionBarActivity {
	public static Time timeOfUnderground = new Time();
	public static int timeoutLock = 0;
    private String sLang;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        sLang = EidssAndroidHelpers.SetLocale();
    }

    @Override
    protected void onStart(){
        String sLangNew = EidssDatabase.GetOptions().getDefLang();
        if (sLangNew.compareTo(sLang) != 0){
            finish();
            startActivity(getIntent());
        }
        super.onStart();
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data)
    {
        if (requestCode == getResources().getInteger(R.integer.ACTIVITY_ID_LOCAL_LOGIN))
        {
            if (resultCode != RESULT_OK)
            {
                Intent a = new Intent(this, StartActivity.class);
                a.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_CLEAR_TOP);
                startActivity(a);
                
                moveTaskToBack(true);
             	finish();
            }
        }
        super.onActivityResult(requestCode, resultCode, data);
    }
    
    @Override
    protected void onPause()
    {
    	super.onPause();
    	//remember when we (maybe) go to background
    	timeOfUnderground.setToNow();
    	
    	//Log.d(this.getTitle().toString(), "onPause timeOfUnderground = " + timeOfUnderground.format("%H:%M:%S"));
    }
    
    @Override
    protected void onRestart()
    {
    	super.onRestart();
    	//check if the time in background is more then allowed
    	if(timeoutLock == 0)
    	{
    		EidssDatabase db = new EidssDatabase(this);
    		timeoutLock = db.Options().getLockTimeout();
    		db.close();
    	}
    	Time now = new Time();
    	now.setToNow();
    	now.set(now.second, now.minute-timeoutLock, now.hour, now.monthDay, now.month, now.year);
    	now.normalize(true);
    	
    	//Log.d(this.getTitle().toString(), "onRestart now=" + now.format("%H:%M:%S") + " timeOfUnderground = " + timeOfUnderground.format("%H:%M:%S"));
    	if (Time.compare(now, timeOfUnderground) > 0)
    	{
			Intent intent = new Intent();
			intent = intent.setClass(getApplicationContext(), LocalLoginActivity.class);
			startActivityForResult(intent, getResources().getInteger(R.integer.ACTIVITY_ID_LOCAL_LOGIN));
  		}
    }
}
