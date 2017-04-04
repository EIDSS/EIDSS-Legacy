package com.bv.eidss;

import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.util.Log;

import com.bv.eidss.model.interfaces.LocationResultListener;
import com.bv.eidss.utils.DateHelpers;

import java.util.Timer;
import java.util.TimerTask;

public class GeoLocationHelper {
    private static final int OLD_LOCATION = 1000 * 60 * 10;
    private static final int ACCURACY_DELTA = 200;
    private static final int GPS_TIMEOUT = 1000 * 10;

	private final LocationListener mGpsLocationListener;
	private final LocationListener mNetworkLocationListener;
	private LocationResultListener mLocationResultListener;
	private LocationManager mLocationManager;
	private Timer mTimer;
    private ProgressDialog progressDialog;

	private boolean mGpsEnabled;
	private boolean mNetworkEnabled;
	private Location bestLoc = null;

	public GeoLocationHelper() {
		mGpsLocationListener = new LocationListener() {
			@Override
			public void onLocationChanged(Location location) {
				//mTimer.cancel();
				mLocationManager.removeUpdates(this);
				//mLocationManager.removeUpdates(mNetworkLocationListener);
				//mLocationResultListener.onLocationResultAvailable(location);

                if(isBetterLocation(location, bestLoc))
                    bestLoc = location;
			}

			@Override
			public void onStatusChanged(String s, int i, Bundle bundle) {
			}

			@Override
			public void onProviderEnabled(String s) {
			}

			@Override
			public void onProviderDisabled(String s) {
			}
		};

		mNetworkLocationListener = new LocationListener() {
			@Override
			public void onLocationChanged(Location location) {
				//mTimer.cancel();
				mLocationManager.removeUpdates(this);
				//mLocationManager.removeUpdates(mGpsLocationListener);
				//mLocationResultListener.onLocationResultAvailable(location);
                if(isBetterLocation(location, bestLoc))
                    bestLoc = location;
			}

			@Override
			public void onStatusChanged(String s, int i, Bundle bundle) {
			}

			@Override
			public void onProviderEnabled(String s) {
			}

			@Override
			public void onProviderDisabled(String s) {
			}
		};
	}

	public boolean getLocation(Activity activity, LocationResultListener locationListener) {
		mLocationResultListener = locationListener;
		if (mLocationManager == null)
			mLocationManager = (LocationManager) activity.getSystemService(Context.LOCATION_SERVICE);

		try {
			mGpsEnabled = mLocationManager.isProviderEnabled(LocationManager.GPS_PROVIDER);
		} catch (Exception ex) {
            Log.d("GoLocationHelper", ex.getMessage());
        }

		try {
			mNetworkEnabled = mLocationManager.isProviderEnabled(LocationManager.NETWORK_PROVIDER);
        } catch (Exception ex) {
            Log.d("GoLocationHelper", ex.getMessage());
        }

		if (!mGpsEnabled && !mNetworkEnabled)
			return false;

        getLastKnownLocation();

        // we have already new location
        if(bestLoc != null && DateHelpers.Now().getTime() - bestLoc.getTime() < OLD_LOCATION){
            mLocationResultListener.onLocationResultAvailable(bestLoc);
            return true;
        }



        if (mGpsEnabled)
			mLocationManager.requestLocationUpdates(LocationManager.GPS_PROVIDER, 0, 0, mGpsLocationListener);

		if (mNetworkEnabled)
			mLocationManager.requestLocationUpdates(LocationManager.NETWORK_PROVIDER, 0, 0, mNetworkLocationListener);

		mTimer = new Timer();

		mTimer.schedule(new LastLocationFetcher(), GPS_TIMEOUT);

        progressDialog = EidssAndroidHelpers.ProgressDialog(activity, R.string.WaitLocating, new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int which) {
                stopGetLocation();
            }
        });

        return true;
	}

    public void stopGetLocation(){
        // stop timer and listening
        mTimer.cancel();
        mLocationManager.removeUpdates(mGpsLocationListener);
        mLocationManager.removeUpdates(mNetworkLocationListener);
        progressDialog.dismiss();
    }

	private class LastLocationFetcher extends TimerTask {

		@Override
		public void run() {
            stopGetLocation();

            getLastKnownLocation();

            mLocationResultListener.onLocationResultAvailable(bestLoc);
 		}
	}

    private void getLastKnownLocation(){
        Location gpsLoc = null, netLoc = null;

        // if we had GPS enabled, get the last known location from GPS provider
        if (mGpsEnabled)
            gpsLoc = mLocationManager.getLastKnownLocation(LocationManager.GPS_PROVIDER);

        // if we had WiFi enabled, get the last known location from Network provider
        if (mNetworkEnabled)
            netLoc = mLocationManager.getLastKnownLocation(LocationManager.NETWORK_PROVIDER);


        if (gpsLoc != null) {
            if(isBetterLocation(gpsLoc, bestLoc))
                bestLoc = gpsLoc;
        }

        if (netLoc != null) {
            if(isBetterLocation(netLoc, bestLoc))
                bestLoc = netLoc;
        }

    }

    /** Determines whether one Location reading is better than the current Location fix
     * @param location  The new Location that you want to evaluate
     * @param currentBestLocation  The current Location fix, to which you want to compare the new one
     */
    protected boolean isBetterLocation(Location location, Location currentBestLocation) {
        if (currentBestLocation == null) {
            // A new location is always better than no location
            return true;
        }

        // Check whether the new location fix is newer or older
        long timeDelta = location.getTime() - currentBestLocation.getTime();
        boolean isSignificantlyNewer = timeDelta > OLD_LOCATION;
        boolean isSignificantlyOlder = timeDelta < -OLD_LOCATION;
        boolean isNewer = timeDelta > 0;

        // If it's been more than two minutes since the current location, use the new location
        // because the user has likely moved
        if (isSignificantlyNewer) {
            return true;
            // If the new location is more than two minutes older, it must be worse
        } else if (isSignificantlyOlder) {
            return false;
        }

        // Check whether the new location fix is more or less accurate
        int accuracyDelta = (int) (location.getAccuracy() - currentBestLocation.getAccuracy());
        boolean isLessAccurate = accuracyDelta > 0;
        boolean isMoreAccurate = accuracyDelta < 0;
        boolean isSignificantlyLessAccurate = accuracyDelta > ACCURACY_DELTA;

        // Check if the old and new location are from the same provider
        boolean isFromSameProvider = isSameProvider(location.getProvider(),
                currentBestLocation.getProvider());

        // Determine location quality using a combination of timeliness and accuracy
        if (isMoreAccurate) {
            return true;
        } else if (isNewer && !isLessAccurate) {
            return true;
        } else if (isNewer && !isSignificantlyLessAccurate && isFromSameProvider) {
            return true;
        }
        return false;
    }

    /** Checks whether two providers are the same */
    private boolean isSameProvider(String provider1, String provider2) {
        if (provider1 == null) {
            return provider2 == null;
        }
        return provider1.equals(provider2);
    }
}
