using Develeon64.Bots.DeveBot.Utils;
using Develeon64.Bots.DeveBot.Utils.Managers;

using Discord;
using Discord.Interactions;
using Discord.Rest;
using Discord.WebSocket;

using ExpressionTree;

namespace Develeon64.Bots.DeveBot.Modules.Discord.Commands;


[Group("rules", "Manage your Guild's Rules")]
[DefaultMemberPermissions(GuildPermission.Administrator)]
[EnabledInDm(false)]
// ReSharper disable once ClassNeverInstantiated.Global
public class RulesCommand : InteractionModuleBase<SocketInteractionContext> {
	[SlashCommand("add", "Add a new Rule to your rule set")]
	public async Task AddRule ([Summary("paragraph", "The text of the new paragraph")] string paragraph) {
		if (await this.IsActivated()) {
			await this.DeferAsync(true);

			DeveBot.Discord.Database.Insert("rules", new Dictionary<string, object> {{"guild", this.Context.Guild.Id}, {"paragraph", paragraph}});
			await this.SendRules();
			await this.FollowupAsync($"{LanguageManager.Languages[this.Context.Guild.PreferredLocale].DiscordRulesOk}\n> {paragraph}");
		}
	}

	[SlashCommand("edit", "Edit a Rule of your rule set")]
	public async Task EditRule ([Summary("number", "Which rule to edit")] int number, [Summary("paragraph", "The text of the new paragraph")] string paragraph) {
		if (await this.IsActivated()) {
			await this.DeferAsync(true);

			DataRowCollection? rows = DeveBot.Discord.Database.Select("rules", null, null, null, new Expr("guild", OperatorEnum.Equals, this.Context.Guild.Id)).Rows;

			if (number > rows.Count) {
				await this.FollowupAsync(LanguageManager.Languages[this.Context.Guild.PreferredLocale].DiscordRulesEditOnlyExisting);
				return;
			}

			DeveBot.Discord.Database.Update("rules", new Dictionary<string, object> {{"paragraph", paragraph}}, new Expr("id", OperatorEnum.Equals, rows[number - 1].ItemArray[0]));
			await this.SendRules();
			await this.FollowupAsync($"{LanguageManager.Languages[this.Context.Guild.PreferredLocale].DiscordRulesEditedFirst} ***{number}*** {LanguageManager.Languages[this.Context.Guild.PreferredLocale].DiscordRulesEditedSecond}\n> {rows[number - 1].ItemArray[2]}\n{LanguageManager.Languages[this.Context.Guild.PreferredLocale].DiscordRulesEditedThird}\n> {paragraph}");
		}
	}

	[SlashCommand("delete", "Delete a Rule of your rule set")]
	public async Task EditRule ([Summary("number", "Which rule to delete")] int number) {
		if (await this.IsActivated()) {
			await this.DeferAsync(true);

			DataRowCollection? rows = DeveBot.Discord.Database.Select("rules", null, null, null, new Expr("guild", OperatorEnum.Equals, this.Context.Guild.Id)).Rows;

			if (number > rows.Count) {
				await this.FollowupAsync(LanguageManager.Languages[this.Context.Guild.PreferredLocale].DiscordRulesDeleteOnlyExisting);
				return;
			}

			DeveBot.Discord.Database.Delete("rules", new Expr("id", OperatorEnum.Equals, rows[number - 1].ItemArray[0]));
			await this.SendRules();
			await this.FollowupAsync($"{LanguageManager.Languages[this.Context.Guild.PreferredLocale].DiscordRulesDeletedFirst} ***{number}***\n> {rows[number - 1].ItemArray[2]}\n{LanguageManager.Languages[this.Context.Guild.PreferredLocale].DiscordRulesDeletedSecond}!");
		}
	}


	[Group("settings", "Set up the rule system")]
	public class RuleSettings : InteractionModuleBase<SocketInteractionContext> {
		[SlashCommand("role", "The role an user gets by accepting the rules")]
		public async Task SetRole (SocketRole role) {
			await this.DeferAsync(true);
			DeveBot.Discord.Database.Update("guilds", new Dictionary<string, object> {{"rules_role", role.Id}}, new Expr("id", OperatorEnum.Equals, this.Context.Guild.Id));
			await this.FollowupAsync(LanguageManager.Languages[this.Context.Guild.PreferredLocale].DiscordRulesRoleSet);
		}
	}


	private async Task SendRules () {
		var messageIds = new List<ulong>();
		await foreach (IReadOnlyCollection<IMessage>? messages in this.Context.Guild.RulesChannel.GetMessagesAsync())
			messageIds.AddRange(messages.Select(message => message.Id));

		try {
			await this.Context.Guild.RulesChannel.DeleteMessagesAsync(messageIds, new RequestOptions {AuditLogReason = "Edited Server Rules"});
		}
		catch {
			/*foreach (ulong id in messageIds) {
				await this.Context.Guild.RulesChannel.DeleteMessageAsync(id, new RequestOptions {AuditLogReason = "Edited Server Rules"});
			}*/
		}

		DiscordEmbedBuilder embed = new(this.Context.Guild.Owner);
		embed.WithTitle($"__**{LanguageManager.Languages[this.Context.Guild.PreferredLocale].DiscordRulesTitle}**__");
		embed.WithDescription(LanguageManager.Languages[this.Context.Guild.PreferredLocale].DiscordRulesGeneral);

		DataRowCollection? rows = DeveBot.Discord.Database.Select("rules", null, null, null, new Expr("guild", OperatorEnum.Equals, this.Context.Guild.Id)).Rows;
		for (var i = 0; i < rows.Count; i++)
			embed.AddField($"__§ {i + 1}__", rows[i].ItemArray[2], false);

		ComponentBuilder components = new();
		components.AddRow(new ActionRowBuilder()
						  .WithButton(LanguageManager.Languages[this.Context.Guild.PreferredLocale].DiscordRulesDecline, "guild_rules|decline", ButtonStyle.Secondary, new Emoji("❌"))
						  .WithButton(LanguageManager.Languages[this.Context.Guild.PreferredLocale].DiscordRulesAccept,  "guild_rules|accept",  ButtonStyle.Primary,   new Emoji("✅"))
						 );

		RestUserMessage? message = await this.Context.Guild.RulesChannel.SendMessageAsync($"@everyone {LanguageManager.Languages[this.Context.Guild.PreferredLocale].DiscordRulesNewAnnouncement}:", embed: embed.Build(), components: components.Build());
		await Task.Delay(1000);
		await message.ModifyAsync(properties => properties.Content = "");
	}

	private async Task<bool> IsActivated () {
		try {
			_ = (long?)DeveBot.Discord.Database.Select("guilds", null, null, null, new Expr("id", OperatorEnum.Equals, this.Context.Guild.Id)).Rows[0].ItemArray[3] is not null;

			if (this.Context.Guild.RulesChannel is null) {
				await this.SendError(LanguageManager.Languages[this.Context.Guild.PreferredLocale].DiscordRulesNoCommunity);
				return false;
			}

			return true;
		}
		catch {
			await this.SendError($"{LanguageManager.Languages[this.Context.Guild.PreferredLocale].DiscordRulesNoRole} </rules settings role:1054045662582419576>.");
			return false;
		}
	}

	private async Task SendError (string text) {
		if (this.Context.Interaction.HasResponded) await this.FollowupAsync(text);
		else await this.RespondAsync(text, ephemeral: true);
	}
}
