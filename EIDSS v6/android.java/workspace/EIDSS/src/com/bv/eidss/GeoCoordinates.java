package com.bv.eidss;

import android.os.Parcel;
import android.os.Parcelable;

public class GeoCoordinates implements Parcelable {
	public double Latitude;
	public double Longitude;
	public double Altitude;	
	
	public GeoCoordinates(){		
		Latitude = Longitude = Altitude = 0;
	}

	@Override
	public int describeContents() {		
		return 0;
	}

	@Override
	public void writeToParcel(Parcel parcel, int i) {
		parcel.writeDouble(Latitude);
		parcel.writeDouble(Longitude);
		parcel.writeDouble(Altitude);			
	}
	
	public static final Parcelable.Creator<GeoCoordinates> CREATOR = new Parcelable.Creator<GeoCoordinates>() {
		 
	    public GeoCoordinates createFromParcel(Parcel in) {
	      return new GeoCoordinates(in);
	    }
	 
	    public GeoCoordinates[] newArray(int size) {
	      return new GeoCoordinates[size];
	    }
	 };
	
	 private GeoCoordinates(Parcel in) {
		this.Latitude = in.readDouble();
		this.Longitude = in.readDouble();
		this.Altitude = in.readDouble();		
	 }
}
