package com.bv.eidss;

import android.app.Activity;
import android.content.Context;
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

import com.bv.eidss.model.interfaces.IFFModel;
import com.bv.eidss.model.interfaces.IFFOperations;
import com.bv.eidss.model.interfaces.IToChange;


public class CheckableListFragment extends ListFragment
            implements IToChange {
    protected FragmentActivity mActivity;

    //IToChange
    private boolean mToChange;
    public boolean ToChange(){return mToChange;}
    public void setToChange(boolean value){mToChange = value;}
    //End IToChange

    private boolean mReadonly;
    public boolean Readonly(){return mReadonly;}
    public void setReadonly(boolean value){mReadonly = value;}

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setHasOptionsMenu(true);
    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        if (context instanceof Activity){
            mActivity = (FragmentActivity) context;
        }
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

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {

        switch (item.getItemId()) {
            case android.R.id.home:
                ((IFFOperations) mActivity).Home();
                return true;
            case R.id.Save:
                ((IFFOperations) mActivity).Save();
                return true;
            case R.id.Refresh:
                final View menuItemView = mActivity.findViewById(R.id.Refresh);
                PopupMenu popupMenu = new PopupMenu(mActivity, menuItemView);//, R.style.PopupMenu
                popupMenu.inflate(R.menu.synchronize_one_menu);
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

    public boolean onSyncMenuItemClick(android.view.MenuItem item) {
        switch (item.getItemId()) {
            case R.id.IDM_ONLINE:
                ((IFFModel) mActivity).OnLine();
                break;
            case R.id.IDM_OFFLINE:
                ((IFFModel) mActivity).OffLine();
                break;
            default:
                return super.onContextItemSelected(item);
        }
        return true;

    }
}
