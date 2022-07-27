using System;
using System.Text;
using System.Management.Automation;

namespace Wireguard_FrontEnd.Backend
{
    public static class PowerShellHandler
    {

        private static readonly PowerShell _ps = PowerShell.Create();

        public static string Command(string script)
        {
            string errorMsg = string.Empty;

            _ps.AddScript(script);

            //Make sure return values are outputted to the stream captured by C#
            _ps.AddCommand("Out-String");

            PSDataCollection<PSObject> outputCollection = new();
            _ps.Streams.Error.DataAdded += (sender, e) =>
            {
                errorMsg = ((PSDataCollection<ErrorRecord>)sender)[e.Index].ToString();
            };


            IAsyncResult result = _ps.BeginInvoke<PSObject, PSObject>(null, outputCollection);

            //Wait for powershell command/script to finish executing
            _ps.EndInvoke(result);

            StringBuilder sb = new();

            foreach (var outputItem in outputCollection)
            {
                sb.AppendLine(outputItem.BaseObject.ToString());
            }

            //Clears the commands we added to the powershell runspace so it's empty the next time we use it
            _ps.Commands.Clear();

            //If an error is encountered, return it
            if (!string.IsNullOrEmpty(errorMsg))
                return errorMsg;

            return sb.ToString().Trim();

        }

        //string script = " & \"C:\\Program Files\\WireGuard\\wireguard.exe\" /uninstalltunnelservice \"WG4\"";
        //string script = " & \"C:\\Program Files\\WireGuard\\wireguard.exe\" / installtunnelservice \"C:\\Program Files\\WireGuard\\Data\\Configurations\\wg4.conf.dpapi\"";
    }
}
