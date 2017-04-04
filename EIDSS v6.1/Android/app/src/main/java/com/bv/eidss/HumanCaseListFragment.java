package com.bv.eidss;


import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.ListFragment;
import android.support.v7.widget.PopupMenu;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.LinearLayout;
import android.widget.ListAdapter;
import android.widget.ListView;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.CaseSerializer;
import com.bv.eidss.model.CaseStatus;
import com.bv.eidss.model.HumanCase;

import java.io.File;
import java.io.FileOutputStream;
import java.io.OutputStreamWriter;
import java.util.List;


public class HumanCaseListFragment extends ListFragment {
    private int maxCountList;
    private int maxCountPage;
    private int filterPosition = -1;
    private Menu adapterMenu;

    public HumanCaseListFragment() {
        // Required empty public constructor
    }

    public static HumanCaseListFragment newInstance() {
        return new HumanCaseListFragment();
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setHasOptionsMenu(true);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        //View v = inflater.inflate(R.layout.cases_list_layout, container, false);
        View v = super.onCreateView(inflater, container, savedInstanceState);
        ViewGroup parent = (ViewGroup) inflater.inflate(R.layout.cases_list_layout, container, false);
        LinearLayout layout = (LinearLayout)parent.findViewById(R.id.ListPlace);
        layout.addView(v, 0);

        EidssDatabase mDb = new EidssDatabase(getActivity());
        maxCountList = maxCountPage = mDb.Options().getPageSize();
        mDb.close();


        parent.findViewById(R.id.ShowMore).setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                maxCountList += maxCountPage;
                Refill();
            }
        });
        return parent;
    }

    @Override
    public void onActivityCreated(Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);

        getListView().setOnItemClickListener(new ListView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> list, View view, int position, long id) {
                setListShown(false);
                Intent intent = new Intent(getActivity(), HumanCaseActivity.class);
                intent.putExtra(getResources().getString(R.string.EXTRA_ID_HUMAN_CASE), ((HumanCase) list.getAdapter().getItem(position)).getId());
                startActivityForResult(intent, getResources().getInteger(R.integer.ACTIVITY_ID_HUMAN_CASE));
            }
        });

        setEmptyText(getResources().getText(R.string.ListEmpty));
    }

    @Override
    public void  onCreateOptionsMenu(Menu menu, MenuInflater inflater) {
        adapterMenu = menu;
        inflater.inflate(R.menu.case_list_toolbar, menu);
    }

    /* Called whenever we call invalidateOptionsMenu() */
    @Override
    public void onPrepareOptionsMenu(Menu menu) {
        adapterMenu = menu;
        if (getListView() != null) {
            ListAdapter adapter = getListView().getAdapter();
            if (adapter !=null && adapter instanceof CaseListAdapter) {
                ((CaseListAdapter) adapter).updateMenuVisibility();
            }
        }
        super.onPrepareOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.Add:
                setListShown(false);
                startActivityForResult(new Intent(getActivity(), HumanCaseActivity.class), getResources().getInteger(R.integer.ACTIVITY_ID_HUMAN_CASE));
                return true;
            case R.id.Remove:
                final int sel = ((HumanCaseListAdapter) getListView().getAdapter()).getCheckItemsCount();
                if(sel == 0) {
                    EidssAndroidHelpers.AlertOkDialog.Show(getActivity().getSupportFragmentManager(), R.string.NothingToDelete);
                    return true;
                }
                ListAdapter adapter = getListView().getAdapter();
                int title = ((CaseListAdapter) adapter).isNewChecked() ? R.string.ConfirmToDeleteNewCases : R.string.ConfirmToDeleteSynCases;
                EidssAndroidHelpers.AlertOkResultDialog.ShowQuestion(getActivity().getSupportFragmentManager(), ((HumanCaseListActivity)getActivity()).DELETE_DIALOG_ID, title);
                return true;
            case R.id.Refresh:
                final View menuItemView = getActivity().findViewById(R.id.Refresh);
                PopupMenu popupMenu = new PopupMenu(getActivity(), menuItemView);//, R.style.PopupMenu
                popupMenu.inflate(R.menu.synchronize_menu);
                popupMenu.setOnMenuItemClickListener(new PopupMenu.OnMenuItemClickListener()
                {
                    @Override
                    public boolean onMenuItemClick(MenuItem item)
                    {
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
        Intent intent = new Intent();
        switch(item.getItemId()){
            case R.id.IDM_ONLINE:
                intent = intent.setClass(getActivity(), SynchronizeCasesActivity.class);
                intent.putExtra("Type", R.integer.SYNCHRONIZATION_TYPE_HUMAN);
                startActivityForResult(intent, getResources().getInteger(R.integer.ACTIVITY_ID_SYNCHRONIZE_CASE));
                break;
            case R.id.IDM_OFFLINE:
                intent.setClass(getActivity(), FileBrowser.class);
                int md = getResources().getInteger(R.integer.FILE_BROWSER_MODE_SAVE);
                intent.putExtra("mode", md);
                intent.putExtra("mask", "Cases.eidss");
                startActivityForResult(intent, md);
                break;
            default:
                return super.onContextItemSelected(item);
        }
        return true;

    }

    public void onFilterChanged(int position) {
        if(filterPosition != position) {
            filterPosition = position;
            Refill();
        }
    }

    private void Refill() {
        setListShown(false);

        EidssDatabase mDb = new EidssDatabase(getActivity());
        List<HumanCase> cases = mDb.HumanCaseSelect(filterPosition);
        mDb.close();
        getActivity().findViewById(R.id.ShowMore).setVisibility(cases.size() > maxCountPage ? View.VISIBLE : View.GONE);

        HumanCaseListAdapter adapter = new HumanCaseListAdapter(getActivity(), adapterMenu, cases, maxCountList);
        setListAdapter(null);
        setListAdapter(adapter);
        setListShown(true);
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data)
    {
        if (requestCode == getResources().getInteger(R.integer.ACTIVITY_ID_HUMAN_CASE))
        {
            if (resultCode != Activity.RESULT_CANCELED)
                Refill();
        }
        else if (requestCode == getResources().getInteger(R.integer.ACTIVITY_ID_SYNCHRONIZE_CASE))
        {
            if (resultCode != Activity.RESULT_CANCELED)
                Refill();
        }
        else if (requestCode == getResources().getInteger(R.integer.FILE_BROWSER_MODE_SAVE))
        {
            String fullFilename = data.getStringExtra(getResources().getString(R.string.EXTRA_ID_FILENAME));
            if (!fullFilename.isEmpty()){
                try {
                    EidssDatabase db = new EidssDatabase(getActivity());
                    List<HumanCase> hcs = db.HumanCaseSelect(0L);
                    long country = db.GisCountry(DeploymentCountry.getDefCountry()).idfsBaseReference;

                    String content = CaseSerializer.writeXml(hcs, null, null, country, true);
                    File file = new File(fullFilename);
                    FileOutputStream filecon = new FileOutputStream(file);
                    OutputStreamWriter writer = new OutputStreamWriter(filecon);
                    writer.write(content);
                    writer.close();
                    filecon.close();

                    hcs = db.HumanCaseSelect(0L);
                    for (HumanCase hc: hcs){
                        if (hc.getStatus() == CaseStatus.NEW || hc.getStatus() == CaseStatus.CHANGED){
                            hc.setStatusUploaded();
                            db.HumanCaseUpdate(hc);
                        }
                    }
                    db.close();

                    Refill();
                } catch (Exception e) {
                    EidssAndroidHelpers.AlertOkDialog.Warning(getActivity().getSupportFragmentManager(), R.string.ErrorCasesUploaded);
                    //e.printStackTrace();
                }
            }
        }

        super.onActivityResult(requestCode, resultCode, data);
    }

    public void DeleteCases()
    {
        ((HumanCaseListAdapter)getListView().getAdapter()).deleteCases();
    }


}
