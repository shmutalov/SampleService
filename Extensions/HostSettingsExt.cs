using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf.Runtime;

namespace SamlpeService.Extensions
{
    /// <summary>
    /// HostControl extension methods
    /// </summary>
    public static class HostSettingsExt
    {
        public static string ToFormattedString(this HostSettings settings)
        {
            return string.Format(
                "HostSettings({0}): \n" + 
                "{{" + "\n" +
                "\t" + "CanPauseAndContinue={1}" + "\n" + 
                "\t" + "CanSessionChanged={2}" + "\n" + 
                "\t" + "CanShutdown={3}" + "\n" + 
                "\t" + "Description={4}" + "\n" + 
                "\t" + "DisplayName={5}" + "\n" + 
                "\t" + "InstanceName={6}" + "\n" + 
                "\t" + "Name={7}\n" + 
                "\t" + "ServiceName={8}" + "\n" + 
                "\t" + "StartTimeOut={9}" + "\n" + 
                "\t" + "StopTimeOut={10}" + "\n" +
                "}}",
                settings.GetHashCode(),
                settings.CanPauseAndContinue, settings.CanSessionChanged,
                settings.CanShutdown, settings.Description, settings.DisplayName,
                settings.InstanceName, settings.Name, settings.ServiceName,
                settings.StartTimeOut, settings.StopTimeOut);
        }
    }
}
