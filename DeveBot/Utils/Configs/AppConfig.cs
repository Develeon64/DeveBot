using Develeon64.Bots.DeveBot.Utils.Configs.Discord;
using Develeon64.Bots.DeveBot.Utils.Configs.Twitch;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Develeon64.Bots.DeveBot.Utils.Configs;


[JsonObject(ItemRequired = Required.DisallowNull,
		    MemberSerialization = MemberSerialization.OptOut,
		    NamingStrategyType = typeof(SnakeCaseNamingStrategy)
		   )]
public struct AppConfig {
	[JsonProperty]
	public DiscordConfig Discord { get; set; }

	[JsonProperty]
	public TwitchConfig Twitch { get; set; }
}
