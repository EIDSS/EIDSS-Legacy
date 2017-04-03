using System;
using bv.common;
using bv.common.win;
using EIDSS.Tests.Core;
using NUnit.Framework;
namespace EIDSS.Tests.CommonForms
{
    [TestFixture]
    public class ErrorFormTest
    {
        [Test, Ignore("manual test")]
        public void MessageDirectTest()
        {
            ErrorForm.ShowMessageDirect("Test");
        }
        [Test, Ignore("manual test")]
        public void MessageTest()
        {
            ErrorForm.ShowMessage("Test", "Default Test String");
        }
        [Test, Ignore("manual test")]
        public void ErrorTest()
        {
            ErrorForm.ShowMode = ErrorFormShowMode.ShowInUnitTest;
            ErrorForm.ShowError(new ErrorMessage("TestError", "Default Test Error String"));
            Exception ex = new Exception("Test Error");
            ErrorForm.ShowError(new ErrorMessage("TestError", "Default Test Error String", ex));
            ErrorForm.ShowErrorDirect("TestError",null);
            ErrorForm.ShowErrorDirect("Test Error [{0}]", "Description");
        }
    }
}