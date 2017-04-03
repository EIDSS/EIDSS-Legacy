package com.bv.eidss;
import java.util.List;

import android.location.Criteria;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.content.Context;
import android.content.Intent;

public class GeoLocationHelper extends EidssBaseActivity {
	
	private GeoCoordinates CurrentCoords;
	
	@Override
    protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState); 
		try
		{
			CurrentCoords = new GeoCoordinates();
		
			Criteria criteria = new Criteria();
			criteria.setAccuracy(Criteria.ACCURACY_FINE);
			//criteria.setPowerRequirement(Criteria.POWER_LOW);
			//TODO какие ещё критерии нужны?		
		
			/* settings window
			if (!enabled) {
				  Intent intent = new Intent(Settings.ACTION_LOCATION_SOURCE_SETTINGS);
				  startActivity(intent);
				} 
			*/
			
			LocationManager manager = (LocationManager)getSystemService(Context.LOCATION_SERVICE); 
			Intent intent = new Intent();
			intent.putExtra(EXTRA_ID_COORDINATES, CurrentCoords);
			List<String> allProviders = manager.getProviders(criteria, false);
			if (allProviders.size() > 0){
				String provider = allProviders.get(0);
				if (manager.isProviderEnabled(provider))
				{
					manager.requestLocationUpdates(provider, 100, 1, locationListener);					
				}
			}			
		}
		catch(Exception exc){
			System.out.println(exc.getMessage());
			//TODO
		}		
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
			// TODO Auto-generated method stub
			
		}

		@Override
		public void onProviderEnabled(String provider) {
			// TODO Auto-generated method stub
			
		}

		@Override
		public void onStatusChanged(String provider, int status, Bundle extras) {
			// TODO Auto-generated method stub
			
		}
	};
}
