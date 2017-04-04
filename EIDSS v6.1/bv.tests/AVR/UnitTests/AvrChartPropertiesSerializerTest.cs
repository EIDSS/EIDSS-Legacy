using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eidss.model.Avr.Chart;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class AvrChartPropertiesSerializerTest

    {
        [TestMethod]
        public void SerializeTest()
        {
            var properties = new AvrChartProperties
                {
                    Title =
                        {
                            Text = "This is test"
                        }
                };
            properties.Title.Font.TextColorArgb = Color.Red.ToArgb();

            Assert.AreEqual(properties.Title.Font.TextColorArgb, properties.Title.Font.TextColor.ToArgb());

            var xml = AvrChartPropertiesSerializer.Serialize(properties);
            Console.WriteLine("Serialized AvrChartProperties:");
            Console.WriteLine(xml);

            var deserializedProperties = AvrChartPropertiesSerializer.Deserialize(xml);

            Assert.AreEqual(properties.Title.Text, deserializedProperties.Title.Text);
            Assert.AreEqual(properties.Title.Font.TextColorArgb, deserializedProperties.Title.Font.TextColorArgb);
            Assert.AreEqual(Color.Red.ToArgb(), deserializedProperties.Title.Font.TextColorArgb);
            
        }

        [TestMethod]
        public void FontPropertiesTest()
        {
            var fp = new FontProperties {TextColorArgb = Color.Red.ToArgb()};
            fp.IsBold = fp.IsItalic = fp.IsUnderline = true;
            var font = fp.ToFont();
            Assert.IsNotNull(font);
        }

        [TestMethod]
        public void FlagTest()
        {
            var t = new TitleProperties();
            Assert.IsFalse(t.TextWasChanged);
            Assert.IsTrue(t.Text == String.Empty);
            t.Text = String.Empty;
            Assert.IsFalse(t.TextWasChanged);
            t.Text = "test";
            Assert.IsTrue(t.TextWasChanged);
        }
        
    }
}