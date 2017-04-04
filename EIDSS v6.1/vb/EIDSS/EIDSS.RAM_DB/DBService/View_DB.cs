using System;
using System.Data;
using bv.common;
using bv.common.Core;
using bv.common.db.Core;
using bv.common.Enums;
using bv.common.Objects;
using bv.model.Model.Core;
using eidss.avr.db.Common;
using eidss.model.Avr.View;
using eidss.model.WindowsService.Serialization;

namespace eidss.avr.db.DBService
{
    public class View_DB : BaseAvrDbService
    {
        #region Constants

        private const string TasView = "tasView";
        private const string TasViewBand = "tasViewBand";
        private const string TasViewColumn = "tasViewColumn";
        private const string TasLayout = "tasLayout";

        #endregion

        public View_DB()
        {
            ObjectName = @"AsView";
        }

        public AvrView avrView { get; set; }

        #region Get

        public DataSet GetDetail(object id, IDbTransaction transaction)
        {
            long correctedId = CorrectId(id, -1);

            var ds = new DataSet();
            try
            {
                IDbCommand cmd = CreateSPCommand("spAsView_SelectDetail", transaction);
                AddParam(cmd, "@ID", id, ref m_Error);
                if (m_Error != null)
                {
                    return (null);
                }
                AddParam(cmd, "@LangID", ModelUserContext.CurrentLanguage, ref m_Error);
                if (m_Error != null)
                {
                    return (null);
                }
                FillDataset(cmd, ds, TasView);
                ds.EnforceConstraints = false;
                CorrectTableEx(ds.Tables[0], TasView, new[] {"idfView", "idfsLanguage"});
                CorrectTableEx(ds.Tables[1], TasViewBand, new[] {"idfViewBand", "idfsLanguage"});
                CorrectTableEx(ds.Tables[2], TasViewColumn, new[] {"idfViewColumn", "idfsLanguage"});
                ClearColumnsAttibutes(ds);

                if (ds.Tables[TasView].Rows.Count == 0)
                {
                    m_ID = correctedId;
                    m_IsNewObject = true;

                    DataRow row = ds.Tables[TasView].NewRow();
                    row["idfView"] = correctedId;
                    row["idflLayout"] = correctedId;
                    var layoutsView = LookupCache.Get("Layout");
                    var layoutRow = layoutsView.Table.Rows.Find(correctedId);
//                    if (layoutRow == null)
//                    {
//                        LookupCache.Fill(new LookupTableInfo("Layout"), true);
//                        layoutsView = LookupCache.Get("Layout");
//                        layoutRow = layoutsView.Table.Rows.Find(correctedId);
//                    }
                    row["idflQuery"] = layoutRow != null 
                        ? layoutRow["idflQuery"] 
                        : -1L;

                    if (Connection.State != ConnectionState.Open)
                    {
                        Connection.Open();
                    }
                    AvrBinarySettings layoutSettings = GetLayoutLocalBinarySettings(correctedId, transaction);
                    row["blbChartLocalSettings"] = layoutSettings.ChartSettings;
                    row["blbGisLayerLocalSettings"] = layoutSettings.GisLayerSettings;
                    row["blbGisMapLocalSettings"] = layoutSettings.GisMapSettings;
                    row["intGisLayerPosition"] = layoutSettings.GisLayerPosition ?? (object)DBNull.Value;

                    ds.EnforceConstraints = false;
                    ds.Tables[TasView].Rows.Add(row);
                }
                else
                {
                    m_IsNewObject = false;
                }

                ds.EnforceConstraints = false;

                avrView = new AvrView(ds, TasView, TasViewBand, TasViewColumn);
                if (m_IsNewObject)
                {
                    avrView.SetNew();
                }

                return (ds);
            }
            catch (Exception ex)
            {
                m_Error = new ErrorMessage(StandardError.FillDatasetError, ex);
            }
            return null;
        }

        public override DataSet GetDetail(object id)
        {
            return GetDetail(id, null);
        }

        #endregion

        #region Post

