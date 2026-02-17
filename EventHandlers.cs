using CustomPlayerEffects;
using Hazards;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.Handlers;
using LabApi.Features.Wrappers;
using PlayerRoles;
using PlayerRoles.FirstPersonControl;
using UnityEngine;

namespace BetterSinkholes;

public class SinkholeEventsHandler
{
    private static Config _config => BetterSinkholes.Instance.Config;
    private static Translation _translation => BetterSinkholes.Instance.Translation;

    public static void UnregisterEvents()
    {
        PlayerEvents.StayingInHazard -= OnStayingAtSinkhole;
        ServerEvents.WaitingForPlayers -= OnWaitingForPlayers;
    }

    public static void RegisterEvents()
    {
        PlayerEvents.StayingInHazard += OnStayingAtSinkhole;
        ServerEvents.WaitingForPlayers += OnWaitingForPlayers;
    }

    public static void OnWaitingForPlayers()
    {
        foreach (SinkholeHazard sinkholeHazard in SinkholeHazard.List)
            sinkholeHazard.MaxDistance *= _config.SlowDistance;
    }

    public static void OnStayingAtSinkhole(PlayersStayingInHazardEventArgs ev)
    {
        if(ev.Hazard is not SinkholeHazard)
            return;

        foreach (Player player in ev.AffectedPlayers)
        {
            ReferenceHub playerHub = player.ReferenceHub;

            if (!playerHub)
                continue;

            if (playerHub.playerEffectsController.GetEffect<PocketCorroding>().IsEnabled)
                continue;

            if (playerHub.IsSCP() || playerHub.characterClassManager.GodMode)
                continue;

            if ((double)Vector3.Distance(ev.Hazard.SourcePosition, playerHub.GetPosition()) <= (double)ev.Hazard.MaxDistance * _config.TeleportDistance)
            {
                playerHub.playerEffectsController.EnableEffect<PocketCorroding>();

                if (_translation.TeleportMessage is not null)
                    playerHub.BroadcastMessage(_translation.TeleportMessage);
            }
        }
    }
}