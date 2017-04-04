using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Web;
using bv.common.Configuration;
using bv.common.Core;

namespace bv.common.Resources.TranslationTool
{

    public class TranslatorItem
    {
        //public static long _id = 1;
        //public long Id { get; set; }
        public string Key { get; set; }
        public string Lang1 { get; set; }
        public string Lang2 { get; set; }
        public string Val { get; set; }
        public string Split { get; set; }
        public bool IsValueExists { get; set; }
        //public TranslatorItem()
        //{
        //    Id = _id++;
        //}
    }

    public class TranslatorContainer : List<TranslatorItem>
    {
    }

    /*
    public class TranslatorContainer : Dictionary<string, Dictionary<string, Tuple<string, string, string, string>>>
    {

    }
    */


    public static class TranslationToolOnlineStorage
    {
        private static Dictionary<CultureInfo, Dictionary<string, TranslatorContainer>>
            g_translatedContainer = new Dictionary<CultureInfo, Dictionary<string, TranslatorContainer>>();

        //private static Dictionary<CultureInfo, Dictionary<string, Dictionary<string, string>>>
        //    g_translatedCache = new Dictionary<CultureInfo, Dictionary<string, Dictionary<string, string>>>();

        private static string g_lastPage = null;

        private static List<Tuple<string, string, string, string>> g_resourcesFormView = new List<Tuple<string, string, string, string>>();


        internal static void AddTranslated(BaseStringsStorage source, string key, string val, bool bSplit, string langId)
        {
            if (BaseSettings.TranslationMode)
            {
                var ci = langId == null ? Thread.CurrentThread.CurrentUICulture : new CultureInfo(CustomCultureHelper.GetCustomCultureName(langId));
                string page = getPageForWeb();
                var n = source.ResourceName.Split('.');
                string sourceName = n[n.Length - 1];
                if (page != null)
                {
                    lock (g_translatedContainer)
                    {
                        if (!g_translatedContainer.ContainsKey(ci))
                            g_translatedContainer.Add(ci, new Dictionary<string, TranslatorContainer>());

                        if (!g_translatedContainer[ci].ContainsKey(page))
                            g_translatedContainer[ci].Add(page, new TranslatorContainer());

                        string k = page + "*" + ci.Name + "*" + sourceName + "*" + key;
                        if (g_translatedContainer[ci][page].Find(c => c.Key == k) == null)
                        {
                            string[] langs = Config.GetSetting("TranslationModeLanguages", "en").Split(',');
                            string l1 = langs.Length > 0 ? source.GetStringInternal(key, key, langs[0]) : "";
                            var bIsValueExists = source.IsValueExists;
                            string l2 = langs.Length > 1 ? source.GetStringInternal(key, key, langs[1]) : "";
                            bIsValueExists = bIsValueExists || source.IsValueExists;
                            g_translatedContainer[ci][page].Add(new TranslatorItem() { Key = k, Lang1 = l1, Lang2 = l2, Val = val, Split = bSplit ? "true" : "", IsValueExists = bIsValueExists });
                        }
                        else
                        {
                            var item = g_translatedContainer[ci][page].Find(c => c.Key == k);
                            item.Val = val;
                            item.Split = bSplit ? "true" : "";
                        }

                    }
                }

                if (!bSplit)
                    CommonResourcesCache.SetText(sourceName, ci.Name, key, val);

            }
            // in the scanning resources usage mode - gather in g_resourcesFormView forms and views where current function was invoked from
            if (BaseSettings.ScanFormsMode)
            {
                var formView = GetFormViewFromStack();

                // remember found form and view
                string file = source.ResourceName.Substring(source.ResourceName.LastIndexOf('.') + 1);
                g_resourcesFormView.Add(new Tuple<string, string, string, string>(key, file, formView.Item1, formView.Item2));
            }
        }

