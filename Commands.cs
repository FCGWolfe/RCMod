using PulsarPluginLoader.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCMod
{
    public class Commands
    {
        public static void HelmControl()
        {

            PLEncounterManager.Instance.PlayerShip.photonView.RPC("RequestShipControl", PhotonTargets.All, new object[]
            {
                PLNetworkManager.Instance.LocalPlayer.GetPlayerID()
            });
        }
        public static void WeaponsControl()
        {
            PLNetworkManager.Instance.MyLocalPawn.MyController.IsControllingTurret = true;
            PLCameraSystem.Instance.ChangeCameraMode(new PLCameraMode_Turret(0, null));
            //PLTurret.TurretInstance.Targeting.SetActive(true);
            //Doesn't quite work yet... Wants PLShipInfo data where I put the "null" but idk what it's expecting.
        }
        public static void SensorControl()
        {
            PLServer.Instance.photonView.RPC("NewSensorDishController", PhotonTargets.All, new object[]
            {
                PLNetworkManager.Instance.LocalPlayer.GetPlayerID()
            });
        }
        public static void Traitor()
        {
            Messaging.Echo(PhotonTargets.All, "Nice try. Your mutiny will never succeed. Now, into the airlock with you, traitorous scum!");
            //Messaging.ChatMessage(PhotonTargets.All, "Unauthorized Remote Intrusion Detected In Helm Control System. System Lockout In Effect.");
        }
    }
}