        public bool PostDetail(IDbTransaction transaction = null)
        {
            return PostDetail(null, 0, transaction);
        }

        public void DeleteDeletedView(IDbTransaction transaction = null)
        {
            Utils.CheckNotNull(avrView, "avrView");

            IDbCommand cmdBandDel = CreateSPCommandWithParams("spAsViewBand_Delete", transaction);
            IDbCommand cmdColDel = CreateSPCommandWithParams("spAsViewColumn_Delete", transaction);

            if (cmdBandDel == null || cmdColDel == null)
            {
                return;
            }

            // Delete Children - Bands
            avrView.Bands.ForEach(b => DeleteDeletedBand(cmdBandDel, cmdColDel, b));
            // Delete Children - Columns
            avrView.Columns.FindAll(c => c.IsToDelete).ForEach(c => DeleteDeletedColumn(cmdColDel, c));

            //Delete deleted bands and columns in data
            avrView.RemoveDeleted();
        }

        public override bool PostDetail(DataSet dataSet, int postType, IDbTransaction transaction = null)
        {
            Utils.CheckNotNull(avrView, "avrView");

            try
            {
                if (avrView.IsChanged)
                {
                    IDbCommand cmd = CreateSPCommand("spAsView_Post", transaction);
                    if (m_IsNewObject || avrView.IsSelfChanged)
                    {
                        SetParam(cmd, "@LangID", ModelUserContext.CurrentLanguage);
                        SetParam(cmd, "@idflLayout", avrView.LayoutID);
                        SetParam(cmd, "@ChartXAxisViewColumn", avrView.ChartXAxisViewColumn);
                        SetParam(cmd, "@MapAdminUnitViewColumn", avrView.MapAdminUnitViewColumn);
                        SetParam(cmd, "@idfGlobalView", avrView.GlobalView);
                        if (avrView.ChartLocalSettingsZip == null)
                        {
                            avrView.ChartLocalSettingsZip = string.IsNullOrEmpty(avrView.ChartLocalSettingsXml)
                                ? new byte[0]
                                : BinaryCompressor.ZipString(avrView.ChartLocalSettingsXml);
                        }
                        SetParam(cmd, "@blbChartLocalSettings", avrView.ChartLocalSettingsZip);
                        if (avrView.GisLayerLocalSettingsZip == null)
                        {
                            avrView.GisLayerLocalSettingsZip = string.IsNullOrEmpty(avrView.GisLayerLocalSettingsXml)
                                ? new byte[0]
                                : BinaryCompressor.ZipString(avrView.GisLayerLocalSettingsXml);
                        }
                        SetParam(cmd, "@blbGisLayerLocalSettings", avrView.GisLayerLocalSettingsZip);
                        if (avrView.GisMapLocalSettingsZip == null)
                        {
                            avrView.GisMapLocalSettingsZip = string.IsNullOrEmpty(avrView.GisMapLocalSettingsXml)
                                ? new byte[0]
                                : BinaryCompressor.ZipString(avrView.GisMapLocalSettingsXml);
                        }
                        SetParam(cmd, "@blbGisMapLocalSettings", avrView.GisMapLocalSettingsZip);
                        if (avrView.ViewSettingsZip == null)
                        {
                            avrView.ViewSettingsZip = string.IsNullOrEmpty(avrView.ViewSettingsXml)
                                ? new byte[0]
                                : BinaryCompressor.ZipString(avrView.ViewSettingsXml);
                        }
                        SetParam(cmd, "@blbViewSettings", avrView.ViewSettingsZip);
                        SetParam(cmd, "@intGisLayerPosition", avrView.GisLayerPosition);
                        ExecCommand(cmd, cmd.Connection, transaction, true);
                    }

                    IDbCommand cmdBand = CreateSPCommandWithParams("spAsViewBand_Post", transaction);
                    IDbCommand cmdCol = CreateSPCommandWithParams("spAsViewColumn_Post", transaction);

                    // Post Children - Bands
                    avrView.Bands.ForEach(b => PostBand(cmdBand, cmdCol, b, null));

                    // Post Children - Columns
                    if (m_IsNewObject)
                    {
                        avrView.Columns.ForEach(c => PostColumn(cmdCol, c, null));
                    }
                    else
                    {
                        avrView.Columns.FindAll(c => c.IsSelfChanged).ForEach(c => PostColumn(cmdCol, c, null));
                    }

                    // first time links to ChartXAxisViewColumn and MapAdminUnitViewColumn could be nonexistent
                    if (avrView.IsSelfChanged && (avrView.ChartXAxisViewColumn != null || avrView.MapAdminUnitViewColumn != null))
                    {
                        ExecCommand(cmd, cmd.Connection, transaction, true);
                    }

                    avrView.SetUnchanged();
                    avrView.SetNotNew();

                    m_IsNewObject = false;

                }

                if (avrView.HasToDelete)
                {
                    DeleteDeletedView(transaction);
                }
            }
            catch (Exception ex)
            {
                m_Error = new ErrorMessage(StandardError.PostError, ex);
                return false;
            }
            return true;
        }

