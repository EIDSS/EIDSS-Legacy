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
    internal class PatientListFilterConverter :
        AbstractFieldConverter<eidss.openapi.contract.PatientListFilter, eidss.model.Schema.PatientListItem>
    {
        private static PatientListFilterConverter _instance = new PatientListFilterConverter();
        private PatientListFilterConverter() { }
        public static PatientListFilterConverter Instance { get { return _instance; } }


        public static List<MappingItem> _filedMatcher = new List<MappingItem>()
            {
                new MappingItem(c => c.RecordID, c => c.idfHumanActual, OperationType.Equal),
                new MappingItem(c => c.PatientPersonalIDType, c => c.idfsPersonIDType, OperationType.Equal),
                new MappingItem(c => c.CurrentResidenceCountry, c => c.idfsCountry, OperationType.Equal),
                new MappingItem(c => c.CurrentResidenceRegion, c => c.idfsRegion, OperationType.Equal),
                new MappingItem(c => c.CurrentResidenceRayon, c => c.idfsRayon, OperationType.Equal),
                new MappingItem(c => c.PatientLastName, c => c.strLastName, OperationType.Like),
                new MappingItem(c => c.PatientFirstName, c => c.strFirstName, OperationType.Like),
                new MappingItem(c => c.PatientMiddleName, c => c.strSecondName, OperationType.Like),
                new MappingItem(c => c.PersonalID, c => c.strPersonID, OperationType.Like),
                new MappingItem(c => c.DateOfBirthFrom, c => c.datDateofBirth, OperationType.MoreOrEqualThan),
                new MappingItem(c => c.DateOfBirthTo, c => c.datDateofBirth, OperationType.LessOrEqualThan),
            };

        public override List<MappingItem> MappingList
        {
            get { return _filedMatcher; }
        }
    }
}