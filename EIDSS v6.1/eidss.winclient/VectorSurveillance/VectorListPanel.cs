using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using bv.common.Enums;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Schema;
using eidss.winclient.Schema;

namespace eidss.winclient.VectorSurveillance
{
    public partial class VectorListPanel : BaseGroupPanel_Vector
    {
        /// <summary>
        /// 
        /// </summary>
        public VectorListPanel()
        {
            InitializeComponent();
            TopPanelVisible = true;
            Grid.GridView.OptionsView.ColumnAutoWidth = false;
            EditByDoubleClick = true;
            AllowCustomization = true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public override string GetDetailFormName(IObject o)
        {
            return "VectorDetail";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actions"></param>
        public override void SetCustomActions(List<ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);

            SetActionFunction(actions, "CopyVector", ShowCopyDialogWindow);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="bo"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private ActResult ShowCopyDialogWindow(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            //должен быть выбран вектор
            var vector = bo as Vector;
            if (vector == null) return false;
            var panel = VectorSurveillanceHelper.ShowCopyDialogWindow();
            if (panel.DialogResult.Equals(DialogResult.OK))
            {
                //создаём новый объект и добавляем туда всё нужное из старого
                var vectorNew = vector.CopyVector(manager, panel.IsNeedSpecificData, panel.IsNeedSamples, panel.IsNeedFieldTests);
                vectorNew.Session.Vectors.Add(vectorNew);

                var handle = Grid.GridView.GetRowHandle(vectorNew.Session.Vectors.Count - 1);
                Grid.GridView.FocusedRowHandle = handle;
                Grid.GridView.ClearSelection();
                Grid.GridView.SelectRow(handle);
                PerformAction("Edit");
                if ((LastExecutedActionInternal != null) && (LastExecutedActionInternal.ActionType == ActionTypes.Cancel))
                {
                    vector.Session.Vectors.Remove(vectorNew);
                }
            }
            return true;
        }

        /*public override void DeleteTempObjects(IObject o)
        {
            var vector = o as Vector;
            if (vector != null && vector.Session.Vectors.Any(v => v.idfVector == vector.idfVector))
            {
                vector.Session.Vectors.Remove(vector);
                //vector.MarkToDelete();
            }
        }*/

        public override bool ReadOnly
        {
            get
            {
                var vsSessionPanel = ParentBasePanel as VsSessionDetail;
                if (vsSessionPanel != null && ((VsSession) vsSessionPanel.BusinessObject).IsClosed)
                    return true;
                return base.ReadOnly;
            }
            set
            {
                base.ReadOnly = value;
            }
        }
    }
}
