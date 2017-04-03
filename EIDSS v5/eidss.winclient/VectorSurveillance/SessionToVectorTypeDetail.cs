using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLToolkit.EditableObjects;
using bv.common.Enums;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using DevExpress.XtraEditors.Controls;
using eidss.model.Schema;
using eidss.winclient.Schema;
using System.Linq;

namespace eidss.winclient.VectorSurveillance
{
    public partial class SessionToVectorTypeDetail : BaseDetailPanel_SessionToVectorTypeItem
    {
        /// <summary>
        /// 
        /// </summary>
        public SessionToVectorTypeDetail()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionID"></param>
        /// <param name="sessionToVectorType"></param>
        /// <param name="poolsVectors"></param>
        public void FillList(long sessionID, EditableList<SessionToVectorTypeItem> sessionToVectorType, EditableList<Vector> poolsVectors)
        {
            SessionToVectorType = sessionToVectorType;
            PoolsVectors = poolsVectors;
            if (SessionToVectorType.Count == 0) return;
            cbVectorTypes.Items.Clear();
            foreach (var vectorType in sessionToVectorType)
            {
                if (vectorType.idfsVectorType == 0) continue;
                cbVectorTypes.Items.Add(
                new CheckedListBoxItem(vectorType.idfsVectorType, vectorType.VectorTypeNationalName,
                                                  vectorType.Checked ? CheckState.Checked : CheckState.Unchecked));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private EditableList<SessionToVectorTypeItem> SessionToVectorType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private EditableList<Vector> PoolsVectors { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actions"></param>
        public override void SetCustomActions(List<ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);

            #region Создаём действия
            
            actions.Add(new ActionMetaItem(
                        "OK",
                        ActionTypes.Action,
                        true,
                        String.Empty,
                        String.Empty,
                        null,
                        null,
                        new ActionMetaItem.VisualItem(
                            "strOK_Id",
                            String.Empty,
                            "tooltipOK_Id",
                            String.Empty,
                            String.Empty,
                            String.Empty,
                            ActionsAlignment.Right,
                            ActionsPanelType.Main,
                            ActionsAppType.All
                            )
                            ,false
                            ,null
                            ,null
                            ,null
                            ,null
                            ,null
                            ,true
                        ));
            actions.Add(new ActionMetaItem(
                            "Cancel",
                            ActionTypes.Cancel,
                            true,
                            String.Empty,
                            String.Empty,
                            null,
                            null,
                            new ActionMetaItem.VisualItem(
                                "strCancel_Id",
                                String.Empty,
                                "tooltipCancel_Id",
                                String.Empty,
                                String.Empty,
                                String.Empty,
                                ActionsAlignment.Right,
                                ActionsPanelType.Main,
                                ActionsAppType.All
                                )));


            #endregion

            SetActionFunction(actions, "OK", OnActionOk);
        }

        /// <summary>
        /// 
        /// </summary>
        ActResult OnActionOk(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            if (SessionToVectorType == null) return new ActResult(false);

            foreach (var t in SessionToVectorType)
            {
                var currentVectorTypeID = t.idfsVectorType;
                foreach (CheckedListBoxItem cbItem in cbVectorTypes.Items)
                {
                    var vtID = (long)cbItem.Value;
                    if (vtID != currentVectorTypeID) continue;
                    t.Checked = cbItem.CheckState == CheckState.Checked;
                    break;
                }
            }
            return new ActResult(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnVectorTypesItemChecking(object sender, ItemCheckingEventArgs e)
        {
            if (e.NewValue != CheckState.Unchecked) return;
            //нельзя снимать выбор с типа вектора, если есть вектора с этим типом
            if ((e.Index >= 0) && (e.Index < SessionToVectorType.Count))
            {
                //TODO показать сообщение с объяснением почему нельзя снять галку
                var item = SessionToVectorType[e.Index];
                e.Cancel = PoolsVectors.Count(c => c.idfsVectorType == item.idfsVectorType && !c.IsMarkedToDelete) > 0;
            }
        }
    }
}
