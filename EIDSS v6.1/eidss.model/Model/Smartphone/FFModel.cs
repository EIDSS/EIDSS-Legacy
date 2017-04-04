using System.Collections.Generic;
using System.Linq;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Model.FlexibleForms.FlexNodes;
using eidss.model.Schema;
using eidss.model.Schema.Smartphone;

namespace eidss.model.Model.Smartphone
{
    public class FFModel
    {
        public long id { get; set; }
        public List<FFTemplate> templates { get; set; }
        public List<FFDeterminant> determinants { get; set; }
        public List<FFRule> rules { get; set; }
        public List<FFRuleConstant> constants { get; set; }
        public List<FFParameterForFunction> funcpars { get; set; }
        public List<FFParameterForAction> actpars { get; set; }
        public List<FFParameterFixedPresetValue> pfpvals { get; set; }
        /// <summary>
        /// Reference types for combo boxes
        /// </summary>
        public List<FFLookupReferenceType> rftypes { get; set; }

        private static long Val(long? v) { return v.HasValue ? v.Value : 0; }
        private static int Val(int? v) { return v.HasValue ? v.Value : 0; }
        private static long Val(long v) { return v; }
        private static int Val(int v) { return v; }

        public static FFModel Get()
        {
            using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                var ret = SmphFFLookups.Accessor.Instance(null).SelectByKey(manager);
                var model = new FFModel 
                { 
                    id = Val(ret.idfsDummy),
                    
                    determinants = ret.FFDeterminant.Select(c => new FFDeterminant
                    {
                        dv = Val(c.idfDeterminantValue),
                        tp = Val(c.idfsFormType),
                        ft = Val(c.idfsFormTemplate),
                    }).ToList()
                    ,

                    rules = ret.FFRule.Select(c => new FFRule
                    {
                        rl = Val(c.idfsRule),
                        ft = Val(c.idfsFormTemplate),
                        cp = Val(c.idfsCheckPoint),
                        rm = Val(c.idfsRuleMessage),
                        rf = Val(c.idfsRuleFunction),
                        nt = Val(c.intNot),
                    }).ToList()
                    
                    ,

                    constants = ret.FFRuleConstant.Select(c => new FFRuleConstant
                    {
                        rl = Val(c.idfsRule),
                        cn = c.strConstant,
                    }).ToList()
                    
                    ,

                    funcpars = ret.FFParameterForFunction.Select(c => new FFParameterForFunction
                    {
                        pr = Val(c.idfsParameter),
                        rl = Val(c.idfsRule),
                        rd = Val(c.intOrder),
                    }).ToList()
                    
                    ,

                    actpars = ret.FFParameterForAction.Select(c => new FFParameterForAction
                    {
                        pr = Val(c.idfsParameter),
                        rl = Val(c.idfsRule),
                        ra = Val(c.idfsRuleAction),
                    }).ToList()
                    
                    ,

                    pfpvals = ret.FFParameterFixedPresetValue.Select(c => new FFParameterFixedPresetValue
                    {
                        pv = Val(c.idfsParameterFixedPresetValue),
                        pt = Val(c.idfsParameterType),
                    }).ToList()
                    
                    ,

                    rftypes = ret.FFLookupReferenceType.Select(c => new FFLookupReferenceType
                    {
                        id = Val(c.idfsReferenceType),
                    }).ToList()
                };

                //we are create a templates structure, than will convert it into nodes than will store in model.
                var tAcc = Template.Accessor.Instance(null);
                model.templates = new List<FFTemplate>();
                foreach (var template in ret.FFTemplatesList)
                {
                    var t = tAcc.SelectList(manager, template.idfsFormTemplate, null).FirstOrDefault();
                    var rootNode = t.CreateFlexNodeForTemplate(null, null, null);
                    model.templates.AddRange(GetTemplate(rootNode));
                }
                //
                for (var index = 0; index < model.templates.Count; index++)
                {
                    var t = model.templates[index];
                    t.od = index;
                }
                return model;
            }
        }

