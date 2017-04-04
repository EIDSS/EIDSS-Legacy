package com.bv.eidss;

import android.app.Activity;
import android.view.Menu;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.ASSession;
import com.bv.eidss.model.CaseStatus;

import java.text.DateFormat;
import java.util.List;

public class ASSessionListAdapter extends CaseListAdapter<ASSession> {

    public ASSessionListAdapter(Activity context, Menu menu, List<ASSession> items, int maxCount)
    {
        super(context, menu, items, maxCount);
    }

    @Override
    protected int getLayoutId() {
        return R.layout.assession_item_layout;
    }

    @Override
    protected int getActionBarIconId() {
        return R.drawable.eidss_ic_search_as_big;
    }

    @Override
    protected void dbCaseDelete()
    {
        EidssDatabase db = new EidssDatabase(context);
        db.ASSessionDelete(getCheckItemIds());
        db.close();
    }

    @Override
    protected  void setHolderProperties(ListItemViewHolder holder, ASSession item) {
        holder.CaseID.setText(item.getMonitoringSessionID());
        //holder.CreatedDate.setText(DateFormat.getDateTimeInstance(DateFormat.MEDIUM, DateFormat.MEDIUM).format(item.getCreateDate()));
        holder.LastSynError.setText(item.getLastSynError());
        holder.Image.setImageResource(R.drawable.eidss_ic_as_big);

        holder.FarmAddress.setText(item.getAddress());
        String strStartEndDate =
                (item.getStartDate() == null ? "" : DateFormat.getDateInstance(DateFormat.SHORT).format(item.getStartDate())) +
                " - " +
                (item.getEndDate() == null ? "" : DateFormat.getDateInstance(DateFormat.SHORT).format(item.getEndDate()));
        holder.StartEndDate.setText(strStartEndDate);
        holder.SessionStatus.setText(item.getSesionStatus());
        holder.CampaignName.setText(item.getCampaignName());

        if (holder.LastSynError.getText() == null || holder.LastSynError.getText().toString() == null || holder.LastSynError.getText().toString().length() == 0)
            holder.LastSynError.setHeight(0);
        else
            holder.LastSynError.setHeight(74);

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
    protected boolean isNew(ASSession item){
        if (item.getStatus() == CaseStatus.NEW)
            return true;
        return false;
    }

}