        private void PostBand(IDbCommand cmdBandPost, IDbCommand cmdColumnPost, AvrViewBand obj, long? parent)
        {
            if (cmdBandPost == null || obj == null)
            {
                return;
            }
            if (!obj.IsToDelete)
            {
                if (m_IsNewObject || obj.IsSelfChanged)
                {
                    SetParam(cmdBandPost, "@LangID", ModelUserContext.CurrentLanguage);
                    SetParam(cmdBandPost, "@idfView", obj.ViewID);
                    SetParam(cmdBandPost, "@idfViewBand", obj.ID, ParameterDirection.InputOutput);
                    if (obj.LayoutSearchFieldId > 0)
                    {
                        SetParam(cmdBandPost, "@idfLayoutSearchField", obj.LayoutSearchFieldId);
                    }
                    else
                    {
                        SetParam(cmdBandPost, "@idfLayoutSearchField", null);
                    }
                    SetParam(cmdBandPost, "@strOriginalName", obj.OriginalName);
                    SetParam(cmdBandPost, "@strDisplayName", obj.DisplayText);
                    SetParam(cmdBandPost, "@blnVisible", obj.IsVisible);
                    SetParam(cmdBandPost, "@blnFreeze", obj.IsFreezed);
                    SetParam(cmdBandPost, "@intOrder", obj.Order);
                    SetParam(cmdBandPost, "@idfParentViewBand", parent);

                    ExecCommand(cmdBandPost, cmdBandPost.Connection, cmdBandPost.Transaction, true);
                    obj.ID = (long) ((IDataParameter) cmdBandPost.Parameters["@idfViewBand"]).Value;
                }

                // Post Children - Bands
                obj.Bands.ForEach(b => PostBand(cmdBandPost, cmdColumnPost, b, obj.ID));

                // Post Children - Columns
                if (m_IsNewObject)
                {
                    obj.Columns.ForEach(c => PostColumn(cmdColumnPost, c, obj.ID));
                }
                else
                {
                    obj.Columns.FindAll(c => c.IsSelfChanged).ForEach(c => PostColumn(cmdColumnPost, c, obj.ID));
                }
            }
            obj.SetUnchanged();
        }

