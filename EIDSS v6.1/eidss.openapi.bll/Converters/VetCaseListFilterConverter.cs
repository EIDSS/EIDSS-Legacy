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
    internal class VetCaseListFilterConverter :
        AbstractFieldConverter<eidss.openapi.contract.VetCaseListFilter, eidss.model.Schema.VetCaseListItem>
    {
        private static VetCaseListFilterConverter _instance = new VetCaseListFilterConverter();
        private VetCaseListFilterConverter() { }
        public static VetCaseListFilterConverter Instance { get { return _instance; } }

        public static List<MappingItem> _filedMatcher = new List<MappingItem>()
            {
                new MappingItem(c => c.RecordID, c => c.idfCase, OperationType.Equal),
                new MappingItem(c => c.Diagnosis, c => c.idfsDiagnosis, OperationType.Equal),
                new MappingItem(c => c.CaseClassification, c => c.idfsCaseClassification, OperationType.Equal),
                new MappingItem(c => c.CaseStatus, c => c.idfsCaseProgressStatus, OperationType.Equal),
                new MappingItem(c => c.ReportType, c => c.idfsCaseReportType, OperationType.Equal),
                new MappingItem(c => c.CaseType, c => c.idfsCaseType, OperationType.Equal),
                new MappingItem(c => c.Region, c => c.idfsRegion, OperationType.Equal),
                new MappingItem(c => c.Rayon, c => c.idfsRayon, OperationType.Equal),
                new MappingItem(c => c.Settlement, c => c.idfsSettlement, OperationType.Equal),

                new MappingItem(c => c.CaseID, c => c.strCaseID, OperationType.Like),
                new MappingItem(c => c.OwnerFirstName, c => c.strOwnerFirstName, OperationType.Like),
                new MappingItem(c => c.OwnerLastName, c => c.strOwnerLastName, OperationType.Like),

                new MappingItem(c => c.EnteredDateFrom, c => c.datEnteredDate, OperationType.MoreOrEqualThan),
                new MappingItem(c => c.EnteredDateTo, c => c.datEnteredDate, OperationType.LessOrEqualThan),
                new MappingItem(c => c.InvestigationDateFrom, c => c.datInvestigationDate, OperationType.MoreOrEqualThan),
                new MappingItem(c => c.InvestigationDateTo, c => c.datInvestigationDate, OperationType.LessOrEqualThan),
            };

        public override List<MappingItem> MappingList
        {
            get { return _filedMatcher; }
        }
    }
}