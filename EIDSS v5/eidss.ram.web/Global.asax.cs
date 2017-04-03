using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using bv.common;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.model.Model.Validators;
using EIDSS;
using eidss.model.Core;
using eidss.model.Core.Security;
using eidss.model.Resources;
using EIDSS.RAM;
using eidss.ram.web.Components;

namespace eidss.ram.web
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

            DbManagerFactory.SetSqlFactory(new ConnectionCredentials().ConnectionString);
            EidssUserContext.Init();

            ClassLoader.Init("bv_common.dll", null);
            ClassLoader.Init("bvwin_common.dll", null);
            ClassLoader.Init("bv.common.dll", null);
            ClassLoader.Init("bv.winclient.dll", null);
            ClassLoader.Init("eidss*.dll", null);
            Localizer.MenuMessages = EidssMenu.Instance;
            BaseFieldValidator.FieldCaptions = EidssFields.Instance;

            EIDSS_LookupCacheHelper.Init();

        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            try
            {
                // Code that runs when a new session is started
                var postable = new WebPostable();
                Session["WebPostStub"] = postable;
                PresenterFactory.Init(postable);
                EidssUserContext.User.ID = -1L;

                //var manager = new EidssSecurityManager();
                //var resultCode = manager.LogIn(BaseSettings.DefaultOrganization, BaseSettings.DefaultUser, BaseSettings.DefaultPassword);
                //if (resultCode != 0)
                //{
                //    var err = string.Format("Could not login under user {0} from organization {1}.", 
                //                               BaseSettings.DefaultUser,BaseSettings.DefaultOrganization);
                //    Session[WebRamFormView.SessionError] = err;
                //    Trace.WriteLine(Trace.Kind.Error, err);
                //}
            }
            catch (DbModelException ex)
            {
                string error = string.Format("Data base server is busy. Please wait for 10 seconds and refresh page (press F5)           Technical Information:  {1}",
                                             new ConnectionCredentials().ConnectionString, ex);
                Session[WebRamFormView.SessionError] = error;
                Trace.WriteLine(ex);
            }
        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }
       

    }
}
