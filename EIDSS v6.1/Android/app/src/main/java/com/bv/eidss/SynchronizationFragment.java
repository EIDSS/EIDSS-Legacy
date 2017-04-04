package com.bv.eidss;

import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.ASSession;
import com.bv.eidss.model.CaseSerializer;
import com.bv.eidss.model.CaseStatus;
import com.bv.eidss.model.HumanCase;
import com.bv.eidss.model.Options;
import com.bv.eidss.model.VetCase;
import com.bv.eidss.utils.EidssUtils;

import java.io.File;
import java.io.FileOutputStream;
import java.io.OutputStreamWriter;
import java.util.ArrayList;
import java.util.List;


public class SynchronizationFragment extends Fragment {


    public static SynchronizationFragment newInstance() {
        return new SynchronizationFragment();
    }

    public SynchronizationFragment() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View v = inflater.inflate(R.layout.synchronization_layout, container, false);


        v.findViewById(R.id.OnlineSynchronization).setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                Intent intent = new Intent(getActivity(), SynchronizeCasesActivity.class);
                startActivity(intent);
            }
        });
        v.findViewById(R.id.UnloadCasesFile).setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                Intent intent = new Intent(getActivity(), FileBrowser.class);
                intent.putExtra(getResources().getString(R.string.EXTRA_ID_MODE), getResources().getInteger(R.integer.FILE_BROWSER_MODE_SAVE));
                intent.putExtra("mask", "Cases.eidss");
                startActivityForResult(intent, getResources().getInteger(R.integer.FILE_BROWSER_MODE_SAVE));
            }
        });
        v.findViewById(R.id.DeleteSynchronizedCases).setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                EidssAndroidHelpers.AlertOkResultDialog.ShowQuestion(getActivity().getSupportFragmentManager(), ((SynchronizationActivity)getActivity()).QUESTION_DIALOG_ID, R.string.SynchronizedDeleteConfirm);
            }
        });

        return v;
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data)
    {
        if (requestCode == getResources().getInteger(R.integer.FILE_BROWSER_MODE_SAVE)) {
            String fullFilename = data.getStringExtra(getResources().getString(R.string.EXTRA_ID_FILENAME));
            if (!fullFilename.isEmpty()){
                try {
                    EidssDatabase db = new EidssDatabase(getActivity());
                    Options opts = db.Options();
                    List<HumanCase> hcs = db.HumanCaseSelect(0L);//long means select with child lists
                    List<VetCase> vcs = db.VetCaseSelect(0L);
                    List<ASSession> ass = db.ASSessionSelect(0L);
                    long country = db.GisCountry(DeploymentCountry.getDefCountry()).idfsBaseReference;

/*                    String tmp = CaseSerializer.writeAllXml(opts, hcs, vcs, country, false);
                    Options optsNew = new Options();
                    List<HumanCase> hcsNew = new ArrayList<HumanCase>();
                    List<VetCase> vcsNew = new ArrayList<VetCase>();
                    CaseSerializer.parseAllXml(tmp, optsNew, hcsNew, vcsNew);
                    db.DatabaseRestore(optsNew, hcsNew, vcsNew);*/

                    String content = CaseSerializer.writeXml(hcs, vcs, ass, country, true);
                    File file = new File(fullFilename);
                    FileOutputStream filecon = new FileOutputStream(file);
                    OutputStreamWriter writer = new OutputStreamWriter(filecon);
                    writer.write(content);
                    writer.close();
                    filecon.close();

                    //db = new EidssDatabase(getActivity());
                    //hcs = db.HumanCaseSelect(0, 0);
                    //vcs = db.VetCaseSelect((long)0);
                    for (HumanCase hc: hcs){
                        if (hc.getStatus() == CaseStatus.NEW || hc.getStatus() == CaseStatus.CHANGED){
                            hc.setStatusUploaded();
                            db.HumanCaseUpdate(hc);
                        }
                    }
                    for (VetCase vc: vcs){
                        if (vc.getStatus() == CaseStatus.NEW || vc.getStatus() == CaseStatus.CHANGED){
                            vc.setStatusUploaded();
                            db.VetCaseUpdate(vc);
                        }
                    }
                    for (ASSession as: ass){
                        if (as.getStatus() == CaseStatus.NEW || as.getStatus() == CaseStatus.CHANGED){
                            as.setStatusUploaded();
                            db.ASSessionUpdate(as);
                        }
                    }

                    db.close();
                    EidssAndroidHelpers.AlertOkDialog.Show(getActivity().getSupportFragmentManager(), R.string.CasesUnloaded);
                } catch (Exception e) {
                    EidssAndroidHelpers.AlertOkDialog.Warning(getActivity().getSupportFragmentManager(), R.string.ErrorCasesUnloaded);
                    //e.printStackTrace();
                }
            }
        }

        super.onActivityResult(requestCode, resultCode, data);
    }
}
