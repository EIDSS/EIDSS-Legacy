using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Filtering;

namespace eidss.avr.FilterForm
{
    public class PivotFilterControlModel : WinFilterTreeNodeModel
    {
        public PivotFilterControlModel(FilterControl filterControl) : base(filterControl) { }
        protected override FilterColumnClauseClass GetClauseClass(DevExpress.Data.IBoundProperty property)
        {
            var filter = Control as PivotFilterControl;
            if (filter != null && filter.GetFieldLookupEditor(property.Name) != null)
                return FilterColumnClauseClass.Lookup;
            return base.GetClauseClass(property);
        }

        public override bool IsValidClause(ClauseType clause, FilterColumnClauseClass clauseClass)
        {
            switch (clauseClass)
            {
                case FilterColumnClauseClass.String:

                    switch (clause)
                    {
                        case ClauseType.Equals:
                        case ClauseType.DoesNotEqual:
                        case ClauseType.Greater:
                        case ClauseType.GreaterOrEqual:
                        case ClauseType.Less:
                        case ClauseType.LessOrEqual:
                        case ClauseType.Contains:
                        case ClauseType.DoesNotContain:
                        case ClauseType.BeginsWith:
                        case ClauseType.EndsWith:
                        case ClauseType.Like:
                        case ClauseType.NotLike:
                        case ClauseType.IsNotNull:
                        case ClauseType.IsNull:
                            return true;
                        default:
                            return false;
                    }

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
                        //case ClauseType.Equals:
                        //case ClauseType.IsNotNull:
                        //case ClauseType.IsNull:
                        //case ClauseType.DoesNotEqual:
                        //case ClauseType.Less:
                        //case ClauseType.LessOrEqual:
                        //case ClauseType.Greater:
                        //case ClauseType.GreaterOrEqual:
                        //    return true;
                        //default:
                        //    return false;
                    }

                default:
                    switch (clause)
                    {
                        case ClauseType.Equals:
                        case ClauseType.IsNotNull:
                        case ClauseType.IsNull:
                        case ClauseType.DoesNotEqual:
                        case ClauseType.Less:
                        case ClauseType.LessOrEqual:
                        case ClauseType.Greater:
                        case ClauseType.GreaterOrEqual:
                            return true;
                        default:
                            return false;
                    }
            }
        }
    }
}
