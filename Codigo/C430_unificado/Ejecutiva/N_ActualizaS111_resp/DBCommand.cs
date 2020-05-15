using System;
using System.Collections.Generic;
//using Artinsoft.Silverlight.Client.Utils;

namespace N_ActualizaS111
{
    public class DBCommand : ServiceUtilsCaller
    {
        private Connection _connection;
        internal CommandState _commandState;

        private DataColumn[] _fields = new DataColumn[] { };

        /// <summary>
        /// Constructor
        /// </summary>
        public DBCommand() : this(true) { }

        /// <summary>
        /// Constructor
        /// </summary>
        public DBCommand(bool useNetworkService)
            : base(useNetworkService)
        {
            _commandState.Id = Guid.NewGuid();
            _commandState.BufferSize = -1;
            _commandState.CommandType = CommandTypeEnum.UnSpecified;
        }

        /*private IDBService DBServiceClient
        {
            get { return ServiceUtils.DBNetworkService; }
        }*/

        /// <summary>
        /// Gets or sets the text command to run against the data source.
        /// Returns the text command to execute. The default value is an empty string ("").
        /// </summary>
        public string CommandError
        {
            get { return _commandState.Error; }
        }

        /// <summary>
        /// Gets or sets the text command to run against the data source.
        /// Returns the text command to execute. The default value is an empty string ("").
        /// </summary>
        public string CommandText
        {
            get { return _commandState.CommandText; }
            set { _commandState.CommandText = value; }
        }

        /// <summary>
        /// Gets or sets the wait time before terminating the attempt 
        /// to execute a command and generating an error.
        /// Returns the time in seconds to wait for the command to execute.
        /// </summary>
        public int CommandTimeout
        {
            get { return _commandState.ConnectionTimeOut; }
            set { _commandState.ConnectionTimeOut = value; }
        }

        /// <summary>
        /// Indicates or specifies how the System.Data.Common.DbCommand.CommandText property is interpreted.
        /// Returns one of the CommandTypeEnum values. The default is Text.
        /// </summary>
        public CommandTypeEnum CommandType
        {
            get { return _commandState.CommandType; }
            set { _commandState.CommandType = value; }
        }

        /// <summary>
        /// Gets or sets the Connection (this connection is the one used in all DataTable operations).
        /// </summary>
        public Connection ActiveConnection
        {
            get { return _connection; }
            set
            {
                if (value == null)
                {
                    _commandState.ConnectionId = String.Empty;
                }
                else
                {
                    _commandState.ConnectionId = value.ConnectionId;
                }
                _connection = value;
            }
        }

        /// <summary>
        /// Executes the non querySQL statemen
        /// </summary>
        /// <param name="parameters">Optional. Variant array of parameter values used in conjunction with the input string or stream specified in CommandText.</param>
        /// <param name="options">Optional. Value that indicates how the provider should evaluate the CommandText.</param>
        /// <returns>Returns number of records affected.</returns>
        public int ExecuteNonQuery()
        {
            object result;
            DataTable newQuery = new DataTable(_useNetworkService);
            DBParameter[] parameters = null;
            Execute(ref newQuery, out result, ref parameters, 0);
            return (int)result;
        }

        /// <summary>
        /// Executes the query, SQL statement, or stored procedure specified in the CommandText
        /// </summary>
        /// <returns>Returns a DataTable object reference.</returns>
        public DataTable Execute(string[] sqlCommans = null)
        {
            DataTable newQuery = new DataTable(_useNetworkService);
            object recordsAffected = null;
            DBParameter[] externalParams = null;

            Execute(ref newQuery, out recordsAffected, ref externalParams, -1, sqlCommans);
            newQuery.ActiveConnection = this.ActiveConnection;
            return newQuery;
        }

        /// <summary>
        /// Executes the query, SQL statement, or stored procedure specified in the CommandText
        /// </summary>
        /// <param name="recordsAffected">Optional. Variable to which the provider returns the number of records that the operation affected.</param>
        /// <param name="options">Optional. Value that indicates how the provider should evaluate the CommandText.</param>
        /// <returns>Returns a DataTable object reference.</returns>
        public DataTable Execute(out object recordsAffected, int options, string[] sqlCommans = null)
        {
            DataTable newQuery = new DataTable(_useNetworkService);
            DBParameter[] parameters = null;
            Execute(ref newQuery, out recordsAffected, ref parameters, options, sqlCommans);
            return newQuery;
        }

        private string lastError = "";

        public string LastError
        {
            get { return lastError; }
            set { lastError = value; }
        }

