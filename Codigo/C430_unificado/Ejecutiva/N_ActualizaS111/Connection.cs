using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_ActualizaS111
{
    public class Connection : ServiceUtilsCaller, IDisposable
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Connection() : base(true) { }

        /// <summary>
        /// Constructor
        /// </summary>
        public Connection(bool useNetworkService) : base(useNetworkService) { }

        /// <summary>
        /// Constructor
        /// </summary>
        public Connection(string connection)
            : this(true)
        {
            ConnectionId = connection;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Connection(string connection, bool useNetworkService)
            : base(useNetworkService)
        {
            ConnectionId = connection;
        }

        private IDBService DBServiceClient
        {
            get { return Utils.DBService; }
        }

        public CursorLocationEnum CursorLocation { get; set; }

        public string ConnectionString
        {
            get;
            set;
        }

        public int CommandTimeout
        {
            get;
            set;
        }

        string _conId = "";
        public string ConnectionId
        {
            get
            {
                return _conId;
            }
            set
            {
                _conId = value;
            }
        }

        public int ConnectionTimeout
        {
            get;
            set;
        }

        public string DefaultDatabase
        {
            get;
            set;
        }

        public DataTable Execute(string commandString)
        {
            DataTable result = new DataTable(_useNetworkService);

            if (!string.IsNullOrEmpty(commandString))
            {
                result.Open(commandString, ConnectionId);
                if (ExecuteComplete != null)
                {
                    EventStatusEnum status = EventStatusEnum.adStatusOK;
                    ExecuteComplete(result.RecordCount, null, ref status, result._dbCommandRecordset, result, result.ActiveConnection);
                }
            }

            return result;
        }

        public DBCommand CreateCommand()
        {
            return new DBCommand(_useNetworkService);
        }

        public int RecordsAffected
        {
            get;
            internal set;
        }

        public void Dispose()
        {
        }

        public delegate void ExecuteCompleteEventHandler(int RecordsAffected, object pError, ref Artinsoft.Silverlight.Data.EventStatusEnum status,
            Artinsoft.Silverlight.Data.DBCommand pCommand, Artinsoft.Silverlight.Data.DataTable pRecordset,
            Artinsoft.Silverlight.Data.Connection pConnection);

        public event ExecuteCompleteEventHandler ExecuteComplete = null;

        public delegate void WillExecuteEventHandler(ref string Source, ref Artinsoft.Silverlight.Data.CursorTypeEnum CursorType,
            ref Artinsoft.Silverlight.Data.LockTypeEnum LockType, ref int Options, ref object adStatus,
            Artinsoft.Silverlight.Data.DBCommand pCommand, Artinsoft.Silverlight.Data.DataTable pRecordset,
            Artinsoft.Silverlight.Data.Connection pConnection);

        public event WillExecuteEventHandler WillExecute;

        public delegate void ConnectCompleteEventHandler(object pError, ref Artinsoft.Silverlight.Data.EventStatusEnum adStatus, Artinsoft.Silverlight.Data.Connection pConnection);
        public event ConnectCompleteEventHandler ConnectComplete;

        public delegate void DisconnectEventHandler(ref Artinsoft.Silverlight.Data.EventStatusEnum adStatus, Artinsoft.Silverlight.Data.Connection pConnection);
        public event DisconnectEventHandler Disconnect;
    }
}
