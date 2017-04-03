using System;
using System.ServiceModel;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using eidss.model.Enums;

namespace EIDSS
{
    [Activity]
    public class LoadReferencesActivity : Activity
    {
        private const int PROGRESS_DIALOG_ID = 0;
        private ProgressDialog mDialog;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetTitle(Resource.String.TitleLoadReferences);
            SetContentView(Resource.Layout.LoadReferencesLayout);

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
                ThreadPool.QueueUserWorkItem(c =>
                {
                    int iErr = 0;
                    using (EidssDatabase db = new EidssDatabase(this))
                    {
                        var opt = db.Options();
                        string url = opt.strServerUrl;
                        BaseReferenceRaw[] refs = null;
                        BaseReferenceTranslationRaw[] refs_trans = null;
                        GisBaseReferenceRaw[] gis_refs = null;
                        GisBaseReferenceTranslationRaw[] gis_refs_trans = null;
                        bool bRes = false;
                        try
                        {
                            OAClient oa = new OAClient(url);
                            bRes = oa.Proxy.LoadReferences(org.Text, name.Text, pwd.Text,
                                                                new ArrayOfLong()
                                                                {
                                                                    (long)BaseReferenceType.rftDiagnosis,
                                                                    (long)BaseReferenceType.rftHumanAgeType,
                                                                    (long)BaseReferenceType.rftHumanGender,
                                                                    (long)BaseReferenceType.rftFinalState,
                                                                    (long)BaseReferenceType.rftHospStatus
                                                                },
                                                                new ArrayOfString() { "en", "ru", "ka" },
                                                                out refs, out refs_trans, out gis_refs, out gis_refs_trans);
                        }
                        catch (EndpointNotFoundException) 
                        {
                            iErr = Resource.String.ConnectionFailed; // java.lang.IllegalArgumentException, org.xmlpull.v1.XmlPullParserException, java.net.SocketTimeoutException
                        }
                        catch (FaultException) 
                        {
                            iErr = Resource.String.AccessFailed; // java.lang.ClassCastException: org.ksoap2.SoapFault cannot be cast to org.ksoap2.serialization.SoapObject
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
                            iErr = Resource.String.LoginFailed; // java.lang.ClassCastException: org.ksoap2.serialization.NullSoapObject cannot be cast to org.ksoap2.serialization.SoapObject
                        }
                        if (bRes)
                        {
                            bRes = db.LoadReferences(refs, refs_trans, gis_refs, gis_refs_trans);
                            if (bRes)
                            {
                                opt.strLoginOrganization = org.Text;
                                opt.strLoginUsername = name.Text;
                                db.OptionsUpdate(opt);

                                this.Finish();
                            }
                        }
                    }
                    mDialog.Dismiss();

                    if (iErr != 0)
                        RunOnUiThread(() => ShowDialog(iErr));
                });
            };

            buttonCancel.Click += delegate
            {
                this.Finish();
            };
        }

        protected override Dialog OnCreateDialog(int id)
        {
            switch (id)
            {
                case PROGRESS_DIALOG_ID:
                    mDialog = ProgressDialog.Show(this, "", Resources.GetString(Resource.String.WaitLoading), true);
                    return mDialog;
                case Resource.String.ConnectionFailed:
                case Resource.String.LoginFailed:
                case Resource.String.AccessFailed:
                    return EidssAndroidHelpers.ErrorDialog(this, Resources.GetString(id));
            }
            return null;
        }

    }
}