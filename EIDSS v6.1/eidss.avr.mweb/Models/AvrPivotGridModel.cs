using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using DevExpress.Web.Mvc;
using bv.common.Configuration;
using eidss.avr.db.Common;
using eidss.avr.mweb.Utils;
using eidss.model.AVR.SourceData;
using eidss.web.common.Utils;

namespace eidss.avr.mweb.Models
{
    public class AvrPivotGridModel : AvrPivotGridData
    {
        public AvrPivotGridModel(AvrPivotSettings pivotSettings, AvrDataTable realPivotData)
            : base(realPivotData)
        {
            bv.common.Core.Utils.CheckNotNull(pivotSettings, "pivotSettings");

            PivotSettings = pivotSettings;
            ControlPivotGridSettings = null;
        }

        public AvrDataTable PivotData
        {
            get { return PivotSettings.ShowDataInPivot ? RealPivotData : ClonedPivotData; }
            set { RealPivotData = value; }
        }

        public AvrPivotSettings PivotSettings { get; set; }
        public PivotGridSettings ControlPivotGridSettings { get; set; }
        public DropDownEditSettings ControlTotalsSettings { get; set; }

        public bool IsFirstLoad { get; set; }
        public bool ShowPrefilter { get; set; }
        public bool ShowingPrefilter { get; set; }

        public void HideDataForComplexLayout()
        {
            // todo: make some actions to hide data when layout too complex
            PivotSettings.ShowMissedValues = false;
            PivotSettings.ShowDataInPivot = false;
        }

        public object GetAvailableMapFieldView()
        {
            if (PivotSettings.LayoutDataset != null)
            {
                return new DataView(PivotSettings.LayoutDataset.LayoutSearchField);
            }
            return null;
        }
        
        private DateTime m_LastAccessTime = DateTime.MinValue;
        public DateTime LastAccessTime { get { return m_LastAccessTime; } }
        private readonly static object m_SyncObject = new object();
        public override AvrDataTable RealPivotData
        {
            get
            {
                lock (m_SyncObject)
                {
                    if (m_RealPivotData != null)
                        return m_RealPivotData;
                    bool isNewObject;
                    string errorMessage;
                    base.RealPivotData = LayoutPivotGridHelper.GetPivotData(PivotSettings.LayoutDataset,
                                                                            PivotSettings.QueryId,
                                                                            PivotSettings.LayoutId,
                                                                            PivotSettings.UseArchiveData,
                                                                            out isNewObject, out errorMessage);
                    if (PivotSettings.ShowMissedValues)
                        LayoutPivotGridHelper.AddMissedValues(this, false);
                    return m_RealPivotData;
                }
            }
            set
            {
                lock (m_SyncObject)
                {
                    m_LastAccessTime = DateTime.Now;
                    base.RealPivotData = value;
                }
            }
        }

        private static void DeleteByTimeout()
        {
            lock (m_SyncObject)
            {
                try
                {
                    var list = ObjectStorage.Find<AvrPivotGridModel>(m => m.m_RealPivotData != null && (DateTime.Now - m.LastAccessTime).TotalSeconds > WebAvrDataLifeTime);
                    list.ForEach(m =>
                        {
                            if (m.m_RealPivotData != null)
                            {
                                m.m_RealPivotData.Dispose();
                                m.m_RealPivotData = null;
                                if (m.ClonedPivotData != null)
                                {
                                    m.ClonedPivotData.Dispose();
                                    //m.ClonedPivotData = null;
                                }
                            }
                        });
                }
                catch
                {
                }
            }


        }

        private static int m_WebAvrDataCheckInterval = -1;
        private static int WebAvrDataCheckInterval
        {
            get
            {
                if (m_WebAvrDataCheckInterval == -1)
                    m_WebAvrDataCheckInterval = BaseSettings.WebAvrDataCheckInterval;
                return m_WebAvrDataCheckInterval;
            }
        }
        private static int m_WebAvrDataLifeTime = -1;
        private static int WebAvrDataLifeTime
        {
            get
            {
                if (m_WebAvrDataLifeTime == -1)
                    m_WebAvrDataLifeTime = BaseSettings.WebAvrDataLifeTime;
                return m_WebAvrDataLifeTime;
            }
        }
        private static Timer m_DeleteAvrDataTimer = new Timer(t =>
        {
            DeleteByTimeout();
            m_DeleteAvrDataTimer.Change(WebAvrDataCheckInterval * 1000, Timeout.Infinite);
        }, null, WebAvrDataCheckInterval * 1000, Timeout.Infinite);

    }
}