namespace BetterSinkholes;

using System.ComponentModel;

public sealed class Config
{
    [Description("Enable/disable BetterSinkholes")]
    public bool IsEnabled { get; set; } = true;

    [Description("Distance from the center of a sinkhole where you get teleported")]
    public float TeleportDistance { get; set; } = 0.6f;

    [Description("Distance from the center of a sinkhole where you start getting slowed")]
    public float SlowDistance { get; set; } = 1f;
}