        /// <summary>
        /// Internal Execute method for fill row and column data.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="recordsAffected"></param>
        /// <param name="parameters"></param>
        /// <param name="options"></param>
        internal void Execute(ref DataTable query, out object recordsAffected, ref DBParameter[] externalParameters, int options, string[] sqlCommans = null)
        {
#if PERFORMANCE_METRICS
          var start = DateTime.Now;
#endif
            lastError = "";
            query.CursorLocation = CursorLocationEnum.adUseServer;
            query._dbCommandRecordset = this;
            DataColumnValues[] _Rows = new DataColumnValues[0];
            string tableName;
            query.State = DBStateEnum.Executing;

            DBParameter[] parameters = null;
            if (externalParameters != null)
            {
                parameters = externalParameters;
            }
            else if (Parameters.Count > 0)
            {
                parameters = new DBParameter[Parameters.Count];
                Parameters.CopyTo(parameters, 0);
            }

            ProcessDBNullValuesForActualParameters(parameters);

            _commandState.BufferSize = query.MaxRecordCount;
            try
            {
                _commandState = DBServiceClient.ExecuteFromCommand(ActiveConnection.ConnectionId, ref _commandState, out tableName, ref _Rows, ref _fields, ref parameters, sqlCommans);
            }
            catch (Exception e)
            {
                lastError = e.Message;
                tableName = "Sin Nombre";
            }

            ProcessDBNullValuesForResultParameters(parameters);

            for (int index = 0; parameters != null && index < parameters.Length; index++)
            {
                if (parameters[index].Direction == ParameterDirectionEnum.InputOutput
                    || parameters[index].Direction == ParameterDirectionEnum.Output
                    || parameters[index].Direction == ParameterDirectionEnum.Return)
                {
                    Parameters[index].Value = parameters[index].Value;
                }
            }

            recordsAffected = _commandState.RecordsAffected;
            query.CursorLocation = CursorLocationEnum.adUseClient;
            query.SetTableName(tableName);
            //dataReader load rows
            query.SetSourceData(_Rows);
            if (_Rows != null && _Rows.Length > 0)
            {
                DataRow newRow = null;
                object newValue = null;
                int numberOfRows = _Rows[0].Count;
                var items = new DataRow[numberOfRows];
                for (int totalRows = 0; totalRows < numberOfRows; totalRows++)
                {
                    newRow = new DataRow(query, totalRows);
                    items[totalRows] = newRow;

                }
                ((Artinsoft.Silverlight.Client.Utils.RangeObservableCollection<DataRow>)query.Rows).AddRange(items);
            }

            query.Fields.Clear();
            //dataReader load columns
            query.Fields.AddRange(_fields);
            query.State = DBStateEnum.Open;

            if (_Rows.Length > 0)
            {
                query.UpdateRowIndex(0);
            }
            else
            {
                query.UpdateRowIndex(-1);
            }
#if PERFORMANCE_METRICS
            var end = DateTime.Now;
            Trace.Write(string.Format("DBCommand.Execute overall execution time for [{0}] is {1} milliseconds ", this.CommandText, (end - start).TotalMilliseconds));
#endif
        }

        private void ProcessDBNullValuesForResultParameters(DBParameter[] parameters)
        {
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    if ((parameter.Direction == ParameterDirectionEnum.Output)
                        && (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                }
            }
        }

        private void ProcessDBNullValuesForActualParameters(DBParameter[] parameters)
        {
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    if ((parameter.Direction == ParameterDirectionEnum.Input)
                        && (parameter.Value == DBNull.Value))
                    {
                        parameter.Value = null;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void ExecuteNextReader(DataTable table, bool ignoreBufferSize)
        {
            DataColumnValues[] _rowsNext = new DataColumnValues[0];
            if (table._dbCommandRecordset._commandState.MoreRows)
            {
                _commandState = DBServiceClient.ExecuteNextFromCommand(ref table._dbCommandRecordset._commandState, ref _rowsNext, table.Rows.Count, ignoreBufferSize);
                //dataReader load rows
                if (_rowsNext != null && _rowsNext.Length > 0)
                {
                    for (int i = 0; i < _rowsNext.Length; i++)
                    {
                        table._ColumnValues[i].Append(_rowsNext[i]);
                    }
                    int totalNewRows = _rowsNext[0].Count;
                    int totalCurrentRows = table.Rows.Count;
                    DataRow[] newrows = new DataRow[totalNewRows];
                    for (int i = 0; i < totalNewRows; i++)
                    {
                        newrows[i] = new DataRow(table, totalCurrentRows + i);
                    }
                    ((RangeObservableCollection<DataRow>)table.Rows).AddRange(newrows);

                }
            }


        }

        private DBParameterCollection _parameters = new DBParameterCollection();
        public DBParameterCollection Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="direction"></param>
        /// <param name="size"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public DBParameter CreateParameter(string name = "", Artinsoft.Silverlight.Data.TypeCodeEnum type = Artinsoft.Silverlight.Data.TypeCodeEnum.Empty, Artinsoft.Silverlight.Data.ParameterDirectionEnum direction = ParameterDirectionEnum.Input, int size = 0, object value = null)
        {
            DBParameter res = new DBParameter();
            res.Name = name;
            res.Type = type;
            res.Direction = direction;
            res.Size = size;
            res.Value = (value == null || value == Type.Missing) ? null : value;
            return res;
        }
    }
}
