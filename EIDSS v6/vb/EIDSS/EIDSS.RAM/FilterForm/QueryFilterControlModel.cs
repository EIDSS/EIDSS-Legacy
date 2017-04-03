using DevExpress.Data.Filtering.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Filtering;

namespace eidss.avr.FilterForm
{
    class QueryFilterControlModel : WinFilterTreeNodeModel
    {
        public QueryFilterControlModel(FilterControl filterControl) : base(filterControl) { }
        protected override FilterColumnClauseClass GetClauseClass(DevExpress.Data.IBoundProperty property)
        {
            var filter = Control as QueryFilterControl;
            if (filter != null && filter.GetFieldLookupEditor(property.Name) != null)
                return FilterColumnClauseClass.Lookup;
            return base.GetClauseClass(property);
        }

        public override bool IsValidClause(ClauseType clause, FilterColumnClauseClass clauseClass)
        {
            switch (clauseClass)
            {
                case FilterColumnClauseClass.Lookup:
                    switch (clause)
                    {
                        case ClauseType.Equals:
                        case ClauseType.IsNotNull:
                        case ClauseType.IsNull:
                        case ClauseType.DoesNotEqual:
                            return true;
                        default:
                            return false;
                    }
                case FilterColumnClauseClass.DateTime:
                    switch (clause)
                    {
                        case ClauseType.Between:
                        case ClauseType.NotBetween:
                        case ClauseType.Like:
                        case ClauseType.NotLike:
                        case ClauseType.AnyOf:
                        case ClauseType.NoneOf:
                        case ClauseType.IsLaterThisMonth:
                        case ClauseType.IsLaterThisWeek:
                        case ClauseType.IsLaterThisYear:
                        case ClauseType.IsTomorrow:
                        case ClauseType.IsNextWeek:
                        case ClauseType.IsBeyondThisYear:
                            return false;
                        default:
                            //if (clause.ToString().StartsWith("Is") && clause != ClauseType.IsNull && clause != ClauseType.IsNotNull)
                            //    return false;
                            //else
                            return base.IsValidClause(clause, clauseClass);
                    }
                default:
                    switch (clause)
                    {
                        case ClauseType.Between:
                        case ClauseType.NotBetween:
                        case ClauseType.AnyOf:
                        case ClauseType.NoneOf:
                            return false;
                        default:
                            return base.IsValidClause(clause, clauseClass);
                    }
            }
        }
    }

}
