using System;
using System.Diagnostics;
using System.Drawing;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.gis;
using eidss.model.Resources;
using EIDSS.Reports.Document.Veterinary.AvianInvestigation;

namespace EIDSS.Reports.Document.Veterinary.LivestockInvestigation
{
    public static class PrintMapHelper
    {
        public static Bitmap GetPrintMap(AvianInvestigationDataSet.spRepVetAvianCaseDataTable dataTable)
        {
            if (dataTable.Count == 0)
            {
                return new Bitmap(1, 1);
            }

            AvianInvestigationDataSet.spRepVetAvianCaseRow row = dataTable[0];
            long settlemenyId = row.IsFarmSettlementIdNull() ? 0 : row.FarmSettlementId;
            decimal x = row.IsFarmLongitudeNull() ? 0 : (decimal) row.FarmLongitude;
            decimal y = row.IsFarmLatitudeNull() ? 0 : (decimal) row.FarmLatitude;
            WaitDialog wait = null;
            try
            {
                wait = CreateMapWaitDialog();
                return GisInterface.GetPrintMap(row.FarmCountryId, row.FarmRegionId, row.FarmRayonId, settlemenyId, x, y);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return GetErrorBitmap(ex);
            }
            finally
            {
                if (wait != null)
                {
                    wait.Dispose();
                }
            }
        }

        public static Bitmap GetPrintMap(LivestockInvestigationDataSet.spRepVetLivestockCaseDataTable dataTable)
        {
            if (dataTable.Count == 0)
            {
                return new Bitmap(1, 1);
            }

            LivestockInvestigationDataSet.spRepVetLivestockCaseRow row = dataTable[0];
            long settlemenyId = row.IsFarmSettlementIdNull() ? 0 : row.FarmSettlementId;
            decimal x = row.IsFarmLongitudeNull() ? 0 : (decimal) row.FarmLongitude;
            decimal y = row.IsFarmLatitudeNull() ? 0 : (decimal) row.FarmLatitude;
            WaitDialog wait = null;
            try
            {
                wait = CreateMapWaitDialog();
                return GisInterface.GetPrintMap(row.FarmCountryId, row.FarmRegionId, row.FarmRayonId, settlemenyId, x, y);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return GetErrorBitmap(ex);
            }
            finally
            {
                if (wait != null)
                {
                    wait.Dispose();
                }
            }
        }

        public static WaitDialog CreateMapWaitDialog()
        {
            if (!BaseFormManager.IsReportsServiceRunning && !BaseFormManager.IsAvrServiceRunning)
            {
                string title = EidssMessages.Get("msgPleaseWait");
                string caption = EidssMessages.Get("msgMapInitializing");
                return new WaitDialog(caption, title);
            }
            return null;
        }
        public static Bitmap GetErrorBitmap(Exception ex)
        {
            // some magic numbers for error output ))
            var bitmap = new Bitmap(600, 600);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawString("Map Error", new Font("Tahoma", 32), Brushes.Black, 20, 20);
                g.DrawString(ex.ToString(), new Font("Tahoma", 10), Brushes.Black, new RectangleF(20, 100, 560, 500));
            }
            return bitmap;
        }
    }
}