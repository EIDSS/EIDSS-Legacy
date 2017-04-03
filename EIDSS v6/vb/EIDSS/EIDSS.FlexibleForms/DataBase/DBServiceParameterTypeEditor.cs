using System;
using System.Data;
using System.Data.SqlClient;
using bv.common;
using bv.common.Enums;
using bv.common.db.Core;
using EIDSS.FlexibleForms.DataBase.FlexibleFormsDSTableAdapters;
using EIDSS.FlexibleForms.Helpers;

namespace EIDSS.FlexibleForms.DataBase
{
    public class DBServiceParameterTypeEditor : DbService
    {
        #region јдаптеры

        private readonly ParameterFixedPresetValueTableAdapter m_ParameterFixedPresetValueTableAdapter;
        private readonly ParameterReferenceTypeTableAdapter m_ParameterTypeTableAdapter;
        private readonly ReferenceTypesListTableAdapter m_ReferenceTypesListTableAdapter;
        private readonly ReferenceTypesTableAdapter m_ReferenceTypesTableAdapter;

        #endregion

        private SqlCommand m_CommandDeleteParameterFixedPresetValues;
        private SqlCommand m_CommandDeleteParameterReferenceTypes;
        private SqlCommand m_CommandSaveParameterFixedPresetValues;
        private SqlCommand m_CommandSaveParameterReferenceTypes;

        /// <summary>
        /// 
        /// </summary>
        public DBServiceParameterTypeEditor()
        {
            ObjectName = "ParameterTypeEditor";

            MainDataSet = new FlexibleFormsDS();
            //
            m_ParameterTypeTableAdapter = new ParameterReferenceTypeTableAdapter();
            m_ParameterFixedPresetValueTableAdapter = new ParameterFixedPresetValueTableAdapter();
            m_ReferenceTypesTableAdapter = new ReferenceTypesTableAdapter();
            m_ReferenceTypesListTableAdapter = new ReferenceTypesListTableAdapter();

            //
            m_ParameterTypeTableAdapter.Connection =
                m_ParameterFixedPresetValueTableAdapter.Connection =
                m_ReferenceTypesTableAdapter.Connection =
                m_ReferenceTypesListTableAdapter.Connection =
                (SqlConnection) Connection;

            //
            m_ParameterFixedPresetValueTableAdapter.ClearBeforeFill =
                m_ReferenceTypesListTableAdapter.ClearBeforeFill =
                false;
        }

