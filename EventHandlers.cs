using CustomPlayerEffects;
using Hazards;
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
        CharacterClassManager.OnRoundStarted -= OnRoundStarted;
    }

    public static void RegisterEvents()
    {
        CharacterClassManager.OnRoundStarted += OnRoundStarted;
    }

    public static void OnRoundStarted()
    {
        foreach (Hazard hazard in Hazard.List)
        {
            if (hazard is SinkholeHazard sinkholeHazard)
                sinkholeHazard.MaxDistance *= _config.SlowDistance;
        }
    }

    public static void OnStayingAtSinkhole(ReferenceHub player, SinkholeEnvironmentalHazard Sinkhole) 
    {
        if (player.playerEffectsController.GetEffect<PocketCorroding>().IsEnabled)
            return;

        if (player.IsSCP() || player.characterClassManager.GodMode)
            return;

        if ((double)Vector3.Distance(Sinkhole.SourcePosition, player.GetPosition()) <= (double)Sinkhole.MaxDistance * _config.TeleportDistance)
        {
            player.playerEffectsController.EnableEffect<PocketCorroding>();

            if (_translation.TeleportMessage is not null)
                player.BroadcastMessage(_translation.TeleportMessage);
        }
    }
}