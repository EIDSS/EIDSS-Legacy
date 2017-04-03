using System;
using System.Windows.Forms;
using bv.common.win;
using DevExpress.XtraTreeList;
using EIDSS.FlexibleForms.Components;
using EIDSS.FlexibleForms.DataBase;
using EIDSS.FlexibleForms.Helpers;
using System.Collections.Generic;
using bv.winclient.Core;
using eidss.model.Resources;

namespace EIDSS.FlexibleForms
{
    public partial class FFTreeParameterForTemplate : BaseDetailForm
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbService"></param>
        /// <param name="idfsformtype"></param>
        /// <param name="parameterList"></param>
        public FFTreeParameterForTemplate(DbService dbService, FlexibleFormsDS.FormTypesRow idfsformtype, Dictionary<long, Parameter> parameterList)
        {
            InitializeComponent();
            DbService = dbService;
            IgnoreAudit = true;
            formType = idfsformtype;
            this.parameterList = parameterList;
            m_StrEmpty = EidssMessages.Get("strEmpty");
        }

        // only for scan mode
        public FFTreeParameterForTemplate()
        {
            InitializeComponent();
        }

        private const string StrEmptyKey = "emptykey";
        private readonly string m_StrEmpty;
        private Dictionary<long, Parameter> parameterList { get; set; }
        private FlexibleFormsDS.FormTypesRow formType { get; set; }
        
        /// <summary>
        /// ������ �� ������� �������
        /// </summary>
        private DbService MainDbService { get { return (DbService)DbService; } }

        /// <summary>
        /// ��������, ������� ������ � ������
        /// </summary>
        public long? SelectedParameter
        {
            get { return GetSelectedParameter(); }
        }

