using Develeon64.Bots.DeveBot.Modules.Discord.Commands.Types;
using Develeon64.Bots.DeveBot.Utils.Managers;

using Discord;
using Discord.Interactions;
using Discord.WebSocket;

using ExpressionTree;

namespace Develeon64.Bots.DeveBot.Modules.Discord.Commands;


[Group("count", "Set up channel to show community size")]
[DefaultMemberPermissions(GuildPermission.Administrator)]
[EnabledInDm(false)]
// ReSharper disable once ClassNeverInstantiated.Global
public class CountChannelCommand : InteractionModuleBase<SocketInteractionContext> {
	[SlashCommand("set", "Register a count channel")]
	public async Task SetChannel ([Summary("channel", "The channel to show the count")] SocketVoiceChannel channel, [Summary("type", "Which count should the channel show?")] CountChannelType type, [Summary("prefix", "Text to be shown before the count number")] string prefix = "", [Summary("postfix", "Text to be shown behind the count number")] string postfix = "") {
		await this.DeferAsync(true);
		if (DeveBot.Discord.Database.Exists("count_channels", new Expr("id", OperatorEnum.Equals, channel.Id))) {
			ComponentBuilder components = new();
			components.AddRow(new ActionRowBuilder()
							  .WithButton(LanguageManager.Languages[this.Context.Guild.PreferredLocale].DiscordCountChannelKeep,    $"count_channels|overwrite_channel|{channel.Id}|{type}|{prefix}|{postfix}", ButtonStyle.Danger,  new Emoji("❌"))
							  .WithButton(LanguageManager.Languages[this.Context.Guild.PreferredLocale].DiscordCountChannelOverwrite, "count_channels|overwrite_channel",                                         ButtonStyle.Success, new Emoji("✅"))
							 );
			await this.FollowupAsync(LanguageManager.Languages[this.Context.Guild.PreferredLocale].DiscordCountChannelOverwriteQuestion, components: components.Build());
		}
		else {
			DeveBot.Discord.Database.Insert("count_channels", new Dictionary<string, object> {{"id", channel.Id}, {"guild", channel.Guild.Id}, {"type", type}, {"prefix", prefix}, {"postfix", postfix}});

			if (!string.IsNullOrWhiteSpace(prefix))  prefix  += ": ";
			if (!string.IsNullOrWhiteSpace(postfix)) postfix =  " " + postfix;
			switch (type) {
				case CountChannelType.Members:
					await channel.ModifyAsync(c => c.Name = $"{prefix}{DeveBot.Discord.CountMembers(channel.Guild)}{postfix}");
					break;
				case CountChannelType.Followers:
					break;
				case CountChannelType.Subscribers:
					break;
			}
			
			await this.FollowupAsync($"{LanguageManager.Languages[this.Context.Guild.PreferredLocale].DiscordCountChannelSet}:\n> *{channel.Name}*");
		}
	}
}
