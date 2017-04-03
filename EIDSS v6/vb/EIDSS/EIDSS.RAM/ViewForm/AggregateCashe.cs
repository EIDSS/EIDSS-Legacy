using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using bv.common;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using eidss.model.Avr.View;

namespace eidss.avr.ViewForm
{
    public class AggregateCashe
    {
        private readonly Dictionary<object, object> m_ColumnsCache = new Dictionary<object, object>();
        private readonly ViewDetailPresenter m_ViewDetailPresenter;

        public AggregateCashe(ViewDetailPresenter viewDetailPresenter)
        {
            m_ViewDetailPresenter = viewDetailPresenter;
        }

        public void AddColumn(string keyFieldName)
        {
            var valuesCache = new Dictionary<int, object>();
            if (m_ColumnsCache.ContainsKey(keyFieldName))
            {
                DeleteColumn(keyFieldName);
            }
            m_ColumnsCache.Add(keyFieldName, valuesCache);
        }

        public void ClearColumn(string keyFieldName)
        {
            if (m_ColumnsCache.ContainsKey(keyFieldName))
            {
                ((Dictionary<int, object>) m_ColumnsCache[keyFieldName]).Clear();
            }
        }

        public void DeleteColumn(string keyFieldName)
        {
            ClearColumn(keyFieldName);
            m_ColumnsCache.Remove(keyFieldName);
        }

        public object GetValue(string keyFieldName, int rowIndex, DataRow row, GridView view, GridColumn gCol, AvrViewColumn col)
        {
            object result;

            if (!m_ColumnsCache.ContainsKey(keyFieldName))
                AddColumn(keyFieldName);

            var colCashe = (Dictionary<int, object>) m_ColumnsCache[keyFieldName];

            if (colCashe.TryGetValue(rowIndex, out result))
            {
                return result;
            }

            CollectionBase colCollection = gCol is BandedGridColumn
                ? (((BandedGridColumn)gCol).OwnerBand == null ? gCol.View.Columns : (CollectionBase)((BandedGridColumn)gCol).OwnerBand.Columns)
                : gCol.View.Columns;


            object val = null;

            try
            {
                val = m_ViewDetailPresenter.FillAggregateColumn(view, colCollection, rowIndex, row, col, ref colCashe);
            }
            catch (ArgumentException e)
            {
                Trace.WriteLine(Trace.Kind.Info, e.Message);
            }
            catch (IndexOutOfRangeException e)
            {
                Trace.WriteLine(Trace.Kind.Info, e.Message);
            }

            colCashe.Add(rowIndex, val);
            return val;
        }

        public void SetValue(string keyFieldName, int rowIndex, object value)
        {
            ((Dictionary<object, object>) m_ColumnsCache[keyFieldName])[rowIndex] = value;
        }
    }
}