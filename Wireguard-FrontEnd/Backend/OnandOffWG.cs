using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using static System.Net.Mime.MediaTypeNames;

namespace Wireguard_FrontEnd.Backend
{
    public class OnandOffWG : TemporaryFileCreation
    {

        private readonly string Profile;
        public string ProfileFixed { get; set; }
        private readonly string TemporaryLocal;
        public readonly string OnFile;
        public readonly string OffFile;
        private bool ScriptCreatedOn = false;
        private bool ScriptCreatedOff = false;

        public OnandOffWG(string profile)
        {
            this.Profile = profile;
            ProfileFixed = Profile[..Profile.IndexOf('.')];
            TemporaryLocal = Path.GetTempPath();
            OnFile = Path.Combine(TemporaryLocal, ProfileFixed + "On.ps1");
            OffFile = Path.Combine(TemporaryLocal, ProfileFixed + "Off.ps1");
        }

        public override void CreateScript(bool On)
        {
            if(On)
                using (var file = new FileStream(OnFile, FileMode.OpenOrCreate))
                {
                    string filePath = " & \"C:\\Program Files\\WireGuard\\wireguard.exe\" /installtunnelservice \"C:\\Program Files\\WireGuard\\Data\\Configurations\\" + Profile + "\"";
                    byte[] writeArr = Encoding.UTF8.GetBytes(filePath);
                    file.Write(writeArr, 0, filePath.Length);
                    file.Close();
                    ScriptCreatedOn = true;
                }
            else
                using (var file = new FileStream(OffFile, FileMode.OpenOrCreate))
                {
                    string filePath = @" & ""C:\Program Files\WireGuard\wireguard.exe"" /uninstalltunnelservice """ + ProfileFixed + "\"";
                    byte[] writeArr = Encoding.UTF8.GetBytes(filePath);
                    file.Write(writeArr, 0, filePath.Length);
                    file.Close();
                    ScriptCreatedOff = true;
                }
        }

        public override void DeleteScript(bool On)
        {
            if (On && ScriptCreatedOn)
                File.Delete(OnFile);
            if(On && ScriptCreatedOff)
                File.Delete(OffFile);
        }

    }
}
