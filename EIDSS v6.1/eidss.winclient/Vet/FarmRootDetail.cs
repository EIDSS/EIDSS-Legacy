using System;
using bv.common.Core;
using DevExpress.XtraEditors.Controls;
using bv.model.Model.Extenders;
using bv.winclient.Core;
using bv.winclient.Layout;
using bv.winclient.Localization;
using eidss.model.Core;
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
            if (EidssSiteContext.Instance.IsIraqCustomization)
            {
                txtFarmOwnerFirst.Visible = false;
                txtFarmOwnerMiddle.Visible = false;
                txtFarmOwnerLast.Properties.NullText = "";
                txtFarmOwnerLast.Properties.NullValuePrompt = "";
            }
            if (EidssSiteContext.Instance.IsDTRACustomization)
            {
                lbFax.Visible = false;
                txtFax.Visible = false;
                lbEmail.Top = lbFax.Top;
                txtEmail.Top = txtFax.Top;
            }
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
            if (EidssSiteContext.Instance.IsIraqCustomization)
            {
                txtFarmOwnerLast.Left = 0;
                txtFarmOwnerLast.Width = PanelFarmOwner.Width;
                return;
            }
            txtFarmOwnerLast.Left = 0;
            txtFarmOwnerLast.Width = PanelFarmOwner.Width / 3;
            txtFarmOwnerFirst.Width = PanelFarmOwner.Width / 3;
            txtFarmOwnerFirst.Left = txtFarmOwnerLast.Width;
            txtFarmOwnerMiddle.Left = txtFarmOwnerFirst.Left + txtFarmOwnerFirst.Width;
            txtFarmOwnerMiddle.Width = PanelFarmOwner.Width - txtFarmOwnerMiddle.Left;
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
            var bo = bv.winclient.BasePanel.BaseFormManager.ShowForSelection(new PatientListPanel(), new HumanCaseListPanel());
            if (bo != null)
            {
                var owner = bo as PatientListItem;
                if (owner != null)
                {
                    var farmRoot = BusinessObject as FarmRoot;
                    if (farmRoot == null) return;
                    farmRoot.idfOwner = owner.idfHumanActual;
                    farmRoot.strOwnerFirstName = owner.strFirstName;
                    farmRoot.strOwnerMiddleName = owner.strSecondName;
                    farmRoot.strOwnerLastName = owner.strLastName;
                }
            }
        }

        private void DeleteOwner()
        {
            var farmRoot = BusinessObject as FarmRoot;
            if (farmRoot == null) return;
            farmRoot.idfOwner = (new GetNewIDExtender<FarmRoot>()).GetScalar(farmRoot, false);
            farmRoot.strOwnerFirstName = null;
            farmRoot.strOwnerMiddleName = null;
            farmRoot.strOwnerLastName = null;
        }

        private void TextEditOwner_EditValueChanged(object sender, EventArgs e)
        {
            DxControlsHelper.DisableClearButtonForEmptyEdit(txtFarmOwnerMiddle, BusinessObject.Environment.ReadOnly, txtFarmOwnerFirst,
                                                    txtFarmOwnerMiddle, txtFarmOwnerLast);
            DxControlsHelper.ApplyNullValueStyle(sender as DevExpress.XtraEditors.BaseEdit);
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

        private void FarmRootDetail_VisibleChanged(object sender, EventArgs e)
        {
            TextEditOwner_EditValueChanged(txtFarmOwnerFirst, EventArgs.Empty);
            TextEditOwner_EditValueChanged(txtFarmOwnerMiddle, EventArgs.Empty);
            TextEditOwner_EditValueChanged(txtFarmOwnerLast, EventArgs.Empty);

        }
    }
}
 