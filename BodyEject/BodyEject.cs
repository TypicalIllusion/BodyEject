using System;

using Exiled.API.Features;
using Exiled.API.Enums;

using PPlayer = Exiled.Events.Handlers.Player;

namespace BodyEject
{
    public class BodyEject : Plugin<Config>
    {
        private Handlers.Player player = new Handlers.Player();
        public override string Name { get; } = "BodyEject";
        public override string Author { get; } = "TypicalIllusion";
        public override Version Version { get; } = new Version(2, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(2, 1, 21);
        public override string Prefix { get; } = "BodyEject";

        public static BodyEject Instance;

        public override PluginPriority Priority { get; } = PluginPriority.Low;

        public static BodyEject Singleton;


        public static bool enabledInGame = true;

        public void RegisterEvents()
        {
            PPlayer.SpawningRagdoll += player.OnSpawningRagdoll;
            PPlayer.Dying += player.OnDying;
            Singleton = this;
        }
        public void UnregisterEvents()
        {
            PPlayer.SpawningRagdoll -= player.OnSpawningRagdoll;
            PPlayer.Dying -= player.OnDying;

            player = null;
            Singleton = null;
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
        public override void OnReloaded()
        {
            base.OnReloaded();
        }
    }
}
