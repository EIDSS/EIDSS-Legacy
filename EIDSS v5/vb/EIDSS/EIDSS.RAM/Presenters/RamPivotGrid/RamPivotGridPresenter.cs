using System;
using System.Collections.Generic;
using System.Data;
using EIDSS.RAM.Tools;
using bv.common.Core;
using DevExpress.Utils;
using DevExpress.XtraPivotGrid;
using EIDSS.RAM.Components;
using EIDSS.RAM.Presenters.Base;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands;
using EIDSS.RAM_DB.Common.EventHandlers;
using EIDSS.RAM_DB.Components;
using EIDSS.RAM_DB.Views;

namespace EIDSS.RAM.Presenters.RamPivotGrid
{
    public class RamPivotGridPresenter : BaseRamPresenter
    {
        private readonly IRamPivotGridView m_PivotGridView;
        private Dictionary<string, string> m_CaptionDictionary;

        public RamPivotGridPresenter(SharedPresenter sharedPresenter, IRamPivotGridView view)
            : base(sharedPresenter)
        {
            m_PivotGridView = view;
            m_PivotGridView.FieldVisibleChanged += PivotGridView_FieldVisibleChanged;

            DistinctCounter = new DistinctCounter();
        }

        public DistinctCounter DistinctCounter { get; set; }

        private void PivotGridView_FieldVisibleChanged(LayoutFieldVisibleChanged e)
        {
            m_SharedPresenter.SharedModel.AtLeastOneFieldVisible = e.Visible;
        }

        public override void Process(Command cmd)
        {
        }

        /// <summary>
        /// Init captions given from data columns of data table 
        /// </summary>
        public void InitPivotCaptions(DataTable data)
        {
            m_CaptionDictionary = new Dictionary<string, string>();
            foreach (DataColumn column in data.Columns)
            {
                m_CaptionDictionary.Add(column.ColumnName, column.Caption);
            }
        }

        /// <summary>
        /// Update captions given from internal dictionary of fields of pivot grid 
        /// </summary>
        public void UpdatePivotCaptions()
        {
            if (m_CaptionDictionary == null)
            {
                return;
            }

            using (m_PivotGridView.BeginTransaction())
            {
                foreach (PivotGridField field in m_PivotGridView.BaseFields)
                {
                    if (!m_CaptionDictionary.ContainsKey(field.FieldName))
                    {
                        new RamException("Pivot caption dictionary  doesn't contains field" +
                                         field.FieldName);
                    }
                    field.Caption = m_CaptionDictionary[field.FieldName];
                }
            }
        }

        public static List<RamPivotGridFieldData> CreateDataFields(DataTable data)
        {
            var list = new List<RamPivotGridFieldData>();
            foreach (DataColumn column in data.Columns)
            {
                bool isCopy = column.ExtendedProperties.ContainsKey(RamPivotGridHelper.CopySuffix);
                var field = new RamPivotGridFieldData
                                {
                                    Name = "field" + column.ColumnName,
                                    FieldName = column.ColumnName,
                                    Caption = column.Caption,
                                    IsFilter = isCopy,
                                    Visible = isCopy,
                                };
                list.Add(field);
            }
            return list;
        }

        public static List<WinPivotGridField> CreateWinFields(DataTable data)
        {
            List<RamPivotGridFieldData> dataFields = CreateDataFields(data);

            var list = new List<WinPivotGridField>();
            foreach (RamPivotGridFieldData dataField in dataFields)
            {
                var field = new WinPivotGridField
                                {
                                    Name = dataField.Name,
                                    FieldName = dataField.FieldName,
                                    Caption = dataField.Caption,
                                    IsFilter = dataField.IsFilter,
                                    Visible = dataField.Visible,
                                };
                field.FieldDataType = RamFieldIcons.GetFieldType(field.OriginalName);

                field.ImageIndex = RamFieldIcons.ImageList.Images.IndexOfKey(field.FieldDataType.ToString());
                if (field.FieldDataType == typeof (DateTime))
                {
                    field.CellFormat.FormatType = FormatType.DateTime;
                }
                
                
                list.Add(field);
            }
            return list;
        }
    }
}