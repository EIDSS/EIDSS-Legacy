using bv.common.Core;

namespace eidss.model.AVR.SourceData
{
    public class AvrDataRow : AvrDataRowBase
    {
        protected internal AvrDataRow(object[] array)
        {
            Utils.CheckNotNull(array, "array");
            Array = array;
        }

        protected internal object[] Array { get; private set; }

        public override int Count
        {
            get { return Array.Length; }
        }

        public override object this[int index]
        {
            get
            {
                object item = Array[index];
                return item;
            }
        }

        public void SetValue(int index, object value)
        {
            Array[index] = value;
        }

        public override AvrDataRowBase Clone()
        {
            var copyArray = new object[Array.Length];
            Array.CopyTo(copyArray, 0);

            return new AvrDataRow(copyArray);
        }
    }
}