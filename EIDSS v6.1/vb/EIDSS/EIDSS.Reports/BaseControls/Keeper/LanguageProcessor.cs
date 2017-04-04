using System.ComponentModel;
using bv.common.Core;
using bv.winclient.Core;
using eidss.model.Core.CultureInfo;

namespace EIDSS.Reports.BaseControls.Keeper
{
    public sealed class LanguageProcessor : BaseLanguageProcessor
    {
        private readonly Component m_ParentComponent;

        public LanguageProcessor(Component parentComponent)
        {
            Utils.CheckNotNull(parentComponent, "parentComponent");
            m_ParentComponent = parentComponent;
        }

        protected override bool NeedToFillSupportedLanguages
        {
            get
            {
                bool isInDesign = (WinUtils.IsComponentInDesignMode(m_ParentComponent));
                return base.NeedToFillSupportedLanguages || isInDesign;
            }
        }
    }
}