package com.bv.eidss;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.OutputStreamWriter;
import java.util.Date;
import java.util.List;

import org.xmlpull.v1.XmlPullParserException;

import com.bv.eidss.web.VectorBaseReferenceRaw;
import com.bv.eidss.web.VectorBaseReferenceTranslationRaw;
import com.bv.eidss.web.VectorGisBaseReferenceRaw;
import com.bv.eidss.web.VectorGisBaseReferenceTranslationRaw;
import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.HumanCase;
import com.bv.eidss.model.CaseStatus;
import com.bv.eidss.model.CaseSerializer;
import com.bv.eidss.model.Options;
import com.bv.eidss.model.VetCase;

import android.os.Bundle;
import android.app.Dialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.view.View;

public class OptionsActivity extends EidssBaseBlockTimeoutActivity {
    private final int CONFIRM_DIALOG_ID = 2;
    private final int RESULT_DIALOG_ID = 3;
    private final int ERROR_UPLOAD_CASES_DIALOG_ID = 4;
    private final int ERROR_LOAD_REFERENCE_DIALOG_ID = 5;
    private final int ERROR_OUT_OF_DATE_DIALOG_ID = 6;
    private final int ERROR_WRONG_FORMAT_DIALOG_ID = 7;
    private final int ERROR_SAVE_FILE_DIALOG_ID = 8;
    private final int NEWVERSION_DIALOG_ID = 9;
    private final int REFERENCE_LOADED_DIALOG_ID = 10;
	private OptionsActivity _this;
	public OptionsActivity() {
    	_this = this;
	}

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTitle(R.string.Utilities);
        setContentView(R.layout.options_layout);
   	
