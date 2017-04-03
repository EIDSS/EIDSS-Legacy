using System;
using bv.common.Core;

namespace eidss.model.AVR.ServiceData
{
    [Serializable]
    public class ViewDTO : BaseTableDTO
    {
        public ViewDTO()
        {
        }

        public ViewDTO(BaseTableDTO baseTable, byte[] binaryViewStructure)
        {
            Utils.CheckNotNull(baseTable, "baseTable");
            Utils.CheckNotNull(binaryViewStructure, "binaryViewStructure");

            TableName = baseTable.TableName;
            Header = baseTable.Header;
            BodyPackets = baseTable.BodyPackets;
            BinaryViewStructure = binaryViewStructure;
        }

        public byte[] BinaryViewStructure { get; set; }
    }
}