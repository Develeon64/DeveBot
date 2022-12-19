using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Develeon64.Bots.DeveBot.Utils.Configs.Discord;


[JsonObject(ItemRequired = Required.DisallowNull,
		    MemberSerialization = MemberSerialization.OptOut,
		    NamingStrategyType = typeof(SnakeCaseNamingStrategy)
		   )]
public struct DiscordConfig {
	[JsonProperty]
	public string[] StatusMessages { get; set; }
}
