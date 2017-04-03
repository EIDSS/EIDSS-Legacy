package com.bv.eidss;

import java.text.DateFormat;
import java.util.Date;

import com.bv.eidss.model.BaseReference;
import com.bv.eidss.model.Species;
import com.bv.eidss.model.VetCase;

import android.app.Activity;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.View;
import android.view.ViewGroup;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.AdapterView.OnItemSelectedListener;

public class SpeciesListAdapter extends ArrayAdapter<Species> {
    private final Activity context;
    private final VetCase mCase;
    private final BaseAdapter adapter;
    private final OnClickListener dtListener;
    private final OnClickListener clrListener;

    public SpeciesListAdapter(Activity context, VetCase cs, BaseAdapter spAdapter, OnClickListener dateListener, OnClickListener clearListener)
    {
    	super(context, R.layout.species_item_layout, cs.species);
        this.context = context;
        this.mCase = cs;
        this.adapter = spAdapter;
        this.dtListener = dateListener;
        this.clrListener = clearListener;
    }
	
	@Override
	public int getCount() {
		return mCase.species.size();
	}

	@Override
	public Species getItem(int position) {
		return mCase.species.get(position);
	}

	@Override
	public long getItemId(int position) {
		return position;
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {
		ListItemViewHolder holder = null;
		final Species item = (Species)mCase.species.get(position);
		
        if (convertView == null){
        	convertView = context.getLayoutInflater().inflate(R.layout.species_item_layout, null);
            holder = new ListItemViewHolder(convertView);

            LookupBind(holder.spin_species_type, item.getSpeciesType(), adapter);
            holder.spin_species_type.setOnItemSelectedListener(new OnItemSelectedListener() {
				public void onItemSelected(AdapterView<?> parent, View vw, int spnPosition, long id) {
					int getPosition = (Integer) parent.getTag();
					Species it = mCase.species.get(getPosition);
					it.setSpeciesType(((BaseReference)parent.getSelectedItem()).idfsBaseReference);
				}
				public void onNothingSelected(AdapterView<?> parent) {
					int getPosition = (Integer) parent.getTag();
					Species it = mCase.species.get(getPosition);
					it.setSpeciesType(0);
				}});

            holder.bt_delete.setOnClickListener(
                    new Button.OnClickListener() {
                        @Override
                        public void onClick(View v) {
                        	if(mCase.species.size() > 1) {
                        		v.requestFocus();
                        		v.requestFocusFromTouch();
	                            Integer pos = (Integer) v.getTag();
	                            mCase.deleteSpecies(pos.intValue());  
	                            notifyDataSetChanged();
                        	}
                        }
                    }
                );;

            holder.bt_date_date.setOnClickListener(dtListener);
            
            holder.bt_date_clear.setOnClickListener(clrListener);

            holder.row_total.addTextChangedListener(new CustomTextWatcher(holder.row_total));
            holder.row_dead.addTextChangedListener(new CustomTextWatcher(holder.row_dead));
            holder.row_sick.addTextChangedListener(new CustomTextWatcher(holder.row_sick));
		        	
            convertView.setTag(holder);
		}
        else{
            holder = (ListItemViewHolder) convertView.getTag();
        }
        

        DisplayDate(holder.date, item.getStartOfSignsDate());
        holder.row_total.setId(R.id.Total);
        holder.row_total.setTag(position);
        holder.row_total.setText(Integer.toString(item.getTotalAnimalQty()));
        holder.row_dead.setId(R.id.Dead);
        holder.row_dead.setTag(position);
        holder.row_dead.setText(Integer.toString(item.getDeadAnimalQty()));
        holder.row_sick.setId(R.id.Sick);
        holder.row_sick.setTag(position);
        holder.row_sick.setText(Integer.toString(item.getSickAnimalQty()));
        holder.bt_delete.setTag(position);
        holder.bt_date_clear.setTag(position);
        holder.bt_date_date.setTag(position);
        
        holder.spin_species_type.setSelection(SpeciesType(holder.spin_species_type, item));
        holder.spin_species_type.setTag(position);

		mCase.species_selection = position;
        return convertView;
	}
	
    private int SpeciesType(Spinner sp, Species item)
    { 
    	BaseReferenceAdapter br = (BaseReferenceAdapter)sp.getAdapter();
        for(int i = 0; i < br.getCount(); i++){
    		BaseReference bri = (BaseReference)br.getItem(i);
        	if (bri.idfsBaseReference == item.getSpeciesType())
        		return i;
         }
        return 0;
    }
    
    private void LookupBind(final Spinner sp, long def, BaseAdapter adapter)
    {
        sp.setAdapter(adapter);
        for(int i = 0; i < adapter.getCount(); i++){
        	if (((BaseReference)adapter.getItem(i)).idfsBaseReference == def){
        		sp.setSelection(i);
        		break;
        	}
        }
    }
	
    protected void DisplayDate(EditText ed, Date dt)
    {
        if (dt == null) ed.setText("");
        else ed.setText(DateFormat.getDateInstance(DateFormat.MEDIUM).format(dt));
    }

    static class ListItemViewHolder {

        public Spinner spin_species_type;
        public Button bt_delete;
        public Button bt_date_clear;
        public Button bt_date_date;
        public EditText date;
        public EditText row_total;
        public EditText row_dead;
        public EditText row_sick;

        public ListItemViewHolder(View convertView) {
            spin_species_type = (Spinner) convertView .findViewById(R.id.SpeciesTypeLookup);
            bt_delete = (Button) convertView .findViewById(R.id.DeleteSpecies);
            bt_date_clear = (Button) convertView .findViewById(R.id.StartOfSignsClearButton);
            bt_date_date = (Button) convertView .findViewById(R.id.StartOfSignsButton);
            date = (EditText) convertView .findViewById(R.id.StartOfSigns);
            row_total = (EditText) convertView .findViewById(R.id.Total);
            row_dead = (EditText) convertView .findViewById(R.id.Dead);
            row_sick = (EditText) convertView .findViewById(R.id.Sick);
        }
    }
    
    private class CustomTextWatcher implements TextWatcher {

        private EditText EditText; 

        public CustomTextWatcher(EditText e)
        {
            this.EditText = e;
        }

        @Override
        public void afterTextChanged(Editable arg0) {

            String text = arg0.toString();

            if(text != null)
            {
                int val;
                
                if (text.compareTo("0") == 0){
                	this.EditText.setText("");
                }
                
                try
                {
                    val = Integer.parseInt(text);
                }
                catch(NumberFormatException e)
                {
                    val = 0;
                }
                Integer pos = (Integer) EditText.getTag();
                if(EditText.getId() == R.id.Total)
                {
                	mCase.species.get(pos.intValue()).setTotalAnimalQty(val);
                }
                else if(EditText.getId() == R.id.Dead)
                {
                	mCase.species.get(pos.intValue()).setDeadAnimalQty(val);
                }
                else if(EditText.getId() == R.id.Sick)
                {
                	mCase.species.get(pos.intValue()).setSickAnimalQty(val);
                }
            }
        }

		@Override
		public void beforeTextChanged(CharSequence arg0, int arg1, int arg2, int arg3) {
		}

		@Override
		public void onTextChanged(CharSequence arg0, int arg1, int arg2,int arg3) {
		}
     } 
}
