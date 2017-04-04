using System;
using System.Drawing;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraEditors.Repository;

namespace eidss.avr.QueryBuilder
{
    public class UnboundQueryFilterColumn : FilterColumn
    {
        private string m_ColumnCaption;
        private readonly string m_FieldName;
        private Image m_ColumnImage;
        private readonly Type m_ColumnType;
        private RepositoryItem m_ColumnEdit;
        private readonly FilterColumnClauseClass m_ClauseClass;

        public UnboundQueryFilterColumn
            (string columnCaption, string fieldName, Type columnType,
                RepositoryItem columnEdit, FilterColumnClauseClass clauseClass)
        {
            m_ColumnEdit = columnEdit;
            m_ClauseClass = clauseClass;
            m_ColumnCaption = columnCaption;
            m_ColumnType = columnType;
            m_FieldName = fieldName;
        }

        public override FilterColumnClauseClass ClauseClass
        {
            get { return m_ClauseClass; }
        }

        public override RepositoryItem ColumnEditor
        {
            get { return m_ColumnEdit; }
        }

        public override string ColumnCaption
        {
            get { return m_ColumnCaption; }
        }

        public override Type ColumnType
        {
            get { return m_ColumnType; }
        }

        public override string FieldName
        {
            get { return m_FieldName; }
        }

        public override Image Image
        {
            get { return m_ColumnImage; }
        }

        public override void SetColumnEditor(RepositoryItem item)
        {
            m_ColumnEdit = item;
        }

        public override void SetColumnCaption(string caption)
        {
            m_ColumnCaption = caption;
        }

        public override void SetImage(Image image)
        {
            m_ColumnImage = image;
        }

        //TODO (Mike): find replacement for this method
        //public override bool IsValidClause(ClauseType clause)
        //{
        //    switch (clauseClass)
        //    {
        //        case FilterColumnClauseClass.Lookup:
        //            switch (clause)
        //            {
        //                case ClauseType.Equals:
        //                case ClauseType.IsNotNull:
        //                case ClauseType.IsNull:
        //                case ClauseType.DoesNotEqual:
        //                    return true;
        //                default:
        //                    return false;
        //            }
        //        case FilterColumnClauseClass.DateTime:
        //            switch (clause)
        //            {
        //                case ClauseType.Between:
        //                case ClauseType.NotBetween:
        //                case ClauseType.Like:
        //                case ClauseType.NotLike:
        //                case ClauseType.AnyOf:
        //                case ClauseType.NoneOf:
        //                case ClauseType.IsLaterThisMonth:
        //                case ClauseType.IsLaterThisWeek:
        //                case ClauseType.IsLaterThisYear:
        //                case ClauseType.IsTomorrow:
        //                case ClauseType.IsNextWeek:
        //                case ClauseType.IsBeyondThisYear:
        //                    return false;
        //                default:
        //                    //if (clause.ToString().StartsWith("Is") && clause != ClauseType.IsNull && clause != ClauseType.IsNotNull)
        //                    //    return false;
        //                    //else
        //                    return base.IsValidClause(clause);
        //            }

        //        default:
        //            switch (clause)
        //            {
        //                case ClauseType.Between:
        //                case ClauseType.NotBetween:
        //                case ClauseType.AnyOf:
        //                case ClauseType.NoneOf:
        //                    return false;
        //                default:
        //                    return base.IsValidClause(clause);
        //            }
        //    }
        //}
    }
}