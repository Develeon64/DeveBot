using DatabaseWrapper;

using Develeon64.Bots.DeveBot.Modules.Discord.Commands;
using Develeon64.Bots.DeveBot.Utils.Managers;

using Discord;
using Discord.Interactions;
using Discord.WebSocket;

using ExpressionTree;

using log4net;

namespace Develeon64.Bots.DeveBot.Modules.Discord;


public class DiscordBot {
	private readonly ILog           _logger = LogManager.GetLogger("Discord");
	public           DatabaseClient Database { get; } = new(ConfigManager.Static.DiscordDatabaseSettings);

	private readonly DiscordSocketClient _client        = new(ConfigManager.Static.DiscordSettings);
	private          byte                _presenceState = 1;

	private readonly InteractionService _service;

	public SocketUser? Programmer { get; private set; }
	
	private DateTime Started { get; } = DateTime.Now;

	public DiscordBot (string[] args) {
		this._service = new InteractionService(this._client, ConfigManager.Static.DiscordInteractionSettings);
		this._service.AddModuleAsync<RulesCommand>(null);
		this._service.AddModuleAsync<RulesInteraction>(null);
		this.Initialize(args);
	}

	private async void Initialize (string[] args) {
		this._client.Log   += this.Client_Log;
		this._client.Ready += this.Client_Ready;

		this._client.InteractionCreated += this.Client_InteractionCreated;

		this._client.JoinedGuild += this.Client_JoinedGuild;

		await this._client.LoginAsync(TokenType.Bot, ConfigManager.Auth.Discord.Token);
		await this._client.StartAsync();
	}

	private async Task Client_Ready () {
		if (this._client.CurrentUser.Id == 1052895081826361496) {
			await this._service.RegisterCommandsGloballyAsync();
		}
		else {
			IReadOnlyCollection<SocketApplicationCommand>? commands = await this._client.GetGlobalApplicationCommandsAsync();
			foreach (SocketApplicationCommand? command in commands)
				await command.DeleteAsync();
			//await this._client.Guilds.ToDictionary(guild => guild.Id)[1037303872974233600].DeleteApplicationCommandsAsync();
			await this._service.RegisterCommandsToGuildAsync(1037303872974233600);
		}

		this.Programmer = await this._client.GetUserAsync(298215920709664768) as SocketUser;

		foreach (SocketGuild? guild in this._client.Guilds)
			await this.Client_JoinedGuild(guild);

		//await this._client.SetGameAsync($"{VersionManager.FullVersion} (since {this.started:dd.MM.yyyy HH:mm:ss})");
	}

	private Task Client_Log (LogMessage message) {
		switch (message.Severity) {
			case LogSeverity.Debug:
				this._logger.Debug($"{message.Source}: {message.Message}", message.Exception);
				break;
			case LogSeverity.Info:
				this._logger.Info($"{message.Source}: {message.Message}", message.Exception);
				break;
			case LogSeverity.Warning:
				this._logger.Warn($"{message.Source}: {message.Message}", message.Exception);
				break;
			case LogSeverity.Error:
				this._logger.Error($"{message.Source}: {message.Message}", message.Exception);
				break;
			case LogSeverity.Critical:
				this._logger.Fatal($"{message.Source}: {message.Message}", message.Exception);
				break;
			case LogSeverity.Verbose:
			default:
				Console.WriteLine(message);
				break;
		}

		return Task.CompletedTask;
	}

	private async Task Client_InteractionCreated (SocketInteraction interaction) => await this._service.ExecuteCommandAsync(new SocketInteractionContext(this._client, interaction), null);

	private Task Client_JoinedGuild (SocketGuild guild) {
		if (!this.Database.Exists("users", new Expr("id", OperatorEnum.Equals, guild.OwnerId)))
			this.Database.Insert("users", new Dictionary<string, object> {{"id", guild.OwnerId}, {"username", guild.Owner.Username}, {"discriminator", guild.Owner.DiscriminatorValue}});

		if (!this.Database.Exists("guilds", new Expr("id", OperatorEnum.Equals, guild.Id)))
			this.Database.Insert("guilds", new Dictionary<string, object> {{"id", guild.Id}, {"name", guild.Name}, {"owner", guild.OwnerId}});

		return Task.CompletedTask;
	}

	public async Task SetPresence () {
		switch (this._presenceState) {
			case 1:
			case 3:
			case 5:
				await this._client.SetStatusAsync(UserStatus.Online);
				await this._client.SetGameAsync(ConfigManager.Config.Discord.StatusMessages[Random.Shared.Next(0, ConfigManager.Config.Discord.StatusMessages.Length)], null, ActivityType.Playing);
				break;
			case 2:
				await this._client.SetStatusAsync(UserStatus.AFK);
				await this._client.SetGameAsync("Develeon64", null, ActivityType.Listening);
				break;
			case 4:
				await this._client.SetStatusAsync(UserStatus.DoNotDisturb);
				await this._client.SetGameAsync("WIP!", null, ActivityType.Watching);
				break;
			default:
				await this._client.SetStatusAsync(UserStatus.Online);
				// ReSharper disable once RedundantArgumentDefaultValue
				await this._client.SetGameAsync(VersionManager.FullVersion, null, ActivityType.Playing);
				break;
		}

		this._presenceState = (byte)(this._presenceState < 3 ? this._presenceState + 1 : 0);
	}

	public async Task<int> CountMembers (SocketGuild guild) {
		 await guild.DownloadUsersAsync();

		 var          memberCount = 0;
		 List<string> memberNames = new();
		 foreach (SocketGuildUser guildUser in guild.Users.ToList().Where(guildUser => !memberNames.Contains(guildUser.Username) && !memberNames.Contains(guildUser.Nickname) && guildUser.Id != 344136468068958218 && guildUser.Id != 372108947303301124)) {
			 memberCount += 1;
			 memberNames.Add(guildUser.Username);
			 if (!string.IsNullOrEmpty(guildUser.Nickname)) memberNames.Add(guildUser.Nickname);
		 }

		 return memberCount;
	}
}
