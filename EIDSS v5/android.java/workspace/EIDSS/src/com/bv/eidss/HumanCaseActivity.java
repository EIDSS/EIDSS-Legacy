package com.bv.eidss;

import java.text.DateFormat;
import java.util.Date;
import java.util.List;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.BaseReference;
import com.bv.eidss.model.BaseReferenceType;
import com.bv.eidss.model.GisBaseReference;
import com.bv.eidss.model.HumanCase;
import android.app.Activity;
import android.app.DatePickerDialog;
import android.app.DatePickerDialog.OnDateSetListener;
import android.app.Dialog;
import android.content.DialogInterface;
import android.os.Bundle;
import android.text.InputFilter;
import android.text.Spanned;
import android.view.MotionEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.View.OnTouchListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ScrollView;
import android.widget.Spinner;

public class HumanCaseActivity extends Activity {
	private final int DELETE_DIALOG_ID = 1;
    private final int SAVE_DIALOG_ID = 2;
    private final int CANCEL_DIALOG_ID = 3;
    private final int BACK_DIALOG_ID = 4;
    private final int DATE_DIAGNOSIS_DIALOG_ID = 11;
    private final int DATE_BIRTH_DIALOG_ID = 12;
    private final int DATE_ONSET_DIALOG_ID = 13;

	private HumanCaseActivity _this;
	private HumanCase mCase;
	public HumanCaseActivity() {
    	_this = this;
	}
	
	abstract static interface OnEditTextChangeListener
	{
		public abstract void onEditTextChanged(String text);
	}
	
	@SuppressWarnings("deprecation")
	@Override
    public void onBackPressed()
    {
        if (mCase.getChanged()){
            showDialog(BACK_DIALOG_ID);
        }
        else{
            super.onBackPressed();
        }
    }

    public void Back()
    {
        super.onBackPressed();
    }
	
	@Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTitle(R.string.TitleHumanCase);
        setContentView(R.layout.human_case_layout);
   	
        mCase = (HumanCase)getIntent().getParcelableExtra("hc");

    	findViewById(R.id.DeleteButton).setOnClickListener(new View.OnClickListener() {
			@SuppressWarnings("deprecation")
			public void onClick(View v) {
				showDialog(DELETE_DIALOG_ID);
			}
		});
    	findViewById(R.id.CancelButton).setOnClickListener(new View.OnClickListener() {
			@SuppressWarnings("deprecation")
			public void onClick(View v) {
				if (mCase.getChanged()){
					showDialog(CANCEL_DIALOG_ID);
				}
				else {
    				setResult(RESULT_CANCELED);
    				finish();
				}
			}
		});
    	findViewById(R.id.OkButton).setOnClickListener(new View.OnClickListener() {
			@SuppressWarnings("deprecation")
			public void onClick(View v) {
                if (mCase.getTentativeDiagnosis() == 0)
                    showDialog(R.string.DiagnosisMandatory);
                else if (mCase.getFamilyName() == null || mCase.getFamilyName() == "")
                	showDialog(R.string.LastNameMandatory);
                else if (mCase.getRegionCurrentResidence() == 0)
                	showDialog(R.string.RegionMandatory);
                else if (mCase.getRayonCurrentResidence() == 0)
                	showDialog(R.string.RayonMandatory);
                else if (mCase.getDateofBirth() != null && mCase.getDateofBirth().after(DateHelpers.Today()))
                	showDialog(R.string.DateOfBirthCheckCurrent);
                else if (mCase.getOnSetDate() != null && mCase.getOnSetDate().after(DateHelpers.Today()))
                	showDialog(R.string.DateOfSymptomCheckCurrent);
                else if (mCase.getTentativeDiagnosisDate() != null && mCase.getTentativeDiagnosisDate().after(DateHelpers.Today()))
                	showDialog(R.string.DateOfDiagnosisCheckCurrent);
                else if (mCase.getTentativeDiagnosisDate() != null && mCase.getNotificationDate() != null && mCase.getTentativeDiagnosisDate().after(mCase.getNotificationDate()))
                	showDialog(R.string.DateOfDiagnosisCheckNotification);
                else if (mCase.getDateofBirth() != null && mCase.getTentativeDiagnosisDate() != null && mCase.getDateofBirth().after(mCase.getTentativeDiagnosisDate()))
                	showDialog(R.string.DateOfBirthCheckDiagnosis);
                else if (mCase.getDateofBirth() != null && mCase.getNotificationDate() != null && mCase.getDateofBirth().after(mCase.getNotificationDate()))
                	showDialog(R.string.DateOfBirthCheckNotification);
                else if (mCase.getOnSetDate() != null && mCase.getTentativeDiagnosisDate() != null && mCase.getOnSetDate().after(mCase.getTentativeDiagnosisDate()))
                	showDialog(R.string.DateOfSymptomCheckDiagnosis);
                else
                {
                    if (mCase.getChanged())
                    {
                        showDialog(SAVE_DIALOG_ID);
                    }
                    else
                    {
        				_this.getIntent().putExtra("hc", mCase);
        				_this.setResult(RESULT_OK, _this.getIntent());
        				_this.finish();
                    }
                }
			}
		});

