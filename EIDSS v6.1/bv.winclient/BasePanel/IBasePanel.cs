using System;
using System.Collections.Generic;
using System.Drawing;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.Layout;
using System.Windows.Forms;

namespace bv.winclient.BasePanel
{
    public interface IBasePanel
    {
        string HelpTopicID
        {
            get;
            set;
        }
        string Caption
        {
            get;
            set;
        }
        string FormID
        {
            get;
            set;
        }
        Dictionary<string, object> StartUpParameters
        {
            get;
            set;
        }
        bool @ReadOnly
        {
            get;
            set;
        }
        bool Collapsed
        {
            get;
            set;
        }

        Func<IObject, IObject> AdjustObject { get; }

        LifeTimeState LifeTimeState
        {
            get;
            set;
        }

        Image Icon { get; set; }
        void DefineBinding();
        bool Post();
        bool Delete(object key);
        void LoadData(ref object id, int? hAcode = null);

        /// <summary>
        /// Get current Layout
        /// </summary>
        /// <returns></returns>
        ILayout GetLayout();

        Type GetBusinessObjectType();

        List<ActionMetaItem> CustomActions { get; }

        void SetCustomActions(List<ActionMetaItem> actions);

        void ShowReport();


        IObject BusinessObject { get; set; }
        void UpdateControlsState();
        IBasePanel RootPanel { get; }
        IBasePanel ParentBasePanel { get; }
        List<object> GetParamsAction();
        List<object> GetParamsAction(IObject o);

        //perm!! void CheckActionPermission(ActionMetaItem action, ref bool showAction);
        void VisitControls(Control ctl, string boName, VisitControlFunction[] functions, bool skipIfInitialized);

        KeyValuePair<Func<DbManagerProxy, IObject, List<object>, ActResult>, List<object>> GetFirstUIFunc(string actionName);

        KeyValuePair<Func<DbManagerProxy, IObject, List<object>, ActResult>, List<object>> GetSecondUIFunc(string actionName);
        void Cleanup();
        void DisplayReadOnly(bool recursive);
        bool IsRtlApplied { get; set; }
        bool IsControlsInitialized { get; }
        void SaveGridLayout();

    }

    public delegate Control VisitControlFunction(string boName, Control ctl);

}
