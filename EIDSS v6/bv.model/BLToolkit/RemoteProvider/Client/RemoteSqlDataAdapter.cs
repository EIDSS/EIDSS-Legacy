using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using bv.model.BLToolkit.RemoteProvider.Client;

namespace BLToolkit.Data.DataProvider
{
    public class RemoteSqlDataAdapter : DbDataAdapter, IDbDataAdapter
    {
        private RemoteSqlCommand selectCommand;
        private RemoteSqlCommand insertCommand;
        private RemoteSqlCommand deleteCommand;
        private RemoteSqlCommand updateCommand;

        static private readonly object EventRowUpdated = new object();
        static private readonly object EventRowUpdating = new object();

        public RemoteSqlDataAdapter()
        { }

        #region Properties
        public new RemoteSqlCommand SelectCommand
        {
            get
            {
                return selectCommand;
            }
            set
            {
                selectCommand = value;
            }
        }

        IDbCommand IDbDataAdapter.SelectCommand
        {
            get
            {
                return selectCommand;
            }
            set
            {
                selectCommand = (RemoteSqlCommand)value;
            }
        }

        public new RemoteSqlCommand InsertCommand
        {
            get
            {
                return insertCommand;
            }
            set
            {
                insertCommand = value;
            }
        }

        IDbCommand IDbDataAdapter.InsertCommand
        {
            get
            {
                return insertCommand;
            }
            set
            {
                insertCommand = (RemoteSqlCommand)value;
            }
        }

        public new RemoteSqlCommand UpdateCommand
        {
            get
            {
                return updateCommand;
            }
            set
            {
                updateCommand = value;
            }
        }

        IDbCommand IDbDataAdapter.UpdateCommand
        {
            get
            {
                return updateCommand;
            }
            set
            {
                updateCommand = (RemoteSqlCommand)value;
            }
        }

        public new RemoteSqlCommand DeleteCommand
        {
            get
            {
                return deleteCommand;
            }
            set
            {
                deleteCommand = value;
            }
        }

        IDbCommand IDbDataAdapter.DeleteCommand
        {
            get
            {
                return deleteCommand;
            }
            set
            {
                deleteCommand = (RemoteSqlCommand)value;
            }
        }
        #endregion

        override protected RowUpdatedEventArgs CreateRowUpdatedEvent(DataRow dataRow,
          IDbCommand command, StatementType statementType, DataTableMapping tableMapping)
        {
            return new RemoteSqlRowUpdatedEventArgs(dataRow, command, statementType,
            tableMapping);
        }

        override protected RowUpdatingEventArgs CreateRowUpdatingEvent(DataRow dataRow,
          IDbCommand command, StatementType statementType, DataTableMapping tableMapping)
        {
            return new RemoteSqlRowUpdatingEventArgs(dataRow, command, statementType, tableMapping);
        }

        override protected void OnRowUpdating(RowUpdatingEventArgs value)
        {
            RemoteSqlRowUpdatingEventHandler handler =
              (RemoteSqlRowUpdatingEventHandler)Events[EventRowUpdating];
            if ((null != handler) && (value is RemoteSqlRowUpdatingEventArgs))
            {
                handler(this, (RemoteSqlRowUpdatingEventArgs)value);
            }
        }

        override protected void OnRowUpdated(RowUpdatedEventArgs value)
        {
            RemoteSqlRowUpdatedEventHandler handler =
              (RemoteSqlRowUpdatedEventHandler)Events[EventRowUpdated];
            if ((null != handler) && (value is RemoteSqlRowUpdatedEventArgs))
            {
                handler(this, (RemoteSqlRowUpdatedEventArgs)value);
            }
        }

        public event RemoteSqlRowUpdatingEventHandler RowUpdating
        {
            add { Events.AddHandler(EventRowUpdating, value); }
            remove { Events.RemoveHandler(EventRowUpdating, value); }
        }

        public event RemoteSqlRowUpdatedEventHandler RowUpdated
        {
            add { Events.AddHandler(EventRowUpdated, value); }
            remove { Events.RemoveHandler(EventRowUpdated, value); }
        }
    }

    public delegate
       void RemoteSqlRowUpdatingEventHandler(object sender, RemoteSqlRowUpdatingEventArgs e);
    public delegate
       void RemoteSqlRowUpdatedEventHandler(object sender, RemoteSqlRowUpdatedEventArgs e);

    public class RemoteSqlRowUpdatingEventArgs : RowUpdatingEventArgs
    {
        public RemoteSqlRowUpdatingEventArgs(DataRow row, IDbCommand command,
           StatementType statementType, DataTableMapping tableMapping)
            : base(row, command, statementType, tableMapping)
        {
        }

        // Hide the inherited implementation of the command property.
        new public RemoteSqlCommand Command
        {
            get { return (RemoteSqlCommand)base.Command; }
            set { base.Command = value; }
        }
    }

    public class RemoteSqlRowUpdatedEventArgs : RowUpdatedEventArgs
    {
        public RemoteSqlRowUpdatedEventArgs(DataRow row, IDbCommand command,
          StatementType statementType, DataTableMapping tableMapping)
            : base(row, command, statementType, tableMapping)
        {
        }

        // Hide the inherited implementation of the command property.
        new public RemoteSqlCommand Command
        {
            get { return (RemoteSqlCommand)base.Command; }
        }
    }
}
