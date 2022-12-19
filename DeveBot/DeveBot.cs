// ReSharper disable MemberCanBePrivate.Global

using Develeon64.Bots.DeveBot.Modules.Discord;
using Develeon64.Bots.DeveBot.Utils.Managers;

using log4net;
using log4net.Config;

namespace Develeon64.Bots.DeveBot;


public static class DeveBot {
	private static ILog Logger { get; } = LogManager.GetLogger("System");

	public static DiscordBot Discord { get; private set; } = null!;
	//public static DiscordBot Twitch  { get; private set; }

	public static void Main (string[] args) => DeveBot.MainAsync(args).GetAwaiter().GetResult();

	public static async Task MainAsync (string[] args) {
		XmlConfigurator.ConfigureAndWatch(new FileInfo("Var/Config/Logging.xml"));

		DeveBot.Logger.Info($"{nameof(DeveBot)} starting up!");
		DeveBot.Logger.Info($"Version: {VersionManager.FullVersion[1..]}");

		DeveBot.Discord = new DiscordBot(args);

		await Task.Delay(-1);
	}
}
