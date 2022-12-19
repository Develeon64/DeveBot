using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Develeon64.Bots.DeveBot.Utils.Configs.Auth.Discord;


[JsonObject(ItemRequired = Required.DisallowNull,
		    MemberSerialization = MemberSerialization.OptOut,
		    NamingStrategyType = typeof(SnakeCaseNamingStrategy)
		   )]
public struct DiscordAuthConfig {
	[JsonProperty]
	public ulong Id          { get; set; }

	[JsonProperty]
	public string Key        { get; set; }

	[JsonProperty]
	public string Secret     { get; set; }

	[JsonProperty(Required = Required.Always)]
	public string Token      { get; set; }

	[JsonProperty]
	public string Username   { get; set; }

	[JsonProperty]
	public int Discriminator { get; set; }
}