        private static Dictionary<string, string> g_dirsRes = new Dictionary<string, string>();
            //{
            //    {"BvMessages", @"App_Data\Translations\Resources\developersbranch_v6\bv.common\Resources\"},
            //    {"XtraStrings", @"App_Data\Translations\Resources\developersbranch_v6\bv.common\Resources\"},
            //    {"EidssFields", @"App_Data\Translations\Resources\developersbranch_v6\eidss.core\Resources\"},
            //    {"EidssMenu", @"App_Data\Translations\Resources\developersbranch_v6\eidss.core\Resources\"},
            //    {"EidssMessages", @"App_Data\Translations\Resources\developersbranch_v6\eidss.core\Resources\"}
            //};
        private static string MakePath(string sourceName, CultureInfo ci)
        {
            var key = string.Join(".", sourceName, ci.Name);
            if (!g_dirsRes.ContainsKey(key))
                g_dirsRes.Add(key, TranslationToolHelper.GetFullPathToResX(sourceName, ci.Name));
            return string.IsNullOrEmpty(g_dirsRes[key]) ? null : g_dirsRes[key];

            //string root = Utils.GetExecutingPath();
            //string dir = g_dirsRes[sourceName];
            //return string.Format("{0}{1}{2}.{3}.resx", root, dir, sourceName, ci.Name);
        }
        private static string MakePath(string sourceName, string langId)
        {
            var ci = langId == null ? Thread.CurrentThread.CurrentUICulture : new CultureInfo(CustomCultureHelper.GetCustomCultureName(langId));
            return MakePath(sourceName, ci);
        }
        private static string MakeDefaultPath(string sourceName)
        {
            if (!g_dirsRes.ContainsKey(sourceName))
                g_dirsRes.Add(sourceName, TranslationToolHelper.GetFullPathToResX(sourceName, null));
            return string.IsNullOrEmpty(g_dirsRes[sourceName]) ? null : g_dirsRes[sourceName];
            //string root = Utils.GetExecutingPath();
            //string dir = g_dirsRes[sourceName];
            //return string.Format("{0}{1}{2}.resx", root, dir, sourceName);
        }

        private static string ReadFormResx(string sourceName, string cultureName, string key, string stringValue, out bool found)
        {
            string ret = null;
            string filename = MakePath(sourceName, cultureName);
            ret = ResourceHelper.ReadResxTextValue(filename, key);
            if (ret == null)
            {
                filename = MakeDefaultPath(sourceName);
                ret = ResourceHelper.ReadResxTextValue(filename, key);
            }
            found = ret != null;
            return ret ?? stringValue;
        }
        private static void WriteToResx(string sourceName, CultureInfo ci, string key, string newValue)
        {
            string filename = MakePath(sourceName, ci);
            ResourceHelper.WriteToResx(filename, key, newValue);
        }

        internal static Tuple<string, bool> GetTranslated(BaseStringsStorage source, string key, string stringValue, string langId, string parentViewName, out bool found)
        {
            if (BaseSettings.TranslationMode)
            {
                // During resource reading in Translation mode we first check SplittedResources xml file - if it contains given resource for currently translated view.

                string view = null;
                if (parentViewName == null)
                {
                    var formView = GetFormViewFromStack();
                    view = String.IsNullOrEmpty(formView.Item2) ? formView.Item1 : formView.Item2;
                }
                else
                {
                    view = parentViewName;
                }
                string splitted;
                if ((splitted = ResourceSplitter.Read(view, key, langId, null)) != null)
                {
                    found = true;
                    return new Tuple<string, bool>(splitted, true);
                }

                //////////////////////////////

                var ci = langId == null ? Thread.CurrentThread.CurrentUICulture : new CultureInfo(CustomCultureHelper.GetCustomCultureName(langId));
                var n = source.ResourceName.Split('.');
                string sourceName = n[n.Length - 1];

                if (CommonResourcesCache.ContainsKey(sourceName, ci.Name, key))
                {
                    found = true;
                    source.IsValueExists = true;
                    return new Tuple<string, bool>(CommonResourcesCache.GetText(sourceName, ci.Name, key), false);
                }

                if (HttpContext.Current != null)
                {

                    return new Tuple<string, bool>(ReadFormResx(sourceName, langId, key, stringValue, out found), false);
                }
            }
            var res = new Tuple<string, bool>(source.GetStringInternal(key, stringValue, langId), false);
            found = source.IsValueExists;
            return res;
        }

