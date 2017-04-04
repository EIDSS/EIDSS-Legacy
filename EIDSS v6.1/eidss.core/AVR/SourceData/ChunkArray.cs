using System;

namespace eidss.model.AVR.SourceData
{
    [Serializable]
    public class ChunkArray<T>
    {
        protected const int ChunkSize = 0x4000;
        protected const int ChunkMask = 0x3FFF;
        protected const int ShiftLength = 14;

        protected readonly T[][] m_Chunks;
        protected readonly int m_ChunksCount;

        public ChunkArray(int length)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("length", "Length should be a positive number");
            }
            Length = length;

            m_ChunksCount = Length >> ShiftLength;
            if ((Length & ChunkMask) > 0)
            {
                m_ChunksCount++;
            }
            m_Chunks = new T[m_ChunksCount][];
            for (int i = 0; i < m_ChunksCount; i++)
            {
                m_Chunks[i] = new T[ChunkSize];
            }
        }

        public ChunkArray(T[] sourceArray)
            : this(sourceArray.Length)
        {
            int fullCount = Length;

            for (int i = 0; i < m_ChunksCount; i++)
            {
                var copyCount = fullCount < ChunkSize
                    ? fullCount
                    : ChunkSize;

                Array.Copy(sourceArray, Length - fullCount, m_Chunks[i], 0, copyCount);

                fullCount -= ChunkSize;
            }
        }

        public int Length { get; private set; }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException("Index was outside the bounds of the array.");
                }
                return m_Chunks[index >> ShiftLength][index & ChunkMask];
            }
            set
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException("Index was outside the bounds of the array.");
                }
                m_Chunks[index >> ShiftLength][index & ChunkMask] = value;
            }
        }

        public T[] ToArray()
        {
            T[] result = new T[Length];
            int fullCount = Length;

            for (int i = 0; i < m_ChunksCount; i++)
            {
                int copyCount = fullCount < ChunkSize
                    ? fullCount
                    : ChunkSize;

                Array.Copy(m_Chunks[i], 0, result, Length - fullCount, copyCount);

                fullCount -= ChunkSize;
            }
            return result;
        }
    }
}