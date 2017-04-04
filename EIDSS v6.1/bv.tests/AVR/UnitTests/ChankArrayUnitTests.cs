using System;
using System.IO;
using eidss.model.AVR.SourceData;
using eidss.model.WindowsService.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class ChankArrayUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void ChunkArrayFailConstructorTest()
        {
            new ChunkArray<int>(-1);
        }

        [TestMethod]
        [ExpectedException(typeof (IndexOutOfRangeException))]
        public void ChunkArrayFailRange1Test()
        {
            var array = new ChunkArray<int>(1);
            array[1] = 1;
        }

        [TestMethod]
        [ExpectedException(typeof (IndexOutOfRangeException))]
        public void ChunkArrayFailRange2Test()
        {
            var array = new ChunkArray<int>(1);
            array[-1] = 1;
        }

        [TestMethod]
        public void ChunkArrayShortTest()
        {
            ChunkArray<int> array = new ChunkArray<int>(0);
            Assert.AreEqual(0, array.Length);

            array = new ChunkArray<int>(10);

            Assert.AreEqual(10, array.Length);

            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(0, array[i]);
            }
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }
            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(i, array[i]);
            }
        }

        [TestMethod]
        public void ChunkArrayLongTest()
        {
            ChunkArray<int> array = new ChunkArray<int>(0xFFF);
            Assert.AreEqual(0xFFF, array.Length);
            array[0xFFE] = 1;
            Assert.AreEqual(1, array[0xFFE]);

            array = new ChunkArray<int>(0x1000);
            Assert.AreEqual(0x1000, array.Length);
            array[0xFFF] = 1;
            Assert.AreEqual(1, array[0xFFF]);

            array = new ChunkArray<int>(0x1001);
            Assert.AreEqual(0x1001, array.Length);
            array[0x1000] = 1;
            Assert.AreEqual(1, array[0x1000]);
        }

        [TestMethod]
        public void ChunkByteArrayLongTest()
        {
            var array = new ChunkByteArray(0x10000);
            Assert.AreEqual(0x10000, array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (byte) i;
            }
            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(array[i], (byte) i);
            }
        }

        [TestMethod]
        public void ChunkByteArrayConstructorTest()
        {
            var array = GetTestArray();
            var chankArray = new ChunkByteArray(array);
            Assert.AreEqual(array.Length, chankArray.Length);
            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(array[i], chankArray[i]);
            }
        }

        [TestMethod]
        public void ChunkCopyToArrayTest()
        {
            ChunkArray<int> array = CreateAndFillChunkArray(0xFFF);
            CheckArrayCopy(array.ToArray(), 0xFFF);

            array = CreateAndFillChunkArray(0x1000);
            CheckArrayCopy(array.ToArray(), 0x1000);

            array = CreateAndFillChunkArray(0x1001);
            CheckArrayCopy(array.ToArray(), 0x1001);

            array = CreateAndFillChunkArray(0x1FFF);
            CheckArrayCopy(array.ToArray(), 0x1FFF);

            array = CreateAndFillChunkArray(0x2000);
            CheckArrayCopy(array.ToArray(), 0x2000);

            array = CreateAndFillChunkArray(0x2001);
            CheckArrayCopy(array.ToArray(), 0x2001);
        }

        [TestMethod]
        public void ChunkByteArrayToStreamTest()
        {
            var array = GetTestArray();

            ChunkByteArray chankArray;
            using (MemoryStream stream = new MemoryStream(array))
            {
                chankArray = new ChunkByteArray((int) stream.Length);
                int readed = stream.Read(chankArray, 0, (int) stream.Length);
                Assert.AreEqual(stream.Length, readed, "not all bytes readed");
                Assert.AreEqual(chankArray.Length, readed);
            }
            Assert.AreEqual(array.Length, chankArray.Length);
            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(array[i], chankArray[i]);
            }
        }

        [TestMethod]
        public void ChunkByteArrayFromStreamTest()
        {
            ChunkByteArray chankArray = new ChunkByteArray(GetTestArray());
            byte[] array = new byte[chankArray.Length];
            using (Stream stream = new MemoryStream(chankArray.Length))
            {
                stream.Write(chankArray, 0, chankArray.Length);

                stream.Flush();
                stream.Seek(0, SeekOrigin.Begin);

                int readed = stream.Read(array, 0, (int) stream.Length);
                Assert.AreEqual(stream.Length, readed, "not all bytes readed");
                Assert.AreEqual(array.Length, readed);
            }

            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(chankArray[i], array[i]);
            }
        }

        private static ChunkArray<int> CreateAndFillChunkArray(int length)
        {
            ChunkArray<int> array = new ChunkArray<int>(length);
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }
            return array;
        }

        private static void CheckArrayCopy(int[] array, int length)
        {
            Assert.AreEqual(length, array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(i, array[i]);
            }
        }

        private static byte[] GetTestArray()
        {
            var array = new byte[0x10000];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (byte) i;
            }
            return array;
        }
    }
}