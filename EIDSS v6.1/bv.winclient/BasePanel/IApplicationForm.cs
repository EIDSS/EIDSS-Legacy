using System.Collections.Generic;
using System.Windows.Forms;
using bv.common.Enums;
using bv.model.Model.Core;
using bv.winclient.Core;

namespace bv.winclient.BasePanel
{
    public interface IApplicationForm
    {
        bool Close(FormClosingMode closeMode);
        Control Activate();
        bool Sizable { get; set; }
        string Caption { get; }
        ActionMetaItem GetLastExecutedAction();
        object Key { get; }
        Dictionary<string, object> StartUpParameters { get; set; }
        void BaseForm_KeyDown(object sender, KeyEventArgs e);
        void Release();
        void ShowHelp();
        bool DisableDelayedDisposing { get; set; }
        int MinHeight { get; set; }
        int MinWidth { get; set; }
        bool IsSingleTone { get; }
        int RtlRecalcWidth { get; set; }
    }
}
