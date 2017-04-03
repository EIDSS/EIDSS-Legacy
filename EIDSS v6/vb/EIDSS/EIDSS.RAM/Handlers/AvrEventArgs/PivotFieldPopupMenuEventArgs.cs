using System;
using System.Drawing;
using eidss.avr.db.Common;

namespace eidss.avr.Handlers.AvrEventArgs
{
    public class PivotFieldPopupMenuEventArgs : EventArgs
    {
        private readonly IAvrPivotGridField m_Field;
        private readonly Point m_Location;
        private readonly bool m_EnableDelete;
        private readonly bool m_EnableGroupDate;

        public PivotFieldPopupMenuEventArgs(IAvrPivotGridField field, Point location, bool enableDelete, bool enableGroupDate)
        {
            m_Field = field;
            m_Location = location;
            m_EnableDelete = enableDelete;
            m_EnableGroupDate = enableGroupDate;
        }

        public IAvrPivotGridField Field
        {
            get { return m_Field; }
        }

        public Point Location
        {
            get { return m_Location; }
        }

        public bool EnableDelete
        {
            get { return m_EnableDelete; }
        }

        public bool EnableGroupDate
        {
            get { return m_EnableGroupDate; }
        }
    }
}