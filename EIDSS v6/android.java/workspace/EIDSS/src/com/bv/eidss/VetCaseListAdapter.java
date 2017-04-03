package com.bv.eidss;

import java.text.DateFormat;
import java.util.List;

import com.bv.eidss.model.CaseStatus;
import com.bv.eidss.model.VetCase;

import android.app.Activity;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

public class VetCaseListAdapter extends BaseAdapter {

    private List<VetCase> items;
    private Activity context;
    private int maxItemsCount;

    
    public VetCaseListAdapter(Activity context, List<VetCase> items, int maxCount)
    {
    	super();
        this.context = context;
        this.items = items;
        this.maxItemsCount = maxCount; 
    }
	
	@Override
	public int getCount() {
		return Math.min(maxItemsCount, items.size());
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
		VetCase item = (VetCase)items.get(position);
        View view;
        if (convertView != null) view = convertView;
        else view = context.getLayoutInflater().inflate(R.layout.vet_case_item_layout, null);
        TextView fm = (TextView)view.findViewById(R.id.FarmAddress);
        TextView d = (TextView)view.findViewById(R.id.Diagnosis);
        TextView cs = (TextView)view.findViewById(R.id.CaseID);
        TextView ct = (TextView)view.findViewById(R.id.CaseType);
        TextView st = (TextView)view.findViewById(R.id.Status);
        TextView cr = (TextView)view.findViewById(R.id.CreatedDate);
        TextView er = (TextView)view.findViewById(R.id.LastSynError);
        cs.setText(item.getCaseID());
        cr.setText(DateFormat.getDateTimeInstance(DateFormat.MEDIUM, DateFormat.MEDIUM).format(item.getCreateDate()));
        er.setText(item.getLastSynError());
        ct.setText(item.getStrCaseType());
        fm.setText(item.getAddress());
        d.setText(item.getStrTentativeDiagnosis());
        if (er.getText() == null || er.getText().toString() == null || er.getText().toString().length() == 0)
            er.setHeight(0);
        else
            er.setHeight(74);

        if (item.getStatus() == CaseStatus.NEW)
            st.setText(R.string.CaseStatusNew);
        else if (item.getStatus() == CaseStatus.SYNCHRONIZED)
            st.setText(R.string.CaseStatusSynchronized);
        else if (item.getStatus() == CaseStatus.CHANGED)
            st.setText(R.string.CaseStatusChanged);
        else if (item.getStatus() == CaseStatus.UNLOADED)
            st.setText(R.string.CaseStatusUnloaded);
        else
            st.setText("");

        return view;
	}
	
}
