using System;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Core;
using eidss.winclient.Human;
using eidss.winclient.Schema;

namespace eidss.winclient.Vet
{
    public partial class FarmRootDetail : BaseDetailPanel_FarmRoot
    {
        public FarmRootDetail()
        {
            InitializeComponent();
            PanelFarmOwner_Resize(this, EventArgs.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void DefineBinding()
        {
            var farmRoot = BusinessObject as FarmRoot;
            if (farmRoot == null) return;
            LookupBinder.BindHACodeLookup(cbHaCode, farmRoot, "intHACode", (int)HACode.Avian | (int)HACode.Livestock);
            LookupBinder.BindDate(dtModificationDate, farmRoot, "datModificationDate");
            LookupBinder.BindTextEdit(txtFarm, farmRoot, "strFarmCode");
            LookupBinder.BindTextEdit(txtNatName, farmRoot, "strNationalName");
            LookupBinder.BindTextEdit(txtFarmOwnerFirst, farmRoot, "strOwnerFirstName");
            LookupBinder.BindTextEdit(txtFarmOwnerMiddle, farmRoot, "strOwnerMiddleName");
            LookupBinder.BindTextEdit(txtFarmOwnerLast, farmRoot, "strOwnerLastName");
            LookupBinder.BindTextEdit(txtPhone, farmRoot, "strContactPhone");
            LookupBinder.BindTextEdit(txtFax, farmRoot, "strFax");
            LookupBinder.BindTextEdit(txtEmail, farmRoot, "strEmail");
        }

        public Boolean? IsRootFarm
        {
            get
            {
                return true;
            }
            set
            {
                var farmRoot = BusinessObject as FarmRoot;
                if (farmRoot == null) return;
                farmRoot.blnRootFarm = value;
            }
        }

        protected override void InitChildren()
        {
            if (BusinessObject == null)
            {
                addressDetail.BusinessObject = null;
                location.BusinessObject = null;
            }
            else
            {
                var farmRoot = BusinessObject as FarmRoot;
                if (farmRoot != null)
                {
                    addressDetail.BusinessObject = farmRoot.Address;
                    location.BusinessObject = farmRoot.Address;
                }
            }
        }

        private void PanelFarmOwner_Resize(object sender, EventArgs e)
        {
            txtFarmOwnerLast.Left = 0;
            txtFarmOwnerLast.Width = PanelFarmOwner.Width / 3;
            txtFarmOwnerFirst.Width = PanelFarmOwner.Width / 3;
            txtFarmOwnerFirst.Left = txtFarmOwnerLast.Width;
            txtFarmOwnerMiddle.Left = txtFarmOwnerFirst.Left + txtFarmOwnerFirst.Width;
            txtFarmOwnerMiddle.Width = PanelFarmOwner.Width - txtFarmOwnerFirst.Left;
        }

        #region on user actions

        private void txtFarmOwner_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
                SelectOwner();
            else if(e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                DeleteOwner();
        }

        private void SelectOwner()
        {
            bv.winclient.BasePanel.BaseFormManager.ShowForSelection(new eidss.winclient.Human.PatientListPanel(), new HumanCaseListPanel());
        }

        private void DeleteOwner()
        {
            var farmRoot = BusinessObject as FarmRoot;
            if (farmRoot == null) return;

            farmRoot.strOwnerFirstName = String.Empty;
            farmRoot.strOwnerMiddleName = String.Empty;
            farmRoot.strOwnerLastName = String.Empty;
        }

        private void TextEditOwner_EditValueChanged(object sender, EventArgs e)
        {
            var edit = (DevExpress.XtraEditors.TextEdit)sender; 
            if (edit.EditValue == DBNull.Value)
            {
                edit.Properties.Appearance.Font = new System.Drawing.Font(DevExpress.Utils.AppearanceObject.DefaultFont, System.Drawing.FontStyle.Italic);
                edit.Properties.Appearance.ForeColor = System.Drawing.Color.Gray;
            }
            else
                edit.Properties.Appearance.Reset();
        }
        #endregion

        private void addressDetail_AddressChange(Address address)
        {
            //if (address != null)
            //{
            //    if(address.Region != null)
            //        location.SetRegion(address.Region.idfsRegion);
            //    if (address.Rayon != null)
            //        location.SetRayon(address.Rayon.idfsRayon);
            //}
        }
    }
}
 