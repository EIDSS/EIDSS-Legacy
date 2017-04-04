using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using bv.model.BLToolkit;
using bv.model.Model.Core;

namespace EIDSS.Reports.BaseControls.Filters
{
    public sealed partial class DepartmentAZLookupFilter : LabAZLookupFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (DepartmentAZLookupFilter));

        public DepartmentAZLookupFilter()
        {
            InitializeComponent();
        }

        public bool SampleNotFound
        {
            get { return EntityNotFound; }
        }

        public bool DepartmentsNotFound
        {
            get { return BadEntityFound; }
        }

        protected override DataTable CreateTable(string lang, string entityId)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var ps = new List<object>
                {
                    manager.Parameter("@LangID", lang),
                    manager.Parameter("@SampleID", entityId)
                };
                var command = manager.SetSpCommand("dbo.spRepLabTestingResultsDepartmentLookup", ps.ToArray());
                DataTable lookup = command.ExecuteDataTable();

                return lookup;
            }
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();

            lblLookupName.Text = m_Resources.GetString("lblLookupName.Text");
        }
    }
}