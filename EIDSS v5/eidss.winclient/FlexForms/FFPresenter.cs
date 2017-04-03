using System.Windows.Forms;
using DevExpress.XtraEditors;
using eidss.model.Model.FlexibleForms.Helpers;
using eidss.model.Schema;
using eidss.winclient.FlexForms.Controls;
using eidss.winclient.FlexForms.Helpers;
using eidss.winclient.Schema;
using System.Linq;
using Parameter = eidss.winclient.FlexForms.Controls.Parameter;
using System;

namespace eidss.winclient.FlexForms
{
    public partial class FFPresenter : BaseDetailPanel_FFPresenterModel
    {
        /// <summary>
        /// 
        /// </summary>
        public FFPresenter()
        {
            Init();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public FFPresenter(FFPresenterModel model)
        {
            BusinessObject = model;
            Init();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Init()
        {
            InitializeComponent();

            MainDesignerHost = new DesignerHost();
            Controls.Add(MainDesignerHost);
            MainDesignerHost.BringToFront();
            MainDesignerHost.Dock = DockStyle.Fill;
            MainDesignerHost.AutoScroll = true;
            //MainDesignerHost.VerticalScroll.Visible = true;
        }

        private DesignerHost MainDesignerHost { get; set; }

        /// <summary>
        /// Показывает FF из текущего BusinessObject
        /// </summary>
        public void ShowFlexibleForm()
        {
            var ffPresenterModel = BusinessObject as FFPresenterModel;
            if (ffPresenterModel == null) return;
            nowLoading = true;
            if (ffPresenterModel.TemplateFlexNode == null) ffPresenterModel.RebuildTemplateFlexNode();
            using (var ffRender = new FFRender(MainDesignerHost))
            {
                ffRender.RestoreTemplate(ffPresenterModel.TemplateFlexNode);
                //повесим на все параметры события изменения, чтобы сразу переливать данные в таблицу
                SetEventForParameters(ffRender);
                //восстанавливаем данные
                SetValuesToParameters(ffRender, ffPresenterModel);
            }
            nowLoading = false;
        }

        /// <summary>
        /// Задание событий для параметров
        /// </summary>
        private void SetEventForParameters(FFRender ffRender)
        {
            foreach (var parameterControl in ffRender.ParameterList.Values)
            {
                parameterControl.ControlParameter.EditValueChanged += OnParameterEditValueChanged;
            }
            /*
            //foreach (SectionTable sectionTable in flexibleFormEditor.SectionTableList.Values)
            foreach (var sectionTable in ffRender.SectionTableList.Values)
            {
                //чтобы не было множественного вызова, если есть несколько вложенных табличных секций
                //TODO проверить это
                sectionTable.RootSection.GridViewMain.CellValueChanged -= OnSectionTableCellValueChanged;
                sectionTable.RootSection.GridViewMain.CellValueChanged += OnSectionTableCellValueChanged;
            }
            */
        }

        /// <summary>
        /// Показывает, что в данный момент происходит загрузка компонента или какие-либо служебные действия
        /// </summary>
        private bool nowLoading { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnParameterEditValueChanged(object sender, EventArgs e)
        {
            //if (nowLoading || Closing || !ObservationID.HasValue || !TemplateID.HasValue) return;
            if (nowLoading) return;
            var be = sender as BaseEdit;
            if (be == null) return;
            var control = (Parameter)be.Tag;
            var parameterTemplate = control.Tag as ParameterTemplate;
            if (parameterTemplate == null) return;
            var ffPresenterModel = BusinessObject as FFPresenterModel;
            if (ffPresenterModel == null) return;
            if (ffPresenterModel.CurrentTemplate == null) return;
            if (!ffPresenterModel.CurrentObservation.HasValue) return;
            ffPresenterModel.ActivityParameters.SetActivityParameterValue(ffPresenterModel.CurrentTemplate
                , ffPresenterModel.CurrentObservation.Value
                , parameterTemplate.idfsParameter, be.EditValue, be.Text);
        }

        /// <summary>
        /// Помещает значения в управляющие контролы параметров
        /// </summary>
        ///// <param name="predefinedStubRows">Содержимое боковика, если таковой есть, или null, если его нет</param>
        private void SetValuesToParameters(FFRender ffRender, FFPresenterModel ffPresenterModel/*IEnumerable<FlexibleFormsDS.PredefinedStubRow> predefinedStubRows*/)
        {
            if (ffPresenterModel.ActivityParameters.Count == 0) return;
            if (!ffPresenterModel.CurrentObservation.HasValue) return;

            var idObservation = ffPresenterModel.CurrentObservation.Value;
            var userData = ffPresenterModel.ActivityParameters.Where(c => c.idfObservation == idObservation);
            foreach (var activityParameter in userData)
            {
                if (!activityParameter.intNumRow.HasValue) continue;
                if (!activityParameter.idfsParameter.HasValue) continue;
                /*
                //если боковик задан, то не выводим те строки, которых нет в боковике
                if (predefinedStubRows != null)
                {
                    bool finded = false;
                    foreach (var stubRow in predefinedStubRows)
                    {
                        if (row.idfRow.Equals(stubRow.idfRow))
                        {
                            finded = true;
                            break;
                        }
                    }
                    if (!finded) continue;
                }
                */

                //пробуем найти такой параметр
                if (!ffRender.ParameterList.ContainsKey(activityParameter.idfsParameter.Value)) continue;
                var parameter = ffRender.ParameterList[activityParameter.idfsParameter.Value];
                //помещаем туда значение
                //если параметр относится к обычной секции или просто расположен в теле шаблона, то просто присвоим ему значение
                SetValueToEditor(parameter, activityParameter);
            }


        }

        /// <summary>
        /// Выставляет значение контролу параметра
        /// </summary>
        /// <param name="parameterControl"></param>
        /// <param name="activityParameter"></param>
        private void SetValueToEditor(Parameter parameterControl, ActivityParameter activityParameter)
        {
            var parameterTemplate = parameterControl.Tag as ParameterTemplate;
            if (parameterTemplate == null) return;

            //помещаем туда значение
            //если параметр числовой, то переведём его значение к национальной культуре
            var value = activityParameter.varValue;
            //если параметр числовой, то нужно привести его к национальной культуре
            if (parameterTemplate.IsParameterNumeric())
            {
                decimal decValue;
                if (Decimal.TryParse(value.ToString(), out decValue)) value = decValue;
            }

            //если параметр относится к обычной секции или просто расположен в теле шаблона, то просто присвоим ему значение
            if (parameterControl.RootSection == null)
            {
                parameterControl.ControlParameter.EditValue = value;
            }
            else
            {
                //TODO реализовать простановку табличных значений
                //получаем номер строки по id
                //var column = parameterControl.RootSection.FindParameter(parameterControl.ParameterTemplateRow);
                //parameterControl.RootSection.SetTableValue(rowData.intNumRow, column, value);
            }
        }
        protected override bool IsReadOnlyField(string fieldName)
        {
            return ReadOnly;
        }

    }
}
