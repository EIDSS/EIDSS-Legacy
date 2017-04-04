using System;
using bv.common.Core;

namespace eidss.model.AVR.SourceData
{
    public class AvrDataRowEx : AvrDataRowBase
    {
        private readonly ushort[] m_Map;
        private readonly DateTime[] m_DateTimes;
        private readonly int[] m_Ints;
        private readonly object[] m_Objects;

        protected internal AvrDataRowEx(AvrDataRowDTO dto)
        {
            Utils.CheckNotNull(dto, "dto");

            m_Map = new ushort[dto.Map.Length];
            m_DateTimes = new DateTime[dto.DateTimeIndex];
            m_Ints = new int[dto.IntIndex];
            m_Objects = new object[dto.ObjectIndex];

            Array.Copy(dto.Map, m_Map, m_Map.Length);
            Array.Copy(dto.DateTimes, m_DateTimes, m_DateTimes.Length);
            Array.Copy(dto.Ints, m_Ints, m_Ints.Length);
            Array.Copy(dto.Objects, m_Objects, m_Objects.Length);
        }

        protected internal AvrDataRowEx(AvrDataRowEx row)
        {
            Utils.CheckNotNull(row, "row");

            m_Map = new ushort[row.m_Map.Length];
            m_DateTimes = new DateTime[row.m_DateTimes.Length];
            m_Ints = new int[row.m_Ints.Length];
            m_Objects = new object[row.m_Objects.Length];

            Array.Copy(row.m_Map, m_Map, m_Map.Length);
            Array.Copy(row.m_DateTimes, m_DateTimes, m_DateTimes.Length);
            Array.Copy(row.m_Ints, m_Ints, m_Ints.Length);
            Array.Copy(row.m_Objects, m_Objects, m_Objects.Length);

        }

        public override int Count
        {
            get { return m_Map.Length; }
        }

        public override object this[int index]
        {
            get
            {
                int complexIndex = m_Map[index];
                if (complexIndex == 0)
                {
                    return DbNullValue;
                }
                int internalIndex = complexIndex & 0xFF;
                switch (complexIndex & 0xFF00)
                {
                    case AvrDataRowDTO.ObjectFlag:
                        return m_Objects[internalIndex];
                    case AvrDataRowDTO.DateTimeFlag:
                        return m_DateTimes[internalIndex];
                    case AvrDataRowDTO.IntFlag:
                        return m_Ints[internalIndex];
                    default:
                        throw new AvrException(
                            string.Format("Cannot find corresponding value for index {0}, internal index {1} ", index, internalIndex));
                }
            }
        }

        public override AvrDataRowBase Clone()
        {
            return new AvrDataRowEx(this);
        }
    }
}