using Develeon64.Bots.DeveBot.Utils.Languages;

using Newtonsoft.Json;

namespace Develeon64.Bots.DeveBot.Utils.Managers;


public static class LanguageManager {
	private const  string      LangPath = "Var/Lang";
	private static BotLanguage Default { get; } = new();
	public static readonly Dictionary<string, BotLanguage> Languages = new() {
		{"en-GB", LanguageManager.Default},
		{"en-US", LanguageManager.Default},
		{"es-ES", (File.Exists($"{LanguageManager.LangPath}/es-ES.json") ? JsonConvert.DeserializeObject<BotLanguage>(File.ReadAllText($"{LanguageManager.LangPath}/es-ES.json", Encoding.UTF8), ConfigManager.Static.JsonSettings) : LanguageManager.Default)!},
		{"pt-BR", (File.Exists($"{LanguageManager.LangPath}/pt-BR.json") ? JsonConvert.DeserializeObject<BotLanguage>(File.ReadAllText($"{LanguageManager.LangPath}/pt-BR.json", Encoding.UTF8), ConfigManager.Static.JsonSettings) : LanguageManager.Default)!},
		{"sv-SE", (File.Exists($"{LanguageManager.LangPath}/sv-SE.json") ? JsonConvert.DeserializeObject<BotLanguage>(File.ReadAllText($"{LanguageManager.LangPath}/sv-SE.json", Encoding.UTF8), ConfigManager.Static.JsonSettings) : LanguageManager.Default)!},
		{"zh-CN", (File.Exists($"{LanguageManager.LangPath}/zh-CN.json") ? JsonConvert.DeserializeObject<BotLanguage>(File.ReadAllText($"{LanguageManager.LangPath}/zh-CN.json", Encoding.UTF8), ConfigManager.Static.JsonSettings) : LanguageManager.Default)!},
		{"zh-TW", (File.Exists($"{LanguageManager.LangPath}/zh-TW.json") ? JsonConvert.DeserializeObject<BotLanguage>(File.ReadAllText($"{LanguageManager.LangPath}/zh-TW.json", Encoding.UTF8), ConfigManager.Static.JsonSettings) : LanguageManager.Default)!},
		{"bg", (File.Exists($"{LanguageManager.LangPath}/bg-BG.json") ? JsonConvert.DeserializeObject<BotLanguage>(File.ReadAllText($"{LanguageManager.LangPath}/bg-BG.json", Encoding.UTF8), ConfigManager.Static.JsonSettings) : LanguageManager.Default)!},
		{"cs", (File.Exists($"{LanguageManager.LangPath}/cs-CZ.json") ? JsonConvert.DeserializeObject<BotLanguage>(File.ReadAllText($"{LanguageManager.LangPath}/cs-CZ.json", Encoding.UTF8), ConfigManager.Static.JsonSettings) : LanguageManager.Default)!},
		{"da", (File.Exists($"{LanguageManager.LangPath}/da-DK.json") ? JsonConvert.DeserializeObject<BotLanguage>(File.ReadAllText($"{LanguageManager.LangPath}/da-DK.json", Encoding.UTF8), ConfigManager.Static.JsonSettings) : LanguageManager.Default)!},
		{"de", (File.Exists($"{LanguageManager.LangPath}/de-DE.json") ? JsonConvert.DeserializeObject<BotLanguage>(File.ReadAllText($"{LanguageManager.LangPath}/de-DE.json", Encoding.UTF8), ConfigManager.Static.JsonSettings) : LanguageManager.Default)!},
		{"el", (File.Exists($"{LanguageManager.LangPath}/el-GR.json") ? JsonConvert.DeserializeObject<BotLanguage>(File.ReadAllText($"{LanguageManager.LangPath}/el-GR.json", Encoding.UTF8), ConfigManager.Static.JsonSettings) : LanguageManager.Default)!},
		{"fi", (File.Exists($"{LanguageManager.LangPath}/fi-FI.json") ? JsonConvert.DeserializeObject<BotLanguage>(File.ReadAllText($"{LanguageManager.LangPath}/fi-FI.json", Encoding.UTF8), ConfigManager.Static.JsonSettings) : LanguageManager.Default)!},
		{"fr", (File.Exists($"{LanguageManager.LangPath}/fr-FR.json") ? JsonConvert.DeserializeObject<BotLanguage>(File.ReadAllText($"{LanguageManager.LangPath}/fr-FR.json", Encoding.UTF8), ConfigManager.Static.JsonSettings) : LanguageManager.Default)!},
		{"hi", (File.Exists($"{LanguageManager.LangPath}/hi-IN.json") ? JsonConvert.DeserializeObject<BotLanguage>(File.ReadAllText($"{LanguageManager.LangPath}/hi-IN.json", Encoding.UTF8), ConfigManager.Static.JsonSettings) : LanguageManager.Default)!},
		{"hr", (File.Exists($"{LanguageManager.LangPath}/hr-HR.json") ? JsonConvert.DeserializeObject<BotLanguage>(File.ReadAllText($"{LanguageManager.LangPath}/hr-HR.json", Encoding.UTF8), ConfigManager.Static.JsonSettings) : LanguageManager.Default)!},
		{"hu", (File.Exists($"{LanguageManager.LangPath}/hu-HU.json") ? JsonConvert.DeserializeObject<BotLanguage>(File.ReadAllText($"{LanguageManager.LangPath}/hu-HU.json", Encoding.UTF8), ConfigManager.Static.JsonSettings) : LanguageManager.Default)!},
		{"id", (File.Exists($"{LanguageManager.LangPath}/id-ID.json") ? JsonConvert.DeserializeObject<BotLanguage>(File.ReadAllText($"{LanguageManager.LangPath}/id-ID.json", Encoding.UTF8), ConfigManager.Static.JsonSettings) : LanguageManager.Default)!},
		{"it", (File.Exists($"{LanguageManager.LangPath}/it-IT.json") ? JsonConvert.DeserializeObject<BotLanguage>(File.ReadAllText($"{LanguageManager.LangPath}/it-IT.json", Encoding.UTF8), ConfigManager.Static.JsonSettings) : LanguageManager.Default)!},
		{"ja", (File.Exists($"{LanguageManager.LangPath}/ja-JP.json") ? JsonConvert.DeserializeObject<BotLanguage>(File.ReadAllText($"{LanguageManager.LangPath}/ja-JP.json", Encoding.UTF8), ConfigManager.Static.JsonSettings) : LanguageManager.Default)!},
		{"ko", (File.Exists($"{LanguageManager.LangPath}/ko-KR.json") ? JsonConvert.DeserializeObject<BotLanguage>(File.ReadAllText($"{LanguageManager.LangPath}/ko-KR.json", Encoding.UTF8), ConfigManager.Static.JsonSettings) : LanguageManager.Default)!},
		{"lt", (File.Exists($"{LanguageManager.LangPath}/lt-LT.json") ? JsonConvert.DeserializeObject<BotLanguage>(File.ReadAllText($"{LanguageManager.LangPath}/lt-LT.json", Encoding.UTF8), ConfigManager.Static.JsonSettings) : LanguageManager.Default)!},
		{"nl", (File.Exists($"{LanguageManager.LangPath}/nl-NL.json") ? JsonConvert.DeserializeObject<BotLanguage>(File.ReadAllText($"{LanguageManager.LangPath}/nl-NL.json", Encoding.UTF8), ConfigManager.Static.JsonSettings) : LanguageManager.Default)!},
		{"no", (File.Exists($"{LanguageManager.LangPath}/nn-NO.json") ? JsonConvert.DeserializeObject<BotLanguage>(File.ReadAllText($"{LanguageManager.LangPath}/nn-NO.json", Encoding.UTF8), ConfigManager.Static.JsonSettings) : LanguageManager.Default)!},
		{"pl", (File.Exists($"{LanguageManager.LangPath}/pl-PL.json") ? JsonConvert.DeserializeObject<BotLanguage>(File.ReadAllText($"{LanguageManager.LangPath}/pl-PL.json", Encoding.UTF8), ConfigManager.Static.JsonSettings) : LanguageManager.Default)!},
		{"ro", (File.Exists($"{LanguageManager.LangPath}/ro-RO.json") ? JsonConvert.DeserializeObject<BotLanguage>(File.ReadAllText($"{LanguageManager.LangPath}/ro-RO.json", Encoding.UTF8), ConfigManager.Static.JsonSettings) : LanguageManager.Default)!},
		{"ru", (File.Exists($"{LanguageManager.LangPath}/ru-RU.json") ? JsonConvert.DeserializeObject<BotLanguage>(File.ReadAllText($"{LanguageManager.LangPath}/ru-RU.json", Encoding.UTF8), ConfigManager.Static.JsonSettings) : LanguageManager.Default)!},
		{"th", (File.Exists($"{LanguageManager.LangPath}/th-TH.json") ? JsonConvert.DeserializeObject<BotLanguage>(File.ReadAllText($"{LanguageManager.LangPath}/th-TH.json", Encoding.UTF8), ConfigManager.Static.JsonSettings) : LanguageManager.Default)!},
		{"tr", (File.Exists($"{LanguageManager.LangPath}/tr-TR.json") ? JsonConvert.DeserializeObject<BotLanguage>(File.ReadAllText($"{LanguageManager.LangPath}/tr-TR.json", Encoding.UTF8), ConfigManager.Static.JsonSettings) : LanguageManager.Default)!},
		{"uk", (File.Exists($"{LanguageManager.LangPath}/uk-UA.json") ? JsonConvert.DeserializeObject<BotLanguage>(File.ReadAllText($"{LanguageManager.LangPath}/uk-UA.json", Encoding.UTF8), ConfigManager.Static.JsonSettings) : LanguageManager.Default)!},
		{"vi", (File.Exists($"{LanguageManager.LangPath}/vi-VN.json") ? JsonConvert.DeserializeObject<BotLanguage>(File.ReadAllText($"{LanguageManager.LangPath}/vi-VN.json", Encoding.UTF8), ConfigManager.Static.JsonSettings) : LanguageManager.Default)!},
	};

	public static void Initialize () {
		foreach (string language in LanguageManager.Languages.Keys) {
			foreach (FieldInfo info in typeof(BotLanguage).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)) {
				if (!string.IsNullOrWhiteSpace(info.GetValue(LanguageManager.Languages[language]) as string)) continue;

				object lang = LanguageManager.Languages[language];
				info.SetValue(lang, info.GetValue(LanguageManager.Default));
				LanguageManager.Languages[language] = (BotLanguage)lang;
			}
		}
	}
}
