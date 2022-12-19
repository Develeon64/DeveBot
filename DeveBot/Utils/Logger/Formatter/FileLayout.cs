// ReSharper disable BuiltInTypeReferenceStyleForMemberAccess

using log4net.Core;
using log4net.Layout;

namespace Develeon64.Bots.DeveBot.Utils.Logger.Formatter;


public class FileLayout : ILayout {
	public string ContentType      { get; } = "text/plain";
	public string Header           { get; } = String.Empty;
	public string Footer           { get; } = String.Empty;
	public bool   IgnoresException { get; } = false;

	public void Format (TextWriter writer, LoggingEvent entry) {
		const string separator = " | ";

		StringBuilder message = new(entry.TimeStamp.ToString("dd.MM.yyyy HH:mm:ss"));
		message.Append(separator);
		message.Append(entry.LoggerName.PadRight(10)[..10]);
		message.Append(separator);
		message.Append(entry.Level.DisplayName.PadRight(5)[..5]);
		message.Append(separator);
		message.Append(entry.RenderedMessage);

		if (entry.ExceptionObject is not null) {
			message.Append(separator);
			message.Append(entry.ExceptionObject.Message);

			if (entry.ExceptionObject.StackTrace is not null) {
				message.Append(" | ");
				message.Append(entry.ExceptionObject.StackTrace.ReplaceLineEndings(" +"));
			}
		}

		message.Append('\n');
		writer.Write(message.ToString());
	}
}
