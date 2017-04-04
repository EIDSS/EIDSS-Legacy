package com.bv.eidss;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.res.Resources;
import android.os.Bundle;
import android.support.v4.app.ListFragment;
import android.support.v7.widget.PopupMenu;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListAdapter;

import com.bv.eidss.model.ASSample;
import com.bv.eidss.model.ASSession;
import com.bv.eidss.model.interfaces.Constants;
import com.bv.eidss.model.interfaces.IGet;
import com.bv.eidss.model.interfaces.IToChange;


public class ASSamplesFragment extends ListFragment
        implements IToChange {
    private ASSessionActivity mActivity;

    public ASSamplesFragment() {
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

    public static ASSamplesFragment newInstance() {
        return new ASSamplesFragment();
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

        setListAdapter(new ASSamplesListAdapter(this, mCase()));
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        //Bind
        return inflater.inflate(R.layout.list_m_choice_layout, null);
    }

    @Override
    public void  onCreateOptionsMenu(Menu menu, MenuInflater inflater) {

        inflater.inflate(R.menu.add_remove_with_sync, menu);
    }

    /* Called whenever we call invalidateOptionsMenu() */
    @Override
    public void onPrepareOptionsMenu(Menu menu) {
        final ASSamplesListAdapter adapter = GetAdapter();
        if (adapter != null)
            adapter.updateMenuVisibility(menu);

        super.onPrepareOptionsMenu(menu);
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent intent) {
        if (requestCode == getResources().getInteger(R.integer.ACTIVITY_ID_ASSAMPLE)) {
            if (resultCode == Activity.RESULT_OK || resultCode == Activity.RESULT_FIRST_USER) {
                int position = intent.getIntExtra("position", -1);
                final ASSample gotassample = intent.getParcelableExtra(getResources().getString(R.string.EXTRA_ID_ITEM));

                for(ASSample a: mCase().asSamples){
                    if (a.getAnimal() == gotassample.getAnimal()){
                        a.setAnimalCode(gotassample.getAnimalCode());
                        a.setAnimalAge(gotassample.getAnimalAge());
                        a.setAnimalGender(gotassample.getAnimalGender());
                        a.setColor(gotassample.getColor());
                        a.setDescription(gotassample.getDescription());
                        a.setName(gotassample.getName());
                    }
                }

                if (position >= 0) {
                    final ASSamplesListAdapter list = GetAdapter();
                    if (list != null) {
                        final ASSample assample = list.getItem(position);
                        if (assample != null) {
                            assample.SetFromAnother(gotassample);
                            //updateListItemAtPosition(position);
                        }
                    }
                }
                else {
                    gotassample.setParent(mCase().getId());
                    gotassample.setMonitoringSession(mCase().getMonitoringSession());
                    mCase().asSamples.add(gotassample);
                    //((ASSamplesListAdapter) getListView().getAdapter()).notifyDataSetChanged();
                }

                ((ASSamplesListAdapter) getListView().getAdapter()).notifyDataSetChanged();

                if (resultCode == Activity.RESULT_FIRST_USER) { // copy this sample and edit it
                    ASSample copyassample = ASSample.CreateNew(getContext(), mCase());
                    copyassample.SetForCopy(gotassample);

                    Intent intentCopy = new Intent(getActivity(), ASSampleActivity.class);
                    Resources res = getResources();
                    intentCopy.putExtra(res.getString(R.string.EXTRA_ID_ITEM), copyassample);
                    intentCopy.putExtra(res.getString(R.string.EXTRA_ID_ASSESSION), mCase());
                    intentCopy.putExtra("position", -1);
                    startActivityForResult(intentCopy, res.getInteger(R.integer.ACTIVITY_ID_ASSAMPLE));
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
                final ASSample assample = ASSample.CreateNew(getActivity(), mCase());
                final Intent intent = new Intent(getActivity(), ASSampleActivity.class);
                intent.putExtra(getResources().getString(R.string.EXTRA_ID_ITEM), assample);
                intent.putExtra(getResources().getString(R.string.EXTRA_ID_ASSESSION), mCase());
                startActivityForResult(intent, getResources().getInteger(R.integer.ACTIVITY_ID_ASSAMPLE));
                return true;
            case R.id.Save:
                mActivity.Save();
                return true;
            case R.id.Remove:
                final int sel = ((ASSamplesListAdapter) getListView().getAdapter()).getCheckItemsCount();
                if(sel == 0) {
                    EidssAndroidHelpers.AlertOkDialog.Show(mActivity.getSupportFragmentManager(), R.string.NothingToDelete);
                    return true;
                }
                //EidssAndroidHelpers.AlertOkResultDialog.ShowQuestion(getActivity().getSupportFragmentManager(), Species_binding.datStartOfSignsDate_DialogID,
                //        (new Formatter()).format(getActivity().getResources().getString(R.string.ConfirmToDeleteSpecies), sel).toString());
                DeleteASSamples();
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

    protected ASSamplesListAdapter GetAdapter() {
        if(getListView() !=null)    {
            ListAdapter adapter = getListView().getAdapter();
            if (adapter != null && adapter instanceof ASSamplesListAdapter) {
                return (ASSamplesListAdapter) adapter;
            }
        }
        return null;
    }

    public void updateListItemAtPosition(int position) {
        int visiblePosition = getListView().getFirstVisiblePosition();
        View view = getListView().getChildAt(position - visiblePosition);
        getListView().getAdapter().getView(position, view, getListView());
    }

    public void DeleteASSamples()
    {
        ((ASSamplesListAdapter)getListView().getAdapter()).DeleteASSamples();
    }

    private ASSession mCase() {
        return (ASSession)((IGet)mActivity).get();
    }
}