        public static void SetTranslated(TranslatorItem item)
        {
            if (BaseSettings.TranslationMode)
            {
                string[] k = item.Key.Split('*');
                string page = k[0];
                string ciName = k[1];
                var ci = new CultureInfo(ciName);
                string sourceName = k[2];
                string key = k[3];
                WriteToResx(sourceName, ci, key, item.Val);
                
                if (item.Split != "true")
                    CommonResourcesCache.SetText(sourceName, ciName, key, item.Val);

                lock (g_translatedContainer)
                {
                    if (g_translatedContainer.ContainsKey(ci))
                    {
                        if (g_translatedContainer[ci].ContainsKey(page))
                        {
                            var i = g_translatedContainer[ci][page].SingleOrDefault(c => c.Key == item.Key);
                            if (i != null)
                            {
                                i.Val = item.Val;
                            }
                        }
                    }
                }
            }
        }


        public static TranslatorContainer GetTranslated(string page, string langId = null)
        {
            if (BaseSettings.TranslationMode)
            {
                var ci = langId == null ? Thread.CurrentThread.CurrentUICulture : new CultureInfo(CustomCultureHelper.GetCustomCultureName(langId));
                lock (g_translatedContainer)
                {
                    if (g_translatedContainer.ContainsKey(ci) && g_translatedContainer[ci].ContainsKey(page))
                        return g_translatedContainer[ci][page];
                }
            }
            return null;
        }

        public static List<Tuple<string, string, string, string>> GetResourcesFormView()
        {
            if (BaseSettings.ScanFormsMode)
            {
                lock (g_resourcesFormView)
                {
                    return g_resourcesFormView;
                }
            }
            return null;
        }

        private static string getPageForWeb()
        {
            string ret = null;
            var stackTrace = new StackTrace();
            for (var i = 1; i < stackTrace.FrameCount; i++)
            {
                var stackFrame = stackTrace.GetFrame(i);
                var methodBase = stackFrame.GetMethod();
                if (methodBase.Name == "Execute" && methodBase.ReflectedType.FullName.StartsWith("ASP."))
                {
                    ret = methodBase.ReflectedType.FullName;
                }
            }
            if (ret != null)
            {
                if (ret.Contains("Shared") && ret.Contains("Layout") && g_lastPage != null)
                {
                    ret = g_lastPage;
                }
                else
                    g_lastPage = ret;
            }
            return ret;
        }

