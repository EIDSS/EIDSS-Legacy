using System;
using System.Windows.Forms;

namespace eidss.gis.Forms
{
    public class TemporaryWaitCursor : IDisposable
    {
        private readonly Cursor m_Cursor;

        public TemporaryWaitCursor()
        {
            m_Cursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
        }

        public void Dispose()
        {
            Cursor.Current = m_Cursor;
        }
    }
}
