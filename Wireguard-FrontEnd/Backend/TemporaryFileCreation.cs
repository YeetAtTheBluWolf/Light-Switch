using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wireguard_FrontEnd.Backend
{
    public abstract class TemporaryFileCreation
    {

        public abstract void CreateScript(bool On);
        public abstract void DeleteScript(bool On);

    }
}
