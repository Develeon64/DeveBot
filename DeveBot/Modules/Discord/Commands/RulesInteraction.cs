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
					await this.FollowupAsync("The bot doesn't have the rights to manage the roles of members!");
					break;
				case DiscordErrorCode.InsufficientPermissions:
					await this.FollowupAsync("The highest role of the bot must be higher than the role for accepted members!");
					break;
			}

			return;
		}

		await this.FollowupAsync("Thanks for accepting the rules. You can now start to interact with the server!", ephemeral: true);
	}

	[ComponentInteraction("guild_rules|decline")]
	public async Task DeclineRules () {
		await this.DeferAsync(true);

		try {
			await this.Context.Guild.Users.ToImmutableDictionary(user => user.Id)[this.Context.User.Id].KickAsync("Declined Rules", new RequestOptions {AuditLogReason = "Declined Rules"});
		}
		catch (HttpException ex) {
			if (ex.DiscordCode == DiscordErrorCode.InsufficientPermissions)
				await this.FollowupAsync("The bot doesn't have the rights to kick members!", ephemeral: false);
			return;
		}

		await this.FollowupAsync("You have been kicked from the server, because you declined the rules.", ephemeral: true);
	}
}