        /// <summary>
        /// ���������� ����� �������� ������
        /// </summary>
        /// <returns></returns>
        private long? GetSelectedParameter()
        {
            long? result = null;

            if (treeParametersLibrary.Selection.Count > 0)
            {
                if (treeParametersLibrary.Selection[0].Tag is FlexibleFormsDS.ParametersRow)
                    result = ((FlexibleFormsDS.ParametersRow) treeParametersLibrary.Selection[0].Tag).idfsParameter;
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override bool LoadData(ref object id)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void RefreshTreeParameters()
        {
            if (formType == null) return;
            if (!formType.IsRowAlive()) return;

            //� ������ �������� ������ �� ���������, ������� �� ����������� ��������� �������
            //����� � ��������� ��������� ������� ����� ����������
            treeParametersLibrary.Nodes.Clear();
            
            //�� ������ ������ ��������� ���������� ������ � ���������� �� ����� ���� �����
            //������������ ���������� ������
            MainDbService.LoadSections(formType.idfsFormType, null, null);
            //������������ ���������� ����������
            //����� ������ ��, ��� �� ��������� � �����-���� ������, � ������ � ���� �����
            MainDbService.LoadParameters(formType.idfsFormType, null);

            //������� ��������� ������ �� ����� ���� �����
            formType.HasNestedSections = MainDbService.HasNestedSections(formType.idfsFormType);
            formType.HasParameters = MainDbService.HasNestedParameters(formType.idfsFormType);

            //��������� ���� � ����� �����
            AppendFormTypeNode();
        }
       

        /// <summary>
        /// ��������������� ����� ���������� ���� ���� ����� � ������
        /// </summary>
        public void AppendFormTypeNode()
        {
            var node = treeParametersLibrary.AppendNode(null, null, formType);
            node[trlcTreeListParametersColumn] = formType.Name;
            node.ImageIndex = node.SelectImageIndex = 0;
            //���� � ���� ����� ���� ������ ��� ���������, �� ������� ��� ��������� ����
            //��������� ���� ����� ���������� � ����� ������ ������ ���������, �� ����� ��������� ������������ ��� ��������
            if (formType.HasNestedSections || formType.HasParameters)
            {
                var nodeEmpty = treeParametersLibrary.AppendNode(null, node, StrEmptyKey);
                nodeEmpty[trlcTreeListParametersColumn] = m_StrEmpty;
                node.Expanded = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFFTreeParameterForTemplateLoad(object sender, EventArgs e)
        {
            RefreshTreeParameters();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTreeParametersLibraryBeforeExpand(object sender, BeforeExpandEventArgs e)
        {
            var parentTree = (TreeList)sender;
            var parentNode = e.Node;
            var parentObject = e.Node.Tag;
            //���� � ���� ��� ��������� �������� ����, �� �������� �� �� �����������
            if ((parentNode.FirstNode != null) && (!parentNode.FirstNode.Tag.Equals(StrEmptyKey))) return;

            //������������� ����� ���� ��� �����, ���� ������
            //�������� �� ����� ��������� ��������� ����
            Cursor = Cursors.WaitCursor;

            //���� ������������ ��� �����
            if (parentObject is FlexibleFormsDS.FormTypesRow)
            {
                #region �������� �����������

                //�������� ������, ����������� � ����� ���� ����
                var row = (FlexibleFormsDS.FormTypesRow)parentObject;

                //���������, ��� �� ���� ����� �������, � ��� ���
                if (MainDbService.HasNestedSections(row.idfsFormType))
                {
                    //��������� ������ � ������
                    MainDbService.AppendSectionNodes(parentTree, parentNode, MainDbService.GetSectionsByFormType(row.idfsFormType), true, false);
                }
                if (MainDbService.HasNestedParameters(row.idfsFormType))
                {
                    //��������� ��������� � ������ (�������� ������ ��, ������� ��������� � ���� �����, �� �� ����� ������� ������)
                    HelperFunctions.AppendParameterNodes(parentTree, parentNode,MainDbService.GetParametersByFormType(row.idfsFormType), true);
                }

                #endregion
            }

            //���� ������������ ������
            if (parentObject is FlexibleFormsDS.SectionsRow)
            {
                #region �������� �����������

                //�������� ������, ��� ������� ��� ������ �������� ������������
                var row = (FlexibleFormsDS.SectionsRow)parentObject;

                //������������ ���������� ������
                MainDbService.LoadSections(row.idfsFormType, null, row.idfsSection);
                //������������ ���������� ����������
                //����� ������ ��, ��� �� ��������� � �����-���� ������, � ������ � ���� �����
                MainDbService.LoadParameters(row.idfsFormType, row.idfsSection);

                if (MainDbService.HasNestedSections(row))
                {
                    //��������� ������ � ������
                    MainDbService.AppendSectionNodes(parentTree, parentNode, MainDbService.GetSectionChildrenRows(row.idfsSection), true, false);
                }
                if (MainDbService.HasNestedParameters(row))
                {

                    //��������� ������ � ������
                    HelperFunctions.AppendParameterNodes(parentTree, parentNode, (FlexibleFormsDS.ParametersRow[])MainDbService.MainDataSet.Parameters.Select(DataHelper.Filter("idfsSection", row.idfsSection)), true);

                }

                #endregion
            }

            Cursor = Cursors.Default;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postType"></param>
        /// <returns></returns>
        public override bool Post(bv.common.Enums.PostType postType)
        {
            return m_ClosingMode.Equals(ClosingMode.Cancel) ? true : ValidateData();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool ValidateData()
        {
            bool result =  base.ValidateData();

            if (result)
            {
                //�������� ����� ������ ���������
                //��������, �� ������ �� ��� ���� �������� � ����������� ��� ������������ ����������
                result = (SelectedParameter != null) && (parameterList != null) && (!parameterList.ContainsKey(SelectedParameter.Value));
                if (!result)
                {
                    if ((parameterList != null) && SelectedParameter.HasValue &&
                        parameterList.ContainsKey(SelectedParameter.Value))
                    {
                        ErrorForm.ShowMessageDirect(EidssMessages.Get("ParameterAlreadyInTemplateMessage"));
                        treeParametersLibrary.Selection.Clear();
                    }
                }
            }

            return result;
        }
    }
}

