using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Develeon64.Bots.DeveBot.Utils.Configs.Auth.Twitch;


[JsonObject(ItemRequired = Required.DisallowNull,
		    MemberSerialization = MemberSerialization.OptOut,
		    NamingStrategyType = typeof(SnakeCaseNamingStrategy)
		   )]
public struct TwitchAuthConfig {
	[JsonProperty]
	public TwitchClientAuthConfig Client  { get; set; }

	[JsonProperty]
	public TwitchAuthTokenConfig  Channel { get; set; }

	[JsonProperty]
	public TwitchAuthTokenConfig  Bot     { get; set; }
}
