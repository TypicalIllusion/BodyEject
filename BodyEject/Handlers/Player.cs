using UnityEngine;

using Exiled.Events.EventArgs;
using Exiled.API.Features;
using Exiled.API.Enums;

using static BodyEject.BodyEject;

namespace BodyEject.Handlers
{
    class Player
    {
        public void OnSpawningRagdoll(SpawningRagdollEventArgs ev)
        {
            if (!Singleton.Config.IsEnabled) return;
            else
            {

                {
                    RoomType[] _roomTypes = { RoomType.Hcz106, RoomType.Hcz939, RoomType.HczCrossing, RoomType.HczCurve, };
                    if (ev.HitInformations.GetDamageType() == DamageTypes.Pocket)
                    {
                        System.Random rnd = new System.Random();
                        int _value = rnd.Next(0, _roomTypes.Length);
                        foreach (Room room in Map.Rooms)
                        {
                            if (room.Type == _roomTypes[_value])
                            {
                                float posx = room.Position.x;
                                float posy = room.Position.y + 2;
                                float posz = room.Position.z;
                                ev.Position = new Vector3(posx, posy, posz);
                                Log.Debug($"{ev.PlayerNickname} as {ev.Owner.Role} died by 106 (nerd), Their corpse teleported to: {posx}, {posy}, {posz}");
                            }
                        }
                    }
                }

            }
        }

        public void OnDying(DyingEventArgs ev)
        {
            if (!Singleton.Config.IsEnabled) return;
            else
            {
                if (!Singleton.Config.ItemDrop) return;
                else
                {
                    if (ev.HitInformation.GetDamageType() == DamageTypes.Pocket)
                    {
                        ev.Target.ClearInventory();

                        Log.Debug($"{ev.Target.Nickname} lost all of their items.", Singleton.Config.Debug);
                    }
                }
            }
        }
            
            

}

}