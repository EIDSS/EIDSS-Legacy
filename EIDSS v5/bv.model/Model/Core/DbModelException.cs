using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;

namespace bv.model.Model.Core
{
    public class DbModelException : BvModelException
    {
        public string MessageId { get; private set; }
        public DbModelException(string msgId, Exception inner)
            : base(null, inner)
        {
            MessageId = msgId;
        }
        public DbModelException(string msg, string msgId, Exception inner)
            : base(msg, inner)
        {
            MessageId = msgId;
        }

        public static DbModelException Create(DataException e)
        {
            switch (e.Number)
            {
                case null:
                    //-2146233087
                    return new DbModelConnectionException(e);
                case -1: // connection
                case 11:
                case 19:
                case 17142: 
                    return new DbModelConnectionException(e);
                case 17:
                    return new DbModelDoesNotExistsException(e);
                case -2: // timeout
                    return new DbModelTimeoutException(e);
                case 1205: // deadlock
                    return new DbModelDeadlockException(e);
                case 50000: // raiserror from sp
                    return new DbModelRaiserrorException(e.Message, e);
            }
            return new DbModelException(e.Message, "", e);
        }
    }

    public class DbModelConnectionException : DbModelException
    {
        public DbModelConnectionException(Exception inner)
            : base("errGeneralNetworkError", inner)
        {
        }
    }

    public class DbModelDoesNotExistsException : DbModelException
    {
        public DbModelDoesNotExistsException(Exception inner)
            : base("errSqlServerDoesntExist", inner)
        {
        }
    }

    public class DbModelTimeoutException : DbModelException
    {
        public DbModelTimeoutException(Exception inner)
            : base("msgTimeoutList", inner)
        {
        }
    }

    public class DbModelDeadlockException : DbModelException
    {
        public DbModelDeadlockException(Exception inner)
            : base("msgIdDeadlock", inner)
        {
        }
    }

    public class DbModelRaiserrorException : DbModelException
    {
        public DbModelRaiserrorException(string msgId, Exception inner)
            : base(msgId, inner)
        {
        }
    }

}
