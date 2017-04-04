using System;
using System.Threading;
using bv.common.Core;
using eidss.avr.BaseComponents;

namespace eidss.avr
{
    public static class PresenterFactory
    {
        private static readonly object m_SyncRoot = new object();
        private static SharedPresenter m_SharedPresenter;
        
        public static SharedPresenter SharedPresenter
        {
            get
            {
                if (m_SharedPresenter == null)
                {
                    throw new AvrException(
                        "SharedPresenter is not initialized. Yout should call BeginSharedPresenterTransaction before using of SharedPresenter");
                }

                return m_SharedPresenter;
            }
        }

        public static IDisposable BeginSharedPresenterTransaction(StructureMap.IContainer container, IPostable parentForm)
        {
            return new SharedPresenterTransaction(container, parentForm);
        }

        public static IDisposable BeginSharedPresenterTransaction(SharedPresenter presenter)
        {
            return new SharedPresenterTransaction(presenter);
        }

        private class SharedPresenterTransaction : IDisposable
        {
            public SharedPresenterTransaction(StructureMap.IContainer container,IPostable parentForm)
            {
                Monitor.Enter(m_SyncRoot);
                m_SharedPresenter = new SharedPresenter(container, parentForm);
            }

            public SharedPresenterTransaction(SharedPresenter presenter)
            {
                Monitor.Enter(m_SyncRoot);
                m_SharedPresenter = presenter;
            }

            public void Dispose()
            {
                m_SharedPresenter = null;
                Monitor.Exit(m_SyncRoot);
            }
        }
    }
}