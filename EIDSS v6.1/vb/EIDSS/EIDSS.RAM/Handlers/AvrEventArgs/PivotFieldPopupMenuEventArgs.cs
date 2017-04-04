using System;
using System.Drawing;
using eidss.avr.db.Common;

namespace eidss.avr.Handlers.AvrEventArgs
{
    public class PivotFieldPopupMenuEventArgs : EventArgs
    {
        private readonly IAvrPivotGridField m_Field;
        private readonly Point m_Location;

        public PivotFieldPopupMenuEventArgs(IAvrPivotGridField field, Point location)
        {
            m_Field = field;
            m_Location = location;
        }

        public IAvrPivotGridField Field
        {
            get { return m_Field; }
        }

        public Point Location
        {
            get { return m_Location; }
        }
    }
}