        private static IEnumerable<FFTemplate> GetTemplate(FlexNode node)
        {
            var templates = new List<FFTemplate>();
            var t = new FFTemplate();
            if (node.IsSection())
            {
                var s = node.GetSectionTemplate();
                //we shall not pass table sections
                if (!s.blnGrid)
                {
                    t.br = s.idfsSection;
                    t.ft = s.idfsFormTemplate;
                    if (s.idfsParentSection.HasValue)
                    {
                        t.brp = s.idfsParentSection.Value;
                        t.et = (int)FFModelElementTypes.Label;
                    }
                    else
                    {
                        t.et = (int)FFModelElementTypes.Section;
                    }
                }
            }
            else if (node.IsParameter())
            {
                var p = node.GetParameterTemplate();
                //we shall not pass parameters from table sections
                var canProceed = !(p.ParentSection != null && p.ParentSection.blnGrid);
                if (canProceed)
                {
                    t.br = p.idfsParameter;
                    t.ft = p.idfsFormTemplate;
                    if (p.idfsSection.HasValue) t.brp = p.idfsSection.Value;
                    t.et = (int)FFModelElementTypes.Parameter;
                    if (p.idfsEditor.HasValue) t.ed = p.idfsEditor.Value;
                    t.rd = p.ReadOnly ? 1 : 0;
                    t.md = p.IsMandatory() ? 1 : 0;
                    if (p.idfsParameterType.HasValue) t.pt = p.idfsParameterType.Value;
                    t.ptt = p.idfsParameterCaption.HasValue ? p.idfsParameterCaption.Value : 0;
                }
            }
            else if (node.IsLabel())
            {
                var l = node.GetLabel();
                if (l.idfsBaseReference.HasValue)
                {
                    t.br = l.idfsBaseReference.Value;
                    t.ft = l.idfsFormTemplate;
                    if (l.idfsSection.HasValue) t.brp = l.idfsSection.Value;
                    t.et = (int)FFModelElementTypes.Label;
                }
            }
            if (t.br > 0) templates.Add(t);

            foreach (var n in node.ChildList)
            {
                templates.AddRange(GetTemplate((FlexNode)n));
            }

            return templates;
        }
    }

    public enum FFModelElementTypes
    {
        Unknown = -1,
        Parameter = 0,
        Section = 1,
        SectionTable = 2,
        Label = 3,
    }

    public class FFTemplate
    {
        /*
        idfsBaseReference bigint - id in big eidss
        idfsFormTemplate bigint - defines the template of flexible form
        idfsBaseReferenceParent bigint - reference to parent element
        intElementType int - the element type (parameter, section, table section and label), shall be enumerted in application
        idfsEditor bigint - parameter editor type, shall be enumerated
        intReadOnly int
        intMandatory int
        idfsParameterType bigint - the data type of parameter, shall be enumenated in application
        intOrder int - the element order inside template
        id parameter tooltip (ptt) - this is a short name of parameter
        */
        public long br { get; set; }
        public long ft { get; set; }
        public long brp { get; set; }
        public int et { get; set; }
        public long ed { get; set; }
        public int rd { get; set; }
        public int md { get; set; }
        public long pt { get; set; }
        public int od { get; set; }
        public long ptt { get; set; }

        public FFTemplate()
        {
            et = (int) FFModelElementTypes.Unknown;
        }
    }

    public class FFDeterminant
    {
        /*
    idfDeterminantValue bigint - diagnosis ID or some constant for Uni template, each form type must have record with uni template here.
    idfsFormType bigint - reference to form type, shall be enumerated in application
    idfsFormTemplate bigint not null - reference to FFTemplate table
        */
        public long dv { get; set; }
        public long tp { get; set; }
        public long ft { get; set; }
    }

    public class FFRule
    {
        /*
    idfsRule bigint
    idfsFormTemplate bigint not null - reference to FFTemplate table
    idfsCheckPoint bigint - reference to check point, shall be enumerated
    idfsRuleMessage bigint - reference to translated message
    idfsRuleFunction bigint - reference to function, shall be enumerated
    intNot int
        */
        public long rl { get; set; }
        public long ft { get; set; }
        public long cp { get; set; }
        public long rm { get; set; }
        public long rf { get; set; }
        public int nt { get; set; }
    }

    public class FFRuleConstant
    {
        /*
    idfsRule bigint, not null - refernece to FFRule table
    strConstant string - costant value
        */
        public long rl { get; set; }
        public string cn { get; set; }
    }

    public class FFParameterForFunction
    {
        /*
    idfsParameter  bigint, not null - reference to FFTemplate, idfsBaseReference field
    idfsRule bigint, not null - reference to FFRule table
    intOrder int
        */
        public long pr { get; set; }
        public long rl { get; set; }
        public int rd { get; set; }
    }

    public class FFParameterForAction
    {
        /*
    idfsParameter  bigint, not null - reference to FFTemplate, ElementID field
    idfsRule bigint, not null - reference to FFRule table
    idfsRuleAction bigint, not null  - reference to rule action, shall be enumerated
        */
        public long pr { get; set; }
        public long rl { get; set; }
        public long ra { get; set; }
    }

    public class FFParameterFixedPresetValue
    {
        public long pv { get; set; } //idfsParameterFixedPresetValue
        public long pt { get; set; } //idfsParameterType
    }

    public class FFLookupReferenceType
    {
        public long id { get; set; } //id reference
    }

}