package com.bv.eidss;

import java.util.Date;
import android.app.DatePickerDialog;
import android.app.DatePickerDialog.OnDateSetListener;
import android.app.Dialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.Spinner;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.BaseReference;
import com.bv.eidss.model.BaseReferenceType;
import com.bv.eidss.model.CaseStatus;
import com.bv.eidss.model.CaseTypeHACode;
import com.bv.eidss.model.GisBaseReference;
import com.bv.eidss.model.HumanCase;
import com.bv.eidss.model.interfaces.ValidateCode;
import com.bv.eidss.utils.DateHelpers;

public class HumanCaseActivity extends EidssBaseBindableActivity {
	private final int DELETE_DIALOG_ID = 1;
    private final int SAVE_DIALOG_ID = 2;
    private final int CANCEL_DIALOG_ID = 3;
    private final int BACK_DIALOG_ID = 4;
    private final int SYNCHRONIZE_SAVE_DIALOG_ID = 5;
    private final int DATE_DIAGNOSIS_DIALOG_ID = 11;
    private final int DATE_BIRTH_DIALOG_ID = 12;
    private final int DATE_ONSET_DIALOG_ID = 13;

	private HumanCase mCase;
	public HumanCaseActivity() {
	}
	
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

	@Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTitle(R.string.TitleHumanCase);
        setContentView(R.layout.human_case_layout);
   	
        mCase = (HumanCase)getIntent().getParcelableExtra(EXTRA_ID_HUMANCASE);
        if(mCase.getId() == 0)
        {
        	findViewById(R.id.DeleteButton).setEnabled(false);
        	findViewById(R.id.SynchronizeHumanCaseButton).setEnabled(false);
        }
       	
    	findViewById(R.id.SynchronizeHumanCaseButton).setOnClickListener(new View.OnClickListener() {
			@Override
			public void onClick(View v) {
	        	if (mCase.getChanged())
	                showDialog(SYNCHRONIZE_SAVE_DIALOG_ID);
	            else
	            	Synchronize();
			}
		});
    	findViewById(R.id.DeleteButton).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				showDialog(DELETE_DIALOG_ID);
			}
		});
    	findViewById(R.id.CancelButton).setOnClickListener(new View.OnClickListener() {
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
			public void onClick(View v) {
				if(ValidateCase()) {
                    if (mCase.getChanged())
                        showDialog(SAVE_DIALOG_ID);
                    else
                    	FinishThis(RESULT_OK);
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
    	
        LookupBind(R.id.DiagnosisLookup, mCase.getTentativeDiagnosis(), BaseReferenceType.rftDiagnosis, CaseTypeHACode.HUMAN,
    		new OnItemSelectedListener(){
				public void onItemSelected(AdapterView<?> list, View arg1, int arg2, long arg3) {
					mCase.setTentativeDiagnosis(((BaseReference)list.getSelectedItem()).idfsBaseReference);
				}
				public void onNothingSelected(AdapterView<?> arg0) {
					mCase.setTentativeDiagnosis(0);
				}}, true);
        LookupBind(R.id.HumanAgeType, mCase.getHumanAgeType(), BaseReferenceType.rftHumanAgeType, CaseTypeHACode.HUMAN,
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
        
        DateTimeBind(R.id.CreatedDate, mCase.getCreateDate());
		
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
							DeleteCase();
							FinishThis(RESULT_DELETE);
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
							SaveCase();
							FinishThis(RESULT_OK);
						}},
                	new DialogInterface.OnClickListener(){
						@Override
						public void onClick(DialogInterface dialog, int which) {
							dialog.dismiss();
						}
					});
            case SYNCHRONIZE_SAVE_DIALOG_ID:
                return EidssAndroidHelpers.QuestionDialog(this,
            		getResources().getString(R.string.ConfirmSaveSynchCase),
                	new DialogInterface.OnClickListener(){
						@Override
						public void onClick(DialogInterface dialog, int which) {
							if(ValidateCase())
			                {
								SaveCase();
								Synchronize();
			                }
							dialog.dismiss();
						}},
                	new DialogInterface.OnClickListener(){
						@Override
						public void onClick(DialogInterface dialog, int which) {
							Synchronize();
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
            case R.string.AgeTypeCheck:
                return EidssAndroidHelpers.ErrorDialog(this, getResources().getString(id));
        }
        return null;
    }

	@Override
    public void onActivityResult(int requestCode, int resultCode, Intent data)
    {
        if (requestCode == ACTIVITY_ID_SYNCHRONIZE_CASE)
        {
            if (resultCode == RESULT_OK)
            {
                mCase = (HumanCase)data.getParcelableExtra(EXTRA_ID_HUMANCASE);
                Intent intent = getIntent();
                intent.putExtra(EXTRA_ID_HUMANCASE, mCase);
                finish();
                startActivity(intent);
            }
        }

        super.onActivityResult(requestCode, resultCode, data);
    }
	
	private Boolean ValidateCase(){
		
		ValidateCode vc = mCase.Validate();
		if (vc == ValidateCode.OK)
			return true;
		
		switch(vc) {
		case DiagnosisMandatory:
			showDialog(R.string.DiagnosisMandatory);
			break;
		case LastNameMandatory:
			showDialog(R.string.LastNameMandatory);
			break;
		case RegionMandatory:
			showDialog(R.string.RegionMandatory);
			break;
		case RayonMandatory:
			showDialog(R.string.RayonMandatory);
			break;
		case DateOfBirthCheckCurrent:
			showDialog(R.string.DateOfBirthCheckCurrent);
			break;
		case DateOfSymptomCheckCurrent:
			showDialog(R.string.DateOfSymptomCheckCurrent);
			break;
		case DateOfDiagnosisCheckCurrent:
			showDialog(R.string.DateOfDiagnosisCheckCurrent);
			break;
		case DateOfDiagnosisCheckNotification:
			showDialog(R.string.DateOfDiagnosisCheckNotification);
			break;
		case DateOfBirthCheckDiagnosis:
			showDialog(R.string.DateOfBirthCheckDiagnosis);
			break;
		case DateOfBirthCheckNotification:
			showDialog(R.string.DateOfBirthCheckNotification);
			break;
		case DateOfSymptomCheckDiagnosis:
			showDialog(R.string.DateOfSymptomCheckDiagnosis);
			break;
		case AgeType:
			showDialog(R.string.AgeTypeCheck);
			break;
		default:
			break;
		}
		return false;
	}
	
	private void Synchronize(){
		Intent intent = new Intent();
		intent = intent.setClass(getApplicationContext(), SynchronizeHumanCaseActivity.class);
		intent.putExtra("Id", mCase.getId());
		_this.startActivityForResult(intent, ACTIVITY_ID_SYNCHRONIZE_CASE);
	}
	
	private void FinishThis(int result){
		_this.getIntent().putExtra(EXTRA_ID_HUMANCASE, mCase);
		_this.setResult(result, _this.getIntent());
		_this.finish();
	}
	
	private void SaveCase(){
		EidssDatabase db = new EidssDatabase(this);
	    if (mCase.getId() == 0)
	    {
	        db.HumanCaseInsert(mCase);
	    }
	    else
	    {
	        if (mCase.getStatus() != CaseStatus.NEW)
	            mCase.setStatusChanged();
	        db.HumanCaseUpdate(mCase);
	    }
	    db.close();
	}
	
	private void DeleteCase(){
		EidssDatabase db = new EidssDatabase(this);
	    db.HumanCaseDelete(mCase);
	    db.close();
	}
}
