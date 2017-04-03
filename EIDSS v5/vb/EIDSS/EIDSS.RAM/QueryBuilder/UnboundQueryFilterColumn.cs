using System;
using System.Drawing;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraEditors.Repository;

namespace EIDSS.RAM.QueryBuilder
{
    public class UnboundQueryFilterColumn : FilterColumn
    {
        private string columnCaption;
        private readonly string fieldName;
        private Image columnImage;
        private readonly Type columnType;
        private RepositoryItem columnEdit;
        private readonly FilterColumnClauseClass clauseClass;

        public UnboundQueryFilterColumn
            (string columnCaption, string fieldName, Type columnType,
             RepositoryItem columnEdit, FilterColumnClauseClass clauseClass)
        {
            this.columnEdit = columnEdit;
            this.clauseClass = clauseClass;
            this.columnCaption = columnCaption;
            this.columnType = columnType;
            this.fieldName = fieldName;
        }

        public override FilterColumnClauseClass ClauseClass
        {
            get { return clauseClass; }
        }

        public override RepositoryItem ColumnEditor
        {
            get { return columnEdit; }
        }

        public override string ColumnCaption
        {
            get { return columnCaption; }
        }

        public override Type ColumnType
        {
            get { return columnType; }
        }

        public override string FieldName
        {
            get { return fieldName; }
        }

        public override Image Image
        {
            get { return columnImage; }
        }

        public override void SetColumnEditor(RepositoryItem item)
        {
            columnEdit = item;
        }

        public override void SetColumnCaption(string caption)
        {
            columnCaption = caption;
        }

        public override void SetImage(Image image)
        {
            columnImage = image;
        }

        public override bool IsValidClause(ClauseType clause)
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
                            return base.IsValidClause(clause);
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
                            return base.IsValidClause(clause);
                    }
            }
        }
    }
}