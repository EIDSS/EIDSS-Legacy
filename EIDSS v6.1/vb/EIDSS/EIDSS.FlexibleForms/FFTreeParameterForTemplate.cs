using System;
using System.Windows.Forms;
using bv.common.Core;
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

        //  for scan mode only
        public FFTreeParameterForTemplate()
        {
            InitializeComponent();
        }

        private const string StrEmptyKey = "emptykey";
        private readonly string m_StrEmpty;
        private Dictionary<long, Parameter> parameterList { get; set; }
        private FlexibleFormsDS.FormTypesRow formType { get; set; }
        
        private DbService MainDbService { get { return (DbService)DbService; } }

        public List<long> SelectedParameters
        {
            get { return GetSelectedParameters(); }
        }
        
        private List<long> GetSelectedParameters()
        {
            var result = new List<long>();
            for (var i = 0; i < treeParametersLibrary.Selection.Count; i++)
            {
                if (treeParametersLibrary.Selection[i].Tag is FlexibleFormsDS.ParametersRow)
                    result.Add(((FlexibleFormsDS.ParametersRow) treeParametersLibrary.Selection[i].Tag).idfsParameter);
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

            //в дерево попадают только те параметры, которые не принадлежат табличным секциям
            //также в заголовки выводятся длинные имена параметров
            treeParametersLibrary.Nodes.Clear();
            
            //на всякий случай произведём дозагрузку секций и параметров по этому типу формы
            //осуществляем дозагрузку секций
            MainDbService.LoadSections(formType.idfsFormType, null, null);
            //осуществляем дозагрузку параметров
            //берем только те, что не относятся к какой-либо секции, а только к типу формы
            MainDbService.LoadParameters(formType.idfsFormType, null);

            //обновим статусные данные по этому типу формы
            formType.HasNestedSections = MainDbService.HasNestedSections(formType.idfsFormType);
            formType.HasParameters = MainDbService.HasNestedParameters(formType.idfsFormType);

            //добавляем узел с типом формы
            AppendFormTypeNode();
        }
       

        /// <summary>
        /// Вспомогательный метод добавления узла типа формы в дерево
        /// </summary>
        public void AppendFormTypeNode()
        {
            var node = treeParametersLibrary.AppendNode(null, null, formType);
            node[trlcTreeListParametersColumn] = formType.Name;
            node.ImageIndex = node.SelectImageIndex = 0;
            //если у типа формы есть секции или параметры, то сделаем там фиктивные узлы
            //поскольку этот метод вызывается в самом начале работы программы, то здесь допустимо использовать эти значения
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
            //если у узла уже загружены дочерние узлы, то повторно их не перегружаем
            if ((parentNode.FirstNode != null) && (!parentNode.FirstNode.Tag.Equals(StrEmptyKey))) return;

            //развёртываться может либо тип формы, либо секция
            //параметр не может содержать вложенные узлы
            Cursor = Cursors.WaitCursor;

            //если раскрывается тип формы
            if (parentObject is FlexibleFormsDS.FormTypesRow)
            {
                #region загрузка содержимого

                //догрузим секции, относящиеся к этому типу форм
                var row = (FlexibleFormsDS.FormTypesRow)parentObject;

                //посмотрим, что по нему нужно грузить, а что нет
                if (MainDbService.HasNestedSections(row.idfsFormType))
                {
                    //размещаем секции в дереве
                    MainDbService.AppendSectionNodes(parentTree, parentNode, MainDbService.GetSectionsByFormType(row.idfsFormType), true, false);
                }
                if (MainDbService.HasNestedParameters(row.idfsFormType))
                {
                    //размещаем параметры в дереве (помещаем только те, которые относятся к типу формы, но не имеют никакой секции)
                    HelperFunctions.AppendParameterNodes(parentTree, parentNode,MainDbService.GetParametersByFormType(row.idfsFormType), true);
                }

                #endregion
            }

            //если раскрывается секция
            if (parentObject is FlexibleFormsDS.SectionsRow)
            {
                #region загрузка содержимого

                //догрузим секции, для которых эта секция является родительской
                var row = (FlexibleFormsDS.SectionsRow)parentObject;

                //осуществляем дозагрузку секций
                MainDbService.LoadSections(row.idfsFormType, null, row.idfsSection);
                //осуществляем дозагрузку параметров
                //берем только те, что не относятся к какой-либо секции, а только к типу формы
                MainDbService.LoadParameters(row.idfsFormType, row.idfsSection);

                if (MainDbService.HasNestedSections(row))
                {
                    //размещаем секции в дереве
                    MainDbService.AppendSectionNodes(parentTree, parentNode, MainDbService.GetSectionChildrenRows(row.idfsSection), true, false);
                }
                if (MainDbService.HasNestedParameters(row))
                {

                    //размещаем секции в дереве
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
            if (!Utils.IsCalledFromUnitTest() && FindForm() == null)
                return true;
            return m_ClosingMode.Equals(ClosingMode.Cancel) || ValidateData();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool ValidateData()
        {
            var result =  base.ValidateData();

            if (result)
            {
                //выбирать можно только параметры
                //проверим, не выбран ли уже этот параметр в статических или динамических параметрах
                result = (SelectedParameters.Count > 0) && (parameterList != null);
                var alreadyContains = false;
                if (result)
                {
                    foreach (var sp in SelectedParameters)
                    {
                       if (parameterList.ContainsKey(sp))
                       {
                           result = false;
                           alreadyContains = true;
                           break;
                       }
                    }
                }
                if (!result)
                {
                    if (alreadyContains)
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

