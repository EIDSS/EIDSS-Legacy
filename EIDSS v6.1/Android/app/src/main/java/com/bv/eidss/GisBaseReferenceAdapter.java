package com.bv.eidss;

import java.util.List;

import com.bv.eidss.model.GisBaseReference;

import android.app.Activity;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

public class GisBaseReferenceAdapter extends ArrayAdapter<Object> {

    final private List<GisBaseReference> items;
    final private Activity context;
    public GisBaseReferenceAdapter(Activity context, List<GisBaseReference> items)
    {
    	super(context, R.layout.custom_spinner);
        super.setDropDownViewResource(R.layout.custom_spinner_item);

        this.context = context;
        this.items = items;
    }
	
	@Override
	public int getCount() {
		return items.size();
	}

	@Override
	public Object getItem(int position) {
		return items.get(position);
	}

	@Override
	public long getItemId(int position) {
		return position;
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {
		GisBaseReference item = items.get(position);
        if (convertView == null)
            convertView = context.getLayoutInflater().inflate(R.layout.custom_spinner, null);//must be null
        TextView tv = (TextView)convertView.findViewById(android.R.id.text1);
        tv.setText(item.name);
        return convertView;
	}

}
