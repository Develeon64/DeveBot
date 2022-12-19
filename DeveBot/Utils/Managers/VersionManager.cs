// ReSharper disable All

namespace Develeon64.Bots.DeveBot.Utils.Managers;


public static class VersionManager {
	public static  string Prefix       { get; } = "v";
	public static  short  MajorVersion { get; } = 1;
	public static  short  MinorVersion { get; } = 0;
	public static  short  PatchVersion { get; } = 0;
	public static  string PreVersion   { get; } = "pre_alpha";
	private static string BuildVersion { get; } = "1";

	public static string FullVersion =>
		$"{Prefix}{MajorVersion}.{MinorVersion}.{PatchVersion}{(!String.IsNullOrWhiteSpace(PreVersion) ? "-" : String.Empty)}{PreVersion}{(!String.IsNullOrWhiteSpace(BuildVersion) ? "+" : String.Empty)}{BuildVersion}";

	public static string ReleaseVersion => $"{Prefix}{MajorVersion}.{MinorVersion}.{PatchVersion}";
}