    	EidssDatabase mDb = new EidssDatabase(this);
    	LookupBind(R.id.RegionLookup, mDb.GisRegions(mDb.getCurrentLanguage()), mCase.getRegionCurrentResidence(), 
    		new OnItemSelectedListener(){
				public void onItemSelected(AdapterView<?> list, View arg1, int arg2, long arg3) {
			        if (mCase.getRegionCurrentResidence() != ((GisBaseReference)list.getSelectedItem()).idfsBaseReference) {
			            mCase.setRegionCurrentResidence(((GisBaseReference)list.getSelectedItem()).idfsBaseReference);
			            mCase.setRayonCurrentResidence(0);
			            mCase.setSettlementCurrentResidence(0);
			        	EidssDatabase mDb = new EidssDatabase(_this);
			        	LookupBind(R.id.RayonLookup, mDb.GisRayons(mCase.getRegionCurrentResidence(), mDb.getCurrentLanguage()), mCase.getRayonCurrentResidence(), null, true);
			        	LookupBind(R.id.SettlementLookup, mDb.GisSettlements(mCase.getRayonCurrentResidence(), mDb.getCurrentLanguage()), mCase.getSettlementCurrentResidence(), null, true);
			        	mDb.close();
			        }
				}
				public void onNothingSelected(AdapterView<?> arg0) {
				}}, true);
    	LookupBind(R.id.RayonLookup, mDb.GisRayons(mCase.getRegionCurrentResidence(), mDb.getCurrentLanguage()), mCase.getRayonCurrentResidence(), 
        		new OnItemSelectedListener(){
    				public void onItemSelected(AdapterView<?> list, View arg1, int arg2, long arg3) {
    			        if (mCase.getRayonCurrentResidence() != ((GisBaseReference)list.getSelectedItem()).idfsBaseReference) {
    			            mCase.setRayonCurrentResidence(((GisBaseReference)list.getSelectedItem()).idfsBaseReference);
    			            mCase.setSettlementCurrentResidence(0);
    			        	EidssDatabase mDb = new EidssDatabase(_this);
    			        	LookupBind(R.id.SettlementLookup, mDb.GisSettlements(mCase.getRayonCurrentResidence(), mDb.getCurrentLanguage()), mCase.getSettlementCurrentResidence(), null, true);
    			        	mDb.close();
    			        }
    				}
    				public void onNothingSelected(AdapterView<?> arg0) {
    				}}, true);
    	LookupBind(R.id.SettlementLookup, mDb.GisSettlements(mCase.getRayonCurrentResidence(), mDb.getCurrentLanguage()), mCase.getSettlementCurrentResidence(), 
        		new OnItemSelectedListener(){
    				public void onItemSelected(AdapterView<?> list, View arg1, int arg2, long arg3) {
    			        if (mCase.getSettlementCurrentResidence() != ((GisBaseReference)list.getSelectedItem()).idfsBaseReference) {
    			            mCase.setSettlementCurrentResidence(((GisBaseReference)list.getSelectedItem()).idfsBaseReference);
    			        }
    				}
    				public void onNothingSelected(AdapterView<?> arg0) {
    				}}, true);
    	mDb.close();
    	
