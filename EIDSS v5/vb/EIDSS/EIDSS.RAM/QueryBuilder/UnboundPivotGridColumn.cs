using System;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.XtraEditors.Repository;

namespace EIDSS.RAM.QueryBuilder
{
    public class UnboundPivotGridColumn:UnboundQueryFilterColumn
    {
        public UnboundPivotGridColumn(string columnCaption, string fieldName, Type columnType, RepositoryItem columnEdit, FilterColumnClauseClass clauseClass) : base(columnCaption, fieldName, columnType, columnEdit, clauseClass)
        {
        }
        public override bool IsValidClause(ClauseType clause)
        {
            switch (ClauseClass)
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
                            return base.IsValidClause(clause);
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