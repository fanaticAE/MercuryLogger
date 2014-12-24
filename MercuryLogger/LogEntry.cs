using System;

namespace MercuryLogger
{
	public class LogEntry
	{
		LogLevel Level { get; set; }
		DateTime DateTime {get; set;}
		string Tag {get; set;}
		string Message { get; set; }
		Exception Exception {get; set;}

		public LogEntry ()
		{
			Level = LogLevel.VERBOSE; 
			DateTime = DateTime.Now; 
			Tag = ""; 
			Message = ""; 
			Exception = null; 
		}
		
		public LogEntry(LogLevel Level, string Tag, string Message, Exception Exception = null){
			this.Level = Level; 
			this.DateTime = DateTime.UtcNow; 
			this.Tag = Tag; 
			this.Message = Message; 
			this.Exception = Exception; 
		}

	}
}

