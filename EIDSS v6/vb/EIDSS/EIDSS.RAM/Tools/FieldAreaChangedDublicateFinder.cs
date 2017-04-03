using DevExpress.XtraPivotGrid;

namespace eidss.avr.Tools
{
    public class FieldAreaChangedDublicateFinder
    {
        private PivotGridField m_Field;
        private PivotArea m_Area;
        private int m_AreaIndex;
        private bool m_Visible;

        public bool IsFieldAreaChangedProcessed(PivotFieldEventArgs e)
        {
            if ((m_Field == e.Field) &&
                (m_Area == e.Field.Area) &&
                (m_AreaIndex == e.Field.AreaIndex) &&
                (m_Visible == e.Field.Visible))
            {
                return true;
            }

            m_Field = e.Field;
            m_Area = e.Field.Area;
            m_AreaIndex = e.Field.AreaIndex;
            m_Visible = e.Field.Visible;

            return false;
        }
    }
}