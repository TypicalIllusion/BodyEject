using System;
using Exiled.API.Features;
using Exiled.API.Enums;
using GServer = Exiled.Events.Handlers.Server;
using GPlayer = Exiled.Events.Handlers.Player;

namespace BodyEject
{
    public class BodyEject : Plugin<Config>
    {
        private Handlers.Player player = new Handlers.Player();
        private Handlers.Server server = new Handlers.Server();
        public override string Name { get; } = "BodyEject";
        public override string Author { get; } = "TypicalIllusion";
        public override Version Version { get; } = new Version(1, 5, 0);
        public override Version RequiredExiledVersion { get; } = new Version(2, 1, 14);
        public override string Prefix { get; } = "BodyEject";

        public static BodyEject Instance;

        public override PluginPriority Priority { get; } = PluginPriority.Low;



        public static bool enabledInGame = true;

        public void RegisterEvents()
        {
            GPlayer.SpawningRagdoll += player.OnSpawningRagdoll;
            GServer.WaitingForPlayers += server.WaitingForPlayers;
        }
        public void UnregisterEvents()
        {
            GPlayer.SpawningRagdoll -= player.OnSpawningRagdoll;
            GServer.WaitingForPlayers -= server.WaitingForPlayers;

            player = null;
            server = null;
        }

        public override void OnEnabled()
        {
            base.OnEnabled();
            RegisterEvents();
        }
        public override void OnDisabled()
        {
            base.OnDisabled();
            UnregisterEvents();
        }
    }
}
