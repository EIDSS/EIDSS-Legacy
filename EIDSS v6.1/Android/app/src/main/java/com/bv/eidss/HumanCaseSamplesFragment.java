package com.bv.eidss;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ListAdapter;


import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.HumanCase;
import com.bv.eidss.model.HumanCaseSample;
import com.bv.eidss.model.Options;
import com.bv.eidss.model.interfaces.IGet;
import com.bv.eidss.model.interfaces.IToChange;


public class HumanCaseSamplesFragment extends CheckableListFragment
            implements IToChange {

    public HumanCaseSamplesFragment() {
        // Required empty public constructor
    }

    public static HumanCaseSamplesFragment newInstance() {
        return new HumanCaseSamplesFragment();
    }

    @Override
    public void onActivityCreated(Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);

        setListAdapter(new HumanCaseSamplesListAdapter(this, mCase()));
    }

    /* Called whenever we call invalidateOptionsMenu() */
    @Override
    public void onPrepareOptionsMenu(Menu menu) {
        final HumanCaseSamplesListAdapter adapter = GetAdapter();
        if (adapter != null)
            adapter.updateMenuVisibility(menu);

        super.onPrepareOptionsMenu(menu);
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent intent) {
        if (requestCode == getResources().getInteger(R.integer.ACTIVITY_ID_SAMPLE)) {
            if (resultCode == Activity.RESULT_OK) {
                int position = intent.getIntExtra("position", -1);
                final HumanCaseSample gotit = intent.getParcelableExtra(getResources().getString(R.string.EXTRA_ID_ITEM));
                if (position >= 0) {
                    final HumanCaseSamplesListAdapter list = GetAdapter();
                    if (list != null) {
                        final HumanCaseSample it = list.getItem(position);
                        if (it != null) {
                            it.setSampleType(gotit.getSampleType());
                            it.setFieldBarcode(gotit.getFieldBarcode());
                            it.setFieldCollectionDate(gotit.getFieldCollectionDate());
                            it.setSendToOffice(gotit.getSendToOffice());
                            it.setFieldSentDate(gotit.getFieldSentDate());
                            updateListItemAtPosition(position);
                        }
                    }
                }
                else {
                    mCase().samples.add(gotit);
                    ((HumanCaseSamplesListAdapter) getListView().getAdapter()).notifyDataSetChanged();
                }
            }
        }
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {

        switch (item.getItemId()) {
            case R.id.CreateNew:
                final HumanCaseSample it = HumanCaseSample.CreateNew(mCase().getId());
                for (HumanCaseSample other:mCase().samples) {
                    if (other.getSendToOffice() != 0L) {
                        it.setSendToOffice(other.getSendToOffice());
                        break;
                    }
                }

                final Intent intent = new Intent(getActivity(), HumanCaseSampleActivity.class);
                intent.putExtra(getResources().getString(R.string.EXTRA_ID_ITEM), it);
                EidssDatabase db = new EidssDatabase(getActivity());
                Options opt = db.Options();
                if(opt.getFltrByDgn())
                    intent.putExtra("diagnosis", mCase().getTentativeDiagnosis());
                else
                    intent.putExtra("diagnosis", 0L);
                db.close();
                startActivityForResult(intent, getResources().getInteger(R.integer.ACTIVITY_ID_SAMPLE));
                return true;
            case R.id.Remove:
                final int sel = ((HumanCaseSamplesListAdapter) getListView().getAdapter()).getCheckItemsCount();
                if(sel == 0) {
                    EidssAndroidHelpers.AlertOkDialog.Show(mActivity.getSupportFragmentManager(), R.string.NothingToDelete);
                    return true;
                }
                //EidssAndroidHelpers.AlertOkResultDialog.ShowQuestion(getActivity().getSupportFragmentManager(), Species_binding.datStartOfSignsDate_DialogID,
                //        (new Formatter()).format(getActivity().getResources().getString(R.string.ConfirmToDeleteSpecies), sel).toString());
                DeleteHumanCaseSamples();
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }

    protected HumanCaseSamplesListAdapter GetAdapter() {
        if(getListView() !=null)    {
            ListAdapter adapter = getListView().getAdapter();
            if (adapter != null && adapter instanceof HumanCaseSamplesListAdapter) {
                return (HumanCaseSamplesListAdapter) adapter;
            }
        }
        return null;
    }

    public void updateListItemAtPosition(int position) {
        int visiblePosition = getListView().getFirstVisiblePosition();
        View view = getListView().getChildAt(position - visiblePosition);
        getListView().getAdapter().getView(position, view, getListView());
    }

    public void DeleteHumanCaseSamples()
    {
        ((HumanCaseSamplesListAdapter)getListView().getAdapter()).DeleteHumanCaseSamples();
    }

    private HumanCase mCase() {
        return (HumanCase)((IGet)mActivity).get();
    }
}
