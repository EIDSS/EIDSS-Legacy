using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bv.common.db.Core;
using eidss.avr.db.Common;
using eidss.model.Avr.View;
using eidss.model.Resources;

namespace eidss.avr.mweb.Models
{
    public class ColumnElement
    {
        string uniquePath = string.Empty;
        string fullPath = string.Empty;
        string info = string.Empty;
        string displayText = string.Empty;
        string sourceColumn = string.Empty;
        string denominatorColumn = string.Empty;
        long? aggrFunction = null;
        int? precision = null;
        bool isBand = false;
        bool isColumn = false;
        bool isAggregate = false;

        public string UniquePath { get { return uniquePath; } }
        public string FullPath { get { return fullPath; } }
        public string DisplayText { get { return displayText; } set { displayText = value; } }
        public string SourceColumn { get { return sourceColumn; } set { sourceColumn = value; } }
        public string DenominatorColumn { get { return denominatorColumn; } set { denominatorColumn = value; } }
        public int? Precision { get { return precision; } set { precision = value; } }
        public long? AggrFunction { get { return aggrFunction; } set { aggrFunction = value; } }
        public string Info { get { return info; } }
        public bool IsBand { get { return isBand; } }
        public bool IsColumn { get { return isColumn; } }
        public bool IsAggregate { get { return isAggregate; } }

        public ColumnElement()
        {
        }

        public ColumnElement(AvrViewColumn col)
        {
            this.uniquePath = col.UniquePath;
            this.fullPath = col.FullPath;
            this.displayText = col.DisplayText;
            this.isColumn = true;
            this.info = col.IsAggregate ?
                            EidssMessages.Get("AggregateColumn: ") + col.AggregateFunctionName() :
                            EidssMessages.Get("OrdinaryColumn");
            this.isAggregate = col.IsAggregate;
            if (col.IsAggregate)
            {
                this.aggrFunction = col.AggregateFunction;
                this.precision = col.Precision;
                this.sourceColumn = col.SourceViewColumn;
                this.denominatorColumn = col.DenominatorViewColumn;
            }

        }

        public ColumnElement(AvrViewBand band)
        {
            this.uniquePath = band.UniquePath;
            this.fullPath = band.FullPath;
            this.displayText = band.DisplayText;
            this.info = model.Resources.EidssMessages.Get("Band");
            this.isBand = true;
        }
    }

    public static class WebAvrViewModel
    {
        public static string AggregateFunctionName(this AvrViewColumn obj)
        {
            return LookupCache.GetLookupValue(obj.AggregateFunction, EIDSS.LookupTables.AggregateFunction, "AggregateFunctionName");
        }

        public static string SelectedColBandName(this AvrView obj)
        {
            var field = obj.SelectedColBandObject();
            return field.DisplayText;
        }

        public static string SelectedColAggrFunction(this AvrView obj)
        {
            var field = obj.SelectedColBandObject();
            if (!field.AggrFunction.HasValue)
                return "";
            return field.AggrFunction.Value.ToString();
        }

        public static ColumnElement SelectedColBandObject(this AvrView obj)
        {
            AvrViewColumn col = obj.GetColumnByOriginalName(obj.SelectedColBand);
            if (col != null)
            {
                return new ColumnElement(col);
            }
            AvrViewBand band = obj.GetBandByOriginalName(obj.SelectedColBand);
            if (band != null)
            {
                return new ColumnElement(band);
            }
            return new ColumnElement();
        }

        public static IEnumerable<ColumnElement> GetAllBandsColumns(this AvrView obj)
        {
            obj.FillBandsFullPaths();

            var ret = new List<ColumnElement> { new ColumnElement() };
            return obj.GetVisibleBandsColumns("", ret);
        }

        private static List<ColumnElement> GetVisibleBandsColumns(this BaseBand obj, string path, List<ColumnElement> result)
        {
            obj.Columns.FindAll(c => !c.IsToDelete && c.IsVisible)
                       .OrderBy(c => c.Order_ForUse)
                       .ToList()
                       .ForEach(c =>
                        {
                            c.FullPath = (path.Length == 0 ? " " : path + "->") + bv.common.Core.Utils.Str(c.DisplayText);
                            result.Add(new ColumnElement(c));
                        });

            obj.Bands.FindAll(b => !b.IsToDelete && b.IsVisible)
                     .OrderBy(b => b.Order_ForUse)
                     .ToList()
                     .ForEach(b =>
                      {
                         b.FullPath = (path.Length == 0 ? " " : path + "->") + bv.common.Core.Utils.Str(b.DisplayText);
                         result.Add(new ColumnElement(b));

                         b.GetVisibleBandsColumns(b.FullPath, result);
                      });
            return result;
        }

    }
}