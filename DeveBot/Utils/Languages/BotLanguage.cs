using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Develeon64.Bots.DeveBot.Utils.Languages;


[JsonObject(ItemRequired = Required.Default,
		    MemberSerialization = MemberSerialization.OptOut,
		    NamingStrategyType = typeof(SnakeCaseNamingStrategy)
		   )]
public struct BotLanguage {
	public BotLanguage () { }

	public string DiscordCountChannelKeep              { get; set; } = "No, keep it!";
	public string DiscordCountChannelOverwrite         { get; set; } = "Yes, overwrite!";
	public string DiscordCountChannelOverwriteQuestion { get; set; } = "The channel is set to count something already. Should it be overwritten?";
	public string DiscordCountChannelSet               { get; set; } = "Your count channel has been set";

	public string DiscordRulesGeneral { get; set; } =
		"Here are the rules for this Discord server.\nPlease keep in mind, that in addition to these rules the ***[Discord ToS](https://discord.com/terms)***, ***[Community Guidelines](https://discord.com/guidelines)***, all official ***Laws*** and ***common sense*** apply!\n\nPlease click below to accept the rules and unlock the full server.";

	public string DiscordRulesOk                 { get; set; } = "Ok, added";
	public string DiscordRulesEditOnlyExisting   { get; set; } = "You can only edit existing rules!";
	public string DiscordRulesEditedFirst        { get; set; } = "Rule";
	public string DiscordRulesEditedSecond       { get; set; } = "is edited from";
	public string DiscordRulesEditedThird        { get; set; } = "to";
	public string DiscordRulesDeleteOnlyExisting { get; set; } = "You can only delete existing rules!";
	public string DiscordRulesDeletedFirst       { get; set; } = "Rule";
	public string DiscordRulesDeletedSecond      { get; set; } = "is now deleted";
	public string DiscordRulesRoleSet            { get; set; } = "Role has been set!";
	public string DiscordRulesTitle              { get; set; } = "Server-Rules";
	public string DiscordRulesAccept             { get; set; } = "Accept rules";
	public string DiscordRulesDecline            { get; set; } = "Decline rules";
	public string DiscordRulesNewAnnouncement    { get; set; } = "These are the new server rules";
	public string DiscordRulesNoCommunity        { get; set; } = "Community is not enabled on this server.\nPlease go to the server settings to enable Community.";
	public string DiscordRulesNoRole             { get; set; } = "You haven't selected a role to give accepting members. Set a role with";
	public string DiscordRulesNoManage           { get; set; } = "The bot doesn't have the rights to manage the roles of members!";
	public string DiscordRulesHigherRole         { get; set; } = "The highest role of the bot must be higher than the role for accepted members!";
	public string DiscordRulesAcceptThanks       { get; set; } = "Thanks for accepting the rules. You can now start to interact with the server!";
	public string DiscordRulesNoKick             { get; set; } = "The bot doesn't have the rights to kick members!";
	public string DiscordRulesDeclineKick        { get; set; } = "You have been kicked from the server, because you declined the rules.";
}
