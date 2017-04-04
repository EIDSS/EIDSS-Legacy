using System;
using System.Collections.Generic;
using System.Globalization;
using eidss.model.Avr.Pivot;
using eidss.model.WindowsService.Serialization;

namespace eidss.avr.db.Common
{
    public class AvrBinarySettings
    {
        public AvrBinarySettings()
        {
            Version = PivotGridXmlVersion.Version7;
            MainSettings = new byte[0];
            ChartSettings = new byte[0];
            GisLayerSettings = new byte[0];
            GisMapSettings = new byte[0];
        }

        public PivotGridXmlVersion Version { get; set; }

        public byte[] MainSettings { get; set; }

        public byte[] ChartSettings { get; set; }

        public byte[] GisLayerSettings { get; set; }

        public byte[] GisMapSettings { get; set; }

        public int? GisLayerPosition { get; set; }

        public bool IsOldVersion
        {
            get
            {
                return Version == PivotGridXmlVersion.Version5 || Version == PivotGridXmlVersion.Version6;
            }
        }

        public bool AreAllBinariesEmpty
        {
            get
            {
                return (MainSettings == null || MainSettings.Length == 0) &&
                       (ChartSettings == null || ChartSettings.Length == 0) &&
                       (GisLayerSettings == null || GisLayerSettings.Length == 0) &&
                       (GisMapSettings == null || GisMapSettings.Length == 0);

            }
        }
        public void ReplaceIds(Dictionary<long, long> changedIds, bool isMainSettingsZipped = false)
        {
            MainSettings = isMainSettingsZipped
                ? ReplaceIdsInZip(MainSettings, changedIds)
                : ReplaceIdsInSerialized(MainSettings, changedIds);
            ChartSettings = ReplaceIdsInZip(ChartSettings, changedIds);
            GisLayerSettings = ReplaceIdsInZip(GisLayerSettings, changedIds);
            GisMapSettings = ReplaceIdsInZip(GisMapSettings, changedIds);
        }

        public static byte[] ReplaceIdsInZip(byte[] settings, Dictionary<long, long> changedIds)
        {
            string resultString = BinaryCompressor.UnzipString(settings);
            resultString = ReplaceIds(resultString, changedIds);
            return BinaryCompressor.ZipString(resultString);
        }

        public static byte[] ReplaceIdsInSerialized(byte[] settings, Dictionary<long, long> changedIds)
        {
            string resultString = BinarySerializer.DeserializeToString(settings);
            resultString = ReplaceIds(resultString, changedIds);
            return BinarySerializer.SerializeFromString(resultString);
        }

        public static string ReplaceIds(string settings, Dictionary<long, long> changedIds)
        {
            if (!String.IsNullOrEmpty(settings))
            {
                foreach (KeyValuePair<long, long> pair in changedIds)
                {
                    string oldId = pair.Key.ToString(CultureInfo.InvariantCulture);
                    string newId = pair.Value.ToString(CultureInfo.InvariantCulture);
                    settings = settings.Replace(oldId, newId);
                }
            }
            return settings;
        }
    }
}