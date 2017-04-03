package com.bv.eidss;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.CaseType;
import com.bv.eidss.model.Options;
import com.bv.eidss.model.HumanCase;

import android.os.Bundle;
import android.app.Activity;
import android.content.Intent;
import android.widget.Button;
import android.view.View;

public class MainActivity extends EidssBaseBlockTimeoutActivity
{
	public static int ApplicationMode=APPLICATION_MODE_NOT_INITIALIZED;

	private Activity _this;
	
	public MainActivity() {
    	_this = this;
	}

	@Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTitle(R.string.TitleMainMenu);
        setContentView(R.layout.activity_main);
        
    	EidssDatabase mDb = new EidssDatabase(this);
        if(ApplicationMode==APPLICATION_MODE_NOT_INITIALIZED)
        {
        	Options o = mDb.Options();
        	ApplicationMode = o.getApplicationMode();
        }   	
    	mDb.close();

    	findViewById(R.id.ExitButton).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				_this.finish();
			}
		});
    	
    	findViewById(R.id.OptionsButton).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				_this.startActivity((new Intent()).setClass(getApplicationContext(), OptionsActivity.class));
			}
    	});
    	
    	findViewById(R.id.SystemInfoButton).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				_this.startActivity((new Intent()).setClass(getApplicationContext(), SystemInfoActivity.class));
			}
		});
		
    	findViewById(R.id.HumanCaseListButton).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				_this.startActivity((new Intent()).setClass(getApplicationContext(), HumanCaseListActivity.class));
			}
		});
    	findViewById(R.id.NewHumanCaseButton).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				Intent intent = new Intent();
				intent = intent.setClass(getApplicationContext(), HumanCaseActivity.class);
				intent = intent.putExtra(EXTRA_ID_HUMANCASE, HumanCase.CreateNew());
				_this.startActivityForResult(intent, ACTIVITY_ID_HUMANCASE);
			}
		});    	
    	
    	findViewById(R.id.VeterinaryCaseListButton).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				_this.startActivity((new Intent()).setClass(getApplicationContext(), VetCaseListActivity.class));
			}
		});
    	findViewById(R.id.NewLivestockCaseButton).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				Intent intent = new Intent(getApplicationContext(), VetCaseActivity.class);
				intent.putExtra(EXTRA_ID_VETCASE, (long)0);
				intent.putExtra(EXTRA_ID_MODE, CaseType.LIVESTOCK);
				_this.startActivityForResult(intent, ACTIVITY_ID_VETCASE);
			}
		});    	
    	findViewById(R.id.NewAvianCaseButton).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				Intent intent = new Intent(getApplicationContext(), VetCaseActivity.class);
				intent.putExtra(EXTRA_ID_VETCASE, (long)0);
				intent.putExtra(EXTRA_ID_MODE, CaseType.AVIAN);
				_this.startActivityForResult(intent, ACTIVITY_ID_VETCASE);
			}
		});    	

    	/*
    	 // FILE BROWSER TEST
    	Intent intent = new Intent();
    	intent.setClass(getApplicationContext(), FileBrowser.class);
    	int md = FileBrowser.FILE_BROWSER_MODE_LOAD;     	
    	intent.putExtra("mode", md);
    	intent.putExtra("mask", "*.txt");
    	startActivityForResult(intent, md); 
    	*/    	
    	
    	/*
    	 // GEO LOCATION    	
    	Intent intent = new Intent();
    	intent.setClass(getApplicationContext(), GeoLocationHelper.class);
    	startActivityForResult(intent, GEOLOCATION_GET_COORDINATES);
    	*/
	}
	
	@Override
    protected void onResume() {
        super.onResume();
        
    	final Button btnHumanCaseList = (Button)findViewById(R.id.HumanCaseListButton);
    	final Button btnHumanCase = (Button)findViewById(R.id.NewHumanCaseButton);
    	final Button btnVeterinaryCaseList = (Button)findViewById(R.id.VeterinaryCaseListButton);
    	final Button btnAvianCase = (Button)findViewById(R.id.NewAvianCaseButton);
    	final Button btnLivestockCase = (Button)findViewById(R.id.NewLivestockCaseButton);
        if(ApplicationMode == APPLICATION_MODE_HUMAN)
        {
           	btnHumanCaseList.setVisibility(View.VISIBLE);
           	btnHumanCase.setVisibility(View.VISIBLE);
        	btnVeterinaryCaseList.setVisibility(View.GONE);
        	btnAvianCase.setVisibility(View.GONE);
        	btnLivestockCase.setVisibility(View.GONE);
        }
        else if(ApplicationMode == APPLICATION_MODE_VETERINARY)
        {
           	btnHumanCaseList.setVisibility(View.GONE);
           	btnHumanCase.setVisibility(View.GONE);
        	btnVeterinaryCaseList.setVisibility(View.VISIBLE);
        	btnAvianCase.setVisibility(View.VISIBLE);
        	btnLivestockCase.setVisibility(View.VISIBLE);
        }
        else if(ApplicationMode == APPLICATION_MODE_BOTH)
        {
           	btnHumanCaseList.setVisibility(View.VISIBLE);
           	btnHumanCase.setVisibility(View.VISIBLE);
        	btnVeterinaryCaseList.setVisibility(View.VISIBLE);
        	btnAvianCase.setVisibility(View.VISIBLE);
        	btnLivestockCase.setVisibility(View.VISIBLE);
        }
	}    

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data)
    {
        if (requestCode == FileBrowser.FILE_BROWSER_MODE_SAVE)
        {       	
        	String file = data.getStringExtra(EXTRA_ID_FILENAME);			
        	System.out.println(file);
        }
        else if (requestCode == FileBrowser.FILE_BROWSER_MODE_LOAD)
        {
        	String file = data.getStringExtra(EXTRA_ID_FILENAME);	
        	System.out.println(file);
        }
        else if (requestCode == GEOLOCATION_GET_COORDINATES)
        {        	
        	GeoCoordinates coords = data.getParcelableExtra(EXTRA_ID_COORDINATES);
        	System.out.println(coords.Latitude);
        	System.out.println(coords.Longitude);        	
        }      
    
        super.onActivityResult(requestCode, resultCode, data);
    } 
   
    
}
