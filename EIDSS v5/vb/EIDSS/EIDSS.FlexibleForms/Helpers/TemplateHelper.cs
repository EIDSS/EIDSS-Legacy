using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using bv.common.Core;
using EIDSS.FlexibleForms.DataBase;
using EIDSS.FlexibleForms.Helpers.ReportHelper.DataItems;
using EIDSS.FlexibleForms.Helpers.ReportHelper.Tree;
using eidss.model.Core;
using eidss.model.Resources;

namespace EIDSS.FlexibleForms.Helpers
{
    public class TemplateHelper
    {
        private DbServiceUserData mainDbService { get; set; }
        private FlexibleFormsDS.TemplatesRow actualTemplate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TemplateHelper()
        {
            mainDbService = new DbServiceUserData();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbService"></param>
        internal TemplateHelper(DbServiceUserData dbService)
        {
            mainDbService = dbService;
        }

        /// <summary>
        /// ID ��������� �������
        /// </summary>
        public long? IdfsFormTemplate { get; private set; }

        /// <summary>
        /// �������� �� �������� ������ UNI-��������
        /// </summary>
        public bool? IsUNITemplate { get; private set; }

        /// <summary>
        /// ID ���������� Observation, ������� �������� ������������� ������
        /// </summary>
        public long IdfObservationSummary
        {
            get { return mainDbService.IdfObservationSummary; }
        }

        /// <summary>
        /// ID ���������� Form Template, ������� �������� ������ (merged) ��������� �� ���� Observation, ������� ������ � ������� �����
        /// </summary>
        public long IdfsFormTemplateSummary
        {
            get { return mainDbService.IdfsFormTemplateSummary; }
        }

        /// <summary>
        /// idfVersion �������, ������� ������������ � ������ ������. ����������� ������ ��� Aggregate Case.
        /// </summary>
        public long? VersionMatrixStub { get; private set; }

        /// <summary>
        /// ������, �������� � �������� ������
        /// </summary>
        public FlexibleFormsDS.SectionTemplateDataTable SectionTemplate
        {
            get { return mainDbService.MainDataSet.SectionTemplate; }
        }

        /// <summary>
        /// ���������, �������� � �������� ������
        /// </summary>
        public FlexibleFormsDS.ParameterTemplateDataTable ParameterTemplate
        {
            get { return mainDbService.MainDataSet.ParameterTemplate; }
        }

        /// <summary>
        /// ������, �������� � �������� ������
        /// </summary>
        public FlexibleFormsDS.ActivityParametersDataTable ActivityParameters
        {
            get { return mainDbService.MainDataSet.ActivityParameters; }
        }

        /// <summary>
        /// ������ ���������� �� �������� �������
        /// </summary>
        public FlexibleFormsDS.TemplatesRow ActualTemplate
        {
            get { return actualTemplate; }
        }

        /// <summary>
        /// ������������ ������� �������� � ���������, ������� ��������� � ��������� observation
        /// </summary>
        /// <param name="observations"></param>
        /// <param name="formType"></param>
        /// <param name="idfsFormTemplateMerged">ID �������, � ������� ����� ��������� ���������� ������</param>
        private void MergeTemplates(long idfsFormTemplateMerged, IEnumerable<long> observations, FFType formType)
        {
            var idfsFormType = (long)formType;

            //���� �� ������� ���� �����, � �������� ��������� ������, �� ��������� ����-������ �� �������, �� ���������� ��
            //(�������� ��� ������)
            mainDbService.LoadSections(idfsFormType, null, null);
            mainDbService.LoadParameters(idfsFormType, null);

            //������� observation ����� ��������������� ���� ������, ������ ���� ��������� �� ���
            var observationsRows = mainDbService.LoadObservations(observations);
            if (observationsRows.Length == 0) return;

            #region �������� ������ �� ���� �������

            //����� ������� ����, ������ ��� ������� ��������� ������� ������ ��������� ������ � �������
            foreach (var observationsRow in observationsRows)
            {
                if (observationsRow.IsidfsFormTemplateNull()) continue;
                //��������� ������ �� ������� ������� (���� ��� �� ��� ��� �� ���������)
                mainDbService.LoadSectionTemplate(observationsRow.idfsFormTemplate);
                mainDbService.LoadParameterTemplate(observationsRow.idfsFormTemplate);
            }

            #endregion

            //������� ������ �����, ������ ��� ������� ������� �������� �������� �������� � � ���� �������

            #region ������� ��������� �� ����� �������

            //������� ������ ����������� �������
            mainDbService.DeleteSummaryTemplate();

            //�������� ������ � �������-������
            foreach (var observationsRow in observationsRows)
            {
                if (observationsRow.IsidfsFormTemplateNull()) continue;

                //����� ������ � �������
                CopyHelper.CopySectionTemplate(mainDbService, observationsRow.idfsFormTemplate, idfsFormTemplateMerged, bv.model.Model.Core.ModelUserContext.CurrentLanguage);

                //����� ���������� � �������
                CopyHelper.CopyParameterTemplate(mainDbService, observationsRow.idfsFormTemplate, idfsFormTemplateMerged, bv.model.Model.Core.ModelUserContext.CurrentLanguage);
            }

            #endregion

            #region ������� ��������� �� ��������

            var listStubInfo = mainDbService.GetListSectionsAndVersionsForStub(observationsRows, formType);
            //�������� ���������� � ������ ������� ��������
            //��������� ������ �� �������� � ����� ��������� �� � ������
            mainDbService.IncludeStub(idfsFormTemplateMerged, listStubInfo);

            #endregion
        }

        /// <summary>
        /// ���������� ���������� ������
        /// </summary>
        /// <param name="formType"></param>
        private void SetActualTemplate(long formType)
        {
            //������� ���������� �� ����� �������
            mainDbService.LoadTemplates(formType);
            var templatesRows = (FlexibleFormsDS.TemplatesRow[])mainDbService.MainDataSet.Templates.Select(DataHelper.Filter("idfsFormTemplate", IdfsFormTemplate));
            if (templatesRows.Length == 1)
            {
                actualTemplate = templatesRows[0];
                IsUNITemplate = actualTemplate.blnUNI;
            }
        }

        /// <summary>
        /// ��������� ����������� �������, �������������� �� ���������
        /// </summary>
        public List<DataRow> GetReportView()
        {
            return IdfsFormTemplate.HasValue ? GetReportView(mainDbService, IdfsFormTemplate.Value) : new List<DataRow>();
        }

        /// <summary>
        /// ��������� ����������� �������, �������������� �� ���������
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="templateID"></param>
        /// <returns></returns>
        public static List<DataRow> GetReportView(DbService mainDbService, long templateID)
        {
            var result = new List<DataRow>();

            string filter = DataHelper.Filter("idfsFormTemplate", templateID);

            //��������� �������� ���� TopAbsolute � ���� ������, ����������, ������� � �����
            CalculateTopAbsolute(mainDbService, mainDbService.MainDataSet.SectionTemplate.Select(filter), "idfsParentSection", result);
            CalculateTopAbsolute(mainDbService, mainDbService.MainDataSet.ParameterTemplate.Select(filter), "idfsSection", result);
            CalculateTopAbsolute(mainDbService, mainDbService.MainDataSet.Labels.Select(filter), "idfsSection", result);
            CalculateTopAbsolute(mainDbService, mainDbService.MainDataSet.Lines.Select(filter), "idfsSection", result);

            //��������� �� ����������� ���� TopAbsolute
            result.Sort(CompareParameterHostDataRows);

            return result;
        }

        /// <summary>
        /// ��������� �������� 
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="rows"></param>
        /// <param name="parentSectionColumnName"></param>
        /// <param name="resultList"></param>
        private static void CalculateTopAbsolute(DbService mainDbService, IEnumerable<DataRow> rows, string parentSectionColumnName, List<DataRow> resultList)
        {
            foreach (var row in rows)
            {
                int intTop = Convert.ToInt32(row["intTop"]);
                int intAdditionalTop = 0;
                if (!Utils.IsEmpty(row[parentSectionColumnName]))
                {
                    long idfsSection = Convert.ToInt64(row[parentSectionColumnName]);
                    long idfsformTemplate = Convert.ToInt64(row["idfsFormTemplate"]);
                    intAdditionalTop = GetTopParentSection(mainDbService, idfsSection, idfsformTemplate);
                }
                row[TopAbsoluteColumnName] = intTop + intAdditionalTop;
                resultList.Add(row);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row1"></param>
        /// <param name="row2"></param>
        /// <returns></returns>
        private static int CompareParameterHostDataRows(DataRow row1, DataRow row2)
        {
            return (Convert.ToInt32(row1[TopAbsoluteColumnName]) - Convert.ToInt32(row2[TopAbsoluteColumnName]));
        }

        private const string TopAbsoluteColumnName = "TopAbsolute";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mainDbService"></param>
        /// <param name="idfsSection"></param>
        /// <param name="idfsformTemplate"></param>
        /// <returns></returns>
        private static int GetTopParentSection(DbService mainDbService, long idfsSection, long idfsformTemplate)
        {
            int result = 0;
            var sectionTemplateRow = mainDbService.GetSectionTemplateRow(idfsSection, idfsformTemplate);
            if (sectionTemplateRow != null)
            {
                result = sectionTemplateRow.intTop;
                if (!sectionTemplateRow.IsidfsParentSectionNull())
                {
                    result += GetTopParentSection(mainDbService, sectionTemplateRow.idfsParentSection, sectionTemplateRow.idfsFormTemplate);
                }
            }
            return result;
        }

        /// <summary>
        /// ������������ ������� ������, �������� ��������� ������ ������������������ ����������, �� ������� ������
        /// </summary>
        /// <param name="observations">��������� ID ��������� (observation)</param>
        /// <param name="formType">ID ���� �����</param>
        public void LoadSummary(List<long> observations, FFType formType)
        {
            if (observations == null) return;

            IdfsFormTemplate = IdfsFormTemplateSummary;
            //�������� ��� ��������, ������ ��� � ������� ��������� ��������� Observation � � ������� ����� ���� ���� ������ �������� � �������
            VersionMatrixStub = null;

            var idfsFormType = (long) formType;

            //������� ���������� �� ����� �������
            SetActualTemplate(idfsFormType);

            //��������� ���������
            MergeTemplates(mainDbService.IdfsFormTemplateSummary, observations, formType);
            var observationsRows = mainDbService.LoadObservations(observations);
            
            //��������� ������
            //�������� ���������������� ������
            foreach (var observationsRow in observationsRows)
            {
                if (observationsRow.IsidfsFormTemplateNull()) continue;
                mainDbService.LoadUserData(observationsRow.idfObservation, observationsRow.idfsFormTemplate, true);
            }

            //���� ���������� ����� ������ � �������� � � ��������� ObservationSummary, � ����� ���������� ���
            //����������� ����� ������ �� ���������, � ������� ��� Numeric. ��������� ������������ (������, 11.01.2010).
            //����������� ������ ���� �������, ������� �� �����������
            //� ���������� ������������� ������ �� �����������

            //������ summary
            var lst = new List<long>();
            lst.AddRange(observations);
            mainDbService.CalculateSummary(lst);
            FlexibleFormsDS.PredefinedStubRow[] predefinedStubRows;

            mainDbService.IncludeStubDataInUserData(IdfsFormTemplate, IdfObservationSummary, null, out predefinedStubRows);

            //��������� ��������� �������
            mainDbService.LoadSections(idfsFormType, null, null);
            mainDbService.LoadParameters(idfsFormType, null);
            mainDbService.LoadSectionTemplate(IdfsFormTemplate);
            mainDbService.LoadParameterTemplate(IdfsFormTemplate);
        }

        /// <summary>
        /// ��������� �������������� �������
        /// </summary>
        /// <param name="idFormTemplate"></param>
        /// <param name="presetStub"></param>
        /// <param name="observation"></param>
        /// <param name="formType"></param>
        public void LoadAggregateTemplate(long idFormTemplate, AggregateCaseSection presetStub, long observation, FFType formType)
        {
            LoadTemplate(formType, idFormTemplate, new List<long> {observation}, new[] {presetStub});
        }

        /// <summary>
        /// ��������� �������������� �������
        /// </summary>
        /// <param name="presetStub">�������� ������� [��������� ������ - �������] ��� �������� ���������� ������ � ��������� ������</param>
        /// <param name="observation"></param>
        /// <param name="formType"></param>
        public void LoadAggregateTemplate(AggregateCaseSection presetStub, long observation, FFType formType)
        {
            LoadTemplate(formType, EidssSiteContext.Instance.CountryID, null, new List<long> { observation }, new[] { presetStub });
        }

        /// <summary>
        /// ��������� �������������� �������
        /// </summary>
        /// <param name="observations"></param>
        /// <param name="formType"></param>
        /// <param name="secondDeterminant">������� ��� ��� �����</param>
        public void LoadTemplate(List<long> observations, long? secondDeterminant, FFType formType)
        {
            LoadTemplate(formType, EidssSiteContext.Instance.CountryID, secondDeterminant, observations, null);
        }

        /// <summary>
        /// ��������� �������������� �������
        /// </summary>
        /// <param name="formType">��� �����</param>
        /// <param name="countryDeterminant">�����������-������</param>
        /// <param name="secondDeterminant">����������� ������� ��� ����</param>
        /// <param name="observationList">�������� observation</param>
        /// <param name="presetStubs">�������</param>
        private void LoadTemplate(FFType formType, long countryDeterminant, long? secondDeterminant, List<long> observationList,IEnumerable<AggregateCaseSection> presetStubs)
        {
            IdfsFormTemplate = null;
            if (observationList.Count > 1)
            {
                mainDbService.LoadActualTemplate(countryDeterminant, secondDeterminant, (long) formType);

                //���� ��� �� ����� ������, �� �������� ������� �� ������� ����� (�� ��������, �� UNI)
                if (mainDbService.MainDataSet.ActualTemplate.Rows.Count == 0) return;
                var actualTemplateRow =
                    (FlexibleFormsDS.ActualTemplateRow) mainDbService.MainDataSet.ActualTemplate.Rows[0];
                IdfsFormTemplate = actualTemplateRow.idfsFormTemplate != -1
                                       ? (long?) actualTemplateRow.idfsFormTemplate
                                       : null;
            }
            else
            {
                var observationsRows = mainDbService.LoadObservations(observationList);
                if (observationsRows.Length > 0)
                {
                    if (!observationsRows[0].IsidfsFormTemplateNull())
                        IdfsFormTemplate = observationsRows[0].idfsFormTemplate;
                }
            }

            if ((IdfsFormTemplate == null) || Utils.IsEmpty(IdfsFormTemplate)) return;

            LoadTemplate(formType, IdfsFormTemplate.Value, observationList, presetStubs);
        }

        /// <summary>
        /// ��������� �������������� �������
        /// </summary>
        /// <param name="formType">��� �����</param>
        /// <param name="idFormTemplate">������, ������� ��������� ���������</param>
        /// <param name="observationList">�������� observation</param>
        /// <param name="presetStubs">�������</param>
        internal void LoadTemplate(FFType formType, long idFormTemplate, List<long> observationList,IEnumerable<AggregateCaseSection> presetStubs)
        {
            if (observationList == null) return;

            IdfsFormTemplate = idFormTemplate;

            //������� ���������� �� ����� �������
            var idfsFormType = (long) formType;
            SetActualTemplate(idfsFormType);

            //��������� ��������� �������
            mainDbService.LoadSections(idfsFormType, null, null);
            mainDbService.LoadParameters(idfsFormType, null);
            mainDbService.LoadSectionTemplate(IdfsFormTemplate);
            mainDbService.LoadParameterTemplate(IdfsFormTemplate);

            mainDbService.LoadLines(IdfsFormTemplate);
            mainDbService.LoadLabels(IdfsFormTemplate.Value);

            //���� ���� ����������������� �������, �� ���������� ���
            if (presetStubs != null)
            {
                //������ �������� �� ���������, ����� ���� ����� ��������
                mainDbService.IncludeStub(IdfsFormTemplate.Value, mainDbService.GetListSectionsAndVersionsForStub(observationList, formType));
            }

            //��� ���� �������� observation �������� ���������������� ������
            foreach (var idfObservation in observationList)
            {
                mainDbService.LoadUserData(idfObservation, IdfsFormTemplate.Value, true);
                //���� ���� ����������������� �������, �� �������� ���������������� ������ ��� �������
                if (presetStubs == null) continue;
                
                //�������� ���������� � ������ ������� ��������
                var matrixVersionRow = mainDbService.LoadMatrixStubInfo(idfObservation);
                //���� �� ������� ����� ������� (��������, ��� ��� �� ��������), �� ���� � ������ Observation
                if (matrixVersionRow == null) continue;
                if (matrixVersionRow.IsidfVersionNull()) continue;

                //������ �� �������� ��� ������ ���� ���������, ��������� �� ��� �� ����������������
                var predefinedStubRows = mainDbService.GetPredefinedStubRows(matrixVersionRow.idfVersion);
                foreach (var predefinedStubRow in predefinedStubRows)
                {
                    mainDbService.MainDataSet.ActivityParameters.RenumActivityParameters(predefinedStubRow, idfObservation);
                    mainDbService.ChangeValue(idfObservation, IdfsFormTemplate.Value, predefinedStubRow.idfsParameter, predefinedStubRow.idfRow, predefinedStubRow.NumRow, predefinedStubRow.idfsParameterValue, predefinedStubRow.strNameValue);
                }
            }
        }

        /// <summary>
        /// ��������� ��������� ������� ���������� (������ ��� ������ ���� ��������)
        /// </summary>
        /// <param name="idfObservation"></param>
        /// <returns></returns>
        public FlexNode GetFlexNodeFromTemplate(long idfObservation)
        {
            var rootNode = FlexNode.CreateRoot();
            //�������� ������, ��������� � Observation
            var observationsRow = mainDbService.LoadObservations(idfObservation);
            if ((observationsRow != null) && (!observationsRow.IsidfsFormTemplateNull()))
            {
                //�������� � ����� ������� � ������
                FillFlexNodeForSection(rootNode, null, observationsRow.idfObservation, observationsRow.idfsFormTemplate);
                
                //������� ������ � ������������� �����������
                var parametersTable = mainDbService.LoadParameterDeletedFromTemplate(idfObservation, null, null);
                if (parametersTable.Count > 0)
                {
                    //������� ����������-��������� ��� ������������ ����������
                    var dynamicGroup = rootNode.Add(EidssMessages.Get("DynamicParametersGroupControlCaption"));
                    int heightTotal = 0;
                    int widthTotal = 0;
                    foreach (var rowParameter in parametersTable)
                    {
                        Size size;
                        //������� �������� ��� ����� ���������, ��������� ��� ��������
                        dynamicGroup.Add(rowParameter, mainDbService.GetActivityParametersRow(idfObservation, rowParameter.idfsParameter, null), out size);
                        heightTotal += size.Height;
                        if (widthTotal < size.Width) widthTotal = size.Width;
                    }
                    //��������� ��� ���������� ������� � �������
                    if (heightTotal * widthTotal > 0)
                    {
                        //dynamicGroup.DataItem.Width = widthTotal + 30;
                        dynamicGroup.DataItem.Width = widthTotal;
                        dynamicGroup.DataItem.Height = heightTotal + 30;

                        //������������ ������������ ���� � ����������, ����� �� ������� �� ������� �����
                        if (rootNode.Count > 1)
                        {
                            var staticItemWidth = rootNode[0].DataItem.Width;
                            if (dynamicGroup.DataItem.Width > staticItemWidth)
                                dynamicGroup.DataItem.Width = staticItemWidth;
                            //���������� ������������ � ������������ ���������
                            foreach (var rootNodes in rootNode.ChildList)
                            {
                                if (rootNodes.ChildListCount == 0) continue;
                                foreach (var item in rootNodes.ChildList)
                                {
                                    var paramWidth = item.DataItem.Width;
                                    foreach (var child in dynamicGroup.ChildList)
                                    {
                                        if (child.DataItem.Width > paramWidth) child.DataItem.Width = paramWidth;
                                    }
                                    break;
                                }
                                break;
                            }
                        }
                    }
                }
                //��� ������ ��������� ������ �������� ������, �������� � ������, �������� ������� � �������
                AddDataTable(rootNode, idfObservation);
            }
            return rootNode;
        }

        /// <summary>
        /// ���������� ������ � Summary � ����������� ����� (������ ��� ������ ���� ��������)
        /// </summary>
        /// <returns></returns>
        public FlexNode GetFlexNodeFromTemplateSummary()
        {
            var rootNode = FlexNode.CreateRoot();
            FillFlexNodeForSection(rootNode, null, IdfObservationSummary, IdfsFormTemplateSummary); //�������� � ����� ������� � ������
            //��� ������ ��������� ������ �������� ������, �������� � ������, �������� ������� � �������
            AddDataTable(rootNode, IdfObservationSummary);

            return rootNode;
        }

        /// <summary>
        /// �������� ���������� ��� ����������� ���������, ������� ��� ������������� �� ������� ����������
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="parameters"></param>
        private void CollectParametersUnderSection(FlexNode parentNode, List<FlexibleFormsDS.ParameterTemplateRow> parameters)
        {
            var parameterTemplateRow = parentNode.DataItem.LinkedObject as FlexibleFormsDS.ParameterTemplateRow;
            if (parameterTemplateRow != null)
            {
                parameters.Add(parameterTemplateRow);
            }
            //���������� �� ���� ��������
            foreach (var childNode in parentNode.ChildList)
            {
                CollectParametersUnderSection(childNode, parameters);
            }
        }

        /// <summary>
        /// �������� ������� ��� ������� � TemplateHelper
        /// </summary>
        /// <param name="idfObservation"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private DataTable GetDataTableForTemplate(long idfObservation, List<FlexibleFormsDS.ParameterTemplateRow> parameters)
        {
            //������ ������ ���� ��������, ������ ��������
            //��������� �������������� ������� �������� ��� ��������� ��� ���������� �������.
            //�������� ������� �������� ��� ��������� idfRow ��� ������� Observation
            //������ ������ ����������� DBNull.Value
            var resultTable = new DataTable();
            var rows = mainDbService.GetActivityParametersRows(idfObservation);
            if ((parameters.Count > 0) && (rows.Length > 0))
            {
                foreach (var parameterRow in parameters)
                {
                    if (!parameterRow.IsRowAlive()) continue;
                    var column = new DataColumn(parameterRow.idfsParameter.ToString(), typeof(string))
                                     {
                                         Caption = parameterRow.NationalName,
                                         AllowDBNull = true,
                                         DefaultValue = DBNull.Value
                                     };
                    resultTable.Columns.Add(column);
                }

                foreach (var activityParametersRow in rows)
                {
                    if (!activityParametersRow.IsRowAlive()) continue;
                    //���� �� ������� ������ � ������� ������, �� ������ �����-�� �������� ��� ��������� � ��������, � ���������� ��� ������
                    if (activityParametersRow.IsintNumRowNull()) continue;
                    //��������� ������� �����, ����� ������� ��� ���������� ����������� ������
                    int cnt = activityParametersRow.intNumRow + 1;
                    if (cnt > resultTable.Rows.Count)
                    {
                        for (int i = resultTable.Rows.Count; i < cnt; i++)
                        {
                            resultTable.Rows.Add(resultTable.NewRow());
                        }
                    }

                    var row = resultTable.Rows[activityParametersRow.intNumRow];

                    foreach (var parameterRow in parameters)
                    {
                        if (!parameterRow.IsRowAlive()) continue;
                        var rowValue = mainDbService.GetActivityParametersRow(idfObservation, parameterRow.idfsParameter, activityParametersRow.idfRow);
                        if (!Utils.IsEmpty(rowValue))
                        {
                            //��������� ���� � ���������� ������
                            if (rowValue.varValue is DateTime)
                            {
                                var destFormat = (CultureInfo.CurrentCulture).DateTimeFormat.ShortDatePattern;
                                rowValue.strNameValue = ((DateTime)rowValue.varValue).ToString(destFormat, CultureInfo.InvariantCulture);
                            }
                            row[parameterRow.idfsParameter.ToString()] = rowValue.strNameValue.Length > 0 ? rowValue.strNameValue : rowValue.varValue;
                        }
                    }
                }
            }


            return resultTable;
        }

        /// <summary>
        /// ������ ���������� ������ �������, ������ �� �����, �������� � ���� ��������
        /// </summary>
        /// <param name="parentNode"></param>
        /// <returns></returns>
        private int CalculateWidthTotal(FlexNode parentNode)
        {
            var result = 0;
            if (parentNode.ChildListCount > 0)
            {
                result += parentNode.ChildList.Sum(node => CalculateWidthTotal(node));
                parentNode.DataItem.Width = result;
            }
            else
            {
                result = parentNode.DataItem.Width;
            }
            
            return result;
        }

        /// <summary>
        /// �������� ���������� �� ���� ����� ������, ���������� ��������� ������ �������� ������, ���������� � ��� ������ �� ����������� ����������
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="idfObservation"></param>
        private void AddDataTable(FlexNode parentNode, long idfObservation)
        {
            //���� ���� ������� ��������� ������ � ��� �������� ������ (�.�. ��� ��� ��� ������ ��������� ������), ��
            //������ ��� ����� ����� ���������������� ������
            var flexTableItem = parentNode.DataItem as FlexTableItem;
            if ((flexTableItem != null) && (!(parentNode.ParentNode.DataItem is FlexTableItem)))
            {
                //�������� ���������� ��� ����������� ���������, ������� ��� ������������� �� ������� ����������
                var parameters = new List<FlexibleFormsDS.ParameterTemplateRow>();
                CollectParametersUnderSection(parentNode, parameters);
                flexTableItem.BodyData = GetDataTableForTemplate(idfObservation, parameters);
                //��������� ���������� ������ ���� ������ ��� ������������ ����� �������� � �� ��������
                flexTableItem.Width = CalculateWidthTotal(parentNode);
            }
            //���������� �� ���� ��������
            foreach (var childNode in parentNode.ChildList)
            {
                AddDataTable(childNode, idfObservation);
            }
        }

        /// <summary>
        /// ������ ���� � ���, ��� ����� � ������ � ���������� �� ���� ������� ������ ��. ���� ������ �� �������, �� �������� ��, ��� ����� � ����� �������.
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="idfsParentSection"></param>
        /// <param name="idfObservation"></param>
        /// <param name="idfsFormTemplate"></param>
        /// <returns></returns>
        private void  FillFlexNodeForSection(FlexNode parentNode
                                            , long? idfsParentSection
                                            , long idfObservation
                                            , long idfsFormTemplate
                                            )
        {
            //���������� �������, ������� ������ � ������������ ������
            var sectionTemplateRows = mainDbService.GetSectionTemplateChildrenRows(idfsParentSection, idfsFormTemplate);
            var parameterTemplateRows = mainDbService.GetParameterTemplateChildrenRows(idfsParentSection, idfsFormTemplate);
            var labelsRows = mainDbService.GetLabelsTemplateChildrenRows(idfsParentSection, idfsFormTemplate);
            var linesRows = mainDbService.GetLinesTemplateChildrenRows(idfsParentSection, idfsFormTemplate);
            
            //���������� ������ � ���� ������
            foreach (var sectionTemplateRow in sectionTemplateRows)
            {
                var sectionNode = parentNode.Add(sectionTemplateRow);
                sectionNode.ProcessAsTable = sectionTemplateRow.blnGrid;
                FillFlexNodeForSection(sectionNode, sectionTemplateRow.idfsSection, idfObservation, idfsFormTemplate);
            }

            #region ���������� ���������� � ���� ������
            
            foreach (var parameterTemplateRow in parameterTemplateRows)
            {
                //������������ ���������, �� �������� � �������
                if (parameterTemplateRow.IsidfsSectionNull() || (!parameterTemplateRow.IsidfsSectionNull() && !mainDbService.IsSectionTable(parameterTemplateRow.idfsSection)))
                {
                    //������� �������� ��� ����� ���������, ��������� ��� ��������
                    parentNode.Add(parameterTemplateRow, mainDbService.GetActivityParametersRow(idfObservation, parameterTemplateRow.idfsParameter, null));
                }
                else
                {
                    var isSummaryTemplate = idfsFormTemplate.Equals(mainDbService.IdfsFormTemplateSummary);
                    if (isSummaryTemplate && !mainDbService.IsParameterNumeric(parameterTemplateRow.idfsParameter) && (parameterTemplateRow.intOrder > 0)) continue;
            
                    //� ��������� ������� ������������ ������� ��������� � ����� ��� ��������
                    parentNode.Add(parameterTemplateRow, true);
                }
            }

            #endregion

            //���������� ������ � ����������
            parentNode.Sort();

            //���������� ������� � ���� ������
            foreach (var labelsRow in labelsRows)
            {
                parentNode.Add(labelsRow);
            }
            //���������� ����� � ���� ������
            foreach (var linesRow in linesRows)
            {
                parentNode.Add(linesRow);
            }
        }


    }
}
