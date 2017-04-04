using EIDSS.Reports.BaseControls.Form;
using NUnit.Framework;
using GlobalSettings=bv.common.GlobalSettings;

namespace EIDSS.Tests.Barcode
{
    [TestFixture]
    public class BarcodeFormTests : BaseTests
    {
        #region Setup/Teardown

        [TestFixtureSetUp]
        public override void FixtureSetUp()
        {
            base.FixtureSetUp();
            GlobalSettings.BarcodePrinter = "ZDesigner R2844-Z";
        }

        #endregion

        [Test]
        public void ConstructorTest()
        {
            new BarCodeForm();
        }

        [Test]
        public void ShowTest()
        {
            BarCodeForm form = new BarCodeForm();
            form.Show();
            form.Close();
        }

        [Test]
        public void ShowSampleWithTypeTest()
        {
            BarCodeForm form = new BarCodeForm(NumberingObject.Specimen, null);
            form.Show();
            form.Close();
        }

        [Test]
        public void ShowSampleWithIdTest()
        {
            BarCodeForm form = new BarCodeForm(NumberingObject.Specimen, 72520000000);
            form.Show();
            form.Close();
        }


        [Test]
        public void ShowFreezerWithIdTest()
        {
            BarCodeForm form = new BarCodeForm(NumberingObject.FreezerBarcode, 72930000000);
            form.Show();
            form.Close();
            form = new BarCodeForm(NumberingObject.FreezerBarcode, 72940000000);
            form.Show();
            form.Close();
        }
    }
}