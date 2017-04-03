using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using eidss.smartphone.web.Utils;
using eidss.smartphone.web.Models;
using System.Xml.Linq;
using System.Xml;
using bv.common.Resources;

namespace eidss.smartphone.web.Controllers
{
    [eidss.smartphone.web.Utils.AuthorizeEIDSS]
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
            var model = new UploadModel();
            model.HumanCases = new List<HumanCaseInfoOut>();
            foreach (string upload in Request.Files)
            {
                if (!HasFile(Request.Files[upload])) continue;
                try
                {
                    using (StreamReader reader = new StreamReader(Request.Files[upload].InputStream, System.Text.Encoding.ASCII))
                    {
                        string decripted = DecodeFrom64(reader.ReadToEnd());
                        XDocument doc = XDocument.Parse(decripted);
                        model.HumanCases = HumanCaseInfoIn.Save(doc);
                        model.VetCases = VetCaseInfoIn.Save(doc);
                    }
                }
                catch (FormatException)
                {
                    ModelState.AddModelError("", BvMessages.Get("FileCantBeDecrypted", "File can’t be decrypted"));
                }
                catch (XmlException)
                {
                    ModelState.AddModelError("", BvMessages.Get("WrongFileFormat", "Wrong file format"));
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", BvMessages.Get("GeneralError", "General error"));
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
        public FileStreamResult AndroidApp()
        {
            string localFilePath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Android/EIDSS.apk");
            return File(new FileStream(localFilePath, FileMode.Open, FileAccess.Read), "application/octet-stream", "EIDSS.apk");
        }

    }
}
