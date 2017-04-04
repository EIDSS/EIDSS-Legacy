using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Resources;


namespace eidss.model.Schema
{
    public partial class RootFarmTree
    {
        public string GetHerdName()
        {
            switch (this.idfsPartyType)
            {
                case (int)PartyTypeEnum.Herd: return strName;
                case (int)PartyTypeEnum.Farm: return EidssMessages.Get("VetFarmTree_Total");
                default: return "";
            }
        }
    }
}
