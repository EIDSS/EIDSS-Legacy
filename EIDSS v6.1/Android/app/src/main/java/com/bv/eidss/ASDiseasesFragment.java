package com.bv.eidss;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.ListFragment;
import android.support.v7.widget.PopupMenu;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListAdapter;

import com.bv.eidss.model.ASDisease;
import com.bv.eidss.model.ASSession;
import com.bv.eidss.model.interfaces.Constants;
import com.bv.eidss.model.interfaces.IGet;
import com.bv.eidss.model.interfaces.IToChange;


public class ASDiseasesFragment extends ListFragment
        implements IToChange {
    private ASSessionActivity mActivity;

    public ASDiseasesFragment() {
        // Required empty public constructor
    }

    //IToChange
    private boolean mToChange;
    public boolean ToChange(){return mToChange;}
    public void setToChange(boolean value){mToChange = value;}
    //End IToChange

    private boolean mReadonly;
    public boolean Readonly(){return mReadonly;}
    public void setReadonly(boolean value){mReadonly = value;}

    public static ASDiseasesFragment newInstance() {
        return new ASDiseasesFragment();
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setHasOptionsMenu(true);
    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        if (context instanceof Activity){
            mActivity = (ASSessionActivity) context;
        }
    }

    @Override
    public void onActivityCreated(Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);

        setListAdapter(new ASDiseasesListAdapter(this, mCase()));
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        //Bind
        if (mCase().getMonitoringSession() != 0 || mCase().getMonitoringSessionStatus() == Constants.AsSessionStatus_Closed) {
            mReadonly = true;
        }

        return inflater.inflate(R.layout.list_m_choice_layout, null);
    }

    @Override
    public void  onCreateOptionsMenu(Menu menu, MenuInflater inflater) {

        inflater.inflate(R.menu.add_remove_with_sync, menu);
    }

    /* Called whenever we call invalidateOptionsMenu() */
    @Override
    public void onPrepareOptionsMenu(Menu menu) {
        final ASDiseasesListAdapter adapter = GetAdapter();
        if (adapter != null)
            adapter.updateMenuVisibility(menu);

        super.onPrepareOptionsMenu(menu);
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent intent) {
        if (requestCode == getResources().getInteger(R.integer.ACTIVITY_ID_ASDISEASE)) {
            if (resultCode == Activity.RESULT_OK) {
                int position = intent.getIntExtra("position", -1);
                final ASDisease gotasdisease = intent.getParcelableExtra(getResources().getString(R.string.EXTRA_ID_ITEM));
                if (position >= 0) {
                    final ASDiseasesListAdapter list = GetAdapter();
                    if (list != null) {
                        final ASDisease asdisease = list.getItem(position);
                        if (asdisease != null) {
                            asdisease.setDiagnosis(gotasdisease.getDiagnosis());
                            asdisease.setSpeciesType(gotasdisease.getSpeciesType());
                            asdisease.setSampleType(gotasdisease.getSampleType());
                            updateListItemAtPosition(position);
                        }
                    }
                }
                else {
                    mCase().asDiseases.add(gotasdisease);
                    ((ASDiseasesListAdapter) getListView().getAdapter()).notifyDataSetChanged();
                }
            }
        }
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {

        switch (item.getItemId()) {
            case android.R.id.home:
                mActivity.Home();
                return true;
            case R.id.CreateNew:
                final ASDisease asdisease = ASDisease.CreateNew(mCase().getMonitoringSession(), mCase().getId());
                final Intent intent = new Intent(getActivity(), ASDiseaseActivity.class);
                intent.putExtra(getResources().getString(R.string.EXTRA_ID_ITEM), asdisease);
                intent.putExtra(getResources().getString(R.string.EXTRA_ID_ASSESSION), mCase());
                startActivityForResult(intent, getResources().getInteger(R.integer.ACTIVITY_ID_ASDISEASE));
                return true;
            case R.id.Save:
                mActivity.Save();
                return true;
            case R.id.Remove:
                final int sel = ((ASDiseasesListAdapter) getListView().getAdapter()).getCheckItemsCount();
                if(sel == 0) {
                    EidssAndroidHelpers.AlertOkDialog.Show(mActivity.getSupportFragmentManager(), R.string.NothingToDelete);
                    return true;
                }
                if (!CheckCanDeleteASDiseases()) {
                    EidssAndroidHelpers.AlertOkDialog.Show(mActivity.getSupportFragmentManager(), R.string.ErrDiseaseCantBeDeleted);
                    return true;
                }
                DeleteASDiseases();
                return true;
            case R.id.Refresh:
                final View menuItemView = mActivity.findViewById(R.id.Refresh);
                PopupMenu popupMenu = new PopupMenu(mActivity, menuItemView);//, R.style.PopupMenu
                popupMenu.inflate(R.menu.synchronize_session_one_menu);
                popupMenu.setOnMenuItemClickListener(new PopupMenu.OnMenuItemClickListener() {
                    @Override
                    public boolean onMenuItemClick(MenuItem item) {
                        onSyncMenuItemClick(item);
                        return true;
                    }
                });
                popupMenu.show();
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }

    public boolean onSyncMenuItemClick(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.IDM_ONLINE:
                mActivity.OnLine();
                break;
            case R.id.IDM_OFFLINE:
                mActivity.OffLine();
                break;
            default:
                return super.onContextItemSelected(item);
        }
        return true;

    }

    protected ASDiseasesListAdapter GetAdapter() {
        if(getListView() !=null)    {
            ListAdapter adapter = getListView().getAdapter();
            if (adapter != null && adapter instanceof ASDiseasesListAdapter) {
                return (ASDiseasesListAdapter) adapter;
            }
        }
        return null;
    }

    public void updateListItemAtPosition(int position) {
        int visiblePosition = getListView().getFirstVisiblePosition();
        View view = getListView().getChildAt(position - visiblePosition);
        getListView().getAdapter().getView(position, view, getListView());
    }

    private void DeleteASDiseases()
    {
        ((ASDiseasesListAdapter)getListView().getAdapter()).DeleteASDiseases();
    }
    private boolean CheckCanDeleteASDiseases()
    {
        return ((ASDiseasesListAdapter)getListView().getAdapter()).CheckCanDeleteASDiseases();
    }

    private ASSession mCase() {
        return (ASSession)((IGet)mActivity).get();
    }
}
