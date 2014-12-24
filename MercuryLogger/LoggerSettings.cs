using System;

namespace MercuryLogger
{
	public class LoggerSettings
	{
		public string FilePath { get; set;}
		public bool ImmediateStdOutLogging { get; set; }
		public bool LogToStdOut { get; set; }
		public LogLevel HighestLevelToStdOut { get; set; }
		public LogLevel HighestLevelToFile { get; set; }
		public int BufferSize { get; set; }

		public LoggerSettings(){
			this.FilePath = "log.log"; 
			this.ImmediateStdOutLogging = false; 
			this.LogToStdOut = true; 
			this.HighestLevelToFile = LogLevel.VERBOSE; 
			this.HighestLevelToStdOut = LogLevel.WARNING;
			this.BufferSize = 10; 
		}

	}
}

