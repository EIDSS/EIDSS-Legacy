using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using eidss.model.Enums;
using eidssdroid.Model;
using eidssdroid.model.Database;

namespace EIDSS
{
    [Activity]
    public class HumanCaseActivity : Activity
    {
        private const int DELETE_DIALOG_ID = 1;
        private const int SAVE_DIALOG_ID = 2;
        private const int CANCEL_DIALOG_ID = 3;
        private const int BACK_DIALOG_ID = 4;
        private const int DATE_DIAGNOSIS_DIALOG_ID = 11;
        private const int DATE_BIRTH_DIALOG_ID = 12;
        private const int DATE_ONSET_DIALOG_ID = 13;
        private HumanCase mCase;
        private List<GisBaseReference> mRegions;
        private List<GisBaseReference> mRayons;
        private List<GisBaseReference> mSettlements;
        private Spinner mRegionSpinner;
        private Spinner mRayonSpinner;
        private Spinner mSettlementSpinner;
        private ScrollView mScroller;
        private EventHandler<DatePickerDialog.DateSetEventArgs> DiagnosisHandler;
        private EventHandler<DatePickerDialog.DateSetEventArgs> BirthHandler;
        private EventHandler<DatePickerDialog.DateSetEventArgs> OnsetHandler;

        public override void OnBackPressed()
        {
            if (mCase.bChanged)
            {
                ShowDialog(BACK_DIALOG_ID);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            mCase = (HumanCase)Intent.GetParcelableExtra("hc");

            SetTitle(Resource.String.TitleHumanCase);
            SetContentView(Resource.Layout.HumanCaseLayout);
            Button buttonOk = FindViewById<Button>(Resource.Id.OkButton);
            Button buttonCancel = FindViewById<Button>(Resource.Id.CancelButton);
            Button buttonDelete = FindViewById<Button>(Resource.Id.DeleteButton);
            mScroller = FindViewById<ScrollView>(Resource.Id.Scroll);

            buttonDelete.Click += delegate
            {
                ShowDialog(DELETE_DIALOG_ID);
            };

            buttonCancel.Click += delegate
            {
                if (mCase.bChanged)
                {
                    ShowDialog(CANCEL_DIALOG_ID);
                }
                else
                {
                    SetResult(Result.Canceled);
                    Finish();
                }
            };

            buttonOk.Click += delegate
            {
                if (mCase.idfsTentativeDiagnosis == 0)
                    ShowDialog(Resource.String.DiagnosisMandatory);
                else if (string.IsNullOrEmpty(mCase.strFamilyName))
                    ShowDialog(Resource.String.LastNameMandatory);
                else if (mCase.idfsRegionCurrentResidence == 0)
                    ShowDialog(Resource.String.RegionMandatory);
                else if (mCase.idfsRayonCurrentResidence == 0)
                    ShowDialog(Resource.String.RayonMandatory);
                else if (mCase.datDateofBirth > DateTime.Today)
                    ShowDialog(Resource.String.DateOfBirthCheckCurrent);
                else if (mCase.datOnSetDate > DateTime.Today)
                    ShowDialog(Resource.String.DateOfSymptomCheckCurrent);
                else if (mCase.datTentativeDiagnosisDate > DateTime.Today)
                    ShowDialog(Resource.String.DateOfDiagnosisCheckCurrent);
                else if (mCase.datTentativeDiagnosisDate > DateTime.MinValue && mCase.datNotificationDate > DateTime.MinValue && mCase.datTentativeDiagnosisDate > mCase.datNotificationDate)
                    ShowDialog(Resource.String.DateOfDiagnosisCheckNotification);
                else if (mCase.datDateofBirth > DateTime.MinValue && mCase.datTentativeDiagnosisDate > DateTime.MinValue && mCase.datDateofBirth > mCase.datTentativeDiagnosisDate)
                    ShowDialog(Resource.String.DateOfBirthCheckDiagnosis);
                else if (mCase.datDateofBirth > DateTime.MinValue && mCase.datNotificationDate > DateTime.MinValue && mCase.datDateofBirth > mCase.datNotificationDate)
                    ShowDialog(Resource.String.DateOfBirthCheckNotification);
                else if (mCase.datOnSetDate > DateTime.MinValue && mCase.datTentativeDiagnosisDate > DateTime.MinValue && mCase.datOnSetDate > mCase.datTentativeDiagnosisDate)
                    ShowDialog(Resource.String.DateOfSymptomCheckDiagnosis);
                else
                {
                    if (mCase.bChanged)
                    {
                        ShowDialog(SAVE_DIALOG_ID);
                    }
                    else
                    {
                        Intent.PutExtra("hc", mCase);
                        SetResult(Result.Ok, Intent);
                        Finish();
                    }
                }
            };



            mRegionSpinner = FindViewById<Spinner>(Resource.Id.RegionLookup);
            mRayonSpinner = FindViewById<Spinner>(Resource.Id.RayonLookup);
            mSettlementSpinner = FindViewById<Spinner>(Resource.Id.SettlementLookup);

            using (var mDb = new EidssDatabase(this))
            {
                mRegions = mDb.GisRegions(mDb.CurrentLanguage);
                mRayons = mDb.GisRayons(mCase.idfsRegionCurrentResidence, mDb.CurrentLanguage);
                mSettlements = mDb.GisSettlements(mCase.idfsRayonCurrentResidence, mDb.CurrentLanguage);
            }
            mRegionSpinner.Adapter = new GisBaseReferenceAdapter(this, mRegions);
            mRayonSpinner.Adapter = new GisBaseReferenceAdapter(this, mRayons);
            mSettlementSpinner.Adapter = new GisBaseReferenceAdapter(this, mSettlements);
            mRegionSpinner.SetSelection(mRegions.FindIndex(c => c.idfsBaseReference == mCase.idfsRegionCurrentResidence));
            mRayonSpinner.SetSelection(mRayons.FindIndex(c => c.idfsBaseReference == mCase.idfsRayonCurrentResidence));
            mSettlementSpinner.SetSelection(mSettlements.FindIndex(c => c.idfsBaseReference == mCase.idfsSettlementCurrentResidence));

            mRegionSpinner.Touch += (sender, args) => { args.Handled = false; mScroller.RequestChildFocus(mRegionSpinner, mRegionSpinner); };
            mRayonSpinner.Touch += (sender, args) => { args.Handled = false; mScroller.RequestChildFocus(mRayonSpinner, mRayonSpinner); };
            mSettlementSpinner.Touch += (sender, args) => { args.Handled = false; mScroller.RequestChildFocus(mSettlementSpinner, mSettlementSpinner); };

            mRegionSpinner.ItemSelected += region_spinner_ItemSelected;
            mRayonSpinner.ItemSelected += rayon_spinner_ItemSelected;
            mSettlementSpinner.ItemSelected += settlement_spinner_ItemSelected;

            LookupBind(Resource.Id.DiagnosisLookup, mCase.idfsTentativeDiagnosis, (long)BaseReferenceType.rftDiagnosis, 2,
                       (args, list) => mCase.idfsTentativeDiagnosis = list[args.Position].idfsBaseReference);
            LookupBind(Resource.Id.HumanAgeType, mCase.idfsHumanAgeType, (long)BaseReferenceType.rftHumanAgeType, 2,
                       (args, list) => mCase.idfsHumanAgeType = list[args.Position].idfsBaseReference,
                       mCase.datDateofBirth == DateTime.MinValue);
            LookupBind(Resource.Id.HumanGenderLookup, mCase.idfsHumanGender, (long)BaseReferenceType.rftHumanGender, 0,
                       (args, list) => mCase.idfsHumanGender = list[args.Position].idfsBaseReference);
            LookupBind(Resource.Id.FinalStateLookup, mCase.idfsFinalState, (long)BaseReferenceType.rftFinalState, 0,
                       (args, list) => mCase.idfsFinalState = list[args.Position].idfsBaseReference);
            LookupBind(Resource.Id.HospitalizationStatusLookup, mCase.idfsHospitalizationStatus, (long)BaseReferenceType.rftHospStatus, 0,
                       (args, list) => mCase.idfsHospitalizationStatus = list[args.Position].idfsBaseReference);

            DateBind(Resource.Id.DiagnosisDate, Resource.Id.DiagnosisDateButton, Resource.Id.DiagnosisDateClearButton,
                (c) => { mCase.datTentativeDiagnosisDate = DateTime.MinValue; DisplayDate(Resource.Id.DiagnosisDate, mCase.datTentativeDiagnosisDate); },
                mCase.datTentativeDiagnosisDate, HumanCaseActivity.DATE_DIAGNOSIS_DIALOG_ID);
            DiagnosisHandler = (sender, args) =>
            {
                mCase.datTentativeDiagnosisDate = args.Date;
                DisplayDate(Resource.Id.DiagnosisDate, mCase.datTentativeDiagnosisDate);
            };
            DateBind(Resource.Id.DateofBirth, Resource.Id.DateofBirthButton, Resource.Id.DateofBirthClearButton,
                (c) =>
                {
                    mCase.datDateofBirth = DateTime.MinValue;
                    DisplayDate(Resource.Id.DateofBirth, mCase.datDateofBirth);

                    var ed = FindViewById<EditText>(Resource.Id.PatientAge);
                    var sp = FindViewById<Spinner>(Resource.Id.HumanAgeType);
                    ed.Enabled = true;
                    sp.Enabled = true;
                },
                mCase.datDateofBirth, HumanCaseActivity.DATE_BIRTH_DIALOG_ID);
            BirthHandler = (sender, args) =>
            {
                mCase.datDateofBirth = args.Date;
                DisplayDate(Resource.Id.DateofBirth, mCase.datDateofBirth);

                var ed = FindViewById<EditText>(Resource.Id.PatientAge);
                var sp = FindViewById<Spinner>(Resource.Id.HumanAgeType);

                mCase.intPatientAge = mCase.CalcPatientAge();
                mCase.idfsHumanAgeType = mCase.CalcPatientAgeType();
                ed.Text = mCase.intPatientAge.ToString();
                BaseReferenceAdapter ad = (BaseReferenceAdapter)sp.Adapter;
                sp.SetSelection(ad.items.FindIndex(c => c.idfsBaseReference == mCase.idfsHumanAgeType));
                ed.Enabled = false;
                sp.Enabled = false;
            };
            DateBind(Resource.Id.DateOnSet, Resource.Id.DateOnSetButton, Resource.Id.DateOnSetClearButton,
                (c) => { mCase.datOnSetDate = DateTime.MinValue; DisplayDate(Resource.Id.DateOnSet, mCase.datOnSetDate); },
                mCase.datOnSetDate, HumanCaseActivity.DATE_ONSET_DIALOG_ID);
            OnsetHandler = (sender, args) =>
            {
                mCase.datOnSetDate = args.Date;
                DisplayDate(Resource.Id.DateOnSet, mCase.datOnSetDate);
            };
            DateBind(Resource.Id.NotificationDate, 0, 0, (c) => { }, mCase.datNotificationDate, 0);

            EditTextBind(Resource.Id.CaseID, mCase.strCaseID, (sender, args) => { }, false);
            EditTextBind(Resource.Id.LocalIdentifier, mCase.strLocalIdentifier, (sender, args) => mCase.strLocalIdentifier = ((EditText)sender).Text);
            EditTextBind(Resource.Id.FamilyName, mCase.strFamilyName, (sender, args) => mCase.strFamilyName = ((EditText)sender).Text);
            EditTextBind(Resource.Id.FirstName, mCase.strFirstName, (sender, args) => mCase.strFirstName = ((EditText)sender).Text);
            EditTextBind(Resource.Id.PatientAge, mCase.intPatientAge == 0 ? "" : mCase.intPatientAge.ToString(),
                (sender, args) => { int res; if (Int32.TryParse(((EditText)sender).Text, out res)) mCase.intPatientAge = res; },
                mCase.datDateofBirth == DateTime.MinValue);
            EditTextBind(Resource.Id.Building, mCase.strBuilding, (sender, args) => mCase.strBuilding = ((EditText)sender).Text);
            EditTextBind(Resource.Id.House, mCase.strHouse, (sender, args) => mCase.strHouse = ((EditText)sender).Text);
            EditTextBind(Resource.Id.Apt, mCase.strApartment, (sender, args) => mCase.strApartment = ((EditText)sender).Text);
            EditTextBind(Resource.Id.Street, mCase.strStreetName, (sender, args) => mCase.strStreetName = ((EditText)sender).Text);
            EditTextBind(Resource.Id.PostCode, mCase.strPostCode, (sender, args) => mCase.strPostCode = ((EditText)sender).Text);
            EditTextBind(Resource.Id.Phone, mCase.strHomePhone, (sender, args) => mCase.strHomePhone = ((EditText)sender).Text);
            EditTextBind(Resource.Id.SentByPerson, mCase.strSentByPerson, (sender, args) => { }, false);
            EditTextBind(Resource.Id.SentByOffice, mCase.strSentByOffice, (sender, args) => { }, false);
        }

        private void DisplayDate(int id, DateTime dt)
        {
            var ed = FindViewById<EditText>(id);
            if (dt == DateTime.MinValue) ed.Text = "";
            else ed.Text = dt.ToString("d");
        }

        private void LookupBind(int id, long def, long rft, int ha, Action<AdapterView.ItemSelectedEventArgs, List<BaseReference>> handler, bool bEnabled = true)
        {
            var sp = FindViewById<Spinner>(id);
            using (var mDb = new EidssDatabase(this))
            {
                var list = mDb.Reference(rft, mDb.CurrentLanguage, ha);
                sp.Adapter = new BaseReferenceAdapter(this, list);
                sp.SetSelection(list.FindIndex(c => c.idfsBaseReference == def));
                sp.ItemSelected += (sender, args) => handler(args, list);
            }
            sp.Enabled = bEnabled;

            sp.Touch += (sender, args) => { args.Handled = false; mScroller.RequestChildFocus(sp, sp); };
        }

        private void EditTextBind(int id, string def, EventHandler<TextChangedEventArgs> handler, bool bEnabled = true)
        {
            var ed = FindViewById<EditText>(id);
            ed.Text = def;
            ed.Enabled = bEnabled;
            ed.TextChanged += handler;
        }

        private void DateBind(int edit_id, int btn_id, int btn_clr, Action<bool> act_clr, DateTime def, int dlg)
        {
            DisplayDate(edit_id, def);
            if (btn_id != 0)
            {
                var bt = FindViewById<Button>(btn_id);
                bt.Click += (sender, args) => this.ShowDialog(dlg);
            }
            if (btn_clr != 0)
            {
                var bt = FindViewById<Button>(btn_clr);
                bt.Click += (sender, args) => act_clr(true);
            }
        }

        void region_spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (mCase.idfsRegionCurrentResidence != mRegions[e.Position].idfsBaseReference)
            {
                mCase.idfsRegionCurrentResidence = mRegions[e.Position].idfsBaseReference;
                mCase.idfsRayonCurrentResidence = 0;
                mCase.idfsSettlementCurrentResidence = 0;
                using (var mDb = new EidssDatabase(this))
                {
                    mRayons = mDb.GisRayons(mCase.idfsRegionCurrentResidence, mDb.CurrentLanguage);
                    mSettlements = mDb.GisSettlements(mCase.idfsRayonCurrentResidence, mDb.CurrentLanguage);
                }
                mRayonSpinner.Adapter = new GisBaseReferenceAdapter(this, mRayons);
                mSettlementSpinner.Adapter = new GisBaseReferenceAdapter(this, mSettlements);
                mRayonSpinner.SetSelection(-1);
                mSettlementSpinner.SetSelection(-1);
            }
        }
        void rayon_spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (mCase.idfsRayonCurrentResidence != mRayons[e.Position].idfsBaseReference)
            {
                mCase.idfsRayonCurrentResidence = mRayons[e.Position].idfsBaseReference;
                mCase.idfsSettlementCurrentResidence = 0;
                using (var mDb = new EidssDatabase(this))
                {
                    mSettlements = mDb.GisSettlements(mCase.idfsRayonCurrentResidence, mDb.CurrentLanguage);
                }
                mSettlementSpinner.Adapter = new GisBaseReferenceAdapter(this, mSettlements);
                mSettlementSpinner.SetSelection(-1);
            }
        }
        void settlement_spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (mCase.idfsSettlementCurrentResidence != mSettlements[e.Position].idfsBaseReference)
            {
                mCase.idfsSettlementCurrentResidence = mSettlements[e.Position].idfsBaseReference;
            }
        }

        protected override Dialog OnCreateDialog(int id)
        {
            switch (id)
            {
                case DATE_DIAGNOSIS_DIALOG_ID:
                    var dt1 = mCase.datTentativeDiagnosisDate == DateTime.MinValue ? DateTime.Today : mCase.datTentativeDiagnosisDate;
                    return new DatePickerDialog(this, DiagnosisHandler, dt1.Year, dt1.Month - 1, dt1.Day);
                case DATE_BIRTH_DIALOG_ID:
                    var dt2 = mCase.datDateofBirth == DateTime.MinValue ? DateTime.Today : mCase.datDateofBirth;
                    return new DatePickerDialog(this, BirthHandler, dt2.Year, dt2.Month - 1, dt2.Day);
                case DATE_ONSET_DIALOG_ID:
                    var dt3 = mCase.datOnSetDate == DateTime.MinValue ? DateTime.Today : mCase.datOnSetDate;
                    return new DatePickerDialog(this, OnsetHandler, dt3.Year, dt3.Month - 1, dt3.Day);
                case DELETE_DIALOG_ID:
                    return EidssAndroidHelpers.QuestionDialog(this, 
                        mCase.idfCase == 0
                            ? Resources.GetString(Resource.String.ConfirmToDeleteNewCase)
                            : Resources.GetString(Resource.String.ConfirmToDeleteSynCase),
                        (sender, args) =>
                        {
                            Intent.PutExtra("hc", mCase);
                            SetResult(Result.FirstUser, Intent);
                            Finish();
                        },
                        (sender, args) =>
                        {
                            var dialog = (AlertDialog)sender;
                            dialog.Dismiss();
                        });
                case SAVE_DIALOG_ID:
                    return EidssAndroidHelpers.QuestionDialog(this,
                        Resources.GetString(Resource.String.ConfirmSaveCase),
                        (sender, args) =>
                        {
                            Intent.PutExtra("hc", mCase);
                            SetResult(Result.Ok, Intent);
                            Finish();
                        },
                        (sender, args) =>
                        {
                            var dialog = (AlertDialog)sender;
                            dialog.Dismiss();
                        });
                case CANCEL_DIALOG_ID:
                    return EidssAndroidHelpers.QuestionDialog(this,
                        Resources.GetString(Resource.String.ConfirmCancelCase),
                        (sender, args) =>
                        {
                            SetResult(Result.Canceled);
                            Finish();
                        },
                        (sender, args) =>
                        {
                            var dialog = (AlertDialog)sender;
                            dialog.Dismiss();
                        });
                case BACK_DIALOG_ID:
                    return EidssAndroidHelpers.QuestionDialog(this,
                        Resources.GetString(Resource.String.ConfirmCancelCase),
                        (sender, args) =>
                        {
                            base.OnBackPressed();
                        },
                        (sender, args) =>
                        {
                            var dialog = (AlertDialog)sender;
                            dialog.Dismiss();
                        });
                case Resource.String.DiagnosisMandatory:
                case Resource.String.LastNameMandatory:
                case Resource.String.RegionMandatory:
                case Resource.String.RayonMandatory:
                case Resource.String.DateOfBirthCheckCurrent:
                case Resource.String.DateOfSymptomCheckCurrent:
                case Resource.String.DateOfDiagnosisCheckCurrent:
                case Resource.String.DateOfDiagnosisCheckNotification:
                case Resource.String.DateOfBirthCheckDiagnosis:
                case Resource.String.DateOfBirthCheckNotification:
                case Resource.String.DateOfSymptomCheckDiagnosis:
                    return EidssAndroidHelpers.ErrorDialog(this, Resources.GetString(id));
            }
            return null;
        }

    }


}