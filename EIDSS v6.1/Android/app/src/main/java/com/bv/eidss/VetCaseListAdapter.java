package com.bv.eidss;

import java.text.DateFormat;
import java.util.List;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.CaseStatus;
import com.bv.eidss.model.CaseType;
import com.bv.eidss.model.VetCase;

import android.app.Activity;
import android.view.Menu;

public class VetCaseListAdapter extends CaseListAdapter<VetCase> {

    public VetCaseListAdapter(Activity context, Menu menu, List<VetCase> items, int maxCount)
    {
        super(context, menu, items, maxCount);
    }

    @Override
    protected int getLayoutId() {
        return R.layout.vet_case_item_layout;
    }

    @Override
    protected int getActionBarIconId() {
        return R.drawable.eidss_ic_search_vc_big;
    }

    @Override
    protected void dbCaseDelete()
    {
        EidssDatabase db = new EidssDatabase(context);
        db.VetCaseDelete(getCheckItemIds());
        db.close();
    }

    @Override
    protected  void setHolderProperties(ListItemViewHolder holder, VetCase item) {
        holder.CaseID.setText(item.getCaseID());
        holder.CreatedDate.setText(DateFormat.getDateTimeInstance(DateFormat.MEDIUM, DateFormat.MEDIUM).format(item.getCreateDate()));
        holder.LastSynError.setText(item.getLastSynError());

        if (item.getCaseType() ==  CaseType.LIVESTOCK)
            holder.Image.setImageResource(R.drawable.eidss_ic_lvsc_big);
        else
            holder.Image.setImageResource(R.drawable.eidss_ic_avc_big);
        holder.FarmAddress.setText(item.getAddress());
        holder.Diagnosis.setText(item.getStrTentativeDiagnosis());
        if (holder.LastSynError.getText() == null || holder.LastSynError.getText().toString().length() == 0)
            holder.LastSynError.setHeight(0);

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
    protected boolean isNew(VetCase item){
        if (item.getStatus() == CaseStatus.NEW)
            return true;
        return false;
    }
}
