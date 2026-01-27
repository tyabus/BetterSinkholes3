using HarmonyLib;
using LabApi.Features;
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
    public override Version Version { get; } = new Version(1, 0, 0);
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

    private readonly Harmony _harmony = new("tyabus.BetterSinkholes");

    public override void Enable()
    {
        Instance = this;
        if (Config.IsEnabled)
        {
            SinkholeEventsHandler.RegisterEvents();
            _harmony.PatchAll();
        }
    }

    public override void Disable()
    {
        _harmony.UnpatchAll();
        SinkholeEventsHandler.UnregisterEvents();
        Instance = null!;
    }
 }