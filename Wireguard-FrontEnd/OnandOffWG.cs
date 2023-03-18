using System.IO;
using System.Text;

namespace Wireguard_FrontEnd
{
    internal class OnandOffWG
    {

        private readonly string Profile;
        private readonly string TemporaryLocal;

        public readonly string OnFile;
        public readonly string OffFile;
        public string ProfileFixed { get; set; }

        internal OnandOffWG(string profile)
        {
            Profile = profile;
            ProfileFixed = Profile[..Profile.IndexOf('.')];
            TemporaryLocal = Path.GetTempPath();
            OnFile = Path.Combine(TemporaryLocal, ProfileFixed + "On.ps1");
            OffFile = Path.Combine(TemporaryLocal, ProfileFixed + "Off.ps1");
        }

        internal void CreateConnectScript()
        {
            using var file = new FileStream(OnFile, FileMode.OpenOrCreate);
            string filePath = " & \"C:\\Program Files\\WireGuard\\wireguard.exe\" /installtunnelservice \"C:\\Program Files\\WireGuard\\Data\\Configurations\\" + Profile + "\"";
            byte[] writeArr = Encoding.UTF8.GetBytes(filePath);
            file.Write(writeArr, 0, filePath.Length);
            file.Close();
        }

        internal void CreateDisconnectScript()
        {
            using var file = new FileStream(OffFile, FileMode.OpenOrCreate);
            string filePath = @" & ""C:\Program Files\WireGuard\wireguard.exe"" /uninstalltunnelservice """ + ProfileFixed + "\"";
            byte[] writeArr = Encoding.UTF8.GetBytes(filePath);
            file.Write(writeArr, 0, filePath.Length);
            file.Close();
        }

    }
}
