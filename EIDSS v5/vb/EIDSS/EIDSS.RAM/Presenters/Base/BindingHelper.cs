using System;
using System.Data;
using System.Windows.Forms;
using bv.common.Core;
using bv.common.db;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using EIDSS.Core;
using bv.common.db.Core;

namespace EIDSS.RAM.Presenters.Base
{
    public static class BindingHelper
    {
        private const int MaxEditorLength = 2000;

        internal static void BindCheckEdit
            (CheckEdit checkEdit, DataSet baseDataSet, string tableName, string columnName)
        {
            BindEditor(checkEdit, baseDataSet, tableName, columnName);
            checkEdit.Properties.ValueChecked = true;
            checkEdit.Properties.ValueUnchecked = false;
            checkEdit.Properties.ValueGrayed = DBNull.Value;
            //checkEdit.Checked = GetBlnValue(baseDataSet, tableName, columnName);
        }

        internal static void BindEditor(Control editor, DataSet baseDataSet, string tableName, string columnName)
        {
            Utils.CheckNotNullOrEmpty(tableName, "tableName");
            Utils.CheckNotNullOrEmpty(columnName, "columnName");

            string fieldName = string.Format("{0}.{1}", tableName, columnName);
            editor.DataBindings.Clear();
            editor.DataBindings.Add("EditValue", baseDataSet, fieldName);

            if (editor is TextEdit)
            {
                ((TextEdit) editor).Properties.NullText = string.Empty;
                ((TextEdit) editor).Properties.MaxLength = MaxEditorLength;
            }
        }

        internal static void BindCombobox
            (LookUpEdit comboBox, DataSet baseDataSet, string tableName, string columnName,
             BaseReferenceType baseLookupTables, long defaultValue)
        {
            comboBox.DataBindings.Clear();
            string fieldName = string.Format("{0}.{1}", tableName, columnName);
            LookupBinder.BindBaseLookup(comboBox, baseDataSet, fieldName,
                                        baseLookupTables, false);

            long value = GetIdfsValue(baseDataSet, tableName, columnName, defaultValue);
            baseDataSet.Tables[tableName].Rows[0][columnName] = value;

            HideDeleteButton(comboBox);

            var dataSource = (DataView)comboBox.Properties.DataSource;
            string emptyLineFilter = string.Format("idfsReference <> {0}", LookupCache.EmptyLineKey);
            dataSource.RowFilter = Utils.IsEmpty(dataSource.RowFilter)
                                       ? emptyLineFilter
                                       : string.Format("({0}) AND {1}", dataSource.RowFilter, emptyLineFilter);



        }

        /// <summary>
        /// Returns boolean value from first row of the table with given name of given dataset
        /// Returns false if dataset doesn't contain table with given name, or table is empty.
        /// </summary>
        /// <param name="baseDataSet"></param>
        /// <param name="tableName"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        internal static bool GetBlnValue(DataSet baseDataSet, string tableName, string columnName)
        {
            object value;
            if (TryGetValue(baseDataSet, tableName, columnName, out value))
            {
                return (value == null) || (value is DBNull) || (string.IsNullOrEmpty(value.ToString()))
                           ? false
                           : (bool) value;
            }
            return false;
        }

        /// <summary>
        /// Returns key from first row of the table with given name of given dataset
        /// Table shoud be child of basereference and should have "strBaseReferenceCode" key column
        /// Returns defaultValue if dataset doesn't contain table with given name, or table is empty.
        /// </summary>
        /// <param name="baseDataSet"></param>
        /// <param name="tableName"></param>
        /// <param name="columnName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        internal static long GetIdfsValue(DataSet baseDataSet, string tableName, string columnName, long defaultValue)
        {
            object value;
            if (TryGetValue(baseDataSet, tableName, columnName, out value))
            {
                return (value == null) || (value is DBNull) || (string.IsNullOrEmpty(value.ToString()))
                           ? defaultValue
                           : (long) value;
            }
            return defaultValue;
        }

        /// <summary>
        /// Hides delete button in Combobox
        /// </summary>
        /// <param name="Combobox"></param>
        internal static void HideDeleteButton(LookUpEdit Combobox)
        {
            int index = -1;
            foreach (EditorButton btn in Combobox.Properties.Buttons)
            {
                if (btn.Kind == ButtonPredefines.Delete)
                {
                    btn.Visible = false;
                    index = btn.Index;
                }
            }
            if (index != -1)
            {
                Combobox.Properties.Buttons.RemoveAt(index);
            }
        }

        private static bool TryGetValue(DataSet baseDataSet, string tableName, string columnName, out object value)
        {
            Utils.CheckNotNullOrEmpty(tableName, "tableName");
            Utils.CheckNotNullOrEmpty(columnName, "columnName");

            value = null;

            if (baseDataSet.Tables.Contains(tableName))
            {
                if (!baseDataSet.Tables[tableName].Columns.Contains(columnName))
                {
                    throw new RamDbException(string.Format("Column {0} not foumd in table {1} in basedataset",
                                                           columnName, tableName));
                }

                DataRowCollection rows = baseDataSet.Tables[tableName].Rows;
                if ((rows.Count > 0) && (!Utils.IsEmpty(rows[0][columnName])))
                {
                    value = rows[0][columnName];
                    return true;
                }
            }
            return false;
        }
    }
}