        LookupBind(R.id.DiagnosisLookup, mCase.getTentativeDiagnosis(), BaseReferenceType.rftDiagnosis, 2,
    		new OnItemSelectedListener(){
				public void onItemSelected(AdapterView<?> list, View arg1, int arg2, long arg3) {
					mCase.setTentativeDiagnosis(((BaseReference)list.getSelectedItem()).idfsBaseReference);
				}
				public void onNothingSelected(AdapterView<?> arg0) {
					mCase.setTentativeDiagnosis(0);
				}}, true);
        LookupBind(R.id.HumanAgeType, mCase.getHumanAgeType(), BaseReferenceType.rftHumanAgeType, 2,
    		new OnItemSelectedListener(){
				public void onItemSelected(AdapterView<?> list, View arg1, int arg2, long arg3) {
					mCase.setHumanAgeType(((BaseReference)list.getSelectedItem()).idfsBaseReference);
				}
				public void onNothingSelected(AdapterView<?> arg0) {
					mCase.setHumanAgeType(0);
				}}, mCase.getDateofBirth() == null);
        LookupBind(R.id.HumanGenderLookup, mCase.getHumanGender(), BaseReferenceType.rftHumanGender, 0,
    		new OnItemSelectedListener(){
				public void onItemSelected(AdapterView<?> list, View arg1, int arg2, long arg3) {
					mCase.setHumanGender(((BaseReference)list.getSelectedItem()).idfsBaseReference);
				}
				public void onNothingSelected(AdapterView<?> arg0) {
					mCase.setHumanGender(0);
				}}, true);
        LookupBind(R.id.FinalStateLookup, mCase.getFinalState(), BaseReferenceType.rftFinalState, 0,
    		new OnItemSelectedListener(){
				public void onItemSelected(AdapterView<?> list, View arg1, int arg2, long arg3) {
					mCase.setFinalState(((BaseReference)list.getSelectedItem()).idfsBaseReference);
				}
				public void onNothingSelected(AdapterView<?> arg0) {
					mCase.setFinalState(0);
				}}, true);
        LookupBind(R.id.HospitalizationStatusLookup, mCase.getHospitalizationStatus(), BaseReferenceType.rftHospStatus, 0,
    		new OnItemSelectedListener(){
				public void onItemSelected(AdapterView<?> list, View arg1, int arg2, long arg3) {
					mCase.setHospitalizationStatus(((BaseReference)list.getSelectedItem()).idfsBaseReference);
				}
				public void onNothingSelected(AdapterView<?> arg0) {
					mCase.setHospitalizationStatus(0);
				}}, true);
        
        DateBind(R.id.DiagnosisDate, R.id.DiagnosisDateButton, R.id.DiagnosisDateClearButton,
        	new OnClickListener(){
				public void onClick(View arg0) {
					mCase.setTentativeDiagnosisDate(null); 
					DisplayDate(R.id.DiagnosisDate, mCase.getTentativeDiagnosisDate());
				}},
            mCase.getTentativeDiagnosisDate(), DATE_DIAGNOSIS_DIALOG_ID);
        
        DateBind(R.id.DateofBirth, R.id.DateofBirthButton, R.id.DateofBirthClearButton,
        	new OnClickListener(){
				public void onClick(View arg0) {
					mCase.setDateofBirth(null); 
					DisplayDate(R.id.DateofBirth, mCase.getDateofBirth());
		            EditText ed = (EditText)_this.findViewById(R.id.PatientAge);
		            Spinner sp = (Spinner)_this.findViewById(R.id.HumanAgeType);
	                ed.setEnabled(true);
	                sp.setEnabled(true);
				}},
            mCase.getDateofBirth(), DATE_BIRTH_DIALOG_ID);
        
        DateBind(R.id.DateOnSet, R.id.DateOnSetButton, R.id.DateOnSetClearButton,
        	new OnClickListener(){
				public void onClick(View arg0) {
					mCase.setOnSetDate(null); 
					DisplayDate(R.id.DateOnSet, mCase.getOnSetDate());
				}},
            mCase.getOnSetDate(), DATE_ONSET_DIALOG_ID);

