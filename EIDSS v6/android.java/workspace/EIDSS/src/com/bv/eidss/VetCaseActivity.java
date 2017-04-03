package com.bv.eidss;

import java.util.Date;
import java.util.List;

import android.app.Activity;
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
import android.widget.ListView;

import com.bv.eidss.data.EidssDatabase;
import com.bv.eidss.model.BaseReference;
import com.bv.eidss.model.BaseReferenceType;
import com.bv.eidss.model.CaseStatus;
import com.bv.eidss.model.CaseType;
import com.bv.eidss.model.GisBaseReference;
import com.bv.eidss.model.Species;
import com.bv.eidss.model.VetCase;
import com.bv.eidss.model.interfaces.ValidateCode;
import com.bv.eidss.utils.DateHelpers;

public class VetCaseActivity extends EidssBaseBindableActivity {
	private final int DELETE_DIALOG_ID = 1;
    private final int SAVE_DIALOG_ID = 2;
    private final int CANCEL_DIALOG_ID = 3;
    private final int BACK_DIALOG_ID = 4;
    private final int SYNCHRONIZE_SAVE_DIALOG_ID = 5;
    private final int DATE_OF_SIGNS_DIALOG_ID = 10;
    private final int DATE_DIAGNOSIS_DIALOG_ID = 11;
    private final int DATE_REPORT_DIALOG_ID = 12;

    private VetCase mCase;
    private Activity mActivity;
	public VetCaseActivity() {
		mActivity = this;
	}
	
	@Override
    public void onBackPressed()
    {
        if (mCase.getChanged())
            showDialog(BACK_DIALOG_ID);
        else
            super.onBackPressed();
    }

