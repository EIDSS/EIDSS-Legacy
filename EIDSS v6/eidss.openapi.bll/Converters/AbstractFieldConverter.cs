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
    internal abstract class AbstractFieldConverter<C, O> :
        IFieldConverter<C>
        where C : class
        where O : class, IObject
    {
        internal class MappingItem
        {
            public Expression<Func<C, object>> exprContract { get; protected set; }
            public OperationType oper { get; protected set; }
            public string fldModel;

            public MappingItem(Expression<Func<C, object>> c, string expr, OperationType o)
            {
                exprContract = c;
                fldModel = expr;
                oper = o;
            }

            public MappingItem(Expression<Func<C, object>> c, Expression<Func<O, object>> exprFld, OperationType o)
            {
                exprContract = c;
                fldModel = BindToProp<O>(exprFld);
                oper = o;
            }
        }

        public abstract List<MappingItem> MappingList { get; }

        private static string BindToProp<A>(Expression<Func<A, object>> expr)
        {
            return BindToProp(expr.Body);
        }

        private static string BindToProp(Expression expr)
        {
            return expr is MemberExpression
                       ? ((MemberExpression)expr).Member.Name
                       : expr is UnaryExpression
                             ? BindToProp((expr as UnaryExpression).Operand)
                             : null;
        }

        public Tuple<string, OperationType> Match(string name)
        {
            var item = MappingList.SingleOrDefault(i => BindToProp(i.exprContract.Body) == name);
            if (item != null)
                return new Tuple<string, OperationType>(item.fldModel ?? name, item.oper);
            return null;
        }
    }

}