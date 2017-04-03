using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using bv.common.db.Core;
using DevExpress.XtraEditors;
using NUnit.Framework;
using GlobalSettings = bv.common.GlobalSettings;
namespace EIDSS.Tests.CommonForms
{
    [TestFixture]
    public class LookupBinder
    {
        [SetUp]
        public void Init()
        {
            GlobalSettings.Init("test", "test", "test");
        }
        [TearDown]
        public void TearDown()
        {
            GC.Collect();
        }

        [Test]
        public void TextBinderTest()
        {
            SqlDataAdapter da = new SqlDataAdapter("select CAST('test' as nvarchar(200)) as StringField, Cast(1 as int) as IntField", (SqlConnection)ConnectionManager.DefaultInstance.Connection);
            DataSet ds =new DataSet();
            da.FillSchema( ds, SchemaType.Mapped, "TestTable");
            da.Fill(ds, "TestTable");
            TextEdit txt = new TextEdit();
            EIDSS.Core.LookupBinder.BindTextEdit(txt, ds, "TestTable.StringField");
            Assert.AreEqual(200, txt.Properties.MaxLength);
            txt.Properties.MaxLength = -1;
            EIDSS.Core.LookupBinder.BindTextEdit(txt, ds, "TestTable.IntField");
            Assert.AreEqual(-1, txt.Properties.MaxLength);
        }
        
    }
}