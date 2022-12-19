using Discord.Interactions;

namespace Develeon64.Bots.DeveBot.Modules.Discord.Commands.Types;


public enum CountChannelType {
	[ChoiceDisplay("Server Members")]
	Members,

	[ChoiceDisplay("Twitch Followers")]
	Followers,

	[ChoiceDisplay("Twitch Subscribers")]
	Subscribers,
}
