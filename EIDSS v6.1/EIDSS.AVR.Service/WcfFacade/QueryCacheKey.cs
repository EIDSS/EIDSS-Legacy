using System;

namespace EIDSS.AVR.Service.WcfFacade
{
    [Serializable]
    public class QueryCacheKey
    {
        public QueryCacheKey(long queryId, string lang, bool isArchive)
        {
            QueryId = queryId;
            Lang = lang;
            IsArchive = isArchive;
        }

        public long QueryId { get; set; }
        public string Lang { get; set; }
        public bool IsArchive { get; set; }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = QueryId.GetHashCode();
                hashCode = (hashCode * 397) ^ (Lang != null ? Lang.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ IsArchive.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(QueryCacheKey a, QueryCacheKey b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }
            return a.Equals(b);
        }

        public static bool operator !=(QueryCacheKey a, QueryCacheKey b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != GetType())
            {
                return false;
            }
            return Equals((QueryCacheKey) obj);
        }

        protected bool Equals(QueryCacheKey other)
        {
            return QueryId == other.QueryId && string.Equals(Lang, other.Lang) && IsArchive.Equals(other.IsArchive);
        }

        public override string ToString()
        {
            return string.Format("ID={0}, Lang={1}, IsArchive={2}", QueryId, Lang, IsArchive);
        }
    }
}