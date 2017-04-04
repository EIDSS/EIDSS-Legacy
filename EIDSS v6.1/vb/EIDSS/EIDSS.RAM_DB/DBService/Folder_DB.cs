using System.Data;
using eidss.model.Avr.Tree;
using eidss.model.Enums;

namespace eidss.avr.db.DBService
{
    public class Folder_DB : BaseAvrDbService
    {
        public Folder_DB()
        {
            ObjectName = @"AsFolder";
        }

        public override AvrTreeElementType ElementType
        {
            get { return AvrTreeElementType.Folder; }
        }

        // Note: No need to implement Get and post folder here because new framework do this
        // Use AvrQueryLayoutTreeDbHelper methods

        public override bool PostDetail(DataSet dataSet, int postType, IDbTransaction transaction = null)
        {
            //теперь напрямую сохранения в БД нет. Сохраняется в составе родительского объекта

            return true;
        }
        #region Publish Unpublish
        protected override long Unpublish(long publishedId, IDbTransaction transaction)
        {
            long id;
            using (IDbCommand cmd = CreateSPCommand("spAsFolderUnpublish", transaction))
            {
                AddAndCheckParam(cmd, "@idfsLayoutFolder", publishedId);
                AddTypedParam(cmd, "@idflLayoutFolder", SqlDbType.BigInt, ParameterDirection.Output);
                cmd.ExecuteNonQuery();
                id = (long)GetParamValue(cmd, "@idflLayoutFolder");
            }

            AfterPublishUnpublish(EventType.AVRLayoutFolderUnpublishedLocal, id, publishedId, transaction);
            return id;
        }

        protected override long Publish(long id, IDbTransaction transaction)
        {
            long publishedId;
            using (IDbCommand cmd = CreateSPCommand("spAsFolderPublish", transaction))
            {
                AddAndCheckParam(cmd, "@idflLayoutFolder", id);
                AddTypedParam(cmd, "@idfsLayoutFolder", SqlDbType.BigInt, ParameterDirection.Output);

                cmd.ExecuteNonQuery();
                publishedId = (long) GetParamValue(cmd, "@idfsLayoutFolder");
            }

            AfterPublishUnpublish(EventType.AVRLayoutFolderPublishedLocal, id, publishedId, transaction);
            return publishedId;
        }
        #endregion

    }
}