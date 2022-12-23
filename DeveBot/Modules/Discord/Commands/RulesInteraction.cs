using Develeon64.Bots.DeveBot.Utils.Managers;

using Discord;
using Discord.Interactions;
using Discord.Net;

using ExpressionTree;

namespace Develeon64.Bots.DeveBot.Modules.Discord.Commands;


// ReSharper disable once ClassNeverInstantiated.Global
public class RulesInteraction : InteractionModuleBase<SocketInteractionContext> {
	[ComponentInteraction("guild_rules|accept")]
	public async Task AcceptRules () {
		await this.DeferAsync(true);

		try {
			await this.Context.Guild.Users.ToImmutableDictionary(user => user.Id)[this.Context.User.Id]
					  .AddRoleAsync((ulong)((long?)DeveBot.Discord.Database.Select("guilds", null, null, null, new Expr("id", OperatorEnum.Equals, this.Context.Guild.Id)).Rows[0].ItemArray[3] ?? 0),
								    new RequestOptions {AuditLogReason = "Accepted Rules"}
								   );
		}
		catch (HttpException ex) {
			// ReSharper disable once SwitchStatementMissingSomeEnumCasesNoDefault
			switch (ex.DiscordCode) {
				case DiscordErrorCode.MissingPermissions:
					await this.FollowupAsync(LanguageManager.Languages[this.Context.Guild.PreferredLocale].DiscordRulesNoManage);
					break;
				case DiscordErrorCode.InsufficientPermissions:
					await this.FollowupAsync(LanguageManager.Languages[this.Context.Guild.PreferredLocale].DiscordRulesHigherRole);
					break;
			}

			return;
		}

		await this.FollowupAsync(LanguageManager.Languages[this.Context.Guild.PreferredLocale].DiscordRulesAcceptThanks, ephemeral: true);
	}

	[ComponentInteraction("guild_rules|decline")]
	public async Task DeclineRules () {
		await this.DeferAsync(true);

		try {
			await this.Context.Guild.Users.ToImmutableDictionary(user => user.Id)[this.Context.User.Id].KickAsync("Declined Rules", new RequestOptions {AuditLogReason = "Declined Rules"});
		}
		catch (HttpException ex) {
			if (ex.DiscordCode == DiscordErrorCode.InsufficientPermissions)
				await this.FollowupAsync(LanguageManager.Languages[this.Context.Guild.PreferredLocale].DiscordRulesNoKick, ephemeral: false);
			return;
		}

		await this.FollowupAsync(LanguageManager.Languages[this.Context.Guild.PreferredLocale].DiscordRulesDeclineKick, ephemeral: true);
	}
}
