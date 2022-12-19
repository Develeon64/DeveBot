using Develeon64.Bots.DeveBot.Utils.Jobs;

using FluentScheduler;

namespace Develeon64.Bots.DeveBot.Utils.Managers;


public class JobScheduler : Registry {
	public JobScheduler () {
		this.Schedule<TwitchTokenRefreshJob>().ToRunEvery(5).Minutes();
		this.Schedule<DiscordPresenceJob>().ToRunEvery(5).Minutes();
	}
}
