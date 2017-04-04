using System;
using System.Data;
using System.Drawing;
using bv.common.Core;
using bv.common.db.Core;
using eidss.avr.BaseComponents;
using eidss.avr.ChartForm;
using eidss.avr.db.Common;
using eidss.model.AVR.ServiceData;
using eidss.model.WindowsService.Serialization;
using StructureMap;

namespace eidss.avr.service.VirtualLayout
{
    public class VirtualChart : IDisposable
    {
        private ChartDetailForm m_ChartDetail;

        private readonly SharedPresenter m_SharedPresenter;

        public VirtualChart(IContainer container)
        {
            using (PresenterFactory.BeginSharedPresenterTransaction(container, new EmptyPostableForm()))
            {
                m_SharedPresenter = PresenterFactory.SharedPresenter;
                // any size
                m_ChartDetail = new ChartDetailForm {Size = new Size(1000, 1000)};
            }
        }

        public void Dispose()
        {
            if (m_ChartDetail != null)
            {
                DataTable oldDataSource = m_ChartDetail.DataSource;
                if (oldDataSource != null)
                {
                    m_ChartDetail.DataSource = null;
                    DbDisposeHelper.DisposeTable(ref oldDataSource, true);
                }
                m_ChartDetail.Dispose();
                m_ChartDetail = null;
            }
            if (m_SharedPresenter != null)
            {
                m_SharedPresenter.Dispose();
            }
        }

        public ChartExportDTO ExportChartToJpg(ChartTableDTO zippedData, object syncLock)
        {
            Utils.CheckNotNull(zippedData, "zippedData");
            if (m_ChartDetail == null)
            {
                throw new AvrException("Chart already disposed.");
            }

            BaseTableDTO unzippedData = BinaryCompressor.Unzip(zippedData);
            DataTable data = BinarySerializer.DeserializeToTable(unzippedData);
            if (zippedData.TextPatterns != null)
            {
                foreach (string col in zippedData.TextPatterns.Keys)
                {
                    data.Columns[col].ExtendedProperties.Add("TextPattern", zippedData.TextPatterns[col]);
                }
            }

            ChartExportDTO result;
            lock (syncLock)
            {
                m_ChartDetail.DataSource = data;
                object id = zippedData.ViewId;

                m_ChartDetail.LoadData(ref id);

                m_ChartDetail.ChartControlSize = new Size(zippedData.Width, zippedData.Height);
                result = m_ChartDetail.ExportToJpgBytes(zippedData.ChartSettings, zippedData.ChartType);
            }
            return result;
        }
    }
}