using System;
using System.Data;
using bv.common;
using bv.common.Enums;
using bv.common.db;



namespace EIDSS
{
    public class FreezerTree_DB : BaseDbService
    {

        public override DataSet GetDetail(object ID)
        {
            m_ID = ID;
            var ds = new DataSet();
            try
            {
                var command = CreateSPCommand("spFreezerTree");
                FillDataset(command, ds, "ContainerTree");
                CorrectTable(ds.Tables[0], "ContainerTree", "ID");
                return ds;
            }
            catch (Exception ex)
            {
                m_Error = new ErrorMessage(StandardError.FillDatasetError, ex);
            }
            return null;

        }

    }
}
