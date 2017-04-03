using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using eidss.model.Model.FlexibleForms.FlexNodes;
using eidss.model.Schema;

namespace eidss.webclient.Areas.FlexForms.Helpers
{
    /// <summary>
    /// Хранилище сложных многоуровневых заголовков в таблицах
    /// </summary>
    public class WebGridHelper
    {
        public FlexNode SectionTemplateRootNode { get; private set; }
        public DataColumnCollection Columns { get; private set; }
        public List<ParameterTemplate> ParametersInternal { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sectionTemplate">Табличная секция верхнего уровня (узел)</param>
        /// <param name="columns">Перечень всех столбцов в таблице для секции верхнего уровня</param>
        public WebGridHelper(FlexNode sectionTemplate, DataColumnCollection columns)
        {
            SectionTemplateRootNode = sectionTemplate;
            if (SectionTemplateRootNode != null) ParametersInternal = SectionTemplateRootNode.GetParameterTemplateForDataTable();
            Columns = columns;
        }

        /// <summary>
        /// Для узла с потомками создаёт таблицу
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private static string GetTableForNode(FlexNode node)
        {
            var sb = new StringBuilder();
            var count = node.GetParameterTemplateForDataTable().Count;
            var width = node.GetTotalWidth();
            sb.AppendFormat("<td style=\"width:{0}px; box-sizing: border-box\">", width);
            sb.AppendFormat("<table style=\"width:{0}px; box-sizing: border-box\">", width);
            //первая строка -- сам узел
            sb.Append("<tr style=\"box-sizing: border-box\">");
            sb.AppendFormat("<td style=\"width:{2}px; min-width:{2}px; max-width:{2}px; box-sizing: border-box\" colspan=\"{1}\">{0}</td>", node.Text, count, width);/*node.ChildListCount*/
            sb.Append("</tr>");
            //все его дочерние узлы выводим в строку с вложенностью
            sb.Append(GetRow(node.ChildList));
            sb.Append("</table>");
            sb.Append("</td>");
            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="children"></param>
        /// <returns></returns>
        private static string GetRow(IEnumerable<FlexNode> children)
        {
            var sb = new StringBuilder();
            sb.Append("<tr style=\"box-sizing: border-box\">");

            foreach (var node in children)
            {
                //если это Summary и это не числовой параметр, то рендерить это не надо
                if (node.FFModel.IsSummary)
                {
                    var parameterTemplate = node.GetParameterTemplate();
                    if ((parameterTemplate != null) && !parameterTemplate.IsParameterNumeric()) continue;
                }

                if (node.ChildListCount == 0)
                {
                    sb.AppendFormat("<td style=\"width:{1}px; min-width:{1}px; max-width:{1}px; box-sizing: border-box\">{0}</td>", node.Text, node.Width);
                }
                else
                {
                    sb.Append(GetTableForNode(node));
                }
            }
            sb.Append("</tr>");

            return sb.ToString();
        }

        /// <summary>
        /// Формирует заголовок таблицы
        /// </summary>
        /// <param name="rootNode"></param>
        /// <returns></returns>
        public static HtmlString GetHeader(FlexNode rootNode)
        {
            var sb = new StringBuilder();
            var count = rootNode.GetTotalColumnsCount();//rootNode.GetParameterTemplateForDataTable().Count + rootNode.GetPredefinedStubsForDataTable().Count /*+ rootNode.GetAdditionalColumnsCount()*/;
            var totalWidth = rootNode.GetTotalWidth();

            sb.AppendFormat("<table style=\"width:{0}px; box-sizing: border-box\">", totalWidth);
            sb.Append("<tr style=\"box-sizing: border-box\">");
            sb.AppendFormat("<td style=\"width:{2}px; min-width:{2}px; max-width:{2}px; box-sizing: border-box\" colspan=\"{1}\">{0}</td>",
                rootNode.Level == 1 ? String.Empty : rootNode.Text, count, totalWidth);
            sb.Append("</tr>");
            sb.Append(GetRow(rootNode.ChildList));
            sb.Append("</table>");

            return new HtmlString(sb.ToString());
        }
    }
}
