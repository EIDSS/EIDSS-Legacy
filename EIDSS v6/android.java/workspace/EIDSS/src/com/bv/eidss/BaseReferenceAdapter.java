package com.bv.eidss;

import java.util.List;

import com.bv.eidss.model.BaseReference;

import android.app.Activity;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

public class BaseReferenceAdapter extends BaseAdapter {

    private List<BaseReference> items;
    private Activity context;
    public BaseReferenceAdapter(Activity context, List<BaseReference> items)
    {
    	super();
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
		BaseReference item = (BaseReference)items.get(position);
        View view;
        if (convertView != null) view = convertView;
        else view = context.getLayoutInflater().inflate(R.layout.lookup_layout, null);
        TextView tv = (TextView)view.findViewById(R.id.LookupText);
        tv.setText(item.name);
        return view;
	}

}
