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
                        bool IsPlayerPilot = (PLNetworkManager.Instance.LocalPlayer.GetClassID() == 1);
                        bool IsPlayerHost = PhotonNetwork.isMasterClient;
                        if (IsPlayerPilot && IsPlayerHost)
                        {
                            Commands.HelmControl();
                        }
                        else
                        {
                            Commands.Traitor();
                        }
                    }

                    break;

                case "w": //control mainturret
                    {
                        bool IsPlayerGunner = (PLNetworkManager.Instance.LocalPlayer.GetClassID() == 3);
                        bool IsPlayerHost = PhotonNetwork.isMasterClient;
                        if (IsPlayerGunner && IsPlayerHost)
                        {
                            Commands.WeaponsControl();
                        }
                        else
                        {
                            Commands.Traitor();
                        }
                    }
                    break;

                case "s":
                case "sd":
                    {
                        bool IsPlayerScientist = (PLNetworkManager.Instance.LocalPlayer.GetClassID() == 2);
                        bool IsPlayerHost = (PhotonNetwork.isMasterClient);
                        if (IsPlayerHost || IsPlayerScientist)
                        {
                            Commands.SensorControl();
                        }
                        else
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

