using System;
using System.Data;
using bv.common.Core;
using bv.common.db.Core;
using bv.winclient.Core;
using bv.winclient.Layout;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace EIDSS.Reports.BaseControls.Filters
{
    public partial class BaseFilter : BvXtraUserControl
    {
        private DataView m_DataSource;

        public BaseFilter()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Name of the Key Column in the DataSource
        /// </summary>
        protected virtual string KeyColumnName
        {
            get
            {
                if (WinUtils.IsComponentInDesignMode(this))
                {
                    return string.Empty;
                }
                throw new InvalidOperationException("Property  should be overrided in child class.");
            }
        }

        /// <summary>
        ///     Name of the Value Column in the DataSource
        /// </summary>
        protected virtual string ValueColumnName
        {
            get
            {
                if (WinUtils.IsComponentInDesignMode(this))
                {
                    return string.Empty;
                }
                throw new InvalidOperationException("Property  should be overrided in child class.");
            }
        }

        /// <summary>
        ///     DataSource for Lookup Control
        /// </summary>
        protected DataView DataSource
        {
            get
            {
                if (WinUtils.IsComponentInDesignMode(this))
                {
                    return new DataView();
                }

                if (m_DataSource == null)
                {
                    m_DataSource = CreateDataSource();
                    string emptyLineFilter = string.Format("{0} <> {1}", KeyColumnName, LookupCache.EmptyLineKey);
                    m_DataSource.RowFilter = Utils.IsEmpty(m_DataSource.RowFilter)
                        ? emptyLineFilter
                        : string.Format("{0} AND {1}", m_DataSource.RowFilter, emptyLineFilter);
                }
                return m_DataSource;
            }
        }

        /// <summary>
        ///     Set DataSource equals null to refresh cashed value in m_DataSource next time
        ///     property DataSource called
        /// </summary>
        protected void ResetDataSource()
        {
            m_DataSource = null;
        }

        /// <summary>
        ///     Creates DataSource for Lookup Control
        /// </summary>
        protected virtual DataView CreateDataSource()
        {
            return new DataView();
        }

        /// <summary>
        ///     Bind Datasouce to the Lookup Control and Customize Filter
        /// </summary>
        public virtual void DefineBinding()
        {
        }

        /// <summary>
        ///     Applying resource for corrent Filter Control. Should be overriding in child class
        /// </summary>
        protected virtual void ApplyResources()
        {
            // m_Resources.ApplyResources(this, "$this");
        }

        /// <summary>
        ///     Apply Mandatory style to LookUpEdit
        /// </summary>
        /// <param name="lookUpEdit"></param>
        public static void SetLookupMandatory(LookUpEdit lookUpEdit)
        {
            LayoutCorrector.SetStyleController(lookUpEdit, LayoutCorrector.MandatoryStyleController);

            WinUtils.RemoveClearButton(lookUpEdit);
        }
    }
}