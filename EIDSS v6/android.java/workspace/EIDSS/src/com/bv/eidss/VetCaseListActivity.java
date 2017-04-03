package com.bv.eidss;

import java.io.File;
import java.io.FileOutputStream;
import java.io.OutputStreamWriter;
import java.util.List;

import android.app.Activity;
import android.app.Dialog;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.AdapterView.OnItemSelectedListener;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.CaseSerializer;
import com.bv.eidss.model.CaseStatus;
import com.bv.eidss.model.VetCase;
import com.bv.eidss.model.CaseType;

public class VetCaseListActivity extends EidssBaseBlockTimeoutActivity{
	private static final int IDM_ONLINE = 101;
	private static final int IDM_OFFLINE = 102;
    private final int ERROR_UPLOAD_CASES_DIALOG_ID = 1;
	private int maxCountList;
	private int maxCountPage;
	private int fiterPositon = 0;
	private Activity _this;
	private ListView listView;
	public VetCaseListActivity() {
    	_this = this;
	}
	
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTitle(R.string.TitleVetCaseList);
        setContentView(R.layout.vet_case_list_layout);
   	
        listView = (ListView)findViewById(R.id.List);
        
        EidssDatabase mDb = new EidssDatabase(this);
        List<VetCase> cases = mDb.VetCaseSelect(fiterPositon);
        maxCountList = maxCountPage = mDb.Options().getPageSize();
        mDb.close();
        listView.setAdapter(new VetCaseListAdapter(this, cases, maxCountList));
        
        listView.setOnItemLongClickListener(new ListView.OnItemLongClickListener() {
			@Override
			public boolean onItemLongClick(AdapterView<?> list, View arg1, int position, long arg3) {
				Intent intent = new Intent(getApplicationContext(), VetCaseActivity.class);
				VetCaseListAdapter adapter = (VetCaseListAdapter)list.getAdapter();
				intent.putExtra(EXTRA_ID_VETCASE, ((VetCase)adapter.getItem(position)).getId());
				_this.startActivityForResult(intent, ACTIVITY_ID_VETCASE);
				return false;
			}
		});
    	findViewById(R.id.NewLivestockCaseButton).setOnClickListener(new View.OnClickListener() {
			@Override
			public void onClick(View v) {
				Intent intent = new Intent(getApplicationContext(), VetCaseActivity.class);
				intent.putExtra(EXTRA_ID_VETCASE, (long)0);
				intent.putExtra(EXTRA_ID_MODE, CaseType.LIVESTOCK);
				_this.startActivityForResult(intent, ACTIVITY_ID_VETCASE);
			}
		});
    	findViewById(R.id.NewAvianCaseButton).setOnClickListener(new View.OnClickListener() {
			@Override
			public void onClick(View v) {
				Intent intent = new Intent(getApplicationContext(), VetCaseActivity.class);
				intent.putExtra(EXTRA_ID_VETCASE, (long)0);
				intent.putExtra(EXTRA_ID_MODE, CaseType.AVIAN);
				_this.startActivityForResult(intent, ACTIVITY_ID_VETCASE);
			}
		});
    	registerForContextMenu(findViewById(R.id.SynchronizeCaseButton));
    	findViewById(R.id.SynchronizeCaseButton).setOnClickListener(new View.OnClickListener() {
			@Override
			public void onClick(View v) {
				v.showContextMenu();
			}
		});
    	findViewById(R.id.OkButton).setOnClickListener(new View.OnClickListener() {
			@Override
			public void onClick(View v) {
				_this.finish();
			}
		});
    	findViewById(R.id.ShowMoreButton).setOnClickListener(new View.OnClickListener() {
			@Override
			public void onClick(View v) {
				maxCountList += maxCountPage; 
				Refill();
			}
		});
     
