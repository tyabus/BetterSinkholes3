using LabApi.Features;
using LabApi.Features.Console;
using LabApi.Loader;
using LabApi.Loader.Features.Plugins;
using System;

namespace BetterSinkholes;

public class BetterSinkholes : Plugin
{
    public static BetterSinkholes Instance { get; private set; } = null!;
    public override string Name => "BetterSinkholes3";
    public override string Description { get; } = "BetterSinkholes3";
    public override string Author => "tyabus"; // EXILED version author: Yamato, Original author: Blackruby
    public override Version Version { get; } = new Version(1, 0, 2);
    public Config Config { get; private set; } = null!;
    public Translation Translation { get; private set; } = null!;
    public override Version RequiredApiVersion { get; } = new Version(LabApiProperties.CompiledVersion);

    public override void LoadConfigs()
    {
        Config = this.TryLoadConfig("config.yml", out Config? config)
            ? config
            : new Config();
        Translation = this.TryLoadConfig("translation.yml", out Translation? translation)
            ? translation
            : new Translation();
    }

    public override void Enable()
    {
        Instance = this;
        if (Config.IsEnabled)
        {
            if (GameCore.ConfigFile.ServerConfig.GetInt("sinkhole_spawn_chance") <= 0)
                Logger.Warn("sinkhole_spawn_chance is not above 0, consider changing it in config_gameplay.txt");

            SinkholeEventsHandler.RegisterEvents();
        }
    }

    public override void Disable()
    {
        SinkholeEventsHandler.UnregisterEvents();
        Instance = null!;
    }
 }