        private void PostColumn(IDbCommand cmdColumnPost, AvrViewColumn obj, long? parent)
        {
            if (cmdColumnPost == null || obj == null)
            {
                return;
            }
            if (!obj.IsToDelete)
            {
                SetParam(cmdColumnPost, "@LangID", ModelUserContext.CurrentLanguage);
                SetParam(cmdColumnPost, "@idfView", obj.ViewID);
                SetParam(cmdColumnPost, "@idfViewBand", parent);
                SetParam(cmdColumnPost, "@idfViewColumn", obj.ID, ParameterDirection.InputOutput);
                if (obj.LayoutSearchFieldId > 0)
                {
                    SetParam(cmdColumnPost, "@idfLayoutSearchField", obj.LayoutSearchFieldId);
                }
                else
                {
                    SetParam(cmdColumnPost, "@idfLayoutSearchField", null);
                }
                SetParam(cmdColumnPost, "@strOriginalName", obj.OriginalName);
                SetParam(cmdColumnPost, "@strDisplayName", obj.DisplayText);
                SetParam(cmdColumnPost, "@blnAggregateColumn", obj.IsAggregate);
                SetParam(cmdColumnPost, "@idfsAggregateFunction", obj.AggregateFunction);
                SetParam(cmdColumnPost, "@intPrecision", obj.Precision);
                SetParam(cmdColumnPost, "@blnChartSeries", obj.IsChartSeries);
                SetParam(cmdColumnPost, "@blnMapDiagramSeries", obj.IsMapDiagramSeries);
                SetParam(cmdColumnPost, "@blnMapGradientSeries", obj.IsMapGradientSeries);
                SetParam(cmdColumnPost, "@SourceViewColumn", obj.SourceViewColumn);
                SetParam(cmdColumnPost, "@DenominatorViewColumn", obj.DenominatorViewColumn);
                SetParam(cmdColumnPost, "@blnVisible", obj.IsVisible);
                SetParam(cmdColumnPost, "@blnFreeze", obj.IsFreezed);
                SetParam(cmdColumnPost, "@intSortOrder", obj.SortOrder);
                SetParam(cmdColumnPost, "@blnSortAscending", obj.IsSortAscending);
                SetParam(cmdColumnPost, "@intOrder", obj.Order);
                SetParam(cmdColumnPost, "@strColumnFilter", obj.ColumnFilter);
                SetParam(cmdColumnPost, "@intColumnWidth", obj.ColumnWidth);

                ExecCommand(cmdColumnPost, cmdColumnPost.Connection, cmdColumnPost.Transaction, true);
                obj.ID = (long) ((IDataParameter) cmdColumnPost.Parameters["@idfViewColumn"]).Value;
                obj.SetUnchanged();
            }
        }

        private void DeleteDeletedBand(IDbCommand cmdBandDel, IDbCommand cmdColumnDel, AvrViewBand obj)
        {
            if (cmdBandDel == null || cmdColumnDel == null || obj == null)
            {
                return;
            }
            // Delete Children - Bands
            obj.Bands.ForEach(b => DeleteDeletedBand(cmdBandDel, cmdColumnDel, b));
            // Delete Children - Columns
            obj.Columns.FindAll(c => c.IsToDelete).ForEach(c => DeleteDeletedColumn(cmdColumnDel, c));

            if (obj.IsToDelete)
            {

                SetParam(cmdBandDel, "@LangID", ModelUserContext.CurrentLanguage);
                SetParam(cmdBandDel, "@idfView", obj.ViewID);
                SetParam(cmdBandDel, "@idfViewBand", obj.ID);

                ExecCommand(cmdBandDel, cmdBandDel.Connection, cmdBandDel.Transaction, true);
            }
       }

        private void DeleteDeletedColumn(IDbCommand cmdColumnDel, AvrViewColumn obj)
        {
            if (cmdColumnDel == null || obj == null)
            {
                return;
            }
            if (obj.IsToDelete)
            {
                SetParam(cmdColumnDel, "@LangID", ModelUserContext.CurrentLanguage);
                SetParam(cmdColumnDel, "@idfView", obj.ViewID);
                SetParam(cmdColumnDel, "@idfViewColumn", obj.ID);

                ExecCommand(cmdColumnDel, cmdColumnDel.Connection, cmdColumnDel.Transaction, true);
                cmdColumnDel.ExecuteNonQuery();
            }
        }

/*
        public bool DeleteView()
        {
            Utils.CheckNotNull(avrView, "avrView");

            try
            {
                IDbCommand cmd = CreateSPCommand("spAsView_Delete");
                SetParam(cmd, "@LangID", ModelUserContext.CurrentLanguage);
                SetParam(cmd, "@idfView", avrView.LayoutID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                m_Error = new ErrorMessage(StandardError.PostError, ex);
                return false;
            }
            avrView = null;
            return true;
        }
*/

        #endregion
    }
}