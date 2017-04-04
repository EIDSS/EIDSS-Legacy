using System;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraGrid.Views.Base;
using bv.common.Core;
using bv.common.Diagnostics;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Helpers;
using eidss.model.Schema;
using eidss.winclient.Schema;
using bv.common.Enums;
using bv.model.BLToolkit;
using System.Collections.Generic;

namespace eidss.winclient.Lab
{
    public partial class LaboratorySectionGetByFieldBarcodeListPanel : BaseListPanel_LaboratorySectionGetByFieldBarcodeListItem
    {
        public LaboratorySectionGetByFieldBarcodeListPanel()
        {
            InitializeComponent();
        }

    }
}