        DateBind(R.id.NotificationDate, 0, 0, null, mCase.getNotificationDate(), 0);
		
        EditTextBind(R.id.CaseID, mCase.getCaseID(), null, false);
        EditTextBind(R.id.LocalIdentifier, mCase.getLocalIdentifier(), new OnEditTextChangeListener(){ 
        	public void onEditTextChanged(String text) {
				mCase.setLocalIdentifier(text);
			}}, true);
    	EditTextBind(R.id.FamilyName, mCase.getFamilyName(), new OnEditTextChangeListener(){
			public void onEditTextChanged(String text) {
				mCase.setFamilyName(text);
			}}, true);
    	EditTextBind(R.id.FirstName, mCase.getFirstName(), new OnEditTextChangeListener(){
			public void onEditTextChanged(String text) {
				mCase.setFirstName(text);
			}}, true);
        EditTextBind(R.id.PatientAge, mCase.getPatientAge() == 0 ? "" : String.valueOf(mCase.getPatientAge()), new OnEditTextChangeListener(){
			public void onEditTextChanged(String text) {
				if (text.trim().length() == 0)
					mCase.setPatientAge(0);
				else {
					try { mCase.setPatientAge(Integer.parseInt(text)); } 
					catch (NumberFormatException e) { }
				}
			}}, mCase.getDateofBirth() == null);
        EditTextBind(R.id.Building, mCase.getBuilding(), new OnEditTextChangeListener(){
   			public void onEditTextChanged(String text) {
   				mCase.setBuilding(text);
        	}}, true);
        EditTextBind(R.id.House, mCase.getHouse(), new OnEditTextChangeListener(){
			public void onEditTextChanged(String text) {
				mCase.setHouse(text);
			}}, true);
        EditTextBind(R.id.Apt, mCase.getApartment(), new OnEditTextChangeListener(){
			public void onEditTextChanged(String text) {
				mCase.setApartment(text);
			}}, true); 
        EditTextBind(R.id.Street, mCase.getStreetName(), new OnEditTextChangeListener(){
			public void onEditTextChanged(String text) {
				mCase.setStreetName(text);
			}}, true); 
        EditTextBind(R.id.PostCode, mCase.getPostCode(), new OnEditTextChangeListener(){
			public void onEditTextChanged(String text) {
				mCase.setPostCode(text);
			}}, true); 
        EditTextBind(R.id.Phone, mCase.getHomePhone(), new OnEditTextChangeListener(){
			public void onEditTextChanged(String text) {
				mCase.setHomePhone(text);
			}}, true); 
        EditTextBind(R.id.SentByPerson, mCase.getSentByPerson(), null, false);
        EditTextBind(R.id.SentByOffice, mCase.getSentByOffice(), null, false);
	}

	
    private void DisplayDate(int id, Date dt)
    {
    	EditText ed = (EditText)findViewById(id);
        if (dt == null) ed.setText("");
        else ed.setText(DateFormat.getDateInstance(DateFormat.MEDIUM).format(dt));
    }

    private void LookupBind(int id, long def, long rft, int ha, OnItemSelectedListener listener, boolean bEnabled)
    {
    	final Spinner sp = (Spinner)findViewById(id);
        final ScrollView mScroller = (ScrollView)findViewById(R.id.Scroll);
    	EidssDatabase mDb = new EidssDatabase(this);
        List<BaseReference> list = mDb.Reference(rft, mDb.getCurrentLanguage(), ha);
        mDb.close();
        sp.setAdapter(new BaseReferenceAdapter(this, list));
        for(int i = 0; i < list.size(); i++){
        	if (list.get(i).idfsBaseReference == def){
        		sp.setSelection(i);
        		break;
        	}
        }
        sp.setOnItemSelectedListener(listener);
        sp.setEnabled(bEnabled);
        sp.setOnTouchListener(new OnTouchListener(){
			public boolean onTouch(View arg0, MotionEvent arg1) {
				mScroller.requestChildFocus(sp, sp);
				return false;
			}});
    }

    private void LookupBind(int id, List<GisBaseReference> list, long def, OnItemSelectedListener listener, boolean bEnabled)
    {
    	final Spinner sp = (Spinner)findViewById(id);
        final ScrollView mScroller = (ScrollView)findViewById(R.id.Scroll);
        sp.setAdapter(new GisBaseReferenceAdapter(this, list));
        for(int i = 0; i < list.size(); i++){
        	if (list.get(i).idfsBaseReference == def){
        		sp.setSelection(i);
        		break;
        	}
        }
        if (listener != null)
        	sp.setOnItemSelectedListener(listener);
        sp.setEnabled(bEnabled);
        sp.setOnTouchListener(new OnTouchListener(){
			public boolean onTouch(View arg0, MotionEvent arg1) {
				mScroller.requestChildFocus(sp, sp);
				return false;
			}});
    }

    private void EditTextBind(int id, String def, final OnEditTextChangeListener listener, boolean bEnabled)
    {
    	final EditText ed = (EditText)findViewById(id);
        ed.setText(def);
        ed.setEnabled(bEnabled);
        if (listener != null){
        	InputFilter[] f = ed.getEditableText().getFilters();
        	int length = f == null ? 0 : f.length;
        	InputFilter f1 = new InputFilter(){
				@Override
				public CharSequence filter(CharSequence source, int start, int end, Spanned dest, int dstart, int dend)  {
					//String text = arg0.toString();
					String text = dest.toString();
					text = text.substring(0, dstart) + source.toString() + text.substring(dend, text.length());
					listener.onEditTextChanged(text);
					return source;
				}};
			InputFilter[] f2 = new InputFilter[length + 1];
			int i = 0;
			for(; i < length; i++){
				f2[i] = f[i];
			}
			f2[i] = f1;
			ed.getEditableText().setFilters(f2);
        	
        	/*ed.setOnFocusChangeListener(new OnFocusChangeListener(){
        		public void onFocusChange(View v, boolean hasFocus) {
        			if (!hasFocus) 
        				listener.onEditTextChanged(ed.getText().toString());
        		}});*/
        }
        
    }

    
    private void DateBind(int edit_id, int btn_id, int btn_clr, OnClickListener act_clr, Date def, final int dlg)
    {
        DisplayDate(edit_id, def);
        if (btn_id != 0)
        {
        	Button bt = (Button)findViewById(btn_id);
        	bt.setOnClickListener(new OnClickListener(){
				@SuppressWarnings("deprecation")
				public void onClick(View arg0) {
					_this.showDialog(dlg);
				}});
        }
        if (btn_clr != 0)
        {
        	Button bt = (Button)findViewById(btn_clr);
        	bt.setOnClickListener(act_clr);
        }
    }
    
    @SuppressWarnings("deprecation")
	@Override
    protected Dialog onCreateDialog(int id) {
        switch (id)
        {
            case DATE_DIAGNOSIS_DIALOG_ID:
                Date dt1 = mCase.getTentativeDiagnosisDate() == null ? DateHelpers.Today() : mCase.getTentativeDiagnosisDate();
                return new DatePickerDialog(this,  
	        		new OnDateSetListener(){
						public void onDateSet(DatePicker arg0, int year, int month, int day) {
				            mCase.setTentativeDiagnosisDate(DateHelpers.Date(year, month, day));
				            DisplayDate(R.id.DiagnosisDate, mCase.getTentativeDiagnosisDate());
						}}, dt1.getYear() + 1900, dt1.getMonth(), dt1.getDate());
            case DATE_BIRTH_DIALOG_ID:
                Date dt2 = mCase.getDateofBirth() == null ? DateHelpers.Today() : mCase.getDateofBirth();
                return new DatePickerDialog(this,   
	        		new OnDateSetListener(){
						public void onDateSet(DatePicker arg0, int year, int month, int day) {
				            mCase.setDateofBirth(DateHelpers.Date(year, month, day));
				            DisplayDate(R.id.DateofBirth, mCase.getDateofBirth());

				            EditText ed = (EditText)_this.findViewById(R.id.PatientAge);
				            Spinner sp = (Spinner)_this.findViewById(R.id.HumanAgeType);

				            mCase.setPatientAge(mCase.CalcPatientAge());
				            mCase.setHumanAgeType(mCase.CalcPatientAgeType());
				            ed.setText(String.valueOf(mCase.getPatientAge()));
				            BaseReferenceAdapter ad = (BaseReferenceAdapter)sp.getAdapter();
				            for(int i = 0; i < ad.getCount(); i++){
				            	if (((BaseReference)ad.getItem(i)).idfsBaseReference == mCase.getHumanAgeType()){
				            		sp.setSelection(i);
				            		break;
				            	}
				            }
				            ed.setEnabled(false);
				            sp.setEnabled(false);
						}}, dt2.getYear() + 1900, dt2.getMonth(), dt2.getDate());
            case DATE_ONSET_DIALOG_ID:
                Date dt3 = mCase.getOnSetDate() == null ? DateHelpers.Today() : mCase.getOnSetDate();
                return new DatePickerDialog(this,   
	        		new OnDateSetListener(){
						public void onDateSet(DatePicker arg0, int year, int month, int day) {
				            mCase.setOnSetDate(DateHelpers.Date(year, month, day));
				            DisplayDate(R.id.DateOnSet, mCase.getOnSetDate());
						}}, dt3.getYear() + 1900, dt3.getMonth(), dt3.getDate());
            case DELETE_DIALOG_ID:
            	String title = getResources().getString(mCase.getCase() == 0 ? R.string.ConfirmToDeleteNewCase : R.string.ConfirmToDeleteSynCase);
                return EidssAndroidHelpers.QuestionDialog(this, title,
                	new DialogInterface.OnClickListener(){
						@Override
						public void onClick(DialogInterface dialog, int which) {
	        				_this.getIntent().putExtra("hc", mCase);
	        				_this.setResult(RESULT_FIRST_USER, _this.getIntent());
	        				_this.finish();
						}},
                	new DialogInterface.OnClickListener(){
						@Override
						public void onClick(DialogInterface dialog, int which) {
							dialog.dismiss();
						}
					});
            case SAVE_DIALOG_ID:
                return EidssAndroidHelpers.QuestionDialog(this,
            		getResources().getString(R.string.ConfirmSaveCase),
                	new DialogInterface.OnClickListener(){
						@Override
						public void onClick(DialogInterface dialog, int which) {
	        				_this.getIntent().putExtra("hc", mCase);
	        				_this.setResult(RESULT_OK, _this.getIntent());
	        				_this.finish();
						}},
                	new DialogInterface.OnClickListener(){
						@Override
						public void onClick(DialogInterface dialog, int which) {
							dialog.dismiss();
						}
					});
            case CANCEL_DIALOG_ID:
                return EidssAndroidHelpers.QuestionDialog(this,
                	getResources().getString(R.string.ConfirmCancelCase),
                	new DialogInterface.OnClickListener(){
						@Override
						public void onClick(DialogInterface dialog, int which) {
	        				_this.setResult(RESULT_CANCELED);
	        				_this.finish();
						}},
                	new DialogInterface.OnClickListener(){
						@Override
						public void onClick(DialogInterface dialog, int which) {
							dialog.dismiss();
						}
					});
            case BACK_DIALOG_ID:
                return EidssAndroidHelpers.QuestionDialog(this,
                	getResources().getString(R.string.ConfirmCancelCase),
                	new DialogInterface.OnClickListener(){
						@Override
						public void onClick(DialogInterface dialog, int which) {
							_this.Back();
						}},
                	new DialogInterface.OnClickListener(){
						@Override
						public void onClick(DialogInterface dialog, int which) {
							dialog.dismiss();
						}
					});
            case R.string.DiagnosisMandatory:
            case R.string.LastNameMandatory:
            case R.string.RegionMandatory:
            case R.string.RayonMandatory:
            case R.string.DateOfBirthCheckCurrent:
            case R.string.DateOfSymptomCheckCurrent:
            case R.string.DateOfDiagnosisCheckCurrent:
            case R.string.DateOfDiagnosisCheckNotification:
            case R.string.DateOfBirthCheckDiagnosis:
            case R.string.DateOfBirthCheckNotification:
            case R.string.DateOfSymptomCheckDiagnosis:
                return EidssAndroidHelpers.ErrorDialog(this, getResources().getString(id));
        }
        return null;
    }
	
}
