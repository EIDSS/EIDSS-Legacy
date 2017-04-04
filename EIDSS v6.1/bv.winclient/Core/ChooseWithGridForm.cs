using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace bv.winclient.Core
{
    public partial class ChooseWithGridForm : DevExpress.XtraEditors.XtraForm
    {
        public static bool UnitTestMode { get; set; }

        static ChooseWithGridForm()
        {
            UnitTestMode = false;
        }

        public ChooseWithGridForm(string question, string caption, string list)
        {
            InitializeComponent();

            lbQuestion.Text = question;
            Text = caption;

            string[] items = list.Split(new char[] { '^' });
            int i = 0;
            foreach (string item in items)
            {
                if (item.Trim().Length > 0)
                {
                    string[] cols = item.Split(new char[] { '`' });
                    if (i++ == 0)
                    {
                        foreach (string col in cols)
                        {
                            listItems.Columns.Add(col.Trim());
                        }
                    }
                    else
                    {
                        ListViewItem lv = null;
                        int j = 0;
                        foreach (string col in cols)
                        {
                            if (j++ == 0)
                                lv = new ListViewItem(col.Trim());
                            else
                                lv.SubItems.Add(col.Trim());
                        }
                        listItems.Items.Add(lv);
                    }
                }
            }
        }

        public static string ChooseWithGrid(string prompt, string caption, Form owner, string btYes, string btNo, string btCancel, string list)
		{
            using (var frm = new ChooseWithGridForm(prompt, caption, list))
			{
                frm.btnYes.Text = btYes;
                frm.btnNo.Text = btNo;
                frm.btnCancel.Text = btCancel;
				frm.StartPosition = FormStartPosition.CenterParent;
                frm.TopMost = true;
                if (UnitTestMode)
                {
                    //frm.Show(owner);
                    //System.Threading.Thread.Sleep(2000);
                    return btYes;
                }
                else
                {
                    DialogResult res = frm.ShowDialog(owner);
                    if (res == DialogResult.Yes)
                        return btYes;
                    if (res == DialogResult.No)
                        return btNo;
                }
                return btCancel;
			}
			
		}
    }
}