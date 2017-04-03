using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Web.Services.Protocols;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using bv.com.eidss;
using eidssdroid.Model;
using eidssdroid.model.Database;

namespace EIDSS
{
    [Activity]
    public class SynchronizeHumanCaseActivity : Activity
    {
        private const int PROGRESS_DIALOG_ID = 0;
        private const int RESULT_DIALOG_ID = 1;
        private ProgressDialog mDialog;
        private int iAdded = 0;
        private int iUpdated = 0;
        private int iDeleted = 0;
        private int iFailed = 0;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetTitle(Resource.String.TitleSynchronizeHumanCases);
            SetContentView(Resource.Layout.SynchronizeHumanCaseLayout);

            Button buttonOk = FindViewById<Button>(Resource.Id.OkButton);
            Button buttonCancel = FindViewById<Button>(Resource.Id.CancelButton);
            EditText org = FindViewById<EditText>(Resource.Id.LoginOrganization);
            EditText name = FindViewById<EditText>(Resource.Id.LoginName);
            EditText pwd = FindViewById<EditText>(Resource.Id.LoginPassword);
            using (EidssDatabase db = new EidssDatabase(this))
            {
                var opt = db.Options();
                org.Text = opt.strLoginOrganization;
                name.Text = opt.strLoginUsername;
            }

