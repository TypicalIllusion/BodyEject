using Exiled.Events.EventArgs;
using UnityEngine;
using RemoteAdmin;
using Exiled.API.Features;
using Exiled.API.Enums;

namespace BodyEject.Handlers
{
    class Player
    {
        private PlayerCommandSender sender;
        public void OnSpawningRagdoll(SpawningRagdollEventArgs ev)
        {

            {
                RoomType[] _roomTypes = { RoomType.Hcz106, RoomType.Hcz939, RoomType.HczCrossing, RoomType.HczCurve, }; //if the room type is one of these and the damage is pocket, teleport ragdoll to {x} room
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
                            Log.Debug($"{ev.PlayerNickname} as {ev.Owner.Role} died by 106 (nerd), Their corpse teleported to: {posx}, {posy}, {posz}"); //logs the body pos if debug = true
                        }
                    }
                }
            }

        }

    }
}