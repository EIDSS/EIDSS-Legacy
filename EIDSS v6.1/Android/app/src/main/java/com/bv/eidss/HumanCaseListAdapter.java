package com.bv.eidss;

import java.text.DateFormat;
import java.util.List;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.HumanCase;
import com.bv.eidss.model.CaseStatus;
import com.bv.eidss.utils.EidssUtils;

import android.app.Activity;
import android.view.Menu;

public class HumanCaseListAdapter extends CaseListAdapter<HumanCase> {

    public HumanCaseListAdapter(Activity context, Menu menu, List<HumanCase> items, int maxCount)
    {
        super(context, menu, items, maxCount);
    }

    @Override
    protected int getLayoutId() {
        return R.layout.human_case_item_layout;
    }

    @Override
    protected int getActionBarIconId() {
        return R.drawable.eidss_ic_search_hc_big;
    }

    public void dbCaseDelete()
    {
        EidssDatabase db = new EidssDatabase(context);
        db.HumanCaseDelete(getCheckItemIds());
        db.close();
    }

    protected  void setHolderProperties(ListItemViewHolder holder, HumanCase item) {
        String name = "";
        if (item.getFamilyName() != null) name = name + item.getFamilyName();
        if (item.getFirstName() != null) name = name + " " + item.getFirstName();
        if (item.getSecondName() != null) name = name + " " + item.getSecondName();
        holder.FamilyName.setText(name);
        holder.CaseID.setText(item.getCaseID());
        if (item.getDateofBirth() != null)
            holder.DateOfBirth.setText(DateFormat.getDateInstance(DateFormat.MEDIUM).format(item.getDateofBirth()));
        else
            holder.DateOfBirth.setText("");
        holder.CreatedDate.setText(DateFormat.getDateTimeInstance(DateFormat.MEDIUM, DateFormat.MEDIUM).format(item.getCreateDate()));
        holder.LastSynError.setText(item.getLastSynError());
        if (holder.LastSynError.getText() == null || holder.LastSynError.getText().toString().length() == 0)
            holder.LastSynError.setHeight(0);
        else
            holder.LastSynError.setHeight(74);

        final String lang = EidssUtils.getCurrentLanguage();
        holder.Diagnosis.setText(EidssUtils.getReference(item.getTentativeDiagnosis(), lang));//TentativeDiagnosis(db, item));

        if (item.getStatus() == CaseStatus.NEW)
            holder.Status.setText(R.string.CaseStatusNew);
        else if (item.getStatus() == CaseStatus.SYNCHRONIZED)
            holder.Status.setText(R.string.CaseStatusSynchronized);
        else if (item.getStatus() == CaseStatus.CHANGED)
            holder.Status.setText(R.string.CaseStatusChanged);
        else if (item.getStatus() == CaseStatus.UNLOADED)
            holder.Status.setText(R.string.CaseStatusUnloaded);
        else
            holder.Status.setText("");
    }

    @Override
    protected boolean isNew(HumanCase item){
        return item.getStatus() == CaseStatus.NEW;
    }
}
