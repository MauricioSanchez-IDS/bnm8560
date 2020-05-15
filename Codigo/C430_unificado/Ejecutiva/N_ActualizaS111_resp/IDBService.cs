using System;
using System.ServiceModel;
using System.Collections.Generic;

namespace N_ActualizaS111
{
    public interface IDBService
    {
        #region Connection - Services

        [OperationContract]
        int ExecuteFromConnection(string connectionId, string commandString);

        #endregion

        #region Command - Services

        [OperationContract]
        CommandState ExecuteFromCommand(string connectionId, ref CommandState st, out string tableName, ref DataColumnValues[] rows, ref DataColumn[] columns, ref DBParameter[] parameters, string[] sqlCommands = null);

        [OperationContract]
        CommandState ExecuteNextFromCommand(ref CommandState st, ref DataColumnValues[] rows, long rowsCount, bool ignoreBufferSize);

        [OperationContract]
        void AddNew(string connectionId, String sqlText, DataColumn[] columns, object[] values);

        #endregion

        #region Data Change - Services

        void ExecuteChanges(string connectionId, string tableName, DataColumn[] fields, Dictionary<int, object>[] updated,
            object[][] inserted, object[][] deleted);

        #endregion
    }
}
