using System;

namespace eidss.avr.Handlers.AvrEventArgs
{
    public class TabSelectionEventArgs : EventArgs, IEquatable<TabSelectionEventArgs>
    {
        private readonly bool m_QueryInfoEnabled;
        private readonly bool m_LayoutInfoEnabled;
        private readonly bool m_NewQueryEnabled;
        private readonly bool m_NewEnabled;
        private readonly bool m_CopyEnabled;
        private readonly bool m_LayotDeleteEnabled;
        private readonly bool m_QueryDeleteEnabled;
        private readonly bool m_SaveEnabled;
        private readonly bool m_CancelEnabled;
        private readonly bool m_StandardReportsEnabled;

        public TabSelectionEventArgs(bool queryInfoEnabled, bool layoutInfoEnabled,
                                     bool newQueryEnabled, bool newEnabled, bool copyEnabled,
                                     bool layoutDeleteEnabled, bool queryDeleteEnabled,
                                     bool saveEnabled, bool cancelEnabled,
                                     bool standardReportsEnabled)
        {
            m_QueryInfoEnabled = queryInfoEnabled;
            m_LayoutInfoEnabled = layoutInfoEnabled;
            m_NewEnabled = newEnabled;
            m_NewQueryEnabled = newQueryEnabled;
            m_CopyEnabled = copyEnabled;
            m_LayotDeleteEnabled = layoutDeleteEnabled;
            m_QueryDeleteEnabled = queryDeleteEnabled;
            m_SaveEnabled = saveEnabled;
            m_CancelEnabled = cancelEnabled;
            m_StandardReportsEnabled = standardReportsEnabled;
        }

        public bool LayoutInfoEnabled
        {
            get { return m_LayoutInfoEnabled; }
        }

        public bool QueryInfoEnabled
        {
            get { return m_QueryInfoEnabled; }
        }

        public bool NewQueryEnabled
        {
            get { return m_NewQueryEnabled; }
        }

        public bool NewEnabled
        {
            get { return m_NewEnabled; }
        }

        public bool CopyEnabled
        {
            get { return m_CopyEnabled; }
        }

        public bool LayoutDeleteEnabled
        {
            get { return m_LayotDeleteEnabled; }
        }

        public bool QueryDeleteEnabled
        {
            get { return m_QueryDeleteEnabled; }
        }

        public bool SaveEnabled
        {
            get { return m_SaveEnabled; }
        }

        public bool CancelEnabled
        {
            get { return m_CancelEnabled; }
        }

        public bool StandardReportsEnabled
        {
            get { return m_StandardReportsEnabled; }
        }

        public static TabSelectionEventArgs GridArgs
        {
            get { return new TabSelectionEventArgs(true, true, true, true, true, true, true, true, true, true); }
        }

        public static TabSelectionEventArgs ReadOnlyGridArgs
        {
            get { return new TabSelectionEventArgs(true, true, true, true, true, false, true, true, true, true); }
        }

        public static TabSelectionEventArgs EmptyGridArgs
        {
            get { return new TabSelectionEventArgs(true, true, true, true, false, false, true, false, false, true); }
        }

        public static TabSelectionEventArgs ChartMapArgs
        {
            get { return new TabSelectionEventArgs(false, false, false, false, false, false, false, true, true, false); }
        }

        public static TabSelectionEventArgs ReportArgs
        {
            get { return new TabSelectionEventArgs(false, true, false, false, false, false, false, true, true, false); }
        }

        public static TabSelectionEventArgs EmptyQueryArgs
        {
            get { return new TabSelectionEventArgs(true, true, true, false, false, false, false, true, true, true); }
        }
 

        public bool Equals(TabSelectionEventArgs args)
        {
            if (ReferenceEquals(null, args))
                return false;
            if (ReferenceEquals(this, args))
                return true;

            return (CancelEnabled == args.CancelEnabled) &&
                   (CopyEnabled == args.CopyEnabled) &&
                   (LayoutInfoEnabled == args.LayoutInfoEnabled) &&
                   (LayoutDeleteEnabled == args.LayoutDeleteEnabled) &&
                   (NewEnabled == args.NewEnabled) &&
                   (QueryDeleteEnabled == args.QueryDeleteEnabled) &&
                   (SaveEnabled == args.SaveEnabled);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != typeof (TabSelectionEventArgs))
                return false;
            return Equals((TabSelectionEventArgs) obj);
        }

        public override int GetHashCode()
        {
            return CancelEnabled.GetHashCode() + CopyEnabled.GetHashCode() + LayoutInfoEnabled.GetHashCode() +
                   LayoutDeleteEnabled.GetHashCode() + NewEnabled.GetHashCode() + QueryDeleteEnabled.GetHashCode() +
                   SaveEnabled.GetHashCode();
        }

        public static bool operator ==(TabSelectionEventArgs left, TabSelectionEventArgs right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TabSelectionEventArgs left, TabSelectionEventArgs right)
        {
            return !Equals(left, right);
        }

        public static TabSelectionEventArgs operator &(TabSelectionEventArgs left, TabSelectionEventArgs right)
        {
            if (ReferenceEquals(null, left))
                return right;
            if (ReferenceEquals(null, right))
                return left;
            return new TabSelectionEventArgs(left.QueryInfoEnabled & right.QueryInfoEnabled,
                                             left.LayoutInfoEnabled & right.LayoutInfoEnabled,
                                             left.NewQueryEnabled & right.NewQueryEnabled,
                                             left.NewEnabled & right.NewEnabled,
                                             left.CopyEnabled & right.CopyEnabled,
                                             left.LayoutDeleteEnabled & right.LayoutDeleteEnabled,
                                             left.QueryDeleteEnabled & right.QueryDeleteEnabled,
                                             left.SaveEnabled & right.SaveEnabled,
                                             left.CancelEnabled & right.CancelEnabled,
                                             left.StandardReportsEnabled & right.StandardReportsEnabled);
        }

        public static TabSelectionEventArgs operator |(TabSelectionEventArgs left, TabSelectionEventArgs right)
        {
            if (ReferenceEquals(null, left))
                return right;
            if (ReferenceEquals(null, right))
                return left;
            return new TabSelectionEventArgs(left.QueryInfoEnabled | right.QueryInfoEnabled,
                                             left.LayoutInfoEnabled | right.LayoutInfoEnabled,
                                              left.NewQueryEnabled | right.NewQueryEnabled,
                                             left.NewEnabled | right.NewEnabled,
                                             left.CopyEnabled | right.CopyEnabled,
                                             left.LayoutDeleteEnabled | right.LayoutDeleteEnabled,
                                             left.QueryDeleteEnabled | right.QueryDeleteEnabled,
                                             left.SaveEnabled | right.SaveEnabled,
                                             left.CancelEnabled | right.CancelEnabled,
                                             left.StandardReportsEnabled | right.StandardReportsEnabled);
        }
    }
}