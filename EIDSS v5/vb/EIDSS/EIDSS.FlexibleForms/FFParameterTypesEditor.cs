using System;
using System.Windows.Forms;
using bv.common;
using bv.common.Core;
using bv.common.db;
using bv.common.win;
using bv.winclient.BasePanel;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using EIDSS.FlexibleForms.DataBase;
using EIDSS.FlexibleForms.Helpers;
using bv.winclient.Core;
using eidss.model.Resources;


namespace EIDSS.FlexibleForms
{
    public partial class FFParameterTypesEditor : BaseDetailList
    {
        public FFParameterTypesEditor()
        {
            InitializeComponent();
            IgnoreAudit = true;
            DbService = new DBServiceParameterTypeEditor();
            PermissionObject = eidss.model.Enums.EIDSSPermissionObject.FlexibleForm;
        }

        /// <summary>
        /// Регистрация модуля редактора
        /// </summary>
        /// <param name="parentControl"></param>
        public static void Register(Control parentControl)
        {
            var category = MenuActionManager.Instance.FindAction("MenuConfiguration", MenuActionManager.Instance.System, 960);
            new MenuAction(ShowMe, MenuActionManager.Instance, category, "MenuParameterTypesEditor", 1000, false, (int)eidss.model.Enums.MenuIconsSmall.ParameterTypesEditor)
                                {
                                    SelectPermission = PermissionHelper.SelectPermission(eidss.model.Enums.EIDSSPermissionObject.FlexibleForm),
                                    BeginGroup = true
                                };
        }

