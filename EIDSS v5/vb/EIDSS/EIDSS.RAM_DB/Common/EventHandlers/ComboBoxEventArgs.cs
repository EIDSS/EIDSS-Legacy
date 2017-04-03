using System;
using bv.common;
using bv.common.Core;
using DevExpress.XtraEditors;
using EIDSS.RAM_DB.DBService.DataSource;

namespace EIDSS.RAM_DB.Common.EventHandlers
{
    public class ComboBoxEventArgs : EventArgs
    {
        private readonly LookUpEdit m_ComboBox;
        private readonly LayoutDetailDataSet.AggregateRow m_SelectedRow;
        private readonly bool m_IsMap;

        public ComboBoxEventArgs(LookUpEdit combo, bool isMap)
        {
            Utils.CheckNotNull(combo, "combo");
            m_ComboBox = combo;
            m_IsMap = isMap;
        }


        public ComboBoxEventArgs(LookUpEdit cbAdministrativeUnit, LayoutDetailDataSet.AggregateRow selectedRow)
            : this(cbAdministrativeUnit, false)
        {
            m_SelectedRow = selectedRow;
        }

        public LookUpEdit ComboBox
        {
            get { return m_ComboBox; }
        }

        public LayoutDetailDataSet.AggregateRow SelectedRow
        {
            get { return m_SelectedRow; }
        }

        public bool IsMap
        {
            get { return m_IsMap; }
        }
    }
}