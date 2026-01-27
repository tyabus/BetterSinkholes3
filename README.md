# BetterSinkholes3 - Sinkhole Environmental Hazard Rework

BetterSinkholes is a LabAPI plugin that makes **sinkhole environmental hazards** (found in LZ - IX Intersections) more realistic and similar to SCP:CB. With the use of this plugin, players who walk into sinkholes fall into the pocket dimension *and may never return*.

## Requirements
- Make sure the config option in `config_gameplay.txt` called `sinkhole_spawn_chance` is set to higher than 0.

## Releases and Installation
You can find the latest release [here](https://github.com/tyabus/BetterSinkholes3/releases).
Once downloaded, place the BetterSinkholes3.dll file into the /LabAPI/plugins/<port> folder and restart your server.

## Configs
| Config option | Value type | Default value | Description |
| --- | --- | --- | --- |
| `IsEnabled` | bool | true | Enables the BetterSinkholes2 plugin. Set it to false to disable it. |
| `SlowDistance` | float | 1f | Distance a the sinkhole where it starts slowing. Don't set it higher than 1.15! |
| `TeleportDistance` | float | 0.6f | Distance from a sinkhole where it teleports you to the pocket dimension. Set it to higher than 0!|

## Translations
| Config option | Value type | Default value | Description |
| --- | --- | --- | --- |
| `TeleportMessage` | Broadcast | '' | Simple Broadcast. Can use Unity's RichText. |

## Thank you!

Thank you for being interested in this plugin and I wish you a great time using it.
(Thanks for `blackruby#2562` for the original Plugin and `_yamato._` for the EXILED Port)
