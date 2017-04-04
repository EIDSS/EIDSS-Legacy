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

        public ViewDTO(BaseTableDTO baseTable, byte[] binaryViewHeader)
        {
            Utils.CheckNotNull(baseTable, "baseTable");
            Utils.CheckNotNull(binaryViewHeader, "binaryViewHeader");

            TableName = baseTable.TableName;
            Header = baseTable.Header;
            BodyPackets = baseTable.BodyPackets;
            BinaryViewHeader = binaryViewHeader;
        }

        public byte[] BinaryViewHeader { get; set; }
    }
}