package com.bv.eidss;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ListAdapter;


import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.Options;
import com.bv.eidss.model.VetCase;
import com.bv.eidss.model.VetCaseSample;
import com.bv.eidss.model.interfaces.IGet;
import com.bv.eidss.model.interfaces.IToChange;

import java.io.Serializable;


public class VetCaseSamplesFragment extends CheckableListFragment
            implements IToChange {

    public VetCaseSamplesFragment() {
        // Required empty public constructor
    }

    public static VetCaseSamplesFragment newInstance() {
        return new VetCaseSamplesFragment();
    }

    @Override
    public void onActivityCreated(Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);

        setListAdapter(new VetCaseSamplesListAdapter(this, mCase()));
    }

    /* Called whenever we call invalidateOptionsMenu() */
    @Override
    public void onPrepareOptionsMenu(Menu menu) {
        final VetCaseSamplesListAdapter adapter = GetAdapter();
        if (adapter != null)
            adapter.updateMenuVisibility(menu);

        super.onPrepareOptionsMenu(menu);
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent intent) {
        if (requestCode == getResources().getInteger(R.integer.ACTIVITY_ID_SAMPLE)) {
            if (resultCode == Activity.RESULT_OK) {
                int position = intent.getIntExtra("position", -1);
                final VetCaseSample gotit = intent.getParcelableExtra(getResources().getString(R.string.EXTRA_ID_ITEM));
                if (position >= 0) {
                    final VetCaseSamplesListAdapter list = GetAdapter();
                    if (list != null) {
                        final VetCaseSample it = list.getItem(position);
                        if (it != null) {
                            it.setSampleType(gotit.getSampleType());
                            it.setFieldBarcode(gotit.getFieldBarcode());
                            it.setAnimal(gotit.getAnimal());
                            it.setSpeciesType(gotit.getSpeciesType());
                            it.setBirdStatus(gotit.getBirdStatus());
                            it.setFieldCollectionDate(gotit.getFieldCollectionDate());
                            it.setSendToOffice(gotit.getSendToOffice());
                            updateListItemAtPosition(position);
                        }
                    }
                }
                else {
                    mCase().samples.add(gotit);
                    ((VetCaseSamplesListAdapter) getListView().getAdapter()).notifyDataSetChanged();
                }
            }
        }
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {

        switch (item.getItemId()) {
            case R.id.CreateNew:
                final VetCaseSample it = VetCaseSample.CreateNew(mCase().getId());
                final Intent intent = new Intent(getActivity(), VetCaseSampleActivity.class);
                intent.putExtra(getResources().getString(R.string.EXTRA_ID_ITEM), it);
                intent.putExtra(getResources().getString(R.string.EXTRA_ID_MODE), mCase().IsLivestockCase());
                if (mCase().IsLivestockCase())
                    intent.putExtra(getResources().getString(R.string.EXTRA_ID_ITEMS), (Serializable) mCase().getAnimals(getActivity()));
                else
                    intent.putExtra(getResources().getString(R.string.EXTRA_ID_ITEMS), (Serializable) mCase().getSpecies(getActivity()));
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
                final int sel = ((VetCaseSamplesListAdapter) getListView().getAdapter()).getCheckItemsCount();
                if(sel == 0) {
                    EidssAndroidHelpers.AlertOkDialog.Show(mActivity.getSupportFragmentManager(), R.string.NothingToDelete);
                    return true;
                }
                //EidssAndroidHelpers.AlertOkResultDialog.ShowQuestion(getActivity().getSupportFragmentManager(), Species_binding.datStartOfSignsDate_DialogID,
                //        (new Formatter()).format(getActivity().getResources().getString(R.string.ConfirmToDeleteSpecies), sel).toString());
                DeleteVetCaseSamples();
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }

    protected VetCaseSamplesListAdapter GetAdapter() {
        if(getListView() !=null)    {
            ListAdapter adapter = getListView().getAdapter();
            if (adapter != null && adapter instanceof VetCaseSamplesListAdapter) {
                return (VetCaseSamplesListAdapter) adapter;
            }
        }
        return null;
    }

    public void updateListItemAtPosition(int position) {
        int visiblePosition = getListView().getFirstVisiblePosition();
        View view = getListView().getChildAt(position - visiblePosition);
        getListView().getAdapter().getView(position, view, getListView());
    }

    public void DeleteVetCaseSamples()
    {
        ((VetCaseSamplesListAdapter)getListView().getAdapter()).DeleteVetCaseSamples();
    }

    private VetCase mCase() {
        return (VetCase)((IGet)mActivity).get();
    }
}
