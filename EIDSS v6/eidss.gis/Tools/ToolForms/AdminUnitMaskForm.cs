using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using EIDSS;
using bv.common.db.Core;
using bv.winclient.Core;

namespace eidss.gis.Tools.ToolForms
{
    public partial class AdminUnitMaskForm : BvForm
    {
        public AdminUnitMaskForm()
        {
            InitializeComponent();
        }

        private void checkEdit1_CheckStateChanged(object sender, EventArgs e)
        {
            groupControl1.Enabled = checkUseMask.Checked;
        }

        private void AdminUnitMaskForm_Load(object sender, EventArgs e)
        {
            #region Fill Countriy list

            var countries = LookupCache.Get(LookupTables.Country);

            countries.RowFilter = string.Format("strCountryName <> '{0}'", "");

            lookUpEdit_Cnt.SuspendLayout();
            lookUpEdit_Cnt.Properties.Columns.Clear();
            lookUpEdit_Cnt.Properties.Columns.Add(new LookUpColumnInfo("strCountryName", "", 200, FormatType.None, "",
                                                                       true, HorzAlignment.Near));
            lookUpEdit_Cnt.Properties.PopupWidth = lookUpEdit_Cnt.Width;

            lookUpEdit_Cnt.Properties.DataSource = countries;

            lookUpEdit_Cnt.Properties.DisplayMember = "strCountryName";
            lookUpEdit_Cnt.Properties.ValueMember = "idfsCountry";

            lookUpEdit_Cnt.EditValue = IdfsCountry ?? model.Core.EidssSiteContext.Instance.CountryID;
            lookUpEdit_Cnt.ResumeLayout();

            #endregion
        }

        private void lookUpEdit_Cnt_EditValueChanged(object sender, EventArgs e)
        {
            #region Change region list

            var regions = LookupCache.Get(LookupTables.Region);

            regions.RowFilter = string.Format("idfsCountry = {0} OR idfsCountry = {1}", lookUpEdit_Cnt.EditValue, -101);

            lookUpEdit_Reg.SuspendLayout();
            lookUpEdit_Reg.Properties.Columns.Clear();
            lookUpEdit_Reg.Properties.Columns.Add(new LookUpColumnInfo("strRegionName", "", 200, FormatType.None, "",
                                                                       true, HorzAlignment.Near));
            lookUpEdit_Reg.Properties.PopupWidth = lookUpEdit_Reg.Width;

            lookUpEdit_Reg.Properties.DataSource = regions;

            lookUpEdit_Reg.Properties.DisplayMember = "strRegionName";
            lookUpEdit_Reg.Properties.ValueMember = "idfsRegion";

            lookUpEdit_Reg.EditValue = null;
            
            lookUpEdit_Reg.ResumeLayout();
            
            #endregion
        }

        private void lookUpEdit_Reg_EditValueChanged(object sender, EventArgs e)
        {
            #region Change rayon list

            if (lookUpEdit_Reg.EditValue != null)
            {
                var rayons = LookupCache.Get(LookupTables.Rayon);

                rayons.RowFilter = string.Format("idfsRegion = {0} OR idfsRegion = {1}", lookUpEdit_Reg.EditValue, -101);

                lookUpEdit_Ryn.SuspendLayout();
                lookUpEdit_Ryn.Properties.Columns.Clear();
                lookUpEdit_Ryn.Properties.Columns.Add(new LookUpColumnInfo("strRayonName", "", 200, FormatType.None, "",
                    true, HorzAlignment.Near));
                lookUpEdit_Ryn.Properties.PopupWidth = lookUpEdit_Ryn.Width;

                lookUpEdit_Ryn.Properties.DataSource = rayons;

                lookUpEdit_Ryn.Properties.DisplayMember = "strRayonName";
                lookUpEdit_Ryn.Properties.ValueMember = "idfsRayon";

                lookUpEdit_Ryn.EditValue = null;

                lookUpEdit_Ryn.ResumeLayout();
            }
            else
            {
                lookUpEdit_Ryn.EditValue = null;
            }

            #endregion
        }

        #region Properties

        public object IdfsCountry
        {
            get { return lookUpEdit_Cnt.EditValue; }
            set { lookUpEdit_Cnt.EditValue = value; }
        }

        public object IdfsRegion
        {
            get { return lookUpEdit_Reg.EditValue; }
            set { lookUpEdit_Reg.EditValue = value; }
        }

        public object IdfsRayon
        {
            get { return lookUpEdit_Ryn.EditValue; }
            set { lookUpEdit_Ryn.EditValue = value; }
        }

        public bool UseMask
        {
            get { return checkUseMask.Checked; }
            set { checkUseMask.Checked = value; }
        }

        #endregion
    }
}