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
    internal class OrganizationListFilterConverter :
        AbstractFieldConverter<eidss.openapi.contract.OrganizationListFilter, eidss.model.Schema.OrganizationListItem>
    {
        private static OrganizationListFilterConverter _instance = new OrganizationListFilterConverter();
        private OrganizationListFilterConverter() { }
        public static OrganizationListFilterConverter Instance { get { return _instance; } }


        public static List<MappingItem> _filedMatcher = new List<MappingItem>()
            {
                new MappingItem(c => c.RecordID, c => c.idfInstitution, OperationType.Equal),
                new MappingItem(c => c.AccessoryCode, c => c.HACode, OperationType.Equal),
                new MappingItem(c => c.Abbreviation, c => c.name, OperationType.Like),
                new MappingItem(c => c.OrganizationName, c => c.FullName, OperationType.Like),
                new MappingItem(c => c.UniqueOrganizationID, c => c.strOrganizationID, OperationType.Like),
            };

        public override List<MappingItem> MappingList
        {
            get { return _filedMatcher; }
        }
    }
}