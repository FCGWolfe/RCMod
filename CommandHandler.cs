using PulsarPluginLoader.Chat.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCMod
{
    internal class CommandHandler : IChatCommand
    {
        public string[] CommandAliases()
        {
            return new string[] { "rc" };
        }
        public string Description()
        {
            return "RCMod. Janky remote control!";
        }
        public string UsageExample()
        {
            return "/rc";
        }
        public bool Execute(string arguments)
        {
            string[] Args = arguments.Split(' ');

            switch (Args[0].ToLower())
            {
                case "p": //control pilot
                    {
                        int IsPlayerPilot = PLNetworkManager.Instance.LocalPlayer.GetClassID();
                        int IsPlayerHost = PLNetworkManager.Instance.LocalPlayer.GetPlayerID();
                        if (IsPlayerPilot == 3)
                            if (IsPlayerHost != 0)
                                Commands.HelmControl();
                            else
                                Commands.Traitor();
                    }
                    //IsPlayerPilot = PLNetworkManager.Instance.LocalPlayerID = 1;
                    //Commands.HelmControl();
                    break;

                case "w": //control mainturret
                    {
                        int IsPlayerGunner = PLNetworkManager.Instance.LocalPlayer.GetClassID();
                        int IsPlayerHost = PLNetworkManager.Instance.LocalPlayer.GetPlayerID();
                        if (IsPlayerGunner == 3)
                            if (IsPlayerHost != 0)
                                Commands.WeaponsControl();
                            else
                                Commands.Traitor();
                    }
                    break;
                case "s":
                case "sd":
                    {
                        int IsPlayerScientist = PLNetworkManager.Instance.LocalPlayer.GetClassID();
                        int IsPlayerHost = PLNetworkManager.Instance.LocalPlayer.GetPlayerID();
                        if (IsPlayerHost == 0)
                        {
                            Commands.SensorControl();
                        }
                        else if (IsPlayerScientist == 4)
                        {
                            Commands.SensorControl();
                        }
                        else if (IsPlayerScientist != 4)
                        {
                            Commands.Traitor();
                        }
                    }
                    break;
            }
            return false;
        }
    }
}

