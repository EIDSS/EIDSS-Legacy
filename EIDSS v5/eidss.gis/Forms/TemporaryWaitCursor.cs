using System;
using System.Windows.Forms;

namespace eidss.gis.Forms
{
    public class TemporaryWaitCursor : IDisposable
    {
        private Cursor crs;

        public TemporaryWaitCursor()
        {
            crs = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
        }

        public void Dispose()
        {
            Cursor.Current = crs;
        }
    }
}
