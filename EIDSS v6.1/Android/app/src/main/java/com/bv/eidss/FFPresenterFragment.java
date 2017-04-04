package com.bv.eidss;

import android.app.Activity;
import android.content.Context;
import android.os.Bundle;
import android.support.v4.app.FragmentActivity;
import android.support.v4.util.SimpleArrayMap;
import android.support.v7.widget.PopupMenu;
import android.text.InputType;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.widget.AdapterView;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.ActivityParameter;
import com.bv.eidss.model.BaseReference;
import com.bv.eidss.model.FFModel;
import com.bv.eidss.model.FFParameterTypesEnum;
import com.bv.eidss.model.FFTemplateElement;
import com.bv.eidss.model.interfaces.IFFModel;
import com.bv.eidss.model.interfaces.IFFOperations;
import com.bv.eidss.model.interfaces.IToChange;
import com.bv.eidss.utils.DateHelpers;
import com.bv.eidss.utils.EidssUtils;
import com.bv.eidss.utils.OnEditTextChangeListener;

import java.sql.Date;
import java.util.ArrayList;

public class FFPresenterFragment
        extends EidssBaseBindableFragment
        implements EidssAndroidHelpers.DialogDoneDateListener, IToChange {

    //IToChange
    private boolean mToChange;
    @Override
    public boolean ToChange(){return mToChange;}
    @Override
    public void setToChange(boolean value){mToChange = value;}
    //End IToChange

    private static final String ARG_FORM_TYPE = "arg_form_type";
    private long formType;

    private FragmentActivity mActivity;

    private ArrayList<View> Parameters;

    private final static long edtCheckBox = 10067001;
    private final static long edtComboBox = 10067002;
    private final static long edtDate = 10067003;
    private final static long edtDateTime = 10067004;
    private final static long edtMemo = 10067006;
    private final static long edtTextBox = 10067008;
    private final static long edtUpDown = 10067009;

    private final static int etpParameter = 0;
    private final static int etpSection = 1;
    //private final static int etpSectionTable = 2;
    private final static int etpLabel = 3;

    private SimpleArrayMap<Long, ArrayList<BaseReference>> SelectLists;

    public FFPresenterFragment() {
        Parameters = new ArrayList<>();
        SelectLists = new SimpleArrayMap<>();
    }

    public static FFPresenterFragment newInstance(long idfsFormType) {
        FFPresenterFragment fragment = new FFPresenterFragment();
        Bundle args = new Bundle();
        args.putLong(ARG_FORM_TYPE, idfsFormType);
        fragment.setArguments(args);
        return fragment;
    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);

        if (context instanceof Activity){
            mActivity = (FragmentActivity) context;
        }
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setHasOptionsMenu(true);

        if (getArguments() != null) {
            formType = getArguments().getLong(ARG_FORM_TYPE);
        }
        Log.d("FFPresenterFragment", "onCreate");
    }

    @Override
    public void onSaveInstanceState(Bundle outState) {
        super.onSaveInstanceState(outState);
    }

    @Override
    public void onActivityCreated(Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View v = inflater.inflate(R.layout.ff_presenter_layout, container, false);

        if(GetModel() != null && !EidssDatabase.IsFFLoaded())
        {
            String[] sels = new String[1];
            sels[0] = EidssUtils.getCurrentLanguage();

            EidssDatabase.AddFFData(getActivity().getContentResolver().query(ReferenciesProvider.CONTENT_URI, null, null, sels, null));
        }

        if (GetModel() != null && EidssDatabase.IsFFLoaded()) {
            ShowFlexibleForm(inflater, container, v);
        }

        // hide soft keyboard
        mActivity.getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_HIDDEN);
        return v;
    }

    @Override
    public void onCreateOptionsMenu(Menu menu, MenuInflater inflater) {

        inflater.inflate(R.menu.case_toolbar, menu);
    }

    /* Called whenever we call invalidateOptionsMenu() */
    @Override
    public void onPrepareOptionsMenu(Menu menu) {
        FFModel mod = GetModel();
        //menu.findItem(R.id.Save).setVisible(mod.getChanged() || mod.GetObservation() == 0);
        menu.findItem(R.id.Remove).setVisible(mod.GetObservation() != 0L && formType != 0L);
        //menu.findItem(R.id.Refresh).setVisible(mod.GetObservation() != 0L && formType != 0L);
        //return super.onPrepareOptionsMenu(menu);
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
            case R.id.Remove:
                ((IFFOperations) mActivity).Remove();
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

    private FFModel GetModel() {
        return ((IFFModel) mActivity).getFFModel(formType);
    }

    private void ShowFlexibleForm(LayoutInflater inflater, ViewGroup container, View v) {
        LinearLayout li = (LinearLayout) v.findViewById(R.id.PlaceHolder);

        Parameters.clear();

        FFModel model = GetModel();
        int idParam = 1;
        /*
        Unknown = -1,
        Parameter = 0,
        Section = 1,
        SectionTable = 2,
        Label = 3,
        * *///an element type = 2 isn't supported at the moment
        EidssDatabase mDb = new EidssDatabase(mActivity);
        for (FFTemplateElement item : model.Elements)
            if (item.intElementType == etpParameter) {

                int layoutId = 0;
                String typeControl = "";
                final Boolean isCheckBox = item.idfsEditor == edtCheckBox;
                Boolean isComboBox = item.idfsEditor == edtComboBox;
                Boolean isDate = item.idfsEditor == edtDate
                            || item.idfsEditor == edtDateTime;
                Boolean isTextBox = item.idfsEditor == edtMemo
                            || item.idfsEditor == edtTextBox
                            || item.idfsEditor == edtUpDown;

                if (isCheckBox) {
                    layoutId = R.layout.ff_template_parameter_checkbox;
                    typeControl = "CheckBoxControl";
                } else if (isComboBox) {
                    layoutId = R.layout.ff_template_parameter_combo;
                    typeControl = "ComboControl";
                } else if (isDate) {
                    layoutId = R.layout.ff_template_parameter_date;
                    typeControl = "DateControl";
                } else if (isTextBox) {
                    layoutId = R.layout.ff_template_parameter_edittext;
                    typeControl = "TextControl";
                }
                //TODO RadioButtons control is absent
                //TODO How to set UpDown Control?

                if (layoutId > 0) {
                    final View parameterView = inflater.inflate(layoutId, container, false);

                    //caption
                    final TextView parameterCaption = (TextView) parameterView.findViewById(R.id.idParameterCaption);
                    String caption = EidssDatabase.FFGetText(item.idfsParameterCaption);
                    parameterCaption.setText(caption);

                    //input control
                    final View parameterControl = parameterView.findViewWithTag(typeControl);
                    idParam++;
                    //value for control
                    ActivityParameter ap = model.GetActivityParameter(item.idfsBaseReference, 0);
                    parameterControl.setTag(ap);

                    //bind
                    if (isCheckBox) {
                        Boolean apBool = false;
                        if (ap.Value != null && ap.Value.equals("1")) apBool = true;
                        BooleanBind(parameterControl, apBool,
                                new CompoundButton.OnCheckedChangeListener() {
                                    public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                                        ActivityParameter ap = (ActivityParameter) parameterControl.getTag();
                                        ap.SetValue(isChecked);
                                    }
                                }, item.intMandatory==1, false);
                    } else if (isComboBox) {
                        //try to find select list
                        long idReference = item.idfsParameterType;
                        long value = 0;
                        if (ap.Value != null) value = Long.valueOf(ap.Value);
                        ArrayList<BaseReference> listBR;
                        if (!SelectLists.containsKey(idReference)) {
                            listBR = (ArrayList<BaseReference>) mDb.Reference(idReference, EidssUtils.getCurrentLanguage(), 0, value);
                            //if it is not a reference type then try to find it in the Fixed Preset Values
                            if (listBR.size() <= 1) {
                                listBR = (ArrayList<BaseReference>) mDb.FFGetFixedPresetValues(idReference);
                            }
                            SelectLists.put(idReference, listBR);
                        } else {
                            listBR = SelectLists.get(idReference);
                        }

                        LookupBind(parameterControl, listBR,
                                new AdapterView.OnItemSelectedListener() {
                                    public void onItemSelected(AdapterView<?> parent, View arg1, int pos, long id) {
                                        ActivityParameter ap = (ActivityParameter) parameterControl.getTag();
                                        if (id == 0) {
                                            ap.Value = null;
                                        } else {
                                            FFModel model = GetModel();
                                            long idParameterType = 0;
                                            for (int i = 0; i < model.Elements.size(); i++) {
                                                FFTemplateElement te = model.Elements.get(i);
                                                if (te.idfsBaseReference == ap.idfsParameter) {
                                                    idParameterType = te.idfsParameterType;
                                                    break;
                                                }
                                            }
                                            if (idParameterType > 0 && SelectLists.containsKey(idParameterType)) {
                                                ArrayList<BaseReference> albr = SelectLists.get(idParameterType);
                                                if (albr != null) {
                                                    long vl = albr.get((int) id).idfsBaseReference;
                                                    ap.SetValue(vl);
                                                }
                                            }
                                        }
                                    }

                                    public void onNothingSelected(AdapterView<?> arg0) {
                                        ActivityParameter ap = (ActivityParameter) parameterControl.getTag();
                                        ap.Value = null;
                                    }
                                }, value, item.intReadOnly==0, item.intMandatory==1, false);
                    } else if (isDate) {
                        java.util.Date date = null;//Calendar.getInstance().getTime();
                        if (ap.Value != null) date = Date.valueOf(ap.Value);
                        ap.idDialog = idParam++;
                        Parameters.add(parameterControl);

                        DateBind(parameterControl, parameterView, R.id.btnDate
                                , new View.OnClickListener() {
                                    @Override
                                    public void onClick(View arg0) {
                                        ActivityParameter apDate = (ActivityParameter) parameterControl.getTag();
                                        java.util.Date date = null;
                                        if (apDate.Value != null) date = Date.valueOf(apDate.Value);
                                        EidssAndroidHelpers.DatePickerFragment.Show(getActivity().getSupportFragmentManager(), apDate.idDialog, 0, null, date, formType);
                                    }
                                },
                                new View.OnClickListener() {
                                    @Override
                                    public void onClick(View arg0) {
                                        ActivityParameter ap = (ActivityParameter) parameterControl.getTag();
                                        ap.Value = null;
                                        DateHelpers.DisplayDate(ap.idDialog, parameterControl, null);
                                        ap.setChanged(true);
                                    }
                                },
                                date
                                , item.intMandatory==1, false);
                    } else  {//if (isTextBox) - always true
                        EditTextBind(parameterControl, ap.Value
                                , new OnEditTextChangeListener() {
                            @Override
                            public void onEditTextChanged(String text) {
                                ActivityParameter ap = (ActivityParameter) parameterControl.getTag();
                                ap.SetValue(text);
                                ap.setChanged(true);
                            }
                        }, item.intReadOnly==0, item.intMandatory==1, false);

                        final EditText ed = (EditText) parameterControl;
                        if (item.idfsParameterType == FFParameterTypesEnum.Numeric) {
                            ed.setInputType(InputType.TYPE_CLASS_NUMBER);
                        } else if (item.idfsParameterType == FFParameterTypesEnum.NumericNatural) {
                            ed.setInputType(InputType.TYPE_CLASS_NUMBER);
                        } else if (item.idfsParameterType == FFParameterTypesEnum.NumericInteger) {
                            ed.setInputType(InputType.TYPE_CLASS_NUMBER | InputType.TYPE_NUMBER_FLAG_SIGNED);
                        } else if (item.idfsParameterType == FFParameterTypesEnum.NumericPositive) {
                            ed.setInputType(InputType.TYPE_CLASS_NUMBER | InputType.TYPE_NUMBER_FLAG_DECIMAL);
                        }
                    }

                    li.addView(parameterView);
                }
            } else if (item.intElementType == etpSection) {
                View sectionView = inflater.inflate(R.layout.ff_template_section, container, false);
                TextView sectionCaption = (TextView) sectionView.findViewById(R.id.idSectionCaption);
                String caption = EidssDatabase.FFGetText(item.idfsBaseReference);
                sectionCaption.setText(caption);
                li.addView(sectionView);
            //} else if (item.intElementType == etpSectionTable) {
            } else if (item.intElementType == etpLabel) {
                View labelView = inflater.inflate(R.layout.ff_template_label, container, false);
                TextView labelCaption = (TextView) labelView.findViewById(R.id.idLabelCaption);
                String caption = EidssDatabase.FFGetText(item.idfsBaseReference);
                labelCaption.setText(caption);
                li.addView(labelView);
            }
        mDb.close();
    }

    @Override
    public void onDone(int idDialog, int year, int month, int day) {
        FFModel model = GetModel();
        if (model == null) return;
        ActivityParameter ap = model.GetActivityParameterByDialog(idDialog);
        //lets find an activity parameter with exact idDialog
        Date dt = new java.sql.Date(DateHelpers.Date(year, month, day).getTime());
        ap.SetValue(String.valueOf(dt));

        for (View v : Parameters) {
            if (((ActivityParameter)v.getTag()).idfsParameter == ap.idfsParameter) {
                DateHelpers.DisplayDate((TextView)v, dt);
                break;
            }
        }
    }

}
