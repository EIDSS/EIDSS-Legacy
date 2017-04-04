using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using bv.common.Core;
using bv.common.Resources.TranslationTool;
using bv.winclient.BasePanel;
using DevExpress.XtraVerticalGrid.Rows;

namespace bv.winclient.Core.TranslationTool
{
    public partial class FormTranslationsEditor : BvForm
    {
        public FormTranslationsEditor()
        {
            InitializeComponent();
        }
        public DialogResult EditTranslations(List<ITranslationView> views)
        {
            if (views.Count(v => v.EditableControlsList != null) == 0 )  // || view.EditableControlsList.Count == 0)
                return DialogResult.Cancel;

            translationsEditGrid.CloseEditor();
            translationsEditGrid.Rows.Clear();
            translationsEditGrid.OptionsView.AutoScaleBands = true;

            foreach (var v in views)
            {
                AddViewResources(v);
            }
            return ShowDialog();
        }
        public List<ControlDesignerEventArgs> GetChanges()
        {
            var changes = new List<ControlDesignerEventArgs>();
            foreach (CategoryRow cRow in translationsEditGrid.Rows)
            {
                foreach (EditorRow eRow in cRow.ChildRows)
                {
                    var ctrl = eRow.Tag as Component;
                    if (ctrl != null)
                    {
                        var text = TranslationToolHelperWinClient.GetComponentText(ctrl);
                        if (!Utils.IsEmpty(eRow.Properties.Value) && !text.Equals(eRow.Properties.Value))
                        {
                            var state = new UndoControlState { Element = ctrl, Caption = text, Operation = UndoOperation.Text };
                            TranslationToolHelperWinClient.SetComponentText(ctrl, eRow.Properties.Value.ToString());
                            changes.Add(new ControlDesignerEventArgs { UndoState = state });
                        }
                    }
                }
            }
            return changes;
        }


        // this function makes rows on form from  view.EditableControlsList
        private void AddViewResources(ITranslationView view)
        {
            if (view.EditableControlsList == null)
                return;

            if ( view.EditableControlsList.ContainsKey("lbCaption.Text") &&
                !view.EditableControlsList.ContainsKey("$this.Caption")     )
            {
                var a = view.EditableControlsList.First(s => s.Key == "lbCaption.Text");
                view.EditableControlsList.Add("$this.Caption", a.Value);
            }


            if (view.EditableControlsList.Count(s => view.DefaultResourcesList.ContainsKey(s.Key)) +
                view.EditableControlsList.Count(s => view.ResourcesList.ContainsKey(s.Key)) == 0)
                return;

            var cRow = new CategoryRow(view.ToString());
            translationsEditGrid.Rows.Add(cRow);

            foreach (var item in view.EditableControlsList)
            {
                var eRow = new EditorRow();
                eRow.Properties.RowEdit = this.repositoryItemMemoEdit1;
                eRow.Tag = item.Value;

                if (view.DefaultResourcesList.ContainsKey(item.Key) &&
                    view.DefaultResourcesList[item.Key].Value.ToString().Trim().Length > 0)
                {
                    eRow.Properties.Caption = view.DefaultResourcesList[item.Key].Value.ToString();
                    if (view.ResourcesList.ContainsKey(item.Key))
                        eRow.Properties.Value = view.ResourcesList[item.Key].Value;
                    else
                        eRow.Properties.Value = view.DefaultResourcesList[item.Key].Value;

                    cRow.ChildRows.Add(eRow);
                }
                else if (view.ResourcesList.ContainsKey(item.Key) &&
                        view.ResourcesList[item.Key].EnglishText != null &&
                        view.ResourcesList[item.Key].EnglishText.ToString().Trim().Length > 0)
                {
                    eRow.Properties.Caption = view.ResourcesList[item.Key].EnglishText;
                    eRow.Properties.Value = view.ResourcesList[item.Key].Value;

                    cRow.ChildRows.Add(eRow);
                }
            }
        }

    }
}
