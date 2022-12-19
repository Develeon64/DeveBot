// ReSharper disable MemberCanBePrivate.Global

using Discord;

namespace Develeon64.Bots.DeveBot.Utils;


public class DiscordEmbedBuilder : EmbedBuilder {
	private static char BlankChar { get; } = '\u200b';

	public DiscordEmbedBuilder (IUser? author = null) {
		if (author != null) this.WithAuthor(author);
		this.WithBlueColor();
		this.WithFooter(DeveBot.Discord.Programmer?.Username, DeveBot.Discord.Programmer?.GetAvatarUrl());
		this.WithCurrentTimestamp();
	}

	public DiscordEmbedBuilder AddBlankField (bool inline = false) {
		this.AddField(DiscordEmbedBuilder.BlankChar.ToString(), DiscordEmbedBuilder.BlankChar, inline);
		return this;
	}

	public DiscordEmbedBuilder WithBlueColor () {
		this.WithColor(63, 127, 191);
		return this;
	}

	public DiscordEmbedBuilder WithLimeColor () {
		this.WithColor(63, 191, 127);
		return this;
	}

	public DiscordEmbedBuilder WithPurpleColor () {
		this.WithColor(127, 63, 191);
		return this;
	}

	public DiscordEmbedBuilder WithPinkColor () {
		this.WithColor(191, 63, 127);
		return this;
	}

	public DiscordEmbedBuilder WithGreenColor () {
		this.WithColor(127, 191, 63);
		return this;
	}

	public DiscordEmbedBuilder WithYellowColor () {
		this.WithColor(191, 127, 63);
		return this;
	}

	public DiscordEmbedBuilder WithDarkColor () {
		this.WithColor(63, 63, 63);
		return this;
	}

	public DiscordEmbedBuilder WithGreyColor () {
		this.WithColor(127, 127, 127);
		return this;
	}

	public DiscordEmbedBuilder WithLightColor () {
		this.WithColor(191, 191, 191);
		return this;
	}
}
