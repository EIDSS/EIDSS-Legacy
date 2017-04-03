using System;
using System.Data;
using System.Windows.Forms;
using bv.common;
using bv.common.Core;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using NUnit.Framework;

namespace EIDSS.Tests.RAM.IntegrationTests
{
    public class BindingHelper : IDisposable
    {
        private readonly Form m_HelperForm;
        private readonly DataRow m_DataRow;

        public BindingHelper(DataRow dataRow)
        {
            Utils.CheckNotNull(dataRow, "dataRow");
            m_DataRow = dataRow;
            m_HelperForm = (new Form());
            m_HelperForm.Show();
        }

        public void CheckTextBinding(TextEdit edit, string columnName, string newValue)
        {
            CheckBinding(edit, newValue);

            Assert.AreEqual(edit.Text, m_DataRow[columnName]);
        }

        public void CheckBoolBinding(CheckEdit edit, string columnName, bool newValue)
        {
            CheckBinding(edit, newValue);

            Assert.AreEqual(edit.Checked, m_DataRow[columnName]);
        }

        public void CheckComboBinding(LookUpEdit edit, string columnName, int newIndex)
        {
            CheckBinding(edit, newIndex);

            Assert.AreEqual(edit.EditValue, m_DataRow[columnName]);
        }

        public void CheckComboBinding(CheckedComboBoxEdit edit,  bool newValue)
        {
            CheckBinding(edit, newValue);
        }
        private void CheckBinding(Control edit, object newValue)
        {
            Control layoutNameParent = edit.Parent;
            Control grandParent = layoutNameParent.Parent;
            TextEdit tmp = new TextEdit();
            m_HelperForm.Controls.Add(tmp);
            tmp.Focus();
            m_HelperForm.Controls.Add(layoutNameParent);
            layoutNameParent.Visible = true;
            edit.Focus();

            if (edit is CheckedComboBoxEdit)
            {
                bool sw = true;
                foreach (CheckedListBoxItem item in ((CheckedComboBoxEdit)edit).Properties.Items)
                {
                    item.CheckState = ((bool) newValue == sw)? CheckState.Checked : CheckState.Unchecked;
                    sw = !sw;
                }
            }
            else if (edit is CheckEdit)
            {
                ((CheckEdit) edit).Checked = (bool) newValue;
            }
            else if (edit is LookUpEdit)
            {
                ((LookUpEdit)edit).ItemIndex = (int)newValue;
            }
            else if (edit is TextEdit)
            {
                edit.Text = (string) newValue;
            }
            else
            {
                throw new Exception(string.Format("unsupported type {0}", edit));
            }

            tmp.Focus();
            grandParent.Controls.Add(layoutNameParent);
        }

        public void Dispose()
        {
            if (m_HelperForm != null)
            {
                m_HelperForm.Close();
                m_HelperForm.Dispose();
            }
        }
    }
}