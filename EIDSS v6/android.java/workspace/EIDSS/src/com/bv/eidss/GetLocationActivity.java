package com.bv.eidss;

import java.util.List;
import java.util.Timer;
import java.util.TimerTask;

import android.location.Criteria;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.app.Activity;
import android.app.Dialog;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;

public class GetLocationActivity extends EidssBaseBlockTimeoutActivity {
    private final int PROGRESS_DIALOG_ID = 0;
    private int iErr = 0;
    private ProgressDialog mDialog;
	private GetLocationActivity _this;
	private GeoCoordinates CurrentCoords;
	private LocationManager manager;
	private Timer longTimer;
    private int timeoutMs = 120000; // 2 min
	
	public GetLocationActivity() {
    	_this = this;
	}

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
		CurrentCoords = new GeoCoordinates();
		
		Criteria criteria = new Criteria();
		criteria.setAccuracy(Criteria.ACCURACY_FINE);

		manager = (LocationManager)getSystemService(Context.LOCATION_SERVICE); 
		Intent intent = new Intent();
		intent.putExtra(EXTRA_ID_COORDINATES, CurrentCoords);
		List<String> allProviders = manager.getProviders(criteria, false);
		if (allProviders.size() > 0){
			String provider = allProviders.get(0);
			if (manager.isProviderEnabled(provider)){
				manager.requestLocationUpdates(provider, 100, 1, locationListener);
			}
			else{
				iErr = R.string.LocatingUnavailable;
			}
		}			
		else{
			iErr = R.string.LocatingUnavailable;
		}
		if (iErr == 0){
			setupLongTimeout(timeoutMs); 
			showDialog(PROGRESS_DIALOG_ID);
		}
		else{
        	showDialog(iErr);
		}
    }	
    
	@Override
	protected void onStop() {
		manager.removeUpdates(locationListener);
		super.onStop();
	};

	synchronized void setupLongTimeout(long timeout) {
		if(longTimer != null) {
			longTimer.cancel();
			longTimer = null;
			}
		if(longTimer == null) {
			longTimer = new Timer();
			longTimer.schedule(new TimerTask() {
				public void run() {
					longTimer.cancel();
					longTimer = null;

					mDialog.dismiss();
					runOnUiThread(new Runnable() {
						@Override
			            public void run() {
			            	showDialog(R.string.LocatingAbortedByTimeout);
			            }
			        });
					}
				}, timeout  
				);
		}
	}
    
	@Override
    protected Dialog onCreateDialog(int id) {
        switch (id)
        {
			case PROGRESS_DIALOG_ID:
				mDialog = EidssAndroidHelpers.ProgressDialog(this, R.string.WaitLocating, new DialogInterface.OnClickListener(){
	    			public void onClick(DialogInterface dialog, int which) {
	    				longTimer.cancel();
	    				longTimer = null;
	    				
						mDialog.dismiss();
		            	showDialog(R.string.LocatingAborted);
	    			}});
				return mDialog;
            case R.string.LocationGeneralError:
	        case R.string.LocatingAborted:
	        case R.string.LocatingAbortedByTimeout:
	        case R.string.LocatingUnavailable:
				_this.setResult(Activity.RESULT_CANCELED);
	            return EidssAndroidHelpers.ErrorDialogAndFinishActivity(this, getResources().getString(id));
        }
        return null;
    }
	
	private final LocationListener locationListener = new LocationListener() {
		public void onLocationChanged(Location location) {
			if (location != null)
			{
				CurrentCoords.Latitude = location.getLatitude();
				CurrentCoords.Longitude = location.getLongitude();
				CurrentCoords.Altitude = location.getAltitude();
				Intent intent = new Intent();
				intent.putExtra(EXTRA_ID_COORDINATES, CurrentCoords);
				setResult(RESULT_OK, intent);
				finish();
			}
		}

		@Override
		public void onProviderDisabled(String provider) {
		}

		@Override
		public void onProviderEnabled(String provider) {
		}

		@Override
		public void onStatusChanged(String provider, int status, Bundle extras) {
		}
	};

}