        Spinner spinnerCaseStatusFilter = (Spinner)findViewById(R.id.CaseStatusFilterLookup);
        ArrayAdapter<CharSequence> adapter = ArrayAdapter.createFromResource(this, R.array.CaseStatusFilterItems, android.R.layout.simple_spinner_item);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinnerCaseStatusFilter.setAdapter(adapter);
        spinnerCaseStatusFilter.setOnItemSelectedListener(new OnItemSelectedListener(){
			@Override
			public void onItemSelected(AdapterView<?> parent, View v, int position, long id) {
				fiterPositon = position;
				Refill();
			}
			@Override
			public void onNothingSelected(AdapterView<?> arg0) {
			}});
    }
    
    @Override
    public void onCreateContextMenu(android.view.ContextMenu menu, View v, android.view.ContextMenu.ContextMenuInfo menuInfo) {
    	super.onCreateContextMenu(menu, v, menuInfo);
    	
    	menu.add(Menu.NONE, IDM_ONLINE, Menu.NONE, R.string.OnlineSynMenu);
    	menu.add(Menu.NONE, IDM_OFFLINE, Menu.NONE, R.string.OfflineSynMenu);
    };

    @Override
    public boolean onContextItemSelected(android.view.MenuItem item) {
		Intent intent = new Intent();
    	switch(item.getItemId()){
	    	case IDM_ONLINE:
				intent = intent.setClass(getApplicationContext(), SynchronizeVetCaseActivity.class);
				_this.startActivityForResult(intent, ACTIVITY_ID_SYNCHRONIZE_CASE);
	    		break;
	    	case IDM_OFFLINE:
		    	intent.setClass(getApplicationContext(), FileBrowser.class);
		    	int md = FileBrowser.FILE_BROWSER_MODE_SAVE;     	
		    	intent.putExtra("mode", md);
		    	intent.putExtra("mask", "Cases.eidss");
		    	startActivityForResult(intent, md);
	    		break;
	    	default:
	    		return super.onContextItemSelected(item);
    	}
		return true;
    	
    };
    
    private void Refill() {
        EidssDatabase mDb = new EidssDatabase(_this);
        List<VetCase> cases = mDb.VetCaseSelect(fiterPositon);
        mDb.close();
        listView.setAdapter(new VetCaseListAdapter(_this, cases, maxCountList));
    }

	@Override
    protected Dialog onCreateDialog(int id) {
        switch (id)
        {
            case ERROR_UPLOAD_CASES_DIALOG_ID:
                return EidssAndroidHelpers.ErrorDialog(this, getResources().getString(R.string.ErrorCasesUploaded));
        }
        return null;
    }
    
	@Override
    public void onActivityResult(int requestCode, int resultCode, Intent data)
    {
        if (requestCode == ACTIVITY_ID_VETCASE)
        {
			Refill();
        }
        if (requestCode == ACTIVITY_ID_SYNCHRONIZE_CASE)
        {
            if (resultCode == RESULT_OK)
				Refill();
        }
        if (requestCode == FileBrowser.FILE_BROWSER_MODE_SAVE)
        {       
        	String fullFilename = data.getStringExtra(EXTRA_ID_FILENAME);
        	if (!fullFilename.isEmpty()){
	    		try {
			        EidssDatabase db = new EidssDatabase(this);
			        List<VetCase> vcs = db.VetCaseSelect((long)0);
			        long country = db.GisCountry(db.getCurrentLanguage()).idfsBaseReference;
			        db.close();

			        String content = CaseSerializer.writeVetXml(vcs, country);
	        		File file = new File(fullFilename);
	        		FileOutputStream filecon = new FileOutputStream(file);
	        		OutputStreamWriter writer = new OutputStreamWriter(filecon);
	        		writer.write(content);
	        		writer.close();
	        		filecon.close();
	        		
			        db = new EidssDatabase(this);
			        vcs = db.VetCaseSelect((long)0);
			        for (VetCase vc: vcs){
			        	if (vc.getStatus() == CaseStatus.NEW || vc.getStatus() == CaseStatus.CHANGED){
			        		vc.setStatusUploaded();
		        			db.VetCaseUpdate(vc);
			        	}
			        }
			        db.close();

					Refill();
	    		} catch (Exception e) {
					showDialog(ERROR_UPLOAD_CASES_DIALOG_ID);
					//e.printStackTrace();
				}
        	}
        }

        super.onActivityResult(requestCode, resultCode, data);
    }

}
