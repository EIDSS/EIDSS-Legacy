using System;

namespace eidss.model.AVR.SourceData
{
    public class AvrDataRowDTO
    {
      

        public const int DateTimeFlag = 0x100 + 0x200;
        public const int IntFlag = 0x100 + 0x400;
        public const int ObjectFlag = 0x100 + 0x200 + 0x400;

        public int DateTimeIndex;
        public int IntIndex;
        public int ObjectIndex;

        public DateTime[] DateTimes;
        public int[] Ints;
        public object[] Objects;
        public ushort[] Map;

        public AvrDataRowDTO(int dateTimeCount, int intCount, int objectCount)
        {
            DateTimes = new DateTime[dateTimeCount];
            Ints = new int[intCount];
            Objects = new object[objectCount];

            Map = new ushort[dateTimeCount + intCount + objectCount];
        }

        public void SetDateTime(int totalIndex, DateTime value)
        {
            Map[totalIndex] = (ushort) (DateTimeFlag + DateTimeIndex);
            DateTimes[DateTimeIndex] = value;

            DateTimeIndex++;
        }

        public void SetInt(int totalIndex, int value)
        {
            Map[totalIndex] = (ushort) (IntFlag + IntIndex);
            Ints[IntIndex] = value;

            IntIndex++;
        }

        public void SetObject(int totalIndex, object value)
        {
            Map[totalIndex] = (ushort) (ObjectFlag + ObjectIndex);
            Objects[ObjectIndex] = value;

            ObjectIndex++;
        }

        public void Reset()
        {
            Array.Clear(Map, 0, Map.Length);
            DateTimeIndex = 0;
            IntIndex = 0;
            ObjectIndex = 0;
        }
    }
}