using FluentScheduler;

namespace Develeon64.Bots.DeveBot.Utils.Jobs;


public abstract class DiscordPresenceJob : IJob {
	public async void Execute () { await DeveBot.Discord.SetPresence()!; }
}
