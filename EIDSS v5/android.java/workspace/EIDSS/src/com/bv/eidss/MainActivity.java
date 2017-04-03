package com.bv.eidss;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.HumanCase;

import android.os.Bundle;
import android.app.Activity;
import android.content.Intent;
import android.view.View;

//import android.widget.Button;
//import android.view.Menu;

public class MainActivity extends Activity {

	private Activity _this;
	public MainActivity() {
    	_this = this;
	}

	@Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTitle(R.string.TitleMainMenu);
        setContentView(R.layout.activity_main);

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
    	findViewById(R.id.HumanCaseListButton).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				_this.startActivity((new Intent()).setClass(getApplicationContext(), HumanCaseListActivity.class));
			}
		});
    	findViewById(R.id.NewHumanCaseButton).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				Intent intent = new Intent();
				intent = intent.setClass(getApplicationContext(), HumanCaseActivity.class);
				intent = intent.putExtra("hc", HumanCase.CreateNew());
				_this.startActivityForResult(intent, 333);
			}
		});
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data)
    {
        if (requestCode == 333)
        {
            if (resultCode == RESULT_OK)
            {
            	HumanCase mCase = (HumanCase)data.getParcelableExtra("hc");
            	EidssDatabase db = new EidssDatabase(this);
                db.HumanCaseInsert(mCase);
                db.close();
            }
        }
        super.onActivityResult(requestCode, resultCode, data);
    }

}
