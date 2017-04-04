package com.bv.eidss;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.res.Resources;
import android.database.Cursor;
import android.os.Bundle;
import android.support.v4.app.ListFragment;
import android.support.v4.app.LoaderManager;
import android.support.v4.content.Loader;
import android.text.TextUtils;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.widget.AdapterView;
import android.widget.ImageView;
import android.widget.Spinner;
import android.widget.TextView;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.generated.Species_binding;
import com.bv.eidss.model.BaseReference;
import com.bv.eidss.model.BaseReferenceType;
import com.bv.eidss.model.CaseTypeHACode;
import com.bv.eidss.model.Species;
import com.bv.eidss.utils.EidssUtils;

import java.util.List;


public class SpeciesFragment extends EidssBaseBindableFragment
        implements  LoaderManager.LoaderCallbacks<Cursor> {

    private SpeciesActivity mActivity;

    public SpeciesFragment() {
        // Required empty public constructor
    }

    public static SpeciesFragment newInstance() {
        return new SpeciesFragment();
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setHasOptionsMenu(true);
    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        if (context instanceof Activity) {
            mActivity = (SpeciesActivity) context;
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        final View v;
        v = inflater.inflate(R.layout.species_layout, container, false);

        // Custom Binding
        final List<String> mandatoryFields = EidssDatabase.GetMandatoryFields();
        final List<String> invisibleFields = EidssDatabase.GetInvisibleFields();

        final Spinner spinnerSpeciesType = (Spinner)v.findViewById(R.id.idfsSpeciesType);
        if (mActivity.mode == 0) {
            LookupBind(spinnerSpeciesType, mActivity._listSpeciesTypes,
                    new AdapterView.OnItemSelectedListener() {
                        public void onItemSelected(AdapterView<?> parent, View vw, int spnPosition, long id) {
                            mActivity.mSpecies.setSpeciesType(((BaseReference) parent.getSelectedItem()).idfsBaseReference);
                        }
                        public void onNothingSelected(AdapterView<?> parent) {
                            mActivity.mSpecies.setSpeciesType(0);
                        }
                    }, mActivity.mSpecies.getSpeciesType(), true, true, false);
        } else {
            LookupBind(R.id.idfsSpeciesType, v, mActivity.mSpecies.getSpeciesType(),
                    BaseReferenceType.rftSpeciesList,
                    (mActivity.mode == 1 ? CaseTypeHACode.LIVESTOCK : CaseTypeHACode.AVIAN),
                    new AdapterView.OnItemSelectedListener() {
                        public void onItemSelected(AdapterView<?> parent, View vw, int spnPosition, long id) {
                            mActivity.mSpecies.setSpeciesType(((BaseReference) parent.getSelectedItem()).idfsBaseReference);
                        }

                        public void onNothingSelected(AdapterView<?> parent) {
                            mActivity.mSpecies.setSpeciesType(0);
                        }
                    }, true, Species.eidss_SpeciesType, mandatoryFields, invisibleFields);
        }

        if (mActivity.mode != 0) {// 0 - assession, 1 - livestock, 2 - avian
            //FF
            RefreshFFSummary();

            // Clinical Signs
            View.OnClickListener cl = new View.OnClickListener() {
                public void onClick(View v) {
                    Intent intent = new Intent(mActivity, FFActivity.class);
                    Resources res = getResources();
                    intent.putExtra("idSpeciesType", mActivity.mSpecies.getSpeciesType());
                    intent.putExtra("ffmodel", mActivity.mSpecies.FFPresenterCs);
                    intent.putExtra("caption", getResources().getString((mActivity.mode == 1
                        ? R.string.EpidemiologicalAndClinicalInvestigation
                        : R.string.ClinicalSigns)));
                    startActivityForResult(intent, res.getInteger(R.integer.FF_ACTIVITY));
                }
            };

            final TextView FFSummaryText = (TextView) v.findViewById(R.id.ffSummaryText);
            final TextView FFSummaryTextCaption = (TextView) v.findViewById(R.id.ffSummaryTextCaption);
            final ImageView FFSummaryIcon = (ImageView) v.findViewById(R.id.ffSummaryIcon);

            FFSummaryIcon.setOnClickListener(cl);
            FFSummaryText.setOnClickListener(cl);
            FFSummaryTextCaption.setOnClickListener(cl);
            FFSummaryTextCaption.setText(getResources().getString((mActivity.mode == 1
                    ? R.string.EpidemiologicalAndClinicalInvestigation
                    : R.string.ClinicalSigns)));

            FFSummaryText.setText(mActivity.mSpecies.FFPresenterCs.GetActivityParameterSummary());

            FFSummaryText.setSelected(true);
            FFSummaryText.setEllipsize(TextUtils.TruncateAt.MARQUEE);
            FFSummaryText.setSingleLine(true);

            Species_binding.Bind(this, v, mActivity.mSpecies, mandatoryFields, invisibleFields, EidssUtils.getCurrentLanguage(), 0);
        } else {// mActivity.mode = 0 - assession

            Species_binding.Bind(this, v, mActivity.mSpecies, mandatoryFields, invisibleFields, EidssUtils.getCurrentLanguage(), 0);

            View parent = (View)v.findViewById(R.id.datStartOfSignsDate).getParent().getParent();
            if (parent != null)
                parent.setVisibility(View.GONE);
            parent = (View)v.findViewById(R.id.intDeadAnimalQty).getParent();
            if (parent != null)
                parent.setVisibility(View.GONE);
            parent = (View)v.findViewById(R.id.intSickAnimalQty).getParent();
            if (parent != null)
                parent.setVisibility(View.GONE);
            v.findViewById(R.id.FFDetailsButton).setVisibility(View.GONE);
            v.findViewById(R.id.ffSummaryText).setVisibility(View.GONE);
            v.findViewById(R.id.ffSummaryTextCaption).setVisibility(View.GONE);
            v.findViewById(R.id.ffSummaryIcon).setVisibility(View.GONE);
        }

        // 0 - assession, 1 - livestock, 2 - avian
        if (mActivity.mode != 1)
            EidssUtils.setInvisible(v.findViewById(R.id.strNote));
        if (mActivity.mode != 2)
            EidssUtils.setInvisible(v.findViewById(R.id.intAverageAge));
        // End of Custom Binding


        // hide soft keyboard
        mActivity.getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_HIDDEN);
        return v;
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent intent) {
        if (requestCode == getResources().getInteger(R.integer.FF_ACTIVITY)) {
            if (resultCode == Activity.RESULT_OK) {
                mActivity.mSpecies.FFPresenterCs = intent.getParcelableExtra("ffmodel");
                ((TextView) mActivity.findViewById(R.id.ffSummaryText)).setText(mActivity.mSpecies.FFPresenterCs.GetActivityParameterSummary());
            }
        }
    }

    @Override
    public void onCreateOptionsMenu(Menu menu, MenuInflater inflater) {
        inflater.inflate(R.menu.case_toolbar, menu);
    }

    /* Called whenever we call invalidateOptionsMenu() */
    @Override
    public void onPrepareOptionsMenu(Menu menu) {
        menu.findItem(R.id.Save).setVisible(false);
        menu.findItem(R.id.Remove).setVisible(false);
        menu.findItem(R.id.Refresh).setVisible(false);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {

        switch (item.getItemId()) {
            case android.R.id.home:
                mActivity.Home();
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }

    @Override
    public Loader<Cursor> onCreateLoader(int id, Bundle args) {
        return Species_binding.onCreateLoader(id, EidssUtils.getCurrentLanguage(), mActivity.mSpecies, mActivity);
    }

    @Override
    public void onLoadFinished(Loader<Cursor> loader, Cursor data) {
        Species_binding.onLoadFinished(loader.getId(), data, mActivity.mSpecies);
    }

    @Override
    public void onLoaderReset(Loader<Cursor> loader) {
        Species_binding.onLoaderReset(loader.getId());
    }

    public void RefreshFFSummary(){
        EidssDatabase db = new EidssDatabase(mActivity);
        mActivity.mSpecies.FFPresenterCs.LoadTemplate(db, mActivity.mSpecies.getSpeciesType());
        db.close();
    }
}
