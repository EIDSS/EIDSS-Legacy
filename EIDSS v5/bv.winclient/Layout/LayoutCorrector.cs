using System.Drawing;
using System.Windows.Forms;
using bv.common.Configuration;
using bv.common.Core;
using bv.winclient.Localization;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraNavBar;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList;
using bv.winclient.Core;

namespace bv.winclient.Layout
{
    public class MandatoryStyleController : StyleController
    {
    }
    public static class StyleControllerExtension
    {
        public static bool IsMandatory(this IStyleController style)
        {
            return style is MandatoryStyleController;
        }
    }

    public class LayoutCorrector
    {

        private static StyleController m_ButtonStyleController;

        private static MandatoryStyleController m_MandatoryStyleController;

        private static StyleController m_ReadOnlyStyleController;

        private static StyleController m_EditorStyleController;

        private static StyleController m_DropDownStyleController;

        /// <summary>
        /// 
        /// </summary>
        public static StyleController ButtonStyleController
        {
            get
            {
                if (m_ButtonStyleController == null)
                {
                    m_ButtonStyleController = new StyleController();
                    m_ButtonStyleController.InitStyleController();
                }
                return m_ButtonStyleController;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static StyleController MandatoryStyleController
        {
            get
            {
                if (m_MandatoryStyleController == null)
                {
                    m_MandatoryStyleController = new MandatoryStyleController();
                    m_MandatoryStyleController.InitStyleController();
                    m_MandatoryStyleController.Appearance.BackColor = Color.LemonChiffon;
                    m_MandatoryStyleController.Appearance.BorderColor = Color.Red;

                    //m_MandatoryStyleController.Appearance.Font = new Font("Arial", 8.25F, FontStyle.Regular,
                    //                                                      GraphicsUnit.Point, ((204)));
                    m_MandatoryStyleController.Appearance.Options.UseBackColor = true;
                    m_MandatoryStyleController.Appearance.Options.UseBorderColor = true;
                    m_MandatoryStyleController.Appearance.Options.UseFont = true;
                    m_MandatoryStyleController.AppearanceDisabled.BorderColor = Color.Red;
                    m_MandatoryStyleController.AppearanceDisabled.Options.UseBorderColor = true;
                    m_MandatoryStyleController.AppearanceDropDown.BorderColor = Color.Red;
                    m_MandatoryStyleController.AppearanceDropDown.Options.UseBorderColor = true;
                    m_MandatoryStyleController.AppearanceDropDownHeader.BorderColor = Color.Red;
                    m_MandatoryStyleController.AppearanceDropDownHeader.Options.UseBorderColor = true;
                    m_MandatoryStyleController.BorderStyle = BorderStyles.Simple;
                    m_MandatoryStyleController.InitStyleController();
                }
                return m_MandatoryStyleController;
            }
        }

        public static StyleController ReadOnlyStyleController
        {
            get
            {
                if (m_ReadOnlyStyleController == null)
                {
                    m_ReadOnlyStyleController = new StyleController();
                    m_ReadOnlyStyleController.InitStyleController();
                }
                return m_ReadOnlyStyleController;
            }
        }

        public static StyleController EditorStyleController
        {
            get
            {
                if (m_EditorStyleController == null)
                {
                    m_EditorStyleController = new StyleController();
                    m_EditorStyleController.InitStyleController();
                }
                return m_EditorStyleController;
            }
        }

        public static StyleController DropDownStyleController
        {
            get
            {
                if (m_DropDownStyleController == null)
                {
                    m_DropDownStyleController = new StyleController();
                    m_DropDownStyleController.InitStyleController();
                    m_DropDownStyleController.Appearance.BackColor = Color.White;
                    //m_DropDownStyleController.Appearance.Font = new Font("Arial", 8.25F, FontStyle.Regular,
                    //                                                     GraphicsUnit.Point, ((204)));
                    m_DropDownStyleController.Appearance.Options.UseBackColor = true;
                    m_DropDownStyleController.Appearance.Options.UseFont = true;
                    m_DropDownStyleController.InitStyleController();
                }
                return m_DropDownStyleController;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        public static void ApplySystemFont(Control ctl)
        {
            SetControlFont(ctl);
            foreach (Control c in ctl.Controls)
            {
                ApplySystemFont(c);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        public static void InitFormLayout(XtraForm form)
        {
            form.LookAndFeel.SkinName = BaseSettings.SkinName;//"Money Twins";
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Init()
        {
            EditorStyleController.InitStyleController();
            MandatoryStyleController.InitStyleController();
            ReadOnlyStyleController.InitStyleController();
            DropDownStyleController.InitStyleController();
            ButtonStyleController.InitStyleController();
        }

        public static void Reset()
        {
            m_EditorStyleController = null;
            m_MandatoryStyleController = null;
            m_ReadOnlyStyleController = null;
            m_DropDownStyleController = null;
            m_ButtonStyleController = null;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="source"></param>
        public static void SetStyleController(BaseControl c, IStyleController source)
        {
            c.StyleController = source;
            var be = c as BaseEdit;
            if (be == null) return;
            SetClearButtonVisibility(c, !(source is MandatoryStyleController));
            if (!be.Properties.Appearance.Font.Equals(source.Appearance.Font))
            {
                be.Properties.Appearance.Font = source.Appearance.Font;
            }
            if (!be.Properties.AppearanceDisabled.Font.Equals(source.AppearanceDisabled.Font))
            {
                be.Properties.AppearanceDisabled.Font = source.AppearanceDisabled.Font;
            }
            if (!be.Properties.AppearanceFocused.Font.Equals(source.AppearanceFocused.Font))
            {
                be.Properties.AppearanceFocused.Font = source.AppearanceFocused.Font;
            }
            if (!be.Properties.AppearanceReadOnly.Font.Equals(source.AppearanceReadOnly.Font))
            {
                be.Properties.AppearanceReadOnly.Font = source.AppearanceReadOnly.Font;
            }
            var pe = c as PopupBaseEdit;
            if (pe == null) return;

            if (!pe.Properties.AppearanceDropDown.Font.Equals(source.AppearanceDropDown.Font))
            {
                pe.Properties.AppearanceDropDown.Font = source.AppearanceDropDown.Font;
            }
            var cb = c as LookUpEdit;
            if (cb == null) return;
            if (!cb.Properties.AppearanceDropDownHeader.Font.Equals(source.AppearanceDropDownHeader.Font))
            {
                cb.Properties.AppearanceDropDownHeader.Font = source.AppearanceDropDownHeader.Font;
            }
        }
        private static void SetClearButtonVisibility(BaseControl ctl, bool visible)
        {
            var btnEdit = ctl as ButtonEdit;
            if(btnEdit!=null)
            {
                foreach (EditorButton  btn in btnEdit.Properties.Buttons)
                {
                    if (btn.Kind == ButtonPredefines.Delete)
                        btn.Visible = visible;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        public static void SetControlFont(object c)
        {
            if ((c is Control) && TagEquals((Control)c, "FixFont")) return;

            //TODO: uncomment conditions below if PopUpButton or BarcodeButton will be implemented
            if (c is Label || c is LabelControl || c is TabControl || /*c is PopUpButton|| c is BarcodeButton||*/
                c is Button || c is XtraForm)
            {
                var ctl = (Control)c;
                if (ctl.Font.Size != 8.25F || TagEquals(ctl, "FixFontSize"))
                {
                    ctl.Font = new Font(WinClientContext.CurrentFont.FontFamily.Name, ctl.Font.Size, ctl.Font.Style);
                }
                else if (ctl.Font.Bold)
                {
                    ctl.Font = WinClientContext.CurrentBoldFont;
                }
                else
                {
                    ctl.Font = WinClientContext.CurrentFont;
                }
            }
            else if (c is GridControl)
            {
                ((GridControl)c).InitXtraGridAppearance(BaseSettings.ShowDateTimeFormatAsNullText);
            }
            else if (c is PivotGridControl)
            {
                ((PivotGridControl)c).InitPivotGridAppearance();
            }
            else if (c is NavBarControl)
            {
                ((NavBarControl)c).InitNavAppearance();
            }
            else if (c is TreeList)
            {
                ((TreeList)c).InitXtraTreeAppearance(BaseSettings.ShowDateTimeFormatAsNullText);
            }
            else if (c is XtraTabPage)
            {
                ((XtraTabPage)c).InitXtraTabAppearance();
            }
            else if (c is GroupControl)
            {
                ((GroupControl)c).InitGroupControlAppearance();
            }
            else if (c is RadioGroup)
            {
                ((RadioGroup)c).InitRadioGroupAppearance();
            }
            else if (c is CheckEdit)
            {
                ((CheckEdit)c).InitCheckEditAppearance();
            }
            else if (c is CheckedListBoxControl)
            {
                ((CheckedListBoxControl)c).Appearance.InitAppearance();
            }
            else if (c is BaseEdit && ((BaseEdit)c).StyleController == null)
            {
                if (c is PopupBaseEdit)
                {
                    SetStyleController((BaseControl)c, DropDownStyleController);
                }
                else
                {
                    SetStyleController((BaseControl)c, EditorStyleController);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        private static bool TagEquals(Control ctl, string text)
        {
            if (ctl.Tag == null)
            {
                return false;
            }
            //if ((ctl.Tag) is TagHelper)
            //{
            //    return Utils.Str(((TagHelper)ctl.Tag).StringTag) == text;
            //}
            return Utils.Str(ctl.Tag) == text;
        }
    }
}