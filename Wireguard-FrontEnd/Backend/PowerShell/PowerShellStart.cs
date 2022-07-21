using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wireguard_FrontEnd.Backend
{
    public class PowerShellStart : VpnSelectionDetection
    {

        public PowerShellStart()
        {
            
        }

        public static void StartTunnelProcess(object conf)
        {
            try
            {
                var start = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    Arguments =
                        " & \"C:\\Program Files\\WireGuard\\wireguard.exe\" /installtunnelservice \"" + Path + "\\" + conf + "\"",
                    CreateNoWindow = true
                };

                using var process = Process.Start(start);
            }
            catch (Exception)
            {
                Console.WriteLine("Error at PowerShellStart.cs");
            }
        }

    }
}
