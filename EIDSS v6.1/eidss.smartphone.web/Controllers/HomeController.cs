using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Xml;

using bv.common.Resources;

using eidss.smartphone.web.Utils;
using eidss.smartphone.web.Models;

namespace eidss.smartphone.web.Controllers
{
    [AuthorizeEIDSS]
    public class HomeController : Controller
    {
        public static bool HasFile(HttpPostedFileBase file)
        {
            return (file != null && file.ContentLength > 0) ? true : false;
        }

        private static string DecodeFrom64(string encodedData)
        {
            byte[] encodedDataAsBytes = System.Convert.FromBase64String(encodedData);
            string returnValue = System.Text.Encoding.GetEncoding("UTF-8").GetString(encodedDataAsBytes);
            return returnValue;
        }

        public ActionResult Index()
        {
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            ViewBag.Version = string.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);

            var model = new UploadModel();
            model.HumanCases = new List<HumanCaseInfoOut>();
            try
            {
                long a = Request.InputStream.Length;
                foreach (string upload in Request.Files)
                {
                    if (!HasFile(Request.Files[upload])) continue;

                    eidss.model.Core.EidssUserContext.SmartphoneContext = true;
                    
                    try
                    {
                        using (StreamReader reader = new StreamReader(Request.Files[upload].InputStream, System.Text.Encoding.ASCII))
                        {
                            string decripted = DecodeFrom64(reader.ReadToEnd());
                            XDocument doc = XDocument.Parse(decripted);
                            model.HumanCases = HumanCaseInfoIn.Save(doc);
                            model.VetCases = VetCaseInfoIn.Save(doc);
                            model.ASSessions = ASSessionInfoIn.Save(doc);
                        }
                    }
                    catch (FormatException e)
                    {
                        ModelState.AddModelError("", BvMessages.Get("FileCantBeDecrypted", "File can’t be decrypted") + "\n" + e.Message);
                    }
                    catch (XmlException)
                    {
                        ModelState.AddModelError("", BvMessages.Get("WrongFileFormat", "Wrong file format"));
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("", BvMessages.Get("GeneralError", "General error") + "\n" + e.Message);
                    }
                }
            }
            catch(HttpException ex)
            {
                if (ex.WebEventCode == System.Web.Management.WebEventCodes.RuntimeErrorPostTooLarge)
                {
                    //RuntimeErrorPostTooLarge (code 3004). This indicates that the size of the posted information exceeded the allowed limits.
                     ModelState.AddModelError("", "Your uploaded file exceeded the allowed limit");
                }
                else
                {
                    //Other exception
                    ModelState.AddModelError("", ex.Message);
                }
            }

            return View(model);
        }

        [System.Web.Mvc.HttpGet]
        public FileContentResult Referencies()
        {
            string refs = RefsSerializer.GetReferencies();
            byte[] content = new System.Text.UTF8Encoding().GetBytes(refs);
            return File(content, "application/octet-stream", "References.eidss");
        }

        [System.Web.Mvc.HttpGet]
        public FileContentResult Lists()
        {
            string lists = ListsSerializer.GetLists();
            byte[] content = new System.Text.UTF8Encoding().GetBytes(lists);
            return File(content, "application/octet-stream", "Lists.eidss");
        }

        [System.Web.Mvc.HttpGet]
        public FileStreamResult AndroidApp()
        {
            string localFilePath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Android/EIDSS.apk");
            return File(new FileStream(localFilePath, FileMode.Open, FileAccess.Read), "application/octet-stream", "EIDSS.apk");
        }

    }
}
