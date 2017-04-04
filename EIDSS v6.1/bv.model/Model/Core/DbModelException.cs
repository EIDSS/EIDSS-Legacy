using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using System.Data.SqlClient;

namespace bv.model.Model.Core
{
    public class DbModelException : BvModelException
    {
        public string MessageId { get; private set; }
        public IObject Obj { get; private set; }
        public DbModelException(IObject obj, string msgId, Exception inner)
            : base(null, inner)
        {
            Obj = obj;
            MessageId = msgId;
        }
        public DbModelException(IObject obj, string msg, string msgId, Exception inner)
            : base(msg, inner)
        {
            Obj = obj;
            MessageId = msgId;
        }


        public static bool IsDeadlockException(Exception e)
        {
            if (e is DbModelDeadlockException)
            {
                return true;
            }
            if (e is DataException)
            {
                return (e as DataException).Number == 1205;
            }
            if (e is SqlException)
            {
                return (e as SqlException).Number == 1205;
            }
            return false;
        }

        public static DbModelException Create(IObject obj, DataException e)
        {
            switch (e.Number)
            {
                case null:
                    //-2146233087
                    return new DbModelConnectionException(obj, e);
                case -1: // connection
                case 11:
                case 19:
                case 17142:
                    return new DbModelConnectionException(obj, e);
                case 17:
                    return new DbModelDoesNotExistsException(obj, e);
                case -2: // timeout
                    return new DbModelTimeoutException(obj, e);
                case 1205: // deadlock
                    return new DbModelDeadlockException(obj, e);
                case 50000: // raiserror from sp
                    return new DbModelRaiserrorException(obj, e.Message, e);
            }
            return new DbModelException(obj, e.Message, "", e);
        }
        public static DbModelException Create(IObject obj, SqlException e)
        {
            switch (e.Number)
            {
                case 0:
                    //-2146233087
                    return new DbModelConnectionException(obj, e);
                case -1: // connection
                case 11:
                case 19:
                case 17142:
                    return new DbModelConnectionException(obj, e);
                case 17:
                    return new DbModelDoesNotExistsException(obj, e);
                case -2: // timeout
                    return new DbModelTimeoutException(obj, e);
                case 1205: // deadlock
                    return new DbModelDeadlockException(obj, e);
                case 50000: // raiserror from sp
                    return new DbModelRaiserrorException(obj, e.Message, e);
            }
            return new DbModelException(obj, e.Message, "", e);
        }
    }

    public class DbModelConnectionException : DbModelException
    {
        public DbModelConnectionException(IObject obj, Exception inner)
            : base(obj, "errGeneralNetworkError", inner)
        {
        }
    }

    public class DbModelDoesNotExistsException : DbModelException
    {
        public DbModelDoesNotExistsException(IObject obj, Exception inner)
            : base(obj, "errSqlServerDoesntExist", inner)
        {
        }
    }

    public class DbModelTimeoutException : DbModelException
    {
        public DbModelTimeoutException(IObject obj, Exception inner)
            : base(obj, "msgTimeoutList", inner)
        {
        }
    }

    public class DbModelDeadlockException : DbModelException
    {
        public DbModelDeadlockException(IObject obj, Exception inner)
            : base(obj, "msgIdDeadlock", inner)
        {
        }
    }

    public class DbModelRaiserrorException : DbModelException
    {
        public DbModelRaiserrorException(IObject obj, string msgId, Exception inner)
            : base(obj, msgId, inner)
        {
        }
    }

}
