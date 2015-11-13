using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NLog;
using SamlpeService.Config;
using Topshelf;

namespace SamlpeService
{
    public static class Program
    {
        /// <summary>
        /// Logger
        /// </summary>
        private static readonly Logger LogHelper = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// For each service, GUID must be unique
        /// </summary>
        private readonly static Mutex Mutex = new Mutex(true, @"Global\ee53f62a-0d35-4536-92ac-3abad9dd1ba0");

        public static void Main(string[] args)
        {
            if (Mutex.WaitOne(TimeSpan.Zero, true))
            {
                try
                {
                    // configure the service
                    HostFactory.Run(conf =>
                    {
                        // service configuration
                        conf.Service(settings => new SampleService(settings));

                        // set recovery mode
                        conf.EnableServiceRecovery(rc =>
                        {
                            // restart the service after 1 minute
                            rc.RestartService(1);

                            // set reset interval to 1 day
                            rc.SetResetPeriod(1);
                        });

                        // run as local administrator (Windows user credentials)
                        conf.RunAsLocalSystem();

                        // service description
                        conf.SetDescription(SampleServiceConfig.ServiceDescription);
                        conf.SetDisplayName(SampleServiceConfig.ServiceDisplayName);
                        conf.SetServiceName(SampleServiceConfig.ServiceName);
                    });
                }
                catch (Exception ex)
                {
                    LogHelper.Fatal(ex);
                }
                finally
                {
                    Mutex.ReleaseMutex();
                }

            }
            else
            {
                LogHelper.Fatal("Already running SampleService detected!");
            }
        }
    }
}
