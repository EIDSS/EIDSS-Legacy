using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using bv.common.Core;
using bv.common.db.Core;

namespace eidss.avr.db.Common
{
    public class AvrPivotGridData : IDisposable
    {
        private DataTable m_RealPivotData;
        private DataTable m_ClonedPivotData;

        public AvrPivotGridData()
            : this(new DataTable(@"Empty Table"))
        {
        }

        public AvrPivotGridData(DataTable realPivotData)
        {
            m_RealPivotData = realPivotData;
        }

        public DataTable RealPivotData
        {
            get { return m_RealPivotData; }
            set
            {
                m_RealPivotData = value;
                m_ClonedPivotData = m_RealPivotData.Clone();
            }
        }

        public DataTable ClonedPivotData
        {
            get { return m_ClonedPivotData; }
        }

        public IEnumerable<DataRow> Rows
        {
            get
            {
                CheckIsTableNotNull();
                return RealPivotData.Rows.Cast<DataRow>();
            }
        }

        public DataRow NewRow()
        {
            CheckIsTableNotNull();
            return RealPivotData.NewRow();
        }

        public void AddRow(DataRow row)
        {
            Utils.CheckNotNull(row, "row");
            CheckIsTableNotNull();
            RealPivotData.Rows.Add(row);
        }

        public void BeginLoadData()
        {
            if (RealPivotData != null)
            {
                RealPivotData.BeginLoadData();
            }
        }

        public void EndLoadData()
        {
            if (RealPivotData != null)
            {
                RealPivotData.EndLoadData();
                m_ClonedPivotData = RealPivotData.Clone();
            }
        }

        public void RejectChanges()
        {
            CheckIsTableNotNull();
            RealPivotData.RejectChanges();
            m_ClonedPivotData = RealPivotData.Clone();
        }

        public void AcceptChanges()
        {
            CheckIsTableNotNull();
            RealPivotData.AcceptChanges();
            m_ClonedPivotData = RealPivotData.Clone();
        }

        public void Dispose()
        {
            if (RealPivotData != null)
            {
                DataTable oldDataSource = RealPivotData;
                RealPivotData = RealPivotData.Clone();
                DbDisposeHelper.DisposeTable(ref oldDataSource, true);
            }
        }

        private void CheckIsTableNotNull()
        {
            if (RealPivotData == null)
            {
                throw new AvrException("Table of AvrPivotGridData is not initialized");
            }
        }
    }
}