using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_ActualizaS111
{
    public static class ServiceUtils
    {
        private static IDBService _dbNetworkService;
        private static IDBService _dbLocalService;
        private static readonly Object _thisNetworkLock = new Object();
        private static readonly Object _thisLocalLock = new Object();

        /// <summary>
        /// Gets an Sets The Network Server Service Reference instance.
        /// </summary>
        public static IDBService DBNetworkService
        {
            get
            {
                lock (_thisNetworkLock)
                {
                    return _dbNetworkService;
                }
            }
            set
            {
                lock (_thisNetworkLock)
                {
                    if (_dbNetworkService != null) throw new NotSupportedException();
                    _dbNetworkService = value;
                }
            }
        }


        /// <summary>
        /// Gets an Sets The Network Server Service Reference instance.
        /// </summary>
        public static IDBService DBLocalService
        {
            get
            {
                lock (_thisLocalLock)
                {
                    return _dbLocalService;
                }
            }
            set
            {
                lock (_thisLocalLock)
                {
                    if (_dbLocalService != null) throw new NotSupportedException();
                    _dbLocalService = value;
                }
            }
        }
    }
}
