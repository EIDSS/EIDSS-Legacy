using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BLToolkit.Reflection;
using bv.common.Core;
using bv.common.Enums;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.BasePanel.ListPanelComponents;
using bv.winclient.Core;
using eidss.model.Resources;
using eidss.model.Schema;

namespace eidss.winclient.Human
{
    public partial class DeduplicationLayout : bv.winclient.Layout.LayoutAdvanced
    {
        public DeduplicationLayout()
        {
            InitializeComponent();
            BusinessObject = TypeAccessor.CreateInstanceEx<HumanCaseListItem>();
            var meta = (IObjectMeta)BusinessObject.GetAccessor();
            BaseListGridControl.InitColumns(DeduplicationView, meta.GridMeta);
        }
        public override void AddActions(List<ActionMetaItem> actions)
        {
            var actionsCopy = actions.ToArray().ToList();
            if (actionsCopy.Find(c => c.Name == "AddForDeduplication") == null)
            {
                var action = 
                    new ActionMetaItem(
                        "AddForDeduplication",
                        ActionTypes.Action, 
                        true,
                        String.Empty,
                        String.Empty,
                        null,
                        null,
                        new ActionMetaItem.VisualItem(
                            "strAddForDeduplication_Id",
                            "add",
                            "strAddForDeduplication_Id",
                            "",
                            "",
                            "",
                            ActionsAlignment.Right,
                            ActionsPanelType.Main,
                            ActionsAppType.Win
                            )
                        );
                    /*
                    new ActionMetaItem(
                    "AddForDeduplication",
                    "strAddForDeduplication_Id",
                    "add",
                    "strAddForDeduplication_Id",
                    "",
                    "",
                    "",
                    "",
                    null,
                    ActionsAlignment.Right,
                    ActionsPanelType.Main,
                    ActionsAppType.Win,
                    true,
                    true,
                    false,
                    null,
                    null,
                    ActionMetaItem.IsListItemActionEnabled,
                    ActionTypes.Action,
                    ActionTypes.Action,
                    ActionTypes.Unknown,
                    "",
                    ""
                    );*/
                action.AddFirstUIFunc(AddForDeduplication, null);
                actionsCopy.Insert(0, action);
            }
            base.AddActions(actionsCopy);
        }
        public override void AddActionPanel(Control actionPanelControl, ActionPanelPosition position)
        {
            if (!position.Equals(ActionPanelPosition.Top))
                base.AddActionPanel(actionPanelControl, position);
        }

        private void btnRemoveCase_Click(object sender, EventArgs e)
        {
            var rowIndex = DeduplicationView.FocusedRowHandle;
            if (rowIndex >= 0)
                DeduplicationList.RemoveAt(rowIndex);
            DeduplicationView.RefreshData();
        }

        private List<HumanCaseListItem> m_DeduplicationList;
        public List<HumanCaseListItem> DeduplicationList
        {
            get { return m_DeduplicationList ?? (m_DeduplicationList = new List<HumanCaseListItem>()); }
            set { m_DeduplicationList = value; }
        }
        private readonly ActionLocker m_ActionLocker = new ActionLocker();
        private void btnDeduplicate_Click(object sender, EventArgs e)
        {
            if (DeduplicationView.RowCount == 2)
            {
                if (m_ActionLocker.Lock())
                {
                    try
                    {
                        var keys = new ArrayList { DeduplicationList[0].Key, DeduplicationList[1].Key };
                        var form = (IApplicationForm)ClassLoader.LoadClass("HumanCaseDeduplicationDetail");
                        if (form != null)
                        {
                            object id = keys;
                            if (BaseFormManager.ShowModal(form, FindForm(), ref id, null, null))
                            {
                                DeduplicationList.Clear();
                                DeduplicationView.RefreshData();
                            }
                        }
                    }
                    finally
                    {
                        m_ActionLocker.Unlock();
                    }
                }

            }
            else
                ErrorForm.ShowWarning("errNotEnoughHC", "There is no enough records for de-duplication.");

        }

        //private void panelMain_Resize(object sender, EventArgs e)
        //{
        //    DeduplicationGrid.Left = panelMain.Left;
        //    DeduplicationGrid.Width = panelMain.Width;
        //    lblHCDeduplication.Width = DeduplicationGrid.Left - lblHCDeduplication.Left;
        //    lblHCDeduplication.Visible = lblHCDeduplication.Width > 100;
        //}

        private void DeduplicationView_RowCountChanged(object sender, EventArgs e)
        {
            btnDeduplicate.Enabled = DeduplicationView.RowCount == 2;
            btnRemoveCase.Enabled = DeduplicationView.RowCount > 0;
        }

        public ActResult AddForDeduplication(DbManagerProxy manager, IObject bo, List<object> pars)
        {
            if (DeduplicationList.Count < 2)
            {
                if (pars == null || pars.Count < 2 || pars[1] == null || !(pars[1] is HumanCaseListItem))
                    return false;
                if (DeduplicationList.Count == 1 && DeduplicationList[0].Key.Equals(((HumanCaseListItem)pars[1]).Key))
                {
                    MessageForm.Show(EidssMessages.Get("errDoubleHC"));
                    return true;
                }
                DeduplicationList.Add((HumanCaseListItem)((HumanCaseListItem)pars[1]).Clone());
                if (DeduplicationGrid.DataSource == null || DeduplicationGrid.DataSource != DeduplicationList)
                    DeduplicationGrid.DataSource = DeduplicationList;
                DeduplicationView.RefreshData();

                return true;
            }
            return false;
        }
    }

}
