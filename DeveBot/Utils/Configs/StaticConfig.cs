using DatabaseWrapper.Core;

using Discord;
using Discord.Interactions;
using Discord.WebSocket;

using Newtonsoft.Json;

namespace Develeon64.Bots.DeveBot.Utils.Configs;


public struct StaticConfig {
	public StaticConfig () { }

	public JsonSerializerSettings JsonSettings { get; } = new() {
		DefaultValueHandling = DefaultValueHandling.Populate,
		FloatFormatHandling  = FloatFormatHandling.DefaultValue,
		Formatting           = Formatting.None,
		StringEscapeHandling = StringEscapeHandling.EscapeNonAscii,
	};

	public DiscordSocketConfig DiscordSettings { get; } = new() {
		AlwaysDownloadUsers                      = true,
		AlwaysResolveStickers                    = true,
		AlwaysDownloadDefaultStickers            = true,
		DefaultRetryMode                         = RetryMode.AlwaysRetry,
		GatewayIntents                           = GatewayIntents.Guilds | GatewayIntents.GuildMembers,
		LargeThreshold                           = 1000,
		LogGatewayIntentWarnings                 = true,
		MaxWaitBetweenGuildAvailablesBeforeReady = 30 * 1000,
		SuppressUnknownDispatchWarnings          = true,
		TotalShards                              = 1,
	};

	public InteractionServiceConfig DiscordInteractionSettings { get; } = new() {
		AutoServiceScopes          = true,
		DefaultRunMode             = RunMode.Async,
		EnableAutocompleteHandlers = false,
		//InteractionCustomIdDelimiters = new [] { '|' },
		//LocalizationManager = new JsonLocalizationManager("", ""),
		UseCompiledLambda = true,
	};

	public DatabaseSettings DiscordDatabaseSettings { get; } = new() {
		Type     = DbTypeEnum.Sqlite,
		Filename = "Var/DB/Discord.db3",
	};
}
