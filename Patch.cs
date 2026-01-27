using HarmonyLib;
using Hazards;
using PlayerRoles;

namespace BetterSinkholes;

[HarmonyPatch(typeof(SinkholeEnvironmentalHazard))]
internal class SinkholeOnStayPatch
{
    [HarmonyPostfix]
    [HarmonyPatch(nameof(SinkholeEnvironmentalHazard.OnStay))]
    private static void Postfix(SinkholeEnvironmentalHazard __instance, ReferenceHub player)
    {
        if (player == null || __instance == null)
            return;

        SinkholeEventsHandler.OnStayingAtSinkhole(player, __instance);
    }
}