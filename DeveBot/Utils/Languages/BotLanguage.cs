using System.ComponentModel;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Develeon64.Bots.DeveBot.Utils.Languages;


[JsonObject(ItemRequired = Required.Default,
		    MemberSerialization = MemberSerialization.OptOut,
		    NamingStrategyType = typeof(SnakeCaseNamingStrategy)
		   )]
public struct BotLanguage {
	public BotLanguage () { }
}
