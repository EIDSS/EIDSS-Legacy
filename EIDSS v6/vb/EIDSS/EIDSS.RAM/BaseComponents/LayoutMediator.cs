using System.Data;
using bv.common.Core;
using eidss.avr.db.DBService.DataSource;
using eidss.model.AVR.Db;

namespace eidss.avr.BaseComponents
{
    public class LayoutMediator
    { 
        private readonly RelatedObjectPresenter m_ParentPresenter;

        public LayoutMediator(RelatedObjectPresenter parentPresenter)
        {
            Utils.CheckNotNull(parentPresenter, "parentPresenter");

            m_ParentPresenter = parentPresenter;
        }

        private DataSet BaseDataSet
        {
            get
            {
                DataSet dataSet = m_ParentPresenter.RelatedObjectView.baseDataSet;
                if (dataSet == null)
                {
                    throw new AvrException(string.Format("Dataset of view {0} is not initialized",
                                                         m_ParentPresenter.RelatedObjectView));
                }
                return dataSet;
            }
        }

        public LayoutDetailDataSet LayoutDataSet
        {
            get
            {
                if (!(BaseDataSet is LayoutDetailDataSet))
                {
                    throw new AvrDbException(string.Format("Presenter should have dataset of type {0}",
                                                           typeof (LayoutDetailDataSet)));
                }
                return (LayoutDetailDataSet) BaseDataSet;
            }
        }

        public LayoutDetailDataSet.LayoutDataTable LayoutTable
        {
            get { return LayoutDataSet.Layout; }
        }

        public LayoutDetailDataSet.LayoutRow LayoutRow
        {
            get
            {
                if (LayoutTable.Count == 0)
                {
                    throw new AvrDbException("Table Layout of BaseDataSet is empty");
                }

                return (LayoutDetailDataSet.LayoutRow) LayoutDataSet.Layout.Rows[0];
            }
        }
    }
}