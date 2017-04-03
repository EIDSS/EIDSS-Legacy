using System;
using System.Drawing;

namespace EIDSS.RAM_DB.Common.EventHandlers
{
    public class PivotFieldPopupMenuEventArgs : EventArgs
    {
        private readonly string m_FieldName;
        private readonly Point m_Location;

        public PivotFieldPopupMenuEventArgs(string fieldName, Point location)
        {
            m_FieldName = fieldName;
            m_Location = location;
        }

        public string FieldName
        {
            get { return m_FieldName; }
        }

        public Point Location
        {
            get { return m_Location; }
        }
    }
}