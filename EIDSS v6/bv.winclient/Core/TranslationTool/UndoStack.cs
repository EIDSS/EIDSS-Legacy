using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraTreeList.Columns;

namespace bv.winclient.Core.TranslationTool
{
    public class UndoStack
    {
        private readonly Stack<UndoControlState> m_UndoStack;
        public UndoStack()
        {
            m_UndoStack = new Stack<UndoControlState>();
        }

        public bool CanUndo
        {
            get { return m_UndoStack.Count > 0; }
        }

        public UndoControlState Push(Component ctl, UndoOperation operation, Rectangle bounds, string caption, bool visibility)
        {
            var state = new UndoControlState() { Element = ctl, Operation = operation, Bounds = bounds, Caption = caption, Visible = visibility };
            m_UndoStack.Push(state);
            return state;
        }
        public UndoControlState Push(Component ctl, Rectangle bounds)
        {
            var state = new UndoControlState() { Element = ctl, Operation = UndoOperation.Position, Bounds = bounds };
            m_UndoStack.Push(state);
            return state;
        }
        public UndoControlState Push(Component ctl, string caption)
        {
            var state = new UndoControlState() { Element = ctl, Operation = UndoOperation.Text, Caption = caption };
            m_UndoStack.Push(state);
            return state;
        }
        public UndoControlState Push(Component ctl, bool visibility)
        {
            var state = new UndoControlState() { Element = ctl, Operation = UndoOperation.Visibility, Visible = visibility };
            m_UndoStack.Push(state);
            return state;
        }

        public UndoControlState Push(UndoControlState state)
        {
            m_UndoStack.Push(state);
            return state;
        }

        public void Undo()
        {
            var state = m_UndoStack.Pop();
            if (state != null)
                RestoreControlState(state);
        }

        public Dictionary<object, DesignElement> GetChangedElements()
        {
            var list = new Dictionary<object, DesignElement>();
            foreach (var elem in m_UndoStack)
            {
                GetChangeFromUndoState(elem, list);
                if (elem.RelatedChanges != null)
                    foreach (var elem1 in elem.RelatedChanges)
                    {
                        GetChangeFromUndoState(elem1, list);
                    }
            }
            return list;
        }

        private void GetChangeFromUndoState(UndoControlState undoState, Dictionary<object, DesignElement> changes)
        {
            DesignElement de = DesignElement.None;
            if ((undoState.Operation & UndoOperation.Text) != 0)
                de |= DesignElement.Caption;
            var ctl = undoState.Element as Control;
            if (ctl != null)
            {
                if ((undoState.Operation & UndoOperation.Position) != 0)
                {
                    if (ctl.Location != undoState.Bounds.Location)
                        de |= DesignElement.Moving;
                    if (ctl.Size != undoState.Bounds.Size)
                        de |= DesignElement.Sizing;
                }
                if ((undoState.Operation & UndoOperation.Visibility) != 0)
                    de |= DesignElement.Visibility;
            }
            if (de == DesignElement.None)
                return;
            object element = undoState.Element is ControlDesignerProxy
                                 ? (undoState.Element as ControlDesignerProxy).HostControl
                                 : undoState.Element;
            if (!changes.ContainsKey(element))
                changes.Add(element, de);
            else
            {
                changes[element] |= de;
            }

        }
        private void RestoreControlState(UndoControlState state)
        {
            var elem = state.Element;
            var ctl = elem as Control;
            if (ctl != null && (state.Operation & UndoOperation.Position) != 0)
            {
                ctl.SuspendLayout();
                ctl.SetBounds(state.Bounds.X, state.Bounds.Y, state.Bounds.Width, state.Bounds.Height);
                ctl.ResumeLayout();
            }
            if ((state.Operation & UndoOperation.Text) != 0)
                TranslationToolHelperWinClient.SetComponentText(elem, state.Caption);
            if (ctl != null && (state.Operation & UndoOperation.Visibility) != 0)
                ctl.Visible = state.Visible;
            if (state.RelatedChanges != null && state.RelatedChanges.Length > 0)
            {
                foreach (var change in state.RelatedChanges)
                {
                    RestoreControlState(change);
                }
            }
        }


        public void Clear()
        {
            m_UndoStack.Clear();
        }
    }
}
