using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Wireguard_FrontEnd.Backend
{
    public class ProfileDetector
    {

        private static string Path = @"C:\Program Files\WireGuard\Data\Configurations";
        private static readonly DirectoryInfo FileDetections = new(Path);

        public ProfileDetector(string path = @"C:\Program Files\WireGuard\Data\Configurations")
        {
            Path = path;
        }

        public List<string> FilesListed()
        {
            List<string> filesDetected = new();

            try
            {
                if (FileDetections != null)
                    foreach (var i in FileDetections.GetFiles("*.dpapi"))
                        filesDetected.Add(i.Name);
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
