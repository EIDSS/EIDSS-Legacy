using System;

using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraBars;
using bv.winclient.BasePanel;

namespace bv.winclient.Core
{
    public class PopupMenuWrapper : IDisposable
    {
        private PopupMenu m_PopupMenu;
        private void Init(ContextMenu menu, CancelEventHandler beforePopup)
        {
            if (m_PopupMenu == null)
            {
                m_PopupMenu = new PopupMenu();
                m_PopupMenu.Manager = BaseFormManager.MainBarManager;
                m_PopupMenu.CloseUp += DisposeMenu;
                if ((beforePopup != null))
                {
                    m_PopupMenu.BeforePopup += beforePopup;
                }

                foreach (MenuItem item in menu.MenuItems)
                {
                    if (!item.Visible)
                    {
                        continue;
                    }
                    BarButtonItem barButton = new BarButtonItem(m_PopupMenu.Manager, item.Text);
                    barButton.Tag = item;
                    barButton.Enabled = item.Enabled;
                    barButton.ItemClick += BarButtonClick;
                    m_PopupMenu.AddItem(barButton);
                }
            }

        }
        public PopupMenuWrapper(ContextMenu menu)
        {
            Init(menu, null);
        }
        public PopupMenuWrapper(ContextMenu menu, CancelEventHandler BeforePopup)
        {
            Init(menu, BeforePopup);
        }


        private void DisposeMenu(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void ShowPopup(System.Drawing.Point p)
        {
            if ((m_PopupMenu != null))
            {
                m_PopupMenu.ShowPopup(p);
            }
        }
        private void BarButtonClick(object sender, ItemClickEventArgs e)
        {
            ((MenuItem)e.Item.Tag).PerformClick();
        }

        // To detect redundant calls
        private bool disposedValue = false;

        // IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    if ((m_PopupMenu != null))
                    {
                        m_PopupMenu.Dispose();
                        m_PopupMenu = null;
                    }
                }

                // TODO: free shared unmanaged resources
            }
            this.disposedValue = true;
        }

        #region " IDisposable Support "
        // This code added by Visual Basic to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
