package com.bv.eidss;

import java.util.List;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.HumanCase;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Spinner;

public class HumanCaseListActivity extends Activity {

	private Activity _this;
	public HumanCaseListActivity() {
    	_this = this;
	}
	
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTitle(R.string.TitleHumanCaseList);
        setContentView(R.layout.human_case_list_layout);
   	
        final ListView listView = (ListView)findViewById(R.id.List);
        
        EidssDatabase mDb = new EidssDatabase(this);
        List<HumanCase> cases = mDb.HumanCaseSelect(0);
        mDb.close();
        listView.setAdapter(new HumanCaseListAdapter(this, cases));
        
        listView.setOnItemLongClickListener(new ListView.OnItemLongClickListener() {
			@Override
			public boolean onItemLongClick(AdapterView<?> list, View arg1, int position, long arg3) {
				Intent intent = new Intent();
				intent = intent.setClass(getApplicationContext(), HumanCaseActivity.class);
				HumanCaseListAdapter adapter = (HumanCaseListAdapter)list.getAdapter();
				HumanCase hc = (HumanCase)adapter.getItem(position);
				intent = intent.putExtra("hc", hc);
				_this.startActivityForResult(intent, 333);
				return false;
			}
		});
    	findViewById(R.id.NewHumanCaseButton).setOnClickListener(new View.OnClickListener() {
			@Override
			public void onClick(View v) {
				Intent intent = new Intent();
				intent = intent.setClass(getApplicationContext(), HumanCaseActivity.class);
				intent = intent.putExtra("hc", HumanCase.CreateNew());
				_this.startActivityForResult(intent, 333);
			}
		});
    	findViewById(R.id.SynchronizeHumanCaseButton).setOnClickListener(new View.OnClickListener() {
			@Override
			public void onClick(View v) {
				Intent intent = new Intent();
				intent = intent.setClass(getApplicationContext(), SynchronizeHumanCaseActivity.class);
				_this.startActivityForResult(intent, 444);
			}
		});
    	findViewById(R.id.OkButton).setOnClickListener(new View.OnClickListener() {
			@Override
			public void onClick(View v) {
				_this.finish();
			}
		});
     
        Spinner spinnerCaseStatusFilter = (Spinner)findViewById(R.id.CaseStatusFilterLookup);
        //ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, R.array.CaseStatusFilterItems, android.R.layout.simple_spinner_item);
        ArrayAdapter<CharSequence> adapter = ArrayAdapter.createFromResource(this, R.array.CaseStatusFilterItems, android.R.layout.simple_spinner_item);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinnerCaseStatusFilter.setAdapter(adapter);
        spinnerCaseStatusFilter.setOnItemSelectedListener(new OnItemSelectedListener(){
			@Override
			public void onItemSelected(AdapterView<?> parent, View v, int position, long id) {
		        EidssDatabase mDb = new EidssDatabase(_this);
		        List<HumanCase> cases = mDb.HumanCaseSelect(position);
		        mDb.close();
		        listView.setAdapter(new HumanCaseListAdapter(_this, cases));
			}
			@Override
			public void onNothingSelected(AdapterView<?> arg0) {
			}});
    }

	@Override
    public void onActivityResult(int requestCode, int resultCode, Intent data)
    {
        if (requestCode == 333)
        {
            if (resultCode == RESULT_FIRST_USER) // delete
            {
            	HumanCase mCase = (HumanCase)data.getParcelableExtra("hc");
            	EidssDatabase db = new EidssDatabase(this);
                db.HumanCaseDelete(mCase);
                db.close();
                //this.recreate();
                Intent intent = getIntent();
                finish();
                startActivity(intent);
            }
            if (resultCode == RESULT_OK)
            {
            	HumanCase mCase = (HumanCase)data.getParcelableExtra("hc");
            	EidssDatabase db = new EidssDatabase(this);
                if (mCase.getId() == 0)
                {
                    db.HumanCaseInsert(mCase);
                }
                else
                {
                    if (mCase.getCase() != 0)
                        mCase.setStatusChanged();
                    db.HumanCaseUpdate(mCase);
                }
                db.close();
                //this.recreate();
                Intent intent = getIntent();
                finish();
                startActivity(intent);
            }
        }
        if (requestCode == 444)
        {
            if (resultCode == RESULT_OK)
            {
                //this.recreate();
                Intent intent = getIntent();
                finish();
                startActivity(intent);
            }
        }

        super.onActivityResult(requestCode, resultCode, data);
    }
    
}
