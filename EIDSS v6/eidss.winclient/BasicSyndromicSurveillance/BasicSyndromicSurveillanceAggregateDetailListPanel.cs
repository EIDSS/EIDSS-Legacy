﻿using System;
using DevExpress.XtraEditors.Mask;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Core;
using eidss.winclient.Schema;
using eidss.winclient.Helpers;

namespace eidss.winclient.BasicSyndromicSurveillance
{
    public partial class BasicSyndromicSurveillanceAggregateDetailListPanel : BaseGroupPanel_BasicSyndromicSurveillanceAggregateDetail
    {
        /// <summary>
        /// 
        /// </summary>
        public BasicSyndromicSurveillanceAggregateDetailListPanel()
        {
            InitializeComponent();

            //Grid.GridView.InitNewRow += GridView_InitNewRow;

            TopPanelVisible = true;
            EditByDoubleClick = false;
            SearchPanelVisible = false;

            InlineMode = InlineMode.UseNewRow;

            Grid.GridView.OptionsBehavior.ReadOnly = false;
        }

        /*
        void GridView_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var obj = Grid.GridView.GetRow(e.RowHandle) as BasicSyndromicSurveillanceAggregateDetail;
        }
        */

        private BasicSyndromicSurveillanceAggregateDetail fakeBAD { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dummyObjectWithLookups"></param>
        public override void InitGridBehavior(IObject dummyObjectWithLookups)
        {
            base.InitGridBehavior(dummyObjectWithLookups);

            fakeBAD = dummyObjectWithLookups as BasicSyndromicSurveillanceAggregateDetail;
            if (fakeBAD == null) return;
            
            var column = Grid.GridView.Columns.ColumnByName("idfHospital");
            if (column != null)
            {
                LookupBinder.BindOrganizationRepositoryLookup(column.SetLookupEditor(), fakeBAD.HospitalLookup, HACode.Syndromic);
                column.Width = 180;
            }

            SetSpinEditor("intAge0_4");
            SetSpinEditor("intAge5_14");
            SetSpinEditor("intAge15_29");
            SetSpinEditor("intAge30_64");
            SetSpinEditor("intAge65");
            SetSpinEditor("inTotalILI");
            SetSpinEditor("intTotalAdmissions");
            SetSpinEditor("intILISamples");
        }

        private void SetSpinEditor(string columnName)
        {
            var column = Grid.GridView.Columns.ColumnByName(columnName);
            if (column != null)
            {
                var se = column.SetSpinEditor();
                se.Mask.EditMask = @"\d+";
                se.Mask.MaskType = MaskType.RegEx;
                se.MinValue = 0;
                se.MaxValue = Int32.MaxValue;
            }
        }
    }
}
