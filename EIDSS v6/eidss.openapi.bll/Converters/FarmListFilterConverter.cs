using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using BLToolkit.EditableObjects;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.openapi.bll.Exceptions;
using eidss.openapi.contract;

namespace eidss.openapi.bll.Converters
{
    internal class FarmListFilterConverter :
        AbstractFieldConverter<eidss.openapi.contract.FarmListFilter, eidss.model.Schema.FarmListItem>
    {
        private static FarmListFilterConverter _instance = new FarmListFilterConverter();
        private FarmListFilterConverter() { }
        public static FarmListFilterConverter Instance { get { return _instance; } }


        public static List<MappingItem> _filedMatcher = new List<MappingItem>()
            {
                new MappingItem(c => c.RecordID, c => c.idfFarm, OperationType.Equal),
                new MappingItem(c => c.Type, c => c.idfsOwnershipStructure, OperationType.Equal),
                new MappingItem(c => c.Region, c => c.idfsRegion, OperationType.Equal),
                new MappingItem(c => c.Rayon, c => c.idfsRayon, OperationType.Equal),
                new MappingItem(c => c.Settlement, c => c.idfsSettlement, OperationType.Equal),
                new MappingItem(c => c.FarmID, c => c.strFarmCode, OperationType.Like),
                new MappingItem(c => c.OwnerFirstName, c => c.strFirstName, OperationType.Like),
                new MappingItem(c => c.OwnerMiddleName, c => c.strSecondName, OperationType.Like),
                new MappingItem(c => c.OwnerLastName, c => c.strLastName, OperationType.Like),
                new MappingItem(c => c.Name, c => c.strNationalName, OperationType.Like),
            };

        public override List<MappingItem> MappingList
        {
            get { return _filedMatcher; }
        }
    }
}