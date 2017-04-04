using eidss.avr.db.DBService.DataSource;
using eidss.model.Avr.Commands.Models;
using eidss.model.WindowsService.Serialization;

namespace eidss.avr.db.DBService
{
    public class WinLayout_DB : Layout_DB
    {
        private readonly SharedModel m_SharedModel;

        public WinLayout_DB(SharedModel sharedModel)
        {
            m_SharedModel = sharedModel;
        }

        protected override void PrepareLayoutBeforePost(LayoutDetailDataSet.LayoutDataTable layoutTable)
        {
            var layoutRow = (LayoutDetailDataSet.LayoutRow) layoutTable.Rows[0];

            if (m_IsNewObject)
            {
                if (m_SharedModel.SelectedFolderId < 0)
                {
                    layoutRow.SetidflLayoutFolderNull();
                }
                else
                {
                    layoutRow.idflLayoutFolder = m_SharedModel.SelectedFolderId;
                }
            }
            layoutRow.blbPivotGridSettings = layoutRow.IsstrPivotGridSettingsNull() || string.IsNullOrEmpty(layoutRow.strPivotGridSettings)
                ? new byte[0]
                : BinarySerializer.SerializeFromString(layoutRow.strPivotGridSettings);

            m_IsNewObject = false;
        }
    }
}