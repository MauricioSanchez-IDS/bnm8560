using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace N_ActualizaS111
{
    public abstract class ServiceUtilsCaller
    {
        internal bool _useNetworkService = true;

        private ServiceUtilsCaller() { }

        protected ServiceUtilsCaller(bool userNetworkService)
        {
            _useNetworkService = userNetworkService;
        }

        /// <summary>
        /// Instanse of the network or local service
        /// </summary>
        internal IDBService DBServiceClient
        {
            get { return _useNetworkService ? ServiceUtils.DBNetworkService : ServiceUtils.DBLocalService; }
        }
    }
}
