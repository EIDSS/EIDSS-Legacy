using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using eidss.smartphone.web.Models;
using eidss.model.Enums;
using eidss.model.Model.Smartphone;

namespace eidss.smartphone.web.Utils
{
    public class RefsSerializer
    {
        private static string[] supportedLangs = new string[]
                {
                    "en",
                    "ru",
                    "ka",
                    "ar",
                    "az",
                    "hy",
                    "kk",
                    "th",
                    "uk",
                };
        private static long[] supTypes = new long[]
            { 
                    (long)BaseReferenceType.rftDiagnosis,
                    (long)BaseReferenceType.rftAnimalAgeList,
                    (long)BaseReferenceType.rftAnimalCondition,
                    (long)BaseReferenceType.rftAnimalSex,
                    (long)BaseReferenceType.rftSampleType,
                    (long)BaseReferenceType.rftSampleType + 10000,
                    (long)BaseReferenceType.rftHumanAgeType,
                    (long)BaseReferenceType.rftHumanGender,
                    (long)BaseReferenceType.rftPatientState,
                    (long)BaseReferenceType.rftHospStatus,
                    (long)BaseReferenceType.rftInstitutionName,
                    (long)BaseReferenceType.rftCaseClassification,
                    (long)BaseReferenceType.rftYesNoValue,
                    (long)BaseReferenceType.rftNationality,
                    (long)BaseReferenceType.rftPersonIDType,
                    (long)BaseReferenceType.rftOutcome,
                    (long)BaseReferenceType.rftNotCollectedReason,
                    (long)BaseReferenceType.rftCaseType,
                    (long)BaseReferenceType.rftCaseReportType,
                    (long)BaseReferenceType.rftSpeciesList,
                    (long)BaseReferenceType.rftFFRuleMessage,
                    (long)BaseReferenceType.rftFFTemplate,
                    (long)BaseReferenceType.rftFFType,
                    (long)BaseReferenceType.rftParameter,
                    (long)BaseReferenceType.rftParametersFixedPresetValue,
                    (long)BaseReferenceType.rftCampaignType,
                    (long)BaseReferenceType.rftMonitoringSessionStatus,
                    (long)BaseReferenceType.rftParameterToolTip,
                    (long)BaseReferenceType.rftSection,
                    (long)BaseReferenceType.rftFlexibleFormLabelText,

                    /*(long)BaseReferenceType.rftDiagnosticActionList,
                    (long)BaseReferenceType.rftProphilacticActionList,
                    (long)BaseReferenceType.rftSanitaryActionList*/
                    };