            buttonOk.Click += delegate
            {
                ShowDialog(PROGRESS_DIALOG_ID);
                ThreadPool.QueueUserWorkItem(i =>
                {
                    int iErr = 0;
                    using (EidssDatabase db = new EidssDatabase(this))
                    {
                        var list = db.HumanCaseSelect()
                            .Where(c => c.intStatus == (int)HumanCaseStatus.NEW || c.intStatus == (int)HumanCaseStatus.CHANGED).ToList();
                        var inp = list
                            .Select(c => new HumanCaseInfo()
                            {
                                Id = c.idfCase,
                                CaseID = c.strCaseID,
                                OfflineCaseID = c.uidOfflineCaseID,
                                LocalIdentifier = c.strLocalIdentifier,
                                TentativeDiagnosis = new BaseReferenceItem() { Id = c.idfsTentativeDiagnosis },
                                TentativeDiagnosisDate = c.datTentativeDiagnosisDate == DateTime.MinValue ? (DateTime?)null : c.datTentativeDiagnosisDate,
                                FirstName = c.strFirstName,
                                LastName = c.strFamilyName,
                                DateOfBirth = c.datDateofBirth == DateTime.MinValue ? (DateTime?)null : c.datDateofBirth,
                                PatientAge = c.intPatientAge,
                                PatientAgeType = new BaseReferenceItem() { Id = c.idfsHumanAgeType },
                                PatientGender = new BaseReferenceItem() { Id = c.idfsHumanGender },
                                CaseStatus = new BaseReferenceItem() { Id = 10109001 }, // CaseStatusEnum.InProgress
                                CurrentResidence = new AddressInfo()
                                {
                                    Country = new BaseReferenceItem() { Id = db.GisCountry(db.CurrentLanguage).idfsBaseReference },
                                    Region = new BaseReferenceItem() { Id = c.idfsRegionCurrentResidence },
                                    Rayon = new BaseReferenceItem() { Id = c.idfsRayonCurrentResidence },
                                    Settlement = new BaseReferenceItem() { Id = c.idfsSettlementCurrentResidence },
                                    Building = c.strBuilding,
                                    House = c.strHouse,
                                    Apartment = c.strApartment,
                                    Street = c.strStreetName,
                                    ZipCode = c.strPostCode,
                                    HomePhone = c.strHomePhone
                                },
                                OnsetDate = c.datOnSetDate == DateTime.MinValue ? (DateTime?)null : c.datOnSetDate,
                                PatientState = new BaseReferenceItem() { Id = c.idfsFinalState },
                                Hospitalization = new BaseReferenceItem() { Id = c.idfsHospitalizationStatus },
                                NotificationDate = c.datNotificationDate == DateTime.MinValue ? (DateTime?)null : c.datNotificationDate
                            }).ToArray();
                        HumanCaseInfo[] outp = null;
                        var opt = db.Options();
                        string url = opt.strServerUrl;
                        bool bRes = false;
                        try
                        {
                            OAClient oa = new OAClient(url);
                            bRes = oa.Proxy.SaveHumanCases(org.Text, name.Text, pwd.Text, db.CurrentLanguage, inp, out outp);
                        }
                        catch(EndpointNotFoundException)
                        {
                            iErr = Resource.String.ConnectionFailed;
                        }
                        catch (FaultException)
                        {
                            iErr = Resource.String.AccessFailed;
                        }
                        catch (CommunicationException)
                        {
                            iErr = Resource.String.ConnectionFailed;
                        }
                        catch (Exception)
                        {
                            iErr = Resource.String.ConnectionFailed;
                        }
                        if (iErr == 0 && !bRes)
                        {
                            iErr = Resource.String.LoginFailed;
                        }
                        if (bRes)
                        {
                            iAdded = 0;
                            iUpdated = 0;
                            iDeleted = 0;
                            iFailed = 0;
                            foreach (var o in outp)
                            {
                                var hc = list.SingleOrDefault(c => c.uidOfflineCaseID == o.OfflineCaseID);
                                if (hc != null)
                                {
                                    if (o.MarkedToDelete)
                                    {
                                        iDeleted++;
                                        db.HumanCaseDelete(hc);
                                    }
                                    else
                                    {
                                        if (string.IsNullOrEmpty(o.LastErrorDescription))
                                        {
                                            if (hc.idfCase == 0)
                                            {
                                                iAdded++;

                                                hc.idfCase = o.Id;
                                                hc.strCaseID = o.CaseID;
                                                hc.datNotificationDate = o.NotificationDate.Value;
                                                hc.strSentByOffice = o.NotificationSentBy.Name;
                                                hc.strSentByPerson = o.NotificationSentByPerson.Name;
                                            }
                                            else
                                                iUpdated++;

                                            hc.strLastSynError = "";
                                            hc.intStatus = (int)HumanCaseStatus.SYNCHRONIZED;
                                        }
                                        else
                                        {
                                            iFailed++;
                                            hc.strLastSynError = o.LastErrorDescription;
                                        }
                                        db.HumanCaseUpdate(hc);
                                    }
                                }
                            }

                            opt.strLoginOrganization = org.Text;
                            opt.strLoginUsername = name.Text;
                            db.OptionsUpdate(opt);

                            RunOnUiThread(() => ShowDialog(RESULT_DIALOG_ID));
                        }
                    }
                    mDialog.Dismiss();

                    if (iErr != 0)
                        RunOnUiThread(() => ShowDialog(iErr));
                });
            };

            buttonCancel.Click += delegate
            {
                SetResult(Result.Canceled);
                this.Finish();
            };
        }

        protected override Dialog OnCreateDialog(int id)
        {
            switch (id)
            {
                case PROGRESS_DIALOG_ID:
                    mDialog = ProgressDialog.Show(this, "", Resources.GetString(Resource.String.WaitSynchronizing), true);
                    return mDialog;
                case RESULT_DIALOG_ID:
                    return EidssAndroidHelpers.MessageDialog(this, 
                        String.Format(Resources.GetString(Resource.String.SynResult), iAdded, iUpdated, iDeleted, iFailed), 
                        (sender, args) =>
                            {
                                var dialog = (AlertDialog)sender;
                                dialog.Dismiss();

                                SetResult(Result.Ok);
                                this.Finish();
                            });
                case Resource.String.ConnectionFailed:
                case Resource.String.LoginFailed:
                case Resource.String.AccessFailed:
                    return EidssAndroidHelpers.ErrorDialog(this, Resources.GetString(id));
            }
            return null;
        }
    }
}