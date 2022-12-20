// ReSharper disable MemberCanBePrivate.Global

using Develeon64.Bots.DeveBot.Utils.Configs;
using Develeon64.Bots.DeveBot.Utils.Configs.Auth;
using Develeon64.Bots.DeveBot.Utils.Configs.Auth.Twitch;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Develeon64.Bots.DeveBot.Utils.Managers;


public static class ConfigManager {
	private const string ConfPath = "Var/Config/";
	private const string ConfName = "Configuration.jsonc";

	private const string AuthName = "Authentification.jsonc";

	public static StaticConfig Static { get; }              = new();
	public static AppConfig    Config { get; }              = JsonConvert.DeserializeObject<AppConfig>(File.ReadAllText(ConfigManager.ConfPath  + ConfigManager.ConfName, Encoding.UTF8), ConfigManager.Static.JsonSettings);
	public static AuthConfig   Auth   { get; private set; } = JsonConvert.DeserializeObject<AuthConfig>(File.ReadAllText(ConfigManager.ConfPath + ConfigManager.AuthName, Encoding.UTF8), ConfigManager.Static.JsonSettings);

	public static void Initialize (string[]? args) {
		//ConfigManager.Config = JsonConvert.DeserializeObject<AppConfig>(File.ReadAllText(ConfigManager.ConfPath  + ConfigManager.ConfName, Encoding.UTF8), ConfigManager.Static.JsonSettings);
		//ConfigManager.Auth   = JsonConvert.DeserializeObject<AuthConfig>(File.ReadAllText(ConfigManager.ConfPath + ConfigManager.AuthName, Encoding.UTF8), ConfigManager.Static.JsonSettings);
	}

	public static void RefreshTwitchBotTokens (string accessToken, string refreshToken, int? expiresIn = 0) {
		AuthConfig            auth   = ConfigManager.Auth;
		TwitchAuthConfig      twitch = auth.Twitch;
		TwitchAuthTokenConfig bot    = twitch.Bot;

		bot.Access  = accessToken;
		bot.Refresh = refreshToken;

		twitch.Bot         = bot;
		auth.Twitch        = twitch;
		ConfigManager.Auth = auth;

		File.WriteAllText(ConfigManager.ConfPath + ConfigManager.AuthName, JObject.FromObject(ConfigManager.Auth).ToString(Formatting.Indented), Encoding.UTF8);
	}

	public static void RefreshTwitchChannelTokens (string accessToken, string refreshToken, int? expiresIn = 0) {
		AuthConfig            auth    = ConfigManager.Auth;
		TwitchAuthConfig      twitch  = auth.Twitch;
		TwitchAuthTokenConfig channel = twitch.Channel;

		channel.Access  = accessToken;
		channel.Refresh = refreshToken;

		twitch.Channel     = channel;
		auth.Twitch        = twitch;
		ConfigManager.Auth = auth;

		File.WriteAllText(ConfigManager.ConfPath + ConfigManager.AuthName, JObject.FromObject(ConfigManager.Auth).ToString(Formatting.Indented), Encoding.UTF8);
	}
}
