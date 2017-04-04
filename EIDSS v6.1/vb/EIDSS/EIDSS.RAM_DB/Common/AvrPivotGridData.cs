using System;
using System.Collections.Generic;
using bv.common.Core;
using eidss.model.AVR.SourceData;

namespace eidss.avr.db.Common
{
    public class AvrPivotGridData : IDisposable
    {
        protected AvrDataTable m_RealPivotData;

        public AvrPivotGridData()
            : this(new AvrDataTable {TableName = @"Empty Table"})
        {
        }

        public AvrPivotGridData(AvrDataTable realPivotData)
        {
            RealPivotData = realPivotData;
        }

        public virtual AvrDataTable RealPivotData
        {
            get { return m_RealPivotData; }
            set
            {
                m_RealPivotData = value;
                if(ClonedPivotData != null)
                    ClonedPivotData.Dispose();
                if (m_RealPivotData != null)
                    ClonedPivotData = m_RealPivotData.Clone();
                else
                    ClonedPivotData = null;
            }
        }

        public AvrDataTable ClonedPivotData { get; private set; }

        public IEnumerable<AvrDataRowBase> Rows
        {
            get
            {
                CheckIsTableNotNull();
                return RealPivotData.Rows;
            }
        }

        public IEnumerable<AvrDataColumn> Columns
        {
            get
            {
                CheckIsTableNotNull();
                return RealPivotData.Columns;
            }
        }
        public int RowsCount
        {
            get
            {
                CheckIsTableNotNull();
                return RealPivotData.Rows.Count;
            }
        }

        public AvrDataRow NewRow()
        {
            CheckIsTableNotNull();
            return RealPivotData.NewRow();
        }

        public void ThreadSafeAddRow(AvrDataRowBase row)
        {
            Utils.CheckNotNull(row, "row");
            CheckIsTableNotNull();
            RealPivotData.ThreadSafeAdd(row);
        }

      

        public void RejectChanges()
        {
            CheckIsTableNotNull();
            RealPivotData.RejectChanges();
        }

        public void Dispose()
        {
            if (RealPivotData != null)
            {
                AvrDataTable oldDataSource = RealPivotData;
                RealPivotData = RealPivotData.Clone();
                oldDataSource.Clear();
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