	@Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.vet_case_layout);
   	
        Intent intent = getIntent();
        long Id = intent.getLongExtra(EXTRA_ID_VETCASE, 0);
        if(Id == 0) {
	        int caseType = intent.getIntExtra(EXTRA_ID_MODE, CaseType.LIVESTOCK);
	        mCase = VetCase.CreateNew((long)caseType);
        	findViewById(R.id.DeleteButton).setEnabled(false);
        	findViewById(R.id.SynchronizeCaseButton).setEnabled(false);
        }
        else {
        	List<VetCase> vcs = null;
        	EidssDatabase mDb = new EidssDatabase(mActivity);
	        vcs = mDb.VetCaseSelect(Id);
        	mDb.close();
        	if(vcs.size() != 1){
        		return;
        	}
         	mCase = vcs.get(0);
        }
        
        if(mCase.getCaseType() == CaseType.LIVESTOCK)
        	setTitle(R.string.TitleLivestockCase);
        else
        	setTitle(R.string.TitleAvianCase);
       	
        
    	findViewById(R.id.SynchronizeCaseButton).setOnClickListener(new View.OnClickListener() {
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
				if (mCase.getChanged())
					showDialog(CANCEL_DIALOG_ID);
				else {
    				setResult(RESULT_CANCELED);
    				finish();
				}
			}
		});
    	findViewById(R.id.OkButton).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				if(ValidateCase())
                {
                    if (mCase.getChanged())
                        showDialog(SAVE_DIALOG_ID);
                    else
						FinishThis(RESULT_OK);
                }
			}
		});

    	EidssDatabase mDb = new EidssDatabase(this);
    	LookupBind(R.id.RegionLookup, mDb.GisRegions(mDb.getCurrentLanguage()), mCase.getRegion(), 
    		new OnItemSelectedListener(){
				public void onItemSelected(AdapterView<?> list, View arg1, int arg2, long arg3) {
			        if (mCase.getRegion() != ((GisBaseReference)list.getSelectedItem()).idfsBaseReference) {
			            mCase.setRegion(((GisBaseReference)list.getSelectedItem()).idfsBaseReference);
			            mCase.setRayon(0);
			            mCase.setSettlement(0);
			        	EidssDatabase mDb = new EidssDatabase(_this);
			        	LookupBind(R.id.RayonLookup, mDb.GisRayons(mCase.getRegion(), mDb.getCurrentLanguage()), mCase.getRayon(), null, true);
			        	LookupBind(R.id.SettlementLookup, mDb.GisSettlements(mCase.getRayon(), mDb.getCurrentLanguage()), mCase.getSettlement(), null, true);
			        	mDb.close();
			        }
				}
				public void onNothingSelected(AdapterView<?> arg0) {
				}}, true);
    	LookupBind(R.id.RayonLookup, mDb.GisRayons(mCase.getRegion(), mDb.getCurrentLanguage()), mCase.getRayon(), 
        		new OnItemSelectedListener(){
    				public void onItemSelected(AdapterView<?> list, View arg1, int arg2, long arg3) {
    			        if (mCase.getRayon() != ((GisBaseReference)list.getSelectedItem()).idfsBaseReference) {
    			            mCase.setRayon(((GisBaseReference)list.getSelectedItem()).idfsBaseReference);
    			            mCase.setSettlement(0);
    			        	EidssDatabase mDb = new EidssDatabase(_this);
    			        	LookupBind(R.id.SettlementLookup, mDb.GisSettlements(mCase.getRayon(), mDb.getCurrentLanguage()), mCase.getSettlement(), null, true);
    			        	mDb.close();
    			        }
    				}
    				public void onNothingSelected(AdapterView<?> arg0) {
    				}}, true);
    	LookupBind(R.id.SettlementLookup, mDb.GisSettlements(mCase.getRayon(), mDb.getCurrentLanguage()), mCase.getSettlement(), 
        		new OnItemSelectedListener(){
    				public void onItemSelected(AdapterView<?> list, View arg1, int arg2, long arg3) {
    			        if (mCase.getSettlement() != ((GisBaseReference)list.getSelectedItem()).idfsBaseReference)
    			            mCase.setSettlement(((GisBaseReference)list.getSelectedItem()).idfsBaseReference);
    				}
    				public void onNothingSelected(AdapterView<?> arg0) {
    				}}, true);
        List<BaseReference> listSpecies = mDb.Reference(BaseReferenceType.rftSpeciesList, mDb.getCurrentLanguage(), VetCase.GetVetCaseHaCode(mCase.getCaseType()));
    	mDb.close();
    	

    	BaseReferenceAdapter spinnerAdapter = new BaseReferenceAdapter(mActivity, listSpecies);
        final ListView listView = (ListView) findViewById(R.id.SpeciesList);
        final SpeciesListAdapter adapter = new SpeciesListAdapter(this, mCase, spinnerAdapter,
				new OnClickListener(){
					public void onClick(View parent) {
						int getPosition = (Integer) parent.getTag();
						mCase.species_selection = getPosition;
	                    _this.showDialog(DATE_OF_SIGNS_DIALOG_ID);
				}},
		    	new OnClickListener(){
		    		public void onClick(View parent) {
						int getPosition = (Integer) parent.getTag();
			            mCase.species.get(getPosition).setStartOfSignsDate(null);
			            ExpandedListView lv = (ExpandedListView)findViewById(R.id.SpeciesList);
			            updateListItemAtPosition(lv, getPosition);
				}});
		listView.setAdapter(adapter);
		
    	findViewById(R.id.AddSpecies).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				//findViewById(R.id.AddSpecies).requestFocus();
				//findViewById(R.id.AddSpecies).requestFocusFromTouch();
				v.requestFocus();
				v.requestFocusFromTouch();
				mCase.species.add(Species.CreateNew(mCase.getId()));
				ExpandedListView lv = (ExpandedListView)findViewById(R.id.SpeciesList);
	            updateListItemAtPosition(lv, mCase.species.size()-1);
	            adapter.notifyDataSetChanged();
			}
		});
    	
        LookupBind(R.id.ReportTypeLookup, mCase.getCaseReportType(), BaseReferenceType.rftCaseReportType, 0,
    		new OnItemSelectedListener(){
				public void onItemSelected(AdapterView<?> list, View arg1, int arg2, long arg3) {
					mCase.setCaseReportType(((BaseReference)list.getSelectedItem()).idfsBaseReference);
				}
				public void onNothingSelected(AdapterView<?> arg0) {
					mCase.setCaseReportType(0);
				}}, true);
    	
        LookupBind(R.id.DiagnosisLookup, mCase.getTentativeDiagnosis(), BaseReferenceType.rftDiagnosis, VetCase.GetVetCaseHaCode(mCase.getCaseType()),
    		new OnItemSelectedListener(){
				public void onItemSelected(AdapterView<?> list, View arg1, int arg2, long arg3) {
					mCase.setTentativeDiagnosis(((BaseReference)list.getSelectedItem()).idfsBaseReference);
				}
				public void onNothingSelected(AdapterView<?> arg0) {
					mCase.setTentativeDiagnosis(0);
				}}, true);
        
        DateBind(R.id.DiagnosisDate, R.id.DiagnosisDateButton, R.id.DiagnosisDateClearButton,
        	new OnClickListener(){
				public void onClick(View arg0) {
					mCase.setTentativeDiagnosisDate(null); 
					DisplayDate(R.id.DiagnosisDate, mCase.getTentativeDiagnosisDate());
				}},
            mCase.getTentativeDiagnosisDate(), DATE_DIAGNOSIS_DIALOG_ID);
        
        DateBind(R.id.ReportDate, R.id.ReportDateButton, R.id.ReportDateClearButton,
            	new OnClickListener(){
    				public void onClick(View arg0) {
    					mCase.setReportDate(null); 
    					DisplayDate(R.id.ReportDate, mCase.getReportDate());
    				}},
                mCase.getReportDate(), DATE_REPORT_DIALOG_ID);
        
        DateTimeBind(R.id.CreatedDate, mCase.getCreateDate());
		
        EditTextBind(R.id.CaseID, mCase.getCaseID(), null, false);
        EditTextBind(R.id.FarmID, mCase.getFarmCode(), null, false);
        EditTextBind(R.id.LocalIdentifier, mCase.getLocalIdentifier(), new OnEditTextChangeListener(){ 
        	public void onEditTextChanged(String text) {
				mCase.setLocalIdentifier(text);
			}}, true);
    	EditTextBind(R.id.FarmName, mCase.getFarmName(), new OnEditTextChangeListener(){
			public void onEditTextChanged(String text) {
				mCase.setFarmName(text);
			}}, true);
    	EditTextBind(R.id.FarmOwnerLast, mCase.getOwnerLastName(), new OnEditTextChangeListener(){
			public void onEditTextChanged(String text) {
				mCase.setOwnerLastName(text);
			}}, true);
    	EditTextBind(R.id.FarmOwnerFirst, mCase.getOwnerFirstName(), new OnEditTextChangeListener(){
			public void onEditTextChanged(String text) {
				mCase.setOwnerFirstName(text);
			}}, true);
    	EditTextBind(R.id.FarmOwnerMiddle, mCase.getOwnerMiddleName(), new OnEditTextChangeListener(){
			public void onEditTextChanged(String text) {
				mCase.setOwnerMiddleName(text);
			}}, true);
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
        EditTextBind(R.id.Phone, mCase.getPhone(), new OnEditTextChangeListener(){
			public void onEditTextChanged(String text) {
				mCase.setPhone(text);
			}}, true); 
        EditTextBind(R.id.Longitude, Double.toString(mCase.getLongitude()), new OnEditTextChangeListener(){
			public void onEditTextChanged(String text) {
				Double val;
				try{
					val = Double.parseDouble(text.replace(',', '.'));
				} catch (final NumberFormatException e) {
					val = 0.0;
				}
				mCase.setLongitude(val);
			}}, true); 
        EditTextBind(R.id.Latitude, Double.toString(mCase.getLatitude()), new OnEditTextChangeListener(){
			public void onEditTextChanged(String text) {
				Double val;
				try{
					val = Double.parseDouble(text.replace(',', '.'));
				} catch (final NumberFormatException e) {
					val = 0.0;
				}
				mCase.setLatitude(val);
			}}, true); 
    	findViewById(R.id.GetCoordinatesButton).setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				//_this.startActivityForResult((new Intent()).setClass(getApplicationContext(), GeoLocationHelper.class), GEOLOCATION_GET_COORDINATES);
				_this.startActivityForResult((new Intent()).setClass(getApplicationContext(), GetLocationActivity.class), GEOLOCATION_GET_COORDINATES);
			}
		});
		
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
            case DATE_REPORT_DIALOG_ID:
                Date dtr = mCase.getReportDate() == null ? DateHelpers.Today() : mCase.getReportDate();
                return new DatePickerDialog(this,  
	        		new OnDateSetListener(){
						public void onDateSet(DatePicker arg0, int year, int month, int day) {
				            mCase.setReportDate(DateHelpers.Date(year, month, day));
				            DisplayDate(R.id.ReportDate, mCase.getReportDate());
						}}, dtr.getYear() + 1900, dtr.getMonth(), dtr.getDate());
            case DATE_OF_SIGNS_DIALOG_ID:
            	int pos = mCase.species_selection;
                Date dt2 = mCase.species.get(pos).getStartOfSignsDate() == null ? DateHelpers.Today() : mCase.species.get(pos).getStartOfSignsDate();
                return new DatePickerDialog(this,  
	        		new OnDateSetListener(){
						public void onDateSet(DatePicker arg0, int year, int month, int day) {
				            mCase.species.get(mCase.species_selection).setStartOfSignsDate(DateHelpers.Date(year, month, day));
				            ExpandedListView lv = (ExpandedListView)findViewById(R.id.SpeciesList);
				            updateListItemAtPosition(lv, mCase.species_selection);
						}}, dt2.getYear() + 1900, dt2.getMonth(), dt2.getDate());
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
            case R.string.ReportTypeMandatory:
            case R.string.DiagnosisMandatory:
            case R.string.LastNameMandatory:
            case R.string.RegionMandatory:
            case R.string.RayonMandatory:
            case R.string.DateOfDiagnosisCheckCurrent:
            case R.string.DateOfEnteredCheckDiagnosis:
            case R.string.DateOfReportCheckCurrent:
            case R.string.DateOfStartOfSignsCheckCurrent:
            case R.string.SpeciesMandatory:
            case R.string.SpeciesTypeMandatory:
            case R.string.SpeciesTotalLessDeadSick:
                return EidssAndroidHelpers.ErrorDialog(this, getResources().getString(id));
        }
        return null;
    }
	
	@Override
	protected void onPrepareDialog (int id, Dialog dialog)
	{
        switch (id)
        {
            case DATE_OF_SIGNS_DIALOG_ID:
			    DatePickerDialog datePickerDialog = (DatePickerDialog) dialog;
            	int pos = mCase.species_selection;
                Date dt2 = mCase.species.get(pos).getStartOfSignsDate() == null ? DateHelpers.Today() : mCase.species.get(pos).getStartOfSignsDate();
			    datePickerDialog.updateDate(dt2.getYear() + 1900, dt2.getMonth(), dt2.getDate());
			    break;
        }
	}
	
	@Override
    public void onActivityResult(int requestCode, int resultCode, Intent data)
    {
        if (requestCode == ACTIVITY_ID_SYNCHRONIZE_CASE)
        {
            if (resultCode == RESULT_OK)
            {
                mCase = (VetCase)data.getParcelableExtra(EXTRA_ID_VETCASE);
                Intent intent = getIntent();
                intent.putExtra(EXTRA_ID_VETCASE, mCase.getId());
                finish();
                startActivity(intent);
            }
        }
        else if (requestCode == GEOLOCATION_GET_COORDINATES)
        {
            if (resultCode == RESULT_OK)
            {
            	GeoCoordinates coords = data.getParcelableExtra(EXTRA_ID_COORDINATES);
				mCase.setLongitude(coords.Longitude);
				mCase.setLatitude(coords.Latitude);
				((EditText)findViewById(R.id.Longitude)).setText(Double.toString(mCase.getLongitude()));
				((EditText)findViewById(R.id.Latitude)).setText(Double.toString(mCase.getLatitude()));
            }
        }

        super.onActivityResult(requestCode, resultCode, data);
    }
	
	private void updateListItemAtPosition(ExpandedListView lv, int position) {
	    int visiblePosition = lv.getFirstVisiblePosition();
	    View view = lv.getChildAt(position - visiblePosition);
	    lv.getAdapter().getView(position, view, lv);
	}

	private Boolean ValidateCase(){
	
		ValidateCode vc = mCase.Validate();
		if (vc == ValidateCode.OK)
			return true;
		
		switch(vc) {
			case ReportTypeMandatory:
		        showDialog(R.string.ReportTypeMandatory);
				break;
			case DiagnosisMandatory:
				showDialog(R.string.DiagnosisMandatory);
				break;
			case LastNameMandatory:
				showDialog(R.string.FarmOwnerLastNameMandatory);
				break;
			case RegionMandatory:
				showDialog(R.string.RegionMandatory);
				break;
			case RayonMandatory:
				showDialog(R.string.RayonMandatory);
				break;
			case DateOfDiagnosisCheckCurrent:
				showDialog(R.string.DateOfDiagnosisCheckCurrent);
				break;
			case DateOfEnteredCheckDiagnosis:
		        showDialog(R.string.DateOfEnteredCheckDiagnosis);
				break;
			case DateOfReportCheckCurrent:
		        showDialog(R.string.DateOfReportCheckCurrent);
				break;
			case DateOfStartOfSignsCheckCurrent:
		        showDialog(R.string.DateOfStartOfSignsCheckCurrent);
				break;
			case SpeciesMandatory:
		        showDialog(R.string.SpeciesMandatory);
				break;
			case SpeciesTypeMandatory:
		        showDialog(R.string.SpeciesTypeMandatory);
				break;
			case SpeciesTotalLessDeadSick:
		        showDialog(R.string.SpeciesTotalLessDeadSick);
				break;
			default:
				break;
		}
		return false;
	}
	
	private void Synchronize(){
		Intent intent = new Intent();
		intent = intent.setClass(getApplicationContext(), SynchronizeVetCaseActivity.class);
		intent.putExtra("Id", mCase.getId());
		_this.startActivityForResult(intent, ACTIVITY_ID_SYNCHRONIZE_CASE);
	}
	
	private void FinishThis(int result){
		_this.setResult(result);
		_this.finish();
	}
	
	private void SaveCase(){
		EidssDatabase db = new EidssDatabase(this);
	    if (mCase.getId() == 0)
	    {
	        db.VetCaseInsert(mCase);
	    }
	    else
	    {
	        if (mCase.getStatus() != CaseStatus.NEW)
	            mCase.setStatusChanged();
	        db.VetCaseUpdate(mCase);
	    }
	    db.close();
	}
	
	private void DeleteCase(){
		EidssDatabase db = new EidssDatabase(this);
	    db.VetCaseDelete(mCase);
	    db.close();
	}

}
