package com.bv.eidss;

import java.text.DateFormat;
import java.util.Date;
import java.util.List;

import android.text.InputFilter;
import android.text.Spanned;
import android.view.MotionEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.View.OnTouchListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ScrollView;
import android.widget.Spinner;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.TextView;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.BaseReference;
import com.bv.eidss.model.GisBaseReference;

public class EidssBaseBindableActivity extends EidssBaseBlockTimeoutActivity {

	protected EidssBaseBindableActivity _this;
	public EidssBaseBindableActivity() {
    	_this = this;
	}
	
	abstract static interface OnEditTextChangeListener
	{
		public abstract void onEditTextChanged(String text);
	}
	
	protected void Back()
    {
        super.onBackPressed();
    }
	
    protected void DisplayDate(int id, Date dt)
    {
    	EditText ed = (EditText)findViewById(id);
        if (dt == null) ed.setText("");
        else ed.setText(DateFormat.getDateInstance(DateFormat.MEDIUM).format(dt));
    }
	
    protected void DisplayDateTV(int id, Date dt)
    {
    	TextView ed = (TextView)findViewById(id);
        if (dt == null) ed.setText("");
        else ed.setText(DateFormat.getDateInstance(DateFormat.MEDIUM).format(dt));
    }
	
    protected void DisplayDateTime(int id, Date dt)
    {
    	EditText ed = (EditText)findViewById(id);
        if (dt == null) ed.setText("");
        else ed.setText(DateFormat.getDateTimeInstance(DateFormat.MEDIUM, DateFormat.MEDIUM).format(dt));
    }
	
    protected void DisplayDateTimeTV(int id, Date dt)
    {
    	TextView ed = (TextView)findViewById(id);
        if (dt == null) ed.setText("");
        else ed.setText(DateFormat.getDateTimeInstance(DateFormat.MEDIUM, DateFormat.MEDIUM).format(dt));
    }

    protected void LookupBind(int id, long def, long rft, int ha, OnItemSelectedListener listener, boolean bEnabled)
    {
    	final Spinner sp = (Spinner)findViewById(id);
        final ScrollView mScroller = (ScrollView)findViewById(R.id.Scroll);
    	EidssDatabase mDb = new EidssDatabase(this);
        List<BaseReference> list = mDb.Reference(rft, mDb.getCurrentLanguage(), ha);
        mDb.close();
        sp.setAdapter(new BaseReferenceAdapter(this, list));
        for(int i = 0; i < list.size(); i++){
        	if (list.get(i).idfsBaseReference == def){
        		sp.setSelection(i);
        		break;
        	}
        }
        sp.setOnItemSelectedListener(listener);
        sp.setEnabled(bEnabled);
        sp.setOnTouchListener(new OnTouchListener(){
			public boolean onTouch(View arg0, MotionEvent arg1) {
				mScroller.requestChildFocus(sp, sp);
				return false;
			}});
    }

    protected void LookupBind(int id, List<GisBaseReference> list, long def, OnItemSelectedListener listener, boolean bEnabled)
    {
    	final Spinner sp = (Spinner)findViewById(id);
        final ScrollView mScroller = (ScrollView)findViewById(R.id.Scroll);
        sp.setAdapter(new GisBaseReferenceAdapter(this, list));
        for(int i = 0; i < list.size(); i++){
        	if (list.get(i).idfsBaseReference == def){
        		sp.setSelection(i);
        		break;
        	}
        }
        if (listener != null)
        	sp.setOnItemSelectedListener(listener);
        sp.setEnabled(bEnabled);
        sp.setOnTouchListener(new OnTouchListener(){
			public boolean onTouch(View arg0, MotionEvent arg1) {
				mScroller.requestChildFocus(sp, sp);
				return false;
			}});
    }

    protected void EditTextBind(int id, String def, final OnEditTextChangeListener listener, boolean bEnabled)
    {
    	final EditText ed = (EditText)findViewById(id);
        ed.setText(def);
        ed.setEnabled(bEnabled);
        if (listener != null){
        	InputFilter[] f = ed.getEditableText().getFilters();
        	int length = f == null ? 0 : f.length;
        	InputFilter f1 = new InputFilter(){
				@Override
				public CharSequence filter(CharSequence source, int start, int end, Spanned dest, int dstart, int dend)  {
					String text = dest.toString();
					text = text.substring(0, dstart) + source.toString() + text.substring(dend, text.length());
					listener.onEditTextChanged(text);
					return source;
				}};
			InputFilter[] f2 = new InputFilter[length + 1];
			int i = 0;
			for(; i < length; i++){
				f2[i] = f[i];
			}
			f2[i] = f1;
			ed.getEditableText().setFilters(f2);
        	
        	/*ed.setOnFocusChangeListener(new OnFocusChangeListener(){
        		public void onFocusChange(View v, boolean hasFocus) {
        			if (!hasFocus) 
        				listener.onEditTextChanged(ed.getText().toString());
        		}});*/
        }
        
    }

    
    protected void DateBind(int edit_id, int btn_id, int btn_clr, OnClickListener act_clr, Date def, final int dlg)
    {
        DisplayDate(edit_id, def);
        if (btn_id != 0)
        {
        	Button bt = (Button)findViewById(btn_id);
        	bt.setOnClickListener(new OnClickListener(){
				public void onClick(View arg0) {
					_this.showDialog(dlg);
				}});
        }
        if (btn_clr != 0)
        {
        	Button bt = (Button)findViewById(btn_clr);
        	bt.setOnClickListener(act_clr);
        }
    }
    
    protected void DateTimeBind(int edit_id, Date def)
    {
        DisplayDateTime(edit_id, def);
    }


}
