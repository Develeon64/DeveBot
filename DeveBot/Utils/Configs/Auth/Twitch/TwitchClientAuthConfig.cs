using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Develeon64.Bots.DeveBot.Utils.Configs.Auth.Twitch;


[JsonObject(ItemRequired = Required.DisallowNull,
		    MemberSerialization = MemberSerialization.OptOut,
		    NamingStrategyType = typeof(SnakeCaseNamingStrategy)
		   )]
public struct TwitchClientAuthConfig {
	[JsonProperty]
	public string Id     { get; set; }

	[JsonProperty]
	public string Secret { get; set; }
}
