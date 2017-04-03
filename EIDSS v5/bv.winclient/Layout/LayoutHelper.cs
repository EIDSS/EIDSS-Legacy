using System;
using System.Drawing;
using System.Windows.Forms;
using bv.model.Model.Core;

namespace bv.winclient.Layout
{
    public static class LayoutHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeLayout"></param>
        /// <param name="basePanel"></param>
        /// <param name="bo"></param>
        public static ILayout CreateLayout(Type typeLayout, BasePanel.IBasePanel basePanel, IObject bo)
        {
            var layout = (ILayout)Activator.CreateInstance(typeLayout);
            LayoutCorrector.ApplySystemFont((Control)layout);
            layout.BusinessObject = bo;
            layout.Init(basePanel);
            layout.AddControlToMainContainer((Control)basePanel);
            return layout;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static LayoutEmpty CreateLayoutEmpty(this BasePanel.IBasePanel basePanel, IObject bo)
        {
            return (LayoutEmpty)CreateLayout(typeof(LayoutEmpty), basePanel, bo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static LayoutSimple CreateLayoutSimple(this BasePanel.IBasePanel basePanel, IObject bo, string caption, string formID, Image image)
        {
            var layout = (LayoutSimple)CreateLayout(typeof(LayoutSimple), basePanel, bo);
            layout.SetProperties(caption, formID, image);
            return layout;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="layout"></param>
        /// <param name="caption"></param>
        /// <param name="formID"></param>
        /// <param name="image"></param>
        public static void SetProperties(this LayoutSimple layout, string caption, string formID, Image image)
        {
            layout.SetCaption(caption);
            layout.SetFormID(formID);
            layout.SetPicture(image);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basePanel"></param>
        /// <param name="bo"></param>
        /// <param name="caption"></param>
        /// <param name="formID"></param>
        /// <param name="image"></param>
        /// <returns></returns>
        public static LayoutAdvanced CreateLayoutAdvanced(this BasePanel.IBasePanel basePanel, IObject bo, string caption, string formID, Image image)
        {
            var layout = (LayoutAdvanced)CreateLayout(typeof(LayoutAdvanced), basePanel, bo);
            layout.SetProperties(caption, formID, image);           
            return layout;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basePanel"></param>
        /// <param name="bo"></param>
        /// <returns></returns>
        public static LayoutGroup CreateLayoutGroup(this BasePanel.IBasePanel basePanel, IObject bo)
        {
            return (LayoutGroup)CreateLayout(typeof(LayoutGroup), basePanel, bo);
        }
    }
}