    	findViewById(R.id.OnlineSynchronization).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				startActivity((new Intent()).setClass(getApplicationContext(), SynchronizeCasesActivity.class));
			}
		});
    	findViewById(R.id.UnloadCasesFile).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				Intent intent = new Intent();
		    	intent.setClass(getApplicationContext(), FileBrowser.class);
		    	int md = FileBrowser.FILE_BROWSER_MODE_SAVE;     	
		    	intent.putExtra(EXTRA_ID_MODE, md);
		    	intent.putExtra("mask", "Cases.eidss");
		    	startActivityForResult(intent, md);
			}
		});
    	findViewById(R.id.LoadReferencesOnline).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				startActivity((new Intent()).setClass(getApplicationContext(), LoadReferencesActivity.class));
			}
		});
    	findViewById(R.id.LoadReferencesFile).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				Intent intent = new Intent();
		    	intent.setClass(getApplicationContext(), FileBrowser.class);
		    	int md = FileBrowser.FILE_BROWSER_MODE_LOAD;     	
		    	intent.putExtra(EXTRA_ID_MODE, md);
		    	intent.putExtra("mask", "References.eidss");//"References.eidss"
		    	startActivityForResult(intent, md);
			}
		});
    	findViewById(R.id.CheckForUpdates).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				Intent intent = new Intent();
		    	intent.putExtra(EXTRA_ID_MODE, APP_DOWNLOAD_MODE_CHCK);
		    	intent.setClass(getApplicationContext(), AppDownloadActivity.class);
		    	startActivityForResult(intent, ACTIVITY_ID_APP_DOWNLOAD);
			}
		});
    	findViewById(R.id.DeleteSynchronizedCases).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				showDialog(CONFIRM_DIALOG_ID);
			}
		});
    	findViewById(R.id.SetPasswordButton).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				startActivity((new Intent()).setClass(getApplicationContext(), ChangeLocalPasswordActivity.class));
			}
		});
    	findViewById(R.id.Settings).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				startActivity((new Intent()).setClass(getApplicationContext(), SettingsActivity.class));
			}
		});   	
    }	

	@Override
    protected Dialog onCreateDialog(int id) {
        switch (id)
        {
	        case CONFIRM_DIALOG_ID:
                return EidssAndroidHelpers.QuestionDialog(this, getResources().getString(R.string.SynchronizedDeleteConfirm),
                       	new DialogInterface.OnClickListener(){
        						@Override
        						public void onClick(DialogInterface dialog, int which) {
        					        final EidssDatabase db = new EidssDatabase(_this);
        			                db.SinchronizedCasesDelete();
        			                db.close();
        							dialog.dismiss();
        							showDialog(RESULT_DIALOG_ID);
        						}},
                        	new DialogInterface.OnClickListener(){
        						@Override
        						public void onClick(DialogInterface dialog, int which) {
        							dialog.dismiss();
        						}
        					});
            case RESULT_DIALOG_ID:
                return EidssAndroidHelpers.ErrorDialog(this, getResources().getString(R.string.SynchronizedDeleteOk));
            case ERROR_UPLOAD_CASES_DIALOG_ID:
                return EidssAndroidHelpers.ErrorDialog(this, getResources().getString(R.string.ErrorCasesUploaded));
            case ERROR_LOAD_REFERENCE_DIALOG_ID:
                return EidssAndroidHelpers.ErrorDialog(this, getResources().getString(R.string.ErrorRefsLoaded));
            case ERROR_OUT_OF_DATE_DIALOG_ID:
                return EidssAndroidHelpers.ErrorDialog(this, getResources().getString(R.string.ErrorOutOfDate));
            case ERROR_WRONG_FORMAT_DIALOG_ID:
                return EidssAndroidHelpers.ErrorDialog(this, getResources().getString(R.string.ErrorWrongFormat));
            case ERROR_SAVE_FILE_DIALOG_ID:
                return EidssAndroidHelpers.ErrorDialog(this, getResources().getString(R.string.ErrorSaveAppFile));
            case NEWVERSION_DIALOG_ID:
                return EidssAndroidHelpers.MessageDialog(this, getResources().getString(R.string.NewVersionDownloaded));
            case REFERENCE_LOADED_DIALOG_ID:
                return EidssAndroidHelpers.MessageDialog(this, getResources().getString(R.string.ReferencesUpdated));
            case R.string.ConnectionFailed:
            case R.string.LoginFailed:
            case R.string.AccessFailed:
            case R.string.NetworkTimeout:
            case R.string.GeneralError:
	        case R.string.CheckingAborted:
	        case R.string.DownloadingAborted:
	            return EidssAndroidHelpers.ErrorDialog(this, getResources().getString(id));
        }
        return null;
    }
	
	@Override
    public void onActivityResult(int requestCode, int resultCode, Intent data)
    {
        if (requestCode == ACTIVITY_ID_APP_DOWNLOAD) {
        }
        else if (requestCode == FileBrowser.FILE_BROWSER_MODE_SAVE) {       
    		String fullFilename = data.getStringExtra(EXTRA_ID_FILENAME);
        	if (!fullFilename.isEmpty()){
	    		try {
			        EidssDatabase db = new EidssDatabase(this);
			        List<HumanCase> hcs = db.HumanCaseSelect(0, 0);
			        List<VetCase> vcs = db.VetCaseSelect((long)0);
			        long country = db.GisCountry(db.getCurrentLanguage()).idfsBaseReference;
			        db.close();

			        String content = CaseSerializer.writeXml(hcs, vcs, country);
	        		File file = new File(fullFilename);
	        		FileOutputStream filecon = new FileOutputStream(file);
	        		OutputStreamWriter writer = new OutputStreamWriter(filecon);
	        		writer.write(content);
	        		writer.close();
	        		filecon.close();
	        		
			        db = new EidssDatabase(this);
			        hcs = db.HumanCaseSelect(0, 0);
			        vcs = db.VetCaseSelect((long)0);
			        for (HumanCase hc: hcs){
			        	if (hc.getStatus() == CaseStatus.NEW || hc.getStatus() == CaseStatus.CHANGED){
			        		hc.setStatusUploaded();
		        			db.HumanCaseUpdate(hc);
			        	}
			        }
			        for (VetCase vc: vcs){
			        	if (vc.getStatus() == CaseStatus.NEW || vc.getStatus() == CaseStatus.CHANGED){
			        		vc.setStatusUploaded();
		        			db.VetCaseUpdate(vc);
			        	}
			        }
			        db.close();
				} catch (Exception e) {
					showDialog(ERROR_UPLOAD_CASES_DIALOG_ID);
					//e.printStackTrace();
				}
        	}
        }
        else if (requestCode == FileBrowser.FILE_BROWSER_MODE_LOAD) {
        	String fullFilename = data.getStringExtra(EXTRA_ID_FILENAME);
        	try{
		        EidssDatabase db = new EidssDatabase(this);
	        	Options opt = db.Options();
                Date lastUpdate = opt.getLastRefUpdt();
		        db.close();

        		FileInputStream stream = new FileInputStream(fullFilename);
        		Object[] ret = com.bv.eidss.web.RefDeserializer.parseAll(stream);
        		stream.close();
        		Date refDate = (Date)ret[0];
        		if (lastUpdate != null && refDate.after(lastUpdate)){
	        		VectorBaseReferenceRaw refs = (VectorBaseReferenceRaw)ret[1];
	        		VectorBaseReferenceTranslationRaw refs_trans = (VectorBaseReferenceTranslationRaw)ret[2]; 
	        		VectorGisBaseReferenceRaw gis_refs = (VectorGisBaseReferenceRaw)ret[3];
	        		VectorGisBaseReferenceTranslationRaw gis_refs_trans = (VectorGisBaseReferenceTranslationRaw)ret[4];
			        db = new EidssDatabase(this);
			        if (db.LoadReferences(refs, refs_trans, gis_refs, gis_refs_trans)){
			        	opt = db.Options();
		                opt.setLastRefUpdt(new Date());
		                db.OptionsUpdate(opt);
			        }
			        db.close();
    				showDialog(REFERENCE_LOADED_DIALOG_ID);
        		}
        		else{
    				showDialog(ERROR_OUT_OF_DATE_DIALOG_ID);
        		}
        	} 
        	catch(XmlPullParserException e){
				showDialog(ERROR_WRONG_FORMAT_DIALOG_ID);
    		}
        	catch(NullPointerException e){
				showDialog(ERROR_WRONG_FORMAT_DIALOG_ID);
    		}
        	catch(Exception e){
				showDialog(ERROR_LOAD_REFERENCE_DIALOG_ID);
    		}
        }                
    
        super.onActivityResult(requestCode, resultCode, data);
    }
}

