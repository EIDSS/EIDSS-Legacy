using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using bv.common.Resources.TranslationTool;
using bv.winclient.Core.TranslationTool;

namespace bv.winclient.BasePanel
{
    public delegate void DesignOperationHandler(object sender, ControlDesignerEventArgs e);
    public interface ITranslationView
    {
        void AddButtons();

        DesignControlManager DCManager { get; set; }
        void ApplyResources(string cultureCode);

        bool SaveChanges(Dictionary<object, DesignElement> changes, string cultureCode);
        string SetExclusionText(Component component, string resourceName, string textId, string cultureCode);
        Dictionary<Component,ExclusionItem> ExclusionsList { get; }
        string GetKeyForComponent(Component component, DesignElement designType);
        string GetResourceNameForComponent(Component component, DesignElement designType);
        string FormatText(Component component, string text, string textId);
        DesignElement GetDesignTypeForComponent(Component component);
        Dictionary<string, ResourceValue> ResourcesList { get; }//stores resources in current localization resx file for current and all base views
        //DefaultResourcesList stores all supported resources in default resx file for current and all base views. 
        //Used to determine which resource file shall be used for storing localized data.
        //if any resource is changed it is searched in this list and linked to resource file defined by found item 
        Dictionary<string, ResourceValue> DefaultResourcesList { get; }
        bool CanHideControl(Control sourceControl);
        DesignOperationHandler AfterDesignOperation { get; }
        string GetViewNameForSplittedResources();
        string GetViewNameForResourceUsage();
        void ControlBoundChange(object sender, EventArgs args);
    }
}
