package com.bv.eidss;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ListAdapter;


import com.bv.eidss.model.BaseReference;
import com.bv.eidss.model.Species;
import com.bv.eidss.model.interfaces.IGet;
import com.bv.eidss.model.interfaces.ISpeciesParent;
import com.bv.eidss.model.interfaces.IToChange;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;


public class SpeciesesFragment extends CheckableListFragment
            implements IToChange {

    public SpeciesesFragment() {
        // Required empty public constructor
    }

    private Class<?> _clsForNewOrEdit;
    private ArrayList<BaseReference> _listSpeciesTypes = new ArrayList<BaseReference>();
    private Object _parent;
    public Class<?> getClsForNewOrEdit(){
        return _clsForNewOrEdit;
    }
    public static SpeciesesFragment newInstance(Class<?> clsForNewOrEdit, ArrayList<BaseReference> listSpeciesTypes, Object parent) {
        SpeciesesFragment ret = new SpeciesesFragment();
        ret._clsForNewOrEdit = clsForNewOrEdit;
        ret._listSpeciesTypes = listSpeciesTypes == null ? new ArrayList<BaseReference>() : listSpeciesTypes;
        ret._parent = parent;
        return ret;
    }

    @Override
    public void onActivityCreated(Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);

        setListAdapter(new SpeciesListAdapter(this, mCase(), _listSpeciesTypes));
    }

    /* Called whenever we call invalidateOptionsMenu() */
    @Override
    public void onPrepareOptionsMenu(Menu menu) {
        if (mCase().IsASSession()) {
            MenuItem button = menu.findItem(R.id.Save);
            if (button != null)
                button.setVisible(false);
            button = menu.findItem(R.id.Refresh);
            if (button != null)
                button.setVisible(false);
        }
        final SpeciesListAdapter adapter = GetAdapter();
        if (adapter != null)
            adapter.updateMenuVisibility(menu);

        super.onPrepareOptionsMenu(menu);
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent intent) {
        if (requestCode == getResources().getInteger(R.integer.ACTIVITY_ID_SPECIES)) {
            if (resultCode == Activity.RESULT_OK) {
                int position = intent.getIntExtra("position", -1);
                final Species gotit = intent.getParcelableExtra(getResources().getString(R.string.EXTRA_ID_ITEM));
                if (position >= 0) {
                    final SpeciesListAdapter list = GetAdapter();
                    if (list != null) {
                        final Species it = list.getItem(position);
                        if (it != null) {
                            it.SetFromAnother(gotit);
                            updateListItemAtPosition(position);
                        }
                    }
                }
                else {
                    mCase().getSpecies().add(gotit);
                    ((SpeciesListAdapter) getListView().getAdapter()).notifyDataSetChanged();
                }
            }
        }
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {

        switch (item.getItemId()) {
            case R.id.CreateNew:
                final Species it = Species.CreateNew(mCase().getId(), mCase().IsLivestockCase());
                final Intent intent = new Intent(getActivity(), _clsForNewOrEdit);
                intent.putExtra(getResources().getString(R.string.EXTRA_ID_ITEM), it);
                intent.putExtra(getResources().getString(R.string.EXTRA_ID_ITEMS), (Serializable) mCase().getSpeciesTypes(0L));
                intent.putExtra(getResources().getString(R.string.EXTRA_ID_MODE), mCase().IsASSession() ? 0 : ( mCase().IsLivestockCase() ? 1 : 2));
                intent.putParcelableArrayListExtra(getResources().getString(R.string.EXTRA_ID_LIST), _listSpeciesTypes);
                startActivityForResult(intent, getResources().getInteger(R.integer.ACTIVITY_ID_SPECIES));
                return true;
            case R.id.Remove:
                final int sel = ((SpeciesListAdapter) getListView().getAdapter()).getCheckItemsCount();
                if(sel == 0) {
                    EidssAndroidHelpers.AlertOkDialog.Show(mActivity.getSupportFragmentManager(), R.string.NothingToDelete);
                    return true;
                }
                if (!CheckCanDeleteSpecies()) {
                    EidssAndroidHelpers.AlertOkDialog.Show(mActivity.getSupportFragmentManager(), R.string.ErrSpeciesCantBeDeleted);
                    return true;
                }
                DeleteSpecies();
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }

    protected SpeciesListAdapter GetAdapter() {
        if(getListView() !=null)    {
            ListAdapter adapter = getListView().getAdapter();
            if (adapter != null && adapter instanceof SpeciesListAdapter) {
                return (SpeciesListAdapter) adapter;
            }
        }
        return null;
    }

    public void updateListItemAtPosition(int position) {
        int visiblePosition = getListView().getFirstVisiblePosition();
        View view = getListView().getChildAt(position - visiblePosition);
        getListView().getAdapter().getView(position, view, getListView());
    }

    private void DeleteSpecies()
    {
        ((SpeciesListAdapter)getListView().getAdapter()).DeleteSpecies();
    }
    private boolean CheckCanDeleteSpecies()
    {
        return ((SpeciesListAdapter)getListView().getAdapter()).CheckCanDeleteSpecies(_parent);
    }

    private ISpeciesParent mCase() {
        return (ISpeciesParent)((IGet)mActivity).get();
    }
}
