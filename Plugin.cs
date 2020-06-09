using PulsarPluginLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCMod
{
    public class Plugin : PulsarPlugin
    {
        public override string HarmonyIdentifier()
        {
            return "RCMod";
        }
        public override string Version => "1.0";

        public override string Author => "💩Ship's Compooter💩";

        public override string ShortDescription => "Remote Control Mod.";

    }
}
