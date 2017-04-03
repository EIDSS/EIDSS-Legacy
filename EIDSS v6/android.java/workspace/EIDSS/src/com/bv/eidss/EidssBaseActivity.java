package com.bv.eidss;

import android.app.Activity;

public class EidssBaseActivity extends Activity {
	public static final int RESULT_DELETE = RESULT_FIRST_USER + 1;
	
	public static final int PASSWORD_MIN_LENGTH = 4;
	
	public static final int ACTIVITY_ID_LOCAL_LOGIN = 1;
	public static final int ACTIVITY_ID_SET_LOCAL_PASSWORD = 2;
	public static final int ACTIVITY_ID_MAIN = 3;
	public static final int ACTIVITY_ID_LOAD_REFERENCES = 4;
	public static final int ACTIVITY_ID_HUMANCASE = 5;
	public static final int ACTIVITY_ID_VETCASE = 6;
	public static final int ACTIVITY_ID_SYNCHRONIZE_CASE = 7;	
	public static final int ACTIVITY_ID_APP_DOWNLOAD = 8;	
	
	public static final String FILE_TO_UPPER_DIR = "..";
	public static final int FILE_BROWSER_MODE_LOAD = 1001;
	public static final int FILE_BROWSER_MODE_SAVE = 1002;

	public static final int APP_DOWNLOAD_MODE_CHCK = 1001;
	public static final int APP_DOWNLOAD_MODE_REFS = 1002;
	public static final int APP_DOWNLOAD_MODE_CASE = 1003;
	
	public static final int APPLICATION_MODE_NOT_INITIALIZED = 0;
	public static final int APPLICATION_MODE_HUMAN = 1;
	public static final int APPLICATION_MODE_VETERINARY = 2;
	public static final int APPLICATION_MODE_BOTH = 3;
	
	public static final String EXTRA_ID_HUMANCASE = "hc";
	public static final String EXTRA_ID_VETCASE = "vc";
	public static final String EXTRA_ID_FILENAME = "filename";
	public static final String EXTRA_ID_COORDINATES = "coordinates";
	public static final String EXTRA_ID_MODE = "mode";
	
	public static final int GEOLOCATION_GET_COORDINATES = 1100;
}
