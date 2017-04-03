using bv.common.Core;
using EIDSS.RAM.Presenters;

namespace EIDSS.RAM
{
    public static class PresenterFactory
    {
        private static SharedPresenter m_SharedPresenter;

        public static SharedPresenter SharedPresenter
        {
            get
            {
                if (m_SharedPresenter == null)
                {
                    throw new RamException("m_SharedPresenter is not initialized");
                }

                return m_SharedPresenter;
            }
        }

        public static void Init(IPostable parentForm)
        {
            m_SharedPresenter = new SharedPresenter(parentForm);
        }

        public static void RemovePresenterLink(SharedPresenter presenter)
        {
            if (ReferenceEquals(m_SharedPresenter, presenter))
            {
                m_SharedPresenter = null;
            }
        }
       
    }
}