using System.ComponentModel;

namespace BetterSinkholes;

public sealed class Translation
{
    [Description("Broadcasted to the player upon falling into a sinkhole. Default: nothing")]
    public string TeleportMessage { get; set; } = "";
}