using System.Data;

namespace eidss.avr.db.DBService
{
    public class Chart_DB : BaseAvrDbService
    {
        public Chart_DB()
        {
            ObjectName = @"AsLayout";
        }

        //теперь напрямую загрузки из БД нет. 

        public override bool PostDetail(DataSet dataSet, int postType, IDbTransaction transaction = null)
        {
            //теперь напрямую сохранения в БД нет. Сохраняется в составе родительского объекта

            return true;
        }
    }
}