        public static string GetReferencies()
        {
            var ffObj = FFModel.Get();
            List<long> supportedTypes = new List<long>();
            supportedTypes.AddRange(supTypes);
            ffObj.rftypes.ForEach(t => { if (!supportedTypes.Contains(t.id)) supportedTypes.Add(t.id); });


            XElement refs = Refs(supportedTypes);
            XElement refsLangs = RefsLangs(supportedTypes, supportedLangs);
            XElement refsGis = GisRefs();
            XElement refsLangsGis = GisRefsLangs(supportedLangs);

            XDocument doc = new XDocument();
            XElement root = new XElement("references"
                , new XAttribute("date", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"))
                , new XAttribute("defRg", eidss.model.Core.EidssSiteContext.Instance.RegionID)
                , new XAttribute("defRn", eidss.model.Core.EidssSiteContext.Instance.RayonID)
                );
            doc.Add(root);
            root.Add(MandatoryFields());
            root.Add(InvisibleFields());
            root.Add(refs);
            root.Add(refsLangs);
            root.Add(refsGis);
            root.Add(refsLangsGis);
            root.Add(FFs(ffObj));
            return doc.ToString(SaveOptions.DisableFormatting);
        }

        private static XElement MandatoryFields()
        {
            return new XElement("mandatory",
                    eidss.smartphone.web.Models.MandatoryFields.GetList().Select(c =>
                        new XElement("field",
                            new XAttribute("id", c.id),
                            new XAttribute("fn", c.fn)
                            )));
        }
        private static XElement InvisibleFields()
        {
            return new XElement("invisible",
                    eidss.smartphone.web.Models.InvisibleFields.GetList().Select(c =>
                        new XElement("field",
                            new XAttribute("id", c.id),
                            new XAttribute("fn", c.fn)
                            )));
        }
        private static XElement FFs(FFModel ffObj)
        {
            return new XElement("ff",
                    new XAttribute("id", ffObj.id),
                    new XElement("acts",
                        ffObj.actpars.Select(c =>
                            new XElement("act",
                                new XAttribute("pr", c.pr),
                                new XAttribute("ra", c.ra),
                                new XAttribute("rl", c.rl)
                        ))
                    ),
                    new XElement("cons",
                        ffObj.constants.Select(c =>
                            new XElement("con",
                                new XAttribute("cn", c.cn),
                                new XAttribute("rl", c.rl)
                        ))
                    ),
                    new XElement("dets",
                        ffObj.determinants.Select(c =>
                            new XElement("det",
                                new XAttribute("dv", c.dv),
                                new XAttribute("ft", c.ft),
                                new XAttribute("tp", c.tp)
                        ))
                    ),
                    new XElement("funs",
                        ffObj.funcpars.Select(c =>
                            new XElement("fun",
                                new XAttribute("pr", c.pr),
                                new XAttribute("rd", c.rd),
                                new XAttribute("rl", c.rl)
                        ))
                    ),
                    new XElement("pfps",
                        ffObj.pfpvals.Select(c =>
                            new XElement("pfp",
                                new XAttribute("pt", c.pt),
                                new XAttribute("pv", c.pv)
                        ))
                    ),
                    new XElement("ruls",
                        ffObj.rules.Select(c =>
                            new XElement("rul",
                                new XAttribute("cp", c.cp),
                                new XAttribute("ft", c.ft),
                                new XAttribute("nt", c.nt),
                                new XAttribute("rf", c.rf),
                                new XAttribute("rl", c.rl),
                                new XAttribute("rm", c.rm)
                        ))
                    ),
                    new XElement("tems",
                        ffObj.templates.Select(c =>
                            new XElement("tem",
                                new XAttribute("br", c.br),
                                new XAttribute("brp", c.brp),
                                new XAttribute("ed", c.ed),
                                new XAttribute("et", c.et),
                                new XAttribute("ft", c.ft),
                                new XAttribute("md", c.md),
                                new XAttribute("od", c.od),
                                new XAttribute("pt", c.pt),
                                new XAttribute("ptt", c.ptt),
                                new XAttribute("rd", c.rd)
                        ))
                    ),
                    new XElement("rfts",
                        ffObj.rftypes.Select(c =>
                            new XElement("rft",
                                new XAttribute("id", c.id)
                        ))
                    )
           );
        }

        private static XElement Refs(List<long> types)
        {
            return new XElement("refs",
                types.Where(c => c != (long)BaseReferenceType.rftCaseClassification &&
                            c != (long)BaseReferenceType.rftInstitutionName &&
                            c != (long)BaseReferenceType.rftAnimalAgeList &&
                            c != (long)BaseReferenceType.rftSampleType + 10000)
                            .Select(type => BaseReferenceRaw.GetList(type)
                            .Select(c =>
                                    new XElement("r",
                                        new XAttribute("id", (long)c.id),
                                        new XAttribute("tp", (long)c.tp),
                                        new XAttribute("ha", (int)c.ha),
                                        new XAttribute("df", (string)c.df),
                                        new XAttribute("rs", (int)c.rs),
                                        new XAttribute("rd", (int)c.rd)
                                        ))
                            ),
                types.Where(c => c == (long)BaseReferenceType.rftCaseClassification ||
                            c == (long)BaseReferenceType.rftInstitutionName ||
                            c == (long)BaseReferenceType.rftAnimalAgeList ||
                            c == (long)BaseReferenceType.rftSampleType + 10000)
                            .Select(type => BaseReferenceRaw.GetList(type)
                            .Select(c =>
                                    new XElement("rf",
                                        new XAttribute("id", (long)c.id),
                                        new XAttribute("tp", (long)c.tp),
                                        new XAttribute("ha", (int)c.ha),
                                        new XAttribute("df", (string)c.df),
                                        new XAttribute("rs", (int)c.rs),
                                        new XAttribute("rd", (int)c.rd),
                                        new XAttribute("f1", (long)c.f1),
                                        new XAttribute("f2", (long)c.f2)
                                        ))
                            )

/*
                            BaseReferenceRaw.GetList( (long)BaseReferenceType.rftCaseClassification)
                            .Select(c =>
                                    new XElement("rf",
                                        new XAttribute("id", (long)c.id),
                                        new XAttribute("tp", (long)c.tp),
                                        new XAttribute("ha", (int)c.ha),
                                        new XAttribute("df", (string)c.df),
                                        new XAttribute("rs", (int)c.rs),
                                        new XAttribute("rd", (int)c.rd),
                                        new XAttribute("f1", (long)c.f1),
                                        new XAttribute("f2", (long)c.f2)
                                        )),
                            BaseReferenceRaw.GetList((long)BaseReferenceType.rftInstitutionName)
                            .Select(c =>
                                    new XElement("rf",
                                        new XAttribute("id", (long)c.id),
                                        new XAttribute("tp", (long)c.tp),
                                        new XAttribute("ha", (int)c.ha),
                                        new XAttribute("df", (string)c.df),
                                        new XAttribute("rs", (int)c.rs),
                                        new XAttribute("rd", (int)c.rd),
                                        new XAttribute("f1", (long)c.f1),
                                        new XAttribute("f2", (long)c.f2)
                                        )),
                            BaseReferenceRaw.GetList( (long)BaseReferenceType.rftAnimalAgeList)
                            .Select(c =>
                                    new XElement("rf",
                                        new XAttribute("id", (long)c.id),
                                        new XAttribute("tp", (long)c.tp),
                                        new XAttribute("ha", (int)c.ha),
                                        new XAttribute("df", (string)c.df),
                                        new XAttribute("rs", (int)c.rs),
                                        new XAttribute("rd", (int)c.rd),
                                        new XAttribute("f1", (long)c.f1),
                                        new XAttribute("f2", (long)c.f2)
                                        )),
                            BaseReferenceRaw.GetList((long)BaseReferenceType.rftSampleType + 10000)
                            .Select(c =>
                                    new XElement("rf",
                                        new XAttribute("id", (long)c.id),
                                        new XAttribute("tp", (long)c.tp),
                                        new XAttribute("ha", (int)c.ha),
                                        new XAttribute("df", (string)c.df),
                                        new XAttribute("rs", (int)c.rs),
                                        new XAttribute("rd", (int)c.rd),
                                        new XAttribute("f1", (long)c.f1),
                                        new XAttribute("f2", (long)c.f2)
                                        ))*/
            );
        }

        private static XElement RefsLangs(List<long> types, string[] langs)
        {
            return new XElement("refsLang",
                langs.Select(lang => new XElement("lang",
                    new XAttribute("lang", lang),
                    types.Select(type =>
                        BaseReferenceTranslationRaw.GetList(type, lang).Select(c =>
                            new XElement("rl",
                                new XAttribute("id", c.id),
                                new XAttribute("tr", c.tr)
                                ))))));
        }

        private static XElement GisRefs()
        {
            return new XElement("giss",
                GisBaseReferenceRaw.GetAll().Select(c =>
                    new XElement("gis",
                        new XAttribute("id", c.id),
                        new XAttribute("tp", c.tp),
                        new XAttribute("cn", c.cn),
                        new XAttribute("rg", c.rg),
                        new XAttribute("rn", c.rn),
                        new XAttribute("df", c.df),
                        new XAttribute("rs", c.rs),
                        new XAttribute("rd", c.rd)
                        )));
        }

        private static XElement GisRefsLangs(string[] langs)
        {
            return new XElement("gissLang",
                langs.Select(lang => new XElement("lang",
                    new XAttribute("lang", lang),
                    GisBaseReferenceTranslationRaw.GetAll(lang).Select(c =>
                        new XElement("gl",
                            new XAttribute("id", c.id),
                            new XAttribute("tr", c.tr)
                            )))));
        }

    }
}