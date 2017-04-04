using System;
using System.Data;
using System.IO;
using BLToolkit.Data;
using bv.model.BLToolkit;
using eidss.avr;
using eidss.avr.BaseComponents;
using eidss.avr.db.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock2;

namespace bv.tests.AVR.Helpers
{
    public static class DataHelper
    {
        public static int GetQueryFieldsCount(long queryId)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                DbManager command = manager.SetCommand(
                    @"   select sum(t.fieldCount) from
                               (
                                     select 
	                                    case 
		                                    when sf.idfsGISReferenceType is not null then 2 else 1
	                                    end as fieldCount
                                     from tasQuerySearchField qsf
                                     inner join tasQuerySearchObject qso
                                     on qsf.idfQuerySearchObject = qso.idfQuerySearchObject
                                     inner join tasSearchField sf
                                     on sf.idfsSearchField = qsf.idfsSearchField
                                     where qso.idflQuery = @idflQuery
                                ) as t",
                    manager.Parameter("idflQuery", queryId)
                    );

                var count = (int) command.ExecuteScalar();
                return count;
            }
        }

        public static void CheckAndDeleteFile(string ext)
        {
            Assert.IsTrue(File.Exists("file." + ext), "Grid does not exported to " + ext);
            File.Delete("file." + ext);
        }

        public static DataTable GenerateTestTable()
        {
            var dataTable = new DataTable("testTable");
            dataTable.Columns.Add(GenerateColumn("sflHC_PatientAge", typeof (long)));
            dataTable.Columns.Add(GenerateColumn("sflHC_PatientDOB", typeof (DateTime)));
            dataTable.Columns.Add(GenerateColumn("sflHC_CaseID", typeof (string)));
            for (int i = 0; i <= 9; i++)
            {
                DataRow workRow = dataTable.NewRow();
                workRow[0] = i % 5;
                workRow[1] = DateTime.Now;
                workRow[2] = "test" + (i) % 3;
                dataTable.Rows.Add(workRow);
            }
            return dataTable;
        }

        public static DataColumn GenerateColumn(string name, Type dataType)
        {
            var column = new DataColumn(name) {Caption = name + "_Caption", DataType = dataType};
            return column;
        }

        public static T GetView<T>(Mockery mocks) where T : IBaseAvrView
        {
            var view = mocks.NewMock<T>();
            Expect.Once.On(view).EventAdd("SendCommand", Is.Anything);
            Expect.Once.On(view).SetProperty("DBService");

            return view;
        }

        public static T GetPresenter<T>(IBaseAvrView view) where T : BaseAvrPresenter
        {
            BaseAvrPresenter avrPresenter = PresenterFactory.SharedPresenter[view];
            Console.WriteLine(avrPresenter);
            Assert.IsTrue(avrPresenter is T);
            return avrPresenter as T;
        }
    }
}