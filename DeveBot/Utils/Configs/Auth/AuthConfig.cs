using Develeon64.Bots.DeveBot.Utils.Configs.Auth.Discord;
using Develeon64.Bots.DeveBot.Utils.Configs.Auth.Twitch;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Develeon64.Bots.DeveBot.Utils.Configs.Auth;


[JsonObject(ItemRequired = Required.DisallowNull,
		    MemberSerialization = MemberSerialization.OptOut,
		    NamingStrategyType = typeof(SnakeCaseNamingStrategy)
		   )]
public struct AuthConfig {
	[JsonProperty(Required = Required.Always)]
	public DiscordAuthConfig Discord { get; set; }

	[JsonProperty]
	public TwitchAuthConfig  Twitch  { get; set; }
}
