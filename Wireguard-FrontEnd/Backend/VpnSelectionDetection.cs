using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Wireguard_FrontEnd.Backend
{
    public class VpnSelectionDetection
    {

        private static string _path = @"C:\Program Files\WireGuard\Data\Configurations";
        private static readonly DirectoryInfo FileDetections = new(_path);

        public VpnSelectionDetection(string path = @"C:\Program Files\WireGuard\Data\Configurations")
        {
            _path = path;
        }

        public List<string> FilesListed()
        {
            List<string> filesDetected = new List<string>();
            try
            {
                if (FileDetections != null)
                    foreach (var i in FileDetections.GetFiles())
                    {
                        filesDetected.Add(i.FullName);
                    }

            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e + ": Detected no files");
            }
            catch (Exception e)
            {
                Console.WriteLine(e + ": Detected Error maybe run program in administrator");
            }

            return filesDetected;
        }
    }
}