        /// <summary>
        ///  оманда дл€ сохранени€ типов параметров (Insert+Update)
        /// </summary>
        public SqlCommand CommandSaveParameterReferenceType
        {
            get
            {
                if (m_CommandSaveParameterReferenceTypes == null)
                {
                    m_CommandSaveParameterReferenceTypes = new SqlCommand
                                                               {
                                                                   CommandText = "dbo.spFFSaveParameterReferenceType",
                                                                   Connection = (SqlConnection) Connection,
                                                                   CommandType = CommandType.StoredProcedure
                                                               };
                    m_CommandSaveParameterReferenceTypes.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4,
                                                                                       ParameterDirection.ReturnValue,
                                                                                       10, 0, null,
                                                                                       DataRowVersion.Current, false,
                                                                                       null, "", "", ""));
                    m_CommandSaveParameterReferenceTypes.Parameters.Add(new SqlParameter("@idfsParameterType",
                                                                                       SqlDbType.BigInt, 8,
                                                                                       ParameterDirection.InputOutput,
                                                                                       19, 0, "idfsParameterType",
                                                                                       DataRowVersion.Current, false,
                                                                                       null, "", "", ""));
                    m_CommandSaveParameterReferenceTypes.Parameters.Add(new SqlParameter("@DefaultName",
                                                                                       SqlDbType.NVarChar, 400,
                                                                                       ParameterDirection.Input, 0, 0,
                                                                                       "DefaultName",
                                                                                       DataRowVersion.Current, false,
                                                                                       null, "", "", ""));
                    m_CommandSaveParameterReferenceTypes.Parameters.Add(new SqlParameter("@NationalName",
                                                                                       SqlDbType.NVarChar, 600,
                                                                                       ParameterDirection.Input, 0, 0,
                                                                                       "NationalName",
                                                                                       DataRowVersion.Current, false,
                                                                                       null, "", "", ""));
                    m_CommandSaveParameterReferenceTypes.Parameters.Add(new SqlParameter("@idfsReferenceType",
                                                                                       SqlDbType.BigInt, 8,
                                                                                       ParameterDirection.Input, 19, 0,
                                                                                       "idfsReferenceType",
                                                                                       DataRowVersion.Current, false,
                                                                                       null, "", "", ""));
                    m_CommandSaveParameterReferenceTypes.Parameters.Add(new SqlParameter("@LangID", SqlDbType.NVarChar, 50,
                                                                                       ParameterDirection.Input, 0, 0,
                                                                                       "LangID", DataRowVersion.Current,
                                                                                       false, null, "", "", ""));
                }
                return m_CommandSaveParameterReferenceTypes;
            }
        }

        /// <summary>
        ///  оманда дл€ сохранени€ предустановленных значений типов параметров (Insert+Update)
        /// </summary>
        public SqlCommand CommandSaveParameterFixedPresetValues
        {
            get
            {
                if (m_CommandSaveParameterFixedPresetValues == null)
                {
                    m_CommandSaveParameterFixedPresetValues = new SqlCommand
                                                                  {
                                                                      CommandText =
                                                                          "dbo.spFFSaveParameterFixedPresetValue",
                                                                      Connection = (SqlConnection) Connection,
                                                                      CommandType = CommandType.StoredProcedure
                                                                  };
                    m_CommandSaveParameterFixedPresetValues.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int,
                                                                                          4,
                                                                                          ParameterDirection.ReturnValue,
                                                                                          10, 0, null,
                                                                                          DataRowVersion.Current, false,
                                                                                          null, "", "", ""));
                    m_CommandSaveParameterFixedPresetValues.Parameters.Add(
                        new SqlParameter("@idfsParameterFixedPresetValue", SqlDbType.BigInt, 8,
                                         ParameterDirection.InputOutput, 19, 0, "idfsParameterFixedPresetValue",
                                         DataRowVersion.Current, false, null, "", "", ""));
                    m_CommandSaveParameterFixedPresetValues.Parameters.Add(new SqlParameter("@idfsParameterType",
                                                                                          SqlDbType.BigInt, 8,
                                                                                          ParameterDirection.Input, 19,
                                                                                          0, "idfsParameterType",
                                                                                          DataRowVersion.Current, false,
                                                                                          null, "", "", ""));
                    m_CommandSaveParameterFixedPresetValues.Parameters.Add(new SqlParameter("@DefaultName",
                                                                                          SqlDbType.NVarChar, 400,
                                                                                          ParameterDirection.Input, 0, 0,
                                                                                          "DefaultName",
                                                                                          DataRowVersion.Current, false,
                                                                                          null, "", "", ""));
                    m_CommandSaveParameterFixedPresetValues.Parameters.Add(new SqlParameter("@NationalName",
                                                                                          SqlDbType.NVarChar, 600,
                                                                                          ParameterDirection.Input, 0, 0,
                                                                                          "NationalName",
                                                                                          DataRowVersion.Current, false,
                                                                                          null, "", "", ""));
                    m_CommandSaveParameterFixedPresetValues.Parameters.Add(new SqlParameter("@LangID", SqlDbType.NVarChar,
                                                                                          50, ParameterDirection.Input,
                                                                                          0, 0, "langid",
                                                                                          DataRowVersion.Current, false,
                                                                                          null, "", "", ""));
                    m_CommandSaveParameterFixedPresetValues.Parameters.Add(new SqlParameter("@intOrder", SqlDbType.Int, 4,
                                                                                          ParameterDirection.Input, 10,
                                                                                          0, "intOrder",
                                                                                          DataRowVersion.Current, false,
                                                                                          null, "", "", ""));
                }
                return m_CommandSaveParameterFixedPresetValues;
            }
        }

        /// <summary>
        /// ”даление типа параметра
        /// </summary>
        public SqlCommand CommandDeleteParameterReferenceTypes
        {
            get
            {
                if (m_CommandDeleteParameterReferenceTypes == null)
                {
                    m_CommandDeleteParameterReferenceTypes = new SqlCommand
                                                                 {
                                                                     CommandText =
                                                                         "dbo.spFFRemoveParameterReferenceType",
                                                                     Connection = (SqlConnection) Connection,
                                                                     CommandType = CommandType.StoredProcedure
                                                                 };
                    m_CommandDeleteParameterReferenceTypes.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int,
                                                                                         4,
                                                                                         ParameterDirection.ReturnValue,
                                                                                         10, 0, null,
                                                                                         DataRowVersion.Current, false,
                                                                                         null, "", "", ""));
                    m_CommandDeleteParameterReferenceTypes.Parameters.Add(new SqlParameter("@idfsParameterType",
                                                                                         SqlDbType.BigInt, 8,
                                                                                         ParameterDirection.Input, 19, 0,
                                                                                         "idfsParameterType",
                                                                                         DataRowVersion.Current, false,
                                                                                         null, "", "", ""));
                }

                return m_CommandDeleteParameterReferenceTypes;
            }
        }

        /// <summary>
        /// ”даление предустановленного значени€ дл€ типа параметра
        /// </summary>
        public SqlCommand CommandDeleteParameterFixedPresetValues
        {
            get
            {
                if (m_CommandDeleteParameterFixedPresetValues == null)
                {
                    m_CommandDeleteParameterFixedPresetValues = new SqlCommand
                                                                    {
                                                                        CommandText =
                                                                            "dbo.spFFRemoveParameterFixedPresetValue",
                                                                        Connection = (SqlConnection) Connection,
                                                                        CommandType = CommandType.StoredProcedure
                                                                    };
                    m_CommandDeleteParameterFixedPresetValues.Parameters.Add(new SqlParameter("@RETURN_VALUE",
                                                                                            SqlDbType.Int, 4,
                                                                                            ParameterDirection.
                                                                                                ReturnValue, 10, 0, null,
                                                                                            DataRowVersion.Current,
                                                                                            false, null, "", "", ""));
                    m_CommandDeleteParameterFixedPresetValues.Parameters.Add(
                        new SqlParameter("@idfsParameterFixedPresetValue", SqlDbType.BigInt, 8, ParameterDirection.Input,
                                         19, 0, "idfsParameterFixedPresetValue", DataRowVersion.Current, false, null, "",
                                         "", ""));
                }

                return m_CommandDeleteParameterFixedPresetValues;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override DataSet GetDetail(object id)
        {
            return MainDataSet;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="da"></param>
        /// <param name="row"></param>
        private void SaveParameterReferenceType(SqlDataAdapter da, FlexibleFormsDS.ParameterReferenceTypeRow row)
        {
            if ((row.RowState == DataRowState.Deleted) || (row.RowState == DataRowState.Unchanged)) return;
            long? oldID = null;
            //сохраним старый ID
            if (row.idfsParameterType < 0) oldID = row.idfsParameterType;
            da.Update(new DataRow[] {row});

            if (oldID != null)
            {
                //найдем все строки, которые завис€т от этого ID, и сохраним их
                for (int i = 0; i < MainDataSet.ParameterFixedPresetValue.Rows.Count; i++)
                {
                    var fixedPresetValueRow =
                        (FlexibleFormsDS.ParameterFixedPresetValueRow) MainDataSet.ParameterFixedPresetValue.Rows[i];
                    if ((fixedPresetValueRow.RowState == DataRowState.Deleted) ||
                        (fixedPresetValueRow.RowState == DataRowState.Unchanged)) continue;
                    if (fixedPresetValueRow.idfsParameterType.Equals(oldID.Value))
                    {
                        fixedPresetValueRow.idfsParameterType = row.idfsParameterType;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="postType"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public override bool PostDetail(DataSet ds, int postType, IDbTransaction transaction)
        {
            try
            {
                var da = new SqlDataAdapter();

                #region —охранение типов параметров

                da.InsertCommand = da.UpdateCommand = CommandSaveParameterReferenceType;
                da.DeleteCommand = CommandDeleteParameterReferenceTypes;
                ApplyTransaction(da, transaction);
                //проходим по всем строкам, которые мен€лись
                var parameterTypeDataTable =
                    (FlexibleFormsDS.ParameterReferenceTypeDataTable) MainDataSet.ParameterReferenceType.GetChanges();
                if (parameterTypeDataTable != null)
                {
                    for (var i = 0; i < MainDataSet.ParameterReferenceType.Rows.Count; i++)
                    {
                        var row =
                            (FlexibleFormsDS.ParameterReferenceTypeRow) MainDataSet.ParameterReferenceType.Rows[i];
                        if (!row.IsRowAlive()) continue;
                        SaveParameterReferenceType(da, row);
                    }
                    //добиваем недобитое
                    var parameterTypeDataTableDeleted =
                        (FlexibleFormsDS.ParameterReferenceTypeDataTable)
                        MainDataSet.ParameterReferenceType.GetChanges(DataRowState.Deleted);
                    if (parameterTypeDataTableDeleted != null) da.Update(parameterTypeDataTableDeleted);
                }

                #endregion

                #region —охран€ем предустановленные значени€

                da = new SqlDataAdapter();

                da.InsertCommand = da.UpdateCommand = CommandSaveParameterFixedPresetValues;
                da.DeleteCommand = CommandDeleteParameterFixedPresetValues;

                ApplyTransaction(da, transaction);
                da.Update(MainDataSet.ParameterFixedPresetValue);

                #endregion

                LookupCache.NotifyChange("ParameterTypeReferenceEditor", transaction);
            }
            catch (SqlException exc)
            {
                m_Error = ErrorHelper.IsEIDSSError(exc.Message)
                              ? new EIDSSErrorMessage(ErrorHelper.GetMessageString(exc.Message))
                              : new ErrorMessage(StandardError.PostError, exc);

                return false;
            }
            catch (Exception exc)
            {
                m_Error = new ErrorMessage(StandardError.PostError, exc);

                return false;
            }
            return true;
        }

        /// <summary>
        /// ѕолучение типов параметров
        /// </summary>
        public void LoadParameterReferenceTypes()
        {
            m_ParameterTypeTableAdapter.Fill(MainDataSet.ParameterReferenceType, bv.model.Model.Core.ModelUserContext.CurrentLanguage, null,
                                           true);
        }

        /// <summary>
        /// ѕеречень предустановленных значений дл€ типа параметра
        /// </summary>
        /// <param name="idfsParameterType"></param>
        public void LoadParameterFixedPresetValues(long idfsParameterType)
        {
            if (!(
                     (DataHelper.GetParameterFixedPresetValues(this, idfsParameterType) == null)
                     &&
                     (MainDataSet.ParameterFixedPresetValue.Select(
                         DataHelper.Filter("idfsParameterType", idfsParameterType), String.Empty,
                         DataViewRowState.Deleted).Length == 0)
                 ))
                return;
            m_ParameterFixedPresetValueTableAdapter.Fill(MainDataSet.ParameterFixedPresetValue, idfsParameterType,
                                                       bv.model.Model.Core.ModelUserContext.CurrentLanguage);
        }

        /// <summary>
        /// ѕеречень значений дл€ Reference Type
        /// </summary>
        /// <param name="idfsReferenceType"></param>
        public void LoadReferenceTypesList(long idfsReferenceType)
        {
            if (DataHelper.GetReferenceTypesList(this, idfsReferenceType) != null) return;
            m_ReferenceTypesListTableAdapter.Fill(MainDataSet.ReferenceTypesList, bv.model.Model.Core.ModelUserContext.CurrentLanguage,
                                                idfsReferenceType);
        }

        /// <summary>
        /// «агружает перечень доступных Reference Type дл€ указани€ в качестве типов дл€ параметров
        /// </summary>
        /// <returns></returns>
        public FlexibleFormsDS.ReferenceTypesDataTable LoadReferenceTypes()
        {
            m_ReferenceTypesTableAdapter.Fill(MainDataSet.ReferenceTypes, bv.model.Model.Core.ModelUserContext.CurrentLanguage);
            return MainDataSet.ReferenceTypes;
        }
    }
}
