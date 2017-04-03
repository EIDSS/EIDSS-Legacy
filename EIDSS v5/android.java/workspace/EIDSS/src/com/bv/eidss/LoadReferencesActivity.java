package com.bv.eidss;

import com.WSParser.WebServices.EidssService.VectorBaseReferenceRaw;
import com.WSParser.WebServices.EidssService.VectorBaseReferenceTranslationRaw;
import com.WSParser.WebServices.EidssService.VectorGisBaseReferenceRaw;
import com.WSParser.WebServices.EidssService.VectorGisBaseReferenceTranslationRaw;
import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.Options;
import com.bv.eidss.oa.OaClient;
import android.app.Activity;
import android.app.Dialog;
import android.app.ProgressDialog;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;

public class LoadReferencesActivity extends Activity {
    private final int PROGRESS_DIALOG_ID = 0;
    public ProgressDialog mDialog;
    public int iErr = 0;
	
	private LoadReferencesActivity _this;
	public LoadReferencesActivity() {
    	_this = this;
	}

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTitle(R.string.TitleLoadReferences);
        setContentView(R.layout.load_references_layout);

        EidssDatabase db = new EidssDatabase(_this);
        String org = db.Options().getLoginOrganization();
        String usr = db.Options().getLoginUsername();
        ((EditText)findViewById(R.id.LoginOrganization)).setText(org);
        ((EditText)findViewById(R.id.LoginName)).setText(usr);
        db.close();
        
    	findViewById(R.id.OkButton).setOnClickListener(new View.OnClickListener() {
			@SuppressWarnings("deprecation")
			public void onClick(View v) {
				_this.showDialog(PROGRESS_DIALOG_ID);
				new LoadReferenceTask().execute(_this);
			}
		});
    	findViewById(R.id.CancelButton).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				_this.finish();
			}
		});
    }

    @Override
    protected Dialog onCreateDialog(int id) {
    	switch(id)
    	{
    		case PROGRESS_DIALOG_ID:
    			mDialog = ProgressDialog.show(this, "", getResources().getString(R.string.WaitLoading), true);
    			return mDialog;
            case R.string.ConnectionFailed:
            case R.string.LoginFailed:
            case R.string.AccessFailed:
                return EidssAndroidHelpers.ErrorDialog(this, getResources().getString(id));
    	}
    	return null;
    }
}


final class LoadReferenceTask extends AsyncTask<LoadReferencesActivity, Void, Void>{
	@Override
	protected Void doInBackground(LoadReferencesActivity... params) {
		final LoadReferencesActivity activity = params[0];
		activity.iErr = 0;
		VectorBaseReferenceRaw refs = null;
		VectorBaseReferenceTranslationRaw refs_trans = null; 
		VectorGisBaseReferenceRaw gis_refs = null;
		VectorGisBaseReferenceTranslationRaw gis_refs_trans = null;
		String org = "";
		String usr = "";
		try {
	        EidssDatabase db = new EidssDatabase(activity);
	        String url = db.Options().getServerUrl();
	        db.close();
	        org = ((EditText)activity.findViewById(R.id.LoginOrganization)).getText().toString();
	        usr = ((EditText)activity.findViewById(R.id.LoginName)).getText().toString();
	        String pwd = ((EditText)activity.findViewById(R.id.LoginPassword)).getText().toString();
	        OaClient client = new OaClient(url, org, usr, pwd);
	        refs = client.LoadReferences();
	        refs_trans = client.LoadReferenceTranslations();
	        gis_refs = client.LoadGisReferences();
	        gis_refs_trans = client.LoadGisReferenceTranslations();
		}
		catch(ClassCastException e){
			if (e.getMessage().startsWith("org.ksoap2.SoapFault"))
				activity.iErr = R.string.AccessFailed;
			else if (e.getMessage().startsWith("org.ksoap2.serialization.NullSoapObject"))
				activity.iErr = R.string.LoginFailed;
		}
		catch(Exception e){
			activity.iErr = R.string.ConnectionFailed;
		}

		if (activity.iErr == 0){
	        EidssDatabase db = new EidssDatabase(activity);
	        if (db.LoadReferences(refs, refs_trans, gis_refs, gis_refs_trans)){
	        	Options opt = db.Options();
                opt.setLoginOrganization(org);
                opt.setLoginUsername(usr);
                db.OptionsUpdate(opt);
	        }
	        db.close();
			
			activity.mDialog.dismiss();
			activity.finish();
		}
		else{
			activity.mDialog.dismiss();
			activity.runOnUiThread(new Runnable() {
	            @SuppressWarnings("deprecation")
				@Override
	            public void run() {
	            	activity.showDialog(activity.iErr);
	            }
	        });
		}
		return null;
	}
}
