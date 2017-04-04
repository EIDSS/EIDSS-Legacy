package com.bv.eidss;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.support.v4.app.LoaderManager;
import android.support.v4.content.Loader;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.widget.AdapterView;
import android.widget.AutoCompleteTextView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.generated.ASSample_binding;
import com.bv.eidss.model.ASSample;
import com.bv.eidss.model.BaseReference;
import com.bv.eidss.model.BaseReferenceType;
import com.bv.eidss.model.CaseTypeHACode;
import com.bv.eidss.model.Options;
import com.bv.eidss.utils.EidssUtils;
import com.bv.eidss.utils.OnEditTextChangeListener;

import java.util.List;


public class ASSampleFragment extends EidssBaseBindableFragment
    implements  LoaderManager.LoaderCallbacks<Cursor> {

    private ASSampleActivity mActivity;

    public ASSampleFragment() {
        // Required empty public constructor
    }

    public static ASSampleFragment newInstance() {
        return new ASSampleFragment();
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
            mActivity = (ASSampleActivity) context;
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        final View v;
        v = inflater.inflate(R.layout.as_sample_layout, container, false);

        // Custom Binding
        final List<String> mandatoryFields = EidssDatabase.GetMandatoryFields();
        final List<String> invisibleFields = EidssDatabase.GetInvisibleFields();

        EidssDatabase db = new EidssDatabase(getActivity());
        Options opt = db.Options();
        final long RegionDef = opt.getRegionDef();
        final long RayonDef = opt.getRayonDef();
        db.close();

        LookupBind(R.id.idfFarm, v, mActivity.mASSession.getFarms(mActivity),
                new AdapterView.OnItemSelectedListener() {
                    public void onItemSelected(AdapterView<?> parent, View vw, int spnPosition, long id) {
                        long newVal = ((BaseReference) parent.getSelectedItem()).idfsBaseReference;
                        long oldVal = mActivity.mASSample.getFarm();
                        if (newVal != oldVal) {
                            mActivity.mASSample.setFarm(newVal);
                            mActivity.mASSample.setSpeciesType(0);
                            RefreshSpeciesType(v);
                            SetEnabled(v);
                        }
                    }

                    public void onNothingSelected(AdapterView<?> parent) {
                        mActivity.mASSample.setFarm(0);
                        mActivity.mASSample.setSpeciesType(0);
                        RefreshSpeciesType(v);
                        SetEnabled(v);
                    }
                }, mActivity.mASSample.getFarm(), true, ASSample.eidss_Farm, mandatoryFields, invisibleFields);

        LookupBind(R.id.idfSendToOffice, v, mActivity.mASSample.getSendToOffice(), RegionDef, RayonDef, BaseReferenceType.rftInstitutionName, CaseTypeHACode.LIVESTOCK,
                new AdapterView.OnItemSelectedListener() {
                    public void onItemSelected(AdapterView<?> parent, View vw, int spnPosition, long id) {
                        mActivity.mASSample.setSendToOffice(((BaseReference) parent.getSelectedItem()).idfsBaseReference);
                    }

                    public void onNothingSelected(AdapterView<?> parent) {
                        mActivity.mASSample.setSendToOffice(0);
                    }
                }, true, ASSample.eidss_SendToOffice, mandatoryFields, invisibleFields);

        RefreshSpeciesType(v);
        RefreshComboboxes(v);

        ASSample_binding.Bind(this, v, mActivity.mASSample, mandatoryFields, invisibleFields, EidssUtils.getCurrentLanguage(), 0);

        SetEnabled(v);

        // hide soft keyboard
        mActivity.getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_HIDDEN);
        return v;
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent intent) {
    }

    @Override
    public void onCreateOptionsMenu(Menu menu, MenuInflater inflater) {
        inflater.inflate(R.menu.assample_toolbar, menu);
    }

    /* Called whenever we call invalidateOptionsMenu() */
    @Override
    public void onPrepareOptionsMenu(Menu menu) {
        /*menu.findItem(R.id.Save).setVisible(false);
        menu.findItem(R.id.Remove).setVisible(false);
        menu.findItem(R.id.Refresh).setVisible(false);*/
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {

        switch (item.getItemId()) {
            case android.R.id.home:
                mActivity.Home();
                return true;
            case R.id.Copy:
                mActivity.Copy();
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }

    @Override
    public Loader<Cursor> onCreateLoader(int id, Bundle args) {
        switch (id)
        {
            default:
                return ASSample_binding.onCreateLoader(id, EidssUtils.getCurrentLanguage(), mActivity.mASSample, mActivity);
        }
    }

    @Override
    public void onLoadFinished(Loader<Cursor> loader, Cursor data) {
        switch (loader.getId())
        {
            default:
                ASSample_binding.onLoadFinished(loader.getId(), data, mActivity.mASSample);
                break;
        }

    }

    @Override
    public void onLoaderReset(Loader<Cursor> loader) {
        switch (loader.getId())
        {
            default:
                //ASSample_binding.onLoaderReset(loader.getId());
                break;
        }
    }


    private void SetEnabled(View v){
        final List<String> mandatoryFields = EidssDatabase.GetMandatoryFields();
        final Spinner spST = (Spinner)(v.findViewById(R.id.idfsSpeciesType));
        EidssUtils.setEnabled(spST, mActivity.mASSample.getFarm() != 0, mandatoryFields.contains(ASSample.eidss_SpeciesType));

        final AutoCompleteTextView ac = (AutoCompleteTextView)(v.findViewById(R.id.idfAnimal));
        final Button scan = (Button)(v.findViewById(R.id.ScanAnimalIdButton));
        final Spinner spAA = (Spinner)(v.findViewById(R.id.idfsAnimalAge));
        final Spinner spAG = (Spinner)(v.findViewById(R.id.idfsAnimalGender));
        final EditText edC = (EditText) (v.findViewById(R.id.strColor));
        final EditText edN = (EditText) (v.findViewById(R.id.strName));
        final EditText edD = (EditText) (v.findViewById(R.id.strDescription));
        final Spinner spSM = (Spinner)(v.findViewById(R.id.idfsSampleType));
        EidssUtils.setEnabled(scan, mActivity.mASSample.getSpeciesType() != 0);
        EidssUtils.setEnabled(ac, mActivity.mASSample.getSpeciesType() != 0, mandatoryFields.contains(ASSample.eidss_SpeciesType));
        EidssUtils.setEnabled(spAA, mActivity.mASSample.getSpeciesType() != 0, mandatoryFields.contains(ASSample.eidss_AnimalAge));
        EidssUtils.setEnabled(spAG, mActivity.mASSample.getSpeciesType() != 0, mandatoryFields.contains(ASSample.eidss_AnimalGender));
        EidssUtils.setEnabled(edC, mActivity.mASSample.getSpeciesType() != 0, mandatoryFields.contains(ASSample.eidss_Color));
        EidssUtils.setEnabled(edN, mActivity.mASSample.getSpeciesType() != 0, mandatoryFields.contains(ASSample.eidss_Name));
        EidssUtils.setEnabled(edD, mActivity.mASSample.getSpeciesType() != 0, mandatoryFields.contains(ASSample.eidss_Description));
        EidssUtils.setEnabled(spSM, mActivity.mASSample.getSpeciesType() != 0, mandatoryFields.contains(ASSample.eidss_SampleType));

        final EditText edFB = (EditText) (v.findViewById(R.id.strFieldBarcode));
        final TextView edFC = (TextView) (v.findViewById(R.id.datFieldCollectionDate));
        final Button btFC = (Button)(v.findViewById(R.id.datFieldCollectionDateClearButton));
        final Spinner spSO = (Spinner)(v.findViewById(R.id.idfSendToOffice));
        EidssUtils.setEnabled(edFB, mActivity.mASSample.getSampleType() != 0, mandatoryFields.contains(ASSample.eidss_FieldBarcode));
        EidssUtils.setEnabled(edFC, mActivity.mASSample.getSampleType() != 0, mandatoryFields.contains(ASSample.eidss_FieldCollectionDate));
        EidssUtils.setEnabled(btFC, mActivity.mASSample.getSampleType() != 0);
        EidssUtils.setEnabled(spSO, mActivity.mASSample.getSampleType() != 0, mandatoryFields.contains(ASSample.eidss_SendToOffice));
    }


    private void RefreshSpeciesType(final View v){
        final List<String> mandatoryFields = EidssDatabase.GetMandatoryFields();
        final List<String> invisibleFields = EidssDatabase.GetInvisibleFields();
        long farmId = mActivity.mASSample.getFarm();

        final AutoCompleteTextView ac = (AutoCompleteTextView)(v.findViewById(R.id.idfAnimal));
        final Spinner spAA = (Spinner)(v.findViewById(R.id.idfsAnimalAge));
        final Spinner spAG = (Spinner)(v.findViewById(R.id.idfsAnimalGender));
        final EditText edC = (EditText) (v.findViewById(R.id.strColor));
        final EditText edN = (EditText) (v.findViewById(R.id.strName));
        final EditText edD = (EditText) (v.findViewById(R.id.strDescription));
        final Spinner spSM = (Spinner)(v.findViewById(R.id.idfsSampleType));

        LookupBind(R.id.idfsSpeciesType, v, mActivity.mASSession.getSpecies(mActivity, farmId),
                new AdapterView.OnItemSelectedListener() {
                    public void onItemSelected(AdapterView<?> parent, View vw, int spnPosition, long id) {
                        long newVal = ((BaseReference) parent.getSelectedItem()).idfsBaseReference;
                        long oldVal = mActivity.mASSample.getSpeciesType();
                        if (newVal != oldVal) {
                            mActivity.mASSample.setSpeciesType(newVal);
                            ac.setSelection(0);
                            spAA.setSelection(0);
                            spAG.setSelection(0);
                            edC.setText("");
                            edN.setText("");
                            edD.setText("");
                            spSM.setSelection(0);
                            RefreshComboboxes(v);
                            SetEnabled(v);
                        }
                    }

                    public void onNothingSelected(AdapterView<?> parent) {
                        mActivity.mASSample.setSpeciesType(0);
                        ac.setSelection(0);
                        spAA.setSelection(0);
                        spAG.setSelection(0);
                        edC.setText("");
                        edN.setText("");
                        edD.setText("");
                        spSM.setSelection(0);
                        RefreshComboboxes(v);
                        SetEnabled(v);
                    }
                }, mActivity.mASSample.getSpeciesType(), farmId != 0, ASSample.eidss_SpeciesType, mandatoryFields, invisibleFields);
    }

    private void RefreshComboboxes(final View v){
        final List<String> mandatoryFields = EidssDatabase.GetMandatoryFields();
        final List<String> invisibleFields = EidssDatabase.GetInvisibleFields();
        long farmId = mActivity.mASSample.getFarm();
        long speciesType = mActivity.mASSample.getSpeciesType();

        final AutoCompleteTextView ac = (AutoCompleteTextView)(v.findViewById(R.id.idfAnimal));
        final Spinner spAA = (Spinner)(v.findViewById(R.id.idfsAnimalAge));
        final Spinner spAG = (Spinner)(v.findViewById(R.id.idfsAnimalGender));
        final EditText edC = (EditText) (v.findViewById(R.id.strColor));
        final EditText edN = (EditText) (v.findViewById(R.id.strName));
        final EditText edD = (EditText) (v.findViewById(R.id.strDescription));

        final List<BaseReference> list = mActivity.mASSession.getAnimals(farmId, speciesType, mActivity.mASSample, mActivity.position);
        LookupBind(R.id.idfAnimal, v, mActivity.mASSample.getAnimal(), list,
                new AdapterView.OnItemClickListener() {
                    @Override
                    public void onItemClick(AdapterView<?> l, View arg1, int pos, long id) {
                        long itemId = ((BaseReference)l.getItemAtPosition(pos)).idfsBaseReference;

                        BaseReference item = null;
                        for(int i = 0; i < list.size(); i++){
                            item = list.get(i);
                            if (item.idfsBaseReference == itemId){
                                break;
                            }
                        }

                        spAA.setSelection(0);
                        spAG.setSelection(0);
                        edC.setText("");
                        edN.setText("");
                        edD.setText("");

                        String strCode = item.name;
                        if (itemId == 0){
                            mActivity.mASSample.SetNewDefault(mActivity, mActivity.mASSession);
                            item.idfsBaseReference = mActivity.mASSample.getAnimal();
                            item.name = mActivity.mASSample.getAnimalCode();
                            ac.setText(mActivity.mASSample.getAnimalCode());
                        } else {
                            mActivity.mASSample.setAnimal(itemId);
                            mActivity.mASSample.setAnimalCode(strCode);
                        }

                        for(ASSample a: mActivity.mASSession.asSamples){
                            if (a.getAnimal() == itemId){
                                for (int i = 0; i < spAA.getAdapter().getCount(); i++){
                                    if (((BaseReference)spAA.getAdapter().getItem(i)).idfsBaseReference == a.getAnimalAge()){
                                        spAA.setSelection(i);
                                        break;
                                    }
                                }
                                for (int i = 0; i < spAG.getAdapter().getCount(); i++){
                                    if (((Cursor)spAG.getAdapter().getItem(i)).getLong(0) == a.getAnimalGender()){
                                        spAG.setSelection(i);
                                        break;
                                    }
                                }
                                edC.setText(a.getColor());
                                edN.setText(a.getName());
                                edD.setText(a.getDescription());
                                break;
                            }
                        }

                    }
                },
                new OnEditTextChangeListener(){
                    @Override
                    public void onEditTextChanged(String text) {
                        if (mActivity.getResources().getString(R.string.LinkNewAnimal).compareTo(text) == 0){
                            return;
                        }

                        for(int i = 0; i < list.size(); i++){
                            BaseReference item = list.get(i);
                            if (item.name.compareTo(text) == 0){
                                return;
                            }
                        }

                        for(int i = 0; i < list.size(); i++){
                            BaseReference item = list.get(i);
                            if (item.idfsBaseReference == mActivity.mASSample.getAnimal()){
                                item.name = text;
                                mActivity.mASSample.setAnimalCode(text);
                                break;
                            }
                        }
                    }
                },
                speciesType > 0, ASSample.eidss_Animal, mandatoryFields, invisibleFields);


        //Age
        String[] sels = new String[5];
        sels[0] = EidssUtils.getCurrentLanguage();
        sels[1] = String.valueOf(BaseReferenceType.rftAnimalAgeList);
        sels[2] = String.valueOf(CaseTypeHACode.LIVESTOCK);
        sels[3] = String.valueOf(speciesType);
        sels[4] = String.valueOf(mActivity.mASSample.getAnimalAge());
        Cursor data = mActivity.getContentResolver().query(ReferenciesProvider.CONTENT_URI, null, null, sels, null);
        List<BaseReference> ageList = EidssDatabase.GetReferenceListFromCursor(data);
        //ageList.add(0, new BaseReference(0, ""));

        LookupBind(R.id.idfsAnimalAge, v, ageList,
                new AdapterView.OnItemSelectedListener() {
                    public void onItemSelected(AdapterView<?> parent, View vw, int spnPosition, long id) {
                        mActivity.mASSample.setAnimalAge(((BaseReference) parent.getSelectedItem()).idfsBaseReference);
                    }

                    public void onNothingSelected(AdapterView<?> parent) {
                        mActivity.mASSample.setAnimalAge(0);
                    }
                }, mActivity.mASSample.getAnimalAge(), speciesType > 0, ASSample.eidss_AnimalAge, mandatoryFields, invisibleFields);


        final EditText edFB = (EditText) (v.findViewById(R.id.strFieldBarcode));
        final TextView edFC = (TextView) (v.findViewById(R.id.datFieldCollectionDate));
        final Spinner spSO = (Spinner)(v.findViewById(R.id.idfSendToOffice));

        LookupBind(R.id.idfsSampleType, v, mActivity.mASSession.getSampleTypes(mActivity, speciesType),
                new AdapterView.OnItemSelectedListener() {
                    public void onItemSelected(AdapterView<?> parent, View vw, int spnPosition, long id) {
                        long newVal = ((BaseReference) parent.getSelectedItem()).idfsBaseReference;
                        long oldVal = mActivity.mASSample.getSampleType();
                        if (newVal != oldVal) {
                            mActivity.mASSample.setSampleType(newVal);
                            //mActivity.mASSample.setFieldBarcode("");
                            //mActivity.mASSample.setFieldCollectionDate(null);
                            //mActivity.mASSample.setSendToOffice(0);
                            edFB.setText("");
                            edFC.setText("");
                            spSO.setSelection(0);
                            SetEnabled(v);
                        }
                        SetEnabled(v);
                    }

                    public void onNothingSelected(AdapterView<?> parent) {
                        mActivity.mASSample.setSampleType(0);
                        //mActivity.mASSample.setFieldBarcode("");
                        //mActivity.mASSample.setFieldCollectionDate(null);
                        //mActivity.mASSample.setSendToOffice(0);
                        edFB.setText("");
                        edFC.setText("");
                        spSO.setSelection(0);
                        SetEnabled(v);
                    }
                }, mActivity.mASSample.getSampleType(), speciesType > 0, ASSample.eidss_SampleType, mandatoryFields, invisibleFields);

    }

}
