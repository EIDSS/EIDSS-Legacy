using System;
using System.Data;
using System.IO;
using EIDSS.RAM;
using EIDSS.RAM.Presenters.Base;
using EIDSS.RAM_DB.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock2;

namespace bv.tests.AVR.Helpers
{
    public static class DataHelper
    {
        public static void CheckAndDeleteFile(string ext)
        {
            Assert.IsTrue(File.Exists("file." + ext), "Grid does not exported to " + ext);
            File.Delete("file." + ext);
        }

        public static DataTable GenerateTestTable()
        {
            var dataTable = new DataTable("testTable");
            dataTable.Columns.Add(GenerateColumn("sflHC_PatientAge", typeof(long)));
            dataTable.Columns.Add(GenerateColumn("sflHC_PatientDOB", typeof(DateTime)));
            dataTable.Columns.Add(GenerateColumn("sflHC_CaseID", typeof(string)));
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

        public static T GetView<T>(Mockery mocks) where T : IView
        {
            var view = mocks.NewMock<T>();
            Expect.Once.On(view).EventAdd("SendCommand", Is.Anything);
            Expect.Once.On(view).SetProperty("DBService");

            return view;
        }

        public static T GetPresenter<T>(IView view) where T : BaseRamPresenter
        {
            BaseRamPresenter ramPresenter = PresenterFactory.SharedPresenter[view];
            Console.WriteLine(ramPresenter);
            Assert.IsTrue(ramPresenter is T);
            return ramPresenter as T;
        }
    }
}