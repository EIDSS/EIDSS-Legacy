package com.bv.eidss;

import java.util.Formatter;
import java.util.List;

import org.ksoap2.SoapFault;

import com.WSParser.WebServices.EidssService.AddressInfo;
import com.WSParser.WebServices.EidssService.BaseReferenceItem;
import com.WSParser.WebServices.EidssService.HumanCaseInfo;
import com.WSParser.WebServices.EidssService.VectorHumanCaseInfo;
import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.HumanCase;
import com.bv.eidss.model.HumanCaseStatus;
import com.bv.eidss.model.Options;
import com.bv.eidss.oa.OaClient;

import android.app.Activity;
import android.app.Dialog;
import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;

public class SynchronizeHumanCaseActivity extends Activity {
    private final int PROGRESS_DIALOG_ID = 0;
    public final int RESULT_DIALOG_ID = 1;
    public ProgressDialog mDialog;
    public int iErr = 0;
    public int iAdded = 0;
    public int iUpdated = 0;
    public int iDeleted = 0;
    public int iFailed = 0;
	
	private SynchronizeHumanCaseActivity _this;
	public SynchronizeHumanCaseActivity() {
    	_this = this;
	}

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTitle(R.string.TitleSynchronizeHumanCases);
        setContentView(R.layout.synchronize_human_case_layout);

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
				new SynchronizeHumanCaseTask().execute(_this);
			}
		});
    	findViewById(R.id.CancelButton).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				_this.setResult(RESULT_CANCELED);
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
            case RESULT_DIALOG_ID:
                return EidssAndroidHelpers.MessageDialog(this, 
                    (new Formatter()).format(_this.getResources().getString(R.string.SynResult), iAdded, iUpdated, iDeleted, iFailed).toString(), 
                	new DialogInterface.OnClickListener(){
						@Override
						public void onClick(DialogInterface dialog, int which) {
							dialog.dismiss();
							_this.setResult(RESULT_OK);
                            _this.finish();
						}
                    });
            case R.string.ConnectionFailed:
            case R.string.LoginFailed:
            case R.string.AccessFailed:
            case R.string.GeneralError:
                return EidssAndroidHelpers.ErrorDialog(this, getResources().getString(id));
    	}
    	return null;
    }
}


