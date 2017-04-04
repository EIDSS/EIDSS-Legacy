using eidss.avr.db.DBService.DataSource;
using eidss.model.Avr.Tree;
using eidss.model.WindowsService.Serialization;

namespace eidss.avr.db.DBService
{
    public class WebLayoutDB : Layout_DB
    {
        public long m_QueryID = -1;

        public long FolderID { get; set; }

        public AvrTreeElement layout { get; set; }

        protected override void PrepareLayoutBeforePost(LayoutDetailDataSet.LayoutDataTable layoutTable)
        {
            var layoutRow = (LayoutDetailDataSet.LayoutRow) layoutTable.Rows[0];

            if (m_IsNewObject)
            {
                if (FolderID < 0)
                {
                    layoutRow.SetidflLayoutFolderNull();
                }
                else
                {
                    layoutRow.idflLayoutFolder = FolderID;
                }
            }

            if (!layoutRow.IsstrPivotGridSettingsNull())
            {
                layoutRow.blbPivotGridSettings = BinarySerializer.SerializeFromString(layoutRow.strPivotGridSettings);
                //layoutRow.blbPivotGridSettings = BinaryCompressor.ZipString(layoutRow.strPivotGridSettings);
            }

            if (layout != null)
            {
                layoutRow.strDefaultLayoutName = layout.DefaultName;
                layoutRow.strDescription = layout.Description;
                layoutRow.strLayoutName = layout.NationalName;
            }

            m_IsNewObject = false;
        }
    }
}