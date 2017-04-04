package com.bv.eidss;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.res.Resources;
import android.database.Cursor;
import android.os.Bundle;
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
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.Spinner;
import android.widget.TextView;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.generated.Animal_binding;
import com.bv.eidss.model.Animal;
import com.bv.eidss.model.BaseReference;
import com.bv.eidss.model.BaseReferenceType;
import com.bv.eidss.model.CaseTypeHACode;
import com.bv.eidss.utils.EidssUtils;

import java.util.List;


public class AnimalFragment extends EidssBaseBindableFragment
    implements  LoaderManager.LoaderCallbacks<Cursor> {

    private AnimalActivity mActivity;

    public AnimalFragment() {
        // Required empty public constructor
    }

    public static AnimalFragment newInstance() {
        return new AnimalFragment();
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
            mActivity = (AnimalActivity) context;
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        final View v;
        v = inflater.inflate(R.layout.animal_layout, container, false);

        // Custom Binding
        final List<String> mandatoryFields = EidssDatabase.GetMandatoryFields();
        final List<String> invisibleFields = EidssDatabase.GetInvisibleFields();

        final Spinner spAG = (Spinner)(v.findViewById(R.id.idfsAnimalGender));
        final Spinner spAC = (Spinner)(v.findViewById(R.id.idfsAnimalCondition));
        final EditText edAID = (EditText) (v.findViewById(R.id.strAnimalCode));

        LookupBind(R.id.idfsSpeciesType, v, mActivity.mSpeciesTypes,
                new AdapterView.OnItemSelectedListener() {
                    public void onItemSelected(AdapterView<?> parent, View vw, int spnPosition, long id) {
                        mActivity.mAnimal.setSpeciesType(((BaseReference) parent.getSelectedItem()).idfsBaseReference);
                        EidssUtils.setEnabled(edAID, true, mandatoryFields.contains(Animal.eidss_AnimalCode));
                        EidssUtils.setEnabled(spAG, true, mandatoryFields.contains(Animal.eidss_AnimalGender));
                        EidssUtils.setEnabled(spAC, true, mandatoryFields.contains(Animal.eidss_AnimalCondition));
                        RefreshComboboxes(v, mActivity.mAnimal.getSpeciesType(), true);
                    }

                    public void onNothingSelected(AdapterView<?> parent) {
                        mActivity.mAnimal.setSpeciesType(0);
                        EidssUtils.setEnabled(edAID, false);
                        EidssUtils.setEnabled(spAG, false);
                        EidssUtils.setEnabled(spAC, false);
                        RefreshComboboxes(v, mActivity.mAnimal.getSpeciesType(), false);
                    }
                }, mActivity.mAnimal.getSpeciesType(), true, Animal.eidss_SpeciesType, mandatoryFields, invisibleFields);


        //FF
        RefreshFFSummary();

        final TextView FFSummaryText = (TextView) v.findViewById(R.id.ffSummaryText);

        FFSummaryText.setText(mActivity.mAnimal.FFPresenterCs.GetActivityParameterSummary());

        FFSummaryText.setSelected(true);
        FFSummaryText.setEllipsize(TextUtils.TruncateAt.MARQUEE);
        FFSummaryText.setSingleLine(true);

        // End of Custom Binding

        Animal_binding.Bind(this, v, mActivity.mAnimal, mandatoryFields, invisibleFields, EidssUtils.getCurrentLanguage(), 0);

        // hide soft keyboard
        mActivity.getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_HIDDEN);
        return v;
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent intent) {
        if (requestCode == getResources().getInteger(R.integer.FF_ACTIVITY)) {
            if (resultCode == Activity.RESULT_OK) {
                mActivity.mAnimal.FFPresenterCs = intent.getParcelableExtra("ffmodel");
                ((TextView) mActivity.findViewById(R.id.ffSummaryText)).setText(mActivity.mAnimal.FFPresenterCs.GetActivityParameterSummary());
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
        return Animal_binding.onCreateLoader(id, EidssUtils.getCurrentLanguage(), mActivity.mAnimal, mActivity);
    }

    @Override
    public void onLoadFinished(Loader<Cursor> loader, Cursor data) {
        Animal_binding.onLoadFinished(loader.getId(), data, mActivity.mAnimal);
    }

    @Override
    public void onLoaderReset(Loader<Cursor> loader) {
        Animal_binding.onLoaderReset(loader.getId());
    }

    public void RefreshFFSummary(){
        EidssDatabase db = new EidssDatabase(mActivity);
        mActivity.mAnimal.FFPresenterCs.LoadTemplate(db, mActivity.mAnimal.getSpeciesType());
        db.close();
    }

    private void RefreshComboboxes(final View v, final long speciesType, boolean enabled){
        final List<String> mandatoryFields = EidssDatabase.GetMandatoryFields();
        final List<String> invisibleFields = EidssDatabase.GetInvisibleFields();
        //Age
        String[] sels = new String[5];
        sels[0] = EidssUtils.getCurrentLanguage();
        sels[1] = String.valueOf(BaseReferenceType.rftAnimalAgeList);
        sels[2] = String.valueOf(CaseTypeHACode.LIVESTOCK);
        sels[3] = String.valueOf(speciesType);
        sels[4] = String.valueOf(mActivity.mAnimal.getAnimalAge());
        Cursor data = mActivity.getContentResolver().query(ReferenciesProvider.CONTENT_URI, null, null, sels, null);
        List<BaseReference> ageList = EidssDatabase.GetReferenceListFromCursor(data);

        LookupBind(R.id.idfsAnimalAge, v, ageList,
                new AdapterView.OnItemSelectedListener() {
                    public void onItemSelected(AdapterView<?> parent, View vw, int spnPosition, long id) {
                        mActivity.mAnimal.setAnimalAge(((BaseReference) parent.getSelectedItem()).idfsBaseReference);
                    }

                    public void onNothingSelected(AdapterView<?> parent) {
                        mActivity.mAnimal.setAnimalAge(0);
                    }
                }, mActivity.mAnimal.getAnimalAge(), enabled, Animal.eidss_AnimalAge, mandatoryFields, invisibleFields);

        // Clinical Signs
        View.OnClickListener cl = new View.OnClickListener() {
            public void onClick(View v) {
                Intent intent = new Intent(mActivity, FFActivity.class);
                Resources res = getResources();
                intent.putExtra("idSpeciesType", speciesType);
                intent.putExtra("ffmodel", mActivity.mAnimal.FFPresenterCs);
                intent.putExtra("caption",  res.getString(R.string.ClinicalSigns));
                startActivityForResult(intent, res.getInteger(R.integer.FF_ACTIVITY));
            }
        };
        final TextView FFSummaryText = (TextView) v.findViewById(R.id.ffSummaryText);
        final TextView FFSummaryTextCaption = (TextView) v.findViewById(R.id.ffSummaryTextCaption);
        final ImageView FFSummaryIcon = (ImageView) v.findViewById(R.id.ffSummaryIcon);

        FFSummaryIcon.setOnClickListener(cl);
        FFSummaryText.setOnClickListener(cl);
        FFSummaryTextCaption.setOnClickListener(cl);

    }

}
