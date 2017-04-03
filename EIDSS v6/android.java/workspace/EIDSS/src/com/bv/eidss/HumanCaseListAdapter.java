package com.bv.eidss;

import java.text.DateFormat;
import java.util.List;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.BaseReference;
import com.bv.eidss.model.BaseReferenceType;
import com.bv.eidss.model.CaseTypeHACode;
import com.bv.eidss.model.HumanCase;
import com.bv.eidss.model.CaseStatus;

import android.app.Activity;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

public class HumanCaseListAdapter extends BaseAdapter {

    private List<HumanCase> items;
    private Activity context;
    private int maxItemsCount;
    public HumanCaseListAdapter(Activity context, List<HumanCase> items, int maxCount)
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
        HumanCase item = (HumanCase)items.get(position);
        View view;
        if (convertView != null) view = convertView;
        else view = context.getLayoutInflater().inflate(R.layout.human_case_item_layout, null);
        TextView fm = (TextView)view.findViewById(R.id.FamilyName);
        TextView d = (TextView)view.findViewById(R.id.Diagnosis);
        TextView cs = (TextView)view.findViewById(R.id.CaseID);
        TextView st = (TextView)view.findViewById(R.id.Status);
        TextView br = (TextView)view.findViewById(R.id.DateofBirth);
        TextView cr = (TextView)view.findViewById(R.id.CreatedDate);
        TextView er = (TextView)view.findViewById(R.id.LastSynError);
        String name = "";
        if (item.getFamilyName() != null) name = name + item.getFamilyName();
        if (name.length() > 0) name = name + " ";
        if (item.getFirstName() != null) name = name + item.getFirstName();
        fm.setText(name);
        cs.setText(item.getCaseID());
        if (item.getDateofBirth() != null)
            br.setText(DateFormat.getDateInstance(DateFormat.MEDIUM).format(item.getDateofBirth()));
        else 
        	br.setText("");
        cr.setText(DateFormat.getDateTimeInstance(DateFormat.MEDIUM, DateFormat.MEDIUM).format(item.getCreateDate()));
        er.setText(item.getLastSynError());
        if (er.getText() == null || er.getText().toString() == null || er.getText().toString().length() == 0)
            er.setHeight(0);
        else
            er.setHeight(74);
        
        EidssDatabase db = new EidssDatabase(this.context);
        d.setText(TentativeDiagnosis(db, item));
        db.close();

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
	
    private String TentativeDiagnosis(EidssDatabase db, HumanCase item)
    { 
    	List<BaseReference> list = db.Reference(BaseReferenceType.rftDiagnosis, db.getCurrentLanguage(), CaseTypeHACode.HUMAN);
        for(int i = 0; i < list.size(); i++){
        	if (list.get(i).idfsBaseReference == item.getTentativeDiagnosis()){
        		return list.get(i).name;
        	}
        }
        return "";
    }
	

}
