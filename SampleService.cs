using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using SamlpeService.Extensions;
using Topshelf;
using Topshelf.Runtime;

namespace SamlpeService
{
    /// <summary>
    /// Sample service controller
    /// </summary>
    public class SampleService : ServiceControl
    {
        /// <summary>
        /// Logger
        /// </summary>
        private static readonly Logger LogHelper = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Service host settings
        /// </summary>
        private readonly HostSettings _settings;

        public SampleService(HostSettings settings)
        {
            _settings = settings;

            LogHelper.Info(_settings.ToFormattedString());
        }

        /// <summary>
        /// This method will executed when Windows tries to start the service
        /// </summary>
        /// <param name="hostControl"></param>
        /// <returns>If service succesfully starts, then method will return true</returns>
        public bool Start(HostControl hostControl)
        {
            LogHelper.Info("Starting the service...");

            // startup code goes here

            LogHelper.Info("Service successfully started!");

            return true;
        }

        /// <summary>
        /// This method will executed when Windows tries to stop the service
        /// </summary>
        /// <param name="hostControl"></param>
        /// <returns>If service succesfully stops, then method will return true</returns>
        public bool Stop(HostControl hostControl)
        {
            LogHelper.Info("Stopping the service...");

            // shutdown code goes here

            LogHelper.Info("Service successfully stopped!");

            return true;
        }
    }
}