        public static string formNameDefault = "";
        private static Tuple<string, string> GetFormViewFromStack()
        {
            if (HttpContext.Current != null)
            {
                return new Tuple<string, string>(getPageForWeb(), null);
            }

            string form = "eidss.main.MainForm";
            Type methodType = null;
            MethodBase methodBase = null;

            var stackTrace = new StackTrace();

            ////search first invoke from ScanWinForms - it will be our form
            //var i = stackTrace.FrameCount - 1;
            //do
            //{
            //    methodBase = stackTrace.GetFrame(i--).GetMethod();
            //} while (i > 2 && (
            //     methodBase.ReflectedType == null || methodBase.ReflectedType.Name == "BaseForm" ||
            //     methodBase.ReflectedType.GetInterface("ITranslationView") == null
            //    //methodBase.ReflectedType.Name == "AggregateMatrixForm" || methodBase.ReflectedType.FullName == "eidss.main.Program" ||
            //    //(!methodBase.ReflectedType.FullName.StartsWith("eidss", StringComparison.InvariantCultureIgnoreCase) && !methodBase.ReflectedType.FullName.StartsWith("bv.", StringComparison.InvariantCultureIgnoreCase))
            //    ));

            //// form found
            //if (i > 2)
            //    form = methodBase.ReflectedType.FullName;

            //// закопанная проблема: в стеке - базовый класс, нам же нужен производный. На данный момент это единственный случай (BaseFarmTreePanel-RootFarmTree).
            //if (form == "EIDSS.BaseFarmTreePanel")
            //    form = "EIDSS.RootFarmTree";
            string currentViewName = "";
            string viewName = "";
            int iApplicationFormsCount = 0;
            for (int k = 3; k < stackTrace.FrameCount; k++)
            {
                var stackFrame = stackTrace.GetFrame(k);
                methodBase = stackFrame.GetMethod();
                methodType = methodBase.ReflectedType;
                //Type tpParent = IsChildOf(methodType, "BasePanel`1");
                //if (tpParent == null) tpParent = IsChildOf(methodType, "BaseForm");
                //if (tpParent != null)
                if (methodType != null && methodType.GetInterface("ITranslationView") != null && methodType.Name != currentViewName)
                {

                    if (iApplicationFormsCount > 0 && (methodType.Name.StartsWith("BaseDetailPanel") || methodType.Name.StartsWith("BaseListPanel") || methodType.Name.StartsWith("BaseDetailForm")))
                        break;
                    var isIApplicationForm = methodType.GetInterface("IApplicationForm") != null;
                    currentViewName = methodType.Name;
                    if (currentViewName.Contains("`") || currentViewName.StartsWith("BaseListPanel_") || currentViewName.StartsWith("BaseDetailPanel_") || methodType.GetInterface("ILayout") != null)
                        continue;
                    if (!methodType.Name.StartsWith("Base") && isIApplicationForm)
                        iApplicationFormsCount += 1;
                    if (methodType.Name.StartsWith("Base") && isIApplicationForm)
                        continue;
                    if(methodType.FullName == formNameDefault)
                        currentViewName = "";
                    if (viewName.EndsWith("ActionPanel") && currentViewName.EndsWith("ActionPanel"))
                        currentViewName = "";
                    viewName = viewName == "" ? currentViewName : (currentViewName == "" ? viewName : currentViewName + "." + viewName);
                    if (isIApplicationForm)
                        form =  methodBase.ReflectedType.FullName;
                    if (!methodType.Name.StartsWith("Base") && methodType.GetInterface("IDetailPanel") != null || methodType.GetInterface("IBaseListPanel") != null)
                        break;
                }
            }
            form = formNameDefault;
            // now search view
            //for (; i > 2; i--)
            //{
            //    var stackFrame = stackTrace.GetFrame(i);
            //    methodBase = stackFrame.GetMethod();
            //    methodType = methodBase.ReflectedType;
            //    if (methodType.FullName == form)
            //        continue;
            //    if (methodType.Name != "BaseGroupPanel`1")
            //    {
            //        //Type tpParent = IsChildOf(methodType, "BasePanel`1");
            //        //if (tpParent == null) tpParent = IsChildOf(methodType, "BaseForm");
            //        //if (tpParent != null)
            //        if (methodType.GetInterface("ITranslationView") != null && methodType.Name != "BasePanel`1" && methodType.Name != "BaseForm")
            //        {
            //            if (methodBase.Name == "get_SearchPanel" || methodBase.Name == "CreateSearchPanel")// || methodType.Name == "BaseSearchPanel")
            //            {
            //                if (form == "bv.winclient.BasePanel.BaseGridPanel`1")
            //                    form = "SearchPanel";
            //                else
            //                    view = "SearchPanel";
            //            }
            //            else
            //                view = methodType.FullName;
            //            break;
            //        }
            //    }
            //    else
            //    {
            //        if (stackTrace.GetFrame(i + 1).GetMethod().ReflectedType.Name.EndsWith("Helper"))
            //        {
            //            view = ((MethodInfo)stackTrace.GetFrame(i + 1).GetMethod()).ReturnType.FullName;
            //            break;
            //        }
            //    }
            //}
            return new Tuple<string, string>(form, viewName);
        }
    }
}
