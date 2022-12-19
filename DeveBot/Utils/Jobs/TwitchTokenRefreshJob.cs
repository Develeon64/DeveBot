using FluentScheduler;

namespace Develeon64.Bots.DeveBot.Utils.Jobs;


public abstract class TwitchTokenRefreshJob : IJob {
	public async void Execute () {
		//await DeveBot.Twitch.ValidateTokens()!;
	}
}