final class SynchronizeHumanCaseTask extends AsyncTask<SynchronizeHumanCaseActivity, Void, Void>{
	@Override
	protected Void doInBackground(SynchronizeHumanCaseActivity... params) {
		final SynchronizeHumanCaseActivity activity = params[0];
		activity.iErr = 0;
		
		VectorHumanCaseInfo hcs_out = null;
		List<HumanCase> hcs = null;
		String org = "";
		String usr = "";
		try {
	        EidssDatabase db = new EidssDatabase(activity);
	        String url = db.Options().getServerUrl();
	        String lang = db.getCurrentLanguage(); 
	        hcs = db.HumanCaseSelect(0);
	        db.close();
	        
	        VectorHumanCaseInfo hcs_in = new VectorHumanCaseInfo();
	        for(int i = 0; i < hcs.size(); i++){
	        	HumanCase c = hcs.get(i);
	        	if (c.getStatus() == HumanCaseStatus.NEW || c.getStatus() == HumanCaseStatus.CHANGED){
	        		HumanCaseInfo hci = new HumanCaseInfo();
	        		hci.id = c.getCase();
	        		hci.caseID = c.getCaseID();
	        		hci.offlineCaseID = c.getOfflineCaseID();
	        		hci.localIdentifier = c.getLocalIdentifier();
	        		hci.tentativeDiagnosis = new BaseReferenceItem();
                    hci.tentativeDiagnosis.id = c.getTentativeDiagnosis();
                    
                    hci.setTentativeDiagnosisDate(c.getTentativeDiagnosisDate());
                    hci.firstName = c.getFirstName();
                    hci.lastName = c.getFamilyName();
                    hci.setDateOfBirth(c.getDateofBirth());
                    hci.patientAge = c.getPatientAge();
                    hci.patientAgeType = new BaseReferenceItem();
                    hci.patientAgeType.id = c.getHumanAgeType();
                    hci.patientGender = new BaseReferenceItem(); 
                    hci.patientGender.id = c.getHumanGender();
                    hci.caseStatus = new BaseReferenceItem();
                    hci.caseStatus.id = 10109001; // CaseStatusEnum.InProgress
                    hci.currentResidence = new AddressInfo();
                    hci.currentResidence.country = new BaseReferenceItem(); 
                    hci.currentResidence.country.id = db.GisCountry(db.getCurrentLanguage()).idfsBaseReference;
                    hci.currentResidence.region = new BaseReferenceItem();
                    hci.currentResidence.region.id = c.getRegionCurrentResidence();
                    hci.currentResidence.rayon = new BaseReferenceItem();
                    hci.currentResidence.rayon.id = c.getRayonCurrentResidence();
                    hci.currentResidence.settlement = new BaseReferenceItem();
                    hci.currentResidence.settlement.id = c.getSettlementCurrentResidence();
                    hci.currentResidence.building = c.getBuilding();
                    hci.currentResidence.house = c.getHouse();
                    hci.currentResidence.apartment = c.getApartment();
                    hci.currentResidence.street = c.getStreetName();
                    hci.currentResidence.zipCode = c.getPostCode();
                    hci.currentResidence.homePhone = c.getHomePhone();
                    hci.setOnsetDate(c.getOnSetDate());
                    hci.patientState = new BaseReferenceItem();
                    hci.patientState.id = c.getFinalState();
                    hci.hospitalization = new BaseReferenceItem();
                    hci.hospitalization.id = c.getHospitalizationStatus();
                    
	        		hcs_in.add(hci);
	        	}
	        }

	        org = ((EditText)activity.findViewById(R.id.LoginOrganization)).getText().toString();
	        usr = ((EditText)activity.findViewById(R.id.LoginName)).getText().toString();
	        String pwd = ((EditText)activity.findViewById(R.id.LoginPassword)).getText().toString();
	        OaClient client = new OaClient(url, org, usr, pwd);
	        hcs_out = client.SynchronizeHumanCases(hcs_in, lang);
			if (hcs_out == null){
				activity.iErr = R.string.GeneralError;
			}
		}
		catch(SoapFault e){
			if (e.getMessage().startsWith("org.ksoap2.SoapFault"))
				activity.iErr = R.string.AccessFailed;
			else if (e.getMessage().startsWith("org.ksoap2.serialization.NullSoapObject"))
				activity.iErr = R.string.LoginFailed;
			else
				activity.iErr = R.string.GeneralError;
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

	        activity.iAdded = 0;
            activity.iUpdated = 0;
            activity.iDeleted = 0;
            activity.iFailed = 0;
	        
            for(int i = 0; i < hcs_out.size(); i++){
	        	HumanCaseInfo ci = hcs_out.get(i);
		        for(int j = 0; j < hcs.size(); j++){
		        	HumanCase c = hcs.get(j);
		        	if (ci.offlineCaseID.compareTo(c.getOfflineCaseID()) == 0) {
		        		if (ci.markedToDelete){
		        			activity.iDeleted++;
		        			db.HumanCaseDelete(c);
		        		}
		        		else{
		        			if (ci.lastErrorDescription == null || ci.lastErrorDescription.length() == 0){
                                if (c.getCase() == 0)
                                {
                                	activity.iAdded++;

                                    c.setCase(ci.id);
                                    c.setCaseID(ci.caseID);
                                    c.setNotificationDate(ci.getNotificationDate());
                                    c.setSentByOffice(ci.notificationSentBy.name);
                                    c.setSentByPerson(ci.notificationSentByPerson.name);
                                }
                                else {
                                	activity.iUpdated++;
                                }

                                c.setLastSynError("");
                                c.setStatusSyn();
		        			}
		        			else{
		        				activity.iFailed++;
                                c.setLastSynError(ci.lastErrorDescription);
		        			}
		        			db.HumanCaseUpdate(c);
		        		}
		        	}
		        }
	        }
	        
        	Options opt = db.Options();
            opt.setLoginOrganization(org);
            opt.setLoginUsername(usr);
            db.OptionsUpdate(opt);
            db.close();
			
			activity.mDialog.dismiss();
			activity.runOnUiThread(new Runnable() {
	            @SuppressWarnings("deprecation")
				@Override
	            public void run() {
	            	activity.showDialog(activity.RESULT_DIALOG_ID);
	            }
	        });
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
