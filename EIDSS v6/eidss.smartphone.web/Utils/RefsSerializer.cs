using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using eidss.smartphone.web.Models;
using eidss.model.Enums;

namespace eidss.smartphone.web.Utils
{
    public class RefsSerializer
    {
        public static string GetReferencies()
        {
            XElement refs =
                Refs(new long[] { 
                    (long)BaseReferenceType.rftDiagnosis,
                    (long)BaseReferenceType.rftHumanAgeType,
                    (long)BaseReferenceType.rftHumanGender,
                    (long)BaseReferenceType.rftPatientState,
                    (long)BaseReferenceType.rftHospStatus,
                    (long)BaseReferenceType.rftCaseType,
                    (long)BaseReferenceType.rftCaseReportType,
                    (long)BaseReferenceType.rftSpeciesList
                    });
            XElement refsLangs =
                RefsLangs(new long[] { 
                    (long)BaseReferenceType.rftDiagnosis,
                    (long)BaseReferenceType.rftHumanAgeType,
                    (long)BaseReferenceType.rftHumanGender,
                    (long)BaseReferenceType.rftPatientState,
                    (long)BaseReferenceType.rftHospStatus,
                    (long)BaseReferenceType.rftCaseType,
                    (long)BaseReferenceType.rftCaseReportType,
                    (long)BaseReferenceType.rftSpeciesList
                    }, new string[]{
                    "en",
                    "ru",
                    "ka"
                    });
            XElement refsGis = GisRefs();
            XElement refsLangsGis =
                GisRefsLangs(new string[]{
                    "en",
                    "ru",
                    "ka"
                    });

            XDocument doc = new XDocument();
            XElement root = new XElement("references", new XAttribute("date", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")));
            doc.Add(root);
            root.Add(refs);
            root.Add(refsLangs);
            root.Add(refsGis);
            root.Add(refsLangsGis);
            return doc.ToString(SaveOptions.DisableFormatting);
        }

        private static XElement Refs(long[] types)
        {
            return new XElement("refs",
                types.Select(type => 
                    BaseReferenceRaw.GetList(type).Select(c =>
                        new XElement("ref",
                            new XAttribute("id", c.id),
                            new XAttribute("type", c.tp),
                            new XAttribute("ha", c.ha),
                            new XAttribute("val", c.df)
                            ))));
        }

        private static XElement RefsLangs(long[] types, string[] langs)
        {
            return new XElement("refsLang",
                langs.Select(lang =>
                    types.Select(type =>
                        BaseReferenceTranslationRaw.GetList(type, lang).Select(c =>
                            new XElement("refLang",
                                new XAttribute("id", c.id),
                                new XAttribute("lang", c.lg),
                                new XAttribute("val", c.tr)
                                )))));
        }

        private static XElement GisRefs()
        {
            return new XElement("giss",
                GisBaseReferenceRaw.GetAll().Select(c =>
                    new XElement("gis",
                        new XAttribute("id", c.id),
                        new XAttribute("type", c.tp),
                        new XAttribute("cn", c.cn),
                        new XAttribute("rg", c.rg),
                        new XAttribute("rn", c.rn),
                        new XAttribute("val", c.df)
                        )));
        }

        private static XElement GisRefsLangs(string[] langs)
        {
            return new XElement("gissLang",
                langs.Select(lang =>
                    GisBaseReferenceTranslationRaw.GetAll(lang).Select(c =>
                        new XElement("gisLang",
                            new XAttribute("id", c.id),
                            new XAttribute("lang", c.lg),
                            new XAttribute("val", c.tr)
                            ))));
        }

    }
}