﻿using System.Diagnostics;

namespace Wireguard_FrontEnd
{
    internal class CommandLine
    {

        internal static void RunCMD(string command)
        {
            Process cmd = new();

            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine(command);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.Close();
        }

    }
}