        /// <summary>
        /// Запуск редактора
        /// </summary>
        public static void ShowMe()
        {
            BaseFormManager.ShowNormal(new FFParameterTypesEditor(), null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool HasChanges()
        {
            return ((MainDbService.MainDataSet.ParameterReferenceType.GetChanges() != null) ||
                    (MainDbService.MainDataSet.ParameterFixedPresetValue.GetChanges() != null)
                    );
        }

        /// <summary>
        /// Ссылка на главный датасет
        /// </summary>
        private DBServiceParameterTypeEditor MainDbService { get { return (DBServiceParameterTypeEditor)DbService; } }

        /// <summary>
        /// 
        /// </summary>
        protected override void DefineBinding()
        {
            //загружаем перечень доступных типов параметров. элементарные типы не грузим.
            MainDbService.LoadParameterReferenceTypes();
            RefreshParameterTypes();
            //загружаем перечень Reference Type
            leReferenceType.Properties.DataSource = MainDbService.LoadReferenceTypes();
            if (MainDbService.MainDataSet.ReferenceTypes.Count > 0)
            {
                //leReferenceType.EditValue = MainDbService.MainDataSet.ReferenceTypes[0].idfsReferenceType;
            }
            //
            icbParameterTypeSystem.SelectedValueChanged += OnIcbParameterTypeSystemSelectedValueChanged;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnIcbParameterTypeSystemSelectedValueChanged(object sender, EventArgs e)
        {
            var rowParameterType = gvParameterTypes.GetFocusedRow() as FlexibleFormsDS.ParameterReferenceTypeRow;
            if (rowParameterType == null) return;
            //
            if (leReferenceType.EditValue == null) return;
            //
            var imageComboBoxEdit = sender as ImageComboBoxEdit;
            if (imageComboBoxEdit == null) return;
            if (imageComboBoxEdit.EditValue == null) return;
            bool isFixedPresed = imageComboBoxEdit.EditValue.ToString().Equals("0");
            if (!isFixedPresed)
            {
                //если происходит перевод типа параметра из предустановленных значений в референсные, то нужно сначала проверить
                //возможность перехода, а потом удалить все предустановленные значения
                //сначала полная проверка всех
                if (!CheckParameterTypeChildren(rowParameterType.idfsParameterType))
                {
                    imageComboBoxEdit.SelectedIndex = 0; //возвращаем обратно
                    return;
                }
                //теперь удаление всех
                for (var i = MainDbService.MainDataSet.ParameterFixedPresetValue.Count - 1; i >= 0; i--)
                {
                    var row = MainDbService.MainDataSet.ParameterFixedPresetValue[i];
                    if (row.IsRowAlive()) row.Delete();
                }

                //выставляем новый референсный тип
                rowParameterType.idfsReferenceType = (long)leReferenceType.EditValue;
                RefreshReferenceTypesList(rowParameterType.idfsReferenceType);
            }
            else
            {
                rowParameterType.idfsReferenceType = (long)BaseReferenceType.rftParametersFixedPresetValue;
                RefreshFixedPresetValues(rowParameterType.idfsParameterType);
            }
            SetWindowState(isFixedPresed);
        }

        /// <summary>
        /// Проверяет все пресеты для типа параметра
        /// </summary>
        /// <param name="idfsParameterType"></param>
        /// <returns></returns>
        private bool CheckParameterTypeChildren(long idfsParameterType)
        {
            var result = true;
            var fixedPresetValueRows = DataHelper.GetParameterFixedPresetValues(MainDbService, idfsParameterType);
            if (fixedPresetValueRows != null)
            {
                foreach (var row in fixedPresetValueRows)
                {
                    if (!row.IsRowAlive()) continue;
                    //Проверка на возможность удаления
                    if (!CheckRemoveFixedPresetValue(row.idfsParameterFixedPresetValue))
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        private void RefreshParameterTypes()
        {
            gcParameterTypes.DataSource = MainDbService.MainDataSet.ParameterReferenceType.Select();
        }

        /// <summary>
        /// Добавить тип параметра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnAddParameterTypeItemClick(object sender, ItemClickEventArgs e)
        {
            var row = MainDbService.MainDataSet.ParameterReferenceType.NewParameterReferenceTypeRow();
            row.idfsReferenceType = (long)BaseReferenceType.rftParametersFixedPresetValue;
            row.DefaultName = row.NationalName = String.Empty;
            row.langid = bv.model.Model.Core.ModelUserContext.CurrentLanguage;
            row.System = "0";
            MainDbService.MainDataSet.ParameterReferenceType.AddParameterReferenceTypeRow(row);
            //
            RefreshParameterTypes();
            //
            RefreshFixedPresetValues(row.idfsParameterType);
            //
            SetWindowState(true);
        }

        /// <summary>
        /// Удаление Parameter Type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnRemoveParameterTypeItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvParameterTypes.IsEditing) return;
            //выявляем Parameter Type
            var rowParameterType = gvParameterTypes.GetFocusedRow() as FlexibleFormsDS.ParameterReferenceTypeRow;
            if (rowParameterType == null) return;

            if (!CheckRemoveParameterType(rowParameterType.idfsParameterType)) return;

            //удаляем зависимые элементы
            for (var i = MainDbService.MainDataSet.ParameterFixedPresetValue.Count - 1; i >= 0; i-- )
            {
                var row = MainDbService.MainDataSet.ParameterFixedPresetValue[i];
                if (!row.IsRowAlive()) continue;
                if (row.idfsParameterType == rowParameterType.idfsParameterType) row.Delete();
            }

            //удаляем строку
            rowParameterType.Delete();

            RefreshParameterTypes();
        }

        /// <summary>
        /// Добавление пресета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnAddFixedPresetValueItemClick(object sender, ItemClickEventArgs e)
        {
            var rowParameterType = gvParameterTypes.GetFocusedRow() as FlexibleFormsDS.ParameterReferenceTypeRow;
            if (rowParameterType == null) return;

            var row = MainDbService.MainDataSet.ParameterFixedPresetValue.NewParameterFixedPresetValueRow();

            row.DefaultName = row.NationalName = String.Empty;
            row.langid = bv.model.Model.Core.ModelUserContext.CurrentLanguage;
            row.idfsParameterType = rowParameterType.idfsParameterType;
            MainDbService.MainDataSet.ParameterFixedPresetValue.AddParameterFixedPresetValueRow(row);

            RefreshFixedPresetValues(rowParameterType.idfsParameterType);
        }

        /// <summary>
        /// Проверка возможности удаления пресета
        /// </summary>
        /// <param name="idfsParameterFixedPresetValue"></param>
        /// <returns></returns>
        private bool CheckRemoveFixedPresetValue(long idfsParameterFixedPresetValue)
        {
            bool result = true;

            string commandText = String.Format("Select [ErrorMessage] from dbo.fnFFCheckForRemoveParameterFixedPresetValue({0})", idfsParameterFixedPresetValue);
            var cmd = DbService.CreateCommand(commandText);
            ErrorMessage errMsg = null;
            var errorMessage = BaseDbService.ExecScalar(cmd, DbService.Connection, ref errMsg);
            //если ошибка на сервере, то вернем ее текст
            if (errorMessage is string)
            {
                bv.common.win.ErrorForm.ShowMessageDirect(EidssMessages.Get(errorMessage.ToString()));
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Проверка возможности удаления типа параметра
        /// </summary>
        /// <param name="idfsParameterType"></param>
        /// <returns></returns>
        private bool CheckRemoveParameterType(long idfsParameterType)
        {
            //получим из БД перечень всех параметров и отыщем среди них удаляемый
            MainDbService.LoadParameters(null, null);
            bool result = MainDbService.MainDataSet.Parameters.Select(DataHelper.Filter("idfsParameterType", idfsParameterType)).Length == 0;
            if (!result)
            {
                bv.common.win.ErrorForm.ShowMessageDirect(EidssMessages.Get("ParameterTypeRemove_Has_ffParameter"));
            }
            return result;
        }

        /// <summary>
        /// Удаление предустановленного значения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnRemoveFixedPresetValueItemClick(object sender, ItemClickEventArgs e)
        {
            if (gvFixedPresetValues.IsEditing) return;
            //определяем выбранную строку
            var row = gvFixedPresetValues.GetFocusedRow() as FlexibleFormsDS.ParameterFixedPresetValueRow;
            if (row == null) return;

            //Проверка на возможность удаления
            if (!CheckRemoveFixedPresetValue(row.idfsParameterFixedPresetValue)) return;

            //выявляем Parameter Type
            var rowParameterType = gvParameterTypes.GetFocusedRow() as FlexibleFormsDS.ParameterReferenceTypeRow;
            if (rowParameterType == null) return;

            //удаляем строку
            row.Delete();

            RefreshFixedPresetValues(rowParameterType.idfsParameterType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idfsParameterType"></param>
        /// <param name="autoSort"></param>
        private void RefreshFixedPresetValues(long idfsParameterType, bool autoSort = true)
        {
            if (autoSort) RefreshOrders();

            gcFixedPresetValues.DataSource = DataHelper.GetParameterFixedPresetValues(MainDbService, idfsParameterType);
        }

        /// <summary>
        /// 
        /// </summary>
        private void RefreshOrders()
        {
            //проверим, чтобы значения порядка следования были правильные
            //они уже отсортированы в правильном порядке
            for (int i = 0; i < MainDbService.MainDataSet.ParameterFixedPresetValue.Count; i++)
            {
                var row = MainDbService.MainDataSet.ParameterFixedPresetValue[i];
                if (!row.IsRowAlive()) continue;
                if (row.IsintOrderNull()) row.intOrder = i;
                else if (!row.intOrder.Equals(i)) row.intOrder = i;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private FlexibleFormsDS.ParameterFixedPresetValueRow GetSelectedRow()
        {
            return gvFixedPresetValues.GetFocusedRow() as FlexibleFormsDS.ParameterFixedPresetValueRow;
        }

        /// <summary>
        /// Выбор строки в таблице типов параметров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnGvParameterTypesFocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //загружаем перечень предустановленных значений или ссылочный тип
            var row = gvParameterTypes.GetFocusedRow() as FlexibleFormsDS.ParameterReferenceTypeRow;
            if (row == null) return;
            //если предустановленные значения (0)
            bool isFixedPresetValues = row.System.Equals("0");
            //видимость панели ввода reference type
            //pnlReferenceType.Visible = !isFixedPresetValues;
            if (isFixedPresetValues)
            {
                MainDbService.LoadParameterFixedPresetValues(row.idfsParameterType);
                //выбираем те, которые к нему относятся
                RefreshFixedPresetValues(row.idfsParameterType);
            }
            else
            {
                //выставляем reference type
                leReferenceType.EditValue = row.idfsReferenceType;
                //
                //pnlReferenceType.BringToFront();
                //gcFixedPresetValues.BringToFront();
                //заполняем перечнем данных только для чтения
                RefreshReferenceTypesList(row.idfsReferenceType);
            }

            //btnAddFixedPresetValue.Enabled = btnRemoveFixedPresetValue.Enabled = isFixedPresetValues;
            //возможность редактирования списка возможных значений
            //gvFixedPresetValues.OptionsBehavior.Editable = isFixedPresetValues;
            //
            SetWindowState(isFixedPresetValues);
        }

        /// <summary>
        /// Выставляет контролы в нужное состояние, в зависимости от типа параметра
        /// </summary>
        /// <param name="isFixedPresetValues"></param>
        private void SetWindowState(bool isFixedPresetValues)
        {
            btnAddFixedPresetValue.Enabled = btnRemoveFixedPresetValue.Enabled = btnUp.Enabled = btnDown.Enabled = isFixedPresetValues;
            pnlReferenceType.Visible = !isFixedPresetValues;
            if (pnlReferenceType.Visible)
            {
                //
                pnlReferenceType.BringToFront();
                gcFixedPresetValues.BringToFront();
            }
            //возможность редактирования списка возможных значений
            gvFixedPresetValues.OptionsBehavior.Editable = isFixedPresetValues;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idfsReferenceType"></param>
        private void RefreshReferenceTypesList(long idfsReferenceType)
        {
            MainDbService.LoadReferenceTypesList(idfsReferenceType.Equals((long)BaseReferenceType.rftParametersFixedPresetValue) ? -1 : idfsReferenceType);
            gcFixedPresetValues.DataSource = DataHelper.GetReferenceTypesList(MainDbService, idfsReferenceType);
        }

        /// <summary>
        /// Выбор конкретного Reference Type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLeReferenceTypeEditValueChanged(object sender, EventArgs e)
        {
            //определяем выбранную строку
            if (leReferenceType.EditValue == null) return;
            var row = gvParameterTypes.GetFocusedRow() as FlexibleFormsDS.ParameterReferenceTypeRow;
            if (row == null) return;

            //устанавливаем новое значение
            var idfsReferenceTypeNew = (long)leReferenceType.EditValue;
            if (row.idfsReferenceType.Equals(idfsReferenceTypeNew)) return;
            row.idfsReferenceType = (long)leReferenceType.EditValue;
            //обновим перечень отображаемых значений
            RefreshReferenceTypesList(row.idfsReferenceType);
        }

        /// <summary>
        /// Вверх по порядку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnUpItemClick(object sender, ItemClickEventArgs e)
        {
            SetOrder(true);
        }

        /// <summary>
        /// Вниз по порядку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnDownItemClick(object sender, ItemClickEventArgs e)
        {
            SetOrder(false);
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetOrder(bool up)
        {
            int index = gvFixedPresetValues.GetFocusedDataSourceRowIndex();
            if (up && (index == 0)) return;
            if (!up && (index == gvFixedPresetValues.RowCount - 1)) return;
            var row = GetSelectedRow();
            if (row == null) return;
            int newIndex = up ? index - 1 : index + 1;
            var rowSibling = ((FlexibleFormsDS.ParameterFixedPresetValueRow[])gvFixedPresetValues.DataSource)[newIndex]; //MainDbService.MainDataSet.ParameterFixedPresetValue[newIndex];
            int oldOrder = row.intOrder;
            row.intOrder = rowSibling.intOrder;
            rowSibling.intOrder = oldOrder;
            var rowP = gvParameterTypes.GetFocusedRow() as FlexibleFormsDS.ParameterReferenceTypeRow;
            if (rowP == null) return;
            RefreshFixedPresetValues(rowP.idfsParameterType, false);
            gvFixedPresetValues.FocusedRowHandle = gvFixedPresetValues.GetRowHandle(row.intOrder);
        }

    }
}

